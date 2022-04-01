Imports Telerik.Web.UI
Imports System.Math
Imports System.Configuration.ConfigurationManager
Imports System.Configuration
Imports System.Data.SqlClient
Partial Public Class BusquedaBenchClima
    Inherits System.Web.UI.Page
    Dim Mult As Double = 0.0
    Dim Sum As Double = 0.0
    Dim Con As Integer = 0
    Dim SumPersonasEmpresa As Integer = 0
    Dim SumPersonasEncuesta As Integer = 0
    Dim MultAL As Double = 0.0
    Dim SumAL As Double = 0.0
    Dim MultJI As Double = 0.0
    Dim SumJI As Double = 0.0
    Dim MultCS As Double = 0.0
    Dim SumCS As Double = 0.0
    Dim SumPersonasAL As Integer = 0

    Protected Overrides Sub InitializeCulture()
        If Not Session("Lenguaje") Is Nothing Then
            UICulture = Session("Lenguaje")
            Culture = Session("Lenguaje")
        End If
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CON") = "OK" Then
            If Not Page.IsPostBack Then
                RCBUnidad.Items.Clear()
                RCBAgrupadoPaises.Items.Clear()
                RCBPais.Items.Clear()
                RCBRegion.Items.Clear()
                RCBSubRegion.Items.Clear()
                CargarDivision()
                'RadMenu1.Items(3).Selected = True

                'Dim SEN As String
                'SEN = "SELECT DISTINCT ANIOESTUDIO, ANIOESTUDIO AS AÑO FROM TBLHISTORIA_EMPRESA WHERE ANIOESTUDIO>0 ORDER BY ANIOESTUDIO DESC"
                'Cargar.ComboSentenciaTxt(RCBAño, SEN, "ANIOESTUDIO", "AÑO")

                Dim ds As New DataSet
                Dim P(0) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 1)
                ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


                RCBAño.DataSource = ds.Tables(0)
                RCBAño.DataTextField = "ANIOESTUDIO"
                RCBAño.DataValueField = "AÑO"
                RCBAño.DataBind()

            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Sub CargarDivision()
        Dim PLoad(1) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 0)
        PLoad(1) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBUnidad, "[Sp_CargaEstructura]", PLoad, "NOMDIVISION", "CVEDIVISION", 1, True, Session("Lenguaje"))

        If RCBUnidad.Enabled = False Then
            CargarAgrupadoPaises()
            'Llenargrid_Dinamico()
        End If
    End Sub

    Protected Sub RCBUnidad_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBUnidad.SelectedIndexChanged
        Label6.Visible = False
        RadioButtonList1.Visible = False
        Session("TipoEmpleado") = "Empleado"

        If RCBUnidad.SelectedValue = -1 Then
            Server.Transfer("BusquedaBenchClima.aspx")
        Else
            RCBAgrupadoPaises.Items.Clear()
            RCBPais.Items.Clear()
            RCBTerritorio.Items.Clear()
            RCBRegion.Items.Clear()
            RCBSubRegion.Items.Clear()
            RCBAgrupadoPaises.Text = ""
            RCBPais.Text = ""
            RCBTerritorio.Text = ""
            RCBRegion.Text = ""
            RCBSubRegion.Text = ""

            RCBAgrupadoPaises.Enabled = False
            RCBPais.Enabled = False
            RCBRegion.Enabled = False
            RCBSubRegion.Enabled = False

            CargarAgrupadoPaises()
            'Llenargrid_Dinamico()
        End If
    End Sub

    Protected Sub RcboTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim RCboTop As RadComboBox = DirectCast(sender, RadComboBox)
        Session("SesTipoOperacion") = RCboTop.SelectedValue
        Session("SesNomTipoOperacion") = RCboTop.Text
        Llenargrid_Dinamico()
    End Sub

    Sub CargarAgrupadoPaises()
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 1)
        PLoad(1) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBAgrupadoPaises, "[Sp_CargaEstructura]", PLoad, "NOMAGRUPADO", "CVEAGRUPADO", 1, True, Session("Lenguaje"))

        If RCBAgrupadoPaises.Items.Count = 2 Then 'Solo hay un Agrupado Paises
            CargarPaises()
        End If
    End Sub

    Protected Sub RCBAgrupadoPaises_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBAgrupadoPaises.SelectedIndexChanged
        Label6.Visible = False
        RadioButtonList1.Visible = False
        Session("TipoEmpleado") = "Empleado"

        RCBPais.Items.Clear()
        RCBTerritorio.Items.Clear()
        RCBRegion.Items.Clear()
        RCBSubRegion.Items.Clear()
        RCBPais.Text = ""
        RCBTerritorio.Text = ""
        RCBRegion.Text = ""
        RCBSubRegion.Text = ""

        RCBPais.Enabled = False
        RCBRegion.Enabled = False
        RCBSubRegion.Enabled = False

        CargarPaises()
        'Llenargrid_Dinamico()
    End Sub

    Sub CargarPaises()
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 2)
        PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", RCBAgrupadoPaises.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBPais, "[Sp_CargaEstructura]", PLoad, "PAIS", "CVEPAIS", 1, True, Session("Lenguaje"))

        If RCBPais.Items.Count = 2 Then
            CargarTerritorios()
        End If
    End Sub

    Protected Sub RCBPais_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBPais.SelectedIndexChanged
        Label6.Visible = False
        RadioButtonList1.Visible = False
        Session("TipoEmpleado") = "Empleado"

        RCBTerritorio.Items.Clear()
        RCBRegion.Items.Clear()
        RCBSubRegion.Items.Clear()
        RCBTerritorio.Text = ""
        RCBRegion.Text = ""
        RCBSubRegion.Text = ""

        RCBRegion.Enabled = False
        RCBSubRegion.Enabled = False

        CargarTerritorios()
        'Llenargrid_Dinamico()
    End Sub

    Sub CargarTerritorios()
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 3)
        PLoad(1) = New SqlParameter("@CVEPAIS", RCBPais.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBTerritorio, "[Sp_CargaEstructura]", PLoad, "TERRITORIO", "CVETERRITORIO", 1, True, Session("Lenguaje"))

        If RCBTerritorio.Enabled = False Then
            CargarRegiones()
        End If

        If RCBUnidad.SelectedValue = 6 Then
            RadioButtonList1.Items(1).Text = "Líder"
            Label6.Visible = False
            RadioButtonList1.Visible = True
            Session("TipoEmpleado") = "Empleado"
        ElseIf (RCBUnidad.SelectedValue = 2 And RCBPais.SelectedValue = 11) Or RCBUnidad.SelectedValue = 13 Then 'Filipinas / Grafo
            RadioButtonList1.Items(1).Text = "Otros"
            RadioButtonList1.SelectedValue = 2
            Label6.Visible = False
            RadioButtonList1.Visible = False
            Session("TipoEmpleado") = "Lider"
        Else
            RadioButtonList1.SelectedValue = 1
            Label6.Visible = False
            RadioButtonList1.Visible = False
            Session("TipoEmpleado") = "Empleado"
        End If
    End Sub

    Protected Sub RCBTerritorio_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RCBTerritorio.SelectedIndexChanged
        RCBRegion.Items.Clear()
        RCBSubRegion.Items.Clear()
        RCBRegion.Text = ""
        RCBSubRegion.Text = ""

        RCBRegion.Enabled = False
        RCBSubRegion.Enabled = False

        CargarRegiones()
        'LlenarGrid()

    End Sub

    Sub CargarRegiones()
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 4)
        PLoad(1) = New SqlParameter("@CVETERRITORIO", RCBTerritorio.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBRegion, "[Sp_CargaEstructura]", PLoad, "NOMREGION", "CVEREGION", 1, True, Session("Lenguaje"))

        If RCBRegion.Enabled = False Then
            CargarSubRegiones()
        End If

        If RCBUnidad.SelectedValue = 6 Then
            RadioButtonList1.Items(1).Text = "Líder"
            Label6.Visible = False
            RadioButtonList1.Visible = True
            Session("TipoEmpleado") = "Empleado"
        ElseIf (RCBUnidad.SelectedValue = 2 And RCBPais.SelectedValue = 11) Or RCBUnidad.SelectedValue = 13 Then 'Filipinas / Grafo
            RadioButtonList1.Items(1).Text = "Otros"
            RadioButtonList1.SelectedValue = 2
            Label6.Visible = False
            RadioButtonList1.Visible = False
            Session("TipoEmpleado") = "Lider"
        Else
            RadioButtonList1.SelectedValue = 1
            Label6.Visible = False
            RadioButtonList1.Visible = False
            Session("TipoEmpleado") = "Empleado"
        End If
    End Sub

    Protected Sub RCBRegion_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBRegion.SelectedIndexChanged
        RCBSubRegion.Items.Clear()
        RCBSubRegion.Text = ""
        RCBSubRegion.Enabled = False

        CargarSubRegiones()
        'Llenargrid_Dinamico()
    End Sub

    Sub CargarSubRegiones()
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 5)
        PLoad(1) = New SqlParameter("@CVEREGION", RCBRegion.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBSubRegion, "[Sp_CargaEstructura]", PLoad, "NOMSUBREGION", "CVESUBREGION", 1, True, Session("Lenguaje"))
    End Sub

    Protected Sub RCBSubRegion_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBSubRegion.SelectedIndexChanged
        'Llenargrid_Dinamico()
    End Sub

    Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.CommandItem Then
            If RCBUnidad.SelectedValue <> "-1" Or RCBUnidad.SelectedValue <> "" Then
                Dim GIC As GridCommandItem = DirectCast(e.Item, GridCommandItem)
                Dim RD As RadComboBox = DirectCast(GIC.FindControl("RcboTipoOperacion"), RadComboBox)
                RD.Items.Clear()
                RD.Enabled = True

                Dim PLoad(3) As SqlParameter
                PLoad(0) = New SqlParameter("@TIPO", 7)
                PLoad(1) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
                PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
                PLoad(3) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
                'Dim DS As DataSet = DatosBDCubo.FuncionConPar("[Sp_CargaEstructura]", PLoad, "")

                Cargar.ComboParametros(RD, "[Sp_CargaEstructura]", PLoad, "NomArea", "CveArea", 1, True)

                If Not Session("SesTipoOperacion") Is Nothing Then
                    RD.FindItemByValue(Session("SesTipoOperacion")).Selected = True
                End If
            End If
        ElseIf e.Item.ItemType = GridItemType.Header Then

        ElseIf e.Item.ItemType = GridItemType.AlternatingItem OrElse e.Item.ItemType = GridItemType.Item Then
            For N As Integer = 7 To e.Item.Cells.Count - 1
                If IsNumeric(e.Item.Cells(N).Text) Then
                    e.Item.Cells(N).BackColor = GETCOLOR(e.Item.Cells(N).Text)
                    e.Item.Cells(N).ForeColor = GETCOLOR2(e.Item.Cells(N).Text)
                End If
            Next
        ElseIf e.Item.ItemType = GridItemType.Footer Then
            Dim DSet As DataSet
            DSet = CType(Session("DSGeneral"), DataSet)

            If DSet.Tables(1).Rows.Count > 0 Then
                e.Item.Cells(3).Text = "Total"
                e.Item.Cells(5).Text = DSet.Tables(1).Rows(0).Item(0)
                e.Item.Cells(6).Text = DSet.Tables(1).Rows(0).Item(1)

                'If DSet.Tables(0).Rows.Count = 1 Then
                'e.Item.Cells(10).Text = CDbl(DSet.Tables(1).Rows(0).Item(5)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'CO  
                'ElseIf DSet.Tables(0).Rows.Count = 2 Then
                '   e.Item.Cells(9).Text = CDbl(DSet.Tables(1).Rows(0).Item(4)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'CS
                '  e.Item.Cells(10).Text = CDbl(DSet.Tables(1).Rows(0).Item(5)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'CO  
                'ElseIf DSet.Tables(0).Rows.Count >= 3 Then
                e.Item.Cells(7).Text = CDbl(DSet.Tables(1).Rows(0).Item(2)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'AL
                e.Item.Cells(8).Text = CDbl(DSet.Tables(1).Rows(0).Item(3)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'JI
                e.Item.Cells(9).Text = CDbl(DSet.Tables(1).Rows(0).Item(4)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'CS
                e.Item.Cells(10).Text = CDbl(DSet.Tables(1).Rows(0).Item(5)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'CO  
                ' End If
        End If
        End If
    End Sub

    Function GETCOLOR(ByVal Numero As Double) As System.Drawing.Color
        If Numero = 0 Then
            Return Drawing.Color.Gray
        ElseIf Numero > 0 And Numero <= 69.999999 Then
            Return Drawing.Color.DarkRed
        ElseIf Numero >= 70.0 And Numero <= 79.999999 Then
            Return Drawing.Color.Goldenrod
        ElseIf Numero >= 80.0 And Numero <= 89.999999 Then
            Return Drawing.Color.DarkBlue
        Else
            Return Drawing.Color.DarkGreen
        End If
    End Function

    Function GETCOLOR2(ByVal Numero As Double) As System.Drawing.Color
        If Numero = 0 Then
            Return Drawing.Color.White
        ElseIf Numero > 0 And Numero <= 69.999999 Then
            Return Drawing.Color.White
        ElseIf Numero >= 70.0 And Numero <= 79.999999 Then
            Return Drawing.Color.Black
        ElseIf Numero >= 80.0 And Numero <= 89.999999 Then
            Return Drawing.Color.White
        Else
            Return Drawing.Color.White
        End If
    End Function

    Private Sub RadGrid1_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        Llenargrid_Dinamico()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedIndex = 0 Then 'RadioButtonList1.Items(0).Selected = True Then
            'empleados
            Session("TipoEmpleado") = "Empleado"
            'Llenargrid_Dinamico()
        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            'lider
            Session("TipoEmpleado") = "Lider"
            'Llenargrid_Dinamico()
        End If
    End Sub

    Sub Llenargrid_Dinamico()
        Lerror.Text = ""
        Dim ds As New DataSet
        Dim PLoad(10) As SqlParameter
        Try
            If RCBUnidad.SelectedValue = "-1" Or RCBUnidad.SelectedValue = "" Then
                Session("CveUnidad") = DBNull.Value
                PLoad(0) = New SqlParameter("@CVEDIVISION", DBNull.Value)
            Else
                Session("CveUnidad") = RCBUnidad.SelectedValue
                PLoad(0) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
            End If

            If RCBAgrupadoPaises.SelectedValue = "-1" Or RCBAgrupadoPaises.SelectedValue = "" Then
                Session("CveAgrupado") = DBNull.Value
                PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", DBNull.Value)
            Else
                Session("CveAgrupado") = RCBAgrupadoPaises.SelectedItem.Value
                PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", RCBAgrupadoPaises.SelectedValue)
            End If

            If RCBPais.SelectedValue = "-1" Or RCBPais.SelectedValue = "" Then
                Session("CvePais") = DBNull.Value
                PLoad(2) = New SqlParameter("@CVEPAIS", DBNull.Value)
            Else
                Session("CvePais") = RCBPais.SelectedItem.Value
                PLoad(2) = New SqlParameter("@CVEPAIS", RCBPais.SelectedValue)
            End If

            'Meter concepto area
            If Session("SesTipoOperacion") Is Nothing Or Session("SesTipoOperacion") = "-1" Then
                'If RCBTipoEmpresa.SelectedValue = "-1" Or RCBTipoEmpresa.SelectedValue = "" Then
                Session("CveTipo") = DBNull.Value
                PLoad(3) = New SqlParameter("@CVEAREA", DBNull.Value)
            Else
                Session("CveTipo") = Session("SesTipoOperacion")
                PLoad(3) = New SqlParameter("@CVEAREA", Session("SesTipoOperacion"))
            End If

            If RCBTerritorio.SelectedValue = "-1" Or RCBTerritorio.SelectedValue = "" Then
                Session("CveTerritorio") = DBNull.Value
                PLoad(4) = New SqlParameter("@CVETERRITORIO", DBNull.Value)
            Else
                Session("CveTerritorio") = RCBTerritorio.SelectedItem.Value
                PLoad(4) = New SqlParameter("@CVETERRITORIO", RCBTerritorio.SelectedValue)
            End If

            If RCBRegion.SelectedValue = "-1" Or RCBRegion.SelectedValue = "" Then
                Session("CveRegion") = DBNull.Value
                PLoad(5) = New SqlParameter("@CVEREGION", DBNull.Value)
            Else
                Session("CveRegion") = RCBRegion.SelectedItem.Value
                PLoad(5) = New SqlParameter("@CVEREGION", RCBRegion.SelectedValue)
            End If

            If RCBSubRegion.SelectedValue = "-1" Or RCBSubRegion.SelectedValue = "" Then
                Session("CveSubRegion") = DBNull.Value
                PLoad(6) = New SqlParameter("@CVESUBREGION", DBNull.Value)
            Else
                Session("CveSubRegion") = RCBSubRegion.SelectedItem.Value
                PLoad(6) = New SqlParameter("@CVESUBREGION", RCBSubRegion.SelectedValue)
            End If

            If RadioButtonList1.SelectedIndex = 1 Then
                Session("CveSistema") = 13
                PLoad(7) = New SqlParameter("@CVESISTEMA", 13)
            Else
                Session("CveSistema") = 3
                PLoad(7) = New SqlParameter("@CVESISTEMA", 3)
            End If

            PLoad(8) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(9) = New SqlParameter("@USUARIO", Session("USUARIO"))
            PLoad(10) = New SqlParameter("@ANIOESTUDIO", RCBAño.SelectedValue)

            ds = DatosBD.FuncionConPar("SP_BUSQUEDA_BENCHMARK_CLIMA", PLoad, Lerror.Text)
            Session("DSGeneral") = ds

            If ds.Tables(0).Rows.Count > 0 Then
                RadGrid1.DataSource = ds.Tables(0)
                RadGrid1.DataBind()
            Else
                RadGrid1.DataSource = Nothing
                RadGrid1.DataBind()
                Lerror.Text = "No hay información con los filtros seleccionados."
            End If

        Catch ex As Exception
            Lerror.Text = ex.Message '& " " & ex.StackTrace
        End Try
    End Sub

    Protected Sub BFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BFiltrar.Click
        Session("SesTipoOperacion") = Nothing
        Llenargrid_Dinamico()
    End Sub

    Sub Exportar()
        RadGrid1.MasterTableView.ExportToExcel()
    End Sub
End Class
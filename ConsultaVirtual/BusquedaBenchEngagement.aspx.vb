Imports Telerik.Web.UI
Imports System.Math
Imports System.Configuration.ConfigurationManager
Imports System.Configuration
Imports System.Data.SqlClient
Partial Public Class BusquedaBenchEngagement
    Inherits System.Web.UI.Page

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

                If Session("Lenguaje") = "en-US" Then
                    Label9.Text = "Year"
                ElseIf Session("Lenguaje") = "pt-BR" Then
                    Label9.Text = "Ano"

              
                End If

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
            Server.Transfer("BusquedaBenchEngagement.aspx")
        Else
            RCBAgrupadoPaises.Items.Clear()
            RCBPais.Items.Clear()
            RCBRegion.Items.Clear()
            RCBSubRegion.Items.Clear()
            RCBAgrupadoPaises.Text = ""
            RCBPais.Text = ""
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
        RCBRegion.Items.Clear()
        RCBSubRegion.Items.Clear()
        RCBPais.Text = ""
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

        RCBTerritorio.Enabled = False
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
        'Llenargrid_Dinamico()
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
        End If
    End Sub

    Function GETCOLOR(ByVal Numero As Double) As System.Drawing.Color
        If Numero = 0 Then
            Return Drawing.Color.Gray
        ElseIf Numero > 0 And Numero <= 69.999999 Then
            Return Drawing.Color.Red
        ElseIf Numero >= 70.0 And Numero <= 79.999999 Then
            Return Drawing.Color.Yellow
        ElseIf Numero >= 80.0 And Numero <= 89.999999 Then
            Return Drawing.Color.Blue
        Else
            Return Drawing.Color.Green
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

    Function BuscarArray(ByVal Arreglo As Array, ByVal Elemento As Integer) As Boolean
        Dim flag As Boolean = False
        For i As Integer = 0 To Arreglo.Length - 1
            If Arreglo(i) = Elemento Then
                flag = True
                Exit For
            End If
        Next
        Return flag
    End Function

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
        Try
           Dim Ds As New DataSet
            Dim PLoad(11) As SqlParameter

            If RCBSubRegion.SelectedValue <> "-1" And RCBSubRegion.SelectedValue <> "" Then
                PLoad(0) = New SqlParameter("@TIPO", 7)
            ElseIf RCBRegion.SelectedValue <> "-1" And RCBRegion.SelectedValue <> "" Then
                PLoad(0) = New SqlParameter("@TIPO", 6)
            ElseIf RCBTerritorio.SelectedValue <> "-1" And RCBTerritorio.SelectedValue <> "" Then
                PLoad(0) = New SqlParameter("@TIPO", 5)
            ElseIf RCBPais.SelectedValue <> "-1" And RCBPais.SelectedValue <> "" Then
                PLoad(0) = New SqlParameter("@TIPO", 4)
            ElseIf RCBAgrupadoPaises.SelectedValue <> "-1" And RCBAgrupadoPaises.SelectedValue <> "" Then
                PLoad(0) = New SqlParameter("@TIPO", 3)
            ElseIf RCBUnidad.SelectedValue <> "-1" And RCBUnidad.SelectedValue <> "" Then
                PLoad(0) = New SqlParameter("@TIPO", 2)
            Else
                PLoad(0) = New SqlParameter("@TIPO", 1)
            End If

            If RCBUnidad.SelectedValue = "-1" Or RCBUnidad.SelectedValue = "" Then
                Session("CveUnidad") = DBNull.Value
                PLoad(1) = New SqlParameter("@CVEDIVISION", DBNull.Value)
            Else
                Session("CveUnidad") = RCBUnidad.SelectedValue
                PLoad(1) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
            End If

            If RCBAgrupadoPaises.SelectedValue = "-1" Or RCBAgrupadoPaises.SelectedValue = "" Then
                Session("CveAgrupado") = DBNull.Value
                PLoad(2) = New SqlParameter("@CVEAGRUPADOPAIS", DBNull.Value)
            Else
                Session("CveAgrupado") = RCBAgrupadoPaises.SelectedItem.Value
                PLoad(2) = New SqlParameter("@CVEAGRUPADOPAIS", RCBAgrupadoPaises.SelectedValue)
            End If

            If RCBPais.SelectedValue = "-1" Or RCBPais.SelectedValue = "" Then
                Session("CvePais") = DBNull.Value
                PLoad(3) = New SqlParameter("@CVEPAIS", DBNull.Value)
            Else
                Session("CvePais") = RCBPais.SelectedItem.Value
                PLoad(3) = New SqlParameter("@CVEPAIS", RCBPais.SelectedValue)
            End If

            'Meter concepto area
            If Session("SesTipoOperacion") Is Nothing Or Session("SesTipoOperacion") = "-1" Then
                'If RCBTipoEmpresa.SelectedValue = "-1" Or RCBTipoEmpresa.SelectedValue = "" Then
                Session("CveTipo") = DBNull.Value
                PLoad(4) = New SqlParameter("@CVEAREA", DBNull.Value)
            Else
                Session("CveTipo") = Session("SesTipoOperacion")
                PLoad(4) = New SqlParameter("@CVEAREA", Session("SesTipoOperacion"))
            End If

            If RCBTerritorio.SelectedValue = "-1" Or RCBTerritorio.SelectedValue = "" Then
                Session("CveTerritorio") = DBNull.Value
                PLoad(5) = New SqlParameter("@CVETERRITORIO", DBNull.Value)
            Else
                Session("CveTerritorio") = RCBTerritorio.SelectedItem.Value
                PLoad(5) = New SqlParameter("@CVETERRITORIO", RCBTerritorio.SelectedValue)
            End If

            If RCBRegion.SelectedValue = "-1" Or RCBRegion.SelectedValue = "" Then
                Session("CveRegion") = DBNull.Value
                PLoad(6) = New SqlParameter("@CVEREGION", DBNull.Value)
            Else
                Session("CveRegion") = RCBRegion.SelectedItem.Value
                PLoad(6) = New SqlParameter("@CVEREGION", RCBRegion.SelectedValue)
            End If

            If RCBSubRegion.SelectedValue = "-1" Or RCBSubRegion.SelectedValue = "" Then
                Session("CveSubRegion") = DBNull.Value
                PLoad(7) = New SqlParameter("@CVESUBREGION", DBNull.Value)
            Else
                Session("CveSubRegion") = RCBSubRegion.SelectedItem.Value
                PLoad(7) = New SqlParameter("@CVESUBREGION", RCBSubRegion.SelectedValue)
            End If

            'If RadioButtonList1.SelectedIndex = 1 Then
            '    Session("CveSistema") = 13
            '    PLoad(8) = New SqlParameter("@CVESISTEMA", 13)
            'Else
            '    Session("CveSistema") = 3
            '    PLoad(8) = New SqlParameter("@CVESISTEMA", 3)
            'End If

            If Session("CveUnidad") = 9 Or Session("CveUnidad") = 13 Then
                Session("CveSistema") = 13
                PLoad(8) = New SqlParameter("@CVESISTEMA", 13)
            Else
                Session("CveSistema") = 3
                PLoad(8) = New SqlParameter("@CVESISTEMA", 3)
            End If

            PLoad(9) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(10) = New SqlParameter("@USUARIO", Session("USUARIO"))

            If RCBAño.SelectedValue = "-1" Then
                PLoad(11) = New SqlParameter("@ANIOESTUDIO", DBNull.Value)
            Else
                PLoad(11) = New SqlParameter("@ANIOESTUDIO", RCBAño.SelectedValue)
            End If

            Ds = DatosBD.FuncionConPar("SP_EngBenchmark", PLoad, Lerror.Text)

            Dim TBL As New DataTable
            TBL = Ds.Tables(0)
            RadGrid1.DataSource = TBL
            RadGrid1.DataBind()

        Catch ex As Exception
            Lerror.Text = ex.Message & " " & ex.StackTrace
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
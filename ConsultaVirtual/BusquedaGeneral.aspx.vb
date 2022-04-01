Imports Telerik.Web.UI
Imports System.Math
Imports System.Configuration.ConfigurationManager
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization

Partial Public Class BusquedaGeneral
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
            RadWindowManager1.Windows(0).VisibleOnPageLoad = False
            RadWindowManager1.Windows(1).VisibleOnPageLoad = False
            If Not Page.IsPostBack Then
                RCBUnidad.Items.Clear()
                RCBAgrupadoPaises.Items.Clear()
                RCBPais.Items.Clear()
                RCBRegion.Items.Clear()
                RCBSubRegion.Items.Clear()
                RadGrid1.Visible = False
                CargarDivision()
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
            'LlenarGrid()
        End If
    End Sub

    Protected Sub RCBUnidad_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBUnidad.SelectedIndexChanged
        Label6.Visible = False
        RadioButtonList1.Visible = False
        Session("TipoEmpleado") = "Empleado"

        If RCBUnidad.SelectedValue = -1 Then
            Server.Transfer("BusquedaGeneral.aspx")
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
            RCBTerritorio.Enabled = False
            RCBRegion.Enabled = False
            RCBSubRegion.Enabled = False

            CargarAgrupadoPaises()
            'LlenarGrid()
        End If
    End Sub

    Protected Sub RcboTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim RCboTop As RadComboBox = DirectCast(sender, RadComboBox)
        Session("SesTipoOperacion") = RCboTop.SelectedValue
        Session("SesNomTipoOperacion") = RCboTop.Text
        LlenarGrid()
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
        RCBTerritorio.Enabled = False
        RCBRegion.Enabled = False
        RCBSubRegion.Enabled = False

        CargarPaises()
        'LlenarGrid()
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
        'LlenarGrid()
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
        ElseIf (RCBUnidad.SelectedValue = 2 And RCBPais.SelectedValue = 11) Or RCBUnidad.SelectedValue = 13 Or RCBUnidad.SelectedValue = 9 Then 'Filipinas / Grafo
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

        'If RCBUnidad.SelectedValue = 6 Then
        '    RadioButtonList1.Items(1).Text = "Líder"
        '    Label6.Visible = False
        '    RadioButtonList1.Visible = True
        '    Session("TipoEmpleado") = "Empleado"
        'ElseIf (RCBUnidad.SelectedValue = 2 And RCBPais.SelectedValue = 11) Or RCBUnidad.SelectedValue = 13 Then 'Filipinas / Grafo
        '    RadioButtonList1.Items(1).Text = "Otros"
        '    RadioButtonList1.SelectedValue = 2
        '    Label6.Visible = False
        '    RadioButtonList1.Visible = False
        '    Session("TipoEmpleado") = "Lider"
        'Else
        '    RadioButtonList1.SelectedValue = 1
        '    Label6.Visible = False
        '    RadioButtonList1.Visible = False
        '    Session("TipoEmpleado") = "Empleado"
        'End If
    End Sub

    Protected Sub RCBRegion_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBRegion.SelectedIndexChanged
        RCBSubRegion.Items.Clear()
        RCBSubRegion.Text = ""
        RCBSubRegion.Enabled = False

        CargarSubRegiones()
        'LlenarGrid()
    End Sub

    Sub CargarSubRegiones()
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 5)
        PLoad(1) = New SqlParameter("@CVEREGION", RCBRegion.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBSubRegion, "[Sp_CargaEstructura]", PLoad, "NOMSUBREGION", "CVESUBREGION", 1, True, Session("Lenguaje"))
    End Sub

    Protected Sub RCBSubRegion_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBSubRegion.SelectedIndexChanged
        'LlenarGrid()
    End Sub

    Sub LlenarGrid()
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

            'Tipo de Operacion
            If Session("SesTipoOperacion") Is Nothing Or Session("SesTipoOperacion") = "-1" Then
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

            If RadioButtonList1.SelectedIndex = 1 Or RCBUnidad.SelectedValue = 15 Then
                Session("CveSistema") = 13
                PLoad(7) = New SqlParameter("@CVESISTEMA", 13)
            ElseIf RadioButtonList1.SelectedIndex = 1 And RCBUnidad.SelectedValue = 6 Then
                Session("CveSistema") = 13
                PLoad(7) = New SqlParameter("@CVESISTEMA", 13)
            Else
                Session("CveSistema") = 3
                PLoad(7) = New SqlParameter("@CVESISTEMA", 3)
            End If

            PLoad(8) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(9) = New SqlParameter("@USUARIO", Session("USUARIO"))

            If Session("Lenguaje") = "pt-BR" Then
                PLoad(10) = New SqlParameter("@IDIOMA", 2)
            ElseIf Session("Lenguaje") = "en-US" Then
                PLoad(10) = New SqlParameter("@IDIOMA", 11)
            Else
                PLoad(10) = New SqlParameter("@IDIOMA", 99)
            End If
            ds = DatosBD.FuncionConPar("SP_BUSQUEDA_GENERAL", PLoad, Lerror.Text)
            RadGrid1.DataSource = ds.Tables(0)
            RadGrid1.DataBind()
            RadGrid1.Visible = True
            Session("DTTemas") = ds.Tables(1)
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Private Sub RadGrid1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.Init
        Dim menu As GridFilterMenu = RadGrid1.FilterMenu
        Dim i As Integer = 0
        While i < menu.Items.Count
            If menu.Items(i).Text = "NoFilter" Then
                menu.Items(i).Text = "Limpiar"
                i = i + 1
            ElseIf menu.Items(i).Text = "EqualTo" Then
                menu.Items(i).Text = "Igual"
                i = i + 1
            ElseIf menu.Items(i).Text = "GreaterThan" Then
                menu.Items(i).Text = "Mayor que"
                i = i + 1
            ElseIf menu.Items(i).Text = "LessThan" Then
                menu.Items(i).Text = "Menor que"
                i = i + 1
            ElseIf menu.Items(i).Text = "GreaterThanOrEqualTo" Then
                menu.Items(i).Text = "Mayor o igual que"
                i = i + 1
            ElseIf menu.Items(i).Text = "LessThanOrEqualTo" Then
                menu.Items(i).Text = "Menor o igual que"
                i = i + 1
            Else
                menu.Items.RemoveAt(i)
            End If
        End While
    End Sub

    Private Sub RadGrid1_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = RadGrid.FilterCommandName Then
            LlenarGrid()
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        Try
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

                    Cargar.ComboParametros(RD, "[Sp_CargaEstructura]", PLoad, "NomArea", "CveArea", 1, True, Session("Lenguaje"))

                    If Not Session("SesTipoOperacion") Is Nothing Then
                        RD.FindItemByValue(Session("SesTipoOperacion")).Selected = True
                    End If
                End If
            ElseIf e.Item.ItemType = GridItemType.FilteringItem Then
                Dim item As GridFilteringItem = e.Item
                item("EMPRESA").HorizontalAlign = HorizontalAlign.Left

                'Cambio de Visible por Display para evadir error en javascript
                RadGrid1.Columns(1).Display = False
                RadGrid1.Columns(1).Visible = True
                RadGrid1.Columns(3).Display = False
                RadGrid1.Columns(3).Visible = True
                RadGrid1.Columns(5).Display = False
                RadGrid1.Columns(5).Visible = True
                RadGrid1.Columns(6).Display = False
                RadGrid1.Columns(6).Visible = True
                RadGrid1.Columns(8).Display = False
                RadGrid1.Columns(8).Visible = True
            End If

            If e.Item.ItemType = GridItemType.AlternatingItem OrElse e.Item.ItemType = GridItemType.Item Then
                '2"NUM"
                '3"CVEEMPRESA"
                '4"EMPRESA"
                '5"CVEENCUESTA"
                '6"APLICACION"
                '7"ESPERADO"
                '8"REAL"
                '9"PARTICIPACION"
                '10"PADRE"
                '11"AL"
                '12"JI"
                '13"CS"
                '14"CO"
                '15"CV"
                '16"DS"
                '17"HC"
             
                If e.Item.Cells(10).Text = 1 Then ' SI SON PADRES
                    Con = Con + 1
                    'e.Item.Cells(2).Text = Con
                    e.Item.Cells(2).Text = e.Item.Cells(3).Text
                    SumPersonasEncuesta = SumPersonasEncuesta + e.Item.Cells(8).Text
                    If e.Item.Cells(11).Text <> 0 Or e.Item.Cells(12).Text <> 0 Or e.Item.Cells(13).Text <> 0 Then
                        SumPersonasAL = SumPersonasAL + e.Item.Cells(8).Text
                        MultAL = CDbl(e.Item.Cells(8).Text) * CDbl(e.Item.Cells(11).Text)
                        SumAL = SumAL + MultAL
                        MultJI = CDbl(e.Item.Cells(8).Text) * CDbl(e.Item.Cells(12).Text)
                        SumJI = SumJI + MultJI
                        MultCS = CDbl(e.Item.Cells(8).Text) * CDbl(e.Item.Cells(13).Text)
                        SumCS = SumCS + MultCS
                    End If
                    Mult = CDbl(e.Item.Cells(8).Text) * CDbl(e.Item.Cells(14).Text)
                    Sum = Sum + Mult

                    SumPersonasEmpresa = SumPersonasEmpresa + (e.Item.Cells(7).Text)
                Else
                    e.Item.Cells(2).Text = "-"

                    'Agregamos en el ToolTip del hijo el nombre del padre
                    'Dim DS As DataSet
                    'Dim SEN As String
                    'SEN = "SELECT NOMEMPRESA FROM TBLEMPRESA WHERE CVEEMPRESA=" & e.Item.Cells(10).Text
                    'DS = DatosBD.FuncionTXT(SEN, "")

                
                    Dim ds As New DataSet
                    Dim P(1) As SqlParameter
                    P(0) = New SqlParameter("@TIPO", 2)
                    P(1) = New SqlParameter("@CVEEMPRESA", e.Item.Cells(10).Text)
                    ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


                    e.Item.Cells(4).ToolTip = DS.Tables(0).Rows(0).Item(0)


                End If

                e.Item.Cells(2).ToolTip = CStr(e.Item.Cells(3).Text)  ' ME COLOCA LA CVE EMPRESA EN EL  TOOLTIP
                e.Item.Cells(9).ToolTip = CStr(e.Item.Cells(8).Text) & " / " & CStr(e.Item.Cells(7).Text) 'TOOLTIP DE PARTICIPACION

                'e.Item.Cells(11).BackColor = GETCOLOR(e.Item.Cells(11).Text)
                e.Item.Cells(11).ForeColor = GETCOLOR3(e.Item.Cells(11).Text)
                'e.Item.Cells(12).BackColor = GETCOLOR(e.Item.Cells(12).Text)
                e.Item.Cells(12).ForeColor = GETCOLOR3(e.Item.Cells(12).Text)
                'e.Item.Cells(13).BackColor = GETCOLOR(e.Item.Cells(13).Text)
                e.Item.Cells(13).ForeColor = GETCOLOR3(e.Item.Cells(13).Text)
                e.Item.Cells(14).BackColor = GETCOLOR(e.Item.Cells(14).Text)
                e.Item.Cells(14).ForeColor = GETCOLOR2(e.Item.Cells(14).Text)

                e.Item.Cells(15).BackColor = GETCOLOR(e.Item.Cells(15).Text)
                e.Item.Cells(15).ForeColor = GETCOLOR2(e.Item.Cells(15).Text)

                e.Item.Cells(16).BackColor = GETCOLOR(e.Item.Cells(16).Text)
                e.Item.Cells(16).ForeColor = GETCOLOR2(e.Item.Cells(16).Text)


                'If RCBPais.SelectedValue <> "-1" And RCBPais.SelectedValue <> "" Or (Session("NUMPERFIL") >= 6) Then
                '    Dim Hlink3 As New RadComboBox
                '    Dim RItem1 As New RadComboBoxItem
                '    Dim RItem2 As New RadComboBoxItem
                '    Dim RItem3 As New RadComboBoxItem
                '    RItem1.Text = GETPALABRA("Detalles")
                '    RItem1.Attributes.Add("OnClick", "window.radopen('BuscarReportes.ASPX?CVEm=" & e.Item.Cells(3).Text & "&CVEn=" & e.Item.Cells(5).Text & "','RadDetalles');return false;")
                '    RItem2.Text = GETPALABRA("Temas")
                '    RItem2.Attributes.Add("OnClick", "window.radopen('GraficasComparativas.aspx?Em=" & e.Item.Cells(3).Text & "','UserListDialog');return false;")
                '    RItem3.Text = GETPALABRA("Comparativa")
                '    RItem3.Attributes.Add("OnClick", "window.radopen('ComparativaTemas.ASPX?Tipo=1&Em=" & e.Item.Cells(3).Text & "','UserListDialog');return false;")
                '    Hlink3.Items.Add(RItem1)
                '    Hlink3.Items.Add(RItem2)
                '    Hlink3.Items.Add(RItem3)
                '    Hlink3.Width = 100
                '    Hlink3.Dispose()
                '    e.Item.Cells(17).Controls.Add(Hlink3)
                'End If

                'Dim Hlink3 As New LinkButton
                'Hlink3.Text = GETPALABRA("Detalles")
                'Hlink3.Attributes.Add("OnClick", "window.radopen('BuscarReportes.ASPX?CVEm=" & e.Item.Cells(3).Text & "&CVEn=" & e.Item.Cells(5).Text & "','RadDetalles');return false;")
                'e.Item.Cells(17).Controls.Add(Hlink3)

            ElseIf e.Item.ItemType = GridItemType.Footer Then
                If Sum > 0 And SumPersonasEncuesta > 0 Then
                    Dim DSet As DataSet
                    DSet = BuildData()
                    If DSet.Tables(0).Rows.Count = 1 Then
                        e.Item.Cells(14).Text = CDbl(DSet.Tables(0).Rows(0).Item(3)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'CO  
                    ElseIf DSet.Tables(0).Rows.Count = 2 Then
                        e.Item.Cells(13).Text = CDbl(DSet.Tables(0).Rows(0).Item(3)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'CS
                        e.Item.Cells(14).Text = CDbl(DSet.Tables(0).Rows(1).Item(3)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'CO  
                    ElseIf DSet.Tables(0).Rows.Count >= 3 Then
                        e.Item.Cells(11).Text = CDbl(DSet.Tables(0).Rows(0).Item(3)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'AL
                        e.Item.Cells(12).Text = CDbl(DSet.Tables(0).Rows(1).Item(3)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'JI
                        e.Item.Cells(13).Text = CDbl(DSet.Tables(0).Rows(2).Item(3)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'CS
                        e.Item.Cells(14).Text = CDbl(DSet.Tables(0).Rows(3).Item(3)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'CO  
                        e.Item.Cells(15).Text = CDbl(DSet.Tables(0).Rows(4).Item(3)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'CV  
                        e.Item.Cells(16).Text = CDbl(DSet.Tables(0).Rows(5).Item(3)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture) 'DS  
                    End If
                    'e.Item.Cells(11).Text = CDbl(Round(SumAL / SumPersonasAL, 2)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture)
                    'e.Item.Cells(12).Text = CDbl(Round(SumJI / SumPersonasAL, 2)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture)
                    'e.Item.Cells(13).Text = CDbl(Round(SumCS / SumPersonasAL, 2)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture)
                    'e.Item.Cells(14).Text = CDbl(Round(Sum / SumPersonasEncuesta, 2)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture)
                    Dim Participacion As Double
                    Participacion = CDbl(SumPersonasEncuesta) / CDbl(SumPersonasEmpresa)
                    e.Item.Cells(9).Text = Participacion.ToString("P1", System.Globalization.CultureInfo.InvariantCulture)
                    e.Item.Cells(9).ToolTip = CStr(SumPersonasEncuesta) & " / " & CStr(SumPersonasEmpresa)
                    e.Item.Cells(2).Text = CStr(Con)
                    e.Item.Cells(17).Text = CDbl(SumPersonasEmpresa) 'HC

                    Session("CveEmpresaEst") = DBNull.Value

                    Dim Clink As New RadComboBox
                    Dim RItem1 As New RadComboBoxItem
                    Dim RItem2 As New RadComboBoxItem
                    Dim RItem3 As New RadComboBoxItem
                    Dim RItem4 As New RadComboBoxItem
                    Dim RItem5 As New RadComboBoxItem
                    Dim RItem6 As New RadComboBoxItem
                    Dim RItem7 As New RadComboBoxItem
                    RItem1.Text = GETPALABRA("Gráfica General Por Temas")
                    RItem1.Attributes.Add("OnClick", "window.radopen('GraficaTemas.ASPX?Tipo=1','UserListDialog');return false;")
                    RItem2.Text = GETPALABRA("Reporte por Preguntas")

                    If RCBUnidad.SelectedValue = 6 And RadioButtonList1.SelectedIndex = 1 Then
                        Session("CveSistema") = 13
                    End If


                    RItem2.Attributes.Add("OnClick", "window.radopen('ComparativaTemas.ASPX?Tipo=2&Ses=" & Session("CveSistema") & "','UserListDialog');return false;")
                    If RCBUnidad.SelectedValue = "-1" Then
                        RItem3.Text = GETPALABRA("Gráficas Por Unidad")
                        RItem3.Attributes.Add("OnClick", "window.radopen('Graficas.ASPX?Val=S1','UserListDialog');return false;")
                        RItem7.Visible = False
                    ElseIf RCBAgrupadoPaises.SelectedValue = "-1" Then
                        RItem3.Text = GETPALABRA("Gráficas Por Agrupado País")
                        RItem3.Attributes.Add("OnClick", "window.radopen('Graficas.ASPX?Val=S2','UserListDialog');return false;")
                        RItem7.Visible = False
                    ElseIf RCBPais.SelectedValue = "-1" Then
                        RItem3.Text = GETPALABRA("Gráficas Por País")
                        RItem3.Attributes.Add("OnClick", "window.radopen('Graficas.ASPX?Val=S3','UserListDialog');return false;")
                        'Esconder peticion Esau
                        ' RItem7.Text = GETPALABRA("Estadisticos Por País")
                        ' RItem7.Attributes.Add("OnClick", "window.radopen('EstadisticosCO.ASPX','UserListDialog');return false;")
                        RItem7.Visible = False
                    ElseIf RCBTerritorio.SelectedValue = "-1" Then
                        RItem3.Text = GETPALABRA("Gráficas Por Territorio")
                        RItem3.Attributes.Add("OnClick", "window.radopen('Graficas.ASPX?Val=S4','UserListDialog');return false;")
                        'RItem7.Text = GETPALABRA("Estadisticos Por Territorio")
                        'RItem7.Attributes.Add("OnClick", "window.radopen('EstadisticosCO.ASPX','UserListDialog');return false;")
                        RItem7.Visible = True
                    ElseIf RCBRegion.SelectedValue = "-1" Then
                        RItem3.Text = GETPALABRA("Gráficas Por Región")
                        RItem3.Attributes.Add("OnClick", "window.radopen('Graficas.ASPX?Val=S5','UserListDialog');return false;")
                        RItem7.Text = GETPALABRA("Estadisticos Por Región")
                        RItem7.Attributes.Add("OnClick", "window.radopen('EstadisticosCO.ASPX','UserListDialog');return false;")
                        RItem7.Visible = True
                    ElseIf RCBSubRegion.SelectedValue = "-1" Then
                        RItem3.Text = GETPALABRA("Gráficas Por Subregión")
                        RItem3.Attributes.Add("OnClick", "window.radopen('Graficas.ASPX?Val=S6','UserListDialog');return false;")
                        RItem7.Text = GETPALABRA("Estadisticos Por Subregión")
                        RItem7.Attributes.Add("OnClick", "window.radopen('EstadisticosCO.ASPX','UserListDialog');return false;")
                        RItem7.Visible = True
                    Else
                        RItem3.Visible = False
                        RItem7.Text = GETPALABRA("Estadisticos Por Subregión")
                        RItem7.Attributes.Add("OnClick", "window.radopen('EstadisticosCO.ASPX','UserListDialog');return false;")
                        RItem7.Visible = True
                    End If
                    RItem4.Text = GETPALABRA("Gráfica Clima Organizacional")
                    RItem4.Attributes.Add("OnClick", "window.radopen('Graficas.ASPX?Val=CO','UserListDialog');return false;")
                    RItem5.Text = GETPALABRA("Reportes Demográficos")
                    RItem5.Attributes.Add("OnClick", "window.radopen('ReporteDemograficos.ASPX','RadDetalles');return false;")
                    RItem6.Text = GETPALABRA("Reporte Liderazgo")
                    RItem6.Attributes.Add("OnClick", "window.radopen('ReporteLiderazgo.ASPX','UserListDialog');return false;")
                    Clink.Items.Add(RItem1)
                    Clink.Items.Add(RItem2)
                    Clink.Items.Add(RItem3)
                    Clink.Items.Add(RItem4)
                    Clink.Items.Add(RItem5)
                    Clink.Items.Add(RItem6)
                    Clink.Items.Add(RItem7)
                    Clink.Width = 200
                    Clink.Dispose()
                    e.Item.Cells(4).Controls.Add(Clink)
                    e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Left


                    Dim Clink2 As New RadComboBox
                    Dim RItem2_1 As New RadComboBoxItem
                    Dim RItem2_2 As New RadComboBoxItem
                    Dim RItem2_3 As New RadComboBoxItem
                    Dim RItem2_4 As New RadComboBoxItem
                    Dim RItem2_5 As New RadComboBoxItem
                    RItem2_1.Text = GETPALABRA("Matriz de efectividad")
                    RItem2_1.Attributes.Add("OnClick", "window.radopen('GraficaMatriz.ASPX','UserListDialog');return false;")
                    RItem2_2.Text = GETPALABRA("Resultados por Perfil")
                    RItem2_2.Attributes.Add("OnClick", "window.radopen('GraficaTemas.ASPX?Tipo=2','UserListDialog');return false;")
                    RItem2_3.Text = GETPALABRA("Gráfica impacto (Compromiso)")
                    RItem2_3.Attributes.Add("OnClick", "window.radopen('GraficaImpacto.ASPX?R=R7','UserListDialog');return false;")
                    RItem2_4.Text = GETPALABRA("Gráfica impacto (Soporte)")
                    RItem2_4.Attributes.Add("OnClick", "window.radopen('GraficaImpacto.ASPX?R=R8','UserListDialog');return false;")
                    RItem2_5.Text = GETPALABRA("Reporte de impacto")
                    RItem2_5.Attributes.Add("OnClick", "window.radopen('GraficaImpacto.ASPX?R=R9','UserListDialog');return false;")
                    Clink2.Items.Add(RItem2_1)
                    Clink2.Items.Add(RItem2_2)
                    Clink2.Items.Add(RItem2_3)
                    Clink2.Items.Add(RItem2_4)
                    Clink2.Items.Add(RItem2_5)
                    Clink2.Dispose()
                    e.Item.Cells(6).Controls.Add(Clink2)
                    e.Item.Cells(6).HorizontalAlign = HorizontalAlign.Center


                    MultAL = 0.0
                    SumAL = 0.0
                    MultJI = 0.0
                    SumJI = 0.0
                    MultCS = 0.0
                    SumCS = 0.0
                    SumPersonasAL = 0.0

                    Mult = 0.0
                    Sum = 0.0
                    SumPersonasEncuesta = 0
                    SumPersonasEmpresa = 0
                    Con = 0

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Cambio de Display por Visible para visualizar Footer
                    RadGrid1.Columns(1).Display = True
                    RadGrid1.Columns(1).Visible = False
                    RadGrid1.Columns(3).Display = True
                    RadGrid1.Columns(3).Visible = False
                    RadGrid1.Columns(5).Display = True
                    RadGrid1.Columns(5).Visible = False
                    RadGrid1.Columns(6).Display = True
                    RadGrid1.Columns(6).Visible = False
                    RadGrid1.Columns(8).Display = True
                    RadGrid1.Columns(8).Visible = False
                End If
            End If

        Catch ex As Exception
            Lerror.Text = ex.Message
            Exit Sub
        End Try
    End Sub

    Private Sub RadGrid1_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        LlenarGrid()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedIndex = 0 Then
            'Empleados
            Session("TipoEmpleado") = "Empleado"
            'LlenarGrid()
        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            'Lider
            Session("TipoEmpleado") = "Lider"
            'LlenarGridLider()
        End If
    End Sub

    Protected Sub BFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BFiltrar.Click
        Session("SesTipoOperacion") = Nothing
        'If RadioButtonList1.SelectedIndex = 0 Then
        '    'Empleados
        '    'LlenarGrid()
        '    LlenarGrid()
        'ElseIf RadioButtonList1.SelectedIndex = 1 Then
        '    'Lider
        '    'LlenarGridLider()
        '    LlenarGrid()
        'End If
        'CAMBIO PARA QUE SE PUEDA FILTRAR POR INTEGRAL
        If RCBUnidad.SelectedValue = -1 Then
            LlenarGridtotal()

        Else
            LlenarGrid()
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

    Function GETCOLOR3(ByVal Numero As Double) As System.Drawing.Color
        If Numero = 0 Then
            Return Drawing.Color.Gray
        ElseIf Numero > 0 And Numero <= 69.999999 Then
            Return Drawing.Color.Red
        ElseIf Numero >= 70.0 And Numero <= 79.999999 Then
            Return Drawing.Color.Orange
        ElseIf Numero >= 80.0 And Numero <= 89.999999 Then
            Return Drawing.Color.Blue
        Else
            Return Drawing.Color.Green
        End If
    End Function

    Function GETPALABRA(ByVal Palabra As String) As String
        Dim Traduccion As String
        Dim DS As DataSet
        Dim P(1) As SqlParameter
        P(0) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        P(1) = New SqlParameter("@PALABRA", Palabra)
        DS = DatosBD.FuncionConPar("SP_GETTRADUCCION", P, Lerror.Text)
        Traduccion = DS.Tables(0).Rows(0).Item(0)
        Return Traduccion
    End Function

    Private Function BuildData()
        Try
            Dim ds As New DataSet
            Dim PLoad(11) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 1)
            PLoad(1) = New SqlParameter("@CVEDIVISION", Session("CveUnidad"))
            PLoad(2) = New SqlParameter("@CVEAGRUPADOPAIS", Session("CveAgrupado"))
            PLoad(3) = New SqlParameter("@CVEPAIS", Session("CvePais"))
            PLoad(4) = New SqlParameter("@CVEAREA", Session("CveTipo"))
            PLoad(5) = New SqlParameter("@CVETERRITORIO", Session("CveTerritorio"))
            PLoad(6) = New SqlParameter("@CVEREGION", Session("CveRegion"))
            PLoad(7) = New SqlParameter("@CVESUBREGION", Session("CveSubRegion"))
            PLoad(8) = New SqlParameter("@CVEEMPRESA", DBNull.Value)
            'lalo footer
            If RadioButtonList1.SelectedIndex = 1 And RCBUnidad.SelectedValue = 9 Then
                Session("CveSistema") = 13
                PLoad(9) = New SqlParameter("@CVESISTEMA", 13)
            ElseIf RCBUnidad.SelectedValue = 13 Then
                Session("CveSistema") = 13
                PLoad(9) = New SqlParameter("@CVESISTEMA", 13)
            ElseIf RCBUnidad.SelectedValue = 15 Then
                Session("CveSistema") = 13
                PLoad(9) = New SqlParameter("@CVESISTEMA", 3)
            ElseIf RCBUnidad.SelectedValue = 1 Or RCBUnidad.SelectedValue = 2 Or RCBUnidad.SelectedValue = 4 Or RCBUnidad.SelectedValue = 5 Or RCBUnidad.SelectedValue = 6 Then
                Session("CveSistema") = 3
                PLoad(9) = New SqlParameter("@CVESISTEMA", 3)
            Else
                'Session("CveSistema") = 13
                'PLoad(9) = New SqlParameter("@CVESISTEMA", 13)
                Session("CveSistema") = 3
                PLoad(9) = New SqlParameter("@CVESISTEMA", 3)

            End If
            'PLoad(9) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
            PLoad(10) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(11) = New SqlParameter("@USUARIO", Session("USUARIO"))

            ds = DatosBD.FuncionConPar("SP_Busqueda_General_Footer", PLoad, Lerror.Text)
            Return ds
        Catch ex As Exception
            Lerror.Text = "No existe información para este reporte."
        End Try
    End Function

    Sub Exportar()
        RadGrid1.MasterTableView.ExportToExcel()
    End Sub

    Private Sub RadContextMenu1_ItemClick(sender As Object, e As RadMenuEventArgs) Handles RadContextMenu1.ItemClick
        Dim CveEmpresa, CveEncuesta As Integer
        CveEmpresa = RadGrid1.SelectedItems.Item(0).Cells(3).Text
        CveEncuesta = RadGrid1.SelectedItems.Item(0).Cells(5).Text

        If e.Item.Index = 0 Then
            RadWindowManager1.Windows(1).NavigateUrl = "BuscarReportes.ASPX?CVEm=" & CveEmpresa & "&CVEn=" & CveEncuesta & ""
            RadWindowManager1.Windows(1).VisibleOnPageLoad = True
        ElseIf e.Item.Index = 1 Then
            RadWindowManager1.Windows(0).NavigateUrl = "GraficasComparativas.aspx?Em=" & CveEmpresa & ""
            RadWindowManager1.Windows(0).VisibleOnPageLoad = True
        ElseIf e.Item.Index = 2 Then
            RadWindowManager1.Windows(0).NavigateUrl = "Graficas.ASPX?Val=Participacion&Em=" & CveEmpresa & ""
            RadWindowManager1.Windows(0).VisibleOnPageLoad = True
        ElseIf e.Item.Index = 3 Then
            Session("CveEmpresaEst") = CveEmpresa
            RadWindowManager1.Windows(0).NavigateUrl = "EstadisticosCO.ASPX?Em=" & CveEmpresa & ""
            RadWindowManager1.Windows(0).VisibleOnPageLoad = True
        End If
    End Sub

    Sub LlenarGridtotal()
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

            'Tipo de Operacion
            If Session("SesTipoOperacion") Is Nothing Or Session("SesTipoOperacion") = "-1" Then
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

            PLoad(7) = New SqlParameter("@CVESISTEMA", 3)


            PLoad(8) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(9) = New SqlParameter("@USUARIO", Session("USUARIO"))

            If Session("Lenguaje") = "pt-BR" Then
                PLoad(10) = New SqlParameter("@IDIOMA", 2)
            ElseIf Session("Lenguaje") = "en-US" Then
                PLoad(10) = New SqlParameter("@IDIOMA", 11)
            Else
                PLoad(10) = New SqlParameter("@IDIOMA", 99)
            End If

            ds = DatosBD.FuncionConPar("SP_BUSQUEDA_GENERAL", PLoad, Lerror.Text)
            RadGrid1.DataSource = ds.Tables(0)
            RadGrid1.DataBind()
            RadGrid1.Visible = True
            Session("DTTemas") = ds.Tables(1)
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

End Class
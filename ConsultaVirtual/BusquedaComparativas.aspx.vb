Imports Telerik.Web.UI
Imports System.Math
Imports System.Configuration.ConfigurationManager
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization

Partial Public Class BusquedaComparativas
    Inherits System.Web.UI.Page
    Dim Mult As Double = 0.0
    Dim Sum As Double = 0.0
    Dim Con As Integer = 0

    Dim SumEncuestados As Double = 0.0
    Dim SumPersonal As Double = 0.0
    Dim SumCalculo As Double = 0.0
    Dim SumEncuestados_ As Double = 0.0
    Dim SumPersonal_ As Double = 0.0
    Dim SumCalculo_ As Double = 0.0

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
                'RadMenu1.Items(2).Selected = True

                'Dim SEN As String
                'SEN = "SELECT DISTINCT ANIOESTUDIO, ANIOESTUDIO AS AÑO FROM TBLHISTORIA_EMPRESA WHERE ANIOESTUDIO>0 ORDER BY ANIOESTUDIO DESC"
                'Cargar.ComboSentenciaTxt(RCBAñoActual1, SEN, "ANIOESTUDIO", "AÑO")
                'Cargar.ComboSentenciaTxt(RCBAñoActual2, SEN, "ANIOESTUDIO", "AÑO")
                'Cargar.ComboSentenciaTxt(RCBAñoAnterior1, SEN, "ANIOESTUDIO", "AÑO")
                'Cargar.ComboSentenciaTxt(RCBAñoAnterior2, SEN, "ANIOESTUDIO", "AÑO")

                Dim ds As New DataSet
                Dim P(0) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 1)
                ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


                RCBAñoActual1.DataSource = ds.Tables(0)
                RCBAñoActual1.DataTextField = "ANIOESTUDIO"
                RCBAñoActual1.DataValueField = "AÑO"
                RCBAñoActual1.DataBind()

                'Cargar.ComboParametros(RCBAñoActual1, "SP_CONSULTAS_ENTREGAVIRTUAL", P, "ANIOESTUDIO", "AÑO", 1, True, Session("Lenguaje"))
                'Cargar.ComboParametros(RCBAñoActual2, "SP_CONSULTAS_ENTREGAVIRTUAL", P, "ANIOESTUDIO", "AÑO", 1, True, Session("Lenguaje"))
                'Cargar.ComboParametros(RCBAñoAnterior1, "SP_CONSULTAS_ENTREGAVIRTUAL", P, "ANIOESTUDIO", "AÑO", 1, True, Session("Lenguaje"))
                'Cargar.ComboParametros(RCBAñoAnterior2, "SP_CONSULTAS_ENTREGAVIRTUAL", P, "ANIOESTUDIO", "AÑO", 1, True, Session("Lenguaje"))

                RCBAñoActual2.DataSource = ds.Tables(0)
                RCBAñoActual2.DataTextField = "ANIOESTUDIO"
                RCBAñoActual2.DataValueField = "AÑO"
                RCBAñoActual2.DataBind()

                RCBAñoAnterior1.DataSource = ds.Tables(0)
                RCBAñoAnterior1.DataTextField = "ANIOESTUDIO"
                RCBAñoAnterior1.DataValueField = "AÑO"
                RCBAñoAnterior1.DataBind()

                RCBAñoAnterior2.DataSource = ds.Tables(0)
                RCBAñoAnterior2.DataTextField = "ANIOESTUDIO"
                RCBAñoAnterior2.DataValueField = "AÑO"
                RCBAñoAnterior2.DataBind()
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
            Session("Recalcular") = Nothing
            'Llenargrid_Dinamico()
        End If
    End Sub

    Protected Sub RCBUnidad_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBUnidad.SelectedIndexChanged
        Label6.Visible = False
        RadioButtonList1.Visible = False
        Session("TipoEmpleado") = "Empleado"

        If RCBUnidad.SelectedValue = -1 Then
            Server.Transfer("BusquedaComparativas.aspx")
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
            Session("Recalcular") = Nothing
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
        Session("Recalcular") = Nothing
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

        Session("Recalcular") = Nothing
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
        Session("Recalcular") = Nothing
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
        Session("Recalcular") = Nothing
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
        Session("Recalcular") = Nothing
        'Llenargrid_Dinamico()
    End Sub

    'Private Sub Grid2_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles Grid2.ItemCommand
    '    If e.CommandName = "RebindGrid" Then
    '        Dim Val() As Integer
    '        'Dim Excluidos As String = ""
    '        Dim con As Integer = 0
    '        For i As Integer = 0 To Grid2.MasterTableView.Items.Count - 1
    '            Dim Ck As CheckBox = CType(Grid2.MasterTableView.Items(i).Cells(2).Controls(1), CheckBox)
    '            If Ck.Checked = False Then
    '                ReDim Preserve Val(con)
    '                Val(con) = i
    '                con = con + 1
    '                'If Excluidos.Length = 0 Then
    '                '    Excluidos = "'" & Grid2.MasterTableView.Items(i).Cells(3).Text & "'"
    '                'Else
    '                '    Excluidos = Excluidos & ",'" & Grid2.MasterTableView.Items(i).Cells(3).Text & "'"
    '                'End If
    '            End If
    '        Next
    '        'Session("Excluidos") = Excluidos
    '        Session("Recalcular") = Val
    '        Llenargrid_Dinamico()
    '    Else
    '        Session("Recalcular") = Nothing
    '    End If
    'End Sub

    Private Sub Grid2_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles Grid2.ItemDataBound
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

                    Cargar.ComboParametros(RD, "[Sp_CargaEstructura]", PLoad, "NomArea", "CveArea", 1, True)

                    If Not Session("SesTipoOperacion") Is Nothing Then
                        RD.FindItemByValue(Session("SesTipoOperacion")).Selected = True
                    End If
                End If
            ElseIf e.Item.ItemType = GridItemType.AlternatingItem OrElse e.Item.ItemType = GridItemType.Item Then
                'participacion
                e.Item.Cells(6).BackColor = GETCOLOR(e.Item.Cells(6).Text.Replace("%", ""))
                e.Item.Cells(6).ForeColor = GETCOLOR2(e.Item.Cells(6).Text.Replace("%", ""))
                e.Item.Cells(7).BackColor = GETCOLOR(e.Item.Cells(7).Text.Replace("%", ""))
                e.Item.Cells(7).ForeColor = GETCOLOR2(e.Item.Cells(7).Text.Replace("%", ""))
                'promedio
                e.Item.Cells(10).BackColor = GETCOLOR(e.Item.Cells(10).Text)
                e.Item.Cells(10).ForeColor = GETCOLOR2(e.Item.Cells(10).Text)
                e.Item.Cells(11).BackColor = GETCOLOR(e.Item.Cells(11).Text)
                e.Item.Cells(11).ForeColor = GETCOLOR2(e.Item.Cells(11).Text)

                e.Item.Cells(6).BorderColor = Drawing.Color.White
                e.Item.Cells(7).BorderColor = Drawing.Color.White
                e.Item.Cells(10).BorderColor = Drawing.Color.White
                e.Item.Cells(11).BorderColor = Drawing.Color.White

                e.Item.Cells(6).BorderWidth = 1
                e.Item.Cells(7).BorderWidth = 1
                e.Item.Cells(10).BorderWidth = 1
                e.Item.Cells(11).BorderWidth = 1

                Dim Ck As CheckBox = CType(e.Item.Cells(2).Controls(1), CheckBox)
                If Not Session("Recalcular") Is Nothing Then
                    Dim Val() As Integer = Session("Recalcular")
                    If BuscarArray(Val, e.Item.ItemIndex) = True Then
                        Ck.Checked = False
                        e.Item.Cells(4).ForeColor = Drawing.Color.Gray
                        e.Item.Cells(4).Font.Strikeout = True
                    Else
                        Ck.Checked = True
                        e.Item.Cells(4).ForeColor = Drawing.Color.Black
                        e.Item.Cells(4).Font.Strikeout = False
                    End If
                Else
                    Ck.Checked = True
                End If

                If Ck.Checked = True Then
                    SumEncuestados = SumEncuestados + e.Item.Cells(14).Text
                    SumPersonal = SumPersonal + e.Item.Cells(15).Text
                    SumCalculo = SumCalculo + e.Item.Cells(16).Text

                    SumEncuestados_ = SumEncuestados_ + e.Item.Cells(17).Text
                    SumPersonal_ = SumPersonal_ + e.Item.Cells(18).Text
                    SumCalculo_ = SumCalculo_ + e.Item.Cells(19).Text
                End If

                If e.Item.Cells(7).Text = "0.0 %" Then
                    e.Item.Cells(9).Text = "0.0 %"
                End If
                If e.Item.Cells(11).Text = "0.0" Then
                    e.Item.Cells(13).Text = "0.0"
                End If

                Dim PART As Double = e.Item.Cells(9).Text.Replace("%", "")
                Dim PROM As Double = e.Item.Cells(13).Text

                If PART = 0 Then
                    e.Item.Cells(8).Controls(1).Visible = True
                ElseIf PART > 0 Then
                    e.Item.Cells(8).Controls(3).Visible = True
                Else
                    e.Item.Cells(8).Controls(5).Visible = True
                End If

                If PROM = 0 Then
                    e.Item.Cells(12).Controls(1).Visible = True
                ElseIf PROM > 0 Then
                    e.Item.Cells(12).Controls(3).Visible = True
                Else
                    e.Item.Cells(12).Controls(5).Visible = True
                End If

                'If e.Item.Cells(11).Text = 0.0 Then
                '    e.Item.Visible = False
                'End If

                'Reemplazamos la coma por punto (Pt)
                e.Item.Cells(6).Text = e.Item.Cells(6).Text.Replace(",", ".")
                e.Item.Cells(7).Text = e.Item.Cells(7).Text.Replace(",", ".")
                e.Item.Cells(9).Text = e.Item.Cells(9).Text.Replace(",", ".")
                e.Item.Cells(10).Text = e.Item.Cells(10).Text.Replace(",", ".")
                e.Item.Cells(11).Text = e.Item.Cells(11).Text.Replace(",", ".")
                e.Item.Cells(13).Text = e.Item.Cells(13).Text.Replace(",", ".")

            ElseIf e.Item.ItemType = GridItemType.Footer Then
                '.ToString("P", System.Globalization.CultureInfo.CreateSpecificCulture("es-mx"))

                e.Item.Cells(14).Text = (SumEncuestados).ToString("N1")
                e.Item.Cells(15).Text = (SumPersonal).ToString("N1")
                e.Item.Cells(7).Text = (SumEncuestados / SumPersonal).ToString("P1")
                e.Item.Cells(11).Text = (SumCalculo / SumEncuestados).ToString("N1")

                e.Item.Cells(17).Text = (SumEncuestados_).ToString("N1")
                e.Item.Cells(18).Text = (SumPersonal_).ToString("N1")
                Dim FPart As Double = IIf(SumPersonal_ = 0, 0, (SumEncuestados_ / SumPersonal_))
                Dim FProm As Double = IIf(SumEncuestados_ = 0, 0, (SumCalculo_ / SumEncuestados_))
                e.Item.Cells(6).Text = FPart.ToString("P1")
                e.Item.Cells(10).Text = FProm.ToString("N1")

                Dim PART As Double = (e.Item.Cells(7).Text.Replace("%", "") - e.Item.Cells(6).Text.Replace("%", "")).ToString("N1")
                If PART = 0 Then
                    e.Item.Cells(8).Controls(1).Visible = True
                ElseIf PART > 0 Then
                    e.Item.Cells(8).Controls(3).Visible = True
                Else
                    e.Item.Cells(8).Controls(5).Visible = True
                End If
                e.Item.Cells(9).Text = (PART / 100).ToString("P1")

                Dim PROM As Double = (e.Item.Cells(11).Text - e.Item.Cells(10).Text).ToString("N1")
                If PROM = 0 Then
                    e.Item.Cells(12).Controls(1).Visible = True
                ElseIf PROM > 0 Then
                    e.Item.Cells(12).Controls(3).Visible = True
                Else
                    e.Item.Cells(12).Controls(5).Visible = True
                End If
                e.Item.Cells(13).Text = (PROM).ToString("N1")

                'Reemplazamos la coma por punto (Pt)
                e.Item.Cells(6).Text = e.Item.Cells(6).Text.Replace(",", ".")
                e.Item.Cells(7).Text = e.Item.Cells(7).Text.Replace(",", ".")
                e.Item.Cells(9).Text = e.Item.Cells(9).Text.Replace(",", ".")
                e.Item.Cells(10).Text = e.Item.Cells(10).Text.Replace(",", ".")
                e.Item.Cells(11).Text = e.Item.Cells(11).Text.Replace(",", ".")
                e.Item.Cells(13).Text = e.Item.Cells(13).Text.Replace(",", ".")

                Dim Hlink3 As New RadComboBox
                Dim RItem1 As New RadComboBoxItem
                Dim RItem2 As New RadComboBoxItem
                Dim RItem3 As New RadComboBoxItem
                RItem1.Text = GETPALABRA("Graficar Promedios")
                RItem1.Attributes.Add("OnClick", "window.radopen('GraficasComparativas.aspx?T=1','UserListDialog');return false;")
                RItem2.Text = GETPALABRA("Graficar Participación")
                RItem2.Attributes.Add("OnClick", "window.radopen('GraficasComparativas.aspx?T=2','UserListDialog');return false;")
                RItem3.Text = GETPALABRA("Comparativa Temas")
                RItem3.Attributes.Add("OnClick", "window.radopen('ComparativaTemas.aspx?Tipo=99','UserListDialog');return false;")
                Hlink3.Items.Add(RItem1)
                Hlink3.Items.Add(RItem2)
                Hlink3.Items.Add(RItem3)
                Hlink3.Dispose()
                e.Item.Cells(4).Controls.Add(Hlink3)

                Dim TblPromedios As New DataTable

                Dim Indice As DataColumn = New DataColumn("Indice")
                Indice.DataType = System.Type.GetType("System.Int32")
                Indice.AutoIncrement = True
                TblPromedios.Columns.Add(Indice)

                Dim TEXTO_ACT As DataColumn = New DataColumn("TEXTO_ACT")
                TEXTO_ACT.DataType = System.Type.GetType("System.String")
                TblPromedios.Columns.Add(TEXTO_ACT)

                Dim TOOLTTIP_ACT As DataColumn = New DataColumn("TOOLTTIP_ACT")
                TOOLTTIP_ACT.DataType = System.Type.GetType("System.String")
                TblPromedios.Columns.Add(TOOLTTIP_ACT)

                Dim PROMEDIO_ACT As DataColumn = New DataColumn("PROMEDIO_ACT")
                PROMEDIO_ACT.DataType = System.Type.GetType("System.Double")
                TblPromedios.Columns.Add(PROMEDIO_ACT)

                Dim TOOLTTIP_ANT As DataColumn = New DataColumn("TOOLTTIP_ANT")
                TOOLTTIP_ANT.DataType = System.Type.GetType("System.String")
                TblPromedios.Columns.Add(TOOLTTIP_ANT)

                Dim PROMEDIO_ANT As DataColumn = New DataColumn("PROMEDIO_ANT")
                PROMEDIO_ANT.DataType = System.Type.GetType("System.Double")
                TblPromedios.Columns.Add(PROMEDIO_ANT)

                Dim PARTICIPACION_ACT As DataColumn = New DataColumn("PARTICIPACION_ACT")
                PROMEDIO_ANT.DataType = System.Type.GetType("System.Double")
                TblPromedios.Columns.Add(PARTICIPACION_ACT)

                Dim PARTICIPACION_ANT As DataColumn = New DataColumn("PARTICIPACION_ANT")
                PROMEDIO_ANT.DataType = System.Type.GetType("System.Double")
                TblPromedios.Columns.Add(PARTICIPACION_ANT)

                For Reg As Integer = 0 To Grid2.MasterTableView.Items.Count - 1 '.Item.OwnerTableView.Items.Count - 1
                    Dim RNew As DataRow
                    RNew = TblPromedios.NewRow()
                    With Grid2.MasterTableView
                        Dim Ck As CheckBox = CType(.Items(Reg).Cells(2).Controls(1), CheckBox)
                        If Ck.Checked = True Then
                            If Session("Lenguaje") = "pt-BR" Then
                                RNew.Item(1) = .Items(Reg).Cells(4).Text
                                RNew.Item(2) = CStr(.Items(Reg).Cells(14).Text) & " / " & CStr(.Items(Reg).Cells(15).Text) & " = " & CStr(.Items(Reg).Cells(7).Text)
                                RNew.Item(3) = .Items(Reg).Cells(11).Text / 100
                                RNew.Item(4) = CStr(.Items(Reg).Cells(17).Text) & " / " & CStr(.Items(Reg).Cells(18).Text) & " = " & CStr(.Items(Reg).Cells(6).Text)
                                RNew.Item(5) = .Items(Reg).Cells(10).Text / 100
                                RNew.Item(6) = .Items(Reg).Cells(7).Text.Substring(0, .Items(Reg).Cells(7).Text.Length - 1)
                                RNew.Item(7) = .Items(Reg).Cells(6).Text.Substring(0, .Items(Reg).Cells(6).Text.Length - 1)
                            Else
                                RNew.Item(1) = .Items(Reg).Cells(4).Text
                                RNew.Item(2) = CStr(.Items(Reg).Cells(14).Text) & " / " & CStr(.Items(Reg).Cells(15).Text) & " = " & CStr(.Items(Reg).Cells(7).Text)
                                RNew.Item(3) = .Items(Reg).Cells(11).Text
                                RNew.Item(4) = CStr(.Items(Reg).Cells(17).Text) & " / " & CStr(.Items(Reg).Cells(18).Text) & " = " & CStr(.Items(Reg).Cells(6).Text)
                                RNew.Item(5) = .Items(Reg).Cells(10).Text
                                RNew.Item(6) = .Items(Reg).Cells(7).Text.Substring(0, .Items(Reg).Cells(7).Text.Length - 2)
                                RNew.Item(7) = .Items(Reg).Cells(6).Text.Substring(0, .Items(Reg).Cells(6).Text.Length - 2)
                            End If

                            TblPromedios.Rows.Add(RNew)
                        End If
                    End With
                Next

                Dim RNew1 As DataRow
                RNew1 = TblPromedios.NewRow()
                If Session("Lenguaje") = "pt-BR" Then
                    RNew1.Item(1) = "PROMEDIO"
                    RNew1.Item(2) = CStr(e.Item.Cells(14).Text) & " / " & CStr(e.Item.Cells(15).Text) & " = " & CStr(e.Item.Cells(7).Text)
                    RNew1.Item(3) = e.Item.Cells(11).Text / 100
                    RNew1.Item(4) = CStr(e.Item.Cells(17).Text) & " / " & CStr(e.Item.Cells(18).Text) & " = " & CStr(e.Item.Cells(6).Text)
                    RNew1.Item(5) = e.Item.Cells(10).Text / 100
                    RNew1.Item(6) = e.Item.Cells(7).Text.Substring(0, e.Item.Cells(7).Text.Length - 1)
                    RNew1.Item(7) = e.Item.Cells(6).Text.Substring(0, e.Item.Cells(6).Text.Length - 1)
                Else
                    RNew1.Item(1) = "PROMEDIO"
                    RNew1.Item(2) = CStr(e.Item.Cells(14).Text) & " / " & CStr(e.Item.Cells(15).Text) & " = " & CStr(e.Item.Cells(7).Text)
                    RNew1.Item(3) = e.Item.Cells(11).Text
                    RNew1.Item(4) = CStr(e.Item.Cells(17).Text) & " / " & CStr(e.Item.Cells(18).Text) & " = " & CStr(e.Item.Cells(6).Text)
                    RNew1.Item(5) = e.Item.Cells(10).Text
                    RNew1.Item(6) = e.Item.Cells(7).Text.Substring(0, e.Item.Cells(7).Text.Length - 2)
                    RNew1.Item(7) = e.Item.Cells(6).Text.Substring(0, e.Item.Cells(6).Text.Length - 2)
                End If

                TblPromedios.Rows.Add(RNew1)
                Session("TBL") = Nothing
                Session("TBL") = TblPromedios

                SumEncuestados_ = 0
                SumPersonal_ = 0
                SumCalculo_ = 0
                SumEncuestados = 0
                SumPersonal = 0
                SumCalculo = 0


                If Not Session("Recalcular") Is Nothing Then
                    Hlink3.Items(2).Visible = False
                Else
                    Hlink3.Items(2).Visible = True
                End If
            End If
        Catch ex As Exception
            Lerror.Text = ex.Message
            Exit Sub
        End Try
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

    Private Sub Grid2_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles Grid2.SortCommand
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
            Dim PLoad(15) As SqlParameter

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

            If RadioButtonList1.SelectedIndex = 1 Then
                Session("CveSistema") = 13
                PLoad(8) = New SqlParameter("@CVESISTEMA", 13)
            Else
                Session("CveSistema") = 3
                PLoad(8) = New SqlParameter("@CVESISTEMA", 3)
            End If

            PLoad(9) = New SqlParameter("@AÑO_ACTUAL1", RCBAñoActual1.SelectedValue)
            PLoad(10) = New SqlParameter("@AÑO_ACTUAL2", RCBAñoActual2.SelectedValue)
            PLoad(11) = New SqlParameter("@AÑO_ANTERIOR1", RCBAñoAnterior1.SelectedValue)
            PLoad(12) = New SqlParameter("@AÑO_ANTERIOR2", RCBAñoAnterior2.SelectedValue)
            PLoad(13) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(14) = New SqlParameter("@USUARIO", Session("USUARIO"))
            PLoad(15) = New SqlParameter("@IDIOMA", Session("Idioma"))

            Ds = DatosBD.FuncionConPar("SP_BUSQUEDA_COMPARATIVAS", PLoad, Lerror.Text)

            If Session("Lenguaje") = "en-US" Then
                Ds.Tables(1).Columns(3).ColumnName = "Category"
                Ds.Tables(1).Columns(4).ColumnName = "Previous Average"
                Ds.Tables(1).Columns(5).ColumnName = "Average"
                Ds.Tables(1).Columns(6).ColumnName = "GAP"

            ElseIf Session("Lenguaje") = "pt-BR" Then


            End If

            Session("DSBench") = Ds.Tables(1)

            Dim TBL As New DataTable
            TBL = Ds.Tables(0)
            Grid2.DataSource = TBL
            Grid2.DataBind()
        Catch ex As Exception
            Lerror.Text = ex.Message & " " & ex.StackTrace
        End Try
    End Sub

    Protected Sub BFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BFiltrar.Click
        Session("SesTipoOperacion") = Nothing
        Session("Recalcular") = Nothing
        Llenargrid_Dinamico()
    End Sub

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

    Sub Exportar()
        Grid2.MasterTableView.ExportToExcel()
    End Sub

    Sub Actualizar()
        Dim Val() As Integer
        'Dim Excluidos As String = ""
        Dim con As Integer = 0
        For i As Integer = 0 To Grid2.MasterTableView.Items.Count - 1
            Dim Ck As CheckBox = CType(Grid2.MasterTableView.Items(i).Cells(2).Controls(1), CheckBox)
            If Ck.Checked = False Then
                ReDim Preserve Val(con)
                Val(con) = i
                con = con + 1
                'If Excluidos.Length = 0 Then
                '    Excluidos = "'" & Grid2.MasterTableView.Items(i).Cells(3).Text & "'"
                'Else
                '    Excluidos = Excluidos & ",'" & Grid2.MasterTableView.Items(i).Cells(3).Text & "'"
                'End If
            End If
        Next
        'Session("Excluidos") = Excluidos
        Session("Recalcular") = Val
        Llenargrid_Dinamico()
    End Sub
End Class
Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Partial Public Class AnalisisInformacion
    Inherits System.Web.UI.Page

    Dim contador As Integer

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
                Unidades()
                Comparativas()
                Sistemas()
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Private Sub RadGrid1_CustomAggregate(sender As Object, e As GridCustomAggregateEventArgs) Handles RadGrid1.CustomAggregate
        Dim dtTable As DataTable = CType(Session("AnioEstudio"), DataTable)
        Dim Anio As String
        If DirectCast(e.Column, Telerik.Web.UI.GridBoundColumn).UniqueName = dtTable.Rows(0).Item(1).ToString Then
            Dim personas As Double = 0
            Dim calculo As Double = 0
            Anio = dtTable.Rows(0).Item(1).ToString
            For Each item As GridDataItem In RadGrid1.MasterTableView.Items
                personas += Convert.ToDouble(item("S" & Anio).Text)

                calculo += Convert.ToDouble(item("C" & Anio).Text)
            Next
            If calculo <> 0.0 Then
                e.Result = calculo / personas
            Else
                e.Result = 0.0
            End If

        ElseIf DirectCast(e.Column, Telerik.Web.UI.GridBoundColumn).UniqueName = dtTable.Rows(1).Item(1).ToString Then
            Dim personas As Double = 0
            Dim calculo As Double = 0
            Anio = dtTable.Rows(1).Item(1).ToString
            For Each item As GridDataItem In RadGrid1.MasterTableView.Items
                personas += Convert.ToDouble(item("S" & Anio).Text)

                calculo += Convert.ToDouble(item("C" & Anio).Text)
            Next
            If calculo <> 0.0 Then
                e.Result = calculo / personas
            Else
                e.Result = 0.0
            End If

        ElseIf DirectCast(e.Column, Telerik.Web.UI.GridBoundColumn).UniqueName = dtTable.Rows(2).Item(1).ToString Then
            Dim personas As Double = 0
            Dim calculo As Double = 0
            Anio = dtTable.Rows(2).Item(1).ToString
            For Each item As GridDataItem In RadGrid1.MasterTableView.Items
                personas += Convert.ToDouble(item("S" & Anio).Text)

                calculo += Convert.ToDouble(item("C" & Anio).Text)
            Next
            If calculo <> 0.0 Then
                e.Result = calculo / personas
            Else
                e.Result = 0.0
            End If

        ElseIf DirectCast(e.Column, Telerik.Web.UI.GridBoundColumn).UniqueName = dtTable.Rows(3).Item(1).ToString Then
            Dim personas As Double = 0
            Dim calculo As Double = 0
            Anio = dtTable.Rows(3).Item(1).ToString
            For Each item As GridDataItem In RadGrid1.MasterTableView.Items
                personas += Convert.ToDouble(item("S" & Anio).Text)

                calculo += Convert.ToDouble(item("C" & Anio).Text)
            Next
            If calculo <> 0.0 Then
                e.Result = calculo / personas
            Else
                e.Result = 0.0
            End If

        ElseIf DirectCast(e.Column, Telerik.Web.UI.GridBoundColumn).UniqueName = dtTable.Rows(4).Item(1).ToString Then
            Dim personas As Double = 0
            Dim calculo As Double = 0
            Anio = dtTable.Rows(4).Item(1).ToString
            For Each item As GridDataItem In RadGrid1.MasterTableView.Items
                personas += Convert.ToDouble(item("S" & Anio).Text)

                calculo += Convert.ToDouble(item("C" & Anio).Text)
            Next
            If calculo <> 0.0 Then
                e.Result = calculo / personas
            Else
                e.Result = 0.0
            End If

        ElseIf DirectCast(e.Column, Telerik.Web.UI.GridBoundColumn).UniqueName = dtTable.Rows(5).Item(1).ToString Then
            Dim personas As Double = 0
            Dim calculo As Double = 0
            Anio = dtTable.Rows(5).Item(1).ToString
            For Each item As GridDataItem In RadGrid1.MasterTableView.Items
                personas += Convert.ToDouble(item("S" & Anio).Text)

                calculo += Convert.ToDouble(item("C" & Anio).Text)
            Next
            If calculo <> 0.0 Then
                e.Result = calculo / personas
            Else
                e.Result = 0.0
            End If
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.CommandItem Then
            If RUnidad.SelectedItems.Count <> 0 Then
                Dim GIC As GridCommandItem = DirectCast(e.Item, GridCommandItem)
                Dim RD As RadComboBox = DirectCast(GIC.FindControl("RcboTipoOperacion"), RadComboBox)
                RD.Items.Clear()
                RD.Enabled = True

                Dim PLoad(3) As SqlParameter
                PLoad(0) = New SqlParameter("@TIPO", 7)
                PLoad(1) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
                PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
                PLoad(3) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
                'Dim DS As DataSet = DatosBDCubo.FuncionConPar("[Sp_CargaEstructura]", PLoad, "")

                Cargar.ComboParametros(RD, "[Sp_CargaEstructura]", PLoad, "NomArea", "CveArea", 1, True, Session("Lenguaje"))

                If Not Session("SesTipoOperacion") Is Nothing Then
                    RD.FindItemByValue(Session("SesTipoOperacion")).Selected = True
                End If
            End If
        ElseIf e.Item.ItemType = GridItemType.Header Then
            contador = 0
            'Cambio de Visible por Display para evadir error en javascript
            RadGrid1.MasterTableView.AutoGeneratedColumns(3).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(3).Visible = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(4).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(4).Visible = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(6).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(6).Visible = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(7).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(7).Visible = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(9).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(9).Visible = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(10).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(10).Visible = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(12).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(12).Visible = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(13).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(13).Visible = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(15).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(15).Visible = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(16).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(16).Visible = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(18).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(18).Visible = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(19).Display = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(19).Visible = True
        ElseIf e.Item.ItemType = GridItemType.AlternatingItem OrElse e.Item.ItemType = GridItemType.Item Then

            contador = contador + 1

            'Promedio
            e.Item.Cells(4).BackColor = GETCOLOR(e.Item.Cells(4).Text)
            e.Item.Cells(4).ForeColor = GETCOLOR2(e.Item.Cells(4).Text)
            e.Item.Cells(7).BackColor = GETCOLOR(e.Item.Cells(7).Text)
            e.Item.Cells(7).ForeColor = GETCOLOR2(e.Item.Cells(7).Text)
            e.Item.Cells(10).BackColor = GETCOLOR(e.Item.Cells(10).Text)
            e.Item.Cells(10).ForeColor = GETCOLOR2(e.Item.Cells(10).Text)
            e.Item.Cells(13).BackColor = GETCOLOR(e.Item.Cells(13).Text)
            e.Item.Cells(13).ForeColor = GETCOLOR2(e.Item.Cells(13).Text)
            e.Item.Cells(16).BackColor = GETCOLOR(e.Item.Cells(16).Text)
            e.Item.Cells(16).ForeColor = GETCOLOR2(e.Item.Cells(16).Text)
            e.Item.Cells(19).BackColor = GETCOLOR(e.Item.Cells(19).Text)
            e.Item.Cells(19).ForeColor = GETCOLOR2(e.Item.Cells(19).Text)
        ElseIf e.Item.ItemType = GridItemType.Footer Then
            If RPregunta.SelectedItems.Count <> 0 Then
                Session("NIVEL") = 3
            ElseIf RTema.SelectedItems.Count <> 0 Then
                Session("NIVEL") = 2
            ElseIf RSistema.SelectedItems.Count <> 0 Then
                Session("NIVEL") = 1
            Else
                Session("NIVEL") = 1
            End If

            e.Item.Cells(2).Text = "Total: " & contador

            Dim boton As New LinkButton
            boton.Text = "General"
            boton.Attributes.Add("OnClick", "window.radopen('GraficaAnalisis.ASPX','RadDetalles');return false;")
            e.Item.Cells(3).Controls.Add(boton)

            'Cambio de Display por Visible para visualizar Footer
            RadGrid1.MasterTableView.AutoGeneratedColumns(3).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(3).Visible = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(4).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(4).Visible = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(6).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(6).Visible = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(7).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(7).Visible = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(9).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(9).Visible = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(10).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(10).Visible = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(12).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(12).Visible = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(13).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(13).Visible = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(15).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(15).Visible = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(16).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(16).Visible = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(18).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(18).Visible = False
            RadGrid1.MasterTableView.AutoGeneratedColumns(19).Display = True
            RadGrid1.MasterTableView.AutoGeneratedColumns(19).Visible = False
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
        ElseIf Numero >= 90.0 And Numero <= 100.0 Then
            Return Drawing.Color.DarkGreen
        Else
            Return Drawing.Color.Gray
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

    Sub ColFooter()
        Dim footeritem As GridFooterItem = DirectCast(RadGrid1.MasterTableView.GetItems(GridItemType.Footer)(0), GridFooterItem)
        For i As Integer = 4 To footeritem.Cells.Count - 2 Step 3
            Dim Calificacion As New Label
            Dim Conteo As New Label
            Dim con As Integer = 0

            Calificacion.Width = Unit.Percentage(100)
            Calificacion.Height = Unit.Percentage(100)
            Calificacion.Text = footeritem.Cells(i).Text
            Calificacion.BackColor = GETCOLOR(footeritem.Cells(i).Text)
            Calificacion.ForeColor = GETCOLOR2(footeritem.Cells(i).Text)
            Calificacion.Visible = True

            Conteo.Width = Unit.Percentage(100)
            Conteo.Height = Unit.Percentage(100)

            For a As Integer = 0 To RadGrid1.Items.Count - 1
                If RadGrid1.Items(a).Cells(i).Text > 0 Then
                    con = con + 1
                End If
            Next
            Conteo.Text = con
            Conteo.Visible = True

            footeritem.Cells(i).Controls.Add(Calificacion)
            footeritem.Cells(i).Controls.Add(Conteo)

            'footeritem.Cells(i).BackColor = GETCOLOR(footeritem.Cells(i).Text)
            'footeritem.Cells(i).ForeColor = GETCOLOR2(footeritem.Cells(i).Text)
        Next
    End Sub


    Protected Sub RUnidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RUnidad.SelectedIndexChanged
        RbnEsquema.SelectedValue = 1
        Session("Esquema") = 1
        RegionPaises()
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Protected Sub RRegionPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RRegionPaises.SelectedIndexChanged
        RbnEsquema.SelectedValue = 1
        Session("Esquema") = 1
        Pais()
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Protected Sub RPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RPaises.SelectedIndexChanged
        RbnEsquema.SelectedValue = 1
        Session("Esquema") = 1
        Territorio()
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Private Sub RTerritorios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RTerritorios.SelectedIndexChanged
        Region()
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Protected Sub RRegiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RRegiones.SelectedIndexChanged
        Subregion()
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Protected Sub RSubregiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RSubregiones.SelectedIndexChanged
        CentroDeTrabajo()
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Protected Sub RCentroDeTrabajo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RCentroDeTrabajo.SelectedIndexChanged
        CARGAR_GRID()
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Sub Comparativas()
        Dim Lerror As String = String.Empty
        Dim PLoad(0) As SqlParameter
        PLoad(0) = New SqlParameter("@USUARIO", Session("Usuario"))
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_DWVerComparativa]", PLoad, Lerror)

        RComparativas.DataSource = DS.Tables(0)
        RComparativas.DataTextField = "NombreComparativa"
        RComparativas.DataValueField = "CveComparativa"
        RComparativas.DataBind()
    End Sub

    Sub Sistemas()
        RSistema.Items.Clear()
        RTema.Items.Clear()
        RPregunta.Items.Clear()
        Dim Lerror As String = String.Empty
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 8)
        PLoad(1) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        PLoad(2) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RSistema.DataSource = DS.Tables(0)
        RSistema.DataTextField = "NomSistema"
        RSistema.DataValueField = "CveSistema"
        RSistema.DataBind()
    End Sub

    Sub Temas()
        RTema.Items.Clear()
        RPregunta.Items.Clear()
        Dim Lerror As String = String.Empty
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 9)
        PLoad(1) = New SqlParameter("@CVESISTEMA", RSistema.SelectedValue)
        PLoad(2) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RTema.DataSource = DS.Tables(0)
        RTema.DataTextField = "TemaEspanol"
        RTema.DataValueField = "CveTema"
        RTema.DataBind()
    End Sub

    Sub Preguntas()
        RPregunta.Items.Clear()
        Dim Lerror As String = String.Empty
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 10)
        PLoad(1) = New SqlParameter("@CVESISTEMA", RSistema.SelectedValue)
        PLoad(2) = New SqlParameter("@CVETEMA", RTema.SelectedValue)
        PLoad(3) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RPregunta.DataSource = DS.Tables(0)
        RPregunta.DataTextField = "PreguntaEspanol"
        RPregunta.DataValueField = "CvePregunta"
        RPregunta.DataBind()
    End Sub

    Sub Unidades()
        RRegionPaises.Items.Clear()
        RPaises.Items.Clear()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()
        RadGrid1.DataSource = Nothing

        Dim Lerror As String = String.Empty
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 0)
        PLoad(1) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(2) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RUnidad.DataSource = DS.Tables(0)
        RUnidad.DataTextField = "NomDivision"
        RUnidad.DataValueField = "CveDivision"
        RUnidad.DataBind()

        If RUnidad.Items.Count = 1 Then
            RUnidad.Items(0).Selected = True
            RegionPaises()
        End If

        CARGAR_GRID()
    End Sub

    Sub RegionPaises()
        RRegionPaises.Items.Clear()
        RPaises.Items.Clear()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()
        RadGrid1.DataSource = Nothing


        Dim Lerror As String = String.Empty
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 1)
        PLoad(1) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(3) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RRegionPaises.DataSource = DS.Tables(0)
        RRegionPaises.DataTextField = "NOMAGRUPADO"
        RRegionPaises.DataValueField = "CVEAGRUPADO"
        RRegionPaises.DataBind()

        If RRegionPaises.Items.Count = 1 Then
            RRegionPaises.Items(0).Selected = True
            Pais()
        End If
        
        CARGAR_GRID()
    End Sub

    Sub Pais()
        RPaises.Items.Clear()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()
        RadGrid1.DataSource = Nothing

        Dim Lerror As String = String.Empty
        Dim PLoad(4) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 2)
        PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", RRegionPaises.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(4) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RPaises.DataSource = DS.Tables(0)
        RPaises.DataTextField = "PAIS"
        RPaises.DataValueField = "CVEPAIS"
        RPaises.DataBind()

        If RPaises.Items.Count = 1 Then
            RPaises.Items(0).Selected = True
            Territorio()
        End If

        CARGAR_GRID()
    End Sub

    Sub Territorio()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()
        RadGrid1.DataSource = Nothing

        Dim Lerror As String = String.Empty
        Dim PLoad(4) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 3)
        PLoad(1) = New SqlParameter("@CVEPAIS", RPaises.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(4) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RTerritorios.DataSource = DS.Tables(0)
        RTerritorios.DataTextField = "TERRITORIO"
        RTerritorios.DataValueField = "CVETERRITORIO"
        RTerritorios.DataBind()

        If RUnidad.SelectedValue = 6 Then
            RbnEsquema.Items(1).Text = "Líder"
            RbnEsquema.Visible = False
            Session("Esquema") = 1
        ElseIf (RUnidad.SelectedValue = 2 And RPaises.SelectedValue = 11) Or RUnidad.SelectedValue = 13 Then 'Filipinas / Grafo
            RbnEsquema.Items(1).Text = "Otros"
            RbnEsquema.SelectedValue = 2
            RbnEsquema.Visible = False
            Session("Esquema") = 2
        Else
            RbnEsquema.SelectedValue = 1
            RbnEsquema.Visible = False
            Session("Esquema") = 1
        End If

        If RTerritorios.Items.Count = 1 Then
            RTerritorios.Items(0).Selected = True
            Region()
        End If

        CARGAR_GRID()
    End Sub

    Sub Region()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()
        RadGrid1.DataSource = Nothing

        Dim Lerror As String = String.Empty
        Dim PLoad(4) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 4)
        PLoad(1) = New SqlParameter("@CVETERRITORIO", RTerritorios.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(4) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RRegiones.DataSource = DS.Tables(0)
        RRegiones.DataTextField = "NOMREGION"
        RRegiones.DataValueField = "CVEREGION"
        RRegiones.DataBind()

        If RRegiones.Items.Count = 1 Then
            RRegiones.Items(0).Selected = True
            Subregion()
        End If

        CARGAR_GRID()
    End Sub

    Sub Subregion()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()
        RadGrid1.DataSource = Nothing

        Dim Lerror As String = String.Empty
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 5)
        PLoad(1) = New SqlParameter("@CVEREGION", RRegiones.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(3) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RSubregiones.DataSource = DS.Tables(0)
        RSubregiones.DataTextField = "NOMSUBREGION"
        RSubregiones.DataValueField = "CVESUBREGION"
        RSubregiones.DataBind()

        If RSubregiones.Items.Count = 1 Then
            RSubregiones.Items(0).Selected = True
            CentroDeTrabajo()
        End If

        CARGAR_GRID()
    End Sub

    Sub CentroDeTrabajo()
        'Session("SesContenedor") = "Subregiones: " & RSubregiones.SelectedItem.Text
        'Session("NIVEL") = 6
        RCentroDeTrabajo.Items.Clear()
        RadGrid1.DataSource = Nothing

        Dim Lerror As String = String.Empty
        Dim PLoad(5) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 6)
        PLoad(1) = New SqlParameter("@CVEREGION", RRegiones.SelectedValue)
        PLoad(2) = New SqlParameter("@CVESUBREGION", RSubregiones.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(4) = New SqlParameter("@CveEsquema", RbnEsquema.SelectedValue)
        PLoad(5) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RCentroDeTrabajo.DataSource = DS.Tables(0)
        RCentroDeTrabajo.DataTextField = "NomEmpresa"
        RCentroDeTrabajo.DataValueField = "CveEmpresa"
        RCentroDeTrabajo.DataBind()

        If RCentroDeTrabajo.Items.Count = 1 Then
            RCentroDeTrabajo.Items(0).Selected = True
        End If

        CARGAR_GRID()
    End Sub

    Sub CARGAR_GRID()
        Try
            Lerror.Text = ""
            LConcepto.Text = ""
            'Session("REmpresas") = DBNull.Value
            Dim PLoad(14) As SqlParameter

            If RSistema.SelectedItems.Count = 0 Then
                Session("RSistema") = DBNull.Value
                PLoad(0) = New SqlParameter("@TIPO", DBNull.Value)
                LConcepto.Text = LConcepto.Text & ""
                Lerror.Text = "Favor de seleccionar un sistema."
                Exit Sub
            Else
                Session("RSistema") = RSistema.SelectedValue
                PLoad(0) = New SqlParameter("@TIPO", RSistema.SelectedValue)
                LConcepto.Text = LConcepto.Text & RSistema.SelectedItem.Text & "/"
            End If

            If RUnidad.SelectedItems.Count = 0 Then
                Session("RUnidad") = DBNull.Value
                PLoad(1) = New SqlParameter("@CVEDIVISION", DBNull.Value)
                LConcepto.Text = LConcepto.Text & ""
            Else
                Session("RUnidad") = RUnidad.SelectedValue
                PLoad(1) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
                LConcepto.Text = LConcepto.Text & RUnidad.SelectedItem.Text & "/"
            End If

            If RRegionPaises.SelectedItems.Count = 0 Then
                Session("RRegionPaises") = DBNull.Value
                PLoad(2) = New SqlParameter("@CVEAGRUPADOPAIS", DBNull.Value)
                LConcepto.Text = LConcepto.Text & ""
            Else
                Session("RRegionPaises") = RRegionPaises.SelectedItem.Value
                PLoad(2) = New SqlParameter("@CVEAGRUPADOPAIS", RRegionPaises.SelectedValue)
                LConcepto.Text = LConcepto.Text & RRegionPaises.SelectedItem.Text & "/"
            End If

            If RPaises.SelectedItems.Count = 0 Then
                Session("RPaises") = DBNull.Value
                PLoad(3) = New SqlParameter("@CVEPAIS", DBNull.Value)
                LConcepto.Text = LConcepto.Text & ""
            Else
                Session("RPaises") = RPaises.SelectedItem.Value
                PLoad(3) = New SqlParameter("@CVEPAIS", RPaises.SelectedValue)
                LConcepto.Text = LConcepto.Text & RPaises.SelectedItem.Text & "/"
            End If

            'Meter concepto area
            If Session("SesTipoOperacion") Is Nothing Or Session("SesTipoOperacion") = "-1" Then
                Session("RTipoOperacion") = DBNull.Value
                PLoad(4) = New SqlParameter("@CVEAREA", DBNull.Value)
                LConcepto.Text = LConcepto.Text & ""
            Else
                Session("RTipoOperacion") = Session("SesTipoOperacion")
                PLoad(4) = New SqlParameter("@CVEAREA", Session("SesTipoOperacion"))
                LConcepto.Text = LConcepto.Text & Session("SesNomTipoOperacion") & "/"
            End If

            If RTerritorios.SelectedValue = "-1" Or RTerritorios.SelectedValue = "" Then
                Session("RTerritorios") = DBNull.Value
                PLoad(5) = New SqlParameter("@CVETERRITORIO", DBNull.Value)
                LConcepto.Text = LConcepto.Text & ""
            Else
                Session("RTerritorios") = RTerritorios.SelectedItem.Value
                PLoad(5) = New SqlParameter("@CVETERRITORIO", RTerritorios.SelectedValue)
                LConcepto.Text = LConcepto.Text & RTerritorios.SelectedItem.Text & "/"
            End If

            If RRegiones.SelectedItems.Count = 0 Then
                Session("RRegiones") = DBNull.Value
                PLoad(6) = New SqlParameter("@CVEREGION", DBNull.Value)
                LConcepto.Text = LConcepto.Text & ""
            Else
                Session("RRegiones") = RRegiones.SelectedItem.Value
                PLoad(6) = New SqlParameter("@CVEREGION", RRegiones.SelectedValue)
                LConcepto.Text = LConcepto.Text & RRegiones.SelectedItem.Text & "/"
            End If

            If RSubregiones.SelectedItems.Count = 0 Then
                Session("RSubregiones") = DBNull.Value
                PLoad(7) = New SqlParameter("@CVESUBREGION", DBNull.Value)
                LConcepto.Text = LConcepto.Text & ""
            Else
                Session("RSubregiones") = RSubregiones.SelectedItem.Value
                PLoad(7) = New SqlParameter("@CVESUBREGION", RSubregiones.SelectedValue)
                LConcepto.Text = LConcepto.Text & RSubregiones.SelectedItem.Text & "/"
            End If

            If RCentroDeTrabajo.SelectedItems.Count = 0 Then
                Session("REmpresas") = DBNull.Value
                PLoad(8) = New SqlParameter("@CVEEMPRESA", DBNull.Value)
                LConcepto.Text = LConcepto.Text & ""
            Else
                Session("REmpresas") = RCentroDeTrabajo.SelectedItem.Value
                PLoad(8) = New SqlParameter("@CVEEMPRESA", RCentroDeTrabajo.SelectedValue)
                LConcepto.Text = LConcepto.Text & RCentroDeTrabajo.SelectedItem.Text & "/"
            End If

            If RTema.SelectedItems.Count = 0 Then
                Session("RTemas") = DBNull.Value
                PLoad(9) = New SqlParameter("@CVETEMA", DBNull.Value)
                LConcepto.Text = LConcepto.Text & ""
            Else
                Session("RTemas") = RTema.SelectedItem.Value
                PLoad(9) = New SqlParameter("@CVETEMA", RTema.SelectedValue)
                LConcepto.Text = LConcepto.Text & RTema.SelectedItem.Text & "/"
            End If

            If RPregunta.SelectedItems.Count = 0 Then
                Session("RPreguntas") = DBNull.Value
                PLoad(10) = New SqlParameter("@CVEPREGUNTA", DBNull.Value)
                LConcepto.Text = LConcepto.Text & ""
            Else
                Session("RPreguntas") = RPregunta.SelectedItem.Value
                PLoad(10) = New SqlParameter("@CVEPREGUNTA", RPregunta.SelectedValue)
                LConcepto.Text = LConcepto.Text & RPregunta.SelectedItem.Text & "/"
            End If

            PLoad(11) = New SqlParameter("@USUARIO", Session("Usuario"))
            PLoad(12) = New SqlParameter("@CVEESQUEMA", RbnEsquema.SelectedValue)
            PLoad(13) = New SqlParameter("@CVEAPLICACION", 2)
            PLoad(14) = New SqlParameter("@IDIOMA", Session("Lenguaje"))

            RadGrid1.DataSource = Nothing
            RadGrid1.DataBind()

            Dim ds As DataSet
            ds = DatosBD.FuncionConPar("[SP_DWConsultaMaster]", PLoad, Lerror.Text)
            Session("AnioEstudio") = ds.Tables(1)
            RadGrid1.DataSource = ds.Tables(0)
            RadGrid1.DataBind()

            For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                Dim colDecimal As GridBoundColumn
                colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                colDecimal.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.FooterStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.Visible = True
                If cont = 0 Then 'CveEmpresa
                    colDecimal.HeaderStyle.Width = 100
                ElseIf cont = 1 Then 'Empresa
                    colDecimal.HeaderStyle.HorizontalAlign = HorizontalAlign.Left
                    colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    colDecimal.FooterStyle.HorizontalAlign = HorizontalAlign.Left
                    colDecimal.HeaderStyle.Width = 400
                ElseIf cont = 3 Or cont = 4 Then 'Sum y Calc
                    'colDecimal.Display = False
                    colDecimal.FooterAggregateFormatString = "{0:N1}"
                    colDecimal.Aggregate = GridAggregateFunction.Sum
                ElseIf cont = 6 Or cont = 7 Then 'Sum y Calc
                    'colDecimal.Display = False
                    colDecimal.FooterAggregateFormatString = "{0:N1}"
                    colDecimal.Aggregate = GridAggregateFunction.Sum
                ElseIf cont = 9 Or cont = 10 Then 'Sum y Calc
                    'colDecimal.Display = False
                    colDecimal.FooterAggregateFormatString = "{0:N1}"
                    colDecimal.Aggregate = GridAggregateFunction.Sum
                ElseIf cont = 12 Or cont = 13 Then 'Sum y Calc
                    'colDecimal.Display = False
                    colDecimal.FooterAggregateFormatString = "{0:N1}"
                    colDecimal.Aggregate = GridAggregateFunction.Sum
                ElseIf cont = 15 Or cont = 16 Then 'Sum y Calc
                    'colDecimal.Display = False
                    colDecimal.FooterAggregateFormatString = "{0:N1}"
                    colDecimal.Aggregate = GridAggregateFunction.Sum
                ElseIf cont = 18 Or cont = 19 Then 'Sum y Calc
                    'colDecimal.Display = False
                    colDecimal.FooterAggregateFormatString = "{0:N1}"
                    colDecimal.Aggregate = GridAggregateFunction.Sum
                Else
                    colDecimal.DataFormatString = "{0:N1}"
                    colDecimal.Aggregate = GridAggregateFunction.Custom
                    colDecimal.HeaderStyle.Width = 100
                End If
            Next

            RadGrid1.Rebind()
            ColFooter()
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Private Sub RadMenu1_ItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu1.ItemClick
        Dim radGridClickedRowIndex As Integer
        radGridClickedRowIndex = Convert.ToInt32(Request.Form("radGridClickedRowIndex"))

        Session("REmpresas") = RadGrid1.MasterTableView.Items(radGridClickedRowIndex).Cells(2).Text

        If RPregunta.SelectedItems.Count <> 0 Then
            Session("NIVEL") = 3
        ElseIf RTema.SelectedItems.Count <> 0 Then
            Session("NIVEL") = 2
        ElseIf RSistema.SelectedItems.Count <> 0 Then
            Session("NIVEL") = 1
        Else
            Session("NIVEL") = 1
        End If

        Select Case e.Item.Text
            Case "Tendencia"
                RadWindowManager1.Windows(0).NavigateUrl = "GraficaAnalisis.aspx"
                RadWindowManager1.Windows(0).VisibleOnPageLoad = True
                Exit Select
        End Select

    End Sub

    Protected Sub RSistema_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RSistema.SelectedIndexChanged
        Temas()
        CARGAR_GRID()
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Protected Sub RTema_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RTema.SelectedIndexChanged
        Preguntas()
        CARGAR_GRID()
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Protected Sub RPregunta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RPregunta.SelectedIndexChanged
        CARGAR_GRID()
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Sub LkAgregar()
        If RadGrid1.Items.Count > 0 Then
            'CARGARCT()
            Dim Ds As New DataSet()
            Dim Dt As New DataTable()
            Dim Dr As DataRow

            LConcepto.Text = Reemplazo(LConcepto.Text)

            If Session("TablaComparativa") Is Nothing Then
                CrearTabla()
                CrearTablaAtajo()
            End If

            Ds = CType(Session("TablaComparativa"), DataSet)
            Dt = Ds.Tables(0)

            Dim filteredRows() As DataRow = Dt.Select("[" + Dt.Columns(0).ColumnName + "] = '" + LConcepto.Text + "'")

            If filteredRows.Count = 0 Then
                Dim Val As String = Nothing
                Dim FooterItem As GridFooterItem = DirectCast(RadGrid1.MasterTableView.GetItems(GridItemType.Footer)(0), GridFooterItem)

                For i As Integer = 3 To FooterItem.Cells.Count - 1
                    Val = CStr(FooterItem.Cells(i).Text) & "|"
                    Exit For
                Next

                For i As Integer = 4 To FooterItem.Cells.Count - 1 Step 3
                    Val = Val & CStr(FooterItem.Cells(i).Text) & "|"
                Next

                Dr = Dt.NewRow()
                For i As Integer = 0 To Ds.Tables(0).Columns.Count - 1
                    If i = 0 Then
                        Dr(i) = LConcepto.Text ' Val.Split("|")(i)
                    Else
                        If Val.Split("|")(i) = 0.0 Then
                            Dr(i) = DBNull.Value
                        Else
                            Dr(i) = Val.Split("|")(i)
                        End If
                    End If
                Next
                Dt.Rows.Add(Dr)
                Session("TablaComparativa") = Ds
                AgregarAtajo()
                RadWindowManager1.Windows(0).VisibleOnPageLoad = False
                Cargar.Mensaje(RadAjaxManager1, "Se ha agregado un nuevo registro a la Comparativa.", "Aviso")
            Else
                Cargar.Mensaje(RadAjaxManager1, "Ya existe ese registro en la Comparativa.", "Aviso")
            End If
        Else
            Cargar.Mensaje(RadAjaxManager1, "No existen registros para agregar a Comparativa", "Aviso")
        End If
    End Sub

    Sub CrearTabla()
        Session("TablaComparativa") = Nothing
        Dim Ds As New DataSet()
        Dim Dt As New DataTable()

        For i As Integer = 1 To RadGrid1.MasterTableView.AutoGeneratedColumns.Count - 1
            Dim columna As GridBoundColumn
            columna = RadGrid1.MasterTableView.AutoGeneratedColumns(i)
            If columna.Visible = True Then
                Dt.Columns.Add(New DataColumn(columna.HeaderText, GetType(String)))
            End If
        Next
        Ds.Tables.Add(Dt)
        Session("TablaComparativa") = Ds
    End Sub

    Sub AgregarAtajo()
        Dim Ds As New DataSet()
        Dim Dt As New DataTable()

        Ds = CType(Session("TablaAtajos"), DataSet)
        Dt = Ds.Tables(0)

        Dim Dr As DataRow
        Dr = Dt.NewRow()

        Dr(0) = LConcepto.Text
        Dr(1) = Session("RUnidad")
        Dr(2) = Session("RRegionPaises")
        Dr(3) = Session("RPaises")
        Dr(4) = Session("RTipoOperacion")
        Dr(5) = Session("RTerritorios")
        Dr(6) = Session("RRegiones")
        Dr(7) = Session("RSubregiones")
        Dr(8) = Session("REmpresas")
        Dr(9) = Session("RSistema")
        Dr(10) = Session("RTemas")
        Dr(11) = Session("RPreguntas")

        Dt.Rows.Add(Dr)
        Session("TablaAtajos") = Ds
    End Sub

    Sub CrearTablaAtajo()
        Session("TablaAtajos") = Nothing
        Dim Ds As New DataSet()
        Dim Dt As New DataTable()
        Dt.Columns.Add(New DataColumn("Concepto"))
        Dt.Columns.Add(New DataColumn("CveDivision"))
        Dt.Columns.Add(New DataColumn("CveAgrupado"))
        Dt.Columns.Add(New DataColumn("CvePais"))
        Dt.Columns.Add(New DataColumn("CveArea"))
        Dt.Columns.Add(New DataColumn("CveTerritorio"))
        Dt.Columns.Add(New DataColumn("CveRegion"))
        Dt.Columns.Add(New DataColumn("CveSubRegion"))
        Dt.Columns.Add(New DataColumn("CveEmpresa"))
        Dt.Columns.Add(New DataColumn("CveSistema"))
        Dt.Columns.Add(New DataColumn("CveTema"))
        Dt.Columns.Add(New DataColumn("CvePregunta"))
        Ds.Tables.Add(Dt)
        Session("TablaAtajos") = Ds
    End Sub

    Function Reemplazo(ByVal Texto As String) As String
        Dim Concepto As String = Texto
        Concepto = Concepto.Replace(",", "")
        Concepto = Concepto.Replace(":", "")
        Concepto = Concepto.Replace(";", "")
        Return Concepto
    End Function

    Sub Ver()
        Session("NIVEL") = 4
        Session("REmpresas") = DBNull.Value
        RadWindowManager1.Windows(0).NavigateUrl = "GraficaAnalisis.aspx"
        RadWindowManager1.Windows(0).VisibleOnPageLoad = True
    End Sub

    Sub LkBorrar()
        Session("TablaComparativa") = Nothing
        Cargar.Mensaje(RadAjaxManager1, "Se han eliminado los registros de la Comparativa.", "Aviso")
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Sub LkLimpiar()
        RUnidad.Items.Clear()
        RRegionPaises.Items.Clear()
        RPaises.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()
        RUnidad.SelectedIndex = -1
        Session("SesTipoOperacion") = Nothing
        RbnEsquema.SelectedValue = 1
        Session("Esquema") = 1
        Unidades()
        CARGAR_GRID()
        Cargar.Mensaje(RadAjaxManager1, "Se han limpiado los filtros de la Estructura Organizacional.", "Aviso")
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Sub Exportar()
        RadGrid1.MasterTableView.ExportToExcel()
    End Sub

    Protected Sub BBorrar_Click(sender As Object, e As EventArgs)
        If RComparativas.SelectedItems.Count > 0 Then
            Dim Dset As DataSet
            Dim Par(0) As SqlParameter
            Par(0) = New SqlParameter("@CVECOMPARATIVA", RComparativas.SelectedValue)

            Dset = DatosBD.FuncionConPar("[SP_DWBorraComparativa]", Par, Lerror.Text)

            Cargar.Mensaje(RadAjaxManager1, "Se borró la Comparativa con éxito.", "Aviso")
            Comparativas()
            RadWindowManager1.Windows(0).VisibleOnPageLoad = False
        Else
            Lerror.Text = "Favor de seleccionar una Comparativa."
        End If
    End Sub

    Protected Sub BVerComparativa_Click(sender As Object, e As EventArgs)
        Try
            If RComparativas.SelectedItems.Count <> 0 Then
                Dim DS As DataSet
                Dim P(2) As SqlParameter
                P(0) = New SqlParameter("@CVECOMPARATIVA", RComparativas.SelectedValue)
                P(1) = New SqlParameter("@USUARIO", Session("Usuario"))
                P(2) = New SqlParameter("@CVEAPLICACION", 2)
                DS = DatosBD.FuncionConPar("[SP_DWConsultaComparativa]", P, Lerror.Text)
                Session("TablaComparativa") = DS

                Dim Dset As New DataSet
                Dset.Tables.Add(DS.Tables(1).Copy)
                Session("TablaAtajos") = Dset
                Ver()
            Else
                RadWindowManager1.Windows(0).VisibleOnPageLoad = False
            End If
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub RcboTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim RCboTop As RadComboBox = DirectCast(sender, RadComboBox)
        Session("SesTipoOperacion") = RCboTop.SelectedValue
        Session("SesNomTipoOperacion") = RCboTop.Text
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
        CARGAR_GRID()
    End Sub

    Protected Sub RbnEsquema_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("Esquema") = RbnEsquema.SelectedValue
    End Sub
End Class
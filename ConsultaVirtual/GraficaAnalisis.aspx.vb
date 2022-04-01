Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web.UI.DataVisualization.Charting

Partial Public Class GraficaAnalisis
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
                Dim DS As DataSet
                Dim Empresa As String
                If Session("NIVEL") = 1 Then 'Empresas
                    Dim P(11) As SqlParameter
                    P(0) = New SqlParameter("@TIPO", Session("RSistema"))
                    P(1) = New SqlParameter("@CVEDIVISION", Session("RUnidad"))
                    P(2) = New SqlParameter("@CVEAGRUPADOPAIS", Session("RRegionPaises"))
                    P(3) = New SqlParameter("@CVEPAIS", Session("RPaises"))
                    P(4) = New SqlParameter("@CVEAREA", Session("RTipoOperacion"))
                    P(5) = New SqlParameter("@CVETERRITORIO", Session("RTerritorios"))
                    P(6) = New SqlParameter("@CVEREGION", Session("RRegiones"))
                    P(7) = New SqlParameter("@CVESUBREGION", Session("RSubregiones"))
                    P(8) = New SqlParameter("@CVEEMPRESA", Session("REmpresas"))
                    P(9) = New SqlParameter("@USUARIO", Session("Usuario"))
                    P(10) = New SqlParameter("@CVEESQUEMA", Session("Esquema"))
                    P(11) = New SqlParameter("@CVEAPLICACION", 2)

                    DS = DatosBD.FuncionConPar("[SP_DWConsultaEmpresas_Grafica]", P, Lerror.Text)
                    If DS.Tables.Count > 1 Then
                        Empresa = DS.Tables(1).Rows(0).Item(0)
                    Else
                        Empresa = DS.Tables(0).Rows(0).Item(1)
                    End If
                    Graficar(DS.Tables(0), "ANIOESTUDIO", "PROMEDIO", "AÑOS", "PROMEDIO", "Gráfica de Comportamiento", Empresa, True)
                ElseIf Session("NIVEL") = 2 Then 'Temas
                    Dim P(12) As SqlParameter
                    P(0) = New SqlParameter("@TIPO", Session("RSistema"))
                    P(1) = New SqlParameter("@CVEDIVISION", Session("RUnidad"))
                    P(2) = New SqlParameter("@CVEAGRUPADOPAIS", Session("RRegionPaises"))
                    P(3) = New SqlParameter("@CVEPAIS", Session("RPaises"))
                    P(4) = New SqlParameter("@CVEAREA", Session("RTipoOperacion"))
                    P(5) = New SqlParameter("@CVETERRITORIO", Session("RTerritorios"))
                    P(6) = New SqlParameter("@CVEREGION", Session("RRegiones"))
                    P(7) = New SqlParameter("@CVESUBREGION", Session("RSubregiones"))
                    P(8) = New SqlParameter("@CVEEMPRESA", Session("REmpresas"))
                    P(9) = New SqlParameter("@CVETEMA", Session("RTemas"))
                    P(10) = New SqlParameter("@USUARIO", Session("Usuario"))
                    P(11) = New SqlParameter("@CVEESQUEMA", Session("Esquema"))
                    P(12) = New SqlParameter("@CVEAPLICACION", 2)

                    DS = DatosBD.FuncionConPar("[SP_DWConsultaTemas_Grafica]", P, Lerror.Text)
                    If DS.Tables.Count > 1 Then
                        Empresa = DS.Tables(1).Rows(0).Item(0)
                    Else
                        Empresa = DS.Tables(0).Rows(0).Item(1)
                    End If
                    Graficar(DS.Tables(0), "ANIOESTUDIO", "PROMEDIO", "AÑOS", "PROMEDIO", "Gráfica de Comportamiento", Empresa, True)
                ElseIf Session("NIVEL") = 3 Then 'Preguntas
                    Dim P(13) As SqlParameter
                    P(0) = New SqlParameter("@TIPO", Session("RSistema"))
                    P(1) = New SqlParameter("@CVEDIVISION", Session("RUnidad"))
                    P(2) = New SqlParameter("@CVEAGRUPADOPAIS", Session("RRegionPaises"))
                    P(3) = New SqlParameter("@CVEPAIS", Session("RPaises"))
                    P(4) = New SqlParameter("@CVEAREA", Session("RTipoOperacion"))
                    P(5) = New SqlParameter("@CVETERRITORIO", Session("RTerritorios"))
                    P(6) = New SqlParameter("@CVEREGION", Session("RRegiones"))
                    P(7) = New SqlParameter("@CVESUBREGION", Session("RSubregiones"))
                    P(8) = New SqlParameter("@CVEEMPRESA", Session("REmpresas"))
                    P(9) = New SqlParameter("@CVETEMA", Session("RTemas"))
                    P(10) = New SqlParameter("@CVEPREGUNTA", Session("RPreguntas"))
                    P(11) = New SqlParameter("@USUARIO", Session("Usuario"))
                    P(12) = New SqlParameter("@CVEESQUEMA", Session("Esquema"))
                    P(13) = New SqlParameter("@CVEAPLICACION", 2)

                    DS = DatosBD.FuncionConPar("[SP_DWConsultaPreguntas_Grafica]", P, Lerror.Text)
                    If DS.Tables.Count > 1 Then
                        Empresa = DS.Tables(1).Rows(0).Item(0)
                    Else
                        Empresa = DS.Tables(0).Rows(0).Item(1)
                    End If
                    Graficar(DS.Tables(0), "ANIOESTUDIO", "PROMEDIO", "AÑOS", "PROMEDIO", "Gráfica de Comportamiento", Empresa, True)
                ElseIf Session("NIVEL") = 4 Then 'Comparativa
                    Ver()
                    Panel1.Visible = True
                End If
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Sub Graficar(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)
        Chart1.DataSource = Datos
        Chart1.Series(0).XValueMember = CStr(ValorX)
        Chart1.Series(0).YValueMembers = ValorY
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = TresD
        Chart1.DataBind()
        Chart1.ChartAreas(0).AxisY.Maximum = 110
        Chart1.ChartAreas(0).AxisY.Minimum = 0
        Chart1.ChartAreas(0).AxisX.LabelStyle.IsEndLabelVisible = True
        Chart1.ChartAreas(0).AxisX.Title = AxisX
        Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90
        Chart1.ChartAreas(0).AxisY.Title = AxisY
        Chart1.Titles(0).Text = Titulo1
        Chart1.Titles(1).Text = Titulo2

        If Chart1.Series(0).ChartType = 10 Then 'Columns
            Chart1.Series(0).ShadowOffset = 0
        Else 'Line
            Chart1.Series(0).ShadowOffset = 2
        End If


        Dim annotation As New TextAnnotation()
        annotation.Text = GETPALABRA("Actualizada") & ": " & Now.Date.ToShortDateString
        annotation.ForeColor = Color.Black
        annotation.X = 80
        annotation.Y = 0
        annotation.Font = New Font("Tahoma", 8)
        Chart1.Annotations.Add(annotation)
    End Sub

    Sub Graficar2(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)
        Chart1.DataSource = Datos

        'Chart1.Series(0).XValueMember = CStr(ValorX)
        'Chart1.Series(0).YValueMembers = ValorY
        For n As Integer = 1 To Datos.Columns.Count - 1
            Chart1.Series(n - 1).XValueMember = "Año"
            Chart1.Series(n - 1).YValueMembers = Datos.Columns(n).ColumnName
            Chart1.Series(n - 1).Name = Datos.Columns(n).ColumnName.ToString
            Chart1.Series(n - 1).IsVisibleInLegend = True
        Next

        Chart1.ChartAreas(0).Area3DStyle.Enable3D = TresD
        Chart1.DataBind()
        Dim Max As Double = FindMaxDataTableValue(Datos)
        Dim Min As Double = FindMinDataTableValue(Datos)
        Dim Intervalo As Double = (Max - Min) / 10.0
        If Intervalo = 0 Then
            Max = 110
            Min = 0
            Intervalo = 10
        End If
        Chart1.ChartAreas(0).AxisY.Maximum = Max + Intervalo
        Chart1.ChartAreas(0).AxisY.Minimum = Min - Intervalo
        Chart1.ChartAreas(0).AxisY.Interval = Intervalo
        Chart1.ChartAreas(0).AxisX.LabelStyle.IsEndLabelVisible = True
        Chart1.ChartAreas(0).AxisX.Title = AxisX
        Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90
        Chart1.ChartAreas(0).AxisY.Title = AxisY
        Chart1.Titles(0).Text = Titulo1
        Chart1.Titles(1).Text = Titulo2

        'If Chart1.Series(0).ChartType = 10 Then 'Columns
        '    Chart1.Series(0).ShadowOffset = 0
        'Else 'Line
        '    Chart1.Series(0).ShadowOffset = 2
        'End If

        Dim annotation As New TextAnnotation()
        annotation.Text = GETPALABRA("Actualizada") & ": " & Now.Date.ToShortDateString
        annotation.ForeColor = Color.Black
        annotation.X = 80
        annotation.Y = 0
        annotation.Font = New Font("Tahoma", 8)
        Chart1.Annotations.Add(annotation)


        Dim Imagen As ImageAnnotation = New ImageAnnotation()
        Imagen.X = 1
        Imagen.Y = 1
        Imagen.Image = "~/Imagenes/Estatus/report.png"
        Imagen.PostBackValue = "Back"
        Imagen.ToolTip = "Ver tabla"
        Imagen.Visible = True
        Chart1.Annotations.Add(Imagen)
        Dim Detalle As New TextAnnotation()
        Detalle.Text = "Detalle"
        Detalle.ForeColor = Color.Black
        Detalle.X = 3
        Detalle.Y = 1
        Detalle.Font = New Font("Tahoma", 8)
        Chart1.Annotations.Add(Detalle)
    End Sub

    Private Sub Chart1_Click(sender As Object, e As ImageMapEventArgs) Handles Chart1.Click
        If e.PostBackValue = "Back" Then
            Dim ds As DataSet = CType(Session("TablaComparativa"), DataSet)
            RadGrid1.DataSource = ds
            RadGrid1.DataBind()
            Chart1.Visible = False
            RadGrid1.Visible = True
        End If
    End Sub

    Sub Ver()
        Try
            Dim ds As DataSet = CType(Session("TablaComparativa"), DataSet)
            Dim DT As DataTable = PivotTable(ds.Tables(0))
            'DT.Rows(0).Delete()
            Graficar2(DT, "PROMEDIO", "ANIOESTUDIO", "AÑOS", "PROMEDIO", "Gráfica de Comportamiento", "Comparativa", True)
            RadGrid1.Visible = False
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Sub Exportar()
        RadGrid1.MasterTableView.ExportToExcel()
    End Sub

    Private Function PivotTable(origTable As DataTable) As DataTable
        Dim newTable As New DataTable()
        Dim dr As DataRow = Nothing
        'Add Columns to new Table
        newTable.Columns.Add(New DataColumn("Año", GetType([String])))
        For i As Integer = 0 To origTable.Rows.Count - 1
            newTable.Columns.Add(New DataColumn(origTable.Rows(i).Item(0), GetType([String])))
        Next

        'Execute the Pivot Method
        For cols As Integer = 1 To origTable.Columns.Count - 1
            dr = newTable.NewRow()
            For rows As Integer = 0 To origTable.Rows.Count - 1
                If rows < origTable.Columns.Count Then
                    dr(0) = origTable.Columns(cols).ColumnName
                    ' Add the Column Name in the first Column
                    dr(rows + 1) = origTable.Rows(rows)(cols)
                End If
            Next
            'add the DataRow to the new Table rows collection
            newTable.Rows.Add(dr)
        Next
        Return newTable
    End Function

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem OrElse e.Item.ItemType = GridItemType.Item Then
            'Promedio
            If e.Item.Cells(3).Text <> "&nbsp;" Then
                e.Item.Cells(3).BackColor = GETCOLOR(e.Item.Cells(3).Text)
                e.Item.Cells(3).ForeColor = GETCOLOR2(e.Item.Cells(3).Text)
            End If
            If e.Item.Cells(4).Text <> "&nbsp;" Then
                e.Item.Cells(4).BackColor = GETCOLOR(e.Item.Cells(4).Text)
                e.Item.Cells(4).ForeColor = GETCOLOR2(e.Item.Cells(4).Text)
            End If
            If e.Item.Cells(5).Text <> "&nbsp;" Then
                e.Item.Cells(5).BackColor = GETCOLOR(e.Item.Cells(5).Text)
                e.Item.Cells(5).ForeColor = GETCOLOR2(e.Item.Cells(5).Text)
            End If
            If e.Item.Cells(6).Text <> "&nbsp;" Then
                e.Item.Cells(6).BackColor = GETCOLOR(e.Item.Cells(6).Text)
                e.Item.Cells(6).ForeColor = GETCOLOR2(e.Item.Cells(6).Text)
            End If
            If e.Item.Cells(7).Text <> "&nbsp;" Then
                e.Item.Cells(7).BackColor = GETCOLOR(e.Item.Cells(7).Text)
                e.Item.Cells(7).ForeColor = GETCOLOR2(e.Item.Cells(7).Text)
            End If
            If e.Item.Cells(8).Text <> "&nbsp;" Then
                e.Item.Cells(8).BackColor = GETCOLOR(e.Item.Cells(8).Text)
                e.Item.Cells(8).ForeColor = GETCOLOR2(e.Item.Cells(8).Text)
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
        ElseIf Numero >= 90.0 And Numero <= 100.0 Then
            Return Drawing.Color.Green
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

    Private Function FindMaxDataTableValue(ByRef dt As DataTable) As Double
        Dim Cont As Integer = 0
        Dim Max() As Double

        For R As Integer = 0 To dt.Rows.Count - 1
            For C As Integer = 1 To dt.Columns.Count - 1
                If dt.Rows(R).Item(C).ToString <> "" Then
                    ReDim Preserve Max(Cont)
                    Max(Cont) = dt.Rows(R).Item(C).ToString
                    Cont = Cont + 1
                End If
            Next
        Next
        Return Max.Max()
    End Function

    Private Function FindMinDataTableValue(ByRef dt As DataTable) As Double
        Dim Cont As Integer = 0
        Dim Min() As Double

        For R As Integer = 0 To dt.Rows.Count - 1
            For C As Integer = 1 To dt.Columns.Count - 1
                If dt.Rows(R).Item(C).ToString <> "0" And dt.Rows(R).Item(C).ToString <> "" Then
                    ReDim Preserve Min(Cont)
                    Min(Cont) = dt.Rows(R).Item(C).ToString
                    Cont = Cont + 1
                End If
            Next
        Next
        Return Min.Min()
    End Function

    Protected Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BGuardar.Click
        Try
            If TComparativa.Text.Trim <> "" Then
                Dim Dset As DataSet
                Dim ds As DataSet = CType(Session("TablaAtajos"), DataSet)
                Dim CveComparativa As Integer

                Dim Par(2) As SqlParameter
                Par(0) = New SqlParameter("@TIPO", 1)
                Par(1) = New SqlParameter("@NOMBRECOMPARATIVA", TComparativa.Text.Trim)
                Par(2) = New SqlParameter("@USUARIO", Session("Usuario"))

                Dset = DatosBD.FuncionConPar("[SP_DWGuardaComparativa]", Par, Lerror.Text)
                CveComparativa = Dset.Tables(0).Rows(0).Item(0)

                For n As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(n)
                        Dim P(13) As SqlParameter
                        P(0) = New SqlParameter("@TIPO", 2)
                        P(1) = New SqlParameter("@CVECOMPARATIVA", CveComparativa)
                        P(2) = New SqlParameter("@CONCEPTO", .Item("Concepto"))
                        P(3) = New SqlParameter("@CVEDIVISION", .Item("CveDivision"))
                        P(4) = New SqlParameter("@CVEAGRUPADOPAIS", .Item("CveAgrupado"))
                        P(5) = New SqlParameter("@CVEPAIS", .Item("CvePais"))
                        P(6) = New SqlParameter("@CVETERRITORIO", .Item("CveTerritorio"))
                        P(7) = New SqlParameter("@CVEREGION", .Item("CveRegion"))
                        P(8) = New SqlParameter("@CVESUBREGION", .Item("CveSubRegion"))
                        P(9) = New SqlParameter("@CVEAREA", .Item("CveArea"))
                        P(10) = New SqlParameter("@CVEEMPRESA", .Item("CveEmpresa"))
                        P(11) = New SqlParameter("@CVESISTEMA", .Item("CveSistema"))
                        P(12) = New SqlParameter("@CVETEMA", .Item("CveTema"))
                        P(13) = New SqlParameter("@CVEPREGUNTA", .Item("CvePregunta"))

                        Dset = DatosBD.FuncionConPar("[SP_DWGuardaComparativa]", P, Lerror.Text)
                    End With
                Next
                'Lerror.Text = "Se guardó la Comparativa con éxito."
                Lerror.Text = "<script>CloseAndRedirect()</script>"
            Else
                Lerror.Text = "Favor de darle un nombre a la Comparativa."
            End If
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
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

End Class
Imports Telerik.Web.UI
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.IO

Public Class GraficasJI
    Inherits System.Web.UI.Page
    Dim TipoAgrupado As String
    Dim TipoGrafica As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            'TipoAgrupado = Request.Params("Tipo")
            'Session("CveEmpresa") = Request.Params("CveE")

            'TipoAgrupado = "Agrupado"
            TipoAgrupado = "CT"
            Session("CveEmpresa") = 6631
            TipoGrafica = "Estilos"

            Dim ds3 As New DataSet
            Dim P3(1) As SqlParameter
            P3(0) = New SqlParameter("@TIPO", 13)
            P3(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
            ds3 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P3, Lerror.Text)

            Session("NombreEmpresa") = ds3.Tables(0).Rows(0).Item(0)


            If TipoAgrupado = "CT" Then 'por centro de trabajo
                If TipoGrafica = "Microclima" Then
                    'BUBBLES
                    Dim ds As New DataSet
                    Dim P(1) As SqlParameter
                    P(0) = New SqlParameter("@TIPO", 2)
                    P(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                    ds = DatosBD.FuncionConPar("SP_GRAFICASJI", P, Lerror.Text)

                    'BARCHART
                    Dim ds6 As New DataSet
                    Dim P6(1) As SqlParameter
                    P6(0) = New SqlParameter("@TIPO", 7)
                    P6(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                    ds6 = DatosBD.FuncionConPar("SP_GRAFICASJI", P6, Lerror.Text)

                    'PIE
                    Dim ds2 As New DataSet
                    Dim P2(1) As SqlParameter
                    P2(0) = New SqlParameter("@TIPO", 3)
                    P2(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                    ds2 = DatosBD.FuncionConPar("SP_GRAFICASJI", P2, Lerror.Text)


                    'COLULMNCHART
                    Dim ds4 As New DataSet
                    Dim P4(1) As SqlParameter
                    P4(0) = New SqlParameter("@TIPO", 5)
                    P4(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                    ds4 = DatosBD.FuncionConPar("SP_GRAFICASJI", P4, Lerror.Text)


                    Graficar(ds.Tables(0), "TEXTO", "VALOR", "", "", Session("NombreEmpresa"), "Grafica Microclima", True)
                    Graficar2(ds6.Tables(0), "DescEstilo", "DescEstilo", "", "", Session("NombreEmpresa"), "Grado de presencia de las dimensiones de microclima", True)
                    GraficarPie(ds2.Tables(0), "TEXTO", "VALOR", "", "PORCENTAJE", Session("NombreEmpresa"), "Tipo de Microclima que genera líderes", False)

                    Graficar3(ds4.Tables(0), "DescEstilo", "Porcentaje", "", "", Session("NombreEmpresa"), "Distribución Dimensiones MicroClima", False)

                Else
                    'BUBBLES
                    'Dim ds As New DataSet
                    'Dim P(1) As SqlParameter
                    'P(0) = New SqlParameter("@TIPO", 6)
                    'P(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                    'ds = DatosBD.FuncionConPar("SP_GRAFICASJI", P, Lerror.Text)

                    Dim ds As New DataSet
                    Dim P(0) As SqlParameter
                    P(0) = New SqlParameter("@TIPO", 3)
                    ds = DatosBD.FuncionConPar("ARLA_PagPrincipal", P, Lerror.Text)


                    'BARCHART
                    Dim ds6 As New DataSet
                    Dim P6(1) As SqlParameter
                    P6(0) = New SqlParameter("@TIPO", 0)
                    P6(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                    ds6 = DatosBD.FuncionConPar("SP_GRAFICASJI", P6, Lerror.Text)

                    'PIE
                    Dim ds2 As New DataSet
                    Dim P2(1) As SqlParameter
                    P2(0) = New SqlParameter("@TIPO", 1)
                    P2(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                    ds2 = DatosBD.FuncionConPar("SP_GRAFICASJI", P2, Lerror.Text)


                    'COLUMNCHART
                    Dim ds4 As New DataSet
                    Dim P4(1) As SqlParameter
                    P4(0) = New SqlParameter("@TIPO", 4)
                    P4(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                    ds4 = DatosBD.FuncionConPar("SP_GRAFICASJI", P4, Lerror.Text)



                    Graficar(ds.Tables(0), "TEXTO", "VALOR", "", "", Session("NombreEmpresa"), " Grafica Estilos Gerenciales", True)
                    Graficar2(ds6.Tables(0), "DescEstilo", "PromdePromedio", "", "", Session("NombreEmpresa"), "Grado de presencia de estilos de gerenciamiento", True)
                    GraficarPie(ds2.Tables(0), "TEXTO", "VALOR", "", "PORCENTAJE", Session("NombreEmpresa"), "Amplitud de Reportorio de Estilos Gerenciales", False)

                    Graficar3(ds4.Tables(0), "DescEstilo", "Porcentaje", "", "", Session("NombreEmpresa"), "Distribución Estilos Gerenciales", False)

                End If

            Else 'Agrupado Estructura
                If TipoGrafica = "Microclima" Then

                Else

                End If


            End If



        End If
    End Sub
   
    Sub GraficarPie(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)
        'Chart1.DataSource = Nothing
        'Chart1.DataBind()
        PieChart.PlotArea.Series.Clear()
        PieChart.DataSource = Datos
        PieChart.PlotArea.YAxis.MaxValue = 110
        PieChart.PlotArea.YAxis.MinValue = 0
        PieChart.PlotArea.XAxis.TitleAppearance.Text = AxisX
        PieChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 11
        PieChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = -90
        PieChart.PlotArea.YAxis.TitleAppearance.Text = AxisY
        PieChart.PlotArea.YAxis.TitleAppearance.TextStyle.FontSize = 11
        PieChart.PlotArea.Appearance.FillStyle.BackgroundColor = Color.WhiteSmoke
        PieChart.Legend.Appearance.Visible = True
        PieChart.Legend.Appearance.Position = HtmlChart.ChartLegendPosition.Bottom


        PieChart.ChartTitle.Text = Titulo1 & "\n" & Titulo2
        PieChart.ChartTitle.Appearance.TextStyle.Bold = True

        PieChart.PlotArea.XAxis.DataLabelsField = CStr(ValorX)
        PieChart.DataBind()

        Dim ChartItem As New PieSeries
        ChartItem.LabelsAppearance.DataFormatString = "{0} %"
        ChartItem.LabelsAppearance.TextStyle.Bold = True
        ChartItem.TooltipsAppearance.Visible = True
        'ChartItem.TooltipsAppearance.BackgroundColor = Color.White
        ChartItem.TooltipsAppearance.ClientTemplate = "#=category#"
        'ChartItem.Gap = 0.5

        Dim VAL As Double = 0.0
        Dim TEXTO As String
        For i As Integer = 0 To Datos.Rows.Count - 1
            Dim Item As New SeriesItem
            VAL = FormatNumber(Datos.Rows(i).Item(4), 2)
            TEXTO = Datos.Rows(i).Item(1)
            
            Item.TooltipValue = TEXTO
            Item.YValue = VAL
            Item.Name = TEXTO

            ChartItem.Items.Add(Item)
        Next

        PieChart.PlotArea.Series.Add(ChartItem)
        PieChart.Visible = True
    End Sub

    Sub Graficar3(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)
        ColumnChart.PlotArea.Series.Clear()
        ColumnChart.DataSource = Datos
        ColumnChart.PlotArea.YAxis.MaxValue = 110
        ColumnChart.PlotArea.YAxis.MinValue = 0
        ColumnChart.PlotArea.XAxis.TitleAppearance.Text = AxisY
        ColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10
        ColumnChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = -90
        ColumnChart.PlotArea.YAxis.TitleAppearance.Text = AxisX
        ColumnChart.PlotArea.YAxis.TitleAppearance.TextStyle.FontSize = 11
        ColumnChart.PlotArea.Appearance.FillStyle.BackgroundColor = Color.WhiteSmoke


        ColumnChart.ChartTitle.Text = Titulo1 & "\n" & Titulo2
        ColumnChart.ChartTitle.Appearance.TextStyle.Bold = True

        ColumnChart.PlotArea.XAxis.DataLabelsField = CStr(ValorX)
        ColumnChart.DataBind()

        Dim ChartBar As New ColumnSeries
        ChartBar.LabelsAppearance.DataFormatString = "{0:N1}"
        ChartBar.LabelsAppearance.TextStyle.Bold = True
        ChartBar.TooltipsAppearance.Visible = True
        ChartBar.TooltipsAppearance.BackgroundColor = Color.White
        ChartBar.TooltipsAppearance.ClientTemplate = "#=category#"
        ChartBar.Gap = 0.5

        Dim VAL As Double = 0.0
        Dim TEXTO As String
        For i As Integer = 0 To Datos.Rows.Count - 1
            Dim Barra As New SeriesItem

            VAL = FormatNumber(Datos.Rows(i).Item(2), 1)
            TEXTO = Datos.Rows(i).Item(1)

            ColumnChart.PlotArea.XAxis.LabelsAppearance.Visible = True


            Barra.TooltipValue = TEXTO
            Barra.YValue = VAL


            ChartBar.Items.Add(Barra)
        Next

        ColumnChart.PlotArea.Series.Add(ChartBar)
        ColumnChart.Visible = True

    End Sub

    Sub Graficar2(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)
        BarChart.PlotArea.Series.Clear()
        BarChart.DataSource = Datos
        BarChart.PlotArea.YAxis.MaxValue = 7
        BarChart.PlotArea.YAxis.MinValue = 0
        BarChart.PlotArea.XAxis.TitleAppearance.Text = AxisY
        BarChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10
        BarChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = -90
        BarChart.PlotArea.YAxis.TitleAppearance.Text = AxisX
        BarChart.PlotArea.YAxis.TitleAppearance.TextStyle.FontSize = 11
        BarChart.PlotArea.Appearance.FillStyle.BackgroundColor = Color.WhiteSmoke


        BarChart.ChartTitle.Text = Titulo1 & "\n" & Titulo2
        BarChart.ChartTitle.Appearance.TextStyle.Bold = True

        BarChart.PlotArea.XAxis.DataLabelsField = CStr(ValorX)
        BarChart.PlotArea.XAxis.Visible = False
        BarChart.DataBind()

        Dim ChartBar As New BarSeries
        ChartBar.LabelsAppearance.DataFormatString = "{0:N1}"
        ChartBar.LabelsAppearance.TextStyle.Bold = True
        ChartBar.TooltipsAppearance.Visible = True
        ChartBar.TooltipsAppearance.BackgroundColor = Color.White
        ChartBar.TooltipsAppearance.ClientTemplate = "#=category#"
        ChartBar.Gap = 0.5

        Dim VAL As Double = 0.0
        Dim TEXTO As String
        For i As Integer = 0 To Datos.Rows.Count - 1
            Dim Barra As New SeriesItem
           
            VAL = FormatNumber(Datos.Rows(i).Item(2), 1)
            TEXTO = Datos.Rows(i).Item(1)
            
          
            Barra.TooltipValue = TEXTO
            Barra.YValue = VAL

           
            ChartBar.Items.Add(Barra)
        Next

        BarChart.PlotArea.Series.Add(ChartBar)
        BarChart.Visible = True

    End Sub

    Sub Graficar(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)
        Chart1.PlotArea.Series.Clear()
        ' Chart1.DataSource = Datos
        Chart1.PlotArea.YAxis.MaxValue = 5
        Chart1.PlotArea.YAxis.MinValue = 1
        Chart1.PlotArea.XAxis.MaxValue = 100
        Chart1.PlotArea.XAxis.MinValue = 0
        Chart1.PlotArea.XAxis.TitleAppearance.Text = AxisX
        Chart1.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10
        Chart1.PlotArea.XAxis.LabelsAppearance.RotationAngle = -90
        Chart1.PlotArea.YAxis.TitleAppearance.Text = AxisY
        Chart1.PlotArea.YAxis.TitleAppearance.TextStyle.FontSize = 11
        Chart1.PlotArea.Appearance.FillStyle.BackgroundColor = Color.WhiteSmoke
        Chart1.ChartTitle.Text = Titulo1 & "\n" & Titulo2
        Chart1.ChartTitle.Appearance.TextStyle.Bold = True

        Chart1.PlotArea.XAxis.DataLabelsField = CStr(ValorX)
        ' Chart1.DataBind()

        Dim Bubbles As New BubbleSeries
        Bubbles.LabelsAppearance.DataFormatString = "{0:N1}"
        Bubbles.LabelsAppearance.TextStyle.Bold = True
        Bubbles.TooltipsAppearance.Visible = True
        Bubbles.TooltipsAppearance.BackgroundColor = Color.White
        Bubbles.TooltipsAppearance.ClientTemplate = "#=category#"

        Dim VAL As Integer = 0
        Dim Size As Integer = 0
        Dim EjeX As Integer = 0
        Dim TEXTO As String
        For i As Integer = 0 To Datos.Rows.Count - 1

            Dim Barra As New BubbleSeriesItem

            VAL = FormatNumber(Datos.Rows(i).Item(2), 1)
            TEXTO = Datos.Rows(i).Item(1)
            Size = FormatNumber(Datos.Rows(i).Item(0), 1)
            EjeX = FormatNumber(Datos.Rows(i).Item(3), 1)

            Barra.Tooltip = TEXTO + " = " + Size.ToString
            Barra.Y = VAL
            Barra.X = EjeX
            Barra.Size = Size
            Barra.BackgroundColor = System.Drawing.Color.DarkBlue

            If EjeX >= 0 And EjeX <= 19.9999 Then
                Barra.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#388e3c")
            ElseIf EjeX >= 20 And EjeX <= 40 Then
                Barra.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#C2BA4F")
            ElseIf EjeX >= 41 And EjeX <= 60 Then
                Barra.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#fbc02d")
            ElseIf EjeX >= 61 And EjeX <= 80 Then
                Barra.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#d32f2f")
            ElseIf EjeX >= 81 And EjeX <= 100 Then
                Barra.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#b71c1c")
            End If

            Bubbles.SeriesItems.Add(Barra)
        Next

        Chart1.PlotArea.Series.Add(Bubbles)
        Chart1.Visible = True
       
    End Sub

End Class
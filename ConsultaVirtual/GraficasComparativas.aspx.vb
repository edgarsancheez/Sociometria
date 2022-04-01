Imports Telerik.Web.UI
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports System.Configuration
Imports System.Web.UI.DataVisualization.Charting
Imports System.IO

Partial Public Class GraficasComparativas
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
                If Not Page.Request.Params("Em") Is Nothing Then
                    Session("NumGrafica") = ""
                    Dim CveEmpresa As Integer = Page.Request.Params("Em")
                    Dim DS As DataSet
                    Dim P(5) As SqlParameter
                    P(0) = New SqlParameter("@TIPO", 8)
                    P(1) = New SqlParameter("@CVEEMPRESA", CveEmpresa)
                    P(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
                    P(3) = New SqlParameter("@USUARIO", Session("USUARIO"))
                    P(4) = New SqlParameter("@FECHA", DateTime.Now.Date)
                    If Session("Lenguaje") = "pt-BR" Then
                        P(5) = New SqlParameter("@IDIOMA", 2)
                    ElseIf Session("Lenguaje") = "en-US" Then
                        P(5) = New SqlParameter("@IDIOMA", 11)
                    Else
                        P(5) = New SqlParameter("@IDIOMA", 99)
                    End If
                    DS = DatosBD.FuncionConPar("SP_BUSQUEDA_COMPARATIVAS", P, Lerror.Text)
                    Dim TBL As DataTable = DS.Tables(0)


                    Dim ds2 As New DataSet
                    Dim P2(1) As SqlParameter
                    P2(0) = New SqlParameter("@TIPO", 13)
                    P2(1) = New SqlParameter("@CVEEMPRESA", CveEmpresa)
                    ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)

                    Dim Nom As String = ds2.Tables(0).Rows(0).Item(0)


                    Graficar(TBL, "TEXTO_ACT", "PROMEDIO", "", GETPALABRA("PROMEDIOS"), GETPALABRA("GRÁFICA DE COMPARATIVA"), Nom, False, False)
                Else
                    If Page.Request.Params("T") = 2 Then
                        Session("NumGrafica") = "Participacion"
                        Dim TBL As DataTable = CType(Session("TBL"), DataTable)
                        Dim dv As DataView = TBL.DefaultView
                        dv.RowFilter = "PROMEDIO_ACT <> 0"
                        Dim tabla As DataTable
                        tabla = dv.ToTable
                        Graficar(tabla, "TEXTO_ACT", "PARTICIPACION", "", GETPALABRA("PARTICIPACION"), GETPALABRA("GRÁFICA DE COMPARATIVA"), GETPALABRA("PARTICIPACION"), False, False)
                    Else
                        Session("NumGrafica") = "Promedio"
                        Dim TBL As DataTable = CType(Session("TBL"), DataTable)
                        Dim dv As DataView = TBL.DefaultView
                        dv.RowFilter = "PROMEDIO_ACT <> 0"
                        Dim tabla As DataTable
                        tabla = dv.ToTable
                        Graficar(tabla, "TEXTO_ACT", "PROMEDIO", "", GETPALABRA("PROMEDIOS"), GETPALABRA("GRÁFICA DE COMPARATIVA"), GETPALABRA("PROMEDIOS"), False, False)
                    End If
                End If
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Sub Graficar(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)
        Chart1.PlotArea.Series.Clear()
        Chart1.DataSource = Datos
        Chart1.PlotArea.YAxis.MaxValue = 110
        Chart1.PlotArea.YAxis.MinValue = 0
        Chart1.PlotArea.XAxis.TitleAppearance.Text = AxisX
        Chart1.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10
        Chart1.PlotArea.XAxis.LabelsAppearance.RotationAngle = -90
        Chart1.PlotArea.YAxis.TitleAppearance.Text = AxisY
        Chart1.PlotArea.YAxis.TitleAppearance.TextStyle.FontSize = 11
        Chart1.PlotArea.Appearance.FillStyle.BackgroundColor = Color.WhiteSmoke

        Chart1.ChartTitle.Text = Titulo1 & "\n" & Titulo2
        Chart1.ChartTitle.Appearance.TextStyle.Bold = True

        Chart1.PlotArea.XAxis.DataLabelsField = CStr(ValorX)
        Chart1.DataBind()

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
            If Session("NumGrafica") = "Promedio" Then
                VAL = FormatNumber(Datos.Rows(i).Item(3), 1)
                TEXTO = Datos.Rows(i).Item(1)
            ElseIf Session("NumGrafica") = "Participacion" Then
                VAL = FormatNumber(Datos.Rows(i).Item(6), 1)
                TEXTO = Datos.Rows(i).Item(1)
            Else
                VAL = FormatNumber(Datos.Rows(i).Item(2), 1)
                TEXTO = Datos.Rows(i).Item(1)
            End If

            If TEXTO.Length > 25 Then
                Chart1.PlotArea.XAxis.LabelsAppearance.Visible = False
            End If
            Barra.TooltipValue = TEXTO
            Barra.YValue = VAL

            If VAL <= 69.9999 Then
                Barra.BackgroundColor = System.Drawing.Color.DarkRed
            ElseIf VAL >= 70.0 And VAL <= 79.9999 Then
                Barra.BackgroundColor = System.Drawing.Color.Goldenrod
            ElseIf VAL >= 80.0 And VAL <= 89.9999 Then
                Barra.BackgroundColor = System.Drawing.Color.DarkBlue
            ElseIf VAL >= 90.0 Then
                Barra.BackgroundColor = System.Drawing.Color.DarkGreen
            End If

            ChartBar.Items.Add(Barra)
        Next

        Dim ChartBar2 As New LineSeries
        ChartBar2.LabelsAppearance.DataFormatString = "{0:N1}"
        ChartBar2.LabelsAppearance.TextStyle.Bold = True
        ChartBar2.LabelsAppearance.TextStyle.Color = Color.Black
        ChartBar2.LabelsAppearance.Position = HtmlChart.LineAndScatterLabelsPosition.Below
        ChartBar2.TooltipsAppearance.Visible = True
        ChartBar2.TooltipsAppearance.BackgroundColor = Color.White
        ChartBar2.TooltipsAppearance.ClientTemplate = "#=category#"

        For i As Integer = 0 To Datos.Rows.Count - 1
            Dim Linea As New SeriesItem

            If Session("NumGrafica") = "Promedio" Then
                VAL = FormatNumber(Datos.Rows(i).Item(5), 1)
                TEXTO = Datos.Rows(i).Item(1)
            ElseIf Session("NumGrafica") = "Participacion" Then
                VAL = FormatNumber(Datos.Rows(i).Item(7), 1)
                TEXTO = Datos.Rows(i).Item(1)
            Else
                VAL = FormatNumber(Datos.Rows(i).Item(3), 1)
                TEXTO = Datos.Rows(i).Item(1)
            End If

            If VAL > 0 Then
                Linea.TooltipValue = TEXTO
                Linea.YValue = VAL
            End If

            Linea.BackgroundColor = System.Drawing.Color.Gray

            ChartBar2.Items.Add(Linea)
        Next


        Chart1.PlotArea.Series.Add(ChartBar2)
        Chart1.PlotArea.Series.Add(ChartBar)
        Chart1.Visible = True

        'Chart1.DataSource = Datos
        'Chart1.Series(0).XValueMember = CStr(ValorX)
        'Chart1.Series(0).YValueMembers = ValorY & "_ACT"
        'Chart1.ChartAreas(0).Area3DStyle.Enable3D = TresD
        'Chart1.DataBind()
        'Chart1.ChartAreas(0).AxisY.Maximum = 110
        'Chart1.ChartAreas(0).AxisY.Minimum = 0
        'Chart1.ChartAreas(0).AxisX.LabelStyle.IsEndLabelVisible = True
        'Chart1.ChartAreas(0).AxisX.Title = AxisX
        'Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90
        'Chart1.ChartAreas(0).AxisY.Title = AxisY


        'Chart1.Series(1).XValueMember = CStr(ValorX)
        'Chart1.Series(1).YValueMembers = ValorY & "_ANT"
        'Chart1.DataBind()

        'Chart1.Titles(0).Text = Titulo1
        'Chart1.Titles(1).Text = Titulo2

        'Dim annotation As New TextAnnotation()
        'annotation.Text = GETPALABRA("Actualizada") & ": " & Now.Date.ToShortDateString
        'annotation.ForeColor = Color.Black
        'annotation.X = 80
        'annotation.Y = 0
        'annotation.Font = New Font("Tahoma", 8)
        'Chart1.Annotations.Add(annotation)

        'Dim VAL As Double = 0.0
        'For I As Integer = 0 To Datos.Rows.Count - 1
        '    'VAL = Math.Round(Datos.Rows(I).Item(ValorY & "_ACT"), 2)
        '    VAL = Datos.Rows(I).Item(ValorY & "_ACT")
        '    Chart1.Series(0).Points(I).ToolTip = Datos.Rows(I).Item(2).ToString
        '    If VAL <= 69.9999 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Red
        '    ElseIf VAL >= 70.0 And VAL <= 79.9999 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Yellow
        '    ElseIf VAL >= 80.0 And VAL <= 89.9999 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Blue
        '    ElseIf VAL >= 90.0 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Green
        '    End If
        'Next

        'For I As Integer = 0 To Datos.Rows.Count - 1
        '    'VAL = Math.Round(Datos.Rows(I).Item(ValorY & "_ANT"), 2)
        '    VAL = Datos.Rows(I).Item(ValorY & "_ANT")
        '    Chart1.Series(1).Points(I).Color = Drawing.Color.Orange
        'Next

        'For I As Integer = 0 To Chart1.Series(0).Points.Count - 1

        '    Dim annotation_ As New TextAnnotation()
        '    annotation_.Text = Chart1.Series(1).Points(I).YValues(0).ToString("N1", System.Globalization.CultureInfo.InvariantCulture)
        '    annotation_.AnchorDataPoint = Chart1.Series(0).Points(I)
        '    annotation_.ToolTip = Datos.Rows(I).Item(4).ToString
        '    annotation_.Y = 25.8
        '    annotation_.ForeColor = Color.White
        '    annotation_.BringToFront()
        '    annotation_.Font = New Font("Tahoma", 8, FontStyle.Bold)
        '    annotation_.Alignment = ContentAlignment.BottomCenter
        '    Chart1.Annotations.Add(annotation_)


        '    Dim annotation__ As New TextAnnotation()
        '    Dim valor As Double = Chart1.Series(0).Points(I).YValues(0) - Chart1.Series(1).Points(I).YValues(0)


        '    If valor > 0 Then
        '        annotation__.ForeColor = Color.GreenYellow
        '        annotation__.Text = "+" & valor.ToString("N1", System.Globalization.CultureInfo.InvariantCulture)
        '    Else
        '        annotation__.ForeColor = Color.OrangeRed
        '        annotation__.Text = valor.ToString("N1", System.Globalization.CultureInfo.InvariantCulture)
        '    End If

        '    If Chart1.Series(1).Points(I).YValues(0) = 0 Then
        '        annotation__.ForeColor = Color.Yellow
        '        annotation__.Text = "N/A"
        '    ElseIf Chart1.Series(0).Points(I).YValues(0) = 0 Then
        '        annotation__.ForeColor = Color.Yellow
        '        annotation__.Text = "N/A"
        '    End If


        '    annotation__.Y = 20
        '    annotation__.BringToFront()
        '    annotation__.AnchorDataPoint = Chart1.Series(0).Points(I)
        '    annotation__.Font = New Font("Tahoma", 8, FontStyle.Bold)
        '    annotation__.Alignment = ContentAlignment.BottomCenter
        '    Chart1.Annotations.Add(annotation__)

        'Next
        'Chart1.Visible = True
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

    Public Sub RadAjaxManager1_AjaxRequest(sender As Object, e As AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        Try

        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

End Class

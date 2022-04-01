Imports Telerik.Web.UI
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.IO

Partial Public Class GraficaTemas
    Inherits System.Web.UI.Page

    Protected Overrides Sub InitializeCulture()
        If Not Session("Lenguaje") Is Nothing Then
            UICulture = Session("Lenguaje")
            Culture = Session("Lenguaje")
        End If
        MyBase.InitializeCulture()
    End Sub

    Dim Param As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CON") = "OK" Then
            If Not Page.IsPostBack Then
                Param = Request.Params("Tipo")
                Chart1.DataSource = Nothing
                Chart1.DataBind()

                If Param = 2 Then
                    Dim CONSULTA As String
                    Dim ds As New DataSet
                    Dim P(0) As SqlParameter



                    If Session("Lenguaje") = "pt-BR" Then

                        'CONSULTA = "SELECT IDPERFILEFECTIVIDAD, PERFILEFECTIVIDADPT AS PERFILEFECTIVIDAD FROM TblEngPerfilEfectividad WHERE IDPERFILEFECTIVIDAD > 0 ORDER BY ORDEN"
                        P(0) = New SqlParameter("@TIPO", 20)
                    ElseIf Session("Lenguaje") = "en-US" Then
                        ' CONSULTA = "SELECT IDPERFILEFECTIVIDAD, PERFILEFECTIVIDADEN AS PERFILEFECTIVIDAD FROM TblEngPerfilEfectividad WHERE IDPERFILEFECTIVIDAD > 0 ORDER BY ORDEN"
                        P(0) = New SqlParameter("@TIPO", 21)
                    Else
                        ' CONSULTA = "SELECT IDPERFILEFECTIVIDAD, PERFILEFECTIVIDAD AS PERFILEFECTIVIDAD FROM TblEngPerfilEfectividad WHERE IDPERFILEFECTIVIDAD > 0 ORDER BY ORDEN"
                        P(0) = New SqlParameter("@TIPO", 22)
                    End If
                    'Cargar.ComboSentenciaTxt(RCBPerfil, CONSULTA, "PERFILEFECTIVIDAD", "IDPERFILEFECTIVIDAD", "", False)
                    ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


                    RCBPerfil.DataSource = ds.Tables(0)
                    RCBPerfil.DataTextField = "PERFILEFECTIVIDAD"
                    RCBPerfil.DataValueField = "IDPERFILEFECTIVIDAD"
                    RCBPerfil.DataBind()



                    RCBPerfil.SelectedValue = 2
                    Label1.Visible = True
                    Label1.Text = GETPALABRA("Perfil de Efectividad") & ":"
                    RCBPerfil.Visible = True
                    BuildData()
                Else
                    Dim dt As DataTable
                    dt = CType(Session("DTTemas"), DataTable)
                    If Not dt Is Nothing Then
                        Graficar(dt, "TEMA", "PROMEDIO", "", GETPALABRA("PROMEDIOS"), GETPALABRA("GRAFICA GENERAL POR TEMAS"), "")
                    End If
                    Label1.Visible = False
                    RCBPerfil.Visible = False
                End If
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Protected Sub RCBPerfil_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBPerfil.SelectedIndexChanged
        BuildData()
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

            VAL = FormatNumber(Datos.Rows(i).Item(2), 1)
            TEXTO = Datos.Rows(i).Item(1)

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

        Chart1.PlotArea.Series.Add(ChartBar)
        Chart1.Visible = True

        'Chart1.DataSource = Datos
        'Chart1.Series(0).XValueMember = CStr(ValorX)
        'Chart1.Series(0).YValueMembers = ValorY
        'Chart1.ChartAreas(0).Area3DStyle.Enable3D = TresD
        'Chart1.DataBind()
        'Chart1.ChartAreas(0).AxisY.Maximum = 110
        'Chart1.ChartAreas(0).AxisY.Minimum = 0
        'Chart1.ChartAreas(0).AxisX.LabelStyle.IsEndLabelVisible = True
        'Chart1.ChartAreas(0).AxisX.Title = AxisX
        'Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90
        'Chart1.ChartAreas(0).AxisY.Title = AxisY
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
        '    VAL = Math.Round(Datos.Rows(I).Item(2), 2)
        '    Chart1.Series(0).Points(I).ToolTip = Datos.Rows(I).Item(1).ToString
        '    If VAL <= 69.99 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Red
        '    ElseIf VAL >= 70.0 And VAL <= 79.99 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Yellow
        '    ElseIf VAL >= 80.0 And VAL <= 89.99 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Blue
        '    ElseIf VAL >= 90.0 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Green
        '    End If
        'Next

        'Chart1.ChartAreas(0).AxisY.StripLines(0).IntervalOffset = VAL
        'Chart1.ChartAreas(0).AxisY.StripLines(0).Interval = VAL

        'Chart1.Visible = True
    End Sub

    Private Sub BuildData()
        Dim ds As New DataSet
        Dim PLoad(11) As SqlParameter
        Try

            PLoad(0) = New SqlParameter("@CVEDIVISION", Session("CveUnidad"))
            PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", Session("CveAgrupado"))
            PLoad(2) = New SqlParameter("@CVEPAIS", Session("CvePais"))
            PLoad(3) = New SqlParameter("@CVEAREA", Session("CveTipo"))
            PLoad(4) = New SqlParameter("@CVETERRITORIO", Session("CveTerritorio"))
            PLoad(5) = New SqlParameter("@CVEREGION", Session("CveRegion"))
            PLoad(6) = New SqlParameter("@CVESUBREGION", Session("CveSubRegion"))
            If Session("TipoEmpleado") = "Lider" Or Session("CveUnidad") = 16 Then
                PLoad(7) = New SqlParameter("@CVESISTEMA", 13)
            Else
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
            PLoad(11) = New SqlParameter("@IDPERFILEFECTIVIDAD", RCBPerfil.SelectedValue)

            ds = DatosBD.FuncionConPar("SP_EngGraficaTemas", PLoad, Lerror.Text)
            If ds.Tables(0).Rows.Count > 0 Then
                Graficar(ds.Tables(0), "TEMA", "PROMEDIO", "", GETPALABRA("PROMEDIOS"), GETPALABRA("GRAFICA GENERAL POR TEMAS"), RCBPerfil.Text)
            Else
                Chart1.Visible = False
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

    Public Sub RadAjaxManager1_AjaxRequest(sender As Object, e As AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        Try

        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

End Class
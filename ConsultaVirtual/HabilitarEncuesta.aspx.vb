Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports Telerik.ReportViewer.WebForms
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.IO

Public Class HabilitarEncuesta
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
                Unidades()
                TRInfo.Visible = False
                'LlenarReporte()
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Protected Sub RUnidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RUnidad.SelectedIndexChanged
        RegionPaises()

    End Sub

    Protected Sub RRegionPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RRegionPaises.SelectedIndexChanged
        Pais()
    End Sub

    Protected Sub RPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RPaises.SelectedIndexChanged
        Territorio()
    End Sub

    Private Sub RTerritorios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RTerritorios.SelectedIndexChanged
        Region()
    End Sub

    Protected Sub RRegiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RRegiones.SelectedIndexChanged
        Subregion()
    End Sub

    Protected Sub RSubregiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RSubregiones.SelectedIndexChanged
        CentroDeTrabajo()
    End Sub

    Protected Sub RCentroDeTrabajo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RCentroDeTrabajo.SelectedIndexChanged
        Session("CveEmpCODRIVE") = RCentroDeTrabajo.SelectedValue
        BuildData()
    End Sub

    Sub Unidades()
        RUnidad.Items.Clear()
        RRegionPaises.Items.Clear()
        RPaises.Items.Clear()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 0)
        PLoad(1) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(2) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RUnidad.DataSource = DS.Tables(0)
        RUnidad.DataTextField = "NomDivision"
        RUnidad.DataValueField = "CveDivision"
        RUnidad.DataBind()

        If RUnidad.Items.Count = 1 Then
            RUnidad.Items(0).Selected = True
            RegionPaises()
        
        End If
    End Sub

    Sub RegionPaises()
        RRegionPaises.Items.Clear()
        RPaises.Items.Clear()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 1)
        PLoad(1) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(3) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RRegionPaises.DataSource = DS.Tables(0)
        RRegionPaises.DataTextField = "NOMAGRUPADO"
        RRegionPaises.DataValueField = "CVEAGRUPADO"
        RRegionPaises.DataBind()

        If RRegionPaises.Items.Count = 1 Then
            RRegionPaises.Items(0).Selected = True
            Pais()
       
        End If
    End Sub

    Sub Pais()
        RPaises.Items.Clear()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(4) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 2)
        PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", RRegionPaises.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(4) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RPaises.DataSource = DS.Tables(0)
        RPaises.DataTextField = "PAIS"
        RPaises.DataValueField = "CVEPAIS"
        RPaises.DataBind()

        If RPaises.Items.Count = 1 Then
            RPaises.Items(0).Selected = True
            Territorio()
       
        End If
    End Sub

    Sub Territorio()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(4) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 3)
        PLoad(1) = New SqlParameter("@CVEPAIS", RPaises.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(4) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RTerritorios.DataSource = DS.Tables(0)
        RTerritorios.DataTextField = "TERRITORIO"
        RTerritorios.DataValueField = "CVETERRITORIO"
        RTerritorios.DataBind()

        If RTerritorios.Items.Count = 1 Then
            RTerritorios.Items(0).Selected = True
            Region()
        
        End If
    End Sub

    Sub Region()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(4) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 4)
        PLoad(1) = New SqlParameter("@CVETERRITORIO", RTerritorios.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(4) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RRegiones.DataSource = DS.Tables(0)
        RRegiones.DataTextField = "NOMREGION"
        RRegiones.DataValueField = "CVEREGION"
        RRegiones.DataBind()

        If RRegiones.Items.Count = 1 Then
            RRegiones.Items(0).Selected = True
            Subregion()
       
        End If
    End Sub

    Sub Subregion()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 5)
        PLoad(1) = New SqlParameter("@CVEREGION", RRegiones.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(3) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RSubregiones.DataSource = DS.Tables(0)
        RSubregiones.DataTextField = "NOMSUBREGION"
        RSubregiones.DataValueField = "CVESUBREGION"
        RSubregiones.DataBind()

        If RSubregiones.Items.Count = 1 Then
            RSubregiones.Items(0).Selected = True
            CentroDeTrabajo()
       
        End If
    End Sub

    Sub CentroDeTrabajo()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 0)
        PLoad(1) = New SqlParameter("@CVEREGION", RRegiones.SelectedValue)
        PLoad(2) = New SqlParameter("@CVESUBREGION", RSubregiones.SelectedValue)
  
        Dim DS As DataSet = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", PLoad, Lerror)

        RCentroDeTrabajo.DataSource = DS.Tables(0)
        RCentroDeTrabajo.DataTextField = "NomEmpresa"
        RCentroDeTrabajo.DataValueField = "CveEmpresa"
        RCentroDeTrabajo.DataBind()

        If RCentroDeTrabajo.Items.Count = 1 Then
            RCentroDeTrabajo.Items(0).Selected = True
            Session("CveEmpCODRIVE") = RCentroDeTrabajo.SelectedValue
            BuildData()
       

        End If
    End Sub

    Sub BuildData()

        TRInfo.Visible = True

        Dim DS2 As DataSet
        Dim PLoad2(1) As SqlParameter
        PLoad2(0) = New SqlParameter("@TIPO", 1)
        PLoad2(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpCODRIVE"))


        DS2 = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", PLoad2, Lerror.Text)

        RdtpInicio.SelectedDate = DS2.Tables(0).Rows(0).Item(0)
        RdtpFin.SelectedDate = DS2.Tables(0).Rows(0).Item(1)
        TxtDiasAp.Text = DS2.Tables(0).Rows(0).Item(2)


        Dim DS3 As DataSet
        Dim PLoad3(1) As SqlParameter
        PLoad3(0) = New SqlParameter("@TIPO", 2)
        PLoad3(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpCODRIVE"))

        DS3 = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", PLoad3, Lerror.Text)

        TxtHeadCount.Text = DS3.Tables(0).Rows(0).Item(0)


        Dim DS4 As DataSet
        Dim PLoad4(1) As SqlParameter
        PLoad4(0) = New SqlParameter("@TIPO", 3)
        PLoad4(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpCODRIVE"))

        DS4 = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", PLoad4, Lerror.Text)

        TxtFoliosDisp.Text = DS4.Tables(0).Rows(0).Item(0)


        CargaGrid()
        GraficarDepartamentos()
        GraficarNiveles()
    End Sub

    Sub CargaGrid()

        Dim DS As DataSet
        Dim PLoad(1) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 4)
        PLoad(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpCODRIVE"))

        DS = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", PLoad, Lerror.Text)
        RadGrid1.DataSource = ds.Tables(0)
        RadGrid1.DataBind()
    End Sub




    Sub GraficarDepartamentos()
        Try
            Dim DS As DataSet
            Dim PLoad(1) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 5)
            PLoad(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpCODRIVE"))
         

            DS = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", PLoad, Lerror.Text)
            GraficarPie(DS.Tables(0), "TEXTO", "VALOR", "", "Conteo", "Departamentos", "".Replace("'", "&#8217"), False)
            Chart1.Visible = True
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub


    Sub GraficarNiveles()
        Try
            Dim DS As DataSet
            Dim PLoad(1) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 6)
            PLoad(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpCODRIVE"))


            DS = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", PLoad, Lerror.Text)
            GraficarPie2(DS.Tables(0), "TEXTO", "VALOR", "", "Conteo", "Niveles", "".Replace("'", "&#8217"), False)
            Chart2.Visible = True
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Sub GraficarPie2(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)
        'Chart2.DataSource = Nothing
        'Chart2.DataBind()
        Chart2.PlotArea.Series.Clear()
        Chart2.DataSource = Datos
        Chart2.PlotArea.YAxis.MaxValue = 110
        Chart2.PlotArea.YAxis.MinValue = 0
        Chart2.PlotArea.XAxis.TitleAppearance.Text = AxisX
        Chart2.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 11
        Chart2.PlotArea.XAxis.LabelsAppearance.RotationAngle = -90
        Chart2.PlotArea.YAxis.TitleAppearance.Text = AxisY
        Chart2.PlotArea.YAxis.TitleAppearance.TextStyle.FontSize = 11
        Chart2.PlotArea.Appearance.FillStyle.BackgroundColor = Color.WhiteSmoke
        Chart2.Legend.Appearance.Visible = True
        Chart2.Legend.Appearance.Position = HtmlChart.ChartLegendPosition.Bottom

        Dim Pregunta As String = NuevoTexto(Titulo2)

        Chart2.ChartTitle.Text = Titulo1 & "\n" & Pregunta
        Chart2.ChartTitle.Appearance.TextStyle.Bold = False

        Chart2.PlotArea.XAxis.DataLabelsField = CStr(ValorX)
        Chart2.DataBind()

        Dim ChartItem As New PieSeries
        'ChartItem.LabelsAppearance.DataFormatString = "{0} %"
        ChartItem.LabelsAppearance.TextStyle.Bold = True
        ChartItem.TooltipsAppearance.Visible = True
        'ChartItem.TooltipsAppearance.BackgroundColor = Color.White
        ChartItem.TooltipsAppearance.ClientTemplate = "#=category#"
        'ChartItem.Gap = 0.5

        Dim VAL As Double = 0.0
        Dim TEXTO As String
        For i As Integer = 0 To Datos.Rows.Count - 1
            Dim Item As New SeriesItem
            VAL = FormatNumber(Datos.Rows(i).Item(2), 2)
            TEXTO = Datos.Rows(i).Item(1)
            If TEXTO.Length > 25 Then
                Chart2.PlotArea.XAxis.LabelsAppearance.Visible = False
            End If
            Item.TooltipValue = TEXTO
            Item.YValue = VAL
            Item.Name = TEXTO

            ChartItem.Items.Add(Item)
        Next

        Chart2.PlotArea.Series.Add(ChartItem)
        Chart2.Visible = True
    End Sub


    Sub GraficarPie(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)
        'Chart1.DataSource = Nothing
        'Chart1.DataBind()
        Chart1.PlotArea.Series.Clear()
        Chart1.DataSource = Datos
        Chart1.PlotArea.YAxis.MaxValue = 110
        Chart1.PlotArea.YAxis.MinValue = 0
        Chart1.PlotArea.XAxis.TitleAppearance.Text = AxisX
        Chart1.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 11
        Chart1.PlotArea.XAxis.LabelsAppearance.RotationAngle = -90
        Chart1.PlotArea.YAxis.TitleAppearance.Text = AxisY
        Chart1.PlotArea.YAxis.TitleAppearance.TextStyle.FontSize = 11
        Chart1.PlotArea.Appearance.FillStyle.BackgroundColor = Color.WhiteSmoke
        Chart1.Legend.Appearance.Visible = True
        Chart1.Legend.Appearance.Position = HtmlChart.ChartLegendPosition.Bottom

        Dim Pregunta As String = NuevoTexto(Titulo2)

        Chart1.ChartTitle.Text = Titulo1 & "\n" & Pregunta
        Chart1.ChartTitle.Appearance.TextStyle.Bold = False

        Chart1.PlotArea.XAxis.DataLabelsField = CStr(ValorX)
        Chart1.DataBind()

        Dim ChartItem As New PieSeries
        'ChartItem.LabelsAppearance.DataFormatString = "{0} %"
        ChartItem.LabelsAppearance.TextStyle.Bold = True
        ChartItem.TooltipsAppearance.Visible = True
        'ChartItem.TooltipsAppearance.BackgroundColor = Color.White
        ChartItem.TooltipsAppearance.ClientTemplate = "#=category#"
        'ChartItem.Gap = 0.5

        Dim VAL As Double = 0.0
        Dim TEXTO As String
        For i As Integer = 0 To Datos.Rows.Count - 1
            Dim Item As New SeriesItem
            VAL = FormatNumber(Datos.Rows(i).Item(2), 2)
            TEXTO = Datos.Rows(i).Item(1)
            If TEXTO.Length > 25 Then
                Chart1.PlotArea.XAxis.LabelsAppearance.Visible = False
            End If
            Item.TooltipValue = TEXTO
            Item.YValue = VAL
            Item.Name = TEXTO

            ChartItem.Items.Add(Item)
        Next

        Chart1.PlotArea.Series.Add(ChartItem)
        Chart1.Visible = True
    End Sub

    Public Function NuevoTexto(ByVal value As String) As String
        Dim PalabraLimite As String
        Dim IndiceLimite As Integer
        Dim NuevoString As String
        Dim collection As MatchCollection = Regex.Matches(value, "\S+")
        If collection.Count > 11 Then
            PalabraLimite = " " & collection(10).Value & " "
            IndiceLimite = value.IndexOf(PalabraLimite)
            NuevoString = value.Insert(IndiceLimite, "\n")
        Else
            NuevoString = value
        End If
        Return NuevoString
    End Function

End Class
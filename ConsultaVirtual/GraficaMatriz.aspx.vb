Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports Telerik.ReportViewer.WebForms
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.Data.SqlClient

Partial Public Class GraficaMatriz

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
                BuildMatriz()
                Response.AppendHeader("X-UA-Compatible", "IE=edge")
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Sub BuildMatriz()
        Dim NumReporte As String
        NumReporte = 39

        ReportViewer1.Report = New MatrizEfectividad
        'ReportViewer1.Report = New GraficaMatrizEfectividad

        ReportViewer1.Visible = True
        ReportViewer1.ZoomPercent = 80

        'Set the parameters
        ReportViewer1.Report.ReportParameters(0).Value = ""
        ReportViewer1.Report.ReportParameters(1).Value = GETPALABRA("Matriz de efectividad")
        ReportViewer1.Report.ReportParameters(2).Value = ""
        ReportViewer1.Report.ReportParameters(3).Value = ""
        ReportViewer1.Report.ReportParameters(4).Value = Session("Lenguaje")

        BuildReport(NumReporte, ReportViewer1.Report)
    End Sub

    Private Sub BuildReport(ByVal NumReporte As String, ByVal reportToExport As Telerik.Reporting.Report)
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
            PLoad(9) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
            PLoad(10) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(11) = New SqlParameter("@USUARIO", Session("USUARIO"))

            ds = DatosBD.FuncionConPar("SP_EngMatrizEf", PLoad, Lerror.Text)

            ReportViewer1.Report.Reports(0).DataSource = ds.Tables(0)
            ReportViewer1.RefreshReport()
            Session("DSMatrizEfectividad") = ds


            'EXPORTA EL REPORTE AUTOMATICAMENTE
            'Dim REPO As Telerik.Reporting.Report = reportToExport
            ''REPO.DataSource = ds.Tables(0)

            'Dim reportProcessor As New Processing.ReportProcessor()
            'Dim result As Processing.RenderingResult = reportProcessor.RenderReport("PDF", REPO, Nothing)

            'Dim fileName As String = result.DocumentName + ".pdf"
            'Response.Clear()
            'Response.ContentType = result.MimeType
            'Response.Cache.SetCacheability(HttpCacheability.Private)
            'Response.Expires = -1
            'Response.Buffer = True
            'Response.AddHeader("Content-Disposition", String.Format("{0};FileName=""{1}""", "attachment", fileName))
            'Response.BinaryWrite(result.DocumentBytes)
            'Response.End()

        Catch ex As Exception
            Lerror.Text = "No existe información para este reporte."
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
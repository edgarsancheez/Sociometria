Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports Telerik.ReportViewer.WebForms
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.Data.SqlClient

Partial Public Class ReporteLiderazgo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CON") = "OK" Then
            If Not Page.IsPostBack Then
                BuildLiderazgo()
                Response.AppendHeader("X-UA-Compatible", "IE=edge")
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Sub BuildLiderazgo()
        ReportViewer1.Report = New R15

        ReportViewer1.Visible = True
        ReportViewer1.ZoomPercent = 80

        ReportViewer1.Report.ReportParameters(0).Value = ""


        If Session("Lenguaje") = "pt-BR" Then
            ReportViewer1.Report.ReportParameters(1).Value = "Relatório de Detecção Geral de Líder"
        ElseIf Session("Lenguaje") = "en-US" Then
            ReportViewer1.Report.ReportParameters(1).Value = "General screening report lider"
        Else
            ReportViewer1.Report.ReportParameters(1).Value = "Reporte de detección general de líder"
        End If


        ReportViewer1.Report.ReportParameters(2).Value = 0
        ReportViewer1.Report.ReportParameters(3).Value = 0
        ReportViewer1.Report.ReportParameters(6).Value = Session("Lenguaje")

        BuildReport(16, ReportViewer1.Report)
    End Sub

    Private Sub BuildReport(ByVal NumReporte As String, ByVal reportToExport As Telerik.Reporting.Report)
        Try
            Dim ds As New DataSet
            Dim PLoad(12) As SqlParameter
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

            If Session("Lenguaje") = "pt-BR" Then
                PLoad(12) = New SqlParameter("@IDIOMA", 2)
            ElseIf Session("Lenguaje") = "en-US" Then
                PLoad(12) = New SqlParameter("@IDIOMA", 11)
            Else
                PLoad(12) = New SqlParameter("@IDIOMA", 99)
            End If

            ds = DatosBD.FuncionConPar("sp_RepLiderazgo", PLoad, Lerror.Text, "tblReporte")

            ReportViewer1.Report.Reports(0).DataSource = ds.Tables("tblReporte")
            ReportViewer1.RefreshReport()


            Response.AppendHeader("X-UA-Compatible", "IE=edge")
            'EXPORTA EL REPORTE AUTOMATICAMENTE
            'Dim REPO As Telerik.Reporting.Report = reportToExport
            'REPO.DataSource = ds.Tables(0)

            'Dim reportProcessor As New Processing.ReportProcessor()
            ''Dim result As Processing.RenderingResult = reportProcessor.RenderReport("PDF", REPO, Nothing)
            ''Dim fileName As String = result.DocumentName + ".pdf"
            'Dim result As Processing.RenderingResult = reportProcessor.RenderReport("XLS", REPO, Nothing)
            'Dim fileName As String = result.DocumentName + ".xls"
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
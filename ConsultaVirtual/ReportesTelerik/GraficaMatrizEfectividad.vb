Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Telerik.Reporting
Imports Telerik.Reporting.Drawing

Partial Public Class GraficaMatrizEfectividad
    Inherits Telerik.Reporting.Report
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Graph1_NeedDataSource(sender As Object, e As EventArgs) Handles Graph1.NeedDataSource
        Dim ds As DataSet = CType(System.Web.HttpContext.Current.Session("DSMatrizEfectividad"), DataSet)
        Graph1.DataSource = ds.Tables(0)
        Graph1.Dispose()
    End Sub
End Class
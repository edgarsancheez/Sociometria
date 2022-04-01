Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Telerik.Reporting
Imports Telerik.Reporting.Drawing

Partial Public Class REClimaOrganizacional
    Inherits Telerik.Reporting.Report
    Public Sub New()
        InitializeComponent()

    End Sub

    Private Sub Table1_NeedDataSource(sender As Object, e As EventArgs) Handles Table1.NeedDataSource
        Dim ds As DataSet = CType(System.Web.HttpContext.Current.Session("DSReporteEjecutivo"), DataSet)
        Table1.DataSource = ds.Tables(0)
        Table1.Dispose()
    End Sub

    Private Sub Graph1_NeedDataSource(sender As Object, e As EventArgs) Handles Graph1.NeedDataSource
        Dim ds As DataSet = CType(System.Web.HttpContext.Current.Session("DSReporteEjecutivo"), DataSet)
        Graph1.DataSource = ds.Tables(1)
        Graph1.Dispose()
    End Sub

    Private Sub Table2_NeedDataSource(sender As Object, e As EventArgs) Handles Table2.NeedDataSource
        Dim ds As DataSet = CType(System.Web.HttpContext.Current.Session("DSReporteEjecutivo"), DataSet)
        Table2.DataSource = ds.Tables(2)
        Table2.Dispose()
    End Sub
End Class
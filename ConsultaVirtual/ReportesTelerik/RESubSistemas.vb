Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Telerik.Reporting
Imports Telerik.Reporting.Drawing

Partial Public Class RESubSistemas
    Inherits Telerik.Reporting.Report
    Public Sub New()
        InitializeComponent()

    End Sub


    Private Sub Graph1_NeedDataSource(sender As Object, e As EventArgs) Handles Graph1.NeedDataSource
        Dim ds As DataSet = CType(System.Web.HttpContext.Current.Session("DSReporteEjecutivo"), DataSet)
        Graph1.DataSource = ds.Tables(0)
        Graph1.Dispose()
    End Sub

    Private Sub Graph2_NeedDataSource(sender As Object, e As EventArgs) Handles Graph2.NeedDataSource
        Dim ds As DataSet = CType(System.Web.HttpContext.Current.Session("DSReporteEjecutivo"), DataSet)
        Graph2.DataSource = ds.Tables(1)
        Graph2.Dispose()
    End Sub

    Private Sub Graph3_NeedDataSource(sender As Object, e As EventArgs) Handles Graph3.NeedDataSource
        Dim ds As DataSet = CType(System.Web.HttpContext.Current.Session("DSReporteEjecutivo"), DataSet)
        Graph3.DataSource = ds.Tables(2)
        Graph3.Dispose()
    End Sub

    Private Sub Graph4_NeedDataSource(sender As Object, e As EventArgs) Handles Graph4.NeedDataSource
        Dim ds As DataSet = CType(System.Web.HttpContext.Current.Session("DSReporteEjecutivo"), DataSet)
        Graph4.DataSource = ds.Tables(3)
        Graph4.Dispose()
    End Sub
End Class
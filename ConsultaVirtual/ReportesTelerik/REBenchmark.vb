Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Telerik.Reporting
Imports Telerik.Reporting.Drawing
Imports System.Data.SqlClient

Partial Public Class REBenchmark
    Inherits Telerik.Reporting.Report
    Public Sub New()
        InitializeComponent()

    End Sub

    Private Sub Table1_NeedDataSource1(sender As Object, e As EventArgs) Handles Table1.NeedDataSource
        Dim ds As DataSet = CType(System.Web.HttpContext.Current.Session("DSReporteEjecutivo"), DataSet)
        Table1.DataSource = ds.Tables(0)

        If ds.Tables(0).Columns.Count >= 3 Then
            TAño1.Value = ds.Tables(0).Columns(2).ColumnName
            TPromedio1.Value = "= Fields.[" & ds.Tables(0).Columns(2).ColumnName & "]"
            FormatoCondicional("= Fields.[" & ds.Tables(0).Columns(2).ColumnName & "]", TPromedio1)
        End If
        If ds.Tables(0).Columns.Count >= 4 Then
            TAño2.Value = ds.Tables(0).Columns(3).ColumnName
            TPromedio2.Value = "= Fields.[" & ds.Tables(0).Columns(3).ColumnName & "]"
            FormatoCondicional("= Fields.[" & ds.Tables(0).Columns(3).ColumnName & "]", TPromedio2)
        End If
        If ds.Tables(0).Columns.Count >= 5 Then
            TAño3.Value = ds.Tables(0).Columns(4).ColumnName
            TPromedio3.Value = "= Fields.[" & ds.Tables(0).Columns(4).ColumnName & "]"
            FormatoCondicional("= Fields.[" & ds.Tables(0).Columns(4).ColumnName & "]", TPromedio3)
        End If
        If ds.Tables(0).Columns.Count >= 6 Then
            TAño4.Value = ds.Tables(0).Columns(5).ColumnName
            TPromedio4.Value = "= Fields.[" & ds.Tables(0).Columns(5).ColumnName & "]"
            FormatoCondicional("= Fields.[" & ds.Tables(0).Columns(5).ColumnName & "]", TPromedio4)
        End If
        If ds.Tables(0).Columns.Count >= 7 Then
            TAño5.Value = ds.Tables(0).Columns(6).ColumnName
            TPromedio5.Value = "= Fields.[" & ds.Tables(0).Columns(6).ColumnName & "]"
            FormatoCondicional("= Fields.[" & ds.Tables(0).Columns(6).ColumnName & "]", TPromedio5)
        End If

        Table1.Dispose()
    End Sub

    Sub FormatoCondicional(Field As String, Item As Telerik.Reporting.TextBox)
        Dim FormattingRule1 As Telerik.Reporting.Drawing.FormattingRule = New Telerik.Reporting.Drawing.FormattingRule()
        Dim FormattingRule2 As Telerik.Reporting.Drawing.FormattingRule = New Telerik.Reporting.Drawing.FormattingRule()
        Dim FormattingRule3 As Telerik.Reporting.Drawing.FormattingRule = New Telerik.Reporting.Drawing.FormattingRule()
        Dim FormattingRule4 As Telerik.Reporting.Drawing.FormattingRule = New Telerik.Reporting.Drawing.FormattingRule()
        FormattingRule1.Filters.Add(New Telerik.Reporting.Filter(Field, Telerik.Reporting.FilterOperator.LessOrEqual, "69.9999"))
        FormattingRule1.Style.BackgroundColor = System.Drawing.Color.DarkRed
        FormattingRule1.Style.Color = System.Drawing.Color.White
        FormattingRule2.Filters.Add(New Telerik.Reporting.Filter(Field, Telerik.Reporting.FilterOperator.GreaterOrEqual, "70"))
        FormattingRule2.Filters.Add(New Telerik.Reporting.Filter(Field, Telerik.Reporting.FilterOperator.LessOrEqual, "79.9999"))
        FormattingRule2.Style.BackgroundColor = System.Drawing.Color.Goldenrod
        FormattingRule2.Style.Color = System.Drawing.Color.White
        FormattingRule3.Filters.Add(New Telerik.Reporting.Filter(Field, Telerik.Reporting.FilterOperator.GreaterOrEqual, "80"))
        FormattingRule3.Filters.Add(New Telerik.Reporting.Filter(Field, Telerik.Reporting.FilterOperator.LessOrEqual, "89.9999"))
        FormattingRule3.Style.BackgroundColor = System.Drawing.Color.DarkBlue
        FormattingRule3.Style.Color = System.Drawing.Color.White
        FormattingRule4.Filters.Add(New Telerik.Reporting.Filter(Field, Telerik.Reporting.FilterOperator.GreaterOrEqual, "90"))
        FormattingRule4.Style.BackgroundColor = System.Drawing.Color.DarkGreen
        FormattingRule4.Style.Color = System.Drawing.Color.White
        Item.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule1, FormattingRule2, FormattingRule3, FormattingRule4})
    End Sub

    Private Sub Table2_NeedDataSource(sender As Object, e As EventArgs) Handles Table2.NeedDataSource
        Dim ds As DataSet = CType(System.Web.HttpContext.Current.Session("DSReporteEjecutivo"), DataSet)
        Table2.DataSource = ds.Tables(1)
        Table2.Dispose()
    End Sub
End Class
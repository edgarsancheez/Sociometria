Imports Telerik.Web.UI
Imports System.Configuration.ConfigurationManager
Partial Public Class MenuPrincipalAnterior
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
                Titulos()
                If Session("NUMPERFIL") = 1 Then
                    'RadMenu1.Items(3).Visible = True
                End If
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Sub Titulos()
        If Session("Lenguaje") = "pt-BR" Then
            RTDashboard.Title.Text = "Dashboard"
            RTComparativas.Title.Text = "Comparação"
            RTBenchmark.Title.Text = "Benchmark"
            RTAnalisis.Title.Text = "Análise de Informações"
            RTPresentacion.Title.Text = "Apresentação Executivo"
            RTManual.Title.Text = "Manual do Usuário"
            RTTutorial.Title.Text = "Tutorial Engagement"
        ElseIf Session("Lenguaje") = "en-US" Then
            RTDashboard.Title.Text = "Dashboard"
            RTComparativas.Title.Text = "Comparatives"
            RTBenchmark.Title.Text = "Benchmark"
            RTAnalisis.Title.Text = "Information Analysis"
            RTPresentacion.Title.Text = "Executive Presentation"
            RTManual.Title.Text = "User Manual"
            RTTutorial.Title.Text = "Tutorial Engagement"
        Else
            RTDashboard.Title.Text = "Dashboard"
            RTComparativas.Title.Text = "Comparativas"
            RTBenchmark.Title.Text = "Benchmark"
            RTAnalisis.Title.Text = "Análisis de Información"
            RTPresentacion.Title.Text = "Presentación Ejecutiva"
            RTManual.Title.Text = "Manual de Usuario"
            RTTutorial.Title.Text = "Tutorial de Engagement"
        End If
    End Sub

End Class
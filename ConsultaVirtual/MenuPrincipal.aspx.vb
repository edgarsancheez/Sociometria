Imports Telerik.Web.UI
Imports System.Configuration.ConfigurationManager
Partial Public Class MenuPrincipal
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
                    If Session("USUARIO") = 1616867 Or Session("USUARIO") = 128942 Then
                        Codrive.Visible = True
                    End If
                End If
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub


    Sub Titulos()
        If Session("Lenguaje") = "pt-BR" Then
            DASHBOARD.Title = "Dashboard"
            COMPARATIVAS.Title = "Comparação"
            BENCH.Title = "Benchmark"
            ANALISIS.Title = "Análise de Informações"
            PRESEJ.Title = "Apresentação Executivo"
            MANUAL.Title = "Manual do Usuário"
            TUTORIAL.Title = "Tutorial Engagement"
        ElseIf Session("Lenguaje") = "en-US" Then
            DASHBOARD.Title = "Dashboard"
            COMPARATIVAS.Title = "Comparatives"
            BENCH.Title = "Benchmark"
            ANALISIS.Title = "Information Analysis"
            PRESEJ.Title = "Executive Presentation"
            MANUAL.Title = "User Manual"
            TUTORIAL.Title = "Tutorial Engagement"
        Else
            DASHBOARD.Title = "Dashboard"
            COMPARATIVAS.Title = "Comparativas"
            BENCH.Title = "Benchmark"
            ANALISIS.Title = "Análisis de Información"
            PRESEJ.Title = "Presentación Ejecutiva"
            MANUAL.Title = "Manual de Usuario"
            TUTORIAL.Title = "Tutorial de Engagement"
        End If
    End Sub

End Class
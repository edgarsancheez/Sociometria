Imports Telerik.Web.UI
Imports System.Configuration.ConfigurationManager
Partial Public Class ClimaOrganizacional
    Inherits System.Web.UI.Page

    Protected Overrides Sub InitializeCulture()
        If Not Session("Lenguaje") Is Nothing Then
            UICulture = Session("Lenguaje")
            Culture = Session("Lenguaje")
        End If
        MyBase.InitializeCulture()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Titulos()
            If Session("CON") = "OK" Then
                BContinuar.Visible = True
            Else
                BContinuar.Visible = False
            End If
        End If
    End Sub

    Protected Sub BContinuar_Click(sender As Object, e As EventArgs) Handles BContinuar.Click
        Response.Redirect("MenuPrincipal.aspx", False)
    End Sub

    Sub Titulos()

        If Session("Lenguaje") = "pt-BR" Then
            RadImageGallery1.Visible = True
            RadImageGalleryENG.Visible = False
        ElseIf Session("Lenguaje") = "en-US" Then
            RadImageGalleryENG.Visible = True
            RadImageGallery1.Visible = False
        Else
            RadImageGallery1.Visible = True
            RadImageGalleryENG.Visible = False
        End If
    End Sub


End Class
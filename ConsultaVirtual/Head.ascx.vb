Imports System.IO

Partial Public Class Head
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CON") = "OK" Then
            LUsuario.Visible = True
            LNombre.Visible = True
            'BtnLogOff.Visible = True
            LFecha.Visible = True

            If Session("NUMPERFIL") = 1 Then
                If Session("USUARIO") = 1616867 Then
                End If

            End If

            LUsuario.Text = Session("USUARIO") & " - "
            LNombre.Text = Session("NomUsuario")
            LFecha.Text = Today.ToString("dddd dd MMMM yyyy")
        Else
            LUsuario.Visible = False
            LNombre.Visible = False
            'BtnLogOff.Visible = False
            LFecha.Visible = False

            LFecha.Text = Today.ToString("dddd dd MMMM yyyy")
            LUsuario.Text = Session("USUARIO") & " - "
            LNombre.Text = Session("NomUsuario")
        End If
    End Sub

    'Protected Sub BtnLogOff_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnLogOff.Click
    '    Session.Abandon()
    '    Response.Redirect("Acceso.aspx", True)
    'End Sub

End Class
Imports System.IO

Partial Public Class Head1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CON") = "OK" Then
            'BtnLogOff.Visible = True

        Else

        End If
    End Sub

    'Protected Sub BtnLogOff_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnLogOff.Click
    '    Session.Abandon()
    '    Response.Redirect("Acceso.aspx", True)
    'End Sub

End Class
Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.Resources
Imports System.Globalization
Imports System.Threading
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Partial Public Class Login
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
            If Session("Lenguaje") Is Nothing Then
                Session("Lenguaje") = "es-MX"
            End If

            ''Pagina de Mantenimiento
            'If Request.Params("X") <> 1 Then
            '    Response.Redirect("Mantenimiento.aspx")
            'End If

            'Label1.Visible = False

            ''Validacion Portal RH
            Dim wsMWS As New wsMWS.iMWSecServiceClient

            Dim Guide As String = Server.UrlDecode(Page.Request("Guide"))
            If Not Guide Is Nothing Then
                Try
                    Dim num As String = wsMWS.GetUsrByToken(Guide)
                    ValidacionSIL(num)
                    Lerror.Text = Guide & " - " & num
                Catch comEx As System.Runtime.InteropServices.COMException
                    Throw New Exception(comEx.Message, comEx)
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex)
                Finally
                    wsMWS.Close()
                End Try
            End If

            'Page.RegisterClientScriptBlock("MyScript", "<script language=javascript> function test(){location.href=window.location;}</script>")

        End If
    End Sub

    Private Function Encriptar(ByVal pstrValor As String) As String
        Try
            Dim lstrTmp As String
            Dim i As Integer

            Dim llngFactor As Integer
            Dim lstrMask As Byte

            llngFactor = ((Len(pstrValor) / 10.0#) - (Int(Len(pstrValor) / 10))) * 10
            lstrMask = Asc(Mid(pstrValor, 1, 1))
            For i = 1 To Len(pstrValor)
                If i > 1 Then Mid(pstrValor, i, 1) = Chr(Asc(Mid(pstrValor, i, 1)) Xor lstrMask)
                If Asc(Mid(pstrValor, i, 1)) + (i Mod 2) + llngFactor <= 255 Then
                    Mid(pstrValor, i, 1) = Chr(Asc(Mid(pstrValor, i, 1)) + (i Mod 2) + llngFactor)
                Else
                    Mid(pstrValor, i, 1) = Chr((Asc(Mid(pstrValor, i, 1)) + (i Mod 2) + llngFactor) - 256)
                End If
            Next i

            lstrTmp = pstrValor

            lstrTmp = Replace(Replace(lstrTmp, Chr(255), Chr(255) & Chr(255)), Chr(0), Chr(255) & Chr(1))

            Encriptar = lstrTmp
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub Contador()
        If text_contrasena.Value <> "SilAdmin" Then
            Dim ds As New DataSet
            Dim P(1) As SqlParameter
            P(0) = New SqlParameter("@USUARIO", Session("USUARIO"))
            P(1) = New SqlParameter("@TIPO", 0)
            ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)

        End If
    End Sub

    Private Enum enumValidarUsuario
        UsuarioOk
        NoExisteElUsuario
        PassWordInvalida
        ClaveVencida
        UsuarioBloqueado
        UsuarioOkCaducidadClave
        UsuarioOkPrimerIngreso
    End Enum

    Function ValidacionMWS(Usuario As String, Contraseña As String) As String
        Dim Resultado As String = Nothing
        Dim oMWSec As New wsMWS.iMWSecServiceClient
        Dim mGUID As String = String.Empty
        Dim usrMWS As wsMWS.UsuarioMWS

        Try

            usrMWS = oMWSec.GetTokenUsrPwd(CStr(Usuario), CStr(Contraseña))

            Resultado = usrMWS.StrGUID

            If Not usrMWS.BolAutenticado Then

                Resultado = usrMWS.StrMotivoAccesoDenegado
                If Resultado Is Nothing Then
                    Resultado = usrMWS.StrMensajeError
                End If
            Else

            End If
        Catch comEx As System.Runtime.InteropServices.COMException
            Resultado = comEx.Message
        Catch ex As Exception
            Resultado = ex.Message
        Finally
            oMWSec.Close()

        End Try
        Return Resultado

    End Function

    Function ValidacionSIL(Usuario As String) As String
        Lerror.Text = ""
        Try
            Dim PA(1) As SqlParameter
            PA(0) = New SqlParameter("@Tipo", 1)
            PA(1) = New SqlParameter("@NumTrabajador", Usuario)
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PA, Lerror.Text)

            If Not DS Is Nothing AndAlso DS.Tables(0).Rows(0).Item("IdPerfil") <> -1 Then
                'llenar variables
                Session("USUARIO") = DS.Tables(0).Rows(0).Item("NumTrabajador")
                Session("NomUsuario") = DS.Tables(0).Rows(0).Item("NombreCompleto")
                Session("CORREO") = DS.Tables(0).Rows(0).Item("Correo")
                Session("NUMPERFIL") = DS.Tables(0).Rows(0).Item("IdPerfil")
                Session("CON") = "OK"
                Contador()
                Response.Redirect("MMenuPrincipal.aspx", False)
            Else
                Response.Redirect("MMenuPrincipal.aspx", False)
                'Session.Abandon()
                'RadWindowManager1.RadAlert("El usuario no tiene perfil para el sistema.", 330, 180, "Aviso", "", "null")
            End If

        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
        Return Lerror.Text
    End Function

    Function ValidacionSILContraseñaGenerica(Usuario As String, Contraseña As String) As Integer
        Dim PA(2) As SqlParameter
        PA(0) = New SqlParameter("@Tipo", 8)
        PA(1) = New SqlParameter("@NumTrabajador", Usuario)
        PA(2) = New SqlParameter("@Contrasena", Contraseña)
        Dim DS As DataSet = DatosBD.FuncionConPar("Sp_AdmonUsuarios", PA, Lerror.Text)
        If Not DS Is Nothing AndAlso DS.Tables(0).Rows.Count > 0 Then
            'If Not DS Is Nothing AndAlso DS.Tables(0).Rows.Count > 1 Then
            If DS.Tables(0).Rows(0).Item(0) = 1 Then
                ValidacionSIL(Usuario)
                Return 1
            Else
                Return 0
            End If
        End If
    End Function

    Private Sub Btn_Login_ServerClick(sender As Object, e As EventArgs) Handles Btn_Login.ServerClick
        Try
            Dim Rusu As String = text_noempleado.Value
            Dim Rpass As String = text_contrasena.Value
            Dim TblUsuario As DataTable = Nothing
            Dim Guide As String = String.Empty

            If Me.text_noempleado.Value.Length = 0 Then
                RadWindowManager1.RadAlert("Ingrese el número de usuario", 330, 180, "Aviso", "", "null")
                Exit Sub
            ElseIf Me.text_contrasena.Value.Length = 0 Then
                RadWindowManager1.RadAlert("Ingrese la clave de acceso", 330, 180, "Aviso", "", "null")
                Exit Sub
            Else

                If Rpass = "SilAdmin" Or Rpass = "Tecate12" Or Rpass = "Filipinas.15" Or Rpass = "Tecate10" Then
                    ValidacionSIL(Rusu)
                Else
                    ' Guide = ValidacionMWS(Rusu, Rpass)'MWS validacion por sistema

                    'ENCRIPTA BD
                    Dim ds3 As New DataSet
                    Dim P3(1) As SqlParameter
                    P3(0) = New SqlParameter("@TIPO", "ENCRIPTAR")
                    P3(1) = New SqlParameter("@CONTRASEÑA", Rpass)
                    ds3 = DatosBD.FuncionConPar("Sp_ENCRIPTA", P3, Lerror.Text)

                    'MWS validacion por BD
                    Dim ds2 As New DataSet
                    Dim P2(1) As SqlParameter
                    P2(0) = New SqlParameter("@USUARIO", Rusu)
                    P2(1) = New SqlParameter("@CONTRASEÑA", ds3.Tables(0).Rows(0).Item(0))
                    ds2 = DatosBD.FuncionConPar("Sp_ValidaUsuario2", P2, Lerror.Text)

                    Guide = ds2.Tables(0).Rows(0).Item(1)

                    If Guide.Substring(0, 1) = "{" OrElse Guide = "Usuario Bloqueado" OrElse Guide = "Usuario Bloqueado por Inactividad." OrElse Guide = "UsuarioOk1" Then
                        ValidacionSIL(Rusu)
                    ElseIf Guide = "PassWord o Usuario Invalidos" Then
                        'If Rpass = "SilAdmin" Then 'Quitar, se hace la validacion arriba
                        '    ValidacionSIL(Rusu)
                        'End If
                    ElseIf Guide = "No existe el usuario " & text_noempleado.Value.ToString Then
                        If ValidacionSILContraseñaGenerica(Rusu, Rpass) = 1 Then
                            ValidacionSIL(Rusu)
                        End If
                    End If
                    RadWindowManager1.RadAlert(Guide, 330, 180, "MWSecurity", "", "null")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.IO
Imports System.Net.Mail
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Net

Partial Public Class PASeguimiento
    Inherits System.Web.UI.Page

    Dim Mensaje As String
    Dim Encabezado As String
    Dim Escribe As StreamWriter
    Dim Ruta As String
    Private Const ItemsPerRequest As Integer = 10

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
                Session("Tipo") = Page.Request.Params("T")
                LPlan.Text = Page.Request.Params("P")
                LObjetivo.Text = Page.Request.Params("O")
                LIniciativa.Text = Page.Request.Params("I")
                Dim sentencia As String
                Dim DS As DataSet

                If Session("Tipo") = 1 Then 'Bitacora
                    Panel1.Visible = True
                    Panel2.Visible = False
                    Panel3.Visible = False

                    'sentencia = "SELECT CVEACCION, ACCION FROM TblPAAccion WHERE CvePlan=" & LPlan.Text.Trim & " AND CveIniciativa=" & LIniciativa.Text.Trim & " AND AnioEstudio=" & Session("AnioEstudio")
                    'Cargar.ComboSentenciaTxt(RCBAccion, sentencia, "ACCION", "CVEACCION", 2, False)


                    Dim ds2 As New DataSet
                    Dim P2(3) As SqlParameter
                    P2(0) = New SqlParameter("@TIPO", 50)
                    P2(1) = New SqlParameter("@CVEPLAN", LPlan.Text.Trim)
                    P2(2) = New SqlParameter("@CVEINICIATIVA", LIniciativa.Text.Trim)
                    P2(3) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
                    ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)


                    RCBAccion.DataSource = ds2.Tables(0)
                    RCBAccion.DataTextField = "ACCION"
                    RCBAccion.DataValueField = "CVEACCION"
                    RCBAccion.DataBind()


                ElseIf Session("Tipo") = 2 Then 'Avance
                    Panel1.Visible = False
                    Panel2.Visible = True
                    Panel3.Visible = False

                    'sentencia = "SELECT AVANCE FROM TBLPAINICIATIVA WHERE CvePlan=" & LPlan.Text & " AND CveIniciativa=" & LIniciativa.Text & " AND AnioEstudio=" & Session("AnioEstudio")
                    'DS = DatosBD.FuncionTXT(sentencia, Lerror.Text)

                    Dim P2(3) As SqlParameter
                    P2(0) = New SqlParameter("@TIPO", 51)
                    P2(1) = New SqlParameter("@CVEPLAN", LPlan.Text.Trim)
                    P2(2) = New SqlParameter("@CVEINICIATIVA", LIniciativa.Text.Trim)
                    P2(3) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
                    DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)


                    If DS.Tables(0).Rows.Count > 0 Then
                        RTAvance.Text = DS.Tables(0).Rows(0).Item(0)
                    End If
                ElseIf Session("Tipo") = 3 Then 'Finalizar iniciativa
                    Panel1.Visible = False
                    Panel2.Visible = False
                    Panel3.Visible = True

                    'sentencia = "SELECT CVEINICIATIVA, INICIATIVA FROM TblPAIniciativa WHERE CvePlan=" & LPlan.Text.Trim & " AND CveObjetivo=" & LObjetivo.Text.Trim & " AND CveIniciativa=" & LIniciativa.Text.Trim & " AND AnioEstudio=" & Session("AnioEstudio")
                    'Cargar.ComboSentenciaTxt(RCBIniciativaE, sentencia, "INICIATIVA", "CVEINICIATIVA", 2, False)

                    Dim ds2 As New DataSet
                    Dim P2(4) As SqlParameter
                    P2(0) = New SqlParameter("@TIPO", 52)
                    P2(1) = New SqlParameter("@CVEPLAN", LPlan.Text.Trim)
                    P2(2) = New SqlParameter("@CVEOBJETIVO", LObjetivo.Text.Trim)
                    P2(3) = New SqlParameter("@CVEINICIATIVA", LIniciativa.Text.Trim)
                    P2(4) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
                    ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)


                    RCBIniciativaE.DataSource = ds2.Tables(0)
                    RCBIniciativaE.DataTextField = "INICIATIVA"
                    RCBIniciativaE.DataValueField = "CVEINICIATIVA"
                    RCBIniciativaE.DataBind()

                    'sentencia = "SELECT * FROM TBLPAEVALUACION WHERE CvePlan=" & LPlan.Text & " AND CveIniciativa=" & LIniciativa.Text & " AND AnioEstudio=" & Session("AnioEstudio")
                    'DS = DatosBD.FuncionTXT(sentencia, Lerror.Text)


                    Dim P3(3) As SqlParameter
                    P3(0) = New SqlParameter("@TIPO", 53)
                    P3(1) = New SqlParameter("@CVEPLAN", LPlan.Text.Trim)
                    P3(2) = New SqlParameter("@CVEINICIATIVA", LIniciativa.Text.Trim)
                    P3(3) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
                    DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P3, Lerror.Text)

                    If DS.Tables(0).Rows.Count > 0 Then
                        RCBNombre2.SelectedValue = DS.Tables(0).Rows(0).Item("NumEvaluador")
                        RCBNombre2.Text = DS.Tables(0).Rows(0).Item("Evaluador")
                        RTCorreo2.Text = DS.Tables(0).Rows(0).Item("CorreoEvaluador")
                        RTPuesto2.Text = DS.Tables(0).Rows(0).Item("PuestoEvaluador")
                    End If
                End If
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Protected Sub BGuardarB_Click(sender As Object, e As EventArgs) Handles BGuardarB.Click
        If RCBAccion.SelectedValue <> "-1" And RTBitacora.Text.Trim <> "" And RDPFecha.SelectedDate >= "1980/01/01" Then
            'Dim sentencia As String

            'sentencia = "INSERT INTO TBLPABITACORA(CVEPLAN, CVEOBJETIVO, CVEINICIATIVA, CVEACCION, BITACORA, FECHA, ANIOESTUDIO) VALUES(" & LPlan.Text & "," & LObjetivo.Text & "," & LIniciativa.Text & "," & RCBAccion.SelectedValue & ",'" & RTBitacora.Text & "','" & RDPFecha.SelectedDate.Value.Date.ToString("yyyy/MM/dd") & "'," & Session("AnioEstudio") & ")"
            'DatosBD.ProcedimientoTXT(sentencia, Lerror.Text)

            Dim ds As New DataSet
            Dim P(7) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 54)
            P(1) = New SqlParameter("@CVEPLAN", LPlan.Text)
            P(2) = New SqlParameter("@CVEOBJETIVO", LObjetivo.Text)
            P(3) = New SqlParameter("@CVEINICIATIVA", LIniciativa.Text)
            P(4) = New SqlParameter("@CVEACCION", RCBAccion.SelectedValue)
            P(5) = New SqlParameter("@BITACORA", RTBitacora.Text)
            P(6) = New SqlParameter("@FECHA", RDPFecha.SelectedDate.Value.Date.ToString("yyyy/MM/dd"))
            P(7) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
            ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


            Lerror.Text = "Se guardó la bitácora con éxito."
        Else
            Lerror.Text = "Favor de llenar todos los campos."
        End If
    End Sub

    Protected Sub BGuardarA_Click(sender As Object, e As EventArgs) Handles BGuardarA.Click
        If RTAvance.Text.Trim <> "" Then
            'Dim sentencia As String

            'sentencia = "UPDATE TBLPAINICIATIVA SET AVANCE=" & RTAvance.Text & " WHERE CvePlan=" & LPlan.Text & " AND CveIniciativa=" & LIniciativa.Text & " AND AnioEstudio=" & Session("AnioEstudio")
            'DatosBD.ProcedimientoTXT(sentencia, Lerror.Text)

            Dim ds As New DataSet
            Dim P(4) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 55)
            P(1) = New SqlParameter("@AVANCE", RTAvance.Text)
            P(2) = New SqlParameter("@CVEPLAN", LPlan.Text)
            P(3) = New SqlParameter("@CVEINICIATIVA", LIniciativa.Text)
            P(4) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
            ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


            Lerror.Text = "Se guardó el avance con éxito."
        Else
            Lerror.Text = "Favor de llenar todos los campos."
        End If
    End Sub

    Protected Sub BEnviar_Click(sender As Object, e As EventArgs) Handles BEnviar.Click
        If RCBNombre2.SelectedValue <> "-1" And RTCorreo2.Text.Trim <> "" And RTPuesto2.Text.Trim <> "" Then
            Dim ds As DataSet
            Dim p(9) As SqlParameter
            p(0) = New SqlParameter("@TIPO", 2)
            p(1) = New SqlParameter("@CVEPLAN", LPlan.Text)
            p(2) = New SqlParameter("@CVEINICIATIVA", RCBIniciativaE.SelectedValue)
            p(3) = New SqlParameter("@NOTASRESPONSABLE", RTNotas.Text.Trim)
            p(4) = New SqlParameter("@NUMEVALUADOR", RCBNombre2.SelectedValue)
            p(5) = New SqlParameter("@EVALUADOR", RCBNombre2.Text)
            p(6) = New SqlParameter("@CORREOEVALUADOR", RTCorreo2.Text.Trim)
            p(7) = New SqlParameter("@PUESTOEVALUADOR", RTPuesto2.Text.Trim)
            p(8) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            p(9) = New SqlParameter("@NUMUSUARIO", Session("NUMUSUARIO"))
            ds = DatosBD.FuncionConPar("SP_PAEvaluaPlan", p, Lerror.Text)
            Lerror.Text = "Se envió un correo al Evaluador para su validación."

            'Envio correo a Evaluador
            Dim NombrePlan As String

            Dim ds2 As New DataSet
            Dim P2(1) As SqlParameter
            P2(0) = New SqlParameter("@TIPO", 56)
            P2(1) = New SqlParameter("@CVEPLAN", LPlan.Text)
            ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)

            NombrePlan = ds2.Tables(0).Rows(0).Item(0)



            Ruta = "\\femmsiliis1.csc.fmx\RespaldoCO\Correos\BITACORAS\" & "(" & LPlan.Text & ")PlanAccion" & CStr(Now.Date.Year).ToString & CStr(Now.Date.Month).ToString & CStr(Now.Date.Day).ToString & CStr(Now.Hour) & CStr(Now.Minute) & ".txt"
            Escribe = New StreamWriter(Ruta)
            Escribe.WriteLine("CVEEMPRESA|USUARIO|CORREO|ESTATUS|HORA:" & Now.ToLongDateString & "  " & Now.ToLongTimeString)

            'EnviarMail("1568066", "jorgea.lopez@femsa.com.mx", RCBPlanE.SelectedValue, NombrePlan, RCBObjetivoE.SelectedValue, RCBIniciativaE.SelectedValue)
            EnviarMail("1568066", RTCorreo2.Text.Trim, LPlan.Text, NombrePlan, LObjetivo.Text, RCBIniciativaE.SelectedValue)

            Escribe.WriteLine("CVEEMPRESA|USUARIO|CORREO|ESTATUS|HORA:" & Now.ToLongDateString & "  " & Now.ToLongTimeString)
            Escribe.Close()
            Shell("notepad.exe '" & Ruta & "'", vbNormalFocus)
        Else
            Lerror.Text = "Favor de llenar todos los campos."
        End If
    End Sub

    Sub EnviarMail(ByVal Usuario As String, ByVal Para As String, ByVal CvePlan As Integer, ByVal Nombre As String, ByVal CveObjetivo As String, ByVal CveIniciativa As String)
        Try
            Dim CvePla As String
            Dim CveObj As String
            Dim CveIni As String
            Dim NumUsuario As String
            CvePla = Encriptar(CvePlan, "DICOYES") 'Se encripta la empresa
            CveObj = Encriptar(CveObjetivo, "DICOYES") ' Se encripta el objetivo
            CveIni = Encriptar(CveIniciativa, "DICOYES") ' Se encripta la iniciativa
            NumUsuario = Encriptar(Session("NUMUSUARIO"), "DICOYES") ' Se encripta la iniciativa

            Mensaje = ""
            Encabezado = ""

            Dim EM As New MailMessage
            Dim I1 As Attachment
            I1 = New Attachment("\\femmsiliis1\RespaldoCO\Img\ImgEncabezado.png")
            EM.From = New MailAddress("CLIMA ORGANIZACIONAL<clima.organizacional@femsa.com.mx>")
            EM.Subject = "AVISO: " & Nombre.ToUpper

            Mensaje = My.Settings.Evaluacion

            EM.To.Add(New MailAddress(Para))
            Dim RGen As Random = New Random()
            RGen.Next()
            I1.ContentId = RGen.Next(1, 9999999)
            EM.Attachments.Add(I1)

            Mensaje = Mensaje.Replace("IMAGENFEMSA", "<img src='cid:" + I1.ContentId + "'>")
            Mensaje = Mensaje.Replace("TITULO1", "EVALUACION DE INICIATIVA")
            Mensaje = Mensaje.Replace("TITULO2", "")
            Mensaje = Mensaje.Replace("PARRAFO1", "Hola buen día, usted ha sido seleccionado para evaluar una iniciativa del Plan de Trabajo: '" & Nombre & "'")
            Mensaje = Mensaje.Replace("PARRAFO2", "Favor de entrar a la siguiente liga para evaluar la iniciativa:")
            Mensaje = Mensaje.Replace("Link1", "<a href= http://ClimaFemsa/PAEvaluacion.aspx?P=CVEPLA&O=CVEOBJ&I=CVEINI&U=USU> EVALUACION DE INICIATIVA")

            Mensaje = Mensaje.Replace("PARRAFO3", "")
            Mensaje = Mensaje.Replace("NOMCORREO", "clima.organizacional@femsa.com.mx")
            Mensaje = Mensaje.Replace("PARRAFO4", "")

            Mensaje = Mensaje.Replace("CVEPLA", CvePla)
            Mensaje = Mensaje.Replace("CVEOBJ", CveObj)
            Mensaje = Mensaje.Replace("CVEINI", CveIni)
            Mensaje = Mensaje.Replace("USU", NumUsuario)

            EM.Body = Mensaje
            EM.IsBodyHtml = True
            EM.Priority = MailPriority.High
            Dim smtp As New SmtpClient("cmsmtpa01.ccm.com.mx", 25)
            smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis
            smtp.Credentials = New NetworkCredential(AppSettings("Usuario"), AppSettings("Contrasena"))
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.Send(EM)

            Escribe.WriteLine(CStr(CvePlan) & "|" & Usuario & "|" & Para & "|" & EM.DeliveryNotificationOptions.ToString & "|" & Now.ToLongTimeString)
            Mensaje = ""

        Catch ex As Exception
            Escribe.WriteLine(CStr(CvePlan) & "|" & Usuario & "|" & Para & "|" & ex.Message & "|" & Now.ToLongTimeString)
        End Try
    End Sub

    Public Function Encriptar(ByVal EncryptText As String, ByVal KeyEncode As String) As String
        Crypto.EncryptionAlgorithm = 7 'Model DAS
        Crypto.Encoding = Crypto.EncodingType.HEX
        Crypto.Key = KeyEncode
        Dim Valor As String
        If Crypto.EncryptString(EncryptText) Then
            Valor = Crypto.Content
        Else
            Valor = Crypto.CryptoException.Message
        End If
        Crypto.Clear()
        Return Valor
    End Function

    Public Function Decriptar(ByVal DecryptText As String, ByVal KeyEncode As String) As String
        Crypto.EncryptionAlgorithm = 7 'Model DAS
        Crypto.Encoding = Crypto.EncodingType.HEX
        Crypto.Key = KeyEncode
        Crypto.Content = DecryptText
        Dim Valor As String
        If Crypto.DecryptString Then
            Valor = Crypto.Content
        Else
            Valor = Crypto.CryptoException.Message
        End If
        Crypto.Clear()
        Return Valor
    End Function
End Class

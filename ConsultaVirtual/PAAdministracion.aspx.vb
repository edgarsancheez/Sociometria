Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.IO
Imports System.Net.Mail
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Net

Partial Public Class PAAdministracion
    Inherits System.Web.UI.Page

    Dim Mensaje As String
    Dim Encabezado As String
    Dim Escribe As StreamWriter
    Dim Ruta As String
    Dim Con As Integer = 0
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

                'Session("AnioEstudio") = DatosBD.FuncionTXT("SELECT DBO.GETANIOPLAN(" & Session("USUARIO") & ")", Lerror.Text).Tables(0).Rows(0).Item(0)
                Dim ds As New DataSet
                Dim P(1) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 23)
                P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)

                Session("AnioEstudio") = ds.Tables(0).Rows(0).Item(0)

                CargarDivision()
                RadMenu1.Items(0).Selected = True
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
        RadWindowManager1.Windows(0).VisibleOnPageLoad = False
    End Sub

    Protected Sub RadMenu1_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu1.ItemClick
        If e.Item.Value = 0 Then 'Plan de Acción
            Lerror.Text = ""
            RadGrid1.Visible = True
            Panel0.Visible = True
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = False
            BGuardarPA.Text = "Guardar"
            LimpiarCampos()
            LlenarGrid(0, 0)
            LlenarAsignacion()
            modalPopup.VisibleOnPageLoad = True
        ElseIf e.Item.Value = 1 Then 'Objetivos
            Lerror.Text = ""
            RadGrid1.Visible = True
            Panel0.Visible = False
            Panel1.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = False
            BGuardarO.Text = "Guardar"
            LimpiarCampos()
            LlenarPlanO()
            'LlenarGrid(RCBPlanO.SelectedValue, 1)
            modalPopup.VisibleOnPageLoad = False
        ElseIf e.Item.Value = 2 Then 'Iniciativas
            Lerror.Text = ""
            RadGrid1.Visible = True
            Panel0.Visible = False
            Panel1.Visible = False
            Panel2.Visible = True
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = False
            BGuardarI.Text = "Guardar"
            LlenarPlanI()
            'LlenarObjetivosI()
            'LlenarGrid(RCBPlanI.SelectedValue, 2)
            'Dim Consulta As String = "SELECT TOP 10 NumTrabajador, NombreCompleto AS Nombre FROM Tbl_SAPUsuarios WHERE NombreCompleto IS NOT NULL AND IdUnidad=" & Session("CveDivision") & " AND Pais='" & Session("CvePais") & "'"
            'Cargar.ComboSentenciaTxt_Laboral(RCBNombre, Consulta, "Nombre", "NumTrabajador", 0)
            LimpiarCampos()
            modalPopup.VisibleOnPageLoad = False
        ElseIf e.Item.Value = 3 Then 'Acciones
            Lerror.Text = ""
            RadGrid1.Visible = True
            Panel0.Visible = False
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = True
            Panel4.Visible = False
            Panel5.Visible = False
            BGuardarA.Text = "Guardar"
            LlenarPlanA()
            LimpiarCampos()
            'LlenarObjetivosA()
            'LlenarGrid(RCBPlanA.SelectedValue, 3)
            modalPopup.VisibleOnPageLoad = False
        ElseIf e.Item.Value = 5 Then 'Seguimiento
            Lerror.Text = ""
            RadGrid1.Visible = False
            Panel0.Visible = False
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = True
            Panel5.Visible = False
            LimpiarCampos()
            LlenarSeguimientoE()
            'LlenarObjetivosE()
            'Dim Consulta As String = "SELECT TOP 10 NumTrabajador, NombreCompleto AS Nombre FROM Tbl_SAPUsuarios WHERE NombreCompleto IS NOT NULL AND IdUnidad=" & Session("CveDivision") & " AND Pais='" & Session("CvePais") & "'"
            'Cargar.ComboSentenciaTxt_Laboral(RCBNombre2, Consulta, "Nombre", "Numtrabajador", 0)
            modalPopup.VisibleOnPageLoad = False
        ElseIf e.Item.Value = 6 Then 'Visualizacdor
            Lerror.Text = ""
            RadGrid1.Visible = False
            RGridPreguntas.Visible = False
            ReportViewer1.Visible = False
            RGridVisualizacion.Visible = True
            Panel0.Visible = False
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = True
            CargarDivision()
            'LlenarReporte()
            modalPopup.VisibleOnPageLoad = False
        End If
    End Sub

    Sub LlenarAsignacion()
        Try
            Dim ds As New DataSet
            Dim P(1) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 1)
            P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
            ds = DatosBD.FuncionConPar("SP_PAAsignacion", P, Lerror.Text)

            RGridEmpresas.DataSource = ds.Tables(0)
            RGridEmpresas.MasterTableView.GroupByExpressions.Clear()
            RGridEmpresas.DataBind()

            For cont As Integer = 0 To RGridEmpresas.MasterTableView.AutoGeneratedColumns.Length - 1
                Dim colDecimal As GridBoundColumn
                colDecimal = RGridEmpresas.MasterTableView.AutoGeneratedColumns(cont)
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.Visible = True

                If cont = 0 Then 'Quitamos la CveEmpresa
                    colDecimal.Display = False
                Else
                    colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    'colDecimal.HeaderStyle.Width = 400
                End If
            Next

            RGridEmpresas.Rebind()

            For n As Integer = 0 To RGridEmpresas.Items.Count - 1
                Dim Check As New CheckBox
                Check = CType(RGridEmpresas.Items(n).Cells(2).Controls(1), CheckBox)
                If RGridEmpresas.Items(n).Cells(5).Text <> "&nbsp;" Then
                    Check.Enabled = False
                End If
            Next

        Catch ex As Exception
            Lerror.Text = "No existe información para este reporte."
        End Try
    End Sub

    Protected Sub BVerReporte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BVerReporte.Click
        Dim sentencia As String
        Dim CveEmpresa As String
        Dim ds As DataSet

        'sentencia = "DELETE FROM TblPAEmpTemp WHERE USUARIO='" & Session("USUARIO") & "'"
        'DatosBD.ProcedimientoTXT(sentencia, "")

        Dim ds2 As New DataSet
        Dim P2(1) As SqlParameter
        P2(0) = New SqlParameter("@TIPO", 24)
        P2(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
        ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)


        For i As Integer = 0 To RGridEmpresas.Items.Count - 1
            Dim Check As New CheckBox
            Check = CType(RGridEmpresas.Items(i).Cells(2).Controls(1), CheckBox)
            If Check.Checked = True Then
                CveEmpresa = RGridEmpresas.Items(i).Cells(3).Text
                If Check.Checked = True Then
                    'sentencia = "INSERT INTO TblPAEmpTemp(USUARIO,CVEEMPRESA) " & _
                    '    "VALUES('" & Session("USUARIO") & "'," & CveEmpresa & ")"

                    Dim ds3 As New DataSet
                    Dim P3(2) As SqlParameter
                    P3(0) = New SqlParameter("@TIPO", 25)
                    P3(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
                    P3(2) = New SqlParameter("@CVEEMPRESA", CveEmpresa)
                    ds3 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P3, Lerror.Text)


                End If
                'DatosBD.ProcedimientoTXT(sentencia, "")
            End If
        Next
        modalPopup.VisibleOnPageLoad = False
        RadWindowManager1.Windows(0).NavigateUrl = "GraficaImpacto.aspx?R=R9&T=Filtro"
        RadWindowManager1.Windows(0).VisibleOnPageLoad = True
    End Sub

    Protected Sub BGuardarPA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BGuardarPA.Click
        Dim Valida As Boolean = False
        For N As Integer = 0 To RGridEmpresas.Items.Count - 1
            Dim Check As New CheckBox
            Check = CType(RGridEmpresas.Items(N).Cells(2).Controls(1), CheckBox)
            If Check.Checked = True Then
                Valida = True
            End If
        Next

        If RTPlan.Text.Trim <> "" And Valida = True Then
            Dim ds As DataSet
            Dim sentencia As String
            Dim CveEmpresa As String
            Dim CvePlan As String
            If BGuardarPA.Text = "Guardar" Then
                Dim p(2) As SqlParameter
                p(0) = New SqlParameter("@TIPO", 0)
                p(1) = New SqlParameter("@PLAN", RTPlan.Text.Trim)
                p(2) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PACreaPlan", p, Lerror.Text)
            Else
                Dim p(3) As SqlParameter
                p(0) = New SqlParameter("@CVEPLAN", LPA.Text)
                p(1) = New SqlParameter("@TIPO", 0)
                p(2) = New SqlParameter("@PLAN", RTPlan.Text.Trim)
                p(3) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PAActualizaPlan", p, Lerror.Text)
            End If

            CvePlan = ds.Tables(0).Rows(0).Item(0)

            'sentencia = "DELETE FROM TblPARelacionEmp WHERE CvePlan=" & CvePlan & " AND AnioEstudio=" & Session("AnioEstudio")
            'DatosBD.ProcedimientoTXT(sentencia, "")

            Dim ds2 As New DataSet
            Dim P2(2) As SqlParameter
            P2(0) = New SqlParameter("@TIPO", 26)
            P2(1) = New SqlParameter("@CVEPLAN", CvePlan)
            P2(2) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
            ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)


            For i As Integer = 0 To RGridEmpresas.Items.Count - 1
                Dim Check As New CheckBox
                Check = CType(RGridEmpresas.Items(i).Cells(2).Controls(1), CheckBox)
                If Check.Checked = True Then
                    CveEmpresa = RGridEmpresas.Items(i).Cells(3).Text
                    If Check.Checked = True Then
                        Dim p3(3) As SqlParameter
                        p3(0) = New SqlParameter("@TIPO", 2)
                        p3(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
                        p3(2) = New SqlParameter("@CVEEMPRESA", CveEmpresa)
                        p3(3) = New SqlParameter("@CVEPLAN", CvePlan)
                        ds = DatosBD.FuncionConPar("SP_PAAsignacion", p3, Lerror.Text)
                    End If
                End If
            Next

            LimpiarCampos()
            LlenarGrid(0, 0)
            LlenarAsignacion()
        Else
            Lerror.Text = "Favor de llenar todos los campos."
        End If
    End Sub

    Sub LlenarPlanO()
        RCBPlanO.Items.Clear()
        ' Dim CONSULTA As String
        'CONSULTA = "SELECT CVEPLAN, PLANACCION FROM TblPA WHERE Usuario=" & Session("USUARIO") & " AND ANIOESTUDIO=" & Session("AnioEstudio")
        'cargar.ComboSentenciaTxt(RCBPlanO, CONSULTA, "PLANACCION", "CVEPLAN", 2, False)

        Dim ds As New DataSet
        Dim P(2) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 27)
        P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
        P(2) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
        ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


        RCBPlanO.DataSource = ds.Tables(0)
        RCBPlanO.DataTextField = "PLANACCION"
        RCBPlanO.DataValueField = "CVEPLAN"
        RCBPlanO.DataBind()

        If RCBPlanO.Enabled = False Then
            GetEstructura(RCBPlanO.SelectedValue)
            LlenarGrid(RCBPlanO.SelectedValue, 1)
        End If
    End Sub

    Protected Sub RCBPlanO_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBPlanO.SelectedIndexChanged
        If RCBPlanO.SelectedValue <> -1 Then
            GetEstructura(RCBPlanO.SelectedValue)
            LlenarGrid(RCBPlanO.SelectedValue, 1)
        End If
    End Sub

    Protected Sub BGuardarO_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BGuardarO.Click
        If RTObjetivo.Text.Trim <> "" Then
            Dim ds As DataSet
            If BGuardarO.Text = "Guardar" Then
                Dim p(3) As SqlParameter
                p(0) = New SqlParameter("@CVEPLAN", RCBPlanO.SelectedValue)
                p(1) = New SqlParameter("@TIPO", 1)
                p(2) = New SqlParameter("@OBJETIVO", RTObjetivo.Text.Trim)
                p(3) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PACreaPlan", p, Lerror.Text)
            Else
                Dim p(4) As SqlParameter
                p(0) = New SqlParameter("@CVEPLAN", RCBPlanO.SelectedValue)
                p(1) = New SqlParameter("@TIPO", 1)
                p(2) = New SqlParameter("@CVEOBJETIVO", LO.Text)
                p(3) = New SqlParameter("@OBJETIVO", RTObjetivo.Text.Trim)
                p(4) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PAActualizaPlan", p, Lerror.Text)
            End If
            LimpiarCampos()
            LlenarGrid(RCBPlanO.SelectedValue, 1)
        Else
            Lerror.Text = "Favor de llenar todos los campos."
        End If
    End Sub

    Sub LlenarPlanI()
        RCBPlanI.Items.Clear()
        'Dim CONSULTA As String
        'CONSULTA = "SELECT CVEPLAN, PLANACCION FROM TblPA WHERE Usuario=" & Session("USUARIO") & " AND ANIOESTUDIO=" & Session("AnioEstudio")
        'Cargar.ComboSentenciaTxt(RCBPlanI, CONSULTA, "PLANACCION", "CVEPLAN", 2, False)

        Dim ds As New DataSet
        Dim P(2) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 27)
        P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
        P(2) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
        ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


        RCBPlanI.DataSource = ds.Tables(0)
        RCBPlanI.DataTextField = "PLANACCION"
        RCBPlanI.DataValueField = "CVEPLAN"
        RCBPlanI.DataBind()

        If RCBPlanI.Enabled = False Then
            GetEstructura(RCBPlanI.SelectedValue)
            LlenarObjetivosI()
            LlenarGrid(RCBPlanI.SelectedValue, 2)
        End If
    End Sub

    Sub LlenarObjetivosI()
        RCBObjetivoI.Items.Clear()
        ' Dim CONSULTA As String
        'CONSULTA = "SELECT CVEOBJETIVO, OBJETIVO FROM TblPAObjetivo WHERE CVEPLAN=" & RCBPlanI.SelectedValue & " AND ANIOESTUDIO=" & Session("AnioEstudio")
        'Cargar.ComboSentenciaTxt(RCBObjetivoI, CONSULTA, "OBJETIVO", "CVEOBJETIVO", 2, False)

        Dim ds As New DataSet
        Dim P(2) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 28)
        P(1) = New SqlParameter("@CVEPLAN", RCBPlanI.SelectedValue)
        P(2) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
        ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


        RCBObjetivoI.DataSource = ds.Tables(0)
        RCBObjetivoI.DataTextField = "OBJETIVO"
        RCBObjetivoI.DataValueField = "CVEOBJETIVO"
        RCBObjetivoI.DataBind()

        If RCBObjetivoI.Enabled = False Then
            'LlenarIniciativas()
        End If
    End Sub

    Protected Sub RCBPlanI_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBPlanI.SelectedIndexChanged
        If RCBPlanI.SelectedValue <> -1 Then
            GetEstructura(RCBPlanI.SelectedValue)
            LlenarObjetivosI()
            LlenarGrid(RCBPlanI.SelectedValue, 2)
        End If
    End Sub

    Protected Sub BGuardarI_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BGuardarI.Click
        If RTIniciativa.Text.Trim <> "" And RCBIndicador.SelectedValue <> "-1" And RTFuente.Text.Trim <> "" And RTProductoFinal.Text.Trim <> "" And RTResponsable.Text.Trim <> "" And RDPFI.SelectedDate >= "1980/01/01" And RDPFF.SelectedDate >= "1980/01/01" And RCBNombre.SelectedValue <> "-1" And RTCorreo.Text.Trim <> "" And RTPuesto.Text.Trim <> "" Then
            If RDPFI.SelectedDate >= RDPFF.SelectedDate Then
                Lerror.Text = "La fecha de inicio no puede ser mayor a la fecha de fin."
                Exit Sub
            End If

            Dim ds As DataSet
            If BGuardarI.Text = "Guardar" Then
                Dim p(10) As SqlParameter
                p(0) = New SqlParameter("@CVEPLAN", RCBPlanI.SelectedValue)
                p(1) = New SqlParameter("@TIPO", 2)
                p(2) = New SqlParameter("@CVEOBJETIVO", RCBObjetivoI.SelectedValue)
                p(3) = New SqlParameter("@INICIATIVA", RTIniciativa.Text.Trim)
                p(4) = New SqlParameter("@INDICADOR", RCBIndicador.Text)
                p(5) = New SqlParameter("@FUENTEINDICADOR", RTFuente.Text.Trim)
                p(6) = New SqlParameter("@RESPONSABLE", RTResponsable.Text.Trim)
                p(7) = New SqlParameter("@PRODUCTOFINAL", RTProductoFinal.Text.Trim)
                p(8) = New SqlParameter("@FECHAINICIO", RDPFI.SelectedDate)
                p(9) = New SqlParameter("@FECHAFIN", RDPFF.SelectedDate)
                p(10) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PACreaPlan", p, Lerror.Text)

                LI.Text = ds.Tables(0).Rows(0).Item(0)

                Dim p2(8) As SqlParameter
                p2(0) = New SqlParameter("@TIPO", 1)
                p2(1) = New SqlParameter("@CVEPLAN", RCBPlanI.SelectedValue)
                p2(2) = New SqlParameter("@CVEINICIATIVA", LI.Text)
                p2(3) = New SqlParameter("@NUMEVALUADOR", RCBNombre.SelectedValue)
                p2(4) = New SqlParameter("@EVALUADOR", RCBNombre.Text)
                p2(5) = New SqlParameter("@CORREOEVALUADOR", RTCorreo.Text.Trim)
                p2(6) = New SqlParameter("@PUESTOEVALUADOR", RTPuesto.Text.Trim)
                p2(7) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
                p2(8) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PAEvaluaPlan", p2, Lerror.Text)
                Lerror.Text = "Se envió un correo al Evaluador para su validación."

                'Envio correo a Evaluador
                Dim NombrePlan As String
                'NombrePlan = DatosBD.FuncionTXT("SELECT PlanAccion FROM TBLPA WHERE CVEPLAN=" & RCBPlanI.SelectedValue & " ", Lerror.Text).Tables(0).Rows(0).Item(0)

                Dim ds1 As New DataSet
                Dim P1(1) As SqlParameter
                P1(0) = New SqlParameter("@TIPO", 29)
                P1(1) = New SqlParameter("@CVEPLAN", RCBPlanI.SelectedValue)
                ds1 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P1, Lerror.Text)

                NombrePlan = ds1.Tables(0).Rows(0).Item(0)


                Ruta = "\\femmsiliis1.csc.fmx\RespaldoCO\Correos\BITACORAS\" & "(" & RCBPlanI.SelectedValue & ")PlanAccion" & CStr(Now.Date.Year).ToString & CStr(Now.Date.Month).ToString & CStr(Now.Date.Day).ToString & CStr(Now.Hour) & CStr(Now.Minute) & ".txt"
                Escribe = New StreamWriter(Ruta)
                Escribe.WriteLine("CVEEMPRESA|USUARIO|CORREO|ESTATUS|HORA:" & Now.ToLongDateString & "  " & Now.ToLongTimeString)

                'EnviarMail("1568066", "jorgea.lopez@femsa.com.mx", RCBPlanI.SelectedValue, NombrePlan, RCBObjetivoI.SelectedValue, LI.Text)
                EnviarMail("1568066", RTCorreo.Text.Trim, RCBPlanI.SelectedValue, NombrePlan, RCBObjetivoI.SelectedValue, LI.Text)

                Escribe.WriteLine("CVEEMPRESA|USUARIO|CORREO|ESTATUS|HORA:" & Now.ToLongDateString & "  " & Now.ToLongTimeString)
                Escribe.Close()
                Shell("notepad.exe '" & Ruta & "'", vbNormalFocus)
                Lerror.Text = "Se envió un correo al Evaluador para su validación."

                RadWindowManager1.Windows(1).NavigateUrl = "PAPreguntas.ASPX?P=" & RCBPlanI.SelectedValue & "&Ini=" & LI.Text & ""
                RadWindowManager1.Windows(1).VisibleOnPageLoad = True
            Else
                Dim p(11) As SqlParameter
                p(0) = New SqlParameter("@CVEPLAN", RCBPlanI.SelectedValue)
                p(1) = New SqlParameter("@TIPO", 2)
                p(2) = New SqlParameter("@CVEOBJETIVO", RCBObjetivoI.SelectedValue)
                p(3) = New SqlParameter("@CVEINICIATIVA", LI.Text)
                p(4) = New SqlParameter("@INICIATIVA", RTIniciativa.Text.Trim)
                p(5) = New SqlParameter("@INDICADOR", RCBIndicador.Text)
                p(6) = New SqlParameter("@FUENTEINDICADOR", RTFuente.Text.Trim)
                p(7) = New SqlParameter("@RESPONSABLE", RTResponsable.Text.Trim)
                p(8) = New SqlParameter("@PRODUCTOFINAL", RTProductoFinal.Text.Trim)
                p(9) = New SqlParameter("@FECHAINICIO", RDPFI.SelectedDate)
                p(10) = New SqlParameter("@FECHAFIN", RDPFF.SelectedDate)
                p(11) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PAActualizaPlan", p, Lerror.Text)

                Dim p2(8) As SqlParameter
                p2(0) = New SqlParameter("@TIPO", 2)
                p2(1) = New SqlParameter("@CVEPLAN", RCBPlanI.SelectedValue)
                p2(2) = New SqlParameter("@CVEINICIATIVA", LI.Text)
                p2(3) = New SqlParameter("@NUMEVALUADOR", RCBNombre.SelectedValue)
                p2(4) = New SqlParameter("@EVALUADOR", RCBNombre.Text)
                p2(5) = New SqlParameter("@CORREOEVALUADOR", RTCorreo.Text.Trim)
                p2(6) = New SqlParameter("@PUESTOEVALUADOR", RTPuesto.Text.Trim)
                p2(7) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
                p2(8) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PAEvaluaPlan", p2, Lerror.Text)
                Lerror.Text = "Se actualizó el registro con éxito."
            End If
            BGuardarI.Text = "Guardar"
            LimpiarCampos()
            LlenarGrid(RCBPlanI.SelectedValue, 2)
        Else
            Lerror.Text = "Favor de llenar todos los campos."
        End If
    End Sub

    Sub LlenarPlanA()
        RCBPlanA.Items.Clear()
        'Dim CONSULTA As String
        'CONSULTA = "SELECT CVEPLAN, PLANACCION FROM TblPA WHERE Usuario=" & Session("USUARIO") & " AND ANIOESTUDIO=" & Session("AnioEstudio")
        'Cargar.ComboSentenciaTxt(RCBPlanA, CONSULTA, "PLANACCION", "CVEPLAN", 2, False)

        Dim ds As New DataSet
        Dim P(2) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 27)
        P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
        P(2) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
        ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


        RCBPlanA.DataSource = ds.Tables(0)
        RCBPlanA.DataTextField = "PLANACCION"
        RCBPlanA.DataValueField = "CVEPLAN"
        RCBPlanA.DataBind()

        If RCBPlanA.Enabled = False Then
            GetEstructura(RCBPlanA.SelectedValue)
            LlenarObjetivosA()
            LlenarGrid(RCBPlanA.SelectedValue, 3)
        End If
    End Sub

    Sub LlenarObjetivosA()
        RCBObjetivoI.Items.Clear()
        'Dim CONSULTA As String
        'CONSULTA = "SELECT CVEOBJETIVO, OBJETIVO FROM TblPAObjetivo WHERE CVEPLAN=" & RCBPlanA.SelectedValue & " AND ANIOESTUDIO=" & Session("AnioEstudio")
        'Cargar.ComboSentenciaTxt(RCBObjetivoA, CONSULTA, "OBJETIVO", "CVEOBJETIVO", 2, False)

        Dim ds As New DataSet
        Dim P(2) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 30)
        P(1) = New SqlParameter("@CVEPLAN", RCBPlanA.SelectedValue)
        P(2) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
        ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


        RCBObjetivoA.DataSource = ds.Tables(0)
        RCBObjetivoA.DataTextField = "OBJETIVO"
        RCBObjetivoA.DataValueField = "CVEOBJETIVO"
        RCBObjetivoA.DataBind()


        If RCBObjetivoA.Enabled = False Then
            LlenarIniciativasA()
        End If
    End Sub

    Protected Sub RCBPlanA_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBPlanA.SelectedIndexChanged
        If RCBPlanA.SelectedValue <> -1 Then
            GetEstructura(RCBPlanA.SelectedValue)
            LlenarObjetivosA()
            LlenarGrid(RCBPlanA.SelectedValue, 3)
        End If
    End Sub

    Protected Sub RCBObjetivoA_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBObjetivoA.SelectedIndexChanged
        LlenarIniciativasA()
    End Sub

    Sub LlenarIniciativasA()
        RCBIniciativaA.Items.Clear()
        'Dim CONSULTA As String
        'CONSULTA = "SELECT CVEINICIATIVA, INICIATIVA FROM TblPAIniciativa WHERE CVEPLAN=" & RCBPlanA.SelectedValue & " AND CVEOBJETIVO=" & RCBObjetivoA.SelectedValue & " AND ANIOESTUDIO=" & Session("AnioEstudio")
        'Cargar.ComboSentenciaTxt(RCBIniciativaA, CONSULTA, "INICIATIVA", "CVEINICIATIVA", 2, False)

        Dim ds As New DataSet
        Dim P(3) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 31)
        P(1) = New SqlParameter("@CVEPLAN", RCBPlanA.SelectedValue)
        P(2) = New SqlParameter("@CVEOBJETIVO", RCBObjetivoA.SelectedValue)
        P(3) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
        ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


        RCBIniciativaA.DataSource = ds.Tables(0)
        RCBIniciativaA.DataTextField = "INICIATIVA"
        RCBIniciativaA.DataValueField = "CVEINICIATIVA"
        RCBIniciativaA.DataBind()

    End Sub

    Protected Sub BGuardarA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BGuardarA.Click
        If RCBIniciativaA.SelectedValue <> "-1" And RTAccion.Text.Trim <> "" Then
            Dim ds As DataSet
            If BGuardarA.Text = "Guardar" Then
                Dim p(4) As SqlParameter
                p(0) = New SqlParameter("@CVEPLAN", RCBPlanA.SelectedValue)
                p(1) = New SqlParameter("@TIPO", 3)
                p(2) = New SqlParameter("@CVEINICIATIVA", RCBIniciativaA.SelectedValue)
                p(3) = New SqlParameter("@ACCION", RTAccion.Text.Trim)
                p(4) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PACreaPlan", p, Lerror.Text)
            Else
                Dim p(5) As SqlParameter
                p(0) = New SqlParameter("@CVEPLAN", RCBPlanA.SelectedValue)
                p(1) = New SqlParameter("@TIPO", 3)
                p(2) = New SqlParameter("@CVEINICIATIVA", RCBIniciativaA.SelectedValue)
                p(3) = New SqlParameter("@CVEACCION", LA.Text)
                p(4) = New SqlParameter("@ACCION", RTAccion.Text.Trim)
                p(5) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PAActualizaPlan", p, Lerror.Text)
            End If
            BGuardarO.Text = "Guardar"
            LimpiarCampos()
            LlenarGrid(RCBPlanA.SelectedValue, 3)
        Else
            Lerror.Text = "Favor de llenar todos los campos."
        End If
    End Sub

    Sub LlenarGrid(ByVal CvePlan As Integer, ByVal Tipo As Integer)
        Dim ds As DataSet
        Dim p(2) As SqlParameter
        p(0) = New SqlParameter("@CVEPLAN", CvePlan)
        p(1) = New SqlParameter("@TIPO", Tipo)
        p(2) = New SqlParameter("@USUARIO", Session("USUARIO"))
        ds = DatosBD.FuncionConPar("SP_PAConsultaPlan", p, Lerror.Text)

        RadGrid1.DataSource = ds.Tables(0)
        RadGrid1.DataBind()

        For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
            Dim colDecimal As GridBoundColumn
            colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
            colDecimal.HeaderStyle.Font.Bold = True
            colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left

            If Panel0.Visible = True Then 'Plan
                If cont = 0 Then '
                    colDecimal.HeaderStyle.Width = 50
                    colDecimal.ItemStyle.Width = 50
                ElseIf cont = 1 Then '
                    colDecimal.HeaderStyle.Width = 600
                    colDecimal.ItemStyle.Width = 600
                End If
            ElseIf Panel1.Visible = True Then 'Objetivo
                If cont = 0 Then '
                    colDecimal.Display = False
                ElseIf cont = 1 Then '
                    colDecimal.HeaderStyle.Width = 50
                ElseIf cont = 2 Then '
                    colDecimal.HeaderStyle.Width = 600
                End If
            ElseIf Panel2.Visible = True Then 'Iniciativa
                If cont = 0 Then '
                    colDecimal.Display = False
                ElseIf cont = 1 Then '
                    colDecimal.HeaderStyle.Width = 50
                ElseIf cont = 2 Then '
                    colDecimal.HeaderStyle.Width = 150
                ElseIf cont = 3 Then '
                    colDecimal.HeaderStyle.Width = 50
                ElseIf cont = 4 Then '
                    colDecimal.HeaderStyle.Width = 150
                ElseIf cont = 5 Then '
                    colDecimal.HeaderStyle.Width = 100
                ElseIf cont = 6 Then '
                    colDecimal.HeaderStyle.Width = 100
                ElseIf cont = 7 Then '
                    colDecimal.HeaderStyle.Width = 100
                ElseIf cont = 8 Then '
                    colDecimal.HeaderStyle.Width = 100
                ElseIf cont = 9 Then '
                    colDecimal.HeaderStyle.Width = 100
                ElseIf cont = 10 Then '
                    colDecimal.HeaderStyle.Width = 100
                End If
            ElseIf Panel3.Visible = True Then 'Accion
                If cont = 0 Then '
                    colDecimal.Display = False
                ElseIf cont = 1 Then '
                    colDecimal.HeaderStyle.Width = 50
                ElseIf cont = 2 Then '
                    colDecimal.HeaderStyle.Width = 200
                ElseIf cont = 3 Then '
                    colDecimal.HeaderStyle.Width = 50
                ElseIf cont = 4 Then '
                    colDecimal.HeaderStyle.Width = 200
                ElseIf cont = 5 Then '
                    colDecimal.HeaderStyle.Width = 100
                ElseIf cont = 6 Then '
                    colDecimal.HeaderStyle.Width = 400
                End If
            End If
        Next
        If Panel2.Visible = True Then 'Oculta/Muestra columna de preguntas
            RadGrid1.MasterTableView.Columns(2).Visible = True
            'RadGrid1.MasterTableView.AutoGeneratedColumns(0).Visible = False
        Else
            RadGrid1.MasterTableView.Columns(2).Visible = False
            'RadGrid1.MasterTableView.AutoGeneratedColumns(0).Visible = True
        End If

        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "Editar" Then
            Dim sentencia As String
            Dim DS As DataSet
            If Panel0.Visible = True Then
                ''sentencia = "SELECT * FROM TBLPA WHERE CvePlan=" & e.Item.Cells(5).Text & " AND ANIOESTUDIO=" & Session("AnioEstudio")
                'DS = DatosBD.FuncionTXT(sentencia, Lerror.Text)

                Dim P(2) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 32)
                P(1) = New SqlParameter("@CVEPLAN", e.Item.Cells(5).Text)
                P(2) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
                DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)



                RTPlan.Text = DS.Tables(0).Rows(0).Item("PlanAccion")
                LPA.Text = DS.Tables(0).Rows(0).Item("CvePlan")

                'sentencia = "SELECT CveEmpresa FROM TblPARelacionEmp WHERE CvePlan=" & e.Item.Cells(5).Text & " AND ANIOESTUDIO=" & Session("AnioEstudio")

                Dim P1(2) As SqlParameter
                P1(0) = New SqlParameter("@TIPO", 33)
                P1(1) = New SqlParameter("@CVEPLAN", e.Item.Cells(5).Text)
                P1(2) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
                DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P1, Lerror.Text)

                'DS = DatosBD.FuncionTXT(sentencia, Lerror.Text)
                For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                    For n As Integer = 0 To RGridEmpresas.Items.Count - 1
                        Dim Check As New CheckBox
                        Check = CType(RGridEmpresas.Items(n).Cells(2).Controls(1), CheckBox)
                        If RGridEmpresas.Items(n).Cells(3).Text = DS.Tables(0).Rows(i).Item(0) Then
                            Check.Checked = True
                        End If
                    Next
                Next
                BGuardarPA.Text = "Actualizar"
            ElseIf Panel1.Visible = True Then
                ' sentencia = "SELECT * FROM TBLPAOBJETIVO WHERE CvePlan=" & e.Item.Cells(5).Text & " AND CveObjetivo=" & e.Item.Cells(6).Text & " AND ANIOESTUDIO=" & Session("AnioEstudio")

                Dim P2(3) As SqlParameter
                P2(0) = New SqlParameter("@TIPO", 34)
                P2(1) = New SqlParameter("@CVEPLAN", e.Item.Cells(5).Text)
                P2(2) = New SqlParameter("@CVEOBJETIVO", e.Item.Cells(6).Text)
                P2(3) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
                DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)

                ' DS = DatosBD.FuncionTXT(sentencia, Lerror.Text)
                RTObjetivo.Text = DS.Tables(0).Rows(0).Item("Objetivo")
                LO.Text = DS.Tables(0).Rows(0).Item("CveObjetivo")
                BGuardarO.Text = "Actualizar"
            ElseIf Panel2.Visible = True Then
                ' sentencia = "SELECT * FROM TBLPAINICIATIVA WHERE CvePlan=" & e.Item.Cells(5).Text & " AND CveIniciativa=" & e.Item.Cells(8).Text & " AND ANIOESTUDIO=" & Session("AnioEstudio")
                ' DS = DatosBD.FuncionTXT(sentencia, Lerror.Text)

                Dim P3(3) As SqlParameter
                P3(0) = New SqlParameter("@TIPO", 35)
                P3(1) = New SqlParameter("@CVEPLAN", e.Item.Cells(5).Text)
                P3(2) = New SqlParameter("@CVEINICIATIVA", e.Item.Cells(8).Text)
                P3(3) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
                DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P3, Lerror.Text)


                RCBObjetivoI.SelectedValue = DS.Tables(0).Rows(0).Item("CveObjetivo")
                LI.Text = DS.Tables(0).Rows(0).Item("CveIniciativa")
                RTIniciativa.Text = DS.Tables(0).Rows(0).Item("Iniciativa")
                RCBIndicador.SelectedValue = DS.Tables(0).Rows(0).Item("Indicador")
                RTFuente.Text = DS.Tables(0).Rows(0).Item("FuenteIndicador")
                RTProductoFinal.Text = DS.Tables(0).Rows(0).Item("ProductoFinal")
                RTResponsable.Text = DS.Tables(0).Rows(0).Item("Responsable")
                RDPFI.SelectedDate = DS.Tables(0).Rows(0).Item("FechaInicio")
                RDPFF.SelectedDate = DS.Tables(0).Rows(0).Item("FechaFin")

                ' sentencia = "SELECT * FROM TBLPAEVALUACION WHERE CvePlan=" & e.Item.Cells(5).Text & " AND CveIniciativa=" & e.Item.Cells(8).Text & " AND ANIOESTUDIO=" & Session("AnioEstudio")
                ' DS = DatosBD.FuncionTXT(sentencia, Lerror.Text)



                Dim P4(3) As SqlParameter
                P4(0) = New SqlParameter("@TIPO", 36)
                P4(1) = New SqlParameter("@CVEPLAN", e.Item.Cells(5).Text)
                P4(2) = New SqlParameter("@CVEINICIATIVA", e.Item.Cells(8).Text)
                P4(3) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
                DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P4, Lerror.Text)

                If DS.Tables(0).Rows.Count > 0 Then
                    RCBNombre.SelectedValue = DS.Tables(0).Rows(0).Item("NumEvaluador")
                    RCBNombre.Text = DS.Tables(0).Rows(0).Item("Evaluador")
                    RTCorreo.Text = DS.Tables(0).Rows(0).Item("CorreoEvaluador")
                    RTPuesto.Text = DS.Tables(0).Rows(0).Item("PuestoEvaluador")
                End If
                LlenarGrid(RCBPlanI.SelectedValue, 2)
                BGuardarI.Text = "Actualizar"
            ElseIf Panel3.Visible = True Then
                ' sentencia = "SELECT CVEOBJETIVO FROM TBLPAINICIATIVA WHERE CvePlan=" & e.Item.Cells(5).Text & " AND CVEINICIATIVA=" & e.Item.Cells(6).Text & " AND ANIOESTUDIO=" & Session("AnioEstudio")
                ' DS = DatosBD.FuncionTXT(sentencia, Lerror.Text)

                Dim P5(3) As SqlParameter
                P5(0) = New SqlParameter("@TIPO", 37)
                P5(1) = New SqlParameter("@CVEPLAN", e.Item.Cells(5).Text)
                P5(2) = New SqlParameter("@CVEINICIATIVA", e.Item.Cells(6).Text)
                P5(3) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
                DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P5, Lerror.Text)

                RCBObjetivoA.SelectedValue = DS.Tables(0).Rows(0).Item(0)
                LlenarIniciativasA()

                ' sentencia = "SELECT * FROM TBLPAACCION WHERE CvePlan=" & e.Item.Cells(5).Text & " AND CveIniciativa=" & e.Item.Cells(6).Text & " AND CveAccion=" & e.Item.Cells(8).Text & " AND ANIOESTUDIO=" & Session("AnioEstudio")
                ' DS = DatosBD.FuncionTXT(sentencia, Lerror.Text)


                Dim P6(3) As SqlParameter
                P6(0) = New SqlParameter("@TIPO", 38)
                P6(1) = New SqlParameter("@CVEPLAN", e.Item.Cells(5).Text)
                P6(2) = New SqlParameter("@CVEINICIATIVA", e.Item.Cells(6).Text)
                P6(2) = New SqlParameter("@CVEACCION", e.Item.Cells(8).Text)
                P6(3) = New SqlParameter("@ANIOESTUDIO", Session("AnioEstudio"))
                DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P6, Lerror.Text)

                RCBIniciativaA.SelectedValue = DS.Tables(0).Rows(0).Item("CveIniciativa")
                LA.Text = DS.Tables(0).Rows(0).Item("CveAccion")
                RTAccion.Text = DS.Tables(0).Rows(0).Item("Accion")
                'LlenarGrid(RCBPlanA.SelectedValue, 3)
                BGuardarA.Text = "Actualizar"
            End If
        ElseIf e.CommandName = "Borrar" Then
            Dim ds As DataSet
            If Panel0.Visible = True Then
                Dim p(2) As SqlParameter
                p(0) = New SqlParameter("@CVEPLAN", e.Item.Cells(5).Text)
                p(1) = New SqlParameter("@TIPO", 0)
                p(2) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PABorraPlan", p, Lerror.Text)
                LlenarGrid(0, 0)
                LlenarAsignacion()
                BGuardarPA.Text = "Guardar"
            ElseIf Panel1.Visible = True Then
                Dim p(3) As SqlParameter
                p(0) = New SqlParameter("@CVEPLAN", e.Item.Cells(5).Text)
                p(1) = New SqlParameter("@TIPO", 1)
                p(2) = New SqlParameter("@CVEOBJETIVO", e.Item.Cells(6).Text)
                p(3) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PABorraPlan", p, Lerror.Text)
                LlenarGrid(RCBPlanO.SelectedValue, 1)
                BGuardarO.Text = "Guardar"
            ElseIf Panel2.Visible = True Then
                Dim p(4) As SqlParameter
                p(0) = New SqlParameter("@CVEPLAN", e.Item.Cells(5).Text)
                p(1) = New SqlParameter("@TIPO", 2)
                p(2) = New SqlParameter("@CVEOBJETIVO", e.Item.Cells(6).Text)
                p(3) = New SqlParameter("@CVEINICIATIVA", e.Item.Cells(8).Text)
                p(4) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PABorraPlan", p, Lerror.Text)
                LlenarGrid(RCBPlanI.SelectedValue, 2)
                BGuardarI.Text = "Guardar"
            ElseIf Panel3.Visible = True Then
                Dim p(5) As SqlParameter
                p(0) = New SqlParameter("@CVEPLAN", e.Item.Cells(5).Text)
                p(1) = New SqlParameter("@TIPO", 3)
                p(2) = New SqlParameter("@CVEOBJETIVO", RCBObjetivoI.SelectedValue)
                p(3) = New SqlParameter("@CVEINICIATIVA", e.Item.Cells(6).Text)
                p(4) = New SqlParameter("@CVEACCION", e.Item.Cells(8).Text)
                p(5) = New SqlParameter("@USUARIO", Session("USUARIO"))
                ds = DatosBD.FuncionConPar("SP_PABorraPlan", p, Lerror.Text)
                LlenarGrid(RCBPlanA.SelectedValue, 3)
                BGuardarA.Text = "Guardar"
            End If
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem OrElse e.Item.ItemType = GridItemType.Item Then
            If Panel2.Visible = True Then
                'Reemplazamos la coma por punto (Pt)
                e.Item.Cells(8).Text = e.Item.Cells(8).Text.Replace(",", ".")

                Dim Hlink As New LinkButton
                Hlink.Text = "Preguntas"
                Hlink.Attributes.Add("OnClick", "window.radopen('PAPreguntas.ASPX?P=" & RCBPlanI.SelectedValue & "&Ini=" & e.Item.Cells(8).Text & "','UserListDialog');return false;")
                Hlink.Dispose()
                e.Item.Cells(4).Controls.Add(Hlink)
            End If
        End If
    End Sub

    Sub LimpiarCampos()
        RTPlan.Text = ""
        'RCBObjetivo.SelectedValue = -1
        RTObjetivo.Text = ""
        'RCBIniciativa.SelectedValue = -1
        RTIniciativa.Text = ""
        RTFuente.Text = ""
        RTProductoFinal.Text = ""
        RDPFI.Clear()
        RDPFF.Clear()
        RTResponsable.Text = ""
        RCBNombre.SelectedIndex = -1
        RTCorreo.Text = ""
        RTPuesto.Text = ""
        RTAccion.Text = ""
        RTAccion.Enabled = True
        'Lerror.Text = ""
    End Sub

    Sub CargarDivision()
        Dim PLoad(1) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 0)
        PLoad(1) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBUnidad, "[Sp_CargaEstructura]", PLoad, "NOMDIVISION", "CVEDIVISION", 1, True, Session("Lenguaje"))

        If RCBUnidad.Enabled = False Then
            CargarAgrupadoPaises()
            'LlenarGrid()
        End If
    End Sub

    Protected Sub RCBUnidad_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBUnidad.SelectedIndexChanged
        Label6.Visible = False
        RadioButtonList1.Visible = False
        Session("TipoEmpleado") = "Empleado"

        If RCBUnidad.SelectedValue = -1 Then
            Server.Transfer("BusquedaGeneral.aspx")
        Else
            RCBAgrupadoPaises.Items.Clear()
            RCBPais.Items.Clear()
            RCBTerritorio.Items.Clear()
            RCBRegion.Items.Clear()
            RCBSubRegion.Items.Clear()
            RCBAgrupadoPaises.Text = ""
            RCBPais.Text = ""
            RCBTerritorio.Text = ""
            RCBRegion.Text = ""
            RCBSubRegion.Text = ""

            RCBAgrupadoPaises.Enabled = False
            RCBPais.Enabled = False
            RCBTerritorio.Enabled = False
            RCBRegion.Enabled = False
            RCBSubRegion.Enabled = False

            CargarAgrupadoPaises()
            'LlenarGrid()
        End If
    End Sub

    Protected Sub RcboTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim RCboTop As RadComboBox = DirectCast(sender, RadComboBox)
        Session("SesTipoOperacion") = RCboTop.SelectedValue
        Session("SesNomTipoOperacion") = RCboTop.Text
        LlenarVisualizacion()
    End Sub

    Sub CargarAgrupadoPaises()
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 1)
        PLoad(1) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBAgrupadoPaises, "[Sp_CargaEstructura]", PLoad, "NOMAGRUPADO", "CVEAGRUPADO", 1, True, Session("Lenguaje"))

        If RCBAgrupadoPaises.Items.Count = 2 Then 'Solo hay un Agrupado Paises
            CargarPaises()
        End If
    End Sub

    Protected Sub RCBAgrupadoPaises_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBAgrupadoPaises.SelectedIndexChanged
        Label6.Visible = False
        RadioButtonList1.Visible = False
        Session("TipoEmpleado") = "Empleado"

        RCBPais.Items.Clear()
        RCBTerritorio.Items.Clear()
        RCBRegion.Items.Clear()
        RCBSubRegion.Items.Clear()
        RCBPais.Text = ""
        RCBTerritorio.Text = ""
        RCBRegion.Text = ""
        RCBSubRegion.Text = ""

        RCBPais.Enabled = False
        RCBTerritorio.Enabled = False
        RCBRegion.Enabled = False
        RCBSubRegion.Enabled = False

        CargarPaises()
        'LlenarGrid()
    End Sub

    Sub CargarPaises()
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 2)
        PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", RCBAgrupadoPaises.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBPais, "[Sp_CargaEstructura]", PLoad, "PAIS", "CVEPAIS", 1, True, Session("Lenguaje"))

        If RCBPais.Items.Count = 2 Then
            CargarTerritorios()
        End If
    End Sub

    Protected Sub RCBPais_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBPais.SelectedIndexChanged
        Label6.Visible = False
        RadioButtonList1.Visible = False
        Session("TipoEmpleado") = "Empleado"

        RCBTerritorio.Items.Clear()
        RCBRegion.Items.Clear()
        RCBSubRegion.Items.Clear()
        RCBTerritorio.Text = ""
        RCBRegion.Text = ""
        RCBSubRegion.Text = ""

        RCBTerritorio.Enabled = False
        RCBRegion.Enabled = False
        RCBSubRegion.Enabled = False

        CargarTerritorios()
        'LlenarGrid()
    End Sub

    Sub CargarTerritorios()
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 3)
        PLoad(1) = New SqlParameter("@CVEPAIS", RCBPais.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBTerritorio, "[Sp_CargaEstructura]", PLoad, "TERRITORIO", "CVETERRITORIO", 1, True, Session("Lenguaje"))

        If RCBTerritorio.Enabled = False Then
            CargarRegiones()
        End If

        If RCBUnidad.SelectedValue = 6 Then
            RadioButtonList1.Items(1).Text = "Líder"
            Label6.Visible = False
            RadioButtonList1.Visible = True
            Session("TipoEmpleado") = "Empleado"
        ElseIf (RCBUnidad.SelectedValue = 2 And RCBPais.SelectedValue = 11) Or RCBUnidad.SelectedValue = 13 Then 'Filipinas / Grafo
            RadioButtonList1.Items(1).Text = "Otros"
            RadioButtonList1.SelectedValue = 2
            Label6.Visible = False
            RadioButtonList1.Visible = False
            Session("TipoEmpleado") = "Lider"
        Else
            RadioButtonList1.SelectedValue = 1
            Label6.Visible = False
            RadioButtonList1.Visible = False
            Session("TipoEmpleado") = "Empleado"
        End If
    End Sub

    Protected Sub RCBTerritorio_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RCBTerritorio.SelectedIndexChanged
        RCBRegion.Items.Clear()
        RCBSubRegion.Items.Clear()
        RCBRegion.Text = ""
        RCBSubRegion.Text = ""

        RCBRegion.Enabled = False
        RCBSubRegion.Enabled = False

        CargarRegiones()
        'LlenarGrid()
    End Sub

    Sub CargarRegiones()
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 4)
        PLoad(1) = New SqlParameter("@CVETERRITORIO", RCBTerritorio.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBRegion, "[Sp_CargaEstructura]", PLoad, "NOMREGION", "CVEREGION", 1, True, Session("Lenguaje"))

        If RCBRegion.Enabled = False Then
            CargarSubRegiones()
        End If

        If RCBUnidad.SelectedValue = 6 Then
            RadioButtonList1.Items(1).Text = "Líder"
            Label6.Visible = False
            RadioButtonList1.Visible = True
            Session("TipoEmpleado") = "Empleado"
        ElseIf (RCBUnidad.SelectedValue = 2 And RCBPais.SelectedValue = 11) Or RCBUnidad.SelectedValue = 13 Then 'Filipinas / Grafo
            RadioButtonList1.Items(1).Text = "Otros"
            RadioButtonList1.SelectedValue = 2
            Label6.Visible = False
            RadioButtonList1.Visible = False
            Session("TipoEmpleado") = "Lider"
        Else
            RadioButtonList1.SelectedValue = 1
            Label6.Visible = False
            RadioButtonList1.Visible = False
            Session("TipoEmpleado") = "Empleado"
        End If
    End Sub

    Protected Sub RCBRegion_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBRegion.SelectedIndexChanged
        RCBSubRegion.Items.Clear()
        RCBSubRegion.Text = ""
        RCBSubRegion.Enabled = False

        CargarSubRegiones()
        'LlenarGrid()
    End Sub

    Sub CargarSubRegiones()
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 5)
        PLoad(1) = New SqlParameter("@CVEREGION", RCBRegion.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        Cargar.ComboParametros(RCBSubRegion, "[Sp_CargaEstructura]", PLoad, "NOMSUBREGION", "CVESUBREGION", 1, True, Session("Lenguaje"))
    End Sub

    Protected Sub RCBSubRegion_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBSubRegion.SelectedIndexChanged
        'LlenarGrid()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedIndex = 0 Then 'RadioButtonList1.Items(0).Selected = True Then
            'Empleados
            Session("TipoEmpleado") = "Empleado"
        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            'Lider
            Session("TipoEmpleado") = "Lider"
        End If
    End Sub

    Sub LlenarRelacionPreguntas(CvePlan As Integer)
        Try
            Dim ds2 As New DataSet
            Dim P(2) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 3)
            P(1) = New SqlParameter("@CVEPLAN", CvePlan)
            P(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            ds2 = DatosBD.FuncionConPar("sp_EngCorrelacion", P, "")

            Dim TBLREPORTE As DataTable = ds2.Tables(2)
            RGridPreguntas.MasterTableView.GroupByExpressions.Clear()
            RGridPreguntas.DataSource = TBLREPORTE
            RGridPreguntas.DataBind()

            RGridPreguntas.Visible = True
        Catch ex As Exception
            Lerror.Text = "No existe información para este reporte."
        End Try
    End Sub

    Private Sub RGridPreguntas_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RGridPreguntas.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            e.Item.Cells(6).BackColor = GETCOLOR3(e.Item.Cells(6).Text)
            e.Item.Cells(6).ForeColor = GETCOLOR4(e.Item.Cells(6).Text)

            e.Item.Cells(7).BackColor = GETCOLOR3(e.Item.Cells(7).Text)
            e.Item.Cells(7).ForeColor = GETCOLOR4(e.Item.Cells(7).Text)


            'Cargamos las iniciativas en los Combos
            'Dim RCB1 As RadComboBox = CType(e.Item.Cells(8).Controls(1), RadComboBox)
            'RCB1.Items.Clear()

            'Dim sentencia As String
            'sentencia = "SELECT I.CveIniciativa, I.Iniciativa FROM TblPAPregunta PA, TblPAIniciativa I, tblPregunta P, TblHistoria_Empresa E"
            'sentencia = sentencia & " WHERE PA.CveEmpresa=I.CveEmpresa AND PA.AnioEstudio=I.AnioEstudio AND PA.CveEmpresa=E.CveEmpresa AND P.CveEncuesta=E.CveEncuesta"
            'sentencia = sentencia & " AND PA.AnioEstudio=E.AnioEstudio AND PA.CvePregunta=P.CvePregunta AND PA.CveIniciativa=I.CveIniciativa"
            'sentencia = sentencia & " AND PA.CveEmpresa=" & Session("CveEmpresa") & " AND PA.AnioEstudio=" & Session("AnioEstudio") & " AND P.PilaPregunta=" & e.Item.Cells(4).Text
            'Dim datos As New DataTable
            'datos = DatosBD.FuncionTXT(sentencia, "").Tables(0)

            'RCB1.DataSource = datos
            'RCB1.DataTextField = "Iniciativa"
            'RCB1.DataValueField = "CveIniciativa"
            'RCB1.DataBind()

            Dim ds As New DataSet
            Dim P(4) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 2)
            P(1) = New SqlParameter("@CVEPLAN", Session("CvePlan"))
            P(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            P(3) = New SqlParameter("@CVEPREGUNTA", e.Item.Cells(4).Text)
            P(4) = New SqlParameter("@USUARIO", Session("USUARIO"))
            ds = DatosBD.FuncionConPar("sp_PAConsultaPreguntas", P, Lerror.Text)
            e.Item.Cells(8).Text = ds.Tables(0).Rows(0).Item(0)
        End If
    End Sub

    Function GETCOLOR3(ByVal Numero As Integer) As System.Drawing.Color
        If Numero = 1 Or Numero = 2 Then
            Return Drawing.Color.Red
        ElseIf Numero = 3 Or Numero = 4 Then
            Return Drawing.Color.Yellow
        ElseIf Numero = 5 Or Numero = 6 Then
            Return Drawing.Color.Blue
        ElseIf Numero = 7 Or Numero = 8 Then
            Return Drawing.Color.Green
        Else
            Return Drawing.Color.Gray
        End If
    End Function

    Function GETCOLOR4(ByVal Numero As Integer) As System.Drawing.Color
        If Numero = 1 Or Numero = 2 Then
            Return Drawing.Color.White
        ElseIf Numero = 3 Or Numero = 4 Then
            Return Drawing.Color.Black
        ElseIf Numero = 5 Or Numero = 6 Then
            Return Drawing.Color.White
        ElseIf Numero = 7 Or Numero = 8 Then
            Return Drawing.Color.White
        Else
            Return Drawing.Color.White
        End If
    End Function

    Sub LlenarSeguimientoE()
        ''LLENAR GRID DE SEGUIMIENTO
        Dim ds As New DataSet
        Dim P(0) As SqlParameter
        P(0) = New SqlParameter("@USUARIO", Session("USUARIO"))
        ds = DatosBD.FuncionConPar("SP_PAReporteSeguimiento", P, Lerror.Text)

        RGridSeguimiento.DataSource = ds.Tables(0)
        RGridSeguimiento.DataBind()
        RGridSeguimiento.Visible = True
    End Sub

    Private Sub RGridSeguimiento_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RGridSeguimiento.ItemDataBound
        If e.Item.ItemType = GridItemType.Header Then
            'Cambio de Visible por Display para evadir error en javascriptRadGrid1.Columns(0).Display = False
            RGridSeguimiento.Columns(0).Display = False
            RGridSeguimiento.Columns(0).Visible = True
            RGridSeguimiento.Columns(2).Display = False
            RGridSeguimiento.Columns(2).Visible = True
            RGridSeguimiento.Columns(4).Display = False
            RGridSeguimiento.Columns(4).Visible = True

        ElseIf e.Item.ItemType = GridItemType.AlternatingItem OrElse e.Item.ItemType = GridItemType.Item Then
            'Reemplazamos la coma por punto (Pt)
            e.Item.Cells(6).Text = e.Item.Cells(6).Text.Replace(",", ".")

            Dim Hlink1 As New LinkButton
            Hlink1.Text = "Bitacora"
            Hlink1.Attributes.Add("OnClick", "window.radopen('PASeguimiento.ASPX?T=1&P=" & e.Item.Cells(2).Text & "&O=" & e.Item.Cells(4).Text & "&I=" & e.Item.Cells(6).Text & "','UserListDialog');return false;")
            Hlink1.Dispose()
            e.Item.Cells(8).Controls.Add(Hlink1)

            Dim Hlink2 As New LinkButton
            Hlink2.Text = "Avance"
            Hlink2.Attributes.Add("OnClick", "window.radopen('PASeguimiento.ASPX?T=2&P=" & e.Item.Cells(2).Text & "&O=" & e.Item.Cells(4).Text & "&I=" & e.Item.Cells(6).Text & "','UserListDialog');return false;")
            Hlink2.Dispose()
            e.Item.Cells(9).Controls.Add(Hlink2)

            Dim Hlink3 As New LinkButton
            Hlink3.Text = "Finalizar"
            Hlink3.Attributes.Add("OnClick", "window.radopen('PASeguimiento.ASPX?T=3&P=" & e.Item.Cells(2).Text & "&O=" & e.Item.Cells(4).Text & "&I=" & e.Item.Cells(6).Text & "','UserListDialog');return false;")
            Hlink3.Dispose()
            e.Item.Cells(10).Controls.Add(Hlink3)

        ElseIf e.Item.ItemType = GridItemType.Footer Then
            'Cambio de Display por Visible para visualizar Footer
            RGridSeguimiento.Columns(0).Display = True
            RGridSeguimiento.Columns(0).Visible = False
            RGridSeguimiento.Columns(2).Display = True
            RGridSeguimiento.Columns(2).Visible = False
            RGridSeguimiento.Columns(4).Display = True
            RGridSeguimiento.Columns(4).Visible = False
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
            NumUsuario = Encriptar(Session("USUARIO"), "DICOYES") ' Se encripta la iniciativa

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
            If Panel2.Visible = True Then
                Mensaje = Mensaje.Replace("PARRAFO2", " ")
                Mensaje = Mensaje.Replace("Link1", " ")
            Else
                Mensaje = Mensaje.Replace("PARRAFO2", "Favor de entrar a la siguiente liga para evaluar la iniciativa:")
                Mensaje = Mensaje.Replace("Link1", "<a href= http://ClimaFemsa/PAEvaluacion.aspx?P=CVEPLA&O=CVEOBJ&I=CVEINI&U=USU> EVALUACION DE INICIATIVA")
            End If
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

    Private Sub RCBNombre_ItemsRequested(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs) Handles RCBNombre.ItemsRequested
        Dim data As DataTable = GetData(e.Text)

        Dim itemOffset As Integer = e.NumberOfItems
        Dim endOffset As Integer = Math.Min(itemOffset + ItemsPerRequest, data.Rows.Count)
        e.EndOfItems = endOffset = data.Rows.Count

        For i As Integer = 0 To endOffset - 1
            RCBNombre.Items.Add(New RadComboBoxItem(data.Rows(i)("Nombre").ToString(), data.Rows(i)("NumTrabajador").ToString()))
        Next

        e.Message = GetStatusMessage(endOffset, data.Rows.Count)
    End Sub

    Protected Sub RCBNombre_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBNombre.SelectedIndexChanged
        If RCBNombre.SelectedValue <> "-1" And RCBNombre.SelectedValue <> "" Then
            ' Dim sentencia As String
            ' sentencia = "SELECT ISNULL(Correo,''), ISNULL(Puesto, '') FROM Tbl_SAPUsuarios WHERE NumTrabajador=" & RCBNombre.SelectedValue

            Dim ds As New DataSet
            Dim P(1) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 39)
            P(1) = New SqlParameter("@NUMTRABAJADOR", RCBNombre.SelectedValue)
            ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)



            Dim datos As New DataTable
            datos = ds.Tables(0)


            RTCorreo.Text = datos.Rows(0).Item(0)
            RTPuesto.Text = datos.Rows(0).Item(1)
            LlenarGrid(RCBPlanI.SelectedValue, 2)
        End If
    End Sub

    Private Shared Function GetStatusMessage(ByVal offset As Integer, ByVal total As Integer) As String
        If total <= 0 Then
            Return "No matches"
        End If
        Return [String].Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", offset, total)
    End Function

    Function GetData(ByVal text As String) As DataTable
        ' Dim SEL As String
        ' SEL = "SELECT TOP 10 NumTrabajador, NombreCompleto AS Nombre FROM Tbl_SAPUsuarios WHERE NombreCompleto IS NOT NULL AND IdUnidad=" & Session("CveDivision") & " AND Pais='" & Session("CvePais") & "' AND NombreCompleto LIKE '%" & text.Trim & "%' ORDER BY NOMBRE"

        Dim ds As New DataSet
        Dim P(3) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 40)
        P(1) = New SqlParameter("@UNIDAD", Session("CveDivision"))
        P(2) = New SqlParameter("@CVEPAIS", Session("CvePais"))
        P(3) = New SqlParameter("@NOMBRE", text.Trim)
        ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)

        Dim DT As DataTable = ds.Tables(0)
        Return DT
    End Function

    Sub GetEstructura(ByVal CvePlan As Integer)
        Dim DS As DataSet
        'Dim sentencia As String
        'sentencia = "SELECT TOP 1 CveEmpresa FROM TblPARelacionEmp WHERE CvePlan=" & CvePlan & " "
        'DS = DatosBD.FuncionTXT(sentencia, Lerror.Text)


        Dim P(1) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 41)
        P(1) = New SqlParameter("@CVEPLAN", CvePlan)
        DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


        If DS.Tables(0).Rows.Count > 0 Then
            Dim P1(0) As SqlParameter
            P1(0) = New SqlParameter("@CveEmpresa", DS.Tables(0).Rows(0).Item(0))
            DS = DatosBD.FuncionConPar("SP_ESTRUCTURA_CENTROTRABAJO", P1, Lerror.Text)
            Session("CveDivision") = DS.Tables(0).Rows(0).Item("CveDivision")
            Session("CvePais") = DS.Tables(0).Rows(0).Item("CvePais")
        Else
            Lerror.Text = "El plan de acción no tiene un Centro de Trabajo asignado."
        End If
    End Sub

    Protected Sub BFiltrar_Click(sender As Object, e As EventArgs) Handles BFiltrar.Click
        Session("SesTipoOperacion") = Nothing
        RGridVisualizacion.Visible = True
        RGridPreguntas.Visible = False
        ReportViewer1.Visible = False
        BtnRegresar.Visible = False
        Lerror.Text = ""
        LlenarVisualizacion()
    End Sub

    Sub LlenarVisualizacion()
        Dim ds As New DataSet
        Dim PLoad(9) As SqlParameter
        Try
            If RCBUnidad.SelectedValue = "-1" Or RCBUnidad.SelectedValue = "" Then
                Session("CveUnidad") = DBNull.Value
                PLoad(0) = New SqlParameter("@CVEDIVISION", DBNull.Value)
            Else
                Session("CveUnidad") = RCBUnidad.SelectedValue
                PLoad(0) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
            End If

            If RCBAgrupadoPaises.SelectedValue = "-1" Or RCBAgrupadoPaises.SelectedValue = "" Then
                Session("CveAgrupado") = DBNull.Value
                PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", DBNull.Value)
            Else
                Session("CveAgrupado") = RCBAgrupadoPaises.SelectedItem.Value
                PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", RCBAgrupadoPaises.SelectedValue)
            End If

            If RCBPais.SelectedValue = "-1" Or RCBPais.SelectedValue = "" Then
                Session("CvePais") = DBNull.Value
                PLoad(2) = New SqlParameter("@CVEPAIS", DBNull.Value)
            Else
                Session("CvePais") = RCBPais.SelectedItem.Value
                PLoad(2) = New SqlParameter("@CVEPAIS", RCBPais.SelectedValue)
            End If

            'Meter concepto area
            If Session("SesTipoOperacion") Is Nothing Or Session("SesTipoOperacion") = "-1" Then
                'If RCBTipoEmpresa.SelectedValue = "-1" Or RCBTipoEmpresa.SelectedValue = "" Then
                Session("CveTipo") = DBNull.Value
                PLoad(3) = New SqlParameter("@CVEAREA", DBNull.Value)
            Else
                Session("CveTipo") = Session("SesTipoOperacion")
                PLoad(3) = New SqlParameter("@CVEAREA", Session("SesTipoOperacion"))
            End If

            If RCBTerritorio.SelectedValue = "-1" Or RCBTerritorio.SelectedValue = "" Then
                Session("CveTerritorio") = DBNull.Value
                PLoad(4) = New SqlParameter("@CVETERRITORIO", DBNull.Value)
            Else
                Session("CveTerritorio") = RCBTerritorio.SelectedItem.Value
                PLoad(4) = New SqlParameter("@CVETERRITORIO", RCBTerritorio.SelectedValue)
            End If

            If RCBRegion.SelectedValue = "-1" Or RCBRegion.SelectedValue = "" Then
                Session("CveRegion") = DBNull.Value
                PLoad(5) = New SqlParameter("@CVEREGION", DBNull.Value)
            Else
                Session("CveRegion") = RCBRegion.SelectedItem.Value
                PLoad(5) = New SqlParameter("@CVEREGION", RCBRegion.SelectedValue)
            End If

            If RCBSubRegion.SelectedValue = "-1" Or RCBSubRegion.SelectedValue = "" Then
                Session("CveSubRegion") = DBNull.Value
                PLoad(6) = New SqlParameter("@CVESUBREGION", DBNull.Value)
            Else
                Session("CveSubRegion") = RCBSubRegion.SelectedItem.Value
                PLoad(6) = New SqlParameter("@CVESUBREGION", RCBSubRegion.SelectedValue)
            End If

            If RadioButtonList1.SelectedIndex = 1 Then
                Session("CveSistema") = 13
                PLoad(7) = New SqlParameter("@CVESISTEMA", 13)
            Else
                Session("CveSistema") = 3
                PLoad(7) = New SqlParameter("@CVESISTEMA", 3)
            End If

            PLoad(8) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(9) = New SqlParameter("@USUARIO", Session("USUARIO"))

            ds = DatosBD.FuncionConPar("SP_PAVisualizacion", PLoad, Lerror.Text)

            Session("TotalPlanes") = ds.Tables(1).Rows(0).Item(0)
            RGridVisualizacion.DataSource = ds.Tables(0)
            RGridVisualizacion.DataBind()

        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Private Sub RGridVisualizacion_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RGridVisualizacion.ItemCommand
        If e.CommandName = "Detalles" Then
            Session("CvePlan") = e.Item.Cells(7).Text
            RGridVisualizacion.Visible = False
            'RGridPlan.Visible = True
            GetEstructura(Session("CvePlan"))
            'LlenarReporte(Session("CvePlan"))
            CrearReporte(Session("CvePlan"))
            BtnRegresar.Visible = True
        ElseIf e.CommandName = "Preguntas" Then
            Session("CvePlan") = e.Item.Cells(7).Text
            RGridVisualizacion.Visible = False
            RGridPreguntas.Visible = True
            GetEstructura(Session("CvePlan"))
            LlenarRelacionPreguntas(Session("CvePlan"))
            BtnRegresar.Visible = True
        End If
    End Sub

    Private Sub RGridVisualizacion_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RGridVisualizacion.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.CommandItem Then
                If RCBUnidad.SelectedValue <> "-1" Or RCBUnidad.SelectedValue <> "" Then
                    Dim GIC As GridCommandItem = DirectCast(e.Item, GridCommandItem)
                    Dim RD As RadComboBox = DirectCast(GIC.FindControl("RcboTipoOperacion"), RadComboBox)
                    RD.Items.Clear()
                    RD.Enabled = True

                    Dim PLoad(2) As SqlParameter
                    PLoad(0) = New SqlParameter("@TIPO", 7)
                    PLoad(1) = New SqlParameter("@CVEDIVISION", RCBUnidad.SelectedValue)
                    PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
                    'Dim DS As DataSet = DatosBDCubo.FuncionConPar("[Sp_CargaEstructura]", PLoad, "")

                    Cargar.ComboParametros(RD, "[Sp_CargaEstructura]", PLoad, "NomArea", "CveArea", 1, True)

                    If Not Session("SesTipoOperacion") Is Nothing Then
                        RD.FindItemByValue(Session("SesTipoOperacion")).Selected = True
                    End If
                End If
            ElseIf e.Item.ItemType = GridItemType.Header Then
                'Cambio de Visible por Display para evadir error en javascript
                RGridVisualizacion.Columns(1).Display = False
                RGridVisualizacion.Columns(1).Visible = True
                RGridVisualizacion.Columns(5).Display = False
                RGridVisualizacion.Columns(5).Visible = True
                RGridVisualizacion.Columns(8).Display = False
                RGridVisualizacion.Columns(8).Visible = True
            ElseIf e.Item.ItemType = GridItemType.AlternatingItem OrElse e.Item.ItemType = GridItemType.Item Then
                If e.Item.Cells(10).Text = 1 Then ' SI SON PADRES
                    Con = Con + 1
                    e.Item.Cells(2).Text = Con
                Else
                    e.Item.Cells(2).Text = "-"
                    'Agregamos en el ToolTip del hijo el nombre del padre
                    Dim DS As DataSet
                    'Dim SEN As String
                    'SEN = "SELECT NOMEMPRESA FROM TBLEMPRESA WHERE CVEEMPRESA=" & e.Item.Cells(10).Text
                    'DS = DatosBD.FuncionTXT(SEN, "")


                    Dim P(1) As SqlParameter
                    P(0) = New SqlParameter("@TIPO", 42)
                    P(1) = New SqlParameter("@CVEEMPRESA", e.Item.Cells(10).Text)
                    DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


                    e.Item.Cells(4).ToolTip = DS.Tables(0).Rows(0).Item(0)
                End If

                e.Item.Cells(2).ToolTip = CStr(e.Item.Cells(3).Text)  ' COLOCA LA CVE EMPRESA EN EL  TOOLTIP

                If e.Item.Cells(7).Text = "&nbsp;" Then ' SI NO TIENE PLAN, OCULTAMOS LINKS
                    e.Item.Cells(11).Controls(0).Visible = False
                    e.Item.Cells(12).Controls(0).Visible = False
                End If
            ElseIf e.Item.ItemType = GridItemType.Footer Then
                Dim Total As Double
                Total = Session("TotalPlanes") / 100
                e.Item.Cells(9).Text = Total.ToString("P", System.Globalization.CultureInfo.InvariantCulture)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Cambio de Display por Visible para visualizar Footer
                RGridVisualizacion.Columns(1).Display = True
                RGridVisualizacion.Columns(1).Visible = False
                RGridVisualizacion.Columns(5).Display = True
                RGridVisualizacion.Columns(5).Visible = False
                RGridVisualizacion.Columns(8).Display = True
                RGridVisualizacion.Columns(8).Visible = False
            End If
        Catch ex As Exception
            Lerror.Text = ex.Message
            Exit Sub
        End Try
    End Sub

    Private Sub RGridVisualizacion_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RGridVisualizacion.SortCommand
        LlenarVisualizacion()
    End Sub

    Sub CrearReporte(ByVal CvePlan As Integer)
        Try
            ReportViewer1.Report = New PlanAccion
            ReportViewer1.Visible = True
            ReportViewer1.ZoomPercent = 80

            'Set the parameters
            Dim PlanAccion As String
            Dim con2 As String = "SELECT DBO.GETPLANES(" & CvePlan & ")"
            Dim ds2 As New DataSet
            ds2 = DatosBD.FuncionTXT(con2, "")
            PlanAccion = ds2.Tables(0).Rows(0).Item(0)

            ReportViewer1.Report.ReportParameters(0).Value = PlanAccion
            ReportViewer1.Report.ReportParameters(1).Value = CvePlan
            ReportViewer1.Report.ReportParameters(2).Value = Session("USUARIO")

            Dim ds As DataSet
            Dim P(1) As SqlParameter
            P(0) = New SqlParameter("@CVEPLAN", CvePlan)
            P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
            ds = DatosBD.FuncionConPar("SP_PAReporteEjecutivo", P, Lerror.Text)

            ReportViewer1.Report.Reports(0).DataSource = ds.Tables(0)
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnRegresar_Click(sender As Object, e As ImageClickEventArgs) Handles BtnRegresar.Click
        RGridVisualizacion.Visible = True
        RGridPreguntas.Visible = False
        ReportViewer1.Visible = False
        BtnRegresar.Visible = False
        Lerror.Text = ""
    End Sub

    Sub Exportar()
        RGridVisualizacion.MasterTableView.ExportToExcel()
    End Sub
End Class

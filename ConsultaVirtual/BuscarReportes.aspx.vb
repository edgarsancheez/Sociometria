Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports Telerik.ReportViewer.WebForms
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.IO

Partial Public Class BuscarReportes
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
                Session("CveEmpresa") = Page.Request.Params("CVEm")
                Session("CveEncuesta") = Page.Request.Params("CVEn")
                'Session("NombreEmpresa") = DatosBD.FuncionTXT("SELECT ISNULL(DBO.GETEMPRESAS(" & Session("CveEmpresa") & "),'SIN NOMBRE')", Lerror.Text).Tables(0).Rows(0).Item(0)
                'Session("NumDivision") = DatosBD.FuncionTXT("SELECT CVEDIVISION FROM TBLEMPRESA WHERE CVEEMPRESA=" & Session("CveEmpresa"), Lerror.Text).Tables(0).Rows(0).Item(0)
                'Session("NumPais") = DatosBD.FuncionTXT("SELECT CVEPAIS FROM TBLEMPRESA WHERE CVEEMPRESA=" & Session("CveEmpresa"), Lerror.Text).Tables(0).Rows(0).Item(0)
                'Session("AnioEstudio") = DatosBD.FuncionTXT("SELECT DBO.GETANIOVIGENTE(" & Session("CveEmpresa") & ", " & Session("NUMPERFIL") & ")", Lerror.Text).Tables(0).Rows(0).Item(0)
                'Session("TipoEncuesta") = DatosBD.FuncionTXT("SELECT TipoEncuesta FROM TblEmpresaEncuesta WHERE CveEmpresa=" & Session("CveEmpresa") & " AND AñoEstudio=" & Session("AnioEstudio") & " AND CveEncuesta<>2", Lerror.Text).Tables(0).Rows(0).Item(0)

                Dim ds As DataSet
                Dim p(2) As SqlParameter
                p(0) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                p(1) = New SqlParameter("@CVEENCUESTA", Session("CveEncuesta"))
                p(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))

                'Dim ds As New DataSet
                ds = DatosBD.FuncionConPar("SP_BUSCAR_REPORTES", p, "")
                Session("NombreEmpresa") = ds.Tables(0).Rows(0).Item(0)
                Session("NumDivision") = ds.Tables(1).Rows(0).Item(0)
                Session("NumPais") = ds.Tables(2).Rows(0).Item(0)
                Session("AnioEstudio") = ds.Tables(3).Rows(0).Item(0)
                Session("TipoEncuesta") = ds.Tables(4).Rows(0).Item(0)


                Session("RUTA_DEF") = "\\femmsiliis1.csc.fmx\RespaldoCO\ReportesEV\" & Session("AnioEstudio") & "\" & Session("CveEmpresa") & "\"
                'Session("RUTA_DEF") = "\\femmsilqa01.csc.fmx\RespaldoCO\ReportesEV\" & Session("AnioEstudio") & "\" & Session("CveEmpresa") & "\"
                Label8.Text = GETPALABRA("Detalles del estudio: ") & Session("NombreEmpresa")
                LlenarSeccion()
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Sub Enabled(ByVal Val As Boolean)
        'RCBReporte.Enabled = Val
        RCBSubreporte.Enabled = Val
        RCBDepartamento.Enabled = Val
        RCBTrabajador.Enabled = Val
        RCBLiderazgo.Enabled = Val
    End Sub

    Sub Show(ByVal Val As Boolean)
        Chart1.Visible = Val
        BRegresar.Visible = Val
        ReportViewer1.Visible = Val
        RadGrid1.Visible = Val
        BVerReporte.Visible = Val
        RBPantalla.Visible = Val
        Chart2.Visible = Val
        ShowPdf1.Visible = Val
    End Sub

    Sub LlenarSeccion()
        RCBSeccion.Items.Clear()
        ' Dim CONSULTA As String
        Dim ds As New DataSet
        Dim P(0) As SqlParameter
        If Session("Lenguaje") = "pt-BR" Then
            'CONSULTA = "SELECT DISTINCT CVESECCION, NOMSECCIONPT AS NOMSECCION FROM TblReportes_EntregaVirtual WHERE VISIBLE=1"
            P(0) = New SqlParameter("@TIPO", 64)
        ElseIf Session("Lenguaje") = "en-US" Then
            '  CONSULTA = "SELECT DISTINCT CVESECCION, NOMSECCIONEN AS NOMSECCION FROM TblReportes_EntregaVirtual WHERE VISIBLE=1"
            P(0) = New SqlParameter("@TIPO", 65)
        Else
            '  CONSULTA = "SELECT DISTINCT CVESECCION, NOMSECCION FROM TblReportes_EntregaVirtual WHERE VISIBLE=1"
            P(0) = New SqlParameter("@TIPO", 66)
        End If

        ' ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)

        ' Cargar.ComboSentenciaTxt(RCBSeccion, CONSULTA, "NOMSECCION", "CVESECCION", 2, False, Session("Lenguaje"))

        Cargar.ComboParametros(RCBSeccion, "SP_CONSULTAS_ENTREGAVIRTUAL", P, "NOMSECCION", "CVESECCION", 2, True, Session("Lenguaje"))

        'RCBSeccion.DataSource = ds.Tables(0)
        'RCBSeccion.DataTextField = "NOMSECCION"
        'RCBSeccion.DataValueField = "CVESECCION"
        'RCBSeccion.DataBind()


        AlternateColor(RCBSeccion)
    End Sub

    Protected Sub RCBSeccion_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBSeccion.SelectedIndexChanged
        Enabled(False)
        Show(False)
        Lerror.Text = ""
        AlternateColor(RCBLiderazgo)
        AlternateColor(RCBTrabajador)
        LlenarReporte()

        Dim DSBr As DataSet
        Dim P(1) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 67)
        P(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
        DSBr = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)




        If DSBr.Tables(0).Rows(0).Item(0) > 0 Then
            Session("BrasilKOF") = "Y"
            'RCBReporte.Items.FindItemByValue(6).Visible = True 'Funcion Sindical
        Else
            Session("BrasilKOF") = "N"
        End If

        If RCBSeccion.SelectedValue = "1P" Then
            BuildData()
            Chart1.Visible = True

        ElseIf RCBSeccion.SelectedValue = "CO" Then
            If Session("NumDivision") = "2" Then
                RCBReporte.Items.FindItemByValue("R5").Visible = True 'Cultura KOF
            Else
                RCBReporte.Items.FindItemByValue("R5").Visible = False
            End If

            Label5.Text = GETPALABRA("Tipo de Liderazgo")
            RCBLiderazgo.Items.Clear()
            RCBLiderazgo.Items.Add(New RadComboBoxItem(GETPALABRA("[Seleccionar]"), GETPALABRA("[Seleccionar]")))
            RCBLiderazgo.Items.Add(New RadComboBoxItem(GETPALABRA("Afinidad"), "Af"))
            RCBLiderazgo.Items.Add(New RadComboBoxItem(GETPALABRA("Ascendencia"), "As"))
            RCBLiderazgo.Items.Add(New RadComboBoxItem(GETPALABRA("Popularidad"), "Po"))
            RCBLiderazgo.Enabled = False
            AlternateColor(RCBLiderazgo)

        ElseIf RCBSeccion.SelectedValue = "ENG" Then
            Label5.Text = GETPALABRA("Perfil de Efectividad")
            'Dim CONSULTA As String
            Dim ds As New DataSet
            Dim P1(0) As SqlParameter
            If Session("Lenguaje") = "pt-BR" Then
                ' CONSULTA = "SELECT IDPERFILEFECTIVIDAD, PERFILEFECTIVIDADPT AS PERFILEFECTIVIDAD FROM TblEngPerfilEfectividad WHERE IDPERFILEFECTIVIDAD > 0 ORDER BY ORDEN"
                P1(0) = New SqlParameter("@TIPO", 68)
            ElseIf Session("Lenguaje") = "en-US" Then
                ' CONSULTA = "SELECT IDPERFILEFECTIVIDAD, PERFILEFECTIVIDADEN AS PERFILEFECTIVIDAD FROM TblEngPerfilEfectividad WHERE IDPERFILEFECTIVIDAD > 0 ORDER BY ORDEN"
                P1(0) = New SqlParameter("@TIPO", 69)
            Else
                ' CONSULTA = "SELECT IDPERFILEFECTIVIDAD, PERFILEFECTIVIDAD AS PERFILEFECTIVIDAD FROM TblEngPerfilEfectividad WHERE IDPERFILEFECTIVIDAD > 0 ORDER BY ORDEN"
                P1(0) = New SqlParameter("@TIPO", 70)
            End If
            ' Cargar.ComboSentenciaTxt(RCBLiderazgo, CONSULTA, "PERFILEFECTIVIDAD", "IDPERFILEFECTIVIDAD", 2, False, Session("Lenguaje"))



            'ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P1, Lerror.Text)


            Cargar.ComboParametros(RCBLiderazgo, "SP_CONSULTAS_ENTREGAVIRTUAL", P1, "PERFILEFECTIVIDAD", "IDPERFILEFECTIVIDAD", 1, True, Session("Lenguaje"))

            'RCBLiderazgo.DataSource = ds.Tables(0)
            'RCBLiderazgo.DataTextField = "PERFILEFECTIVIDAD"
            'RCBLiderazgo.DataValueField = "IDPERFILEFECTIVIDAD"
            'RCBLiderazgo.DataBind()


            AlternateColor(RCBLiderazgo)
            RCBLiderazgo.Enabled = False
            RCBLiderazgo.SelectedIndex = 0

        ElseIf RCBSeccion.SelectedValue = "RF" Then
            'CalificacionFEMSA()
        ElseIf RCBSeccion.SelectedValue = "CV" Then
            BuildGrid("49")
        ElseIf RCBSeccion.SelectedValue = "DS" Then
            BuildGrid("50")
        End If
    End Sub

    Private Sub BuildData() 'PARTICIPACION
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@CveEmpresa", Session("CveEmpresa"))
        p(1) = New SqlParameter("@CvePerfil", Session("NUMPERFIL"))
        Dim ds As New DataSet
        'If Session("BrasilKOF") = "Y" Then
        '    ds = DatosBD.FuncionConPar("SP_PARTICIPACION_BRASILKOF", p, Lerror.Text, "tblParticipacion")
        'Else
        ds = DatosBD.FuncionConPar("SP_PARTICIPACION_HISTORICO", p, Lerror.Text, "tblParticipacion")
        'End If
        Graficar(ds.Tables(0), "CONCEPTO", "PORCENTAJE", "", GETPALABRA("PARTICIPACION"), Session("NombreEmpresa"), GETPALABRA("Gráfica de Participación"))
        Chart1.Visible = True
    End Sub

    Sub LlenarReporte()
        RCBReporte.Items.Clear()
        'Dim CONSULTA As String
        Dim ds As New DataSet
        Dim P(1) As SqlParameter
        If Session("Lenguaje") = "pt-BR" Then
            ' CONSULTA = "SELECT DISTINCT NUMREPORTE, NOMREPORTEPT AS NOMREPORTE FROM TblReportes_EntregaVirtual WHERE VISIBLE=1 AND CVESECCION='" & RCBSeccion.SelectedValue & "' ORDER BY NUMREPORTE"
            P(0) = New SqlParameter("@TIPO", 71)
            P(1) = New SqlParameter("@CVESECCION", RCBSeccion.SelectedValue)
        ElseIf Session("Lenguaje") = "en-US" Then
            'CONSULTA = "SELECT DISTINCT NUMREPORTE, NOMREPORTEEN AS NOMREPORTE FROM TblReportes_EntregaVirtual WHERE VISIBLE=1 AND CVESECCION='" & RCBSeccion.SelectedValue & "' ORDER BY NUMREPORTE"
            P(0) = New SqlParameter("@TIPO", 72)
            P(1) = New SqlParameter("@CVESECCION", RCBSeccion.SelectedValue)
        Else
            'CONSULTA = "SELECT DISTINCT NUMREPORTE, NOMREPORTE FROM TblReportes_EntregaVirtual WHERE VISIBLE=1 AND CVESECCION='" & RCBSeccion.SelectedValue & "' ORDER BY NUMREPORTE"
            P(0) = New SqlParameter("@TIPO", 73)
            P(1) = New SqlParameter("@CVESECCION", RCBSeccion.SelectedValue)
        End If
        'Cargar.ComboSentenciaTxt(RCBReporte, CONSULTA, "NOMREPORTE", "NUMREPORTE", 2, False, Session("Lenguaje"))
        'ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


        Cargar.ComboParametros(RCBReporte, "SP_CONSULTAS_ENTREGAVIRTUAL", P, "NOMREPORTE", "NUMREPORTE", 2, True, Session("Lenguaje"))

        'RCBReporte.DataSource = ds.Tables(0)
        'RCBReporte.DataTextField = "NOMREPORTE"
        'RCBReporte.DataValueField = "NUMREPORTE"
        'RCBReporte.DataBind()


        AlternateColor(RCBReporte)
    End Sub

    Protected Sub RCBReporte_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBReporte.SelectedIndexChanged
        Show(False)
        Enabled(False)
        Lerror.Text = ""
        RadGrid1.Columns.Clear()
        LlenarSubReporte()

        Dim VAL As String
        If RCBReporte.SelectedValue = "" Then 'SELECCIONO PARTICIPACION
            BuildData()
            VAL = "NDA"
        ElseIf RCBReporte.SelectedValue = "R1" Then 'SELECCIONO GRAFICAS
            VAL = "GRA"
        ElseIf RCBReporte.SelectedValue = "R2" Then 'SELECCIONO CLIMA
            VAL = "RCO"
        ElseIf RCBReporte.SelectedValue = "R3" Then 'SELECCIONO LIDERAZGO
            VAL = "RLI"
        ElseIf RCBReporte.SelectedValue = "R4" Then 'SELECCIONO SICAV
            VAL = "NDA"
            BuildGrid("21")
        ElseIf RCBReporte.SelectedValue = "R5" Then 'SELECCIONO CULTURA KOF
            VAL = "NDA"
            BuildGrid("22")
        ElseIf RCBReporte.SelectedValue = "" Then 'SELECCIONO FUNCION SINDICAL KOF
            VAL = "NDA"
            BuildData3(3)
        ElseIf RCBReporte.SelectedValue = "R6" Then 'SELECCIONO REPORTES DEMOGRAFICOS
            VAL = "RD"
        ElseIf RCBReporte.SelectedValue = "R-1" Then 'SELECCIONO MATRIZ DE EFECTIVIDAD
            VAL = "NDA"
            BuildMatriz()
        ElseIf RCBReporte.SelectedValue = "R-0" Then 'SELECCIONO MATRIZ DE EFECTIVIDAD POR DEPARTAMENTO
            VAL = "ME"
            LlenarDepartamentos(RCBReporte.SelectedValue.ToString)
            RCBDepartamento.Enabled = True
        ElseIf RCBReporte.SelectedValue = "R7" Or RCBReporte.SelectedValue = "R8" Or RCBReporte.SelectedValue = "R9" Then 'SELECCIONO GRAFICA IMPACTO
            VAL = "NDA"
            Dim ds2 As New DataSet
            Dim PLoad(5) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 4)
            PLoad(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
            If Session("TipoEmpleado") = "Lider" Then
                PLoad(2) = New SqlParameter("@CVESISTEMA", 13)
            ElseIf Session("CveUnidad") = 9 Then
                PLoad(2) = New SqlParameter("@CVESISTEMA", 13)
            Else
                'TRUENA CROWN 8 FEB 2018
                PLoad(2) = New SqlParameter("@CVESISTEMA", 3)
            End If
            PLoad(3) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(4) = New SqlParameter("@USUARIO", Session("USUARIO"))
            PLoad(5) = New SqlParameter("@IDIOMA", Session("Idioma"))

            ds2 = DatosBD.FuncionConPar("sp_EngCorrelacion", PLoad, Lerror.Text)

          
            Dim ds As New DataSet
            Dim P(0) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 74)
            ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


            If RCBReporte.SelectedValue = "R7" Then
                Session("DTGraficaCorrelacion") = ds2.Tables(0)
                Graficar2(ds.Tables(0), "TEXTO", "PROM", GETPALABRA("IMPACTO"), GETPALABRA("SATISFACCION"), GETPALABRA("GRAFICA DE PRIORIDADES (COMPROMISO)"), " ", True)
                Chart2.Visible = True
            ElseIf RCBReporte.SelectedValue = "R8" Then
                Session("DTGraficaCorrelacion") = ds2.Tables(1)
                Graficar2(ds.Tables(0), "TEXTO", "PROM", GETPALABRA("IMPACTO"), GETPALABRA("SATISFACCION"), GETPALABRA("GRAFICA DE PRIORIDADES (SOPORTE)"), " ", True)
                Chart2.Visible = True
            ElseIf RCBReporte.SelectedValue = "R9" Then
                Session("DTReporteCorrelacion") = ds2.Tables(2)
                Dim TBLREPORTE As DataTable = ds2.Tables(2)
                RadGrid1.MasterTableView.GroupByExpressions.Clear()
                RadGrid1.DataSource = TBLREPORTE
                RadGrid1.DataBind()

                For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                    Dim colDecimal As GridBoundColumn
                    colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                    colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    colDecimal.Visible = True
                    If cont = 0 Then 'CveTema
                        colDecimal.Visible = False
                    ElseIf cont = 1 Then 'Tema
                        colDecimal.HeaderStyle.Width = 100
                        colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    ElseIf cont = 2 Then 'CvePregunta
                        colDecimal.HeaderStyle.Width = 50
                    ElseIf cont = 3 Then 'Pregunta
                        colDecimal.HeaderStyle.Width = 350
                        colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    ElseIf cont = 4 Or cont = 5 Then 'Cuadrantes
                        colDecimal.HeaderStyle.Width = 100
                    End If
                Next
                RadGrid1.Visible = True
            End If
        ElseIf RCBReporte.SelectedValue = "R10" Then 'SELECCIONO REPORTE COMPROMISO Y SOPORTE
            VAL = "NDA"
            BuildGrid("40")
        ElseIf RCBReporte.SelectedValue = "R13" Then 'SELECCIONO CALIFICACION FEMSA 
            VAL = "NDA"
            CalificacionFEMSA("1")
        ElseIf RCBReporte.SelectedValue = "R14" Then 'SELECCIONO CALIFICACION FEMSA POR DEPARTAMENTO
            VAL = "CO"
            LlenarDepartamentos(RCBReporte.SelectedValue.ToString)
            RCBDepartamento.Enabled = True
        End If


        If VAL <> "NDA" Then
            RCBReporte.Enabled = True
            Dim CONSULTA As String
            If Session("Departamentos") = "Y" Then
                If VAL = "RLI" Then 'Si selecciona Liderazgo, carga automaticamente el subreporte
                    LlenarDepartamentos(RCBReporte.SelectedValue.ToString)
                    RCBLiderazgo.Enabled = True
                    RCBTrabajador.Enabled = True
                    RCBSubreporte.Enabled = True
                    BVerReporte.Visible = True
                End If
            End If

            AlternateColor(RCBReporte)
            RCBReporte.Visible = True
        End If

    End Sub

    Sub LlenarSubReporte()
        RCBSubreporte.Items.Clear()
        Dim ds As New DataSet
        Dim P(2) As SqlParameter
        If Session("Lenguaje") = "pt-BR" Then
            ' CONSULTA = "SELECT ORDEN, NOMSUBREPORTEPT AS NOMSUBREPORTE FROM TblReportes_EntregaVirtual WHERE VISIBLE=1 AND CVESECCION='" & RCBSeccion.SelectedValue & "' AND NUMREPORTE='" & RCBReporte.SelectedValue & "' ORDER BY ORDEN"

            P(0) = New SqlParameter("@TIPO", 75)
            P(1) = New SqlParameter("@CVESECCION", RCBSeccion.SelectedValue)
            P(2) = New SqlParameter("@TIPOREPORTE", RCBReporte.SelectedValue)
        ElseIf Session("Lenguaje") = "en-US" Then
            ' CONSULTA = "SELECT ORDEN, NOMSUBREPORTEEN AS NOMSUBREPORTE FROM TblReportes_EntregaVirtual WHERE VISIBLE=1 AND CVESECCION='" & RCBSeccion.SelectedValue & "' AND NUMREPORTE='" & RCBReporte.SelectedValue & "' ORDER BY ORDEN"

            P(0) = New SqlParameter("@TIPO", 76)
            P(1) = New SqlParameter("@CVESECCION", RCBSeccion.SelectedValue)
            P(2) = New SqlParameter("@TIPOREPORTE", RCBReporte.SelectedValue)
        Else
            'CONSULTA = "SELECT ORDEN, NOMSUBREPORTE FROM TblReportes_EntregaVirtual WHERE VISIBLE=1 AND CVESECCION='" & RCBSeccion.SelectedValue & "' AND NUMREPORTE='" & RCBReporte.SelectedValue & "' ORDER BY ORDEN"

            P(0) = New SqlParameter("@TIPO", 77)
            P(1) = New SqlParameter("@CVESECCION", RCBSeccion.SelectedValue)
            P(2) = New SqlParameter("@TIPOREPORTE", RCBReporte.SelectedValue)
        End If

        ' ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)


        Cargar.ComboParametros(RCBSubreporte, "SP_CONSULTAS_ENTREGAVIRTUAL", P, "NOMSUBREPORTE", "ORDEN", 2, True, Session("Lenguaje"))

        'RCBSubreporte.DataSource = ds.Tables(0)
        'RCBSubreporte.DataTextField = "NOMSUBREPORTE"
        'RCBSubreporte.DataValueField = "ORDEN"
        'RCBSubreporte.DataBind()



        AlternateColor(RCBSubreporte)
    End Sub

    Protected Sub RCBSubreporte_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBSubreporte.SelectedIndexChanged
        Try
            Show(False)
            Enabled(False)
            Lerror.Text = ""
            RCBSubreporte.Enabled = True

            'Agrega opcion de reportes psicosociales
            If RCBSeccion.SelectedValue = "CO" Or RCBSeccion.SelectedValue = "PS" Then
                If RCBReporte.SelectedValue = "R1" Then
                    'SELECCIONO GRAFICAS
                    If RCBSubreporte.SelectedIndex = 0 Then 'Pedir que seleccione nuevamente, no hace nada
                        Cargar.Mensaje(RadAjaxManager1, "Seleccione un elemento para continuar")
                        Exit Sub
                    ElseIf RCBSubreporte.SelectedValue = "1" Then
                        Graficar(BuildData1(1), "DESCTEMA", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text, True)
                        Chart1.Visible = True
                    ElseIf RCBSubreporte.SelectedValue = "2" Then
                        LlenarDepartamentos("2")
                        RCBDepartamento.Enabled = True
                    ElseIf RCBSubreporte.SelectedValue = "4" Then
                        Dim DT As DataTable = BuildData1(3)
                        Graficar(DT, "INDICE", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text, False)
                        Chart1.Visible = True
                        CARGARGRID(DT)
                    ElseIf RCBSubreporte.SelectedValue = "5" Then
                        Dim DT As DataTable = BuildData1(4)
                        Graficar(DT, "INDICE", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text, False)
                        Chart1.Visible = True
                        CARGARGRID(DT)
                    ElseIf RCBSubreporte.SelectedValue = "6" Then
                        Dim DT As DataTable = BuildData1(5)
                        Graficar(DT, "NOMEMPRESA", "PROMEDIOEMPRESA", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text, False)
                        Chart1.Visible = True
                    End If
                ElseIf RCBReporte.SelectedValue = "R2" Then
                    'SELECCIONO CLIMA
                    If RCBSubreporte.SelectedValue = "8" Or RCBSubreporte.SelectedValue = "6" Or RCBSubreporte.SelectedValue = "11" Or RCBSubreporte.SelectedValue = "12" Or RCBSubreporte.SelectedValue = "31" Then
                        BuildGrid(RCBSubreporte.SelectedValue)
                    ElseIf RCBSubreporte.SelectedValue = "3" Then
                        LlenarDepartamentos("3")
                        RCBDepartamento.Enabled = True
                    Else
                        If RCBSubreporte.SelectedValue = "7" OrElse RCBSubreporte.SelectedValue = "10" OrElse RCBSubreporte.SelectedValue = "13" Then
                            LlenarDepartamentos(RCBSubreporte.SelectedValue)
                            RCBDepartamento.Enabled = True
                        End If
                    End If
                ElseIf RCBReporte.SelectedValue = "R3" Then
                    'SELECCIONO LIDERAZGO
                    Dim NumReporte As String
                    NumReporte = RCBSubreporte.SelectedValue.ToString
                    If NumReporte <> "15" Then
                        If NumReporte = 16 Then
                            ReportViewer1.Report = New R16
                        ElseIf NumReporte = 17 Then
                            ReportViewer1.Report = New R17
                        ElseIf NumReporte = 18 Then
                            ReportViewer1.Report = New R18
                        ElseIf NumReporte = 19 Then
                            ReportViewer1.Report = New R19
                        ElseIf NumReporte = 20 Then
                            ReportViewer1.Report = New R20
                        End If

                        ReportViewer1.Visible = True
                        ReportViewer1.ZoomPercent = 80

                        'Set the parameters
                        Dim NomEmpresa As String
                        NomEmpresa = Session("NombreEmpresa")

                        ReportViewer1.Report.ReportParameters(0).Value = NomEmpresa
                        ReportViewer1.Report.ReportParameters(1).Value = RCBSubreporte.SelectedItem.Text
                        ReportViewer1.Report.ReportParameters(2).Value = CInt(Session("CveEmpresa"))
                        ReportViewer1.Report.ReportParameters(3).Value = CInt(Session("CveEncuesta"))
                        ReportViewer1.Report.ReportParameters(6).Value = Session("Lenguaje")

                        BuildReport(NumReporte, ReportViewer1.Report)
                    Else
                        LlenarDepartamentos(RCBSubreporte.SelectedValue.ToString)
                        RCBLiderazgo.SelectedIndex = 0
                        RCBLiderazgo.Enabled = True
                        RCBTrabajador.SelectedIndex = 0
                        RCBTrabajador.Enabled = True
                        RCBDepartamento.Enabled = True
                        RCBSubreporte.Enabled = True
                        BVerReporte.Visible = True
                    End If
                ElseIf RCBReporte.SelectedValue = "R6" Then
                    'SELECCIONO REPORTES DEMOGRAFICOS
                    BuildGrid(RCBSubreporte.SelectedValue)



                ElseIf RCBReporte.SelectedValue = "R17" Then
                    'SELECCIONO REPORTES PSICOSOCIALES
                    Dim NumReporte As String
                    NumReporte = RCBSubreporte.SelectedValue.ToString
                    If RCBReporte.Visible = True Then
                        If NumReporte = 51 Then
                            ReportViewer1.Report = New R51
                        ElseIf NumReporte = 53 Then
                            ReportViewer1.Report = New R53
                        End If

                        ReportViewer1.Visible = True
                        ReportViewer1.ZoomPercent = 80

                        'Set the parameters
                        Dim NomEmpresa As String
                        NomEmpresa = Session("NombreEmpresa")

                        ReportViewer1.Report.ReportParameters(0).Value = NomEmpresa
                        ReportViewer1.Report.ReportParameters(1).Value = RCBSubreporte.SelectedItem.Text
                        ReportViewer1.Report.ReportParameters(2).Value = CInt(Session("CveEmpresa"))
                        ReportViewer1.Report.ReportParameters(3).Value = CInt(Session("CveEncuesta"))
                        ReportViewer1.Report.ReportParameters(6).Value = Session("Lenguaje")

                        BuildReport(NumReporte, ReportViewer1.Report)
                    Else
                        LlenarDepartamentos(RCBSubreporte.SelectedValue.ToString)
                        RCBLiderazgo.SelectedIndex = 0
                        RCBLiderazgo.Enabled = True
                        RCBTrabajador.SelectedIndex = 0
                        RCBTrabajador.Enabled = True
                        RCBDepartamento.Enabled = True
                        RCBSubreporte.Enabled = True
                        BVerReporte.Visible = True
                    End If
                ElseIf RCBReporte.SelectedValue = "R18" Then

                    Dim NumReporte As String
                    NumReporte = RCBSubreporte.SelectedValue.ToString
                    If RCBReporte.Visible = True Then
                        If NumReporte = 52 Then
                            ReportViewer1.Report = New R52
                        ElseIf NumReporte = 17 Then
                            ReportViewer1.Report = New R17
                        ElseIf NumReporte = 18 Then
                            ReportViewer1.Report = New R18
                        ElseIf NumReporte = 19 Then
                            ReportViewer1.Report = New R19
                        ElseIf NumReporte = 20 Then
                            ReportViewer1.Report = New R20
                        End If

                        ReportViewer1.Visible = True
                        ReportViewer1.ZoomPercent = 80

                        'Set the parameters
                        Dim NomEmpresa As String
                        NomEmpresa = Session("NombreEmpresa")

                        ReportViewer1.Report.ReportParameters(0).Value = NomEmpresa
                        ReportViewer1.Report.ReportParameters(1).Value = RCBSubreporte.SelectedItem.Text
                        ReportViewer1.Report.ReportParameters(2).Value = CInt(Session("CveEmpresa"))
                        ReportViewer1.Report.ReportParameters(3).Value = CInt(Session("CveEncuesta"))
                        ReportViewer1.Report.ReportParameters(6).Value = Session("Lenguaje")

                        BuildReport(NumReporte, ReportViewer1.Report)
                    Else
                        LlenarDepartamentos(RCBSubreporte.SelectedValue.ToString)
                        RCBLiderazgo.SelectedIndex = 0
                        RCBLiderazgo.Enabled = True
                        RCBTrabajador.SelectedIndex = 0
                        RCBTrabajador.Enabled = True
                        RCBDepartamento.Enabled = True
                        RCBSubreporte.Enabled = True
                        BVerReporte.Visible = True
                    End If

                End If

            ElseIf RCBSeccion.SelectedValue = "ENG" Then
                If RCBReporte.SelectedValue = "R1" Then
                    'SELECCIONO GRAFICAS
                    If RCBSubreporte.SelectedIndex = 0 Then 'Pedir que seleccione nuevamente, no hace nada
                        Cargar.Mensaje(RadAjaxManager1, "Seleccione un elemento para continuar")
                        Exit Sub
                    ElseIf RCBSubreporte.SelectedValue = "1" Then
                        RCBLiderazgo.Enabled = True
                    ElseIf RCBSubreporte.SelectedValue = "2" Then
                        LlenarDepartamentos("2")
                        RCBDepartamento.Enabled = True
                    ElseIf RCBSubreporte.SelectedValue = "4" Then
                        RCBLiderazgo.Enabled = True
                    ElseIf RCBSubreporte.SelectedValue = "5" Then
                        RCBLiderazgo.Enabled = True
                    ElseIf RCBSubreporte.SelectedValue = "6" Then
                        RCBLiderazgo.Enabled = True
                    End If
                ElseIf RCBReporte.SelectedValue = "R2" Then
                    'SELECCIONO CLIMA
                    If RCBSubreporte.SelectedValue = "8" Or RCBSubreporte.SelectedValue = "6" Or RCBSubreporte.SelectedValue = "11" Or RCBSubreporte.SelectedValue = "12" Then
                        RCBLiderazgo.Enabled = True
                    ElseIf RCBSubreporte.SelectedValue = "3" Then
                        LlenarDepartamentos("3")
                        RCBDepartamento.Enabled = True
                    Else
                        If RCBSubreporte.SelectedValue = "7" OrElse RCBSubreporte.SelectedValue = "10" OrElse RCBSubreporte.SelectedValue = "13" Then
                            LlenarDepartamentos(RCBSubreporte.SelectedValue)
                            RCBDepartamento.Enabled = True
                        End If
                    End If
                ElseIf RCBReporte.SelectedValue = "R6" Then
                    'SELECCIONO REPORTES DEMOGRAFICOS
                    MatrizDemograficos()
                    'RCBLiderazgo.Enabled = True
                End If
                RCBLiderazgo.SelectedIndex = 0
            End If
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Sub CARGARGRID(ByVal TABLAS As DataTable)
        RadGrid1.Columns.Clear()
        RadGrid1.MasterTableView.GroupByExpressions.Clear()
        RadGrid1.DataSource = TABLAS
        RadGrid1.DataBind()
        RadGrid1.Visible = True

        For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
            Dim colDecimal As GridBoundColumn
            colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
            colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            colDecimal.Visible = True
            If cont = 0 Or cont = 1 Then 'Quitamos campos
                colDecimal.Visible = False
            ElseIf cont = 2 Then 'Indice
                colDecimal.HeaderStyle.Width = 100
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            ElseIf cont = 3 Then 'CvePregunta
                colDecimal.HeaderStyle.Width = 100
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            ElseIf cont = 4 Then 'Pregunta
                colDecimal.HeaderStyle.Width = 400
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
            ElseIf cont = 5 Then 'Promedio
                colDecimal.HeaderStyle.Width = 100
                colDecimal.DataFormatString = "{0:N1}"
            End If
        Next

        RadGrid1.Rebind()
    End Sub

    Sub LlenarDepartamentos(ByVal Tipo As String)
        If RCBReporte.SelectedValue = "R1" Then
            'SELECCIONO GRAFICAS
            If Tipo = "2" Then 'Graficas por departamento (jpg)
                GenerearNombre(Tipo, ".JPG", False)
            End If
        ElseIf RCBReporte.SelectedValue = "R2" Then
            'SELECCIONO CLIMA
            If Tipo = "3" Then
                GenerearNombre(Tipo & Session("CveEmpresa"), ".XLS", False)
                If Session("Departamentos") <> "Y" Then
                    RCBDepartamento.Items.Add(New RadComboBoxItem("Por Nivel", "0"))
                    RCBDepartamento.Items.Add(New RadComboBoxItem(GETPALABRA("Todos los Departamentos"), "999"))
                End If
            ElseIf Tipo = "13" Then 'Reporte de comentarios o molestias
                GenerearNombre(Tipo, ".PDF", False)
                If Session("Departamentos") <> "Y" Then
                    RCBDepartamento.Items.Add(New RadComboBoxItem(GETPALABRA("Todos los Departamentos"), "999"))
                    If Session("BrasilKOF") = "Y" Then 'Si es Brasil agregamos los comentarios presenciales
                        RCBDepartamento.Items.Add(New RadComboBoxItem("Comentários Pesquisas presenciales", "R22Presencial.PDF"))
                    End If
                    If Session("TipoEncuesta") = "PRESENCIAL" And Session("AnioEstudio") <= 2016 Then
                        RCBDepartamento.Items.Clear()
                        RCBDepartamento.Items.Add(New RadComboBoxItem(GETPALABRA("[Seleccionar]"), "-1"))
                        RCBDepartamento.Items.Add(New RadComboBoxItem(GETPALABRA("Comentarios y/o sugerencias y molestias"), "R13Presencial.PDF"))
                    End If
                End If
            End If
        ElseIf RCBReporte.SelectedValue = "R3" Then
            'SELECCIONO LIDERAZGO
            If Tipo = "15" Then 'Reporte de deteccion de lideres generales  (pdf)
                GenerearNombre(Tipo, ".PDF", True)
                If Session("Departamentos") <> "Y" Then
                    RCBDepartamento.Items.Add(New RadComboBoxItem(GETPALABRA("Todos los Departamentos"), "999"))
                End If
            End If
        ElseIf RCBReporte.SelectedValue = "R-0" Then
            GenerearNombre(Tipo, "", False)
            If Session("Departamentos") <> "Y" Then
                RCBDepartamento.Items.Add(New RadComboBoxItem(GETPALABRA("Todos los Departamentos"), "999"))
            End If
        ElseIf RCBReporte.SelectedValue = "R14" Then
            GenerearNombre(Tipo, "", False)
            If Session("Departamentos") <> "Y" Then
                RCBDepartamento.Items.Add(New RadComboBoxItem(GETPALABRA("Todos los Departamentos"), "999"))
            End If
        End If

        RCBDepartamento.SelectedIndex = 0
        AlternateColor(RCBDepartamento)
    End Sub

    Protected Sub RCBDepartamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBDepartamento.SelectedIndexChanged
        Show(False)
        Lerror.Text = ""
        If RCBSeccion.SelectedValue = "CO" Then
            If RCBReporte.SelectedValue = "R1" Then
                'SELECCIONO GRAFICAS
                If RCBSubreporte.SelectedValue = "2" Then
                    Dim DT As DataTable = BuildData1(2)
                    Graficar(DT, "NOMTEMA", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text & ": " & CStr(RCBDepartamento.SelectedItem.Text), True)
                    Chart1.Visible = True
                End If
            ElseIf RCBReporte.SelectedValue = "R2" Then
                'SELECCIONO CLIMA
                If RCBSubreporte.SelectedValue = "3" Then
                    If RCBDepartamento.SelectedValue = "0" Then
                        BuildGrid("3_General")
                    ElseIf RCBDepartamento.SelectedValue = "999" Then
                        BuildGrid("3_Todos")
                    Else
                        BuildGrid(RCBSubreporte.SelectedValue)
                    End If
                ElseIf RCBSubreporte.SelectedValue = "13" Then
                    If RCBDepartamento.SelectedValue = "R22Presencial.PDF" Or RCBDepartamento.SelectedValue = "R13Presencial.PDF" Then
                        VerPdf(RCBDepartamento.SelectedValue)
                    Else
                        Dim NumReporte As String
                        NumReporte = RCBSubreporte.SelectedValue.ToString

                        ReportViewer1.Report = New R13

                        ReportViewer1.Visible = True
                        ReportViewer1.ZoomPercent = 80

                        'Set the parameters
                        Dim NomEmpresa As String
                        NomEmpresa = Session("NombreEmpresa")

                        Dim ds3 As New DataSet
                        Dim T_Comentarios As Integer
                        Dim T_Molestias As Integer


                        Dim P(1) As SqlParameter
                        P(0) = New SqlParameter("@TIPO", 78)
                        P(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                        ds3 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)

                        T_Comentarios = ds3.Tables(0).Rows(0).Item(1)
                        T_Molestias = ds3.Tables(0).Rows(1).Item(1)

                        ReportViewer1.Report.ReportParameters(0).Value = NomEmpresa
                        ReportViewer1.Report.ReportParameters(1).Value = RCBSubreporte.SelectedItem.Text
                        ReportViewer1.Report.ReportParameters(2).Value = CInt(Session("CveEmpresa"))
                        ReportViewer1.Report.ReportParameters(3).Value = CInt(Session("CveEncuesta"))
                        ReportViewer1.Report.ReportParameters(4).Value = T_Comentarios
                        ReportViewer1.Report.ReportParameters(5).Value = T_Molestias
                        ReportViewer1.Report.ReportParameters(6).Value = Session("Lenguaje")

                        BuildReport(NumReporte, ReportViewer1.Report)
                    End If
                End If
            ElseIf RCBReporte.SelectedValue = "R3" Then
                BVerReporte.Visible = True
            End If

        ElseIf RCBSeccion.SelectedValue = "ENG" Then
            If RCBReporte.SelectedValue = "R-0" Then
                If RCBDepartamento.SelectedValue <> "999" Then
                    BuildMatriz()
                Else
                    MatrizDepartamentos()
                End If
            ElseIf RCBReporte.SelectedValue = "R7" Or RCBReporte.SelectedValue = "R8" Then 'Grafica (Entra a RCBDepartamento_SelectedIndexChanged sin razon)
                Chart2.Visible = True
                Exit Sub
            ElseIf RCBReporte.SelectedValue = "R9" Then 'Reporte (Entra a RCBDepartamento_SelectedIndexChanged sin razon)
                RadGrid1.Visible = True
                Exit Sub
            Else
                RCBLiderazgo.Enabled = True
                RCBLiderazgo.SelectedIndex = 0
            End If

        ElseIf RCBSeccion.SelectedValue = "RF" Then
            If RCBReporte.SelectedValue = "R14" Then
                If RCBDepartamento.SelectedValue <> "999" Then
                    CalificacionFEMSA("2")
                Else
                    CalificacionFEMSA("3")
                End If

            End If
        End If
    End Sub

    Sub VerPdf(ByVal Archivo As String)
        Try
            If File.Exists(Session("RUTA_DEF") & Archivo) = True Then
                ShowPdf1.FilePath = Session("RUTA_DEF") & Archivo
                ShowPdf1.Visible = True
            Else
                Lerror.Text = "No se encuentra el archivo: " & Archivo
            End If
        Catch ex As Exception
            Lerror.Text = ex.Message & ex.Source & ex.StackTrace
            Lerror.Visible = True
        End Try
    End Sub

    Sub GenerearNombre(ByVal Pre As String, ByVal Ext As String, ByVal Menciones As Boolean) 'OK
        RCBDepartamento.Items.Clear()
        Dim ds As New DataSet
        ' Dim ExtraerDepartamentos As String
        If Session("Departamentos") = "Y" Then
            If Menciones = False Then
                'SIN MENCIONES
                Dim P(3) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 79)
                P(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                P(2) = New SqlParameter("@USUARIO", Session("NumUsuario"))
                P(3) = New SqlParameter("@NUMPERFIL", Session("NUMPERFIL"))
                ' ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)
                '  ExtraerDepartamentos = "Select CveDepto,NomDepto From TblHistoria_Departamento Where CveEmpresa=" & Session("CveEmpresa") & " and CveDepto In(Select Numrastreo from TblPerfilAgrupacion where NumUsuario=" & Session("NumUsuario") & " and TipoAgrupacion=12) and AnioEstudio=dbo.GETANIOVIGENTE(CveEmpresa, " & Session("NUMPERFIL") & ")"
                ' ExtraerDepartamentos = ExtraerDepartamentos & " and Cvedepto<>9000 order by Cvedepto asc"
                Cargar.ComboParametros(RCBDepartamento, "SP_CONSULTAS_ENTREGAVIRTUAL", P, "NomDepto", "CveDepto", 2, True, Session("Lenguaje"))
            Else
                Dim P(3) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 80)
                P(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                P(2) = New SqlParameter("@USUARIO", Session("NumUsuario"))
                P(3) = New SqlParameter("@NUMPERFIL", Session("NUMPERFIL"))
                ' ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)
                ' ExtraerDepartamentos = "Select CveDepto,NomDepto From TblHistoria_Departamento Where CveEmpresa=" & Session("CveEmpresa") & " and CveDepto In(Select Numrastreo from TblPerfilAgrupacion where NumUsuario=" & Session("NumUsuario") & " and TipoAgrupacion=12) and AnioEstudio=dbo.GETANIOVIGENTE(CveEmpresa, " & Session("NUMPERFIL") & ")"
                ' ExtraerDepartamentos = ExtraerDepartamentos & " Order by Cvedepto asc"
                Cargar.ComboParametros(RCBDepartamento, "SP_CONSULTAS_ENTREGAVIRTUAL", P, "NomDepto", "CveDepto", 2, True, Session("Lenguaje"))
            End If


        Else

            If Menciones = False Then
                'SIN MENCIONES
                Dim P(2) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 81)
                P(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                P(2) = New SqlParameter("@NUMPERFIL", Session("NUMPERFIL"))
                'ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)
                'ExtraerDepartamentos = "Select CveDepto,NomDepto From TblHistoria_Departamento Where CveEmpresa=" & Session("CveEmpresa") & " and AnioEstudio=dbo.GETANIOVIGENTE(CveEmpresa, " & Session("NUMPERFIL") & ")"
                'ExtraerDepartamentos = ExtraerDepartamentos & " and Cvedepto<>9000 order by Cvedepto asc"
                Cargar.ComboParametros(RCBDepartamento, "SP_CONSULTAS_ENTREGAVIRTUAL", P, "NomDepto", "CveDepto", 2, True, Session("Lenguaje"))
            Else
                Dim P(2) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 82)
                P(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                P(2) = New SqlParameter("@NUMPERFIL", Session("NUMPERFIL"))
                ' ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)
                ' ExtraerDepartamentos = "Select CveDepto,NomDepto From TblHistoria_Departamento Where CveEmpresa=" & Session("CveEmpresa") & " and AnioEstudio=dbo.GETANIOVIGENTE(CveEmpresa, " & Session("NUMPERFIL") & ")"
                ' ExtraerDepartamentos = ExtraerDepartamentos & " Order by Cvedepto asc"
                Cargar.ComboParametros(RCBDepartamento, "SP_CONSULTAS_ENTREGAVIRTUAL", P, "NomDepto", "CveDepto", 2, True, Session("Lenguaje"))
            End If
        End If





        'RCBDepartamento.DataSource = ds.Tables(0)
        'RCBDepartamento.DataTextField = "NomDepto"
        'RCBDepartamento.DataValueField = "CveDepto"
        'RCBDepartamento.DataBind()


        'Cargar.ComboSentenciaTxt(RCBDepartamento, ExtraerDepartamentos, "NomDepto", "CveDepto", 2, False, Session("Lenguaje"))
    End Sub

    Sub Graficar(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)
        Chart1.PlotArea.Series.Clear()
        Chart1.DataSource = Datos
        Chart1.PlotArea.YAxis.MaxValue = 110
        Chart1.PlotArea.YAxis.MinValue = 0
        Chart1.PlotArea.XAxis.TitleAppearance.Text = AxisX
        Chart1.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10
        Chart1.PlotArea.XAxis.LabelsAppearance.RotationAngle = -90
        Chart1.PlotArea.YAxis.TitleAppearance.Text = AxisY
        Chart1.PlotArea.YAxis.TitleAppearance.TextStyle.FontSize = 11
        Chart1.PlotArea.Appearance.FillStyle.BackgroundColor = Color.WhiteSmoke

        Chart1.ChartTitle.Text = Titulo1 & "\n" & Titulo2
        Chart1.ChartTitle.Appearance.TextStyle.Bold = True

        Chart1.PlotArea.XAxis.DataLabelsField = CStr(ValorX)
        Chart1.DataBind()

        Dim ChartBar As New ColumnSeries
        ChartBar.LabelsAppearance.DataFormatString = "{0:N1}"
        ChartBar.LabelsAppearance.TextStyle.Bold = True
        ChartBar.TooltipsAppearance.Visible = True
        ChartBar.TooltipsAppearance.BackgroundColor = Color.White
        ChartBar.TooltipsAppearance.ClientTemplate = "#=category#"
        ChartBar.Gap = 0.5

        Dim VAL As Double = 0.0
        Dim TEXTO As String
        For i As Integer = 0 To Datos.Rows.Count - 1
            Dim Barra As New SeriesItem
            If RCBSeccion.SelectedValue = "RF" Then
                VAL = FormatNumber(Datos.Rows(i).Item(3), 1)
                TEXTO = Datos.Rows(i).Item(1)
            Else
                VAL = FormatNumber(Datos.Rows(i).Item(5), 1)
                TEXTO = Datos.Rows(i).Item(1)
            End If

            If TEXTO.Length > 25 Then
                Chart1.PlotArea.XAxis.LabelsAppearance.Visible = False
            End If
            Barra.TooltipValue = TEXTO
            Barra.YValue = VAL

            If VAL <= 69.9999 Then
                Barra.BackgroundColor = System.Drawing.Color.DarkRed
            ElseIf VAL >= 70.0 And VAL <= 79.9999 Then
                Barra.BackgroundColor = System.Drawing.Color.Goldenrod
            ElseIf VAL >= 80.0 And VAL <= 89.9999 Then
                Barra.BackgroundColor = System.Drawing.Color.DarkBlue
            ElseIf VAL >= 90.0 Then
                Barra.BackgroundColor = System.Drawing.Color.DarkGreen
            End If

            ChartBar.Items.Add(Barra)
        Next

        Chart1.PlotArea.Series.Add(ChartBar)
        Chart1.Visible = True


        'Chart1.DataSource = Datos
        'Chart1.Series(0).XValueMember = CStr(ValorX)
        'Chart1.Series(0).YValueMembers = ValorY
        'Chart1.ChartAreas(0).Area3DStyle.Enable3D = TresD
        'Chart1.DataBind()
        'Chart1.ChartAreas(0).AxisY.Maximum = 110
        'Chart1.ChartAreas(0).AxisY.Minimum = 0
        'Chart1.ChartAreas(0).AxisX.LabelStyle.IsEndLabelVisible = True
        'Chart1.ChartAreas(0).AxisX.Title = AxisX
        'Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90
        'Chart1.ChartAreas(0).AxisY.Title = AxisY
        'Chart1.Titles(0).Text = Titulo1
        'Chart1.Titles(1).Text = Titulo2


        'Dim annotation As New TextAnnotation()
        'annotation.Text = GETPALABRA("Actualizada") & ": " & Now.Date.ToShortDateString
        'annotation.ForeColor = Color.Black
        'annotation.X = 80
        'annotation.Y = 0
        'annotation.Font = New Font("Tahoma", 8)
        'Chart1.Annotations.Add(annotation)

        'Dim VAL As Double = 0.0
        'For I As Integer = 0 To Datos.Rows.Count - 1
        '    If RCBSeccion.SelectedValue = "RF" Then
        '        VAL = Datos.Rows(I).Item(3)
        '    Else
        '        VAL = Datos.Rows(I).Item(5)
        '    End If
        '    Chart1.Series(0).Points(I).ToolTip = Datos.Rows(I).Item(3)
        '    If vPostBack = True Then
        '        Chart1.Series(0).Points(I).PostBackValue = Datos.Rows(I).Item(2)
        '        'Else
        '        '    Chart1.Series(0).Points(I).PostBackValue = -1
        '    End If

        '    VAL = Math.Round(VAL, 1) 'Redondea a 1 decimal para los colores

        '    If VAL <= 69.9999 Then
        '        Chart1.Series(0).Points(I).Color = System.Drawing.Color.Red
        '    ElseIf VAL >= 70.0 And VAL <= 79.9999 Then
        '        Chart1.Series(0).Points(I).Color = System.Drawing.Color.Yellow
        '    ElseIf VAL >= 80.0 And VAL <= 89.9999 Then
        '        Chart1.Series(0).Points(I).Color = System.Drawing.Color.Blue
        '    ElseIf VAL >= 90.0 Then
        '        Chart1.Series(0).Points(I).Color = System.Drawing.Color.Green
        '    End If
        'Next
    End Sub

    'Private Sub Chart1_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles Chart1.Click
    '    If RCBReporte.SelectedValue = "R1" Then
    '        'SELECCIONO GRAFICAS
    '        If e.PostBackValue = -1 Then
    '            If RCBSubreporte.SelectedValue = "4" Then
    '                Dim DT As DataTable = BuildData1(3)
    '                Graficar(DT, "INDICE", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text, False)
    '                CARGARGRID(DT)
    '            ElseIf RCBSubreporte.SelectedValue = "5" Then
    '                Dim DT As DataTable = BuildData1(4)
    '                Graficar(DT, "INDICE", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text, False)
    '                CARGARGRID(DT)
    '            End If
    '        Else
    '            If RCBSubreporte.SelectedValue = "2" Then
    '                Dim DT As DataTable = BuildData1(2)
    '                Graficar(DT, "NOMTEMA", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text & " de : " & RCBDepartamento.SelectedItem.Text, True)
    '                BuildData2(e.PostBackValue)
    '            Else
    '                Dim DT As DataTable = BuildData1(1)
    '                Graficar(DT, "DESCTEMA", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text, True)
    '                BuildData2(e.PostBackValue)
    '            End If
    '        End If
    '    End If
    '    Chart1.Visible = True
    'End Sub

    Function BuildData1(ByVal Tipo As Integer) As DataTable 'Graficas
        Dim ds As New DataSet

        If RCBSeccion.SelectedValue = "CO" Then
            Dim p(4) As SqlParameter
            p(0) = New SqlParameter("@TIPO", CInt(Tipo))
            p(1) = New SqlParameter("@CVEEMPRESA", CInt(Session("CveEmpresa")))
            p(2) = New SqlParameter("@CVEENCUESTA", CInt((Session("CveEncuesta"))))
            If Tipo = 2 Then
                p(3) = New SqlParameter("@CVEDEPTO", RCBDepartamento.SelectedValue)
            Else
                p(3) = New SqlParameter("@CVEDEPTO", 0)
            End If
            p(4) = New SqlParameter("@IDIOMA", Session("Idioma"))
            'Dim ds As New DataSet
            ds = DatosBD.FuncionConPar("SP_VER_GRAFICAS", p, "")
            Session("ChartDT") = ds.Tables(0)
        ElseIf RCBSeccion.SelectedValue = "ENG" Then
            Dim p(4) As SqlParameter
            p(0) = New SqlParameter("@TIPO", CInt(Tipo))
            p(1) = New SqlParameter("@CVEEMPRESA", CInt(Session("CveEmpresa")))
            p(2) = New SqlParameter("@CVEENCUESTA", CInt((Session("CveEncuesta"))))
            If Tipo = 2 Then
                p(3) = New SqlParameter("@CVEDEPTO", RCBDepartamento.SelectedValue)
            Else
                p(3) = New SqlParameter("@CVEDEPTO", 0)
            End If
            p(4) = New SqlParameter("@IDPERFILEFECTIVIDAD", RCBLiderazgo.SelectedValue)

            'p(5) = New SqlParameter("@IDIOMA", Session("Lenguaje"))

            ds = DatosBD.FuncionConPar("SP_EngVer_Graficas", p, "")
            Session("ChartDT") = ds.Tables(0)
        End If

        Return ds.Tables(0)
    End Function

    Sub BuildData2(ByVal Tema As Integer)
        Dim ds As New DataSet
        RadGrid1.Columns.Clear()
        If RCBSeccion.SelectedValue = "CO" Then
            Dim CveDeptoSel As Integer
            If RCBDepartamento.Enabled = True Then
                CveDeptoSel = RCBDepartamento.SelectedValue
            Else
                CveDeptoSel = 999
            End If

            Dim p(4) As SqlParameter
            p(0) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
            p(1) = New SqlParameter("@CVEENCUESTA", Session("CveEncuesta"))
            p(2) = New SqlParameter("@CVETEMA", Tema)
            p(3) = New SqlParameter("@CVEDEPTO", CveDeptoSel)
            p(4) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))

            'Dim ds As New DataSet
            ds = DatosBD.FuncionConPar("SP_VER_PREGUNTAS", p, "")

        ElseIf RCBSeccion.SelectedValue = "ENG" Then
            Dim CveDeptoSel As Integer
            If RCBDepartamento.Enabled = True Then
                CveDeptoSel = RCBDepartamento.SelectedValue
            Else
                CveDeptoSel = 999
            End If

            Dim p(5) As SqlParameter
            p(0) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
            p(1) = New SqlParameter("@CVEENCUESTA", Session("CveEncuesta"))
            p(2) = New SqlParameter("@CVETEMA", Tema)
            p(3) = New SqlParameter("@CVEDEPTO", CveDeptoSel)
            p(4) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            p(5) = New SqlParameter("@IDPERFILEFECTIVIDAD", RCBLiderazgo.SelectedValue)

            ds = DatosBD.FuncionConPar("SP_EngVer_Preguntas", p, "")
        End If

        Dim templateColumn As New GridTemplateColumn()
        templateColumn.HeaderStyle.Width = 50
        templateColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'templateColumn.ItemTemplate = New MyTemplate("Tipo")
        templateColumn.HeaderText = "TIPO"
        RadGrid1.MasterTableView.Columns.Add(templateColumn)

        RadGrid1.MasterTableView.GroupByExpressions.Clear()
        RadGrid1.DataSource = ds.Tables(0)
        RadGrid1.DataBind()
        RadGrid1.Visible = True

        For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
            Dim colDecimal As GridBoundColumn
            colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
            colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            colDecimal.Visible = True
            If cont = 0 Or cont = 1 Then 'Quitamos campos
                colDecimal.Display = False
            ElseIf cont = 2 Then 'Indice
                colDecimal.HeaderStyle.Width = 100
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
            ElseIf cont = 3 Then 'CvePregunta
                colDecimal.HeaderStyle.Width = 50
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            ElseIf cont = 4 Then 'Pregunta
                colDecimal.HeaderStyle.Width = 400
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
            ElseIf cont = 5 Then 'Promedio
                colDecimal.HeaderStyle.Width = 100
                colDecimal.DataFormatString = "{0:N1}"
            ElseIf cont = 6 Then 'CveCategoria
                colDecimal.Display = False
            End If
        Next

        RadGrid1.Rebind()
    End Sub

    Sub BuildData3(ByVal Tipo As Integer) 'Reporte Funcion Sindical
        RadGrid1.Columns.Clear()

        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
        p(1) = New SqlParameter("@CVEENCUESTA", Session("CveEncuesta"))

        Dim ds As New DataSet
        ds = DatosBD.FuncionConPar("SP_VER_NOVALORIZADAS", p, "")
        RadGrid1.DataSource = ds.Tables(0)
        RadGrid1.DataBind()
        RadGrid1.Visible = True

        For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
            Dim colDecimal As GridBoundColumn
            colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
            colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            colDecimal.Visible = True
            If cont = 0 Or cont = 1 Then 'Quitamos campos
                colDecimal.Visible = False
            ElseIf cont = 2 Then 'Indice
                colDecimal.HeaderStyle.Width = 100
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
            ElseIf cont = 3 Then 'CvePregunta
                colDecimal.HeaderStyle.Width = 100
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            ElseIf cont = 4 Then 'Pregunta
                colDecimal.HeaderStyle.Width = 400
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
            ElseIf cont = 5 Then 'Promedio
                colDecimal.HeaderStyle.Width = 100
                colDecimal.DataFormatString = "{0:N1}"
            End If
        Next

        RadGrid1.Rebind()
    End Sub

    Protected Sub BVerReporte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BVerReporte.Click
        Dim NumReporte As String
        NumReporte = RCBSubreporte.SelectedValue.ToString

        ReportViewer1.Report = New R15

        ReportViewer1.Visible = True
        ReportViewer1.ZoomPercent = 80

        'Set the parameters
        Dim NomEmpresa As String
        NomEmpresa = Session("NombreEmpresa")

        ReportViewer1.Report.ReportParameters(0).Value = NomEmpresa
        ReportViewer1.Report.ReportParameters(1).Value = RCBSubreporte.SelectedItem.Text
        ReportViewer1.Report.ReportParameters(2).Value = CInt(Session("CveEmpresa"))
        ReportViewer1.Report.ReportParameters(3).Value = CInt(Session("CveEncuesta"))
        ReportViewer1.Report.ReportParameters(6).Value = Session("Lenguaje")

        BuildReport(NumReporte, ReportViewer1.Report)

        Lerror.Text = ""

    End Sub

    Sub AlternateColor(ByVal Combo As RadComboBox)
        'For i As Integer = 0 To Combo.Items.Count - 1
        '    If i Mod 2 <> 0 Then
        '        Combo.Items.Item(i).BackColor = Color.WhiteSmoke
        '    End If
        'Next
    End Sub

    Private Sub BuildReport(ByVal NumReporte As String, ByVal reportToExport As Telerik.Reporting.Report)
        Try
            Dim Stored As String
            Dim ds As New DataSet
            'psicosociales
            If NumReporte = 51 Or NumReporte = 52 Or NumReporte = 53 Then
                Stored = "sp_Reportes_Psicosociales"
            Else
                Stored = "sp_Reportes_Liderazgo"
            End If
            If NumReporte = 15 Then
                Dim p(6) As SqlParameter
                p(0) = New SqlParameter("@CveEmpresa", Session("CveEmpresa"))
                p(1) = New SqlParameter("@CveEncuesta", Session("CveEncuesta"))
                p(2) = New SqlParameter("@CveReporte", NumReporte)
                p(3) = New SqlParameter("@Subreporte", RCBDepartamento.SelectedValue)
                p(4) = New SqlParameter("@TipoLiderazgo", RCBLiderazgo.SelectedValue)
                p(5) = New SqlParameter("@TipoTrabajador", RCBTrabajador.SelectedValue)
                p(6) = New SqlParameter("@CvePerfil", Session("NUMPERFIL"))

                ds = DatosBD.FuncionConPar(Stored, p, "", "tblReporte")

                If Not ds Is Nothing Then
                    ReportViewer1.Report.Reports(0).DataSource = ds.Tables("tblReporte")
                    ReportViewer1.RefreshReport()
                End If
            ElseIf NumReporte = 13 And RCBDepartamento.SelectedValue <> "999" Then
                Dim p(5) As SqlParameter
                p(0) = New SqlParameter("@CveEmpresa", Session("CveEmpresa"))
                p(1) = New SqlParameter("@CveEncuesta", Session("CveEncuesta"))
                p(2) = New SqlParameter("@CveReporte", NumReporte)
                p(3) = New SqlParameter("@SubReporte", RCBDepartamento.SelectedValue)
                p(4) = New SqlParameter("@CvePerfil", Session("NUMPERFIL"))
                p(5) = New SqlParameter("@Idioma", Session("Lenguaje"))

                ds = DatosBD.FuncionConPar(Stored, p, "", "tblReporte")
                ReportViewer1.Report.Reports(0).DataSource = ds.Tables("tblReporte")
                ReportViewer1.RefreshReport()
            ElseIf NumReporte = 39 Then
                Dim p(3) As SqlParameter
                p(0) = New SqlParameter("@TIPO", 1)
                p(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                p(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
                p(3) = New SqlParameter("@USUARIO", Session("USUARIO"))

                ds = DatosBD.FuncionConPar("SP_EngMatrizEf", p, Lerror.Text, "tblReporte")
                Session("DSMatrizEfectividad") = ds
                ReportViewer1.Report.Reports(0).DataSource = ds.Tables("tblReporte")
                ReportViewer1.RefreshReport()
            ElseIf NumReporte = 38 Then
                Dim p(4) As SqlParameter
                p(0) = New SqlParameter("@TIPO", 2)
                p(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                p(2) = New SqlParameter("@CVEDEPTO", RCBDepartamento.SelectedValue)
                p(3) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
                p(4) = New SqlParameter("@USUARIO", Session("USUARIO"))

                ds = DatosBD.FuncionConPar("SP_EngMatrizEf", p, Lerror.Text, "tblReporte")
                Session("DSMatrizEfectividad") = ds
                ReportViewer1.Report.Reports(0).DataSource = ds.Tables("tblReporte")
                ReportViewer1.RefreshReport()
            Else
                'OCUPO ESTA SALIDA CON NUMREPORTE NUEVO
                Dim p(4) As SqlParameter
                p(0) = New SqlParameter("@CveEmpresa", Session("CveEmpresa"))
                p(1) = New SqlParameter("@CveEncuesta", Session("CveEncuesta"))
                p(2) = New SqlParameter("@CveReporte", NumReporte)
                p(3) = New SqlParameter("@CvePerfil", Session("NUMPERFIL"))
                p(4) = New SqlParameter("@Idioma", Session("Lenguaje"))

                ds = DatosBD.FuncionConPar(Stored, p, "", "tblReporte")
                ReportViewer1.Report.Reports(0).DataSource = ds.Tables("tblReporte")
                ReportViewer1.RefreshReport()
            End If

            Session("DTPantalla") = ds.Tables(0)
            RBPantalla.Attributes.Add("OnClick", "window.radopen('PantallaCompleta.ASPX?T=Liderazgo&R=" & NumReporte & "','RadDetalles');return false;")
            RBPantalla.Visible = True

            Response.AppendHeader("X-UA-Compatible", "IE=edge")
            'EXPORTA EL REPORTE AUTOMATICAMENTE
            'Dim REPO As Telerik.Reporting.Report = reportToExport
            'REPO.DataSource = ds.Tables(0)

            'Dim reportProcessor As New Processing.ReportProcessor()
            ''Dim result As Processing.RenderingResult = reportProcessor.RenderReport("PDF", REPO, Nothing)
            ''Dim fileName As String = result.DocumentName + ".pdf"
            'Dim result As Processing.RenderingResult = reportProcessor.RenderReport("XLS", REPO, Nothing)
            'Dim fileName As String = result.DocumentName + ".xls"
            'Response.Clear()
            'Response.ContentType = result.MimeType
            'Response.Cache.SetCacheability(HttpCacheability.Private)
            'Response.Expires = -1
            'Response.Buffer = True
            'Response.AddHeader("Content-Disposition", String.Format("{0};FileName=""{1}""", "attachment", fileName))
            'Response.BinaryWrite(result.DocumentBytes)
            'Response.End()

        Catch ex As Exception
            Lerror.Text = "No existe información para este reporte."
        End Try
    End Sub

    Private Sub BuildGrid(ByVal Reporte As String)
        Dim DS As DataSet
        Dim Stored As String
        RadGrid1.Columns.Clear()

        If RCBSeccion.SelectedValue = "CO" Then
            If Reporte = "3" Then 'Si es de Graficas
                Stored = "sp_RepDeptoNivelPreg"
                Dim p(4) As SqlParameter
                p(0) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                p(1) = New SqlParameter("@CVEENCUESTA", Session("CveEncuesta"))
                p(2) = New SqlParameter("@CVEDEPTO", RCBDepartamento.SelectedValue)
                p(3) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
                p(4) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
                DS = DatosBD.FuncionConPar(Stored, p, "")


               

                If Session("Lenguaje") = "en-US" Then
                    DS.Tables(0).Columns(2).ColumnName = "Code"
                    DS.Tables(0).Columns(3).ColumnName = "Questión"
                ElseIf Session("Lenguaje") = "pt-BR" Then


                ElseIf Session("Lenguaje") = "es-MX" Then

                End If


                RadGrid1.DataSource = DS.Tables(0)


            Else
                If Reporte = "3_General" Then
                    Stored = "SP_RepNivelPreg"
                ElseIf Reporte = "3_Todos" Then
                    Stored = "SP_RepDeptoPreg"
                ElseIf Reporte = "6" Then
                    Stored = "sp_RepTemaReactivo"
                ElseIf Reporte = "8" Then
                    Stored = "sp_RepDeptoNivelTema"
                ElseIf Reporte = "11" Then
                    Stored = "sp_RepSindicalizadosTema"
                ElseIf Reporte = "12" Then
                    Stored = "sp_RepNoValorizados"
                ElseIf Reporte = "21" Then
                    Stored = "sp_ReporteCV" '"sp_RepSicav"
                ElseIf Reporte = "22" Then
                    Stored = "SP_RepCultura"
                ElseIf Reporte = "23" Then
                    Stored = "SP_RepEdadPreg"
                ElseIf Reporte = "24" Then
                    Stored = "SP_RepAntiguedadPreg"
                ElseIf Reporte = "25" Then
                    Stored = "SP_RepEstudiosPreg"
                ElseIf Reporte = "26" Then
                    Stored = "SP_RepGeneroPreg"
                ElseIf Reporte = "31" Then
                    Stored = "SP_RepDeptoPreg_Anterior"
                ElseIf Reporte = "49" Then
                    Stored = "sp_ReporteCV"
                ElseIf Reporte = "50" Then
                    Stored = "sp_ReporteDS"
                End If

                Dim p(3) As SqlParameter
                p(0) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                p(1) = New SqlParameter("@CVEENCUESTA", Session("CveEncuesta"))
                p(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
                p(3) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
                DS = DatosBD.FuncionConPar(Stored, p, "")

                If Session("Lenguaje") = "en-US" Then
                    If Stored = "sp_RepTemaReactivo" Then
                        DS.Tables(0).Columns(2).ColumnName = "Code"
                        DS.Tables(0).Columns(3).ColumnName = "Questión"
                        DS.Tables(0).Columns(4).ColumnName = "Answered questions"
                        DS.Tables(0).Columns(5).ColumnName = "Weighted index"


                    ElseIf Stored = "sp_RepDeptoNivelTema" Then
                        DS.Tables(0).Columns(2).ColumnName = "WAC"
                        DS.Tables(0).Columns(3).ColumnName = "Work Area"

                    ElseIf Stored = "sp_RepSindicalizadosTema" Then
                        DS.Tables(0).Columns(2).ColumnName = "Code"
                        DS.Tables(0).Columns(3).ColumnName = "Questión"
                        DS.Tables(0).Columns(4).ColumnName = "Unionized"
                        DS.Tables(0).Columns(5).ColumnName = "Non Unionized"
                        DS.Tables(0).Columns(6).ColumnName = "Total WorkCenter"

                    ElseIf Stored = "sp_RepNoValorizados" Then
                        DS.Tables(0).Columns(2).ColumnName = "WAC"
                        DS.Tables(0).Columns(3).ColumnName = "Work Area"
                    ElseIf Stored = "SP_RepDeptoPreg_Anterior" Then
                        DS.Tables(0).Columns(2).ColumnName = "Code"
                        DS.Tables(0).Columns(3).ColumnName = "Questión"
                    ElseIf Stored = "SP_RepEdadPreg" Then
                        DS.Tables(0).Columns(2).ColumnName = "Code"
                        DS.Tables(0).Columns(3).ColumnName = "Questión"

                    ElseIf Stored = "SP_RepAntiguedadPreg" Then
                        DS.Tables(0).Columns(2).ColumnName = "Code"
                        DS.Tables(0).Columns(3).ColumnName = "Questión"
                    ElseIf Stored = "SP_RepEstudiosPreg" Then
                        DS.Tables(0).Columns(2).ColumnName = "Code"
                        DS.Tables(0).Columns(3).ColumnName = "Questión"

                    ElseIf Stored = "SP_RepGeneroPreg" Then
                        DS.Tables(0).Columns(2).ColumnName = "Code"
                        DS.Tables(0).Columns(3).ColumnName = "Questión"
                        DS.Tables(0).Columns(4).ColumnName = "Female"
                        DS.Tables(0).Columns(5).ColumnName = "Male"

                    ElseIf Stored = "SP_RepCultura" Then
                        DS.Tables(0).Columns(2).ColumnName = "Code"
                        DS.Tables(0).Columns(3).ColumnName = "Questión"
                        DS.Tables(0).Columns(4).ColumnName = "Weighted index"

                    End If
                ElseIf Session("Lenguaje") = "pt-BR" Then


                ElseIf Session("Lenguaje") = "es-MX" Then

            End If



            RadGrid1.DataSource = DS.Tables(0)
            End If

        ElseIf RCBSeccion.SelectedValue = "CV" Or RCBSeccion.SelectedValue = "DS" Then
            If Reporte = "49" Then

                Stored = "sp_ReporteCV"
            ElseIf Reporte = "50" Then

                Stored = "sp_ReporteDS"
            End If

            Dim p(3) As SqlParameter
            p(0) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
            p(1) = New SqlParameter("@CVEENCUESTA", Session("CveEncuesta"))
            p(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            p(3) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
            DS = DatosBD.FuncionConPar(Stored, p, "")

            If Session("Lenguaje") = "en-US" Then
                If Stored = "sp_ReporteCV" Then
                    DS.Tables(0).Columns(2).ColumnName = "Code"
                    DS.Tables(0).Columns(3).ColumnName = "Questión"
                    DS.Tables(0).Columns(4).ColumnName = "Weighted index"

                End If
            ElseIf Session("Lenguaje") = "pt-BR" Then


            ElseIf Session("Lenguaje") = "es-MX" Then

            End If

            RadGrid1.DataSource = DS.Tables(0)
        End If

            Dim expression1 As GridGroupByExpression
            RadGrid1.MasterTableView.GroupByExpressions.Clear()

            RadGrid1.DataBind()

        If Reporte = "6" Then
            For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                Dim colDecimal As GridBoundColumn
                colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.Visible = True
                If cont = 0 Or cont = 1 Then 'Quitamos el tema de la tabla
                    colDecimal.Visible = False
                ElseIf cont = 2 Then 'CvePregunta
                    colDecimal.HeaderStyle.Width = 50
                ElseIf cont = 3 Then 'DescPregunta
                    colDecimal.HeaderStyle.Width = 400
                    colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                ElseIf cont = 4 Then 'Personas
                    colDecimal.HeaderStyle.Width = 50
                ElseIf cont = 5 Then 'Promedio
                    colDecimal.HeaderStyle.Width = 100
                    colDecimal.DataFormatString = "{0:N1}"
                End If
            Next
            expression1 = GridGroupByExpression.Parse("NOMTEMA [" & GETPALABRA("Tema") & "] GROUP BY CVETEMA")
        ElseIf Reporte = "8" Then
            For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                Dim colDecimal As GridBoundColumn
                colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.Visible = True
                If cont >= 5 Then
                    colDecimal.HeaderStyle.Width = 100
                    If cont Mod 2 = 1 Then
                        colDecimal.DataFormatString = "{0:N1}"
                    End If
                Else
                    If cont = 0 Or cont = 1 Then 'Quitamos el tema de la tabla
                        colDecimal.Visible = False
                    ElseIf cont = 2 Then
                        colDecimal.HeaderStyle.Width = 50
                    ElseIf cont = 3 Then
                        colDecimal.HeaderStyle.Width = 150
                        colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    Else
                        colDecimal.HeaderStyle.Width = 150
                    End If
                End If
            Next
            expression1 = GridGroupByExpression.Parse("NOMTEMA [" & GETPALABRA("Tema") & "] GROUP BY CVETEMA")
        ElseIf Reporte = "11" Then
            For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                Dim colDecimal As GridBoundColumn
                colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.Visible = True
                If cont = 0 Or cont = 1 Then 'Quitamos el tema de la tabla
                    colDecimal.Visible = False
                ElseIf cont = 2 Then 'CvePregunta
                    colDecimal.HeaderStyle.Width = 50
                ElseIf cont = 3 Then 'DescPregunta
                    colDecimal.HeaderStyle.Width = 400
                    colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                ElseIf cont = 4 Then 'Sindicalizados
                    colDecimal.HeaderStyle.Width = 100
                    colDecimal.DataFormatString = "{0:N1}"
                ElseIf cont = 5 Then 'No Sindicalizados
                    colDecimal.HeaderStyle.Width = 100
                    colDecimal.DataFormatString = "{0:N1}"
                ElseIf cont = 6 Then 'Total Empresa
                    colDecimal.HeaderStyle.Width = 100
                    colDecimal.DataFormatString = "{0:N1}"
                End If
            Next
            expression1 = GridGroupByExpression.Parse("NOMTEMA [" & GETPALABRA("Tema") & "] GROUP BY CVETEMA")
        ElseIf Reporte = "12" Then
            For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                Dim colDecimal As GridBoundColumn
                colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.Visible = True
                If cont = 0 Or cont = 1 Then 'Quitamos las preguntas
                    colDecimal.Visible = False
                ElseIf cont = 2 Then 'CveDepto
                    colDecimal.HeaderStyle.Width = 50
                ElseIf cont = 3 Then 'NomDepto
                    colDecimal.HeaderStyle.Width = 100
                    colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                ElseIf cont >= 4 Then 'Respuestas
                    colDecimal.HeaderStyle.Width = 100
                End If
            Next
            expression1 = GridGroupByExpression.Parse("PREGUNTA [P ] GROUP BY CVEPREGUNTA")
        ElseIf Reporte = "3" Then
            For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                Dim colDecimal As GridBoundColumn
                colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.Visible = True
                If cont >= 4 Then
                    colDecimal.HeaderStyle.Width = 100
                    colDecimal.DataFormatString = "{0:N1}"
                Else
                    If cont = 0 Or cont = 1 Then 'Quitamos el tema de la tabla
                        colDecimal.Visible = False
                    ElseIf cont = 2 Then
                        colDecimal.HeaderStyle.Width = 50
                    Else
                        colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                        colDecimal.HeaderStyle.Width = 150
                    End If
                End If
            Next
            expression1 = GridGroupByExpression.Parse("NOMTEMA [" & GETPALABRA("Tema") & "] GROUP BY CVETEMA")
        ElseIf Reporte = "3_Todos" OrElse Reporte = "3_General" OrElse Reporte = "23" OrElse Reporte = "24" OrElse Reporte = "25" OrElse Reporte = "26" OrElse Reporte = "31" Then
            For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                Dim colDecimal As GridBoundColumn
                colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.Visible = True
                If cont >= 4 Then
                    colDecimal.HeaderStyle.Width = 100
                    colDecimal.DataFormatString = "{0:N1}"
                Else
                    If cont = 0 Or cont = 1 Then 'Quitamos el tema de la tabla
                        colDecimal.Visible = False
                    ElseIf cont = 2 Then
                        colDecimal.HeaderStyle.Width = 50
                    Else
                        colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                        colDecimal.HeaderStyle.Width = 150
                    End If
                End If
            Next
            expression1 = GridGroupByExpression.Parse("NOMTEMA [" & GETPALABRA("Tema") & "] GROUP BY CVETEMA")
        ElseIf Reporte = "21" OrElse Reporte = "22" OrElse Reporte = "49" OrElse Reporte = "50" Then
            For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                Dim colDecimal As GridBoundColumn
                colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.Visible = True
                If cont = 4 Then
                    colDecimal.HeaderStyle.Width = 100
                    colDecimal.DataFormatString = "{0:N1}"
                Else
                    If cont = 0 Or cont = 1 Then 'Quitamos el tema de la tabla
                        colDecimal.Visible = False
                    ElseIf cont = 2 Then
                        colDecimal.HeaderStyle.Width = 50
                    Else
                        colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                        colDecimal.HeaderStyle.Width = 400
                    End If
                End If
            Next
            expression1 = GridGroupByExpression.Parse("NOMTEMA [" & GETPALABRA("Tema") & "] GROUP BY CVETEMA")
        ElseIf Reporte = "40" Then
            For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                Dim colDecimal As GridBoundColumn
                colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                colDecimal.Visible = True
                If cont = 4 Then
                    colDecimal.HeaderStyle.Width = 100
                    colDecimal.DataFormatString = "{0:P}"
                    colDecimal.ItemStyle.Font.Bold = True
                Else
                    If cont = 0 Or cont = 1 Then 'Quitamos el componente de la tabla
                        colDecimal.Visible = False
                    ElseIf cont = 2 Then
                        colDecimal.HeaderStyle.Width = 50
                    Else
                        colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                        colDecimal.HeaderStyle.Width = 400
                    End If
                End If
            Next
            expression1 = GridGroupByExpression.Parse("COMPONENTE [Componente] GROUP BY COMPONENTE")
        End If

            Session("DTPantalla") = DS.Tables(0)
            RBPantalla.Attributes.Add("OnClick", "window.radopen('PantallaCompleta.ASPX?T=Clima&R=" & Reporte & "','RadDetalles');return false;")
            RBPantalla.Visible = True

            Try
            Me.RadGrid1.MasterTableView.GroupByExpressions.Add(expression1)
            Me.RadGrid1.MasterTableView.GroupsDefaultExpanded = True
            Catch ex As Exception
                Lerror.Text = String.Format("<span style='color:red'>Cannot add group by expression: {0}</span>", ex.Message)
                Lerror.Visible = True
            Finally
                RadGrid1.Rebind()
                RadGrid1.Visible = True
            End Try
    End Sub

    Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.Header Then

        ElseIf e.Item.ItemType = GridItemType.GroupHeader Then
            e.Item.BackColor = Color.LightSteelBlue
        ElseIf e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            If RCBReporte.SelectedValue = "R9" Then 'Reporte para identificar prioridades 
                e.Item.Cells(6).BackColor = GETCOLOR3(e.Item.Cells(6).Text)
                e.Item.Cells(6).ForeColor = GETCOLOR4(e.Item.Cells(6).Text)

                e.Item.Cells(7).BackColor = GETCOLOR3(e.Item.Cells(7).Text)
                e.Item.Cells(7).ForeColor = GETCOLOR4(e.Item.Cells(7).Text)
            ElseIf RCBSubreporte.SelectedValue = "27" Or RCBSubreporte.SelectedValue = "28" Or RCBSubreporte.SelectedValue = "29" Or RCBSubreporte.SelectedValue = "30" Or RCBSubreporte.SelectedValue = "38" Then 'Matriz Demograficos/Departamentos
                e.Item.Cells(4).ForeColor = Color.Green
                e.Item.Cells(5).ForeColor = Color.Blue
                e.Item.Cells(6).ForeColor = Color.Orange
                e.Item.Cells(7).ForeColor = Color.Red

                e.Item.Cells(4).Font.Bold = True
                e.Item.Cells(5).Font.Bold = True
                e.Item.Cells(6).Font.Bold = True
                e.Item.Cells(7).Font.Bold = True
            Else
                For N As Integer = 4 To e.Item.Cells.Count - 1
                    If IsNumeric(e.Item.Cells(N).Text) And e.Item.Cells(N).Text.Contains(".") Then
                        e.Item.Cells(N).BackColor = GETCOLOR(e.Item.Cells(N).Text)
                        e.Item.Cells(N).ForeColor = GETCOLOR2(e.Item.Cells(N).Text)
                    End If
                Next
                If e.Item.Cells(5).Text = "999" Then ' SI ES GENERAL
                    e.Item.Font.Bold = True
                End If

                If RCBSeccion.SelectedValue = "CV" Then
                    Exit Sub
                End If

                If RCBSeccion.SelectedValue = "DS" Then
                    Exit Sub
                End If

                If RCBSubreporte.SelectedValue = "1" Or RCBSubreporte.SelectedValue = "2" Then

                    Dim check As New System.Web.UI.WebControls.CheckBox
                    check.Enabled = False
                    e.Item.Cells(2).Controls.Add(check)
                    If e.Item.Cells(9).Text = "1" Or e.Item.Cells(9).Text = "2" Or e.Item.Cells(9).Text = "3" Then
                        check.Checked = True
                    ElseIf e.Item.Cells(9).Text = "4" Or e.Item.Cells(9).Text = "5" Then
                        check.Checked = False
                    End If


            End If
            End If
        End If
    End Sub

    Function GETCOLOR(ByVal Numero As Double) As System.Drawing.Color
        If Numero = 0 Then
            Return System.Drawing.Color.Gray
        ElseIf Numero > 0 And Numero <= 69.999999 Then
            Return System.Drawing.Color.DarkRed
        ElseIf Numero >= 70.0 And Numero <= 79.999999 Then
            Return System.Drawing.Color.Goldenrod
        ElseIf Numero >= 80.0 And Numero <= 89.999999 Then
            Return System.Drawing.Color.DarkBlue
        Else
            Return System.Drawing.Color.DarkGreen
        End If
    End Function

    Function GETCOLOR2(ByVal Numero As Double) As System.Drawing.Color
        If Numero = 0 Then
            Return System.Drawing.Color.White
        ElseIf Numero > 0 And Numero <= 69.999999 Then
            Return System.Drawing.Color.White
        ElseIf Numero >= 70.0 And Numero <= 79.999999 Then
            Return System.Drawing.Color.Black
        ElseIf Numero >= 80.0 And Numero <= 89.999999 Then
            Return System.Drawing.Color.White
        Else
            Return System.Drawing.Color.White
        End If
    End Function

    Function GETCOLOR3(ByVal Numero As Integer) As System.Drawing.Color
        If Numero = 1 Or Numero = 2 Then
            Return System.Drawing.Color.DarkRed
        ElseIf Numero = 3 Or Numero = 4 Then
            Return System.Drawing.Color.Goldenrod
        ElseIf Numero = 5 Or Numero = 6 Then
            Return System.Drawing.Color.DarkBlue
        ElseIf Numero = 7 Or Numero = 8 Then
            Return System.Drawing.Color.DarkGreen
        Else
            Return System.Drawing.Color.Gray
        End If
    End Function

    Function GETCOLOR4(ByVal Numero As Integer) As System.Drawing.Color
        If Numero = 1 Or Numero = 2 Then
            Return System.Drawing.Color.White
        ElseIf Numero = 3 Or Numero = 4 Then
            Return System.Drawing.Color.Black
        ElseIf Numero = 5 Or Numero = 6 Then
            Return System.Drawing.Color.White
        ElseIf Numero = 7 Or Numero = 8 Then
            Return System.Drawing.Color.White
        Else
            Return System.Drawing.Color.White
        End If
    End Function

    Protected Sub RCBLiderazgo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RCBLiderazgo.SelectedIndexChanged
        If RCBReporte.SelectedValue = "R1" Then
            'SELECCIONO GRAFICAS
            If RCBSubreporte.SelectedIndex = 0 Then 'Pedir que seleccione nuevamente, no hace nada
                Cargar.Mensaje(RadAjaxManager1, "Seleccione un elemento para continuar")
                Exit Sub
            ElseIf RCBSubreporte.SelectedValue = "1" Then
                Graficar(BuildData1(1), "DESCTEMA", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text & " (" & RCBLiderazgo.Text & ")", True)
                Chart1.Visible = True
            ElseIf RCBSubreporte.SelectedValue = "2" Then
                Dim DT As DataTable = BuildData1(2)
                Graficar(DT, "NOMTEMA", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text & ": " & CStr(RCBDepartamento.SelectedItem.Text) & " (" & RCBLiderazgo.Text & ")", True)
                Chart1.Visible = True
            ElseIf RCBSubreporte.SelectedValue = "4" Then
                Dim DT As DataTable = BuildData1(3)
                Graficar(DT, "INDICE", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text & " (" & RCBLiderazgo.Text & ")", False)
                Chart1.Visible = True
                CARGARGRID(DT)
            ElseIf RCBSubreporte.SelectedValue = "5" Then
                Dim DT As DataTable = BuildData1(4)
                Graficar(DT, "INDICE", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text & " (" & RCBLiderazgo.Text & ")", False)
                Chart1.Visible = True
                CARGARGRID(DT)
            ElseIf RCBSubreporte.SelectedValue = "6" Then
                Dim DT As DataTable = BuildData1(5)
                Graficar(DT, "NOMEMPRESA", "PROMEDIOEMPRESA", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text & " (" & RCBLiderazgo.Text & ")", False)
                Chart1.Visible = True
            End If
        ElseIf RCBReporte.SelectedValue = "R2" Then
            'SELECCIONO CLIMA
            If RCBSubreporte.SelectedValue = "8" Or RCBSubreporte.SelectedValue = "6" Or RCBSubreporte.SelectedValue = "11" Or RCBSubreporte.SelectedValue = "12" Then
                BuildGrid(RCBSubreporte.SelectedValue)
            ElseIf RCBSubreporte.SelectedValue = "3" Then
                If RCBDepartamento.SelectedValue = 0 Then
                    BuildGrid("3_General")
                ElseIf RCBDepartamento.SelectedValue = 999 Then
                    BuildGrid("3_Todos")
                Else
                    BuildGrid(RCBSubreporte.SelectedValue)
                End If
            End If
        ElseIf RCBReporte.SelectedValue = "R6" And RCBSubreporte.SelectedValue <> "-1" Then
            'SELECCIONO REPORTES DEMOGRAFICOS
            BuildGrid(RCBSubreporte.SelectedValue)
        End If
    End Sub

    Sub Graficar2(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)

        Chart2.DataSource = Datos
        Chart2.Series(0).XValueMember = CStr(ValorX)
        Chart2.Series(0).YValueMembers = ValorY
        Chart2.ChartAreas(0).Area3DStyle.Enable3D = TresD
        Chart2.DataBind()
        Chart2.ChartAreas(0).AxisY.Maximum = 110
        Chart2.ChartAreas(0).AxisY.Minimum = 0
        Chart2.ChartAreas(0).AxisX.LabelStyle.IsEndLabelVisible = True
        Chart2.ChartAreas(0).AxisX.Title = AxisX
        Chart2.ChartAreas(0).AxisX.LabelStyle.Angle = -90
        Chart2.ChartAreas(0).AxisY.Title = AxisY
        Chart2.Titles(0).Text = Titulo1
        Chart2.Titles(1).Text = Titulo2

        AgregarLeyendas()

        Chart2.Legends(0).Position.Width = 90
        Chart2.Legends(0).Position.Height = 15
        Chart2.Legends(0).Position.X = 5
        Chart2.Legends(0).Position.Y = 80

        Dim TBLIMPACTO As DataTable = CType(Session("DTGraficaCorrelacion"), DataTable)
        Dim P60, P80 As Integer
        P60 = TBLIMPACTO.Rows.Count * 0.6
        P80 = TBLIMPACTO.Rows.Count * 0.8

        For I As Integer = 0 To TBLIMPACTO.Rows.Count - 1
            If I = P60 Then
                Chart2.ChartAreas(0).AxisX.StripLines(0).IntervalOffset = TBLIMPACTO.Rows(I).Item(4)
            ElseIf I = P80 Then
                Chart2.ChartAreas(0).AxisX.StripLines(1).IntervalOffset = TBLIMPACTO.Rows(I).Item(4)
            End If
        Next

        'Chart2.ChartAreas(0).AxisX.StripLines(0).IntervalOffset = 40
        'Chart2.ChartAreas(0).AxisX.StripLines(1).IntervalOffset = 60
        Chart2.ChartAreas(0).AxisX.StripLines(0).Interval = 100
        Chart2.ChartAreas(0).AxisX.StripLines(1).Interval = 100

        'Datos.Clear()
        'Chart2.Visible = True
    End Sub

    Function GetImage(ByVal Tema As Integer) As String
        If Tema = 1 Then
            Return "\Imagenes\Correlacion\Box_Gray.png"
        ElseIf Tema = 2 Then
            Return "\Imagenes\Correlacion\Box_Green.png"
        ElseIf Tema = 3 Then
            Return "\Imagenes\Correlacion\Circle_Blue.png"
        ElseIf Tema = 4 Then
            Return "\Imagenes\Correlacion\Circle_Green.png"
        ElseIf Tema = 5 Then
            Return "\Imagenes\Correlacion\Circle_Orange.png"
        ElseIf Tema = 6 Then
            Return "\Imagenes\Correlacion\Circle_Red.png"
        ElseIf Tema = 7 Then
            Return "\Imagenes\Correlacion\Circle_Yellow.png"
        ElseIf Tema = 8 Then
            Return "\Imagenes\Correlacion\Pentagon_blue.png"
        ElseIf Tema = 9 Then
            Return "\Imagenes\Correlacion\Pentagon_lightblue.png"
        ElseIf Tema = 10 Then
            Return "\Imagenes\Correlacion\Rhombus_blue.png"
        ElseIf Tema = 11 Then
            Return "\Imagenes\Correlacion\Rhombus_lightblue.png"
        ElseIf Tema = 12 Then
            Return "\Imagenes\Correlacion\Shield_blue.png"
        ElseIf Tema = 13 Then
            Return "\Imagenes\Correlacion\Shield_Green.png"
        ElseIf Tema = 14 Then
            Return "\Imagenes\Correlacion\Shield_Red.png"
        ElseIf Tema = 15 Then
            Return "\Imagenes\Correlacion\Shield_Yellow.png"
        ElseIf Tema = 16 Then
            Return "\Imagenes\Correlacion\Square_blue.png"
        ElseIf Tema = 17 Then
            Return "\Imagenes\Correlacion\Square_Green.png"
        ElseIf Tema = 18 Then
            Return "\Imagenes\Correlacion\Star_Black.png"
        ElseIf Tema = 19 Then
            Return "\Imagenes\Correlacion\Star_Blue.png"
        ElseIf Tema = 20 Then
            Return "\Imagenes\Correlacion\Star_Green.png"
        ElseIf Tema = 21 Then
            Return "\Imagenes\Correlacion\Star_Yellow.png"
        ElseIf Tema = 22 Then
            Return "\Imagenes\Correlacion\Triangle_Black.png"
        ElseIf Tema = 23 Then
            Return "\Imagenes\Correlacion\Triangle_Blue.png"
            'LIDERES
        ElseIf Tema = 24 Then
            Return "\Imagenes\Correlacion\Box_Gray.png"
        ElseIf Tema = 25 Then
            Return "\Imagenes\Correlacion\Box_Green.png"
        ElseIf Tema = 26 Then
            Return "\Imagenes\Correlacion\Circle_Blue.png"
        ElseIf Tema = 27 Then
            Return "\Imagenes\Correlacion\Circle_Green.png"
        ElseIf Tema = 28 Then
            Return "\Imagenes\Correlacion\Circle_Orange.png"
        ElseIf Tema = 29 Then
            Return "\Imagenes\Correlacion\Circle_Yellow.png"
        ElseIf Tema = 30 Then
            Return "\Imagenes\Correlacion\Pentagon_blue.png"
        ElseIf Tema = 31 Then
            Return "\Imagenes\Correlacion\Pentagon_lightblue.png"
        ElseIf Tema = 32 Then
            Return "\Imagenes\Correlacion\Rhombus_blue.png"
        ElseIf Tema = 33 Then
            Return "\Imagenes\Correlacion\Rhombus_lightblue.png"
        ElseIf Tema = 34 Then
            Return "\Imagenes\Correlacion\Shield_blue.png"
        ElseIf Tema = 35 Then
            Return "\Imagenes\Correlacion\Shield_Green.png"

        ElseIf Tema = 36 Then
            Return "\Imagenes\Correlacion\Square_blue.png"
        ElseIf Tema = 37 Then
            Return "\Imagenes\Correlacion\Square_Green.png"
        ElseIf Tema = 38 Then
            Return "\Imagenes\Correlacion\Box_Gray.png"
        ElseIf Tema = 39 Then
            Return "\Imagenes\Correlacion\Box_Green.png"
        ElseIf Tema = 40 Then
            Return "\Imagenes\Correlacion\Circle_Blue.png"
        ElseIf Tema = 41 Then
            Return "\Imagenes\Correlacion\Circle_Green.png"
        ElseIf Tema = 42 Then
            Return "\Imagenes\Correlacion\Circle_Orange.png"
        ElseIf Tema = 43 Then
            Return "\Imagenes\Correlacion\Circle_Red.png"
        ElseIf Tema = 44 Then
            Return "\Imagenes\Correlacion\Circle_Yellow.png"
        ElseIf Tema = 45 Then
            Return "\Imagenes\Correlacion\Pentagon_blue.png"
        ElseIf Tema = 46 Then
            Return "\Imagenes\Correlacion\Pentagon_lightblue.png"
        ElseIf Tema = 47 Then
            Return "\Imagenes\Correlacion\Rhombus_blue.png"
        ElseIf Tema = 48 Then
            Return "\Imagenes\Correlacion\Rhombus_lightblue.png"
        ElseIf Tema = 49 Then
            Return "\Imagenes\Correlacion\Shield_blue.png"
        ElseIf Tema = 50 Then
            Return "\Imagenes\Correlacion\Shield_Green.png"
        ElseIf Tema = 51 Then
            Return "\Imagenes\Correlacion\Shield_Red.png"
        ElseIf Tema = 52 Then
            Return "\Imagenes\Correlacion\Shield_Yellow.png"
        ElseIf Tema = 53 Then
            Return "\Imagenes\Correlacion\Square_blue.png"
        ElseIf Tema = 54 Then
            Return "\Imagenes\Correlacion\Square_Green.png"
        ElseIf Tema = 55 Then
            Return "\Imagenes\Correlacion\Star_Black.png"
        ElseIf Tema = 56 Then
            Return "\Imagenes\Correlacion\Star_Blue.png"
        ElseIf Tema = 57 Then
            Return "\Imagenes\Correlacion\Star_Green.png"
        ElseIf Tema = 58 Then
            Return "\Imagenes\Correlacion\Star_Yellow.png"
        ElseIf Tema = 59 Then
            Return "\Imagenes\Correlacion\Triangle_Black.png"
        ElseIf Tema = 60 Then
            Return "\Imagenes\Correlacion\Triangle_Blue.png"
        ElseIf Tema = 61 Then
            Return "\Imagenes\Correlacion\Square_blue.png"
        ElseIf Tema = 62 Then
            Return "\Imagenes\Correlacion\Square_Green.png"

            'LIDERES
        ElseIf Tema = 63 Then
            Return "\Imagenes\Correlacion\Box_Gray.png"
        ElseIf Tema = 64 Then
            Return "\Imagenes\Correlacion\Box_Green.png"
        ElseIf Tema = 65 Then
            Return "\Imagenes\Correlacion\Circle_Blue.png"
        ElseIf Tema = 66 Then
            Return "\Imagenes\Correlacion\Circle_Green.png"
        ElseIf Tema = 67 Then
            Return "\Imagenes\Correlacion\Circle_Orange.png"
        ElseIf Tema = 68 Then
            Return "\Imagenes\Correlacion\Circle_Yellow.png"
        ElseIf Tema = 69 Then
            Return "\Imagenes\Correlacion\Pentagon_blue.png"
        ElseIf Tema = 70 Then
            Return "\Imagenes\Correlacion\Pentagon_lightblue.png"
        ElseIf Tema = 71 Then
            Return "\Imagenes\Correlacion\Rhombus_blue.png"
        ElseIf Tema = 72 Then
            Return "\Imagenes\Correlacion\Rhombus_lightblue.png"
        ElseIf Tema = 73 Then
            Return "\Imagenes\Correlacion\Shield_blue.png"
        ElseIf Tema = 74 Then
            Return "\Imagenes\Correlacion\Shield_Green.png"
        Else
            Return "\Imagenes\Correlacion\Star_black.png"
        End If

    End Function

    Sub AgregarLeyendas()
        Dim TBLIMPACTO As DataTable = CType(Session("DTGraficaCorrelacion"), DataTable)
        For I As Integer = 0 To TBLIMPACTO.Rows.Count - 1
            Chart2.Legends(0).CustomItems(TBLIMPACTO.Rows(I).Item(0) - 1).Enabled = True
            'Chart2.Legends(0).CustomItems(TBLIMPACTO.Rows(I).Item(0)).Enabled = True
            Chart2.Legends(0).CustomItems(TBLIMPACTO.Rows(I).Item(0) - 1).Name = TBLIMPACTO.Rows(I).Item(1)
        Next
        'Chart2.Legends(0).CustomItems(0).Enabled = True
    End Sub

    Private Sub Chart2_PostPaint(ByVal sender As Object, ByVal e As System.Web.UI.DataVisualization.Charting.ChartPaintEventArgs) Handles Chart2.PostPaint
        Dim TBLIMPACTO As DataTable = CType(Session("DTGraficaCorrelacion"), DataTable)
        If Not TBLIMPACTO Is Nothing AndAlso TBLIMPACTO.Rows.Count > 0 Then
            For I As Integer = 0 To TBLIMPACTO.Rows.Count - 1
                Dim Imagen As String = GetImage(TBLIMPACTO.Rows(I).Item(0))
                Dim Figura As System.Drawing.Image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & Imagen)
                'Minimo
                Dim Impacto As Integer = TBLIMPACTO.Rows(I).Item(4)
                Dim Satisfaccion As Integer = TBLIMPACTO.Rows(I).Item(5)
                ' Set White color as transparent 
                Dim attrib1 As New System.Drawing.Imaging.ImageAttributes()
                attrib1.SetColorKey(System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Imaging.ColorAdjustType.Default)
                ' Calculates marker position depending on the data point X and Y values 
                Dim ImgRojo As System.Drawing.RectangleF = System.Drawing.RectangleF.Empty
                ImgRojo.X = CSng(e.ChartGraphics.GetPositionFromAxis(Chart2.ChartAreas(0).Name, AxisName.X, Impacto))
                ImgRojo.Y = CSng(e.ChartGraphics.GetPositionFromAxis(Chart2.ChartAreas(0).Name, AxisName.Y, Satisfaccion))
                ImgRojo = e.ChartGraphics.GetAbsoluteRectangle(ImgRojo)
                ImgRojo.Width = Figura.Width
                ImgRojo.Height = Figura.Height
                ImgRojo.Y -= Figura.Height
                ImgRojo.X -= Figura.Width / 2
                ' Draw image 
                e.ChartGraphics.Graphics.DrawImage(Figura, System.Drawing.Rectangle.Round(ImgRojo), 0, 0, Figura.Width, Figura.Height, System.Drawing.GraphicsUnit.Pixel, attrib1)
                ' Add a custom map area in the coordinates of the image 
                Dim rect1 As System.Drawing.RectangleF = e.ChartGraphics.GetRelativeRectangle(ImgRojo)
                Dim area1 As New MapArea(TBLIMPACTO.Rows(I).Item(3), "", "", String.Empty, rect1, Nothing)
                Chart2.MapAreas.Add(area1)
                Figura.Dispose()
            Next
        End If
    End Sub

    Sub BuildMatriz()
        Dim NumReporte As String
        NumReporte = RCBSubreporte.SelectedValue.ToString

        ReportViewer1.Report = New MatrizEfectividad
        'ReportViewer1.Report = New GraficaMatrizEfectividad

        ReportViewer1.Visible = True
        ReportViewer1.ZoomPercent = 80

        'Set the parameters
        Dim NomEmpresa As String
        Dim NomReporte As String
        NomEmpresa = Session("NombreEmpresa")

        If NumReporte = 39 Then
            NomReporte = RCBSubreporte.SelectedItem.Text
        ElseIf NumReporte = 38 Then
            NomReporte = RCBSubreporte.SelectedItem.Text & " (" & RCBDepartamento.Text & ")"
        End If

        ReportViewer1.Report.ReportParameters(0).Value = NomEmpresa
        ReportViewer1.Report.ReportParameters(1).Value = NomReporte
        ReportViewer1.Report.ReportParameters(2).Value = CInt(Session("CveEmpresa"))
        ReportViewer1.Report.ReportParameters(3).Value = CInt(Session("CveEncuesta"))
        ReportViewer1.Report.ReportParameters(4).Value = Session("Lenguaje")

        BuildReport(NumReporte, ReportViewer1.Report)
    End Sub

    Sub MatrizDemograficos()
        RadGrid1.Columns.Clear()
        RadGrid1.MasterTableView.GroupByExpressions.Clear()
        Dim DS As DataSet
        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@TIPO", 21)
        p(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
        p(2) = New SqlParameter("@DEMOGRAFICO", RCBSubreporte.SelectedValue)
        If Session("Lenguaje") = "pt-BR" Then
            p(3) = New SqlParameter("@IDIOMA", 2)
        ElseIf Session("Lenguaje") = "en-US" Then
            p(3) = New SqlParameter("@IDIOMA", 11)
        Else
            p(3) = New SqlParameter("@IDIOMA", 99)
        End If
        DS = DatosBD.FuncionConPar("SP_EngMatrizDemograficos", p, "")
        RadGrid1.DataSource = DS.Tables(0)
        RadGrid1.DataBind()
        RadGrid1.Visible = True

        For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
            Dim colDecimal As GridBoundColumn
            colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
            colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            colDecimal.Visible = True
            If cont = 0 Then 'Quitamos la clave
                colDecimal.Visible = False
            ElseIf cont = 1 Then 'Descripcion
                colDecimal.HeaderStyle.Width = 200
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
            ElseIf cont >= 2 Then 'Perfiles de Efectividad
                colDecimal.HeaderStyle.Width = 100
                colDecimal.DataFormatString = "{0:P}"
            End If
        Next

        Session("DTPantalla") = DS.Tables(0)
        RBPantalla.Attributes.Add("OnClick", "window.radopen('PantallaCompleta.ASPX?T=EngDemograficos&R=" & RCBSubreporte.SelectedValue & "','RadDetalles');return false;")
        RBPantalla.Visible = True

        RadGrid1.Rebind()
    End Sub

    Sub MatrizDepartamentos()
        RadGrid1.Columns.Clear()
        RadGrid1.MasterTableView.GroupByExpressions.Clear()
        Dim DS As DataSet
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@TIPO", 23)
        p(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
        DS = DatosBD.FuncionConPar("SP_EngMatrizEfectividad", p, "")
        RadGrid1.DataSource = DS.Tables(0)
        RadGrid1.DataBind()
        RadGrid1.Visible = True

        For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
            Dim colDecimal As GridBoundColumn
            colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
            colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            colDecimal.Visible = True
            If cont = 0 Then 'Quitamos la clave
                colDecimal.Visible = False
            ElseIf cont = 1 Then 'Descripcion
                colDecimal.HeaderStyle.Width = 200
                colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
            ElseIf cont >= 2 Then 'Perfiles de Efectividad
                colDecimal.HeaderStyle.Width = 100
                colDecimal.DataFormatString = "{0:P}"
            End If
        Next

        Session("DTPantalla") = DS.Tables(0)
        RBPantalla.Attributes.Add("OnClick", "window.radopen('PantallaCompleta.ASPX?T=EngDemograficos&R=" & RCBSubreporte.SelectedValue & "','RadDetalles');return false;")
        RBPantalla.Visible = True

        RadGrid1.Rebind()
    End Sub

    Sub CalificacionFEMSA(ByVal Tipo As Integer)
        Try
            Dim DS As DataSet
            If Tipo = 1 Then
                Dim p(5) As SqlParameter
                p(0) = New SqlParameter("@TIPO", 1)
                p(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                p(2) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
                p(3) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
                p(4) = New SqlParameter("@USUARIO", Session("USUARIO"))
                If Session("Lenguaje") = "pt-BR" Then
                    p(5) = New SqlParameter("@IDIOMA", 2)
                ElseIf Session("Lenguaje") = "en-US" Then
                    p(5) = New SqlParameter("@IDIOMA", 11)
                Else
                    p(5) = New SqlParameter("@IDIOMA", 99)
                End If
                DS = DatosBD.FuncionConPar("SP_EngRepCO", p, "")
                Graficar(DS.Tables(0), "SUBSISTEMA", "PROMEDIO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), GETPALABRA("Clima Organizacional"))
            ElseIf Tipo = 2 Then
                Dim p(6) As SqlParameter
                p(0) = New SqlParameter("@TIPO", 2)
                p(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                p(2) = New SqlParameter("@CVEDEPTO", RCBDepartamento.SelectedValue)
                p(3) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
                p(4) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
                p(5) = New SqlParameter("@USUARIO", Session("USUARIO"))
                If Session("Lenguaje") = "pt-BR" Then
                    p(6) = New SqlParameter("@IDIOMA", 2)
                ElseIf Session("Lenguaje") = "en-US" Then
                    p(6) = New SqlParameter("@IDIOMA", 11)
                Else
                    p(6) = New SqlParameter("@IDIOMA", 99)
                End If
                DS = DatosBD.FuncionConPar("SP_EngRepCO", p, "")
                Graficar(DS.Tables(0), "SUBSISTEMA", "PROMEDIO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), GETPALABRA("Clima Organizacional") & ": " & RCBDepartamento.Text)
            ElseIf Tipo = 3 Then
                Dim p(4) As SqlParameter
                p(0) = New SqlParameter("@TIPO", 3)
                p(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                p(2) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
                p(3) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
                p(4) = New SqlParameter("@USUARIO", Session("USUARIO"))
                DS = DatosBD.FuncionConPar("SP_EngRepCO", p, "")
                Graficar(DS.Tables(0), "NOMDEPTO", "PROMEDIO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), GETPALABRA("Clima Organizacional"))
            End If
            Chart1.Visible = True
        Catch ex As Exception
            Lerror.Text = "No existe información para este reporte."
        End Try
    End Sub

    Function GETPALABRA(ByVal Palabra As String) As String
        Dim Traduccion As String
        Dim DS As DataSet
        Dim P(1) As SqlParameter
        P(0) = New SqlParameter("@IDIOMA", Session("Lenguaje"))
        P(1) = New SqlParameter("@PALABRA", Palabra)
        DS = DatosBD.FuncionConPar("SP_GETTRADUCCION", P, Lerror.Text)
        Traduccion = DS.Tables(0).Rows(0).Item(0)
        Return Traduccion
    End Function

    Public Sub RadAjaxManager1_AjaxRequest(sender As Object, e As AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        Try
            Dim tabla As DataTable = CType(Session("ChartDT"), DataTable)
            Dim Clave As Integer
            Dim dv As DataView = tabla.DefaultView
            If RCBSubreporte.SelectedValue = "1" Then
                dv.RowFilter = "DESCTEMA = '" & e.Argument & "'"
            Else
                dv.RowFilter = "NOMTEMA = '" & e.Argument & "'"
            End If
            Clave = dv.Item(0).Row(2)

            If RCBSubreporte.SelectedValue = "2" Then
                'Dim DT As DataTable = BuildData1(2)
                'Graficar(DT, "NOMTEMA", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text & " de : " & RCBDepartamento.SelectedItem.Text, True)
                BuildData2(Clave)
            Else
                'Dim DT As DataTable = BuildData1(1)
                'Graficar(DT, "NOMTEMA", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text, True)
                BuildData2(Clave)
            End If
            Chart1.Visible = False
            BRegresar.Visible = True
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub BRegresar_Click(sender As Object, e As ImageClickEventArgs) Handles BRegresar.Click
        If RCBSubreporte.SelectedValue = "2" Then
            Dim DT As DataTable = BuildData1(2)
            Graficar(DT, "NOMTEMA", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text & " de : " & RCBDepartamento.SelectedItem.Text, True)
        Else
            Dim DT As DataTable = BuildData1(1)
            Graficar(DT, "DESCTEMA", "INDICEPONDERADO", "", GETPALABRA("PROMEDIOS"), Session("NombreEmpresa"), RCBSubreporte.SelectedItem.Text, True)
        End If
        Chart1.Visible = True
        BRegresar.Visible = False
        RadGrid1.Visible = False
    End Sub

End Class
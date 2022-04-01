Imports Telerik.Web.UI
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports System.Configuration
Imports System.IO

Partial Public Class Graficas
    Inherits System.Web.UI.Page

    Protected Overrides Sub InitializeCulture()
        If Not Session("Lenguaje") Is Nothing Then
            UICulture = Session("Lenguaje")
            Culture = Session("Lenguaje")
        End If
        MyBase.InitializeCulture()
    End Sub

    Dim Param As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CON") = "OK" Then
            If Not Page.IsPostBack Then
                'Con un parametro  controlar el tipo de grafica que se utilizará
                Param = Request.Params("Val")
                If Param = "CO" Then 'Grafica de Clima Organizacional
                    Session("NumGrafica") = "CO"
                    BuildData()
                ElseIf Param = "Participacion" Then
                    Session("NumGrafica") = "Participación"
                    Session("CveEmpresa") = Request.Params("Em")


                    'Session("NombreEmpresa") = DatosBD.FuncionTXT("SELECT ISNULL(DBO.GETEMPRESAS(" & Session("CveEmpresa") & "),'SIN NOMBRE')", Lerror.Text).Tables(0).Rows(0).Item(0)


                    Dim ds As New DataSet
                    Dim P(1) As SqlParameter
                    P(0) = New SqlParameter("@TIPO", 13)
                    P(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresa"))
                    ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)

                    Session("NombreEmpresa") = ds.Tables(0).Rows(0).Item(0)

                    BuildParticipacion()
                Else
                    LUNIDAD.Text = 0
                    LAGRUPADO.Text = 0
                    LPAIS.Text = 0
                    LTERRITORIO.Text = 0
                    LREGION.Text = 0
                    LSUBREGION.Text = 0
                    LEMPRESA.Text = 0
                    LANTERIOR.Text = 0

                    If Not IsDBNull(Session("CveUnidad")) Then
                        LUNIDAD.Text = Session("CveUnidad")
                    End If
                    If Not IsDBNull(Session("CveAgrupado")) Then
                        LAGRUPADO.Text = Session("CveAgrupado")
                    End If
                    If Not IsDBNull(Session("CvePais")) Then
                        LPAIS.Text = Session("CvePais")
                    End If
                    If Not IsDBNull(Session("CveTerritorio")) Then
                        LTERRITORIO.Text = Session("CveTerritorio")
                    End If
                    If Not IsDBNull(Session("CveRegion")) Then
                        LREGION.Text = Session("CveRegion")
                    End If
                    If Not IsDBNull(Session("CveSubRegion")) Then
                        LSUBREGION.Text = Session("CveSubRegion")
                    End If

                    BRegresar.Visible = False
                    Session("TipoGrafica") = Param
                    BuildChart(Session("TipoGrafica"))
                End If
                Response.AppendHeader("X-UA-Compatible", "IE=edge")
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
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
            If Session("NumGrafica") = "Participación" Then
                VAL = FormatNumber(Datos.Rows(i).Item(4), 1)
                TEXTO = Datos.Rows(i).Item(1)
            Else
                VAL = FormatNumber(Datos.Rows(i).Item(3), 1)
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

        ''Chart1.Legends(0).Enabled = False

        'Dim annotation As New TextAnnotation()
        'annotation.Text = GETPALABRA("Actualizada") & ": " & Now.Date.ToShortDateString
        'annotation.ForeColor = Color.Black
        'annotation.X = 80
        'annotation.Y = 0
        'annotation.Font = New Font("Tahoma", 8)
        'Chart1.Annotations.Add(annotation)


        'Dim annotation1 As New TextAnnotation()
        'annotation1.Text = Session("NumGrafica")
        'annotation1.ForeColor = Color.Black
        'annotation1.X = 0
        'annotation1.Y = 0
        'annotation1.Font = New Font("Tahoma", 8)
        'Chart1.Annotations.Add(annotation1)


        'Dim VAL As Double = 0.0
        'For I As Integer = 0 To Datos.Rows.Count - 1

        '    'Graficas con link en todas las barras menos en el 99
        '    If vPostBack = True Then
        '        If Datos.Rows(I).Item(2) <> "99" And Session("TipoGrafica") <> "S7" Then
        '            Chart1.Series(0).Points(I).PostBackValue = Datos.Rows(I).Item(0)
        '        End If
        '    End If

        '    If Session("NumGrafica") = "Participación" Then
        '        VAL = Datos.Rows(I).Item(4)
        '    Else
        '        VAL = Datos.Rows(I).Item(3)
        '    End If

        '    Chart1.Series(0).Points(I).ToolTip = Datos.Rows(I).Item(1).ToString
        '    If VAL <= 69.99 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Red
        '    ElseIf VAL >= 70.0 And VAL <= 79.99 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Yellow
        '    ElseIf VAL >= 80.0 And VAL <= 89.99 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Blue
        '    ElseIf VAL >= 90.0 Then
        '        Chart1.Series(0).Points(I).Color = Drawing.Color.Green
        '    End If
        'Next
        'Datos.Clear()
        'Chart1.Visible = True
    End Sub

    'Private Sub Chart1_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles Chart1.Click
    '    If Session("TipoGrafica") = "S1" Then
    '        LUNIDAD.Text = e.PostBackValue
    '        Session("TipoGrafica") = "S2"
    '    ElseIf Session("TipoGrafica") = "S2" Then
    '        LAGRUPADO.Text = e.PostBackValue
    '        Session("TipoGrafica") = "S3"
    '    ElseIf Session("TipoGrafica") = "S3" Then
    '        LPAIS.Text = e.PostBackValue
    '        Session("TipoGrafica") = "S4"
    '    ElseIf Session("TipoGrafica") = "S4" Then
    '        LTERRITORIO.Text = e.PostBackValue
    '        Session("TipoGrafica") = "S5"
    '    ElseIf Session("TipoGrafica") = "S5" Then
    '        LREGION.Text = e.PostBackValue
    '        Session("TipoGrafica") = "S6"
    '    ElseIf Session("TipoGrafica") = "S6" Then
    '        LSUBREGION.Text = e.PostBackValue
    '        Session("TipoGrafica") = "S7"
    '    ElseIf Session("TipoGrafica") = "S7" Then
    '        LEMPRESA.Text = e.PostBackValue
    '        Session("TipoGrafica") = "S8"
    '    End If
    '    BuildChart(Session("TipoGrafica"))
    'End Sub

    Protected Sub BRegresar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BRegresar.Click
        'Validacion de "Regresar"
        If Session("TipoGrafica") = "S2" Then
            Session("TipoGrafica") = "S1"
        ElseIf Session("TipoGrafica") = "S3" Then
            Session("TipoGrafica") = "S2"
        ElseIf Session("TipoGrafica") = "S4" Then
            Session("TipoGrafica") = "S3"
        ElseIf Session("TipoGrafica") = "S5" Then
            Session("TipoGrafica") = "S4"
        ElseIf Session("TipoGrafica") = "S6" Then
            Session("TipoGrafica") = "S5"
        ElseIf Session("TipoGrafica") = "S7" Then
            Session("TipoGrafica") = "S6"
        ElseIf Session("TipoGrafica") = "S8" Then
            Session("TipoGrafica") = "S7"
        End If
        BuildChart(Session("TipoGrafica"))
    End Sub

    Sub BuildChart(ByVal Tipo As String)
        Dim DS As DataSet
        If Tipo = "S1" Then 'Unidades de Negocio
            '1
            Session("NumGrafica") = "G1"
            Dim P(3) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 1)
            P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
            P(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            P(3) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))

            DS = DatosBD.FuncionConPar("SP_BUSQUEDA_GRAFICA", P, Lerror.Text)
            Session("ChartDT") = DS.Tables(0)

            Graficar(DS.Tables(0), "TEXTO", "PROM", "", GETPALABRA("PROMEDIOS"), GETPALABRA("Gráficas Por Unidad"), " ", True)
            BRegresar.Visible = False
        ElseIf Tipo = "S2" Then 'Agrupados de Paises por Unidad de Negocio
            '2
            Session("NumGrafica") = "G2"
            Dim P(5) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 2)
            P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
            P(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            P(3) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
            P(4) = New SqlParameter("@CVEAREA", Session("CveTipo"))
            P(5) = New SqlParameter("@CVEDIVISION", LUNIDAD.Text)

            DS = DatosBD.FuncionConPar("SP_BUSQUEDA_GRAFICA", P, Lerror.Text)
            Session("ChartDT") = DS.Tables(0)


            Dim ds2 As New DataSet
            Dim P2(1) As SqlParameter
            P2(0) = New SqlParameter("@TIPO", 14)
            P2(1) = New SqlParameter("@UNIDAD", LUNIDAD.Text)
            ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)

            Dim CU As String = ds2.Tables(0).Rows(0).Item(0)

            'Dim CU As String = DatosBD.FuncionTXT("SELECT  DBO.GETDIVISIONES(" & LUNIDAD.Text & ")", Lerror.Text).Tables(0).Rows(0).Item(0)

            Graficar(DS.Tables(0), "TEXTO", "PROM", "", GETPALABRA("PROMEDIOS"), GETPALABRA("Gráficas Por Agrupado País"), CU, True)
            If Request.Params("Val") = "S1" Then
                BRegresar.Visible = True
            Else
                BRegresar.Visible = False
            End If
        ElseIf Tipo = "S3" Then ' Paises por Agrupado de Paises
            '3
            Session("NumGrafica") = "G3"
            Dim P(6) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 3)
            P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
            P(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            P(3) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
            P(4) = New SqlParameter("@CVEAREA", Session("CveTipo"))
            P(5) = New SqlParameter("@CVEDIVISION", LUNIDAD.Text)
            P(6) = New SqlParameter("@CVEAGRUPADOPAIS", LAGRUPADO.Text)

            DS = DatosBD.FuncionConPar("SP_BUSQUEDA_GRAFICA", P, Lerror.Text)
            Session("ChartDT") = DS.Tables(0)

            Dim ds2 As New DataSet
            Dim P2(1) As SqlParameter
            P2(0) = New SqlParameter("@TIPO", 14)
            P2(1) = New SqlParameter("@UNIDAD", LUNIDAD.Text)
            ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)

            Dim CU As String = ds2.Tables(0).Rows(0).Item(0)

            'Dim CU As String = DatosBD.FuncionTXT("SELECT  DBO.GETDIVISIONES(" & LUNIDAD.Text & ")", Lerror.Text).Tables(0).Rows(0).Item(0)


            Dim ds3 As New DataSet
            Dim P3(1) As SqlParameter
            P3(0) = New SqlParameter("@TIPO", 15)
            P3(1) = New SqlParameter("@AGRUPADOPAIS", LAGRUPADO.Text)
            ds3 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P3, Lerror.Text)

            Dim CA As String = ds3.Tables(0).Rows(0).Item(0)

            ' Dim CA As String = DatosBD.FuncionTXT("SELECT  DBO.GETAGRUPADOPAISES(" & LAGRUPADO.Text & ")", Lerror.Text).Tables(0).Rows(0).Item(0)

            Graficar(DS.Tables(0), "TEXTO", "PROM", "", GETPALABRA("PROMEDIOS"), GETPALABRA("Gráficas Por País"), CU & "/" & CA, True)
            If Request.Params("Val") = "S1" Or Request.Params("Val") = "S2" Then
                BRegresar.Visible = True
            Else
                BRegresar.Visible = False
            End If
        ElseIf Tipo = "S4" Then 'Territorios por Pais
            '4
            Session("NumGrafica") = "G4"
            Dim P(7) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 4)
            P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
            P(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            P(3) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
            P(4) = New SqlParameter("@CVEAREA", Session("CveTipo"))
            P(5) = New SqlParameter("@CVEDIVISION", LUNIDAD.Text)
            P(6) = New SqlParameter("@CVEAGRUPADOPAIS", LAGRUPADO.Text)
            P(7) = New SqlParameter("@CVEPAIS", LPAIS.Text)

            DS = DatosBD.FuncionConPar("SP_BUSQUEDA_GRAFICA", P, Lerror.Text)
            Session("ChartDT") = DS.Tables(0)

            'Dim CU As String = DatosBD.FuncionTXT("SELECT  DBO.GETDIVISIONES(" & LUNIDAD.Text & ")", Lerror.Text).Tables(0).Rows(0).Item(0)

            Dim ds2 As New DataSet
            Dim P2(1) As SqlParameter
            P2(0) = New SqlParameter("@TIPO", 14)
            P2(1) = New SqlParameter("@UNIDAD", LUNIDAD.Text)
            ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)

            Dim CU As String = ds2.Tables(0).Rows(0).Item(0)

            ' Dim CA As String = DatosBD.FuncionTXT("SELECT  DBO.GETAGRUPADOPAISES(" & LAGRUPADO.Text & ")", Lerror.Text).Tables(0).Rows(0).Item(0)


            Dim ds3 As New DataSet
            Dim P3(1) As SqlParameter
            P3(0) = New SqlParameter("@TIPO", 15)
            P3(1) = New SqlParameter("@AGRUPADOPAIS", LAGRUPADO.Text)
            ds3 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P3, Lerror.Text)

            Dim CA As String = ds3.Tables(0).Rows(0).Item(0)

            ' Dim CP As String = DatosBD.FuncionTXT("SELECT  DBO.GETPAISES(" & LPAIS.Text & ")", Lerror.Text).Tables(0).Rows(0).Item(0)

            Dim ds4 As New DataSet
            Dim P4(1) As SqlParameter
            P4(0) = New SqlParameter("@TIPO", 16)
            P4(1) = New SqlParameter("@CVEPAIS", LPAIS.Text)
            ds4 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P4, Lerror.Text)

            Dim CP As String = ds4.Tables(0).Rows(0).Item(0)

            Graficar(DS.Tables(0), "TEXTO", "PROM", "", GETPALABRA("PROMEDIOS"), GETPALABRA("Gráficas Por Territorio"), CU & "/" & CA & "/" & CP, True)
            If Request.Params("Val") = "S1" Or Request.Params("Val") = "S2" Or Request.Params("Val") = "S3" Then
                BRegresar.Visible = True
            Else
                BRegresar.Visible = False
            End If
        ElseIf Tipo = "S5" Then 'Regiones por Territorio
            '5
            Session("NumGrafica") = "G5"
            Dim P(8) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 5)
            P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
            P(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            P(3) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
            P(4) = New SqlParameter("@CVEAREA", Session("CveTipo"))
            P(5) = New SqlParameter("@CVEDIVISION", LUNIDAD.Text)
            P(6) = New SqlParameter("@CVEAGRUPADOPAIS", LAGRUPADO.Text)
            P(7) = New SqlParameter("@CVEPAIS", LPAIS.Text)
            P(8) = New SqlParameter("@CVETERRITORIO", LTERRITORIO.Text)

            DS = DatosBD.FuncionConPar("SP_BUSQUEDA_GRAFICA", P, Lerror.Text)
            Session("ChartDT") = DS.Tables(0)


            Dim ds2 As New DataSet
            Dim P2(1) As SqlParameter
            P2(0) = New SqlParameter("@TIPO", 14)
            P2(1) = New SqlParameter("@UNIDAD", LUNIDAD.Text)
            ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)

            Dim CU As String = ds2.Tables(0).Rows(0).Item(0)

            Dim ds3 As New DataSet
            Dim P3(1) As SqlParameter
            P3(0) = New SqlParameter("@TIPO", 15)
            P3(1) = New SqlParameter("@AGRUPADOPAIS", LAGRUPADO.Text)
            ds3 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P3, Lerror.Text)

            Dim CA As String = ds3.Tables(0).Rows(0).Item(0)

            Dim ds4 As New DataSet
            Dim P4(1) As SqlParameter
            P4(0) = New SqlParameter("@TIPO", 16)
            P4(1) = New SqlParameter("@CVEPAIS", LPAIS.Text)
            ds4 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P4, Lerror.Text)

            Dim CP As String = ds4.Tables(0).Rows(0).Item(0)


            Dim ds5 As New DataSet
            Dim P5(1) As SqlParameter
            P5(0) = New SqlParameter("@TIPO", 17)
            P5(1) = New SqlParameter("@CVETERRITORIO", LTERRITORIO.Text)
            ds5 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P5, Lerror.Text)

            Dim CT As String = ds5.Tables(0).Rows(0).Item(0)



            Graficar(DS.Tables(0), "TEXTO", "PROM", "", GETPALABRA("PROMEDIOS"), GETPALABRA("Gráficas Por Región"), CU & "/" & CA & "/" & CP & "/" & CT, True)
            If Request.Params("Val") = "S1" Or Request.Params("Val") = "S2" Or Request.Params("Val") = "S3" Then
                BRegresar.Visible = True
            Else
                BRegresar.Visible = False
            End If
        ElseIf Tipo = "S6" Then 'SubRegiones por Region
            '6
            Session("NumGrafica") = "G6"
            Dim P(9) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 6)
            P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
            P(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            P(3) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
            P(4) = New SqlParameter("@CVEAREA", Session("CveTipo"))
            P(5) = New SqlParameter("@CVEDIVISION", LUNIDAD.Text)
            P(6) = New SqlParameter("@CVEAGRUPADOPAIS", LAGRUPADO.Text)
            P(7) = New SqlParameter("@CVEPAIS", LPAIS.Text)
            P(8) = New SqlParameter("@CVETERRITORIO", LTERRITORIO.Text)
            P(9) = New SqlParameter("@CVEREGION", LREGION.Text)

            DS = DatosBD.FuncionConPar("SP_BUSQUEDA_GRAFICA", P, Lerror.Text)
            Session("ChartDT") = DS.Tables(0)


            Dim ds2 As New DataSet
            Dim P2(1) As SqlParameter
            P2(0) = New SqlParameter("@TIPO", 14)
            P2(1) = New SqlParameter("@UNIDAD", LUNIDAD.Text)
            ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)

            Dim CU As String = ds2.Tables(0).Rows(0).Item(0)

            Dim ds3 As New DataSet
            Dim P3(1) As SqlParameter
            P3(0) = New SqlParameter("@TIPO", 15)
            P3(1) = New SqlParameter("@AGRUPADOPAIS", LAGRUPADO.Text)
            ds3 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P3, Lerror.Text)

            Dim CA As String = ds3.Tables(0).Rows(0).Item(0)

            Dim ds4 As New DataSet
            Dim P4(1) As SqlParameter
            P4(0) = New SqlParameter("@TIPO", 16)
            P4(1) = New SqlParameter("@CVEPAIS", LPAIS.Text)
            ds4 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P4, Lerror.Text)

            Dim CP As String = ds4.Tables(0).Rows(0).Item(0)

            Dim ds5 As New DataSet
            Dim P5(1) As SqlParameter
            P5(0) = New SqlParameter("@TIPO", 17)
            P5(1) = New SqlParameter("@CVETERRITORIO", LTERRITORIO.Text)
            ds5 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P5, Lerror.Text)

            Dim CT As String = ds5.Tables(0).Rows(0).Item(0)

            Dim ds6 As New DataSet
            Dim P6(1) As SqlParameter
            P6(0) = New SqlParameter("@TIPO", 18)
            P6(1) = New SqlParameter("@CVEREGION", LREGION.Text)
            ds6 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P6, Lerror.Text)

            Dim CR As String = ds6.Tables(0).Rows(0).Item(0)




            Graficar(DS.Tables(0), "TEXTO", "PROM", "", GETPALABRA("PROMEDIOS"), GETPALABRA("Gráficas Por Subregión"), CU & "/" & CA & "/" & CP & "/" & CT & "/" & CR, True)
            If Request.Params("Val") = "S1" Or Request.Params("Val") = "S2" Or Request.Params("Val") = "S3" Or Request.Params("Val") = "S4" Then
                BRegresar.Visible = True
            Else
                BRegresar.Visible = False
            End If
        ElseIf Tipo = "S7" Then 'Centros de Trabajo por SubRegion
            '7
            Session("NumGrafica") = "G7"
            Dim P(10) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 7)
            P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
            P(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            P(3) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
            P(4) = New SqlParameter("@CVEAREA", Session("CveTipo"))
            P(5) = New SqlParameter("@CVEDIVISION", LUNIDAD.Text)
            P(6) = New SqlParameter("@CVEAGRUPADOPAIS", LAGRUPADO.Text)
            P(7) = New SqlParameter("@CVEPAIS", LPAIS.Text)
            P(8) = New SqlParameter("@CVETERRITORIO", LTERRITORIO.Text)
            P(9) = New SqlParameter("@CVEREGION", LREGION.Text)
            P(10) = New SqlParameter("@CVESUBREGION", LSUBREGION.Text)

            DS = DatosBD.FuncionConPar("SP_BUSQUEDA_GRAFICA", P, Lerror.Text)
            Session("ChartDT") = DS.Tables(0)

            Dim ds2 As New DataSet
            Dim P2(1) As SqlParameter
            P2(0) = New SqlParameter("@TIPO", 14)
            P2(1) = New SqlParameter("@UNIDAD", LUNIDAD.Text)
            ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)

            Dim CU As String = ds2.Tables(0).Rows(0).Item(0)

            Dim ds3 As New DataSet
            Dim P3(1) As SqlParameter
            P3(0) = New SqlParameter("@TIPO", 15)
            P3(1) = New SqlParameter("@AGRUPADOPAIS", LAGRUPADO.Text)
            ds3 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P3, Lerror.Text)

            Dim CA As String = ds3.Tables(0).Rows(0).Item(0)

            Dim ds4 As New DataSet
            Dim P4(1) As SqlParameter
            P4(0) = New SqlParameter("@TIPO", 16)
            P4(1) = New SqlParameter("@CVEPAIS", LPAIS.Text)
            ds4 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P4, Lerror.Text)

            Dim CP As String = ds4.Tables(0).Rows(0).Item(0)

            Dim ds5 As New DataSet
            Dim P5(1) As SqlParameter
            P5(0) = New SqlParameter("@TIPO", 16)
            P5(1) = New SqlParameter("@CVETERRITORIO", LTERRITORIO.Text)
            ds5 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P5, Lerror.Text)

            Dim CT As String = ds5.Tables(0).Rows(0).Item(0)

            Dim ds6 As New DataSet
            Dim P6(1) As SqlParameter
            P6(0) = New SqlParameter("@TIPO", 18)
            P6(1) = New SqlParameter("@CVEREGION", LREGION.Text)
            ds6 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P6, Lerror.Text)

            Dim CR As String = ds6.Tables(0).Rows(0).Item(0)

            Dim ds7 As New DataSet
            Dim P7(2) As SqlParameter
            P7(0) = New SqlParameter("@TIPO", 19)
            P7(1) = New SqlParameter("@CVEREGION", LREGION.Text)
            P7(2) = New SqlParameter("@CVEREGION", LSUBREGION.Text)
            ds7 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P6, Lerror.Text)

            Dim CS As String = ds7.Tables(0).Rows(0).Item(0)



            Graficar(DS.Tables(0), "TEXTO", "PROM", "", GETPALABRA("PROMEDIOS"), GETPALABRA("Gráficas Por Centro de Trabajo"), CU & "/" & CA & "/" & CP & "/" & CT & "/" & CR & "/" & CS, True)
            BRegresar.Visible = True
        ElseIf Tipo = "S8" Then 'Temas por Centro de Trabajo
            '8
            Session("NumGrafica") = "G8"
            Dim P(11) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 8)
            P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
            P(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            P(3) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
            P(4) = New SqlParameter("@CVEAREA", Session("CveTipo"))
            P(5) = New SqlParameter("@CVEDIVISION", LUNIDAD.Text)
            P(6) = New SqlParameter("@CVEAGRUPADOPAIS", LAGRUPADO.Text)
            P(7) = New SqlParameter("@CVEPAIS", LPAIS.Text)
            P(8) = New SqlParameter("@CVETERRITORIO", LTERRITORIO.Text)
            P(9) = New SqlParameter("@CVEREGION", LREGION.Text)
            P(10) = New SqlParameter("@CVESUBREGION", LSUBREGION.Text)
            P(11) = New SqlParameter("@CVEEMPRESA", LEMPRESA.Text)

            DS = DatosBD.FuncionConPar("SP_BUSQUEDA_GRAFICA", P, Lerror.Text)
            Session("ChartDT") = DS.Tables(0)

            Dim ds2 As New DataSet
            Dim P2(1) As SqlParameter
            P2(0) = New SqlParameter("@TIPO", 13)
            P2(1) = New SqlParameter("@CVEEMPRESA", LEMPRESA.Text)
            ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, Lerror.Text)

            Dim CE As String = ds2.Tables(0).Rows(0).Item(0)

            Graficar(DS.Tables(0), "TEXTO", "PROM", "", GETPALABRA("PROMEDIOS"), GETPALABRA("Gráfica General Por Temas"), CE, True)
            BRegresar.Visible = True
        End If
    End Sub

    Private Sub BuildData()
        Try
            Dim ds As New DataSet
            Dim PLoad(12) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 1)
            PLoad(1) = New SqlParameter("@CVEDIVISION", Session("CveUnidad"))
            PLoad(2) = New SqlParameter("@CVEAGRUPADOPAIS", Session("CveAgrupado"))
            PLoad(3) = New SqlParameter("@CVEPAIS", Session("CvePais"))
            PLoad(4) = New SqlParameter("@CVEAREA", Session("CveTipo"))
            PLoad(5) = New SqlParameter("@CVETERRITORIO", Session("CveTerritorio"))
            PLoad(6) = New SqlParameter("@CVEREGION", Session("CveRegion"))
            PLoad(7) = New SqlParameter("@CVESUBREGION", Session("CveSubRegion"))
            PLoad(8) = New SqlParameter("@CVEEMPRESA", DBNull.Value)
            PLoad(9) = New SqlParameter("@CVESISTEMA", Session("CveSistema"))
            PLoad(10) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(11) = New SqlParameter("@USUARIO", Session("USUARIO"))

            If Session("Lenguaje") = "pt-BR" Then
                PLoad(12) = New SqlParameter("@IDIOMA", 2)
            ElseIf Session("Lenguaje") = "en-US" Then
                PLoad(12) = New SqlParameter("@IDIOMA", 11)
            Else
                PLoad(12) = New SqlParameter("@IDIOMA", 99)
            End If

            ds = DatosBD.FuncionConPar("SP_EngRepCO", PLoad, Lerror.Text)

            Graficar(ds.Tables(0), "SUBSISTEMA", "PROMEDIO", "", GETPALABRA("PROMEDIOS"), GETPALABRA("GRAFICA CLIMA ORGANIZACIONAL"), "", False)
        Catch ex As Exception
            Lerror.Text = "No existe información para este reporte."
        End Try
    End Sub

    Sub BuildParticipacion()
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@CveEmpresa", Session("CveEmpresa"))
        p(1) = New SqlParameter("@CvePerfil", Session("NUMPERFIL"))
        Dim ds As New DataSet
        ds = DatosBD.FuncionConPar("SP_PARTICIPACION_HISTORICO", p, Lerror.Text, "tblParticipacion")


        If Session("Lenguaje") = "pt-BR" Then
            Graficar(ds.Tables(0), "CONCEPTO", "PORCENTAJE", "", "Participação", "GRÁFICA DE PARTICIPACIÓN", Session("NombreEmpresa"))
        ElseIf Session("Lenguaje") = "en-US" Then
            Graficar(ds.Tables(0), "CONCEPTO", "PORCENTAJE", "", "Participation", "Participation Chart", Session("NombreEmpresa"))
        Else
            Graficar(ds.Tables(0), "CONCEPTO", "PORCENTAJE", "", "PARTICIPACION", "GRÁFICA DE PARTICIPACIÓN", Session("NombreEmpresa"))
        End If




        Chart1.Visible = True
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
            dv.RowFilter = "TEXTO = '" & e.Argument & "'"
            Clave = dv.Item(0).Row(0)

            If Session("TipoGrafica") = "S1" Then
                LUNIDAD.Text = Clave
                Session("TipoGrafica") = "S2"
            ElseIf Session("TipoGrafica") = "S2" Then
                LAGRUPADO.Text = Clave
                Session("TipoGrafica") = "S3"
            ElseIf Session("TipoGrafica") = "S3" Then
                LPAIS.Text = Clave
                Session("TipoGrafica") = "S4"
            ElseIf Session("TipoGrafica") = "S4" Then
                LTERRITORIO.Text = Clave
                Session("TipoGrafica") = "S5"
            ElseIf Session("TipoGrafica") = "S5" Then
                LREGION.Text = Clave
                Session("TipoGrafica") = "S6"
            ElseIf Session("TipoGrafica") = "S6" Then
                LSUBREGION.Text = Clave
                Session("TipoGrafica") = "S7"
            ElseIf Session("TipoGrafica") = "S7" Then
                LEMPRESA.Text = Clave
                Session("TipoGrafica") = "S8"
            End If
            BuildChart(Session("TipoGrafica"))
            BRegresar.Visible = True
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

End Class
Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports Telerik.ReportViewer.WebForms
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.IO

Partial Public Class ReporteEjecutivo
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
                Unidades()
                LlenarReporte()
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Protected Sub RUnidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RUnidad.SelectedIndexChanged
        RegionPaises()
        TipoOperacion()
    End Sub

    Protected Sub RRegionPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RRegionPaises.SelectedIndexChanged
        Pais()
    End Sub

    Protected Sub RPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RPaises.SelectedIndexChanged
        Territorio()
    End Sub

    Private Sub RTerritorios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RTerritorios.SelectedIndexChanged
        Region()
    End Sub

    Protected Sub RRegiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RRegiones.SelectedIndexChanged
        Subregion()
    End Sub

    Protected Sub RSubregiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RSubregiones.SelectedIndexChanged
        CentroDeTrabajo()
    End Sub

    Protected Sub RCentroDeTrabajo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RCentroDeTrabajo.SelectedIndexChanged
        BuildData()
    End Sub

    Sub Unidades()
        RUnidad.Items.Clear()
        RRegionPaises.Items.Clear()
        RPaises.Items.Clear()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 0)
        PLoad(1) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(2) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RUnidad.DataSource = DS.Tables(0)
        RUnidad.DataTextField = "NomDivision"
        RUnidad.DataValueField = "CveDivision"
        RUnidad.DataBind()

        If RUnidad.Items.Count = 1 Then
            RUnidad.Items(0).Selected = True
            RegionPaises()
        Else
            BuildData()
        End If
    End Sub

    Sub RegionPaises()
        RRegionPaises.Items.Clear()
        RPaises.Items.Clear()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 1)
        PLoad(1) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(3) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RRegionPaises.DataSource = DS.Tables(0)
        RRegionPaises.DataTextField = "NOMAGRUPADO"
        RRegionPaises.DataValueField = "CVEAGRUPADO"
        RRegionPaises.DataBind()

        If RRegionPaises.Items.Count = 1 Then
            RRegionPaises.Items(0).Selected = True
            Pais()
        Else
            BuildData()
        End If
    End Sub

    Sub Pais()
        RPaises.Items.Clear()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(4) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 2)
        PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", RRegionPaises.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(4) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RPaises.DataSource = DS.Tables(0)
        RPaises.DataTextField = "PAIS"
        RPaises.DataValueField = "CVEPAIS"
        RPaises.DataBind()

        If RPaises.Items.Count = 1 Then
            RPaises.Items(0).Selected = True
            Territorio()
        Else
            BuildData()
        End If
    End Sub

    Sub Territorio()
        RTerritorios.Items.Clear()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(4) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 3)
        PLoad(1) = New SqlParameter("@CVEPAIS", RPaises.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(4) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RTerritorios.DataSource = DS.Tables(0)
        RTerritorios.DataTextField = "TERRITORIO"
        RTerritorios.DataValueField = "CVETERRITORIO"
        RTerritorios.DataBind()

        If RTerritorios.Items.Count = 1 Then
            RTerritorios.Items(0).Selected = True
            Region()
        Else
            BuildData()
        End If
    End Sub

    Sub Region()
        RRegiones.Items.Clear()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(4) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 4)
        PLoad(1) = New SqlParameter("@CVETERRITORIO", RTerritorios.SelectedValue)
        PLoad(2) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(4) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RRegiones.DataSource = DS.Tables(0)
        RRegiones.DataTextField = "NOMREGION"
        RRegiones.DataValueField = "CVEREGION"
        RRegiones.DataBind()

        If RRegiones.Items.Count = 1 Then
            RRegiones.Items(0).Selected = True
            Subregion()
        Else
            BuildData()
        End If
    End Sub

    Sub Subregion()
        RSubregiones.Items.Clear()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 5)
        PLoad(1) = New SqlParameter("@CVEREGION", RRegiones.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(3) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RSubregiones.DataSource = DS.Tables(0)
        RSubregiones.DataTextField = "NOMSUBREGION"
        RSubregiones.DataValueField = "CVESUBREGION"
        RSubregiones.DataBind()

        If RSubregiones.Items.Count = 1 Then
            RSubregiones.Items(0).Selected = True
            CentroDeTrabajo()
        Else
            BuildData()
        End If
    End Sub

    Sub CentroDeTrabajo()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(4) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 15)
        PLoad(1) = New SqlParameter("@CVEREGION", RRegiones.SelectedValue)
        PLoad(2) = New SqlParameter("@CVESUBREGION", RSubregiones.SelectedValue)
        PLoad(3) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(4) = New SqlParameter("@CVEAPLICACION", 2)
        Dim DS As DataSet = DatosBD.FuncionConPar("[Sp_CargaEstructura]", PLoad, Lerror)

        RCentroDeTrabajo.DataSource = DS.Tables(0)
        RCentroDeTrabajo.DataTextField = "NomEmpresa"
        RCentroDeTrabajo.DataValueField = "CveEmpresa"
        RCentroDeTrabajo.DataBind()

        If RCentroDeTrabajo.Items.Count = 1 Then
            RCentroDeTrabajo.Items(0).Selected = True
        Else
            BuildData()
        End If
    End Sub

    Sub TipoOperacion()
        Dim PLoad(3) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 7)
        PLoad(1) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
        PLoad(2) = New SqlParameter("@USUARIO", Session("Usuario"))
        PLoad(3) = New SqlParameter("@CVEAPLICACION", 2)
        Cargar.ComboParametros(RcbTipoOperacion, "SP_CargaEstructura", PLoad, "NOMAREA", "CVEAREA", 1, True, Session("Lenguaje"))
    End Sub

    Sub LlenarReporte()
        RReporte.Items.Clear()
        ' Dim CONSULTA As String
        Dim DS As DataSet
        Dim P(0) As SqlParameter
        If Session("Lenguaje") = "pt-BR" Then
            ' CONSULTA = "SELECT DISTINCT NUMREPORTE, NOMREPORTEPT AS NOMREPORTE, CAST(substring(NUMREPORTE,2,2) AS INT) FROM TblReporte_Ejecutivo WHERE VISIBLE=1 AND CVESECCION='CO' ORDER BY CAST(substring(NUMREPORTE,2,2) AS INT)"
            P(0) = New SqlParameter("@TIPO", 58)
        ElseIf Session("Lenguaje") = "en-US" Then
            'CONSULTA = "SELECT DISTINCT NUMREPORTE, NOMREPORTEEN AS NOMREPORTE, CAST(substring(NUMREPORTE,2,2) AS INT) FROM TblReporte_Ejecutivo WHERE VISIBLE=1 AND CVESECCION='CO' ORDER BY CAST(substring(NUMREPORTE,2,2) AS INT)"
            P(0) = New SqlParameter("@TIPO", 59)
        Else
            'CONSULTA = "SELECT DISTINCT NUMREPORTE, NOMREPORTE, CAST(substring(NUMREPORTE,2,2) AS INT) FROM TblReporte_Ejecutivo WHERE VISIBLE=1 AND CVESECCION='CO' ORDER BY CAST(substring(NUMREPORTE,2,2) AS INT)"
            P(0) = New SqlParameter("@TIPO", 60)
        End If
        'Dim DS As DataSet = DatosBD.FuncionTXT(CONSULTA, Lerror.Text)

        DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)



        RReporte.DataSource = DS.Tables(0)
        RReporte.DataTextField = "NOMREPORTE"
        RReporte.DataValueField = "NUMREPORTE"
        RReporte.DataBind()

        If RReporte.Items.Count = 1 Then
            RReporte.Items(0).Selected = True
            LlenarSubReporte()
        End If
    End Sub

    Protected Sub RReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RReporte.SelectedIndexChanged
        ReportViewer1.Visible = False
        LlenarSubReporte()
    End Sub

    Sub LlenarSubReporte()
        RSubreporte.Items.Clear()
        ' Dim CONSULTA As String
        Dim DS As DataSet
        Dim P(1) As SqlParameter
        If Session("Lenguaje") = "pt-BR" Then
            ' CONSULTA = "SELECT ORDEN, NOMSUBREPORTEPT AS NOMSUBREPORTE FROM TblReporte_Ejecutivo WHERE VISIBLE=1 AND CVESECCION='CO' AND NUMREPORTE='" & RReporte.SelectedValue & "' ORDER BY ORDEN"
            P(0) = New SqlParameter("@TIPO", 61)
            P(1) = New SqlParameter("@TIPOREPORTE", RReporte.SelectedValue)
        ElseIf Session("Lenguaje") = "en-US" Then
            ' CONSULTA = "SELECT ORDEN, NOMSUBREPORTEEN AS NOMSUBREPORTE FROM TblReporte_Ejecutivo WHERE VISIBLE=1 AND CVESECCION='CO' AND NUMREPORTE='" & RReporte.SelectedValue & "' ORDER BY ORDEN"
            P(0) = New SqlParameter("@TIPO", 62)
            P(1) = New SqlParameter("@TIPOREPORTE", RReporte.SelectedValue)
        Else
            'CONSULTA = "SELECT ORDEN, NOMSUBREPORTE FROM TblReporte_Ejecutivo WHERE VISIBLE=1 AND CVESECCION='CO' AND NUMREPORTE='" & RReporte.SelectedValue & "' ORDER BY ORDEN"
            P(0) = New SqlParameter("@TIPO", 63)
            P(1) = New SqlParameter("@TIPOREPORTE", RReporte.SelectedValue)
        End If
        'Dim DS As DataSet = DatosBD.FuncionTXT(CONSULTA, Lerror.Text)

        DS = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)

        RSubreporte.DataSource = DS.Tables(0)
        RSubreporte.DataTextField = "NOMSUBREPORTE"
        RSubreporte.DataValueField = "ORDEN"
        RSubreporte.DataBind()

        If RSubreporte.Items.Count = 1 Then
            RSubreporte.Items(0).Selected = True
            BuildData()
        End If
    End Sub

    Protected Sub RSubReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RSubreporte.SelectedIndexChanged
        BuildData()
    End Sub

    Sub BuildData()
        If RSubreporte.SelectedValue <> "" Then
            ReportViewer1.Visible = False
            Dim NumReporte As String
            NumReporte = RSubreporte.SelectedValue.ToString

            If NumReporte = "1" Then
                ReportViewer1.Report = New REQueEsClima
            ElseIf NumReporte = "2" Then
                ReportViewer1.Report = New REParticipacion
            ElseIf NumReporte = "3" Then
                ReportViewer1.Report = New REClimaOrganizacional
            ElseIf NumReporte = "4" Then
                ReportViewer1.Report = New RESubSistemas
            ElseIf NumReporte = "5" Then
                ReportViewer1.Report = New REDemograficos
            ElseIf NumReporte = "7" Then
                ReportViewer1.Report = New REBenchmark
            ElseIf NumReporte = "8" Then
                ReportViewer1.Report = New REComentatios
            ElseIf NumReporte = "9" And RCentroDeTrabajo.SelectedItems.Count > 0 Then
                ReportViewer1.Report = New RELiderazgo
            Else
                Exit Sub
            End If

            ReportViewer1.Visible = True
            ReportViewer1.ZoomPercent = 80

            'Set the parameters
            Dim NomReporte As String
            NomReporte = RSubreporte.SelectedItem.Text

            ReportViewer1.Report.ReportParameters(0).Value = ""
            ReportViewer1.Report.ReportParameters(1).Value = NomReporte
            ReportViewer1.Report.ReportParameters(2).Value = 99

            BuildReport(NumReporte, ReportViewer1.Report)
        End If
    End Sub

    Private Sub BuildReport(ByVal NumReporte As String, ByVal reportToExport As Telerik.Reporting.Report)
        Try
            Dim Stored As String
            Dim ds As New DataSet
            Stored = "SP_Reporte_Ejecutivo"

            Lerror.Text = ""
            Dim PLoad(12) As SqlParameter
            PLoad(0) = New SqlParameter("@CVEREPORTE", NumReporte)
            If RUnidad.SelectedItems.Count = 0 Then
                Session("RUnidad") = DBNull.Value
                PLoad(1) = New SqlParameter("@CVEDIVISION", DBNull.Value)
            Else
                Session("RUnidad") = RUnidad.SelectedValue
                PLoad(1) = New SqlParameter("@CVEDIVISION", RUnidad.SelectedValue)
            End If

            If RRegionPaises.SelectedItems.Count = 0 Then
                Session("RRegionPaises") = DBNull.Value
                PLoad(2) = New SqlParameter("@CVEAGRUPADOPAIS", DBNull.Value)
            Else
                Session("RRegionPaises") = RRegionPaises.SelectedItem.Value
                PLoad(2) = New SqlParameter("@CVEAGRUPADOPAIS", RRegionPaises.SelectedValue)
            End If

            If RPaises.SelectedItems.Count = 0 Then
                Session("RPaises") = DBNull.Value
                PLoad(3) = New SqlParameter("@CVEPAIS", DBNull.Value)
            Else
                Session("RPaises") = RPaises.SelectedItem.Value
                PLoad(3) = New SqlParameter("@CVEPAIS", RPaises.SelectedValue)
            End If

            'Meter concepto area
            If Session("SesTipoOperacion") Is Nothing Or Session("SesTipoOperacion") = "-1" Then
                Session("RTipoOperacion") = DBNull.Value
                PLoad(4) = New SqlParameter("@CVEAREA", DBNull.Value)
            Else
                Session("RTipoOperacion") = Session("SesTipoOperacion")
                PLoad(4) = New SqlParameter("@CVEAREA", Session("SesTipoOperacion"))
            End If

            If RTerritorios.SelectedValue = "-1" Or RTerritorios.SelectedValue = "" Then
                Session("RTerritorios") = DBNull.Value
                PLoad(5) = New SqlParameter("@CVETERRITORIO", DBNull.Value)
            Else
                Session("RTerritorios") = RTerritorios.SelectedItem.Value
                PLoad(5) = New SqlParameter("@CVETERRITORIO", RTerritorios.SelectedValue)
            End If

            If RRegiones.SelectedItems.Count = 0 Then
                Session("RRegiones") = DBNull.Value
                PLoad(6) = New SqlParameter("@CVEREGION", DBNull.Value)
            Else
                Session("RRegiones") = RRegiones.SelectedItem.Value
                PLoad(6) = New SqlParameter("@CVEREGION", RRegiones.SelectedValue)
            End If

            If RSubregiones.SelectedItems.Count = 0 Then
                Session("RSubregiones") = DBNull.Value
                PLoad(7) = New SqlParameter("@CVESUBREGION", DBNull.Value)
            Else
                Session("RSubregiones") = RSubregiones.SelectedItem.Value
                PLoad(7) = New SqlParameter("@CVESUBREGION", RSubregiones.SelectedValue)
            End If

            If RCentroDeTrabajo.SelectedItems.Count = 0 Then
                Session("REmpresas") = DBNull.Value
                PLoad(8) = New SqlParameter("@CVEEMPRESA", DBNull.Value)
            Else
                Session("REmpresas") = RCentroDeTrabajo.SelectedItem.Value
                PLoad(8) = New SqlParameter("@CVEEMPRESA", RCentroDeTrabajo.SelectedValue)
            End If

            If RUnidad.SelectedValue = 9 Then
                PLoad(9) = New SqlParameter("@CVESISTEMA", 13)
            Else
                PLoad(9) = New SqlParameter("@CVESISTEMA", 3)
            End If


            PLoad(10) = New SqlParameter("@CVEPERFIL", 1)
            PLoad(11) = New SqlParameter("@USUARIO", Session("Usuario"))
            PLoad(12) = New SqlParameter("@IDIOMA", 99)

            ds = DatosBD.FuncionConPar("SP_Reporte_Ejecutivo", PLoad, Lerror.Text)

            If Not ds Is Nothing Then
                Session("DSReporteEjecutivo") = ds
            End If
        Catch ex As Exception
            Lerror.Text = "No existe información para este reporte."
        End Try
    End Sub

End Class
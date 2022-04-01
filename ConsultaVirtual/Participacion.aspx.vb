Imports Telerik.Web.UI
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports System.Configuration
Imports System.IO

Public Class Participacion
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
            
                Unidades()
                 
               

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
            ' If Session("NumGrafica") = "Participación" Then
            VAL = FormatNumber(Datos.Rows(i).Item(4), 1)
            TEXTO = Datos.Rows(i).Item(1)
            'Else
            'VAL = FormatNumber(Datos.Rows(i).Item(3), 1)
            'TEXTO = Datos.Rows(i).Item(1)
            'End If

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


    End Sub


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

    End Sub

  

   

    Sub BuildParticipacion(cveempresa As Integer)
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@CveEmpresa", cveempresa)
        p(1) = New SqlParameter("@CvePerfil", Session("NUMPERFIL"))
        Dim ds As New DataSet
        ds = DatosBD.FuncionConPar("SP_PARTICIPACION_HISTORICO", p, Lerror.Text, "tblParticipacion")
        Graficar(ds.Tables(0), "CONCEPTO", "PORCENTAJE", "", "PARTICIPACION", "GRÁFICA DE PARTICIPACIÓN", Session("NombreEmpresa"))
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
                LEmpresa.Text = Clave
                Session("TipoGrafica") = "S8"
            End If

            BRegresar.Visible = True
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub


    Protected Sub RUnidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RUnidad.SelectedIndexChanged
        RegionPaises()
        Chart1.Visible = False
    End Sub

    Protected Sub RRegionPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RRegionPaises.SelectedIndexChanged
        Pais()
        Chart1.Visible = False
    End Sub

    Protected Sub RPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RPaises.SelectedIndexChanged
        Territorio()
        Chart1.Visible = False
    End Sub

    Private Sub RTerritorios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RTerritorios.SelectedIndexChanged
        Region()
        Chart1.Visible = False
    End Sub

    Protected Sub RRegiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RRegiones.SelectedIndexChanged
        Subregion()
        Chart1.Visible = False
    End Sub

    Protected Sub RSubregiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RSubregiones.SelectedIndexChanged
        CentroDeTrabajo()
        Chart1.Visible = False
    End Sub

    Protected Sub RCentroDeTrabajo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RCentroDeTrabajo.SelectedIndexChanged
        Session("CveEmpCODRIVE") = RCentroDeTrabajo.SelectedValue
        Dim ds As New DataSet
        Dim P(1) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 13)
        P(1) = New SqlParameter("@CVEEMPRESA", RCentroDeTrabajo.SelectedValue)
        ds = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)

        Session("NombreEmpresa") = ds.Tables(0).Rows(0).Item(0)

        BuildParticipacion(RCentroDeTrabajo.SelectedValue)
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

        End If
    End Sub

    Sub CentroDeTrabajo()
        RCentroDeTrabajo.Items.Clear()

        Dim Lerror As String = String.Empty
        Dim PLoad(2) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 0)
        PLoad(1) = New SqlParameter("@CVEREGION", RRegiones.SelectedValue)
        PLoad(2) = New SqlParameter("@CVESUBREGION", RSubregiones.SelectedValue)

        Dim DS As DataSet = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", PLoad, Lerror)

        RCentroDeTrabajo.DataSource = DS.Tables(0)
        RCentroDeTrabajo.DataTextField = "NomEmpresa"
        RCentroDeTrabajo.DataValueField = "CveEmpresa"
        RCentroDeTrabajo.DataBind()

        If RCentroDeTrabajo.Items.Count = 1 Then
            RCentroDeTrabajo.Items(0).Selected = True
            Session("CveEmpCODRIVE") = RCentroDeTrabajo.SelectedValue
            ' BuildData()


        End If
    End Sub

End Class
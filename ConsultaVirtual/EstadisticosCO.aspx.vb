Imports Telerik.Web.UI
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.IO

Public Class EstadisticosCO
    Inherits System.Web.UI.Page

    Protected Overrides Sub InitializeCulture()
        If Not Session("Lenguaje") Is Nothing Then
            UICulture = Session("Lenguaje")
            Culture = Session("Lenguaje")
        End If
        MyBase.InitializeCulture()
    End Sub

    Dim CveEmpresa As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CON") = "OK" Then
            If Not Page.IsPostBack Then
                Session("CveEmpresaEst") = Request.Params("Em")
                RadGrid1.DataSource = Nothing
                RadGrid1.DataBind()


                Dim CONSULTA As String
                Dim ds As New DataSet
                Dim P(11) As SqlParameter

                P(0) = New SqlParameter("@CVEDIVISION", Session("CveUnidad"))
                P(1) = New SqlParameter("@CVEAGRUPADOPAIS", Session("CveAgrupado"))
                P(2) = New SqlParameter("@CVEPAIS", Session("CvePais"))
                P(3) = New SqlParameter("@CVEAREA", Session("CveTipo"))
                P(4) = New SqlParameter("@CVETERRITORIO", Session("CveTerritorio"))
                P(5) = New SqlParameter("@CVEREGION", Session("CveRegion"))
                P(6) = New SqlParameter("@CVESUBREGION", Session("CveSubRegion"))
                P(7) = New SqlParameter("@CVESISTEMA", 3)
                P(8) = New SqlParameter("@USUARIO", Session("USUARIO"))

                If Session("Lenguaje") = "pt-BR" Then
                    P(9) = New SqlParameter("@IDIOMA", 2)
                ElseIf Session("Lenguaje") = "en-US" Then
                    P(9) = New SqlParameter("@IDIOMA", 11)
                Else
                    P(9) = New SqlParameter("@IDIOMA", 99)
                End If
                P(10) = New SqlParameter("@TIPO", 1)



                P(11) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresaEst"))


                ds = DatosBD.FuncionConPar("SP_RptEstadisticas", P, Lerror.Text)


                RCBTemas.DataSource = ds.Tables(0)
                RCBTemas.DataTextField = "DescTema"
                RCBTemas.DataValueField = "CveTema"
                RCBTemas.DataBind()




            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Private Sub RCBTemas_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RCBTemas.SelectedIndexChanged
        CargaGrid()
    End Sub



    Sub CargaGrid()
        Try
            Dim ds As New DataSet
            Dim PLoad(11) As SqlParameter
            PLoad(0) = New SqlParameter("@CVEDIVISION", Session("CveUnidad"))
            PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", Session("CveAgrupado"))
            PLoad(2) = New SqlParameter("@CVEPAIS", Session("CvePais"))
            PLoad(3) = New SqlParameter("@CVETEMA", RCBTemas.SelectedValue)
            PLoad(4) = New SqlParameter("@CVETERRITORIO", Session("CveTerritorio"))
            PLoad(5) = New SqlParameter("@CVEREGION", Session("CveRegion"))
            PLoad(6) = New SqlParameter("@CVESUBREGION", Session("CveSubRegion"))
            PLoad(7) = New SqlParameter("@CVESISTEMA", 3)
            PLoad(8) = New SqlParameter("@USUARIO", Session("USUARIO"))

            If Session("Lenguaje") = "pt-BR" Then
                PLoad(9) = New SqlParameter("@IDIOMA", 2)
            ElseIf Session("Lenguaje") = "en-US" Then
                PLoad(9) = New SqlParameter("@IDIOMA", 11)

            Else
                PLoad(9) = New SqlParameter("@IDIOMA", 99)
            End If
            PLoad(10) = New SqlParameter("@TIPO", 0)
            

                PLoad(11) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresaEst"))

            ds = DatosBD.FuncionConPar("SP_RptEstadisticas", PLoad, Lerror.Text)
            RadGrid1.DataSource = ds.Tables(0)
            RadGrid1.DataBind()



            TR2.Visible = True

        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub BTNREPORTE_Click(sender As Object, e As EventArgs) Handles BTNREPORTE.Click
        CargaGrid2()
        CrearReporte()
    End Sub
    Sub CrearReporte()
        RadGrid2.ExportSettings.ExportOnlyData = True
        RadGrid2.ExportSettings.OpenInNewWindow = True
        RadGrid2.MasterTableView.ExportToExcel()
    End Sub

    Sub CargaGrid2()

        Try
            Dim ds As New DataSet
            Dim PLoad(11) As SqlParameter
            PLoad(0) = New SqlParameter("@CVEDIVISION", Session("CveUnidad"))
            PLoad(1) = New SqlParameter("@CVEAGRUPADOPAIS", Session("CveAgrupado"))
            PLoad(2) = New SqlParameter("@CVEPAIS", Session("CvePais"))
            PLoad(3) = New SqlParameter("@CVETEMA", RCBTemas.SelectedValue)
            PLoad(4) = New SqlParameter("@CVETERRITORIO", Session("CveTerritorio"))
            PLoad(5) = New SqlParameter("@CVEREGION", Session("CveRegion"))
            PLoad(6) = New SqlParameter("@CVESUBREGION", Session("CveSubRegion"))
            PLoad(7) = New SqlParameter("@CVESISTEMA", 3)
            PLoad(8) = New SqlParameter("@USUARIO", Session("USUARIO"))

            If Session("Lenguaje") = "pt-BR" Then
                PLoad(9) = New SqlParameter("@IDIOMA", 2)
            ElseIf Session("Lenguaje") = "en-US" Then
                PLoad(9) = New SqlParameter("@IDIOMA", 11)

            Else
                PLoad(9) = New SqlParameter("@IDIOMA", 99)
            End If
            PLoad(10) = New SqlParameter("@TIPO", 2)


            PLoad(11) = New SqlParameter("@CVEEMPRESA", Session("CveEmpresaEst"))

            ds = DatosBD.FuncionConPar("SP_RptEstadisticas", PLoad, Lerror.Text)
            RadGrid2.DataSource = ds.Tables(0)
            RadGrid2.DataBind()




        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub
End Class
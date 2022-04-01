Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Net
Imports System.IO
Imports System.Configuration.ConfigurationManager
Imports System.Net.Mail
Imports System.Configuration
Imports System.Globalization


Public Class SynchSystem
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
                RadAsyncUpload1.Visible = False
                Button1.Visible = False
                Unidades()
                'LRuta.text = "\\femmsiliis1\RespaldoCO\CODRIVE\"
            End If
            'LlenarReporte()

        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub
  
   

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim PLoad(1) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 9)
        PLoad(1) = New SqlParameter("@CVEEMPRESA", RCentroDeTrabajo.SelectedValue)
        Dim DS As DataSet = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", PLoad, Lerror.Text)

        Dim flag As Integer = DS.Tables(0).Rows(0).Item(0)
        Dim empresa As Integer
        'If RCentroDeTrabajo.SelectedIndex > 0 Then
        empresa = RCentroDeTrabajo.SelectedValue
        'Else
        'empresa = 999
        'End If
        For Each f As UploadedFile In RadAsyncUpload1.UploadedFiles
            flag = flag + 1
            Dim fileName As String = f.GetNameWithoutExtension + "_" + empresa.ToString + "_" + flag.ToString + ".mdb"

           

            'f.SaveAs("\\femmsiliis1\RespaldoCO\CODRIVE\" + f.GetName, True)
            f.SaveAs("\\femmsiliis1\RespaldoCO\CODRIVE\" + fileName, True)
            'Guardarutasparacargagrid()

            Dim PLoad2(4) As SqlParameter
            PLoad2(0) = New SqlParameter("@TIPO", 10)
            PLoad2(1) = New SqlParameter("@CVEEMPRESA", RCentroDeTrabajo.SelectedValue)
            PLoad2(2) = New SqlParameter("@RUTA", "\\femmsiliis1\RespaldoCO\CODRIVE\" + fileName)
            PLoad2(3) = New SqlParameter("@FILENAME", fileName)
            PLoad2(4) = New SqlParameter("@USUARIO", Session("USUARIO"))
            Dim DS2 As DataSet = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", PLoad2, Lerror.Text)

        Next

        RadAsyncUpload1.Dispose()
        CargaGrid()

        If Lerror.Text = "" Then
            RadNotification1.Text = "<table>" & _
                                    "<tr>" & _
                                    "<td align=""center"">" & _
                                    "<b>Se mandaron los archivos con éxito!</b>" & _
                                    "</td>" & _
                                    "</tr>" & _
                                    "<tr>" &
                                    "<td align=""Center"">" & _
                                    "<IMG    SRC=""Imagenes/CoDrive/ok2.png"" width=""100px"" align=""Center"">" & _
                                    "</td>" & _
                                    "</tr>" & _
                                    "</table>" & _
""
            RadNotification1.Show()
        Else
            RadNotification1.Text = "Se perdio la conexion con el servidor " & Lerror.Text & ", revise su conexión"
            RadNotification1.Show()
        End If
     


        'Label1.Visible = False
        ' Label1.Text = "Uploaded Succsesfully"
        'Label1.ForeColor = Drawing.Color.Green

        ' Response.Redirect("SynchSystem.aspx?E=1")

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If (e.CommandName = "Download") Then
            Descarga(CStr(e.Item.Cells(4).Text), e.Item.Cells(2).Text)
        End If
    End Sub


    Sub Descarga(ruta As String, filename As String)
        Response.Clear()
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", "attachment; filename=""" & filename & """")
        ' Response.Flush()
        'Response.WriteFile(ruta)
        Response.TransmitFile(ruta)
        Response.End()
    End Sub
 
    
    Protected Sub RUnidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RUnidad.SelectedIndexChanged
        RegionPaises()

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
        Session("CveEmpCODRIVE") = RCentroDeTrabajo.SelectedValue
        RadAsyncUpload1.Visible = True
        Button1.Visible = True
        CargaGrid()
    End Sub

    Sub CargaGrid()

        Dim DS As DataSet
        Dim PLoad(1) As SqlParameter
        PLoad(0) = New SqlParameter("@TIPO", 8)
        PLoad(1) = New SqlParameter("@CVEEMPRESA", Session("CveEmpCODRIVE"))

        DS = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", PLoad, Lerror.Text)
        RadGrid1.DataSource = DS.Tables(0)
        RadGrid1.DataBind()
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
        RadAsyncUpload1.Visible = False
        Button1.Visible = False

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
        RadAsyncUpload1.Visible = False
        Button1.Visible = False

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
        RadAsyncUpload1.Visible = False
        Button1.Visible = False

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
        RadAsyncUpload1.Visible = False
        Button1.Visible = False

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
        RadAsyncUpload1.Visible = False
        Button1.Visible = False

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
        RadAsyncUpload1.Visible = False
        Button1.Visible = False

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
        RadAsyncUpload1.Visible = False
        Button1.Visible = False

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



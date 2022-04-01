Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Net
Imports System.IO



Public Class GenerarInstalador
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
            End If
            'LlenarReporte()

        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If

    End Sub

    'Sub CargaFiltros()
    '    RUnidad.SelectedValue = Session("CODRIVEUNIDAD")
    '    RRegionPaises.SelectedValue = Session("CODRIVEAGRUPADO")
    '    RPaises.SelectedValue = Session("CODRIVEPAIS")
    '    RTerritorios.SelectedValue = Session("CODRIVETERRITORIO")
    '    RRegiones.SelectedValue = Session("CODRIVEREGION")
    '    RSubregiones.SelectedValue = Session("CODRIVESUBREGION")
    '    RCentroDeTrabajo.SelectedValue = Session("CODRIVECT")

    'End Sub

    Protected Sub RUnidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RUnidad.SelectedIndexChanged
        RegionPaises()
        ImageButton1.Visible = False
        ImageButton2.Visible = False
        ImageButton3.Visible = False
    End Sub

    Protected Sub RRegionPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RRegionPaises.SelectedIndexChanged
        Pais()
        ImageButton1.Visible = False
        ImageButton2.Visible = False
        ImageButton3.Visible = False
    End Sub

    Protected Sub RPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RPaises.SelectedIndexChanged
        Territorio()
        ImageButton1.Visible = False
        ImageButton2.Visible = False
        ImageButton3.Visible = False
    End Sub

    Private Sub RTerritorios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RTerritorios.SelectedIndexChanged
        Region()
        ImageButton1.Visible = False
        ImageButton2.Visible = False
        ImageButton3.Visible = False
    End Sub

    Protected Sub RRegiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RRegiones.SelectedIndexChanged
        Subregion()
        ImageButton1.Visible = False
        ImageButton2.Visible = False
        ImageButton3.Visible = False
    End Sub

    Protected Sub RSubregiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RSubregiones.SelectedIndexChanged
        CentroDeTrabajo()
        ImageButton1.Visible = False
        ImageButton2.Visible = False
        ImageButton3.Visible = False
    End Sub

    Protected Sub RCentroDeTrabajo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RCentroDeTrabajo.SelectedIndexChanged
        Session("CveEmpCODRIVE") = RCentroDeTrabajo.SelectedValue
        ImageButton1.Visible = True
        'BuildData()
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

        'If RCentroDeTrabajo.Items.Count = 1 Then
        '    RCentroDeTrabajo.Items(0).Selected = True
        '    Session("CveEmpCODRIVE") = RCentroDeTrabajo.SelectedValue
        '    ' BuildData()


        'End If
    End Sub

    Private Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        ' fountainG.Visible = True
        ' Connecting.Visible = True
        'ImageButton1.Enabled = False
        InsertaAccess()

    End Sub


    Public Sub ConnectToAccess(sentencia As String)
        Dim conn As New System.Data.OleDb.OleDbConnection()
        Try
            'funbcion sin parametros
            Dim comando As New OleDb.OleDbCommand
            ' Dim adap As New OleDb.OleDbDataAdapter
            ' Dim dset As New DataSet
            comando.CommandTimeout = 0
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & _
          "\\femmsiliis1\RespaldoCO\BDCODRIVE\CoDrive.mdb"
            conn.Open()
            comando.Connection = conn
            comando.CommandType = CommandType.Text
            comando.CommandText = sentencia
            comando.ExecuteNonQuery()
            'adap.SelectCommand = comando
            'adap.Fill(dset)
            'Session("Dataset") = dset
        Catch ex As Exception
            Lerror.Text = "Delete " & ex.Message & " " & sentencia
        Finally
            conn.Close()
        End Try

    End Sub

    Sub Cargadatasets()
        Dim ds As New DataSet
        Dim P(1) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 7)
        P(1) = New SqlParameter("@CVEEMPRESA", RCentroDeTrabajo.SelectedValue)
        ds = DatosBD.FuncionConPar("SP_CONSULTAS_CODRIVE", P, Lerror.Text)

        'TBLPREGUNTA
            Try
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ConnectToAccess("INSERT INTO tblpregunta (CVEENCUESTA,CVEPREGUNTA,CVETEMA,DESCLARGA,DESCCORTA,IndicadorRespuestaDada,CveTipoRespuesta,MideSatisfaccion,Obligatorio,Complemento,NoAplica,PilaPregunta,CveCritica)" & _
                                "values (" & ds.Tables(0).Rows(i).Item(0) & "," & ds.Tables(0).Rows(i).Item(1) & "," & ds.Tables(0).Rows(i).Item(2) & ",'" & ds.Tables(0).Rows(i).Item(3) & "','" & ds.Tables(0).Rows(i).Item(4) & "'," & ds.Tables(0).Rows(i).Item(5) & "," & ds.Tables(0).Rows(i).Item(6) & "," & ds.Tables(0).Rows(i).Item(7) & "," & ds.Tables(0).Rows(i).Item(8) & ",'" & ds.Tables(0).Rows(i).Item(9) & "'," & ds.Tables(0).Rows(i).Item(10) & "," & ds.Tables(0).Rows(i).Item(11) & "," & ds.Tables(0).Rows(i).Item(12) & ")")
            Next
            Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion tblpregunta: " & ex.StackTrace
            End Try


        'TBLTEMA
        Try
            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                ConnectToAccess("INSERT INTO tbltema (CVEENCUESTA,CVETEMA,DESCTEMA,DURACIONSEGUNDOS,PILATEMA)" & _
                                "values (" & ds.Tables(1).Rows(i).Item(0) & "," & ds.Tables(1).Rows(i).Item(1) & ",'" & ds.Tables(1).Rows(i).Item(2) & "'," & ds.Tables(1).Rows(i).Item(3) & "," & ds.Tables(1).Rows(i).Item(4) & ")")
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion tbltema: " & ex.StackTrace
        End Try

        'TBLENCUESTA
        Try
            For i As Integer = 0 To ds.Tables(2).Rows.Count - 1
                ConnectToAccess("INSERT INTO tblencuesta (CVEENCUESTA,descencuesta,fechaencuesta,totpersonas,midesatisfaccion,cvedivision,cvepais,cvesistema,estatus,tipoencuesta)" & _
                                "values (" & ds.Tables(2).Rows(i).Item(0) & ",'" & ds.Tables(2).Rows(i).Item(1) & "','" & ds.Tables(2).Rows(i).Item(2) & "'," & ds.Tables(2).Rows(i).Item(3) & "," & ds.Tables(2).Rows(i).Item(4) & "," & ds.Tables(2).Rows(i).Item(5) & "," & ds.Tables(2).Rows(i).Item(6) & "," & ds.Tables(2).Rows(i).Item(7) & "," & ds.Tables(2).Rows(i).Item(8) & ",'" & ds.Tables(2).Rows(i).Item(9) & "')")
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion tblencuesta: " & ex.StackTrace
        End Try


        'TBLRANGOEDAD
        Try
            For i As Integer = 0 To ds.Tables(3).Rows.Count - 1
                ConnectToAccess("INSERT INTO TblRangoEdad (CVEEDAD,DESCRIPCION,DESCRIPCIONEN,DESCRIPCIONPT)" & _
                                "values (" & ds.Tables(3).Rows(i).Item(0) & ",'" & ds.Tables(3).Rows(i).Item(1) & "','" & ds.Tables(3).Rows(i).Item(2) & "','" & ds.Tables(3).Rows(i).Item(3) & "')")
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion TblRangoEdad: " & ex.StackTrace
        End Try

        'TBLRANGOANTIGUEDAD
        Try
            For i As Integer = 0 To ds.Tables(4).Rows.Count - 1
                ConnectToAccess("INSERT INTO TBLRANGOANTIGUEDAD (CVEANTIGUEDAD,DESCRIPCION,DESCRIPCIONEN,DESCRIPCIONPT)" & _
                                "values (" & ds.Tables(4).Rows(i).Item(0) & ",'" & ds.Tables(4).Rows(i).Item(1) & "','" & ds.Tables(4).Rows(i).Item(2) & "','" & ds.Tables(4).Rows(i).Item(3) & "')")
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion TBLRANGOANTIGUEDAD: " & ex.StackTrace
        End Try


        'TBLNIVEL
        Try
            For i As Integer = 0 To ds.Tables(5).Rows.Count - 1
                ConnectToAccess("INSERT INTO tblNivel (CVENIVEL,DESCNIVEL,GENTEACARGO)" & _
                                "values (" & ds.Tables(5).Rows(i).Item(0) & ",'" & ds.Tables(5).Rows(i).Item(1) & "','" & ds.Tables(5).Rows(i).Item(2) & "')")
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion tblNivel: " & ex.StackTrace
        End Try

        'TBLRESPUESTA
        Try
            For i As Integer = 0 To ds.Tables(6).Rows.Count - 1
                ConnectToAccess("INSERT INTO tblRespuesta (CVETIPORESPUESTA,ORDENRESPUESTA,DESCRESPUESTA,VALORPONDERADO,SATISFECHO)" & _
                                "values (" & ds.Tables(6).Rows(i).Item(0) & "," & ds.Tables(6).Rows(i).Item(1) & ",'" & ds.Tables(6).Rows(i).Item(2) & "'," & ds.Tables(6).Rows(i).Item(3) & "," & ds.Tables(6).Rows(i).Item(4) & ")")
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion tblRespuesta: " & ex.StackTrace
        End Try

        'TBLPERSONAL
        Try
            For i As Integer = 0 To ds.Tables(7).Rows.Count - 1
                ConnectToAccess("INSERT INTO TBLPERSONAL (CVEEMPRESA,NUMTRABAJADOR,APELLIDOPATERNO,APELLIDOMATERNO,NOMBRE,FECHAINGRESO,FECHANACIMIENTO,CVEDEPTO,CVENIVEL,SINDICONOSINDICO,CVESUBDEPTO,PUESTO,CVESUBSUBDEPTO,IDPERFILEFECTIVIDAD)" & _
                                "values (" & ds.Tables(7).Rows(i).Item(0) & "," & ds.Tables(7).Rows(i).Item(1) & ",'" & ds.Tables(7).Rows(i).Item(2) & "','" & ds.Tables(7).Rows(i).Item(3) & "','" & ds.Tables(7).Rows(i).Item(4) & "','" & ds.Tables(7).Rows(i).Item(5) & "','" & ds.Tables(7).Rows(i).Item(6) & "'," & ds.Tables(7).Rows(i).Item(7) & "," & ds.Tables(7).Rows(i).Item(8) & "," & ds.Tables(7).Rows(i).Item(9) & "," & ds.Tables(7).Rows(i).Item(10) & ",'" & ds.Tables(7).Rows(i).Item(11) & "'," & ds.Tables(7).Rows(i).Item(12) & "," & ds.Tables(7).Rows(i).Item(13) & ")")
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion TBLPERSONAL: " & ex.StackTrace
        End Try

        'TBLDEPARTAMENTO
        Try
            For i As Integer = 0 To ds.Tables(8).Rows.Count - 1
                ConnectToAccess("INSERT INTO TBLDEPARTAMENTO (CVEEMPRESA,CVEDEPTO,NOMDEPTO)" & _
                                  "values (" & ds.Tables(8).Rows(i).Item(0) & "," & ds.Tables(8).Rows(i).Item(1) & ",'" & ds.Tables(8).Rows(i).Item(2) & "')")
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion TBLDEPARTAMENTO: " & ex.StackTrace
        End Try

        'TBLSUBDEPARATMENTO
        Try
            For i As Integer = 0 To ds.Tables(9).Rows.Count - 1
                ConnectToAccess("INSERT INTO tblSUBdepartamento (CVEEMPRESA,CVEDEPTO,CVESUBDEPTO,NOMSUBDEPTO)" & _
                                  "values (" & ds.Tables(9).Rows(i).Item(0) & "," & ds.Tables(9).Rows(i).Item(1) & "," & ds.Tables(9).Rows(i).Item(2) & ",'" & ds.Tables(9).Rows(i).Item(2) & "')")
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion tblSUBdepartamento: " & ex.StackTrace
        End Try

        'TBLSUBSUBDEPARTAMENTO
        Try
            For i As Integer = 0 To ds.Tables(10).Rows.Count - 1
                ConnectToAccess("INSERT INTO tblSUBSUBdepartamento (CVEEMPRESA,CVEDEPTO,CVESUBDEPTO,CVESUBSUBDEPTO,NOMSUBSUBDEPTO)" & _
                                  "values (" & ds.Tables(10).Rows(i).Item(0) & "," & ds.Tables(10).Rows(i).Item(1) & "," & ds.Tables(10).Rows(i).Item(2) & "," & ds.Tables(10).Rows(i).Item(2) & "," & ds.Tables(10).Rows(i).Item(2) & ")")
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion tblSUBSUBdepartamento: " & ex.StackTrace
        End Try


        'TBLEMPRESA
        Try
            For i As Integer = 0 To ds.Tables(11).Rows.Count - 1
                ConnectToAccess("INSERT INTO TBLEMPRESA (CVEEMPRESA,NOMEMPRESA,RESPONSABLE,CVEDIVISION,CVEAGRUPADOPAIS,CVEPAIS,CVEAREA,CVETERRITORIO,CVEREGION,CVESUBREGION,CVEESTADO,CVECIUDAD,CVESAP,CVEESQUEMA,HC,PADRE,ESTATUS,ESTATUSSIL,ESTATUSSASSO,NOTAS)" & _
                                   "values (" & ds.Tables(11).Rows(i).Item(0) & ",'" & ds.Tables(11).Rows(i).Item(1) & "'," & ds.Tables(11).Rows(i).Item(2) & "," & ds.Tables(11).Rows(i).Item(3) & "," & ds.Tables(11).Rows(i).Item(4) & "," & ds.Tables(11).Rows(i).Item(5) & "," & ds.Tables(11).Rows(i).Item(6) & "," & ds.Tables(11).Rows(i).Item(7) & "," & ds.Tables(11).Rows(i).Item(8) & "," & ds.Tables(11).Rows(i).Item(9) & "," & ds.Tables(11).Rows(i).Item(10) & "," & ds.Tables(11).Rows(i).Item(11) & ",'" & ds.Tables(11).Rows(i).Item(12) & "'," & ds.Tables(11).Rows(i).Item(13) & "," & ds.Tables(11).Rows(i).Item(14) & "," & ds.Tables(11).Rows(i).Item(15) & "," & ds.Tables(11).Rows(i).Item(16) & "," & ds.Tables(11).Rows(i).Item(17) & "," & ds.Tables(11).Rows(i).Item(18) & ",'" & ds.Tables(11).Rows(i).Item(19) & "')")
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion TBLEMPRESA: " & ex.StackTrace
        End Try


    End Sub

    Sub InsertaAccess()
        'BORRA E INSERTA
        ConnectToAccess("delete from tblpregunta")
        ConnectToAccess("delete from tbltema")
        ConnectToAccess("delete from tblencuesta")
        ConnectToAccess("delete from TblRangoEdad")
        ConnectToAccess("delete from TblRangoAntiguedad")
        ConnectToAccess("delete from tblNivel")
        ConnectToAccess("delete from tblRespuesta")
        ConnectToAccess("delete from tblpersonal")
        ConnectToAccess("delete from tbldepartamento")
        ConnectToAccess("delete from tblSUBdepartamento")
        ConnectToAccess("delete from tblSUBSUBdepartamento")
        ConnectToAccess("delete from TBLEMPRESA")

        'SOLO BORRA
        ConnectToAccess("delete from tbldatospersonales")
        ConnectToAccess("delete from tblregistrousuarioencuesta")
        ConnectToAccess("delete from tblencuestarealizada")
        ConnectToAccess("delete from tblrespuestadadanumerica")
        ConnectToAccess("delete from tblsociometria")
        ConnectToAccess("delete from tblLider")
        ConnectToAccess("delete from tblRespuestaDadaTexto")
        ConnectToAccess("delete from tblClaseCom")



        Cargadatasets()

        'Thread.Sleep(5000)
        ImageButton1.Enabled = True

        Label1.Visible = False
        ImageButton1.Visible = False

        ImageButton2.Visible = True
        ImageButton3.Visible = True
        Label1.Text = "Generated Succsefully"
        Label1.ForeColor = Drawing.Color.Green


        'Session("CODRIVEUNIDAD") = RUnidad.SelectedValue
        'Session("CODRIVEAGRUPADO") = RRegionPaises.SelectedValue
        'Session("CODRIVEPAIS") = RPaises.SelectedValue
        'Session("CODRIVETERRITORIO") = RTerritorios.SelectedValue
        'Session("CODRIVEREGION") = RRegiones.SelectedValue
        'Session("CODRIVESUBREGION") = RSubregiones.SelectedValue
        'Session("CODRIVECT") = RCentroDeTrabajo.SelectedValue

        'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "ocultar();", True)
        'Response.Redirect("GenerarInstalador.aspx?E=1")

    End Sub

    Sub Descargar2()
        ' Dim ruta As String = "\\femmsiliis1\RespaldoCO\Temporales\Formato Carga SES.xls"
        Dim ruta As String = "\\femmsiliis1\RespaldoCO\BDCODRIVE\CoDrive.mdb"
        ' Response.Buffer = True
        Response.Clear()
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", "attachment; filename=""" & "CoDriveBD.mdb" & """")
        'Response.Flush()
        ' Response.WriteFile(ruta)
        Response.TransmitFile(ruta)
        Response.End()

    End Sub

    Sub Descargar3()
        ' Dim ruta As String = "\\femmsiliis1\RespaldoCO\Temporales\Formato Carga SES.xls"
        ' Dim ruta As String = "\\femmsiliis1\RespaldoCO\BDCODRIVE\CoDriveEncuestaElectronica.exe"
        Dim ruta As String = "\\femmsiliis1\RespaldoCO\BDCODRIVE\CoDriveEncuesta.exe"
        ' Response.Buffer = True
        Response.Clear()
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", "attachment; filename=""" & "ClimaOrganizacional.exe" & """")
        'Response.Flush()
        ' Response.WriteFile(ruta)
        Response.TransmitFile(ruta)
        Response.End()
    End Sub





    Private Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click

        Descargar2()

    End Sub

    Private Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Descargar3()
    End Sub
End Class


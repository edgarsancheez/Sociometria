'Imports Telerik.WebControls
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Web.UI.DataVisualization.Charting

Public Class Cargar

    Public Shared Function ContarColores(ByVal Grafico As Chart, ByVal Filtro As String, ByVal Sorteo As String) As DataTable
        Dim TablaColor As New DataTable("OrdenColores")
        Dim Indice As DataColumn = New DataColumn("Indice")
        Indice.DataType = System.Type.GetType("System.Int16")
        TablaColor.Columns.Add(Indice)

        Dim Promedio As DataColumn = New DataColumn("Promedio")
        Promedio.DataType = System.Type.GetType("System.Double")
        TablaColor.Columns.Add(Promedio)

        For i As Integer = 0 To Grafico.Series(0).Points.Count - 2 'para que  no tome el promedio
            Dim row As DataRow
            row = TablaColor.NewRow
            row.Item(0) = i
            row.Item(1) = Grafico.Series(0).Points(i).YValues(0)
            TablaColor.Rows.Add(row)
        Next

        Dim dv As DataView = TablaColor.DefaultView
        dv.RowFilter = Filtro
        dv.Sort = Sorteo
        Return dv.ToTable()
    End Function

    'llenar un RadGrid, con una sentencia rad
    Public Shared Sub GridSentenciaTxt(ByVal grid As RadGrid, ByVal sentencia As String)
        Dim datos As New DataTable
        Dim M As String = ""
        datos = DatosBD.FuncionTXT(sentencia, M).Tables(0)
        If M.Length <> 0 Then
            Throw New Exception(M)
        Else
            grid.DataSource = datos
            grid.DataBind()
        End If
    End Sub

    'llenar un RadGrid, com procedure rad
    Public Shared Sub GridProcedure(ByVal grid As RadGrid, ByVal sentencia As String, ByVal param() As SqlParameter)
        Dim datos As New DataTable
        Dim M As String = ""
        datos = DatosBD.FuncionConPar(sentencia, param, M).Tables(0)
        If M.Length <> 0 Then
            Throw New Exception(M)
        Else
            grid.DataSource = datos
            grid.DataBind()
        End If
    End Sub

    'llena el combo con  todos los  datos, con  sentencia rad
    Public Shared Sub ComboSentenciaTxt(ByVal combo As RadComboBox, ByVal sentencia As String, ByVal CampoDisplay As String, ByVal CampoValue As String, Optional ByVal tipo As String = "", Optional ByVal Mayuscula As Boolean = True, Optional ByVal Idioma As String = "es-MX")
        Dim datos As New DataTable
        Dim M As String = ""
        datos = DatosBD.FuncionTXT(sentencia, M).Tables(0)
        If M.Length <> 0 Then
            Throw New Exception(M)
        Else
            Dim ren As DataRow
            If tipo = "" Then

            ElseIf tipo = "1" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[TODOS]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[TODOS]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[ALL]"
                    End If
                Else
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[Todos]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[Todos]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[All]"
                    End If
                End If
                datos.Rows.InsertAt(ren, 0)
            ElseIf tipo = "2" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[SELECCIONAR]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[SELECIONAR]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[SELECT]"
                    End If
                Else
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[Seleccionar]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[Selecionar]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[Select]"
                    End If
                End If
                datos.Rows.InsertAt(ren, 0)
            End If

            combo.DataSource = datos
            combo.DataTextField = CampoDisplay.ToUpper
            combo.DataValueField = CampoValue
            combo.DataBind()

            If combo.Items.Count = 2 Then
                combo.Enabled = False
                combo.SelectedIndex = 1
            Else
                combo.Enabled = True
                combo.SelectedIndex = 0
            End If
        End If
    End Sub
    'llena el combo con  todos los  datos, con procedure rad
    Public Shared Sub ComboParametros(ByVal combo As RadComboBox, ByVal sentencia As String, ByVal param() As SqlParameter, ByVal CampoDisplay As String, ByVal CampoValue As String, Optional ByVal tipo As String = "", Optional ByVal Mayuscula As Boolean = True, Optional ByVal Idioma As String = "es-MX")
        Dim datos As New DataTable
        Dim M As String = ""
        datos = DatosBD.FuncionConPar(sentencia, param, M).Tables(0)
        If M.Length <> 0 Then
            Throw New Exception(M)
        Else
            Dim ren As DataRow
            If tipo = "" Then

            ElseIf tipo = "1" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[TODOS]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[TODOS]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[ALL]"
                    End If
                Else
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[Todos]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[Todos]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[All]"
                    End If
                End If
                datos.Rows.InsertAt(ren, 0)
            ElseIf tipo = "2" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[SELECCIONAR]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[SELECIONAR]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[SELECT]"
                    End If
                Else
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[Seleccionar]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[Selecionar]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[Select]"
                    End If
                End If
                datos.Rows.InsertAt(ren, 0)
            End If

            combo.DataSource = datos
            combo.DataTextField = CampoDisplay.ToUpper
            combo.DataValueField = CampoValue
            combo.DataBind()

            If combo.Items.Count = 2 Then
                combo.Enabled = False
                combo.SelectedIndex = 1
            Else
                combo.Enabled = True
                combo.SelectedIndex = 0
            End If
        End If
    End Sub

    Public Shared Sub UserMsgBox(ByVal sMsg As String, ByVal pa As System.Web.UI.Page)
        Dim sb As New StringBuilder()
        Dim oFormObject As System.Web.UI.Control
        sMsg = sMsg.Replace("'", "\'")
        sMsg = sMsg.Replace(Chr(34), "\" & Chr(34))
        sMsg = sMsg.Replace(vbCrLf, "\n")
        sMsg = "<script language=javascript>alert(""" & sMsg & """)</script>"
        sb = New StringBuilder()
        sb.Append(sMsg)
        For Each oFormObject In pa.Controls
            If TypeOf oFormObject Is HtmlForm Then
                Exit For
            End If
        Next
        ' Add the javascript after the form object so that the 
        ' message doesn't appear on a blank screen.
        oFormObject.Controls.AddAt(oFormObject.Controls.Count, New LiteralControl(sb.ToString()))
    End Sub

    Public Shared Sub Mensaje(ByVal RaM As RadAjaxManager, ByVal Mensaje As String, Optional ByVal Encabezado As String = "Información")
        'si funciona
        'RadAjaxManager1.ResponseScripts.Add("Sys.Application.add_load(function()    " & vbCr & vbLf & "        {radalert('Welcome to RadWindow for <b>ASP.NET AJAX</b>!', 330, 210,'Rad alert');})")
        If Mensaje.Length > 0 Then
            RaM.ResponseScripts.Add("Sys.Application.add_load(function(){radalert('" & Mensaje & "', 330, 210,'" & Encabezado & "');})")
        End If
    End Sub

    Public Shared Sub ComboSentenciaTxt_Laboral(ByVal combo As RadComboBox, ByVal sentencia As String, ByVal CampoDisplay As String, ByVal CampoValue As String, Optional ByVal tipo As String = "", Optional ByVal Mayuscula As Boolean = True, Optional ByVal Idioma As String = "es-MX")
        Dim datos As New DataTable
        Dim M As String = ""
        datos = DatosBD.FuncionTXT_Laboral(sentencia, M).Tables(0)
        If M.Length <> 0 Then
            Throw New Exception(M)
        Else
            Dim ren As DataRow
            If tipo = "" Then

            ElseIf tipo = "1" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[TODOS]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[TODOS]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[ALL]"
                    End If
                Else
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[Todos]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[Todos]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[All]"
                    End If
                End If
                datos.Rows.InsertAt(ren, 0)
            ElseIf tipo = "2" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[SELECCIONAR]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[SELECIONAR]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[SELECT]"
                    End If
                Else
                    If Idioma = "es-MX" Then
                        ren.Item(1) = "[Seleccionar]"
                    ElseIf Idioma = "pt-BR" Then
                        ren.Item(1) = "[Selecionar]"
                    ElseIf Idioma = "en-US" Then
                        ren.Item(1) = "[Select]"
                    End If
                End If
                datos.Rows.InsertAt(ren, 0)
            End If

            combo.DataSource = datos
            combo.DataTextField = CampoDisplay.ToUpper
            combo.DataValueField = CampoValue
            combo.DataBind()

            If combo.Items.Count = 2 Then
                combo.Enabled = False
                combo.SelectedIndex = 1
            Else
                combo.Enabled = True
                combo.SelectedIndex = -1
            End If
        End If
    End Sub

    Public Shared Function StrValidarRetorno(Ds As DataSet, Optional NumTabla As Integer = 0) As String
        Dim valor As String = Nothing
        If Not Ds Is Nothing Then
            If Ds.Tables(NumTabla).Rows.Count > 0 Then
                valor = "OK"
            Else
                valor = "No existe el registro buscado"
            End If
        Else
            valor = "No existe ninguna coinicdencia, Error en la busqueda!!"
        End If
        Return valor
    End Function

    Public Shared Function DsFunConPar(ByVal sentencia As String, ByVal param() As SqlParameter, ByRef msjerr As String) As Data.DataSet
        Dim con As New SqlConnection
        Dim dset As New DataSet
        msjerr = Nothing

        Try
            'Funcion con parametros
            Dim comando As New SqlCommand
            Dim adap As New SqlDataAdapter

            If System.Environment.MachineName = "FEMMENCP1" Then
                con.ConnectionString = ConfigurationManager.ConnectionStrings("ADMONLABORALDMZ").ConnectionString
            Else
                con.ConnectionString = ConfigurationManager.ConnectionStrings("ADMONLABORAL").ConnectionString
            End If

            con.Open()
            comando.CommandTimeout = 0
            comando.Connection = con
            comando.CommandType = CommandType.StoredProcedure
            comando.CommandText = sentencia
            For i As Integer = 0 To param.Length - 1
                comando.Parameters.Add(param(i))
            Next
            adap.SelectCommand = comando
            adap.Fill(dset)

        Catch ex As SqlException
            msjerr = ex.Message
        Catch ex As Exception
            msjerr = ex.Message
        Finally
            con.Close()
        End Try
        Return dset
    End Function

    Public Shared Function StrValidarRetorno(Dt As DataTable) As String
        Dim valor As String = Nothing

        If Dt.Rows.Count > 0 Then
            valor = "OK"
        Else
            valor = "No existe el registro buscado"
        End If

        Return valor

    End Function

End Class

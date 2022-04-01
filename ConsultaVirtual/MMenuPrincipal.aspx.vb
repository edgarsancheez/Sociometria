Imports Telerik.Web.UI
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports ConsultaVirtual.Graficas
Imports System.Web.Services
Imports System.Web.Script.Services
Imports Newtonsoft.Json

Partial Public Class MMenuPrincipal
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
                Demografico1()
            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Protected Sub Cargar_info()
        Try

            Dim PLoad(11) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 12)
            PLoad(1) = New SqlParameter("@NUMTRABAJADOR", Session("USUARIO"))
            If Session("DEMOGRAFICO1") = "" Then
                PLoad(2) = New SqlParameter("@DEMOGRAFICO1", DBNull.Value)
            Else
                PLoad(2) = New SqlParameter("@DEMOGRAFICO1", Session("DEMOGRAFICO1"))
            End If
            If Session("DEMOGRAFICO2") = "" Then
                PLoad(3) = New SqlParameter("@DEMOGRAFICO2", DBNull.Value)
            Else
                PLoad(3) = New SqlParameter("@DEMOGRAFICO2", Session("DEMOGRAFICO2"))
            End If
            If Session("DEMOGRAFICO3") = "" Then
                PLoad(4) = New SqlParameter("@DEMOGRAFICO3", DBNull.Value)
            Else
                PLoad(4) = New SqlParameter("@DEMOGRAFICO3", Session("DEMOGRAFICO3"))
            End If
            If Session("DEMOGRAFICO4") = "" Then
                PLoad(5) = New SqlParameter("@DEMOGRAFICO4", DBNull.Value)
            Else
                PLoad(5) = New SqlParameter("@DEMOGRAFICO4", Session("DEMOGRAFICO4"))
            End If
            If Session("DEMOGRAFICO5") = "" Then
                PLoad(6) = New SqlParameter("@DEMOGRAFICO5", DBNull.Value)
            Else
                PLoad(6) = New SqlParameter("@DEMOGRAFICO5", Session("DEMOGRAFICO5"))
            End If
            If Session("DEMOGRAFICO6") = "" Then
                PLoad(7) = New SqlParameter("@DEMOGRAFICO6", DBNull.Value)
            Else
                PLoad(7) = New SqlParameter("@DEMOGRAFICO6", Session("DEMOGRAFICO6"))
            End If
            If Session("DEMOGRAFICO7") = "" Then
                PLoad(8) = New SqlParameter("@DEMOGRAFICO7", DBNull.Value)
            Else
                PLoad(8) = New SqlParameter("@DEMOGRAFICO7", Session("DEMOGRAFICO7"))
            End If
            If Session("DEMOGRAFICO8") = "" Then
                PLoad(9) = New SqlParameter("@DEMOGRAFICO8", DBNull.Value)
            Else
                PLoad(9) = New SqlParameter("@DEMOGRAFICO8", Session("DEMOGRAFICO8"))
            End If
            If Session("DEMOGRAFICO9") = "" Then
                PLoad(10) = New SqlParameter("@DEMOGRAFICO9", DBNull.Value)
            Else
                PLoad(10) = New SqlParameter("@DEMOGRAFICO9", Session("DEMOGRAFICO9"))
            End If
            If Session("DEMOGRAFICO10") = "" Then
                PLoad(11) = New SqlParameter("@DEMOGRAFICO10", DBNull.Value)
            Else
                PLoad(11) = New SqlParameter("@DEMOGRAFICO10", Session("DEMOGRAFICO10"))
            End If
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror1.Text)
            'COLUMNA1
            Dim datos1 As DataTable = DS.Tables(0)
            Dim Columnas1 As List(Of Column1) = New List(Of Column1)()

            For f As Integer = 0 To datos1.Rows.Count - 1
                Dim Columna1 As Column1 = New Column1 With {
                                .Nombre = datos1.Rows(f).Item(0),
                                .Afinidad = datos1.Rows(f).Item(1),
                                .Ascendencia = datos1.Rows(f).Item(2),
                                .Popularidad = datos1.Rows(f).Item(3)
                            }

                Columnas1.Add(Columna1)
            Next

            Dim strDatos1 As String
            Dim conteo1 As Integer = datos1.Rows.Count
            Dim i As Integer = 0

            strDatos1 = "[['Nombre','Afinidad','Ascendencia','Popularidad'],"

            For Each dr1 As DataRow In datos1.Rows
                i = i + 1
                strDatos1 = strDatos1 & "["
                strDatos1 = strDatos1 & "'" & dr1(0) & "'" & "," & dr1(1) & "," & dr1(2) & "," & dr1(3)

                If conteo1 = i Then
                    strDatos1 = strDatos1 + "]"
                Else
                    strDatos1 = strDatos1 + "],"
                End If
            Next

            lbljson1.Text = strDatos1 & "]"

            'COLUMNA2
            Dim datos2 As DataTable = DS.Tables(1)
            Dim strDatos2 As String
            Dim conteo2 As Integer = datos2.Rows.Count
            Dim i2 As Integer = 0

            strDatos2 = "[['Genero','Total'],"

            For Each dr2 As DataRow In datos2.Rows
                i2 = i2 + 1
                strDatos2 = strDatos2 & "["
                strDatos2 = strDatos2 & "'" & dr2(0) & "'" & "," & dr2(1)

                If conteo2 = i2 Then
                    strDatos2 = strDatos2 + "]"
                Else
                    strDatos2 = strDatos2 + "],"
                End If
            Next

            lbljson2.Text = strDatos2 & "]"

            'COLUMNA3
            Dim datos3 As DataTable = DS.Tables(2)

            Dim strDatos3 As String
            Dim conteo3 As Integer = datos3.Rows.Count
            Dim i3 As Integer = 0

            strDatos3 = "[['nivelcontribucion','Total',{role: 'style'}],"

            For Each dr3 As DataRow In datos3.Rows
                i3 = i3 + 1
                strDatos3 = strDatos3 & "["
                strDatos3 = strDatos3 & "'" & dr3(0) & "'" & "," & dr3(1) & "," & "'" & dr3(2) & "'"

                If conteo3 = i3 Then
                    strDatos3 = strDatos3 + "]"
                Else
                    strDatos3 = strDatos3 + "],"
                End If
            Next
            lbljson3.Text = strDatos3 & "]"

            'COLUMNA4
            Dim datos4 As DataTable = DS.Tables(3)

            Dim strDatos4 As String
            Dim conteo4 As Integer = datos4.Rows.Count
            Dim i4 As Integer = 0

            strDatos4 = "[['Nivel','Total',{role:'style'}],"

            For Each dr4 As DataRow In datos4.Rows
                i4 = i4 + 1
                strDatos4 = strDatos4 & "["
                strDatos4 = strDatos4 & "'" & dr4(0) & "'" & "," & dr4(1) & "," & "'" & dr4(2) & "'"
                'strDatos = strDatos & "]"

                If conteo4 = i4 Then
                    strDatos4 = strDatos4 + "]"
                Else
                    strDatos4 = strDatos4 + "],"
                End If
            Next
            lbljson4.Text = strDatos4 & "]"

            'COLUMNA 5
            Dim datos5 As DataTable = DS.Tables(4)

            Dim strDatos5 As String
            Dim conteo5 As Integer = datos5.Rows.Count
            Dim i5 As Integer = 0

            strDatos5 = "[['Escolaridad','Total',{role: 'style'}],"

            For Each dr5 As DataRow In datos5.Rows
                i5 = i5 + 1
                strDatos5 = strDatos5 & "["
                strDatos5 = strDatos5 & "'" & dr5(0) & "'" & "," & dr5(1) & "," & "'" & dr5(2) & "'"

                If conteo5 = i5 Then
                    strDatos5 = strDatos5 + "]"
                Else
                    strDatos5 = strDatos5 + "],"
                End If
            Next
            lbljson5.Text = strDatos5 & "]"

            'COLUMNA 6
            Dim datos6 As DataTable = DS.Tables(5)
            Dim strDatos6 As String
            Dim conteo6 As Integer = datos6.Rows.Count
            Dim i6 As Integer = 0

            strDatos6 = "[['Generacion','Total'],"

            For Each dr6 As DataRow In datos6.Rows
                i6 = i6 + 1
                strDatos6 = strDatos6 & "["
                strDatos6 = strDatos6 & "'" & dr6(0) & "'" & "," & dr6(1)

                If conteo6 = i6 Then
                    strDatos6 = strDatos6 + "]"
                Else
                    strDatos6 = strDatos6 + "],"
                End If
            Next

            lbljson6.Text = strDatos6 & "]"

            'COLUMNA7
            Dim datos7 As DataTable = DS.Tables(6)

            Dim strDatos7 As String
            Dim conteo7 As Integer = datos7.Rows.Count
            Dim i7 As Integer = 0

            strDatos7 = "[['Estilos','Afinidad','Ascendencia','Popularidad'],"

            For Each dr7 As DataRow In datos7.Rows
                i7 = i7 + 1
                strDatos7 = strDatos7 & "["
                strDatos7 = strDatos7 & "'" & dr7(0) & "'" & "," & dr7(1) & "," & dr7(2) & "," & dr7(3)

                If conteo7 = i7 Then
                    strDatos7 = strDatos7 + "]"
                Else
                    strDatos7 = strDatos7 + "],"
                End If
            Next

            lbljson7.Text = strDatos7 & "]"

            Id_Empleado.InnerText = DS.Tables(7).Rows(0).Item(1)
            id_sindicalizado.InnerText = DS.Tables(7).Rows(1).Item(1)

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
        'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "drawChart1();", True)
        'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "drawChart2();", True)
        'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "drawChart4();", True)
        'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "drawChart6();", True)
        'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "drawChart7();", True)
    End Sub

    Sub Demografico1()
        Try
            RDemografico1.Items.Clear()
            RDemografico2.Items.Clear()
            RDemografico3.Items.Clear()
            RDemografico4.Items.Clear()
            RDemografico5.Items.Clear()
            RDemografico6.Items.Clear()
            RDemografico7.Items.Clear()
            RDemografico8.Items.Clear()
            RDemografico9.Items.Clear()
            RDemografico10.Items.Clear()

            Dim Lerror As String = String.Empty
            Dim PLoad(2) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 2)
            PLoad(1) = New SqlParameter("@NUMTRABAJADOR", Session("USUARIO"))
            PLoad(2) = New SqlParameter("@IDPERFIL", Session("NUMPERFIL"))
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror)
            DatosBD.ComboDT(RDemografico1, DS.Tables(0), "Demografico1", "IdDemografico", True, 2)

            If Not Session("Demografico1") Is Nothing AndAlso Not Session("Demografico1") Is DBNull.Value Then
                RDemografico1.FindItemByText(Session("Demografico1")).Selected = True
                Demografico2()
            ElseIf RDemografico1.SelectedIndex = 1 Then
                Session("Demografico1") = RDemografico1.SelectedItem.Text
                Demografico2()
                'ElseIf RDemografico1.SelectedIndex = 0 Then
                '    Div_dem2.Visible = False
                '    Div_dem3.Visible = False
                '    Div_dem4.Visible = False
                '    Div_dem5.Visible = False
                '    Div_dem6.Visible = False
                '    Div_dem7.Visible = False
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
            End If

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub
    Sub Demografico2()
        Try
            RDemografico2.Items.Clear()
            RDemografico3.Items.Clear()
            RDemografico4.Items.Clear()
            RDemografico5.Items.Clear()
            RDemografico6.Items.Clear()
            RDemografico7.Items.Clear()
            RDemografico8.Items.Clear()
            RDemografico9.Items.Clear()
            RDemografico10.Items.Clear()

            Dim Lerror As String = String.Empty
            Dim PLoad(3) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 3)
            PLoad(1) = New SqlParameter("@DEMOGRAFICO1", RDemografico1.SelectedItem.Text)
            PLoad(2) = New SqlParameter("@NUMTRABAJADOR", Session("USUARIO"))
            PLoad(3) = New SqlParameter("@IDPERFIL", Session("NUMPERFIL"))
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror)
            DatosBD.ComboDT(RDemografico2, DS.Tables(0), "Demografico2", "Id", True, 2)

            If Not Session("Demografico2") Is Nothing AndAlso Not Session("Demografico2") Is DBNull.Value Then
                RDemografico2.FindItemByText(Session("Demografico2")).Selected = True
                Demografico3()
            ElseIf RDemografico2.SelectedIndex = 1 Then
                Session("Demografico2") = RDemografico2.SelectedItem.Text
                Demografico3()
                'ElseIf RDemografico2.Items.Count >= 2 Then
                '    Div_dem3.Visible = True
                '    Div_dem4.Visible = False
                '    Div_dem5.Visible = False
                '    Div_dem6.Visible = False
                '    Div_dem7.Visible = False
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
                'ElseIf RDemografico2.SelectedIndex = 0 Then
                '    Div_dem3.Visible = False
                '    Div_dem4.Visible = False
                '    Div_dem5.Visible = False
                '    Div_dem6.Visible = False
                '    Div_dem7.Visible = False
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
            End If

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub
    Sub Demografico3()
        Try
            RDemografico4.Items.Clear()
            RDemografico5.Items.Clear()
            RDemografico6.Items.Clear()
            RDemografico7.Items.Clear()
            RDemografico8.Items.Clear()
            RDemografico9.Items.Clear()
            RDemografico10.Items.Clear()

            Dim Lerror As String = String.Empty
            Dim PLoad(4) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 4)
            PLoad(1) = New SqlParameter("@DEMOGRAFICO1", RDemografico1.SelectedItem.Text)
            PLoad(2) = New SqlParameter("@DEMOGRAFICO2", RDemografico2.SelectedItem.Text)
            PLoad(3) = New SqlParameter("@NUMTRABAJADOR", Session("USUARIO"))
            PLoad(4) = New SqlParameter("@IDPERFIL", Session("NUMPERFIL"))
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror)
            DatosBD.ComboDT(RDemografico3, DS.Tables(0), "Demografico3", "Id", True, 2)

            If Not Session("Demografico3") Is Nothing AndAlso Not Session("Demografico3") Is DBNull.Value Then
                RDemografico3.FindItemByText(Session("Demografico3")).Selected = True
                Demografico4()
            ElseIf RDemografico3.SelectedIndex = 1 Then
                Session("Demografico3") = RDemografico3.SelectedItem.Text
                Demografico4()
                'ElseIf RDemografico3.Items.Count >= 2 Then
                '    Div_dem4.Visible = True
                '    Div_dem5.Visible = False
                '    Div_dem6.Visible = False
                '    Div_dem7.Visible = False
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
                'ElseIf RDemografico3.SelectedIndex = 0 Then
                '    Div_dem4.Visible = False
                '    Div_dem5.Visible = False
                '    Div_dem6.Visible = False
                '    Div_dem7.Visible = False
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
            End If

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub
    Sub Demografico4()
        Try
            RDemografico5.Items.Clear()
            RDemografico6.Items.Clear()
            RDemografico7.Items.Clear()
            RDemografico8.Items.Clear()
            RDemografico9.Items.Clear()
            RDemografico10.Items.Clear()

            Dim Lerror As String = String.Empty
            Dim PLoad(5) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 5)
            PLoad(1) = New SqlParameter("@DEMOGRAFICO1", RDemografico1.SelectedItem.Text)
            PLoad(2) = New SqlParameter("@DEMOGRAFICO2", RDemografico2.SelectedItem.Text)
            PLoad(3) = New SqlParameter("@DEMOGRAFICO3", RDemografico3.SelectedItem.Text)
            PLoad(4) = New SqlParameter("@NUMTRABAJADOR", Session("USUARIO"))
            PLoad(5) = New SqlParameter("@IDPERFIL", Session("NUMPERFIL"))
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror)
            DatosBD.ComboDT(RDemografico4, DS.Tables(0), "Demografico4", "Id", True, 2)

            If Not Session("Demografico4") Is Nothing AndAlso Not Session("Demografico4") Is DBNull.Value Then
                RDemografico4.FindItemByText(Session("Demografico4")).Selected = True
                Demografico5()
            ElseIf RDemografico4.SelectedIndex = 1 Then
                Session("Demografico4") = RDemografico4.SelectedItem.Text
                Demografico5()
                'ElseIf RDemografico4.Items.Count >= 2 Then
                '    Div_dem5.Visible = True
                '    Div_dem6.Visible = False
                '    Div_dem7.Visible = False
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
                'ElseIf RDemografico4.SelectedIndex = 0 Then
                '    Div_dem5.Visible = False
                '    Div_dem6.Visible = False
                '    Div_dem7.Visible = False
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
            End If

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub
    Sub Demografico5()
        Try
            RDemografico6.Items.Clear()
            RDemografico7.Items.Clear()
            RDemografico8.Items.Clear()
            RDemografico9.Items.Clear()
            RDemografico10.Items.Clear()

            Dim Lerror As String = String.Empty
            Dim PLoad(6) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 6)
            PLoad(1) = New SqlParameter("@DEMOGRAFICO1", RDemografico1.SelectedItem.Text)
            PLoad(2) = New SqlParameter("@DEMOGRAFICO2", RDemografico2.SelectedItem.Text)
            PLoad(3) = New SqlParameter("@DEMOGRAFICO3", RDemografico3.SelectedItem.Text)
            PLoad(4) = New SqlParameter("@DEMOGRAFICO4", RDemografico4.SelectedItem.Text)
            PLoad(5) = New SqlParameter("@NUMTRABAJADOR", Session("USUARIO"))
            PLoad(6) = New SqlParameter("@IDPERFIL", Session("NUMPERFIL"))
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror)
            DatosBD.ComboDT(RDemografico5, DS.Tables(0), "Demografico5", "Id", True, 2)

            If Not Session("Demografico5") Is Nothing AndAlso Not Session("Demografico5") Is DBNull.Value Then
                RDemografico5.FindItemByText(Session("Demografico5")).Selected = True
                Demografico6()
            ElseIf RDemografico5.SelectedIndex = 1 Then
                Session("Demografico5") = RDemografico5.SelectedItem.Text
                Demografico6()
                'ElseIf RDemografico5.Items.Count >= 2 Then
                '    Div_dem6.Visible = True
                '    Div_dem7.Visible = False
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
                'ElseIf RDemografico5.SelectedIndex = 0 Then
                '    Div_dem6.Visible = False
                '    Div_dem7.Visible = False
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
            End If

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub
    Sub Demografico6()
        Try
            RDemografico7.Items.Clear()
            RDemografico8.Items.Clear()
            RDemografico9.Items.Clear()
            RDemografico10.Items.Clear()

            Dim Lerror As String = String.Empty
            Dim PLoad(7) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 7)
            PLoad(1) = New SqlParameter("@DEMOGRAFICO1", RDemografico1.SelectedItem.Text)
            PLoad(2) = New SqlParameter("@DEMOGRAFICO2", RDemografico2.SelectedItem.Text)
            PLoad(3) = New SqlParameter("@DEMOGRAFICO3", RDemografico3.SelectedItem.Text)
            PLoad(4) = New SqlParameter("@DEMOGRAFICO4", RDemografico4.SelectedItem.Text)
            PLoad(5) = New SqlParameter("@DEMOGRAFICO5", RDemografico5.SelectedItem.Text)
            PLoad(6) = New SqlParameter("@NUMTRABAJADOR", Session("USUARIO"))
            PLoad(7) = New SqlParameter("@IDPERFIL", Session("NUMPERFIL"))
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror)
            DatosBD.ComboDT(RDemografico6, DS.Tables(0), "Demografico6", "Id", True, 2)

            If Not Session("Demografico6") Is Nothing AndAlso Not Session("Demografico6") Is DBNull.Value Then
                RDemografico6.FindItemByText(Session("Demografico6")).Selected = True
                Demografico7()
            ElseIf RDemografico6.SelectedIndex = 1 Then
                Session("Demografico6") = RDemografico6.SelectedItem.Text
                Demografico7()
                'ElseIf RDemografico6.Items.Count >= 2 Then
                '    Div_dem7.Visible = True
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
                'ElseIf RDemografico6.SelectedIndex = 0 Then
                '    Div_dem7.Visible = False
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
            End If

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub
    Sub Demografico7()
        Try
            RDemografico8.Items.Clear()
            RDemografico9.Items.Clear()
            RDemografico10.Items.Clear()

            Dim Lerror As String = String.Empty
            Dim PLoad(8) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 8)
            PLoad(1) = New SqlParameter("@DEMOGRAFICO1", RDemografico1.SelectedItem.Text)
            PLoad(2) = New SqlParameter("@DEMOGRAFICO2", RDemografico2.SelectedItem.Text)
            PLoad(3) = New SqlParameter("@DEMOGRAFICO3", RDemografico3.SelectedItem.Text)
            PLoad(4) = New SqlParameter("@DEMOGRAFICO4", RDemografico4.SelectedItem.Text)
            PLoad(5) = New SqlParameter("@DEMOGRAFICO5", RDemografico5.SelectedItem.Text)
            PLoad(6) = New SqlParameter("@DEMOGRAFICO6", RDemografico6.SelectedItem.Text)
            PLoad(7) = New SqlParameter("@NUMTRABAJADOR", Session("USUARIO"))
            PLoad(8) = New SqlParameter("@IDPERFIL", Session("NUMPERFIL"))
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror)
            DatosBD.ComboDT(RDemografico7, DS.Tables(0), "Demografico7", "Id", True, 2)

            If Not Session("Demografico7") Is Nothing AndAlso Not Session("Demografico7") Is DBNull.Value Then
                RDemografico7.FindItemByText(Session("Demografico7")).Selected = True
                Demografico8()
            ElseIf RDemografico7.SelectedIndex = 1 Then
                Session("Demografico7") = RDemografico7.SelectedItem.Text
                Demografico8()
                'ElseIf RDemografico7.Items.Count >= 2 Then
                '    RDemografico7.SelectedValue = -1
                '    Div_dem8.Visible = True
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
                'ElseIf RDemografico7.SelectedIndex = 0 Then
                '    Div_dem8.Visible = False
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
            End If

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub
    Sub Demografico8()
        Try
            RDemografico9.Items.Clear()
            RDemografico10.Items.Clear()

            Dim Lerror As String = String.Empty
            Dim PLoad(9) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 9)
            PLoad(1) = New SqlParameter("@DEMOGRAFICO1", RDemografico1.SelectedItem.Text)
            PLoad(2) = New SqlParameter("@DEMOGRAFICO2", RDemografico2.SelectedItem.Text)
            PLoad(3) = New SqlParameter("@DEMOGRAFICO3", RDemografico3.SelectedItem.Text)
            PLoad(4) = New SqlParameter("@DEMOGRAFICO4", RDemografico4.SelectedItem.Text)
            PLoad(5) = New SqlParameter("@DEMOGRAFICO5", RDemografico5.SelectedItem.Text)
            PLoad(6) = New SqlParameter("@DEMOGRAFICO6", RDemografico6.SelectedItem.Text)
            PLoad(7) = New SqlParameter("@DEMOGRAFICO7", RDemografico7.SelectedItem.Text)
            PLoad(8) = New SqlParameter("@NUMTRABAJADOR", Session("USUARIO"))
            PLoad(9) = New SqlParameter("@IDPERFIL", Session("NUMPERFIL"))
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror)
            DatosBD.ComboDT(RDemografico8, DS.Tables(0), "Demografico8", "Id", True, 2)

            If Not Session("Demografico8") Is Nothing AndAlso Not Session("Demografico8") Is DBNull.Value Then
                RDemografico8.FindItemByText(Session("Demografico8")).Selected = True
                Demografico9()
            ElseIf RDemografico8.SelectedIndex = 1 Then
                Session("Demografico8") = RDemografico8.SelectedItem.Text
                Demografico9()
                'ElseIf RDemografico8.Items.Count >= 2 Then
                '    Div_dem9.Visible = True
                '    Div_dem10.Visible = False
                'ElseIf RDemografico8.SelectedIndex = 0 Then
                '    Div_dem9.Visible = False
                '    Div_dem10.Visible = False
            End If

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub
    Sub Demografico9()
        Try
            RDemografico10.Items.Clear()
            Dim Lerror As String = String.Empty
            Dim PLoad(10) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 10)
            PLoad(1) = New SqlParameter("@DEMOGRAFICO1", RDemografico1.SelectedItem.Text)
            PLoad(2) = New SqlParameter("@DEMOGRAFICO2", RDemografico2.SelectedItem.Text)
            PLoad(3) = New SqlParameter("@DEMOGRAFICO3", RDemografico3.SelectedItem.Text)
            PLoad(4) = New SqlParameter("@DEMOGRAFICO4", RDemografico4.SelectedItem.Text)
            PLoad(5) = New SqlParameter("@DEMOGRAFICO5", RDemografico5.SelectedItem.Text)
            PLoad(6) = New SqlParameter("@DEMOGRAFICO6", RDemografico6.SelectedItem.Text)
            PLoad(7) = New SqlParameter("@DEMOGRAFICO7", RDemografico7.SelectedItem.Text)
            PLoad(8) = New SqlParameter("@DEMOGRAFICO8", RDemografico8.SelectedItem.Text)
            PLoad(9) = New SqlParameter("@NUMTRABAJADOR", Session("USUARIO"))
            PLoad(10) = New SqlParameter("@IDPERFIL", Session("NUMPERFIL"))
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror)
            DatosBD.ComboDT(RDemografico9, DS.Tables(0), "Demografico9", "Id", True, 2)

            If Not Session("Demografico9") Is Nothing AndAlso Not Session("Demografico9") Is DBNull.Value Then
                RDemografico9.FindItemByText(Session("Demografico9")).Selected = True
                Demografico10()
            ElseIf RDemografico9.SelectedIndex = 1 Then
                Session("Demografico9") = RDemografico9.SelectedItem.Text
                Demografico10()
                'ElseIf RDemografico9.Items.Count >= 2 Then
                '    Div_dem10.Visible = True
                'ElseIf RDemografico9.SelectedIndex = 0 Then
                '    Div_dem10.Visible = False
            End If

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub
    Sub Demografico10()
        Try
            Dim Lerror As String = String.Empty
            Dim PLoad(10) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 11)
            PLoad(1) = New SqlParameter("@DEMOGRAFICO1", RDemografico1.SelectedItem.Text)
            PLoad(2) = New SqlParameter("@DEMOGRAFICO2", RDemografico2.SelectedItem.Text)
            PLoad(3) = New SqlParameter("@DEMOGRAFICO3", RDemografico3.SelectedItem.Text)
            PLoad(4) = New SqlParameter("@DEMOGRAFICO4", RDemografico4.SelectedItem.Text)
            PLoad(5) = New SqlParameter("@DEMOGRAFICO5", RDemografico5.SelectedItem.Text)
            PLoad(6) = New SqlParameter("@DEMOGRAFICO6", RDemografico6.SelectedItem.Text)
            PLoad(7) = New SqlParameter("@DEMOGRAFICO7", RDemografico7.SelectedItem.Text)
            PLoad(8) = New SqlParameter("@DEMOGRAFICO8", RDemografico8.SelectedItem.Text)
            PLoad(8) = New SqlParameter("@DEMOGRAFICO9", RDemografico9.SelectedItem.Text)
            PLoad(9) = New SqlParameter("@NUMTRABAJADOR", Session("USUARIO"))
            PLoad(10) = New SqlParameter("@IDPERFIL", Session("NUMPERFIL"))
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror)
            DatosBD.ComboDT(RDemografico10, DS.Tables(0), "Demografico10", "Id", True, 2)

            If Not Session("Demografico10") Is Nothing AndAlso Not Session("Demografico10") Is DBNull.Value Then
                RDemografico10.FindItemByText(Session("Demografico10")).Selected = True
                Cargar_info()
            ElseIf RDemografico10.SelectedIndex = 1 Then
                Session("Demografico10") = RDemografico10.SelectedItem.Text
                Cargar_info()
            End If

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub
    Private Sub RDemografico1_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RDemografico1.SelectedIndexChanged
        Session("Demografico1") = RDemografico1.SelectedItem.Text
        Session("Demografico2") = Nothing
        Session("Demografico3") = Nothing
        Session("Demografico4") = Nothing
        Session("Demografico5") = Nothing
        Session("Demografico6") = Nothing
        Session("Demografico7") = Nothing
        Session("Demografico8") = Nothing
        Session("Demografico9") = Nothing
        Session("Demografico10") = Nothing
        Demografico2()
    End Sub

    Private Sub RDemografico2_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RDemografico2.SelectedIndexChanged
        Session("Demografico2") = RDemografico2.SelectedItem.Text
        Session("Demografico3") = Nothing
        Session("Demografico4") = Nothing
        Session("Demografico5") = Nothing
        Session("Demografico6") = Nothing
        Session("Demografico7") = Nothing
        Session("Demografico8") = Nothing
        Session("Demografico9") = Nothing
        Session("Demografico10") = Nothing
        Demografico3()
    End Sub

    Private Sub RDemografico3_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RDemografico3.SelectedIndexChanged
        Session("Demografico3") = RDemografico3.SelectedItem.Text
        Session("Demografico4") = Nothing
        Session("Demografico5") = Nothing
        Session("Demografico6") = Nothing
        Session("Demografico7") = Nothing
        Session("Demografico8") = Nothing
        Session("Demografico9") = Nothing
        Session("Demografico10") = Nothing
        Demografico4()
    End Sub

    Private Sub RDemografico4_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RDemografico4.SelectedIndexChanged
        Session("Demografico4") = RDemografico4.SelectedItem.Text
        Session("Demografico5") = Nothing
        Session("Demografico6") = Nothing
        Session("Demografico7") = Nothing
        Session("Demografico8") = Nothing
        Session("Demografico9") = Nothing
        Session("Demografico10") = Nothing
        Demografico5()
    End Sub
    Private Sub RDemografico5_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RDemografico5.SelectedIndexChanged
        Session("Demografico5") = RDemografico5.SelectedItem.Text
        Session("Demografico6") = Nothing
        Session("Demografico7") = Nothing
        Session("Demografico8") = Nothing
        Session("Demografico9") = Nothing
        Session("Demografico10") = Nothing
        Demografico6()
    End Sub

    Private Sub RDemografico6_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RDemografico6.SelectedIndexChanged
        Session("Demografico6") = RDemografico6.SelectedItem.Text
        Session("Demografico7") = Nothing
        Session("Demografico8") = Nothing
        Session("Demografico9") = Nothing
        Session("Demografico10") = Nothing
        Demografico7()
    End Sub

    Private Sub RDemografico7_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RDemografico7.SelectedIndexChanged
        Session("Demografico7") = RDemografico7.SelectedItem.Text
        Session("Demografico8") = Nothing
        Session("Demografico9") = Nothing
        Session("Demografico10") = Nothing
        Demografico8()
    End Sub

    Private Sub RDemografico8_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RDemografico8.SelectedIndexChanged
        Session("Demografico8") = RDemografico8.SelectedItem.Text
        Session("Demografico9") = Nothing
        Session("Demografico10") = Nothing
        Demografico9()
    End Sub

    Private Sub RDemografico9_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RDemografico9.SelectedIndexChanged
        Session("Demografico9") = RDemografico9.SelectedItem.Text
        Session("Demografico10") = Nothing
        Demografico10()
    End Sub
    Private Sub RDemografico10_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RDemografico10.SelectedIndexChanged
        Session("Demografico10") = RDemografico10.SelectedItem.Text
        Cargar_info()
    End Sub

    Protected Sub Btn_cargardato_Click(sender As Object, e As EventArgs)
        Cargar_info()
        'Cargar_infov2()
    End Sub

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Shared Function Cargar_infov2()
        Try
            Dim Lerror As String = ""
            Dim PLoad(11) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 12)
            PLoad(1) = New SqlParameter("@NUMTRABAJADOR", HttpContext.Current.Session("USUARIO"))
            If HttpContext.Current.Session("DEMOGRAFICO1") = "" Then
                PLoad(2) = New SqlParameter("@DEMOGRAFICO1", DBNull.Value)
            Else
                PLoad(2) = New SqlParameter("@DEMOGRAFICO1", HttpContext.Current.Session("DEMOGRAFICO1"))
            End If
            If HttpContext.Current.Session("DEMOGRAFICO2") = "" Then
                PLoad(3) = New SqlParameter("@DEMOGRAFICO2", DBNull.Value)
            Else
                PLoad(3) = New SqlParameter("@DEMOGRAFICO2", HttpContext.Current.Session("DEMOGRAFICO2"))
            End If
            If HttpContext.Current.Session("DEMOGRAFICO3") = "" Then
                PLoad(4) = New SqlParameter("@DEMOGRAFICO3", DBNull.Value)
            Else
                PLoad(4) = New SqlParameter("@DEMOGRAFICO3", HttpContext.Current.Session("DEMOGRAFICO3"))
            End If
            If HttpContext.Current.Session("DEMOGRAFICO4") = "" Then
                PLoad(5) = New SqlParameter("@DEMOGRAFICO4", DBNull.Value)
            Else
                PLoad(5) = New SqlParameter("@DEMOGRAFICO4", HttpContext.Current.Session("DEMOGRAFICO4"))
            End If
            If HttpContext.Current.Session("DEMOGRAFICO5") = "" Then
                PLoad(6) = New SqlParameter("@DEMOGRAFICO5", DBNull.Value)
            Else
                PLoad(6) = New SqlParameter("@DEMOGRAFICO5", HttpContext.Current.Session("DEMOGRAFICO5"))
            End If
            If HttpContext.Current.Session("DEMOGRAFICO6") = "" Then
                PLoad(7) = New SqlParameter("@DEMOGRAFICO6", DBNull.Value)
            Else
                PLoad(7) = New SqlParameter("@DEMOGRAFICO6", HttpContext.Current.Session("DEMOGRAFICO6"))
            End If
            If HttpContext.Current.Session("DEMOGRAFICO7") = "" Then
                PLoad(8) = New SqlParameter("@DEMOGRAFICO7", DBNull.Value)
            Else
                PLoad(8) = New SqlParameter("@DEMOGRAFICO7", HttpContext.Current.Session("DEMOGRAFICO7"))
            End If
            If HttpContext.Current.Session("DEMOGRAFICO8") = "" Then
                PLoad(9) = New SqlParameter("@DEMOGRAFICO8", DBNull.Value)
            Else
                PLoad(9) = New SqlParameter("@DEMOGRAFICO8", HttpContext.Current.Session("DEMOGRAFICO8"))
            End If
            If HttpContext.Current.Session("DEMOGRAFICO9") = "" Then
                PLoad(10) = New SqlParameter("@DEMOGRAFICO9", DBNull.Value)
            Else
                PLoad(10) = New SqlParameter("@DEMOGRAFICO9", HttpContext.Current.Session("DEMOGRAFICO9"))
            End If
            If HttpContext.Current.Session("DEMOGRAFICO10") = "" Then
                PLoad(11) = New SqlParameter("@DEMOGRAFICO10", DBNull.Value)
            Else
                PLoad(11) = New SqlParameter("@DEMOGRAFICO10", HttpContext.Current.Session("DEMOGRAFICO10"))
            End If
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror)
            'COLUMNA1
            Dim data As DataWrapperColumn1 = New DataWrapperColumn1()
            Dim datos1 As DataTable = DS.Tables(0)
            Dim Columnas1 As List(Of Column1) = New List(Of Column1)()

            For f As Integer = 0 To datos1.Rows.Count - 1
                Dim Columna1 As Column1 = New Column1 With {
                                .Nombre = datos1.Rows(f).Item(0),
                                .Afinidad = datos1.Rows(f).Item(1),
                                .Ascendencia = datos1.Rows(f).Item(2),
                                .Popularidad = datos1.Rows(f).Item(3)
                            }

                Columnas1.Add(Columna1)
            Next

            data.data = Columnas1

            Dim json As String = JsonConvert.SerializeObject(data)
            Return json

            'Dim strDatos1 As String
            'Dim conteo1 As Integer = datos1.Rows.Count
            'Dim i As Integer = 0

            'strDatos1 = "[['Nombre','Afinidad','Ascendencia','Popularidad'],"

            'For Each dr1 As DataRow In datos1.Rows
            '    i = i + 1
            '    strDatos1 = strDatos1 & "["
            '    strDatos1 = strDatos1 & "'" & dr1(0) & "'" & "," & dr1(1) & "," & dr1(2) & "," & dr1(3)

            '    If conteo1 = i Then
            '        strDatos1 = strDatos1 + "]"
            '    Else
            '        strDatos1 = strDatos1 + "],"
            '    End If
            'Next

            'lbljson1.Text = strDatos1 & "]"

        Catch ex As Exception
        End Try
    End Function

End Class
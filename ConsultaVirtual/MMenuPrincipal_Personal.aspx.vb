Imports Telerik.Web.UI
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient

Partial Public Class MMenuPrincipal_Personal
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
            PLoad(0) = New SqlParameter("@TIPO", 13)
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

            If DS Is Nothing Then
                Exit Sub
            End If

            Dim tabla As DataTable
            tabla = DS.Tables(0)
            RadGrid1.DataSource = tabla
            RadGrid1.DataBind()

            DatosBD.ComboDT(RC_Genero, DS.Tables(1), "Genero1", "Genero", True, 2)
            DatosBD.ComboDT(RC_Generacion, DS.Tables(2), "Generacion1", "Generacion", True, 2)
            DatosBD.ComboDT(RC_Escolaridad, DS.Tables(3), "Escolaridad1", "Escolaridad", True, 2)
            DatosBD.ComboDT(RC_NivelContribucion, DS.Tables(4), "Nivel1", "Nivel", True, 2)
            DatosBD.ComboDT(RC_TipoEmpleado, DS.Tables(5), "TipoEmpleado1", "TipoEmpleado", True, 2)
        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "Filter" Then
            Cargar_info()
        ElseIf e.CommandName = "RebindGrid" Then
        ElseIf e.CommandName = "Ver" Then
            Session("NumTrabajador_buscar") = e.Item.Cells(2).Text
            GenerarDatos()
            Cards_Valor.Visible = True
        End If
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If TypeOf e.Item Is GridDataItem Then

        ElseIf e.Item.ItemType = GridItemType.Footer Then
            e.Item.Cells(4).Text = "Total de elementos:"
            e.Item.Cells(5).Text = CStr(RadGrid1.Items.Count)
        End If
    End Sub

    Private Sub RadGrid1_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        Cargar_info()
    End Sub
    Private Sub RadGrid1_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGrid1.PageSizeChanged
        Cargar_info()
    End Sub
    Private Sub RadGrid1_SortCommand(sender As Object, e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        Cargar_info()
    End Sub

    Sub GenerarDatos()
        Try

            Dim ds As New DataSet
            Dim P(1) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 14)
            P(1) = New SqlParameter("@NUMTRABAJADOR", Session("NumTrabajador_buscar"))
            ds = DatosBD.FuncionConPar("Liderazgo.SP_Admin", P, Lerror1.Text)

            Session("nombre") = ds.Tables(0).Rows(0).Item("nombre")
            Session("Edad") = ds.Tables(0).Rows(0).Item("Edad")
            Session("Generacion") = ds.Tables(0).Rows(0).Item("Generacion")
            Session("Genero") = ds.Tables(0).Rows(0).Item("Genero")
            Session("Escolaridad") = ds.Tables(0).Rows(0).Item("Escolaridad")
            Session("NivelContribucion") = ds.Tables(0).Rows(0).Item("NivelContribucion")
            Session("Sindicalizado") = ds.Tables(0).Rows(0).Item("Sindicalizado")

            Label_nombre.InnerText = Session("nombre")
            Label_edad.InnerText = Session("Edad")
            Label_generacion.InnerText = Session("Generacion")
            Label_genero.InnerText = Session("Genero")
            Label_Escolaridad.InnerText = Session("Escolaridad")
            Label_Nivel.InnerText = Session("NivelContribucion")
            Label_Sindicalizado.InnerText = Session("Sindicalizado")
        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
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
            ElseIf RDemografico4.SelectedIndex = 0 Then
                Div_dem5.Visible = False
                Div_dem6.Visible = False
                Div_dem7.Visible = False
                Div_dem8.Visible = False
                Div_dem9.Visible = False
                Div_dem10.Visible = False
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
            ElseIf RDemografico5.SelectedIndex = 0 Then
                Div_dem6.Visible = False
                Div_dem7.Visible = False
                Div_dem8.Visible = False
                Div_dem9.Visible = False
                Div_dem10.Visible = False
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
            ElseIf RDemografico6.SelectedIndex = 0 Then
                Div_dem7.Visible = False
                Div_dem8.Visible = False
                Div_dem9.Visible = False
                Div_dem10.Visible = False
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
            ElseIf RDemografico7.SelectedIndex = 0 Then
                Div_dem8.Visible = False
                Div_dem9.Visible = False
                Div_dem10.Visible = False
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
            ElseIf RDemografico8.SelectedIndex = 0 Then
                Div_dem9.Visible = False
                Div_dem10.Visible = False
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
            ElseIf RDemografico9.SelectedIndex = 0 Then
                Div_dem10.Visible = False
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
        'LoadGrid()
    End Sub
    Protected Sub BtnCargar_Demo_Click(sender As Object, e As EventArgs)
        Try
            Session("Genero") = RC_Genero.SelectedValue
            Session("Generacion") = RC_Generacion.SelectedValue
            Session("Escolaridad") = RC_Escolaridad.SelectedValue
            Session("NivelContribucion") = RC_NivelContribucion.SelectedValue
            Session("Sindicalizado") = RC_TipoEmpleado.SelectedValue

            Dim PLoad(16) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 16)
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
            If Session("Genero") = "-1" Then
                PLoad(12) = New SqlParameter("@GENERO", DBNull.Value)
            Else
                PLoad(12) = New SqlParameter("@GENERO", Session("Genero"))
            End If
            If Session("Generacion") = "-1" Then
                PLoad(13) = New SqlParameter("@GENERACION", DBNull.Value)
            Else
                PLoad(13) = New SqlParameter("@GENERACION", Session("Generacion"))
            End If
            If Session("Escolaridad") = "-1" Then
                PLoad(14) = New SqlParameter("@ESCOLARIDAD", DBNull.Value)
            Else
                PLoad(14) = New SqlParameter("@ESCOLARIDAD", Session("Escolaridad"))
            End If
            If Session("NivelContribucion") = "-1" Then
                PLoad(15) = New SqlParameter("@NIVELCONTRIBUCION", DBNull.Value)
            Else
                PLoad(15) = New SqlParameter("@NIVELCONTRIBUCION", Session("NivelContribucion"))
            End If
            If Session("Sindicalizado") = "-1" Then
                PLoad(16) = New SqlParameter("@SINDICALIZADO", DBNull.Value)
            Else
                PLoad(16) = New SqlParameter("@SINDICALIZADO", Session("Sindicalizado"))
            End If
            Dim DS As DataSet = DatosBD.FuncionConPar("Liderazgo.SP_Admin", PLoad, Lerror1.Text)

            If DS Is Nothing Then
                Exit Sub
            End If

            Dim tabla As DataTable
            tabla = DS.Tables(0)
            RadGrid1.DataSource = tabla
            RadGrid1.DataBind()

        Catch ex As Exception
            Lerror1.Text = ex.Message
        End Try
    End Sub

End Class
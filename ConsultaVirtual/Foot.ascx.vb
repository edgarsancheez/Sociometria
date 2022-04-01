Imports System.Data.SqlClient

Partial Public Class Foot
    Inherits System.Web.UI.UserControl

    'Protected Sub InitializeCulture()
    '    If Not Session("Lenguaje") Is Nothing Then
    '        UICulture = Session("Lenguaje")
    '        Culture = Session("Lenguaje")
    '    End If
    '    MyBase.InitializeCulture()
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CON") = "OK" Then
            Dim Sen As String
            Dim data As New DataSet

            If Session("Lenguaje") = "es-MX" Then
                'Sen = "SET LANGUAGE Spanish" & _
                '                " SELECT 'Mis visitas en ' + CAST(YEAR(GETDATE()) as NVARCHAR(10)) + ' : ' + CAST(COUNT(*) AS NVARCHAR(10))" & _
                '                " FROM TBLCONTADORVISITAS WHERE YEAR(FECHA)=YEAR(GETDATE()) AND USUARIO='" & Session("USUARIO") & "'"
                'data = DatosBD.FuncionTXT(Sen, "")

                Dim P(1) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 3)
                P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
                data = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, LCont.Text)

                LCont.Text = data.Tables(0).Rows(0).Item(0)
                LCont.Visible = True

                'Sen = "SET LANGUAGE Spanish" & _
                '    " SELECT 'Mis visitas en ' + DATENAME(month, GETDATE()) + ' : ' + CAST(COUNT(*) AS NVARCHAR(10))" & _
                '    " FROM TBLCONTADORVISITAS WHERE YEAR(FECHA)=YEAR(GETDATE()) AND MONTH(FECHA)=MONTH(GETDATE()) AND USUARIO='" & Session("USUARIO") & "'"
                'data = DatosBD.FuncionTXT(Sen, "")

                Dim P2(1) As SqlParameter
                P2(0) = New SqlParameter("@TIPO", 4)
                P2(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
                data = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, LCont.Text)

                LCont2.Text = data.Tables(0).Rows(0).Item(0)
                LCont2.Visible = True
            ElseIf Session("Lenguaje") = "pt-BR" Then
                'Sen = "SET LANGUAGE Portuguese" & _
                '" SELECT 'Minhas visitas ' + CAST(YEAR(GETDATE()) as NVARCHAR(10)) + ' : ' + CAST(COUNT(*) AS NVARCHAR(10))" & _
                '" FROM TBLCONTADORVISITAS WHERE YEAR(FECHA)=YEAR(GETDATE()) AND USUARIO='" & Session("USUARIO") & "'"
                'data = DatosBD.FuncionTXT(Sen, "")

                Dim P(1) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 5)
                P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
                data = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, LCont.Text)


                LCont.Text = data.Tables(0).Rows(0).Item(0)
                LCont.Visible = True

                'Sen = "SET LANGUAGE Portuguese" & _
                '    " SELECT 'Minhas visitas em ' + DATENAME(month, GETDATE()) + ' : ' + CAST(COUNT(*) AS NVARCHAR(10))" & _
                '    " FROM TBLCONTADORVISITAS WHERE YEAR(FECHA)=YEAR(GETDATE()) AND MONTH(FECHA)=MONTH(GETDATE()) AND USUARIO='" & Session("USUARIO") & "'"
                'data = DatosBD.FuncionTXT(Sen, "")



                Dim P2(1) As SqlParameter
                P2(0) = New SqlParameter("@TIPO", 6)
                P2(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
                data = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, LCont.Text)


                LCont2.Text = data.Tables(0).Rows(0).Item(0)
                LCont2.Visible = True
            ElseIf Session("Lenguaje") = "en-US" Then
                'Sen = "SET LANGUAGE English" & _
                '" SELECT 'My visits in ' + CAST(YEAR(GETDATE()) as NVARCHAR(10)) + ' : ' + CAST(COUNT(*) AS NVARCHAR(10))" & _
                '" FROM TBLCONTADORVISITAS WHERE YEAR(FECHA)=YEAR(GETDATE()) AND USUARIO='" & Session("USUARIO") & "'"
                'data = DatosBD.FuncionTXT(Sen, "")

                Dim P(1) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 7)
                P(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
                data = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, LCont.Text)

                LCont.Text = data.Tables(0).Rows(0).Item(0)
                LCont.Visible = True

                'Sen = "SET LANGUAGE English" & _
                '    " SELECT 'My visits in ' + DATENAME(month, GETDATE()) + ' : ' + CAST(COUNT(*) AS NVARCHAR(10))" & _
                '    " FROM TBLCONTADORVISITAS WHERE YEAR(FECHA)=YEAR(GETDATE()) AND MONTH(FECHA)=MONTH(GETDATE()) AND USUARIO='" & Session("USUARIO") & "'"
                'data = DatosBD.FuncionTXT(Sen, "")


                Dim P2(1) As SqlParameter
                P2(0) = New SqlParameter("@TIPO", 8)
                P2(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
                data = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P2, LCont.Text)
                LCont2.Text = data.Tables(0).Rows(0).Item(0)
                LCont2.Visible = True
            End If
        Else
            Dim Sen As String
            Dim data As New DataSet

            If Session("Lenguaje") = "es-MX" Then
                'Sen = "SET LANGUAGE Spanish" & _
                '    " SELECT 'No. de visitas en ' + CAST(YEAR(GETDATE()) as NVARCHAR(10)) + ' : ' + CAST(COUNT(*) AS NVARCHAR(10))" & _
                '    " FROM TBLCONTADORVISITAS WHERE YEAR(FECHA)=YEAR(GETDATE())"
                'data = DatosBD.FuncionTXT(Sen, "")


                Dim P(0) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 9)
                data = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, LCont.Text)


                LCont.Text = data.Tables(0).Rows(0).Item(0)
                LCont.Visible = True
            ElseIf Session("Lenguaje") = "pt-BR" Then
                'Sen = "SET LANGUAGE Portuguese" & _
                '    " SELECT 'Minhas visitas ' + CAST(YEAR(GETDATE()) as NVARCHAR(10)) + ' : ' + CAST(COUNT(*) AS NVARCHAR(10))" & _
                '    " FROM TBLCONTADORVISITAS WHERE YEAR(FECHA)=YEAR(GETDATE())"
                'data = DatosBD.FuncionTXT(Sen, "")

                Dim P(0) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 10)
                data = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, LCont.Text)

                LCont.Text = data.Tables(0).Rows(0).Item(0)
                LCont.Visible = True
            ElseIf Session("Lenguaje") = "en-US" Then
                'Sen = "SET LANGUAGE English" & _
                '    " SELECT 'Number of visits in ' + CAST(YEAR(GETDATE()) as NVARCHAR(10)) + ' : ' + CAST(COUNT(*) AS NVARCHAR(10))" & _
                '    " FROM TBLCONTADORVISITAS WHERE YEAR(FECHA)=YEAR(GETDATE())"
                'data = DatosBD.FuncionTXT(Sen, "")

                Dim P(0) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 11)
                data = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, LCont.Text)
                LCont.Text = data.Tables(0).Rows(0).Item(0)
                LCont.Visible = True
            End If
        End If

    End Sub

End Class
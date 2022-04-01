Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Public Class GraficaImpacto


    Inherits System.Web.UI.Page

    Protected Overrides Sub InitializeCulture()
        If Not Session("Lenguaje") Is Nothing Then
            UICulture = Session("Lenguaje")
            Culture = Session("Lenguaje")
        End If
        MyBase.InitializeCulture()
    End Sub

    Dim Tipo As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CON") = "OK" Then
            If Not Page.IsPostBack Then
                Tipo = Page.Request.Params("T")

                If Session("CveUnidad") Is DBNull.Value Then
                    BuildReportotal(Page.Request.Params("R"))
                Else
                    BuildReport(Page.Request.Params("R"))
                End If


            End If
        Else
            Session.Abandon()
            Response.Redirect("Acceso.aspx", True)
        End If
    End Sub

    Sub Graficar(ByVal Datos As DataTable, ByVal ValorX As String, ByVal ValorY As String, ByVal AxisX As String, ByVal AxisY As String, ByVal Titulo1 As String, ByVal Titulo2 As String, Optional ByVal vPostBack As Boolean = False, Optional ByVal TresD As Boolean = False)
        Chart1.DataSource = Datos
        Chart1.Series(0).XValueMember = CStr(ValorX)
        Chart1.Series(0).YValueMembers = ValorY
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = TresD
        Chart1.DataBind()
        Chart1.ChartAreas(0).AxisY.Maximum = 110
        Chart1.ChartAreas(0).AxisY.Minimum = 0
        Chart1.ChartAreas(0).AxisX.LabelStyle.IsEndLabelVisible = True
        Chart1.ChartAreas(0).AxisX.Title = AxisX
        Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90
        Chart1.ChartAreas(0).AxisY.Title = AxisY
        Chart1.Titles(0).Text = Titulo1
        Chart1.Titles(1).Text = Titulo2

        AgregarLeyendas()

        Chart1.Legends(0).Position.Width = 90
        Chart1.Legends(0).Position.Height = 15
        Chart1.Legends(0).Position.X = 5
        Chart1.Legends(0).Position.Y = 80

        Dim TBLIMPACTO As DataTable = CType(Session("DTGraficaCorrelacion"), DataTable)
        Dim P60, P80 As Integer
        P60 = TBLIMPACTO.Rows.Count * 0.6
        P80 = TBLIMPACTO.Rows.Count * 0.8

        For I As Integer = 0 To TBLIMPACTO.Rows.Count - 1
            If I = P60 Then
                Chart1.ChartAreas(0).AxisX.StripLines(0).IntervalOffset = TBLIMPACTO.Rows(I).Item(4)
            ElseIf I = P80 Then
                Chart1.ChartAreas(0).AxisX.StripLines(1).IntervalOffset = TBLIMPACTO.Rows(I).Item(4)
            End If
        Next

        'Chart1.ChartAreas(0).AxisX.StripLines(0).IntervalOffset = 40
        'Chart1.ChartAreas(0).AxisX.StripLines(1).IntervalOffset = 60
        Chart1.ChartAreas(0).AxisX.StripLines(0).Interval = 100
        Chart1.ChartAreas(0).AxisX.StripLines(1).Interval = 100

        'Datos.Clear()
        Chart1.Visible = True
    End Sub

    Function GetImage(ByVal Tema As Integer) As String
        If Tema = 1 Then
            Return "\Imagenes\Correlacion\Box_Gray.png"
        ElseIf Tema = 2 Then
            Return "\Imagenes\Correlacion\Box_Green.png"
        ElseIf Tema = 3 Then
            Return "\Imagenes\Correlacion\Circle_Blue.png"
        ElseIf Tema = 4 Then
            Return "\Imagenes\Correlacion\Circle_Green.png"
        ElseIf Tema = 5 Then
            Return "\Imagenes\Correlacion\Circle_Orange.png"
        ElseIf Tema = 6 Then
            Return "\Imagenes\Correlacion\Circle_Red.png"
        ElseIf Tema = 7 Then
            Return "\Imagenes\Correlacion\Circle_Yellow.png"
        ElseIf Tema = 8 Then
            Return "\Imagenes\Correlacion\Pentagon_blue.png"
        ElseIf Tema = 9 Then
            Return "\Imagenes\Correlacion\Pentagon_lightblue.png"
        ElseIf Tema = 10 Then
            Return "\Imagenes\Correlacion\Rhombus_blue.png"
        ElseIf Tema = 11 Then
            Return "\Imagenes\Correlacion\Rhombus_lightblue.png"
        ElseIf Tema = 12 Then
            Return "\Imagenes\Correlacion\Shield_blue.png"
        ElseIf Tema = 13 Then
            Return "\Imagenes\Correlacion\Shield_Green.png"
        ElseIf Tema = 14 Then
            Return "\Imagenes\Correlacion\Shield_Red.png"
        ElseIf Tema = 15 Then
            Return "\Imagenes\Correlacion\Shield_Yellow.png"
        ElseIf Tema = 16 Then
            Return "\Imagenes\Correlacion\Square_blue.png"
        ElseIf Tema = 17 Then
            Return "\Imagenes\Correlacion\Square_Green.png"
        ElseIf Tema = 18 Then
            Return "\Imagenes\Correlacion\Star_Black.png"
        ElseIf Tema = 19 Then
            Return "\Imagenes\Correlacion\Star_Blue.png"
        ElseIf Tema = 20 Then
            Return "\Imagenes\Correlacion\Star_Green.png"
        ElseIf Tema = 21 Then
            Return "\Imagenes\Correlacion\Star_Yellow.png"
        ElseIf Tema = 22 Then
            Return "\Imagenes\Correlacion\Triangle_Black.png"
        ElseIf Tema = 23 Then
            Return "\Imagenes\Correlacion\Triangle_Blue.png"
        ElseIf Tema = 36 Then
            Return "\Imagenes\Correlacion\Square_blue.png"
        ElseIf Tema = 37 Then
            Return "\Imagenes\Correlacion\Square_Green.png"

            'LIDERES
        ElseIf Tema = 24 Then
            Return "\Imagenes\Correlacion\Box_Gray.png"
        ElseIf Tema = 25 Then
            Return "\Imagenes\Correlacion\Box_Green.png"
        ElseIf Tema = 26 Then
            Return "\Imagenes\Correlacion\Circle_Blue.png"
        ElseIf Tema = 27 Then
            Return "\Imagenes\Correlacion\Circle_Green.png"
        ElseIf Tema = 28 Then
            Return "\Imagenes\Correlacion\Circle_Orange.png"
        ElseIf Tema = 29 Then
            Return "\Imagenes\Correlacion\Circle_Yellow.png"
        ElseIf Tema = 30 Then
            Return "\Imagenes\Correlacion\Pentagon_blue.png"
        ElseIf Tema = 31 Then
            Return "\Imagenes\Correlacion\Pentagon_lightblue.png"
        ElseIf Tema = 32 Then
            Return "\Imagenes\Correlacion\Rhombus_blue.png"
        ElseIf Tema = 33 Then
            Return "\Imagenes\Correlacion\Rhombus_lightblue.png"
        ElseIf Tema = 34 Then
            Return "\Imagenes\Correlacion\Shield_blue.png"
        ElseIf Tema = 35 Then
            Return "\Imagenes\Correlacion\Shield_Green.png"

        ElseIf Tema = 36 Then
            Return "\Imagenes\Correlacion\Square_blue.png"

        ElseIf Tema = 37 Then
            Return "\Imagenes\Correlacion\Square_Green.png"


        ElseIf Tema = 38 Then
            Return "\Imagenes\Correlacion\Box_Gray.png"
        ElseIf Tema = 39 Then
            Return "\Imagenes\Correlacion\Box_Green.png"
        ElseIf Tema = 40 Then
            Return "\Imagenes\Correlacion\Circle_Blue.png"
        ElseIf Tema = 41 Then
            Return "\Imagenes\Correlacion\Circle_Green.png"
        ElseIf Tema = 42 Then
            Return "\Imagenes\Correlacion\Circle_Orange.png"
        ElseIf Tema = 43 Then
            Return "\Imagenes\Correlacion\Circle_Red.png"
        ElseIf Tema = 44 Then
            Return "\Imagenes\Correlacion\Circle_Yellow.png"
        ElseIf Tema = 45 Then
            Return "\Imagenes\Correlacion\Pentagon_blue.png"
        ElseIf Tema = 46 Then
            Return "\Imagenes\Correlacion\Pentagon_lightblue.png"
        ElseIf Tema = 47 Then
            Return "\Imagenes\Correlacion\Rhombus_blue.png"
        ElseIf Tema = 48 Then
            Return "\Imagenes\Correlacion\Rhombus_lightblue.png"
        ElseIf Tema = 49 Then
            Return "\Imagenes\Correlacion\Shield_blue.png"
        ElseIf Tema = 50 Then
            Return "\Imagenes\Correlacion\Shield_Green.png"
        ElseIf Tema = 51 Then
            Return "\Imagenes\Correlacion\Shield_Red.png"
        ElseIf Tema = 52 Then
            Return "\Imagenes\Correlacion\Shield_Yellow.png"
        ElseIf Tema = 53 Then
            Return "\Imagenes\Correlacion\Square_blue.png"
        ElseIf Tema = 54 Then
            Return "\Imagenes\Correlacion\Square_Green.png"
        ElseIf Tema = 55 Then
            Return "\Imagenes\Correlacion\Star_Black.png"
        ElseIf Tema = 56 Then
            Return "\Imagenes\Correlacion\Star_Blue.png"
        ElseIf Tema = 57 Then
            Return "\Imagenes\Correlacion\Star_Green.png"
        ElseIf Tema = 58 Then
            Return "\Imagenes\Correlacion\Star_Yellow.png"
        ElseIf Tema = 59 Then
            Return "\Imagenes\Correlacion\Triangle_Black.png"
        ElseIf Tema = 60 Then
            Return "\Imagenes\Correlacion\Triangle_Blue.png"
        ElseIf Tema = 61 Then
            Return "\Imagenes\Correlacion\Square_blue.png"
        ElseIf Tema = 62 Then
            Return "\Imagenes\Correlacion\Square_Green.png"

            'LIDERES
        ElseIf Tema = 63 Then
            Return "\Imagenes\Correlacion\Box_Gray.png"
        ElseIf Tema = 64 Then
            Return "\Imagenes\Correlacion\Box_Green.png"
        ElseIf Tema = 65 Then
            Return "\Imagenes\Correlacion\Circle_Blue.png"
        ElseIf Tema = 66 Then
            Return "\Imagenes\Correlacion\Circle_Green.png"
        ElseIf Tema = 67 Then
            Return "\Imagenes\Correlacion\Circle_Orange.png"
        ElseIf Tema = 68 Then
            Return "\Imagenes\Correlacion\Circle_Yellow.png"
        ElseIf Tema = 69 Then
            Return "\Imagenes\Correlacion\Pentagon_blue.png"
        ElseIf Tema = 70 Then
            Return "\Imagenes\Correlacion\Pentagon_lightblue.png"
        ElseIf Tema = 71 Then
            Return "\Imagenes\Correlacion\Rhombus_blue.png"
        ElseIf Tema = 72 Then
            Return "\Imagenes\Correlacion\Rhombus_lightblue.png"
        ElseIf Tema = 73 Then
            Return "\Imagenes\Correlacion\Shield_blue.png"
        ElseIf Tema = 74 Then
            Return "\Imagenes\Correlacion\Shield_Green.png"
        Else
            Return "\Imagenes\Correlacion\Star_black.png"
        End If
    End Function

    Sub AgregarLeyendas()
        Dim TBLIMPACTO As DataTable = CType(Session("DTGraficaCorrelacion"), DataTable)
        For I As Integer = 0 To TBLIMPACTO.Rows.Count - 1
            Chart1.Legends(0).CustomItems(TBLIMPACTO.Rows(I).Item(0) - 1).Enabled = True
            Chart1.Legends(0).CustomItems(TBLIMPACTO.Rows(I).Item(0) - 1).Name = TBLIMPACTO.Rows(I).Item(1)
        Next
    End Sub

    Private Sub BuildReport(ByVal NumReporte As String)
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
            If Session("TipoEmpleado") = "Lider" Then
                PLoad(9) = New SqlParameter("@CVESISTEMA", 13)
            Else
                PLoad(9) = New SqlParameter("@CVESISTEMA", 3)
            End If

            'If Session("CveUnidad") = 9 Or Session("CveUnidad") = 13 Or Session("CveUnidad") = 15 Or Session("CveUnidad") = 16 Then
            '    PLoad(9) = New SqlParameter("@CVESISTEMA", 13)
            'Else
            '    PLoad(9) = New SqlParameter("@CVESISTEMA", 3)
            'End If
            PLoad(10) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(11) = New SqlParameter("@USUARIO", Session("USUARIO"))
            If Session("Lenguaje") = "pt-BR" Then
                PLoad(12) = New SqlParameter("@IDIOMA", 2)
            ElseIf Session("Lenguaje") = "en-US" Then
                PLoad(12) = New SqlParameter("@IDIOMA", 11)
            Else
                PLoad(12) = New SqlParameter("@IDIOMA", 99)
            End If

            ds = DatosBD.FuncionConPar("sp_EngCorrelacion", PLoad, Lerror.Text)

            If Tipo = "Filtro" Then
                Dim P2(2) As SqlParameter
                P2(0) = New SqlParameter("@TIPO", 2)
                P2(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
                P2(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))

                ds = DatosBD.FuncionConPar("sp_EngCorrelacion", P2, Lerror.Text)
            End If

            'Dim Sen As String
            'Sen = "Select TOP 100 ROW_NUMBER() OVER(ORDER BY CveEncuesta ASC) TEXTO, 0 PROM FROM TblEncuesta"
            'Dim ds2 As New DataSet
            'ds2 = DatosBD.FuncionTXT(Sen, "")

            Dim ds2 As New DataSet
            Dim P(0) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 12)
            ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)



            If NumReporte = "R7" Then
                Session("DTGraficaCorrelacion") = ds.Tables(0)
                Graficar(ds2.Tables(0), "TEXTO", "PROM", GETPALABRA("IMPACTO"), GETPALABRA("SATISFACCION"), GETPALABRA("GRAFICA DE PRIORIDADES (COMPROMISO)"), " ", True)
                Chart1.Visible = True
            ElseIf NumReporte = "R8" Then
                Session("DTGraficaCorrelacion") = ds.Tables(1)
                Graficar(ds2.Tables(0), "TEXTO", "PROM", GETPALABRA("IMPACTO"), GETPALABRA("SATISFACCION"), GETPALABRA("GRAFICA DE PRIORIDADES (SOPORTE)"), " ", True)
                Chart1.Visible = True
            ElseIf NumReporte = "R9" Then
                Session("DTReporteCorrelacion") = ds.Tables(2)
                Dim TBLREPORTE As DataTable = ds.Tables(2)
                RadGrid1.MasterTableView.GroupByExpressions.Clear()
                RadGrid1.DataSource = TBLREPORTE
                RadGrid1.DataBind()

                For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                    Dim colDecimal As GridBoundColumn
                    colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                    colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    colDecimal.Visible = True
                    If cont = 0 Then 'CveTema
                        colDecimal.Visible = False
                    ElseIf cont = 1 Then 'Tema
                        colDecimal.HeaderStyle.Width = 100
                        colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    ElseIf cont = 2 Then 'CvePregunta
                        colDecimal.HeaderStyle.Width = 50
                    ElseIf cont = 3 Then 'Pregunta
                        colDecimal.HeaderStyle.Width = 400
                        colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    ElseIf cont = 4 Or cont = 5 Then 'Cuadrantes
                        colDecimal.HeaderStyle.Width = 100
                    End If
                Next
                RadGrid1.Visible = True
            End If

        Catch ex As Exception
            Lerror.Text = "No existe información para este reporte."
        End Try
    End Sub

    Private Sub Chart1_PostPaint(ByVal sender As Object, ByVal e As System.Web.UI.DataVisualization.Charting.ChartPaintEventArgs) Handles Chart1.PostPaint
        Dim TBLIMPACTO As DataTable = CType(Session("DTGraficaCorrelacion"), DataTable)
        If Not TBLIMPACTO Is Nothing AndAlso TBLIMPACTO.Rows.Count > 0 Then
            For I As Integer = 0 To TBLIMPACTO.Rows.Count - 1
                Dim Imagen As String = GetImage(TBLIMPACTO.Rows(I).Item(0))
                Dim Figura As System.Drawing.Image = Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & Imagen)
                'Minimo
                Dim Impacto As Integer = TBLIMPACTO.Rows(I).Item(4)
                Dim Satisfaccion As Integer = TBLIMPACTO.Rows(I).Item(5)
                ' Set White color as transparent 
                Dim attrib1 As New Drawing.Imaging.ImageAttributes()
                attrib1.SetColorKey(Drawing.Color.White, Drawing.Color.White, Drawing.Imaging.ColorAdjustType.Default)
                ' Calculates marker position depending on the data point X and Y values 
                Dim ImgRojo As Drawing.RectangleF = Drawing.RectangleF.Empty
                ImgRojo.X = CSng(e.ChartGraphics.GetPositionFromAxis(Chart1.ChartAreas(0).Name, AxisName.X, Impacto))
                ImgRojo.Y = CSng(e.ChartGraphics.GetPositionFromAxis(Chart1.ChartAreas(0).Name, AxisName.Y, Satisfaccion))
                ImgRojo = e.ChartGraphics.GetAbsoluteRectangle(ImgRojo)
                ImgRojo.Width = Figura.Width
                ImgRojo.Height = Figura.Height
                ImgRojo.Y -= Figura.Height
                ImgRojo.X -= Figura.Width / 2
                ' Draw image 
                e.ChartGraphics.Graphics.DrawImage(Figura, Drawing.Rectangle.Round(ImgRojo), 0, 0, Figura.Width, Figura.Height, Drawing.GraphicsUnit.Pixel, attrib1)
                ' Add a custom map area in the coordinates of the image 
                Dim rect1 As Drawing.RectangleF = e.ChartGraphics.GetRelativeRectangle(ImgRojo)
                Dim area1 As New MapArea(TBLIMPACTO.Rows(I).Item(3), "", "", String.Empty, rect1, Nothing)
                Chart1.MapAreas.Add(area1)
                Figura.Dispose()
            Next
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            e.Item.Cells(6).BackColor = GETCOLOR3(e.Item.Cells(6).Text)
            e.Item.Cells(6).ForeColor = GETCOLOR4(e.Item.Cells(6).Text)

            e.Item.Cells(7).BackColor = GETCOLOR3(e.Item.Cells(7).Text)
            e.Item.Cells(7).ForeColor = GETCOLOR4(e.Item.Cells(7).Text)
        End If
    End Sub

    Function GETCOLOR3(ByVal Numero As Integer) As System.Drawing.Color
        If Numero = 1 Or Numero = 2 Then
            Return Drawing.Color.Red
        ElseIf Numero = 3 Or Numero = 4 Then
            Return Drawing.Color.Yellow
        ElseIf Numero = 5 Or Numero = 6 Then
            Return Drawing.Color.Blue
        ElseIf Numero = 7 Or Numero = 8 Then
            Return Drawing.Color.Green
        Else
            Return Drawing.Color.Gray
        End If
    End Function

    Function GETCOLOR4(ByVal Numero As Integer) As System.Drawing.Color
        If Numero = 1 Or Numero = 2 Then
            Return Drawing.Color.White
        ElseIf Numero = 3 Or Numero = 4 Then
            Return Drawing.Color.Black
        ElseIf Numero = 5 Or Numero = 6 Then
            Return Drawing.Color.White
        ElseIf Numero = 7 Or Numero = 8 Then
            Return Drawing.Color.White
        Else
            Return Drawing.Color.White
        End If
    End Function

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

    Private Sub BuildReportotal(ByVal NumReporte As String)
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
            PLoad(9) = New SqlParameter("@CVESISTEMA", 3)

            PLoad(10) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))
            PLoad(11) = New SqlParameter("@USUARIO", Session("USUARIO"))
            If Session("Lenguaje") = "pt-BR" Then
                PLoad(12) = New SqlParameter("@IDIOMA", 2)
            ElseIf Session("Lenguaje") = "en-US" Then
                PLoad(12) = New SqlParameter("@IDIOMA", 11)
            Else
                PLoad(12) = New SqlParameter("@IDIOMA", 99)
            End If

            ds = DatosBD.FuncionConPar("sp_EngCorrelacion", PLoad, Lerror.Text)

            If Tipo = "Filtro" Then
                Dim P2(2) As SqlParameter
                P2(0) = New SqlParameter("@TIPO", 2)
                P2(1) = New SqlParameter("@USUARIO", Session("USUARIO"))
                P2(2) = New SqlParameter("@CVEPERFIL", Session("NUMPERFIL"))

                ds = DatosBD.FuncionConPar("sp_EngCorrelacion", P2, Lerror.Text)
            End If

            'Dim Sen As String
            'Sen = "Select TOP 100 ROW_NUMBER() OVER(ORDER BY CveEncuesta ASC) TEXTO, 0 PROM FROM TblEncuesta"
            'Dim ds2 As New DataSet
            'ds2 = DatosBD.FuncionTXT(Sen, "")

            Dim ds2 As New DataSet
            Dim P(0) As SqlParameter
            P(0) = New SqlParameter("@TIPO", 12)
            ds2 = DatosBD.FuncionConPar("SP_CONSULTAS_ENTREGAVIRTUAL", P, Lerror.Text)



            If NumReporte = "R7" Then
                Session("DTGraficaCorrelacion") = ds.Tables(0)
                Graficar(ds2.Tables(0), "TEXTO", "PROM", GETPALABRA("IMPACTO"), GETPALABRA("SATISFACCION"), GETPALABRA("GRAFICA DE PRIORIDADES (COMPROMISO)"), " ", True)
                Chart1.Visible = True
            ElseIf NumReporte = "R8" Then
                Session("DTGraficaCorrelacion") = ds.Tables(1)
                Graficar(ds2.Tables(0), "TEXTO", "PROM", GETPALABRA("IMPACTO"), GETPALABRA("SATISFACCION"), GETPALABRA("GRAFICA DE PRIORIDADES (SOPORTE)"), " ", True)
                Chart1.Visible = True
            ElseIf NumReporte = "R9" Then
                Session("DTReporteCorrelacion") = ds.Tables(2)
                Dim TBLREPORTE As DataTable = ds.Tables(2)
                RadGrid1.MasterTableView.GroupByExpressions.Clear()
                RadGrid1.DataSource = TBLREPORTE
                RadGrid1.DataBind()

                For cont As Integer = 0 To RadGrid1.MasterTableView.AutoGeneratedColumns.Length - 1
                    Dim colDecimal As GridBoundColumn
                    colDecimal = RadGrid1.MasterTableView.AutoGeneratedColumns(cont)
                    colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    colDecimal.Visible = True
                    If cont = 0 Then 'CveTema
                        colDecimal.Visible = False
                    ElseIf cont = 1 Then 'Tema
                        colDecimal.HeaderStyle.Width = 100
                        colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    ElseIf cont = 2 Then 'CvePregunta
                        colDecimal.HeaderStyle.Width = 50
                    ElseIf cont = 3 Then 'Pregunta
                        colDecimal.HeaderStyle.Width = 400
                        colDecimal.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    ElseIf cont = 4 Or cont = 5 Then 'Cuadrantes
                        colDecimal.HeaderStyle.Width = 100
                    End If
                Next
                RadGrid1.Visible = True
            End If

        Catch ex As Exception
            Lerror.Text = "No existe información para este reporte."
        End Try
    End Sub
End Class
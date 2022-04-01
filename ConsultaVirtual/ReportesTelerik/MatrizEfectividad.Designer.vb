Partial Class MatrizEfectividad
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MatrizEfectividad))
        Dim TableGroup1 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup2 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup3 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup4 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup5 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter3 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter4 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter5 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox11 = New Telerik.Reporting.TextBox()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.PictureBox1 = New Telerik.Reporting.PictureBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.reportNameTextBox = New Telerik.Reporting.TextBox()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.Panel4 = New Telerik.Reporting.Panel()
        Me.TPorcentaje4 = New Telerik.Reporting.TextBox()
        Me.TDescripcion4 = New Telerik.Reporting.TextBox()
        Me.TPerfil4 = New Telerik.Reporting.TextBox()
        Me.Panel3 = New Telerik.Reporting.Panel()
        Me.TPorcentaje3 = New Telerik.Reporting.TextBox()
        Me.TDescripcion3 = New Telerik.Reporting.TextBox()
        Me.TPerfil3 = New Telerik.Reporting.TextBox()
        Me.Panel2 = New Telerik.Reporting.Panel()
        Me.TPorcentaje2 = New Telerik.Reporting.TextBox()
        Me.TDescripcion2 = New Telerik.Reporting.TextBox()
        Me.TPerfil2 = New Telerik.Reporting.TextBox()
        Me.Panel1 = New Telerik.Reporting.Panel()
        Me.TPerfil1 = New Telerik.Reporting.TextBox()
        Me.TDescripcion1 = New Telerik.Reporting.TextBox()
        Me.TPorcentaje1 = New Telerik.Reporting.TextBox()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox12 = New Telerik.Reporting.TextBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.currentTimeTextBox = New Telerik.Reporting.TextBox()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TextBox4
        '
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0R), Telerik.Reporting.Drawing.Unit.Cm(0.84666663408279419R))
        Me.TextBox4.Style.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.TextBox4.Style.Font.Bold = True
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox4.Value = "= IIf(Parameters.Idioma.Value='en-US','Potentially Effective', IIf(Parameters.Idi" & _
    "oma.Value='pt-BR','Potencialmente Efectivo', 'Potencialmente Efectivo'))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox5
        '
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0R), Telerik.Reporting.Drawing.Unit.Cm(0.84666663408279419R))
        Me.TextBox5.Style.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.TextBox5.Style.Font.Bold = True
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox5.Value = "= IIf(Parameters.Idioma.Value='en-US','Underutilized', IIf(Parameters.Idioma.Valu" & _
    "e='pt-BR','Desaprovechado', 'Desaprovechado'))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox11
        '
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0R), Telerik.Reporting.Drawing.Unit.Cm(0.84666663408279419R))
        Me.TextBox11.Style.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.TextBox11.Style.Font.Bold = True
        Me.TextBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox11.StyleName = ""
        Me.TextBox11.Value = "= IIf(Parameters.Idioma.Value='en-US','Indifferent', IIf(Parameters.Idioma.Value=" & _
    "'pt-BR','Indiferente', 'Indiferente'))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox9
        '
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0R), Telerik.Reporting.Drawing.Unit.Cm(0.84666663408279419R))
        Me.TextBox9.Style.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.TextBox9.Style.Font.Bold = True
        Me.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox9.StyleName = ""
        Me.TextBox9.Value = "= IIf(Parameters.Idioma.Value='en-US','Distant', IIf(Parameters.Idioma.Value='pt-" & _
    "BR','Distante', 'Distante'))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.0R)
        Me.pageHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.PictureBox1, Me.PictureBox2, Me.TextBox2, Me.reportNameTextBox})
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.30000004172325134R), Telerik.Reporting.Drawing.Unit.Cm(0.49999994039535522R))
        Me.PictureBox1.MimeType = "image/jpeg"
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.75R), Telerik.Reporting.Drawing.Unit.Cm(1.0R))
        Me.PictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox1.Value = CType(resources.GetObject("PictureBox1.Value"), Object)
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.09999942779541R), Telerik.Reporting.Drawing.Unit.Cm(0.19989997148513794R))
        Me.PictureBox2.MimeType = "image/jpeg"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6998996734619141R), Telerik.Reporting.Drawing.Unit.Cm(1.5R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'TextBox2
        '
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.34999942779541R), Telerik.Reporting.Drawing.Unit.Cm(1.0998998880386353R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.4500007629394531R), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269R))
        Me.TextBox2.Style.Font.Bold = True
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox2.Value = "= Parameters.Reporte.Value"
        '
        'reportNameTextBox
        '
        Me.reportNameTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.34999942779541R), Telerik.Reporting.Drawing.Unit.Cm(0.30000004172325134R))
        Me.reportNameTextBox.Name = "reportNameTextBox"
        Me.reportNameTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.4500007629394531R), Telerik.Reporting.Drawing.Unit.Cm(0.747083306312561R))
        Me.reportNameTextBox.Style.Font.Bold = True
        Me.reportNameTextBox.Style.Font.Name = "Arial"
        Me.reportNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14.0R)
        Me.reportNameTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.reportNameTextBox.StyleName = "PageInfo"
        Me.reportNameTextBox.Value = "= Parameters.Empresa.Value"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(16.299999237060547R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Panel4, Me.Panel3, Me.Panel2, Me.Panel1, Me.TextBox1, Me.Table1})
        Me.detail.Name = "detail"
        '
        'Panel4
        '
        Me.Panel4.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TPorcentaje4, Me.TDescripcion4, Me.TPerfil4})
        Me.Panel4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.604374885559082R), Telerik.Reporting.Drawing.Unit.Cm(5.7414579391479492R))
        Me.Panel4.Name = "Panel1"
        Me.Panel4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.8000001907348633R), Telerik.Reporting.Drawing.Unit.Cm(5.0R))
        Me.Panel4.Style.BorderColor.Default = System.Drawing.Color.Blue
        Me.Panel4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.Panel4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(4.0R)
        '
        'TPorcentaje4
        '
        Me.TPorcentaje4.Format = "{0:P1}"
        Me.TPorcentaje4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842R), Telerik.Reporting.Drawing.Unit.Cm(3.5000002384185791R))
        Me.TPorcentaje4.Name = "TPorcentaje4"
        Me.TPorcentaje4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2000000476837158R), Telerik.Reporting.Drawing.Unit.Cm(1.0R))
        Me.TPorcentaje4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20.0R)
        Me.TPorcentaje4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TPorcentaje4.Value = "=Fields.Frustrado"
        '
        'TDescripcion4
        '
        Me.TDescripcion4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.39687499403953552R), Telerik.Reporting.Drawing.Unit.Cm(1.1906249523162842R))
        Me.TDescripcion4.Name = "TDescripcion4"
        Me.TDescripcion4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.0R), Telerik.Reporting.Drawing.Unit.Cm(2.0R))
        Me.TDescripcion4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TDescripcion4.Value = resources.GetString("TDescripcion4.Value")
        '
        'TPerfil4
        '
        Me.TPerfil4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.3956255912780762R), Telerik.Reporting.Drawing.Unit.Cm(0.29104167222976685R))
        Me.TPerfil4.Name = "TPerfil4"
        Me.TPerfil4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0R), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269R))
        Me.TPerfil4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14.0R)
        Me.TPerfil4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TPerfil4.Value = "= IIf(Parameters.Idioma.Value='en-US','Underutilized', IIf(Parameters.Idioma.Valu" & _
    "e='pt-BR','Desaprovechado', 'Desaprovechado'))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel3
        '
        Me.Panel3.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TPorcentaje3, Me.TDescripcion3, Me.TPerfil3})
        Me.Panel3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526R), Telerik.Reporting.Drawing.Unit.Cm(5.7414579391479492R))
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.8000001907348633R), Telerik.Reporting.Drawing.Unit.Cm(5.0R))
        Me.Panel3.Style.BorderColor.Default = System.Drawing.Color.Red
        Me.Panel3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.Panel3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(4.0R)
        '
        'TPorcentaje3
        '
        Me.TPorcentaje3.Format = "{0:P1}"
        Me.TPorcentaje3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842R), Telerik.Reporting.Drawing.Unit.Cm(3.5000002384185791R))
        Me.TPorcentaje3.Name = "TPorcentaje3"
        Me.TPorcentaje3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2000000476837158R), Telerik.Reporting.Drawing.Unit.Cm(1.0R))
        Me.TPorcentaje3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20.0R)
        Me.TPorcentaje3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TPorcentaje3.Value = "=Fields.Inefectivo"
        '
        'TDescripcion3
        '
        Me.TDescripcion3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.39687499403953552R), Telerik.Reporting.Drawing.Unit.Cm(1.1906249523162842R))
        Me.TDescripcion3.Name = "TDescripcion3"
        Me.TDescripcion3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.0R), Telerik.Reporting.Drawing.Unit.Cm(2.0R))
        Me.TDescripcion3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TDescripcion3.Value = resources.GetString("TDescripcion3.Value")
        '
        'TPerfil3
        '
        Me.TPerfil3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.8999998569488525R), Telerik.Reporting.Drawing.Unit.Cm(0.29104167222976685R))
        Me.TPerfil3.Name = "TPerfil3"
        Me.TPerfil3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.0R), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269R))
        Me.TPerfil3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14.0R)
        Me.TPerfil3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TPerfil3.Value = "= IIf(Parameters.Idioma.Value='en-US','Distant', IIf(Parameters.Idioma.Value='pt-" & _
    "BR','Distante', 'Distante'))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel2
        '
        Me.Panel2.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TPorcentaje2, Me.TDescripcion2, Me.TPerfil2})
        Me.Panel2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.604374885559082R), Telerik.Reporting.Drawing.Unit.Cm(0.55562496185302734R))
        Me.Panel2.Name = "Panel1"
        Me.Panel2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.8000001907348633R), Telerik.Reporting.Drawing.Unit.Cm(5.0R))
        Me.Panel2.Style.BorderColor.Default = System.Drawing.Color.Green
        Me.Panel2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.Panel2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(4.0R)
        Me.Panel2.Style.Color = System.Drawing.Color.Black
        '
        'TPorcentaje2
        '
        Me.TPorcentaje2.Format = "{0:P1}"
        Me.TPorcentaje2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842R), Telerik.Reporting.Drawing.Unit.Cm(3.4857246875762939R))
        Me.TPorcentaje2.Name = "TPorcentaje2"
        Me.TPorcentaje2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2000000476837158R), Telerik.Reporting.Drawing.Unit.Cm(1.0R))
        Me.TPorcentaje2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20.0R)
        Me.TPorcentaje2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TPorcentaje2.Value = "=Fields.Efectivo"
        '
        'TDescripcion2
        '
        Me.TDescripcion2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.39687499403953552R), Telerik.Reporting.Drawing.Unit.Cm(1.1906249523162842R))
        Me.TDescripcion2.Name = "TDescripcion2"
        Me.TDescripcion2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.0R), Telerik.Reporting.Drawing.Unit.Cm(2.0R))
        Me.TDescripcion2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TDescripcion2.Value = resources.GetString("TDescripcion2.Value")
        '
        'TPerfil2
        '
        Me.TPerfil2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.5956252813339233R), Telerik.Reporting.Drawing.Unit.Cm(0.29104167222976685R))
        Me.TPerfil2.Name = "TPerfil2"
        Me.TPerfil2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.59999942779541R), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269R))
        Me.TPerfil2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14.0R)
        Me.TPerfil2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TPerfil2.Value = "= IIf(Parameters.Idioma.Value='en-US','Potentially Effective', IIf(Parameters.Idi" & _
    "oma.Value='pt-BR','Potencialmente Efectivo', 'Potencialmente Efectivo'))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel1
        '
        Me.Panel1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TPerfil1, Me.TDescripcion1, Me.TPorcentaje1})
        Me.Panel1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526R), Telerik.Reporting.Drawing.Unit.Cm(0.55562496185302734R))
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.8000001907348633R), Telerik.Reporting.Drawing.Unit.Cm(5.0R))
        Me.Panel1.Style.BorderColor.Default = System.Drawing.Color.Orange
        Me.Panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.Panel1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(4.0R)
        '
        'TPerfil1
        '
        Me.TPerfil1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.8999998569488525R), Telerik.Reporting.Drawing.Unit.Cm(0.299999862909317R))
        Me.TPerfil1.Name = "TPerfil1"
        Me.TPerfil1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.0R), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269R))
        Me.TPerfil1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14.0R)
        Me.TPerfil1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TPerfil1.Value = "= IIf(Parameters.Idioma.Value='en-US','Indifferent', IIf(Parameters.Idioma.Value=" & _
    "'pt-BR','Indiferente', 'Indiferente'))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TDescripcion1
        '
        Me.TDescripcion1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.39999979734420776R), Telerik.Reporting.Drawing.Unit.Cm(1.1999998092651367R))
        Me.TDescripcion1.Name = "TDescripcion1"
        Me.TDescripcion1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.0R), Telerik.Reporting.Drawing.Unit.Cm(2.0R))
        Me.TDescripcion1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TDescripcion1.Value = resources.GetString("TDescripcion1.Value")
        '
        'TPorcentaje1
        '
        Me.TPorcentaje1.Format = "{0:P1}"
        Me.TPorcentaje1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842R), Telerik.Reporting.Drawing.Unit.Cm(3.485724925994873R))
        Me.TPorcentaje1.Name = "TPorcentaje1"
        Me.TPorcentaje1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2000000476837158R), Telerik.Reporting.Drawing.Unit.Cm(1.0R))
        Me.TPorcentaje1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20.0R)
        Me.TPorcentaje1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TPorcentaje1.Value = "=Fields.Indiferente"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.0R), Telerik.Reporting.Drawing.Unit.Cm(12.700000762939453R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.0000004768371582R), Telerik.Reporting.Drawing.Unit.Cm(0.60000050067901611R))
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14.0R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox1.Value = "= IIf(Parameters.Idioma.Value='en-US','High Performance Companies', IIf(Parameter" & _
    "s.Idioma.Value='pt-BR','Empresas de Alto Desempeño', 'Empresas de Alto Desempeño" & _
    "'))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.0R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.0R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.0R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.0R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.63499951362609863R)))
        Me.Table1.Body.SetCellContent(0, 0, Me.TextBox7)
        Me.Table1.Body.SetCellContent(0, 1, Me.TextBox8)
        Me.Table1.Body.SetCellContent(0, 3, Me.TextBox10)
        Me.Table1.Body.SetCellContent(0, 2, Me.TextBox12)
        TableGroup1.ReportItem = Me.TextBox4
        TableGroup2.ReportItem = Me.TextBox5
        TableGroup3.Name = "Group2"
        TableGroup3.ReportItem = Me.TextBox11
        TableGroup4.Name = "Group1"
        TableGroup4.ReportItem = Me.TextBox9
        Me.Table1.ColumnGroups.Add(TableGroup1)
        Me.Table1.ColumnGroups.Add(TableGroup2)
        Me.Table1.ColumnGroups.Add(TableGroup3)
        Me.Table1.ColumnGroups.Add(TableGroup4)
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox7, Me.TextBox8, Me.TextBox12, Me.TextBox10, Me.TextBox4, Me.TextBox5, Me.TextBox11, Me.TextBox9})
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.5R), Telerik.Reporting.Drawing.Unit.Cm(13.699999809265137R))
        Me.Table1.Name = "Table1"
        TableGroup5.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup5.Name = "DetailGroup"
        Me.Table1.RowGroups.Add(TableGroup5)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.0R), Telerik.Reporting.Drawing.Unit.Cm(1.481666088104248R))
        Me.Table1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        '
        'TextBox7
        '
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0R), Telerik.Reporting.Drawing.Unit.Cm(0.63499957323074341R))
        Me.TextBox7.Style.Color = System.Drawing.Color.Green
        Me.TextBox7.Style.Font.Bold = True
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox7.Value = "55.0%"
        '
        'TextBox8
        '
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0R), Telerik.Reporting.Drawing.Unit.Cm(0.63499957323074341R))
        Me.TextBox8.Style.Color = System.Drawing.Color.Blue
        Me.TextBox8.Style.Font.Bold = True
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox8.Value = "11.0%"
        '
        'TextBox10
        '
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0R), Telerik.Reporting.Drawing.Unit.Cm(0.63499957323074341R))
        Me.TextBox10.Style.Color = System.Drawing.Color.Red
        Me.TextBox10.Style.Font.Bold = True
        Me.TextBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox10.StyleName = ""
        Me.TextBox10.Value = "23.0%"
        '
        'TextBox12
        '
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0R), Telerik.Reporting.Drawing.Unit.Cm(0.63499957323074341R))
        Me.TextBox12.Style.Color = System.Drawing.Color.Orange
        Me.TextBox12.Style.Font.Bold = True
        Me.TextBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox12.StyleName = ""
        Me.TextBox12.Value = "12.0%"
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.25R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.currentTimeTextBox, Me.pageInfoTextBox})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'currentTimeTextBox
        '
        Me.currentTimeTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526R), Telerik.Reporting.Drawing.Unit.Cm(0.29999944567680359R))
        Me.currentTimeTextBox.Name = "currentTimeTextBox"
        Me.currentTimeTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.9470834732055664R), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791R))
        Me.currentTimeTextBox.Style.Font.Name = "Arial"
        Me.currentTimeTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.currentTimeTextBox.StyleName = "PageInfo"
        Me.currentTimeTextBox.Value = "= ""Generado el: "" + NOW() "
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.504474639892578R), Telerik.Reporting.Drawing.Unit.Cm(0.29999944567680359R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.899899959564209R), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791R))
        Me.pageInfoTextBox.Style.Font.Name = "Arial"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página "" + PageNumber + "" de "" + PageCount" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'MatrizEfectividad
        '
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1})
        Me.Name = "MatrizEfectividad"
        Me.PageSettings.Landscape = False
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(1.0R), Telerik.Reporting.Drawing.Unit.Cm(1.0R), Telerik.Reporting.Drawing.Unit.Cm(1.0R), Telerik.Reporting.Drawing.Unit.Cm(1.0R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        ReportParameter1.AllowNull = True
        ReportParameter1.Name = "Empresa"
        ReportParameter2.AllowNull = True
        ReportParameter2.Name = "Reporte"
        ReportParameter3.AllowNull = True
        ReportParameter3.Name = "CveEmpresa"
        ReportParameter4.AllowNull = True
        ReportParameter4.Name = "CveEncuesta"
        ReportParameter5.AllowNull = True
        ReportParameter5.Name = "Idioma"
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.ReportParameters.Add(ReportParameter3)
        Me.ReportParameters.Add(ReportParameter4)
        Me.ReportParameters.Add(ReportParameter5)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(19.0R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents Panel4 As Telerik.Reporting.Panel
    Friend WithEvents TPorcentaje4 As Telerik.Reporting.TextBox
    Friend WithEvents TDescripcion4 As Telerik.Reporting.TextBox
    Friend WithEvents TPerfil4 As Telerik.Reporting.TextBox
    Friend WithEvents Panel3 As Telerik.Reporting.Panel
    Friend WithEvents TPorcentaje3 As Telerik.Reporting.TextBox
    Friend WithEvents TDescripcion3 As Telerik.Reporting.TextBox
    Friend WithEvents TPerfil3 As Telerik.Reporting.TextBox
    Friend WithEvents Panel2 As Telerik.Reporting.Panel
    Friend WithEvents TPorcentaje2 As Telerik.Reporting.TextBox
    Friend WithEvents TDescripcion2 As Telerik.Reporting.TextBox
    Friend WithEvents TPerfil2 As Telerik.Reporting.TextBox
    Friend WithEvents Panel1 As Telerik.Reporting.Panel
    Friend WithEvents TPerfil1 As Telerik.Reporting.TextBox
    Friend WithEvents TPorcentaje1 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox1 As Telerik.Reporting.PictureBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents reportNameTextBox As Telerik.Reporting.TextBox
    Friend WithEvents currentTimeTextBox As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox12 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox11 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents TDescripcion1 As Telerik.Reporting.TextBox
End Class
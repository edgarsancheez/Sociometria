<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BuscarReportes.aspx.vb" Inherits="ConsultaVirtual.BuscarReportes" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Charting" tagprefix="telerik" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<%@ Register assembly="PdfViewer" namespace="PdfViewer" tagprefix="cc1" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=9.1.15.624, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Detalles</title>
    <link href="Clases/EstiloPagina.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .HTMLChart
        {
             text-align: left;
             float: none;
        }
        .auto-style1 {
            height: 628px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadCodeBlock ID="codeBlock" runat="server">
        <script type="text/javascript">
            function OnClientSeriesClicked(sender, args) {
                RadAjaxManager1.ajaxRequest(args.get_category());
            }

            function mngRequestStarted(ajaxManager, eventArgs) {
                if (eventArgs.EventTarget == "RadGrid1$ctl00$ctl02$ctl00$ExportToExcelButton") {
                    eventArgs.EnableAjax = false;
                }
            }

            function getSvgContent(sender) {
                //obtain an SVG version of the chart regardless of the browser
                var chartRendering = $find("<%=Chart1.ClientID%>").getSVGString();
                //store the SVG string in a hidden field and escape it so that the value can be posted to the server
                $get("<%=svgHolder.ClientID %>").value = escape(chartRendering);
                //initiate the postback from the button so that its server-side handler is executed
                __doPostBack(sender.name, "");
            }
        </script>

         <script>
             (function (i, s, o, g, r, a, m) {
                 i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                     (i[r].q = i[r].q || []).push(arguments)
                 }, i[r].l = 1 * new Date(); a = s.createElement(o),
                 m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
             })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

             ga('create', 'UA-85965342-1', 'auto');
             ga('send', 'pageview');

    </script>
    </telerik:RadCodeBlock>
      <table cellpadding="0" cellspacing="0" class="style1">
          <tr>
              <td align="center">
                  <table cellpadding="0" cellspacing="0" class="style1">
                      <tr>
                          <td align="center" height="23" style="background-image: url('Imagenes/Background/MainItemBackground.gif'); background-repeat: repeat-x;">
                                <asp:Label ID="Label8" runat="server" style="font-weight: 700; font-family: Arial, Helvetica, sans-serif;" 
                                Text="Seleccione los  filtros deseados" meta:resourcekey="Label8Resource1" Font-Size="14pt"></asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <td align="center">
                                &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="center">
                                <table cellpadding="2" cellspacing="2" border="0"  class="style2" width="100%">
                                    <tr>
                                        <td align="left" valign="top" width="30%" class="auto-style1">
                                            <table cellpadding="3" cellspacing="3" width="200px" class="style3">
                                                <tr>
                                                    <td align="center" height="23" >
                                                        <asp:Label ID="Label9" runat="server" style="font-weight: 700" 
                                                            Text="Seleccione los filtros deseados" meta:resourcekey="Label9Resource1" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" height="23" >
                                            <asp:Label ID="Label1" runat="server" Text="Sección" 
                                                style="font-weight: 700" meta:resourcekey="Label1Resource1" Font-Size="10pt" Font-Names="Arial" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" height="23" >
                                            <telerik:RadComboBox ID="RCBSeccion" Runat="server" MarkFirstMatch="True" 
                                                Width="200px" EmptyMessage="Sin datos que mostrar" AutoPostBack="True" 
                                                meta:resourcekey="RCBtipoResource1" Culture="es-ES">
                                            </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                            <asp:Label ID="Label2" runat="server" Text="Reporte" 
                                                style="font-weight: 700" meta:resourcekey="Label2Resource1" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                            <telerik:RadComboBox ID="RCBReporte" Runat="server" MarkFirstMatch="True" 
                                                Width="200px" AutoPostBack="True" EmptyMessage="Sin datos que mostrar" 
                                                Enabled="False" meta:resourcekey="RCBReporteResource1" Culture="es-ES">
                                            </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                            <asp:Label ID="Label3" runat="server" Text="Subreporte" 
                                                style="font-weight: 700" meta:resourcekey="Label3Resource1" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                            <telerik:RadComboBox ID="RCBSubreporte" Runat="server" MarkFirstMatch="True" 
                                                Width="200px" AutoPostBack="True" EmptyMessage="Sin datos que mostrar" 
                                                meta:resourcekey="RCBsubreporteResource1" Enabled="False" Culture="es-ES">
                                            </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                            <asp:Label ID="Label4" runat="server" Text="Departamento" 
                                                style="font-weight: 700" meta:resourcekey="Label4Resource1" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                            <telerik:RadComboBox ID="RCBDepartamento" Runat="server" MarkFirstMatch="True" 
                                                Width="200px" AutoPostBack="True" EmptyMessage="Sin datos que mostrar" 
                                                Enabled="False" Culture="es-ES" meta:resourcekey="RCBDepartamentoResource1">
                                            </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                            <asp:Label ID="Label5" runat="server" Text="Tipo de Liderazgo" 
                                                style="font-weight: 700" meta:resourcekey="Label5Resource1" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                            <telerik:RadComboBox ID="RCBLiderazgo" Runat="server" MarkFirstMatch="True" 
                                                Width="200px" AutoPostBack="True" EmptyMessage="Sin datos que mostrar" 
                                                meta:resourcekey="REBliderazgoResource1" Enabled="False" Culture="es-ES">
                                                <Items>
                                                    <telerik:RadComboBoxItem runat="server" Text="[Seleccionar]" 
                                                        Value="[Seleccionar]" meta:resourcekey="RadComboBoxItemResource24" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Afinidad" Value="Af" 
                                                        meta:resourcekey="RadComboBoxItemResource25" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Ascendencia" Value="As" 
                                                        meta:resourcekey="RadComboBoxItemResource26" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Popularidad" Value="Po" 
                                                        meta:resourcekey="RadComboBoxItemResource27" />
                                                </Items>
                                            </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                            <asp:Label ID="Label6" runat="server" Text="Tipo de Trabajador" 
                                                style="font-weight: 700" meta:resourcekey="Label6Resource1" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                            <telerik:RadComboBox ID="RCBTrabajador" Runat="server" MarkFirstMatch="True" 
                                                Width="200px" AutoPostBack="True" EmptyMessage="Sin datos que mostrar" 
                                                meta:resourcekey="RCBtrabajadorResource1" Enabled="False" Culture="es-ES">
                                                <Items>
                                                    <telerik:RadComboBoxItem runat="server" Text="[Todos]" 
                                                        Value="[Todos]" meta:resourcekey="RadComboBoxItemResource10" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Comisión Mixta" Value="_c" meta:resourcekey="RadComboBoxItemResource11" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Delegado Sindical" Value="_d" meta:resourcekey="RadComboBoxItemResource12" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Empleados" Value="_e" meta:resourcekey="RadComboBoxItemResource13" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Sindicalizados" Value="_s" meta:resourcekey="RadComboBoxItemResource14" />
                                                </Items>
                                            </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" >
                                                        <telerik:RadButton ID="BVerReporte" runat="server" Text="Ver Reporte" meta:resourcekey="BVerReporteResource1" style="position: relative;">
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" height="23" >
                                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                Font-Size="10pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" height="23" >
                                                        <telerik:RadButton ID="RBPantalla" runat="server" Text="Pantalla completa" 
                                                            ToolTip="Ver reporte en pantalla completa" AutoPostBack="False" 
                                                            style="top: 0px; left: 0px; position: relative;" Visible="False" meta:resourcekey="RBPantallaResource1">
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>
                                            </table>
                                            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                                            </telerik:RadScriptManager>
                                            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest" ClientEvents-OnRequestStart="mngRequestStarted" meta:resourcekey="RadAjaxManager1Resource1">
                                                 <AjaxSettings>
                                                     <telerik:AjaxSetting AjaxControlID="BRegresar">
                                                         <UpdatedControls>
                                                             <telerik:AjaxUpdatedControl ControlID="Chart1" />
                                                             <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                                                             <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" />
                                                         </UpdatedControls>
                                                     </telerik:AjaxSetting>
                                                     <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                                                         <UpdatedControls>
                                                             <telerik:AjaxUpdatedControl ControlID="Chart1" />
                                                             <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                                                             <telerik:AjaxUpdatedControl ControlID="BRegresar" />
                                                         </UpdatedControls>
                                                     </telerik:AjaxSetting>
                                                     <telerik:AjaxSetting AjaxControlID="RadGrid1">
                                                         <UpdatedControls>
                                                             <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                                                         </UpdatedControls>
                                                     </telerik:AjaxSetting>
                                                 </AjaxSettings>
                                             </telerik:RadAjaxManager>
                                            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" meta:resourcekey="RadWindowManager1Resource1">
                                                <Windows>
                                                            <telerik:RadWindow runat="server" 
                                                            Behavior="Close, Maximize" Behaviors="Close, Maximize" 
                                                            InitialBehavior="Maximize" InitialBehaviors="Maximize" Left="" Modal="True" 
                                                            ReloadOnShow="True" Top="" ID="RadDetalles" Height="650px" 
                                                            VisibleStatusbar="False" Width="850px" meta:resourcekey="RadDetallesResource1">
                                                            </telerik:RadWindow>
                                                </Windows>
                                            </telerik:RadWindowManager>
                                            <asp:HiddenField ID="svgHolder" runat="server" />
                                        </td>
                                        <td align="left" width="70%" class="auto-style1">
                                            <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Auto" 
                                                    Width="820px" meta:resourcekey="Panel1Resource2" Font-Names="Arial">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="right">
                                                            <asp:ImageButton ID="BRegresar" runat="server" ImageUrl="~/Imagenes/COManager/back.png" ToolTip="Regresar" Visible="False" meta:resourcekey="BRegresarResource1" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <telerik:RadHtmlChart ID="Chart1" runat="server" CssClass="HTMLChart" Height="550px" OnClientSeriesClicked="OnClientSeriesClicked" ViewStateMode="Enabled" Visible="False" Width="800px" meta:resourcekey="Chart1Resource1">
                                                    <ChartTitle Text="ENCABEZADO PRINCIPAL">
                                                        <Appearance>
                                                            <TextStyle FontSize="16px" />
                                                        </Appearance>
                                                    </ChartTitle>
                                                    <Legend>
                                                        <Appearance>
                                                        </Appearance>
                                                    </Legend>
                                                    <PlotArea>
                                                        <XAxis>
                                                            <TitleAppearance>
                                                                <TextStyle FontSize="16px" />
                                                            </TitleAppearance>
                                                        </XAxis>
                                                        <YAxis>
                                                            <TitleAppearance>
                                                                <TextStyle FontSize="16px" />
                                                            </TitleAppearance>
                                                        </YAxis>
                                                    </PlotArea>
                                                    <Navigator>
                                                        <XAxis>
                                                            <TitleAppearance>
                                                                <TextStyle FontSize="16px" />
                                                            </TitleAppearance>
                                                        </XAxis>
                                                    </Navigator>
                                                </telerik:RadHtmlChart>
                                            <telerik:ReportViewer ID="ReportViewer1" runat="server" Width="800px" 
                                                Height="550px" Visible="False"
                                                Font-Size="8pt" Font-Names="Verdana" meta:resourcekey="ReportViewer1Resource1" >
                                            </telerik:ReportViewer>
                                            <telerik:RadGrid ID="RadGrid1" runat="server" Height="550px" 
                                                Width="800px" Visible="False" Culture="es-ES" meta:resourcekey="RadGrid1Resource1" GroupPanelPosition="Top" >
                                                <ExportSettings FileName="ReporteClima" 
                                                ExportOnlyData="True" HideStructureColumns="True">
                                                <Excel FileExtension="xlsx">
                                                </Excel>
                                                </ExportSettings>
                                                <ClientSettings>
                                                    <Selecting AllowRowSelect="True" />
                                                    <Scrolling AllowScroll="True" FrozenColumnsCount="3" UseStaticHeaders="True" />
                                                </ClientSettings>
                                                <MasterTableView CommandItemDisplay="Top" Width="100%">
                                                    <CommandItemSettings AddNewRecordText="" ExportToExcelText="Exportar a Excel" ExportToWordText="Exportar a Word" RefreshText="" ShowAddNewRecordButton="False" ShowExportToExcelButton="True" ShowRefreshButton="False" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                                <asp:Chart ID="Chart2" runat="server" BackColor="WhiteSmoke" 
                                                BackGradientStyle="TopBottom" BorderlineColor="Black" 
                                                BorderlineDashStyle="Solid" Height="600px"
                                                Visible="False" Width="800px" meta:resourcekey="Chart2Resource1">
                                                    <Series>
                                                        <asp:Series ChartArea="ChartArea1" CustomProperties="DrawingStyle=Cylinder, PointWidth=0.5, LabelStyle=Top" Font="Arial, 9pt, style=Bold" IsVisibleInLegend="False" Legend="Legend1" Name="Series1">
                                                            <SmartLabelStyle CalloutStyle="None" />
                                                        </asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea BackColor="White" BackSecondaryColor="Silver" IsSameFontSizeForAllAxes="True" Name="ChartArea1">
                                                            <axisy intervalautomode="VariableCount" isinterlaced="True" InterlacedColor="White" 
                                                            title="EJE Y" Maximum="110" Minimum="10" >
                                                                <MajorGrid Enabled="False" />
                                                                <StripLines>
                                                                    <asp:StripLine BackColor="Red" BackSecondaryColor="White" BorderColor="Red" BorderDashStyle="NotSet" BorderWidth="0" Interval="70" IntervalOffset="70" StripWidth="1" />
                                                                    <asp:StripLine BackColor="Yellow" BorderColor="Yellow" BorderWidth="0" Interval="80" IntervalOffset="80" StripWidth="1" />
                                                                    <asp:StripLine BackColor="Blue" BorderColor="Blue" BorderWidth="0" Interval="90" IntervalOffset="90" StripWidth="1" />
                                                                    <asp:StripLine BackColor="Green" BorderColor="Green" BorderWidth="0" Interval="100" IntervalOffset="100" StripWidth="1" />
                                                                </StripLines>
                                                            </AxisY>
                                                            <AxisX InterlacedColor="White" IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                                                                <MajorGrid Enabled="False" />
                                                                <StripLines>
                                                                    <asp:StripLine BackColor="Black" BorderColor="Black" Interval="60" IntervalOffset="60" />
                                                                    <asp:StripLine BackColor="Black" BorderColor="Black" Interval="80" IntervalOffset="80" />
                                                                </StripLines>
                                                                <LabelStyle Angle="-90" Enabled="False" />
                                                                <ScaleBreakStyle BreakLineStyle="None" LineColor="" />
                                                            </AxisX>
                                                            <InnerPlotPosition Auto="False" Height="75" Width="95" X="5" Y="2" />
                                                            <Area3DStyle LightStyle="Realistic" />
                                                        </asp:ChartArea>
                                                    </ChartAreas>
                                                    <Legends>
                                                        <asp:Legend Alignment="Center" AutoFitMinFontSize="8" BackColor="WhiteSmoke" BorderColor="Silver" DockedToChartArea="ChartArea1" Docking="Bottom" Font="Microsoft Sans Serif, 7pt" IsDockedInsideChartArea="False" IsEquallySpacedItems="True" IsTextAutoFit="False" Name="Legend1">
                                                            <CustomItems>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Box_Gray.png" Name="1">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Box_Green.png" Name="2">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Blue.png" Name="3">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Green.png" Name="4">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Orange.png" Name="5">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Red.png" Name="6">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Yellow.png" Name="7">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Pentagon_blue.png" Name="8">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Pentagon_lightblue.png" Name="9">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Rhombus_blue.png" Name="10">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Rhombus_lightblue.png" Name="11">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_blue.png" Name="12">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_Green.png" Name="13">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_Red.png" Name="14">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_Yellow.png" Name="15">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Square_blue.png" Name="16">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Square_Green.png" Name="17">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Star_Black.png" Name="18">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Star_Blue.png" Name="19">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Star_Green.png" Name="20">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Star_Yellow.png" Name="21">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Triangle_Black.png" Name="22">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Triangle_Blue.png" Name="23">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Box_Gray.png" Name="24">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Box_Green.png" Name="25">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Blue.png" Name="26">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Green.png" Name="27">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Orange.png" Name="28">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Yellow.png" Name="29">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Pentagon_blue.png" Name="30">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Pentagon_lightblue.png" Name="31">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Rhombus_blue.png" Name="32">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Rhombus_lightblue.png" Name="33">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_blue.png" Name="34">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_Green.png" Name="35">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Square_blue.png" Name="36">
                                                                </asp:LegendItem>
                                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Square_Green.png" Name="37">
                                                                </asp:LegendItem>

                                                           <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Box_Gray.png" Name="38">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Box_Green.png" Name="39">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Blue.png" Name="40">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Green.png" Name="41">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Orange.png" Name="42">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Red.png" Name="43">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Yellow.png" Name="44">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Pentagon_blue.png" Name="45">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Pentagon_lightblue.png" Name="46">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Rhombus_blue.png" Name="47">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Rhombus_lightblue.png" Name="48">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_blue.png" Name="49">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_Green.png" Name="50">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_Red.png" Name="51">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_Yellow.png" Name="52">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Square_blue.png" Name="53">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Square_Green.png" Name="54">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Star_Black.png" Name="55">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Star_Blue.png" Name="56">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Star_Green.png" Name="57">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Star_Yellow.png" Name="58">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Triangle_Black.png" Name="59">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Triangle_Blue.png" Name="60">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Box_Gray.png" Name="61">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Box_Green.png" Name="62">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Blue.png" Name="63">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Green.png" Name="64">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Orange.png" Name="65">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Circle_Yellow.png" Name="66">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Pentagon_blue.png" Name="67">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Pentagon_lightblue.png" Name="68">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Rhombus_blue.png" Name="69">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Rhombus_lightblue.png" Name="70">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_blue.png" Name="71">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Shield_Green.png" Name="72">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Square_blue.png" Name="73">
                                                </asp:LegendItem>
                                                <asp:LegendItem Enabled="False" Image="~/Imagenes/Correlacion/Square_Green.png" Name="74">
                                                </asp:LegendItem>
                                                            </CustomItems>
                                                        </asp:Legend>
                                                    </Legends>
                                                    <Titles>
                                                        <asp:Title Font="Arial, 12pt, style=Bold" Name="Title1" Text="ENCABEZADO PRINCIPAL">
                                                        </asp:Title>
                                                        <asp:Title Font="Arial, 11pt, style=Bold" Name="Title2" Text="Titulo Dos">
                                                            <Position Auto="False" Height="2.7" Width="91.37171" X="4.3141427" Y="8.5" />
                                                        </asp:Title>
                                                    </Titles>
                                                    <borderskin backcolor="" bordercolor="" pagecolor="" skinstyle="Emboss" />
                                            </asp:Chart>
                                            <cc1:ShowPdf ID="ShowPdf1" runat="server" Height="600px" Visible="False"  
                                                    Width="800px" meta:resourcekey="ShowPdf1Resource1" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                          </td>
                      </tr>
                      <tr>
                          <td>
                              &nbsp;</td>
                      </tr>
                  </table>
              </td>
          </tr>
    </table>
    </form>
</body>
</html>

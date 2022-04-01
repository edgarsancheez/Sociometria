<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GraficaImpacto.aspx.vb" Inherits="ConsultaVirtual.GraficaImpacto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>




<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=9.1.15.624, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="Clases/EstiloPagina.css" rel="stylesheet" type="text/css" />
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
</head>
<body>
    <form id="form1" runat="server" style="clip: rect(5px, 5px, 5px, 5px)">
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr align="center" valign="middle">
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="0" class="style2">
                        <tr align="center" valign="middle">
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="80%">
                                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                Font-Size="9pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="center" valign="middle">
                            <td>
                                <asp:Chart ID="Chart1" runat="server" BackColor="WhiteSmoke" 
                                    BackGradientStyle="TopBottom" BorderlineColor="Black" 
                                    BorderlineDashStyle="Solid" Height="600px"
                                    Visible="False" Width="800px" meta:resourcekey="Chart1Resource1">
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
                    <telerik:RadGrid ID="RadGrid1" runat="server" Height="550px" 
                        ShowFooter="True" Width="800px" ShowStatusBar="True" Visible="False" GroupPanelPosition="Top" meta:resourcekey="RadGrid1Resource1" >
                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                        <ExportSettings FileName="ReporteClima" Excel-FileExtension="xlsx" 
                        ExportOnlyData="True" HideStructureColumns="True">
                        <Excel FileExtension="xlsx">
                        </Excel>
                        </ExportSettings>
                        <FooterStyle Font-Bold="True" />
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemSettings   ShowExportToExcelButton="True"    
                                ExportToExcelText="Exportar a Excel" ShowExportToWordButton="True" 
                                ExportToWordText="Exportar a Word"  AddNewRecordText="" RefreshText="" 
                                ShowAddNewRecordButton="False" ShowRefreshButton="False" />

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                Wrap="True" />
                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                Wrap="True" />
                            <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                            Font-Strikeout="False" Font-Underline="False" Wrap="True" />
                        </MasterTableView>
                        <ClientSettings AllowDragToGroup="False">
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" FrozenColumnsCount="3" />
                            <Resizing AllowColumnResize="True" />
                        </ClientSettings>
                    </telerik:RadGrid>
                    </td>
                        </tr>
                        <tr align="center" valign="middle">
                            <td>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
</telerik:RadScriptManager>
                    </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

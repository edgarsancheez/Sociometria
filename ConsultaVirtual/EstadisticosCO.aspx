<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EstadisticosCO.aspx.vb" Inherits="ConsultaVirtual.EstadisticosCO" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Clases/EstiloPagina.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .HTMLChart
        {
             text-align: left;
             float: none;
        }
    </style>
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
                    
                    //store the SVG string in a hidden field and escape it so that the value can be posted to the server
                    $get("<%=svgHolder.ClientID %>").value = escape(chartRendering);
                    //initiate the postback from the button so that its server-side handler is executed
                    __doPostBack(sender.name, "");
                }
            </script>
        </telerik:RadCodeBlock>
    <table cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
            <table cellpadding="2" cellspacing="0" class="style2"
            style="font-family: arial, Helvetica, sans-serif; font-size: small;" >
                <tr align="center" valign="middle">
                    <td align="center" width="10%">
                        &nbsp;</td>
                    <td colspan="2" align="center" width="80%">
                                    <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                        Font-Size="9pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label>
                    </td>
                    <td align="center" width="10%">
                        &nbsp;</td>
                </tr>
                <tr align="center" valign="middle">
                    <td align="right">
                        &nbsp;</td>
                    <td align="right" style="width: 15%; padding-right:25px">
                        <asp:Label ID="Label1" runat="server" Text="Tema: " 
                        style="font-weight: 700" Visible="true" ></asp:Label>
                    </td>
                    <td align="left" style="width: 25%">
                        <telerik:RadComboBox ID="RCBTemas" Runat="server" MarkFirstMatch="True" 
                            Width="200px" EmptyMessage="Sin datos que mostrar" AutoPostBack="True">
                        </telerik:RadComboBox>
                    </td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr runat="server" id="TR2" align="center" valign="middle" visible="false">
                    <td align="right">
                        &nbsp;</td>
                    <td align="center" style="padding-right:25px" colspan="2">
                          
                    <asp:Button ID="BTNREPORTE" runat="server" Text="Exportar Reporte Completo" />
                    </td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr align="center" valign="middle">
                    <td>
                        &nbsp;</td>
                    <td colspan="2">
                       <telerik:RadGrid ID="RadGrid1" runat="server" Height="550px"
                            ShowFooter="True" Width="100%" ShowStatusBar="True" GroupPanelPosition="Top" >
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
                                    Font-Strikeout="False" Font-Underline="False" 
                                    Wrap="True" />
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                    Wrap="True" />
                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                Font-Strikeout="False" Font-Underline="False" Wrap="True" />
                            </MasterTableView>
                            <ClientSettings AllowDragToGroup="False">
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" FrozenColumnsCount="3"/>
                                <Resizing AllowColumnResize="True" />
                                
                            </ClientSettings>
                        </telerik:RadGrid>
                        <telerik:RadGrid ID="RadGrid2" runat="server" Visible="false"></telerik:RadGrid>

                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr align="center" valign="middle">
                    <td>
                        &nbsp;</td>
                    <td colspan="2">
                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>
                                
                                <asp:HiddenField ID="svgHolder" runat="server" />
                    </td>
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

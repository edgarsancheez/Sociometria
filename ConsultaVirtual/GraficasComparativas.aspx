<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GraficasComparativas.aspx.vb" Inherits="ConsultaVirtual.GraficasComparativas" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
        </telerik:RadCodeBlock>
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr align="center" valign="middle">
                <td>
                <table cellpadding="0" cellspacing="0" width="100%" align="center" class="style2">
                    <tr>
                        <td align="center">
                            <table width="800px">
                                <tr>
                                    <td align="left" width="10%">
                                            &nbsp;</td>
                                    <td width="80%" align="center">
                                        <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                            Font-Size="9pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label>
                                    </td>
                                    <td width="10%" align="right">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                                <telerik:RadHtmlChart ID="Chart1" runat="server" CssClass="HTMLChart" Height="550px" ViewStateMode="Enabled" Visible="False" Width="800px" meta:resourcekey="Chart1Resource1">
                                    <ChartTitle Text="ENCABEZADO PRINCIPAL">
                                    </ChartTitle>
                                </telerik:RadHtmlChart>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                                </telerik:RadScriptManager>
                                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest" ClientEvents-OnRequestStart="mngRequestStarted" meta:resourcekey="RadAjaxManager1Resource1">
                                        <AjaxSettings>
                                            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                                                <UpdatedControls>
                                                    <telerik:AjaxUpdatedControl ControlID="Chart1" />
                                                </UpdatedControls>
                                            </telerik:AjaxSetting>
                                        </AjaxSettings>
                                    </telerik:RadAjaxManager>
                                <asp:HiddenField ID="svgHolder" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
    </form>
</body>
</html>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ComparativaTemas.aspx.vb" Inherits="ConsultaVirtual.ComparativaTemas" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
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
            <tr align="center" valign="middle">
                <td>
                    <telerik:RadGrid ID="RadGrid1" runat="server" Height="600px" 
                    ShowFooter="True" Width="95%" ShowStatusBar="True" GroupPanelPosition="Top" meta:resourcekey="RadGrid1Resource1" >
                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                        <ExportSettings FileName="ReporteClima" Excel-FileExtension="xlsx" 
                        ExportOnlyData="True" HideStructureColumns="True">
                        <Excel FileExtension="xlsx">
                        </Excel>
                        </ExportSettings>
                        <FooterStyle Font-Bold="True" />
                        <MasterTableView CommandItemDisplay="Top" Width="95%">
                            <CommandItemSettings ShowExportToExcelButton="True" 
                                ExportToExcelText="Exportar a Excel" AddNewRecordText="" RefreshText="" 
                                showaddnewrecordbutton="False" showrefreshbutton="False" />
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
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            <Resizing AllowColumnResize="True" />
                        </ClientSettings>
                    </telerik:RadGrid>
                   <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>
                    &nbsp;<asp:Label ID="LError" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                    </tr>
        </table>
    </form>
</body>
</html>

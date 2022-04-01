<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PantallaCompleta.aspx.vb" Inherits="ConsultaVirtual.PantallaCompleta" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>






<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=9.1.15.624, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reportes</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            border-color: #c0c0c0;
            border-width: 0;
            background-color: #333333;
        }
        .style2
        {
            width: 95%;
            height: 500px;
            border-color: #c0c0c0;
            border-width: 0;
            background-color: #ffffff;
        }
        .style3
        {
            border: 1px solid #c0c0c0;
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
        <table cellpadding="0" cellspacing="0" class="style2" width="100%">
            <tr align="center" valign="middle">
                <td>
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                </telerik:RadScriptManager>
                </td>
            </tr>
            <tr align="center" valign="middle">
                <td>
            <telerik:RadGrid ID="RadGrid1" runat="server" Height="600px" 
            ShowFooter="True" Width="100%" ShowStatusBar="True" Visible="False" GroupPanelPosition="Top" meta:resourcekey="RadGrid1Resource1" >
                <ExportSettings FileName="ReporteClima" Excel-FileExtension="xlsx" 
                ExportOnlyData="True" HideStructureColumns="True">
                <Excel FileExtension="xlsx">
                </Excel>
                </ExportSettings>
                <FooterStyle Font-Bold="True" />
                <MasterTableView CommandItemDisplay="Top" TableLayout="Fixed">
                    <CommandItemSettings ShowExportToExcelButton="True" 
                        ExportToExcelText="Exportar a Excel" AddNewRecordText="" RefreshText="" 
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
                </MasterTableView>
                <HeaderStyle Wrap="True" />

                <FilterMenu EnableImageSprites="False"></FilterMenu>

                <ClientSettings AllowDragToGroup="False">
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" FrozenColumnsCount="3" />
                    <Resizing AllowColumnResize="False" />
                </ClientSettings>
            </telerik:RadGrid>
                </td>
            </tr>
            <tr align="center" valign="middle">
                <td>
                    <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="600px" 
                        Width="90%" meta:resourcekey="ReportViewer1Resource1" ReportBookID=""></telerik:ReportViewer>
                </td>
            </tr>
            <tr align="center" valign="middle">
                <td>
                    <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="#990033" meta:resourcekey="LerrorResource1"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

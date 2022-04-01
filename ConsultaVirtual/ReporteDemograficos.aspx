<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReporteDemograficos.aspx.vb" Inherits="ConsultaVirtual.ReporteDemograficos" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>





<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=9.1.15.624, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
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
            <table cellpadding="0" cellspacing="0" class="style2"
            style="font-family: arial, Helvetica, sans-serif; font-size: small;">
                <tr align="center" valign="middle">
                    <td width="10%">
                        &nbsp;</td>
                    <td width="80%">
                        <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                            Font-Size="9pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label>
                    </td>
                    <td width="10%">
                        &nbsp;</td>
                </tr>
                <tr align="center" valign="middle">
                    <td>
                        &nbsp;</td>
                    <td align="center">
                        <asp:Label ID="Label1" runat="server" Text="Demográfico:" 
                            style="font-weight: 700" meta:resourceKey="Label2Resource2" ></asp:Label>
                        &nbsp;
                        <telerik:RadComboBox ID="RCBSubreporte" Runat="server" MarkFirstMatch="True" 
                            Width="200px" AutoPostBack="True" EmptyMessage="Sin datos que mostrar" 
                            meta:resourcekey="RCBsubreporteResource1" Enabled="False">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr align="center" valign="middle">
                    <td>
                        &nbsp;</td>
                    <td align="center">
                        <telerik:RadGrid ID="RadGrid1" runat="server" Height="550px" 
                            ShowFooter="True" Width="100%" ShowStatusBar="True" GroupPanelPosition="Top" meta:resourcekey="RadGrid1Resource1" >
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
                    <td>
                        &nbsp;</td>
                </tr>
                <tr align="center" valign="middle">
                    <td colspan="3">
                        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                        </telerik:RadScriptManager>
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>

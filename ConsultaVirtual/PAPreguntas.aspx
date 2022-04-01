<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PAPreguntas.aspx.vb" Inherits="ConsultaVirtual.PAPreguntas" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>




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
<script type="text/javascript" language="javascript">
    function SetStatus(headObj) {

        var obj = document.getElementsByTagName("input");
        for (var i = 0; i < obj.length; i++) {
            if (obj[i].type.toLowerCase() == "checkbox" &&
            obj[i].name.toLowerCase() != headObj.name.toLowerCase()){
                if (headObj.checked)
                    obj[i].checked = true;
                else
                    obj[i].checked = false;
            }
        }
        return true;
    }
</script>
<body>
    <form id="form1" runat="server" style="clip: rect(5px, 5px, 5px, 5px)">
     <table cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr align="center" valign="middle">
            <td>
                <table class="style2">
                    <tr align="center" valign="middle">
                        <td>
                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                Font-Size="9pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr align="center" valign="middle">
                        <td>
                            <telerik:RadGrid ID="RadGrid1" runat="server" 
                                Height="500px" Width="700px" GroupPanelPosition="Top" meta:resourcekey="RadGrid1Resource1">
                                <ClientSettings>
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>
                            <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                                <Columns>
                                <telerik:GridTemplateColumn UniqueName="TemplateColumn" meta:resourcekey="GridTemplateColumnResource1">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckHead" runat="server" onclick="SetStatus(this);" meta:resourcekey="CheckHeadResource1"  />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Check" runat="server" meta:resourcekey="CheckResource1" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" />
                                    <ItemStyle Width="5%" />
                                </telerik:GridTemplateColumn>
                                </Columns>
                            <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>
                            </MasterTableView>
                            <FilterMenu EnableImageSprites="False"></FilterMenu>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr align="center" valign="middle">
                        <td>
                            <telerik:RadButton ID="BGuardar" runat="server" Text="Guardar" meta:resourcekey="BGuardarResource1" style="position: relative;">
                                <Icon PrimaryIconLeft="4" PrimaryIconTop="4" 
                                    PrimaryIconUrl="Imagenes/COManager/Save16.png" />
                            </telerik:RadButton>
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

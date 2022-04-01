<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReporteLiderazgo.aspx.vb" Inherits="ConsultaVirtual.ReporteLiderazgo" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>




<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=9.1.15.624, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html id="html" xmlns="http://www.w3.org/1999/xhtml" >
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
                    <table cellpadding="0" cellspacing="0" class="style2">
                        <tr>
                            <td width="80%" align="center">
                                <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                    Font-Size="9pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="80%" align="center">
                    <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="600px" 
                        Width="80%" meta:resourcekey="ReportViewer1Resource1" ReportBookID=""></telerik:ReportViewer>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
    </form>
</body>
</html>

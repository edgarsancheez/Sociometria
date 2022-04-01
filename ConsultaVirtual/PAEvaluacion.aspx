<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PAEvaluacion.aspx.vb" Inherits="ConsultaVirtual.PAEvaluacion" meta:resourcekey="PageResource1" uiculture="auto" %>
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
<body>
    <form id="form1" runat="server" style="clip: rect(5px, 5px, 5px, 5px)">
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="middle">
                    <table cellpadding="0" cellspacing="0" class="style2">
                        <tr align="center" valign="middle">
                            <td>
                                <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                Font-Size="9pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center" valign="middle">
                            <td>
                                <table style="width:100%;" 
                                    style="font-family: arial, Helvetica, sans-serif; font-size: small;" >
                                        <tr>
                                            <td width="25%">
                                                &nbsp;</td>
                                            <td width="30%">
                                                &nbsp;</td>
                                            <td width="30%">
                                                &nbsp;</td>
                                            <td width="15%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label10" runat="server" Text="Plan de Acción" 
                                                style="font-weight: 700" meta:resourcekey="Label2Resource2" ></asp:Label>
                                            </td>
                                            <td align="left" colspan="2">
                                                <telerik:RadComboBox ID="RCBPlan" Runat="server" Width="80%" meta:resourcekey="RCBPlanResource1">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label11" runat="server" Text="Objetivo" 
                                                style="font-weight: 700" meta:resourcekey="Label2Resource2" ></asp:Label>
                                            </td>
                                            <td align="left" colspan="2">
                                                <telerik:RadComboBox ID="RCBObjetivo" Runat="server" Width="80%" meta:resourcekey="RCBObjetivoResource1">
                                                </telerik:RadComboBox>
                                                </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label12" runat="server" Text="Iniciativa" 
                                                style="font-weight: 700" meta:resourcekey="Label2Resource2" ></asp:Label>
                                            </td>
                                            <td align="left" colspan="2">
                                                <telerik:RadComboBox ID="RCBIniciativa" Runat="server" Width="80%" meta:resourcekey="RCBIniciativaResource1">
                                                </telerik:RadComboBox>
                                                </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label13" runat="server" Text="Evaluación" 
                                                style="font-weight: 700" meta:resourcekey="Label2Resource2" ></asp:Label>
                                            </td>
                                            <td align="left" colspan="2">
                                                <telerik:RadRating ID="RadRating1" Runat="server" ItemCount="10" DbValue="0" meta:resourcekey="RadRating1Resource1">
                                                </telerik:RadRating>
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                <asp:Label ID="Label14" runat="server" Text="Notas" 
                                                style="font-weight: 700" meta:resourcekey="Label2Resource2" ></asp:Label>
                                            </td>
                                            <td align="left" colspan="2">
                                                <telerik:RadTextBox ID="RTNotas" Runat="server" Width="80%" Rows="3" 
                                                    TextMode="MultiLine" LabelWidth="40%" meta:resourcekey="RTNotasResource1" Resize="None">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                &nbsp;</td>
                                            <td align="left" colspan="2">
                                                <asp:Label ID="LNumUsuario" runat="server" Visible="False" meta:resourcekey="LNumUsuarioResource1"></asp:Label>
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                <telerik:RadGrid ID="RadGrid1" runat="server" 
                                    Height="300px" Width="100%" GroupPanelPosition="Top" meta:resourcekey="RadGrid1Resource1">
                                    <ClientSettings>
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                        <MasterTableView TableLayout="Fixed" Width="99%">
                                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                        </RowIndicatorColumn>

                                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                        </ExpandCollapseColumn>

                                        <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>
                                        </MasterTableView>

                                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <telerik:RadButton ID="BGuardar" runat="server" Text="Guardar" meta:resourcekey="BGuardarResource1" style="position: relative;">
                                                    <Icon PrimaryIconLeft="4" PrimaryIconTop="4" 
                                                        PrimaryIconUrl="Imagenes/COManager/Save16.png" />
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
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

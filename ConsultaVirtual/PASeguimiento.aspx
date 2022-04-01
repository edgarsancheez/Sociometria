<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PASeguimiento.aspx.vb" Inherits="ConsultaVirtual.PASeguimiento" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
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
    
<script type="text/javascript">
    function OnClientEntryAddingHandler(sender, eventArgs)
    {  
        if(sender.get_entries().get_count() > 0)
        {
            eventArgs.set_cancel(true);
    //        alert("You can select only one entry");
        }
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
                            <asp:Label ID="LPlan" runat="server" Visible="False" meta:resourcekey="LPlanResource1"></asp:Label>
                            <asp:Label ID="LObjetivo" runat="server" Visible="False" meta:resourcekey="LObjetivoResource1"></asp:Label>
                            <asp:Label ID="LIniciativa" runat="server" Visible="False" meta:resourcekey="LIniciativaResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr align="center" valign="middle">
                        <td>
                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                Font-Size="9pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr align="center" valign="middle">
                        <td>
                            <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel1Resource1">
                                <table width="800px" >
                                    <tr>
                                        <td width="30%">
                                            &nbsp;</td>
                                        <td width="50%">
                                            &nbsp;</td>
                                        <td width="20%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label26" runat="server" Text="Accion" 
                                            style="font-weight: 700" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="Label26Resource1" ></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="RCBAccion" Runat="server" Width="80%" Culture="es-ES" meta:resourcekey="RCBAccionResource1">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="10pt" style="font-weight: 700" Text="Fecha" meta:resourcekey="Label13Resource1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadDatePicker ID="RDPFecha" Runat="server" Culture="en-US" meta:resourcekey="RDPFechaResource1">
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;">
                                                </Calendar>
                                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" Width="">
                                                    <EmptyMessageStyle Resize="None" />
                                                    <ReadOnlyStyle Resize="None" />
                                                    <FocusedStyle Resize="None" />
                                                    <DisabledStyle Resize="None" />
                                                    <InvalidStyle Resize="None" />
                                                    <HoveredStyle Resize="None" />
                                                    <EnabledStyle Resize="None" />
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" CssClass="" />
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Label ID="Label10" runat="server" style="font-weight: 700" Text="Bitacora" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="Label10Resource1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadTextBox ID="RTBitacora" Runat="server" Rows="3" TextMode="MultiLine" Width="80%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTBitacoraResource1" Resize="None">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </telerik:RadTextBox>
                                        </td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <telerik:RadButton ID="BGuardarB" runat="server" Text="Guardar" meta:resourcekey="BGuardarBResource1">
                                                <Icon PrimaryIconLeft="4px" PrimaryIconTop="4px" 
                                                    PrimaryIconUrl="Imagenes/COManager/Save16.png" />
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr align="center" valign="middle">
                        <td>
                            <asp:Panel ID="Panel2" runat="server" Visible="False" meta:resourcekey="Panel2Resource1">
                                <table width="800px" >
                                    <tr>
                                        <td width="50%">&nbsp;</td>
                                        <td width="30%">&nbsp;</td>
                                        <td width="20%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" Text="Avance" 
                    style="font-weight: 700" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="Label11Resource1" ></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadTextBox ID="RTAvance" Runat="server" Width="20%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTAvanceResource1" Resize="None">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </telerik:RadTextBox>
                                            <asp:Label ID="Label25" runat="server" Text="%" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="Label25Resource1"></asp:Label>
                                        </td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <telerik:RadButton ID="BGuardarA" runat="server" Text="Guardar" meta:resourcekey="BGuardarAResource1">
                                                <Icon PrimaryIconLeft="4px" PrimaryIconTop="4px" 
                                                    PrimaryIconUrl="Imagenes/COManager/Save16.png" />
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr align="center" valign="middle">
                        <td>
                            <asp:Panel ID="Panel3" runat="server" Visible="False" meta:resourcekey="Panel3Resource1">
                                <table width="800px">
                                    <tr>
                                        <td width="30%"></td>
                                        <td width="50%"></td>
                                        <td width="20%"></td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label19" runat="server" style="font-weight: 700" Text="Iniciativa" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="Label19Resource1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="RCBIniciativaE" Runat="server" AutoPostBack="True" Width="80%" Culture="es-ES" meta:resourcekey="RCBIniciativaEResource1">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Label ID="Label24" runat="server" style="font-weight: 700" Text="Notas" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="Label24Resource1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadTextBox ID="RTNotas" Runat="server" Rows="3" TextMode="MultiLine" Width="80%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTNotasResource1" Resize="None">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </telerik:RadTextBox>
                                        </td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label21" runat="server" 
                                                style="font-weight: 700" Text="Nombre" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="Label21Resource1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="RCBNombre2" Runat="server" 
                                                AutoPostBack="True" DataValueField="-1"
                                                EnableLoadOnDemand="True" EnableVirtualScrolling="True" Filter="Contains" 
                                                Height="100px" ItemsPerRequest="10" MinFilterLength="5" 
                                                ShowMoreResultsBox="True" ShowToggleImage="False" Width="80%" 
                                                Enabled="False" EmptyMessage="Seleccione" Culture="es-ES" meta:resourcekey="RCBNombre2Resource1">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label22" runat="server" 
                                                style="font-weight: 700" Text="Correo" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="Label22Resource1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadTextBox ID="RTCorreo2" Runat="server" Width="80%" Enabled="False" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTCorreo2Resource1" Resize="None">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </telerik:RadTextBox>
                                        </td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label23" runat="server" 
                                                style="font-weight: 700" Text="Puesto" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="Label23Resource1"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadTextBox ID="RTPuesto2" Runat="server" Width="80%" Enabled="False" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTPuesto2Resource1" Resize="None">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </telerik:RadTextBox>
                                        </td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <telerik:RadButton ID="BEnviar" runat="server" Text="Enviar" meta:resourcekey="BEnviarResource1">
                                                <Icon PrimaryIconLeft="4px" PrimaryIconTop="4px" 
                                                    PrimaryIconUrl="Imagenes/COManager/Mail16.png" />
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr align="center" valign="middle">
                        <td>
                            &nbsp;</td>
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

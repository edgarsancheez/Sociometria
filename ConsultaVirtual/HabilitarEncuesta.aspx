<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HabilitarEncuesta.aspx.vb" Inherits="ConsultaVirtual.HabilitarEncuesta" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="X-UA-Compatible" content="IE=Edge" />

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Clima Organizacional</title>
     
    <link href="Clases/EstiloPagina.css" rel="stylesheet" type="text/css" />
    <%--<link href="Clases/Menu.css" rel="stylesheet" type="text/css" />--%>
    <style type="text/css">
        .RadMenu .rmGroup .rmText
        {
            text-align: left !important; 
        }

        .RadTile .rtileBottomContent {
            min-width: 100%;
            background-color: black;
            opacity: .7;
        }
        .RadTile h6.rtileTitle {
            width: 100%;
            left: 10px;
            text-align: left;
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
      
                  <table cellpadding="0" cellspacing="0" class="style1" >
                      <tr>
                          <td align="left" height="46px" 
                              style="background-position: center; background-image: url('Imagenes/Background/Banner.png'); background-repeat: no-repeat;" 
                              valign="bottom">
                              <uc2:Head ID="Head2" runat="server" EnableTheming="True" 
                                  EnableViewState="False" />
                          </td>
                      </tr>
                     
                      <tr>
                          <td align="center" height="23px">
                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                Font-Size="10pt" ForeColor="White" meta:resourcekey="LerrorResource1" ></asp:Label>
                          </td>
                       
                       
                         </tr>

                      
                        <tr align="center">
                            <td >
                                  <table class="style2">
                                        <tr>
                                                <td align="center" valign="top">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%"
                                                        style="font-family: arial, Helvetica, sans-serif; font-size: small;">
                                                          <tr>
                          
                                                             <td align="center">
                                                                   <table align="left" border="0" style="width:100%;">
                                                                
                                                                                                    <tr>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LUnidad" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black"  style="font-weight: 700" Text="Unidad de Negocio" meta:resourcekey="LUnidadResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LAgrupado" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black"  style="font-weight: 700" Text="Agrupado Pais" meta:resourcekey="LAgrupadoResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LPais" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black" style="font-weight: 700" Text="Pais" meta:resourcekey="LPaisResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LTerritorio" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black" style="font-weight: 700" Text="Territorio" meta:resourcekey="LTerritorioResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LRegion" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black" style="font-weight: 700" Text="Región" meta:resourcekey="LRegionResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LSubregion" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black"  style="font-weight: 700" Text="Subregión" meta:resourcekey="LSubregionResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="15%">
                                                                                                            <asp:Label ID="LEmpresa" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black" style="font-weight: 700" Text="Centro de Trabajo" meta:resourcekey="LEmpresaResource1"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RUnidad" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RUnidadResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RRegionPaises" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RRegionPaisesResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RPaises" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RPaisesResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RTerritorios" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RTerritoriosResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RRegiones" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RRegionesResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RSubregiones" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RSubregionesResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="15%">
                                                                                                            <telerik:RadListBox ID="RCentroDeTrabajo" runat="server" Height="100%"  Width="98%" AutoPostBack="True" meta:resourcekey="RCentroDeTrabajoResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                            </td>
                                                          </tr>
                   
                                                          <tr runat="server" id="TRInfo">
                                                                         
                                                            <td align="center">
                                                                <table style="width:100%">
                                                                  <tr style="padding-left:10px;">
                                                                        
                                                                    <td style="width:10%;text-align:left; padding-left:20px">


                                                                        <asp:Label ID="Label1" runat="server" Text="Head Count:" Font-Bold="True" meta:resourcekey="Label1Resource1"></asp:Label>


                                                                    </td>
                                                                    <td style="width:10%">


                                                                        <telerik:RadTextBox ID="TxtHeadCount" Runat="server" Enabled="False" Width="100px" Skin="Bootstrap" LabelWidth="40px" meta:resourcekey="TxtHeadCountResource1" Resize="None">
                                                                        </telerik:RadTextBox>
                                                                      </td>
                                                                    <td style="width:40%;text-align:center" colspan="2">


                                                                        <asp:Label ID="Label3" runat="server" Text="Inicio Encuesta" Font-Bold="True" meta:resourcekey="Label3Resource1"></asp:Label>


                                                                    </td>
                                                                    <td style="width:40%;text-align:center;">


                                                                        <asp:Label ID="Label4" runat="server" Text="Fin Encuesta" Font-Bold="True" meta:resourcekey="Label4Resource1"></asp:Label>


                                                                    </td>


                                                                  </tr>

                                                                    <tr style="padding-left:10px;">
                                                                    <td style="width:10%; text-align:left;padding-left:20px">


                                                                        <asp:Label ID="Label2" runat="server" Text="Folios Disponibles:" Font-Bold="True" meta:resourcekey="Label2Resource1"></asp:Label>


                                                                    </td>
                                                                    <td style="width:10%">


                                                                        <telerik:RadTextBox ID="TxtFoliosDisp" Runat="server" Enabled="False" Width="100px" Skin="Bootstrap" LabelWidth="40px" meta:resourcekey="TxtFoliosDispResource1" Resize="None">
                                                                        </telerik:RadTextBox>


                                                                    </td>
                                                                    <td style="width:40%; vertical-align:central;text-align:center" colspan="2">


                                                                        <telerik:RadDateTimePicker ID="RdtpInicio" Runat="server" Enabled="False" Width="350px" Skin="Bootstrap" Culture="en-US" meta:resourcekey="RdtpInicioResource1" >
                                                                            <TimeView CellSpacing="-1" Culture="es-MX"></TimeView>

                                                                            <TimePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></TimePopupButton>

                                                                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" Skin="Bootstrap"></Calendar>

                                                                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Width="">
                                                                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                                                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                                                            <FocusedStyle Resize="None"></FocusedStyle>

                                                                            <DisabledStyle Resize="None"></DisabledStyle>

                                                                            <InvalidStyle Resize="None"></InvalidStyle>

                                                                            <HoveredStyle Resize="None"></HoveredStyle>

                                                                            <EnabledStyle Resize="None"></EnabledStyle>
                                                                            </DateInput>

                                                                            <DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                                                                        </telerik:RadDateTimePicker>


                                                                    </td>
                                                                    <td style="width:40%;text-align:center;vertical-align:central ">


                                                                        <telerik:RadDateTimePicker ID="RdtpFin" Runat="server" Enabled="False" Width="350px" ZIndex="9000" Skin="Bootstrap" Culture="en-US" meta:resourcekey="RdtpFinResource1">
<TimeView CellSpacing="-1" Culture="es-MX"></TimeView>

<TimePopupButton CssClass="rcTimePopup rcDisabled" ImageUrl="" HoverImageUrl=""></TimePopupButton>

<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" Skin="Bootstrap"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Width="">
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
</DateInput>

<DatePopupButton CssClass="rcCalPopup rcDisabled" ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                                        </telerik:RadDateTimePicker>


                                                                    </td>


                                                                  </tr>

                                                                    <tr style="padding-left:10px;">
                                                                    <td style="width:10%; text-align:left;padding-left:20px; background-color:#afbbff">


                                                                        <asp:Label ID="Label5" runat="server" Text="Dias de Aplicacíon: " Font-Bold="True" meta:resourcekey="Label5Resource1"></asp:Label>


                                                                        </td>
                                                                    <td style="width:10%; background-color:#afbbff">


                                                                        <telerik:RadTextBox ID="TxtDiasAp" Runat="server" Enabled="False" Width="100px" Skin="Bootstrap" LabelWidth="40px" meta:resourcekey="TxtDiasApResource1" Resize="None">
                                                                        </telerik:RadTextBox>


                                                                        </td>
                                                                    <td style="width:40%;text-align:center" colspan="2">


                                                                        &nbsp;</td>
                                                                    <td style="width:40%">


                                                                        &nbsp;</td>


                                                                  </tr>

                                                                    <tr style="padding-left:10px;">
                                                                    <td style="text-align:center;padding-left:20px" colspan="5">


                                                                        <asp:Label ID="Label6" runat="server" Text="Distribución de participantes" Font-Bold="True" Font-Size="Medium" meta:resourcekey="Label6Resource1"></asp:Label>


                                                                        </td>


                                                                  </tr>

                                                                    <tr style="padding-left:10px">
                                                                    <td style="text-align:center;padding:20px" colspan="3">
                                                                        <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Bootstrap" GroupPanelPosition="Top" meta:resourcekey="RadGrid1Resource1" >
                                                                            <ClientSettings>
                                                                                <Scrolling AllowScroll="True" UseStaticHeaders="true"  />
                                                                            </ClientSettings>
                                                                        </telerik:RadGrid>

                                                                    </td>


                                                                    <td style="text-align:center;padding:20px;width:30%">


                                                                        <telerik:RadHtmlChart ID="Chart1" runat="server" BackColor="White" Skin="Bootstrap" meta:resourcekey="Chart1Resource1">
                                                                        </telerik:RadHtmlChart>
                                                                        </td>


                                                                    <td style="text-align:center;padding:20px;width:30%">

                                                                        <telerik:RadHtmlChart ID="Chart2" runat="server" BackColor="White" Skin="Bootstrap" meta:resourcekey="Chart2Resource1">
                                                                        </telerik:RadHtmlChart>
                                                                    
                                                                    </td>


                                                                  </tr>

                                                                </table>    

                                                            </td>
                                                          </tr>
                   
                   
                   
                    
                  
                   
                                                    </table>
                                                </td>     
                                           
                                        </tr>

                                     
                                  </table>
                            </td>
                        </tr>

                     

                      </table>
            
                              <tr>
                                      <td align="center" colspan="3" style="height:20px;">
                                        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                                        </telerik:RadScriptManager>
                                      </td>
                              </tr>

                              <tr>
                                      <td>
                                          <uc1:Foot ID="Foot1" runat="server" />
                                      </td>
                              </tr>
    

    </form>
</body>
</html>

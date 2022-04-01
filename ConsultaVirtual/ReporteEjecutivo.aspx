<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReporteEjecutivo.aspx.vb" Inherits="ConsultaVirtual.ReporteEjecutivo" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Charting" tagprefix="telerik" %>
<meta http-equiv="X-UA-Compatible" content="IE=Edge" />


<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=9.1.15.624, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reporte Ejecutivo</title>
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
    <form id="form1" runat="server">
      <table cellpadding="0" cellspacing="0" class="style1">
          <tr>
              <td align="center">
                  <table cellpadding="0" cellspacing="0" class="style1">
                      <tr>
                          <td align="center" height="46" style="background-image: url('Imagenes/Background/MainItemBackground.gif'); background-repeat: repeat-x;">
                              <uc2:Head ID="Head1" runat="server" EnableTheming="True" 
                                  EnableViewState="False" />
                          </td>
                      </tr>
                      <tr>
                          <td align="center">
                                &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="center">
                                <table cellpadding="2" cellspacing="2" border="0"  class="style2"
                                    style="font-family: arial, Helvetica, sans-serif; font-size: small;" 
                                    width="100%">
                                    <tr>
                                        <td align="center" height="23" >
                                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                Font-Size="10pt" ForeColor="#990033" meta:resourcekey="LerrorResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" height="23" >
                                            <telerik:RadPanelBar ID="RadPanelBar1" runat="server" BorderWidth="0px" Width="95%" meta:resourcekey="RadPanelBar1Resource1">
                                                <Items>
                                                    <telerik:RadPanelItem PostBack="False" Text="Estructura Organizacional" meta:resourcekey="RadPanelItemResource1">
                                                        <ContentTemplate>
                                                            <table align="left" border="0" style="width:100%;">
                                                                <tr>
                                                                    <td align="left" width="14%">&nbsp;</td>
                                                                    <td align="left" width="14%">&nbsp;</td>
                                                                    <td align="left" width="14%">&nbsp;</td>
                                                                    <td align="left" width="14%">&nbsp;</td>
                                                                    <td align="left" width="14%">&nbsp;</td>
                                                                    <td align="left" width="14%">
                                                                        <asp:Label ID="LTipo" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#666666" meta:resourcekey="LTipoResource1" style="font-weight: 700" Text="Tipo de Operación:"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="15%">
                                                                        <telerik:RadComboBox ID="RcbTipoOperacion" Runat="server" meta:resourcekey="RcbTipoOperacionResource1">
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="14%">
                                                                        <asp:Label ID="LUnidad" runat="server" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="LUnidadResource1" style="font-weight: 700" Text="Unidad de Negocio"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="14%">
                                                                        <asp:Label ID="LAgrupado" runat="server" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="LAgrupadoResource1" style="font-weight: 700" Text="Agrupado Pais"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="14%">
                                                                        <asp:Label ID="LPais" runat="server" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="LPaisResource1" style="font-weight: 700" Text="Pais"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="14%">
                                                                        <asp:Label ID="LTerritorio" runat="server" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="LTerritorioResource1" style="font-weight: 700" Text="Territorio"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="14%">
                                                                        <asp:Label ID="LRegion" runat="server" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="LRegionResource1" style="font-weight: 700" Text="Región"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="14%">
                                                                        <asp:Label ID="LSubregion" runat="server" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="LSubregionResource1" style="font-weight: 700" Text="Subregión"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="15%">
                                                                        <asp:Label ID="LEmpresa" runat="server" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="LEmpresaResource1" style="font-weight: 700" Text="Centro de Trabajo"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" height="140px" valign="top" width="14%">
                                                                        <telerik:RadListBox ID="RUnidad" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RUnidadResource1" Width="98%">
                                                                            <ButtonSettings TransferButtons="All" />
                                                                        </telerik:RadListBox>
                                                                    </td>
                                                                    <td align="left" height="140px" valign="top" width="14%">
                                                                        <telerik:RadListBox ID="RRegionPaises" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RRegionPaisesResource1" Width="98%">
                                                                            <ButtonSettings TransferButtons="All" />
                                                                        </telerik:RadListBox>
                                                                    </td>
                                                                    <td align="left" height="140px" valign="top" width="14%">
                                                                        <telerik:RadListBox ID="RPaises" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RPaisesResource1" Width="98%">
                                                                            <ButtonSettings TransferButtons="All" />
                                                                        </telerik:RadListBox>
                                                                    </td>
                                                                    <td align="left" height="140px" valign="top" width="14%">
                                                                        <telerik:RadListBox ID="RTerritorios" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RRegionesResource1" Width="98%">
                                                                            <ButtonSettings TransferButtons="All" />
                                                                        </telerik:RadListBox>
                                                                    </td>
                                                                    <td align="left" height="140px" valign="top" width="14%">
                                                                        <telerik:RadListBox ID="RRegiones" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RRegionesResource1" Width="98%">
                                                                            <ButtonSettings TransferButtons="All" />
                                                                        </telerik:RadListBox>
                                                                    </td>
                                                                    <td align="left" height="140px" valign="top" width="14%">
                                                                        <telerik:RadListBox ID="RSubregiones" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RSubregionesResource1" Width="98%">
                                                                            <ButtonSettings TransferButtons="All" />
                                                                        </telerik:RadListBox>
                                                                    </td>
                                                                    <td align="left" height="140px" valign="top" width="15%">
                                                                        <telerik:RadListBox ID="RCentroDeTrabajo" runat="server" Height="100%" meta:resourcekey="RCentroDeTrabajoResource1" Width="98%" AutoPostBack="True">
                                                                            <ButtonSettings TransferButtons="All" />
                                                                        </telerik:RadListBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </telerik:RadPanelItem>
                                                    <telerik:RadPanelItem runat="server" Text="Reportes" meta:resourcekey="RadPanelItemResource2">
                                                        <ContentTemplate>
                                                            <table style="width:100%;">
                                                                <tr>
                                                                    <td align="left" height="140px" valign="top" width="20%">
                                                                        <telerik:RadListBox ID="RReporte" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RSistemaResource1" Width="98%">
                                                                            <ButtonSettings TransferButtons="All" />
                                                                        </telerik:RadListBox>
                                                                    </td>
                                                                    <td align="left" height="140px" valign="top" width="80%">
                                                                        <telerik:RadListBox ID="RSubreporte" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RPreguntaResource1" Width="98%">
                                                                            <ButtonSettings TransferButtons="All" />
                                                                        </telerik:RadListBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </telerik:RadPanelItem>
                                                </Items>
                                                <ExpandAnimation Type="Linear" />
                                            </telerik:RadPanelBar>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" height="23" >
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" height="23" >

                                            <telerik:ReportViewer ID="ReportViewer1" runat="server" Width="1200px" 
                                                    Height="600px" Visible="False"
                                                Font-Size="8pt" Font-Names="Verdana" meta:resourcekey="ReportViewer1Resource1" ReportBookID="" ></telerik:ReportViewer>
                                            <br />
                                            <telerik:RadGrid ID="RadGrid1" runat="server" Height="400px" 
                                                ShowFooter="True" Width="800px" ShowStatusBar="True" Visible="False" Culture="es-ES" meta:resourcekey="RadGrid1Resource1" GroupPanelPosition="Top" >
                                                <ExportSettings FileName="ReporteClima" 
                                                ExportOnlyData="True" HideStructureColumns="True">
                                                <Excel FileExtension="xlsx">
                                                </Excel>
                                                </ExportSettings>
                                                <ClientSettings>
                                                    <Selecting AllowRowSelect="True" />
                                                    <Scrolling AllowScroll="True" FrozenColumnsCount="3" UseStaticHeaders="True" />
                                                    <Resizing AllowColumnResize="True" />
                                                </ClientSettings>
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <CommandItemSettings AddNewRecordText="" ExportToExcelText="Exportar a Excel" ExportToWordText="Exportar a Word" RefreshText="" ShowAddNewRecordButton="False" ShowExportToExcelButton="True" ShowExportToWordButton="True" ShowRefreshButton="False" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="True" />
                                                </MasterTableView>
                                                <FooterStyle Font-Bold="True" />
                                            </telerik:RadGrid>
                                            <br />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
                                        </td>
                                    </tr>
                                    </table>
                          </td>
                      </tr>
                      <tr>
                          <td align="center">
                                &nbsp;</td>
                      </tr>
                      <tr>
                          <td>
                              <uc1:Foot ID="Foot1" runat="server" />
                          </td>
                      </tr>
                  </table>
              </td>
          </tr>
    </table>
    </form>
</body>
</html>

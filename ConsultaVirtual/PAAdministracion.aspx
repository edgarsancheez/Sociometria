<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PAAdministracion.aspx.vb" Inherits="ConsultaVirtual.PAAdministracion" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>





<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=9.1.15.624, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Planes de Accion</title>
    <link href="Clases/EstiloPagina.css" rel="stylesheet" type="text/css" />
 
     <script type="text/javascript">
       function refresh()
       {
           location.href=window.location;
       }
       
       function SetStatus(headObj) {
           var obj = document.getElementsByTagName("input");
           for (var i = 0; i < obj.length; i++) {
               if (obj[i].type.toLowerCase() == "checkbox" &&
                    obj[i].name.toLowerCase() != headObj.name.toLowerCase() &&
                    obj[i].disabled == false) {
                   if (headObj.checked)
                       obj[i].checked = true;
                   else
                       obj[i].checked = false;
               }
           }
           return true;
       }
      </script>
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
      <table cellpadding="0" cellspacing="0" class="style1" align="center">
          <tr>
              <td align="center">
                  <table cellpadding="0" cellspacing="0" class="style1">
                      <tr>
                          <td align="left" height="46px" 
                              style="background-position: center; background-image: url('Imagenes/Background/Banner.png'); background-repeat: no-repeat;" 
                              valign="bottom">
                              <uc2:Head ID="Head1" runat="server" EnableTheming="True" 
                                  EnableViewState="False" />
                          </td>
                      </tr>
                      <tr>
                          <td align="left" height="23" style="z-index: -1;">
                                                      &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="left" height="23" style="z-index: -1;">
                              <table cellpadding="0" cellspacing="0" class="style2" align="center">
                                  <tr>
                                      <td valign="top">
                                          <table cellpadding="2" cellspacing="2" border="0" 
                                              style="font-family: arial, Helvetica, sans-serif; font-size: small; width: 100%;">
                                              <tr>
                                                  <td width="100%" align="center">
                                                      <telerik:RadMenu ID="RadMenu1" Runat="server" 
                                                        Width="100%" Height="20px" meta:resourcekey="RadMenu1Resource1" style="top: 0px; left: 0px" >
                                                          <Items>
                                                              <telerik:RadMenuItem runat="server" Text="Visualizador" Value="6" meta:resourcekey="RadMenuItemResource2">
                                                              </telerik:RadMenuItem>
                                                              <telerik:RadMenuItem runat="server" Text="Plan de Acción" Value="0" meta:resourcekey="RadMenuItemResource3">
                                                              </telerik:RadMenuItem>
                                                              <telerik:RadMenuItem runat="server" Text="Objetivos" Value="1" meta:resourcekey="RadMenuItemResource4">
                                                              </telerik:RadMenuItem>
                                                              <telerik:RadMenuItem runat="server" Text="Iniciativas" Value="2" meta:resourcekey="RadMenuItemResource5" >
                                                              </telerik:RadMenuItem>
                                                              <telerik:RadMenuItem runat="server" Text="Acciones" Value="3" meta:resourcekey="RadMenuItemResource6">
                                                              </telerik:RadMenuItem>
                                                              <telerik:RadMenuItem runat="server" Text="Seguimiento" Value="5" meta:resourcekey="RadMenuItemResource7">
                                                              </telerik:RadMenuItem>
                                                          </Items>
                                                      </telerik:RadMenu>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td width="100%" align="center">
                                                      <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                          Font-Size="10pt" ForeColor="#990033" meta:resourcekey="LerrorResource1" ></asp:Label>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td width="100%" align="center" valign="top">
                                                                  <asp:Panel ID="Panel5" runat="server" meta:resourcekey="Panel5Resource1">
                                                                      <table style="width:100%;">
                                                                          <tr>
                                                                              <td width="20%" align="right">
                                                                                  &nbsp;</td>
                                                                              <td width="20%" align="left">
                                                                                  &nbsp;</td>
                                                                              <td align="left" width="20%">
                                                                                  &nbsp;</td>
                                                                              <td align="left" width="20%">
                                                                                  &nbsp;</td>
                                                                              <td align="left" width="20%">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="left" >
                                                                                  &nbsp;&nbsp;
                                                                                  <asp:Label ID="Label32" runat="server"  
                                                                                      style="font-weight: 700" Text="Unidad de Negocio" meta:resourcekey="Label32Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left" >
                                                                                  <telerik:RadComboBox ID="RCBUnidad" Runat="server" AutoPostBack="True" 
                                                                                      EmptyMessage="Sin datos que mostrar" Enabled="False" MarkFirstMatch="True" 
                                                                                      Width="90%" Culture="es-ES" meta:resourcekey="RCBUnidadResource1">
                                                                                  </telerik:RadComboBox>
                                                                              </td>
                                                                              <td align="left" >
                                                                                  &nbsp;</td>
                                                                              <td align="left" >
                                                                                  
                                                                                  <asp:Label ID="Label18" runat="server" Font-Size="10pt" meta:resourcekey="Label18Resource1" style="font-weight: 700" Text="Territorio"></asp:Label>
                                                                                  
                                                                              </td>
                                                                              <td align="left" >
                                                                                  
                                                                                  <telerik:RadComboBox ID="RCBTerritorio" Runat="server" AutoPostBack="True" Culture="es-ES" EmptyMessage="Sin datos que mostrar" Enabled="False" MarkFirstMatch="True" meta:resourcekey="RCBTerritorioResource1" Width="90%">
                                                                                  </telerik:RadComboBox>
                                                                                  
                                                                              </td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="left" >
                                                                                  &nbsp;&nbsp;
                                                                                  <asp:Label ID="Label34" runat="server" Font-Bold="True" 
                                                                                      Text="Agrupado por Paises" meta:resourcekey="Label34Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left" >
                                                                                  <telerik:RadComboBox ID="RCBAgrupadoPaises" Runat="server" AutoPostBack="True" 
                                                                                      EmptyMessage="Sin datos que mostrar" Enabled="False" MarkFirstMatch="True" 
                                                                                      Width="90%" Culture="es-ES" meta:resourcekey="RCBAgrupadoPaisesResource1">
                                                                                  </telerik:RadComboBox>
                                                                              </td>
                                                                              <td align="center" >
                                                                                  <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Esquema" Visible="False" meta:resourcekey="Label6Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left" >
                                                                                  <asp:Label ID="Label36" runat="server" Font-Size="10pt" meta:resourcekey="Label36Resource1" style="font-weight: 700" Text="Región / Zona"></asp:Label>
                                                                              </td>
                                                                              <td align="left" >
                                                                                  <telerik:RadComboBox ID="RCBRegion" Runat="server" AutoPostBack="True" Culture="es-ES" EmptyMessage="Sin datos que mostrar" Enabled="False" MarkFirstMatch="True" meta:resourcekey="RCBRegionResource1" Width="90%">
                                                                                  </telerik:RadComboBox>
                                                                              </td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="left" >
                                                                                  &nbsp;&nbsp;
                                                                                  <asp:Label ID="Label35" runat="server"  
                                                                                      style="font-weight: 700" Text="País" meta:resourcekey="Label35Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left" >
                                                                                  <telerik:RadComboBox ID="RCBPais" Runat="server" AutoPostBack="True" 
                                                                                      EmptyMessage="Sin datos que mostrar" Enabled="False" MarkFirstMatch="True" 
                                                                                      Width="90%" Culture="es-ES" meta:resourcekey="RCBPaisResource1">
                                                                                  </telerik:RadComboBox>
                                                                              </td>
                                                                              <td align="center" >
                                                                                  <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Visible="False" meta:resourcekey="RadioButtonList1Resource1" Font-Size="10pt">
                                                                                      <asp:ListItem Selected="True" Value="1" meta:resourcekey="ListItemResource1">Empleado</asp:ListItem>
                                                                                      <asp:ListItem Value="2" meta:resourcekey="ListItemResource2">Lider</asp:ListItem>
                                                                                  </asp:RadioButtonList>
                                                                              </td>
                                                                              <td align="left" >
                                                                                  <asp:Label ID="Label37" runat="server" Font-Size="10pt" meta:resourcekey="Label37Resource1" style="font-weight: 700" Text="Subregión"></asp:Label>
                                                                              </td>
                                                                              <td align="left" >
                                                                                  <telerik:RadComboBox ID="RCBSubRegion" Runat="server" AutoPostBack="True" Culture="es-ES" EmptyMessage="Sin datos que mostrar" Enabled="False" MarkFirstMatch="True" meta:resourcekey="RCBSubRegionResource1" Width="90%">
                                                                                  </telerik:RadComboBox>
                                                                              </td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right" >
                                                                                  &nbsp;</td>
                                                                              <td align="left" >
                                                                                  &nbsp;</td>
                                                                              <td align="center" >
                                                                                  <telerik:RadButton ID="BFiltrar" runat="server" Text="Filtrar" meta:resourcekey="BFiltrarResource1">
                                                                                      <Icon PrimaryIconLeft="4px" PrimaryIconTop="4px" PrimaryIconUrl="Imagenes/COManager/Search16.png" />
                                                                                  </telerik:RadButton>
                                                                              </td>
                                                                              <td align="left" >
                                                                                  &nbsp;</td>
                                                                              <td align="right" >
                                                                                  <asp:ImageButton ID="BtnRegresar" runat="server" ImageUrl="~/Imagenes/Background/backbutton.png" Visible="False" meta:resourcekey="BtnRegresarResource1" />
                                                                              </td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td colspan="5" >
                                                                                  <telerik:RadGrid ID="RGridVisualizacion" runat="server" AutoGenerateColumns="False" Culture="es-ES" Height="400px" Width="100%" meta:resourcekey="RGridVisualizacionResource1" AllowSorting="True" ShowFooter="True" GroupPanelPosition="Top">
                                                                                      <ExportSettings exportonlydata="True" filename="Reporte Plan de Accion" hidestructurecolumns="True">
                                                                                          <excel fileextension="xlsx" />
                                                                                      </ExportSettings>
                                                                                      <ClientSettings>
                                                                                        <Selecting AllowRowSelect="True" />
                                                                                        <Scrolling AllowScroll="True" />
                                                                                      </ClientSettings>
                                                                                      <mastertableview commanditemdisplay="Top">
                                                                                          <commanditemsettings showaddnewrecordbutton="False" showexporttoexcelbutton="True" showrefreshbutton="False" />
                                                                                          <Columns>
                                                                                              <telerik:GridBoundColumn AllowFiltering="False" FilterControlAltText="Filter NUM column" HeaderText="NUM" meta:resourceKey="GridBoundColumnResource7" UniqueName="NUM">
                                                                                                  <HeaderStyle Width="50px" />
                                                                                                  <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="CVEEMPRESA" Display="False" FilterControlAltText="Filter CVEEMPRESA column" HeaderText="CVEEMPRESA" meta:resourceKey="GridBoundColumnResource8" SortExpression="CVEEMPRESA" UniqueName="CVEEMPRESA">
                                                                                                  <HeaderStyle Width="0px" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" DataField="EMPRESA" FilterControlAltText="Filter EMPRESA column" FilterControlWidth="80%" HeaderText="EMPRESA" meta:resourceKey="GridBoundColumnResource9" ShowFilterIcon="False" SortExpression="EMPRESA" UniqueName="EMPRESA">
                                                                                                  <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="True" />
                                                                                                  <HeaderStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" Width="25%" Wrap="True" />
                                                                                                  <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" Wrap="True" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridDateTimeColumn DataField="APLICACION" DataFormatString="{0:d}" FilterControlAltText="Filter APLICACION column" FilterControlWidth="80%" HeaderText="APLICACION" meta:resourceKey="GridDateTimeColumnResource1" SortExpression="APLICACION" UniqueName="APLICACION">
                                                                                                  <HeaderStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="10%" Wrap="True" />
                                                                                                  <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                                                              </telerik:GridDateTimeColumn>
                                                                                              <telerik:GridDateTimeColumn DataField="ULTIMAMODIFICACION" DataFormatString="{0:d}" FilterControlAltText="Filter ULTIMAMODIFICACION column" FilterControlWidth="80%" HeaderText="ULTIMA MODIFICACION" meta:resourceKey="GridDateTimeColumnResource2" SortExpression="ULTIMAMODIFICACION" UniqueName="ULTIMAMODIFICACION">
                                                                                                  <HeaderStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="10%" Wrap="True" />
                                                                                                  <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                                                              </telerik:GridDateTimeColumn>
                                                                                              <telerik:GridBoundColumn DataField="CVEPLAN" Display="False" FilterControlAltText="Filter CVEPLAN column" HeaderText="CVEPLAN" meta:resourceKey="GridBoundColumnResource10" SortExpression="CVEPLAN" UniqueName="CVEPLAN">
                                                                                                  <HeaderStyle Width="0px" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" DataField="PLANACCION" FilterControlAltText="Filter PLANACCION column" FilterControlWidth="80%" HeaderText="PLAN DE ACCION" meta:resourceKey="GridBoundColumnResource11" ShowFilterIcon="False" SortExpression="PLANACCION" UniqueName="PLANACCION">
                                                                                                  <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="True" />
                                                                                                  <HeaderStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" Width="25%" Wrap="True" />
                                                                                                  <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" Wrap="True" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" DataField="AVANCE" DataFormatString="{0:F1}%" FilterControlAltText="Filter AVANCE column" FilterControlWidth="80%" HeaderText="AVANCE" meta:resourceKey="GridBoundColumnResource27" ShowFilterIcon="False" SortExpression="AVANCE" UniqueName="AVANCE">
                                                                                                  <HeaderStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="5%" Wrap="True" />
                                                                                                  <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="PADRE" Display="False" FilterControlAltText="Filter PADRE column" HeaderText="PADRE" meta:resourceKey="GridBoundColumnResource12" UniqueName="PADRE">
                                                                                                  <HeaderStyle Width="0px" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridButtonColumn CommandName="Detalles" FilterControlAltText="Filter Detalles column" HeaderText="DETALLES" meta:resourceKey="GridButtonColumnResource3" Text="Detalles" UniqueName="Detalles">
                                                                                                  <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                                                                  <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                                                              </telerik:GridButtonColumn>
                                                                                              <telerik:GridButtonColumn CommandName="Preguntas" FilterControlAltText="Filter Preguntas column" HeaderText="PREGUNTAS" meta:resourceKey="GridButtonColumnResource4" Text="Preguntas" UniqueName="Preguntas">
                                                                                                  <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                                                                  <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                                                              </telerik:GridButtonColumn>
                                                                                          </Columns>
                                                                                          <HeaderStyle Font-Bold="True" />
                                                                                          <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="True" />
                                                                                          <commanditemtemplate>
                                                                                              <table style="width:100%;">
                                                                                                  <tr>
                                                                                                      <td align="left" width="97%">
                                                                                                          <asp:Label ID="Label33" runat="server" meta:resourceKey="Label33Resource1" style="font-weight: 700" Text="Tipo de Operación"></asp:Label>
                                                                                                          &nbsp;<telerik:RadComboBox ID="RcboTipoOperacion" runat="server" AppendDataBoundItems="True" AutoPostBack="True" EmptyMessage="Sin información disponible" Enabled="False" EnableVirtualScrolling="True" Filter="Contains" Height="100px" ItemsPerRequest="10" MarkFirstMatch="True" meta:resourcekey="RcboTipoOperacionResource1" MinFilterLength="4" OnSelectedIndexChanged="RcboTipoOperacion_SelectedIndexChanged" Width="20%">
                                                                                                          </telerik:RadComboBox>
                                                                                                      </td>
                                                                                                      <td align="right" width="3%">
                                                                                                          <asp:ImageButton ID="LkExcel" runat="server" ImageUrl="~/Imagenes/Estatus/page_excel.png" meta:resourcekey="LkExcelResource1" OnClick="Exportar" />
                                                                                                      </td>
                                                                                                  </tr>
                                                                                              </table>
                                                                                          </commanditemtemplate>
                                                                                      </mastertableview>
                                                                                  </telerik:RadGrid>
                                                                                  <telerik:RadGrid ID="RGridPreguntas" runat="server" AutoGenerateColumns="False" Height="400px" Visible="False" Width="100%" Culture="es-ES" meta:resourcekey="RGridPreguntasResource1" GroupPanelPosition="Top">
                                                                                      <exportsettings exportonlydata="True" filename="Reporte Plan de Accion" hidestructurecolumns="True">
                                                                                          <excel fileextension="xlsx" />
                                                                                      </exportsettings>
                                                                                      <clientsettings>
                                                                                          <scrolling allowscroll="True" usestaticheaders="True" />
                                                                                      </clientsettings>
                                                                                      <mastertableview commanditemdisplay="Top" Width="99%">
                                                                                          <commanditemsettings showaddnewrecordbutton="False" showexporttoexcelbutton="True" showrefreshbutton="False" />
                                                                                          <Columns>
                                                                                              <telerik:GridBoundColumn DataField="CveTema" FilterControlAltText="Filter CveTema column" HeaderText="CveTema" UniqueName="CveTema" meta:resourcekey="GridBoundColumnResource13">
                                                                                                  <HeaderStyle Width="50px" />
                                                                                                  <ItemStyle HorizontalAlign="Center" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="Tema" FilterControlAltText="Filter Tema column" HeaderText="Tema" UniqueName="Tema" meta:resourcekey="GridBoundColumnResource14">
                                                                                                  <HeaderStyle Width="10%" />
                                                                                                  <ItemStyle HorizontalAlign="Left" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="Cve" FilterControlAltText="Filter Cve column" HeaderText="Cve" UniqueName="Cve" meta:resourcekey="GridBoundColumnResource15">
                                                                                                  <HeaderStyle Width="5%" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="Pregunta" FilterControlAltText="Filter Pregunta column" HeaderText="Pregunta" UniqueName="Pregunta" meta:resourcekey="GridBoundColumnResource16">
                                                                                                  <HeaderStyle Width="40%" />
                                                                                                  <ItemStyle HorizontalAlign="Left" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="Cuadrante Compromiso" FilterControlAltText="Filter CuadranteCompromiso column" HeaderText="Cuadrante Compromiso" UniqueName="CuadranteCompromiso" meta:resourcekey="GridBoundColumnResource17">
                                                                                                  <HeaderStyle Width="7%" />
                                                                                                  <ItemStyle HorizontalAlign="Center" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="Cuadrante Soporte" FilterControlAltText="Filter CuadranteSoporte column" HeaderText="Cuadrante Soporte" UniqueName="CuadranteSoporte" meta:resourcekey="GridBoundColumnResource18">
                                                                                                  <HeaderStyle Width="7%" />
                                                                                                  <ItemStyle HorizontalAlign="Center" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="Iniciativas" FilterControlAltText="Filter Iniciativas column" HeaderText="Iniciativas" UniqueName="Iniciativas" meta:resourcekey="GridBoundColumnResource19">
                                                                                                  <HeaderStyle Width="25%" />
                                                                                                  <ItemStyle HorizontalAlign="Left" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridTemplateColumn FilterControlAltText="Filter Combo column" HeaderText="Combo" UniqueName="Combo" Visible="False" meta:resourcekey="GridTemplateColumnResource5">
                                                                                                  <ItemTemplate>
                                                                                                      <telerik:RadComboBox ID="RCBIniPreg" Runat="server" Width="100%" Culture="es-ES" meta:resourcekey="RCBIniPregResource1">
                                                                                                      </telerik:RadComboBox>
                                                                                                  </ItemTemplate>
                                                                                              </telerik:GridTemplateColumn>
                                                                                          </Columns>
                                                                                          <HeaderStyle Font-Bold="True" />
                                                                                      </mastertableview>
                                                                                  </telerik:RadGrid>
                                                                                  <telerik:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="800px" 
                                                                                      Visible="False" Width="100%" meta:resourcekey="ReportViewer1Resource1">
                                                                                      
                                                                                     
                                                                                 </telerik:ReportViewer>
                                                                              </td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td colspan="5">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                      </table>
                                                                  </asp:Panel>
                                                      
                                                                  <asp:Panel ID="Panel0" runat="server" Visible="False" meta:resourcekey="Panel0Resource1">
                                                                      <table style="width:100%;" 
                                                                        style="font-family: arial, Helvetica, sans-serif; font-size: small;" >
                                                                          <tr>
                                                                              <td width="10%" align="left">
                                                                                  <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Estatus/Circle_Red.png" ToolTip="Toma como base el reporte de prioridades que identifica las áreas de oportunidad para generar tus Objetivos. " meta:resourcekey="Image1Resource1" />
                                                                              </td>
                                                                              <td width="25%">
                                                                                  &nbsp;</td>
                                                                              <td width="25%">
                                                                                  &nbsp;</td>
                                                                              <td width="40%" align="right">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">
                                                                                  <telerik:RadButton ID="BVerReporte" runat="server" Text="Ver Reporte de Prioridades" meta:resourcekey="BVerReporteResource1">
                                                                                  </telerik:RadButton>
                                                                              </td>
                                                                              <td align="left" rowspan="12">
                                                                                  <telerik:RadGrid ID="RGridEmpresas" runat="server" Height="300px" Width="99%" Culture="es-ES" meta:resourcekey="RGridEmpresasResource1" GroupPanelPosition="Top">
                                                                                      <exportsettings exportonlydata="True" filename="Reporte Plan de Accion" hidestructurecolumns="True">
                                                                                          <excel fileextension="xlsx" />
                                                                                      </exportsettings>
                                                                                      <clientsettings>
                                                                                          <scrolling allowscroll="True" usestaticheaders="True" />
                                                                                      </clientsettings>
                                                                                      <mastertableview commanditemdisplay="Top">
                                                                                          <commanditemsettings showaddnewrecordbutton="False" showexporttoexcelbutton="True" showrefreshbutton="False" />
                                                                                          <Columns>
                                                                                              <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" meta:resourcekey="GridTemplateColumnResource6" UniqueName="TemplateColumn">
                                                                                                  <HeaderTemplate>
                                                                                                      <asp:CheckBox ID="CheckHead" runat="server" meta:resourcekey="CheckHeadResource1" onclick="SetStatus(this);" />
                                                                                                  </HeaderTemplate>
                                                                                                  <ItemTemplate>
                                                                                                      <asp:CheckBox ID="Check" runat="server" meta:resourcekey="CheckResource1" />
                                                                                                  </ItemTemplate>
                                                                                                  <HeaderStyle Width="5%" />
                                                                                                  <ItemStyle Width="5%" />
                                                                                              </telerik:GridTemplateColumn>
                                                                                          </Columns>
                                                                                          <HeaderStyle Font-Bold="True" />
                                                                                      </mastertableview>
                                                                                  </telerik:RadGrid>
                                                                              </td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label26" runat="server" style="font-weight: 700" Text="Plan de Acción" meta:resourcekey="Label26Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left" colspan="2">
                                                                                  <telerik:RadTextBox ID="RTPlan" Runat="server" Width="80%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTPlanResource1" Resize="None">
                                                                                      <EmptyMessageStyle Resize="None" />
                                                                                      <ReadOnlyStyle Resize="None" />
                                                                                      <FocusedStyle Resize="None" />
                                                                                      <DisabledStyle Resize="None" />
                                                                                      <InvalidStyle Resize="None" />
                                                                                      <HoveredStyle Resize="None" />
                                                                                      <EnabledStyle Resize="None" />
                                                                                  </telerik:RadTextBox>
                                                                                  <asp:Label ID="LPA" runat="server" Visible="False" meta:resourcekey="LPAResource1"></asp:Label>
                                                                              </td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">&nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="center" colspan="4">
                                                                                  <telerik:RadButton ID="BGuardarPA" runat="server" Text="Guardar" meta:resourcekey="BGuardarPAResource1">
                                                                                      <Icon PrimaryIconLeft="4px" PrimaryIconTop="4px" PrimaryIconUrl="Imagenes/COManager/Save16.png" />
                                                                                  </telerik:RadButton>
                                                                              </td>
                                                                          </tr>
                                                                      </table>
                                                                  </asp:Panel>
                                                      
                                                                  <asp:Panel ID="Panel1" runat="server" Visible="False" meta:resourcekey="Panel1Resource1">
                                                                      <table style="width:100%;" 
                                                                        style="font-family: arial, Helvetica, sans-serif; font-size: small;" >
                                                                          <tr>
                                                                              <td width="25%" align="left">
                                                                                  <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Estatus/Circle_Grey.png" ToolTip="Una vez que analizaste el reporte de prioridades, es necesario que definas entre 3 y 4 grandes objetivos que abarquen las áreas de oportunidad previamente identificadas. " meta:resourcekey="Image2Resource1" />
                                                                              </td>
                                                                              <td width="60%">
                                                                                  &nbsp;</td>
                                                                              <td width="15%" align="right">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label27" runat="server" 
                                                                                      style="font-weight: 700" Text="Plan de Acción" meta:resourcekey="Label27Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadComboBox ID="RCBPlanO" Runat="server" AutoPostBack="True" 
                                                                                      Width="80%" Culture="es-ES" meta:resourcekey="RCBPlanOResource1">
                                                                                  </telerik:RadComboBox>
                                                                              </td>
                                                                              <td align="left">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label10" runat="server"  
                                                                                      style="font-weight: 700" Text="Objetivo" meta:resourcekey="Label10Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadTextBox ID="RTObjetivo" Runat="server" Width="80%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTObjetivoResource1" Resize="None">
                                                                                      <EmptyMessageStyle Resize="None" />
                                                                                      <ReadOnlyStyle Resize="None" />
                                                                                      <FocusedStyle Resize="None" />
                                                                                      <DisabledStyle Resize="None" />
                                                                                      <InvalidStyle Resize="None" />
                                                                                      <HoveredStyle Resize="None" />
                                                                                      <EnabledStyle Resize="None" />
                                                                                  </telerik:RadTextBox>
                                                                                  <asp:Label ID="LO" runat="server" Visible="False" meta:resourcekey="LOResource1"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  &nbsp;</td>
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
                                                                                  <telerik:RadButton ID="BGuardarO" runat="server" Text="Guardar" meta:resourcekey="BGuardarOResource1">
                                                                                      <Icon PrimaryIconLeft="4px" PrimaryIconTop="4px" 
                                                                                          PrimaryIconUrl="Imagenes/COManager/Save16.png" />
                                                                                  </telerik:RadButton>
                                                                              </td>
                                                                          </tr>
                                                                      </table>
                                                                  </asp:Panel>
                                                                  <asp:Panel ID="Panel2" runat="server" Visible="False" meta:resourcekey="Panel2Resource1">
                                                                      <table style="width:100%;" 
                                                                        style="font-family: arial, Helvetica, sans-serif; font-size: small;" >
                                                                          <tr>
                                                                              <td width="15%" align="left">
                                                                                  <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/Estatus/Circle_Yellow.png" ToolTip="Dentro de cada uno de tus objetivos, debes establecer de 2 a 3 iniciativas encaminadas  a atacar las áreas de oportunidad detectadas. Para asegurar el correcto cumplimiento de los planes de acción, es necesario designar responsables para cada una de las iniciativas." meta:resourcekey="Image5Resource1" />
                                                                              </td>
                                                                              <td width="30%">
                                                                                  &nbsp;</td>
                                                                              <td width="15%" align="right">
                                                                                  &nbsp;</td>
                                                                              <td width="30%">
                                                                                  &nbsp;</td>
                                                                              <td width="10%" align="right">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" style="background-color: #4D78D2">
                                                                                  <asp:Label ID="Label57" runat="server" ForeColor="White" style="font-weight: 700" Text="DEFINICION" meta:resourcekey="Label57Resource1"></asp:Label>
                                                                              </td>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" style="background-color: #4D78D2">
                                                                                  <asp:Label ID="Label59" runat="server" ForeColor="White" style="font-weight: 700" Text="ACTORES" meta:resourcekey="Label59Resource1"></asp:Label>
                                                                              </td>
                                                                              <td align="left">&nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label28" runat="server" style="font-weight: 700" Text="Plan de Acción" meta:resourcekey="Label28Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadComboBox ID="RCBPlanI" Runat="server" AutoPostBack="True" Width="80%" Culture="es-ES" meta:resourcekey="RCBPlanIResource1">
                                                                                  </telerik:RadComboBox>
                                                                              </td>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label20" runat="server" style="font-weight: 700" Text="Responsable" meta:resourcekey="Label20Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadTextBox ID="RTResponsable" Runat="server" Width="80%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTResponsableResource1" Resize="None">
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
                                                                                  <asp:Label ID="Label1" runat="server" 
                                                                                      style="font-weight: 700" Text="Objetivo" meta:resourcekey="Label1Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadComboBox ID="RCBObjetivoI" Runat="server" Width="80%" Culture="es-ES" meta:resourcekey="RCBObjetivoIResource1">
                                                                                  </telerik:RadComboBox>
                                                                                  &nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label2" runat="server" Text="Iniciativa" 
                                                                                    style="font-weight: 700" meta:resourcekey="Label2Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadTextBox ID="RTIniciativa" Runat="server" Width="80%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTIniciativaResource1" Resize="None">
                                                                                      <EmptyMessageStyle Resize="None" />
                                                                                      <ReadOnlyStyle Resize="None" />
                                                                                      <FocusedStyle Resize="None" />
                                                                                      <DisabledStyle Resize="None" />
                                                                                      <InvalidStyle Resize="None" />
                                                                                      <HoveredStyle Resize="None" />
                                                                                      <EnabledStyle Resize="None" />
                                                                                  </telerik:RadTextBox>
                                                                                  <asp:Label ID="LI" runat="server" Visible="False" meta:resourcekey="LIResource1"></asp:Label>
                                                                              </td>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label17" runat="server" style="font-weight: 700" Text="Evaluador:" meta:resourcekey="Label17Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">&nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left">
                                                                                  &nbsp;</td>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label14" runat="server" style="font-weight: 700" Text="Nombre" meta:resourcekey="Label14Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadComboBox ID="RCBNombre" Runat="server" AutoPostBack="True" DataValueField="-1" EmptyMessage="Seleccione" EnableLoadOnDemand="True" EnableVirtualScrolling="True" Filter="Contains" Height="100px" ItemsPerRequest="10" MinFilterLength="5" ShowMoreResultsBox="True" ShowToggleImage="False" Width="80%" Culture="es-ES" meta:resourcekey="RCBNombreResource1">
                                                                                  </telerik:RadComboBox>
                                                                              </td>
                                                                              <td align="left">&nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" style="background-color: #4D78D2">
                                                                                  <asp:Label ID="Label58" runat="server" ForeColor="White" style="font-weight: 700" Text="MEDICION" meta:resourcekey="Label58Resource1"></asp:Label>
                                                                              </td>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label15" runat="server" style="font-weight: 700" Text="Correo" meta:resourcekey="Label15Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadTextBox ID="RTCorreo" Runat="server" Width="80%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTCorreoResource1" Resize="None">
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
                                                                                  <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Indicador" meta:resourcekey="Label3Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadComboBox ID="RCBIndicador" Runat="server" Width="80%" Culture="es-ES" meta:resourcekey="RCBIndicadorResource1">
                                                                                      <Items>
                                                                                          <telerik:RadComboBoxItem runat="server" Text="[Seleccionar]" Value="-1" meta:resourcekey="RadComboBoxItemResource1" />
                                                                                          <telerik:RadComboBoxItem runat="server" Text="Evaluación" Value="Evaluación" meta:resourcekey="RadComboBoxItemResource2" />
                                                                                          <telerik:RadComboBoxItem runat="server" Text="Indice" Value="Indice" meta:resourcekey="RadComboBoxItemResource3" />
                                                                                          <telerik:RadComboBoxItem runat="server" Text="Porcentaje" Value="Porcentaje" meta:resourcekey="RadComboBoxItemResource4" />
                                                                                          <telerik:RadComboBoxItem runat="server" Text="Número" Value="Número" meta:resourcekey="RadComboBoxItemResource5" />
                                                                                      </Items>
                                                                                  </telerik:RadComboBox>
                                                                              </td>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label16" runat="server" style="font-weight: 700" Text="Puesto" meta:resourcekey="Label16Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadTextBox ID="RTPuesto" Runat="server" Width="80%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTPuestoResource1" Resize="None">
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
                                                                                  <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Fuente" meta:resourcekey="Label4Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadTextBox ID="RTFuente" Runat="server" Width="80%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTFuenteResource1" Resize="None">
                                                                                      <EmptyMessageStyle Resize="None" />
                                                                                      <ReadOnlyStyle Resize="None" />
                                                                                      <FocusedStyle Resize="None" />
                                                                                      <DisabledStyle Resize="None" />
                                                                                      <InvalidStyle Resize="None" />
                                                                                      <HoveredStyle Resize="None" />
                                                                                      <EnabledStyle Resize="None" />
                                                                                  </telerik:RadTextBox>
                                                                              </td>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label56" runat="server" style="font-weight: 700" Text="Producto Final" meta:resourcekey="Label56Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadTextBox ID="RTProductoFinal" Runat="server" Width="80%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTProductoFinalResource1" Resize="None">
                                                                                      <EmptyMessageStyle Resize="None" />
                                                                                      <ReadOnlyStyle Resize="None" />
                                                                                      <FocusedStyle Resize="None" />
                                                                                      <DisabledStyle Resize="None" />
                                                                                      <InvalidStyle Resize="None" />
                                                                                      <HoveredStyle Resize="None" />
                                                                                      <EnabledStyle Resize="None" />
                                                                                  </telerik:RadTextBox>
                                                                              </td>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label11" runat="server" style="font-weight: 700" Text="Fecha Inicio" meta:resourcekey="Label11Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadDatePicker ID="RDPFI" Runat="server" Culture="en-US" meta:resourcekey="RDPFIResource1">
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
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label12" runat="server" style="font-weight: 700" Text="Fecha Fin" meta:resourcekey="Label12Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  <telerik:RadDatePicker ID="RDPFF" Runat="server" Culture="en-US" meta:resourcekey="RDPFFResource1">
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
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left">
                                                                                  &nbsp;</td>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                              <td align="left">&nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="center" colspan="5">
                                                                                  <telerik:RadButton ID="BGuardarI" runat="server" Text="Guardar" meta:resourcekey="BGuardarIResource1">
                                                                                      <icon primaryiconleft="4px" primaryicontop="4px" 
                                                                                          primaryiconurl="Imagenes/COManager/Save16.png" />
                                                                                  </telerik:RadButton>
                                                                              </td>
                                                                          </tr>
                                                                      </table>
                                                                  </asp:Panel>
                                                                  <asp:Panel ID="Panel3" runat="server" Visible="False" meta:resourcekey="Panel3Resource1">
                                                                      <table style="width:100%;" 
                                                                              style="font-family: arial, Helvetica, sans-serif; font-size: small;">
                                                                          <tr>
                                                                              <td width="25%" align="left">
                                                                                  <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Estatus/Circle_Green.png" ToolTip="Nuestras iniciativas deben contener una serie de acciones los cuales son actividades enfocadas a cumplir las iniciativas señaladas. " meta:resourcekey="Image3Resource1" />
                                                                              </td>
                                                                              <td width="30%">
                                                                                  &nbsp;</td>
                                                                              <td width="30%">
                                                                                  &nbsp;</td>
                                                                              <td width="15%" align="right">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label29" runat="server" 
                                                                                      style="font-weight: 700" Text="Plan de Acción" meta:resourcekey="Label29Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left" colspan="2">
                                                                                  <telerik:RadComboBox ID="RCBPlanA" Runat="server" AutoPostBack="True" 
                                                                                      Width="80%" Culture="es-ES" meta:resourcekey="RCBPlanAResource1">
                                                                                  </telerik:RadComboBox>
                                                                              </td>
                                                                              <td align="left">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label13" runat="server"
                                                                                      style="font-weight: 700" Text="Objetivo" meta:resourcekey="Label13Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left" colspan="2">
                                                                                  <telerik:RadComboBox ID="RCBObjetivoA" Runat="server" AutoPostBack="True" 
                                                                                      Width="80%" Culture="es-ES" meta:resourcekey="RCBObjetivoAResource1">
                                                                                  </telerik:RadComboBox>
                                                                              </td>
                                                                              <td align="left">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label5" runat="server" 
                                                                                      style="font-weight: 700" Text="Iniciativa" meta:resourcekey="Label5Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left" colspan="2">
                                                                                  <telerik:RadComboBox ID="RCBIniciativaA" Runat="server" Width="80%" Culture="es-ES" meta:resourcekey="RCBIniciativaAResource1">
                                                                                  </telerik:RadComboBox>
                                                                                  &nbsp;</td>
                                                                              <td align="left">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  <asp:Label ID="Label7" runat="server" 
                                                                                          style="font-weight: 700" Text="Accion" meta:resourcekey="Label7Resource1" Font-Size="10pt"></asp:Label>
                                                                              </td>
                                                                              <td align="left" colspan="2">
                                                                                  <telerik:RadTextBox ID="RTAccion" Runat="server" Width="80%" LabelCssClass="" LabelWidth="64px" meta:resourcekey="RTAccionResource1" Resize="None">
                                                                                      <EmptyMessageStyle Resize="None" />
                                                                                      <ReadOnlyStyle Resize="None" />
                                                                                      <FocusedStyle Resize="None" />
                                                                                      <DisabledStyle Resize="None" />
                                                                                      <InvalidStyle Resize="None" />
                                                                                      <HoveredStyle Resize="None" />
                                                                                      <EnabledStyle Resize="None" />
                                                                                  </telerik:RadTextBox>
                                                                                  <asp:Label ID="LA" runat="server" Visible="False" meta:resourcekey="LAResource1"></asp:Label>
                                                                              </td>
                                                                              <td align="left">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="right">
                                                                                  &nbsp;</td>
                                                                              <td align="left" colspan="2">
                                                                                  &nbsp;</td>
                                                                              <td align="left">
                                                                                  &nbsp;</td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="center" colspan="4">
                                                                                  <telerik:RadButton ID="BGuardarA" runat="server" Text="Guardar" meta:resourcekey="BGuardarAResource1">
                                                                                      <icon primaryiconleft="4px" primaryicontop="4px" 
                                                                                          primaryiconurl="Imagenes/COManager/Save16.png" />
                                                                                  </telerik:RadButton>
                                                                              </td>
                                                                          </tr>
                                                                      </table>
                                                                  </asp:Panel>
                                                                  <asp:Panel ID="Panel4" runat="server" Visible="False" meta:resourcekey="Panel4Resource1">
                                                                  <table style="width:100%;" 
                                                                        style="font-family: arial, Helvetica, sans-serif; font-size: small;" >
                                                                          <tr>
                                                                              <td align="left">
                                                                                  <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Estatus/Circle_Orange.png" ToolTip="Mediante el Módulo de Seguimiento podrás administrar, gestionar y monitorear el día a día de las actividades necesarias para cumplir con las iniciativas mismas que comprenden un gran objetivo." meta:resourcekey="Image4Resource1" />
                                                                              </td>
                                                                          </tr>
                                                                          <tr>
                                                                              <td align="center">
                                                                                  <telerik:RadGrid ID="RGridSeguimiento" runat="server" AutoGenerateColumns="False" Culture="es-ES" Height="400px" Visible="False" Width="100%" meta:resourcekey="RGridSeguimientoResource1" GroupPanelPosition="Top">
                                                                                      <ExportSettings ExportOnlyData="True" Filename="Reporte Plan de Accion" HideStructureColumns="True">
                                                                                          <Excel FileExtension="xlsx" />
                                                                                      </ExportSettings>
                                                                                      <ClientSettings>
                                                                                          <Scrolling AllowScroll="True" />
                                                                                      </ClientSettings>
                                                                                      <mastertableview commanditemdisplay="Top">
                                                                                          <commanditemsettings showaddnewrecordbutton="False" showexporttoexcelbutton="True" showrefreshbutton="False" />
                                                                                          <Columns>
                                                                                              <telerik:GridBoundColumn DataField="CvePlan" Display="False" FilterControlAltText="Filter CvePlan column" HeaderText="CvePlan" meta:resourceKey="GridBoundColumnResource1" UniqueName="CvePlan">
                                                                                                  <HeaderStyle Width="0px" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="PlanAccion" FilterControlAltText="Filter PlanAccion column" HeaderText="PlanAccion" meta:resourceKey="GridBoundColumnResource2" UniqueName="PlanAccion">
                                                                                                  <HeaderStyle HorizontalAlign="Center" Width="16%" />
                                                                                                  <ItemStyle HorizontalAlign="Left" Width="16%" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="CveObjetivo" Display="False" FilterControlAltText="Filter CveObjetivo column" HeaderText="CveObjetivo" meta:resourceKey="GridBoundColumnResource3" UniqueName="CveObjetivo">
                                                                                                  <HeaderStyle Width="0px" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="Objetivo" FilterControlAltText="Filter Objetivo column" HeaderText="Objetivo" meta:resourceKey="GridBoundColumnResource4" UniqueName="Objetivo">
                                                                                                  <HeaderStyle HorizontalAlign="Center" Width="16%" />
                                                                                                  <ItemStyle HorizontalAlign="Left" Width="16%" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="CveIniciativa" Display="False" FilterControlAltText="Filter CveIniciativa column" HeaderText="CveIniciativa" meta:resourceKey="GridBoundColumnResource5" UniqueName="CveIniciativa">
                                                                                                  <HeaderStyle Width="0px" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridBoundColumn DataField="Iniciativa" FilterControlAltText="Filter Iniciativa column" HeaderText="Iniciativa" meta:resourceKey="GridBoundColumnResource6" UniqueName="Iniciativa">
                                                                                                  <HeaderStyle HorizontalAlign="Center" Width="16%" />
                                                                                                  <ItemStyle HorizontalAlign="Left" Width="16%" />
                                                                                              </telerik:GridBoundColumn>
                                                                                              <telerik:GridTemplateColumn FilterControlAltText="Filter Bitacora column" HeaderText="Bitacora" meta:resourceKey="GridTemplateColumnResource1" UniqueName="Bitacora">
                                                                                                  <HeaderStyle HorizontalAlign="Center" Width="16%" />
                                                                                                  <ItemStyle HorizontalAlign="Center" Width="16%" />
                                                                                              </telerik:GridTemplateColumn>
                                                                                              <telerik:GridTemplateColumn FilterControlAltText="Filter Avance column" HeaderText="Avance" meta:resourceKey="GridTemplateColumnResource2" UniqueName="Avance">
                                                                                                  <HeaderStyle HorizontalAlign="Center" Width="16%" />
                                                                                                  <ItemStyle HorizontalAlign="Center" Width="16%" />
                                                                                              </telerik:GridTemplateColumn>
                                                                                              <telerik:GridTemplateColumn FilterControlAltText="Filter Finalizar column" HeaderText="Finalizar" meta:resourceKey="GridTemplateColumnResource3" UniqueName="Finalizar">
                                                                                                  <HeaderStyle HorizontalAlign="Center" Width="16%" />
                                                                                                  <ItemStyle HorizontalAlign="Center" Width="16%" />
                                                                                              </telerik:GridTemplateColumn>
                                                                                          </Columns>
                                                                                          <HeaderStyle Font-Bold="True" />
                                                                                      </mastertableview>
                                                                                  </telerik:RadGrid>
                                                                              </td>
                                                                          </tr>
                                                                      </table>
                                                                  </asp:Panel>
                                                                  <br />
                                                                  <telerik:RadGrid ID="RadGrid1" runat="server" 
                                                                      Height="300px" Width="100%" Visible="False" Culture="es-ES" meta:resourcekey="RadGrid1Resource1" GroupPanelPosition="Top">
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

                                                                        <Columns>
                                                                          <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Editar" 
                                                                              FilterControlAltText="Filter EditColumn column" HeaderText="Editar" 
                                                                              ImageUrl="~/Imagenes/COManager/Edit16.png" UniqueName="EditColumn" meta:resourcekey="GridButtonColumnResource1">
                                                                              <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                          </telerik:GridButtonColumn>
                                                                          <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Borrar" 
                                                                              FilterControlAltText="Filter DeleteColumn column" HeaderText="Borrar" 
                                                                              ImageUrl="~/Imagenes/COManager/Delete16.png" UniqueName="DeleteColumn" meta:resourcekey="GridButtonColumnResource2">
                                                                              <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                          </telerik:GridButtonColumn>
                                                                          <telerik:GridTemplateColumn HeaderText="Detalle" UniqueName="DETALLE" meta:resourcekey="GridTemplateColumnResource4">
                                                                            <HeaderStyle Width="50px" Font-Italic="False" 
                                                                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                            HorizontalAlign="Center" Wrap="True" />
                                                                              <ItemStyle Width="50px" Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                            Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                                            Wrap="True" />
                                                                          </telerik:GridTemplateColumn>
                                                                        </Columns>

                                                                    <EditFormSettings>
                                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                                    </EditFormSettings>
                                                                        <HeaderStyle Font-Bold="True" />
                                                                    </MasterTableView>

                                                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                                                  </telerik:RadGrid>
                                                              <br />
                                                          <br />
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td align="center">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
                                          <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Style="z-index: 7001" KeepInScreenBounds="True" meta:resourcekey="RadWindowManager1Resource1">  
                                           <Windows>
                                                <telerik:RadWindow ID="UserListDialog" runat="server" Title="Window" Height="600px"
                                                    Width="850px" Left="" ReloadOnShow="True"
                                                    Modal="true" Animation="Fade" InitialBehavior="None" 
                                                    Behavior="Close, Maximize" 
                                                    NavigateUrl="PAPreguntas.aspx" meta:resourcekey="UserListDialogResource1">
                                                </telerik:RadWindow>
                                               <telerik:RadWindow ID="modalPopup" runat="server" Width="680px" Height="965px" meta:resourcekey="modalPopupResource1" Behavior="Close, Maximize">
                                                   <ContentTemplate>
                                                        <div style="padding: 10px; text-align: center;">
                                                             <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/Estatus/PasosPA.png" meta:resourcekey="Image6Resource1" />
                                                        </div>
                                                   </ContentTemplate>
                                              </telerik:RadWindow>
                                            </Windows>
                                          </telerik:RadWindowManager>
                                                  </td>
                                              </tr>
                                              </table>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                      </tr>
                      <tr>
                          <td>
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
    
     <script type="text/javascript">
         //<![CDATA[
        /* function showMenuAt(e) {
             var contextMenu = $find("RadContextMenu1.ClientID");
             var x = parseInt($get("contextX").value);
             var y = parseInt($get("contextY").value);

             if (isNaN(x) || isNaN(y)) {
                 alert("Please provide valid integer coordinates");
                 return;
             }

             contextMenu.showAt(x, y);

             $telerik.cancelRawEvent(e);
         }
        */
         function showMenu(e) {
             var contextMenu = $find("RadContextMenu1");

             if ((!e.relatedTarget) || (!$telerik.isDescendantOrSelf(contextMenu.get_element(), e.relatedTarget))) {
                 contextMenu.show(e);
             }

             $telerik.cancelRawEvent(e);
         }
         //]]>
    </script>
    
</body>
</html>

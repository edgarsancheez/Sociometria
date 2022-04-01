<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BusquedaBenchTemas.aspx.vb" Inherits="ConsultaVirtual.BusquedaBenchTemas" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Benchmark</title>
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
         function requestStart(sender, args) {
             if (args.get_eventTarget().indexOf("ExportToExcel") >= 0)
                 args.set_enableAjax(false);
         }
    </script>
    
    <script type="text/javascript" language="javascript">
    function SetStatus(headObj) {

        var obj = document.getElementsByTagName("input");
        for (var i = 0; i < obj.length; i++) {
            if (obj[i].type.toLowerCase() == "checkbox" &&
                obj[i].name.toLowerCase() != headObj.name.toLowerCase()) {
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
      <table cellpadding="0" cellspacing="0" class="style1" align="center" width="100%">
          <tr>
              <td align="center">
                  <table cellpadding="0" cellspacing="0" class="style1" width="100%">
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
                                          <table cellpadding="2" cellspacing="2" border="0" style="font-family: arial, Helvetica, sans-serif; font-size: small; width: 100%;">
                                              <tr>
                                                  <td width="100%" colspan="5" align="center">
                                                      <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                          Font-Size="10pt" ForeColor="#990033" meta:resourcekey="LerrorResource1"></asp:Label>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td align="left" width="20%">
                                                      &nbsp;&nbsp;
                                                      <asp:Label ID="Label2" runat="server" Text="Unidad de Negocio" 
                                                          style="font-weight: 700" meta:resourcekey="Label2Resource1"></asp:Label>
                                                  </td>
                                                  <td align="left" width="20%">
                                                      <telerik:RadComboBox ID="RCBUnidad" Runat="server" MarkFirstMatch="True" 
                                                          Width="90%" EmptyMessage="Sin datos que mostrar" 
                                                          Enabled="False" AutoPostBack="True" Culture="es-ES" meta:resourcekey="RCBUnidadResource1">
                                                      </telerik:RadComboBox>
                                                  </td>
                                                  <td align="left" width="20%">
                                                      &nbsp;</td>
                                                  <td align="left" width="20%">
                                                      <asp:Label ID="Label18" runat="server" Text="Territorio" 
                                                          style="font-weight: 700" meta:resourcekey="Label18Resource1" ></asp:Label>
                                                  </td>
                                                  <td align="left" width="20%">
                                                      <telerik:RadComboBox ID="RCBTerritorio" Runat="server" MarkFirstMatch="True" 
                                                          Width="90%" AutoPostBack="True" EmptyMessage="Sin datos que mostrar" 
                                                          Enabled="False" Culture="es-ES" meta:resourcekey="RCBTerritorioResource1">
                                                      </telerik:RadComboBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td align="left" >
                                                      &nbsp;&nbsp;
                                                      <asp:Label ID="Label7" runat="server" Font-Bold="True" 
                                                          Text="Agrupado por Paises" meta:resourcekey="Label7Resource1"></asp:Label>
                                                  </td>
                                                  <td align="left" >
                                                      <telerik:RadComboBox ID="RCBAgrupadoPaises" Runat="server" MarkFirstMatch="True" 
                                                          Width="90%" EmptyMessage="Sin datos que mostrar" 
                                                          Enabled="False" AutoPostBack="True" Culture="es-ES" meta:resourcekey="RCBUnidadResource1">
                                                      </telerik:RadComboBox>
                                                  </td>
                                                  <td align="center"  valign="middle">
                                                      <asp:Label ID="Label6" runat="server" Text="Esquema" 
                                                          style="font-weight: 700" Visible="False" meta:resourcekey="Label6Resource1" ></asp:Label>
                                                  </td>
                                                  <td align="left" >
                                                      <asp:Label ID="Label3" runat="server" Text="Región / Zona" 
                                                          style="font-weight: 700" meta:resourcekey="Label3Resource1"></asp:Label>
                                                  </td>
                                                  <td align="left" >
                                                      <telerik:RadComboBox ID="RCBRegion" Runat="server" MarkFirstMatch="True" 
                                                          Width="90%" AutoPostBack="True" EmptyMessage="Sin datos que mostrar" 
                                                          Enabled="False" Culture="es-ES" meta:resourcekey="RCBregionResource1">
                                                      </telerik:RadComboBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td align="left" >
                                                      &nbsp;&nbsp;
                                                      <asp:Label ID="Label1" runat="server" Text="País" style="font-weight: 700" meta:resourcekey="Label1Resource1" 
                                                          ></asp:Label>
                                                  </td>
                                                  <td align="left" >
                                                      <telerik:RadComboBox ID="RCBPais" Runat="server" MarkFirstMatch="True" 
                                                          Width="90%" AutoPostBack="True" EmptyMessage="Sin datos que mostrar" 
                                                          Enabled="False" Culture="es-ES" meta:resourcekey="RCBpaisResource1">
                                                      </telerik:RadComboBox>
                                                  </td>
                                                  <td align="center" >
                                                      <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                                          RepeatDirection="Horizontal" Visible="False" AutoPostBack="True" meta:resourcekey="RadioButtonList1Resource1" >
                                                          <asp:ListItem Selected="True" Value="1" meta:resourcekey="ListItemResource1">Empleado</asp:ListItem>
                                                          <asp:ListItem Value="2" meta:resourcekey="ListItemResource2">Lider</asp:ListItem>
                                                      </asp:RadioButtonList>
                                                  </td>
                                                  <td align="left" >
                                                      <asp:Label ID="Label4" runat="server" Text="Subregión" style="font-weight: 700" meta:resourcekey="Label4Resource1" 
                                                          ></asp:Label>
                                                  </td>
                                                  <td align="left" >
                                                      <telerik:RadComboBox ID="RCBSubRegion" Runat="server" MarkFirstMatch="True" 
                                                          Width="90%" AutoPostBack="True" EmptyMessage="Sin datos que mostrar" 
                                                          Enabled="False" Culture="es-ES" meta:resourcekey="RCBsubregionResource1">
                                                      </telerik:RadComboBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td align="left" >
                                                      &nbsp;</td>
                                                  <td align="left" >
                                                      &nbsp;</td>
                                                  <td align="center" >
                                                      <telerik:RadButton ID="BFiltrar" runat="server" Text="Filtrar" meta:resourcekey="BFiltrarResource1" style="position: relative;">
                                                          <Icon PrimaryIconLeft="4" PrimaryIconTop="4" 
                                                              PrimaryIconUrl="Imagenes/COManager/Search16.png" />
                                                      </telerik:RadButton>
                                                  </td>
                                                  <td align="left" >
                                                      <asp:Label ID="Label8" runat="server" Text="Tema" style="font-weight: 700" 
                                                          ForeColor="#666666" 
                                                          ToolTip="Tema específico a visualizar" meta:resourcekey="Label8Resource1"></asp:Label>
                                                  </td>
                                                  <td align="left" >
                                                      <telerik:RadComboBox ID="RCBTema" Runat="server" MarkFirstMatch="True" 
                                                          Width="90%" EmptyMessage="Todos" 
                                                          Enabled="False" CheckBoxes="True" Culture="es-ES" meta:resourcekey="RCBTemaResource1">
                                                      </telerik:RadComboBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td width="100%" align="center" colspan="5" valign="top">
                                                      
                                                          <telerik:RadGrid ID="RadGrid1" runat="server" Height="400px" ShowFooter="True" ShowStatusBar="True" 
                                                              Width="99%" Culture="es-ES" meta:resourcekey="Grid2Resource1" GroupPanelPosition="Top">
                                                              <ExportSettings ExportOnlyData="True" 
                                                                  FileName="ReporteClima" HideStructureColumns="True">
                                                                  <Excel FileExtension="xlsx" />
                                                              </ExportSettings>
                                                              <ClientSettings>
                                                                  <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                                                  <Resizing AllowColumnResize="True" />
                                                              </ClientSettings>
                                                              <MasterTableView CommandItemDisplay="Top">
                                                                  <CommandItemSettings AddNewRecordText="" ExportToExcelText="Exportar a Excel" RefreshText="" ShowAddNewRecordButton="False" ShowExportToExcelButton="True" ShowRefreshButton="False" />
                                                                  <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                                  <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                                  <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="True" />
                                                                  <CommandItemTemplate>
                                                                      <table style="width:100%;">
                                                                          <tr>
                                                                              <td align="left" width="97%">
                                                                                  <asp:Label ID="Label5" runat="server" meta:resourcekey="Label5Resource1" style="font-weight: 700" Text="Tipo de Operación"></asp:Label>
                                                                                  &nbsp;<telerik:RadComboBox ID="RcboTipoOperacion" Runat="server" 
                                                                                  AppendDataBoundItems="True" AutoPostBack="True" 
                                                                                  EmptyMessage="Sin información disponible" Enabled="False" 
                                                                                  EnableVirtualScrolling="True" Filter="Contains" 
                                                                                  Height="100px" ItemsPerRequest="10" MarkFirstMatch="True" MinFilterLength="4" 
                                                                                  OnSelectedIndexChanged="RcboTipoOperacion_SelectedIndexChanged" 
                                                                                  Width="20%" meta:resourcekey="RcboTipoOperacionResource1">
                                                                                </telerik:RadComboBox>
                                                                              </td>
                                                                              <td align="right" width="3%">
                                                                                  <asp:ImageButton ID="LkExcel" runat="server" OnClick="Exportar" ImageUrl="~/Imagenes/Estatus/page_excel.png" meta:resourcekey="LkExcelResource1" />
                                                                              </td>
                                                                          </tr>
                                                                      </table>
                                                                  </CommandItemTemplate>
                                                              </MasterTableView>
                                                              <FooterStyle Font-Bold="True" />
                                                          </telerik:RadGrid>
                                            </td>
                                              </tr>
                                              <tr>
                                                  <td align="center" colspan="5" >
       <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
                                                          <telerik:RadWindowManager ID="RadWindowManager1" runat="server" 
                                                              Style="z-index: 7001" meta:resourcekey="RadWindowManager1Resource1">
                                                              <Windows>
                                                                  <telerik:RadWindow ID="UserListDialog" runat="server" Animation="Fade" 
                                                                      Behavior="Close, Maximize" Behaviors="Close, Maximize" Height="650px" 
                                                                      Modal="True" ReloadOnShow="True" Title="Grafica General Por Temas" 
                                                                      ToolTip="Gráfica que  agrupa los temas de los  estudios generados en la consulta" 
                                                                      VisibleStatusbar="False" Width="850px" meta:resourcekey="UserListDialogResource1" />
                                                                  <telerik:RadWindow ID="RadDetalles" runat="server" Behavior="Close, Maximize" 
                                                                      Behaviors="Close, Maximize" Height="650px" InitialBehavior="Maximize" 
                                                                      InitialBehaviors="Maximize" Modal="True" ReloadOnShow="True" 
                                                                      VisibleStatusbar="False" Width="850px" meta:resourcekey="RadDetallesResource1">
                                                                  </telerik:RadWindow>
                                                                  <telerik:RadWindow ID="RadRegional" runat="server" Behavior="Close, Maximize" 
                                                                      Behaviors="Close, Maximize" Height="650px" 
                                                                      Modal="True" ReloadOnShow="True" VisibleStatusbar="False" Width="850px" meta:resourcekey="RadRegionalResource1">
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
</body>
</html>

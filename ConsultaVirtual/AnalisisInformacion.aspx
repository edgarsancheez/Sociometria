<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AnalisisInformacion.aspx.vb" Inherits="ConsultaVirtual.AnalisisInformacion" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" MaintainScrollPositionOnPostback="true" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Análisis Información</title>
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
     <telerik:RadCodeBlock runat="server" ID="RadCodeBlock1">
        <script type="text/javascript">
            function RowContextMenu(sender, eventArgs) {
                var menu = $find("<%= RadMenu1.ClientID %>");
                var evt = eventArgs.get_domEvent();

                if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                    return;
                }

                var index = eventArgs.get_itemIndexHierarchical();
                document.getElementById("radGridClickedRowIndex").value = index;

                sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);

                menu.show(evt);

                evt.cancelBubble = true;
                evt.returnValue = false;

                if (evt.stopPropagation) {
                    evt.stopPropagation();
                    evt.preventDefault();
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <form id="form1" runat="server" style="clip: rect(5px, 5px, 5px, 5px)">
                                         <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex"/>
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
                          <td align="center" height="23">
                              &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="center" height="23">
                              <table cellpadding="0" cellspacing="0" align="center" class="style2">
                                  <tr>
                                      <td valign="middle" align="center">
                                          &nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td valign="middle" align="center">
                                        <telerik:RadPanelBar ID="RadPanelBar1" runat="server" BorderWidth="0px" Width="95%" meta:resourcekey="RadPanelBar1Resource1">
                                                <Items>
                                                    <telerik:RadPanelItem runat="server" Text="Mis Comparativas" PostBack="False" meta:resourcekey="RadPanelItemResource1">
                                                        <ContentTemplate>
                                                            <table style="width:100%;">
                                                                <tr>
                                                                    <td align="left" height="140px" valign="top" width="50%">
                                                                        <telerik:RadListBox ID="RComparativas" runat="server" 
                                                                            Height="100%" meta:resourcekey="RComparativasResource1" Width="98%">
                                                                            <ButtonSettings TransferButtons="All" />
                                                                        </telerik:RadListBox>
                                                                    </td>
                                                                    <td align="left" height="140px" valign="top" width="50%">
                                                                        <telerik:RadButton ID="BVerComparativa" runat="server" meta:resourcekey="BVerComparativaResource1" Text="Ver" OnClick="BVerComparativa_Click" ToolTip="Ver Comparativa" Width="75px">
                                                                            <Icon PrimaryIconLeft="4px" PrimaryIconTop="4px" PrimaryIconUrl="Imagenes/Estatus/VerComparativa.png" />
                                                                        </telerik:RadButton>
                                                                        <br />
                                                                        <br />
                                                                        <telerik:RadButton ID="BBorrar" runat="server" meta:resourcekey="BBorrarResource1" OnClick="BBorrar_Click" Text="Borrar" ToolTip="Borrar Comparativa" Width="75px">
                                                                            <Icon PrimaryIconLeft="4px" PrimaryIconTop="4px" PrimaryIconUrl="Imagenes/COManager/Delete16.png" />
                                                                        </telerik:RadButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </telerik:RadPanelItem>
                                                    <telerik:RadPanelItem runat="server" Text="Sistemas" meta:resourcekey="RadPanelItemResource2">
                                                            <ContentTemplate>
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td align="left" width="17%">
                                                                                <asp:Label ID="LSistema" runat="server" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="LSistemaResource1" style="font-weight: 700" Text="Sistema"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="16.5%">
                                                                                <asp:Label ID="LTema" runat="server" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="LTemaResource1" style="font-weight: 700" Text="Tema"></asp:Label>
                                                                        </td>
                                                                        <td align="left" width="66.5%">
                                                                                <asp:Label ID="LPregunta" runat="server" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="LPreguntaResource1" style="font-weight: 700" Text="Pregunta"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" height="140px" valign="top" width="17%">
                                                                            <telerik:RadListBox ID="RSistema" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RSistemaResource1" Width="98%">
                                                                                <ButtonSettings TransferButtons="All" />
                                                                            </telerik:RadListBox>
                                                                        </td>
                                                                        <td align="left" height="140px" valign="top" width="16.5%">
                                                                            <telerik:RadListBox ID="RTema" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RTemaResource1" Width="98%">
                                                                                <ButtonSettings TransferButtons="All" />
                                                                            </telerik:RadListBox>
                                                                        </td>
                                                                        <td align="left" height="140px" valign="top" width="66.5%">
                                                                            <telerik:RadListBox ID="RPregunta" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RPreguntaResource1" Width="98%">
                                                                                <ButtonSettings TransferButtons="All" />
                                                                            </telerik:RadListBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                    </telerik:RadPanelItem>
                                                    <telerik:RadPanelItem Text="Estructura Organizacional" PostBack="False" meta:resourcekey="RadPanelItemResource3">
                                                            <ContentTemplate>
                                                                <table align="left" border="0" style="width:100%;">
                                                                    <tr>
                                                                        <td align="left" colspan="7">
                                                                            <asp:RadioButtonList ID="RbnEsquema" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="10pt" meta:resourcekey="RadioButtonList1Resource1" RepeatDirection="Horizontal" Visible="False" OnSelectedIndexChanged="RbnEsquema_SelectedIndexChanged">
                                                                                <asp:ListItem meta:resourcekey="ListItemResource1" Selected="True" Value="1">Empleado</asp:ListItem>
                                                                                <asp:ListItem meta:resourcekey="ListItemResource2" Value="2">Tercero</asp:ListItem>
                                                                            </asp:RadioButtonList>
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
                                                                            <telerik:RadListBox ID="RTerritorios" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RTerritoriosResource1" Width="98%">
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
                                                                            <telerik:RadListBox ID="RCentroDeTrabajo" runat="server" AutoPostBack="True" Height="100%" meta:resourcekey="RCentroDeTrabajoResource1" Width="98%">
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
                                      <td valign="middle" align="center">
                            <asp:Label ID="LConcepto" runat="server" Font-Bold="True" Font-Names="Arial" 
                                Font-Size="10pt" ForeColor="Black" Visible="False" meta:resourcekey="LConceptoResource1"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td valign="middle" align="center">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" Height="400px" 
                        ShowFooter="True" Width="95%" Culture="es-ES" meta:resourcekey="RadGrid1Resource1" GroupPanelPosition="Top">
                        <SortingSettings SortedAscToolTip="Reordenar Ascendente" 
                        SortedDescToolTip="Reordenar Descendente" />
                                    <ExportSettings ExportOnlyData="True" FileName="Comparativa" HideStructureColumns="True">
                                        <Excel FileExtension="xlsx" />
                                    </ExportSettings>
                                                        <ClientSettings  EnableRowHoverStyle="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="true" />
                                        <ClientEvents OnRowClick="RowContextMenu"></ClientEvents>
                                    </ClientSettings>
                    <MasterTableView CommandItemDisplay="Top" TableLayout="Fixed"> 
                        <CommandItemSettings AddNewRecordText="" ExportToExcelText="Exportar el contenido del Grid a un archivo Excel" RefreshText="Actualizar contenido" ShowAddNewRecordButton="False" ShowExportToExcelButton="True" ShowRefreshButton="False" />
                        <RowIndicatorColumn Visible="False">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Created="True">
                        </ExpandCollapseColumn>
                        <EditFormSettings>
                                            <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <HeaderStyle Height="50px" Font-Bold="True" />
                        <CommandItemTemplate>
                            <div style="margin-top: 0px; vertical-align: middle; text-align: left; width: 100%;">
                            <table id="Table1" align="right" cellpadding="2" cellspacing="0"  style="width:100%;">
                            <tr>
                            <td align="right" valign="middle" width="10%">
                            
                                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="10pt" Text="Tipo de Operación" meta:resourcekey="Label1Resource1"></asp:Label>
                            
                            </td>
                            <td align="left" valign="middle" width="75%">
                            <telerik:RadComboBox ID="RcboTipoOperacion" Runat="server" 
                              AppendDataBoundItems="True" AutoPostBack="True" 
                              EmptyMessage="Sin información disponible" Enabled="False" 
                              EnableVirtualScrolling="True" Filter="Contains" 
                              Height="100px" ItemsPerRequest="10" MarkFirstMatch="True" MinFilterLength="4" 
                              OnSelectedIndexChanged="RcboTipoOperacion_SelectedIndexChanged" 
                              Width="20%" meta:resourcekey="RcboTipoOperacionResource1">
                            </telerik:RadComboBox>
                            </td>
                            <td align="right" valign="middle" width="3%">
                            <asp:ImageButton ID="LkLimpiar" runat="server" OnClick="LkLimpiar" ImageUrl="~/Imagenes/Estatus/Limpiar.png" ToolTip="Limpiar los filtros seleccionados" meta:resourcekey="LkLimpiarResource1"></asp:ImageButton>
                            </td>
                            <td align="right" valign="middle" width="3%">
                            <asp:ImageButton ID="LkAgregar" runat="server" OnClick="LkAgregar" ImageUrl="~/Imagenes/Estatus/AddComparativa.png" ToolTip="Agregar nuevo registro a comparativa" meta:resourcekey="LkAgregarResource1"></asp:ImageButton>
                            </td>
                            <td align="right" valign="middle" width="3%">
                            <asp:ImageButton ID="LkBorrar" runat="server" OnClick="LkBorrar" ImageUrl="~/Imagenes/Estatus/RemoveComparativa.png" ToolTip="Eliminar los registros almacenados en comparativa" meta:resourcekey="LkBorrarResource1"></asp:ImageButton>
                            </td>    
                            <td align="right" valign="middle" width="3%">
                            <asp:ImageButton ID="LKVer" runat="server" OnClick="Ver" ImageUrl="~/Imagenes/Estatus/VerComparativa.png" ToolTip="Ver comparativa" meta:resourcekey="LKVerResource1"></asp:ImageButton>
                            </td>
                            <td align="right" valign="middle" width="3%">
                             <asp:ImageButton ID="LkExcel" runat="server" OnClick="Exportar" ImageUrl="~/Imagenes/Estatus/page_excel.png" meta:resourcekey="LkExcelResource1"></asp:ImageButton>
                            </td>   
                            </tr>
                            </table>          
                        </CommandItemTemplate>   
                        <FooterStyle Font-Bold="True" />
                                        
                    </MasterTableView>
                                    <FilterMenu EnableEmbeddedSkins="False">
                                    </FilterMenu>
                                    <HeaderContextMenu EnableEmbeddedSkins="False">
                                    </HeaderContextMenu>
                </telerik:RadGrid>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td valign="middle" align="center">
                                        <telerik:RadContextMenu ID="RadMenu1" runat="server"  
                                            EnableRoundedCorners="True" 
                                            EnableShadows="True" style="left: 680px" meta:resourcekey="RadMenu1Resource1" >
                                            <Items>
                                                <telerik:RadMenuItem Text="Tendencia" meta:resourcekey="RadMenuItemResource1">
                                                </telerik:RadMenuItem>
                                            </Items>
                                        </telerik:RadContextMenu>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td valign="middle" align="center">
                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                Font-Size="10pt" ForeColor="#990033" meta:resourcekey="LerrorResource1"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td valign="middle" align="center">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" meta:resourcekey="RadAjaxManager1Resource1">
        </telerik:RadAjaxManager>
                                        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Style="z-index: 7001" meta:resourcekey="RadWindowManager1Resource1">
                                            <Windows>
                                                <telerik:RadWindow ID="RadDetalles" runat="server" Behavior="Close, Maximize" 
                                                    Behaviors="Close, Maximize" Height="700px" InitialBehavior="None" 
                                                    InitialBehaviors="None" Modal="True" ReloadOnShow="True" 
                                                    VisibleStatusbar="False" Width="900px" meta:resourcekey="RadDetallesResource1">
                                                </telerik:RadWindow>
                                            </Windows>
                                        </telerik:RadWindowManager>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td valign="middle" align="center">
                                          &nbsp;</td>
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

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BusquedaGeneral.aspx.vb" Inherits="ConsultaVirtual.BusquedaGeneral" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Dashboard</title>
    <link href="Clases/EstiloPagina.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
         .RadMenu a.rmSelected .rmText
         {
            /*font-weight: bold;
            background-color: #990033;
            color: #ffffff;*/
         }

         /*.RadGrid .rgHoveredRow {
            text-decoration: underline;
         }*/
    </style>
    <script type="text/javascript">
        function RowContextMenu(sender, eventArgs) {
            var menu = $find("RadContextMenu1");
            var evt = eventArgs.get_domEvent();
            menu.show(evt);
         }
    </script>
</head>
<body>
    <form id="form1" runat="server" style="clip: rect(5px, 5px, 5px, 5px)">
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td align="left" height="46px" 
                    style="background-position: center; background-image: url('Imagenes/Background/Banner.png'); background-repeat: no-repeat;" 
                    valign="bottom">
                    <uc2:Head ID="HeadLeft1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center" height="23">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <table class="style2">
                    <tr>
                        <td align="center" valign="top">
                            <table cellpadding="2" cellspacing="2" border="0" width="100%"
                            style="font-family: arial, Helvetica, sans-serif; font-size: small;">
                    <tr>
                        <td width="100%" colspan="5" align="center">
                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial"
                                Font-Size="10pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="20%">
                            &nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Unidad de Negocio" 
                                style="font-weight: 700" meta:resourcekey="Label2Resource1" ></asp:Label>
                        </td>
                        <td align="left" width="20%">
                            <telerik:RadComboBox ID="RCBUnidad" Runat="server" MarkFirstMatch="True" 
                                Width="90%" EmptyMessage="Sin datos que mostrar" 
                                Enabled="False"  AutoPostBack="True" Culture="es-ES" meta:resourcekey="RCBUnidadResource1">
                            </telerik:RadComboBox>
                        </td>
                        <td width="20%">
                        &nbsp;&nbsp;
                            </td>
                        <td align="left" width="20%">
                            <asp:Label ID="Label18" runat="server" Text="Territorio" 
                                style="font-weight: 700" meta:resourcekey="Label18Resource1"></asp:Label>
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
                                Text="Agrupado por Paises" meta:resourcekey="Label7Resource1" ></asp:Label>
                        </td>
                        <td align="left" >
                            <telerik:RadComboBox ID="RCBAgrupadoPaises" Runat="server" MarkFirstMatch="True" 
                                Width="90%" EmptyMessage="Sin datos que mostrar" 
                                Enabled="False"  AutoPostBack="True" Culture="es-ES" meta:resourcekey="RCBAgrupadoPaisesResource1">
                            </telerik:RadComboBox>
                        </td>
                        <td align="center"  valign="middle">
                            <asp:Label ID="Label6" runat="server" Text="Esquema" 
                                Visible="False" Font-Bold="True" meta:resourcekey="Label6Resource1" ></asp:Label>
                        </td>
                        <td align="left" >
                            <asp:Label ID="Label3" runat="server" Text="Región / Zona" 
                                style="font-weight: 700" meta:resourcekey="Label3Resource1" ></asp:Label>
                        </td>
                        <td align="left">
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
                                <asp:ListItem Selected="True" Value="1" meta:resourcekey="ListItemResource1" >Empleado</asp:ListItem>
                                <asp:ListItem Value="2" meta:resourcekey="ListItemResource2" >Lider</asp:ListItem>
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
                            <telerik:RadButton ID="BFiltrar" runat="server" Text="Filtrar" meta:resourcekey="BFiltrarResource1" style="position: relative;" >
                                <Icon PrimaryIconLeft="4" PrimaryIconTop="4" 
                                    PrimaryIconUrl="Imagenes/COManager/Search16.png" />
                            </telerik:RadButton>
                        </td>
                        <td align="left" >
                            &nbsp;</td>
                        <td align="left" >
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" colspan="5" valign="top" >
                                <telerik:RadGrid ID="RadGrid1" runat="server" Height="450px" 
                                ShowFooter="True" Width="100%" AutoGenerateColumns="False" 
                                AllowSorting="True" Culture="es-MX" meta:resourcekey="RadGrid1Resource1" GroupPanelPosition="Top" >
                                    <HeaderStyle Font-Bold="True" />
                                    <ExportSettings FileName="CentrosDeTrabajo" ExportOnlyData="True">
                                    </ExportSettings>
                                    <FooterStyle Font-Bold="True" />
                                    <GroupingSettings CaseSensitive="False" /> 
                                    <MasterTableView CommandItemDisplay="Top" AllowFilteringByColumn="True" width="100%" >
                                        <CommandItemSettings   ShowExportToExcelButton="True"    
                                        ExportToExcelText="Exportar a Excel" ShowExportToWordButton="True" 
                                        ExportToWordText="Exportar a Word"  AddNewRecordText="" RefreshText="" 
                                        ShowAddNewRecordButton="False" ShowRefreshButton="False" />
                                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="NUM" UniqueName="NUM" 
                                                AllowFiltering="False" meta:resourcekey="GridBoundColumnResource1" >
                                                <HeaderStyle Width="50px" HorizontalAlign="Center"  />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                    Wrap="True"/>
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CVEEMPRESA" HeaderText="CVEEMPRESA" 
                                                SortExpression="CVEEMPRESA" UniqueName="CVEEMPRESA" Display="false" meta:resourcekey="GridBoundColumnResource2" >
                                                <HeaderStyle Width="0px" />
                                                <ItemStyle />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EMPRESA" HeaderText="CENTRO DE TRABAJO" 
                                                SortExpression="EMPRESA" UniqueName="EMPRESA" AutoPostBackOnFilter="true" 
                                                CurrentFilterFunction="Contains" ShowFilterIcon="False" 
                                                FilterControlWidth="80%" meta:resourcekey="GridBoundColumnResource3" >
                                                <HeaderStyle Width="30%" Font-Italic="False" 
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                    HorizontalAlign="Left" Wrap="True" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="True" HorizontalAlign="Left" 
                                                    Wrap="True" />
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CVEENCUESTA" HeaderText="CVEENCUESTA" 
                                                SortExpression="CVEENCUESTA" UniqueName="CVEENCUESTA" Display="false" meta:resourcekey="GridBoundColumnResource4" >
                                                <HeaderStyle Width="0px" />
                                                <ItemStyle />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridDateTimeColumn DataField="APLICACION" 
                                                FilterControlAltText="Filter APLICACION column" HeaderText="APLICACION" 
                                                SortExpression="APLICACION" UniqueName="APLICACION"
                                                DataFormatString="{0:d}" FilterControlWidth="70%" meta:resourcekey="GridDateTimeColumnResource1" >
                                                <HeaderStyle Width="15%" Font-Italic="False" 
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                    HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                    Wrap="True" />
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" HorizontalAlign="Left" />
                                            </telerik:GridDateTimeColumn>
                                            <telerik:GridBoundColumn DataField="ESPERADO" HeaderText="ESPERADO" 
                                                SortExpression="ESPERADO" UniqueName="ESPERADO" Display="false" meta:resourcekey="GridBoundColumnResource5" >
                                                <HeaderStyle Width="0px" />
                                                <ItemStyle />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="REAL" HeaderText="REAL" 
                                                SortExpression="REAL" UniqueName="REAL" Display="false" meta:resourcekey="GridBoundColumnResource6" >
                                                <HeaderStyle Width="0px" />
                                                <ItemStyle />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="PARTICIPACION" UniqueName="PARTICIPACION" 
                                                DataField="PARTICIPACION" DataFormatString="{0:F1}%" FilterControlWidth="80%" meta:resourcekey="GridBoundColumnResource7" >
                                                <HeaderStyle Width="10%" Font-Italic="False" 
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                    HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                    Wrap="True" />
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PADRE" HeaderText="PADRE" 
                                                UniqueName="PADRE" FilterControlAltText="Filter PADRE column" Display="false" meta:resourcekey="GridBoundColumnResource8" >
                                                <HeaderStyle Width="0px" />
                                                <ItemStyle />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="AMBIENTELABORAL" HeaderText="AL" 
                                                SortExpression="AMBIENTELABORAL" UniqueName="AMBIENTELABORAL" DataType="System.Double" 
                                                DataFormatString="{0:N1}" HeaderTooltip="Ambiente Laboral" 
                                                FilterControlWidth="60%" meta:resourcekey="GridBoundColumnResource9" >
                                                <HeaderStyle Width="5%" Font-Italic="False" 
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                    HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                    Wrap="True" />
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JEFEINMEDIATO" HeaderText="JI" 
                                                SortExpression="JEFEINMEDIATO" UniqueName="JEFEINMEDIATO" DataType="System.Double" 
                                                DataFormatString="{0:N1}" HeaderTooltip="Jefe Inmediato" 
                                                FilterControlWidth="60%" meta:resourcekey="GridBoundColumnResource10" >
                                                <HeaderStyle Width="5%" Font-Italic="False" 
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                    HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                    Wrap="True" />
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="COMPROMISOSOPORTE" HeaderText="CS" 
                                                SortExpression="COMPROMISOSOPORTE" UniqueName="COMPROMISOSOPORTE" DataType="System.Double" 
                                                DataFormatString="{0:N1}" HeaderTooltip="Compromiso y Soporte" 
                                                FilterControlWidth="60%" meta:resourcekey="GridBoundColumnResource11" >
                                                <HeaderStyle Width="5%" Font-Italic="False" 
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                    HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                    Wrap="True" />
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CLIMAORGANIZACIONAL" HeaderText="CO" 
                                                SortExpression="CLIMAORGANIZACIONAL" UniqueName="CLIMAORGANIZACIONAL" DataType="System.Double" 
                                                DataFormatString="{0:N1}" HeaderTooltip="Clima Organizacional" 
                                                FilterControlWidth="60%" meta:resourcekey="GridBoundColumnResource12" >
                                                <HeaderStyle Width="7%" Font-Italic="False" 
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                    HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                    Wrap="True" />
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="CALIDADDEVIDA" HeaderText="CV" 
                                                SortExpression="CALIDADDEVIDA" UniqueName="CALIDADDEVIDA" DataType="System.Double" 
                                                DataFormatString="{0:N1}" HeaderTooltip="Calidad de Vida" 
                                                FilterControlWidth="60%" meta:resourcekey="GridBoundColumnResource14" >
                                                <HeaderStyle Width="7%" Font-Italic="False" 
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                    HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                    Wrap="True" />
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="DESARROLLOSOCIAL" HeaderText="DS" 
                                                SortExpression="DESARROLLOSOCIAL" UniqueName="DESARROLLOSOCIAL" DataType="System.Double" 
                                                DataFormatString="{0:N1}" HeaderTooltip="Desarrollo Social" 
                                                FilterControlWidth="60%" meta:resourcekey="GridBoundColumnResource15" >
                                                <HeaderStyle Width="7%" Font-Italic="False" 
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                    HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                    Wrap="True" />
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="ESPERADO" HeaderText="HC" 
                                                SortExpression="ESPERADO" UniqueName="HC" FilterControlWidth="60%" meta:resourcekey="GridBoundColumnResource13" >
                                                <HeaderStyle Width="5%" Font-Italic="False" 
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                    HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                    Wrap="True" />
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>
                                        <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" />
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
                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                    <ClientSettings EnableRowHoverStyle="True">
                                        <Selecting AllowRowSelect="True" />
                                        <ClientEvents OnRowClick="RowContextMenu" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                </telerik:RadGrid>                               
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5" >
                            <telerik:RadContextMenu ID="RadContextMenu1" Runat="server" meta:resourcekey="RadContextMenu1Resource1" CssClass="auto-style1">
                                <Items>
                                    <telerik:RadMenuItem runat="server" Text="Detalles" meta:resourcekey="RadMenuItemResource1">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="Temas" meta:resourcekey="RadMenuItemResource2">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="Participación" meta:resourcekey="RadMenuItemResource3">
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem runat="server" Text="Estadisticos">
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadContextMenu>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5" >
                            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                            </telerik:RadScriptManager>
                            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Style="z-index: 7001" KeepInScreenBounds="True" meta:resourcekey="RadWindowManager1Resource1">  
                            <Windows>
                                <telerik:RadWindow ID="UserListDialog" runat="server" Title="Window" Height="700px"
                                    Width="900px" Left="" ReloadOnShow="True"
                                    Modal="true" Animation="Fade" InitialBehavior="None"           
                                    ToolTip="Gráfica que  agrupa los temas de los  estudios generados en la consulta" 
                                    Behavior="Close, Maximize" Behaviors="Close, Maximize" 
                                    VisibleStatusbar="False" meta:resourcekey="UserListDialogResource1" />
                                <telerik:RadWindow runat="server" 
                                    Behavior="Close, Maximize" Behaviors="Close, Maximize" 
                                    InitialBehavior="Maximize" InitialBehaviors="Maximize" Left="" Modal="True" 
                                    ReloadOnShow="True" Top="" ID="RadDetalles" Height="650px" 
                                    VisibleStatusbar="False" Width="850px" meta:resourcekey="RadDetallesResource1" >
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
    </form>
    <script src="js/jquery-3.2.1.min.js"></script>
     <script type="text/javascript">
         function showMenu(e) {
             var contextMenu = $find("RadContextMenu1");

             if ((!e.relatedTarget) || (!$telerik.isDescendantOrSelf(contextMenu.get_element(), e.relatedTarget))) {
                 contextMenu.show(e);
             }

             $telerik.cancelRawEvent(e);
         }


         $(document).ready(function () {
             var isHover = 0;

             //ocultar tr hijos
           //$("tr").each(function (index) {
           //      if ($(this).children(":first").html() == "-") {
           //          $(this).hide();
           //      }
           //  });

             $("tr").on("contextmenu", function () {
                 var title = $(this).children().eq(1).html();
                 console.log("title");
                 $("tr").each(function (index) {
                     if ($(this).children().eq(1).attr("title") == title) {
                         $(this).toggle(500);
                         //Sin efecto de desvanecer
                         //$(this).toggle();
                     }
                 });
                 return false;
             });

         });
    </script>
    
    
</body>
</html>

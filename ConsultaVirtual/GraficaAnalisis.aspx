<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GraficaAnalisis.aspx.vb" Inherits="ConsultaVirtual.GraficaAnalisis" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Charting" tagprefix="telerik" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Chart</title>
    <link href="Clases/EstiloPagina.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
                 function GetRadWindow() {
                     var oWindow = null;
                     if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                     else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
                     return oWindow;
                 }

                 function CloseOnReload() {
                     GetRadWindow().Close();
                 }

                 function CloseAndRedirect() {
                     var url = GetRadWindow().BrowserWindow.location.protocol + '//' + GetRadWindow().BrowserWindow.location.host + GetRadWindow().BrowserWindow.location.pathname
                     GetRadWindow().BrowserWindow.location.href = url;
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
    <table cellpadding="0" cellspacing="0" class="style1">
        <tr align="center" valign="middle">
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="4" cellspacing="4" class="style2">
                    <tr>
                        <td align="center">
                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                Font-Size="10pt" ForeColor="#990033" meta:resourcekey="LerrorResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="100%">
                            <asp:Panel ID="Panel1" runat="server" Visible="False" meta:resourcekey="Panel1Resource1">
                                <table style="border: 1px solid #C0C0C0; width:100%;">
                                    <tr>
                                        <td align="right" width="40%">
                                            <asp:Label ID="LComparativa" runat="server" Font-Bold="True" Font-Names="Arial" 
                                            Font-Size="10pt" ForeColor="Black" meta:resourceKey="LComparativaResource1">Nombre Comparativa</asp:Label>
                                        </td>
                                        <td align="left" width="30%">
                                            <telerik:RadTextBox ID="TComparativa" Runat="server" Width="90%" LabelCssClass="" LabelWidth="64px" meta:resourceKey="TComparativaResource1" Resize="None">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </telerik:RadTextBox>
                                        </td>
                                        <td align="left" width="30%">
                                            <telerik:RadButton ID="BGuardar" runat="server" Text="Guardar" meta:resourcekey="BGuardarPAResource1">
                                                <Icon PrimaryIconLeft="4px" PrimaryIconTop="4px" PrimaryIconUrl="Imagenes/COManager/Save16.png" />
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%">
                            <asp:Chart ID="Chart1" runat="server" BackColor="Gainsboro" BackGradientStyle="TopBottom" BorderlineColor="Black" BorderlineDashStyle="Solid" Height="600px" Width="800px" meta:resourcekey="Chart1Resource1">
                                <Legends>
                                    <asp:Legend AutoFitMinFontSize="6" BackColor="Transparent" BackSecondaryColor="White" 
                                                BorderColor="198, 206, 209" Font="Microsoft Sans Serif, 7pt" 
                                                HeaderSeparator="Line" InterlacedRows="True" InterlacedRowsColor="White" 
                                                IsTextAutoFit="False" Name="Legend1" TitleAlignment="Near">
                                                <Position Height="15" Width="88" X="8" Y="82" Auto="False" />
                                    </asp:Legend>
                                </Legends>
                                    <series>      
                                                                    <asp:Series CustomProperties="DrawingStyle=LightToDark, PointWidth=0.5, LabelStyle=Top" 
	                                                                    Font="Arial, 9pt, style=Bold" IsValueShownAsLabel="True" 
	                                                                    IsVisibleInLegend="False" Label="#VAL{N1}" MarkerSize="10" MarkerStyle="Star4" 
	                                                                    Name="Series1" YValuesPerPoint="6" ChartType="Line" Legend="Legend1">
	                                                                    <EmptyPointStyle BorderDashStyle="Dash" BorderWidth="1" Color="Black"/>
	                                                                    <smartlabelstyle calloutstyle="None" />
                                                                    </asp:Series>
                                                                     <asp:Series CustomProperties="DrawingStyle=LightToDark, PointWidth=0.5, LabelStyle=Top" 
	                                                                    Font="Arial, 9pt, style=Bold" IsValueShownAsLabel="True" 
	                                                                    IsVisibleInLegend="False" Label="#VAL{N1}" MarkerSize="10" MarkerStyle="Star4" 
	                                                                    Name="Series2" YValuesPerPoint="6" ChartType="Line" Legend="Legend1">
                                                                        <EmptyPointStyle BorderDashStyle="Dash" BorderWidth="1" Color="Black"/>
	                                                                    <smartlabelstyle calloutstyle="None" />
                                                                    </asp:Series>
                                                                     <asp:Series CustomProperties="DrawingStyle=LightToDark, PointWidth=0.5, LabelStyle=Top" 
	                                                                    Font="Arial, 9pt, style=Bold" IsValueShownAsLabel="True" 
	                                                                    IsVisibleInLegend="False" Label="#VAL{N1}" MarkerSize="10" MarkerStyle="Star4" 
	                                                                    Name="Series3" YValuesPerPoint="6" ChartType="Line" Legend="Legend1">
                                                                        <EmptyPointStyle BorderDashStyle="Dash" BorderWidth="1" Color="Black"/>
	                                                                    <smartlabelstyle calloutstyle="None" />
                                                                    </asp:Series>
                                                                     <asp:Series CustomProperties="DrawingStyle=LightToDark, PointWidth=0.5, LabelStyle=Top" 
	                                                                    Font="Arial, 9pt, style=Bold" IsValueShownAsLabel="True" 
	                                                                    IsVisibleInLegend="False" Label="#VAL{N1}" MarkerSize="10" MarkerStyle="Star4" 
	                                                                    Name="Series4" YValuesPerPoint="6" ChartType="Line" Legend="Legend1">
                                                                        <EmptyPointStyle BorderDashStyle="Dash" BorderWidth="1" Color="Black"/>
	                                                                    <smartlabelstyle calloutstyle="None" />
                                                                    </asp:Series>
                                                                     <asp:Series CustomProperties="DrawingStyle=LightToDark, PointWidth=0.5, LabelStyle=Top" 
	                                                                    Font="Arial, 9pt, style=Bold" IsValueShownAsLabel="True" 
	                                                                    IsVisibleInLegend="False" Label="#VAL{N1}" MarkerSize="10" MarkerStyle="Star4" 
	                                                                    Name="Series5" YValuesPerPoint="6" ChartType="Line" Legend="Legend1">
                                                                        <EmptyPointStyle BorderDashStyle="Dash" BorderWidth="1" Color="Black"/>
	                                                                    <smartlabelstyle calloutstyle="None" />
                                                                    </asp:Series>
                                                                     <asp:Series CustomProperties="DrawingStyle=LightToDark, PointWidth=0.5, LabelStyle=Top" 
	                                                                    Font="Arial, 9pt, style=Bold" IsValueShownAsLabel="True" 
	                                                                    IsVisibleInLegend="False" Label="#VAL{N1}" MarkerSize="10" MarkerStyle="Star4" 
	                                                                    Name="Series6" YValuesPerPoint="6" ChartType="Line" Legend="Legend1">
                                                                        <EmptyPointStyle BorderDashStyle="Dash" BorderWidth="1" Color="Black"/>
	                                                                    <smartlabelstyle calloutstyle="None" />
                                                                    </asp:Series>
                                                                     <asp:Series CustomProperties="DrawingStyle=LightToDark, PointWidth=0.5, LabelStyle=Top" 
	                                                                    Font="Arial, 9pt, style=Bold" IsValueShownAsLabel="True" 
	                                                                    IsVisibleInLegend="False" Label="#VAL{N1}" MarkerSize="10" MarkerStyle="Star4" 
	                                                                    Name="Series7" YValuesPerPoint="6" ChartType="Line" Legend="Legend1">
                                                                        <EmptyPointStyle BorderDashStyle="Dash" BorderWidth="1" Color="Black"/>
	                                                                    <smartlabelstyle calloutstyle="None" />
                                                                    </asp:Series>
                                                                     <asp:Series CustomProperties="DrawingStyle=LightToDark, PointWidth=0.5, LabelStyle=Top" 
	                                                                    Font="Arial, 9pt, style=Bold" IsValueShownAsLabel="True" 
	                                                                    IsVisibleInLegend="False" Label="#VAL{N1}" MarkerSize="10" MarkerStyle="Star4" 
	                                                                    Name="Series8" YValuesPerPoint="6" ChartType="Line" Legend="Legend1">
                                                                        <EmptyPointStyle BorderDashStyle="Dash" BorderWidth="1" Color="Black"/>
	                                                                    <smartlabelstyle calloutstyle="None" />
                                                                    </asp:Series>
                                                                     <asp:Series CustomProperties="DrawingStyle=LightToDark, PointWidth=0.5, LabelStyle=Top" 
	                                                                    Font="Arial, 9pt, style=Bold" IsValueShownAsLabel="True" 
	                                                                    IsVisibleInLegend="False" Label="#VAL{N1}" MarkerSize="10" MarkerStyle="Star4" 
	                                                                    Name="Series9" YValuesPerPoint="6" ChartType="Line" Legend="Legend1">
                                                                        <EmptyPointStyle BorderDashStyle="Dash" BorderWidth="1" Color="Black"/>
	                                                                    <smartlabelstyle calloutstyle="None" />
                                                                    </asp:Series>
                                                                     <asp:Series CustomProperties="DrawingStyle=LightToDark, PointWidth=0.5, LabelStyle=Top" 
	                                                                    Font="Arial, 9pt, style=Bold" IsValueShownAsLabel="True" 
	                                                                    IsVisibleInLegend="False" Label="#VAL{N1}" MarkerSize="10" MarkerStyle="Star4" 
	                                                                    Name="Series10" YValuesPerPoint="6" ChartType="Line" Legend="Legend1">
                                                                        <EmptyPointStyle BorderDashStyle="Dash" BorderWidth="1" Color="Black"/>
	                                                                    <smartlabelstyle calloutstyle="None" />
                                                                    </asp:Series>                
                                    </series>
                                <chartareas>
                                    <asp:ChartArea BackColor="White" BackSecondaryColor="Silver" IsSameFontSizeForAllAxes="True" Name="ChartArea1">
                                        <axisy intervalautomode="VariableCount" isinterlaced="True" maximum="110" minimum="10" title="EJE Y">
                                                <MajorGrid Enabled="False" />
                                            </axisy>
                                        <axisx interlacedcolor="White" intervalautomode="VariableCount" islabelautofit="False" title="EJE X">
                                                <MajorGrid Enabled="False" />
                                                <LabelStyle Angle="-90" />
                                                <ScaleBreakStyle BreakLineStyle="None" LineColor="" />
                                            </axisx>
                                            <InnerPlotPosition Auto="False" Height="70" Width="95" X="5" Y="2" />
                                            <Area3DStyle LightStyle="Realistic" />
                                     </asp:ChartArea>
                                </chartareas>
                                <titles>
                                    <asp:Title Font="Arial, 12pt, style=Bold" Name="Title1" Text="ENCABEZADO PRINCIPAL">
                                    </asp:Title>
                                    <asp:Title Font="Arial, 11pt, style=Bold" Name="Title2" Text="Titulo Dos">
                                            <Position Auto="False" Height="2.7" Width="91.37171" X="4.3141427" Y="8.5" />
                                        </asp:Title>
                                </titles>
                                    <BorderSkin BackColor="" BorderColor="" PageColor="" SkinStyle="Emboss" />
                                </asp:Chart>
                            <br />

                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" Culture="es-ES" meta:resourcekey="Grid2Resource1" ShowFooter="True" Width="790px" Height="500px" Visible="False" GroupPanelPosition="Top">
                                                                    <SortingSettings SortedAscToolTip="Reordenar Ascendente" SortedDescToolTip="Reordenar Descendente" />
                                                                    <ExportSettings ExportOnlyData="True" FileName="Comparativa" HideStructureColumns="True">
                                                                        <Excel FileExtension="xls" />
                                                                    </ExportSettings>
                                                                    <ClientSettings EnableRowHoverStyle="True">
                                                                        <Selecting AllowRowSelect="True" />
                                                                        <Scrolling AllowScroll="True" UseStaticHeaders="true" />
                                                                     
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
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <AlternatingItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle Font-Bold="True" Height="50px" HorizontalAlign="Center" />
                                                                        <CommandItemTemplate>
                                                                            <div style="margin-top: 0px; vertical-align: middle; text-align: left; width: 100%;">
                                                                                <table id="Table1" align="right" cellpadding="2" cellspacing="0"  style="width:100%;" width="100%" >
                                                                                <tr>
                                                                                <td align="right" valign="middle" width="94%"></td>
                                                                                <td align="right" valign="middle" width="3%">
                                                                                <asp:ImageButton ID="LKVer" runat="server" OnClick="Ver" ImageUrl="~/Imagenes/Estatus/chart_bar.png" ToolTip="Ver gráfica" meta:resourcekey="LKVerResource1"></asp:ImageButton>
                                                                                </td>
                                                                                <td align="right" valign="middle" width="3%">
                                                                                 <asp:ImageButton ID="LkExcel" runat="server" OnClick="Exportar" ImageUrl="~/Imagenes/Estatus/page_excel.png" meta:resourcekey="LkExcelResource1"></asp:ImageButton>
                                                                                </td>   
                                                                                </tr>
                                                                                </table>          
                                                                            </div>
                                                                        </CommandItemTemplate>
                                                                    </MasterTableView>
                                                                    <FilterMenu EnableEmbeddedSkins="False">
                                                                    </FilterMenu>
                                                                    <HeaderContextMenu EnableEmbeddedSkins="False">
                                                                    </HeaderContextMenu>
                             </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
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

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BusquedaComparativas.aspx.vb" Inherits="ConsultaVirtual.BusquedaComparativas" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Comparativas</title>
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
                                                          Enabled="False" AutoPostBack="True" Culture="es-ES" meta:resourcekey="RCBAgrupadoPaisesResource1">
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
                                                      <asp:Label ID="Label1" runat="server" Text="País" style="font-weight: 700" meta:resourcekey="Label1Resource1"></asp:Label>
                                                  </td>
                                                  <td align="left" >
                                                      <telerik:RadComboBox ID="RCBPais" Runat="server" MarkFirstMatch="True" 
                                                          Width="90%" AutoPostBack="True" EmptyMessage="Sin datos que mostrar" 
                                                          Enabled="False" Culture="es-ES" meta:resourcekey="RCBPaisResource1" >
                                                      </telerik:RadComboBox>
                                                  </td>
                                                  <td align="center" >
                                                      <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                                          RepeatDirection="Horizontal" Visible="False" AutoPostBack="True" 
                                                          style="margin-left: 0px" meta:resourcekey="RadioButtonList1Resource1">
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
                                                          Enabled="False" Culture="es-ES" meta:resourcekey="RCBSubRegionResource1">
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
                                                      <asp:Label ID="Label9" runat="server" Text="Rango de Año Actual" style="font-weight: 700" meta:resourcekey="Label9Resource1" 
                                                          ></asp:Label>
                                                  </td>
                                                  <td align="left" >
                                                      <telerik:RadComboBox ID="RCBAñoActual1" Runat="server" Width="75px" meta:resourcekey="RCBAñoActual1Resource1">
                                                      </telerik:RadComboBox>
                                                    &nbsp;<asp:Label ID="Label10" runat="server" Text="a" 
                                                          style="font-weight: 700" meta:resourcekey="Label10Resource1" ></asp:Label>
                                                    &nbsp;<telerik:RadComboBox ID="RCBAñoActual2" Runat="server" Width="75px" meta:resourcekey="RCBAñoActual2Resource1">
                                                      </telerik:RadComboBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td align="left" >
                                                      &nbsp;</td>
                                                  <td align="left" >
                                                      &nbsp;</td>
                                                  <td align="center" >
                                                      &nbsp;</td>
                                                  <td align="left" >
                                                      <asp:Label ID="Label14" runat="server" Text="Rango de Año Anterior" style="font-weight: 700" meta:resourcekey="Label14Resource1" 
                                                          ></asp:Label>
                                                  </td>
                                                  <td align="left" >
                                                      <telerik:RadComboBox ID="RCBAñoAnterior1" Runat="server" Width="75px" meta:resourcekey="RCBAñoAnterior1Resource1">
                                                      </telerik:RadComboBox>
                                                    &nbsp;<asp:Label ID="Label11" runat="server" Text="a" 
                                                          style="font-weight: 700" meta:resourcekey="Label11Resource1" ></asp:Label>
                                                    &nbsp;<telerik:RadComboBox ID="RCBAñoAnterior2" Runat="server" Width="75px" meta:resourcekey="RCBAñoAnterior2Resource1">
                                                      </telerik:RadComboBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td width="100%" align="center" colspan="5" valign="top">
                                                      
                                <telerik:RadGrid ID="Grid2" runat="server" AllowSorting="True"     
                        AutoGenerateColumns="False" Height="400px" 
                        ShowFooter="True" Width="98%" Culture="es-ES" meta:resourcekey="Grid2Resource1" GroupPanelPosition="Top">
                                    <SortingSettings SortedAscToolTip="Reordenar Ascendente" 
                                    SortedDescToolTip="Reordenar Descendente" />
                                    <ExportSettings ExportOnlyData="True" FileName="Comparativa" HideStructureColumns="True">
                                        <Excel FileExtension="xlsx" />
                                    </ExportSettings>
                                    <ClientSettings EnableRowHoverStyle="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView CommandItemDisplay="Top" Name="DIVISION">
                                        <CommandItemSettings AddNewRecordText="" ExportToExcelText="Exportar el contenido del Grid a un archivo Excel" RefreshText="Actualizar contenido" ShowAddNewRecordButton="False" ShowExportToExcelButton="True" />
                                        <Columns>
                                            <telerik:GridTemplateColumn FilterControlAltText="Filter C16 column" meta:resourcekey="GridTemplateColumnResource1" UniqueName="C16">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="Chk1" runat="server" Checked="True" meta:resourcekey="Chk1Resource1" OnClick="SetStatus(this);" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Chk2" runat="server" Checked="True" meta:resourcekey="Chk1Resource2" />
                                                </ItemTemplate>
                                                <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="CVE" Visible="False" FilterControlAltText="Filter C1 column" HeaderText="CVE" meta:resourcekey="GridBoundColumnResource1" UniqueName="C1">
                                                <HeaderStyle Width="0%" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CONCEPTO" FilterControlAltText="Filter C2 column" HeaderText="Concepto" meta:resourcekey="GridBoundColumnResource2" UniqueName="C2">
                                                <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ANIOESTUDIO" FilterControlAltText="Filter C13 column" HeaderText="Año" meta:resourcekey="GridBoundColumnResource3" UniqueName="C13">
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" Width="5%" Wrap="True" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PARTICIPACION_ANT" DataFormatString="{0:P1}" FilterControlAltText="Filter C10 column" HeaderText="Participación anterior" HeaderTooltip="Participación agrupada de los centros de  trabajo anteriores" meta:resourcekey="GridBoundColumnResource4" UniqueName="C10">
                                                <FooterStyle Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PARTICIPACION" DataFormatString="{0:P1}" DataType="System.Double" FilterControlAltText="Filter C5 column" HeaderText="Participación actual" HeaderTooltip="Participación agrupada de los centros de  trabajo anteriores" meta:resourcekey="GridBoundColumnResource5" UniqueName="C5">
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn FilterControlAltText="Filter C131 column" meta:resourcekey="GridTemplateColumnResource2" UniqueName="C131">
                                                <FooterTemplate>
                                                    <asp:Image ID="ImgAmarillaPA0" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Amarillo.png" meta:resourcekey="ImgAmarillaPA0Resource1" ToolTip="No existe Participación anterior/ Participación no cambio" Visible="False" Width="18px" />
                                                    <asp:Image ID="ImgVerdePA0" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Verde.png" meta:resourcekey="ImgVerdePA0Resource1" ToolTip="La participación subio en comparación con la evaluación anterior" Visible="False" Width="18px" />
                                                    <asp:Image ID="ImgRojaPA0" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Rojo.png" meta:resourcekey="ImgRojaPA0Resource1" ToolTip="La participación bajo en comparación con la evaluación anterior" Visible="False" Width="18px" />
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Image ID="ImgAmarillaPA1" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Amarillo.png" meta:resourcekey="ImgAmarillaPA0Resource2" ToolTip="No existe Participación anterior/ Participación no cambio" Visible="False" Width="18px" />
                                                    <asp:Image ID="ImgVerdePA1" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Verde.png" meta:resourcekey="ImgVerdePA0Resource2" ToolTip="La participación subio en comparación con la evaluación anterior" Visible="False" Width="18px" />
                                                    <asp:Image ID="ImgRojaPA1" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Rojo.png" meta:resourcekey="ImgRojaPA0Resource2" ToolTip="La participación bajo en comparación con la evaluación anterior" Visible="False" Width="18px" />
                                                </ItemTemplate>
                                                <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="PARTDIF" DataFormatString="{0:P1}" FilterControlAltText="Filter C14 column" HeaderText="Diferencia participación" meta:resourcekey="GridBoundColumnResource6" UniqueName="C14">
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PROMEDIO_ANT" DataFormatString="{0:N1}" FilterControlAltText="Filter C11 column" HeaderText="Promedio anterior" HeaderTooltip="Promedio agrupado de los centros de trabajo" meta:resourcekey="GridBoundColumnResource7" UniqueName="C11">
                                                <FooterStyle Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PROMEDIO" DataFormatString="{0:N1}" FilterControlAltText="Filter C6 column" HeaderText="Promedio actual" HeaderTooltip="Promedio agrupado de los centros de trabajo" meta:resourcekey="GridBoundColumnResource8" UniqueName="C6">
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn FilterControlAltText="Filter C15 column" meta:resourcekey="GridTemplateColumnResource3" UniqueName="C15">
                                                <FooterTemplate>
                                                    <asp:Image ID="ImgAmarilla1" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Amarillo.png" meta:resourcekey="ImgAmarilla1Resource1" ToolTip="No existe promedio anterior/ Promedio no cambio" Visible="False" Width="18px" />
                                                    <asp:Image ID="ImgVerde1" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Verde.png" meta:resourcekey="ImgVerde1Resource1" ToolTip="El promedio subio en comparación con la evaluación anterior" Visible="False" Width="18px" />
                                                    <asp:Image ID="ImgRoja1" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Rojo.png" meta:resourcekey="ImgRoja1Resource1" ToolTip="El promedio bajo en comparación con la evaluación anterior" Visible="False" Width="18px" />
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Image ID="ImgAmarilla2" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Amarillo.png" meta:resourcekey="ImgAmarilla1Resource2" ToolTip="No existe promedio anterior/ Promedio no cambio" Visible="False" Width="18px" />
                                                    <asp:Image ID="ImgVerde2" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Verde.png" meta:resourcekey="ImgVerde1Resource2" ToolTip="El promedio subio en comparación con la evaluación anterior" Visible="False" Width="18px" />
                                                    <asp:Image ID="ImgRoja2" runat="server" Height="18px" ImageUrl="~/Imagenes/20/32Rojo.png" meta:resourcekey="ImgRoja1Resource2" ToolTip="El promedio bajo en comparación con la evaluación anterior" Visible="False" Width="18px" />
                                                </ItemTemplate>
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="PROMDIF" DataFormatString="{0:N1}" FilterControlAltText="Filter C161 column" HeaderText="Diferencia promedio" meta:resourcekey="GridBoundColumnResource9" UniqueName="C161">
                                                <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="True" />
                                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ENCUESTADOS" DataType="System.Int64" Display="False" FilterControlAltText="Filter C3 column" HeaderText="ENCACT" HeaderTooltip="Número de personas que participaron en el centro de  trabajo" meta:resourcekey="GridBoundColumnResource10" UniqueName="C3">
                                                <HeaderStyle Width="0%" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PERSONAL" DataType="System.Int64" Display="False" FilterControlAltText="Filter C4 column" HeaderText="PERACT" HeaderTooltip="Número total de personas que  integran el centro de  trabajo" meta:resourcekey="GridBoundColumnResource11" UniqueName="C4">
                                                <HeaderStyle Width="0%" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CALCULO" Display="False" FilterControlAltText="Filter C7 column" HeaderText="CALCULO" HeaderTooltip="Número total de personas que  integran el centro de  trabajo" meta:resourcekey="GridBoundColumnResource12" UniqueName="C7">
                                                <HeaderStyle Width="0%" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ENCUESTADOS_ANT" Display="False" FilterControlAltText="Filter C8 column" HeaderText="ENCANT" HeaderTooltip="Número de personas que participaron en el centro de  trabajo anterior." meta:resourcekey="GridBoundColumnResource13" UniqueName="C8">
                                                <HeaderStyle Width="0%" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PERSONAL_ANT" Display="False" FilterControlAltText="Filter C9 column" HeaderText="PERANT" HeaderTooltip="Número total de personas que  integran el centro de  trabajo  anterior." meta:resourcekey="GridBoundColumnResource14" UniqueName="C9">
                                                <HeaderStyle Width="0%" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CALCULO_ANT" Display="False" FilterControlAltText="Filter C12 column" HeaderText="CALCULO_ANT" meta:resourcekey="GridBoundColumnResource15" UniqueName="C12">
                                                <HeaderStyle Width="0%" />
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <HeaderStyle Height="50px" />
                                        <FooterStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="True" />
                                        <CommandItemTemplate>
                                            <table style="width:100%;">
                                                <tr>
                                                    <td align="left" width="94%">
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
                                                        <asp:ImageButton ID="LkActualizar" runat="server" OnClick="Actualizar" ImageUrl="~/Imagenes/Estatus/Refresh.png" ToolTip="Actualizar contenido" meta:resourcekey="LkActualizarResource1" />
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:ImageButton ID="LkExcel" runat="server" OnClick="Exportar" ImageUrl="~/Imagenes/Estatus/page_excel.png" ToolTip="Exportar" meta:resourcekey="LkExcelResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                    </MasterTableView>
                                    <FooterStyle Font-Bold="True" />
                                    <HeaderStyle Height="30px" />
                                    <FilterMenu EnableEmbeddedSkins="False">
                                    </FilterMenu>
                                    <HeaderContextMenu EnableEmbeddedSkins="False">
                                    </HeaderContextMenu>
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
                                                                      Behavior="Close, Maximize" Behaviors="Close, Maximize" Height="700px" 
                                                                      Modal="True" ReloadOnShow="True"
                                                                      VisibleStatusbar="False" Width="900px" meta:resourcekey="UserListDialogResource1" />
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

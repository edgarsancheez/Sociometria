<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MenuPrincipalAnterior.aspx.vb" Inherits="ConsultaVirtual.MenuPrincipalAnterior" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="X-UA-Compatible" content="IE=Edge" />

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Menú Principal</title>
    <link href="Clases/EstiloPagina.css" rel="stylesheet" type="text/css" />
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
                          <td align="center" height="23">
                              &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="center" height="23">
                                                      <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                          Font-Size="10pt" ForeColor="White" meta:resourcekey="LerrorResource1"></asp:Label>
                                                  </td>
                      </tr>
                      <tr>
                          <td align="center">
                              <table style="width: 400px;">
                                  <tr>
                                      <td align="center" colspan="2" rowspan="2">
                                          <telerik:RadImageAndTextTile ID="RTDashboard" runat="server" ForeColor="White" Height="415px" ImageHeight="415px" ImageUrl="~/Imagenes/TileList/4.jpg" 
                                              ImageWidth="400px" Name="Consulta" NavigateUrl="~/BusquedaGeneral.aspx" Shape="Wide" style="top: 0px; left: 0px" Target="_self" Width="400px" meta:resourcekey="RTDashboardResource1">
                                              <Title Text="Dashboard"></Title>
                                              <PeekTemplateSettings Animation="Slide" AnimationDuration="500" CloseDelay="7000" Easing="easeInQuint" HidePeekTemplateOnMouseOut="true" ShowInterval="0" ShowPeekTemplateOnMouseOver="true" />
                                          </telerik:RadImageAndTextTile>
                                      </td>
                                      <td align="center">
                                          <telerik:RadImageAndTextTile ID="RTComparativas" runat="server" ForeColor="White" Height="200px" ImageHeight="200px" ImageUrl="~/Imagenes/TileList/1.jpg" 
                                              ImageWidth="200px" Name="Comparativas" NavigateUrl="~/BusquedaComparativas.aspx" Shape="Wide" style="top: 0px; left: 0px" Target="_self" Width="200px" meta:resourcekey="RTComparativasResource1">
                                              <Title Text="Comparativas"></Title>
                                              <PeekTemplateSettings Animation="Slide" AnimationDuration="500" CloseDelay="7000" Easing="easeInQuint" HidePeekTemplateOnMouseOut="true" ShowInterval="0" ShowPeekTemplateOnMouseOver="true" />
                                          </telerik:RadImageAndTextTile>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="center">
                                          <telerik:RadImageAndTextTile ID="RTBenchmark" runat="server" ForeColor="White" Height="200px" ImageHeight="200px" ImageUrl="~/Imagenes/TileList/3.jpg" 
                                              ImageWidth="200px" Name="Benchmark" NavigateUrl="~/BusquedaBenchTemas.aspx" Shape="Wide" style="top: 0px; left: 0px" Target="_self" Width="200px" meta:resourcekey="RTBenchmarkResource1">
                                              <Title Text="Benchmark"></Title>
                                              <PeekTemplateSettings Animation="Slide" AnimationDuration="500" CloseDelay="7000" Easing="easeInQuint" HidePeekTemplateOnMouseOut="true" ShowInterval="0" ShowPeekTemplateOnMouseOver="true" />
                                          </telerik:RadImageAndTextTile>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="center" colspan="3">
                                          <telerik:RadImageAndTextTile ID="RTAnalisis" runat="server" ForeColor="White" Height="200px" ImageHeight="200px" ImageUrl="~/Imagenes/TileList/2.jpg"
                                              ImageWidth="630px" Name="Analisis" NavigateUrl="~/AnalisisInformacion.aspx" Shape="Wide" style="top: 0px; left: 0px" Target="_self" Width="630px" meta:resourcekey="RTAnalisisResource1">
                                              <Title Text="Análisis de Información"></Title>
                                              <PeekTemplateSettings Animation="Slide" AnimationDuration="500" CloseDelay="7000" Easing="easeInQuint" HidePeekTemplateOnMouseOut="true" ShowInterval="0" ShowPeekTemplateOnMouseOver="true" />
                                          </telerik:RadImageAndTextTile>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="center">
                                          <telerik:RadImageAndTextTile ID="RTPresentacion" runat="server" ForeColor="White" Height="200px" ImageHeight="200px" ImageUrl="~/Imagenes/TileList/107.jpg" 
                                              ImageWidth="200px" Name="Presentacion" NavigateUrl="~/ReporteEjecutivo.aspx"  Shape="Wide" style="top: 0px; left: 0px" Target="_self" Width="200px" meta:resourcekey="RTPresentacionResource1">
                                              <Title Text="Presentación Ejecutiva"></Title>
                                              <PeekTemplateSettings Animation="Slide" AnimationDuration="500" CloseDelay="7000" Easing="easeInQuint" HidePeekTemplateOnMouseOut="true" ShowInterval="0" ShowPeekTemplateOnMouseOver="true" />
                                          </telerik:RadImageAndTextTile>
                                      </td>
                                      <td align="center">
                                          <telerik:RadImageAndTextTile ID="RTManual" runat="server" ForeColor="White" Height="200px" ImageHeight="200px" ImageUrl="~/Imagenes/TileList/103.jpg" 
                                              ImageWidth="200px" Name="Manual" NavigateUrl="~/Presentaciones/ManualEntregaVirtual.pptx" Shape="Wide" style="top: 0px; left: 0px" Target="_self" Width="200px" meta:resourcekey="RTManualResource1">
                                              <Title Text="Manual de Usuario"></Title>
                                              <PeekTemplateSettings Animation="Slide" AnimationDuration="500" CloseDelay="7000" Easing="easeInQuint" HidePeekTemplateOnMouseOut="true" ShowInterval="0" ShowPeekTemplateOnMouseOver="true" />
                                          </telerik:RadImageAndTextTile>
                                      </td>
                                      <td align="center" style="font-weight: 700">
                                          <telerik:RadImageAndTextTile ID="RTTutorial" runat="server" ForeColor="White" Height="200px" ImageHeight="200px" ImageUrl="~/Imagenes/TileList/106.jpg" 
                                              ImageWidth="200px" Name="Tutorial" NavigateUrl="~/Presentaciones/TutorialVF.pdf" Shape="Wide" style="top: 0px; left: 0px" Target="_self" Width="200px" meta:resourcekey="RTTutorialResource1">
                                              <Title Text="Tutorial de Engagement"></Title>
                                              <PeekTemplateSettings Animation="Slide" AnimationDuration="500" CloseDelay="7000" Easing="easeInQuint" HidePeekTemplateOnMouseOut="true" ShowInterval="0" ShowPeekTemplateOnMouseOver="true" />
                                          </telerik:RadImageAndTextTile>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="center" colspan="3">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
                                      </td>
                                  </tr>
                              </table>
                          </td>
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

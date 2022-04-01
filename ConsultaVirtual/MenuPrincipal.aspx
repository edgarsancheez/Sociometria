<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MenuPrincipal.aspx.vb" Inherits="ConsultaVirtual.MenuPrincipal" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="X-UA-Compatible" content="IE=Edge" />

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Menú Principal</title>
    <link href="Clases/EstiloPagina.css" rel="stylesheet" type="text/css" />
    <link href="Clases/Menu.css" rel="stylesheet" type="text/css" />
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
                              <table style="width: 800px;" cellpadding="5px" cellspacing="5px">
                                  <tr>
                                      <td align="center" rowspan="2" style="width: 300px;">
                                          <div class="efecto">
                                                <a iD="DASHBOARD" runat="server"   class="hovertext1" href="BusquedaGeneral.aspx" title="Dashboard">
                                                    <img src="Imagenes/TileList/Dashboard.jpg" width="300px" height="420px" border="0" alt="" /></a>
                                          </div>
                                      </td>
                                      <td align="center" style="width: 300px;">
                                          <div class="efecto">
                                                <a iD="BENCH" runat="server"  class="hovertext2" href="BusquedaBenchTemas.aspx" title="Benchmark">
                                                    <img src="Imagenes/TileList/Benchmark.jpg" width="300px" height="200px" border="0" alt="" /></a>
                                            </div>
                                      </td>
                                      <td align="center" style="width: 300px;">
                                          <div class="efecto">
                                                <a iD="PRESEJ" runat="server" class="hovertext2" href="ReporteEjecutivo.aspx" title="Presentación Ejecutiva">
                                                    <img src="Imagenes/TileList/PlanTrabajo.jpg" width="300px" height="200px" border="0" alt="" /></a>
                                               </div>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="center" rowspan="2">
                                          <div class="efecto">
                                                <a iD="ANALISIS" runat="server" class="hovertext1" href="AnalisisInformacion.aspx" title="Análisis de Información">
                                                    <img src="Imagenes/TileList/AnálisisInformacion.jpg" width="300px" height="420px" border="0" alt="" /></a>
                                            </div>
                                        </td>
                                      <td align="center">
                                          <div class="efecto">
                                                <a iD="MANUAL" runat="server" class="hovertext2" href="Presentaciones/Manual Entrega Virtual V2.1.pdf" title="Manual de Usuario">
                                                    <img src="Imagenes/TileList/ManualUsuario.jpg" width="300px" height="200px" border="0" alt="" /></a>
                                            </div>
                                        </td>
                                  </tr>
                                  <tr>
                                      <td align="center">
                                          <div class="efecto">
                                                <a iD="COMPARATIVAS" runat="server" class="hovertext2" href="BusquedaComparativas.aspx" title="Comparativas">
                                                    <img src="Imagenes/TileList/109.jpg" width="300px" height="200px" border="0" alt="" /></a>
                                            </div>
                                      </td>
                                      <td align="center">
                                           <div class="efecto">
                                                <a iD="TUTORIAL" runat="server" class="hovertext2" href="Presentaciones/TutorialVF.pdf" title="Tutorial Engagement">
                                                    <img src="Imagenes/TileList/106.jpg" width="300px" height="200px" border="0" alt="" /></a>
                                            </div>
                                    </td>
                                  </tr>
                                  <tr runat="server" id="Codrive" visible="false">
                                      <td align="center" colspan="3">
                                      
                                          
                                          <div class="efecto">
                                                <a iD="A1" runat="server" class="hovertext3" href="CoDrive.aspx" title="CoDrive">
                                                    <img src="Imagenes/CoDrive/Virtualisation_cloud_Fotolia.jpg" width="940px" height="200px" border="0" alt="" /></a>
                                          </div>
                                         
                                      
                                      
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

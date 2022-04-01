<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Acceso.aspx.vb" Inherits="ConsultaVirtual.Acceso" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Portal Clima</title>
    <link href="Clases/EstiloPagina1.css" rel="stylesheet" type="text/css" />
                
    <meta http-equiv="X-UA-Compatible" content="IE=8; IE=9;IE=10; IE=11;IE=EDGE" />

        <style type="text/css">             
            .RadButton.css3Grad {
             border: 1px solid dimgray;
             background-color: #3B5998;
        }

        .RadButton.css3Grad:hover {
             border: 1px solid dimgray;
             background-color: #8b9dc3;
        }
        #form1 {
            height: 800px;
        }
        body {
 background: url("Imagenes/fondo.jpg") no-repeat center center fixed;
  background-size: cover;
  height: 100%;
  overflow: hidden;
}
            </style>

</head>
<body>
    <form id="form1" runat="server"  defaultbutton="BLogIn" defaultfocus="TUsuario">
      <table cellpadding="0" cellspacing="0" class="style1">
          <tr>
              <td align="center">
                  <table cellpadding="0" cellspacing="0" class="style1">
                      <tr>
                          <td align="left" 
                              style="background-position: center; background-image: url('Imagenes/Background/Banner.png'); background-repeat: no-repeat;" 
                              valign="bottom" >
                          </td>
                      </tr>
                      <tr>
                          <td align="center" height="40px" style="color: #FFFFFF; font-size: 32px;" valign="middle">
                            <table style="width: 95%;">
                                <tr>
                                    <td align="right" height="5px" style="color: #FFFFFF; font-size: 32px;" valign="middle" >
                                          </td>
                                </tr>
                                <tr>
                                    <td align="right" height="40px" style="color: #FFFFFF; font-size: 32px;" valign="middle">
                                          <asp:ImageButton ID="IB1" runat="server" ImageUrl="~/Imagenes/Generales/spain1.png" ToolTip="Spanish" meta:resourcekey="IB1Resource1" />&nbsp;|
                                          <asp:ImageButton ID="IB2" runat="server" ImageUrl="~/Imagenes/Generales/brazil1.png" ToolTip="Portuguese" meta:resourcekey="IB2Resource1" />&nbsp;|
                                          <asp:ImageButton ID="IB3" runat="server" ImageUrl="~/Imagenes/Generales/usa.png" ToolTip="English" meta:resourcekey="IB3Resource1" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                          </td>
                      </tr>
                      <tr>
                          <td align="right" height="40px">
                              &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="right" height="40px">
                              &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="right" height="40px">
                              &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="right" height="40px">
                              &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="right">
                              &nbsp;</td>
                      </tr>
                      <tr>
                          <td>
                              <table cellpadding="0" cellspacing="0" align="center">
                                  <tr>
                                      <td valign="middle" align="center">
                                          <table cellpadding="4" cellspacing="4" border="0" width="400px" class="style3">
                                              <tr>
                                                  <td colspan="2" width="100%" align="center">
                                                      &nbsp;</td>
                                              </tr>
                                              <tr>
                                                  <td align="right" width="30%">
                                                      <asp:Label ID="LUsuario" runat="server" Font-Italic="False" Font-Names="Arial" Font-Size="10pt" Text="Usuario:"
                                                          meta:resourcekey="LUsuarioResource1" ForeColor="White"></asp:Label>
                                                  </td>
                                                  <td align="left" width="70%">
                                                      <telerik:RadTextBox ID="TUsuario" Runat="server" 
                                                          Width="90%" MaxLength="20" LabelWidth="40%" Resize="None" meta:resourcekey="TUsuarioResource1">
                                                      </telerik:RadTextBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td align="right" width="30%">
                                                      <asp:Label ID="LContraseña" runat="server" Font-Italic="False" Font-Names="Arial" Font-Size="10pt" Text="Contraseña:"
                                                          meta:resourcekey="LContraseñaResource1" ForeColor="White"></asp:Label>
                                                  </td>
                                                  <td align="left" width="70%">
                                                      <telerik:RadTextBox ID="TPassword" Runat="server" 
                                                          Width="90%" MaxLength="20" TextMode="Password" 
                                                          LabelWidth="40%" Resize="None" type="password" meta:resourcekey="TPasswordResource1">
                                                      </telerik:RadTextBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td align="right" width="30%">
                                                      &nbsp;</td>
                                                  <td align="left" width="70%">
                                                      <telerik:RadButton ID="BLogIn" runat="server" CssClass="css3Grad" Font-Bold="True" Skin="Glow" Text="Log in" ForeColor="White" Font-Size="12pt" meta:resourcekey="BLogInResource1" style="position: relative;">
                                                      </telerik:RadButton>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td colspan="2" width="100%" align="center" >
                                                      &nbsp;</td></tr>
                                              <tr>
                                                  <td colspan="2" width="100%" align="center" >
                                                      <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Names="Arial" Font-Size="10pt" Text="* Ingrese con su usuario y contraseña del portal Connect"
                                                          meta:resourcekey="Label1Resource1" ForeColor="White"></asp:Label>
                                                  </td></tr><tr>
                                                  <td colspan="2" width="100%" align="center" >
                                                      <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                          Font-Size="10pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label></td></tr><tr>
                                                  <td colspan="2" width="100%" align="center" >
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
                                          <telerik:RadWindowManager ID="RadWindowManager1" runat="server" meta:resourcekey="RadWindowManager1Resource1">
                                          </telerik:RadWindowManager>
                                                  </td></tr></table>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                      </tr>
                    <tr>
                        <td align="right">
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
    </form></body>
</html>

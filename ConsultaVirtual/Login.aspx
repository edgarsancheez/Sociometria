<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="ConsultaVirtual.Login" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sociometría</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" rel="stylesheet" />              
    <meta http-equiv="X-UA-Compatible" content="IE=8; IE=9;IE=10; IE=11;IE=EDGE" />

</head>
<body style="background-color: #003459;">
<div class="vh-100" >
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col col-xl-10">
        <div class="card" style="border-radius: 1rem;">
          <div class="row g-0">
            <div class="col-md-6 col-lg-5 d-none d-md-block">
              <img
                src="https://mdbootstrap.com/img/Photos/new-templates/bootstrap-login-form/img1.jpg"
                alt="login form"
                class="img-fluid" style="border-radius: 1rem 0 0 1rem;"
              />
            </div>
            <div class="col-md-6 col-lg-7 d-flex align-items-center">
              <div class="card-body p-4 p-lg-5 text-black">

                <form runat="server" >

                  <div class="d-flex align-items-center mb-3 pb-1">
                    <i class="fas fa-cubes fa-2x me-3" style="color: #ff6219;"></i>
                    <span class="h1 fw-bold mb-0">Sociometría</span>
                  </div>

                  <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Iniciar Sesión</h5>

                  <div class="form-outline mb-4">
                    <input type="text" runat="server" id="text_noempleado" class="form-control form-control-lg" />
                    <label class="form-label" for="form2Example17">No. Empleado</label>
                  </div>

                  <div class="form-outline mb-4">
                    <input type="password" runat="server" id="text_contrasena" class="form-control form-control-lg" />
                    <label class="form-label" for="form2Example27">Contraseña</label>
                  </div>

                  <div class="pt-1 mb-4">
                    <button class="btn btn-dark btn-lg btn-block" runat="server" id="Btn_Login" type="button">Login</button>
                  </div>

                  <a class="small text-muted" href="#!">Forgot password?</a>
                  <p class="mb-5 pb-lg-2" style="color: #393f81;">Ingrese con su usuario y contraseña del portal Connect</p>
<%--                  <a href="#!" class="small text-muted">Terms of use.</a>
                  <a href="#!" class="small text-muted">Privacy policy</a>--%>

                    <div class="container">
                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label>
<%--                            <telerik:RadButton ID="BLogIn" runat="server" CssClass="css3Grad" Font-Bold="True" Skin="Glow" Text="Log in" ForeColor="White" Font-Size="12pt" 
                                meta:resourcekey="BLogInResource1" style="position: relative;">  </telerik:RadButton>
                            <telerik:RadTextBox ID="TUsuario" Runat="server"  Width="90%" MaxLength="20" LabelWidth="40%" Resize="None" meta:resourcekey="TUsuarioResource1">  </telerik:RadTextBox>
                            <telerik:RadTextBox ID="TPassword" Runat="server"  Width="90%" MaxLength="20" TextMode="Password" 
                                LabelWidth="40%" Resize="None" type="password" meta:resourcekey="TPasswordResource1"> </telerik:RadTextBox>--%>
                            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                            </telerik:RadScriptManager>
                            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" meta:resourcekey="RadWindowManager1Resource1">
                            </telerik:RadWindowManager>
                    </div>


                </form>

              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>

<%--        <asp:Label ID="LUsuario" runat="server" Font-Italic="False" Font-Names="Arial" Font-Size="10pt" Text="Usuario:"
            meta:resourcekey="LUsuarioResource1" ForeColor="White"></asp:Label>
        <asp:Label ID="LContraseña" runat="server" Font-Italic="False" Font-Names="Arial" Font-Size="10pt" Text="Contraseña:"
            meta:resourcekey="LContraseñaResource1" ForeColor="White"></asp:Label>

        <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Names="Arial" Font-Size="10pt" Text="* Ingrese con su usuario y contraseña del portal Connect"
            meta:resourcekey="Label1Resource1" ForeColor="White"></asp:Label>
                      
--%>

</body>

<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js" ></script>
<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.min.js" ></script>
</html>

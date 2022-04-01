<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Head1.ascx.vb" Inherits="ConsultaVirtual.Head1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

            <style type="text/css">             
        body {
        background-image: url("Imagenes/fondo.jpg");
        border-image-width: 100%;
}
            </style>
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Dancing+Script">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto">
</head>
<body>
  <div class="container">
    <header>
      <div class="menu-toggle" data-js="menu-toggle">
        <span class="menu-toggle-grippy">Toggle</span>
        <span class="menu-toggle-label">Menu</span>
      </div>
    </header>
      
    <section class="banner" role="banner">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

      <h1>Portal Clima Organizacional</h1>
    <br />
    <br />
      <h2>El éxito no es la clave de la felicidad. La felicidad es la clave del éxito</h2>
    </section>
    
    <div class="hidden-panel">
      
      <span class="hidden-panel-close" data-js="hidden-panel-close">Cerrar</span>
      
      <div class="hidden-panel-content">
        
        <nav class="hidden-panel-nav">
          <h3>Portal Clima</h3>
          <ul>
            <li><a href="BusquedaGeneral.aspx">Dashboard</a></li>
              <br />
              <br />
            <li><a href="BusquedaBenchTemas.aspx">Benchmark</a></li>
              <br />
              <br />
            <li><a href="AnalisisInformacion.aspx">Análisis de Información</a></li>
              <br />
              <br />
            <li><a href="AnalisisInformacion.aspx">Panel de Información</a></li>
              <br />
              <br />
            <li><a href="BusquedaComparativas.aspx">Comparativas</a></li>
              <br />
              <br />
            <li><a href="ReporteEjecutivo.aspx">Presentación Ejecutiva</a></li>
          </ul>
        </nav>
        
        <div class="hidden-panel-text">
          <p>This is an experimental CodePen which utilises an absolutely positioned hidden panel which can be triggered by clicking a toggle.</p>
        </div>

        <div class="hidden-panel-credits">
          <span>Coded by <a href="https://twitter.com/darrenhuskie" title="Darren Huskie">Darren Huskie</a>.</span>
          <span>Powered by <a href="#" title="some framework">some framework</a>.</span>
          <span>Hosted by a <a href="#" title="web host">web host</a>.</span>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
                  <form ID="frm1" runat="server">
           &nbsp;&nbsp;&nbsp;&nbsp;


           <asp:ImageButton ID="IB1" runat="server" ImageUrl="~/Imagenes/Generales/spain1.png" ToolTip="Spanish" meta:resourcekey="IB1Resource1" OnClick="IB1_Click" />&nbsp;&nbsp; &nbsp;|&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="IB2" runat="server" ImageUrl="~/Imagenes/Generales/brazil1.png" ToolTip="Portuguese" meta:resourcekey="IB2Resource1" OnClick="IB2_Click" />&nbsp;&nbsp; &nbsp;|&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="IB3" runat="server" ImageUrl="~/Imagenes/Generales/usa.png" ToolTip="English" meta:resourcekey="IB3Resource1" OnClick="IB3_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
               </form>

      </div>
    </div>
    </div>


</body>
    <script src="js/Ejemplo11.js"></script>
      <link rel="stylesheet" href="clases/Ejemplo11.css">
</html>

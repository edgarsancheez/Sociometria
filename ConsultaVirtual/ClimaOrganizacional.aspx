<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ClimaOrganizacional.aspx.vb" Inherits="ConsultaVirtual.ClimaOrganizacional" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="X-UA-Compatible" content="IE=Edge" />

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Clima Organizacional</title>

   <link href="Clases/videopopup.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body {
 background: url("Imagenes/fondo.jpg") no-repeat center center fixed;
  background-size: cover;
  height: 100%;
  overflow: hidden;
}
.style1 {
    width: 100%;
    background-color: transparent;
    border-bottom-color: transparent;
    border-color: transparent;
}

        .RadMenu .rmGroup .rmText
        {
            text-align: left !important; 
        }

        .RadImageGallery .rigItemBox .rigActiveImage img {
            padding: 0 !important;
        }
        .auto-style2 {
            height: 25px;
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
                          <td align="left" 
                              style="background-position: center; background-image: url('Imagenes/Background/Banner.png'); background-repeat: no-repeat;" 
                              valign="bottom">
                          </td>
                      </tr>
                      <tr>
                          <td align="center" height="23">
                              &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="left" height="23">
                                                         <telerik:RadButton ID="BContinuar" runat="server" CssClass="css3Grad" Font-Bold="True" Skin="Glow" Text="Continuar" ForeColor="White" Font-Size="12pt" meta:resourcekey="BContinuarResource1" style="position: relative; top: 4px;">
                                                      </telerik:RadButton>
                                                  &nbsp;
                                                  <br />
                          </td>
                      </tr>
                      <tr>
                          <td align="center" height="23">
                                                      <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                          Font-Size="10pt" ForeColor="White" meta:resourcekey="LerrorResource1"></asp:Label>
                                                  </td>
                      </tr>
                      <tr>
                          <td align="center">
                              <table style="width: 800px;">
                                  <tr>
                                      <td align="right" class="auto-style2">
                                                      &nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td id="td1" align="center">
                                          <telerik:RadImageGallery ID="RadImageGallery1" runat="server" Width="800px" meta:resourcekey="RadImageGallery1Resource1" Visible="false">
                                              <Items>
                                                  
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONESP/Slide1.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONESP/Slide2.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONESP/Slide3.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONESP/Slide4.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONESP/Slide5.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONESP/Slide6.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONESP/Slide7.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONESP/Slide8.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONESP/Slide9.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONESP/Slide10.JPG" Title="" 
                                                    Description="" />
<%--                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONESP/Slide11.JPG" Title="" 
                                                    Description="" />--%>
                                              
                                            </Items>
                                            <ThumbnailsAreaSettings Mode="ImageSliderPreview" />
                                            <ImageAreaSettings Height="550px" />
                                            <ToolbarSettings ShowSlideshowButton="False" />
                                            <ClientSettings>
                                                <AnimationSettings>
                                                    <NextImagesAnimation Easing="Random" Type="Random" />
                                                    <PrevImagesAnimation Easing="Random" Type="Random" />
                                                </AnimationSettings>
                                            </ClientSettings>
                                          </telerik:RadImageGallery>

                                            <telerik:RadImageGallery ID="RadImageGalleryENG" Visible="false" runat="server" Width="800px" meta:resourcekey="RadImageGallery1Resource1">
                                              <Items>
                                                  
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONENG/Slide1.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONENG/Slide2.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONENG/Slide3.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONENG/Slide4.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONENG/Slide5.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONENG/Slide6.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONENG/Slide7.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONENG/Slide8.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONENG/Slide9.JPG" Title="" 
                                                    Description="" />
                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONENG/Slide10.JPG" Title="" 
                                                    Description="" />
<%--                                                <telerik:ImageGalleryItem ImageUrl="Imagenes/PRESENTACIONENG/Slide11.JPG" Title="" 
                                                    Description="" />--%>
                                              
                                            </Items>
                                            <ThumbnailsAreaSettings Mode="ImageSliderPreview" />
                                            <ImageAreaSettings Height="550px" />
                                            <ToolbarSettings ShowSlideshowButton="False" />
                                            <ClientSettings>
                                                <AnimationSettings>
                                                    <NextImagesAnimation Easing="Random" Type="Random" />
                                                    <PrevImagesAnimation Easing="Random" Type="Random" />
                                                </AnimationSettings>
                                            </ClientSettings>
                                          </telerik:RadImageGallery>
<%--                                         <telerik:RadMediaPlayer ID="RadMediaPlayer1" RenderMode="Lightweight" runat="server" HDActive="True" Title="Clima Organizacional" HDSource= "/Videos/Clima_organizacional_HD.mp4" Height="400px" Source="~/Videos/Clima_organizacional.mp4" Width="800px">
                                              <Sources>
                                                  <telerik:MediaPlayerSource IsHD="False" MimeType="" Path="" />
                                              </Sources>
                                            <PlaylistSettings Mode="Buttons" ButtonsTrigger="Hover"></PlaylistSettings>
                                         </telerik:RadMediaPlayer>--%>

                                          
                                            <div id="vidBox">
                                            </div>

                                            <a hidden href="javascript:void(0)" id="video-trigger">Open</a>

                                          <br />
                                          <br />
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="center">
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

    
    <script src="/js/jquery-3.2.1.min.js"></script>
    <script src="/js/videopopup.js"></script>
    <script src="/js/js.cookie.js"></script>

   <%-- VIDEO HECHO CON JQUERY--%>

<%--    <script>
        (function () {




            if (Cookies.get('alreadyPlayed') == undefined || Cookies.get('alreadyPlayed') == null) {
                Cookies.set('alreadyPlayed', 'none');
                // video settings
                $('#vidBox').VideoPopUp({
                    opener: "video-trigger",
                    idvideo: "videoPlayer",
                    backgroundColor: "#000000",
                    pausevideo: true,
                    maxweight: "640"
                });
                // video trigger
                $('#video-trigger').trigger('click');
            } else {
                $('#videoPlayer').remove(); // aqui se remueve el video si ya se encuentra una cookie
            }
        })();

 

        $('#videoPlayer').on('ended', function () {  // evento donde termina el video
             $('#closer_videopopup').trigger('click');  // auto click con jquery en div de tachita 
        });




    </script>--%>
</html>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CoDrive.aspx.vb" Inherits="ConsultaVirtual.CoDrive" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX"%>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="X-UA-Compatible" content="IE=Edge" />

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
      <table cellpadding="0" cellspacing="0" class="style1" align="center">
          <tr>
              <td align="center">
                  <table cellpadding="0" cellspacing="0" class="style1">
                      <tr>
                          <td align="left" height="46px" 
                              style="background-position: center; background-image: url('Imagenes/Background/Banner.png'); background-repeat: no-repeat;" 
                              valign="bottom">
                              <uc2:Head ID="Head2" runat="server" EnableTheming="True" 
                                  EnableViewState="False" />
                          </td>
                      </tr>
                      <tr>
                          <td align="center" height="23px">
                              &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="center" height="23px">
                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                Font-Size="10pt" ForeColor="White" meta:resourcekey="LerrorResource1"></asp:Label>
                          </td>
                       
                       
                         </tr>

                      <tr>
                          
                        <td align="center" height="10px">
                            
                        </td>
                         </tr>
                      <tr >
                        <td align="center">

                               <table style="width: 85%;" cellpadding="5px" cellspacing="5px">

                                  <tr>
                                      <td align="left" rowspan="2" style="width: 100%; padding-left:100px">


                                            <table>
                                                   <tr style="width: 100%; ">
                                                        
                                                       <td style="width:350px; height:150px">
                                                           <div class="efecto">
                                                            <a iD="A1" runat="server"   class="hovertext1" href="HabilitarEncuesta.aspx" title="">
                                                                <img src="Imagenes/CoDrive/Picture1.png" width="350px" height="150px" border="0" alt="" />

                                                            </a>
                                                           </div>
                                                       </td>

                                                          <td style="width:10px; height:150px">

                                                       </td>
                                                           
                                                       <td style="width: 350px;  height:150px">
                                                          <div class="efecto">
                                                            <a iD="A2" runat="server"   class="hovertext1" href="GenerarInstalador.aspx?E=0" title="">
                                                                <img src="Imagenes/CoDrive/Picture2.png" width="350px" height="150px" border="0" alt="" />

                                                            </a>
                                                           </div>
                                                       </td>

                                                        <td style="width:10px; height:150px">

                                                       </td>      

                                                        <td style="width: 350px;  height:150px">
                                                          <div class="efecto">
                                                            <a iD="A7" runat="server"   class="hovertext1" href="SynchSystem.aspx" title="">
                                                                <img src="Imagenes/CoDrive/Picture5.png" width="350px" height="150px" border="0" alt="" />

                                                            </a>
                                                           </div>
                                                       </td>

                                                   </tr>

                                            </table>


                                      </td>
                                  </tr>
                                 
                                   

                               </table>

                        </td>

                      </tr>

                      <tr style="padding-top:15PX">
                            <td align="center">
                                   <table style="width: 85%;" cellpadding="5px" cellspacing="5px">
                                      
                                          <tr>
                                              <td align="center"  style="width: 100%; ">

                                                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                                        
                                                                                 <Scripts>
                                                                                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                                                                                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                                                                                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                                                                                 </Scripts>
                                                                             </telerik:RadScriptManager>
                                                                                <script type="text/javascript">
                                                                                    //Put your JavaScript code here.
                                                                                    function pageLoad() {
                                                                                        var imageGallery = $find('<%= RadImageGallery1.ClientID %>');
                                                                                        imageGallery.playSlideshow();
                                                                                    }
                                                                                </script>
                                                                             <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" meta:resourcekey="RadAjaxManager1Resource1">
                                                                                </telerik:RadAjaxManager>
                                                                              <telerik:RadImageGallery ID="RadImageGallery1" runat="server" Width="800px"  RenderMode="Mobile" LoopItems="True" meta:resourcekey="RadImageGallery1Resource1">
                                                                                  <Items>
                                                                                      
                                                                                    <telerik:ImageGalleryItem ImageUrl="Imagenes/CoDrive/COSLIDE1.JPG" Title="" 
                                                                                        Description="" />
                                                                                    <telerik:ImageGalleryItem ImageUrl="Imagenes/CODRIVE/COSlide2.JPG" Title="" 
                                                                                        Description="" />
                                                                                    <telerik:ImageGalleryItem ImageUrl="Imagenes/CODRIVE/COSlide3.JPG" Title="" 
                                                                                        Description="" />
                                                                                    <telerik:ImageGalleryItem ImageUrl="Imagenes/CODRIVE/COSlide4.JPG" Title="" 
                                                                                        Description="" />
                                                                                    <telerik:ImageGalleryItem ImageUrl="Imagenes/CODRIVE/COSlide5.JPG" Title="" 
                                                                                        Description="" />
                                                                                    <telerik:ImageGalleryItem ImageUrl="Imagenes/CODRIVE/COSlide6.JPG" Title="" 
                                                                                        Description="" />
                                                                                   
                                                                                        
                                              
                                                                                </Items>
                                                                                <ThumbnailsAreaSettings Mode="ImageSliderPreview" />
                                                                                <ImageAreaSettings Height="550px" />
                                                                                <ToolbarSettings ShowSlideshowButton="False" />
                                                                                <ClientSettings AllowKeyboardNavigation="True">
                                                                                    <KeyboardNavigationSettings><Shortcuts>
                                                                                        <telerik:ImageGalleryShortcut Command="Focus" Key="Y" Modifiers="Ctrl" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="Prev" Key="LeftArrow" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="Next" Key="RightArrow" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="Up" Key="UpArrow" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="Down" Key="DownArrow" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="MoveToFirst" Key="Home" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="MoveToLast" Key="End" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="PrevView" Key="LeftArrow" Modifiers="Alt" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="NextView" Key="RightArrow" Modifiers="Alt" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="PrevView" Key="UpArrow" Modifiers="Alt" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="NextView" Key="DownArrow" Modifiers="Alt" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="Select" Key="Enter" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="Close" Key="Escape" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="ToggleSlideshow" Key="Space" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="ToggleFullScreen" Key="F" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="ToggleThumbnails" Key="T" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="PrevPage" Key="PageDown" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        <telerik:ImageGalleryShortcut Command="NextPage" Key="PageUp" Modifiers="None" Enabled="True"></telerik:ImageGalleryShortcut>
                                                                                        </Shortcuts>
                                                                                    </KeyboardNavigationSettings>

                                                                                    <AnimationSettings SlideshowSlideDuration="6000">
                                                                                        <NextImagesAnimation Easing="Random" Type="Random" />
                                                                                        <PrevImagesAnimation Easing="Random" Type="Random" />
                                                                                    </AnimationSettings>
                                                                                </ClientSettings>
                                                                              </telerik:RadImageGallery>
                                              </td>
                                          </tr>

                                   </table>

                            </td>
                      </tr>

                      <tr style="padding-top:15PX; display:none" >
                        <td align="center">

                               <table style="width: 85%;" cellpadding="5px" cellspacing="5px">

                                  <tr>
                                      <td align="left" rowspan="2" style="width: 100%; padding-left:100px">


                                            <table>
                                                   <tr style="width: 100%; ">
                                                        
                                                       <td style="width:150px; height:150px">
                                                           <div class="efecto">
                                                            <a iD="A3" runat="server"   class="hovertext1" href="BusquedaGeneral.aspx" title="">
                                                                <img src="Imagenes/CoDrive/Picture3.png" width="150px" height="150px" border="0" alt="" />

                                                            </a>
                                                           </div>
                                                       </td>

                                                          <td style="width:42px; height:150px">

                                                       </td>
                                                           
                                                       <td style="width: 150px;  height:150px">
                                                          <div class="efecto">
                                                            <a iD="A4" runat="server"   class="hovertext1" href="BusquedaGeneral.aspx" title="">
                                                                <img src="Imagenes/CoDrive/Picture4.png" width="150px" height="150px" border="0" alt="" />

                                                            </a>
                                                           </div>
                                                       </td>

                                                         <td style="width:10px; height:150px">

                                                       </td>

                                                        <td style="width: 350px;  height:150px">
                                                          <div class="efecto">
                                                            <a iD="A5" runat="server"   class="hovertext1" href="SynchSystem.aspx" title="">
                                                                <img src="Imagenes/CoDrive/Picture5.png" width="350px" height="150px" border="0" alt="" />

                                                            </a>
                                                           </div>
                                                       </td>

                                                       
                                                         <td style="width:10px; height:150px">

                                                       </td>

                                                        <td style="width: 350px;  height:150px">
                                                          <div class="efecto">
                                                            <a iD="A6" runat="server"   class="hovertext1" href="Participacion.aspx" title="">
                                                                <img src="Imagenes/CoDrive/Picture6.png" width="350px" height="150px" border="0" alt="" />

                                                            </a>
                                                           </div>
                                                       </td>

                                                   </tr>

                                            </table>


                                      </td>
                                  </tr>

                                   

                               </table>

                        </td>

                      </tr>

                      </table>
             </td>
        </tr>
           <tr>
                                      <td align="center" colspan="3" style="height:20px;">
                                        
                                      </td>
                                  </tr>
         
              <tr >
                              <td>
                                  <uc1:Foot ID="Foot1" runat="server" />
                              </td>
              </tr>
          
      </table>
    </form>
</body>
</html>

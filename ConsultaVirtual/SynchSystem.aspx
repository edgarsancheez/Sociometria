<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SynchSystem.aspx.vb" Inherits="ConsultaVirtual.SynchSystem"  MaintainScrollPositionOnPostback="true" meta:resourcekey="PageResource1" uiculture="auto"%>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Foot.ascx" tagname="Foot" tagprefix="uc1" %>
<%@ Register src="Head.ascx" tagname="Head" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="X-UA-Compatible" content="IE=Edge" />

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Clima Organizacional</title>
     
    <link href="Clases/EstiloPagina.css" rel="stylesheet" type="text/css" />
    <link href="Clases/Cargando.css" rel="stylesheet" type="text/css" />
    <%--<link href="Clases/Menu.css" rel="stylesheet" type="text/css" />--%>
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

    
        <script type="text/javascript">
            function mostrar() {
                document.getElementById('fountainG').style.display = 'block';
                document.getElementById('Connecting').style.display = 'block';

            }

            function ocultar() {
                document.getElementById('fountainG').style.display = 'none';
                document.getElementById('Connecting').style.display = 'none';

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
      
                  <table cellpadding="0" cellspacing="0" class="style1" >
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
                            <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" 
                                Font-Size="10pt" ForeColor="White" meta:resourcekey="LerrorResource1" ></asp:Label>
                          </td>
                       
                       
                         </tr>

                      
                        <tr align="center">
                            <td >
                                  
                                  <table class="style2">
                                       <tr>
                                          <td align="center" valign="top">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%"
                                                        style="font-family: arial, Helvetica, sans-serif; font-size: small;">
                                                          <tr>
                          
                                                             <td align="center">
                                                                   <table align="left" border="0" style="width:100%;">
                                                                
                                                                                                    <tr>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LUnidad" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black"  style="font-weight: 700" Text="Unidad de Negocio" meta:resourcekey="LUnidadResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LAgrupado" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black"  style="font-weight: 700" Text="Agrupado Pais" meta:resourcekey="LAgrupadoResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LPais" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black" style="font-weight: 700" Text="Pais" meta:resourcekey="LPaisResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LTerritorio" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black" style="font-weight: 700" Text="Territorio" meta:resourcekey="LTerritorioResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LRegion" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black" style="font-weight: 700" Text="Región" meta:resourcekey="LRegionResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="14%">
                                                                                                            <asp:Label ID="LSubregion" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black"  style="font-weight: 700" Text="Subregión" meta:resourcekey="LSubregionResource1"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" width="15%">
                                                                                                            <asp:Label ID="LEmpresa" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Black" style="font-weight: 700" Text="Centro de Trabajo" meta:resourcekey="LEmpresaResource1"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RUnidad" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RUnidadResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RRegionPaises" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RRegionPaisesResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RPaises" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RPaisesResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RTerritorios" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RTerritoriosResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RRegiones" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RRegionesResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="14%">
                                                                                                            <telerik:RadListBox ID="RSubregiones" runat="server" AutoPostBack="True" Height="100%"  Width="98%" meta:resourcekey="RSubregionesResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                        <td align="left" height="140px" valign="top" width="15%">
                                                                                                            <telerik:RadListBox ID="RCentroDeTrabajo" runat="server" Height="100%"  Width="98%" AutoPostBack="True" meta:resourcekey="RCentroDeTrabajoResource1">
                                                                                                                <ButtonSettings TransferButtons="All" />
                                                                                                            </telerik:RadListBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                            </td>
                                                          </tr>
                   
                                                          <tr  align="center">
                                                                         
                                                            <td align="center">
                                                                <table style="width:100%">
                                                                       <tr>
                                                                        <td style="width:100%;text-align:center" colspan="2">
                                                                            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                                                                    <script type="text/javascript">

                                                                                        var $ = $telerik.$;

                                                                                        function onClientFileUploaded(radAsyncUpload, args) {

                                                                                        }

                                                                                        function OnClientValidationFailed(sender, args) {
                                                                                            var fileExtention = args.get_fileName().substring(args.get_fileName().lastIndexOf('.') + 1, args.get_fileName().length);
                                                                                            if (args.get_fileName().lastIndexOf('.') != -1) {//this checks if the extension is correct
                                                                                                if (sender.get_allowedFileExtensions().indexOf(fileExtention) == -1) {
                                                                                                    alert("Tipo de documento invalido, favor de seleccionar un archivo valido!");
                                                                                                }
                                                                                                else {
                                                                                                    alert("Wrong file size!");
                                                                                                }
                                                                                            }
                                                                                            else {
                                                                                                alert("Tipo de documento invalido, favor de seleccionar un archivo valido!");
                                                                                            }
                                                                                        }

                                                                                    </script>
                                                                                </telerik:RadCodeBlock>

                                                                          
                                                                           <div  runat="server" id="DemoContainer1" align="center" style="margin-left: 40px">

                                                                                                  

                                                                               <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" Width="300px" OnClientFileUploaded="onClientFileUploaded" OnClientValidationFailed="OnClientValidationFailed" MaxFileInputsCount="2" AllowedFileExtensions=".mdb" AllowedMimeTypes=".mdb" meta:resourcekey="RadAsyncUpload1Resource1" DisablePlugins="True"  EnablePermissionsCheck="False" TemporaryFolder="\\femmsiliis1.csc.fmx\RespaldoCO\TEMPRADASYNCUPLOAD">
                                                                                   <Localization Cancel="Cancel" Remove="Remove" Select="Select File" />
                                                                                   <FileFilters>
                                                                                       <telerik:FileFilter Description="BD" Extensions=".mdb" />
                                                                                   </FileFilters>

                                                                               </telerik:RadAsyncUpload>
                                                                                        <%--<telerik:RadProgressArea RenderMode="Lightweight" runat="server" ID="RadProgressArea1" />
                                                                               <telerik:RadProgressManager ID="RadProgressManager1" runat="server" />--%>
                                                                                <br />
                                                                                <asp:Button ID="Button1" runat="server" Text="Enviar archivos" OnClientClick="mostrar()" meta:resourcekey="Button1Resource1"/>
                                                                                <br />
                                                                                
                                                                            </div>
                                                                               

                                                                            <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" meta:resourcekey="RadAjaxLoadingPanel1Resource1"  />
                                                                                 
                                                                        </td>
                                                                    </tr>
                                                                      <tr>

                                                                        <td runat="server" id="TDMOSTRAR" style="text-align:center" colspan="2">
                                                                            
                                                                           
                                                                                    <div id="Connecting"  style='display:none;'>
                                                                                         <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Blue" Text="Se están enviando los archivos, este proceso puede ser largo favor de esperar..." meta:resourcekey="Label1Resource1"></asp:Label>
                                                                                        
                                                                                    </div>
                                                                                    <div id="fountainG"  style='display:none;'>
                                                                                
	                                                                                    <div id="fountainG_1" class="fountainG"></div>
	                                                                                    <div id="fountainG_2" class="fountainG"></div>
	                                                                                    <div id="fountainG_3" class="fountainG"></div>
	                                                                                    <div id="fountainG_4" class="fountainG"></div>
	                                                                                    <div id="fountainG_5" class="fountainG"></div>
	                                                                                    <div id="fountainG_6" class="fountainG"></div>
	                                                                                    <div id="fountainG_7" class="fountainG"></div>
	                                                                                    <div id="fountainG_8" class="fountainG"></div>
                                                                            
                                                                               

                                                                                    </div>

                                                                            
                                                                               
                                                                            </td>
                                                                        
                                                                    </tr>
                                                                     <tr style="width:100%">
                                                                         <td style="width:50%;text-align:center;vertical-align:top">

                                                                            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                                        
                                                                                 <Scripts>
                                                                                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                                                                                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                                                                                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                                                                                 </Scripts>
                                                                             </telerik:RadScriptManager>
                                                                               
                                                                             <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" meta:resourcekey="RadAjaxManager1Resource1">
                                                                                  
                                                                                </telerik:RadAjaxManager>
                                                                             
                                                                             <asp:ImageMap ID="ImageMap1" Width="750px" Height="500px" runat="server" ImageUrl="~/Imagenes/CoDrive/COSLIDE6.jpg" meta:resourcekey="ImageMap1Resource1"></asp:ImageMap>

                                                                         </td>

                                                                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                                                         <td style="width:50%;text-align:center;vertical-align:top; padding-left:25px" align="right">

                                                                             <telerik:RadGrid ID="RadGrid1" runat="server" Height="500px" Width="100%" 
                                                                  AutoGenerateColumns="False" ShowFooter="True" AllowPaging="True" ShowGroupPanel="True" GroupPanelPosition="Top" meta:resourcekey="RadGrid1Resource1">
                                                                  <clientsettings>
                                                                      <scrolling allowscroll="True" usestaticheaders="True" />
                                                                  </clientsettings>
                                                                  <MasterTableView>
                                                                      <Columns>
                                                                           <telerik:GridBoundColumn DataField="filename" 
                                                                              FilterControlAltText="Filter filename column" HeaderText="filename" 
                                                                              UniqueName="filename" Display="false" meta:resourcekey="GridBoundColumnResource1">
                                                                               <HeaderStyle Width="0px" />
                                                                              <ItemStyle HorizontalAlign="Left" />
                                                                          </telerik:GridBoundColumn>
                                                                           
                                                                          <telerik:GridBoundColumn DataField="Usuario" 
                                                                              FilterControlAltText="Filter Usuario column" HeaderText="Usuario" 
                                                                              UniqueName="Usuario"  Display="false" meta:resourcekey="GridBoundColumnResource2">
                                                                               <HeaderStyle Width="100px" />
                                                                              <ItemStyle HorizontalAlign="Left" />
                                                                          </telerik:GridBoundColumn>

                                                                              <telerik:GridBoundColumn DataField="Ruta"
                                                                              FilterControlAltText="Filter Ruta column" HeaderText="Ruta" 
                                                                              UniqueName="Ruta" meta:resourcekey="GridBoundColumnResource3" >
                                                                                   <HeaderStyle Width="200px" />
                                                                              <ItemStyle HorizontalAlign="Left" />
                                                                          </telerik:GridBoundColumn>
                                                                           
                                                                             <telerik:GridBoundColumn DataField="Fecha" 
                                                                              FilterControlAltText="Filter DESCCHECK column" HeaderText="Fecha" 
                                                                              UniqueName="Fecha" meta:resourcekey="GridBoundColumnResource4">
                                                                                   <HeaderStyle Width="200px" />
                                                                              <ItemStyle HorizontalAlign="Left" />
                                                                          </telerik:GridBoundColumn>
                                                                       

                                                                                    <telerik:GridTemplateColumn FilterControlAltText="Filter Download column"  
                                                                            UniqueName="Download" meta:resourcekey="GridTemplateColumnResource1">
                                                                              <ItemTemplate>
                                                                                
                                                                                  <asp:ImageButton ID="Download" runat="server" CommandName="Download" ImageUrl="~/Imagenes/Estatus/Download.png" meta:resourcekey="DownloadResource1"/>
                                                                                     
                                                                                  


                                                                              </ItemTemplate>
                                                                              <HeaderStyle Width="50px" />
                                                                          </telerik:GridTemplateColumn>
                                                                         
                                                                      </Columns>
                                                                  </MasterTableView>
                                                              </telerik:RadGrid>

                                                                         </td>

                                                                        

                                                                     </tr>
                                                                 
                                                                  

                                                                </table>    
                                                                    <telerik:RadNotification ID="RadNotification1" runat="server" ForeColor="#00CC00" Position="Center" meta:resourcekey="RadNotification1Resource1"></telerik:RadNotification>
                                                            </td>
                                                          </tr>
                   
                   
                   
                    
                  
                   
                                                    </table>
                                                </td>  

                                       </tr>

                                     
                                  </table>
                            </td>
                        </tr>

                     

                      </table>
            
                              <tr>
                                      <td align="center" colspan="3" style="height:20px;">
                                     
                                      </td>
                              </tr>

                              <tr>
                                      <td>
                                          <uc1:Foot ID="Foot1" runat="server" />
                                      </td>
                              </tr>
    

    </form>
</body>
</html>

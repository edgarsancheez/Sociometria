<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MMenuPrincipal_Personal.aspx.vb" Inherits="ConsultaVirtual.MMenuPrincipal_Personal" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="">
    <title>Sociometría</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="css/SiteMaster.css" />
    <link rel="stylesheet" href="css/Cards.css" />
    <style type="text/css">      
                body {
        background: #edf2f4;
        min-height: 100vh;
        padding-top: 5px;
    }
             .bg-azul {
                background-color: #003049;
            }
            .bg-amarillo {
                background-color: #ffde59;
            }
            </style>
    </head>

<body>
    <form runat="server" id="form1">
<!-- Vertical navbar -->
<div class="vertical-nav bg-sidebar" id="sidebar">
  <div class="py-4 px-3 mb-4">
    <div class="media d-flex align-items-center">
      <div class="media-body text-white">
        <h3 runat="server" id="NombrePersona" class="m-0">Sociometría</h3>
      </div>
    </div>
  </div>
    <hr class="line" />
    
    <div class="container">
        <div class="row">
            <div class="col-md-12 mb-2 text-center"  runat="server" id="Div_dem1">
                        <asp:Label ID="LDemografico1" CssClass="text-white" runat="server" Text="Demografico 1"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico1" runat="server" AutoPostBack="true" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem2">
                        <asp:Label ID="Label1" runat="server"  CssClass="text-white" Text="Demografico 2"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico2" runat="server" AutoPostBack="true" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem3">
                        <asp:Label ID="Label2"  CssClass="text-white" runat="server" Text="Demografico 3"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico3" runat="server" AutoPostBack="true" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem4">
                        <asp:Label ID="Label3"  CssClass="text-white" runat="server" Text="Demografico 4"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico4" runat="server" AutoPostBack="true" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem5">
                        <asp:Label ID="Label4"  CssClass="text-white" runat="server" Text="Demografico 5"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico5" runat="server" AutoPostBack="true" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem6">
                        <asp:Label ID="Label5"  CssClass="text-white" runat="server" Text="Demografico 6"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico6" runat="server" AutoPostBack="true" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem7">
                        <asp:Label ID="Label6"  CssClass="text-white" runat="server" Text="Demografico 7"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico7" runat="server" AutoPostBack="true" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem8">
                        <asp:Label ID="Label7"  CssClass="text-white" runat="server" Text="Demografico 8"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico8" runat="server" AutoPostBack="true" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem9">
                        <asp:Label ID="Label8"  CssClass="text-white" runat="server" Text="Demografico 9"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico9" runat="server" AutoPostBack="true" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem10">
                        <asp:Label ID="Label9"  CssClass="text-white" runat="server" Text="Demografico 10"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico10" runat="server" AutoPostBack="true" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center">

                <asp:Button runat="server" ID="Btn_cargardato" CssClass="btn btn-primary" OnClick="Btn_cargardato_Click" Text="Cargar" />
            </div>
        </div>
    </div>

</div>
<div class="page-content p-2" id="content">
  <!-- Toggle button -->
 
    <nav class="navbar navbar-expand-lg navbar-light bg-transparent">
                <div class="container-fluid">
                <button id="sidebarCollapse" type="button" class="btn btn-light bg-white rounded-pill shadow-sm px-4 mb-4"><i class="fa fa-bars mr-2"></i><small class="text-uppercase font-weight-bold">Toggle</small></button>
                    <button class="btn btn-dark d-inline-block d-lg-none ml-auto" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <i class="fas fa-align-justify"></i>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="nav navbar-nav ml-auto">
                            <li class="nav-item active">
                                <a class="nav-link" href="MMenuPrincipal.aspx">Dashboard</a>
                            </li> 
                            <li class="nav-item active">
                                <a class="nav-link" href="MMenuPrincipal_Personal.aspx">Personal</a>
                            </li> 
                            <li class="nav-item">
                                <a class="nav-link" href="#">|</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Login.aspx">Cerrar Sesión</a>
                            </li>

                        </ul>
                    </div>
                </div>
            </nav>

    <asp:Label runat="server" ID="LRuta" ></asp:Label>

<%--    graficas--%>
    <div>
        <div class="container">
            <div class="row">
                <div class="col-md-12 mb-3">
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Label ID="Label_1" runat="server" Text="Genero"></asp:Label>
                            <telerik:RadComboBox ID="RC_Genero" runat="server" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label_2"  runat="server" Text="Generación"></asp:Label>
                            <telerik:RadComboBox ID="RC_Generacion" runat="server" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label_3"  runat="server" Text="Escolaridad"></asp:Label>
                            <telerik:RadComboBox ID="RC_Escolaridad" runat="server" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label_4" runat="server" Text="Nivel de Contribución"></asp:Label>
                            <telerik:RadComboBox ID="RC_NivelContribucion" runat="server"  Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label_5"  runat="server" Text="Tipo Empleado"></asp:Label>
                            <telerik:RadComboBox ID="RC_TipoEmpleado" runat="server" Skin="Metro" EnableEmbeddedSkins="true" ></telerik:RadComboBox>
                        </div>
                        <div class="col-md-2">
                             <asp:Button runat="server" ID="BtnCargar_Demo" OnClick="BtnCargar_Demo_Click" CssClass="btn btn-primary" Text="Cargar" />
                        </div>
                    </div>
                </div>
                <div class="col-md-12 mb-3">
               <telerik:RadGrid runat="server" ID="RadGrid1" Skin="Metro" Width="100%" AllowFilteringByColumn="True" AllowPaging="True" AutoGenerateColumns="False"
                   AllowSorting="True" ShowStatusBar="True">
                    <ClientSettings>
                        <Selecting AllowRowSelect="true" />                                       
                        <Selecting AllowRowSelect="True" />     
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
                    <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" NoDetailRecordsText="No existen registros" 
                        NoMasterRecordsText="No existen registros" PageSize="200" ShowFooter="True">
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False"></RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True" Created="True"> </ExpandCollapseColumn>
                        <CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="False" ShowSaveChangesButton="false" />
                    <Columns>
                    <telerik:GridBoundColumn AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="numtrabajador" FilterControlAltText="Filter numtrabajador column"
                     FilterControlWidth="100%"  HeaderText="Num Empleado" ShowFilterIcon="false" UniqueName="numtrabajador">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="nombre" FilterControlAltText="Filter nombre column" 
                      FilterControlWidth="100%"  HeaderText="Nombre" ShowFilterIcon="false"  UniqueName="nombre">
                    </telerik:GridBoundColumn>
                    <telerik:GridNumericColumn AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataField="Afinidad" FilterControlAltText="Filter Afinidad column"
                        FilterControlWidth="100%" HeaderText="Afinidad" ShowFilterIcon="false" UniqueName="Afinidad">
                    </telerik:GridNumericColumn> 
                    <telerik:GridNumericColumn AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataField="Ascendencia" FilterControlAltText="Filter Ascendencia column"
                       FilterControlWidth="100%" HeaderText="Ascendencia" ShowFilterIcon="false" UniqueName="Ascendencia">
                    </telerik:GridNumericColumn>
                    <telerik:GridNumericColumn AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataField="Popularidad" FilterControlAltText="Filter Popularidad column"
                       FilterControlWidth="100%" HeaderText="Popularidad" ShowFilterIcon="false" UniqueName="Popularidad">
                    </telerik:GridNumericColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Ver" FilterControlAltText="Filter EditColumn column" HeaderText="Ver" ImageUrl="~/Imagenes/informacion.png" UniqueName="EditColumn">
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridButtonColumn>
                    </Columns>
                    <PagerStyle AlwaysVisible="True" />
                    <HeaderStyle Font-Bold="True" />
                    <FooterStyle Font-Bold="True" />
                    </MasterTableView>
                    <CommandItemStyle Height="23px" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                </telerik:RadGrid>
                 </div>
                <div class="col-md-12 mb-3" runat="server" visible="false" id="Cards_Valor">
                    <div class="row">
                        <div class="col-md-5">
                          <div class="card-counter card1">
                            <i class="fa fa-users"></i>
                            <span class="count-numbers" runat="server" id="Label_nombre"></span>
                            <span class="count-name">Nombre</span>
                          </div>
                        </div>
                        <div class="col-md-3">
                          <div class="card-counter card2">
                            <i class="fa fa-users"></i>
                            <span class="count-numbers" runat="server" id="Label_edad"></span>
                            <span class="count-name">Edad</span>
                          </div>
                        </div>
                        <div class="col-md-4">
                          <div class="card-counter card6">
                            <i class="fa fa-user-circle"></i>
                            <span class="count-numbers" runat="server" id="Label_Nivel"></span>
                            <span class="count-name">Nivel Contribucion</span>
                          </div>
                        </div>
                        <div class="col-md-4">
                          <div class="card-counter card3">
                            <i class="fa fa-user-circle-o"></i>
                            <span class="count-numbers" runat="server" id="Label_generacion"></span>
                            <span class="count-name">Generacion</span>
                          </div>
                        </div>
                        <div class="col-md-3">
                          <div class="card-counter card4">
                            <i class="fa fa-user-circle"></i>
                            <span class="count-numbers" runat="server" id="Label_genero"></span>
                            <span class="count-name">Genero</span>
                          </div>
                        </div>
                        <div class="col-md-2">
                          <div class="card-counter card5">
                            <i class="fa fa-percent"></i>
                            <span class="count-numbers" runat="server" id="Label_Escolaridad"></span>
                            <span class="count-name">Escolaridad</span>
                          </div>
                        </div>
                        <div class="col-md-3">
                          <div class="card-counter card7">
                            <i class="fa fa-percent"></i>
                            <span class="count-numbers" runat="server" id="Label_Sindicalizado"></span>
                            <span class="count-name">Tipo de Empleado</span>
                          </div>
                        </div>
                    </div>
                </div>

            </div>
         </div>
        <div>
            <asp:Label ID="Lerror1" runat="server"></asp:Label>
             <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
                <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RDemografico1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RDemografico2" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico3" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico4" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico5" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico6" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico7" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico8" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico9" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico10" UpdatePanelCssClass="" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RDemografico2">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RDemografico3" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico4" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico5" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico6" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico7" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico8" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico9" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico10" UpdatePanelCssClass="" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RDemografico3">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RDemografico4" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico5" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico6" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico7" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico8" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico9" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico10" UpdatePanelCssClass="" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RDemografico4">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RDemografico5" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico6" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico7" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico8" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico9" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico10" UpdatePanelCssClass="" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RDemografico5">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RDemografico6" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico7" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico8" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico9" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico10" UpdatePanelCssClass="" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RDemografico6">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RDemografico7" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico8" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico9" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico10" UpdatePanelCssClass="" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RDemografico7">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RDemografico8" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico9" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico10" UpdatePanelCssClass="" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RDemografico8">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RDemografico9" UpdatePanelCssClass="" />
                                <telerik:AjaxUpdatedControl ControlID="RDemografico10" UpdatePanelCssClass="" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RDemografico9">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RDemografico10" UpdatePanelCssClass="" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>

                    </AjaxSettings>

                    <ClientEvents OnRequestStart="mngRequestStarted"></ClientEvents>
                </telerik:RadAjaxManager>--%>
        </div>
    </div>
</div>
  </form>
</body>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" ></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" ></script>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" ></script>
 <script type="text/javascript">
            $(function() {
  // Sidebar toggle behavior
  $('#sidebarCollapse').on('click', function() {
    $('#sidebar, #content').toggleClass('active');
  });
     });
 </script>

</html>

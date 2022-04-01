<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MMenuPrincipal.aspx.vb" Inherits="ConsultaVirtual.MMenuPrincipal" culture="auto" meta:resourcekey="PageResource1" uiculture="auto:es-MX" %>
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
                        <telerik:RadComboBox ID="RDemografico1" runat="server" AutoPostBack="true" Skin="Metro" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem2">
                        <asp:Label ID="Label1" runat="server"  CssClass="text-white" Text="Demografico 2"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico2" runat="server" AutoPostBack="true" Skin="Metro" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem3">
                        <asp:Label ID="Label2"  CssClass="text-white" runat="server" Text="Demografico 3"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico3" runat="server" AutoPostBack="true" Skin="Metro" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem4">
                        <asp:Label ID="Label3"  CssClass="text-white" runat="server" Text="Demografico 4"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico4" runat="server" AutoPostBack="true" Skin="Metro"  ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem5">
                        <asp:Label ID="Label4"  CssClass="text-white" runat="server" Text="Demografico 5"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico5" runat="server" AutoPostBack="true" Skin="Metro"  ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem6">
                        <asp:Label ID="Label5"  CssClass="text-white" runat="server" Text="Demografico 6"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico6" runat="server" AutoPostBack="true" Skin="Metro"  ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem7">
                        <asp:Label ID="Label6"  CssClass="text-white" runat="server" Text="Demografico 7"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico7" runat="server" AutoPostBack="true" Skin="Metro"  ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem8">
                        <asp:Label ID="Label7"  CssClass="text-white" runat="server" Text="Demografico 8"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico8" runat="server" AutoPostBack="true" Skin="Metro" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem9">
                        <asp:Label ID="Label8"  CssClass="text-white" runat="server" Text="Demografico 9"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico9" runat="server" AutoPostBack="true" Skin="Metro" ></telerik:RadComboBox>
            </div>
            <div class="col-md-12 mb-2 text-center" runat="server" id="Div_dem10">
                        <asp:Label ID="Label9"  CssClass="text-white" runat="server" Text="Demografico 10"></asp:Label>
                        <telerik:RadComboBox ID="RDemografico10" runat="server" AutoPostBack="true" Skin="Metro" ></telerik:RadComboBox>
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
                <div class="col-md-3">
                  <div class="card-counter card11">
                    <i class="fa fa-users"></i>
                    <span class="count-numbers">1065</span>
                    <span class="count-name">Head Count</span>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="card-counter card10">
                    <i class="fa fa-user-circle-o"></i>
                    <span class="count-numbers" runat="server" id="id_sindicalizado"></span>
                    <span class="count-name">Sindicalizado</span>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="card-counter card9">
                    <i class="fa fa-user-circle"></i>
                    <span class="count-numbers" runat="server" id="Id_Empleado"></span>
                    <span class="count-name">Empleado</span>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="card-counter card8">
                    <i class="fa fa-percent"></i>
                    <span class="count-numbers">85%</span>
                    <span class="count-name">Participación</span>
                  </div>
                </div>
                <div class="col-md-12 mb-2">
                    <div id="columnchart_material" ></div>
                </div>
                <div class="col-md-4 mb-2">
                    <div id="donutchart"></div>
                </div>
                <div class="col-md-4 mb-2">
                    <div id="barchart_values"></div>
                </div>
                <div class="col-md-4 mb-2">
                    <div id="piechart"></div>
                </div>
                <div class="col-md-4 mb-2">
                    <div id="columnchart_values"></div>          
                </div>
                <div class="col-md-4 mb-2">
                    <div id="donutchart1" ></div>
                </div>
                <div class="col-md-4 mb-2">
                    <div id="columnchart_material1" ></div>
                </div>
            </div>
         </div>
        <div>
              <asp:Label ID="lbljson1" hidden runat="server"></asp:Label>          
              <asp:Label ID="lbljson2" hidden runat="server"></asp:Label>     
              <asp:Label ID="lbljson3" hidden runat="server"></asp:Label>     
              <asp:Label ID="lbljson4" hidden runat="server"></asp:Label>     
              <asp:Label ID="lbljson5" hidden runat="server"></asp:Label>    
              <asp:Label ID="lbljson6" hidden runat="server"></asp:Label>   
              <asp:Label ID="lbljson7" hidden runat="server"></asp:Label>   
            <asp:Label ID="Lerror1" runat="server"></asp:Label>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
             
                        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" >
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
                 </telerik:RadAjaxManager> 
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

    //COLUMNA 1
    google.charts.load('current', {'packages':['bar']});
     google.charts.setOnLoadCallback(drawChart1);
     function drawChart1() {
            var data1 = google.visualization.arrayToDataTable(<%=lbljson1.Text%>);
         var data1 = google.visualization.arrayToDataTable(<%=lbljson1.Text%>);
        var options1 = { title:'Top de Colaboradores Liderazgo',    is3D: true, };
        var chart1 = new google.charts.Bar(document.getElementById('columnchart_material'));
        chart1.draw(data1, google.charts.Bar.convertOptions(options1));
    }

    //COLUMNA 2
      google.charts.load("current", {packages:["corechart"]});
      google.charts.setOnLoadCallback(drawChart2);
      function drawChart2() {
         var data2 = google.visualization.arrayToDataTable(<%=lbljson2.Text%>);
        var options2 = {  title: 'Menciones por Género',  pieHole: 0.1, };
        var chart2 = new google.visualization.PieChart(document.getElementById('donutchart'));
        chart2.draw(data2, options2);
    }


    //COLUMNA 3
    google.charts.load("current", {packages:["corechart"]});
    google.charts.setOnLoadCallback(drawChart3);
     function drawChart3() {
         var data3 = google.visualization.arrayToDataTable(<%=lbljson3.Text%>);
      //var data3 = google.visualization.arrayToDataTable([
      //  ["Nivel", "Total", { role: "style" } ],
      //  ["Analista", 202, "#03045e"],
      //  ["Coordinador", 290, "#023e8a"],
      //  ["Director", 217, "#0077b6"],
      //  ["Jefe", 897, "color: #0096c7"],
      //    ["Sin Dato", 173, "color: #00b4d8"]
      //]);

      var view3 = new google.visualization.DataView(data3);
      view3.setColumns([0, 1,
                       { calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation" },
                       2]);

      var options = {  title: "Menciones por Nivel de Contribución",  bar: {groupWidth: "95%"},  legend: { position: "none" },};
      var chart = new google.visualization.BarChart(document.getElementById("barchart_values"));
      chart.draw(view3, options);
    }


    //COLUMNA 4
      google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart4);

      function drawChart4() {
        var data4 = google.visualization.arrayToDataTable(<%=lbljson4.Text%>)
        var options4 = {  title: 'Menciones por Nivel de Contribución' };
        var chart4 = new google.visualization.PieChart(document.getElementById('piechart'));

        chart4.draw(data4, options4);
                }

    //COLUMNA 5
    google.charts.load("current", {packages:['corechart']});
    google.charts.setOnLoadCallback(drawChart5);
     function drawChart5() {
        var data5 = google.visualization.arrayToDataTable(<%=lbljson5.Text%>)
      //var data5 = google.visualization.arrayToDataTable([
      //  ["Escolaridad", "Total", { role: "style" } ],
      //  ["Secundaria", 202, "#00b4d8"],
      //  ["Doctorado", 217, "#0096c7"],
      //  ["Preparatoria", 290, "#0077b6"],
      //    ["Profesional", 897, "#023e8a"],
      //  ["Técnica", 173, "color: #03045e"]
      //]);
      var view5 = new google.visualization.DataView(data5);
      view5.setColumns([0, 1,
                       { calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation" },
                       2]);

      var options5 = {
        title: "Menciones por Nivel de Escolaridad",
        bar: {groupWidth: "95%"},
        legend: { position: "none" },
      };
      var chart5 = new google.visualization.ColumnChart(document.getElementById("columnchart_values"));
      chart5.draw(view5, options5);
     }
    //COLUMNA 6
      google.charts.load("current", {packages:["corechart"]});
      google.charts.setOnLoadCallback(drawChart6);
      function drawChart6() {
         var data6 = google.visualization.arrayToDataTable(<%=lbljson6.Text%>);
        var options6 = {  title: 'Menciones por Generación',  pieHole: 0.1, };
        var chart6 = new google.visualization.PieChart(document.getElementById('donutchart1'));
        chart6.draw(data6, options6);
    }

    //COLUMNA 7
      google.charts.load('current', {'packages':['bar']});
     google.charts.setOnLoadCallback(drawChart7);
        function drawChart7() {
         var data7 = google.visualization.arrayToDataTable(<%=lbljson7.Text%>);
            var options7 = { title: 'Personas mencionadas por estilo de liderazgo',  is3D: true, };
        var chart7 = new google.charts.Bar(document.getElementById('columnchart_material1'));
        chart7.draw(data7, google.charts.Bar.convertOptions(options7));
                            }


google.charts.load('current', {'packages':['bar']});
     google.charts.setOnLoadCallback(drawChart1);
     function drawChart1() {
            var data1 = google.visualization.arrayToDataTable(<%=lbljson1.Text%>);
         var data1 = google.visualization.arrayToDataTable(<%=lbljson1.Text%>);
        var options1 = { title:'Top de Colaboradores Liderazgo',    is3D: true, };
        var chart1 = new google.charts.Bar(document.getElementById('columnchart_material'));
        chart1.draw(data1, google.charts.Bar.convertOptions(options1));
     }

                        $.ajax({
                            type: "POST",
                            url: "ARLA_Arana.aspx/Cargar_Riesgos",
                            data: jsonText,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",

                            success: function (msg) {
                                debugger;

                                for (var i = 0; i < msg.d.length; i++) {
                                     $("#cboFiltro").append("<option value='" + data.id + "'>" + data.nombre + "</option>");
                                   }

                            },
                            failure: function (msg) {
                                alert(msg);
                            },
                            error: function (xhr, err) {
                                debugger;
                                alert(err);
                            }

                        });

 </script>

</html>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GraficasJI.aspx.vb" Inherits="ConsultaVirtual.GraficasJI" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
      <meta http-equiv="X-UA-Compatible" content="IE=edge" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Clases/EstiloPagina.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .HTMLChart
        {
             text-align: left;
             float: none;
        }
        .auto-style1 {
            width: 20%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">                                                
    
    <table cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td align="center">
                <table cellpadding="2" cellspacing="0" class="style2"
            style="font-family: arial, Helvetica, sans-serif; font-size: small;" >
                <tr align="center" valign="middle">
                     <td align="center" width="20%">
                        &nbsp;</td>
                    <td colspan="3" align="center" width="60%">
                                    <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                        Font-Size="9pt" ForeColor="Maroon" meta:resourcekey="LerrorResource1"></asp:Label>
                    </td>
                    <td align="center" width="20%">
                        &nbsp;</td>
                    </tr>

                    <tr>
                        <td>
                        </td>
                     <td colspan="3">

                  
                <telerik:RadHtmlChart runat="server" ID="Chart1" Width="800px" Height="500px" Skin="Silk">
           
                </telerik:RadHtmlChart>
                  <telerik:RadHtmlChart runat="server" ID="BarChart" Width="800px" Height="500px" Skin="Silk">
           
                </telerik:RadHtmlChart>

                 <telerik:RadHtmlChart runat="server" ID="PieChart" Width="800px" Height="500px" Skin="Silk">
           
                </telerik:RadHtmlChart>

                <telerik:RadHtmlChart runat="server" ID="ColumnChart" CssClass="HTMLChart" Width="800px" Height="500px" viewstatemode="Enabled">
                              <ChartTitle Text="ENCABEZADO PRINCIPAL">
                            </ChartTitle>
                </telerik:RadHtmlChart>
                         <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
                              </td>
                     
                    
                    <td>


                     </td>
                    
            
                    
                </tr>
        <tr align="center" valign="middle">
                    <td>
                      </td>
                    <td colspan="3">
                   
                            
                    </td>
                    <td>
                     </td>
                </tr>

        
                 </table>

    </table>
       
    
        
          
    </form>
</body>
</html>

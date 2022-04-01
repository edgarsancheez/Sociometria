<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Head.ascx.vb" Inherits="ConsultaVirtual.Head" %>
<style type="text/css">

    .style1
    {
        width: 100%;
    }
    .auto-style1 {
        height: 30px;
    }
</style>
<link rel="shortcut icon" href="Imagenes/Generales/COIcon.ico"/>
<table cellpadding="0" cellspacing="0" class="style1" style="border-width: thin; border-color: transparent; border-bottom-style: none;     background-image:url('Imagenes/fondo.jpg')">
    <tr>
        <td align="center">
            <table cellspacing="3" cellpading="3" width="95%">
                <tr>
                    <td align="left" width="50%" rowspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="48%" height="30px">
                        <asp:Label ID="LUsuario" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="10pt" ForeColor="White" Visible="False" meta:resourcekey="LUsuarioResource1"></asp:Label>
                        <asp:Label ID="LNombre" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="White" Visible="False" meta:resourcekey="LNombreResource1"></asp:Label>
                    </td>
                    <td align="right" width="2%" height="30px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">
                        <asp:Label ID="LFecha" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="White" Visible="False" meta:resourcekey="LFechaResource1"></asp:Label>
                    </td>
                    <td align="right" class="auto-style1"></td>
                </tr>
                </table>
        </td>
    </tr>
</table>


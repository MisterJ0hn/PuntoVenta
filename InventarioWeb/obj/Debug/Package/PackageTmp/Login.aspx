<%@ Page Title="" Language="C#" MasterPageFile="~/MPP.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InventarioWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style5
        {
            width: 63px;
            height: 104px;
        }
        .style6
        {
            width: 170px;
            height: 104px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align: center">
        <table align="center" bgcolor="White" frame="border" 
            style="width: 180px; height: 320px">
            <tr>
                <td align="left" class="style1">
                    <img alt="login" class="style6" longdesc="login" src="Imagenes/login.gif" /><br />
                    Usuario:<br />
    <asp:TextBox ID="txtUsuario" runat="server" Width="155px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtUsuario" Display="Dynamic" ErrorMessage="Ingrese Usuario" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                    <br />
                    Contraseña:<br />
    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtClave" Display="Dynamic" 
                        ErrorMessage="Ingrese Contraseña" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <br />
    <asp:Button ID="btnIngresar" runat="server" onclick="btnIngresar_Click" 
        Text="Ingresar" />
                    <br />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ShowMessageBox="True" ShowSummary="False" />
                    <br />
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp;
    </div>
    <br />

</asp:Content>

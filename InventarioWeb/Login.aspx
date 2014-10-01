<%@ Page Title="" Language="C#" MasterPageFile="~/MPP.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InventarioWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    Ingreo de Login<br />
    Usuario<br />
    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    <br />
    Password<br />
    <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnIngresar" runat="server" onclick="btnIngresar_Click" 
        Text="Ingresar" />
    <br />

</asp:Content>

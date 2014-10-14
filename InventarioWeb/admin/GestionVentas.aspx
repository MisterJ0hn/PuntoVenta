<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionVentas.aspx.cs" Inherits="InventarioWeb.admin.GestionVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
    <asp:Label ID="Label1" runat="server" Text="Gestion de Ventas"></asp:Label>
    </h1>
    <p class="submitButton">
    <asp:Button ID="btnCrear" runat="server" Text="Crear Venta" 
            onclick="btnCrear_Click" />
    </p>
   
</asp:Content>

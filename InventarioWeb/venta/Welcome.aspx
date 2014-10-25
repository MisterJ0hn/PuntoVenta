<%@ Page Title="" Language="C#" MasterPageFile="~/VNT.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="InventarioWeb.venta.Welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <h1>
    <asp:Label ID="lbl1" Text="Bienvenido " runat="server"></asp:Label> <asp:Label ID="lblBienvenido" runat="server"></asp:Label>
    </h1>
   
    
    
    <h2>
    <asp:Label ID="Label1" Text="Empresa" runat="server"></asp:Label> <asp:Label ID="lblRutEmpresa" runat="server"></asp:Label>
    </h2>
    
    
    <h2>
    <asp:Label ID="Label3" Text="Sucursal " runat="server"></asp:Label> <asp:Label ID="lblSucursal" runat="server"></asp:Label>
    </h2>
   
    
<br />

</asp:Content>

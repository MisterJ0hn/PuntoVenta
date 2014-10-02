<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="IngresoDocumento.aspx.cs" Inherits="InventarioWeb.admin.IngresoDocumento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Datos de Factura</h1>
<asp:TextBox ID="Codigo" runat="server"  OnTextChanged="Codificar"   ></asp:TextBox>
<p>
<asp:Label ID="lbl1" runat="server" Text="Rut Proveedor" Width="150"></asp:Label>
<asp:TextBox ID="txtRutEmpresa" runat="server"></asp:TextBox>
</p>
<p>
<asp:Label ID="Label1" runat="server" Text="Nombre Proveedor" Width="150"></asp:Label>
<asp:TextBox ID="txtNombreProveedor" runat="server"></asp:TextBox>
</p>
<p>
<asp:Label ID="Label2" runat="server" Text="Numero Factura" Width="150"></asp:Label>
<asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
</p>
<p>
<asp:Label ID="Label4" runat="server" Text="Fecha Vencimiento" Width="150"></asp:Label>
<asp:TextBox ID="txtFechaVenc" runat="server"></asp:TextBox>
</p>
<p>
<asp:Label ID="Label3" runat="server" Text="Monto" Width="150"></asp:Label>
<asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
</p>
<h2>Prueba Caputador Virtual</h2>
<asp:TextBox ID="Capturadora" runat="server"></asp:TextBox> 
    <asp:Button ID="btnCapturadora" runat="server" Text="Capturadora" 
        onclick="btnCapturadora_Click" />

</asp:Content>

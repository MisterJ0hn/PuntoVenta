<%@ Page Title="" Language="C#" MasterPageFile="~/BDG.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="InventarioWeb.bodega.AgregarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>
Agregar Producto
</h1>

<p>
<asp:Label ID="lblNombre" runat="server" Text="Nombre" Width="100"></asp:Label>
<asp:TextBox ID="txtNombre" runat="server" ></asp:TextBox>
</p>
<p>
<asp:Label ID="Label1" runat="server" Text="Departamento" Width="100"></asp:Label>
<asp:DropDownList ID="cboDepartamento" runat="server" 
        onselectedindexchanged="cboDepartamento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
</p>
<p>
<asp:Label ID="Label2" runat="server" Text="Ganancia" Width="100"></asp:Label>
<asp:TextBox ID="txtGanancia" runat="server" ></asp:TextBox>
</p>
<p>
<asp:Label ID="lblBoleta" runat="server" Text="Incluir en Boleta" Width="100"></asp:Label>
<asp:DropDownList ID="cboEnBoleta" runat="server">
<asp:ListItem Value="1" Text="SI"></asp:ListItem>
<asp:ListItem Value="0" Text="NO"></asp:ListItem>
</asp:DropDownList>
</p>

<p>
<asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" />
</p>

</asp:Content>

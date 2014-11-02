<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="ModificarProductos.aspx.cs" Inherits="InventarioWeb.admin.ModificarProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Modificar Productos</h1>
<asp:HiddenField ID="hdProducto" runat="server" />
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
<asp:CheckBox ID="chkDetalle" runat="server" Text="Actualizar Detalles" />
</p>
<p>
<asp:Label ID="lblBoleta" runat="server" Text="Incluir en Boleta" Width="100"></asp:Label>
<asp:DropDownList ID="cboEnBoleta" runat="server">
<asp:ListItem Value="0" Text="NO"></asp:ListItem>
<asp:ListItem Value="1" Text="SI"></asp:ListItem>
</asp:DropDownList>
</p>
<p>
<asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
        onclick="btnGuardar_Click" />
</p>
</asp:Content>

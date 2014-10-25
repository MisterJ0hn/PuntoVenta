<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="ModificarDepartamento.aspx.cs" Inherits="InventarioWeb.admin.ModificarDepartamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Agregar Departamento</h1>
<asp:HiddenField ID="hdDepartamento" runat="server" />
<p>
<asp:Label ID="lblNombre" Text="Nombre" runat="server" Width="100"></asp:Label> <asp:TextBox ID="txtNombre" runat="server" ></asp:TextBox>
</p>
<p>
<asp:Label ID="Label1" Text="Ganancia" runat="server" Width="100"></asp:Label> <asp:TextBox ID="txtGanancia" runat="server" ></asp:TextBox>
</p>
<p>
<asp:CheckBox ID="chkProductos" runat="server" Text="Actualizar Productos" />
</p>
<p>
<asp:CheckBox ID="chkDetalle" runat="server" Text="Actualizar Detalles" />
</p>
<p>
<asp:Button ID="btnGuardar" Text="Guardar" runat="server" 
        onclick="btnGuardar_Click" />
</p>
</asp:Content>

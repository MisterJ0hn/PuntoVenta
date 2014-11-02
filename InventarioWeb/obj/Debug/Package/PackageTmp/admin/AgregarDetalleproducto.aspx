<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="AgregarDetalleproducto.aspx.cs" Inherits="InventarioWeb.admin.AgregarDetalleproducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Ingresar Producto</h2>
<asp:Label ID="lblAlerta" CssClass="alertaP"  runat="server"></asp:Label>
<p>
<asp:Label ID="lblCodigo" runat="server" Text="Codigo" Width="100"></asp:Label>
<asp:TextBox ID="txtCodigo" runat="server" AutoPostBack="true" 
        ontextchanged="txtCodigo_TextChanged"></asp:TextBox>
<asp:RequiredFieldValidator ID="vldCodigo" ControlToValidate="txtCodigo" runat="server" Text="Campo Requerido" CssClass="failureNotification"></asp:RequiredFieldValidator>
</p>
<p>
<asp:Label ID="LblDescripcion" runat="server" Text="Descripcion" Width="100"></asp:Label>
<asp:TextBox ID="txtDescripcion" runat="server" ></asp:TextBox>
<asp:RequiredFieldValidator ID="RangeValidator1" ControlToValidate="txtDescripcion" runat="server" Text="Campo Requerido" CssClass="failureNotification"></asp:RequiredFieldValidator>
</p>
<p>
<asp:Label ID="lblDepartamento" runat="server" Text="Departamento" Width="100">
</asp:Label><asp:DropDownList ID="cboDepartamento" runat="server" 
        AutoPostBack="true" 
        onselectedindexchanged="cboDepartamento_SelectedIndexChanged"></asp:DropDownList>
</p>
<p>
<asp:Label ID="lblProducto" runat="server" Text="Producto" Width="100"></asp:Label>
<asp:DropDownList ID="cboProducto" runat="server" 
AutoPostBack="true" 
        onselectedindexchanged="cboProducto_SelectedIndexChanged" />
<asp:RequiredFieldValidator ID="RangeValidator2" ControlToValidate="cboProducto" runat="server" Text="Campo Requerido" CssClass="failureNotification"></asp:RequiredFieldValidator>
</p>

<p>
<asp:Label ID="lblCosto" Text="Costo" runat="server" Width="100"></asp:Label>
<asp:TextBox ID="txtCosto" runat="server" ontextchanged="txtCosto_TextChanged" AutoPostBack="true" ></asp:TextBox>
<asp:RequiredFieldValidator ID="RangeValidator3" ControlToValidate="txtCosto" runat="server" Text="Campo Requerido" CssClass="failureNotification"></asp:RequiredFieldValidator>
</p>
<p>
<asp:Label ID="lblProcentaje" Text="Ganancia" runat="server" Width="100"></asp:Label>
<asp:TextBox ID="txtGanancia" runat="server"></asp:TextBox>
</p>
<p>
<asp:Label ID="lblVenta" Text="Venta" runat="server" Width="100"></asp:Label>
<asp:TextBox ID="txtVenta" runat="server"></asp:TextBox>
</p>

<asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" Text="Guardar" />
</asp:Content>

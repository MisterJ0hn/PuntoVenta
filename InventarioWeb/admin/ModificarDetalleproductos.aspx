<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="ModificarDetalleproductos.aspx.cs" Inherits="InventarioWeb.admin.ModificarDetalleproductos" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Modificar Producto</h2>
<asp:Label ID="lblAlerta" CssClass="alertaP"  runat="server"></asp:Label>
<p>
<asp:HiddenField ID="hdIdDetalleproducto" runat="server" />
<asp:Label ID="lblCodigo" runat="server" Text="Codigo" Width="100"></asp:Label>
<asp:TextBox ID="txtCodigo" runat="server" ></asp:TextBox>
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
<asp:Label ID="lblBoleta" runat="server" Text="Incluir en Boleta" Width="100"></asp:Label>
<asp:DropDownList ID="cboEnBoleta" runat="server">
<asp:ListItem Value="1" Text="SI"></asp:ListItem>
<asp:ListItem Value="0" Text="NO"></asp:ListItem>
</asp:DropDownList>
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
<asp:TextBox ID="txtVenta" runat="server" ontextchanged="txtVenta_TextChanged" AutoPostBack="true"></asp:TextBox>
</p>

<asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="AgregarPromocion.aspx.cs" Inherits="InventarioWeb.admin.AgregarPromocion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Agregar Promocion</h1>
<div  style="border:1px">
<p>
<asp:Label ID="lblNombre" Text="Nombre" runat="server"></asp:Label>
<asp:TextBox ID="txtNombre" runat="server" AutoPostBack="true" ></asp:TextBox>
</p>
<p>
<asp:Label ID="Label1" Text="Codigo" runat="server"></asp:Label>
<asp:TextBox ID="txtCodigo" runat="server"  AutoPostBack="true" ></asp:TextBox>
</p>
<p>
<asp:Label ID="Label2" Text="Precio" runat="server"></asp:Label>
<asp:TextBox ID="txtPrecio" runat="server"  AutoPostBack="true" ></asp:TextBox>
</p>
</div>

<div>
<p>
    <asp:HiddenField ID="hdIdProducto" runat="server" />
</p>
<p>
    <asp:Label ID="lblCodigo" Text="Codigo" runat="server"></asp:Label>
    <asp:TextBox ID="txtCodigoDetalle" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label3" Text="Descripcion" runat="server"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="lblCantidad" Text="Cantidad" runat="server"></asp:Label>
    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
    <input id="Reset1" type="reset" value="reset" /></p>

<p class="submitButton">
    <asp:Button ID="btnAgregar" Text="Guardar" runat="server" 
        onclick="btnAgregar_Click" />
</p>
<p>
    <asp:GridView ID="GridProductos" runat="server">
    </asp:GridView>
</p>
</div>
<asp:Button ID="btnFinalizar" Text="Finalizar" runat="server" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="AgregarPromocion.aspx.cs" Inherits="InventarioWeb.admin.AgregarPromocion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Agregar Promocion</h1>
<div  style="border:1px">
<asp:Label ID="lblError" runat="server" CssClass="alertaN"></asp:Label>
<p>
<asp:Label ID="lblNombre" Text="Nombre" runat="server" Width="100"></asp:Label>
<asp:TextBox ID="txtNombre" runat="server"  ></asp:TextBox>
</p>
<p>
<asp:Label ID="Label1" Text="Codigo" runat="server" Width="100"></asp:Label>
<asp:TextBox ID="txtCodigo" runat="server"  ></asp:TextBox>
</p>
<p>
<asp:Label ID="Label2" Text="Precio" runat="server" Width="100"></asp:Label>
<asp:TextBox ID="txtPrecio" runat="server"   ></asp:TextBox>
</p>
</div>

<div>

    <asp:HiddenField ID="hdIdProducto" runat="server" />

    <asp:Label ID="lblCodigo" Text="Codigo" runat="server" Width="100"></asp:Label>
    <asp:TextBox ID="txtCodigoDetalle" runat="server" AutoPostBack="true" 
        ontextchanged="txtCodigoDetalle_TextChanged1"></asp:TextBox>

    <asp:Label ID="Label3" Text="Descripcion" runat="server" Width="100"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>

    <asp:Label ID="lblCantidad" Text="Cantidad" runat="server" Width="100"></asp:Label>
    <asp:TextBox ID="txtCantidad" runat="server" ></asp:TextBox>
    
<p class="submitButton">
    <asp:Button ID="btnAgregar" Text="Agregar al listado" runat="server" 
        onclick="btnAgregar_Click" />
</p>
<p>
    <asp:GridView ID="GridProductos" runat="server">
    </asp:GridView>
</p>
</div>
<asp:Button ID="btnFinalizar" Text="Finalizar Promocion" runat="server" 
        onclick="btnFinalizar_Click" />
</asp:Content>

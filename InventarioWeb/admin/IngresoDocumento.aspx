<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="IngresoDocumento.aspx.cs" Inherits="InventarioWeb.admin.IngresoDocumento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Datos de Factura
   
    </h1>
    <asp:Label ID="Alerta" runat="server"></asp:Label>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnCodigo">
<asp:TextBox ID="Codigo" runat="server" OnTextChanged="Codificar"  AutoPostBack="true" ></asp:TextBox>
<asp:Button ID="btnCodigo" runat="server" onclick="Codificar" style="display:none"/>
</asp:Panel>
<asp:Button ID="btnHabilitar" Text="Habilitar ingreso manual" runat="server" 
        onclick="btnHabilitar_Click" />
<p>
<asp:Label ID="lbl1" runat="server" Text="Rut Proveedor" Width="150" Enabled="false"></asp:Label>
<asp:TextBox ID="txtRutEmpresa" runat="server" AutoPostBack="true" OnTextChanged="FiltraEmpresa" Enabled="false"></asp:TextBox>
</p>
<p>
<asp:Label ID="Label1" runat="server" Text="Nombre Proveedor" Width="150" ></asp:Label>
<asp:TextBox ID="txtNombreProveedor" runat="server" Enabled="false"></asp:TextBox>
</p>
<p>
<asp:Label ID="Label2" runat="server" Text="Numero Factura" Width="150" Enabled="false"></asp:Label>
<asp:TextBox ID="txtNumero" runat="server" Enabled="false"></asp:TextBox>
</p>

<p>
<asp:Label ID="Label3" runat="server" Text="Monto" Width="150" Enabled="false"></asp:Label>
<asp:TextBox ID="txtMonto" runat="server" Enabled="false"></asp:TextBox>
</p>
<p>
<asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
        onclick="btnGuardar_Click" />
</p>
<p>
<asp:button ID="btnAgregarProductos" Text="Agregar Productos" runat="server" 
        onclick="btnAgregarProductos_Click"  />
</p>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="AgregarProveedor.aspx.cs" Inherits="InventarioWeb.admin.AgregarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h1><asp:Label ID="Label1" Text="Agregar Proveedor" runat="server"></asp:Label></h1>
<p>
<asp:Label ID="lblRut" runat="server" Text="Rut" Width="100"></asp:Label>
<asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator id="vldRut" runat="server" ControlToValidate="txtRut" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator><br />
<asp:CustomValidator ID="vldRut2" runat="server" OnServerValidate="ValidarRut" ControlToValidate="txtRut" ErrorMessage="Debe Ingresar Un Rut Correcto" ForeColor="Red"></asp:CustomValidator>
</p>
<p>
<asp:Label ID="lblNombre" runat="server" Text="Nombre" Width="100"></asp:Label>
<asp:TextBox ID="txtNombre" runat="server" >
</asp:TextBox>
<asp:RequiredFieldValidator id="vldNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>
</p>
<p>
<asp:Label ID="lblRazonSocial" runat="server" Text="Razon Social" Width="100"></asp:Label>
<asp:TextBox ID="txtRazonSocial" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator id="vldRazonSocial" runat="server" ControlToValidate="txtRazonSocial" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>
</p>
<p class="submitButton">
<asp:Button runat="server" Text="Ingresar" Width="70px"  ID="btnAgregar" 
        onclick="btnAgregar_Click"/>
<input type="reset" value="Limpiar" />
</p>




</asp:Content>

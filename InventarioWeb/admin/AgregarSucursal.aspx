<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="InventarioWeb.admin.AgregarSucursal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1><asp:Label ID="Label1" Text="Agregar Sucursal" runat="server"></asp:Label></h1>
<asp:HiddenField ID="hdRut" runat="server" />

<p>
<asp:Label ID="lblNombre" runat="server" Text="Nombre" Width="70"></asp:Label>
<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ID="vldNombre" ForeColor="Red" ErrorMessage="Campo requerido">
</asp:RequiredFieldValidator>
</p>
<p>
<asp:Label ID="lblDireccion" runat="server" Text="Direccion" Width="70"></asp:Label>
<asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" ControlToValidate="txtDireccion" ID="vldDireccion" ForeColor="Red" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>

</p>
<p>
<asp:Label ID="lblTelefono" runat="server" Text="Telefono" Width="70"></asp:Label>
<asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" ControlToValidate="txtTelefono" ID="vldTelefono" ForeColor="Red" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
   </p> 
   
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <p>
    <asp:Label ID="lblRegion" runat="server" Text="Region" Width="70"></asp:Label>
<asp:DropDownList ID="cboRegion" runat="server" 
            onselectedindexchanged="cboRegion_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
<asp:RequiredFieldValidator runat="server" ControlToValidate="cboRegion" ID="vldRegion" ForeColor="Red" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
   </p>
   <p><asp:Label ID="lblCiudad" runat="server" Text="Ciudad" Width="70"></asp:Label>
<asp:DropDownList ID="cboCiudad" runat="server" 
           onselectedindexchanged="cboCiudad_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
<asp:RequiredFieldValidator runat="server" ControlToValidate="cboCiudad" ID="vldCiudad" ForeColor="Red" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
   </p>
   <p><asp:Label ID="lblComuna" runat="server" Text="Comuna" Width="70"></asp:Label>
<asp:DropDownList ID="cboComuna" runat="server"></asp:DropDownList>
<asp:RequiredFieldValidator runat="server" ControlToValidate="cboComuna" ID="vldCOmuna" ForeColor="Red" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
   </p> 
   </ContentTemplate>
    </asp:UpdatePanel>

<p class="submitButton">
<asp:Button runat="server" Text="Agregar" Width="70px"  ID="btnAgregar" onclick="btnAgregar_Click" 
        />
        </p>
</asp:Content>

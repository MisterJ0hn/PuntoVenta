<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="InventarioWeb.admin.AgregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><asp:Label Text="Detalle de Usuario" runat="server"></asp:Label></h1>
<p>
<asp:Label ID="lblNombre" runat="server" Text="Nombre" Width="50"></asp:Label>
<asp:TextBox ID="txtNombre" runat="server" >
</asp:TextBox>
<asp:RequiredFieldValidator id="vldNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>
</p>
<p>
<asp:Label ID="lblApellido" runat="server" Text="Apellido" Width="50"></asp:Label>
<asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator id="vldApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>
</p>
<p>
<asp:Label ID="lblMail" runat="server" Text="Mail" Width="50"></asp:Label>
<asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator id="vldMail" runat="server" ControlToValidate="txtMail" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>

</p>
<p>
<asp:Label ID="lblPerfil" runat="server" Text="Pefil" Width="50"></asp:Label>
<select ID="lstPerfil" runat="server">
<option value="1">Administrador</option>
<option value="2">Vendedor</option>
<option value="3">Despacho</option>
</select>
</p>

<asp:ScriptManager ID="ScriptManager1" runat="server" AjaxFrameworkMode="Explicit">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <p>
    <asp:Label ID="lblEmpresa" runat="server" Text="Empresa" Width="50"></asp:Label>
        <asp:DropDownList ID="lstEmpresa" runat="server"
            onselectedindexchanged="lstEmpresa_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList>
   </p> 
    <p> 
    <asp:Label ID="lblSucursal" runat="server" Text="Sucursal" Width="50"></asp:Label>
     <asp:DropDownList ID="lstSucursal" runat="server" >
     </asp:DropDownList>
     <asp:RequiredFieldValidator id="vldSucursal" runat="server" ControlToValidate="lstSucursal" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>

    </p>
  
</ContentTemplate>
</asp:UpdatePanel>



<p>
<asp:Label ID="lblUsuario" runat="server" Text="Usuario" Width="50"></asp:Label>
<asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator id="vldUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="vldUsuario2" runat="server" OnServerValidate="ValidarUsuario" ControlToValidate="txtUsuario" ErrorMessage="El usuario ya existe" ForeColor="Red"></asp:CustomValidator>
</p>
<p>
<asp:Label ID="lblClave" runat="server" Text="Clave" Width="50"></asp:Label>
<asp:TextBox ID="txtClave" runat="server" ></asp:TextBox>
<asp:RequiredFieldValidator id="vldClave" runat="server" ControlToValidate="txtClave" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>


</p>
<br />
<p class="submitButton">
<asp:Button runat="server" Text="Ingresar" Width="70px"  ID="btnAgregar" 
        onclick="btnAgregar_Click"/>
<input type="reset" value="Limpiar" />
</p>
</asp:Content>

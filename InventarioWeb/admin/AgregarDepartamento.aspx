<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="AgregarDepartamento.aspx.cs" Inherits="InventarioWeb.admin.AgregarDepartamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Agregar Departamento</h1>

<p>
<asp:Label ID="lblNombre" Text="Nombre" runat="server" Width="100"></asp:Label> <asp:TextBox ID="txtNombre" runat="server" ></asp:TextBox>
</p>
<p>
<asp:Button ID="btnGuardar" Text="Guardar" runat="server" 
        onclick="btnGuardar_Click" />
</p>
</asp:Content>

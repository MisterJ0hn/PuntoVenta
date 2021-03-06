﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BDG.Master" AutoEventWireup="true" CodeBehind="GestionDocumentos.aspx.cs" Inherits="InventarioWeb.bodega.GestionDocumentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h1>
<asp:Label ID="lblIngresar" Text="Detalle Documentos Ingresados" runat="server"></asp:Label>
</h1>
<p class="submitButton">
<asp:HiddenField ID="hdRutEmpresa" runat="server" />
<asp:Button ID="btnAgregar" runat="server" Text="Ingresar Nuevo Documento" 
        onclick="btnAgregar_Click" /> 
<asp:Button ID="btnProductos" runat="server" Text="Ingresar Productos" onclick="btnProductos_Click" 
     />
</p>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataKeyNames="RutEmpresa" DataSourceID="SqlDataSource1" GridLines="Horizontal"
        onrowcommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="IdDocumento" HeaderText="IdDocumento" 
                SortExpression="IdDocumento" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="NombreEmpresa" HeaderText="Nombre Empresa" 
                SortExpression="NombreEmpresa" />
            <asp:BoundField DataField="RutEmpresa" HeaderText="Rut Empresa" 
                SortExpression="RutEmpresa" />
            <asp:BoundField DataField="NumeroDocumento" HeaderText="Numero" 
                SortExpression="NumeroDocumento" />
            <asp:BoundField DataField="FechaingresoDocumento" 
                HeaderText="Fecha Ingreso" 
                SortExpression="FechaingresoDocumento" />
            <asp:BoundField DataField="MontototalDocumento" 
                HeaderText="Monto Total" SortExpression="MontototalDocumento" />
            <asp:BoundField DataField="EstadoDocumento" HeaderText="Estado" 
                SortExpression="EstadoDocumento" />
            <asp:BoundField DataField="UsuarioRegistro" HeaderText="Usuario Registro" 
                SortExpression="UsuarioRegistro" />

            <asp:ButtonField ButtonType="Button" Text="Detalle" CommandName="Detalle" />
            <asp:ButtonField ButtonType="Button" Text="Eliminar" CommandName="Eliminar" />
            
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString4 %>" 
        SelectCommand="SELECT DOCUMENTO.IdDocumento, EMPRESA.NombreEmpresa, EMPRESA.RutEmpresa, DOCUMENTO.NumeroDocumento, DOCUMENTO.FechaingresoDocumento, 
        DOCUMENTO.MontototalDocumento, ESTADODOCUMENTO.EstadoDocumento, CONCAT(USUARIO.NombreUsuario,' ', USUARIO.ApellidoUsuario ) AS UsuarioRegistro
        FROM DOCUMENTO 
        INNER JOIN EMPRESA ON DOCUMENTO.RutproveedorDocumento = EMPRESA.RutEmpresa 
        INNER JOIN ESTADODOCUMENTO ON DOCUMENTO.EstadoDocumento = ESTADODOCUMENTO.IdEstadoDocumento 
        INNER JOIN USUARIO ON DOCUMENTO.IdUsuarioRegistro = USUARIO.IdUsuario 
        WHERE (DOCUMENTO.IdTipomovimiento = 1) AND (DOCUMENTO.EstadoDocumento &lt;&gt; 5) AND (DOCUMENTO.RutEmpresa = @rutEmpresa)">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdRutEmpresa" Name="rutEmpresa" Type="String"/>
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

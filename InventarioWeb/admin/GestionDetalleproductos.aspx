<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionDetalleproductos.aspx.cs" Inherits="InventarioWeb.admin.GestionDetalleproductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>DETALLE PRODUCTOS
    </h1>
    <asp:Button ID="btnAgregar" Text="Crear Producto" runat="server" />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" GridLines="Horizontal">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:BoundField DataField="CodigoDetalleproducto" 
            HeaderText="Codigo" SortExpression="CodigoDetalleproducto" />
        <asp:BoundField DataField="DescripcionDetalleproducto" 
            HeaderText="Nombre" 
            SortExpression="DescripcionDetalleproducto" />
        <asp:BoundField DataField="TipoproductoProducto" 
            HeaderText="Producto" SortExpression="TipoproductoProducto" />
        <asp:BoundField DataField="TipodepartamentoDepartamento" 
            HeaderText="Departamento" 
            SortExpression="TipodepartamentoDepartamento" />
        <asp:BoundField DataField="PreciocompraDetalleproducto" 
            HeaderText="Precio Compra" 
            SortExpression="PreciocompraDetalleproducto" />
        <asp:BoundField DataField="ProcentajegananciaDetalleproducto" 
            HeaderText="Ganancia" 
            SortExpression="ProcentajegananciaDetalleproducto" />
        <asp:BoundField DataField="PrecioventaDetalleproducto" 
            HeaderText="Precio Venta" 
            SortExpression="PrecioventaDetalleproducto" />
        <asp:ButtonField ButtonType="Button" Text="Editar" />
        <asp:ButtonField ButtonType="Button" Text="Eliminar" />
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
        ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString4 %>" SelectCommand="SELECT DP.CodigoDetalleproducto, DP.DescripcionDetalleproducto, P.TipoproductoProducto, D.TipodepartamentoDepartamento, 
DP.PreciocompraDetalleproducto, DP.ProcentajegananciaDetalleproducto, DP.PrecioventaDetalleproducto
FROM DETALLEPRODUCTO DP, PRODUCTO P, DEPARTAMENTO D
WHERE DP.IdProducto=p.IdProducto
AND P.IdDepartamento=D.IdDepartamento
"></asp:SqlDataSource>
</asp:Content>

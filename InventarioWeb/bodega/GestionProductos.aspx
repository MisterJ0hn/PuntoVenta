<%@ Page Title="" Language="C#" MasterPageFile="~/BDG.Master" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="InventarioWeb.bodega.GestionProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Productos</h1>

<p>
<asp:Button ID="btnAgregar" Text="Agregar" runat="server" />
</p>

<p>
    <asp:Label ID="lblFiltrar" Text="Filtrar" runat="server"></asp:Label><asp:TextBox ID="txtFiltrar" runat="server" ></asp:TextBox><asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
    </p>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataKeyNames="IdProducto" DataSourceID="SqlDataSource1" GridLines="Horizontal">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" 
                InsertVisible="False" ReadOnly="True" SortExpression="IdProducto" />
            <asp:BoundField DataField="TipoproductoProducto" 
                HeaderText="TipoproductoProducto" SortExpression="TipoproductoProducto" />
            <asp:BoundField DataField="PorcentajeGanancia" HeaderText="PorcentajeGanancia" 
                SortExpression="PorcentajeGanancia" />
            <asp:BoundField DataField="TipodepartamentoDepartamento" 
                HeaderText="TipodepartamentoDepartamento" 
                SortExpression="TipodepartamentoDepartamento" />
            <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
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
        SelectCommand="SELECT PRODUCTO.IdProducto, PRODUCTO.TipoproductoProducto, PRODUCTO.PorcentajeGanancia, DEPARTAMENTO.TipodepartamentoDepartamento FROM DEPARTAMENTO INNER JOIN PRODUCTO ON DEPARTAMENTO.IdDepartamento = PRODUCTO.IdDepartamento"
        FilterExpression="(TipoproductoProducto like '%{0}%' OR TipodepartamentoDepartamento like '%{0}%')"
        >
        <FilterParameters>
        <asp:ControlParameter ControlID="txtFiltrar" PropertyName="text" />
        </FilterParameters>
    </asp:SqlDataSource>
</asp:Content>

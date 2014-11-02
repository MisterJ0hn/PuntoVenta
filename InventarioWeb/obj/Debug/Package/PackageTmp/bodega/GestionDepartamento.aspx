<%@ Page Title="" Language="C#" MasterPageFile="~/BDG.Master" AutoEventWireup="true" CodeBehind="GestionDepartamento.aspx.cs" Inherits="InventarioWeb.bodega.GestionDepartamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Departamento</h1>
<p>
<asp:Button ID="btnAgregar" Text="Agregar" runat="server" 
        onclick="btnAgregar_Click" />
</p>
<p>
    <asp:Label ID="lblFiltrar" Text="Filtrar" runat="server"></asp:Label><asp:TextBox ID="txtFiltrar" runat="server" ></asp:TextBox><asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
    </p>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataKeyNames="IdDepartamento" DataSourceID="SqlDataSource1" 
        GridLines="Horizontal" PageSize="30"
         onrowcommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="IdDepartamento" HeaderText="IdDepartamento" 
                SortExpression="IdDepartamento" />
            <asp:BoundField DataField="TipodepartamentoDepartamento" 
                HeaderText="Nombre" 
                SortExpression="TipodepartamentoDepartamento" />
            <asp:BoundField DataField="PorcentajeGananciaDepartamento" 
                HeaderText="Ganancia" 
                SortExpression="PorcentajeGananciaDepartamento" />
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
        SelectCommand="SELECT [TipodepartamentoDepartamento], [IdDepartamento],PorcentajeGananciaDepartamento  FROM [DEPARTAMENTO]"
        FilterExpression="TipodepartamentoDepartamento like '%{0}%'"
        >
        <FilterParameters>
        <asp:ControlParameter ControlID="txtFiltrar" PropertyName="text" />
        </FilterParameters>
    </asp:SqlDataSource>
</asp:Content>

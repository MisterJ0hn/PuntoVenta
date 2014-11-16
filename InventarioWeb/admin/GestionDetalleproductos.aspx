<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionDetalleproductos.aspx.cs" Inherits="InventarioWeb.admin.GestionDetalleproductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>DETALLE PRODUCTOS
    </h1>
    


    <asp:Panel ID="Panel1" runat="server">
    <p>
    <asp:Button ID="btnAgregar" Text="Ingresar Detalle Producto sin documento" runat="server" 
    onclick="btnAgregar_Click" />
    </p>
    <asp:Button ID="btnProductos" Text="Lista Productos" runat="server" 
            onclick="btnProductos_Click" />
    <asp:Button ID="btnDepartamento" Text="Lista Departamentos" runat="server" 
            onclick="btnDepartamento_Click" />
    </asp:Panel>


    <p>
    <asp:Label ID="lblFiltrar" Text="Filtrar" runat="server"></asp:Label><asp:TextBox ID="txtFiltrar" runat="server" ></asp:TextBox><asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
    </p>
    <p>
    
    </p>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" GridLines="Vertical" PageSize="50"
        onrowcommand="GridView1_RowCommand" ShowFooter="True" 
        ShowHeaderWhenEmpty="True" ViewStateMode="Enabled" 
        >
    <AlternatingRowStyle BackColor="#DCDCDC" />
    <Columns>
        <asp:BoundField DataField="CodigoDetalleproducto" 
            HeaderText="Codigo" 
            SortExpression="CodigoDetalleproducto" />
        <asp:BoundField DataField="DescripcionDetalleproducto" 
            HeaderText="Descripcion" 
            SortExpression="DescripcionDetalleproducto" />
        <asp:BoundField DataField="TipoproductoProducto" 
            HeaderText="Producto" SortExpression="TipoproductoProducto" />
        <asp:BoundField DataField="TipodepartamentoDepartamento" 
            HeaderText="Departamento" 
            SortExpression="TipodepartamentoDepartamento" />
        <asp:BoundField DataField="PreciocompraDetalleproducto" 
            HeaderText="Precio Compra" 
            SortExpression="PreciocompraDetalleproducto" />
        <asp:BoundField DataField="PorcentajegananciaDetalleproducto" 
            HeaderText="Procentaje Ganancia" 
            SortExpression="PorcentajegananciaDetalleproducto" />
        <asp:BoundField DataField="PrecioventaDetalleproducto" 
            HeaderText="Precio Venta" 
            SortExpression="PrecioventaDetalleproducto" />
        <asp:BoundField DataField="CantidadStock" HeaderText="Stock" 
            SortExpression="CantidadStock" />
        <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
        <asp:TemplateField HeaderText="Cantidad">
        <ItemTemplate>
            <asp:TextBox ID="txtCantidad" runat="server" Text="1" Width="50"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField Text="Vender" ButtonType="Button"  CommandName="Vender"  />
    </Columns>
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#0000A9" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString4 %>" 
        SelectCommand="SELECT DP.CodigoDetalleproducto, DP.DescripcionDetalleproducto, P.TipoproductoProducto, D.TipodepartamentoDepartamento, DP.PreciocompraDetalleproducto, DP.PorcentajegananciaDetalleproducto, DP.PrecioventaDetalleproducto, STOCK.CantidadStock 
        FROM DETALLEPRODUCTO AS DP 
        INNER JOIN PRODUCTO AS P ON DP.IdProducto = P.IdProducto 
        INNER JOIN DEPARTAMENTO AS D ON P.IdDepartamento = D.IdDepartamento 
        LEFT OUTER JOIN STOCK ON DP.IdDetalleproducto = STOCK.IdDetalleproducto"

        FilterExpression="( DescripcionDetalleproducto like '%{0}%' OR TipoproductoProducto like '%{0}%' OR TipodepartamentoDepartamento like '%{0}%')">
<FilterParameters>
    <asp:ControlParameter ControlID="txtFiltrar" PropertyName="text"/>
</FilterParameters>

</asp:SqlDataSource>
</asp:Content>

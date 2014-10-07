<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="IngresarProductos.aspx.cs" Inherits="InventarioWeb.admin.IngresarProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Ingreso de Productos</h1>
<p><asp:label ID="lblFactura" Text="Facturas" runat="server"></asp:label>
<asp:DropDownList ID="cboFacturas" runat="server" AutoPostBack="true" 
        onselectedindexchanged="cboFacturas_SelectedIndexChanged" >
</asp:DropDownList>
</p>
<p>
<asp:Label ID="lblMonto" Text="Monto" runat="server"></asp:Label>
<asp:Label ID="Monto" Text="" runat="server"></asp:Label>
</p>
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <h2>Ingresar Producto</h2>
            <p>
            <asp:Label ID="lblCodigo" runat="server" Text="Codigo" ></asp:Label><asp:TextBox ID="txtCodigo" runat="server" ></asp:TextBox> <asp:Label ID="Label1" runat="server" Text="Descripcion" ></asp:Label><asp:TextBox ID="txtDescripcion" runat="server" ></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="lblDepartamento" runat="server" Text="Departamento" ></asp:Label><asp:DropDownList ID="cboDepartamento" runat="server" ></asp:DropDownList><asp:Label ID="lblProducto" runat="server" Text="Producto" ></asp:Label><asp:DropDownList ID="cboProducto" runat="server" />
            </p>
            <asp:Button ID="btnGuardar" runat="server" />
        
            <h2>Detalle</h2>
            <p>

                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    DataSourceID="SqlDataSource1" GridLines="Horizontal">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
        
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" 
                            SortExpression="Codigo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                            SortExpression="Descripcion" />
                        <asp:BoundField DataField="TipoProducto" HeaderText="TipoProducto" 
                            SortExpression="TipoProducto" />
                        <asp:BoundField DataField="TipoDepartamento" HeaderText="TipoDepartamento" 
                            SortExpression="TipoDepartamento" />       
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" 
                            SortExpression="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" 
                            SortExpression="Precio" />
                        <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                        <asp:TemplateField>
                            <FooterTemplate>
                                <asp:TextBox ID="txtCodigo" runat="server" ></asp:TextBox>
                                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                                <asp:DropDownList ID="cboTipoProducto" runat="server"></asp:DropDownList>
                                <asp:DropDownList ID="cboTipoDepartamento" runat="server"></asp:DropDownList>
                                <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
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
                    ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString3 %>" SelectCommand="
            SELECT P.TipoProducto, D.TipoDepartamento, DP.Descripcion, DP.Codigo, DD.Cantidad, DD.Precio, DD.Total FROM PRODUCTO P, DETALLE_PRODUCTO DP, DEPARTAMENTO D, DETALLEDOCUMENTO DD
            WHERE P.IdProducto=DP.IdProducto 
            AND P.IdDepartamento=D.IdDepartamento
            AND DP.IdDetalle_Producto=DD.IdDetalleProducto AND DD.NumeroDocumento='@NumeroFactura' ">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cboFacturas" PropertyName="SelectedValue" Name="NumeroFactura" Type="String" />
                    </SelectParameters></asp:SqlDataSource>

            </p>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

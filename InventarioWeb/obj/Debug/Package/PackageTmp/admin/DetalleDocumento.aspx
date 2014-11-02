<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="DetalleDocumento.aspx.cs" Inherits="InventarioWeb.admin.DetalleDocumento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h1>Detalle Documento</h1>
 <asp:HiddenField ID="hdDocumento" runat="server" />
<p><asp:label ID="lblFactura" Text="Factura" runat="server"></asp:label>
<asp:TextBox ID="txtFactura" runat="server"></asp:TextBox>
</p>
<p>
<asp:Label ID="Label2" Text="RutEmpresa" runat="server" Width="100"></asp:Label>
<asp:Label ID="lblRutEmpresa" Text="" runat="server"></asp:Label>
</p>

<p>
<asp:Label ID="label1" Text="Monto" runat="server" Width="100"></asp:Label>
<asp:Label ID="lblMonto" Text="" runat="server"></asp:Label>
</p>

<p>
<asp:Label ID="label3" Text="Monto" runat="server" Width="100"></asp:Label>
<asp:Label ID="lblMontoDetalle" Text="" runat="server"></asp:Label>
</p>

                 
            <h2>Detalle</h2>
            <p>

                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    DataSourceID="SqlDataSource1" GridLines="Horizontal"
                    DataKeyNames="IdDetalledocumento"
                    
                    >
                    <AlternatingRowStyle BackColor="#F7F7F7" />
        
                    <Columns>
                        <asp:BoundField DataField="IdDetalledocumento" HeaderText="Id" 
                            SortExpression="IdDetalledocumento" />
                        <asp:BoundField DataField="TipoproductoProducto" HeaderText="Producto" 
                            SortExpression="TipoproductoProducto" />
                        <asp:BoundField DataField="TipodepartamentoDepartamento" HeaderText="Departamento" 
                            SortExpression="TipodepartamentoDepartamento" />
                        <asp:BoundField DataField="DescripcionDetalleproducto" HeaderText="Descripcion Producto" 
                            SortExpression="DescripcionDetalleproducto" />
                        <asp:BoundField DataField="CodigoDetalleproducto" HeaderText="Codigo" 
                            SortExpression="CodigoDetalleproducto" />       
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" 
                            SortExpression="Cantidad" />
                        <asp:BoundField DataField="PrecioCosto" HeaderText="Precio Costo" 
                            SortExpression="PrecioCosto" />
                        
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
                    ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString4 %>" SelectCommand="
            SELECT DD.IdDetalledocumento,P.TipoproductoProducto, D.TipodepartamentoDepartamento, DP.DescripcionDetalleproducto, DP.CodigoDetalleproducto, DD.Cantidad, DD.PrecioCosto
            FROM PRODUCTO P, DETALLEPRODUCTO DP, DEPARTAMENTO D, DETALLEDOCUMENTO DD
            WHERE P.IdProducto=DP.IdProducto 
            AND P.IdDepartamento=D.IdDepartamento
            AND DP.IdDetalleproducto=DD.IdDetalleproducto
            AND DD.IdDocumento=@IdDocumento"
            DeleteCommand="DELETE FROM DETALLEDOCUMENTO WHERE IdDetalledocumento=@IdDetalledocumento"
                >
                
                <SelectParameters>
                <asp:ControlParameter ControlID="hdDocumento" Name="IdDocumento" />
                </SelectParameters>
            </asp:SqlDataSource>

            </p>
</asp:Content>

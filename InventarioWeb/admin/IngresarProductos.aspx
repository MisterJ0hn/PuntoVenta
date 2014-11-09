<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="IngresarProductos.aspx.cs" Inherits="InventarioWeb.admin.IngresarProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 390px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ingreso de Productos</h1>
<p><asp:label ID="lblFactura" Text="Facturas" runat="server"></asp:label>
<asp:DropDownList ID="cboFacturas" runat="server" AutoPostBack="true" 
        onselectedindexchanged="cboFacturas_SelectedIndexChanged" >
</asp:DropDownList>
</p>
<p>
<asp:Label ID="Label2" Text="RutEmpresa" runat="server" Width="130"></asp:Label>
<asp:Label ID="lblRutEmpresa" Text="" runat="server"></asp:Label>
</p>
<p>
<asp:Label ID="label1" Text="Monto Total Factura" runat="server" Width="130"></asp:Label>
<asp:Label ID="lblMonto" Text="" runat="server"></asp:Label>
</p>
<asp:Label ID="lblMontoDetalle" runat="server" Visible="false"></asp:Label>
        <h2>Ingresar Producto
    </h2><table style="width:100%;">
            <tr>
                <td class="style1">
            <asp:Label ID="lblCodigo" runat="server" Text="Codigo" Width="100"></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server" AutoPostBack="true" 
                    ontextchanged="txtCodigo_TextChanged"></asp:TextBox>
                </td>
                <td>
            <asp:Label ID="LblDescripcion" runat="server" Text="Descripcion" Width="100"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" ></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="vldDescripcion" ControlToValidate="txtDescripcion" ErrorMessage="Debes ingresar una descripcion" CssClass="alertaN" runat="server"></asp:RequiredFieldValidator>
                </td>
               
            </tr>
            <tr>
                <td class="style1">
            <asp:Label ID="lblDepartamento" runat="server" Text="Departamento" Width="100">
            </asp:Label><asp:DropDownList ID="cboDepartamento" runat="server" 
                    AutoPostBack="true" 
                    onselectedindexchanged="cboDepartamento_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
            <asp:Label ID="lblProducto" runat="server" Text="Producto" Width="100"></asp:Label>
            <asp:DropDownList ID="cboProducto" runat="server" />
                </td>
               
            </tr>
            <tr>
                
                <td class="style1" colspan="2">
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnGuardar">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblCantidad" runat="server" Text="Cantidad Unitaria" Width="100"></asp:Label>
                                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                                    <br />
                                    <asp:RegularExpressionValidator id="vldCantidad" runat="server" ControlToValidate="txtCantidad" ValidationExpression="\d*" Display="Static" ErrorMessage="Debes ingresar un numero" CssClass="alertaN"></asp:RegularExpressionValidator>
         
                                </td>
                                <td>
                                    <asp:Label ID="lblPrecio" Text="Precio Compra" runat="server" Width="100"></asp:Label>
                                    <asp:TextBox ID="txtPrecio" runat="server" 
                                        ontextchanged="txtPrecio_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <br />
                                        <asp:RegularExpressionValidator ID="vldCompra" runat="server" ControlToValidate="txtPrecio" ValidationExpression="\d*" Display="Static" ErrorMessage="Debes ingresar un numero" CssClass="alertaN"></asp:RegularExpressionValidator>
         
                                </td>
                                <td rowspan="3" valign="middle">
                                     <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" Text="Ingresar a Listado" Enabled="false"/></td>

                            </tr>
                            <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblGanancia" Text="% Ganancia" runat="server" Width="100"></asp:Label>
                                <asp:TextBox ID="txtGanancia" runat="server"  ontextchanged="txtPrecio_TextChanged" AutoPostBack="true"
                                    ></asp:TextBox>
                                 <br />
                                        <asp:RegularExpressionValidator ID="vldGanancia" runat="server" ControlToValidate="txtGanancia" ValidationExpression="\d*\.?\d*" Display="Static" ErrorMessage="Debes ingresar un numero" CssClass="alertaN"></asp:RegularExpressionValidator>
         
                            </td>
                            </tr>
                            <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblVenta" Text="Precio Venta" runat="server" Width="100"></asp:Label>
                                <asp:TextBox ID="txtVenta" runat="server" ontextchanged="txtVenta_TextChanged1"  AutoPostBack="true"></asp:TextBox>
                                 <br />
                                        <asp:RegularExpressionValidator ID="vldVenta" runat="server" ControlToValidate="txtVenta" ValidationExpression="\d*" Display="Static" ErrorMessage="Debes ingresar un numero" CssClass="alertaN"></asp:RegularExpressionValidator>
         
                            </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
     
            </tr>
            <tr>
                <td class="style1">
          
                </td>
                <td>
           
            <asp:Label ID="Label7" runat="server" Text="Caja" Width="100"  Visible="false"></asp:Label>
            <asp:TextBox ID="txtCaja" runat="server"  Visible="false"></asp:TextBox>
           
                </td>
               
            </tr>
            <tr>
                <td class="style1">
            
                </td>
                <td>
           <asp:Label ID="Label5" runat="server" Text="Lote" Width="100" Visible="false"></asp:Label>
            <asp:TextBox ID="txtLote" runat="server" Visible="false"></asp:TextBox>
           
           
                </td>
               
            </tr>
            </table>
           
             
        
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
                        <asp:BoundField DataField="IdDetalledocumento" HeaderText="Id Detalle" 
                            SortExpression="IdDetalledocumento" />
                        <asp:BoundField DataField="TipoproductoProducto" HeaderText="TipoproductoProducto" 
                            SortExpression="TipoproductoProducto" />
                        <asp:BoundField DataField="TipodepartamentoDepartamento" HeaderText="TipodepartamentoDepartamento" 
                            SortExpression="TipodepartamentoDepartamento" />
                        <asp:BoundField DataField="DescripcionDetalleproducto" HeaderText="DescripcionDetalleproducto" 
                            SortExpression="DescripcionDetalleproducto" />
                        <asp:BoundField DataField="CodigoDetalleproducto" HeaderText="CodigoDetalleproducto" 
                            SortExpression="CodigoDetalleproducto" />       
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" 
                            SortExpression="Cantidad" />
                        <asp:BoundField DataField="PrecioCosto" HeaderText="PrecioCosto" 
                            SortExpression="PrecioCosto" />
                        <asp:BoundField DataField="Ganancia" HeaderText="Ganancia" SortExpression="Ganancia" Visible="false"/>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
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
            SELECT DD.IdDetalledocumento,P.TipoproductoProducto, D.TipodepartamentoDepartamento, DP.DescripcionDetalleproducto, DP.CodigoDetalleproducto, DD.Cantidad, DD.PrecioCosto, DD.Ganancia
            FROM PRODUCTO P, DETALLEPRODUCTO DP, DEPARTAMENTO D, DETALLEDOCUMENTO DD
            WHERE P.IdProducto=DP.IdProducto 
            AND P.IdDepartamento=D.IdDepartamento
            AND DP.IdDetalleproducto=DD.IdDetalleproducto
            AND DD.IdDocumento=@IdDocumento"
            DeleteCommand="DELETE FROM DETALLEDOCUMENTO WHERE IdDetalledocumento=@IdDetalledocumento"
                >
                <DeleteParameters>
                    <asp:Parameter Name="IdDetalledocumento" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                <asp:ControlParameter ControlID="cboFacturas" Name="IdDocumento" />
                </SelectParameters>
            </asp:SqlDataSource>

            </p>
            <asp:Button ID="btnIngresar" runat="server" Text="Guardar Documento" OnClick="btnIngresar_Click" Enabled="false" CausesValidation="False" />
</asp:Content>

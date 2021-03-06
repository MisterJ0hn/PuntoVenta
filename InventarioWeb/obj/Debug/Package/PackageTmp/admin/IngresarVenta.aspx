﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="IngresarVenta.aspx.cs" Inherits="InventarioWeb.admin.IngresarVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" language="javascript">
    function ProdNoExiste()
    {
        if (confirm("El codigo no existe, deseas crearlo?")) {
            window.location.href = "AgregarDetalleproducto.aspx";
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="1" cellpadding="0" cellspacing="0">
<tr>
<td width="200px" valign="top">
<h2>Ingreso</h2>


<p>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:HiddenField ID="hdIdDocumento" runat="server" />
    <asp:HiddenField ID="hdIdDetalle" runat="server" />
    <p>
        &nbsp;<asp:Panel ID="Panel1" runat="server" DefaultButton="btnCodigo">
        <asp:Button ID="btnCodigo" runat="server" onclick="txtCodigo_TextChanged" style="display:none"/>
<asp:Label ID="lblCodigo" runat="server" Text="Codigo" Width="100"></asp:Label>

<asp:TextBox ID="txtCodigo" runat="server"  AutoPostBack="true" OnTextChanged="txtCodigo_TextChanged"/>
<asp:RequiredFieldValidator ID="vldCodigo" Text="Campo Requerido" runat="server" ControlToValidate="txtCodigo"></asp:RequiredFieldValidator>
<br />
<asp:Label ID="lblCOdigoError" runat="server"></asp:Label>
</asp:Panel>
        <p>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Nombre" Width="100"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Precio" Width="100"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server" />
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Disponible" Width="100"></asp:Label>
            <asp:TextBox ID="txtDisp" runat="server" />
        </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Cantidad" Width="100"></asp:Label>
            <asp:TextBox ID="txtCantidad" runat="server" /><br />
            <asp:Label ID="lblCantError" runat="server" CssClass="alertaN"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblFP" runat="server" Text="Forma de Pago"></asp:Label>
            <asp:DropDownList ID="cboFormapago" runat="server">
            </asp:DropDownList>
        
</p>

    </ContentTemplate>
    </asp:UpdatePanel>

</td>
<td valign="top">
<h2>Detalle
    </h2>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataKeyNames="IdDetalledocumento" DataSourceID="SqlDataSource1" 
        ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="IdDetalledocumento" HeaderText="ID" 
            InsertVisible="False" ReadOnly="True" SortExpression="IdDetalledocumento" />
        <asp:BoundField DataField="CodigoDetalleproducto" 
            HeaderText="Codigo" SortExpression="CodigoDetalleproducto" />
        <asp:BoundField DataField="TipoproductoProducto" 
            HeaderText="Tipo" SortExpression="TipoproductoProducto" />
        <asp:BoundField DataField="DescripcionDetalleproducto" 
            HeaderText="Nombre" 
            SortExpression="DescripcionDetalleproducto" />
        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" 
            SortExpression="Cantidad" />
        <asp:BoundField DataField="PrecioVenta" HeaderText="Valor"
            SortExpression="PrecioVenta" />
        <asp:BoundField DataField="Total" HeaderText="Total" 
            SortExpression="Total" /> 
    </Columns>
    <FooterStyle BackColor="#CCCC99" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
    <RowStyle BackColor="#F7F7DE" />
    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#FBFBF2" />
    <SortedAscendingHeaderStyle BackColor="#848384" />
    <SortedDescendingCellStyle BackColor="#EAEAD3" />
    <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString4 %>" 
        SelectCommand="SELECT DD.IdDetalledocumento, P.TipoproductoProducto, DP.DescripcionDetalleproducto, DP.CodigoDetalleproducto, DD.Cantidad, DD.PrecioVenta, (DD.Cantidad* DD.PrecioVenta) as Total
        FROM PRODUCTO AS P 
        INNER JOIN DETALLEPRODUCTO AS DP ON P.IdProducto = DP.IdProducto 
        INNER JOIN DETALLEDOCUMENTO AS DD ON DP.IdDetalleproducto = DD.IdDetalleproducto
        WHERE DD.IdDocumento=@IdDocumento">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdIdDocumento" Name="IdDocumento" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</td>
</tr>
<tr>
<td><p class="submitButton">
<asp:ImageButton ID="btnAgregar" runat="server" Height="80px" ImageUrl="~/Imagenes/agregar.png" 
        Width="80px" onclick="btnAgregar_Click" />

<asp:ImageButton ID="btnEliminar" runat="server" Height="80px" 
    ImageUrl="~/Imagenes/eliminar.png" Width="80px" onclick="btnEliminar_Click"/>
</p>
<p>

<asp:ImageButton ID="btnFinalizar" runat="server" 
    ImageUrl="~/Imagenes/finalizar.png" onclick="btnFinalizar_Click" CausesValidation="False" Height="80px" Width="160px"/>
</p>
</td>
<td>
<h2>
<asp:Label ID="lbl1" runat="server" Text="Neto"></asp:Label> <asp:Label ID="lblNeto" runat="server"></asp:Label>
</h2>
<h2>
<asp:Label ID="Label3" runat="server" Text="IVA"></asp:Label> <asp:Label ID="lblIva" runat="server"></asp:Label>
</h2>
<h2>
<asp:Label ID="Label4" runat="server" Text="Total"></asp:Label> <asp:Label ID="lblTotal" runat="server"></asp:Label>
</h2>
<h2>
<asp:Label ID="Label5" runat="server" Text="Total A Cobrar"></asp:Label> <asp:Label ID="lblTotalCobrar" runat="server"></asp:Label>
</h2>
</td>
</tr>
</table>
</asp:Content>

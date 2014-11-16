<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="ModificarPromocion.aspx.cs" Inherits="InventarioWeb.admin.ModificarPromocion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Agregar Promocion</h1>
<div  style="border:1px">
<asp:Label ID="lblError" runat="server" CssClass="alertaN"></asp:Label>
<asp:HiddenField ID="hdIdPromo" runat="server" />
<p>
<asp:Label ID="lblNombre" Text="Nombre" runat="server" Width="100"></asp:Label>
<asp:TextBox ID="txtNombre" runat="server"  ></asp:TextBox>
</p>
<p>
<asp:Label ID="Label1" Text="Codigo" runat="server" Width="100"></asp:Label>
<asp:TextBox ID="txtCodigo" runat="server"  ></asp:TextBox>
</p>
<p>
<asp:Label ID="Label2" Text="Precio" runat="server" Width="100"></asp:Label>
<asp:TextBox ID="txtPrecio" runat="server"   ></asp:TextBox>
</p>
</div>

<div>

    <asp:HiddenField ID="hdIdProducto" runat="server" />

    <asp:Label ID="lblCodigo" Text="Codigo" runat="server" Width="100"></asp:Label>
    <asp:TextBox ID="txtCodigoDetalle" runat="server" AutoPostBack="true" 
        ontextchanged="txtCodigoDetalle_TextChanged1"></asp:TextBox>

    <asp:Label ID="Label3" Text="Descripcion" runat="server" Width="100"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>

    <asp:Label ID="lblCantidad" Text="Cantidad" runat="server" Width="100"></asp:Label>
    <asp:TextBox ID="txtCantidad" runat="server" ></asp:TextBox>
    
<p class="submitButton">
    <asp:Button ID="btnAgregar" Text="Agregar al listado" runat="server" 
        onclick="btnAgregar_Click" />
</p>
<p>
    <asp:GridView ID="GridProductos" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataKeyNames="IdDetallepromociones" 
        DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="IdDetallepromociones" HeaderText="ID" 
                InsertVisible="False" ReadOnly="True" SortExpression="IdDetallepromociones" />
            <asp:BoundField DataField="CodigoDetalleproducto" HeaderText="Codigo" 
                SortExpression="CodigoDetalleproducto" />
            <asp:BoundField DataField="DescripcionDetalleproducto" HeaderText="Detalle" 
                SortExpression="DescripcionDetalleproducto" />
            <asp:BoundField DataField="CantidadDetallepromocion" HeaderText="Cantidad" 
                SortExpression="CantidadDetallepromocion" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
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
        DeleteCommand="DELETE FROM DETALLEPROMOCIONES where IdDetallepromociones=@IdDetallepromociones" 
        SelectCommand="SELECT DETALLEPROMOCIONES.IdDetallepromociones, DETALLEPRODUCTO.CodigoDetalleproducto, DETALLEPRODUCTO.DescripcionDetalleproducto, 
        DETALLEPROMOCIONES.CantidadDetallepromocion 
        FROM DETALLEPRODUCTO 
        INNER JOIN DETALLEPROMOCIONES ON DETALLEPRODUCTO.IdDetalleproducto = DETALLEPROMOCIONES.IdDetalleproducto
        WHERE IdPromociones=@IdPromo">
        <DeleteParameters>
            <asp:Parameter Name="IdDetallepromociones" Type="Int32" /> 
        </DeleteParameters>
        <SelectParameters >
            <asp:ControlParameter ControlID="hdIdPromo" Name="IdPromo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</p>
</div>
<asp:Button ID="btnFinalizar" Text="Finalizar Promocion" runat="server" 
        onclick="btnFinalizar_Click" />
</asp:Content>

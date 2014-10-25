<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="ImportarStock.aspx.cs" Inherits="InventarioWeb.admin.ImportarStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Importar excel</h1>
<asp:HiddenField ID="hdDocumento" runat="server" Value="0" />

<p>
<asp:Label ID="lblSucursal" Text="Sucursal" runat="server"></asp:Label>
<asp:DropDownList ID="cboSucursal" runat="server" ></asp:DropDownList>
<asp:Button ID="btnIngresarStock1" runat="server" Text="Ingresar Stock Inicial" 
    onclick="btnIngresarStock1_Click" />
</p>

   <asp:Panel ID="PnlImportar" runat="server">
        
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Cargar" 
        OnClick="btnUpload_Click" />
        <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
        Text="Generar Documento de Ingreso" />
        
        <br />
        
        <asp:GridView ID="GridView1" runat="server"  AllowPaging = "True" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
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
        <br />
        <p>
            <asp:Label ID="lblErrores" Text="Codigos con Errores" runat="server" Visible="false"></asp:Label>
        </p>
        <p>

            <asp:ListBox ID="lstErrores" runat="server" AutoPostBack="True" Visible="false"></asp:ListBox>
        </p>
    </asp:Panel>
    <asp:Panel ID="pnlDocActivos" runat="server">
    <p>
        <asp:Label ID="lbl1" Text="Existe un Ingreso que no se a concretado" runat="server"></asp:Label>
    </p> 
        <asp:GridView ID="GridView2" runat="server" 
    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
    BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
    CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="CodigoDetalleproducto" 
                    HeaderText="CodigoDetalleproducto" SortExpression="CodigoDetalleproducto" />
                <asp:BoundField DataField="DescripcionDetalleproducto" 
                    HeaderText="DescripcionDetalleproducto" 
                    SortExpression="DescripcionDetalleproducto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" 
            SortExpression="Cantidad" />
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
    
            SelectCommand="SELECT DETALLEDOCUMENTO.IdDocumento, DETALLEPRODUCTO.CodigoDetalleproducto, DETALLEPRODUCTO.DescripcionDetalleproducto,DETALLEDOCUMENTO.Cantidad 
            FROM DETALLEDOCUMENTO 
            INNER JOIN DETALLEPRODUCTO ON DETALLEDOCUMENTO.IdDetalleproducto = DETALLEPRODUCTO.IdDetalleproducto"
            FilterExpression="IdDocumento={0}">
            <FilterParameters>
                <asp:ControlParameter ControlID="hdDocumento" Name="IdDocumento" PropertyName="Value" />
            </FilterParameters>
        </asp:SqlDataSource>
    
    </asp:Panel>

    
    <br />
</asp:Content>

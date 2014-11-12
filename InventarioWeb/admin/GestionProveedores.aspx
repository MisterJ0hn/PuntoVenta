<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionProveedores.aspx.cs" Inherits="InventarioWeb.admin.GestionProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="submitButton">
<asp:Button ID="btnAgregar" Text="Agregar Usuario" runat="server" 
        onclick="btnAgregar_Click" />
        </p>
        <p>
        <asp:TextBox ID="txtBusqueda" runat="server"></asp:TextBox> 
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
        </p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="RutEmpresa" DataSourceID="SqlDataSource1" 
    AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#E7E7FF" 
    BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal"
    onrowcommand="GridView1_RowCommand"
    >
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="RutEmpresa" HeaderText="RutEmpresa" ReadOnly="True" 
                SortExpression="RutEmpresa" />
            <asp:BoundField DataField="NombreEmpresa" HeaderText="NombreEmpresa" 
                SortExpression="NombreEmpresa" />
            <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" 
                SortExpression="RazonSocial" />
            <asp:ButtonField ButtonType="Button" Text="Editar" CommandName="ModificarProveedor" />
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
        ConnectionString="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=InventarioWeb;Data Source=HANSZUÑIGA-PC"
        SelectCommand="SELECT [RutEmpresa], [NombreEmpresa], '' as RazonSocial FROM [EMPRESA] WHERE ([IdMaestra] = @IdMaestra) and IdTipoempresa=2"
        FilterExpression=" (RutEmpresa like '%{0}%' OR NombreEmpresa like '%{0}%' OR RazonSocial like '%{0}%') "
        >
        <SelectParameters>
            <asp:SessionParameter Name="IdMaestra" SessionField="idMaestra" Type="Int32" />
        </SelectParameters>
        <FilterParameters>
            <asp:ControlParameter ControlID="txtBusqueda" PropertyName="text" />
        </FilterParameters>
    </asp:SqlDataSource>
</asp:Content>

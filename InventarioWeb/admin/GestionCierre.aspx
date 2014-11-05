<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionCierre.aspx.cs" Inherits="InventarioWeb.admin.GestionCierre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p>
<asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
        onclick="btnAgregar_Click" />
</p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="IdCierre" DataSourceID="SqlDataSource1" 
        OnRowCommand="Grid_RowCommand" 
        >
        <Columns>
            <asp:BoundField DataField="IdCierre" HeaderText="IdCierre" 
                InsertVisible="False" ReadOnly="True" SortExpression="IdCierre" />
            <asp:BoundField DataField="FechaCierre" HeaderText="FechaCierre" 
                SortExpression="FechaCierre" />
            <asp:BoundField DataField="Computador" HeaderText="Computador" 
                SortExpression="Computador" />
            <asp:BoundField DataField="Ingresos" HeaderText="Ingresos" 
                SortExpression="Ingresos" />
            <asp:BoundField DataField="NombreSucursal" HeaderText="NombreSucursal" 
                SortExpression="NombreSucursal" />
            <asp:BoundField DataField="NombreUsuario" HeaderText="NombreUsuario" 
                SortExpression="NombreUsuario" />
            <asp:BoundField DataField="ApellidoUsuario" HeaderText="ApellidoUsuario" 
                SortExpression="ApellidoUsuario" />
            <asp:ButtonField ButtonType="Button" Text="Ver" CommandName="ver"/>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString4 %>" 
        SelectCommand="SELECT CIERRECAJA.IdCierre, CIERRECAJA.FechaCierre, CIERRECAJA.Computador, CIERRECAJA.Ingresos, SUCURSAL.NombreSucursal, USUARIO.NombreUsuario, USUARIO.ApellidoUsuario FROM CIERRECAJA INNER JOIN USUARIO ON CIERRECAJA.UsuarioCierre = USUARIO.IdUsuario INNER JOIN SUCURSAL ON CIERRECAJA.IdSucursalCierre = SUCURSAL.IdSucursal">
    </asp:SqlDataSource>


</asp:Content>

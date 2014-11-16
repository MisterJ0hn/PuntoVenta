<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionCierre.aspx.cs" Inherits="InventarioWeb.admin.GestionCierre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p>
<asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
        onclick="btnAgregar_Click" />
</p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="IdCierrecaja" DataSourceID="SqlDataSource1" 
        OnRowCommand="Grid_RowCommand" 
        >
        <Columns>
            <asp:BoundField DataField="IdCierrecaja" HeaderText="ID" 
                InsertVisible="False" ReadOnly="True" SortExpression="IdCierrecaja" />
            <asp:BoundField DataField="FechaCierrecaja" HeaderText="FechaCierre" 
                SortExpression="FechaCierrecaja" />
            <asp:BoundField DataField="SistemaCierrecaja" HeaderText="Computador" 
                SortExpression="SistemaCierrecaja" />
            <asp:BoundField DataField="IngresoCierrecaja" HeaderText="Ingresos" 
                SortExpression="IngresoCierrecaja" />
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
        SelectCommand="SELECT CIERRECAJA.IdCierrecaja, CIERRECAJA.FechaCierrecaja, CIERRECAJA.SistemaCierrecaja, CIERRECAJA.IngresoCierrecaja, SUCURSAL.NombreSucursal, USUARIO.NombreUsuario, USUARIO.ApellidoUsuario 
        FROM CIERRECAJA 
        INNER JOIN USUARIO ON CIERRECAJA.IdUsuario = USUARIO.IdUsuario 
        INNER JOIN SUCURSAL ON CIERRECAJA.IdSucursal = SUCURSAL.IdSucursal">
    </asp:SqlDataSource>


</asp:Content>

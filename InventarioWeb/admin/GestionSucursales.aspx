<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionSucursales.aspx.cs" Inherits="InventarioWeb.admin.GestionSucursales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="NombreSucursal" HeaderText="NombreSucursal" 
            SortExpression="NombreSucursal" />
        <asp:BoundField DataField="DireccionSucursal" HeaderText="DireccionSucursal" 
            SortExpression="DireccionSucursal" />
        <asp:BoundField DataField="RutEmpresa" HeaderText="RutEmpresa" 
            SortExpression="RutEmpresa" />
        <asp:BoundField DataField="TelefonoSucursal" HeaderText="TelefonoSucursal" 
            SortExpression="TelefonoSucursal" />
        <asp:BoundField DataField="NombreComuna" HeaderText="NombreComuna" 
            SortExpression="NombreComuna" />
        <asp:BoundField DataField="NombreCiudad" HeaderText="NombreCiudad" 
            SortExpression="NombreCiudad" />
        <asp:BoundField DataField="NombreRegion" HeaderText="NombreRegion" 
            SortExpression="NombreRegion" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    
        ConnectionString="Data Source=localhost;Initial Catalog=InventarioWeb;User ID=sa;Password=955763" SelectCommand="SELECT S.NombreSucursal, S.DireccionSucursal, S.RutEmpresa,S.TelefonoSucursal, C.NombreComuna, CI.NombreCiudad, R.NombreRegion
FROM SUCURSAL S, COMUNA C, CIUDAD CI,  REGION R
WHERE S.IdComuna=C.IdComuna
AND C.IdCiudad=CI.IdCiudad
AND CI.IdRegion=R.IdRegion
"></asp:SqlDataSource>
</asp:Content>

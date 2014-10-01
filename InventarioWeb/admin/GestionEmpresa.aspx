<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionEmpresa.aspx.cs" Inherits="InventarioWeb.admin.GestionEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
    DataKeyNames="RutEmpresa" DataSourceID="SqlDataSource1" GridLines="Horizontal">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:BoundField DataField="RutEmpresa" HeaderText="RutEmpresa" ReadOnly="True" 
            SortExpression="RutEmpresa" />
        <asp:BoundField DataField="NombreEmpresa" HeaderText="NombreEmpresa" 
            SortExpression="NombreEmpresa" />
        <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" 
            SortExpression="RazonSocial" />
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
    ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString3 %>" 
    SelectCommand="SELECT [RutEmpresa], [NombreEmpresa], [RazonSocial] FROM [EMPRESA]">
</asp:SqlDataSource>
</asp:Content>

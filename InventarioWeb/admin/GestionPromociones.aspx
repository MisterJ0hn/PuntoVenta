<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionPromociones.aspx.cs" Inherits="InventarioWeb.admin.GestionPromociones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnNuevo" Text="Nuevo" runat="server" 
    onclick="btnNuevo_Click" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="IdPromociones" 
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="IdPromociones" HeaderText="IdPromociones" 
                InsertVisible="False" ReadOnly="True" SortExpression="IdPromociones" 
                ShowHeader="False" />
            <asp:BoundField DataField="CodigoPromocion" HeaderText="Codigo" 
                SortExpression="CodigoPromocion" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                SortExpression="Descripcion" />
            <asp:BoundField DataField="PrecioVenta" HeaderText="Precio" 
                SortExpression="PrecioVenta" />
            <asp:ButtonField ButtonType="Button" Text="Ver" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString4 %>" 
        SelectCommand="SELECT * FROM [PROMOCIONES]" 
        DeleteCommand="DELETE FROM PROMOCIONES WHERE IdPromociones=@IdPromociones">
        <DeleteParameters>
            <asp:Parameter Name="IdPromociones" Type="Int32" />
        </DeleteParameters>
        </asp:SqlDataSource>
  
</asp:Content>

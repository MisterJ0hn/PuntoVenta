<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionPromociones.aspx.cs" Inherits="InventarioWeb.admin.GestionPromociones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" type="text/javascript">
    function Eliminar(id) {
        if (confirm("¿Estas seguro de Eliminar este producto?")) {
            __doPostBack('EliminarPromo', id);
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Button ID="btnNuevo" Text="Nuevo" runat="server" onclick="btnNuevo_Click" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="IdPromocion" 
        DataSourceID="SqlDataSource1" onrowcommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdPromocion" HeaderText="ID" 
                InsertVisible="False" ReadOnly="True" SortExpression="IdPromocion" 
                ShowHeader="False" />
            <asp:BoundField DataField="CodigoPromocion" HeaderText="Codigo" 
                SortExpression="CodigoPromocion" />
            <asp:BoundField DataField="DescripcionPromocion" HeaderText="Descripcion" 
                SortExpression="DescripcionPromocion" />
            <asp:BoundField DataField="PrecioventaPromocion" HeaderText="Precio" 
                SortExpression="PrecioventaPromocion" />
            <asp:ButtonField ButtonType="Button" Text="Ver" CommandName="Editar" />
            <asp:ButtonField ButtonType="Button" Text="Eliminar" CommandName="Eliminar"/>
            <asp:TemplateField HeaderText="Cantidad">
        <ItemTemplate>
            <asp:TextBox ID="txtCantidad" runat="server" Text="1" Width="50"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField Text="Vender" ButtonType="Button"  CommandName="Vender"  />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString4 %>" 
        SelectCommand="SELECT * FROM [PROMOCION] WHERE EstadoPromocion=1" 
        DeleteCommand="DELETE FROM PROMOCION WHERE IdPromocion=@IdPromocion">
        <DeleteParameters>
            <asp:Parameter Name="IdPromocion" Type="Int32" />
        </DeleteParameters>
        </asp:SqlDataSource>
</asp:Content>

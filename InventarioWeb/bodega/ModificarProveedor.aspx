<%@ Page Title="" Language="C#" MasterPageFile="~/BDG.Master" AutoEventWireup="true" CodeBehind="ModificarProveedor.aspx.cs" Inherits="InventarioWeb.bodega.ModificarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1><asp:Label ID="Label1" Text="Modificar Proveedor" runat="server"></asp:Label></h1>
<p>
<asp:Label ID="lblRut" runat="server" Text="Rut" Width="100"></asp:Label>
<asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator id="vldRut" runat="server" ControlToValidate="txtRut" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator><br />
</p>
<p>
<asp:Label ID="lblNombre" runat="server" Text="Nombre" Width="100"></asp:Label>
<asp:TextBox ID="txtNombre" runat="server" >
</asp:TextBox>
<asp:RequiredFieldValidator id="vldNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>
</p>

<p class="submitButton">
<asp:Button runat="server" Text="Modificar" Width="70px"  ID="btnModificar" onclick="btnModificar_Click" 
        /><input type="reset" value="Limpiar" /></p>

        <p>
        <asp:Button runat="server" Text="Agregar Sucursal" Width="150px"  ID="Button1" onclick="btnAgregarSucursal_Click" 
        />
        </p>


    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataSourceID="SqlDataSource1" GridLines="Horizontal"
        DataKeyNames="IdSucursal"
        onrowcommand="GridView1_RowCommand"
        >
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="IdSucursal" HeaderText="Id" 
                SortExpression="IdSucursal" />
            <asp:BoundField DataField="RutEmpresa" HeaderText="Rut Empresa" 
                SortExpression="RutEmpresa" />
            <asp:BoundField DataField="NombreSucursal" HeaderText="Nombre Sucursal" 
                SortExpression="NombreSucursal" />
            <asp:BoundField DataField="DireccionSucursal" HeaderText="Direccion Sucursal" 
                SortExpression="DireccionSucursal" />
            <asp:BoundField DataField="TelefonoSucursal" HeaderText="Telefono Sucursal" 
                SortExpression="TelefonoSucursal" />
            <asp:BoundField DataField="NombreComuna" HeaderText="Nombre Comuna" 
                SortExpression="NombreComuna" />
            <asp:BoundField DataField="NombreCiudad" HeaderText="Nombre Ciudad" 
                SortExpression="NombreCiudad" />
            <asp:BoundField DataField="NombreRegion" HeaderText="Nombre Region" 
                SortExpression="NombreRegion" />
            <asp:ButtonField ButtonType="Button" Text="Editar" CommandName="Editar"/>
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
        ConnectionString="Data Source=localhost;Initial Catalog=InventarioWeb;User ID=sa;Password=955763"
        SelectCommand="SELECT IdSucursal, S.RutEmpresa, S.NombreSucursal, S.DireccionSucursal, S.TelefonoSucursal,C.NombreComuna, CI.NombreCiudad, R.NombreRegion 
        FROM SUCURSAL S, COMUNA C, CIUDAD CI, REGION R WHERE ([RutEmpresa] = @RutEmpresa) and S.IdComuna=c.IdComuna and c.IdCiudad=CI.IdCiudad and CI.IdRegion=R.IdRegion"
        DeleteCommand="DELETE FROM SUCRUSAL WHERE IdSucursal=@IdSucursal"
        >

        <DeleteParameters>
            <asp:Parameter Name="IdSucursal" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="txtRut" PropertyName="Text" Name="RutEmpresa" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</p>
</asp:Content>

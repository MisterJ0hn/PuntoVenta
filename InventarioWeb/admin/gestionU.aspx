<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionU.aspx.cs" Inherits="InventarioWeb.admin.GestionU" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            font-size: medium;
            font-weight: 700;
        }
        .style3
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <h2 class="bold">
        <strong>
        <span class="style3">BIENVENIDO </span>
        <asp:Label ID="lblNombre" runat="server" 
            CssClass="style2"></asp:Label>
        &nbsp;</strong><asp:Label ID="lblApellido" runat="server" CssClass="style3"></asp:Label>
    </h2>
    <h2 class="bold">
        <strong>
        <span class="style3">EMPRESA </span>
        <asp:Label ID="lblRutEmpresa" runat="server" 
            CssClass="style2"></asp:Label>
        <span class="style3">&nbsp;SUCURSAL </span> 
        <asp:Label ID="lblSucursal" runat="server" CssClass="style3"></asp:Label>
        </strong>
    </h2>
    <p class="submitButton">
    <asp:Button ID="btnAgregar" Text="Agregar Usuario" runat="server" 
        onclick="btnAgregar_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtBusqueda" runat="server" Height="26px" Width="180px"></asp:TextBox> 
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
        </p>


    <asp:HiddenField ID="hdIdMaestra" Value="0" runat="server" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataSourceID="SqlDataSource1" GridLines="Horizontal"
        DataKeyNames="IdUsuario"
        onrowcommand="GridView1_RowCommand"
        >
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            
            <asp:BoundField DataField="IdUsuario" HeaderText="Id" 
                SortExpression="IdUsuario" />
            <asp:BoundField DataField="NombreUsuario" HeaderText="NombreUsuario" 
                SortExpression="NombreUsuario" />
            <asp:BoundField DataField="ApellidoUsuario" HeaderText="Apellido" 
                SortExpression="ApellidoUsuario" />
            <asp:BoundField DataField="UsuarioUsuario" HeaderText="Usuario" 
                SortExpression="UsuarioUsuario" />
            <asp:BoundField DataField="CorreoUsuario" HeaderText="Correo" 
                SortExpression="CorreoUsuario" />
            <asp:BoundField DataField="FechaRegistroUsuario" HeaderText="Fecha Registro" 
                SortExpression="fechaRegistroUsuario" />
            <asp:BoundField DataField="TipoRol" HeaderText="TipoRol" 
                SortExpression="TipoRol" />
            <asp:BoundField DataField="NombreSucursal" HeaderText="NombreSucursal" 
                SortExpression="NombreSucursal" />
            
            <asp:ButtonField ButtonType="Button" Text="Editar" CommandName="ModificarUsuario"/>
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
        ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString4 %>" 
        SelectCommand="select USU.IdUsuario,USU.NombreUsuario,USU.UsuarioUsuario, USU.FechaRegistroUsuario, USU.ApellidoUsuario, USU.CorreoUsuario, ROL.TipoRol, SUC.NombreSucursal
        from USUARIO USU, ROL, SucursalUsuario SU, SUCURSAL SUC, EMPRESA EMP 
        where USU.IdRol = ROL.IdRol 
        and  USU.IdUsuario = SU.IdUsuario 
        and SU.IdSucursal = SUC.IdSucursal 
        and SUC.RutEmpresa = EMP.RutEmpresa 
        and USU.IdMaestra=@IdMaestra"
        DeleteCommand="UPDATE USUARIO SET  ActivoUsuario=2 WHERE IdUsuario=@IdUsuario
        Delete From USUARIO where IdUsuario=@IdUsuario"
        FilterExpression="(NombreUsuario LIKE '%{0}%' OR ApellidoUsuario LIKE '%{0}%' OR UsuarioUsuario LIKE '%{0}%' OR  TipoRol LIKE '%{0}%' OR  NombreSucursal LIKE '%{0}%')"
        >
        <SelectParameters>
            <asp:ControlParameter Name="IdMaestra" Type="String" PropertyName="value" ControlID="hdIdMaestra"/>
            
        </SelectParameters>
        <FilterParameters>
            <asp:ControlParameter ControlID="txtBusqueda" PropertyName="text" />
        </FilterParameters>
        <DeleteParameters>
            <asp:Parameter Name="IdUsuario" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>

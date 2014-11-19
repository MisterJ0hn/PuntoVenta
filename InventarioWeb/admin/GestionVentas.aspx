<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="GestionVentas.aspx.cs" Inherits="InventarioWeb.admin.GestionVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
    <asp:Label ID="Label1" runat="server" Text="Gestion de Ventas"></asp:Label>
    </h1>
    
    <p class="submitButton">
    <asp:Button ID="btnCrear" runat="server" Text="Crear Venta" 
    onclick="btnCrear_Click" />
      </p>
      <asp:HiddenField id="hdIdDocumento" runat="server"  />

      <asp:HiddenField ID="hdRutEmpresa" runat="server" />
            
 
    
   <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataKeyNames="RutEmpresa" DataSourceID="SqlDataSource1" GridLines="Horizontal"
        onrowcommand="GridView1_RowCommand" Width="100%">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="IdDocumento" HeaderText="Id" 
                SortExpression="IdDocumento" />
            <asp:BoundField DataField="NombreEmpresa" HeaderText="Nombre Cliente" 
                SortExpression="NombreEmpresa" ItemStyle-Width="200px" />
            <asp:BoundField DataField="RutEmpresa" HeaderText="Rut Cliente" ReadOnly="True" 
                SortExpression="RutEmpresa" />
            
            <asp:BoundField DataField="FechaingresoDocumento" 
                HeaderText="Fecha Ingreso" SortExpression="FechaingresoDocumento" DataFormatString="{0:f}"/>
            <asp:BoundField DataField="MontototalDocumento" 
                HeaderText="Monto Total" SortExpression="MontototalDocumento"  DataFormatString="{0:C0}"/>
            <asp:BoundField DataField="NombreEstadodocumento" HeaderText="Estado" 
                SortExpression="NombreEstadodocumento" />
           <asp:BoundField DataField="UsuarioRegistro" HeaderText="Usuario Registro" 
                SortExpression="UsuarioRegistro" />
            <asp:ButtonField ButtonType="Button" Text="Editar" CommandName="Editar" />
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
        SelectCommand="SELECT DOCUMENTO.IdDocumento, EMPRESA.NombreEmpresa, EMPRESA.RutEmpresa, DOCUMENTO.NumeroDocumento, DOCUMENTO.FechaingresoDocumento, 
        DOCUMENTO.MontototalDocumento, ESTADODOCUMENTO.nombreEstadodocumento , FORMAPAGO.FormaPago, CONCAT(USUARIO.NombreUsuario,' ', USUARIO.ApellidoUsuario ) AS UsuarioRegistro
        FROM DOCUMENTO 
        INNER JOIN EMPRESA 
        ON DOCUMENTO.RutproveedorDocumento = EMPRESA.RutEmpresa 
        INNER JOIN ESTADODOCUMENTO 
        ON DOCUMENTO.IdEstadoDocumento = ESTADODOCUMENTO.IdEstadoDocumento
        INNER JOIN FORMAPAGO
        ON FORMAPAGO.IdFormapago=DOCUMENTO.IdFormapago
        INNER JOIN USUARIO ON DOCUMENTO.IdUsuario = USUARIO.IdUsuario 
        Where DOCUMENTO.IdTipomovimiento=2 AND DOCUMENTO.IdEstadoDocumento!=5 AND DOCUMENTO.RutEmpresa=@rutEmpresa
        ORDER BY DOCUMENTO.IdEstadoDocumento, DOCUMENTO.IdDocumento Desc">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdRutEmpresa" Name="rutEmpresa" Type="String"/>
        </SelectParameters>
    </asp:SqlDataSource>
   
</asp:Content>

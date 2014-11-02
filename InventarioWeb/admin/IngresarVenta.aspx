<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="IngresarVenta.aspx.cs" Inherits="InventarioWeb.admin.IngresarVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" language="javascript">
    var codigo = "";
    var cantidad = "";
    var funcion = "";
    window.onload = function () {
 
        document.onkeyup = mostrarInformacionCaracter;

    }
    function mostrarInformacionCaracter(evObject) {
        var elCaracter = String.fromCharCode(evObject.which);
        var tecla = evObject.keyCode;
        var validacion = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUBWXYZ1234567890";
        var validaCantidad = "1234567890";
        document.getElementById("Mensaje").innerHTML = tecla;
        if (validacion.indexOf(elCaracter, 0) != -1) {
            if (document.getElementById("ContentPlaceHolder1_hdFuncion").value != "") {
                if (validaCantidad.indexOf(elCaracter, 0) != -1) {

                    if (document.getElementById("ContentPlaceHolder1_txtCodigo").value != "") {
                        cantidad += elCaracter;
                    } else {

                        codigo += elCaracter;
                    }
                }
            } else {
                codigo += elCaracter;
            }
        }
        if (tecla == 13) {
            if (document.getElementById("ContentPlaceHolder1_hdFuncion").value != "") {
                if (codigo != "") {
                    document.getElementById("Mensaje").innerHTML = "El codigo imputado es: "+codigo+", Ahora ingrese cantidad, si imputa por teclado, presione enter";
                    __doPostBack('SeleccionaCodigo', codigo);
                    codigo = "";
                } else {

                    if (document.getElementById("ContentPlaceHolder1_hdFuncion").value == "+") {
                        __doPostBack('AgregarProducto', cantidad);
                        cantidad = "";
                        document.getElementById("ContentPlaceHolder1_hdFuncion").value = "";
                    }
                    if (document.getElementById("ContentPlaceHolder1_hdFuncion").value == "-") {
                        __doPostBack('EliminarProducto', cantidad);
                        cantidad = "";
                        document.getElementById("ContentPlaceHolder1_hdFuncion").value = "";
                    }
                }
            } else {
                if (codigo != "") {
                    document.getElementById("Mensaje").innerHTML = codigo;
                    __doPostBack('AgregarCodigo', codigo);
                    codigo = "";
                    document.getElementById("ContentPlaceHolder1_hdFuncion").value = "";
                } 
            }
        }
        if (tecla == 187) {
            document.getElementById("ContentPlaceHolder1_hdFuncion").value = "+";
            document.getElementById("Mensaje").innerHTML = "Impute Codigo a agregar, si imputa por teclado, presione Enter";
            codigo = "";
            cantidad = "";
            document.getElementById("ContentPlaceHolder1_txtCodigo").value = "";

        }
        if (tecla == 189) {
            document.getElementById("ContentPlaceHolder1_hdFuncion").value = "-";
            document.getElementById("Mensaje").innerHTML = "Impute Codigo a eliminar, si imputa por teclado, presione Enter";
            codigo = "";
            cantidad = "";
            document.getElementById("ContentPlaceHolder1_txtCodigo").value = "";
        }
        document.getElementById("Funcion").innerHTML = document.getElementById("ContentPlaceHolder1_hdFuncion").value;
    }
   

    function ProdNoExiste()
    {
        if (confirm("El codigo no existe, deseas crearlo?")) {
            window.location.href = "AgregarDetalleproducto.aspx";
        }
    }
</script>
    <style type="text/css">
        .style6
        {
            width: 784px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="1" cellpadding="0" cellspacing="0">
<tr>
<td valign="top" class="style6">
<h2>Ingreso</h2>
<asp:TextBox ID="hdFuncion" runat="server" AutoPostBack="true" style="display:none"></asp:TextBox>
Accion: <div id="Funcion"></div>
<div id="Mensaje" ></div>
<p>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:TextBox ID="hdIdDocumento" runat="server" style="display:none"></asp:TextBox>
    <asp:TextBox ID="hdIdDetalle" runat="server" style="display:none"></asp:TextBox>

        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnCodigo">
        <asp:Button ID="btnCodigo" runat="server"  style="display:none"/>
<asp:Label ID="lblCodigo" runat="server" Text="Codigo" Width="100"></asp:Label>

<asp:TextBox ID="txtCodigo" runat="server"  AutoPostBack="true" Enabled="false" style="display:none"/>
<asp:RequiredFieldValidator ID="vldCodigo" Text="Campo Requerido" runat="server" ControlToValidate="txtCodigo"></asp:RequiredFieldValidator>
<br />
<asp:Label ID="lblCOdigoError" runat="server"></asp:Label>
</asp:Panel>
        
        
            
            <asp:TextBox ID="txtNombre" runat="server" style="display:none"/>
        
            
            <asp:TextBox ID="txtPrecio" runat="server" style="display:none"/>
        
             <asp:TextBox ID="txtDisp" runat="server" style="display:none"/>
        
            <asp:TextBox ID="txtCantidad" runat="server" style="display:none"/><br />
            <asp:Label ID="lblCantError" runat="server" CssClass="alertaN" Visible="false"></asp:Label>
        
            <asp:DropDownList ID="cboFormapago" runat="server">
            </asp:DropDownList>

    </ContentTemplate>
    </asp:UpdatePanel>
<asp:ImageButton ID="btnFinalizar" runat="server" 
    ImageUrl="~/Imagenes/finalizar.png" onclick="btnFinalizar_Click" CausesValidation="False" Height="80px" Width="160px"/>
    </td>
    <td>
    
<asp:Label ID="Label4" runat="server" Text="Boleta"></asp:Label> <asp:Label ID="lblTotal" runat="server"></asp:Label>

<h2>
<asp:Label ID="Label5" runat="server" Text="Total A Cobrar"></asp:Label> <asp:Label ID="lblTotalCobrar" runat="server"></asp:Label>
</h2>
</td>
</tr>
<tr>
<td valign="top" colspan="2">
<h2>Detalle
    </h2>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataKeyNames="IdDetalledocumento" DataSourceID="SqlDataSource1" 
        ForeColor="Black" GridLines="Vertical" Width="100%" RowStyle-Font-Size="Large">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="IdDetalledocumento" HeaderText="ID" 
            InsertVisible="False" ReadOnly="True" SortExpression="IdDetalledocumento" ControlStyle-Width="20px" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" 
            SortExpression="Cantidad" ControlStyle-Width="20px"/>
        <asp:BoundField DataField="CodigoDetalleproducto" 
            HeaderText="Codigo" SortExpression="CodigoDetalleproducto" ControlStyle-Width="100px"/>
        
        <asp:BoundField DataField="DescripcionDetalleproducto" 
            HeaderText="Nombre" 
            SortExpression="DescripcionDetalleproducto" />
        <asp:BoundField DataField="Total" HeaderText="Total" 
            SortExpression="Total" ControlStyle-Width="20px" DataFormatString="{0:C}" ItemStyle-Font-Bold="true"/> 
    </Columns>
    <FooterStyle BackColor="#CCCC99" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
    <RowStyle BackColor="#F7F7DE" />
    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#FBFBF2" />
    <SortedAscendingHeaderStyle BackColor="#848384" />
    <SortedDescendingCellStyle BackColor="#EAEAD3" />
    <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:InventarioWebConnectionString4 %>" 
        SelectCommand="SELECT DD.IdDetalledocumento, P.TipoproductoProducto, DP.DescripcionDetalleproducto, DP.CodigoDetalleproducto, DD.Cantidad, DD.PrecioVenta, (DD.Cantidad* DD.PrecioVenta)*1.19 as Total
        FROM PRODUCTO AS P 
        INNER JOIN DETALLEPRODUCTO AS DP ON P.IdProducto = DP.IdProducto 
        INNER JOIN DETALLEDOCUMENTO AS DD ON DP.IdDetalleproducto = DD.IdDetalleproducto
        WHERE DD.IdDocumento=@IdDocumento">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdIdDocumento" Name="IdDocumento" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</td>
</tr>

</table>
</asp:Content>

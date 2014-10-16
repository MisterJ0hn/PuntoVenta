<%@ Page Title="" Language="C#" MasterPageFile="~/BDG.Master" AutoEventWireup="true" CodeBehind="IngresoDocumento.aspx.cs" Inherits="InventarioWeb.bodega.IngresoDocumento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Datos de Factura
   
    </h1>
    <asp:Label ID="Alerta" runat="server"></asp:Label>
<asp:TextBox ID="Codigo" runat="server" OnTextChanged="Codificar"  AutoPostBack="true"></asp:TextBox>
<p>
<asp:Label ID="lbl1" runat="server" Text="Rut Proveedor" Width="150"></asp:Label>
<asp:TextBox ID="txtRutEmpresa" runat="server" AutoPostBack="true" OnTextChanged="FiltraEmpresa"></asp:TextBox>
</p>
<p>
<asp:Label ID="Label1" runat="server" Text="Nombre Proveedor" Width="150"></asp:Label>
<asp:TextBox ID="txtNombreProveedor" runat="server"></asp:TextBox>
</p>
<p>
<asp:Label ID="Label2" runat="server" Text="Numero Factura" Width="150"></asp:Label>
<asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
</p>
<p>
<asp:Label ID="Label4" runat="server" Text="Fecha Vencimiento" Width="150"></asp:Label>
<asp:TextBox ID="txtFechaVenc" runat="server"></asp:TextBox>
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
        BorderColor="#999999" CellPadding="4" 
        Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
        Width="200px" ViewStateMode="Enabled"
        >
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar>
</p>
<p>
<asp:Label ID="Label3" runat="server" Text="Monto" Width="150"></asp:Label>
<asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
</p>
<p>
<asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
        onclick="btnGuardar_Click" />
</p>
<h2>Prueba Caputador Virtual</h2>
<asp:TextBox ID="Capturadora" runat="server"></asp:TextBox> 
    <asp:Button ID="btnCapturadora" runat="server" Text="Capturadora" 
        onclick="btnCapturadora_Click" />
        
</asp:Content>

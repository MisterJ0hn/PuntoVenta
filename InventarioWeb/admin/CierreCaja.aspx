<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="CierreCaja.aspx.cs" Inherits="InventarioWeb.admin.CierreCaja" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            width: 359px;
        }
        .style7
        {
            width: 289px;
        }
        .style8
        {
            width: 255px;
        }
        .style9
        {
            width: 289px;
            height: 503px;
        }
        .style10
        {
            width: 359px;
            height: 503px;
        }
        .style11
        {
            width: 255px;
            height: 503px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cierre de Caja</h1>
    <asp:Button ID="btnGuardar" Text="Cerrar Caja" runat="server" 
        onclick="btnGuardar_Click" />
    <table border="0" cellpadding="0" cellspacing="0" style="vertical-align: top">
    <tr>
        <td align="center" class="style9" valign="top">
            <div style="border: thin solid #000000">
                <h1>Creditos</h1>
                <div style="text-align:left">
                <asp:Label ID="Label3" Text="Detalle" runat="server" Width="100"></asp:Label><asp:TextBox ID="txtDetalleCredito" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label10" Text="Cantidad" runat="server" Width="100"></asp:Label><asp:TextBox ID="txtCantidadCredito" runat="server" Width="70" TextMode="Number"></asp:TextBox><br />
                <asp:Label ID="Label11" Text="Dia" runat="server" Width="100"></asp:Label><asp:TextBox ID="txtDiaCredito" runat="server"  TextMode="Date"></asp:TextBox><br />
                </div>
                <asp:Button ID="Button2" Text="Agregar Credito" runat="server" 

                    onclick="btnAgregarCredito_Click" />
                <asp:GridView ID="GridCreditos" runat="server">
                    
                </asp:GridView>
               
                 <br />
            <br />
            </div>
            
            <div style="border: thin solid #000000">
                <h1>Venta Menor</h1>
                <div style="text-align:left">
                <asp:Label ID="lblDetalleMenor" Text="Detalle" runat="server" Width="100"></asp:Label><asp:TextBox ID="txtDetalleMenor" runat="server"></asp:TextBox><br />
                <asp:Label ID="lblCantidadMenor" Text="Cantidad" runat="server" Width="100"></asp:Label><asp:TextBox ID="txtCantidadMenor" runat="server" Width="70"></asp:TextBox><br />
                </div>
                <asp:Button ID="btnMenor" Text="Agregar Venta Menor" runat="server" 
                    onclick="btnAgregarVentaMenor_Click" />
                <asp:GridView ID="GridVentaMenor" runat="server">

                </asp:GridView> 
                 <br />
            <br />
            </div>
            
        </td>
        <td align="center" class="style10" valign="top">
            
            <div style="border: thin solid #000000">
                <h1>Egresos</h1>
                <div style="text-align:left">
                <asp:Label ID="lblDetalle" Text="Detalle" runat="server" Width="100"></asp:Label><asp:TextBox ID="txtDetalle" runat="server"></asp:TextBox><br />
                <asp:Label ID="lblCantidad" Text="Cantidad" runat="server" Width="100"></asp:Label><asp:TextBox ID="txtCantidad" runat="server" Width="70"></asp:TextBox><br />
                </div>
                <asp:Button ID="btnAgregarEgreso" Text="Agregar Egreso" runat="server" 
                    onclick="btnAgregarEgreso_Click" />
                <asp:GridView ID="GridEgresos" runat="server">

                </asp:GridView> 
                <br />
            <br />
            </div>
             
            
            <div style="border: thin solid #000000">
                <br />
                <br />
                <asp:Label ID="lblDevolucion" Text="Devolucion de Garantia" runat="server" ></asp:Label><asp:TextBox ID="txtDevolucion" runat="server" Text="0" Width="100"></asp:TextBox>
                <br />
                <br />
            </div>
            <div style="border: thin solid #000000">
                <h1>Ingresos</h1>
                <div style="text-align:left">
                <asp:Label ID="lbl" Text="Detalle" runat="server" Width="100"></asp:Label><asp:TextBox ID="txtDetalleIngresos" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label4" Text="Cantidad" runat="server" Width="100"></asp:Label><asp:TextBox ID="txtCantidadIngreso" runat="server" Width="70"></asp:TextBox><br />
                </div>
                <asp:Button ID="Button1" Text="Agregar Ingreso" runat="server" 
                        onclick="btnAgregarIngreso_Click" />
                <asp:GridView ID="GridIngresos" runat="server"
                >
                    
                </asp:GridView>



                 <br />
            <br />
            </div>

        </td>
        <td align="center" class="style11" valign="top">
            <div style="border: thin solid #000000">
                <h1>DETALLE DINERO</h1>
               
                <asp:Label ID="lbl20000" Text="$20000" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="txt20000" runat="server" Text="0" TextMode="Number" OnTextChanged="sumaDetalleDinero" Width="70" AutoPostBack="true"></asp:TextBox><br />
              
                <asp:Label ID="lbl10000" Text="$10000" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="txt10000" runat="server" Text="0" TextMode="Number" OnTextChanged="sumaDetalleDinero" Width="70" AutoPostBack="true"></asp:TextBox><br />
                
              
                <asp:Label ID="lbl5000" Text="$5000" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="txt5000" runat="server" Text="0" TextMode="Number" OnTextChanged="sumaDetalleDinero" Width="70" AutoPostBack="true"></asp:TextBox><br />
                
                <asp:Label ID="lbl2000" Text="$2000" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="txt2000" runat="server" Text="0" TextMode="Number" OnTextChanged="sumaDetalleDinero" Width="70" AutoPostBack="true"></asp:TextBox><br />
                
                <asp:Label ID="lbl1000" Text="$1000" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="txt1000" runat="server" Text="0" TextMode="Number" OnTextChanged="sumaDetalleDinero" Width="70" AutoPostBack="true"></asp:TextBox><br />
               
                <asp:Label ID="lbl500" Text="$500" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="txt500" runat="server" Text="0" TextMode="Number" OnTextChanged="sumaDetalleDinero" Width="70" AutoPostBack="true"></asp:TextBox><br />
               
                <asp:Label ID="lbl100" Text="$100" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="txt100" runat="server" Text="0" TextMode="Number" OnTextChanged="sumaDetalleDinero" Width="70" AutoPostBack="true"></asp:TextBox><br />
                <asp:Label ID="Label9" Text="$50" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="txt50" runat="server" Text="0" TextMode="Number" OnTextChanged="sumaDetalleDinero" Width="70" AutoPostBack="true"></asp:TextBox><br />
              
                <asp:Label ID="lbl10" Text="$10" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="txt10" runat="server" Text="0" TextMode="Number" OnTextChanged="sumaDetalleDinero" Width="70" AutoPostBack="true"></asp:TextBox><br />
              
                <asp:Label ID="Label1" Text="Cheque" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="txtCheque" runat="server" Text="0" TextMode="Number" OnTextChanged="sumaDetalleDinero" Width="70" AutoPostBack="true"></asp:TextBox><br />
                
                <asp:Label ID="Label2" Text="Total" runat="server" Width="100"></asp:Label>
                <asp:TextBox ID="txtTotal" runat="server" Width="70" AutoPostBack="true" Text="0"></asp:TextBox>
                <br />
                <br />
            <div style="border: thin solid #000000">
                <h1>Resumen</h1>
                <asp:Label ID="lbl1" Text="Cr&eacute;ditos" runat="server" Width="100"></asp:Label><asp:TextBox ID="lblCreditos" runat="server" Enabled="false"></asp:TextBox><br />
                <asp:Label ID="label8" Text="Egresos" runat="server" Width="100" ></asp:Label><asp:TextBox ID="lblEgresos" runat="server" Enabled="false"></asp:TextBox><br />
                <asp:Label ID="Label5" Text="Devoluci&oacute;n" runat="server" Width="100" ></asp:Label><asp:TextBox ID="lblDevolucionResumen" runat="server" Enabled="false"></asp:TextBox><br />
                <asp:Label ID="Label6" Text="Efectivo" runat="server" Width="100" ></asp:Label><asp:TextBox ID="lblEfectivo" runat="server" Enabled="false"></asp:TextBox><br />
                <asp:Label ID="Label7" Text="Total" runat="server" Width="100" ></asp:Label><asp:TextBox ID="lblTotalResumen" runat="server" Enabled="false"></asp:TextBox>
                 <br />
            <br />
            </div>
            
            <div style="border: thin solid #000000">
                <h1>Cuadratura</h1>
                <asp:Label ID="lblCuad1" text="Computador" runat="server" Width="100"></asp:Label><asp:TextBox ID="lblComputador" runat="server" Enabled="false"></asp:TextBox><br />
                <asp:Label ID="lblCuad2" Text="Ingresos" runat="server" Width="100"></asp:Label><asp:TextBox ID="lblIngesos" runat="server" Enabled="false"></asp:TextBox><br />
                <asp:Label ID="lblcuad3" Text="Diferencia" runat="server" Width="100"></asp:Label><asp:TextBox ID="lblDiferencia" runat="server" Enabled="false"></asp:TextBox>
            <br />
            <br />
            </div>
            
            </div>
        </td>
    
    </tr>
    
    
    

</table>
</asp:Content>

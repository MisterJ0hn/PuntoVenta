<%@ Page Title="" Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" CodeBehind="DetalleCierre.aspx.cs" Inherits="InventarioWeb.admin.DetalleCierre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p>
    <asp:Button ID="btnExportar" Text="Exportar" runat="server" 
            onclick="btnExportar_Click" />
    </p>
<asp:Panel ID="pnlCierre" runat="server">
<h1>Cierre de Caja</h1>
   <asp:Label ID="lblResponsable" Text="Responsable :" runat="server"></asp:Label><br />
   <asp:Label ID="lblFecha" Text="Fecha :" runat="server"></asp:Label>
    <br />
    
    <table border="0" cellpadding="0" cellspacing="0" style="vertical-align: top" runat="server">
    <tr>
        <td align="center" class="style9" valign="top">
            <div style="border: thin solid #000000">
                <h1>Creditos</h1>
                
               
                <asp:GridView ID="GridCreditos" runat="server">
                    
                </asp:GridView>
               
                 <br />
            <br />
            </div>
            
            <div style="border: thin solid #000000">
                <h1>Venta Menor</h1>
                
                
                <asp:GridView ID="GridVentaMenor" runat="server">

                </asp:GridView> 
                 <br />
            <br />
            </div>
            
        </td>
        <td align="center" class="style10" valign="top">
            
            <div style="border: thin solid #000000">
                <h1>Egresos</h1>
                
                
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
               
                <asp:Label ID="lbl20000" Text="$20000" runat="server" Width="100"></asp:Label>:
                <asp:Label ID="txt20000" runat="server" Text="0" ></asp:Label><br />
              
                <asp:Label ID="lbl10000" Text="$10000" runat="server" Width="100"></asp:Label>:
                <asp:Label ID="txt10000" runat="server" Text="0"></asp:Label><br />
                
              
                <asp:Label ID="lbl5000" Text="$5000" runat="server" Width="100"></asp:Label>:
                <asp:Label ID="txt5000" runat="server" Text="0" ></asp:Label><br />
                
                <asp:Label ID="lbl2000" Text="$2000" runat="server" Width="100"></asp:Label>:
                <asp:Label ID="txt2000" runat="server" Text="0"></asp:Label><br />
                
                <asp:Label ID="lbl1000" Text="$1000" runat="server" Width="100"></asp:Label>:
                <asp:Label ID="txt1000" runat="server" Text="0"></asp:Label><br />
               
                <asp:Label ID="lbl500" Text="$500" runat="server" Width="100"></asp:Label>:
                <asp:Label ID="txt500" runat="server" Text="0" ></asp:Label><br />
               
                <asp:Label ID="lbl100" Text="$100" runat="server" Width="100"></asp:Label>:
                <asp:Label ID="txt100" runat="server" Text="0" ></asp:Label><br />
                <asp:Label ID="Label9" Text="$50" runat="server" Width="100"></asp:Label>:
                <asp:Label ID="txt50" runat="server" Text="0"></asp:Label><br />
              
                <asp:Label ID="lbl10" Text="$10" runat="server" Width="100"></asp:Label>:
                <asp:Label ID="txt10" runat="server" Text="0"></asp:Label><br />
              
                <asp:Label ID="Label1" Text="Cheque" runat="server" Width="100"></asp:Label>:
                <asp:Label ID="txtCheque" runat="server" Text="0"></asp:Label><br />
                
                <asp:Label ID="Label2" Text="Total" runat="server" Width="100"></asp:Label>:
                <asp:Label ID="txtTotal" runat="server" Text="0"></asp:Label>
                <br />
                <br />
            <div style="border: thin solid #000000">
                <h1>Resumen</h1>
                <asp:Label ID="lbl1" Text="Cr&eacute;ditos" runat="server" Width="100"></asp:Label>:<asp:Label ID="lblCreditos" runat="server" ></asp:Label><br />
                <asp:Label ID="label8" Text="Egresos" runat="server" Width="100" ></asp:Label>:<asp:Label ID="lblEgresos" runat="server"></asp:Label><br />
                <asp:Label ID="Label5" Text="Devoluci&oacute;n" runat="server" Width="100" ></asp:Label>:<asp:Label ID="lblDevolucionResumen" runat="server" ></asp:Label><br />
                <asp:Label ID="Label6" Text="Efectivo" runat="server" Width="100" ></asp:Label>:<asp:Label ID="lblEfectivo" runat="server" ></asp:Label><br />
                <asp:Label ID="Label7" Text="Total" runat="server" Width="100" ></asp:Label>:<asp:Label ID="lblTotalResumen" runat="server"></asp:Label>
                 <br />
            <br />
            </div>
            
            <div style="border: thin solid #000000">
                <h1>Cuadratura</h1>
                <asp:Label ID="lblCuad1" text="Computador" runat="server" Width="100"></asp:Label>:<asp:Label ID="lblComputador" runat="server" ></asp:Label><br />
                <asp:Label ID="lblCuad2" Text="Ingresos" runat="server" Width="100"></asp:Label>:<asp:Label ID="lblIngesos" runat="server"></asp:Label><br />
                <asp:Label ID="lblcuad3" Text="Diferencia" runat="server" Width="100"></asp:Label>:<asp:Label ID="lblDiferencia" runat="server"></asp:Label>
            <br />
            <br />
            </div>
            
            </div>
        </td>
    
    </tr>
</table>
</asp:Panel>
</asp:Content>

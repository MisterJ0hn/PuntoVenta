using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Collections;

namespace InventarioWeb.bodega
{
    public partial class IngresoDocumento : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Codigo.Focus();
           
        }
       

        protected void Codificar(object sender, EventArgs e)
        {
            String codigo;
            String[] array;
            ValidaRut esValido = new ValidaRut();
            
            txtRutEmpresa.Text = "";
            txtNombreProveedor.Text = "";
            txtNumero.Text = "";
            
            txtMonto.Text = "";
            codigo = Codigo.Text;
            array = codigo.Split(new char[] { ';' });
            String tipo="";
            foreach (String str in array)
            {
                String[] subArray = str.Split(new char[] { ':' });
                if (subArray[0].ToString() == "RE")
                {
                    txtRutEmpresa.Text = subArray[1].ToString().Replace('\'', '-');
                    txtRutEmpresa.Text = esValido.FormatearRut(txtRutEmpresa.Text);
                }
                if (subArray[0].ToString() == "RS")
                {
                    txtNombreProveedor.Text = subArray[1].ToString();
                }
                if (subArray[0].ToString() == "F")
                {
                    txtNumero.Text = subArray[1].ToString();
                }
                
                if (subArray[0].ToString() == "MNT")
                {
                    txtMonto.Text = subArray[1].ToString();
                }
                if (subArray[0].ToString() == "TD")
                {
                    tipo = subArray[1].ToString();

                }


                //Console.WriteLine(subArray[0].ToString() + " " + subArray[1].ToString());
                
            }
           
            Codigo.Text = "";
        }
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AppEmpresas appEmpresa = new AppEmpresas();
            AppDocumentos appDocumentos = new AppDocumentos();
            ValidaRut esValido = new ValidaRut();

           
            appEmpresa.AppAgregarEmpresa(txtRutEmpresa.Text, txtNombreProveedor.Text, txtNombreProveedor.Text, Convert.ToInt32(Session["idMaestra"].ToString()), 2);
            
            
            if(appDocumentos.AgregarDocumento(Convert.ToInt32(txtNumero.Text), Convert.ToInt32(txtMonto.Text),"", txtRutEmpresa.Text, Session["rutEmpresa"].ToString(),Convert.ToInt32(Session["idUsuario"].ToString())))
            {
                Alerta.CssClass="alertaP";
                Alerta.Text="Documento Salvado";
                txtRutEmpresa.Text = "";
                txtNombreProveedor.Text = "";
                txtNumero.Text = "";
                
                txtMonto.Text = "";
                Codigo.Text = "";
                Codigo.Focus();
            }
            else{
                Alerta.CssClass="alertaN";
                Alerta.Text="El Documento ya ha sido Ingresado!";
            }


        }

        protected void FiltraEmpresa(object sender, EventArgs e)
        {
            AppEmpresas appEmpresa = new AppEmpresas();
            ValidaRut esValido = new ValidaRut();
            txtRutEmpresa.Text = esValido.FormatearRut(txtRutEmpresa.Text);

            if (esValido.validaRut(txtRutEmpresa.Text))
            {
                ArrayList arrEmpresa = appEmpresa.AppSeleccionaEmpresa(txtRutEmpresa.Text);
                if (arrEmpresa.Count > 0)
                {
                    txtNombreProveedor.Text = arrEmpresa[1].ToString();
                    txtNumero.Focus();
                }
                else
                {
                    txtNombreProveedor.Focus();
                }
            }
            else
            {
                Alerta.CssClass = "alertaN";
                Alerta.Text = "El rut ingresado no es valido";
                txtRutEmpresa.Text = "";
                txtRutEmpresa.Focus();
            }
            
        }

        protected void txtRutEmpresa_TextChanged(object sender, EventArgs e)
        {
            AppEmpresas appEmpresa = new AppEmpresas();
            ArrayList arrEmpresa = appEmpresa.AppSeleccionaEmpresa(txtRutEmpresa.Text);
            txtNombreProveedor.Text = arrEmpresa[1].ToString();
        }

       
    }
}
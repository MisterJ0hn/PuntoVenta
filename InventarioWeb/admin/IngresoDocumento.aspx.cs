using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Collections;

namespace InventarioWeb.admin
{
    public partial class IngresoDocumento : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Codigo.Focus();
            Codigo.Text = ".";
        }
       
        protected void btnCapturadora_Click(object sender, EventArgs e)
        {
            
            Codigo.Text=Capturadora.Text;

        }

        protected void Codificar(object sender, EventArgs e)
        {
            String codigo;
            String[] array;

            txtRutEmpresa.Text = "";
            txtNombreProveedor.Text = "";
            txtNumero.Text = "";
            txtFechaVenc.Text = "";
            txtMonto.Text = "";
            codigo = Codigo.Text;
            array = codigo.Split(new char[] { ';' });
            foreach (String str in array)
            {
                String[] subArray = str.Split(new char[] { ':' });
                if (subArray[0].ToString() == "RE")
                {
                    txtRutEmpresa.Text = subArray[1].ToString().Replace('\'', '-');
                }
                if (subArray[0].ToString() == "RS")
                {
                    txtNombreProveedor.Text = subArray[1].ToString();
                }
                if (subArray[0].ToString() == "F")
                {
                    txtNumero.Text = subArray[1].ToString();
                }
                if (subArray[0].ToString() == "FE")
                {
                    txtFechaVenc.Text = subArray[1].ToString().Replace('\'', '-');
                }
                if (subArray[0].ToString() == "MNT")
                {
                    txtMonto.Text = subArray[1].ToString();
                }
                //Console.WriteLine(subArray[0].ToString() + " " + subArray[1].ToString());
            }
            
        }
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AppEmpresas appEmpresa = new AppEmpresas();
            AppDocumentos appDocumentos = new AppDocumentos();
            appEmpresa.AppAgregarEmpresa(txtRutEmpresa.Text, txtNombreProveedor.Text, txtNombreProveedor.Text, Convert.ToInt32(Session["idMaestra"].ToString()), 2);

            if(appDocumentos.AgregarDocumento(Convert.ToInt32(txtNumero.Text), Convert.ToInt32(txtMonto.Text), txtFechaVenc.Text, txtRutEmpresa.Text, Session["rutEmpresa"].ToString()))
            {
                Alerta.CssClass="alertaP";
                Alerta.Text="Documento Salvado";
                txtRutEmpresa.Text = "";
                txtNombreProveedor.Text = "";
                txtNumero.Text = "";
                txtFechaVenc.Text = "";
                txtMonto.Text = "";
                Codigo.Focus();
            }
            else{
                Alerta.CssClass="alertaN";
                Alerta.Text="Documento no ha sido Guardado";
            }


        }

        protected void FiltraEmpresa(object sender, EventArgs e)
        {
            AppEmpresas appEmpresa = new AppEmpresas();
            
            ArrayList arrEmpresa= appEmpresa.AppSeleccionaEmpresa(txtRutEmpresa.Text);

            txtNombreProveedor.Text = arrEmpresa[1].ToString();
        }

        protected void txtRutEmpresa_TextChanged(object sender, EventArgs e)
        {
            AppEmpresas appEmpresa = new AppEmpresas();
            ArrayList arrEmpresa = appEmpresa.AppSeleccionaEmpresa(txtRutEmpresa.Text);
            txtNombreProveedor.Text = arrEmpresa[1].ToString();
        }
    }
}
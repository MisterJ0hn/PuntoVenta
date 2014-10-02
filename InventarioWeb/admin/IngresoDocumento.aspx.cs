using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioWeb.admin
{
    public partial class IngresoDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Codigo.Focus();
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
    }
}
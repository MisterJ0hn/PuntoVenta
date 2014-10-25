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
    public partial class ModificarDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["IdDepartamento"] != null)
            {
                String idDepartamento = Request.Form["IdDepartamento"];

                AppDocumentos appDoc = new AppDocumentos();
                ArrayList arr = new ArrayList();
                arr = appDoc.SeleccionaDepartamento(Convert.ToInt32(idDepartamento));

                txtNombre.Text = arr[2].ToString();
                txtGanancia.Text = arr[1].ToString();
                hdDepartamento.Value = arr[0].ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();

            appDoc.ModificaDepartamento(Convert.ToInt32(hdDepartamento.Value), txtGanancia.Text, txtNombre.Text, chkProductos.Checked,chkDetalle.Checked);


        }
    }
}
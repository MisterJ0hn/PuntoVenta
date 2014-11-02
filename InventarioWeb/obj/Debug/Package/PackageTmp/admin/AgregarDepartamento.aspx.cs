using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;


namespace InventarioWeb.admin
{
    public partial class AgregarDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            appDoc.AgregarDepartamento(txtGanancia.Text,txtNombre.Text);

            Response.Redirect("GestionDepartamento.aspx");
        }
    }
}
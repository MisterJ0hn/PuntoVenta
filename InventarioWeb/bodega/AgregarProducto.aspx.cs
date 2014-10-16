using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Data;

namespace InventarioWeb.bodega
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppDocumentos appDocumentos = new AppDocumentos();
                cboDepartamento.DataSource = (DataTable)appDocumentos.cboDepartamento();
                cboDepartamento.DataTextField = "Nombre";
                cboDepartamento.DataValueField = "Id";
                cboDepartamento.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();

            appDoc.AgregarProductoProducto(txtNombre.Text, Convert.ToInt32(cboDepartamento.SelectedValue), txtGanancia.Text);

            Response.Redirect("GestionProductos.aspx");
        }
    }
}
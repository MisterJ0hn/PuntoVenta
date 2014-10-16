using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;

namespace InventarioWeb.bodega
{
    public partial class GestionDocumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdRutEmpresa.Value = Session["rutEmpresa"].ToString();
            GridView1.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresoDocumento.aspx");
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresarProductos.aspx");
        }

        protected void GridView1_RowCommand(object sender,GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];
                TableCell tabla = row.Cells[0];
                int idDocumento = Convert.ToInt32(tabla.Text);

                AppDocumentos appDoc = new AppDocumentos();

                appDoc.EliminarDetalleIngreso(Convert.ToInt32(Session["idSucursal"].ToString()), idDocumento);

                GridView1.DataBind();
            }

        }
    }
}
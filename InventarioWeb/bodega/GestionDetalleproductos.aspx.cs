using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Collections.Specialized;

namespace InventarioWeb.bodega
{
    public partial class GestionDetalleproductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarDetalleproducto.aspx");
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                WebForm frm = new WebForm();
                GridViewRow row = GridView1.Rows[index];
                TableCell tabla = row.Cells[0];
                String Codigo = tabla.Text;
                NameValueCollection data = new NameValueCollection();
                data.Add("codigo", Codigo);

                frm.RedirectAndPOST(this.Page, "ModificarDetalleproductos.aspx", data);

            }
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionProductos.aspx");
        }

        protected void btnDepartamento_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionDepartamentos.aspx");
        }
    }
}
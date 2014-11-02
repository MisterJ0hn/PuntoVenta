using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioWeb.admin
{
    public partial class GestionProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProveedor.aspx");
        }
        protected void GridView1_RowCommand(object sender,
  GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ModificarProveedor")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];
                TableCell tabla = row.Cells[0];
                String Rut= tabla.Text;

                Response.Redirect("ModificarProveedor.aspx?rut=" + Rut);
            }

        }
    }

}
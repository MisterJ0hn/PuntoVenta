using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioWeb.admin
{
    public partial class GestionU : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            hdIdMaestra.Value   = Session["idMaestra"].ToString();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuario.aspx");
        }

        protected void GridView1_RowCommand(object sender,
  GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ModificarUsuario")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];
                TableCell tabla = row.Cells[0];
                String IdUsuario = tabla.Text;


                Response.Redirect("UpdateUsuario.aspx?usuario=" + IdUsuario);
            }
        }
             
    }
}
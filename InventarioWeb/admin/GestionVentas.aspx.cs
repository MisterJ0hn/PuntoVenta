using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using InventarioWebApp;
using System.Collections.Specialized;

namespace InventarioWeb.admin
{
    public partial class GestionVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            hdRutEmpresa.Value = Session["rutEmpresa"].ToString();
            GridView1.DataBind();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresarVenta.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                WebForm frm = new WebForm();
                GridViewRow row = GridView1.Rows[index];
                TableCell tabla = row.Cells[0];
                String idDocumento = tabla.Text;
                NameValueCollection data = new NameValueCollection();
                data.Add("IdDocumento",idDocumento);

                frm.RedirectAndPOST(this.Page, "IngresarVenta.aspx", data);
                
            }
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];
                TableCell tabla = row.Cells[0];
                int idDocumento = Convert.ToInt32(tabla.Text);

                AppDocumentos appDoc = new AppDocumentos();

                appDoc.EliminarDetalleEgreso(Convert.ToInt32(Session["idSucursal"].ToString()), idDocumento);

                GridView1.DataBind();
            }
        }

    
    }
}
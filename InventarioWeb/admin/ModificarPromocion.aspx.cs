using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Data;

namespace InventarioWeb.admin
{
    public partial class ModificarPromocion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                if (Request.Form["IdDocumento"] != null)
                {
                    String valor = Request.Form["IdPromo"];
                    AppDocumentos appDoc=new AppDocumentos();

                    GridProductos.DataSource =(DataTable)  appDoc.DetallePromociones(Convert.ToInt32(valor));
                    GridProductos.DataBind();

                }
            }
        }

        protected void txtCodigoDetalle_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {

        }
    }
}
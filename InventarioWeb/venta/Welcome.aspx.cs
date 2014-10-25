using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioWeb.venta
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // String nombre = Session["nombrelogeado"].ToString();
            lblBienvenido.Text =  Session["nombrelogeado"].ToString();
            lblRutEmpresa.Text = Session["nombreEmpresa"].ToString();
            lblSucursal.Text = Session["nombreSucursal"].ToString();
        }
    }
}
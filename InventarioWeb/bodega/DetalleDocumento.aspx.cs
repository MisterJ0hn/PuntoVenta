using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Collections;

namespace InventarioWeb.bodega
{
    public partial class DetalleDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String idDocumento = Request.Form["idDocumento"];
            AppDocumentos appDoc = new AppDocumentos();
            ArrayList arr = new ArrayList();
            hdDocumento.Value = idDocumento;
            arr = appDoc.SeleccionaEmpresa(Convert.ToInt32(idDocumento), 2);
            txtFactura.Text = arr[3].ToString();
            lblMonto.Text = arr[5].ToString();
            lblRutEmpresa.Text = arr[1].ToString();
            

        }
    }
}
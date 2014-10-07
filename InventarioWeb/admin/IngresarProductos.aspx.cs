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
    public partial class IngresarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AppDocumentos appDocumento = new AppDocumentos();
            cboFacturas.DataSource = (DataTable) appDocumento.Seleccionafacturas(Session["rutEmpresa"].ToString());
            cboFacturas.DataTextField = "Nombre";
            cboFacturas.DataValueField = "Id";
            cboFacturas.DataBind();
            cboFacturas.Items.Insert(0, "<Seleccione una Factura>");
          
        }

        protected void cboFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppDocumentos appDocumento new AppDocumentos();
            appDocumento.Seleccionafacturas
        }

    }
}
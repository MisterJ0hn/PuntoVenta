using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Data;
using System.Collections;

namespace InventarioWeb.admin
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
            
            int id = appDoc.AgregarProductoProducto(txtNombre.Text, Convert.ToInt32(cboEnBoleta.SelectedValue), txtGanancia.Text, Convert.ToInt32(cboDepartamento.SelectedValue));
            if (id > 0)
            {
                Response.Redirect("GestionProductos.aspx");
            }
        }

        protected void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            ArrayList arr = new ArrayList();
           
          
            arr = appDoc.SeleccionaDepartamento(Convert.ToInt32(cboDepartamento.SelectedValue));

            txtGanancia.Text = arr[1].ToString();
        }
    }
}
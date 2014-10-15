using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Collections;
using System.Collections.Specialized;

namespace InventarioWeb.admin
{
    public partial class IngresarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Request.Form["IdDocumento"] != null)
                {
                    AppDocumentos appDoc = new AppDocumentos();
                    ArrayList arr = new ArrayList();
                    String valor = Request.Form["IdDocumento"];
                    hdIdDocumento.Value = valor;

                    GridView1.DataBind();
                    arr = appDoc.GenerarTotales(Convert.ToInt32(hdIdDocumento.Value));
                    lblNeto.Text = arr[0].ToString();
                    lblIva.Text = arr[1].ToString();
                    lblTotal.Text = arr[2].ToString();
                    lblTotalCobrar.Text = arr[3].ToString();
                }
                else
                {

                    AppDocumentos appDoc = new AppDocumentos();
                    int idDocumento = appDoc.AgregarVenta(Session["rutEmpresa"].ToString());

                    hdIdDocumento.Value = idDocumento.ToString();
                }
            }
            else
            {
               
            }

        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            AppDocumentos appDocumentos = new AppDocumentos();
            ArrayList arrProd = new ArrayList();
            arrProd = appDocumentos.DetalleProductoBuscar(txtCodigo.Text);
            if (arrProd.Count > 0)
            {
                hdIdDetalle.Value = arrProd[0].ToString();
                txtNombre.Text = arrProd[1].ToString();
                txtPrecio.Text = arrProd[6].ToString();
                txtCantidad.Enabled = true;
                txtCantidad.Focus();
            }
            else
            {
                txtCodigo.Text = "";
                vldCodigo.Visible = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            ArrayList arr=new ArrayList();
            appDoc.AgregarDetalledocumento(Convert.ToInt32(hdIdDetalle.Value), Convert.ToInt32(hdIdDocumento.Value), Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtPrecio.Text), 0, 0);

            GridView1.DataBind();
            arr=appDoc.GenerarTotales( Convert.ToInt32(hdIdDocumento.Value));
            lblNeto.Text = arr[0].ToString();
            lblIva.Text = arr[1].ToString();
            lblTotal.Text = arr[2].ToString();
            lblTotalCobrar.Text = arr[3].ToString();

            txtCodigo.Text = "";
            hdIdDetalle.Value ="";
            txtNombre.Text = "";
            txtPrecio.Text ="";
            txtCantidad.Enabled = false;
            txtCodigo.Focus();

        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            ArrayList arr = new ArrayList();
            appDoc.AgregarDetalledocumento(Convert.ToInt32(hdIdDetalle.Value), Convert.ToInt32(hdIdDocumento.Value), Convert.ToInt32(txtCantidad.Text)*-1, Convert.ToInt32(txtPrecio.Text), 0, 0);

            GridView1.DataBind();
            arr = appDoc.GenerarTotales(Convert.ToInt32(hdIdDocumento.Value));
            lblNeto.Text = arr[0].ToString();
            lblIva.Text = arr[1].ToString();
            lblTotal.Text = arr[2].ToString();
            lblTotalCobrar.Text = arr[3].ToString();

            txtCodigo.Text = "";
            hdIdDetalle.Value = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Enabled = false;
            txtCodigo.Focus();

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            vldCodigo.Enabled = false;
            AppDocumentos appDoc = new AppDocumentos();

            appDoc.CerrarVenta(Convert.ToInt32(Session["idSucursal"].ToString()), Convert.ToInt32(hdIdDocumento.Value));

            Response.Redirect("IngresarVenta.aspx");
        }
    }
}
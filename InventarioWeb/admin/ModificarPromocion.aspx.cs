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
    public partial class ModificarPromocion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {

                if (Request.Form["IdPromo"] != null)
                {
                    String valor = Request.Form["IdPromo"];
                    AppDocumentos appDoc=new AppDocumentos();
                    DataTable dt = new DataTable();
                    hdIdPromo.Value = valor;
                    dt = appDoc.SeleccionaPromocion(Convert.ToInt32(valor));

                    foreach (DataRow row in dt.Rows)
                    {
                        txtCodigo.Text = row["CodigoPromocion"].ToString();
                        txtNombre.Text = row["Descripcion"].ToString();
                        txtPrecio.Text = row["PrecioVenta"].ToString();
                    }



                }
            }
        }

        protected void txtCodigoDetalle_TextChanged1(object sender, EventArgs e)
        {
            AppDocumentos appDocumentos = new AppDocumentos();
            ArrayList arrProd = new ArrayList();
            arrProd = appDocumentos.DetalleProductoBuscar(txtCodigoDetalle.Text, Convert.ToInt32(Session["idSucursal"].ToString()));
            if (arrProd.Count > 0)
            {
                hdIdProducto.Value = arrProd[0].ToString();
                txtDescripcion.Text = arrProd[1].ToString();
                txtCantidad.Text = "1";
            }
            else
            {
                //vldCodigo.Visible = true;
                hdIdProducto.Value = "";
                txtDescripcion.Text = "";
                txtCantidad.Text = "0";
                txtCodigoDetalle.Text = "0";

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            appDoc.AgregarDetallepromocion(Convert.ToInt32(hdIdPromo.Value), Convert.ToInt32(hdIdProducto.Value), Convert.ToInt32(txtCantidad.Text));
            GridProductos.DataBind();

            hdIdProducto.Value = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "0";
            txtCodigoDetalle.Text = "0";
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc =new AppDocumentos();
            bool status = false;
            status= appDoc.ModificarPromo(Convert.ToInt32(hdIdPromo.Value), txtNombre.Text, txtCodigo.Text, Convert.ToInt32(txtPrecio.Text));

            if (status)
            {
                lblError.Text = "Cambio realizado Satisfactoriamente";
            }
            else
            {
                lblError.Text = "Existe un problema, debes revisar los datos ingresados";
            }
        }
    }
}
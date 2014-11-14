using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using InventarioWebApp;
using System.Collections;

namespace InventarioWeb.admin
{
    public partial class AgregarPromocion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["dt"] = "";
            }


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Session["dt"] == null || Session["dt"] == "")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("IdProducto", typeof(Int32));
                    dt.Columns.Add("Codigo", typeof(String));
                    dt.Columns.Add("Nombre", typeof(String));
                    dt.Columns.Add("Cantidad", typeof(Int32));
                    DataRow Row1;
                    Row1 = dt.NewRow();
                    Row1["IdProducto"] = Convert.ToInt32(hdIdProducto.Value);
                    Row1["Codigo"] = txtCodigoDetalle.Text;
                    Row1["Nombre"] = txtDescripcion.Text;
                    Row1["Cantidad"] = Convert.ToInt32(txtCantidad.Text);
                    dt.Rows.Add(Row1);
                    GridProductos.DataSource = dt;
                    GridProductos.DataBind();
                    Session["dt"] = dt;
                }
                catch { }
                

            }
            else
            {
                try
                {
                    DataTable dt = (Session["dt"]) as DataTable;
                    DataRow Row1;
                    Row1 = dt.NewRow();
                    Row1["IdProducto"] = Convert.ToInt32(hdIdProducto.Value);
                    Row1["Codigo"] = txtCodigoDetalle.Text;
                    Row1["Nombre"] = txtDescripcion.Text;
                    Row1["Cantidad"] = Convert.ToInt32(txtCantidad.Text);
                    dt.Rows.Add(Row1);
                    GridProductos.DataSource = dt;
                    GridProductos.DataBind();
                    Session["dt"] = dt;
                }
                catch { }
                
            }
            txtCodigoDetalle.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            hdIdProducto.Value = "";
            txtCodigoDetalle.Focus();
        }

        
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            bool status = false;
            DataTable dt = Session["dt"] as DataTable;

            if (dt.Rows.Count > 0)
            {
            
                status = appDoc.AgregarPromocion(txtNombre.Text, txtCodigo.Text, Convert.ToInt32(txtPrecio.Text), dt);
            }
            if (status)
            {
                Response.Redirect("GestionPromociones.aspx");
            }
            else
            {
                lblError.Text = "A ocurrido un error, Revisa los datos";
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



    }
}
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
            Session["dt"] = "";


            
        }
       
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Session["dt"] == null || Session["dt"] == "")
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
                Row1["Cantidad"] =Convert.ToInt32(txtCantidad.Text);
                dt.Rows.Add(Row1);
                GridProductos.DataSource = dt;
                GridProductos.DataBind();
                Session["dt"] = dt;
            }
            else
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
        }

        protected void txtCodigoDetalle_TextChanged(object sender, EventArgs e)
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
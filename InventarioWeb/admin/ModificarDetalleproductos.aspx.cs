using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Collections;
using System.Data;

namespace InventarioWeb.admin
{
    public partial class ModificarDetalleproductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppDocumentos appDoc = new AppDocumentos();
                String codigo=Request.Form["codigo"];
                ArrayList arr= new ArrayList();
                arr=appDoc.DetalleProductoBuscar(codigo, Convert.ToInt32(Session["idSucursal"].ToString()));
                txtCodigo.Text = codigo;
                hdIdDetalleproducto.Value=arr[0].ToString();
                txtDescripcion.Text = arr[1].ToString();

                cboDepartamento.DataSource = (DataTable)appDoc.cboDepartamento();
                cboDepartamento.DataTextField = "Nombre";
                cboDepartamento.DataValueField = "Id";
                cboDepartamento.DataBind();
                int i=0;
                foreach(ListItem value in cboDepartamento.Items){
                    if(value.Value==arr[3].ToString()){
                        value.Selected=true;
                        break;
                    }
                    i++;
                }
                cboDepartamento.SelectedIndex=i;
                
                cboProducto.DataSource = (DataTable)appDoc.cboProductos(Convert.ToInt32(arr[3].ToString()));
                cboProducto.DataTextField = "Nombre";
                cboProducto.DataValueField = "Id";
                cboProducto.DataBind();

                i=0;
                foreach(ListItem value in cboProducto.Items){
                    if(value.Value==arr[2].ToString()){
                        value.Selected=true;
                        break;
                    }
                    i++;
                }
                cboProducto.SelectedIndex=i;

                
                txtCosto.Text=arr[4].ToString();
                txtGanancia.Text=arr[5].ToString();
                txtVenta.Text=arr[6].ToString();

            }
            

        }
        protected void txtCosto_TextChanged(object sender, EventArgs e)
        {
            RoundInt roundInt = new RoundInt();
            txtVenta.Text = roundInt.Round((Convert.ToInt32(txtCosto.Text) + (Convert.ToInt32(txtCosto.Text) * Convert.ToInt32(txtGanancia.Text) / 100))).ToString();
        }
        protected void txtVenta_TextChanged(object sender, EventArgs e)
        {
            txtGanancia.Text = ((100 * Convert.ToInt32(txtVenta.Text) / Convert.ToInt32(txtCosto.Text)) - 100).ToString();

        }

        protected void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppDocumentos appDocumento = new AppDocumentos();
            cboProducto.DataSource = (DataTable)appDocumento.cboProductos(Convert.ToInt32(cboDepartamento.SelectedValue));
            cboProducto.DataTextField = "Nombre";
            cboProducto.DataValueField = "Id";
            cboProducto.DataBind();
        }
       
        protected void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            txtGanancia.Text = appDoc.PorcentajeProducto(Convert.ToInt32(cboProducto.SelectedValue));
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDocumentos = new AppDocumentos();
            ArrayList arrProd = new ArrayList();

            appDocumentos.ModificaProducto(Convert.ToInt32(hdIdDetalleproducto.Value),txtCodigo.Text, txtDescripcion.Text, Convert.ToInt32(cboProducto.SelectedValue), Convert.ToInt32(txtCosto.Text), Convert.ToDouble(txtGanancia.Text));

            lblAlerta.Text = "Producto modificado satisfactoriamente";
            lblAlerta.CssClass = "alertaP";
                
        }

        
    }
}
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
    public partial class AgregarDetalleproducto : System.Web.UI.Page
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

                cboProducto.DataSource = (DataTable)appDocumentos.cboProductos();
                cboProducto.DataTextField = "Nombre";
                cboProducto.DataValueField = "Id";
                cboProducto.DataBind();
                txtCodigo.Focus();
            }
        }

        protected void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppDocumentos appDocumento = new AppDocumentos();
            cboProducto.DataSource = (DataTable)appDocumento.cboProductos(Convert.ToInt32(cboDepartamento.SelectedValue));
            cboProducto.DataTextField = "Nombre";
            cboProducto.DataValueField = "Id";
            cboProducto.DataBind();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDocumentos = new AppDocumentos();
            ArrayList arrProd = new ArrayList();
            int idProd=0;
            if (chkAgregar.Checked == true)
            {
                idProd = appDocumentos.AgregaProducto(txtCodigo.Text, txtDescripcion.Text, Convert.ToInt32(cboProducto.SelectedValue), Convert.ToInt32(txtCosto.Text), Convert.ToDouble(txtGanancia.Text),0, Convert.ToInt32(Session["idSucursal"]), Convert.ToInt32(txtAgregar.Text));
          
            }
            else{
            
                idProd = appDocumentos.AgregaProducto(txtCodigo.Text, txtDescripcion.Text, Convert.ToInt32(cboProducto.SelectedValue), Convert.ToInt32(txtCosto.Text), Convert.ToDouble(txtGanancia.Text));
            }

            if(idProd >0)
            {
                lblAlerta.Text = "Producto ingresado satisfactoriamente";
                lblAlerta.CssClass = "alertaP";
                txtCodigo.Text = "";
                txtCosto.Text = "";
                txtDescripcion.Text = "";
                txtGanancia.Text = "";
                txtVenta.Text = "";

                cboDepartamento.DataSource = (DataTable)appDocumentos.cboDepartamento();
                cboDepartamento.DataTextField = "Nombre";
                cboDepartamento.DataValueField = "Id";
                cboDepartamento.DataBind();

                cboProducto.DataSource = (DataTable)appDocumentos.cboProductos();
                cboProducto.DataTextField = "Nombre";
                cboProducto.DataValueField = "Id";
                cboProducto.DataBind();
            }
            else
            {
                lblAlerta.Text = "Existe un error al Ingresar, revise los datos y vuelva a guardar";
                lblAlerta.CssClass = "alertaN";
            }
        }

        protected void txtCosto_TextChanged(object sender, EventArgs e)
        {
            txtVenta.Text = (Convert.ToInt32(txtCosto.Text) + (Convert.ToInt32(txtCosto.Text) * Convert.ToInt32(txtGanancia.Text) / 100)).ToString();
        }
       
        protected void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppDocumentos appDoc= new AppDocumentos();
            txtGanancia.Text = appDoc.PorcentajeProducto(Convert.ToInt32(cboProducto.SelectedValue));
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            ArrayList arr = new ArrayList();
            arr=appDoc.DetalleProductoBuscar(txtCodigo.Text);
            if (arr.Count > 0)
            {
                lblAlerta.Text = "Este codigo ya existe";
                lblAlerta.CssClass = "alertaN";
                txtCodigo.Text = "";
                txtCodigo.Focus();
            }
        }

        protected void txtVenta_TextChanged1(object sender, EventArgs e)
        {
            txtGanancia.Text = ((100 * Convert.ToInt32(txtVenta.Text) / Convert.ToInt32(txtCosto.Text)) - 100).ToString();

        }

        
        protected void chkAjustar_CheckedChanged(object sender, EventArgs e)
        {
            
        }

       

        protected void chkAgregar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgregar.Enabled == true)
            {
                txtAgregar.Enabled = true;
            }
            else
            {
                txtAgregar.Enabled = false;
                txtAgregar.Text = "0";
            }

        }
        
    }
}
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
    public partial class IngresarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppDocumentos appDocumento = new AppDocumentos();
                cboFacturas.DataSource = (DataTable)appDocumento.Seleccionafacturas(Session["rutEmpresa"].ToString());
                cboFacturas.DataTextField = "Nombre";
                cboFacturas.DataValueField = "Id";
                cboFacturas.DataBind();
                cboFacturas.Items.Insert(0, "<Seleccione una Factura>");

                cboDepartamento.DataSource = (DataTable)appDocumento.cboDepartamento();
                cboDepartamento.DataTextField = "Nombre";
                cboDepartamento.DataValueField = "Id";
                cboDepartamento.DataBind();
                cboDepartamento.Items.Insert(0, "<Selecciona un Documento>");

                cboProducto.DataSource = (DataTable)appDocumento.cboProductos();
                cboProducto.DataTextField = "Nombre";
                cboProducto.DataValueField = "Id";
                cboProducto.DataBind();
                cboProducto.Items.Insert(0, "<Selecciona un Producto");


                txtDescripcion.Enabled = false;
                cboProducto.Enabled = false;
                cboDepartamento.Enabled = false;
                txtCodigo.Enabled = false;
                txtCantidad.Enabled = false;
                txtPrecio.Enabled = false;


            }
          
        }

        protected void cboFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppDocumentos appDocumento =new AppDocumentos();
            ArrayList arrDoc=new ArrayList();
            arrDoc=appDocumento.SeleccionaEmpresa(Convert.ToInt32(cboFacturas.SelectedValue));
            lblMonto.Text = arrDoc[5].ToString();
            lblRutEmpresa.Text = arrDoc[1].ToString();
            txtCodigo.Enabled = true;
           

        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            AppDocumentos appDocumentos = new AppDocumentos();
            ArrayList arrProd = new ArrayList();
            arrProd = appDocumentos.DetalleProductoBuscar(txtCodigo.Text);
            if (arrProd.Count > 0)
            {
                txtDescripcion.Text = arrProd[1].ToString();
                txtPrecio.Text = arrProd[4].ToString();


                int i = 0;
                foreach (ListItem item in cboDepartamento.Items)
                {
                    if (item.Value == arrProd[3].ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                    i++;
                }
                cboDepartamento.SelectedIndex = i;

                i = 0;
                foreach (ListItem item in cboProducto.Items)
                {
                    if (item.Value == arrProd[2].ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                    i++;
                }
                cboProducto.SelectedIndex = i;

                txtCantidad.Enabled = true;
                txtPrecio.Enabled = true;
            }
            else
            {
                txtDescripcion.Enabled = true;
                cboProducto.Enabled = true;
                cboDepartamento.Enabled = true;
                txtCodigo.Enabled = true;
                txtCantidad.Enabled = true;
                txtPrecio.Enabled = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDocumentos = new AppDocumentos();
            ArrayList arrProd = new ArrayList();
            arrProd = appDocumentos.DetalleProductoBuscar(txtCodigo.Text);


            if (arrProd.Count > 0)
            {
                double porcentajeGanancia = Convert.ToDouble(arrProd[5].ToString());

                appDocumentos.AgregarDetalledocumento(Convert.ToInt32(arrProd[1].ToString()), Convert.ToInt32(cboFacturas.SelectedValue), Convert.ToInt32(txtCantidad.Text), 0, Convert.ToInt32(txtPrecio.Text), 0);
                txtDescripcion.Enabled = false;
                cboProducto.Enabled = false;
                cboDepartamento.Enabled = false;
                txtCantidad.Enabled = false;
                txtPrecio.Enabled = false;
                txtCodigo.Focus();
            }
            else
            {
                double porcentajeGanancia = Convert.ToDouble(arrProd[5].ToString());
                int idProd = appDocumentos.AgregaProducto(txtCodigo.Text, txtDescripcion.Text, Convert.ToInt32(cboProducto.SelectedValue), Convert.ToInt32(txtPrecio.Text));
                appDocumentos.AgregarDetalledocumento(idProd, Convert.ToInt32(cboFacturas.SelectedValue), Convert.ToInt32(txtCantidad.Text), 0, Convert.ToInt32(txtPrecio.Text), 0);
                GridView1.DataBind();
            }
        }


    }
}
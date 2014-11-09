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
                
                cboDepartamento.DataSource = (DataTable)appDocumento.cboDepartamento();
                cboDepartamento.DataTextField = "Nombre";
                cboDepartamento.DataValueField = "Id";
                cboDepartamento.DataBind();
                
                cboProducto.DataSource = (DataTable)appDocumento.cboProductos();
                cboProducto.DataTextField = "Nombre";
                cboProducto.DataValueField = "Id";
                cboProducto.DataBind();
               

                txtDescripcion.Enabled = false;
                cboProducto.Enabled = false;
                cboDepartamento.Enabled = false;
                txtCodigo.Enabled = false;
                txtCantidad.Enabled = false;
                txtPrecio.Enabled = false;
                txtGanancia.Enabled = false;
                txtVenta.Enabled = false;


            }
            GridView1.DataBind();
            if (GridView1.Rows.Count > 0)
            {
                btnIngresar.Enabled = true;
            }
            else
            {
                btnIngresar.Enabled = false;
            }
        }

        protected void cboFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppDocumentos appDocumento =new AppDocumentos();
            ArrayList arrDoc=new ArrayList();
            arrDoc = appDocumento.SeleccionaEmpresa(Convert.ToInt32(cboFacturas.SelectedValue));
            lblMonto.Text = arrDoc[5].ToString();
            lblRutEmpresa.Text = arrDoc[1].ToString();
            txtCodigo.Enabled = true;
            txtCodigo.Focus();

            
           
            //lblMontoDetalle.Text = appDocumento.MontoTotal(Convert.ToInt32(cboFacturas.SelectedValue)).ToString();
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
                txtGanancia.Text = arrProd[5].ToString();
                txtVenta.Text = arrProd[6].ToString();
                txtCantidad.Text = "1";

                cboDepartamento.DataSource = (DataTable)appDocumentos.cboDepartamento();
                cboDepartamento.DataTextField = "Nombre";
                cboDepartamento.DataValueField = "Id";
                cboDepartamento.DataBind();

                cboProducto.DataSource = (DataTable)appDocumentos.cboProductos();
                cboProducto.DataTextField = "Nombre";
                cboProducto.DataValueField = "Id";
                cboProducto.DataBind();

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
                txtCaja.Enabled = true;
                txtLote.Enabled = true;
                txtCantidad.Enabled = true;
                txtPrecio.Enabled = true;
                txtVenta.Enabled = true;
                txtGanancia.Enabled = true;
                txtCantidad.Focus();
            }
            else
            {
                txtDescripcion.Enabled = true;
                cboProducto.Enabled = true;
                cboDepartamento.Enabled = true;
                txtCaja.Enabled = true;
                txtLote.Enabled = true;
                txtCodigo.Enabled = true;
                txtCantidad.Enabled = true;
                txtPrecio.Enabled = true;
                txtVenta.Enabled = true;
                txtGanancia.Enabled = true;
                txtDescripcion.Focus();
            }
            btnGuardar.Enabled = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDocumentos = new AppDocumentos();
            ArrayList arrProd = new ArrayList();
            
            
            
            arrProd = appDocumentos.DetalleProductoBuscar(txtCodigo.Text);

            if (txtGanancia.Text == "")
            {
                txtGanancia.Text = "0";
            }
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "0";
            }
            if (txtVenta.Text == "")
            {
                txtVenta.Text = "0";
            }

            if (Page.IsValid)
            {

                if (arrProd.Count > 0)
                {
                    //double porcentajeGanancia = Convert.ToDouble(arrProd[5].ToString());
                    //precioUnitario = Convert.ToInt32(txtPrecio.Text) / Convert.ToInt32(txtCantidad.Text);
                    //txtPrecio.Text = precioUnitario.ToString();

                    appDocumentos.AgregarDetalledocumento(Convert.ToInt32(arrProd[0].ToString()), Convert.ToInt32(cboFacturas.SelectedValue), Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtVenta.Text), Convert.ToInt32(txtPrecio.Text), 0, Convert.ToDouble(txtGanancia.Text));
                }
                else
                {

                    int idProd = appDocumentos.AgregaProducto(txtCodigo.Text, txtDescripcion.Text, Convert.ToInt32(cboProducto.SelectedValue), Convert.ToInt32(txtPrecio.Text), Convert.ToDouble(txtGanancia.Text), Convert.ToInt32(txtVenta.Text));
                    appDocumentos.AgregarDetalledocumento(idProd, Convert.ToInt32(cboFacturas.SelectedValue), Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtVenta.Text), Convert.ToInt32(txtPrecio.Text), 0, Convert.ToDouble(txtGanancia.Text));

                    txtDescripcion.Enabled = false;
                    cboProducto.Enabled = false;
                    cboDepartamento.Enabled = false;
                    txtCantidad.Enabled = false;
                    txtPrecio.Enabled = false;
                    txtVenta.Enabled = false;
                    txtGanancia.Enabled = false;
                    txtCaja.Enabled = false;
                    txtLote.Enabled = false;

                }
                txtCodigo.Focus();
                txtDescripcion.Text = "";
                cboProducto.SelectedIndex = 0;
                cboDepartamento.SelectedIndex = 0;
                txtCantidad.Text = "";
                txtVenta.Text = "";
                txtGanancia.Text = "";
                txtPrecio.Text = "";
                txtCodigo.Text = "";
                txtCaja.Text = "";
                txtLote.Text = "";

                GridView1.DataBind();

                btnGuardar.Enabled = false;
                if (GridView1.Rows.Count > 0)
                {
                    btnIngresar.Enabled = true;
                }
               
            }
            //lblMontoDetalle.Text = appDocumentos.MontoTotal(Convert.ToInt32(cboFacturas.SelectedValue)).ToString();
            //appDocumentos.ComparaTotales(Convert.ToInt32(lblMonto.Text), Convert.ToInt32(lblMontoDetalle.Text), Convert.ToInt32(cboFacturas.SelectedValue));
        }

        protected void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        
        {
            AppDocumentos appDocumento = new AppDocumentos();
            cboProducto.DataSource = (DataTable)appDocumento.cboProductos(Convert.ToInt32(cboDepartamento.SelectedValue));
            cboProducto.DataTextField = "Nombre";
            cboProducto.DataValueField = "Id";
            cboProducto.DataBind();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            int count = GridView1.Rows.Count;
            int montoTotalDetalle = appDoc.MontoTotal(Convert.ToInt32(cboFacturas.SelectedValue));

            vldDescripcion.Enabled = false;
            foreach (GridViewRow grv in GridView1.Rows)
            {
                appDoc.CerrarDocumento(Convert.ToInt32(Session["idSucursal"].ToString()), Convert.ToInt32(cboFacturas.SelectedValue), Convert.ToInt32(grv.Cells[5].Text), grv.Cells[4].Text);
            }
            if (appDoc.ComparaTotales(Convert.ToInt32(lblMonto.Text), montoTotalDetalle, Convert.ToInt32(cboFacturas.SelectedValue)))
            {
                Response.Redirect("IngresarProductos.aspx");
            }
           
        }

        protected void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (txtGanancia.Text == "")
            {
                txtGanancia.Text = "0";
            }
            if (txtVenta.Text == "")
            {
                txtVenta.Text = "0";
            }
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "0";
            }
            txtVenta.Text = (Convert.ToInt32(txtPrecio.Text) + (Convert.ToInt32(txtPrecio.Text) * Convert.ToInt32(txtGanancia.Text) / 100)).ToString();
        }

       

        protected void txtVenta_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                txtGanancia.Text = ((100 * Convert.ToInt32(txtVenta.Text) / Convert.ToInt32(txtPrecio.Text)) - 100).ToString();
            }
            catch
            {
                Console.WriteLine("Error en calculo");
            }
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Input;
using System.Text;

namespace InventarioWeb.venta
{
    public partial class IngresarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                txtCodigo.Attributes.Add("onkeyup", "handleKeyPress(event);");
                txtCodigo.Focus();
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
                    txtDisp.Enabled = false;
                    txtNombre.Enabled = false;
                    txtPrecio.Enabled = false;
                    txtDisp.Text = "0";
                    txtCantidad.Text = "1";

                    cboFormapago.DataSource = (DataTable)appDoc.cboFormapago();
                    cboFormapago.DataTextField = "Nombre";
                    cboFormapago.DataValueField = "Id";
                    cboFormapago.DataBind();
                    cboFormapago.SelectedIndex = 1;

                    ArrayList arrDoc = new ArrayList();
                    arrDoc=appDoc.SeleccionaVenta(Convert.ToInt32(hdIdDocumento.Value));


                    if (arrDoc[6].ToString() == "2")
                    {
                        txtCodigo.Enabled = false;

                        btnAgregar.Enabled = false;
                        btnEliminar.Enabled = false;
                        btnFinalizar.Enabled = false;
                    }
                }
                else
                {
                    txtCodigo.Focus();
                    txtDisp.Enabled = false;
                    txtNombre.Enabled = false;
                    txtPrecio.Enabled = false;
                    txtDisp.Text = "0";
                    txtCantidad.Text = "1";
                    int idDocumento = 0;
                    ArrayList arr = new ArrayList();
                    AppDocumentos appDoc = new AppDocumentos();
                    
                    cboFormapago.DataSource = (DataTable)appDoc.cboFormapago();
                    cboFormapago.DataTextField = "Nombre";
                    cboFormapago.DataValueField = "Id";
                    cboFormapago.DataBind();
                    cboFormapago.SelectedIndex = 1;
                    arr = appDoc.SeleccionaEmpresa(0, 1, false, 2, Session["rutEmpresa"].ToString());
                    if (arr.Count > 0)
                    {
                        idDocumento = Convert.ToInt32(arr[0].ToString());
                    }
                    else
                    {
                        idDocumento = appDoc.AgregarVenta(Session["rutEmpresa"].ToString(), Convert.ToInt32(cboFormapago.SelectedValue), Convert.ToInt32(Session["idUsuario"].ToString()));
                    }
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
            arrProd = appDocumentos.DetalleProductoBuscar(txtCodigo.Text, Convert.ToInt32(Session["idSucursal"].ToString()));
            if (arrProd.Count > 0)
            {
                hdIdDetalle.Value = arrProd[0].ToString();
                txtNombre.Text = arrProd[1].ToString();
                txtPrecio.Text = arrProd[6].ToString();
                txtDisp.Text = arrProd[8].ToString();
                txtCantidad.Enabled = true;
                txtCantidad.Focus();
                lblCantError.Text = "";
            }
            else
            {
                
                vldCodigo.Visible = true;
                txtNombre.Text = "";
                txtPrecio.Text = "";
                txtDisp.Text = "0";
                txtCantidad.Text = "1";

                ScriptManager.RegisterStartupScript(this, GetType(), "ProdNoExiste", "ProdNoExiste();", true);
                txtCodigo.Text = "";
                txtCodigo.Focus();
                lblCantError.Text = "";
            }
           
        }

        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            ArrayList arr=new ArrayList();
            if (Convert.ToInt32(txtCantidad.Text) > Convert.ToInt32(txtDisp.Text))
            {
                lblCantError.Text = "La cantidad ingresada sobrepasa la disponible";
                txtCantidad.Focus();

            }
            else
            {

                appDoc.AgregarDetalledocumento(Convert.ToInt32(hdIdDetalle.Value), Convert.ToInt32(hdIdDocumento.Value), Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtPrecio.Text), 0, 0);
                appDoc.AgregarDertalleVenta(Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(hdIdDetalle.Value), Convert.ToInt32(Session["idSucursal"].ToString()));
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
                txtDisp.Text = "0";
                txtCantidad.Text = "1";
                txtCantidad.Enabled = false;
                txtCodigo.Focus();
            }

        }
        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            ArrayList arr = new ArrayList();
            if(!appDoc.ExisteEnDoc(txtCodigo.Text,Convert.ToInt32(hdIdDocumento.Value)))
            {
                lblCantError.Text="El producto no se encuentra en el listado, no puedes eliminar";
            }
            else
            {
                appDoc.AgregarDetalledocumento(Convert.ToInt32(hdIdDetalle.Value), Convert.ToInt32(hdIdDocumento.Value), Convert.ToInt32(txtCantidad.Text)*-1, Convert.ToInt32(txtPrecio.Text), 0, 0);
                appDoc.AgregarDertalleVenta(Convert.ToInt32(txtCantidad.Text) * -1, Convert.ToInt32(hdIdDetalle.Value), Convert.ToInt32(Session["idSucursal"].ToString()));
               
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
        }

        protected void btnFinalizar_Click(object sender, ImageClickEventArgs e)
        {
            vldCodigo.Enabled = false;
            AppDocumentos appDoc = new AppDocumentos();

            appDoc.CerrarVenta(Convert.ToInt32(Session["idSucursal"].ToString()), Convert.ToInt32(hdIdDocumento.Value), Convert.ToInt32(lblTotal.Text));

            Response.Redirect("IngresarVenta.aspx");
        }

        
       

       
    }
}
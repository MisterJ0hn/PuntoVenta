﻿using System;
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

namespace InventarioWeb.admin
{
    public partial class IngresarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                txtCodigo.Attributes.Add("onkeyup", "handleKeyPress(event);");
                
                if (Request.Form["IdDocumento"] != null)
                {
                    AppDocumentos appDoc = new AppDocumentos();
                    ArrayList arr = new ArrayList();
                    String valor = Request.Form["IdDocumento"];
                    hdIdDocumento.Text = valor;

                    GridView1.DataBind();
                    totales();
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
                    arrDoc = appDoc.SeleccionaVenta(Convert.ToInt32(hdIdDocumento.Text));
                    

                    if (arrDoc[6].ToString() == "2")
                    {
                        txtCodigo.Enabled = false;

                       
                        //btnFinalizar.Enabled = false;
                    }
                }
                else
                {
                    
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
                    arr.Clear();
                    hdIdDocumento.Text = idDocumento.ToString();
                   
                    
                    
                    totales();

                    if (Request.Form["Codigo"] != null)
                    {
                        String Codigo = Request.Form["Codigo"];
                        String Cantidad = Request.Form["Cantidad"];

                        bool status = txtCodigo_TextChanged(Codigo);

                        if (status)
                        {
                            txtCantidad.Text = Cantidad;
                            //txtCantidad.Text = dat;
                            btnAgregar_Click();
                        }
                    }

                       
                   
                }
            }
            else
            {
                
                    if (Page.Request.Params["__EVENTTARGET"] == "AgregarCodigo")
                    {
                        string dat = Page.Request.Params["__EVENTARGUMENT"].ToString();
                        bool status = txtCodigo_TextChanged(dat);
                        if (status)
                        {
                            btnAgregar_Click();
                        }
                    }
                    if (Page.Request.Params["__EVENTTARGET"] == "AgregarPromocion")
                    {
                        string dat = Page.Request.Params["__EVENTARGUMENT"].ToString();
                        AgregarPromocion(dat);
                    }
                    if (Page.Request.Params["__EVENTTARGET"] == "EliminarPromocion")
                    {
                        string dat = Page.Request.Params["__EVENTARGUMENT"].ToString();
                        EliminarPromocion(dat,1);
                    }
                    if (Page.Request.Params["__EVENTTARGET"] == "SeleccionaCodigo")
                    {
                        string dat = Page.Request.Params["__EVENTARGUMENT"].ToString();
                        txtCodigo_TextChanged(dat);
                    }
                    if (Page.Request.Params["__EVENTTARGET"] == "AgregarCodigoSeleccion")
                    {
                        String dat = Page.Request.Params["__EVENTARGUMENT"].ToString();
                        String[] datArr = dat.Split(':');
                        txtCodigo_TextChanged(datArr[0]);
                        txtCantidad.Text = datArr[1];
                        btnAgregar_Click();
                    }
                    if (Page.Request.Params["__EVENTTARGET"] == "AgregarProducto")
                    {
                        string dat = Page.Request.Params["__EVENTARGUMENT"].ToString();
                        String[] datArr = dat.Split(':');
                        bool status = txtCodigo_TextChanged(datArr[0]);

                        if (status)
                        {
                            txtCantidad.Text = datArr[1];
                            //txtCantidad.Text = dat;
                            btnAgregar_Click();
                        }
                    }
                    if (Page.Request.Params["__EVENTTARGET"] == "EliminarProducto")
                    {
                        string dat = Page.Request.Params["__EVENTARGUMENT"].ToString();
                        String[] datArr = dat.Split(':');
                        bool status = txtCodigo_TextChanged(datArr[0]);
                        if (status)
                        {
                            txtCantidad.Text = datArr[1];
                            // txtCantidad.Text = dat;
                            btnEliminar_Click();
                        }
                    }
                    if (Page.Request.Params["__EVENTTARGET"] == "Finalizar")
                    {
                        
                        btnFinalizar_Click();
                    }
                
            }

        }

        protected bool txtCodigo_TextChanged(String Codigo)
        {
            AppDocumentos appDocumentos = new AppDocumentos();
            ArrayList arrProd = new ArrayList();
            arrProd = appDocumentos.DetalleProductoBuscar(Codigo, Convert.ToInt32(Session["idSucursal"].ToString()));
            if (arrProd.Count > 0)
            {
                hdIdDetalle.Text = arrProd[0].ToString();
                txtCodigo.Text = Codigo;
                txtNombre.Text = arrProd[1].ToString();
                txtPrecio.Text = arrProd[6].ToString();
                if (arrProd[9].ToString() == "1")
                {
                    txtDisp.Text = "99999";
                }
                else
                {
                    txtDisp.Text = arrProd[8].ToString();
                }
                
                hdEsPromo.Value = arrProd[9].ToString();
                txtCantidad.Text = "1";
                
                lblCantError.Text = "";
                //btnAgregar_Click();
                return true;
            }
            else
            {

                    //vldCodigo.Visible = true;
                    lblCantError.Text = "";
                    txtDisp.Text = "0";
                    txtCantidad.Text = "0";
                    txtCodigo.Text = "0";
                    hdFuncion.Text = "0";

                    ScriptManager.RegisterStartupScript(this, GetType(), "ProdNoExiste", "ProdNoExiste();", true);
               
                
                return false;
            }
           
        }

        protected void btnAgregar_Click()
        {
            AppDocumentos appDoc = new AppDocumentos();
            ArrayList arr=new ArrayList();
            if (Convert.ToInt32(txtCantidad.Text) > Convert.ToInt32(txtDisp.Text))
            {
                lblCantError.Text = "La cantidad ingresada sobrepasa la disponible";
                //txtCantidad.Focus();
                hdFuncion.Text = "";
            }
            else
            {
                if (hdEsPromo.Value == "1")
                {
                    AgregarPromocion(txtCodigo.Text, Convert.ToInt32(txtCantidad.Text));
                }
                else
                {
                    appDoc.AgregarDetalledocumento(Convert.ToInt32(hdIdDetalle.Text), Convert.ToInt32(hdIdDocumento.Text), Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtPrecio.Text), 0, 0, 0);
                    appDoc.AgregarDertalleVenta(Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(hdIdDetalle.Text), Convert.ToInt32(Session["idSucursal"].ToString()));
                }
                GridView1.DataBind();
                totales();

                /*
                txtDisp.Text = (Convert.ToInt32(txtDisp.Text)-Convert.ToInt32(txtCantidad.Text)).ToString();
                txtCantidad.Text = "0";
                txtCantidad.Enabled = false;
                txtCodigo.Focus();
                hdFuncion.Text = "";*/

                txtDisp.Text = "0";
                txtCantidad.Text = "0";
                txtCodigo.Text = "0";
                hdFuncion.Text = "";
            }

        }
        
        protected void btnEliminar_Click()
        {
            AppDocumentos appDoc = new AppDocumentos();
            ArrayList arr = new ArrayList();
            if (!appDoc.ExisteEnDoc(txtCodigo.Text, Convert.ToInt32(hdIdDocumento.Text), Convert.ToInt32(hdEsPromo.Value), Convert.ToInt32(txtCantidad.Text)))
            {
                lblCantError.Text="El producto no se encuentra en el listado, no puedes eliminar";
            }
            else
            {
                if (hdEsPromo.Value == "1")
                {
                    EliminarPromocion(txtCodigo.Text, Convert.ToInt32(txtCantidad.Text));
                }else{
                    appDoc.AgregarDetalledocumento(Convert.ToInt32(hdIdDetalle.Text), Convert.ToInt32(hdIdDocumento.Text), Convert.ToInt32(txtCantidad.Text) * -1, Convert.ToInt32(txtPrecio.Text), 0, 0, 0);
                    appDoc.AgregarDertalleVenta(Convert.ToInt32(txtCantidad.Text) * -1, Convert.ToInt32(hdIdDetalle.Text), Convert.ToInt32(Session["idSucursal"].ToString()));
                }
                GridView1.DataBind();

                totales();

                hdFuncion.Text = "";
                txtCantidad.Enabled = false;
                txtCodigo.Focus();
            }
        }
        protected void AgregarPromocion(String Codigo, int cantidad=1)
        {
            AppDocumentos appDoc = new AppDocumentos();
            bool Status = false;
            Status=appDoc.AgregarPromocionVenta(Codigo, Convert.ToInt32(Session["idSucursal"].ToString()), Convert.ToInt32(hdIdDocumento.Text), cantidad);
            if (!Status)
            {
                lblCantError.Text = "No hay stock para esta promoci&oacute;n";
            }
            GridView1.DataBind();
            totales();
        }
        protected void EliminarPromocion(String Codigo, int cantidad)
        {
            AppDocumentos appDoc = new AppDocumentos();

            
            appDoc.EliminarPromocionVenta(Codigo, Convert.ToInt32(Session["idSucursal"].ToString()), Convert.ToInt32(hdIdDocumento.Text), cantidad);

            
            GridView1.DataBind();
            totales();
        }
        protected void btnFinalizar_Click()
        {
            vldCodigo.Enabled = false;
            AppDocumentos appDoc = new AppDocumentos();

            appDoc.CerrarVenta(Convert.ToInt32(Session["idSucursal"].ToString()), Convert.ToInt32(hdIdDocumento.Text), Convert.ToInt32(Convert.ToDouble(lblTotalCobrar.Text.Replace(".","").Replace("$",""))),int.Parse(cboFormapago.SelectedValue));

            Response.Redirect("IngresarVenta.aspx");
        }

        protected void btnFinalizar2_Click(object sender, EventArgs e)
        {
            btnFinalizar_Click();
        }

        public void totales()
        {
            ArrayList arr = new ArrayList();
            AppDocumentos appDoc = new AppDocumentos();
            arr = appDoc.GenerarTotales(Convert.ToInt32(hdIdDocumento.Text));

            lblTotal.Text = "$ " + String.Format("{0:N0}", Convert.ToInt32(arr[2].ToString()));
            lblTotalCobrar.Text = "$ " + String.Format("{0:N0}", Convert.ToInt32(arr[3].ToString()));

        }
       

       
    }
}
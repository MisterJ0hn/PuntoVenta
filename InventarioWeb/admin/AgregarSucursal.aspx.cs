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
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppEmpresas appEmpresa=new AppEmpresas();
                String rut = Request.QueryString["rut"];
                ArrayList arrComuna = new ArrayList();
                ArrayList arrCiudad = new ArrayList();
               

                hdRut.Value = rut;

               

                cboRegion.DataSource = appEmpresa.getRegion();
                cboRegion.DataTextField = "Nombre";
                cboRegion.DataValueField = "Id";
                cboRegion.DataBind();


               
                

                arrCiudad = appEmpresa.getCiudad(Convert.ToInt32(cboRegion.SelectedValue));
                cboCiudad.DataSource = (DataTable) arrCiudad[0];
                cboCiudad.DataTextField = "Nombre";
                cboCiudad.DataValueField = "Id";
                cboCiudad.DataBind();


                
                arrComuna = appEmpresa.getComuna(Convert.ToInt32(cboCiudad.SelectedValue));


                cboComuna.DataSource = (DataTable)arrComuna[0];
                cboComuna.DataTextField = "Nombre";
                cboComuna.DataValueField = "Id";
                cboComuna.DataBind();
               
            }


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AppEmpresas appEmpresa = new AppEmpresas();

            int status = appEmpresa.AgregarSucursal(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, hdRut.Value, Convert.ToInt32(cboComuna.SelectedValue), Convert.ToInt32(Session["idMaestra"]));

            if (status > 0)
            {
                Response.Redirect("ModificarProveedor.aspx?rut=" + hdRut.Value);
            }
        }

        protected void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppEmpresas appEmpresa = new AppEmpresas();
            cboCiudad.Items.Clear();
            cboComuna.Items.Clear();
            ArrayList arrComuna = new ArrayList();
            ArrayList arrCiudad = new ArrayList();


           arrCiudad = appEmpresa.getCiudad(Convert.ToInt32(cboRegion.SelectedValue));
            cboCiudad.DataSource = (DataTable) arrCiudad[0];
            cboCiudad.DataTextField = "Nombre";
            cboCiudad.DataValueField = "Id";
            cboCiudad.DataBind();


                
            arrComuna = appEmpresa.getComuna(Convert.ToInt32(cboCiudad.SelectedValue));


            cboComuna.DataSource = (DataTable)arrComuna[0];
            cboComuna.DataTextField = "Nombre";
            cboComuna.DataValueField = "Id";
            cboComuna.DataBind();
        }

        protected void cboCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppEmpresas appEmpresa = new AppEmpresas();
            cboComuna.Items.Clear();

            ArrayList arrComuna = new ArrayList();
            ArrayList arrCiudad = new ArrayList();

            arrComuna = appEmpresa.getComuna(Convert.ToInt32(cboCiudad.SelectedValue));


            cboComuna.DataSource = (DataTable)arrComuna[0];
            cboComuna.DataTextField = "Nombre";
            cboComuna.DataValueField = "Id";
            cboComuna.DataBind();

        }
    }
}
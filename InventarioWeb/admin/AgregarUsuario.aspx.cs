using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using InventarioWebEntity;

namespace InventarioWeb.admin
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idMaestra = Int32.Parse(Session["idMaestra"].ToString());
                AppGestionU cboEmpresas = new AppGestionU();
                lstEmpresa.DataSource = cboEmpresas.CboEmpresas(idMaestra);
                lstEmpresa.DataTextField = "Nombre";
                lstEmpresa.DataValueField = "Rut";
                lstEmpresa.DataBind();

                /*lstSucursal.DataSource = cboEmpresas.CboSucursal(lstEmpresa.SelectedValue);
                lstSucursal.DataTextField = "Nombre";
                lstSucursal.DataValueField = "id";
                lstSucursal.DataBind();*/

                lstPerfil.DataSource = cboEmpresas.CboRol();
                lstPerfil.DataTextField = "Nombre";
                lstPerfil.DataValueField = "id";
                lstPerfil.DataBind();

                lstSucursal.Items.Clear();

                lstSucursal.DataSource = cboEmpresas.CboSucursal(lstEmpresa.SelectedValue);
                lstSucursal.DataTextField = "Nombre";
                lstSucursal.DataValueField = "id";
                lstSucursal.DataBind();
            }
        }

        protected void lstEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppGestionU cboEmpresas = new AppGestionU();

            lstSucursal.Items.Clear();

            lstSucursal.DataSource = cboEmpresas.CboSucursal(lstEmpresa.SelectedValue);
            lstSucursal.DataTextField = "Nombre";
            lstSucursal.DataValueField = "id";
            lstSucursal.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AppGestionU gestorU = new AppGestionU();

            if (this.IsPostBack)
            {
                this.Validate();
                if (this.IsValid)
                {
                    gestorU.AppAgregarUsuarios(txtNombre.Text, txtApellido.Text, txtMail.Text, txtUsuario.Text, txtClave.Text, int.Parse(lstPerfil.Value), int.Parse(lstSucursal.SelectedValue), int.Parse(Session["idMaestra"].ToString()));

                    Response.Redirect("gestionU.aspx");
                }
            }
           
        }

        protected void ValidarUsuario(object source, ServerValidateEventArgs args)
        {
            NegocioAccesoLogica acceso = new NegocioAccesoLogica();
            Usuario objUsuario = new Usuario();
                
                objUsuario=acceso.iniciarSession(args.Value.ToString());

            if (objUsuario.Usuario1 != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}
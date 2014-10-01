using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Specialized;
using System.Collections;
using InventarioWebApp;
using InventarioWebEntity;

namespace InventarioWeb.admin
{
    public partial class UpdateUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idMaestra = Int32.Parse(Session["idMaestra"].ToString());
                String idUsuario = Request.QueryString["usuario"];
                ArrayList arrUsuario = new ArrayList();
                AppGestionU gestion = new AppGestionU();

                arrUsuario = gestion.AppSeleccionaUsuario(idUsuario);

                lstPerfil.DataSource = gestion.CboRol();
                lstPerfil.DataTextField = "Nombre";
                lstPerfil.DataValueField = "id";
                lstPerfil.DataBind();
                lstPerfil.SelectedIndex=Convert.ToInt32(arrUsuario[7].ToString());


                lstEmpresa.DataSource = gestion.CboEmpresas(idMaestra);
                lstEmpresa.DataTextField = "Nombre";
                lstEmpresa.DataValueField = "Rut";
                lstEmpresa.DataBind();
                int i=0;
                foreach (ListItem item in lstEmpresa.Items)
                {
                    if (item.Value == arrUsuario[8].ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                    i++;
                }
                lstEmpresa.SelectedIndex = i;

                lstSucursal.DataSource = gestion.CboSucursal(arrUsuario[8].ToString());
                lstSucursal.DataTextField = "Nombre";
                lstSucursal.DataValueField = "id";
                lstSucursal.DataBind();
                int j = 0;
                foreach (ListItem item in lstSucursal.Items)
                {
                    if (item.Value == arrUsuario[9].ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                    j++;
                }
                lstSucursal.SelectedIndex = j;


                hdIdUsuario.Value = idUsuario;
                txtNombre.Text = arrUsuario[0].ToString();
                txtApellido.Text = arrUsuario[1].ToString();
                txtUsuario.Text = arrUsuario[2].ToString();
                txtClave.Text = arrUsuario[6].ToString();
                txtMail.Text = arrUsuario[5].ToString();
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
        protected void ValidarUsuario(object source, ServerValidateEventArgs args)
        {
            NegocioAccesoLogica acceso = new NegocioAccesoLogica();
            Usuario objUsuario = new Usuario();

            objUsuario = acceso.iniciarSession(args.Value.ToString(),"",int.Parse(hdIdUsuario.Value));

            if (objUsuario.Usuario1 != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            AppGestionU gestorU = new AppGestionU();

            if (this.IsPostBack)
            {
                this.Validate();
                if (this.IsValid)
                {
                    gestorU.AppModificarUsuarios(txtNombre.Text, txtApellido.Text, "", txtUsuario.Text, txtClave.Text, int.Parse(lstPerfil.Value), int.Parse(lstSucursal.SelectedValue), int.Parse(Session["idMaestra"].ToString()), int.Parse(hdIdUsuario.Value));

                    
                }
            }

        }
    }
}
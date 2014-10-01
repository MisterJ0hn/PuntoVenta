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
    public partial class ModificarSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppEmpresas appEmpresa = new AppEmpresas();
                String idSucursal = Request.QueryString["sucursal"];

                hdIdSucursal.Value = idSucursal;
                ArrayList arr = new ArrayList();
                ArrayList arrComuna = new ArrayList();
                ArrayList arrCiudad = new ArrayList();
                int idCiudad=0;
                int idRegion = 0;
  
                arr = appEmpresa.AppSeleccionaSucursal(Convert.ToInt32(idSucursal));
                hdRut.Value = arr[4].ToString();
                txtNombre.Text = arr[0].ToString();
                txtDireccion.Text=arr[1].ToString();
                txtTelefono.Text=arr[2].ToString();
                arrComuna = appEmpresa.getComuna(0, Convert.ToInt32(arr[3].ToString()));
                idCiudad = Convert.ToInt32(arrComuna[1].ToString());

                arrCiudad = appEmpresa.getCiudad(0, idCiudad);
                idRegion = Convert.ToInt32(arrCiudad[1].ToString());



                cboComuna.DataSource = (DataTable) arrComuna[0];
                cboComuna.DataTextField = "Nombre";
                cboComuna.DataValueField = "Id";
                cboComuna.DataBind();
                int i = 0;
                foreach (ListItem item in cboComuna.Items)
                {
                    if (item.Value == arr[3].ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                    i++;
                }
               cboComuna.SelectedIndex = i;

               cboCiudad.DataSource = (DataTable) arrCiudad[0];
               cboCiudad.DataTextField = "Nombre";
               cboCiudad.DataValueField = "Id";
               cboCiudad.DataBind();
               int j = 0;
               foreach (ListItem item in cboCiudad.Items)
               {
                   if (item.Value == idCiudad.ToString())
                   {
                       item.Selected = true;
                       break;
                   }
                   j++;
               }
               cboCiudad.SelectedIndex = j;


               cboRegion.DataSource = appEmpresa.getRegion();
               cboRegion.DataTextField = "Nombre";
               cboRegion.DataValueField = "Id";
               cboRegion.DataBind();
               int k = 0;
               foreach (ListItem item in cboRegion.Items)
               {
                   if (item.Value == idRegion.ToString())
                   {
                       item.Selected = true;
                       break;
                   }
                   k++;
               }
               cboRegion.SelectedIndex = k;
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            AppEmpresas appEmpresa = new AppEmpresas();

            appEmpresa.AppModificarSucursal(hdRut.Value, txtNombre.Text, txtDireccion.Text, txtTelefono.Text, Convert.ToInt32(Session["idMaestra"].ToString()), int.Parse(cboComuna.SelectedValue), int.Parse(hdIdSucursal.Value));
        }

        protected void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppEmpresas appEmpresa = new AppEmpresas();
            cboCiudad.Items.Clear();
            cboComuna.Items.Clear();
            ArrayList arrComuna = new ArrayList();
            ArrayList arrCiudad = new ArrayList();


            arrCiudad = appEmpresa.getCiudad(Convert.ToInt32(cboRegion.SelectedValue));
            cboCiudad.DataSource = (DataTable)arrCiudad[0];
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
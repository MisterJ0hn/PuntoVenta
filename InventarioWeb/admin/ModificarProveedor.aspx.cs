using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Collections;

namespace InventarioWeb.admin
{
    public partial class ModificarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idMaestra = Int32.Parse(Session["idMaestra"].ToString());
                String rut = Request.QueryString["rut"];
                AppEmpresas proveedor = new AppEmpresas();
                ArrayList arrProveedor = new ArrayList();

                arrProveedor = proveedor.AppSeleccionaEmpresa(rut);
               
                txtRut.Text = arrProveedor[0].ToString();
                txtNombre.Text = arrProveedor[1].ToString();
                txtRazonSocial.Text = arrProveedor[2].ToString();
                
                GridView1.DataBind();


            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            AppEmpresas proceso = new AppEmpresas();
            proceso.AppModificarEmpresa(txtRut.Text, txtNombre.Text, txtRazonSocial.Text, Convert.ToInt32(Session["idMaestra"].ToString()), 2);
              
        }

        protected void btnAgregarSucursal_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarSucursal.aspx?rut=" + txtRut.Text);
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];
                TableCell tabla = row.Cells[0];
                String IdSucursal = tabla.Text;


                Response.Redirect("ModificarSucursal.aspx?sucursal=" + IdSucursal);
            }
        }
    }
}
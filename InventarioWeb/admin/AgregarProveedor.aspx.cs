using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;

namespace InventarioWeb.admin
{
    public partial class AgregarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AppEmpresas proceso = new AppEmpresas();
            
            if (this.IsPostBack)
            {
                this.Validate();
                if (this.IsValid)
                {
                    proceso.AppAgregarEmpresa(txtRut.Text, txtNombre.Text,"", Convert.ToInt32(Session["idMaestra"].ToString()), 2);
                }
            }

        }
        protected void ValidarRut(object source, ServerValidateEventArgs args)
        {
            bool status;
            ValidaRut validar = new ValidaRut();
            status = validar.validaRut(args.Value);

            args.IsValid = status;
            

        }
    }
}
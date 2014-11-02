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
    public partial class DetalleCierre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String idCierre=Request.Form["idCierre"];
                AppCaja appCaja = new AppCaja();
                DataTable dtCaja =new DataTable();
                DataTable dt
                AppGestionU usuario=new AppGestionU();
                ArrayList arrUser=new ArrayList();
               
                
                dtCaja = appCaja.SeleccionaCierre(Convert.ToInt32(idCierre));
                foreach (DataRow row in dtCaja.Rows)
                {
                    txtDevolucion.Text = row["Devolucion"].ToString();
                    lblComputador.Text = row["Computador"].ToString();
                    lblIngesos.Text = row["Ingresos"].ToString();
                    arrUser = usuario.AppSeleccionaUsuario(row["UsuarioCierre"].ToString());
                    lblResponsable.Text = arrUser[0].ToString()+" "+arrUser[1].ToString();
                    lblFecha.Text = row["FechaCierre"].ToString();

                }
            }
        }
    }
}
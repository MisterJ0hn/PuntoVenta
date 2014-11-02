using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioWeb
{
    public partial class VNT : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombrelogeado"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("/Login.aspx");
            }
            else
            {
                if (Session["idPerfil"].ToString() != "4")
                {
                    switch (Session["idPerfil"].ToString())
                    {

                        case "2":
                            Response.Redirect("/admin/GestionU.aspx");
                            break;
                        case "3":
                            Response.Redirect("/bodega/GestionDocumentos.aspx");
                            //Response.Redirect("/admin/GestionU.aspx");
                            break;
                    }
                }
            }
        }
    }
}
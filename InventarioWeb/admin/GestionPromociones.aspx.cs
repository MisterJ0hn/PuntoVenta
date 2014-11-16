﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Collections.Specialized;

namespace InventarioWeb.admin
{
    public partial class GestionPromociones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPromocion.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                WebForm frm = new WebForm();
                GridViewRow row = GridView1.Rows[index];
                TableCell tabla = row.Cells[0];
                String idPromo = tabla.Text;
                NameValueCollection data = new NameValueCollection();
                data.Add("IdPromo", idPromo);

                frm.RedirectAndPOST(this.Page, "ModificarPromocion.aspx", data);
            }
            if (e.CommandName == "Vender")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                WebForm frm = new WebForm();
                GridViewRow row = GridView1.Rows[index];
                TextBox tb = (TextBox)GridView1.Rows[index].FindControl("txtCantidad");
                TableCell tabla = row.Cells[1];
                String Codigo = tabla.Text;
                NameValueCollection data = new NameValueCollection();
                data.Add("Codigo", Codigo);
                data.Add("Cantidad", tb.Text);

                frm.RedirectAndPOST(this.Page, "IngresarVenta.aspx", data);
            }
        }
    }
}
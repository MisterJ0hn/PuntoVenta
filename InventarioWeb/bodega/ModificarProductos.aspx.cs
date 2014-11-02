using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using InventarioWebApp;
using System.Data;

namespace InventarioWeb.bodega
{
    public partial class ModificarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            
                if (Request.Form["idProducto"] != null)
                {
                    AppDocumentos appDoc = new AppDocumentos();
                    String idProducto = Request.Form["idProducto"];
                    ArrayList arr = new ArrayList();

                    arr = appDoc.SeleccionaProducto(Convert.ToInt32(idProducto));
                    hdProducto.Value = idProducto;
                    txtNombre.Text = arr[1].ToString();
                    txtGanancia.Text = arr[2].ToString();
                    if (arr[3].ToString() == "0")
                    {
                        cboEnBoleta.SelectedIndex = 0;
                    }
                    if (arr[3].ToString() == "1")
                    {
                        cboEnBoleta.SelectedIndex = 1;
                    }

                    cboDepartamento.DataSource = (DataTable)appDoc.cboDepartamento();
                    cboDepartamento.DataTextField = "Nombre";
                    cboDepartamento.DataValueField = "Id";
                    cboDepartamento.DataBind();

                    int i = 0;
                    foreach (ListItem item in cboDepartamento.Items)
                    {
                        if (item.Value == arr[4].ToString())
                        {
                            item.Selected = true;
                            break;
                        }
                        i++;
                    }
                    cboDepartamento.SelectedIndex = i;
                }
           

        }

        protected void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();

            ArrayList arr = new ArrayList();
            arr = appDoc.SeleccionaDepartamento(Convert.ToInt32(cboDepartamento.SelectedValue));

            txtGanancia.Text = arr[1].ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();

            appDoc.ModificaProductoProducto(Convert.ToInt32(hdProducto.Value), txtNombre.Text, txtGanancia.Text, Convert.ToInt32(cboEnBoleta.SelectedValue), Convert.ToInt32(cboDepartamento.SelectedValue), chkDetalle.Checked);
            
        }
    }
}
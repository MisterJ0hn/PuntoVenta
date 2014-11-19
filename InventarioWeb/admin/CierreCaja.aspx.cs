using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Data;
using InventarioWebApp;
using System.Collections;
using System.Collections.Specialized;

namespace InventarioWeb.admin
{
    public partial class CierreCaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppDocumentos appDoc = new AppDocumentos();
                int computador = 0;
                Session["dt"] = "";
                Session["dt2"] = "";
                Session["dt3"] = "";
                Session["dt4"] = "";

                computador = appDoc.VentasDelDia(Session["rutEmpresa"].ToString());

                lblComputador.Text = computador.ToString();
                if (Session["dt4"] == null || Session["dt4"] == "")
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("Descripcion", typeof(String));
                    dt.Columns.Add("Monto", typeof(Int32));
                    dt.Columns.Add("Dia", typeof(String));
                    DataRow Row1;
                    Row1 = dt.NewRow();
                    Row1["Descripcion"] = "Red Compra";
                    Row1["Monto"] = appDoc.RedCompra(Session["rutEmpresa"].ToString()) ;
                    Row1["Dia"] = "";
                    dt.Rows.Add(Row1);

                    GridCreditos.DataSource = dt;
                    GridCreditos.DataBind();
                    Session["dt4"] = dt;
                }
                SumarResumen();
            }

        }
        
        

        protected void btnAgregarEgreso_Click(object sender, EventArgs e)
        {

            if (Session["dt"] == null || Session["dt"] == "")
            {
                DataTable dt = cabezerasGrid();
                DataRow Row1;
                Row1 = dt.NewRow();
                Row1["Descripcion"] = txtDetalle.Text;
                Row1["Monto"] = txtCantidad.Text;
                dt.Rows.Add(Row1);
                GridEgresos.DataSource = dt;
                GridEgresos.DataBind();
                Session["dt"] = dt;
            }
            else
            {
                DataTable dt = (Session["dt"]) as DataTable;
                DataRow Row1;
                Row1 = dt.NewRow();
                Row1["Descripcion"] = txtDetalle.Text;
                Row1["Monto"] = txtCantidad.Text;
                dt.Rows.Add(Row1);
                GridEgresos.DataSource = dt;
                GridEgresos.DataBind();
                Session["dt"] = dt;
            }
            SumarResumen();
            txtDetalle.Text = "";
            txtCantidad.Text = "";
        }
        public DataTable cabezerasGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Descripcion", typeof(String));
            dt.Columns.Add("Monto", typeof(Int32));
            return dt;
        }

        protected void sumaDetalleDinero(object sender, EventArgs e)
        {
            txtTotal.Text = (Convert.ToInt32(txt20000.Text) + Convert.ToInt32(txt10000.Text) + Convert.ToInt32(txt5000.Text) + Convert.ToInt32(txt2000.Text) + Convert.ToInt32(txt1000.Text) + Convert.ToInt32(txt500.Text) + Convert.ToInt32(txt100.Text) + Convert.ToInt32(txt50.Text) + Convert.ToInt32(txt10.Text) + Convert.ToInt32(txtCheque.Text)).ToString();
            SumarResumen();
        }

        protected void btnAgregarVentaMenor_Click(object sender, EventArgs e)
        {
            if (Session["dt2"] == null || Session["dt2"]== "")
            {
                DataTable dt = cabezerasGrid(); 
                DataRow Row1;
                Row1 = dt.NewRow();
                Row1["Descripcion"] = txtDetalleMenor.Text;
                Row1["Monto"] = txtCantidadMenor.Text;
                dt.Rows.Add(Row1);
                GridVentaMenor.DataSource = dt;
                GridVentaMenor.DataBind();
                Session["dt2"] = dt;
            }
            else
            {
                DataTable dt = (Session["dt2"]) as DataTable;
                DataRow Row1;
                Row1 = dt.NewRow();
                Row1["Descripcion"] = txtDetalleMenor.Text;
                Row1["Monto"] = txtCantidadMenor.Text;
                dt.Rows.Add(Row1);
                GridVentaMenor.DataSource = dt;
                GridVentaMenor.DataBind();
                Session["dt2"] = dt;
            }
            SumarResumen();
            txtDetalleMenor.Text = "";
            txtCantidadMenor.Text = "";

        }

        protected void btnAgregarIngreso_Click(object sender, EventArgs e)
        {
            if (Session["dt3"] == null || Session["dt3"] == "")
            {
                DataTable dt = cabezerasGrid();
                DataRow Row1;
                Row1 = dt.NewRow();
                Row1["Descripcion"] = txtDetalleIngresos.Text;
                Row1["Monto"] = txtCantidadIngreso.Text;
                dt.Rows.Add(Row1);
                GridIngresos.DataSource = dt;
                GridIngresos.DataBind();
                Session["dt3"] = dt;
            }
            else
            {
                DataTable dt = (Session["dt3"]) as DataTable;
                DataRow Row1;
                Row1 = dt.NewRow();
                Row1["Descripcion"] = txtDetalleIngresos.Text;
                Row1["Monto"] = txtCantidadIngreso.Text;
                dt.Rows.Add(Row1);
                GridIngresos.DataSource = dt;
                GridIngresos.DataBind();
                Session["dt3"] = dt;
            }
            SumarResumen();
            txtDetalleIngresos.Text = "";
            txtCantidadIngreso.Text = "";
        }
        protected void btnAgregarCredito_Click(object sender, EventArgs e)
        {
            if (Session["dt4"] == null || Session["dt4"] == "")
            {
                DataTable dt = new DataTable();
              
                dt.Columns.Add("Descripcion", typeof(String));
                dt.Columns.Add("Monto", typeof(Int32));
                dt.Columns.Add("Dia", typeof(String));
                DataRow Row1;
                Row1 = dt.NewRow();
                Row1["Descripcion"] = txtDetalleCredito.Text;
                Row1["Monto"] = txtCantidadCredito.Text;
                Row1["Dia"] = txtDiaCredito.Text;
                dt.Rows.Add(Row1);
               
                GridCreditos.DataSource = dt;
                GridCreditos.DataBind();
                Session["dt4"] = dt;
            }
            else
            {
                DataTable dt = (Session["dt4"]) as DataTable;
                DataRow Row1;
                Row1 = dt.NewRow();
                Row1["Descripcion"] = txtDetalleCredito.Text;
                Row1["Monto"] = txtCantidadCredito.Text;
                Row1["Dia"] = txtDiaCredito.Text;
                dt.Rows.Add(Row1);
                GridCreditos.DataSource = dt;
                GridCreditos.DataBind();
                Session["dt4"] = dt;
            }
            SumarResumen();
            txtCantidadCredito.Text = "";
            txtDetalleCredito.Text = "";
        }
       
        public void SumarResumen()
        {
            int sumarIngresos = 0;
            int sumarEgresos = 0;
            int sumarCreditos = 0;
            int sumarEfectivo = 0;
            int sumarMenor = 0;

            //C}recorriendo Ingresos

            foreach (GridViewRow row in GridIngresos.Rows)
            {
                sumarIngresos += Convert.ToInt32(row.Cells[2].Text);

            }

            //recorriendo Egresos

            foreach (GridViewRow row1 in GridEgresos.Rows)
            {
                sumarEgresos -= Convert.ToInt32(row1.Cells[2].Text);
            }

            //recorriendo Creditos
            foreach (GridViewRow row2 in GridCreditos.Rows)
            {
                sumarCreditos -= Convert.ToInt32(row2.Cells[2].Text);
            }

            foreach (GridViewRow row3 in GridVentaMenor.Rows)
            {
                sumarMenor += Convert.ToInt32(row3.Cells[2].Text);
            }
            //recorriendo Efectivo
            sumarEfectivo += Convert.ToInt32(txtTotal.Text);


            lblCreditos.Text = sumarCreditos.ToString();
            lblEgresos.Text = sumarEgresos.ToString();
            //lblDevolucionResumen.Text = txtDevolucion.Text;
            lblEfectivo.Text = sumarEfectivo.ToString();
            txtMenor.Text = sumarMenor.ToString();
            lblTotalResumen.Text = (Convert.ToInt32(lblCreditos.Text) + Convert.ToInt32(lblCreditos.Text) + Convert.ToInt32(lblDevolucionResumen.Text) + Convert.ToInt32(lblEfectivo.Text)+Convert.ToInt32(txtMenor.Text)).ToString();
            lblIngesos.Text = sumarIngresos.ToString();

            lblDiferencia.Text = (Convert.ToInt32(lblComputador.Text) - Convert.ToInt32(lblIngesos.Text)).ToString();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AppCaja appCaja = new AppCaja();
            int idCierre;
            NameValueCollection data = new NameValueCollection();
            WebForm frm = new WebForm();
            ArrayList arr=new  ArrayList();
            DataTable dt4 = (Session["dt4"]) as DataTable;
            DataTable dt3 = (Session["dt3"]) as DataTable;
            DataTable dt2 = (Session["dt2"]) as DataTable;
            DataTable dt = (Session["dt"]) as DataTable;
            arr.Add(txt20000.Text);
            arr.Add(txt10000.Text);   
            arr.Add(txt5000.Text);
            arr.Add(txt2000.Text);
            arr.Add(txt1000.Text);
            arr.Add(txt500.Text);
            arr.Add(txt100.Text);
            arr.Add(txt50.Text);
            arr.Add(txt10.Text);
            arr.Add(txtCheque.Text);

            idCierre = appCaja.AgregarCierre(Convert.ToInt32(Session["idUsuario"].ToString()), Convert.ToInt32(Session["idSucursal"].ToString()), Convert.ToInt32(lblComputador.Text), Convert.ToInt32(lblDevolucionResumen.Text), Convert.ToInt32(lblIngesos.Text), dt, dt3, dt2, dt4, arr);

            
            data.Add("IdCierre", idCierre.ToString());

            frm.RedirectAndPOST(this.Page, "DetalleCierre.aspx", data);
        }

        protected void GridCreditos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt1 = Session["dt4"] as DataTable;
                dt1.Rows[index].Delete();
                Session["dt4"] = dt1;

                GridCreditos.DataSource = dt1;
                GridCreditos.DataBind();

            }
        }
        protected void GridEgresos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt1 = Session["dt4"] as DataTable;
                dt1.Rows[index].Delete();
                Session["dt"] = dt1;

                GridCreditos.DataSource = dt1;
                GridCreditos.DataBind();

            }
        }
        protected void GridIngresos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt1 = Session["dt4"] as DataTable;
                dt1.Rows[index].Delete();
                Session["dt3"] = dt1;

                GridCreditos.DataSource = dt1;
                GridCreditos.DataBind();

            }
        }
         protected void GridVentaMenor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt1 = Session["dt4"] as DataTable;
                dt1.Rows[index].Delete();
                Session["dt2"] = dt1;

                GridCreditos.DataSource = dt1;
                GridCreditos.DataBind();

            }

        }

        
        
        
       
    }
}
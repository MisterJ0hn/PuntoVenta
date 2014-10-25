using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.IO;
using System.Configuration;
using System.Data;
using System.Collections;

namespace InventarioWeb.admin
{
    public partial class ImportarStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                AppDocumentos appDoc = new AppDocumentos();
                AppEmpresas appEmpresa=new AppEmpresas();
                btnAgregar.Enabled = false;
                ArrayList arr = new ArrayList();
                arr = appDoc.SeleccionaEmpresa(0, 1, false, 3,Session["rutEmpresa"].ToString());
                cboSucursal.DataSource = appEmpresa.getSucursal(Session["rutEmpresa"].ToString());
                cboSucursal.DataTextField = "Nombre";
                cboSucursal.DataValueField = "Id";
                cboSucursal.DataBind();
                cboSucursal.Enabled = false;
                btnIngresarStock1.Enabled = false;
                if (arr.Count > 0)
                {
                    pnlDocActivos.Visible = true;
                    PnlImportar.Visible = false;
                    hdDocumento.Value = arr[0].ToString();
                    GridView2.DataBind();
                    btnIngresarStock1.Enabled = true;
                    cboSucursal.Enabled = true;
                }
                else
                {
                    PnlImportar.Visible = true;
                    pnlDocActivos.Visible = false;
                    
                }
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                DataTable dt = new DataTable();
                XLS import = new XLS();
                string FilePath = Server.MapPath(FolderPath + FileName);
                FileUpload1.SaveAs(FilePath);
                //dt=import.Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);
                dt = import.Import_To_Grid(FilePath, Extension, "Yes");

                GridView1.DataSource = dt;
                GridView1.DataBind();

                btnAgregar.Enabled = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            ArrayList arrFaltante = new ArrayList();
            int idDocumento = appDoc.AgregarDocumento(Session["rutEmpresa"].ToString(), 3);
            hdDocumento.Value = idDocumento.ToString();
            foreach(GridViewRow fila in GridView1.Rows){
                ArrayList arrFila = new ArrayList();
                arrFila=appDoc.DetalleProductoBuscar(fila.Cells[0].Text);
                if ( arrFila.Count > 0)
                {
                    

                        //appDoc.AgregarDetalledocumento(Convert.ToInt32(hdIdDetalle.Value), Convert.ToInt32(hdIdDocumento.Value), Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtPrecio.Text), 0, 0);

                        appDoc.AgregarDetalledocumento(Convert.ToInt32(arrFila[0].ToString()), idDocumento, Convert.ToInt32(fila.Cells[1].Text), 0, 0, 0);
                    
                }
                else
                {
                    arrFaltante.Add(fila.Cells[0].Text);
                }
            }

            foreach (String codigo in arrFaltante)
            {
                lstErrores.Items.Add(codigo);  
            }


            lblErrores.Visible = true;
            lstErrores.Visible = true;
            btnIngresarStock1.Enabled = true;
            cboSucursal.Enabled = true;

        }

        protected void btnIngresarStock1_Click(object sender, EventArgs e)
        {
            AppDocumentos appDoc = new AppDocumentos();
            appDoc.CerrarInicial(Convert.ToInt32(cboSucursal.SelectedValue), Convert.ToInt32(hdDocumento.Value));

            Response.Redirect("ImportarStock.aspx");
        }

        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioWebApp;
using System.Data;
using System.Collections;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.html;

using System.Diagnostics;
using iTextSharp.text.html.simpleparser;

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
                DataTable dtCredito = new DataTable();
                AppGestionU usuario=new AppGestionU();
                ArrayList arrUser=new ArrayList();
                int intIdCierre=Convert.ToInt32(idCierre);
                ArrayList arrDetDinero = new ArrayList();
                arrDetDinero = appCaja.SeleccionaDetalleDinero(intIdCierre);


                dtCaja = appCaja.SeleccionaCierre(intIdCierre);
                foreach (DataRow row in dtCaja.Rows)
                {
                    txtDevolucion.Text = row["Devolucion"].ToString();
                    lblComputador.Text = row["Computador"].ToString();
                    lblIngesos.Text = row["Ingresos"].ToString();
                    arrUser = usuario.AppSeleccionaUsuario(row["UsuarioCierre"].ToString());
                    lblResponsable.Text += arrUser[0].ToString()+" "+arrUser[1].ToString();
                    lblFecha.Text += row["FechaCierre"].ToString();

                }

                dtCredito = appCaja.SeleccionaCredito(intIdCierre);
                GridCreditos.DataSource = dtCredito;
       
                GridCreditos.DataBind();

                GridEgresos.DataSource = appCaja.SeleccionaEgreso(intIdCierre) as DataTable;
                GridEgresos.DataBind();

                GridIngresos.DataSource = appCaja.SeleccionaIngreso(intIdCierre) as DataTable;
                GridIngresos.DataBind();

                GridVentaMenor.DataSource = appCaja.SeleccionaVentaMenor(intIdCierre) as DataTable;
                GridVentaMenor.DataBind();

                txt20000.Text = arrDetDinero[0].ToString();
                txt10000.Text = arrDetDinero[1].ToString();
                txt5000.Text = arrDetDinero[2].ToString();
                txt2000.Text = arrDetDinero[3].ToString();
                txt1000.Text = arrDetDinero[4].ToString();
                txt500.Text = arrDetDinero[5].ToString();
                txt100.Text = arrDetDinero[6].ToString();
                txt50.Text = arrDetDinero[7].ToString();
                txt10.Text = arrDetDinero[8].ToString();
                txtCheque.Text = arrDetDinero[9].ToString();
                txtTotal.Text = (Convert.ToInt32(txt20000.Text) + Convert.ToInt32(txt10000.Text) + Convert.ToInt32(txt5000.Text) + Convert.ToInt32(txt2000.Text) + Convert.ToInt32(txt1000.Text) + Convert.ToInt32(txt500.Text) + Convert.ToInt32(txt100.Text) + Convert.ToInt32(txt50.Text) + Convert.ToInt32(txt10.Text) + Convert.ToInt32(txtCheque.Text)).ToString();

                SumarResumen();
            }
        }
        public void SumarResumen()
        {
            int sumarIngresos = 0;
            int sumarEgresos = 0;
            int sumarCreditos = 0;
            int sumarEfectivo = 0;

            //C}recorriendo Ingresos

            foreach (GridViewRow row in GridIngresos.Rows)
            {
                sumarIngresos += Convert.ToInt32(row.Cells[1].Text);

            }

            //recorriendo Egresos

            foreach (GridViewRow row1 in GridEgresos.Rows)
            {
                sumarEgresos += Convert.ToInt32(row1.Cells[1].Text);
            }

            //recorriendo Creditos
            foreach (GridViewRow row2 in GridCreditos.Rows)
            {
                sumarCreditos += Convert.ToInt32(row2.Cells[1].Text);
            }

            //recorriendo Efectivo
            sumarEfectivo += Convert.ToInt32(txtTotal.Text);


            lblCreditos.Text = sumarCreditos.ToString();
            lblEgresos.Text = sumarEgresos.ToString();
            lblDevolucionResumen.Text = txtDevolucion.Text;
            lblEfectivo.Text = sumarEfectivo.ToString();

            lblTotalResumen.Text = (Convert.ToInt32(lblCreditos.Text) + Convert.ToInt32(lblCreditos.Text) + Convert.ToInt32(lblDevolucionResumen.Text) + Convert.ToInt32(lblEfectivo.Text)).ToString();
            lblIngesos.Text = sumarIngresos.ToString();

            lblDiferencia.Text = (Convert.ToInt32(lblComputador.Text) - Convert.ToInt32(lblIngesos.Text)).ToString();

        }

        public void crear_pdf()
        {
            string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            Document document = new Document(PageSize.A4, 50, 50, 10, 10);
            PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
            document.Open();

            Paragraph parrafo = new Paragraph();

            parrafo.Alignment = Element.ALIGN_CENTER;
            parrafo.Font = FontFactory.GetFont("Arial", 24);
            parrafo.Font.SetStyle(Font.BOLD);
            parrafo.Font.SetStyle(Font.UNDERLINE);

            parrafo.Add("It's cool man, she's 18");

            document.Add(parrafo);

            PdfPTable unaTabla = new PdfPTable(2);
            unaTabla.SetWidthPercentage(new float[] { 300, 300 }, PageSize.A4);

            //Headers
            unaTabla.AddCell(new Paragraph("Columna 1"));
            unaTabla.AddCell(new Paragraph("Columna 2"));

            //¿Le damos un poco de formato?
            foreach (PdfPCell celda in unaTabla.Rows[0].GetCells())
            {
                celda.BackgroundColor = BaseColor.LIGHT_GRAY;
                celda.HorizontalAlignment = 1;
                celda.Padding = 3;
            }

            PdfPCell celda1 = new PdfPCell(new Paragraph("Celda 1", FontFactory.GetFont("Arial", 10)));
            PdfPCell celda2 = new PdfPCell(new Paragraph("Celda 2", FontFactory.GetFont("Arial", 10)));
            PdfPCell celda3 = new PdfPCell(new Paragraph("Celda 3", FontFactory.GetFont("Arial", 10)));
            PdfPCell celda4 = new PdfPCell(new Paragraph("Celda 4", FontFactory.GetFont("Arial", 10)));

            unaTabla.AddCell(celda1);
            unaTabla.AddCell(celda2);
            unaTabla.AddCell(celda3);
            unaTabla.AddCell(celda4);

            document.Add(unaTabla);

            document.Close();

            Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = fileName;
            prc.Start();
        }
        public String GeneraHtml()
        {
            String cuerpo = "";
            String htmlGridCreditos = "";
            String htmlGridIngreso = "";
            string htmlGridEgreso = "";
            String htmlGridVentamenor = "";
            String htmlDetalleDinero = "";
            String htmlDevolucion = "";
            String htmlResumen = "";
            String htmlCuadratura = "";

            htmlGridIngreso = "INGRESOS<table border='1'><tr><td>Detalle</td><td>Cantidad</td></tr>";
            foreach (GridViewRow row in GridIngresos.Rows)
            {

                htmlGridIngreso += "<tr><td>" + row.Cells[0].Text + "</td><td>" + row.Cells[1].Text + "</td></tr>";
            }
            htmlGridIngreso += "</table>";

            htmlGridCreditos = "CREDITO<table border='1'><tr><td>Detalle</td><td>Cantidad</td><td>Fecha</td></tr>";
            foreach (GridViewRow row2 in GridCreditos.Rows)
            {
                htmlGridCreditos += "<tr><td>" + row2.Cells[0].Text + "</td><td>" + row2.Cells[1].Text + "</td><td>" + row2.Cells[2].Text + "</td></tr>";
            }
            htmlGridCreditos+="</table>";

            htmlGridEgreso = "EGRESOS<table border='1'><tr><td>Detalle</td><td>Cantidad</td></tr>";
            foreach (GridViewRow row3 in GridIngresos.Rows)
            {

                htmlGridEgreso += "<tr><td>" + row3.Cells[0].Text + "</td><td>" + row3.Cells[1].Text + "</td></tr>";
            }
            htmlGridEgreso += "</table>";

            htmlGridVentamenor = "VENTA MENOR<table border='1'><tr><td>Detalle</td><td>Cantidad</td></tr>";
            foreach (GridViewRow row4 in GridIngresos.Rows)
            {

                htmlGridVentamenor += "<tr><td>" + row4.Cells[0].Text + "</td><td>" + row4.Cells[1].Text + "</td></tr>";
            }
            htmlGridVentamenor += "</table>";

            htmlDetalleDinero = "DETALLE DINERO<table border='1'><tr><td align='center'>$20.000</td><td>" + txt20000.Text + "</td></tr>";
            htmlDetalleDinero += "<tr><td>$10.000</td><td>" + txt10000.Text + "</td></tr>";
            htmlDetalleDinero += "<tr><td>$5.000</td><td>" + txt5000.Text + "</td></tr>";
            htmlDetalleDinero += "<tr><td>$2.000</td><td>" + txt2000.Text + "</td></tr>";
            htmlDetalleDinero += "<tr><td>$1.000</td><td>" + txt1000.Text + "</td></tr>";
            htmlDetalleDinero += "<tr><td>$500</td><td>" + txt500.Text + "</td></tr>";
            htmlDetalleDinero += "<tr><td>$100</td><td>" + txt100.Text + "</td></tr>";
            htmlDetalleDinero += "<tr><td>$50</td><td>" + txt50.Text + "</td></tr>";
            htmlDetalleDinero += "<tr><td>$10</td><td>" + txt10.Text + "</td></tr>";
            htmlDetalleDinero += "<tr><td>Cheque</td><td>" + txtCheque.Text + "</td></tr>";
            htmlDetalleDinero += "<tr><td>Total</td><td>" + txtTotal.Text + "</td></tr></table>";


            htmlDevolucion = "<table border='1'><tr><td >Devolucion de Garantia</td><td>" + txtDevolucion.Text + "</td></tr></table>";

            htmlResumen = "RESUMEN<table border='1'><tr><td align='center'>Creditos</td><td>" + lblCreditos.Text + "</td></tr>";
            htmlResumen += "<tr><td align='center'>Egresos</td><td>" + lblEgresos.Text + "</td></tr>";
            htmlResumen += "<tr><td align='center'>Devolucion</td><td>" + lblDevolucionResumen.Text + "</td></tr>";
            htmlResumen += "<tr><td align='center'>Efectivo</td><td>" + lblEfectivo.Text + "</td></tr>";
            htmlResumen += "<tr><td align='center'>Total</td><td>" + lblTotalResumen.Text + "</td></tr></table>";

            htmlCuadratura = "CUADRATURA<table border='1'><tr><td align='center'>Computador</td><td align='center'>" + lblComputador.Text + "</td></tr>";

            htmlCuadratura += "<tr><td>Ingresos</td><td>" + lblIngesos.Text + "</td></tr>";
            htmlCuadratura += "<tr><td>Diferencia</td><td>" + lblDiferencia.Text + "</td></tr></table>";
           



            cuerpo += "<table style='font-size:10px' align='center' valign='top'><tr><td colspan='3'></td></tr><tr><td>" + htmlGridCreditos +"<br /><br />"+ htmlGridVentamenor + "</td><td>" +
                htmlGridEgreso + "<br /><br />" + htmlDevolucion + "<br /><br />" + htmlGridIngreso + "</td><td>" +
                htmlDetalleDinero + "<br /><br />" + htmlResumen + "<br /><br />" + htmlCuadratura + "</td></tr></table>";
           
            return cuerpo;


        }
        public void Exportar_Pdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            /*StringWriter sw = new StringWriter();
           
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnlCierre.RenderControl(hw);*/
            StringReader sr = new StringReader(GeneraHtml());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            
            pdfDoc.SetPageSize(PageSize.LETTER.Rotate());
           
            pdfDoc.Open();
           
            htmlparser.Parse(sr);
          
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

        }
        protected void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar_Pdf();
        }
    }
}
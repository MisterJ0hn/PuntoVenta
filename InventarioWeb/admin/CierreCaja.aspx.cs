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

namespace InventarioWeb.admin
{
    public partial class CierreCaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void crear_pdf()
        {
            string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            crear_pdf();
        }
    }
}
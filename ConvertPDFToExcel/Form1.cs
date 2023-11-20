using System;
using System.Windows.Forms;
using Spire.Pdf;

namespace ConvertPDFToExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult fileLoad = openFileDialog1.ShowDialog();

            string password = txtPassword.Text;
            string path = @"J:\Learn\PDFtoWord\";

            if (fileLoad == DialogResult.OK)
            {
                //Create a PdfDocument instance
                PdfDocument pdf = new PdfDocument();

                //Load the PDF file
                pdf.LoadFromFile(path + "Sample.pdf", password);

                //Save to Excel
                pdf.SaveToFile(path + "PDFToExcel.xlsx", FileFormat.XLSX);
                
                //Save to Word
                //pdf.SaveToFile("PDFtoWord.Docx", FileFormat.DOCX);

            }
        }
    }
}

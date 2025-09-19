using System;
using System.IO;
using System.Collections;

namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {
            // Before starting, we recommend to get a free key:
            // https://sautinsoft.com/start-for-free/

            // Apply the key here:
            // SautinSoft.PdfMetamorphosis.SetLicense("...");

            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            if (p != null)
            {
                string docxPath = @"..\..\..\example.docx";
                string pdfPath = Path.ChangeExtension(docxPath, ".pdf");
                MemoryStream docx = new MemoryStream(File.ReadAllBytes(docxPath));

                // 3. Convert DOCX to PDF in stream                
                Stream pdf = p.DocxToPdfConvertStream(docx);

                if (pdf != null)
                {
                    pdf.Position = 0;
                    var ms = new MemoryStream();
                    pdf.CopyTo(ms);
                    ms.Position = 0;
                    // 3. Save the PDF document to a file for a viewing purpose.
                    File.WriteAllBytes(pdfPath, ms.ToArray());
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
                }
                else
                {
                    System.Console.WriteLine("Conversion failed!");
                    Console.ReadLine();
                }
            }
        }
    }
}
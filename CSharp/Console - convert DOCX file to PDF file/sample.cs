using System;
using System.IO;
using System.Collections;

namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {
            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();
            // After purchasing the license, please insert your serial number here to activate the component.
            //p.Serial = "XXXXXXXXXXX";

            if (p != null)
            {
                string docxPath = @"..\..\example.docx";
                string pdfPath = Path.ChangeExtension(docxPath, ".pdf");

                // 2. Convert DOCX file to PDF file
                if (p.DocxToPdfConvertFile(docxPath, pdfPath) == 0)
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
                else
                {
                    System.Console.WriteLine("Conversion failed!");
                    Console.ReadLine();
                }
            }
        }
    }
}

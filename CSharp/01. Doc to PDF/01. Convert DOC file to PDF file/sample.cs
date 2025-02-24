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
                string docPath = @"..\..\..\example.doc";
                string pdfPath = Path.ChangeExtension(docPath, ".pdf");

                // 2. Convert DOC file to PDF file
                if (p.DocToPdfConvertFile(docPath, pdfPath) == 0)
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

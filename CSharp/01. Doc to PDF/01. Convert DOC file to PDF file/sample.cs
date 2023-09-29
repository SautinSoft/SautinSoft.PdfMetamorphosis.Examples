using System;
using System.IO;
using System.Collections;

namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {
			// Activate your license here
			// SautinSoft.PdfMetamorphosis.SetLicense("1234567890");

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

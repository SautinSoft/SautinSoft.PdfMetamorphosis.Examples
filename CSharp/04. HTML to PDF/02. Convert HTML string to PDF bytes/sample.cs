using System;
using System.IO;
using System.Collections;
using System.Net;

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
                string inpFile = @"..\..\..\example.htm";
                string outFile = Path.ChangeExtension(inpFile, ".pdf");                

                // The easiest way is using the method 'HtmlToPdfConvertFile':
                // int ret = p.HtmlToPdfConvertFile(htmlPath,pdfPath);
                // or :
                // 1. Get HTML content.
                string htmlString = File.ReadAllText(inpFile);

                // 2. Converting HTML to PDF
                // Specify BaseUrl to help converter find a full path for relative images, CSS.
                p.HtmlSettings.BaseUrl = Path.GetDirectoryName(Path.GetFullPath(inpFile));
                byte[] pdfBytes = p.HtmlToPdfConvertStringToByte(htmlString);

                if (pdfBytes != null)
                {
                    // 3. Save the PDF document to a file for a viewing purpose.
                    File.WriteAllBytes(outFile, pdfBytes);
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
                }
                else
                {               
                    System.Console.WriteLine("An error occurred during converting HTML to PDF!");
                }
            }
        }        
    }
}

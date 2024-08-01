using System;
using System.IO;
using System.Collections;

namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {
			// Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfMetamorphosis.SetLicense("...");

            // How to change the page footer to the custom footer
            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            if (p != null)
            {                
                string inputFile = @"..\..\..\example.rtf";
                string originalPdf = @"..\..\..\Original.pdf";
                string customPdf = @"..\..\..\CustomFooter.pdf";

                // Let's convert RTF which has an own page footer to PDF
                if (p.RtfToPdfConvertFile(inputFile, originalPdf)==0)
                {
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(originalPdf) { UseShellExecute = true });
                }

                // Let's change the footer to custom
                string footerInHtml = "<table width=\"100%\" border=\"1\"><tr><td width=\"50%\"></td><td>This is new custom footer!</td></tr></table>";
                p.PageSettings.Footer.FromString(footerInHtml, SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html);

                // Let's convert RTF to PDF and change the footer to the custom
                if (p.RtfToPdfConvertFile(inputFile, customPdf) == 0)
                {
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(customPdf) { UseShellExecute = true });
                }
            }
        }
    }
}

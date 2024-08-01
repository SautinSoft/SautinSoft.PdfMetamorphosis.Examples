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

            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            // Specify some page options.
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape;

            // Set page header in HTML format.
            p.PageSettings.Header.FromString("<b style=\"color: green;\">Sample header in HTML format</b>", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html);

            // Set page footer in RTF format.
            p.PageSettings.Footer.FromString("{\\rtf1 \\b Bold Footer in RTF format}", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Rtf);

            // Set page numbers.
            p.PageSettings.Numbering.Text = "Page {page} of {numpages}";

            if (p != null)
            {
                string rtfPath = @"..\..\..\example.rtf";
                string pdfPath = Path.ChangeExtension(rtfPath, ".pdf");

                int i = p.RtfToPdfConvertFile(rtfPath, pdfPath);

                if (i != 0)
                {
                    System.Console.WriteLine("An error occurred during converting RTF to PDF!");
                }
                else
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
                }
            }
        }
    }
}

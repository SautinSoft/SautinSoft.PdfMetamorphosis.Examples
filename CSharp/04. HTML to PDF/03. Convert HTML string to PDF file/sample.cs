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

            // Specify some PDF options.
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Portrait;
            p.PageSettings.Size.Letter();

            // Specify header in HTML format.
            p.PageSettings.Header.FromString("<b>Sample header in HTML format</b>", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html);

            // Specify footer in RTF format.
            p.PageSettings.Footer.FromString(@"{\rtf1 \b Bold Footer}", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Rtf);

            // Specify page numbers
            p.PageSettings.Numbering.Text = "Page {page} of {numpages}";
            p.PageSettings.Numbering.PosX.Mm = p.PageSettings.Size.Width.Mm / 2;
            p.PageSettings.Numbering.PosY.Mm = 10;

            if (p != null)
            {
                string inpFile = @"..\..\..\example.htm";
                string outFile = Path.ChangeExtension(inpFile, ".pdf");

                // The easiest way is using the method 'HtmlToPdfConvertFile':
                // int ret = p.HtmlToPdfConvertFile(htmlPath,pdfPath);
                // or :
                // 1. Get HTML content from file				
                string htmlString = File.ReadAllText(inpFile);

                // 2. Converting HTML to PDF
                // Specify BaseUrl to help converter find a full path to relative images and external CSS.
                p.HtmlSettings.BaseUrl = Path.GetDirectoryName(inpFile);

                if (p.HtmlToPdfConvertStringToFile(htmlString, outFile) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
                else
                    System.Console.WriteLine("An error occurred during converting HTML to PDF!");
            }
        }
    }
}

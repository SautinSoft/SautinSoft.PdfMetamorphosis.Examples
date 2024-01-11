using System.IO;

namespace Sample
{

    class Test
    {

        static void Main(string[] args)
        {
			// Activate your license here
			// SautinSoft.PdfMetamorphosis.SetLicense("1234567890");

            //How to add page header and footer
            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            //Let's add page header in HTML format
            string headerInHtml = "<table width=\"100%\" border=\"0\" style=\"border-collapse: collapse\"><tr><td style=\"border: 1pt solid black\" ></td><td width=\"50%\" align=\"center\" style=\"border: 1pt solid black\">You are welcome!</td></tr></table>";
            p.PageSettings.Header.FromString(headerInHtml, SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html);

            string footerInRtf = @"{\rtf1\i Italic footer }";
            p.PageSettings.Footer.FromString(footerInRtf, SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Rtf);

            if (p != null)
            {
                string inputFile = @"..\..\..\example.htm";
                string outputFile = Path.ChangeExtension(inputFile, ".pdf");

                int result = p.HtmlToPdfConvertFile(inputFile, outputFile);

                if (result == 0)
                {
                    System.Console.WriteLine("Converted successfully!");
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outputFile) { UseShellExecute = true });
                }
                else
                {
                    System.Console.WriteLine("Converting Error!");
                }
            }
        }
    }
}

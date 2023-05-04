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

            //specify some options
            p.PageSettings.Size.A4();
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape;
            p.PageSettings.Numbering.Text = "Page {page} of {numpages}";

            if (p != null)
            {
                string inputFile = @"..\..\example.htm";
                string outputFile = @"..\..\test.pdf";

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

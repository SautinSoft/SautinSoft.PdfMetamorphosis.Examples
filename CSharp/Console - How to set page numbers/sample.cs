using System;
using System.IO;
using System.Collections;

namespace Sample
{
	
    class Test
	{
		
		static void Main(string[] args)
		{
            // This sample shows how to specify page numbers
			SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

			// After purchasing the license, please insert your serial number here to activate the component
			//p.Serial = "XXXXXXXXXXX";

            //Page 1 of N, position: 30 mm from the left of the page
            p.PageSettings.Numbering.Text = "Page {page} of {numpages}";
            p.PageSettings.Numbering.PosX.Mm = 30;
            p.PageSettings.Numbering.PosY.Mm = 10;
            p.PageSettings.Numbering.FontFace = "Courier";
            p.PageSettings.Numbering.FontSize = 22;

			if (p != null)
			{
				string rtfPath = @"..\..\example.rtf";
                string pdfPath = @"..\..\example.pdf";

				int i = p.RtfToPdfConvertFile(rtfPath,pdfPath);

				if (i !=0)
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

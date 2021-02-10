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
                string rtfPath = @"..\..\example.rtf";
				string pdfPath = Path.ChangeExtension(rtfPath,".pdf");

                // 1. Get RTF content from file
                string rtfString = File.ReadAllText(rtfPath);

				// 2. Convert RTF string to a PDF file
				if (p.RtfToPdfConvertStringToFile(rtfString,pdfPath)==0)
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
				else
					System.Console.WriteLine("An error occurred during converting RTF to PDF!");
			}
		}
	}
}

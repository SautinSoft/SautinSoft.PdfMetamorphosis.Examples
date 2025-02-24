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

            //How to set page size, orientation and margins
			SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

			//Let's set: A3, Landscape orientation, left and right margins: 1.5 Inch, top and bottom: 1 Inch
            p.PageSettings.Size.A3();
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape;
            p.PageSettings.MarginLeft.Inch(1.5f);
            p.PageSettings.MarginRight.Inch(1.5f);
            p.PageSettings.MarginTop.Inch(1.0f);
            p.PageSettings.MarginBottom.Inch(1.0f);

			if (p != null)
			{
                string rtfPath = @"..\..\..\example.rtf";
                string pdfPath = Path.ChangeExtension(rtfPath, ".pdf");

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

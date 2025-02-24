using System;
using System.IO;

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

			SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

			// Let's set: A4, Landscape orientation, left and right margins: 1.5 Inch, top and bottom: 1 Inch
            p.PageSettings.Size.A4();
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape;
            p.PageSettings.MarginLeft.Inch(1.5f);
            p.PageSettings.MarginRight.Inch(1.5f);
            p.PageSettings.MarginTop.Inch(1.0f);
            p.PageSettings.MarginBottom.Inch(1.0f);

			if (p != null)
			{
                string textPath = @"..\..\..\example.txt";
				string pdfPath = Path.ChangeExtension(textPath,".pdf");

                if (p.TextToPdfConvertFile(textPath, pdfPath) == 0)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
                else
                {
                    System.Console.WriteLine("An error occurred during converting Text to PDF!");
                    Console.ReadLine();
                }
			}
		}
	}
}

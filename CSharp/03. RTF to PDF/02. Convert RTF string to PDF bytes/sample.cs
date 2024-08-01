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

			// Specify some options.
			p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape;

			// Specify page numbers.
			p.PageSettings.Numbering.Text = "Page {page} of {numpages}";

			if (p != null)
			{
                string rtfPath = @"..\..\..\example.rtf";
                string pdfPath = Path.ChangeExtension(rtfPath, ".pdf");
                byte[] rtfBytes = File.ReadAllBytes(rtfPath);
			
				//2. Converting RTF to PDF
				byte[] pdfBytes = p.RtfToPdfConvertByte(rtfBytes);

				if (pdfBytes != null)
				{
                    //3. Save the PDF document to a file for a viewing purpose.
                    File.WriteAllBytes(pdfPath, pdfBytes);
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
				}
				else
				{
					System.Console.WriteLine("An error occurred during converting RTF to PDF!");
				}
			}
		}
	}
}

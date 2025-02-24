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

            // How to set a single font for the whole PDF document.
			SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            // Let's make that the all text in PDF became in 'Courier New' font
			p.TextSettings.FontFace.Custom("Courier New");

            // Set also a single font size 10
            p.TextSettings.FontSize = 10;

            // Set also single text color
            p.TextSettings.FontColor = System.Drawing.Color.FromArgb(33, 150, 150);

            // Embed all fonts inside PDF.
            p.PdfSettings.EmbedAllFonts = true;

			if (p != null)
			{
                string rtfPath = @"..\..\..\example.rtf";
                string pdfPath = @"..\..\..\example.pdf";

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

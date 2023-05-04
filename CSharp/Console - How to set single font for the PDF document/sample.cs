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

            // How to set a single font for the whole PDF document.
			SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            // Let's make that the all text in PDF became in 'Comic Sans MS' font
			p.TextSettings.FontFace.Custom("Comic Sans MS");

            // Set also a single font size 10
            p.TextSettings.FontSize = 10;

            // Set also single text color
            p.TextSettings.FontColor = System.Drawing.Color.FromArgb(33, 150, 33);

			if (p != null)
			{
                string rtfPath = @"..\..\example.rtf";
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

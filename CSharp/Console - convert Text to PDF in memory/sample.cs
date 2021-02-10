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
				string textPath = @"..\..\example.txt";
                string pdfPath = Path.ChangeExtension(textPath, ".pdf");
                string textString = File.ReadAllText(textPath);
			
				// 2. Convert Text to PDF in memory                
                byte[] pdfBytes = p.TextToPdfConvertStringToByte(textString);

				if (pdfBytes != null)
				{
                    //3. Save the PDF document to a file for a viewing purpose.
                    File.WriteAllBytes(pdfPath, pdfBytes);
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
				}
				else
				{
					System.Console.WriteLine("An error occurred during converting Text to PDF!");
				}
			}
		}
	}
}

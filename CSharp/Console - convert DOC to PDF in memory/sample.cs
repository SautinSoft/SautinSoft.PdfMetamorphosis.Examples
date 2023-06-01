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

			if (p != null)
			{
                string docPath = @"..\..\..\example.doc";
                string pdfPath = Path.ChangeExtension(docPath, ".pdf");
                byte[] doc = File.ReadAllBytes(docPath);
                			
				// 2. Convert DOC to PDF in memory                
                byte[] pdf = p.DocToPdfConvertByte(doc);

				if (pdf != null)
				{
                    // 3. Save the PDF document to a file for a viewing purpose.
                    File.WriteAllBytes(pdfPath, pdf);
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
				}
				else
				{
					System.Console.WriteLine("Conversion failed!");
                    Console.ReadLine();
				}
			}
		}
	}
}

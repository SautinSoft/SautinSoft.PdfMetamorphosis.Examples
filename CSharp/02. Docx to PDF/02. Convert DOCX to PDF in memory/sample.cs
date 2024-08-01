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
		
			if (p != null)
			{
                string docxPath = @"..\..\..\example.docx";
                string pdfPath = Path.ChangeExtension(docxPath, ".pdf");
                byte[] docx = File.ReadAllBytes(docxPath);
                			
				// 2. Convert DOCX to PDF in memory                
                byte[] pdf = p.DocxToPdfConvertByte(docx);

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

using System;
using System.IO;
using System.Collections;
using SautinSoft;

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

			PdfMetamorphosis.SetLicense("1234567890");
			
            // Place your serial(s) number.
            // You will get own serial number(s) after purchasing the license.
            // If you will have any questions, email us to sales@sautinsoft.com or ask at online chat https://www.sautinsoft.com.

            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();
			
			string docxPath = @"..\..\..\example.docx";
			string pdfPath = Path.ChangeExtension(docxPath, ".pdf");
            if (p.DocxToPdfConvertFile(docxPath, pdfPath) == 0)
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
		}
	}
}

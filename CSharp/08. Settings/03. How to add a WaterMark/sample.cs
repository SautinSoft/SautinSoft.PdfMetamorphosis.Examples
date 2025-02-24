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

            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            SautinSoft.PdfMetamorphosis.WaterMark w1 = new SautinSoft.PdfMetamorphosis.WaterMark(@"..\..\..\WaterMark.png");
            w1.PosX.Mm = 0;
            w1.PosX.Mm = 0;
            w1.PosDX.Mm = 50;
            w1.PosDY.Mm = 50;

            p.WaterMarks.Add(w1);

            if (p != null)
            {
                string rtfPath = @"..\..\..\example.rtf";
                string pdfPath = Path.ChangeExtension(rtfPath, ".pdf");

                int i = p.RtfToPdfConvertFile(rtfPath, pdfPath);

                if (i != 0)
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

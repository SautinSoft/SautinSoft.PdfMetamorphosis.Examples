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

            SautinSoft.PdfMetamorphosis.WaterMark w1 = new SautinSoft.PdfMetamorphosis.WaterMark(@"..\..\WaterMark.png");
            w1.PosX.Mm = 0;
            w1.PosX.Mm = 0;
            w1.PosDX.Mm = 50;
            w1.PosDY.Mm = 50;

            p.WaterMarks.Add(w1);

            SautinSoft.PdfMetamorphosis.WaterMark w2 = p.WaterMarks.Add();
            w2.Img = System.Drawing.Image.FromFile(@"..\..\WaterMark.png");
            w2.Transparency = 20;
            w2.PosX.Mm = 60;
            w2.PosY.Mm = 0;
            w2.PosDX.Mm = 100;
            w2.PosDY.Mm = 100;
            w2.SelectedPages = new int[] { 1 };

            if (p != null)
            {
                string rtfPath = @"..\..\example.rtf";
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

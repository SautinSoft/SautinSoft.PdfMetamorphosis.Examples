using System.IO;

namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {
            // How to set a version for the PDF document.
            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            // After purchasing the license, please insert your serial number here to activate the component
            //p.Serial = "XXXXXXXXXXX";

            // PDF Metamorphosis .Net generates PDF 1.4 document by default.
            // Let's change the PDF version to PDF_A.
            p.PdfSettings.PdfVersion = SautinSoft.PdfMetamorphosis.PdfSetting.PdfVersions.PDF_A;

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

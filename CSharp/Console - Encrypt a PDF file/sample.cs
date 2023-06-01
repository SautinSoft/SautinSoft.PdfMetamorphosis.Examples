using System.IO;

namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {	
			// Activate your license here
			// SautinSoft.PdfMetamorphosis.SetLicense("1234567890");

            // Contains details for encrypting and access permissions for a PDF document.
            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            // Specify the owner password for the encrypted PDF document.
            p.PdfSettings.PdfSecurity.OwnerPassword = "1234567890";
			
			// Specify the user's password required to open the encrypted PDF document.
            p.PdfSettings.PdfSecurity.UserPassword = "0987654321";

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

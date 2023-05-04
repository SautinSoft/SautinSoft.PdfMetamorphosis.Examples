using System;
using System.IO;
using System.Collections;
using System.Net;

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
                string htmlPath = @"..\..\example.htm";
                string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                string htmlString = "";

                // The easiest way is using the method 'HtmlToPdfConvertFile':
                // int ret = p.HtmlToPdfConvertFile(htmlPath,pdfPath);
                // or :
                // 1. Get HTML content.
                htmlString = ReadFromFile(htmlPath); 

                // 2. Converting HTML to PDF
                // Specify BaseUrl to help converter find a full path for relative images, CSS.
                p.HtmlSettings.BaseUrl = Path.GetDirectoryName(Path.GetFullPath(htmlPath));
                byte[] pdfBytes = p.HtmlToPdfConvertStringToByte(htmlString);

                if (pdfBytes != null)
                {
                    // 3. Save the PDF document to a file for a viewing purpose.
                    File.WriteAllBytes(pdfPath, pdfBytes);
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
                }
                else
                {               
                    System.Console.WriteLine("An error occurred during converting HTML to PDF!");
                }
            }
        }

        public static string ReadFromFile(string fileName)
        {
            try
            {
                FileInfo fi = new FileInfo(fileName);
                FileStream strmRead = fi.Open(FileMode.Open);
                int len = (int)fi.Length;
                byte[] b = new byte[len];
                strmRead.Read(b, 0, len);
                strmRead.Close();
                char[] arCharRes = new char[len];
                for (int i = 0; i < len; i++)
                {
                    arCharRes[i] = (char)b[i];
                }
                return new string(arCharRes);
            }
            catch
            {                
                return "";
            }
        }
    }
}

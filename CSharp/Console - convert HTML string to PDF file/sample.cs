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

			// Specify some PDF options.
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Portrait;
            p.PageSettings.Size.Letter();

            // Specify header in HTML format.
            p.PageSettings.Header.FromString("<b>Sample header in HTML format</b>",SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html);

			// Specify footer in RTF format.
            p.PageSettings.Footer.FromString(@"{\rtf1 \b Bold Footer}", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Rtf );

			// Specify page numbers
            p.PageSettings.Numbering.Text = "Page {page} of {numpages}";
            p.PageSettings.Numbering.PosX.Mm = p.PageSettings.Size.Width.Mm/2;
            p.PageSettings.Numbering.PosY.Mm = 10;

			if (p != null)
			{
                string htmlPath = @"..\..\..\example.htm";
                string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
				string htmlString = "";

				// The easiest way is using the method 'HtmlToPdfConvertFile':
				// int ret = p.HtmlToPdfConvertFile(htmlPath,pdfPath);
				// or :
				// 1. Get HTML content from file				
                htmlString = ReadFromFile(htmlPath);

				// 2. Converting HTML to PDF
				// Specify BaseUrl to help converter find a full path to relative images and external CSS.
				p.HtmlSettings.BaseUrl = Path.GetDirectoryName(htmlPath);

				if (p.HtmlToPdfConvertStringToFile(htmlString, pdfPath)==0)
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
				else
					System.Console.WriteLine("An error occurred during converting HTML to PDF!");
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

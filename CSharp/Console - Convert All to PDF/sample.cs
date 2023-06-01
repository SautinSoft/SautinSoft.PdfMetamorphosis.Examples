using System.IO;

namespace Sample
{
    internal class Test
    {

        private static void Main(string[] args)
        {
			// Activate your license here
			// SautinSoft.PdfMetamorphosis.SetLicense("1234567890");

            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            //Prepare variables with path.
            string docxFile = Path.GetFullPath(@"..\..\..\example.docx");
            string pdfFileFromDocx = Path.GetFullPath(@"..\..\..\exampleResultDocx.pdf");
            string rtfFile = Path.GetFullPath(@"..\..\..\example.rtf");
            string pdfFileFromRtf = Path.GetFullPath(@"..\..\..\exampleResultRtf.pdf");
            string htmlFile = Path.GetFullPath(@"..\..\..\example.htm");
            string pdfFileFromHtml = Path.GetFullPath(@"..\..\..\exampleResultHtml.pdf");
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(Path.GetFullPath(@"..\..\..\")) { UseShellExecute = true });

            // Convert DOCX file to PDF file
            p.DocxToPdfConvertFile(docxFile, pdfFileFromDocx);
            // Convert RTF file to PDF file
            p.RtfToPdfConvertFile(rtfFile, pdfFileFromRtf);
            // Convert HTML file to PDF file
            p.HtmlToPdfConvertFile(htmlFile, pdfFileFromHtml);
        }
    }
}

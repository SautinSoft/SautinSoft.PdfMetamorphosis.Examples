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
            string rtfPath = @"..\..\example.rtf";
            string pdfPath = @"..\..\test.pdf";

            // Let's create a PDF file from RTF file
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape;

            //Specify page numbers: {1 of N}, font: Verdana, 18
            p.PageSettings.Numbering.Text = "{page} of {numpages}";
            p.PageSettings.Numbering.FontFace = "Verdana";
            p.PageSettings.Numbering.FontSize = 18;
            
            p.RtfToPdfConvertFile(rtfPath, pdfPath);

            #region split PDF file
            //Split PDF by pages: 1st, 2nd, 3rd ...
            p.SplitPDFFileToPDFFolder(pdfPath, Path.GetDirectoryName(pdfPath));
            #endregion

            #region merge PDF files
            //Merge only 1st and 3rd pages
            string[] pdfFiles = { @"..\..\test-00001.pdf", @"..\..\test-00003.pdf" };
            p.MergePDFFileArrayToPDFFile(pdfFiles, @"..\..\test_Split_and_Merge_1and3page.pdf");
            #endregion

            //Show merged PDF (it doesn't have 2nd page)
			System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(@"..\..\test_Split_and_Merge_1and3page.pdf") { UseShellExecute = true });
        }
    }
}

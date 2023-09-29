Imports System.IO

Module sample

    Sub Main()
				' Activate your license here
				' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")

        Dim p As New SautinSoft.PdfMetamorphosis()
        Dim rtfPath As String = "..\..\..\example.rtf"
        Dim pdfPath As String = "..\..\..\test.pdf"

        ' Let's create a PDF file from RTF file
        p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape

        'Specify page numbers: {1 of N}, font: Verdana, 18
        p.PageSettings.Numbering.Text = "{page} of {numpages}"
        p.PageSettings.Numbering.FontFace = "Verdana"
        p.PageSettings.Numbering.FontSize = 18
        p.RtfToPdfConvertFile(rtfPath, pdfPath)

        'Split PDF by pages: 1st, 2nd, 3rd ...
        p.SplitPDFFileToPDFFolder(pdfPath, Path.GetDirectoryName(pdfPath))

        'Merge only 1st and 3rd pages
        Dim pdfFiles() As String = {"..\..\..\test-00001.pdf", "..\..\..\test-00003.pdf"}
        p.MergePDFFileArrayToPDFFile(pdfFiles, "..\..\..\test_Split_and_Merge_1and3page.pdf")

        'Show merged PDF (it doesn't have 2nd page)
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo("..\..\..\test_Split_and_Merge_1and3page.pdf") With {.UseShellExecute = True})
    End Sub
End Module
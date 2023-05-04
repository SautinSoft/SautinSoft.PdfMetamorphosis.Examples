Imports System.IO

Namespace Sample
    Friend Class Test

        Shared Sub Main(ByVal args() As String)
            ' Activate your license here
			' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")

			Dim p As New SautinSoft.PdfMetamorphosis()

            ' Prepare variables with path.
            Dim docxFile As String = Path.GetFullPath("..\..\example.docx")
            Dim pdfFileFromDocx As String = Path.GetFullPath("..\..\exampleFromDocx.pdf")
            Dim rtfFile As String = Path.GetFullPath("..\..\example.rtf")
            Dim pdfFileFromRtf As String = Path.GetFullPath("..\..\exampleFromRtf.pdf")
            Dim htmlFile As String = Path.GetFullPath("..\..\example.htm")
            Dim pdfFileFromHtml As String = Path.GetFullPath("..\..\exampleFromHtml.pdf")
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Path.GetFullPath("..\..\")) With {.UseShellExecute = True})

            ' Convert DOCX file to PDF file
            p.DocxToPdfConvertFile(docxFile, pdfFileFromDocx)
			' Convert RTF file to PDF file
            p.RtfToPdfConvertFile(rtfFile, pdfFileFromRtf)
			' Convert HTML file to PDF file
            p.HtmlToPdfConvertFile(htmlFile, pdfFileFromHtml)
        End Sub
    End Class
End Namespace
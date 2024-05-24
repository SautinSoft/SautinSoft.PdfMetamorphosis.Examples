Imports Microsoft.VisualBasic
Imports System.IO

Namespace Sample
    Friend Class Test

        Shared Sub Main(ByVal args() As String)
            ' Activate your license here
            ' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")

            Dim p As New SautinSoft.PdfMetamorphosis()

            ' Specify some PDF options.
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Portrait
            p.PageSettings.Size.Letter()

            ' Specify header in HTML format.
            p.PageSettings.Header.FromString("<b>Sample header in HTML format</b>", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html)

            ' Specify footer in RTF format.
            p.PageSettings.Footer.FromString("{\rtf1 \b Bold footer}", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Rtf)

            ' Specify page numbers
            p.PageSettings.Numbering.Text = "Page {page} of {numpages}"
            p.PageSettings.Numbering.PosX.Mm = p.PageSettings.Size.Width.Mm / 2
            p.PageSettings.Numbering.PosY.Mm = 10

            If p IsNot Nothing Then
                Dim inpFile As String = "..\..\..\example.htm"
                Dim outFile As String = Path.ChangeExtension(inpFile, ".pdf")

                ' The easiest way is using the method 'HtmlToPdfConvertFile':
                ' int ret = p.HtmlToPdfConvertFile(htmlPath,pdfPath)
                ' or :
                ' 1. Get HTML content from file				
                Dim htmlString As String = File.ReadAllText(inpFile)

                ' 2. Converting HTML to PDF
                ' Specify BaseUrl to help converter find a full path to relative images and external CSS.
                p.HtmlSettings.BaseUrl = Path.GetDirectoryName(inpFile)

                If p.HtmlToPdfConvertStringToFile(htmlString, outFile) = 0 Then
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("An error occurred during converting HTML to PDF!")
                End If
            End If
        End Sub
    End Class
End Namespace
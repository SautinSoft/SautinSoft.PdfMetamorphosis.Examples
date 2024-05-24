Imports System.IO

Namespace Sample
    Friend Class Test

        Shared Sub Main(ByVal args() As String)
            ' Activate your license here
            ' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")

            Dim p As New SautinSoft.PdfMetamorphosis()

            If p IsNot Nothing Then
                Dim inpFile As String = "..\..\..\example.htm"
                Dim outFile As String = Path.ChangeExtension(inpFile, ".pdf")

                ' The easiest way is using the method 'HtmlToPdfConvertFile':
                ' int ret = p.HtmlToPdfConvertFile(htmlPath,pdfPath)
                ' or :
                ' 1. Get HTML content.
                Dim htmlString As String = File.ReadAllText(inpFile)

                ' 2. Converting HTML to PDF
                ' Specify BaseUrl to help converter find a full path for relative images, CSS.
                p.HtmlSettings.BaseUrl = Path.GetDirectoryName(Path.GetFullPath(inpFile))
                Dim pdfBytes() As Byte = p.HtmlToPdfConvertStringToByte(htmlString)

                If pdfBytes IsNot Nothing Then

                    ' 3. Save the PDF document to a file for a viewing purpose.
                    File.WriteAllBytes(outFile, pdfBytes)
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("An error occurred during converting HTML to PDF!")
                End If
            End If
        End Sub
    End Class
End Namespace
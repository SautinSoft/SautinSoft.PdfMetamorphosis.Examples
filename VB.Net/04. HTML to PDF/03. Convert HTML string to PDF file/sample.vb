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
                Dim htmlPath As String = "..\..\..\example.htm"
                Dim pdfPath As String = Path.ChangeExtension(htmlPath, ".pdf")
                Dim htmlString As String = ""

                ' The easiest way is using the method 'HtmlToPdfConvertFile':
                ' int ret = p.HtmlToPdfConvertFile(htmlPath,pdfPath)
                ' or :
                ' 1. Get HTML content from file				
                htmlString = ReadFromFile(htmlPath)

                ' 2. Converting HTML to PDF
                ' Specify BaseUrl to help converter find a full path to relative images and external CSS.
                p.HtmlSettings.BaseUrl = Path.GetDirectoryName(htmlPath)

                If p.HtmlToPdfConvertStringToFile(htmlString, pdfPath) = 0 Then
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("An error occurred during converting HTML to PDF!")
                End If
            End If
        End Sub
        Public Shared Function ReadFromFile(ByVal fileName As String) As String
            Try
                Dim fi As New FileInfo(fileName)
                Dim strmRead As FileStream = fi.Open(FileMode.Open)
                Dim len As Integer = CInt(fi.Length)
                Dim b(len - 1) As Byte
                strmRead.Read(b, 0, len)
                strmRead.Close()
                Dim arCharRes(len - 1) As Char
                For i As Integer = 0 To len - 1
                    arCharRes(i) = ChrW(b(i))
                Next i
                Return New String(arCharRes)
            Catch
                Return ""
            End Try
        End Function
    End Class
End Namespace
Imports System.IO

Namespace Sample
    Friend Class Test

        Shared Sub Main(ByVal args() As String)
			Dim p As New SautinSoft.PdfMetamorphosis()

            ' After purchasing the license, please insert your serial number here to activate the component
            ' p.Serial = "XXXXXXXXXXX"

            If p IsNot Nothing Then
                Dim htmlPath As String = "..\..\example.htm"
                Dim pdfPath As String = Path.ChangeExtension(htmlPath, ".pdf")
                Dim htmlString As String = ""

                ' The easiest way is using the method 'HtmlToPdfConvertFile':
                ' int ret = p.HtmlToPdfConvertFile(htmlPath,pdfPath)
                ' or :
                ' 1. Get HTML content.
                htmlString = ReadFromFile(htmlPath)

                ' 2. Converting HTML to PDF
                ' Specify BaseUrl to help converter find a full path for relative images, CSS.
                p.HtmlSettings.BaseUrl = Path.GetDirectoryName(Path.GetFullPath(htmlPath))
                Dim pdfBytes() As Byte = p.HtmlToPdfConvertStringToByte(htmlString)

                If pdfBytes IsNot Nothing Then

                    ' 3. Save the PDF document to a file for a viewing purpose.
                    File.WriteAllBytes(pdfPath, pdfBytes)
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
                    arCharRes(i) = Microsoft.VisualBasic.ChrW(b(i))
                Next i
                Return New String(arCharRes)
            Catch
                Return ""
            End Try
        End Function
    End Class
End Namespace
Imports System.IO

Namespace Sample
    Friend Class Test
        Shared Sub Main(ByVal args() As String)
            Dim p As New SautinSoft.PdfMetamorphosis()

            ' After purchasing the license, please insert your serial number here to activate the component.
            'p.Serial = "XXXXXXXXXXX"

            If p IsNot Nothing Then
                Dim rtfPath As String = "..\..\example.rtf"
                Dim pdfPath As String = Path.ChangeExtension(rtfPath, ".pdf")

                ' 1. Get RTF content from file
                Dim rtfString As String = File.ReadAllText(rtfPath)

                ' 2. Convert RTF string to a PDF file
                If p.RtfToPdfConvertStringToFile(rtfString, pdfPath) = 0 Then
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("An error occurred during converting RTF to PDF!")
                End If
            End If
        End Sub
    End Class
End Namespace
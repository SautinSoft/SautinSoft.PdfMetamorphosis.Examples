Imports System.IO

Namespace Sample
    Friend Class Test
        Shared Sub Main(ByVal args() As String)
			' Activate your license here
			' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")

            Dim p As New SautinSoft.PdfMetamorphosis()

            If p IsNot Nothing Then
                Dim textPath As String = "..\..\..\example.txt"
                Dim pdfPath As String = Path.ChangeExtension(textPath, ".pdf")
                Dim textString As String = File.ReadAllText(textPath)

                ' 2. Convert Text to PDF in memory                
                Dim pdfBytes() As Byte = p.TextToPdfConvertStringToByte(textString)

                If pdfBytes IsNot Nothing Then

                    '3. Save the PDF document to a file for a viewing purpose.
                    File.WriteAllBytes(pdfPath, pdfBytes)
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("An error occurred during converting Text to PDF!")
                End If
            End If
        End Sub
    End Class
End Namespace
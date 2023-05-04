
Namespace Sample
    Friend Class Test
        Shared Sub Main(ByVal args() As String)

            ' How to set a single font for the whole PDF document.
				' Activate your license here
				' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")

            Dim p As New SautinSoft.PdfMetamorphosis()

            ' Let's make that the all text in PDF became in 'Comic Sans MS' font
            p.TextSettings.FontFace.Custom("Comic Sans MS")

            ' Set also a single font size 10
            p.TextSettings.FontSize = 10

            ' Set also single text color
            p.TextSettings.FontColor = System.Drawing.Color.FromArgb(33, 150, 33)

            If p IsNot Nothing Then
                Dim rtfPath As String = "..\..\example.rtf"
                Dim pdfPath As String = "..\..\test.pdf"

                Dim i As Integer = p.RtfToPdfConvertFile(rtfPath, pdfPath)

                If i <> 0 Then
                    System.Console.WriteLine("An error occurred during converting RTF to PDF!")
                Else
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                End If
            End If
        End Sub
    End Class
End Namespace
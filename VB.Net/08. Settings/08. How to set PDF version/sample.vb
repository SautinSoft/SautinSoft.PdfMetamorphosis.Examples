
Namespace Sample
    Friend Class Test
        Shared Sub Main(ByVal args() As String)

            ' How to set a version for the PDF document.
			' Before starting, we recommend to get a free key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfMetamorphosis.SetLicense("...");


            Dim p As New SautinSoft.PdfMetamorphosis()

            ' PDF Metamorphosis .Net generates PDF 1.4 document by default.
            ' Let's change the PDF version to PDF_A.
            p.PdfSettings.PdfVersion = SautinSoft.PdfMetamorphosis.PdfSetting.PdfVersions.PDF_A1a

            If p IsNot Nothing Then
                Dim rtfPath As String = "..\..\..\example.rtf"
                Dim pdfPath As String = "..\..\..\test.pdf"

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
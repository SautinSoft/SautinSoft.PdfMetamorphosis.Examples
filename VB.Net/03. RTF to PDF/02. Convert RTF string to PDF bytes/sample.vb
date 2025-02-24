Imports System.IO

Namespace Sample
    Friend Class Test
        Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfMetamorphosis.SetLicense("...");


            Dim p As New SautinSoft.PdfMetamorphosis()

            ' Specify some options.
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape

            ' Specify page numbers.
            p.PageSettings.Numbering.Text = "Page {page} of {numpages}"

            If p IsNot Nothing Then
                Dim rtfPath As String = "..\..\..\example.rtf"
                Dim pdfPath As String = Path.ChangeExtension(rtfPath, ".pdf")
                Dim rtfBytes() As Byte = File.ReadAllBytes(rtfPath)

                '2. Converting RTF to PDF
                Dim pdfBytes() As Byte = p.RtfToPdfConvertByte(rtfBytes)

                If pdfBytes IsNot Nothing Then

                    '3. Save the PDF document to a file for a viewing purpose.
                    File.WriteAllBytes(pdfPath, pdfBytes)
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("An error occurred during converting RTF to PDF!")
                End If
            End If
        End Sub
    End Class
End Namespace
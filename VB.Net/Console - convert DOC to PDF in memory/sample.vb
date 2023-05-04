Imports System
Imports System.IO

Namespace Sample
    Friend Class Test

        Shared Sub Main(ByVal args() As String)
		' Activate your license here
		' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")

            Dim p As New SautinSoft.PdfMetamorphosis()

            If p IsNot Nothing Then
                Dim docPath As String = "..\..\example.doc"
                Dim pdfPath As String = Path.ChangeExtension(docPath, ".pdf")
                Dim doc() As Byte = File.ReadAllBytes(docPath)

                ' 2. Convert DOC to PDF in memory                
                Dim pdf() As Byte = p.DocToPdfConvertByte(doc)

                If pdf IsNot Nothing Then
                    ' 3. Save the PDF document to a file for a viewing purpose.
                    File.WriteAllBytes(pdfPath, pdf)
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("Conversion failed!")
                    Console.ReadLine()
                End If
            End If
        End Sub
    End Class
End Namespace
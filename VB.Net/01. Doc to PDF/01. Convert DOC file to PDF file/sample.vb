Imports System
Imports System.IO

Namespace Sample
    Friend Class Test

        Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free 100-day key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfMetamorphosis.SetLicense("...");

            Dim p As New SautinSoft.PdfMetamorphosis()

            If p IsNot Nothing Then
                Dim docPath As String = "..\..\..\example.doc"
                Dim pdfPath As String = Path.ChangeExtension(docPath, ".pdf")

                ' 2. Convert DOC file to PDF file
                If p.DocToPdfConvertFile(docPath, pdfPath) = 0 Then
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("Conversion failed!")
                    Console.ReadLine()
                End If
            End If
        End Sub
    End Class
End Namespace
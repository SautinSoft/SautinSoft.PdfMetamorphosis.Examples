Imports System
Imports System.IO

Namespace Sample
    Friend Class Test

        Shared Sub Main(ByVal args() As String)
		' Activate your license here
		' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")

            Dim p As New SautinSoft.PdfMetamorphosis()

            If p IsNot Nothing Then
                Dim docxPath As String = "..\..\..\example.docx"
                Dim pdfPath As String = Path.ChangeExtension(docxPath, ".pdf")

                ' 2. Convert DOCX file to PDF file
                If p.DocxToPdfConvertFile(docxPath, pdfPath) = 0 Then
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("Conversion failed!")
                    Console.ReadLine()
                End If
            End If
        End Sub
    End Class
End Namespace
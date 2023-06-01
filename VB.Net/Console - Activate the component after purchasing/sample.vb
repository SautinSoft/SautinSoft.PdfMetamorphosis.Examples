Imports System
Imports System.IO
Imports System.Collections

Namespace Sample
    Friend Class Test

        Shared Sub Main(ByVal args() As String)
            ' Activation of PDF Metamorphosis .Net after purchasing
			  SautinSoft.PdfMetamorphosis.SetLicense("1234567890")
			
			' Place your serial(s) number.
            ' You will get own serial number(s) after purchasing the license.
            ' If you will have any questions, email us to sales@sautinsoft.com or ask at online chat https://www.sautinsoft.com.
			
            Dim p As New SautinSoft.PdfMetamorphosis()

            Dim docxPath As String = "..\..\..\example.docx"
            Dim pdfPath As String = Path.ChangeExtension(docxPath, ".pdf")
            If p.DocxToPdfConvertFile(docxPath, pdfPath) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
            End If
        End Sub
    End Class
End Namespace

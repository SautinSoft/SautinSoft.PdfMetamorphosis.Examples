Imports System.IO

Namespace Sample
	Friend Class Test

		Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfMetamorphosis.SetLicense("...");


			Dim p As New SautinSoft.PdfMetamorphosis()

			' Specify the owner password for the encrypted PDF document.
			p.PdfSettings.PdfSecurity.OwnerPassword = "1234567890"

			' Specify the user's password required to open the encrypted PDF document.
			p.PdfSettings.PdfSecurity.UserPassword = "0987654321"

			If p IsNot Nothing Then
				Dim rtfPath As String = "..\..\..\example.rtf"
				Dim pdfPath As String = Path.ChangeExtension(rtfPath, ".pdf")

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

Option Infer On

Imports System
Imports System.IO
Imports System.Collections

Namespace Sample
	Friend Class Test

		Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free key:
			' https://sautinsoft.com/start-for-free/

			' Apply the key here:
			' SautinSoft.PdfMetamorphosis.SetLicense("...");

			Dim p As New SautinSoft.PdfMetamorphosis()

			If p IsNot Nothing Then
				Dim txtPath As String = "..\..\..\example.txt"
				Dim pdfPath As String = Path.ChangeExtension(txtPath, ".pdf")
				Dim txt As New MemoryStream(File.ReadAllBytes(txtPath))

				' 3. Convert TEXT to PDF in stream                
				Dim pdf As Stream = p.TextToPdfConvertStream(txt)

				If pdf IsNot Nothing Then
					pdf.Position = 0
					Dim ms = New MemoryStream()
					pdf.CopyTo(ms)
					ms.Position = 0
					' 3. Save the PDF document to a file for a viewing purpose.
					File.WriteAllBytes(pdfPath, ms.ToArray())
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
				Else
					System.Console.WriteLine("Conversion failed!")
					Console.ReadLine()
				End If
			End If
		End Sub
	End Class
End Namespace

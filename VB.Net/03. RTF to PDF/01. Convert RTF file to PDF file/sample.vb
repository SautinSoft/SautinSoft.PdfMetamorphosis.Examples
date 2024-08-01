Imports System
Imports System.IO
Imports System.Collections

Namespace Sample

	Friend Class Test

		Shared Sub Main(ByVal args() As String)
			' Before starting, we recommend to get a free 100-day key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfMetamorphosis.SetLicense("...");


			Dim p As New SautinSoft.PdfMetamorphosis()

			' Specify some page options.
			p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape

			' Set page header in HTML format.
			p.PageSettings.Header.FromString("<b style=""color: green;"">Sample header in HTML format</b>", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html)

			' Set page footer in RTF format.
			p.PageSettings.Footer.FromString("{\rtf1 \b Bold Footer in RTF format}", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Rtf)

			' Set page numbers.
			p.PageSettings.Numbering.Text = "Page {page} of {numpages}"

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

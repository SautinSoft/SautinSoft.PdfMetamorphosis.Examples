
Namespace Sample
    Friend Class Test

        Shared Sub Main(ByVal args() As String)
			Dim p As New SautinSoft.PdfMetamorphosis()

            'After purchasing the license, please insert your serial number here to activate the component
            'p.Serial = "XXXXXXXXXXX"

            'specify some options
            p.PageSettings.Size.A4()
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape

            p.PageSettings.Numbering.Text = "Page {page} of {numpages}"

            If p IsNot Nothing Then
                Dim inputFile As String = "..\..\example.htm"
                Dim outputFile As String = "..\..\test.pdf"

                Dim result As Integer = p.HtmlToPdfConvertFile(inputFile, outputFile)

                If result = 0 Then
                    System.Console.WriteLine("Converted successfully!")
					System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outputFile) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("Converting Error!")
                End If
            End If
        End Sub
    End Class
End Namespace
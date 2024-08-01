
Module sample

    Sub Main()

        'How to add page header and footer
			' Before starting, we recommend to get a free 100-day key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfMetamorphosis.SetLicense("...");


        Dim p As New SautinSoft.PdfMetamorphosis()

        'Let's add page header in HTML format
        Dim headerInHtml As String = "<table width=\"100%\" border=\"0\" style=\"border-collapse: collapse\"><tr><td style=\"border: 1pt solid black\" ></td><td width=\"50%\" align=\"center\" style=\"border: 1pt solid black\">You are welcome!</td></tr></table>"
		p.PageSettings.Header.FromString(headerInHtml, SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html)

        Dim footerInRtf As String = "{\rtf1\i Italic Footer}"
        p.PageSettings.Footer.FromString(footerInRtf, SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Rtf)

        If p IsNot Nothing Then
            Dim inputFile As String = "..\..\..\example.htm"
            Dim outputFile As String = "..\..\..\test.pdf"

            Dim result As Integer = p.HtmlToPdfConvertFile(inputFile, outputFile)

            If result = 0 Then
                System.Console.WriteLine("Converted successfully!")
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outputFile) With {.UseShellExecute = True})
            Else
                System.Console.WriteLine("Converting Error!")
            End If
        End If
    End Sub
End Module
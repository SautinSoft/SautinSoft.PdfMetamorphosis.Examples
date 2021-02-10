
Module sample

    Sub Main()

        'How to add page header and footer
        Dim p As New SautinSoft.PdfMetamorphosis()

        'After purchasing the license, please insert your serial number here to activate the component
        'p.Serial = "XXXXXXXXXXX"

        'Let's add page header in HTML format
        Dim headerInHtml As String = "<table width=""100%"" border=""1""><tr><td width=""50%"" align=""center""></td><td>You are welcome!</td></tr></table>"
        p.PageSettings.Header.FromString(headerInHtml, SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html)

        Dim footerInRtf As String = "{\rtf1\i Italic Header}"
        p.PageSettings.Footer.FromString(footerInRtf, SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Rtf)

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
End Module
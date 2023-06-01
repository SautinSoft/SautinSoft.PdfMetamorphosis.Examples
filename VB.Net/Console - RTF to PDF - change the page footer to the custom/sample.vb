
Module sample

    Sub Main()

        'How to change the page footer to the custom footer
				' Activate your license here
				' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")

        Dim p As New SautinSoft.PdfMetamorphosis()

        If p IsNot Nothing Then
            Dim inputFile As String = "..\..\..\example.rtf"
            Dim originalPdf As String = "..\..\..\Original.pdf"
            Dim customPdf As String = "..\..\..\CustomFooter.pdf"

            'Let's convert RTF which has a page footer to PDF
            If p.RtfToPdfConvertFile(inputFile, originalPdf) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(originalPdf) With {.UseShellExecute = True})
            End If

            'Let's change footer to the custom
            Dim footerInHtml As String = "<table width=""100%"" border=""1""><tr><td width=""50%""></td><td>This is new custom footer!</td></tr></table>"
            p.PageSettings.Footer.FromString(footerInHtml, SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html)

            'Let's convert RTF which has a page footer to PDF
            If p.RtfToPdfConvertFile(inputFile, customPdf) = 0 Then
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(customPdf) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
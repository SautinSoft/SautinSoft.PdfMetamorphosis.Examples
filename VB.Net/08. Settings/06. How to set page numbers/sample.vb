
Module sample

    Sub Main()

        ' This sample shows how to specify page numbers
			' Before starting, we recommend to get a free 100-day key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfMetamorphosis.SetLicense("...");


        Dim p As New SautinSoft.PdfMetamorphosis()

        'Page 1 of N, position: 30 mm from the left of the page
        p.PageSettings.Numbering.Text = "Page {page} of {numpages}"
        p.PageSettings.Numbering.PosX.Mm = 30
        p.PageSettings.Numbering.PosY.Mm = 10
        p.PageSettings.Numbering.FontFace = "Courier New"
        p.PageSettings.Numbering.FontSize = 22

        ' This is page number N
        'p.PageSettings.Numbering.Text = "This is page number {page}"

        If p IsNot Nothing Then
            Dim rtfPath As String = "..\..\..\example.rtf"
            Dim pdfPath As String = "..\..\..\test.pdf"

            Dim i As Integer = p.RtfToPdfConvertFile(rtfPath, pdfPath)

            If i <> 0 Then
                System.Console.WriteLine("An error occurred during converting RTF to PDF!")
            Else
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
            End If
        End If
    End Sub
End Module
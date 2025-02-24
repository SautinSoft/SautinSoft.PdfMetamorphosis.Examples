
Module sample

    Sub Main()

        'How to set page size, orientation and margins
			' Before starting, we recommend to get a free key:
            ' https://sautinsoft.com/start-for-free/
            
            ' Apply the key here:
			' SautinSoft.PdfMetamorphosis.SetLicense("...");


        Dim p As New SautinSoft.PdfMetamorphosis()

        'Let's set: A3, Landscape orientation, left and right margins: 1.5 Inch, top and bottom: 1 Inch
        p.PageSettings.Size.A3()
        p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape
        p.PageSettings.MarginLeft.Inch(1.5F)
        p.PageSettings.MarginRight.Inch(1.5F)
        p.PageSettings.MarginTop.Inch(1.0F)
        p.PageSettings.MarginBottom.Inch(1.0F)

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
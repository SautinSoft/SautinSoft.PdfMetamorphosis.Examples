
Module sample

    Sub Main()
				' Activate your license here
				' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")

        Dim p As New SautinSoft.PdfMetamorphosis()

        Dim w1 As New SautinSoft.PdfMetamorphosis.WaterMark("..\..\..\WaterMark.png")

        w1.PosX.Mm = 0
        w1.PosX.Mm = 0
        w1.PosDX.Mm = 50
        w1.PosDY.Mm = 50

        p.WaterMarks.Add(w1)


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
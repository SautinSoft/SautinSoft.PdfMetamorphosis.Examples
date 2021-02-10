Imports System
Imports System.IO

Namespace Sample
    Friend Class Test
        Shared Sub Main(ByVal args() As String)
            Dim p As New SautinSoft.PdfMetamorphosis()

            ' After purchasing the license, please insert your serial number here to activate the component.
            'p.Serial = "XXXXXXXXXXX"

            ' Let's set: A4, Landscape orientation, left and right margins: 1.5 Inch, top and bottom: 1 Inch
            p.PageSettings.Size.A4()
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape
            p.PageSettings.MarginLeft.Inch(1.5F)
            p.PageSettings.MarginRight.Inch(1.5F)
            p.PageSettings.MarginTop.Inch(1.0F)
            p.PageSettings.MarginBottom.Inch(1.0F)

            If p IsNot Nothing Then
                Dim textPath As String = "..\..\example.txt"
                Dim pdfPath As String = Path.ChangeExtension(textPath, ".pdf")

                If p.TextToPdfConvertFile(textPath, pdfPath) = 0 Then
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("An error occurred during converting Text to PDF!")
                    Console.ReadLine()
                End If
            End If
        End Sub
    End Class
End Namespace
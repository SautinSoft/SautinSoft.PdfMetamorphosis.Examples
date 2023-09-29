
Partial Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Result.Text = ""
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Activate your license here
		' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")
		
        Dim p As New SautinSoft.PdfMetamorphosis()

        Dim pdfs As New ArrayList()
        Dim files As Integer = 0

        If FileUpload1.FileBytes.Length > 0 Then
            pdfs.Add(FileUpload1.FileBytes)
            files += 1
        End If
        If FileUpload2.FileBytes.Length > 0 Then
            pdfs.Add(FileUpload2.FileBytes)
            files += 1
        End If
        If FileUpload3.FileBytes.Length > 0 Then
            pdfs.Add(FileUpload3.FileBytes)
            files += 1
        End If

        If files < 2 Then
            Result.Text = "Error! Before merging please select at least two PDF documents!"
            Return
        End If

        Dim pdfBytes() As Byte = Nothing

        'merge
        pdfBytes = p.MergePDFStreamArrayToPDFStream(pdfs)

        'show PDF
        If pdfBytes IsNot Nothing Then
            Response.Buffer = True
            Response.Clear()
            Response.ContentType = "application/PDF"
            Response.AppendHeader("content-disposition", "attachment; filename=single.pdf")
            Response.BinaryWrite(pdfBytes)
            Response.Flush()
            Response.End()
        Else
            Result.Text = "Error in merging these PDF files, email to support@sautinsoft.com!"
        End If
    End Sub
End Class
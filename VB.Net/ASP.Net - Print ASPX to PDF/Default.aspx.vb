Imports System.IO

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        'Create a simple ASP.Net page with table inside
        If Not Page.IsPostBack Then

            'Create a simple ASP.Net table
            Dim table_Renamed As New Table()
			table_Renamed.Style.Add("border-collapse", "collapse")
            Dim row As TableRow = Nothing
            Dim cell As TableCell = Nothing

            Dim rows As Integer = 5
            Dim cells As Integer = 5
            For x As Integer = 0 To rows - 1
                row = New TableRow()
                For y As Integer = 0 To cells - 1
                    cell = New TableCell()
                    cell.Width = Unit.Pixel(100)
                    cell.BorderColor = System.Drawing.ColorTranslator.FromHtml("darkgreen")
                    cell.BorderWidth = Unit.Pixel(2)
                    cell.Font.Name = "Helvetica"
                    cell.Font.Size = FontUnit.Point(10)
                    cell.HorizontalAlign = HorizontalAlign.Center

                    cell.Text = "Row " & (CInt(Fix(x + 1))).ToString() & ", Cell " & (CInt(Fix(y + 1))).ToString()
                    row.Cells.Add(cell)
                Next y
                table_Renamed.Rows.Add(row)
            Next x

            'Add table to page
            Panel1.Controls.Add(table_Renamed)
        End If
    End Sub
    'Get HTML from ASPX
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

        ' setup a TextWriter to capture the markup
        Dim tw As TextWriter = New StringWriter()
        Dim htw As New HtmlTextWriter(tw)

        ' render the markup into our surrogate TextWriter
        MyBase.Render(htw)

        ' get the captured markup as a string
        Dim currentPage As String = tw.ToString()

        'Save HTML code to temporary file 
        If Not Page.IsPostBack Then
            File.WriteAllText(Path.Combine(Server.MapPath("Temp"), "temp.htm"), currentPage, Encoding.UTF8)
        End If

        ' render the markup into the output stream verbatim
        writer.Write(currentPage)
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)

        'Get HTML from temporary file which we've created in the overridden method Render()
        Dim html As String = File.ReadAllText(Path.Combine(Server.MapPath("Temp"), "temp.htm"), Encoding.UTF8)

        Dim url As String = System.Web.HttpContext.Current.Request.Url.AbsoluteUri

        If html.Length > 0 Then
				' Activate your license here
				' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")
            Dim p As New SautinSoft.PdfMetamorphosis()

            p.HtmlSettings.BaseUrl = url

            Dim pdf() As Byte = p.HtmlToPdfConvertStringToByte(html)

            'show PDF
            If pdf IsNot Nothing Then
                Response.Buffer = True
                Response.Clear()
                Response.ContentType = "application/PDF"
                Response.AddHeader("content-disposition", "attachment; filename=Result.pdf")
                Response.BinaryWrite(pdf)
                Response.Flush()
                Response.End()
            End If
        End If
    End Sub
End Class

Imports System.IO
Imports System.Net

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Result.Text = ""
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim p As New SautinSoft.PdfMetamorphosis()

        ' After purchasing the license, please insert your serial number here to activate the component
        'p.Serial = "XXXXXXXXXXX"

        ' Let's set page numbers
        p.PageSettings.Numbering.Text = "Page {page} of {numpages}"

        ' Set page header within HTML string
        p.PageSettings.Header.FromString("<table border=""1""><tr><td>We added this header using the property ""Header.Html""</td></tr></table>", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html)

        ' Add page footer from HTML file
        p.PageSettings.Footer.FromFile(Path.Combine(Server.MapPath(""), "footer.htm"), SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html)

        ' Get content of the ASPX page as HTML document
        Dim htmlString As String = GetHtmlFromAspx(Path.Combine(Server.MapPath(""), "Default.aspx"))

        p.HtmlSettings.BaseUrl = Server.MapPath("")

        Dim pdfBytes() As Byte = p.HtmlToPdfConvertStringToByte(htmlString)

        'show PDF
        If pdfBytes IsNot Nothing Then
            Response.Buffer = True
            Response.Clear()
            Response.ContentType = "application/PDF"
            Response.BinaryWrite(pdfBytes)
            Response.Flush()
            Response.End()
        Else
            Result.Text = "Converting failed!"
        End If
    End Sub
    Public Shared Function GetHtmlFromAspx(ByVal url As String) As String
        Dim contents As String = ""

        If url.Length > 6 Then
            'open 'http://' file
            If (url.Chars(0) = "h"c OrElse url.Chars(0) = "H"c) AndAlso (url.Chars(1) = "t"c OrElse url.Chars(1) = "T"c) AndAlso (url.Chars(2) = "t"c OrElse url.Chars(2) = "T"c) AndAlso (url.Chars(3) = "p"c OrElse url.Chars(3) = "P"c) AndAlso url.Chars(4) = ":"c AndAlso url.Chars(5) = "/"c AndAlso url.Chars(6) = "/"c Then

                Dim StreamHttp As Stream = Nothing
                Dim resp As WebResponse = Nothing
                Dim webrequest As HttpWebRequest = Nothing
                Try
                    webrequest = CType(webrequest.Create(url), HttpWebRequest)
                    resp = webrequest.GetResponse()
                    StreamHttp = resp.GetResponseStream()
                    Dim sr As New StreamReader(StreamHttp)
                    contents = sr.ReadToEnd()
                    Return contents
                Catch
                End Try

                'local file
            Else
                Try
                    Dim sr As New StreamReader(url)
                    contents = sr.ReadToEnd()
                    sr.Close()
                Catch
                End Try
            End If
        End If
        Return contents
    End Function
End Class

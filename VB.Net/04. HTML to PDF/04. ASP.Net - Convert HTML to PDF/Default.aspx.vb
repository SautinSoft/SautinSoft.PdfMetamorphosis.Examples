Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Net

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		
	End Sub

	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		
		' Activate your license here
		' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")
		Dim p As New SautinSoft.PdfMetamorphosis()

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
			
		End If
	End Sub
	Public Shared Function GetHtmlFromAspx(ByVal url As String) As String
		Dim contents As String = ""
		Dim urlpage As String = HttpContext.Current.Request.Url.AbsoluteUri


		Dim StreamHttp As Stream = Nothing
		Dim resp As WebResponse = Nothing
		Dim webrequest As HttpWebRequest = Nothing

			webrequest = CType(WebRequest.Create(urlpage), HttpWebRequest)
			webrequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.1.4322)"
			resp = webrequest.GetResponse()
			StreamHttp = resp.GetResponseStream()
			Dim sr As New StreamReader(StreamHttp)
			contents = sr.ReadToEnd()
			Return contents

	End Function
End Class

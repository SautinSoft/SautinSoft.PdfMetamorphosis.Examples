using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Result.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();
        
		// After purchasing the license, please insert your serial number here to activate the component
        //p.Serial = "XXXXXXXXXXX";

        // Let's set page numbers
        p.PageSettings.Numbering.Text = "Page {page} of {numpages}";

        // Set page header within HTML string
        p.PageSettings.Header.FromString("<table border=\"1\"><tr><td>We added this header using the property \"Header.Html\"</td></tr></table>", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html);

        // Add page footer from HTML file
        p.PageSettings.Footer.FromFile(Path.Combine(Server.MapPath(""), @"footer.htm"), SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html);

        // Get content of the ASPX page as HTML document
        string htmlString = GetHtmlFromAspx(Path.Combine(Server.MapPath(""), @"Default.aspx"));

        p.HtmlSettings.BaseUrl = Server.MapPath("");        

        byte[] pdfBytes = p.HtmlToPdfConvertStringToByte(htmlString);

        //show PDF
        if (pdfBytes != null)
        {
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/PDF";
            Response.BinaryWrite(pdfBytes);
            Response.Flush();
            Response.End();
        }
        else
        {
            Result.Text = "Converting failed!";
        }
    }
    public static string GetHtmlFromAspx(string url)
    {
        string contents = "";

        if (url.Length > 6)
        {
            //open 'http://' file
            if ((url[0] == 'h' || url[0] == 'H') && (url[1] == 't' || url[1] == 'T') &&
                (url[2] == 't' || url[2] == 'T') && (url[3] == 'p' || url[3] == 'P') &&
                url[4] == ':' && url[5] == '/' && url[6] == '/')
            {

                Stream StreamHttp = null;
                WebResponse resp = null;
                HttpWebRequest webrequest = null;
                try
                {
                    webrequest = (HttpWebRequest)WebRequest.Create(url);
					webrequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.1.4322)";
                    resp = webrequest.GetResponse();
                    StreamHttp = resp.GetResponseStream();
                    StreamReader sr = new StreamReader(StreamHttp);
                    contents = sr.ReadToEnd();
                    return contents;
                }
                catch
                {
                }
            }

            //local file
            else
            {
                try
                {
                    StreamReader sr = new StreamReader(url);
                    contents = sr.ReadToEnd();
                    sr.Close();
                }
                catch
                {
                }
            }
        }
        return contents;
    }
}

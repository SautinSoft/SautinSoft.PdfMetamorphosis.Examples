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
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Create a simple ASP.Net page with table inside

        if (!Page.IsPostBack)
        {
            //Create a simple ASP.Net table
            Table table = new Table();
            table.Style.Add("border-collapse", "collapse");
            TableRow row = null;
            TableCell cell = null;

            int rows = 5;
            int cells = 5;
            for (int x = 0; x < rows; x++)
            {
                row = new TableRow();
                for (int y = 0; y < cells; y++)
                {
                    cell = new TableCell();
                    cell.Width = Unit.Pixel(100);
                    cell.BorderColor = System.Drawing.ColorTranslator.FromHtml("darkgreen");
                    cell.BorderWidth = Unit.Pixel(2);
                    cell.Font.Name = "Helvetica";
                    cell.Font.Size = FontUnit.Point(10);
                    cell.HorizontalAlign = HorizontalAlign.Center;

                    cell.Text = "Row " + ((int)(x + 1)).ToString() + ", Cell " + ((int)(y + 1)).ToString();
                    row.Cells.Add(cell);
                }
                table.Rows.Add(row);
            }

            //Add table to page
            Panel1.Controls.Add(table);
        }
    }

    //Get HTML from ASPX
    protected override void Render(HtmlTextWriter writer)
    {
        // setup a TextWriter to capture the markup
        TextWriter tw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(tw);

        // render the markup into our surrogate TextWriter
        base.Render(htw);

        // get the captured markup as a string
        string currentPage = tw.ToString();
        
        //Save HTML code to temporary file 
        if (!Page.IsPostBack)
            File.WriteAllText(Path.Combine(Server.MapPath("Temp"), "temp.htm"), currentPage, Encoding.UTF8);

        // render the markup into the output stream verbatim
        writer.Write(currentPage);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Get HTML from temporary file which we've created in the overridden method Render()
        string html = File.ReadAllText(Path.Combine(Server.MapPath("Temp"), "temp.htm"), Encoding.UTF8);

        string url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;

        if (html.Length > 0)
        {
			// Activate your license here
			// SautinSoft.PdfMetamorphosis.SetLicense("1234567890");
			
            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            p.HtmlSettings.BaseUrl = url;

            byte[] pdf = p.HtmlToPdfConvertStringToByte(html);

            //show PDF
            if (pdf != null)
            {
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = "application/PDF";
                Response.AddHeader("content-disposition", "attachment; filename=Result.pdf");
                Response.BinaryWrite(pdf);
                Response.Flush();
                Response.End();
            }

        }
    }
}

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
using System.Collections;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Result.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

		//After purchasing the license, please insert your serial number here to activate the component
        //p.Serial = "XXXXXXXXXXX";

        ArrayList pdfs = new ArrayList();
        int files = 0;

        if (FileUpload1.FileBytes.Length > 0)
        {
            pdfs.Add(FileUpload1.FileBytes);
            files++;
        }
        if (FileUpload2.FileBytes.Length > 0)
        {
            pdfs.Add(FileUpload2.FileBytes);
            files++;
        }
        if (FileUpload3.FileBytes.Length > 0)
        {
            pdfs.Add(FileUpload3.FileBytes);
            files++;
        }

        if (files < 2)
        {
            Result.Text = "Error! Before merging please select at least two PDF documents!";
            return;
        }

        byte[] pdfBytes = null;
        
        //merge
        pdfBytes = p.MergePDFStreamArrayToPDFStream(pdfs);

        //show PDF
        if (pdfBytes != null)
        {
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/PDF";
            Response.AppendHeader("content-disposition", "attachment; filename=single.pdf");
            Response.BinaryWrite(pdfBytes);
            Response.Flush();
            Response.End();
        }
        else
        {
            Result.Text = "Error in merging these PDF files, email to support@sautinsoft.com!";
        }
    }
}

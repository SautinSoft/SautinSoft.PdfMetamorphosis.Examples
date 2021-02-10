using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace SampleWinForms
{
    public class Form1 : System.Windows.Forms.Form
    {
        private Button buttonConvert;
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(96, 101);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(93, 63);
            this.buttonConvert.TabIndex = 0;
            this.buttonConvert.Text = "Go";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.buttonConvert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }
        #endregion

        static void Main()
        {
            Application.Run(new Form1());
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            // After purchasing the license, please insert your serial number here to activate the component
            //p.Serial = "XXXXXXXXXXX";

            // Specify some page options
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape;

            // Set page header in HTML format
            p.PageSettings.Header.FromString("<b>Sample header in HTML format</b>", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html);

            // Set page footer in RTF format
            p.PageSettings.Footer.FromString(@"{\rtf1\b Bold footer}", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Rtf);

            // Set page numbers
            p.PageSettings.Numbering.Text = "Page {page} of {numpages}";

            if (p != null)
            {
                string rtfPath = @"..\..\example.rtf";
                string pdfPath = @"..\..\test.pdf";

                //1. Get RTF content from file
                string rtfString = File.ReadAllText(rtfPath);

                //2. Convert RTF to PDF bytes
                byte[] pdfBytes = p.RtfToPdfConvertStringToByte(rtfString);

                if (pdfBytes != null)
                {
                    //3. Save pdfBytes to PDF file
                    File.WriteAllBytes(pdfPath, pdfBytes);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
                }
                else
                {
                    System.Console.WriteLine("An error occurred during converting RTF to PDF!");
                    Console.ReadLine();
                }
            }

        }
    }
}

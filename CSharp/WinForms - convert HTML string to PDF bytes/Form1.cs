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
			// Activate your license here
			// SautinSoft.PdfMetamorphosis.SetLicense("1234567890");

            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            if (p != null)
            {
                string htmlPath = @"..\..\example.htm";
                string pdfPath = @"..\..\test.pdf";
                string htmlString = "";

                // The easiest way is using the method 'HtmlToPdfConvertFile':
                // int ret = p.HtmlToPdfConvertFile(htmlPath,pdfPath);
                // or :
                //1. Get HTML content
                htmlString = ReadFromFile(htmlPath);

                //2. Converting HTML to PDF
                //specify BaseUrl to help converter find a full path for relative images, CSS
                p.HtmlSettings.BaseUrl = Path.GetDirectoryName(Path.GetFullPath(htmlPath));
                byte[] pdfBytes = p.HtmlToPdfConvertStringToByte(htmlString);

                if (pdfBytes != null)
                {
                    //3. Save pdfBytes to PDF file
                    File.WriteAllBytes(pdfPath, pdfBytes);
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
                }
                else
                {
                    MessageBox.Show("An error occurred during converting HTML to PDF!");
                }
            }
        }
        public static string ReadFromFile(string fileName)
        {
            try
            {
                FileInfo fi = new FileInfo(fileName);
                FileStream strmRead = fi.Open(FileMode.Open);
                int len = (int)fi.Length;
                byte[] b = new byte[len];
                strmRead.Read(b, 0, len);
                strmRead.Close();
                char[] arCharRes = new char[len];
                for (int i = 0; i < len; i++)
                {
                    arCharRes[i] = (char)b[i];
                }
                return new string(arCharRes);
            }
            catch
            {
                return "";
            }
        }
    }
}

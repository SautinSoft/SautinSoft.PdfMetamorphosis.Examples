Imports System.Windows.Forms
Imports System.IO

Namespace SampleWinForms
    Public Class Form1
        Inherits System.Windows.Forms.Form
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.Button1 = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(105, 109)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(75, 47)
            Me.Button1.TabIndex = 0
            Me.Button1.Text = "Go"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'Form1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(284, 264)
            Me.Controls.Add(Me.Button1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)

        End Sub
#End Region

        Shared Sub Main()
            Application.Run(New Form1())
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
			' Activate your license here
			' SautinSoft.PdfMetamorphosis.SetLicense("1234567890")

            Dim p As New SautinSoft.PdfMetamorphosis()

            'specify some options
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Landscape

            'specify header in HTML format
            p.PageSettings.Header.FromString("<b>Sample header in HTML format</b>", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Html)

            'specify footer in RTF format
            p.PageSettings.Footer.FromString("{\rtf1\b Bold footer}", SautinSoft.PdfMetamorphosis.HeadersFooters.InputFormat.Rtf)

            'specify page numbers
            p.PageSettings.Numbering.Text = "Page {page} of {numpages}"

            If p IsNot Nothing Then
                Dim rtfPath As String = "..\..\example.rtf"
                Dim pdfPath As String = "..\..\test.pdf"

                '1. Get RTF content from file
                Dim rtfString As String = File.ReadAllText(rtfPath)

                '2. Converting RTF to PDF
                Dim pdf() As Byte = p.RtfToPdfConvertStringToByte(rtfString)

                If pdf IsNot Nothing Then

                    '3. Save to PDF file
                    Dim fs As New FileStream(pdfPath, FileMode.Create, FileAccess.Write)
                    fs.Write(pdf, 0, pdf.Length)
                    fs.Close()
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                Else
                    System.Console.WriteLine("An error occurred during converting RTF to PDF!")
                End If
            End If
        End Sub
    End Class
End Namespace

Imports System.Windows.Forms
Imports System.IO

Namespace SampleWinForms
    Public Class Form1
        Inherits System.Windows.Forms.Form
        Private WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
        Private WithEvents button1 As System.Windows.Forms.Button
        Private WithEvents button2 As System.Windows.Forms.Button
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
            Me.button2 = New System.Windows.Forms.Button
            Me.button1 = New System.Windows.Forms.Button
            Me.richTextBox1 = New System.Windows.Forms.RichTextBox
            Me.SuspendLayout()
            '
            'button2
            '
            Me.button2.Location = New System.Drawing.Point(174, 295)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(96, 23)
            Me.button2.TabIndex = 5
            Me.button2.Text = "Open RTF"
            Me.button2.UseVisualStyleBackColor = True
            '
            'button1
            '
            Me.button1.Location = New System.Drawing.Point(290, 295)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(96, 23)
            Me.button1.TabIndex = 4
            Me.button1.Text = "Generate PDF"
            '
            'richTextBox1
            '
            Me.richTextBox1.Location = New System.Drawing.Point(12, 12)
            Me.richTextBox1.Name = "richTextBox1"
            Me.richTextBox1.Size = New System.Drawing.Size(542, 277)
            Me.richTextBox1.TabIndex = 3
            Me.richTextBox1.Text = ""
            '
            'Form1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(566, 330)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.richTextBox1)
            Me.Name = "Form1"
            Me.Text = "How to generate PDF from RichTextBox"
            Me.ResumeLayout(False)

        End Sub
#End Region

        Shared Sub Main()
            Application.Run(New Form1())
        End Sub

        Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
            Dim openFileDialog1 As System.Windows.Forms.OpenFileDialog = New OpenFileDialog()
            openFileDialog1.Filter = "RTF documents (*.rtf)|*.rtf|All files (*.*)|*.*"
            openFileDialog1.FilterIndex = 0
            openFileDialog1.Title = "Select any RTF document:"
            openFileDialog1.Multiselect = False
            openFileDialog1.InitialDirectory = ""

            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                richTextBox1.Rtf = File.ReadAllText(openFileDialog1.FileName, System.Text.Encoding.UTF8)
            End If
        End Sub

        Private Sub button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
			Dim p As New SautinSoft.PdfMetamorphosis()

            If p IsNot Nothing Then
                Dim pdfPath As String = "..\..\test.pdf"

                '1. Get RTF content
                Dim rtfString As String = Me.richTextBox1.Rtf

                '2. Converting RTF to PDF
                Dim pdf() As Byte = p.RtfToPdfConvertStringToByte(rtfString)

                If pdf IsNot Nothing Then

                    '3. Save to PDF file
                    File.WriteAllBytes(pdfPath, pdf)
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                End If
            End If
        End Sub
    End Class
End Namespace

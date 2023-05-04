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

            If p IsNot Nothing Then
                Dim htmlPath As String = "..\..\example.htm"
                Dim pdfPath As String = "..\..\test.pdf"
                Dim htmlString As String = ""

                ' The easiest way is using the method 'HtmlToPdfConvertFile':
                ' int ret = p.HtmlToPdfConvertFile(htmlPath,pdfPath)
                ' or :
                '1. Get HTML content
                htmlString = ReadFromFile(htmlPath)

                '2. Converting HTML to PDF
                'specify BaseUrl to help converter find a full path for relative images, CSS
                p.HtmlSettings.BaseUrl = Path.GetDirectoryName(Path.GetFullPath(htmlPath))
                Dim pdfBytes() As Byte = p.HtmlToPdfConvertStringToByte(htmlString)

                If pdfBytes IsNot Nothing Then

                    '3. Save pdfBytes to PDF file
                    File.WriteAllBytes(pdfPath, pdfBytes)
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
                Else
                    MessageBox.Show("An error occurred during converting HTML to PDF!")
                End If
            End If
        End Sub
        Public Function ReadFromFile(ByVal fileName As String) As String
            Try
                Dim fi As New FileInfo(fileName)
                Dim strmRead As FileStream = fi.Open(FileMode.Open)
                Dim len As Integer = CInt(Microsoft.VisualBasic.Fix(fi.Length))
                Dim b(len - 1) As Byte
                strmRead.Read(b, 0, len)
                strmRead.Close()
                Dim arCharRes(len - 1) As Char
                For i As Integer = 0 To len - 1
                    arCharRes(i) = Microsoft.VisualBasic.ChrW(b(i))
                Next i
                Return New String(arCharRes)
            Catch
                Return ""
            End Try
        End Function
    End Class
End Namespace

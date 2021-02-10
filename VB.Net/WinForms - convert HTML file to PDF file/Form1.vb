Imports System.Windows.Forms

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
            Dim p As New SautinSoft.PdfMetamorphosis()

            ' After purchasing the license, please insert your serial number here to activate the component
            'p.Serial = "XXXXXXXXXXX"

            'specify some options
            p.PageSettings.Size.A4()
            p.PageSettings.Orientation = SautinSoft.PdfMetamorphosis.PageSetting.Orientations.Auto

            p.PageSettings.Numbering.Text = "Page {page} of {numpages}"

            If p IsNot Nothing Then
                Dim inputFile As String = "..\..\example.htm"
                Dim outputFile As String = "..\..\test.pdf"

                Dim result As Integer = p.HtmlToPdfConvertFile(inputFile, outputFile)

                If result = 0 Then
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outputFile) With {.UseShellExecute = True})
                Else
                    MessageBox.Show("Converting Error!")
                End If
            End If
        End Sub
    End Class
End Namespace

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTopScores
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TopTenName = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TopTenScore = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'TopTenName
        '
        Me.TopTenName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TopTenName.Enabled = False
        Me.TopTenName.FormattingEnabled = True
        Me.TopTenName.Location = New System.Drawing.Point(12, 54)
        Me.TopTenName.Name = "TopTenName"
        Me.TopTenName.Size = New System.Drawing.Size(161, 416)
        Me.TopTenName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(188, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Score"
        '
        'TopTenScore
        '
        Me.TopTenScore.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TopTenScore.Enabled = False
        Me.TopTenScore.FormattingEnabled = True
        Me.TopTenScore.Location = New System.Drawing.Point(172, 54)
        Me.TopTenScore.Name = "TopTenScore"
        Me.TopTenScore.Size = New System.Drawing.Size(67, 416)
        Me.TopTenScore.TabIndex = 3
        '
        'frmTopScores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(250, 486)
        Me.Controls.Add(Me.TopTenScore)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TopTenName)
        Me.Name = "frmTopScores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Top 10"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TopTenName As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TopTenScore As System.Windows.Forms.ListBox
End Class

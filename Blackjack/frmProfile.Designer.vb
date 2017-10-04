<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProfile
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
        Me.PlayerSelectorBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBank = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CreateProfile = New System.Windows.Forms.Button()
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PlayerSelectorBox
        '
        Me.PlayerSelectorBox.FormattingEnabled = True
        Me.PlayerSelectorBox.Location = New System.Drawing.Point(134, 43)
        Me.PlayerSelectorBox.Name = "PlayerSelectorBox"
        Me.PlayerSelectorBox.Size = New System.Drawing.Size(120, 21)
        Me.PlayerSelectorBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select your profile"
        '
        'txtBank
        '
        Me.txtBank.Location = New System.Drawing.Point(260, 43)
        Me.txtBank.Name = "txtBank"
        Me.txtBank.ReadOnly = True
        Me.txtBank.Size = New System.Drawing.Size(91, 20)
        Me.txtBank.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "New to the game? "
        '
        'CreateProfile
        '
        Me.CreateProfile.Location = New System.Drawing.Point(134, 94)
        Me.CreateProfile.Name = "CreateProfile"
        Me.CreateProfile.Size = New System.Drawing.Size(120, 23)
        Me.CreateProfile.TabIndex = 4
        Me.CreateProfile.Text = "Create your Profile"
        Me.CreateProfile.UseVisualStyleBackColor = True
        '
        'PlayButton
        '
        Me.PlayButton.Location = New System.Drawing.Point(134, 146)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(63, 53)
        Me.PlayButton.TabIndex = 5
        Me.PlayButton.Text = "PLAY"
        Me.PlayButton.UseVisualStyleBackColor = True
        '
        'frmProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 211)
        Me.Controls.Add(Me.PlayButton)
        Me.Controls.Add(Me.CreateProfile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBank)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PlayerSelectorBox)
        Me.Name = "frmProfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Profile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PlayerSelectorBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBank As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CreateProfile As System.Windows.Forms.Button
    Friend WithEvents PlayButton As System.Windows.Forms.Button
End Class

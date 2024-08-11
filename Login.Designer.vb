<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.adminbtn = New System.Windows.Forms.Button()
        Me.userbtn = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'adminbtn
        '
        Me.adminbtn.Location = New System.Drawing.Point(261, 11)
        Me.adminbtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.adminbtn.Name = "adminbtn"
        Me.adminbtn.Size = New System.Drawing.Size(277, 54)
        Me.adminbtn.TabIndex = 0
        Me.adminbtn.Text = "Admin"
        Me.adminbtn.UseVisualStyleBackColor = True
        '
        'userbtn
        '
        Me.userbtn.Location = New System.Drawing.Point(258, 169)
        Me.userbtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.userbtn.Name = "userbtn"
        Me.userbtn.Size = New System.Drawing.Size(280, 50)
        Me.userbtn.TabIndex = 1
        Me.userbtn.Text = "User"
        Me.userbtn.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.Lab.My.Resources.Resources.Lab_logo
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel3.Location = New System.Drawing.Point(261, 288)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(277, 130)
        Me.Panel3.TabIndex = 146
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.userbtn)
        Me.Controls.Add(Me.adminbtn)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Login"
        Me.Text = "Login"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents adminbtn As Button
    Friend WithEvents userbtn As Button
    Friend WithEvents Panel3 As Panel
End Class

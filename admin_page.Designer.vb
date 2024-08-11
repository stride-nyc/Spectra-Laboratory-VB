<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class admin_page
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim search_patients As System.Windows.Forms.Button
        Dim Staff As System.Windows.Forms.Button
        Dim Button1 As System.Windows.Forms.Button
        Dim Button2 As System.Windows.Forms.Button
        Dim Button3 As System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        search_patients = New System.Windows.Forms.Button()
        Staff = New System.Windows.Forms.Button()
        Button1 = New System.Windows.Forms.Button()
        Button2 = New System.Windows.Forms.Button()
        Button3 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'search_patients
        '
        search_patients.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(241, Byte), Integer))
        search_patients.FlatAppearance.BorderSize = 0
        search_patients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        search_patients.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        search_patients.ForeColor = System.Drawing.SystemColors.Control
        search_patients.Location = New System.Drawing.Point(3, 158)
        search_patients.Name = "search_patients"
        search_patients.Size = New System.Drawing.Size(284, 68)
        search_patients.TabIndex = 0
        search_patients.Text = "Patients"
        search_patients.UseVisualStyleBackColor = False
        AddHandler search_patients.Click, AddressOf Me.Hi_Click
        '
        'Staff
        '
        Staff.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(241, Byte), Integer))
        Staff.FlatAppearance.BorderSize = 0
        Staff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Staff.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Staff.ForeColor = System.Drawing.SystemColors.Control
        Staff.Location = New System.Drawing.Point(3, 232)
        Staff.Name = "Staff"
        Staff.Size = New System.Drawing.Size(284, 68)
        Staff.TabIndex = 1
        Staff.Text = "Staff"
        Staff.UseVisualStyleBackColor = False
        AddHandler Staff.Click, AddressOf Me.Staff_Click
        '
        'Button1
        '
        Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(241, Byte), Integer))
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button1.ForeColor = System.Drawing.SystemColors.Control
        Button1.Location = New System.Drawing.Point(0, 306)
        Button1.Name = "Button1"
        Button1.Size = New System.Drawing.Size(284, 68)
        Button1.TabIndex = 2
        Button1.Text = "Lab Utilities "
        Button1.UseVisualStyleBackColor = False
        AddHandler Button1.Click, AddressOf Me.Button1_Click
        '
        'Button2
        '
        Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(241, Byte), Integer))
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button2.ForeColor = System.Drawing.SystemColors.Control
        Button2.Location = New System.Drawing.Point(0, 454)
        Button2.Name = "Button2"
        Button2.Size = New System.Drawing.Size(284, 68)
        Button2.TabIndex = 3
        Button2.Text = "Statistics"
        Button2.UseVisualStyleBackColor = False
        AddHandler Button2.Click, AddressOf Me.Button2_Click
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Panel1.Controls.Add(Button3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Button2)
        Me.Panel1.Controls.Add(search_patients)
        Me.Panel1.Controls.Add(Staff)
        Me.Panel1.Controls.Add(Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 534)
        Me.Panel1.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(284, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(761, 66)
        Me.Panel3.TabIndex = 5
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'Button3
        '
        Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(241, Byte), Integer))
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button3.ForeColor = System.Drawing.SystemColors.Control
        Button3.Location = New System.Drawing.Point(0, 380)
        Button3.Name = "Button3"
        Button3.Size = New System.Drawing.Size(284, 68)
        Button3.TabIndex = 4
        Button3.Text = "Results"
        Button3.UseVisualStyleBackColor = False
        AddHandler Button3.Click, AddressOf Me.Button3_Click
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Panel4.BackgroundImage = Global.Lab.My.Resources.Resources.lab
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Strikeout), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(284, 66)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(761, 468)
        Me.Panel4.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = Global.Lab.My.Resources.Resources.Lab_logo1
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(284, 119)
        Me.Panel2.TabIndex = 3
        '
        'admin_page
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 534)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "admin_page"
        Me.Text = " "
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Timer1 As Timer
End Class

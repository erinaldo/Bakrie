<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePasswordFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangePasswordFrm))
        Me.PlChangePassword = New System.Windows.Forms.Panel
        Me.gpButtons = New System.Windows.Forms.GroupBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.gpChangePassword = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtRole = New System.Windows.Forms.TextBox
        Me.lblRole = New System.Windows.Forms.Label
        Me.cbUserName = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtConfirmNewPassword = New System.Windows.Forms.TextBox
        Me.txtNewPassword = New System.Windows.Forms.TextBox
        Me.txtDesignation = New System.Windows.Forms.TextBox
        Me.lblConfirmNewPassword = New System.Windows.Forms.Label
        Me.lblNewPassword = New System.Windows.Forms.Label
        Me.lblDesignation = New System.Windows.Forms.Label
        Me.lblUserName = New System.Windows.Forms.Label
        Me.PlChangePassword.SuspendLayout()
        Me.gpButtons.SuspendLayout()
        Me.gpChangePassword.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlChangePassword
        '
        Me.PlChangePassword.BackColor = System.Drawing.Color.Transparent
        Me.PlChangePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PlChangePassword.Controls.Add(Me.gpButtons)
        Me.PlChangePassword.Controls.Add(Me.gpChangePassword)
        Me.PlChangePassword.Location = New System.Drawing.Point(0, 0)
        Me.PlChangePassword.Name = "PlChangePassword"
        Me.PlChangePassword.Size = New System.Drawing.Size(804, 347)
        Me.PlChangePassword.TabIndex = 0
        '
        'gpButtons
        '
        Me.gpButtons.Controls.Add(Me.btnSave)
        Me.gpButtons.Controls.Add(Me.btnReset)
        Me.gpButtons.Location = New System.Drawing.Point(12, 227)
        Me.gpButtons.Name = "gpButtons"
        Me.gpButtons.Size = New System.Drawing.Size(423, 53)
        Me.gpButtons.TabIndex = 1
        Me.gpButtons.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(198, 17)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 25)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save "
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(299, 17)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 25)
        Me.btnReset.TabIndex = 4
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'gpChangePassword
        '
        Me.gpChangePassword.Controls.Add(Me.Label5)
        Me.gpChangePassword.Controls.Add(Me.txtRole)
        Me.gpChangePassword.Controls.Add(Me.lblRole)
        Me.gpChangePassword.Controls.Add(Me.cbUserName)
        Me.gpChangePassword.Controls.Add(Me.Label4)
        Me.gpChangePassword.Controls.Add(Me.Label3)
        Me.gpChangePassword.Controls.Add(Me.Label2)
        Me.gpChangePassword.Controls.Add(Me.Label1)
        Me.gpChangePassword.Controls.Add(Me.txtConfirmNewPassword)
        Me.gpChangePassword.Controls.Add(Me.txtNewPassword)
        Me.gpChangePassword.Controls.Add(Me.txtDesignation)
        Me.gpChangePassword.Controls.Add(Me.lblConfirmNewPassword)
        Me.gpChangePassword.Controls.Add(Me.lblNewPassword)
        Me.gpChangePassword.Controls.Add(Me.lblDesignation)
        Me.gpChangePassword.Controls.Add(Me.lblUserName)
        Me.gpChangePassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChangePassword.Location = New System.Drawing.Point(12, 12)
        Me.gpChangePassword.Name = "gpChangePassword"
        Me.gpChangePassword.Size = New System.Drawing.Size(423, 209)
        Me.gpChangePassword.TabIndex = 0
        Me.gpChangePassword.TabStop = False
        Me.gpChangePassword.Text = "Change Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(185, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = ":"
        '
        'txtRole
        '
        Me.txtRole.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtRole.Location = New System.Drawing.Point(199, 97)
        Me.txtRole.Name = "txtRole"
        Me.txtRole.ReadOnly = True
        Me.txtRole.Size = New System.Drawing.Size(197, 21)
        Me.txtRole.TabIndex = 100
        Me.txtRole.TabStop = False
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRole.Location = New System.Drawing.Point(28, 99)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(32, 13)
        Me.lblRole.TabIndex = 11
        Me.lblRole.Text = "Role"
        '
        'cbUserName
        '
        Me.cbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUserName.FormattingEnabled = True
        Me.cbUserName.Location = New System.Drawing.Point(199, 27)
        Me.cbUserName.Name = "cbUserName"
        Me.cbUserName.Size = New System.Drawing.Size(197, 21)
        Me.cbUserName.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(185, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(185, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(185, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(185, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ":"
        '
        'txtConfirmNewPassword
        '
        Me.txtConfirmNewPassword.Location = New System.Drawing.Point(199, 167)
        Me.txtConfirmNewPassword.Name = "txtConfirmNewPassword"
        Me.txtConfirmNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmNewPassword.Size = New System.Drawing.Size(197, 21)
        Me.txtConfirmNewPassword.TabIndex = 2
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Location = New System.Drawing.Point(199, 132)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Size = New System.Drawing.Size(197, 21)
        Me.txtNewPassword.TabIndex = 1
        '
        'txtDesignation
        '
        Me.txtDesignation.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtDesignation.Location = New System.Drawing.Point(199, 62)
        Me.txtDesignation.Name = "txtDesignation"
        Me.txtDesignation.ReadOnly = True
        Me.txtDesignation.Size = New System.Drawing.Size(197, 21)
        Me.txtDesignation.TabIndex = 100
        Me.txtDesignation.TabStop = False
        '
        'lblConfirmNewPassword
        '
        Me.lblConfirmNewPassword.AutoSize = True
        Me.lblConfirmNewPassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmNewPassword.ForeColor = System.Drawing.Color.Red
        Me.lblConfirmNewPassword.Location = New System.Drawing.Point(28, 173)
        Me.lblConfirmNewPassword.Name = "lblConfirmNewPassword"
        Me.lblConfirmNewPassword.Size = New System.Drawing.Size(139, 13)
        Me.lblConfirmNewPassword.TabIndex = 3
        Me.lblConfirmNewPassword.Text = "Confirm New Password"
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewPassword.ForeColor = System.Drawing.Color.Red
        Me.lblNewPassword.Location = New System.Drawing.Point(28, 136)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(89, 13)
        Me.lblNewPassword.TabIndex = 2
        Me.lblNewPassword.Text = "New Password"
        '
        'lblDesignation
        '
        Me.lblDesignation.AutoSize = True
        Me.lblDesignation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignation.Location = New System.Drawing.Point(28, 62)
        Me.lblDesignation.Name = "lblDesignation"
        Me.lblDesignation.Size = New System.Drawing.Size(74, 13)
        Me.lblDesignation.TabIndex = 1
        Me.lblDesignation.Text = "Designation"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Red
        Me.lblUserName.Location = New System.Drawing.Point(28, 25)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(70, 13)
        Me.lblUserName.TabIndex = 0
        Me.lblUserName.Text = "User Name"
        '
        'ChangePasswordFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(843, 347)
        Me.Controls.Add(Me.PlChangePassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ChangePasswordFrm"
        Me.Text = "Change Password"
        Me.PlChangePassword.ResumeLayout(False)
        Me.gpButtons.ResumeLayout(False)
        Me.gpChangePassword.ResumeLayout(False)
        Me.gpChangePassword.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlChangePassword As System.Windows.Forms.Panel
    Friend WithEvents gpChangePassword As System.Windows.Forms.GroupBox
    Friend WithEvents txtConfirmNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtDesignation As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmNewPassword As System.Windows.Forms.Label
    Friend WithEvents lblNewPassword As System.Windows.Forms.Label
    Friend WithEvents lblDesignation As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRole As System.Windows.Forms.TextBox
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents cbUserName As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button

End Class

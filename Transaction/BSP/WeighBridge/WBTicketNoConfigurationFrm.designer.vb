<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WBTicketNoConfigurationFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WBTicketNoConfigurationFrm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblOtherSerialNo = New System.Windows.Forms.Label
        Me.lblSerialNo = New System.Windows.Forms.Label
        Me.lblColon2 = New System.Windows.Forms.Label
        Me.lblcolon1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.txtOtherSerialNo = New System.Windows.Forms.TextBox
        Me.txtSerialNo = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.tcWBTicketConfiguration = New System.Windows.Forms.TabControl
        Me.tpWBTicketConfig = New System.Windows.Forms.TabPage
        Me.tpWBTicketPassword = New System.Windows.Forms.TabPage
        Me.chkChangePassword = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnTicketPassReset = New System.Windows.Forms.Button
        Me.btnTicketPassClose = New System.Windows.Forms.Button
        Me.btnTicketPassSave = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblNewPassword = New System.Windows.Forms.Label
        Me.colon3 = New System.Windows.Forms.Label
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.txtNewPassword = New System.Windows.Forms.TextBox
        Me.lblSerDesc = New System.Windows.Forms.Label
        Me.lblOtherDesc = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.tcWBTicketConfiguration.SuspendLayout()
        Me.tpWBTicketConfig.SuspendLayout()
        Me.tpWBTicketPassword.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblOtherDesc)
        Me.GroupBox1.Controls.Add(Me.lblSerDesc)
        Me.GroupBox1.Controls.Add(Me.lblOtherSerialNo)
        Me.GroupBox1.Controls.Add(Me.lblSerialNo)
        Me.GroupBox1.Controls.Add(Me.lblColon2)
        Me.GroupBox1.Controls.Add(Me.lblcolon1)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.txtOtherSerialNo)
        Me.GroupBox1.Controls.Add(Me.txtSerialNo)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(363, 105)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lblOtherSerialNo
        '
        Me.lblOtherSerialNo.AutoSize = True
        Me.lblOtherSerialNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOtherSerialNo.ForeColor = System.Drawing.Color.Red
        Me.lblOtherSerialNo.Location = New System.Drawing.Point(3, 63)
        Me.lblOtherSerialNo.Name = "lblOtherSerialNo"
        Me.lblOtherSerialNo.Size = New System.Drawing.Size(99, 13)
        Me.lblOtherSerialNo.TabIndex = 16
        Me.lblOtherSerialNo.Text = "Other Serial No."
        '
        'lblSerialNo
        '
        Me.lblSerialNo.AutoSize = True
        Me.lblSerialNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialNo.ForeColor = System.Drawing.Color.Red
        Me.lblSerialNo.Location = New System.Drawing.Point(3, 28)
        Me.lblSerialNo.Name = "lblSerialNo"
        Me.lblSerialNo.Size = New System.Drawing.Size(63, 13)
        Me.lblSerialNo.TabIndex = 15
        Me.lblSerialNo.Text = "Serial No."
        '
        'lblColon2
        '
        Me.lblColon2.AutoSize = True
        Me.lblColon2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon2.Location = New System.Drawing.Point(97, 61)
        Me.lblColon2.Name = "lblColon2"
        Me.lblColon2.Size = New System.Drawing.Size(12, 13)
        Me.lblColon2.TabIndex = 14
        Me.lblColon2.Text = ":"
        '
        'lblcolon1
        '
        Me.lblcolon1.AutoSize = True
        Me.lblcolon1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblcolon1.Location = New System.Drawing.Point(97, 28)
        Me.lblcolon1.Name = "lblcolon1"
        Me.lblcolon1.Size = New System.Drawing.Size(12, 13)
        Me.lblcolon1.TabIndex = 13
        Me.lblcolon1.Text = ":"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(-49, 149)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1116, 475)
        Me.DataGridView1.TabIndex = 12
        '
        'txtOtherSerialNo
        '
        Me.txtOtherSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOtherSerialNo.Location = New System.Drawing.Point(112, 61)
        Me.txtOtherSerialNo.Name = "txtOtherSerialNo"
        Me.txtOtherSerialNo.Size = New System.Drawing.Size(143, 21)
        Me.txtOtherSerialNo.TabIndex = 2
        '
        'txtSerialNo
        '
        Me.txtSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerialNo.Location = New System.Drawing.Point(112, 28)
        Me.txtSerialNo.Name = "txtSerialNo"
        Me.txtSerialNo.Size = New System.Drawing.Size(143, 21)
        Me.txtSerialNo.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.btnReset)
        Me.GroupBox3.Controls.Add(Me.btnClose)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(3, 176)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(398, 52)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(155, 17)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 25)
        Me.btnReset.TabIndex = 4
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(260, 17)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 25)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(50, 17)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 25)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'tcWBTicketConfiguration
        '
        Me.tcWBTicketConfiguration.Controls.Add(Me.tpWBTicketConfig)
        Me.tcWBTicketConfiguration.Controls.Add(Me.tpWBTicketPassword)
        Me.tcWBTicketConfiguration.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcWBTicketConfiguration.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcWBTicketConfiguration.Location = New System.Drawing.Point(0, 0)
        Me.tcWBTicketConfiguration.Name = "tcWBTicketConfiguration"
        Me.tcWBTicketConfiguration.SelectedIndex = 0
        Me.tcWBTicketConfiguration.Size = New System.Drawing.Size(412, 257)
        Me.tcWBTicketConfiguration.TabIndex = 20
        Me.tcWBTicketConfiguration.TabStop = False
        '
        'tpWBTicketConfig
        '
        Me.tpWBTicketConfig.BackgroundImage = CType(resources.GetObject("tpWBTicketConfig.BackgroundImage"), System.Drawing.Image)
        Me.tpWBTicketConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpWBTicketConfig.Controls.Add(Me.GroupBox1)
        Me.tpWBTicketConfig.Controls.Add(Me.GroupBox3)
        Me.tpWBTicketConfig.Location = New System.Drawing.Point(4, 22)
        Me.tpWBTicketConfig.Name = "tpWBTicketConfig"
        Me.tpWBTicketConfig.Padding = New System.Windows.Forms.Padding(3)
        Me.tpWBTicketConfig.Size = New System.Drawing.Size(404, 231)
        Me.tpWBTicketConfig.TabIndex = 0
        Me.tpWBTicketConfig.Text = "WBTicketConfiguration"
        Me.tpWBTicketConfig.UseVisualStyleBackColor = True
        '
        'tpWBTicketPassword
        '
        Me.tpWBTicketPassword.BackgroundImage = CType(resources.GetObject("tpWBTicketPassword.BackgroundImage"), System.Drawing.Image)
        Me.tpWBTicketPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpWBTicketPassword.Controls.Add(Me.chkChangePassword)
        Me.tpWBTicketPassword.Controls.Add(Me.GroupBox4)
        Me.tpWBTicketPassword.Controls.Add(Me.GroupBox2)
        Me.tpWBTicketPassword.Location = New System.Drawing.Point(4, 22)
        Me.tpWBTicketPassword.Name = "tpWBTicketPassword"
        Me.tpWBTicketPassword.Padding = New System.Windows.Forms.Padding(3)
        Me.tpWBTicketPassword.Size = New System.Drawing.Size(404, 231)
        Me.tpWBTicketPassword.TabIndex = 1
        Me.tpWBTicketPassword.Text = "WBTicketPassword"
        Me.tpWBTicketPassword.UseVisualStyleBackColor = True
        '
        'chkChangePassword
        '
        Me.chkChangePassword.AutoSize = True
        Me.chkChangePassword.Location = New System.Drawing.Point(8, 11)
        Me.chkChangePassword.Name = "chkChangePassword"
        Me.chkChangePassword.Size = New System.Drawing.Size(128, 17)
        Me.chkChangePassword.TabIndex = 18
        Me.chkChangePassword.TabStop = False
        Me.chkChangePassword.Text = "Change Password"
        Me.chkChangePassword.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btnTicketPassReset)
        Me.GroupBox4.Controls.Add(Me.btnTicketPassClose)
        Me.GroupBox4.Controls.Add(Me.btnTicketPassSave)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(3, 176)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(398, 52)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        '
        'btnTicketPassReset
        '
        Me.btnTicketPassReset.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnTicketPassReset.BackgroundImage = CType(resources.GetObject("btnTicketPassReset.BackgroundImage"), System.Drawing.Image)
        Me.btnTicketPassReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTicketPassReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTicketPassReset.Image = CType(resources.GetObject("btnTicketPassReset.Image"), System.Drawing.Image)
        Me.btnTicketPassReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTicketPassReset.Location = New System.Drawing.Point(156, 18)
        Me.btnTicketPassReset.Name = "btnTicketPassReset"
        Me.btnTicketPassReset.Size = New System.Drawing.Size(95, 25)
        Me.btnTicketPassReset.TabIndex = 8
        Me.btnTicketPassReset.Text = "Reset"
        Me.btnTicketPassReset.UseVisualStyleBackColor = False
        '
        'btnTicketPassClose
        '
        Me.btnTicketPassClose.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnTicketPassClose.BackgroundImage = CType(resources.GetObject("btnTicketPassClose.BackgroundImage"), System.Drawing.Image)
        Me.btnTicketPassClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTicketPassClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTicketPassClose.Image = CType(resources.GetObject("btnTicketPassClose.Image"), System.Drawing.Image)
        Me.btnTicketPassClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTicketPassClose.Location = New System.Drawing.Point(265, 18)
        Me.btnTicketPassClose.Name = "btnTicketPassClose"
        Me.btnTicketPassClose.Size = New System.Drawing.Size(95, 25)
        Me.btnTicketPassClose.TabIndex = 9
        Me.btnTicketPassClose.Text = "Close"
        Me.btnTicketPassClose.UseVisualStyleBackColor = False
        '
        'btnTicketPassSave
        '
        Me.btnTicketPassSave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnTicketPassSave.BackgroundImage = CType(resources.GetObject("btnTicketPassSave.BackgroundImage"), System.Drawing.Image)
        Me.btnTicketPassSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTicketPassSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTicketPassSave.Image = CType(resources.GetObject("btnTicketPassSave.Image"), System.Drawing.Image)
        Me.btnTicketPassSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTicketPassSave.Location = New System.Drawing.Point(48, 18)
        Me.btnTicketPassSave.Name = "btnTicketPassSave"
        Me.btnTicketPassSave.Size = New System.Drawing.Size(95, 25)
        Me.btnTicketPassSave.TabIndex = 7
        Me.btnTicketPassSave.Text = "Save"
        Me.btnTicketPassSave.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lblNewPassword)
        Me.GroupBox2.Controls.Add(Me.colon3)
        Me.GroupBox2.Controls.Add(Me.DataGridView2)
        Me.GroupBox2.Controls.Add(Me.txtNewPassword)
        Me.GroupBox2.Location = New System.Drawing.Point(41, 67)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(337, 85)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.Location = New System.Drawing.Point(21, 39)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(123, 13)
        Me.lblNewPassword.TabIndex = 15
        Me.lblNewPassword.Text = "Enter New Password"
        '
        'colon3
        '
        Me.colon3.AutoSize = True
        Me.colon3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colon3.Location = New System.Drawing.Point(133, 38)
        Me.colon3.Name = "colon3"
        Me.colon3.Size = New System.Drawing.Size(12, 13)
        Me.colon3.TabIndex = 14
        Me.colon3.Text = ":"
        '
        'DataGridView2
        '
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(-49, 149)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(1116, 475)
        Me.DataGridView2.TabIndex = 12
        '
        'txtNewPassword
        '
        Me.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewPassword.Location = New System.Drawing.Point(168, 37)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Size = New System.Drawing.Size(143, 21)
        Me.txtNewPassword.TabIndex = 6
        '
        'lblSerDesc
        '
        Me.lblSerDesc.AutoSize = True
        Me.lblSerDesc.ForeColor = System.Drawing.Color.Blue
        Me.lblSerDesc.Location = New System.Drawing.Point(261, 30)
        Me.lblSerDesc.Name = "lblSerDesc"
        Me.lblSerDesc.Size = New System.Drawing.Size(96, 13)
        Me.lblSerDesc.TabIndex = 17
        Me.lblSerDesc.Text = "Numeric Values"
        '
        'lblOtherDesc
        '
        Me.lblOtherDesc.AutoSize = True
        Me.lblOtherDesc.ForeColor = System.Drawing.Color.Blue
        Me.lblOtherDesc.Location = New System.Drawing.Point(261, 63)
        Me.lblOtherDesc.Name = "lblOtherDesc"
        Me.lblOtherDesc.Size = New System.Drawing.Size(96, 13)
        Me.lblOtherDesc.TabIndex = 18
        Me.lblOtherDesc.Text = "Numeric Values"
        '
        'WBTicketNoConfigurationFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(412, 269)
        Me.Controls.Add(Me.tcWBTicketConfiguration)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(227, 60)
        Me.Name = "WBTicketNoConfigurationFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "WBTicketNoConfigurationFrm"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.tcWBTicketConfiguration.ResumeLayout(False)
        Me.tpWBTicketConfig.ResumeLayout(False)
        Me.tpWBTicketPassword.ResumeLayout(False)
        Me.tpWBTicketPassword.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    '--Friend WithEvents ItemLabel1 As BSP.WIN.ItemLabel
    '--Friend WithEvents ItemLabel2 As BSP.WIN.ItemLabel
    Friend WithEvents txtOtherSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents txtSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblColon2 As System.Windows.Forms.Label
    Friend WithEvents lblcolon1 As System.Windows.Forms.Label
    Friend WithEvents tcWBTicketConfiguration As System.Windows.Forms.TabControl
    Friend WithEvents tpWBTicketConfig As System.Windows.Forms.TabPage
    Friend WithEvents tpWBTicketPassword As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents colon3 As System.Windows.Forms.Label
    '--Friend WithEvents lblNewPassword As BSP.WIN.ItemLabel
    '-- Friend WithEvents lblPassword As BSP.WIN.ItemLabel
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTicketPassReset As System.Windows.Forms.Button
    Friend WithEvents btnTicketPassClose As System.Windows.Forms.Button
    Friend WithEvents btnTicketPassSave As System.Windows.Forms.Button
    '--Friend WithEvents lblUserName As BSP.WIN.ItemLabel
    Friend WithEvents chkChangePassword As System.Windows.Forms.CheckBox
    Friend WithEvents lblOtherSerialNo As System.Windows.Forms.Label
    Friend WithEvents lblSerialNo As System.Windows.Forms.Label
    Friend WithEvents lblNewPassword As System.Windows.Forms.Label
    Friend WithEvents lblOtherDesc As System.Windows.Forms.Label
    Friend WithEvents lblSerDesc As System.Windows.Forms.Label
End Class

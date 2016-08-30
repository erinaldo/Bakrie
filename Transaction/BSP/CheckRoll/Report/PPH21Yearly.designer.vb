<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PPH21Yearly
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PPH21Yearly))
        Me.plReport = New Stepi.UI.ExtendedPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNPWP = New System.Windows.Forms.TextBox()
        Me.EmployerNameLabel = New System.Windows.Forms.Label()
        Me.NPWPLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTanggalDTP = New System.Windows.Forms.DateTimePicker()
        Me.TanggalLabel = New System.Windows.Forms.Label()
        Me.plReport.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'plReport
        '
        Me.plReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plReport.BorderColor = System.Drawing.Color.Gray
        Me.plReport.CaptionColorOne = System.Drawing.Color.White
        Me.plReport.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plReport.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plReport.CaptionSize = 40
        Me.plReport.CaptionText = "PPH 21"
        Me.plReport.CaptionTextColor = System.Drawing.Color.Black
        Me.plReport.Controls.Add(Me.GroupBox1)
        Me.plReport.Controls.Add(Me.Label2)
        Me.plReport.Controls.Add(Me.cbYear)
        Me.plReport.Controls.Add(Me.lblYear)
        Me.plReport.Controls.Add(Me.btnReport)
        Me.plReport.Controls.Add(Me.btnClose)
        Me.plReport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plReport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plReport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.plReport.ForeColor = System.Drawing.Color.Black
        Me.plReport.Location = New System.Drawing.Point(0, 0)
        Me.plReport.Name = "plReport"
        Me.plReport.Size = New System.Drawing.Size(637, 306)
        Me.plReport.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(81, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 20)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = ":"
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(126, 63)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(176, 28)
        Me.cbYear.TabIndex = 138
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.Location = New System.Drawing.Point(30, 63)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(45, 20)
        Me.lblYear.TabIndex = 10
        Me.lblYear.Text = "Year"
        '
        'btnReport
        '
        Me.btnReport.BackgroundImage = CType(resources.GetObject("btnReport.BackgroundImage"), System.Drawing.Image)
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.Color.Black
        Me.btnReport.Image = CType(resources.GetObject("btnReport.Image"), System.Drawing.Image)
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(22, 258)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(118, 25)
        Me.btnReport.TabIndex = 112
        Me.btnReport.Text = "View Reports"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(146, 258)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(102, 25)
        Me.btnClose.TabIndex = 118
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTanggalDTP)
        Me.GroupBox1.Controls.Add(Me.TanggalLabel)
        Me.GroupBox1.Controls.Add(Me.txtNPWP)
        Me.GroupBox1.Controls.Add(Me.EmployerNameLabel)
        Me.GroupBox1.Controls.Add(Me.NPWPLabel)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNama)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 97)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 124)
        Me.GroupBox1.TabIndex = 147
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pemotong Pajak"
        '
        'txtNPWP
        '
        Me.txtNPWP.Location = New System.Drawing.Point(100, 50)
        Me.txtNPWP.MaxLength = 20
        Me.txtNPWP.Name = "txtNPWP"
        Me.txtNPWP.Size = New System.Drawing.Size(203, 28)
        Me.txtNPWP.TabIndex = 148
        '
        'EmployerNameLabel
        '
        Me.EmployerNameLabel.AutoSize = True
        Me.EmployerNameLabel.Enabled = False
        Me.EmployerNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmployerNameLabel.ForeColor = System.Drawing.Color.Black
        Me.EmployerNameLabel.Location = New System.Drawing.Point(37, 28)
        Me.EmployerNameLabel.Name = "EmployerNameLabel"
        Me.EmployerNameLabel.Size = New System.Drawing.Size(59, 20)
        Me.EmployerNameLabel.TabIndex = 147
        Me.EmployerNameLabel.Text = "Nama"
        '
        'NPWPLabel
        '
        Me.NPWPLabel.AutoSize = True
        Me.NPWPLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NPWPLabel.ForeColor = System.Drawing.Color.Black
        Me.NPWPLabel.Location = New System.Drawing.Point(37, 58)
        Me.NPWPLabel.Name = "NPWPLabel"
        Me.NPWPLabel.Size = New System.Drawing.Size(59, 20)
        Me.NPWPLabel.TabIndex = 144
        Me.NPWPLabel.Text = "NPWP"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(83, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 20)
        Me.Label5.TabIndex = 150
        Me.Label5.Text = ":"
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(100, 20)
        Me.txtNama.MaxLength = 40
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(343, 28)
        Me.txtNama.TabIndex = 147
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(83, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 20)
        Me.Label4.TabIndex = 149
        Me.Label4.Text = ":"
        '
        'txtTanggalDTP
        '
        Me.txtTanggalDTP.CustomFormat = "dd/MM/yyyy"
        Me.txtTanggalDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtTanggalDTP.Location = New System.Drawing.Point(100, 82)
        Me.txtTanggalDTP.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.txtTanggalDTP.Name = "txtTanggalDTP"
        Me.txtTanggalDTP.Size = New System.Drawing.Size(203, 28)
        Me.txtTanggalDTP.TabIndex = 158
        Me.txtTanggalDTP.Value = New Date(2011, 12, 14, 0, 0, 0, 0)
        '
        'TanggalLabel
        '
        Me.TanggalLabel.AutoSize = True
        Me.TanggalLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TanggalLabel.ForeColor = System.Drawing.Color.Black
        Me.TanggalLabel.Location = New System.Drawing.Point(24, 87)
        Me.TanggalLabel.Name = "TanggalLabel"
        Me.TanggalLabel.Size = New System.Drawing.Size(75, 20)
        Me.TanggalLabel.TabIndex = 159
        Me.TanggalLabel.Text = "Tanggal"
        '
        'PPH21Yearly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(637, 334)
        Me.Controls.Add(Me.plReport)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PPH21Yearly"
        Me.Text = "MaterialusageRpt"
        Me.plReport.ResumeLayout(False)
        Me.plReport.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plReport As Stepi.UI.ExtendedPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNPWP As System.Windows.Forms.TextBox
    Friend WithEvents EmployerNameLabel As System.Windows.Forms.Label
    Friend WithEvents NPWPLabel As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTanggalDTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents TanggalLabel As System.Windows.Forms.Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pph21KaryawanReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pph21KaryawanReport))
        Me.plReport = New Stepi.UI.ExtendedPanel
        Me.TanggalDTP = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.TanggalLabel = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TempatLabel = New System.Windows.Forms.Label
        Me.TempatTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.AlamatLabel = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.AlamatTextBox = New System.Windows.Forms.TextBox
        Me.NPWPTextBox = New System.Windows.Forms.TextBox
        Me.EmployerNameLabel = New System.Windows.Forms.Label
        Me.NPWPLabel = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.EmployerNameTextBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.NPWPKuasaTextBox = New System.Windows.Forms.TextBox
        Me.NameKuasaLabel = New System.Windows.Forms.Label
        Me.NPWPKuasaLabel = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.NameKuasaTextBox = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbMonth = New System.Windows.Forms.ComboBox
        Me.StartSeqNoLabel = New System.Windows.Forms.Label
        Me.lblMonth = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbYear = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.StartSeqNoTextBox = New System.Windows.Forms.TextBox
        Me.lblYear = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnReport = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.JabatanLabel = New System.Windows.Forms.Label
        Me.JabatanTextBox = New System.Windows.Forms.TextBox
        Me.plReport.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.plReport.CaptionText = "PPH21 Karyawan Yearly Reports "
        Me.plReport.CaptionTextColor = System.Drawing.Color.Black
        Me.plReport.Controls.Add(Me.Label7)
        Me.plReport.Controls.Add(Me.JabatanLabel)
        Me.plReport.Controls.Add(Me.JabatanTextBox)
        Me.plReport.Controls.Add(Me.TanggalDTP)
        Me.plReport.Controls.Add(Me.Label10)
        Me.plReport.Controls.Add(Me.TanggalLabel)
        Me.plReport.Controls.Add(Me.Label6)
        Me.plReport.Controls.Add(Me.TempatLabel)
        Me.plReport.Controls.Add(Me.TempatTextBox)
        Me.plReport.Controls.Add(Me.Label3)
        Me.plReport.Controls.Add(Me.GroupBox1)
        Me.plReport.Controls.Add(Me.GroupBox2)
        Me.plReport.Controls.Add(Me.cbMonth)
        Me.plReport.Controls.Add(Me.StartSeqNoLabel)
        Me.plReport.Controls.Add(Me.lblMonth)
        Me.plReport.Controls.Add(Me.Label2)
        Me.plReport.Controls.Add(Me.cbYear)
        Me.plReport.Controls.Add(Me.Label1)
        Me.plReport.Controls.Add(Me.StartSeqNoTextBox)
        Me.plReport.Controls.Add(Me.lblYear)
        Me.plReport.Controls.Add(Me.btnClose)
        Me.plReport.Controls.Add(Me.btnReport)
        Me.plReport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plReport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plReport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.plReport.ForeColor = System.Drawing.Color.Black
        Me.plReport.Location = New System.Drawing.Point(0, 0)
        Me.plReport.Name = "plReport"
        Me.plReport.Size = New System.Drawing.Size(771, 334)
        Me.plReport.TabIndex = 121
        '
        'TanggalDTP
        '
        Me.TanggalDTP.CustomFormat = "dd/MM/yyyy"
        Me.TanggalDTP.Enabled = False
        Me.TanggalDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TanggalDTP.Location = New System.Drawing.Point(93, 199)
        Me.TanggalDTP.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.TanggalDTP.Name = "TanggalDTP"
        Me.TanggalDTP.Size = New System.Drawing.Size(140, 21)
        Me.TanggalDTP.TabIndex = 144
        Me.TanggalDTP.Value = New Date(2011, 12, 14, 0, 0, 0, 0)
        Me.TanggalDTP.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(76, 207)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 158
        Me.Label10.Text = ":"
        '
        'TanggalLabel
        '
        Me.TanggalLabel.AutoSize = True
        Me.TanggalLabel.Enabled = False
        Me.TanggalLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TanggalLabel.ForeColor = System.Drawing.Color.Black
        Me.TanggalLabel.Location = New System.Drawing.Point(23, 207)
        Me.TanggalLabel.Name = "TanggalLabel"
        Me.TanggalLabel.Size = New System.Drawing.Size(52, 13)
        Me.TanggalLabel.TabIndex = 157
        Me.TanggalLabel.Text = "Tanggal"
        Me.TanggalLabel.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(76, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 155
        Me.Label6.Text = ":"
        '
        'TempatLabel
        '
        Me.TempatLabel.AutoSize = True
        Me.TempatLabel.Enabled = False
        Me.TempatLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TempatLabel.ForeColor = System.Drawing.Color.Black
        Me.TempatLabel.Location = New System.Drawing.Point(23, 180)
        Me.TempatLabel.Name = "TempatLabel"
        Me.TempatLabel.Size = New System.Drawing.Size(50, 13)
        Me.TempatLabel.TabIndex = 154
        Me.TempatLabel.Text = "Tempat"
        Me.TempatLabel.Visible = False
        '
        'TempatTextBox
        '
        Me.TempatTextBox.Enabled = False
        Me.TempatTextBox.Location = New System.Drawing.Point(93, 172)
        Me.TempatTextBox.MaxLength = 20
        Me.TempatTextBox.Name = "TempatTextBox"
        Me.TempatTextBox.Size = New System.Drawing.Size(169, 21)
        Me.TempatTextBox.TabIndex = 143
        Me.TempatTextBox.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(76, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = ":"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AlamatLabel)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.AlamatTextBox)
        Me.GroupBox1.Controls.Add(Me.NPWPTextBox)
        Me.GroupBox1.Controls.Add(Me.EmployerNameLabel)
        Me.GroupBox1.Controls.Add(Me.NPWPLabel)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.EmployerNameTextBox)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(271, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 106)
        Me.GroupBox1.TabIndex = 146
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pemotong Pajak"
        Me.GroupBox1.Visible = False
        '
        'AlamatLabel
        '
        Me.AlamatLabel.AutoSize = True
        Me.AlamatLabel.Enabled = False
        Me.AlamatLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlamatLabel.ForeColor = System.Drawing.Color.Black
        Me.AlamatLabel.Location = New System.Drawing.Point(37, 81)
        Me.AlamatLabel.Name = "AlamatLabel"
        Me.AlamatLabel.Size = New System.Drawing.Size(47, 13)
        Me.AlamatLabel.TabIndex = 152
        Me.AlamatLabel.Text = "Alamat"
        Me.AlamatLabel.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(83, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 153
        Me.Label11.Text = ":"
        '
        'AlamatTextBox
        '
        Me.AlamatTextBox.Enabled = False
        Me.AlamatTextBox.Location = New System.Drawing.Point(100, 73)
        Me.AlamatTextBox.MaxLength = 40
        Me.AlamatTextBox.Name = "AlamatTextBox"
        Me.AlamatTextBox.Size = New System.Drawing.Size(343, 21)
        Me.AlamatTextBox.TabIndex = 149
        Me.AlamatTextBox.Visible = False
        '
        'NPWPTextBox
        '
        Me.NPWPTextBox.Enabled = False
        Me.NPWPTextBox.Location = New System.Drawing.Point(100, 46)
        Me.NPWPTextBox.MaxLength = 20
        Me.NPWPTextBox.Name = "NPWPTextBox"
        Me.NPWPTextBox.Size = New System.Drawing.Size(203, 21)
        Me.NPWPTextBox.TabIndex = 148
        Me.NPWPTextBox.Visible = False
        '
        'EmployerNameLabel
        '
        Me.EmployerNameLabel.AutoSize = True
        Me.EmployerNameLabel.Enabled = False
        Me.EmployerNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmployerNameLabel.ForeColor = System.Drawing.Color.Black
        Me.EmployerNameLabel.Location = New System.Drawing.Point(37, 28)
        Me.EmployerNameLabel.Name = "EmployerNameLabel"
        Me.EmployerNameLabel.Size = New System.Drawing.Size(40, 13)
        Me.EmployerNameLabel.TabIndex = 147
        Me.EmployerNameLabel.Text = "Nama"
        Me.EmployerNameLabel.Visible = False
        '
        'NPWPLabel
        '
        Me.NPWPLabel.AutoSize = True
        Me.NPWPLabel.Enabled = False
        Me.NPWPLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NPWPLabel.ForeColor = System.Drawing.Color.Black
        Me.NPWPLabel.Location = New System.Drawing.Point(37, 54)
        Me.NPWPLabel.Name = "NPWPLabel"
        Me.NPWPLabel.Size = New System.Drawing.Size(40, 13)
        Me.NPWPLabel.TabIndex = 144
        Me.NPWPLabel.Text = "NPWP"
        Me.NPWPLabel.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(83, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 150
        Me.Label5.Text = ":"
        '
        'EmployerNameTextBox
        '
        Me.EmployerNameTextBox.Enabled = False
        Me.EmployerNameTextBox.Location = New System.Drawing.Point(100, 20)
        Me.EmployerNameTextBox.MaxLength = 40
        Me.EmployerNameTextBox.Name = "EmployerNameTextBox"
        Me.EmployerNameTextBox.Size = New System.Drawing.Size(343, 21)
        Me.EmployerNameTextBox.TabIndex = 147
        Me.EmployerNameTextBox.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(83, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 149
        Me.Label4.Text = ":"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.NPWPKuasaTextBox)
        Me.GroupBox2.Controls.Add(Me.NameKuasaLabel)
        Me.GroupBox2.Controls.Add(Me.NPWPKuasaLabel)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.NameKuasaTextBox)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(271, 172)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(458, 118)
        Me.GroupBox2.TabIndex = 150
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pemotong Pajak / Kuasa"
        Me.GroupBox2.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Location = New System.Drawing.Point(40, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(369, 37)
        Me.GroupBox3.TabIndex = 151
        Me.GroupBox3.TabStop = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.Location = New System.Drawing.Point(165, 14)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(60, 17)
        Me.RadioButton2.TabIndex = 153
        Me.RadioButton2.Text = "Kuasa"
        Me.RadioButton2.UseVisualStyleBackColor = True
        Me.RadioButton2.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.Location = New System.Drawing.Point(8, 14)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(118, 17)
        Me.RadioButton1.TabIndex = 152
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Pemotong Pajak"
        Me.RadioButton1.UseVisualStyleBackColor = True
        Me.RadioButton1.Visible = False
        '
        'NPWPKuasaTextBox
        '
        Me.NPWPKuasaTextBox.Enabled = False
        Me.NPWPKuasaTextBox.Location = New System.Drawing.Point(100, 89)
        Me.NPWPKuasaTextBox.MaxLength = 20
        Me.NPWPKuasaTextBox.Name = "NPWPKuasaTextBox"
        Me.NPWPKuasaTextBox.Size = New System.Drawing.Size(203, 21)
        Me.NPWPKuasaTextBox.TabIndex = 155
        Me.NPWPKuasaTextBox.Visible = False
        '
        'NameKuasaLabel
        '
        Me.NameKuasaLabel.AutoSize = True
        Me.NameKuasaLabel.Enabled = False
        Me.NameKuasaLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameKuasaLabel.ForeColor = System.Drawing.Color.Black
        Me.NameKuasaLabel.Location = New System.Drawing.Point(37, 71)
        Me.NameKuasaLabel.Name = "NameKuasaLabel"
        Me.NameKuasaLabel.Size = New System.Drawing.Size(40, 13)
        Me.NameKuasaLabel.TabIndex = 147
        Me.NameKuasaLabel.Text = "Nama"
        Me.NameKuasaLabel.Visible = False
        '
        'NPWPKuasaLabel
        '
        Me.NPWPKuasaLabel.AutoSize = True
        Me.NPWPKuasaLabel.Enabled = False
        Me.NPWPKuasaLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NPWPKuasaLabel.ForeColor = System.Drawing.Color.Black
        Me.NPWPKuasaLabel.Location = New System.Drawing.Point(37, 97)
        Me.NPWPKuasaLabel.Name = "NPWPKuasaLabel"
        Me.NPWPKuasaLabel.Size = New System.Drawing.Size(40, 13)
        Me.NPWPKuasaLabel.TabIndex = 144
        Me.NPWPKuasaLabel.Text = "NPWP"
        Me.NPWPKuasaLabel.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(83, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 13)
        Me.Label8.TabIndex = 150
        Me.Label8.Text = ":"
        '
        'NameKuasaTextBox
        '
        Me.NameKuasaTextBox.Enabled = False
        Me.NameKuasaTextBox.Location = New System.Drawing.Point(100, 63)
        Me.NameKuasaTextBox.MaxLength = 40
        Me.NameKuasaTextBox.Name = "NameKuasaTextBox"
        Me.NameKuasaTextBox.Size = New System.Drawing.Size(343, 21)
        Me.NameKuasaTextBox.TabIndex = 154
        Me.NameKuasaTextBox.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(83, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 149
        Me.Label9.Text = ":"
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(93, 98)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(140, 21)
        Me.cbMonth.TabIndex = 141
        '
        'StartSeqNoLabel
        '
        Me.StartSeqNoLabel.AutoSize = True
        Me.StartSeqNoLabel.Enabled = False
        Me.StartSeqNoLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartSeqNoLabel.ForeColor = System.Drawing.Color.Black
        Me.StartSeqNoLabel.Location = New System.Drawing.Point(18, 153)
        Me.StartSeqNoLabel.Name = "StartSeqNoLabel"
        Me.StartSeqNoLabel.Size = New System.Drawing.Size(54, 13)
        Me.StartSeqNoLabel.TabIndex = 143
        Me.StartSeqNoLabel.Text = "No. Urut"
        Me.StartSeqNoLabel.Visible = False
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.ForeColor = System.Drawing.Color.Black
        Me.lblMonth.Location = New System.Drawing.Point(12, 106)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(66, 13)
        Me.lblMonth.TabIndex = 139
        Me.lblMonth.Text = "Emp Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(76, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = ":"
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(93, 71)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(140, 21)
        Me.cbYear.TabIndex = 138
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(76, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = ":"
        '
        'StartSeqNoTextBox
        '
        Me.StartSeqNoTextBox.Enabled = False
        Me.StartSeqNoTextBox.Location = New System.Drawing.Point(93, 145)
        Me.StartSeqNoTextBox.MaxLength = 6
        Me.StartSeqNoTextBox.Name = "StartSeqNoTextBox"
        Me.StartSeqNoTextBox.Size = New System.Drawing.Size(79, 21)
        Me.StartSeqNoTextBox.TabIndex = 142
        Me.StartSeqNoTextBox.Text = "1"
        Me.StartSeqNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.StartSeqNoTextBox.Visible = False
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.Location = New System.Drawing.Point(45, 79)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(33, 13)
        Me.lblYear.TabIndex = 10
        Me.lblYear.Text = "Year"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(344, 301)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(102, 25)
        Me.btnClose.TabIndex = 155
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.BackgroundImage = CType(resources.GetObject("btnReport.BackgroundImage"), System.Drawing.Image)
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.Color.Black
        Me.btnReport.Image = CType(resources.GetObject("btnReport.Image"), System.Drawing.Image)
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(220, 301)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(118, 25)
        Me.btnReport.TabIndex = 154
        Me.btnReport.Text = "View Reports"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(76, 235)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 161
        Me.Label7.Text = ":"
        '
        'JabatanLabel
        '
        Me.JabatanLabel.AutoSize = True
        Me.JabatanLabel.Enabled = False
        Me.JabatanLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JabatanLabel.ForeColor = System.Drawing.Color.Black
        Me.JabatanLabel.Location = New System.Drawing.Point(23, 235)
        Me.JabatanLabel.Name = "JabatanLabel"
        Me.JabatanLabel.Size = New System.Drawing.Size(51, 13)
        Me.JabatanLabel.TabIndex = 160
        Me.JabatanLabel.Text = "Jabatan"
        Me.JabatanLabel.Visible = False
        '
        'JabatanTextBox
        '
        Me.JabatanTextBox.Enabled = False
        Me.JabatanTextBox.Location = New System.Drawing.Point(93, 227)
        Me.JabatanTextBox.MaxLength = 20
        Me.JabatanTextBox.Name = "JabatanTextBox"
        Me.JabatanTextBox.Size = New System.Drawing.Size(169, 21)
        Me.JabatanTextBox.TabIndex = 145
        Me.JabatanTextBox.Visible = False
        '
        'pph21KaryawanReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(771, 393)
        Me.Controls.Add(Me.plReport)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "pph21KaryawanReport"
        Me.Text = "DistribusiCheckrollReport"
        Me.plReport.ResumeLayout(False)
        Me.plReport.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plReport As Stepi.UI.ExtendedPanel
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents StartSeqNoLabel As System.Windows.Forms.Label
    Friend WithEvents StartSeqNoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NPWPLabel As System.Windows.Forms.Label
    Friend WithEvents NPWPTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmployerNameLabel As System.Windows.Forms.Label
    Friend WithEvents EmployerNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents NPWPKuasaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameKuasaLabel As System.Windows.Forms.Label
    Friend WithEvents NPWPKuasaLabel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents NameKuasaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TempatLabel As System.Windows.Forms.Label
    Friend WithEvents TempatTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TanggalLabel As System.Windows.Forms.Label
    Friend WithEvents TanggalDTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents AlamatLabel As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents AlamatTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents JabatanLabel As System.Windows.Forms.Label
    Friend WithEvents JabatanTextBox As System.Windows.Forms.TextBox
End Class

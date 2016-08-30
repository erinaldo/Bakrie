<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyTeamActivity
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DailyTeamActivity))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabInput = New System.Windows.Forms.TabPage()
        Me.cmdPrintLain = New System.Windows.Forms.Button()
        Me.cmdPrintDeres = New System.Windows.Forms.Button()
        Me.cmdPrintPanen = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtChange = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvDailyTeamActivity = New System.Windows.Forms.DataGridView()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnModifyTeam = New System.Windows.Forms.Button()
        Me.lblMandorNik = New System.Windows.Forms.Label()
        Me.lblKraniNik = New System.Windows.Forms.Label()
        Me.btnGenerateTeam = New System.Windows.Forms.Button()
        Me.txtTeam = New System.Windows.Forms.TextBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.lblKraniName = New System.Windows.Forms.Label()
        Me.cmbActivity = New System.Windows.Forms.ComboBox()
        Me.lblMandorName = New System.Windows.Forms.Label()
        Me.lblTeamCode = New System.Windows.Forms.Label()
        Me.dtpRDate = New System.Windows.Forms.DateTimePicker()
        Me.lblKraniId = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMandorId = New System.Windows.Forms.Label()
        Me.lblTeam = New System.Windows.Forms.Label()
        Me.txtKraniNik = New System.Windows.Forms.TextBox()
        Me.btnKraniView = New System.Windows.Forms.Button()
        Me.btnmandorView = New System.Windows.Forms.Button()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblActivity = New System.Windows.Forms.Label()
        Me.lblAttCode = New System.Windows.Forms.Label()
        Me.lblColon1 = New System.Windows.Forms.Label()
        Me.lblColon2 = New System.Windows.Forms.Label()
        Me.lblColon8 = New System.Windows.Forms.Label()
        Me.lblColon4 = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.txtMandorNik = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnEditOrUpdate = New System.Windows.Forms.Button()
        Me.lblDailyTeamActivtyID = New System.Windows.Forms.Label()
        Me.tcDailyAttendance = New System.Windows.Forms.TabControl()
        Me.tabInput.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvDailyTeamActivity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tcDailyAttendance.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabInput
        '
        Me.tabInput.AutoScroll = True
        Me.tabInput.BackColor = System.Drawing.Color.Transparent
        Me.tabInput.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tabInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabInput.Controls.Add(Me.cmdPrintLain)
        Me.tabInput.Controls.Add(Me.cmdPrintDeres)
        Me.tabInput.Controls.Add(Me.cmdPrintPanen)
        Me.tabInput.Controls.Add(Me.btnDelete)
        Me.tabInput.Controls.Add(Me.txtChange)
        Me.tabInput.Controls.Add(Me.GroupBox3)
        Me.tabInput.Controls.Add(Me.btnReset)
        Me.tabInput.Controls.Add(Me.GroupBox1)
        Me.tabInput.Controls.Add(Me.btnClose)
        Me.tabInput.Controls.Add(Me.btnSaveAll)
        Me.tabInput.Controls.Add(Me.btnEditOrUpdate)
        Me.tabInput.Controls.Add(Me.lblDailyTeamActivtyID)
        Me.tabInput.Location = New System.Drawing.Point(4, 29)
        Me.tabInput.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabInput.Name = "tabInput"
        Me.tabInput.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabInput.Size = New System.Drawing.Size(1423, 895)
        Me.tabInput.TabIndex = 0
        Me.tabInput.Text = "Daily Team Activity"
        Me.tabInput.UseVisualStyleBackColor = True
        '
        'cmdPrintLain
        '
        Me.cmdPrintLain.BackgroundImage = CType(resources.GetObject("cmdPrintLain.BackgroundImage"), System.Drawing.Image)
        Me.cmdPrintLain.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdPrintLain.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintLain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrintLain.Location = New System.Drawing.Point(1065, 343)
        Me.cmdPrintLain.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdPrintLain.Name = "cmdPrintLain"
        Me.cmdPrintLain.Size = New System.Drawing.Size(288, 38)
        Me.cmdPrintLain.TabIndex = 170
        Me.cmdPrintLain.Text = "Print Laporan Harian Lain"
        Me.cmdPrintLain.UseVisualStyleBackColor = True
        '
        'cmdPrintDeres
        '
        Me.cmdPrintDeres.BackgroundImage = CType(resources.GetObject("cmdPrintDeres.BackgroundImage"), System.Drawing.Image)
        Me.cmdPrintDeres.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdPrintDeres.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintDeres.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrintDeres.Location = New System.Drawing.Point(768, 343)
        Me.cmdPrintDeres.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdPrintDeres.Name = "cmdPrintDeres"
        Me.cmdPrintDeres.Size = New System.Drawing.Size(288, 38)
        Me.cmdPrintDeres.TabIndex = 169
        Me.cmdPrintDeres.Text = "Print Laporan Harian Deres"
        Me.cmdPrintDeres.UseVisualStyleBackColor = True
        '
        'cmdPrintPanen
        '
        Me.cmdPrintPanen.BackgroundImage = CType(resources.GetObject("cmdPrintPanen.BackgroundImage"), System.Drawing.Image)
        Me.cmdPrintPanen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdPrintPanen.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintPanen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrintPanen.Location = New System.Drawing.Point(471, 343)
        Me.cmdPrintPanen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdPrintPanen.Name = "cmdPrintPanen"
        Me.cmdPrintPanen.Size = New System.Drawing.Size(288, 38)
        Me.cmdPrintPanen.TabIndex = 168
        Me.cmdPrintPanen.Text = "Print Laporan Harian Panen"
        Me.cmdPrintPanen.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnDelete.Image = Global.BSP.My.Resources.Resources.Close_32
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(320, 343)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(142, 38)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtChange
        '
        Me.txtChange.Location = New System.Drawing.Point(1368, 825)
        Me.txtChange.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Size = New System.Drawing.Size(25, 26)
        Me.txtChange.TabIndex = 164
        Me.txtChange.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.dgvDailyTeamActivity)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(9, 391)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(1386, 425)
        Me.GroupBox3.TabIndex = 143
        Me.GroupBox3.TabStop = False
        '
        'dgvDailyTeamActivity
        '
        Me.dgvDailyTeamActivity.AllowUserToAddRows = False
        Me.dgvDailyTeamActivity.AllowUserToDeleteRows = False
        Me.dgvDailyTeamActivity.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver
        Me.dgvDailyTeamActivity.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDailyTeamActivity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDailyTeamActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDailyTeamActivity.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDailyTeamActivity.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvDailyTeamActivity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDailyTeamActivity.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDailyTeamActivity.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDailyTeamActivity.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDailyTeamActivity.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvDailyTeamActivity.EnableHeadersVisualStyles = False
        Me.dgvDailyTeamActivity.GridColor = System.Drawing.Color.Gray
        Me.dgvDailyTeamActivity.Location = New System.Drawing.Point(18, 23)
        Me.dgvDailyTeamActivity.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvDailyTeamActivity.MultiSelect = False
        Me.dgvDailyTeamActivity.Name = "dgvDailyTeamActivity"
        Me.dgvDailyTeamActivity.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDailyTeamActivity.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDailyTeamActivity.RowHeadersVisible = False
        Me.dgvDailyTeamActivity.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvDailyTeamActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDailyTeamActivity.ShowCellErrors = False
        Me.dgvDailyTeamActivity.Size = New System.Drawing.Size(1359, 386)
        Me.dgvDailyTeamActivity.TabIndex = 7
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(172, 343)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(142, 38)
        Me.btnReset.TabIndex = 7
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnModifyTeam)
        Me.GroupBox1.Controls.Add(Me.lblMandorNik)
        Me.GroupBox1.Controls.Add(Me.lblKraniNik)
        Me.GroupBox1.Controls.Add(Me.btnGenerateTeam)
        Me.GroupBox1.Controls.Add(Me.txtTeam)
        Me.GroupBox1.Controls.Add(Me.lblInfo)
        Me.GroupBox1.Controls.Add(Me.lblKraniName)
        Me.GroupBox1.Controls.Add(Me.cmbActivity)
        Me.GroupBox1.Controls.Add(Me.lblMandorName)
        Me.GroupBox1.Controls.Add(Me.lblTeamCode)
        Me.GroupBox1.Controls.Add(Me.dtpRDate)
        Me.GroupBox1.Controls.Add(Me.lblKraniId)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblMandorId)
        Me.GroupBox1.Controls.Add(Me.lblTeam)
        Me.GroupBox1.Controls.Add(Me.txtKraniNik)
        Me.GroupBox1.Controls.Add(Me.btnKraniView)
        Me.GroupBox1.Controls.Add(Me.btnmandorView)
        Me.GroupBox1.Controls.Add(Me.lblDate)
        Me.GroupBox1.Controls.Add(Me.lblActivity)
        Me.GroupBox1.Controls.Add(Me.lblAttCode)
        Me.GroupBox1.Controls.Add(Me.lblColon1)
        Me.GroupBox1.Controls.Add(Me.lblColon2)
        Me.GroupBox1.Controls.Add(Me.lblColon8)
        Me.GroupBox1.Controls.Add(Me.lblColon4)
        Me.GroupBox1.Controls.Add(Me.lblLocation)
        Me.GroupBox1.Controls.Add(Me.txtMandorNik)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1386, 325)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        '
        'btnModifyTeam
        '
        Me.btnModifyTeam.BackgroundImage = CType(resources.GetObject("btnModifyTeam.BackgroundImage"), System.Drawing.Image)
        Me.btnModifyTeam.Enabled = False
        Me.btnModifyTeam.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnModifyTeam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModifyTeam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModifyTeam.Location = New System.Drawing.Point(609, 49)
        Me.btnModifyTeam.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnModifyTeam.Name = "btnModifyTeam"
        Me.btnModifyTeam.Size = New System.Drawing.Size(160, 38)
        Me.btnModifyTeam.TabIndex = 167
        Me.btnModifyTeam.Text = "&Modify Team"
        Me.btnModifyTeam.UseVisualStyleBackColor = True
        '
        'lblMandorNik
        '
        Me.lblMandorNik.AutoSize = True
        Me.lblMandorNik.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMandorNik.ForeColor = System.Drawing.Color.Blue
        Me.lblMandorNik.Location = New System.Drawing.Point(526, 203)
        Me.lblMandorNik.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMandorNik.Name = "lblMandorNik"
        Me.lblMandorNik.Size = New System.Drawing.Size(0, 20)
        Me.lblMandorNik.TabIndex = 165
        '
        'lblKraniNik
        '
        Me.lblKraniNik.AutoSize = True
        Me.lblKraniNik.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKraniNik.ForeColor = System.Drawing.Color.Blue
        Me.lblKraniNik.Location = New System.Drawing.Point(530, 251)
        Me.lblKraniNik.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKraniNik.Name = "lblKraniNik"
        Me.lblKraniNik.Size = New System.Drawing.Size(0, 20)
        Me.lblKraniNik.TabIndex = 166
        '
        'btnGenerateTeam
        '
        Me.btnGenerateTeam.BackgroundImage = CType(resources.GetObject("btnGenerateTeam.BackgroundImage"), System.Drawing.Image)
        Me.btnGenerateTeam.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGenerateTeam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateTeam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerateTeam.Location = New System.Drawing.Point(440, 49)
        Me.btnGenerateTeam.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGenerateTeam.Name = "btnGenerateTeam"
        Me.btnGenerateTeam.Size = New System.Drawing.Size(160, 38)
        Me.btnGenerateTeam.TabIndex = 1
        Me.btnGenerateTeam.Text = "&Generate Team"
        Me.btnGenerateTeam.UseVisualStyleBackColor = True
        '
        'txtTeam
        '
        Me.txtTeam.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTeam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTeam.Enabled = False
        Me.txtTeam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeam.Location = New System.Drawing.Point(213, 102)
        Me.txtTeam.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTeam.MaxLength = 50
        Me.txtTeam.Name = "txtTeam"
        Me.txtTeam.Size = New System.Drawing.Size(202, 28)
        Me.txtTeam.TabIndex = 2
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Red
        Me.lblInfo.Location = New System.Drawing.Point(435, 109)
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(515, 20)
        Me.lblInfo.TabIndex = 164
        Me.lblInfo.Text = "Team Name already in Daily Attendance ( View Only)"
        Me.lblInfo.Visible = False
        '
        'lblKraniName
        '
        Me.lblKraniName.AutoSize = True
        Me.lblKraniName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKraniName.ForeColor = System.Drawing.Color.Blue
        Me.lblKraniName.Location = New System.Drawing.Point(489, 254)
        Me.lblKraniName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKraniName.Name = "lblKraniName"
        Me.lblKraniName.Size = New System.Drawing.Size(125, 20)
        Me.lblKraniName.TabIndex = 162
        Me.lblKraniName.Text = "lblKraniName"
        '
        'cmbActivity
        '
        Me.cmbActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActivity.FormattingEnabled = True
        Me.cmbActivity.Location = New System.Drawing.Point(213, 149)
        Me.cmbActivity.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbActivity.Name = "cmbActivity"
        Me.cmbActivity.Size = New System.Drawing.Size(200, 28)
        Me.cmbActivity.TabIndex = 3
        '
        'lblMandorName
        '
        Me.lblMandorName.AutoSize = True
        Me.lblMandorName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMandorName.ForeColor = System.Drawing.Color.Blue
        Me.lblMandorName.Location = New System.Drawing.Point(489, 203)
        Me.lblMandorName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMandorName.Name = "lblMandorName"
        Me.lblMandorName.Size = New System.Drawing.Size(143, 20)
        Me.lblMandorName.TabIndex = 156
        Me.lblMandorName.Text = "lblMandorName"
        '
        'lblTeamCode
        '
        Me.lblTeamCode.AutoSize = True
        Me.lblTeamCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTeamCode.ForeColor = System.Drawing.Color.Blue
        Me.lblTeamCode.Location = New System.Drawing.Point(314, 109)
        Me.lblTeamCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTeamCode.Name = "lblTeamCode"
        Me.lblTeamCode.Size = New System.Drawing.Size(99, 20)
        Me.lblTeamCode.TabIndex = 155
        Me.lblTeamCode.Text = "NOTVALID"
        Me.lblTeamCode.Visible = False
        '
        'dtpRDate
        '
        Me.dtpRDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRDate.Location = New System.Drawing.Point(214, 52)
        Me.dtpRDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpRDate.Name = "dtpRDate"
        Me.dtpRDate.Size = New System.Drawing.Size(200, 26)
        Me.dtpRDate.TabIndex = 0
        '
        'lblKraniId
        '
        Me.lblKraniId.AutoSize = True
        Me.lblKraniId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKraniId.ForeColor = System.Drawing.Color.Blue
        Me.lblKraniId.Location = New System.Drawing.Point(994, 137)
        Me.lblKraniId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKraniId.Name = "lblKraniId"
        Me.lblKraniId.Size = New System.Drawing.Size(94, 20)
        Me.lblKraniId.TabIndex = 161
        Me.lblKraniId.Text = "lblKraniId"
        Me.lblKraniId.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(186, 109)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 20)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = ":"
        '
        'lblMandorId
        '
        Me.lblMandorId.AutoSize = True
        Me.lblMandorId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMandorId.ForeColor = System.Drawing.Color.Blue
        Me.lblMandorId.Location = New System.Drawing.Point(994, 109)
        Me.lblMandorId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMandorId.Name = "lblMandorId"
        Me.lblMandorId.Size = New System.Drawing.Size(112, 20)
        Me.lblMandorId.TabIndex = 160
        Me.lblMandorId.Text = "lblMandorId"
        Me.lblMandorId.Visible = False
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTeam.ForeColor = System.Drawing.Color.Black
        Me.lblTeam.Location = New System.Drawing.Point(27, 109)
        Me.lblTeam.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(54, 20)
        Me.lblTeam.TabIndex = 141
        Me.lblTeam.Text = "Team"
        '
        'txtKraniNik
        '
        Me.txtKraniNik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKraniNik.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKraniNik.Location = New System.Drawing.Point(212, 249)
        Me.txtKraniNik.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtKraniNik.MaxLength = 50
        Me.txtKraniNik.Name = "txtKraniNik"
        Me.txtKraniNik.Size = New System.Drawing.Size(202, 28)
        Me.txtKraniNik.TabIndex = 5
        '
        'btnKraniView
        '
        Me.btnKraniView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKraniView.Image = CType(resources.GetObject("btnKraniView.Image"), System.Drawing.Image)
        Me.btnKraniView.Location = New System.Drawing.Point(424, 242)
        Me.btnKraniView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnKraniView.Name = "btnKraniView"
        Me.btnKraniView.Size = New System.Drawing.Size(46, 40)
        Me.btnKraniView.TabIndex = 11
        Me.btnKraniView.TabStop = False
        Me.btnKraniView.UseVisualStyleBackColor = True
        '
        'btnmandorView
        '
        Me.btnmandorView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmandorView.Image = CType(resources.GetObject("btnmandorView.Image"), System.Drawing.Image)
        Me.btnmandorView.Location = New System.Drawing.Point(424, 192)
        Me.btnmandorView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnmandorView.Name = "btnmandorView"
        Me.btnmandorView.Size = New System.Drawing.Size(46, 40)
        Me.btnmandorView.TabIndex = 7
        Me.btnmandorView.TabStop = False
        Me.btnmandorView.UseVisualStyleBackColor = True
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(27, 57)
        Me.lblDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(49, 20)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Date"
        '
        'lblActivity
        '
        Me.lblActivity.AutoSize = True
        Me.lblActivity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivity.ForeColor = System.Drawing.Color.Black
        Me.lblActivity.Location = New System.Drawing.Point(27, 154)
        Me.lblActivity.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblActivity.Name = "lblActivity"
        Me.lblActivity.Size = New System.Drawing.Size(74, 20)
        Me.lblActivity.TabIndex = 2
        Me.lblActivity.Text = "Activity"
        '
        'lblAttCode
        '
        Me.lblAttCode.AutoSize = True
        Me.lblAttCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttCode.ForeColor = System.Drawing.Color.Black
        Me.lblAttCode.Location = New System.Drawing.Point(27, 203)
        Me.lblAttCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAttCode.Name = "lblAttCode"
        Me.lblAttCode.Size = New System.Drawing.Size(72, 20)
        Me.lblAttCode.TabIndex = 4
        Me.lblAttCode.Text = "Mandor"
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(186, 57)
        Me.lblColon1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(16, 20)
        Me.lblColon1.TabIndex = 19
        Me.lblColon1.Text = ":"
        '
        'lblColon2
        '
        Me.lblColon2.AutoSize = True
        Me.lblColon2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon2.Location = New System.Drawing.Point(186, 154)
        Me.lblColon2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblColon2.Name = "lblColon2"
        Me.lblColon2.Size = New System.Drawing.Size(16, 20)
        Me.lblColon2.TabIndex = 21
        Me.lblColon2.Text = ":"
        '
        'lblColon8
        '
        Me.lblColon8.AutoSize = True
        Me.lblColon8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon8.Location = New System.Drawing.Point(186, 254)
        Me.lblColon8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblColon8.Name = "lblColon8"
        Me.lblColon8.Size = New System.Drawing.Size(16, 20)
        Me.lblColon8.TabIndex = 121
        Me.lblColon8.Text = ":"
        '
        'lblColon4
        '
        Me.lblColon4.AutoSize = True
        Me.lblColon4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon4.Location = New System.Drawing.Point(186, 203)
        Me.lblColon4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblColon4.Name = "lblColon4"
        Me.lblColon4.Size = New System.Drawing.Size(16, 20)
        Me.lblColon4.TabIndex = 23
        Me.lblColon4.Text = ":"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.Color.Black
        Me.lblLocation.Location = New System.Drawing.Point(27, 254)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(63, 20)
        Me.lblLocation.TabIndex = 119
        Me.lblLocation.Text = "Kerani"
        '
        'txtMandorNik
        '
        Me.txtMandorNik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMandorNik.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMandorNik.Location = New System.Drawing.Point(213, 200)
        Me.txtMandorNik.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMandorNik.Name = "txtMandorNik"
        Me.txtMandorNik.Size = New System.Drawing.Size(202, 28)
        Me.txtMandorNik.TabIndex = 4
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(172, 825)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(165, 46)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = CType(resources.GetObject("btnSaveAll.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(9, 825)
        Me.btnSaveAll.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(158, 46)
        Me.btnSaveAll.TabIndex = 8
        Me.btnSaveAll.Text = "&Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnEditOrUpdate
        '
        Me.btnEditOrUpdate.BackgroundImage = CType(resources.GetObject("btnEditOrUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnEditOrUpdate.Enabled = False
        Me.btnEditOrUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditOrUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditOrUpdate.Image = CType(resources.GetObject("btnEditOrUpdate.Image"), System.Drawing.Image)
        Me.btnEditOrUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditOrUpdate.Location = New System.Drawing.Point(9, 343)
        Me.btnEditOrUpdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnEditOrUpdate.Name = "btnEditOrUpdate"
        Me.btnEditOrUpdate.Size = New System.Drawing.Size(160, 38)
        Me.btnEditOrUpdate.TabIndex = 6
        Me.btnEditOrUpdate.Text = "&Update"
        Me.btnEditOrUpdate.UseVisualStyleBackColor = True
        '
        'lblDailyTeamActivtyID
        '
        Me.lblDailyTeamActivtyID.AutoSize = True
        Me.lblDailyTeamActivtyID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDailyTeamActivtyID.ForeColor = System.Drawing.Color.Black
        Me.lblDailyTeamActivtyID.Location = New System.Drawing.Point(1108, 171)
        Me.lblDailyTeamActivtyID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDailyTeamActivtyID.Name = "lblDailyTeamActivtyID"
        Me.lblDailyTeamActivtyID.Size = New System.Drawing.Size(54, 20)
        Me.lblDailyTeamActivtyID.TabIndex = 165
        Me.lblDailyTeamActivtyID.Text = "Team"
        Me.lblDailyTeamActivtyID.Visible = False
        '
        'tcDailyAttendance
        '
        Me.tcDailyAttendance.Controls.Add(Me.tabInput)
        Me.tcDailyAttendance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcDailyAttendance.Location = New System.Drawing.Point(0, 0)
        Me.tcDailyAttendance.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tcDailyAttendance.Name = "tcDailyAttendance"
        Me.tcDailyAttendance.SelectedIndex = 0
        Me.tcDailyAttendance.Size = New System.Drawing.Size(1431, 928)
        Me.tcDailyAttendance.TabIndex = 1
        '
        'DailyTeamActivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1431, 928)
        Me.Controls.Add(Me.tcDailyAttendance)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "DailyTeamActivity"
        Me.Text = "Daily Team Activity"
        Me.tabInput.ResumeLayout(False)
        Me.tabInput.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvDailyTeamActivity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tcDailyAttendance.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabInput As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDailyTeamActivity As System.Windows.Forms.DataGridView
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMandorName As System.Windows.Forms.Label
    Friend WithEvents lblTeamCode As System.Windows.Forms.Label
    Friend WithEvents dtpRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTeam As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents txtKraniNik As System.Windows.Forms.TextBox
    Friend WithEvents btnKraniView As System.Windows.Forms.Button
    Friend WithEvents btnmandorView As System.Windows.Forms.Button
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblActivity As System.Windows.Forms.Label
    Friend WithEvents lblAttCode As System.Windows.Forms.Label
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents lblColon2 As System.Windows.Forms.Label
    Friend WithEvents lblColon8 As System.Windows.Forms.Label
    Friend WithEvents lblColon4 As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents txtMandorNik As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnEditOrUpdate As System.Windows.Forms.Button
    Friend WithEvents tcDailyAttendance As System.Windows.Forms.TabControl
    Friend WithEvents cmbActivity As System.Windows.Forms.ComboBox
    Friend WithEvents txtChange As System.Windows.Forms.TextBox
    Friend WithEvents lblKraniId As System.Windows.Forms.Label
    Friend WithEvents lblMandorId As System.Windows.Forms.Label
    Friend WithEvents lblKraniName As System.Windows.Forms.Label
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents lblDailyTeamActivtyID As System.Windows.Forms.Label
    Friend WithEvents btnGenerateTeam As System.Windows.Forms.Button
    Friend WithEvents lblMandorNik As System.Windows.Forms.Label
    Friend WithEvents lblKraniNik As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnModifyTeam As System.Windows.Forms.Button
    Friend WithEvents cmdPrintPanen As System.Windows.Forms.Button
    Friend WithEvents cmdPrintLain As System.Windows.Forms.Button
    Friend WithEvents cmdPrintDeres As System.Windows.Forms.Button
End Class

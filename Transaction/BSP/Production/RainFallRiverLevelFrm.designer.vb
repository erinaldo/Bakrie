<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RainFallRiverLevelFrm
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RainFallRiverLevelFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tcRainFallRiver = New System.Windows.Forms.TabControl
        Me.tpRainFallRiverSave = New System.Windows.Forms.TabPage
        Me.panCPO = New System.Windows.Forms.Panel
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblMin = New System.Windows.Forms.Label
        Me.cmbCPOLogStartMin = New System.Windows.Forms.ComboBox
        Me.lblHr1 = New System.Windows.Forms.Label
        Me.cmbCPOLogStartHrs = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRiverLevel = New System.Windows.Forms.TextBox
        Me.lblRiverLevel = New System.Windows.Forms.Label
        Me.txtRain = New System.Windows.Forms.TextBox
        Me.lblRain = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.lblTime = New System.Windows.Forms.Label
        Me.dtpRainFallDate = New System.Windows.Forms.DateTimePicker
        Me.lblDate = New System.Windows.Forms.Label
        Me.tpRainFallView = New System.Windows.Forms.TabPage
        Me.dgvRainFallView = New System.Windows.Forms.DataGridView
        Me.dgclRDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclRainRiverId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclRTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclRain = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclRiverLevel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsRainFall = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.dtpRainFallViewDate = New System.Windows.Forms.DateTimePicker
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label45 = New System.Windows.Forms.Label
        Me.chkRainFallDate = New System.Windows.Forms.CheckBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.btnViewSearch = New System.Windows.Forms.Button
        Me.cmbAdjustViewStatus = New System.Windows.Forms.ComboBox
        Me.lblViewStatus = New System.Windows.Forms.Label
        Me.lblSearch = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.tcRainFallRiver.SuspendLayout()
        Me.tpRainFallRiverSave.SuspendLayout()
        Me.panCPO.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tpRainFallView.SuspendLayout()
        CType(Me.dgvRainFallView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsRainFall.SuspendLayout()
        Me.PnlSearch.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcRainFallRiver
        '
        Me.tcRainFallRiver.Controls.Add(Me.tpRainFallRiverSave)
        Me.tcRainFallRiver.Controls.Add(Me.tpRainFallView)
        Me.tcRainFallRiver.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcRainFallRiver.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcRainFallRiver.Location = New System.Drawing.Point(0, 0)
        Me.tcRainFallRiver.Name = "tcRainFallRiver"
        Me.tcRainFallRiver.SelectedIndex = 0
        Me.tcRainFallRiver.Size = New System.Drawing.Size(695, 313)
        Me.tcRainFallRiver.TabIndex = 3
        Me.tcRainFallRiver.TabStop = False
        '
        'tpRainFallRiverSave
        '
        Me.tpRainFallRiverSave.AutoScroll = True
        Me.tpRainFallRiverSave.BackgroundImage = CType(resources.GetObject("tpRainFallRiverSave.BackgroundImage"), System.Drawing.Image)
        Me.tpRainFallRiverSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpRainFallRiverSave.Controls.Add(Me.panCPO)
        Me.tpRainFallRiverSave.Location = New System.Drawing.Point(4, 22)
        Me.tpRainFallRiverSave.Name = "tpRainFallRiverSave"
        Me.tpRainFallRiverSave.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRainFallRiverSave.Size = New System.Drawing.Size(687, 287)
        Me.tpRainFallRiverSave.TabIndex = 0
        Me.tpRainFallRiverSave.Text = "RainFall"
        Me.tpRainFallRiverSave.UseVisualStyleBackColor = True
        '
        'panCPO
        '
        Me.panCPO.AutoScroll = True
        Me.panCPO.BackColor = System.Drawing.Color.Transparent
        Me.panCPO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panCPO.Controls.Add(Me.btnReset)
        Me.panCPO.Controls.Add(Me.btnClose)
        Me.panCPO.Controls.Add(Me.btnSave)
        Me.panCPO.Controls.Add(Me.GroupBox3)
        Me.panCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panCPO.Location = New System.Drawing.Point(3, 3)
        Me.panCPO.Name = "panCPO"
        Me.panCPO.Size = New System.Drawing.Size(681, 281)
        Me.panCPO.TabIndex = 0
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(374, 207)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(131, 25)
        Me.btnReset.TabIndex = 308
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(510, 207)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(114, 25)
        Me.btnClose.TabIndex = 309
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(254, 207)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(114, 25)
        Me.btnSave.TabIndex = 307
        Me.btnSave.Text = "Save "
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox3.Controls.Add(Me.lblMin)
        Me.GroupBox3.Controls.Add(Me.cmbCPOLogStartMin)
        Me.GroupBox3.Controls.Add(Me.lblHr1)
        Me.GroupBox3.Controls.Add(Me.cmbCPOLogStartHrs)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtRiverLevel)
        Me.GroupBox3.Controls.Add(Me.lblRiverLevel)
        Me.GroupBox3.Controls.Add(Me.txtRain)
        Me.GroupBox3.Controls.Add(Me.lblRain)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.lblTime)
        Me.GroupBox3.Controls.Add(Me.dtpRainFallDate)
        Me.GroupBox3.Controls.Add(Me.lblDate)
        Me.GroupBox3.Location = New System.Drawing.Point(2, -1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(557, 178)
        Me.GroupBox3.TabIndex = 301
        Me.GroupBox3.TabStop = False
        '
        'lblMin
        '
        Me.lblMin.AutoSize = True
        Me.lblMin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMin.ForeColor = System.Drawing.Color.Black
        Me.lblMin.Location = New System.Drawing.Point(348, 55)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(28, 13)
        Me.lblMin.TabIndex = 518
        Me.lblMin.Text = "min"
        '
        'cmbCPOLogStartMin
        '
        Me.cmbCPOLogStartMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPOLogStartMin.FormattingEnabled = True
        Me.cmbCPOLogStartMin.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cmbCPOLogStartMin.Location = New System.Drawing.Point(287, 51)
        Me.cmbCPOLogStartMin.Name = "cmbCPOLogStartMin"
        Me.cmbCPOLogStartMin.Size = New System.Drawing.Size(53, 21)
        Me.cmbCPOLogStartMin.TabIndex = 304
        '
        'lblHr1
        '
        Me.lblHr1.AutoSize = True
        Me.lblHr1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHr1.ForeColor = System.Drawing.Color.Black
        Me.lblHr1.Location = New System.Drawing.Point(262, 55)
        Me.lblHr1.Name = "lblHr1"
        Me.lblHr1.Size = New System.Drawing.Size(19, 13)
        Me.lblHr1.TabIndex = 316
        Me.lblHr1.Text = "hr"
        '
        'cmbCPOLogStartHrs
        '
        Me.cmbCPOLogStartHrs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPOLogStartHrs.FormattingEnabled = True
        Me.cmbCPOLogStartHrs.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cmbCPOLogStartHrs.Location = New System.Drawing.Point(206, 51)
        Me.cmbCPOLogStartHrs.Name = "cmbCPOLogStartHrs"
        Me.cmbCPOLogStartHrs.Size = New System.Drawing.Size(47, 21)
        Me.cmbCPOLogStartHrs.TabIndex = 303
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(174, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 312
        Me.Label1.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(174, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 309
        Me.Label4.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(174, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 308
        Me.Label6.Text = ":"
        '
        'txtRiverLevel
        '
        Me.txtRiverLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRiverLevel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRiverLevel.Location = New System.Drawing.Point(206, 106)
        Me.txtRiverLevel.MaxLength = 18
        Me.txtRiverLevel.Name = "txtRiverLevel"
        Me.txtRiverLevel.Size = New System.Drawing.Size(156, 21)
        Me.txtRiverLevel.TabIndex = 306
        '
        'lblRiverLevel
        '
        Me.lblRiverLevel.AutoSize = True
        Me.lblRiverLevel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRiverLevel.ForeColor = System.Drawing.Color.Black
        Me.lblRiverLevel.Location = New System.Drawing.Point(28, 110)
        Me.lblRiverLevel.Name = "lblRiverLevel"
        Me.lblRiverLevel.Size = New System.Drawing.Size(90, 13)
        Me.lblRiverLevel.TabIndex = 307
        Me.lblRiverLevel.Text = "River Level(M)"
        '
        'txtRain
        '
        Me.txtRain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRain.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRain.Location = New System.Drawing.Point(206, 78)
        Me.txtRain.MaxLength = 18
        Me.txtRain.Name = "txtRain"
        Me.txtRain.Size = New System.Drawing.Size(157, 21)
        Me.txtRain.TabIndex = 305
        '
        'lblRain
        '
        Me.lblRain.AutoSize = True
        Me.lblRain.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRain.ForeColor = System.Drawing.Color.Black
        Me.lblRain.Location = New System.Drawing.Point(28, 82)
        Me.lblRain.Name = "lblRain"
        Me.lblRain.Size = New System.Drawing.Size(64, 13)
        Me.lblRain.TabIndex = 306
        Me.lblRain.Text = "Rain(mm)"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Red
        Me.Label40.Location = New System.Drawing.Point(174, 55)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(11, 13)
        Me.Label40.TabIndex = 304
        Me.Label40.Text = ":"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.Red
        Me.lblTime.Location = New System.Drawing.Point(28, 55)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(69, 13)
        Me.lblTime.TabIndex = 303
        Me.lblTime.Text = "Time Enter"
        '
        'dtpRainFallDate
        '
        Me.dtpRainFallDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpRainFallDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRainFallDate.Location = New System.Drawing.Point(206, 22)
        Me.dtpRainFallDate.Name = "dtpRainFallDate"
        Me.dtpRainFallDate.Size = New System.Drawing.Size(157, 21)
        Me.dtpRainFallDate.TabIndex = 302
        Me.dtpRainFallDate.Value = New Date(2009, 11, 9, 0, 0, 0, 0)
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Red
        Me.lblDate.Location = New System.Drawing.Point(28, 26)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(34, 13)
        Me.lblDate.TabIndex = 170
        Me.lblDate.Text = "Date"
        '
        'tpRainFallView
        '
        Me.tpRainFallView.AutoScroll = True
        Me.tpRainFallView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tpRainFallView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpRainFallView.Controls.Add(Me.dgvRainFallView)
        Me.tpRainFallView.Controls.Add(Me.PnlSearch)
        Me.tpRainFallView.Controls.Add(Me.cmbAdjustViewStatus)
        Me.tpRainFallView.Controls.Add(Me.lblViewStatus)
        Me.tpRainFallView.Controls.Add(Me.lblSearch)
        Me.tpRainFallView.Controls.Add(Me.Label13)
        Me.tpRainFallView.Location = New System.Drawing.Point(4, 22)
        Me.tpRainFallView.Name = "tpRainFallView"
        Me.tpRainFallView.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRainFallView.Size = New System.Drawing.Size(687, 287)
        Me.tpRainFallView.TabIndex = 1
        Me.tpRainFallView.Text = "View"
        Me.tpRainFallView.UseVisualStyleBackColor = True
        '
        'dgvRainFallView
        '
        Me.dgvRainFallView.AllowUserToAddRows = False
        Me.dgvRainFallView.AllowUserToDeleteRows = False
        Me.dgvRainFallView.AllowUserToResizeRows = False
        Me.dgvRainFallView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvRainFallView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvRainFallView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRainFallView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRainFallView.ColumnHeadersHeight = 30
        Me.dgvRainFallView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclRDate, Me.dgclRainRiverId, Me.dgclRTime, Me.dgclRain, Me.dgclRiverLevel})
        Me.dgvRainFallView.ContextMenuStrip = Me.cmsRainFall
        Me.dgvRainFallView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRainFallView.EnableHeadersVisualStyles = False
        Me.dgvRainFallView.GridColor = System.Drawing.Color.Gray
        Me.dgvRainFallView.Location = New System.Drawing.Point(3, 108)
        Me.dgvRainFallView.MultiSelect = False
        Me.dgvRainFallView.Name = "dgvRainFallView"
        Me.dgvRainFallView.ReadOnly = True
        Me.dgvRainFallView.RowHeadersVisible = False
        Me.dgvRainFallView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRainFallView.Size = New System.Drawing.Size(681, 176)
        Me.dgvRainFallView.TabIndex = 416
        Me.dgvRainFallView.TabStop = False
        '
        'dgclRDate
        '
        Me.dgclRDate.DataPropertyName = "RDate"
        Me.dgclRDate.HeaderText = "Date"
        Me.dgclRDate.Name = "dgclRDate"
        Me.dgclRDate.ReadOnly = True
        '
        'dgclRainRiverId
        '
        Me.dgclRainRiverId.DataPropertyName = "RainRiverID"
        Me.dgclRainRiverId.HeaderText = "RainRiverId"
        Me.dgclRainRiverId.Name = "dgclRainRiverId"
        Me.dgclRainRiverId.ReadOnly = True
        Me.dgclRainRiverId.Visible = False
        '
        'dgclRTime
        '
        Me.dgclRTime.DataPropertyName = "RTime"
        DataGridViewCellStyle2.Format = "t"
        DataGridViewCellStyle2.NullValue = "t"
        Me.dgclRTime.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgclRTime.HeaderText = "Time"
        Me.dgclRTime.Name = "dgclRTime"
        Me.dgclRTime.ReadOnly = True
        '
        'dgclRain
        '
        Me.dgclRain.DataPropertyName = "Rain"
        Me.dgclRain.HeaderText = "Rain"
        Me.dgclRain.Name = "dgclRain"
        Me.dgclRain.ReadOnly = True
        '
        'dgclRiverLevel
        '
        Me.dgclRiverLevel.DataPropertyName = "RiverLevel"
        Me.dgclRiverLevel.HeaderText = "River Level"
        Me.dgclRiverLevel.Name = "dgclRiverLevel"
        Me.dgclRiverLevel.ReadOnly = True
        '
        'cmsRainFall
        '
        Me.cmsRainFall.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsRainFall.Name = "cmsIPR"
        Me.cmsRainFall.Size = New System.Drawing.Size(117, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PnlSearch
        '
        Me.PnlSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PnlSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.PnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlSearch.BorderColor = System.Drawing.Color.Gray
        Me.PnlSearch.CaptionColorOne = System.Drawing.Color.White
        Me.PnlSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlSearch.CaptionSize = 40
        Me.PnlSearch.CaptionText = "Search Rain Fall River"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.dtpRainFallViewDate)
        Me.PnlSearch.Controls.Add(Me.Panel2)
        Me.PnlSearch.Controls.Add(Me.Label45)
        Me.PnlSearch.Controls.Add(Me.chkRainFallDate)
        Me.PnlSearch.Controls.Add(Me.Label46)
        Me.PnlSearch.Controls.Add(Me.btnViewSearch)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(681, 105)
        Me.PnlSearch.TabIndex = 350
        '
        'dtpRainFallViewDate
        '
        Me.dtpRainFallViewDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpRainFallViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRainFallViewDate.Location = New System.Drawing.Point(114, 67)
        Me.dtpRainFallViewDate.Name = "dtpRainFallViewDate"
        Me.dtpRainFallViewDate.Size = New System.Drawing.Size(157, 21)
        Me.dtpRainFallViewDate.TabIndex = 352
        Me.dtpRainFallViewDate.Value = New Date(2009, 11, 9, 0, 0, 0, 0)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Location = New System.Drawing.Point(0, 157)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1311, 425)
        Me.Panel2.TabIndex = 33
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1304, 572)
        Me.DataGridView1.TabIndex = 31
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label45.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label45.ForeColor = System.Drawing.Color.DimGray
        Me.Label45.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label45.Location = New System.Drawing.Point(2, 45)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(72, 13)
        Me.Label45.TabIndex = 69
        Me.Label45.Text = "Search By"
        '
        'chkRainFallDate
        '
        Me.chkRainFallDate.AutoSize = True
        Me.chkRainFallDate.Location = New System.Drawing.Point(114, 45)
        Me.chkRainFallDate.Name = "chkRainFallDate"
        Me.chkRainFallDate.Size = New System.Drawing.Size(57, 17)
        Me.chkRainFallDate.TabIndex = 351
        Me.chkRainFallDate.Text = " Date"
        Me.chkRainFallDate.UseVisualStyleBackColor = True
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label46.Location = New System.Drawing.Point(93, 45)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(12, 14)
        Me.Label46.TabIndex = 70
        Me.Label46.Text = ":"
        '
        'btnViewSearch
        '
        Me.btnViewSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnViewSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnViewSearch.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnViewSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnViewSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnViewSearch.Image = CType(resources.GetObject("btnViewSearch.Image"), System.Drawing.Image)
        Me.btnViewSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnViewSearch.Location = New System.Drawing.Point(290, 64)
        Me.btnViewSearch.Name = "btnViewSearch"
        Me.btnViewSearch.Size = New System.Drawing.Size(135, 26)
        Me.btnViewSearch.TabIndex = 353
        Me.btnViewSearch.Text = "Search"
        Me.btnViewSearch.UseVisualStyleBackColor = True
        '
        'cmbAdjustViewStatus
        '
        Me.cmbAdjustViewStatus.FormattingEnabled = True
        Me.cmbAdjustViewStatus.Items.AddRange(New Object() {"SELECT ALL", "OPEN", "MANAGER APPROVED", "REJECTED"})
        Me.cmbAdjustViewStatus.Location = New System.Drawing.Point(401, -25)
        Me.cmbAdjustViewStatus.Name = "cmbAdjustViewStatus"
        Me.cmbAdjustViewStatus.Size = New System.Drawing.Size(177, 21)
        Me.cmbAdjustViewStatus.TabIndex = 413
        Me.cmbAdjustViewStatus.Text = "SELECT ALL"
        '
        'lblViewStatus
        '
        Me.lblViewStatus.AutoSize = True
        Me.lblViewStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblViewStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblViewStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblViewStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblViewStatus.Location = New System.Drawing.Point(400, -47)
        Me.lblViewStatus.Name = "lblViewStatus"
        Me.lblViewStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblViewStatus.TabIndex = 410
        Me.lblViewStatus.Text = "Status"
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearch.Location = New System.Drawing.Point(-82, -47)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(72, 13)
        Me.lblSearch.TabIndex = 407
        Me.lblSearch.Text = "Search By"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(9, -47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 14)
        Me.Label13.TabIndex = 408
        Me.Label13.Text = ":"
        '
        'RainFallRiverLevelFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(695, 313)
        Me.Controls.Add(Me.tcRainFallRiver)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "RainFallRiverLevelFrm"
        Me.Text = "RainFallRiverLevelFrm"
        Me.tcRainFallRiver.ResumeLayout(False)
        Me.tpRainFallRiverSave.ResumeLayout(False)
        Me.panCPO.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tpRainFallView.ResumeLayout(False)
        Me.tpRainFallView.PerformLayout()
        CType(Me.dgvRainFallView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsRainFall.ResumeLayout(False)
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcRainFallRiver As System.Windows.Forms.TabControl
    Friend WithEvents tpRainFallRiverSave As System.Windows.Forms.TabPage
    Friend WithEvents panCPO As System.Windows.Forms.Panel
    Friend WithEvents tpRainFallView As System.Windows.Forms.TabPage
    Friend WithEvents dgvRainFallView As System.Windows.Forms.DataGridView
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents chkRainFallDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents cmbAdjustViewStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblViewStatus As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpRainFallDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRiverLevel As System.Windows.Forms.TextBox
    Friend WithEvents lblRiverLevel As System.Windows.Forms.Label
    Friend WithEvents txtRain As System.Windows.Forms.TextBox
    Friend WithEvents lblRain As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmsRainFall As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbCPOLogStartMin As System.Windows.Forms.ComboBox
    Friend WithEvents lblHr1 As System.Windows.Forms.Label
    Friend WithEvents cmbCPOLogStartHrs As System.Windows.Forms.ComboBox
    Friend WithEvents dtpRainFallViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblMin As System.Windows.Forms.Label
    Friend WithEvents dgclRDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRainRiverId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRain As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRiverLevel As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

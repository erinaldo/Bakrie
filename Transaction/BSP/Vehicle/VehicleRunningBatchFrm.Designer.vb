Partial Class VehicleRunningBatchFrm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VehicleRunningBatchFrm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.plIB1 = New System.Windows.Forms.Panel
        Me.tcVehicleRunningBatch = New System.Windows.Forms.TabControl
        Me.tbpgAdd = New System.Windows.Forms.TabPage
        Me.gbGridAdd = New System.Windows.Forms.GroupBox
        Me.dgvVehicleBatchDetails = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHBatchDT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHRBatchHrsKm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VehicleCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grpSIV = New System.Windows.Forms.GroupBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.lblHrsOrKms = New System.Windows.Forms.Label
        Me.ibtnSearchVehicleCode = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnSaveOrUpdate = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.txtVehicleCode = New System.Windows.Forms.TextBox
        Me.txtBatchValue = New System.Windows.Forms.TextBox
        Me.lblBatchValue = New System.Windows.Forms.Label
        Me.lblVehicleCode = New System.Windows.Forms.Label
        Me.lblContractorValue = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.tbpgViewVRB = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgvVehicleCode = New System.Windows.Forms.DataGridView
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.rbDate = New System.Windows.Forms.RadioButton
        Me.rbVehicleCode = New System.Windows.Forms.RadioButton
        Me.dtpSearchBy = New System.Windows.Forms.DateTimePicker
        Me.txtVehicleCodeView = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.cmsDelete = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHWSCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.plIB1.SuspendLayout()
        Me.tcVehicleRunningBatch.SuspendLayout()
        Me.tbpgAdd.SuspendLayout()
        Me.gbGridAdd.SuspendLayout()
        CType(Me.dgvVehicleBatchDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSIV.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tbpgViewVRB.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvVehicleCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlSearch.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDelete.SuspendLayout()
        Me.SuspendLayout()
        '
        'plIB1
        '
        Me.plIB1.AutoScroll = True
        Me.plIB1.BackColor = System.Drawing.Color.Transparent
        Me.plIB1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.plIB1.Controls.Add(Me.tcVehicleRunningBatch)
        Me.plIB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plIB1.Location = New System.Drawing.Point(0, 0)
        Me.plIB1.Name = "plIB1"
        Me.plIB1.Size = New System.Drawing.Size(956, 457)
        Me.plIB1.TabIndex = 12
        '
        'tcVehicleRunningBatch
        '
        Me.tcVehicleRunningBatch.Controls.Add(Me.tbpgAdd)
        Me.tcVehicleRunningBatch.Controls.Add(Me.tbpgViewVRB)
        Me.tcVehicleRunningBatch.Location = New System.Drawing.Point(3, 3)
        Me.tcVehicleRunningBatch.Name = "tcVehicleRunningBatch"
        Me.tcVehicleRunningBatch.SelectedIndex = 0
        Me.tcVehicleRunningBatch.Size = New System.Drawing.Size(946, 447)
        Me.tcVehicleRunningBatch.TabIndex = 1
        '
        'tbpgAdd
        '
        Me.tbpgAdd.BackColor = System.Drawing.Color.Transparent
        Me.tbpgAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgAdd.Controls.Add(Me.gbGridAdd)
        Me.tbpgAdd.Controls.Add(Me.grpSIV)
        Me.tbpgAdd.Location = New System.Drawing.Point(4, 22)
        Me.tbpgAdd.Name = "tbpgAdd"
        Me.tbpgAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgAdd.Size = New System.Drawing.Size(938, 421)
        Me.tbpgAdd.TabIndex = 0
        Me.tbpgAdd.Text = "Vehicle Running Batch"
        Me.tbpgAdd.UseVisualStyleBackColor = True
        '
        'gbGridAdd
        '
        Me.gbGridAdd.Controls.Add(Me.dgvVehicleBatchDetails)
        Me.gbGridAdd.Location = New System.Drawing.Point(3, 161)
        Me.gbGridAdd.Name = "gbGridAdd"
        Me.gbGridAdd.Size = New System.Drawing.Size(923, 211)
        Me.gbGridAdd.TabIndex = 140
        Me.gbGridAdd.TabStop = False
        '
        'dgvVehicleBatchDetails
        '
        Me.dgvVehicleBatchDetails.AllowUserToAddRows = False
        Me.dgvVehicleBatchDetails.AllowUserToDeleteRows = False
        Me.dgvVehicleBatchDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvVehicleBatchDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvVehicleBatchDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVehicleBatchDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVehicleBatchDetails.ColumnHeadersHeight = 30
        Me.dgvVehicleBatchDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.VHBatchDT, Me.VHRBatchHrsKm, Me.VehicleCode})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVehicleBatchDetails.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVehicleBatchDetails.EnableHeadersVisualStyles = False
        Me.dgvVehicleBatchDetails.GridColor = System.Drawing.Color.Gray
        Me.dgvVehicleBatchDetails.Location = New System.Drawing.Point(0, 19)
        Me.dgvVehicleBatchDetails.MultiSelect = False
        Me.dgvVehicleBatchDetails.Name = "dgvVehicleBatchDetails"
        Me.dgvVehicleBatchDetails.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVehicleBatchDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVehicleBatchDetails.RowHeadersVisible = False
        Me.dgvVehicleBatchDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVehicleBatchDetails.Size = New System.Drawing.Size(500, 127)
        Me.dgvVehicleBatchDetails.TabIndex = 10
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 150
        '
        'VHBatchDT
        '
        Me.VHBatchDT.DataPropertyName = "VHBatchDT"
        Me.VHBatchDT.HeaderText = "Date"
        Me.VHBatchDT.Name = "VHBatchDT"
        Me.VHBatchDT.ReadOnly = True
        Me.VHBatchDT.Width = 150
        '
        'VHRBatchHrsKm
        '
        Me.VHRBatchHrsKm.DataPropertyName = "VHBatchValue"
        Me.VHRBatchHrsKm.HeaderText = "Batch (Hrs or Kms)"
        Me.VHRBatchHrsKm.Name = "VHRBatchHrsKm"
        Me.VHRBatchHrsKm.ReadOnly = True
        Me.VHRBatchHrsKm.Width = 150
        '
        'VehicleCode
        '
        Me.VehicleCode.DataPropertyName = "VHWSCode"
        Me.VehicleCode.HeaderText = "VehicleCode"
        Me.VehicleCode.Name = "VehicleCode"
        Me.VehicleCode.ReadOnly = True
        Me.VehicleCode.Visible = False
        '
        'grpSIV
        '
        Me.grpSIV.Controls.Add(Me.dtpDate)
        Me.grpSIV.Controls.Add(Me.lblHrsOrKms)
        Me.grpSIV.Controls.Add(Me.ibtnSearchVehicleCode)
        Me.grpSIV.Controls.Add(Me.GroupBox2)
        Me.grpSIV.Controls.Add(Me.txtVehicleCode)
        Me.grpSIV.Controls.Add(Me.txtBatchValue)
        Me.grpSIV.Controls.Add(Me.lblBatchValue)
        Me.grpSIV.Controls.Add(Me.lblVehicleCode)
        Me.grpSIV.Controls.Add(Me.lblContractorValue)
        Me.grpSIV.Controls.Add(Me.Label13)
        Me.grpSIV.Controls.Add(Me.Label14)
        Me.grpSIV.Controls.Add(Me.Label15)
        Me.grpSIV.Controls.Add(Me.lblDate)
        Me.grpSIV.Location = New System.Drawing.Point(0, 0)
        Me.grpSIV.Name = "grpSIV"
        Me.grpSIV.Size = New System.Drawing.Size(926, 155)
        Me.grpSIV.TabIndex = 34
        Me.grpSIV.TabStop = False
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(137, 10)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(133, 20)
        Me.dtpDate.TabIndex = 211
        '
        'lblHrsOrKms
        '
        Me.lblHrsOrKms.AutoSize = True
        Me.lblHrsOrKms.Location = New System.Drawing.Point(280, 71)
        Me.lblHrsOrKms.Name = "lblHrsOrKms"
        Me.lblHrsOrKms.Size = New System.Drawing.Size(0, 13)
        Me.lblHrsOrKms.TabIndex = 210
        '
        'ibtnSearchVehicleCode
        '
        Me.ibtnSearchVehicleCode.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.ibtnSearchVehicleCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ibtnSearchVehicleCode.FlatAppearance.BorderSize = 0
        Me.ibtnSearchVehicleCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ibtnSearchVehicleCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSearchVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ibtnSearchVehicleCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ibtnSearchVehicleCode.Location = New System.Drawing.Point(277, 32)
        Me.ibtnSearchVehicleCode.Name = "ibtnSearchVehicleCode"
        Me.ibtnSearchVehicleCode.Size = New System.Drawing.Size(30, 35)
        Me.ibtnSearchVehicleCode.TabIndex = 4
        Me.ibtnSearchVehicleCode.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSaveOrUpdate)
        Me.GroupBox2.Controls.Add(Me.btnPrint)
        Me.GroupBox2.Controls.Add(Me.btnClose)
        Me.GroupBox2.Controls.Add(Me.btnReset)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(3, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(920, 58)
        Me.GroupBox2.TabIndex = 148
        Me.GroupBox2.TabStop = False
        '
        'btnSaveOrUpdate
        '
        Me.btnSaveOrUpdate.BackgroundImage = CType(resources.GetObject("btnSaveOrUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveOrUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveOrUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveOrUpdate.Image = CType(resources.GetObject("btnSaveOrUpdate.Image"), System.Drawing.Image)
        Me.btnSaveOrUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveOrUpdate.Location = New System.Drawing.Point(475, 19)
        Me.btnSaveOrUpdate.Name = "btnSaveOrUpdate"
        Me.btnSaveOrUpdate.Size = New System.Drawing.Size(95, 28)
        Me.btnSaveOrUpdate.TabIndex = 6
        Me.btnSaveOrUpdate.Text = "Save"
        Me.btnSaveOrUpdate.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrint.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(814, 19)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(95, 28)
        Me.btnPrint.TabIndex = 9
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(701, 19)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 28)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(588, 19)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 28)
        Me.btnReset.TabIndex = 7
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'txtVehicleCode
        '
        Me.txtVehicleCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtVehicleCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleCode.Location = New System.Drawing.Point(136, 40)
        Me.txtVehicleCode.MaxLength = 50
        Me.txtVehicleCode.Name = "txtVehicleCode"
        Me.txtVehicleCode.Size = New System.Drawing.Size(135, 21)
        Me.txtVehicleCode.TabIndex = 3
        '
        'txtBatchValue
        '
        Me.txtBatchValue.BackColor = System.Drawing.SystemColors.Window
        Me.txtBatchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBatchValue.Location = New System.Drawing.Point(136, 68)
        Me.txtBatchValue.MaxLength = 50
        Me.txtBatchValue.Name = "txtBatchValue"
        Me.txtBatchValue.Size = New System.Drawing.Size(135, 21)
        Me.txtBatchValue.TabIndex = 5
        '
        'lblBatchValue
        '
        Me.lblBatchValue.AutoSize = True
        Me.lblBatchValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBatchValue.ForeColor = System.Drawing.Color.Red
        Me.lblBatchValue.Location = New System.Drawing.Point(14, 68)
        Me.lblBatchValue.Name = "lblBatchValue"
        Me.lblBatchValue.Size = New System.Drawing.Size(75, 13)
        Me.lblBatchValue.TabIndex = 142
        Me.lblBatchValue.Text = "Batch Value"
        '
        'lblVehicleCode
        '
        Me.lblVehicleCode.AutoSize = True
        Me.lblVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleCode.ForeColor = System.Drawing.Color.Red
        Me.lblVehicleCode.Location = New System.Drawing.Point(14, 40)
        Me.lblVehicleCode.Name = "lblVehicleCode"
        Me.lblVehicleCode.Size = New System.Drawing.Size(82, 13)
        Me.lblVehicleCode.TabIndex = 141
        Me.lblVehicleCode.Text = "Vehicle Code"
        '
        'lblContractorValue
        '
        Me.lblContractorValue.AutoSize = True
        Me.lblContractorValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContractorValue.ForeColor = System.Drawing.Color.Black
        Me.lblContractorValue.Location = New System.Drawing.Point(325, 46)
        Me.lblContractorValue.Name = "lblContractorValue"
        Me.lblContractorValue.Size = New System.Drawing.Size(0, 13)
        Me.lblContractorValue.TabIndex = 140
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(120, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 13)
        Me.Label13.TabIndex = 131
        Me.Label13.Text = ":"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(120, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 13)
        Me.Label14.TabIndex = 130
        Me.Label14.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(120, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 13)
        Me.Label15.TabIndex = 129
        Me.Label15.Text = ":"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Red
        Me.lblDate.Location = New System.Drawing.Point(14, 17)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(34, 13)
        Me.lblDate.TabIndex = 1
        Me.lblDate.Text = "Date"
        '
        'tbpgViewVRB
        '
        Me.tbpgViewVRB.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgViewVRB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgViewVRB.Controls.Add(Me.Panel1)
        Me.tbpgViewVRB.Controls.Add(Me.PnlSearch)
        Me.tbpgViewVRB.Location = New System.Drawing.Point(4, 22)
        Me.tbpgViewVRB.Name = "tbpgViewVRB"
        Me.tbpgViewVRB.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgViewVRB.Size = New System.Drawing.Size(938, 421)
        Me.tbpgViewVRB.TabIndex = 1
        Me.tbpgViewVRB.Text = "View"
        Me.tbpgViewVRB.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvVehicleCode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 147)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(932, 235)
        Me.Panel1.TabIndex = 41
        '
        'dgvVehicleCode
        '
        Me.dgvVehicleCode.AllowUserToAddRows = False
        Me.dgvVehicleCode.AllowUserToDeleteRows = False
        Me.dgvVehicleCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvVehicleCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvVehicleCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVehicleCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvVehicleCode.ColumnHeadersHeight = 30
        Me.dgvVehicleCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SNo, Me.VHWSCode})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVehicleCode.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvVehicleCode.EnableHeadersVisualStyles = False
        Me.dgvVehicleCode.GridColor = System.Drawing.Color.Gray
        Me.dgvVehicleCode.Location = New System.Drawing.Point(0, 0)
        Me.dgvVehicleCode.MultiSelect = False
        Me.dgvVehicleCode.Name = "dgvVehicleCode"
        Me.dgvVehicleCode.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVehicleCode.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvVehicleCode.RowHeadersVisible = False
        Me.dgvVehicleCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVehicleCode.Size = New System.Drawing.Size(297, 163)
        Me.dgvVehicleCode.TabIndex = 5
        Me.dgvVehicleCode.VirtualMode = True
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
        Me.PnlSearch.CaptionText = "Search Vehicle Running Batch"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.rbDate)
        Me.PnlSearch.Controls.Add(Me.rbVehicleCode)
        Me.PnlSearch.Controls.Add(Me.dtpSearchBy)
        Me.PnlSearch.Controls.Add(Me.txtVehicleCodeView)
        Me.PnlSearch.Controls.Add(Me.Panel2)
        Me.PnlSearch.Controls.Add(Me.lblSearchBy)
        Me.PnlSearch.Controls.Add(Me.Label30)
        Me.PnlSearch.Controls.Add(Me.btnSearch)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlSearch.Moveable = True
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(932, 144)
        Me.PnlSearch.TabIndex = 39
        '
        'rbDate
        '
        Me.rbDate.AutoSize = True
        Me.rbDate.Location = New System.Drawing.Point(198, 45)
        Me.rbDate.Name = "rbDate"
        Me.rbDate.Size = New System.Drawing.Size(48, 17)
        Me.rbDate.TabIndex = 2
        Me.rbDate.TabStop = True
        Me.rbDate.Text = "Date"
        Me.rbDate.UseVisualStyleBackColor = True
        '
        'rbVehicleCode
        '
        Me.rbVehicleCode.AutoSize = True
        Me.rbVehicleCode.Checked = True
        Me.rbVehicleCode.Location = New System.Drawing.Point(94, 45)
        Me.rbVehicleCode.Name = "rbVehicleCode"
        Me.rbVehicleCode.Size = New System.Drawing.Size(88, 17)
        Me.rbVehicleCode.TabIndex = 1
        Me.rbVehicleCode.TabStop = True
        Me.rbVehicleCode.Text = "Vehicle Code"
        Me.rbVehicleCode.UseVisualStyleBackColor = True
        '
        'dtpSearchBy
        '
        Me.dtpSearchBy.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchBy.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchBy.Location = New System.Drawing.Point(94, 68)
        Me.dtpSearchBy.Name = "dtpSearchBy"
        Me.dtpSearchBy.Size = New System.Drawing.Size(169, 20)
        Me.dtpSearchBy.TabIndex = 3
        Me.dtpSearchBy.Visible = False
        '
        'txtVehicleCodeView
        '
        Me.txtVehicleCodeView.Location = New System.Drawing.Point(94, 69)
        Me.txtVehicleCodeView.Name = "txtVehicleCodeView"
        Me.txtVehicleCodeView.Size = New System.Drawing.Size(169, 20)
        Me.txtVehicleCodeView.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Location = New System.Drawing.Point(0, 157)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1124, 425)
        Me.Panel2.TabIndex = 33
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.Size = New System.Drawing.Size(1118, 572)
        Me.DataGridView1.TabIndex = 31
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearchBy.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchBy.Location = New System.Drawing.Point(2, 45)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchBy.TabIndex = 69
        Me.lblSearchBy.Text = "Search By"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(80, 45)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(12, 14)
        Me.Label30.TabIndex = 70
        Me.Label30.Text = ":"
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearch.Location = New System.Drawing.Point(279, 59)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(116, 29)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmsDelete
        '
        Me.cmsDelete.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.cmsDelete.Name = "cmsDelete"
        Me.cmsDelete.Size = New System.Drawing.Size(117, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'SNo
        '
        Me.SNo.DataPropertyName = "None"
        Me.SNo.HeaderText = "S.No."
        Me.SNo.Name = "SNo"
        Me.SNo.ReadOnly = True
        Me.SNo.Width = 85
        '
        'VHWSCode
        '
        Me.VHWSCode.DataPropertyName = "VHWSCode"
        Me.VHWSCode.HeaderText = "Vehicle Code"
        Me.VHWSCode.Name = "VHWSCode"
        Me.VHWSCode.ReadOnly = True
        Me.VHWSCode.Width = 150
        '
        'VehicleRunningBatchFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(956, 457)
        Me.Controls.Add(Me.plIB1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VehicleRunningBatchFrm"
        Me.Text = "Vehicle Running Batch"
        Me.plIB1.ResumeLayout(False)
        Me.tcVehicleRunningBatch.ResumeLayout(False)
        Me.tbpgAdd.ResumeLayout(False)
        Me.gbGridAdd.ResumeLayout(False)
        CType(Me.dgvVehicleBatchDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSIV.ResumeLayout(False)
        Me.grpSIV.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.tbpgViewVRB.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvVehicleCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDelete.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plIB1 As System.Windows.Forms.Panel
    Friend WithEvents tcVehicleRunningBatch As System.Windows.Forms.TabControl
    Friend WithEvents tbpgViewVRB As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtVehicleCodeView As System.Windows.Forms.TextBox
    Friend WithEvents tbpgAdd As System.Windows.Forms.TabPage
    Friend WithEvents rbDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbVehicleCode As System.Windows.Forms.RadioButton
    Friend WithEvents dtpSearchBy As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpSIV As System.Windows.Forms.GroupBox
    Friend WithEvents txtVehicleCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBatchValue As System.Windows.Forms.TextBox
    Friend WithEvents lblBatchValue As System.Windows.Forms.Label
    Friend WithEvents lblVehicleCode As System.Windows.Forms.Label
    Friend WithEvents lblContractorValue As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvVehicleCode As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gbGridAdd As System.Windows.Forms.GroupBox
    Friend WithEvents dgvVehicleBatchDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents ibtnSearchVehicleCode As System.Windows.Forms.Button
    Friend WithEvents lblHrsOrKms As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSaveOrUpdate As System.Windows.Forms.Button
    Friend WithEvents cmsDelete As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHBatchDT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHRBatchHrsKm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VehicleCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHWSCode As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

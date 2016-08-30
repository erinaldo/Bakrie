<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleRunningLogFrm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VehicleRunningLogFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.plIB1 = New System.Windows.Forms.Panel()
        Me.tbVehicleRunningLog = New System.Windows.Forms.TabControl()
        Me.tbpgAdd = New System.Windows.Forms.TabPage()
        Me.btnActivity = New System.Windows.Forms.Button()
        Me.gbAddReset = New System.Windows.Forms.GroupBox()
        Me.btnSaveOrUpdate = New System.Windows.Forms.Button()
        Me.btnPrintFFBDO = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.gbListOfVehicleLog = New System.Windows.Forms.GroupBox()
        Me.dgvListOfVehicleLog = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VehicleCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartKms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndKms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalKms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Activity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Posted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlEntryArea = New System.Windows.Forms.Panel()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.gbVehicleRunningData = New System.Windows.Forms.GroupBox()
        Me.btnNIK = New System.Windows.Forms.Button()
        Me.txtDriverName = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtNIK = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtEndHr = New System.Windows.Forms.TextBox()
        Me.txtEndMin = New System.Windows.Forms.TextBox()
        Me.txtStartMin = New System.Windows.Forms.TextBox()
        Me.txtStartHr = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.btnLookUpSubBlock = New System.Windows.Forms.Button()
        Me.btnLookUpDIV = New System.Windows.Forms.Button()
        Me.txtTotalHours = New System.Windows.Forms.TextBox()
        Me.txtShift = New System.Windows.Forms.TextBox()
        Me.txtTotalKms = New System.Windows.Forms.TextBox()
        Me.txtVehicleActivity = New System.Windows.Forms.TextBox()
        Me.txtDIV = New System.Windows.Forms.TextBox()
        Me.txtYOP = New System.Windows.Forms.TextBox()
        Me.txtSubBlock = New System.Windows.Forms.TextBox()
        Me.txtStartKms = New System.Windows.Forms.TextBox()
        Me.txtEndKms = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblYOP = New System.Windows.Forms.Label()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.lblTotalKms = New System.Windows.Forms.Label()
        Me.lblStartKms = New System.Windows.Forms.Label()
        Me.lblEndKms = New System.Windows.Forms.Label()
        Me.lblEndTime = New System.Windows.Forms.Label()
        Me.lblVehicleActivity = New System.Windows.Forms.Label()
        Me.lblSubBlock = New System.Windows.Forms.Label()
        Me.lblDIV = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblTotalHours = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpDefault = New System.Windows.Forms.GroupBox()
        Me.rbFFBdeliverytoMill = New System.Windows.Forms.RadioButton()
        Me.ddlLocation = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.btnLookUpContractNo = New System.Windows.Forms.Button()
        Me.ibtnSearchVehicleCode = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.rbOperational = New System.Windows.Forms.RadioButton()
        Me.rbStandBy = New System.Windows.Forms.RadioButton()
        Me.rbBreakDown = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.txtVehicleCode = New System.Windows.Forms.TextBox()
        Me.txtBatchValue = New System.Windows.Forms.TextBox()
        Me.txtUOM = New System.Windows.Forms.TextBox()
        Me.txtVehicleModel = New System.Windows.Forms.TextBox()
        Me.txtVehicleRegNo = New System.Windows.Forms.TextBox()
        Me.lblOperatedBy = New System.Windows.Forms.Label()
        Me.lblVehicleModel = New System.Windows.Forms.Label()
        Me.lblUOM = New System.Windows.Forms.Label()
        Me.lblContractNo = New System.Windows.Forms.Label()
        Me.lblBatchValue = New System.Windows.Forms.Label()
        Me.lblVehicleRegNo = New System.Windows.Forms.Label()
        Me.lblVehicleDescription = New System.Windows.Forms.Label()
        Me.txtVehicleDescription = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtOperatedBy = New System.Windows.Forms.TextBox()
        Me.lblVehicleCode = New System.Windows.Forms.Label()
        Me.lblContractorValue = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.tpViewVRL = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgVehicleCode = New System.Windows.Forms.DataGridView()
        Me.PnlSearch = New Stepi.UI.ExtendedPanel()
        Me.btnViewReport = New System.Windows.Forms.Button()
        Me.lblViewVehicleCode = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.lblSearchby = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dtpSearchBy = New System.Windows.Forms.DateTimePicker()
        Me.txtVehicleCodeView = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmsDelete = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiViewAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiViewEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiViewDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvLogDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VHWSCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ViewPosted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plIB1.SuspendLayout()
        Me.tbVehicleRunningLog.SuspendLayout()
        Me.tbpgAdd.SuspendLayout()
        Me.gbAddReset.SuspendLayout()
        Me.gbListOfVehicleLog.SuspendLayout()
        CType(Me.dgvListOfVehicleLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEntryArea.SuspendLayout()
        Me.gbVehicleRunningData.SuspendLayout()
        Me.grpDefault.SuspendLayout()
        Me.tpViewVRL.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgVehicleCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlSearch.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDelete.SuspendLayout()
        Me.cmsView.SuspendLayout()
        Me.SuspendLayout()
        '
        'plIB1
        '
        Me.plIB1.AutoScroll = True
        Me.plIB1.BackColor = System.Drawing.Color.Transparent
        Me.plIB1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.plIB1.Controls.Add(Me.tbVehicleRunningLog)
        Me.plIB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plIB1.Location = New System.Drawing.Point(0, 0)
        Me.plIB1.Name = "plIB1"
        Me.plIB1.Size = New System.Drawing.Size(1040, 732)
        Me.plIB1.TabIndex = 12
        '
        'tbVehicleRunningLog
        '
        Me.tbVehicleRunningLog.Controls.Add(Me.tbpgAdd)
        Me.tbVehicleRunningLog.Controls.Add(Me.tpViewVRL)
        Me.tbVehicleRunningLog.Location = New System.Drawing.Point(3, 3)
        Me.tbVehicleRunningLog.Name = "tbVehicleRunningLog"
        Me.tbVehicleRunningLog.SelectedIndex = 0
        Me.tbVehicleRunningLog.Size = New System.Drawing.Size(1009, 825)
        Me.tbVehicleRunningLog.TabIndex = 0
        Me.tbVehicleRunningLog.TabStop = False
        '
        'tbpgAdd
        '
        Me.tbpgAdd.BackColor = System.Drawing.Color.Transparent
        Me.tbpgAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgAdd.Controls.Add(Me.btnActivity)
        Me.tbpgAdd.Controls.Add(Me.gbAddReset)
        Me.tbpgAdd.Controls.Add(Me.gbListOfVehicleLog)
        Me.tbpgAdd.Controls.Add(Me.pnlEntryArea)
        Me.tbpgAdd.Location = New System.Drawing.Point(4, 22)
        Me.tbpgAdd.Name = "tbpgAdd"
        Me.tbpgAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgAdd.Size = New System.Drawing.Size(1001, 799)
        Me.tbpgAdd.TabIndex = 0
        Me.tbpgAdd.Text = "Vehicle Running Log"
        Me.tbpgAdd.UseVisualStyleBackColor = True
        '
        'btnActivity
        '
        Me.btnActivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActivity.BackgroundImage = CType(resources.GetObject("btnActivity.BackgroundImage"), System.Drawing.Image)
        Me.btnActivity.Enabled = False
        Me.btnActivity.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnActivity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActivity.Image = CType(resources.GetObject("btnActivity.Image"), System.Drawing.Image)
        Me.btnActivity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActivity.Location = New System.Drawing.Point(796, 344)
        Me.btnActivity.Name = "btnActivity"
        Me.btnActivity.Size = New System.Drawing.Size(139, 30)
        Me.btnActivity.TabIndex = 165
        Me.btnActivity.Text = "&Activity"
        Me.btnActivity.UseVisualStyleBackColor = True
        '
        'gbAddReset
        '
        Me.gbAddReset.Controls.Add(Me.btnSaveOrUpdate)
        Me.gbAddReset.Controls.Add(Me.btnPrintFFBDO)
        Me.gbAddReset.Controls.Add(Me.btnClose)
        Me.gbAddReset.Controls.Add(Me.btnReset)
        Me.gbAddReset.Location = New System.Drawing.Point(13, 380)
        Me.gbAddReset.Name = "gbAddReset"
        Me.gbAddReset.Size = New System.Drawing.Size(948, 44)
        Me.gbAddReset.TabIndex = 36
        Me.gbAddReset.TabStop = False
        '
        'btnSaveOrUpdate
        '
        Me.btnSaveOrUpdate.BackgroundImage = CType(resources.GetObject("btnSaveOrUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveOrUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveOrUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveOrUpdate.Image = CType(resources.GetObject("btnSaveOrUpdate.Image"), System.Drawing.Image)
        Me.btnSaveOrUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveOrUpdate.Location = New System.Drawing.Point(500, 12)
        Me.btnSaveOrUpdate.Name = "btnSaveOrUpdate"
        Me.btnSaveOrUpdate.Size = New System.Drawing.Size(95, 28)
        Me.btnSaveOrUpdate.TabIndex = 38
        Me.btnSaveOrUpdate.Text = "Save"
        Me.btnSaveOrUpdate.UseVisualStyleBackColor = True
        '
        'btnPrintFFBDO
        '
        Me.btnPrintFFBDO.BackgroundImage = CType(resources.GetObject("btnPrintFFBDO.BackgroundImage"), System.Drawing.Image)
        Me.btnPrintFFBDO.Enabled = False
        Me.btnPrintFFBDO.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrintFFBDO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintFFBDO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintFFBDO.Location = New System.Drawing.Point(824, 12)
        Me.btnPrintFFBDO.Name = "btnPrintFFBDO"
        Me.btnPrintFFBDO.Size = New System.Drawing.Size(95, 28)
        Me.btnPrintFFBDO.TabIndex = 41
        Me.btnPrintFFBDO.Text = "Print"
        Me.btnPrintFFBDO.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(716, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 28)
        Me.btnClose.TabIndex = 40
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
        Me.btnReset.Location = New System.Drawing.Point(608, 12)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 28)
        Me.btnReset.TabIndex = 39
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'gbListOfVehicleLog
        '
        Me.gbListOfVehicleLog.Controls.Add(Me.dgvListOfVehicleLog)
        Me.gbListOfVehicleLog.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbListOfVehicleLog.Location = New System.Drawing.Point(12, 430)
        Me.gbListOfVehicleLog.Name = "gbListOfVehicleLog"
        Me.gbListOfVehicleLog.Size = New System.Drawing.Size(948, 177)
        Me.gbListOfVehicleLog.TabIndex = 41
        Me.gbListOfVehicleLog.TabStop = False
        Me.gbListOfVehicleLog.Text = "Vehicle Running Log Records"
        '
        'dgvListOfVehicleLog
        '
        Me.dgvListOfVehicleLog.AllowUserToAddRows = False
        Me.dgvListOfVehicleLog.AllowUserToDeleteRows = False
        Me.dgvListOfVehicleLog.AllowUserToResizeColumns = False
        Me.dgvListOfVehicleLog.AllowUserToResizeRows = False
        Me.dgvListOfVehicleLog.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvListOfVehicleLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvListOfVehicleLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListOfVehicleLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListOfVehicleLog.ColumnHeadersHeight = 30
        Me.dgvListOfVehicleLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvListOfVehicleLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.LogDate, Me.VehicleCode, Me.Status, Me.StartTime, Me.EndTime, Me.TotalHrs, Me.StartKms, Me.EndKms, Me.TotalKms, Me.Activity, Me.Posted})
        Me.dgvListOfVehicleLog.EnableHeadersVisualStyles = False
        Me.dgvListOfVehicleLog.GridColor = System.Drawing.Color.Gray
        Me.dgvListOfVehicleLog.Location = New System.Drawing.Point(18, 20)
        Me.dgvListOfVehicleLog.MultiSelect = False
        Me.dgvListOfVehicleLog.Name = "dgvListOfVehicleLog"
        Me.dgvListOfVehicleLog.ReadOnly = True
        Me.dgvListOfVehicleLog.RowHeadersVisible = False
        Me.dgvListOfVehicleLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvListOfVehicleLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListOfVehicleLog.Size = New System.Drawing.Size(933, 150)
        Me.dgvListOfVehicleLog.TabIndex = 42
        Me.dgvListOfVehicleLog.TabStop = False
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 46
        '
        'LogDate
        '
        Me.LogDate.DataPropertyName = "LogDate"
        Me.LogDate.HeaderText = "Date"
        Me.LogDate.Name = "LogDate"
        Me.LogDate.ReadOnly = True
        '
        'VehicleCode
        '
        Me.VehicleCode.DataPropertyName = "VHWSCode"
        Me.VehicleCode.HeaderText = "Vehicle Code"
        Me.VehicleCode.Name = "VehicleCode"
        Me.VehicleCode.ReadOnly = True
        Me.VehicleCode.Width = 110
        '
        'Status
        '
        Me.Status.DataPropertyName = "OprStatus"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'StartTime
        '
        Me.StartTime.DataPropertyName = "StartTime"
        DataGridViewCellStyle2.Format = "HH:MM"
        DataGridViewCellStyle2.NullValue = "00:00"
        Me.StartTime.DefaultCellStyle = DataGridViewCellStyle2
        Me.StartTime.HeaderText = "Start Time"
        Me.StartTime.Name = "StartTime"
        Me.StartTime.ReadOnly = True
        Me.StartTime.Width = 96
        '
        'EndTime
        '
        Me.EndTime.DataPropertyName = "EndTime"
        DataGridViewCellStyle3.Format = "HH:MM"
        DataGridViewCellStyle3.NullValue = "00:00"
        Me.EndTime.DefaultCellStyle = DataGridViewCellStyle3
        Me.EndTime.HeaderText = "End Time"
        Me.EndTime.Name = "EndTime"
        Me.EndTime.ReadOnly = True
        Me.EndTime.Width = 96
        '
        'TotalHrs
        '
        Me.TotalHrs.DataPropertyName = "TotalHrs"
        Me.TotalHrs.HeaderText = "Total Hrs"
        Me.TotalHrs.Name = "TotalHrs"
        Me.TotalHrs.ReadOnly = True
        Me.TotalHrs.Width = 88
        '
        'StartKms
        '
        Me.StartKms.DataPropertyName = "StartKMs"
        Me.StartKms.HeaderText = "Start Kms"
        Me.StartKms.Name = "StartKms"
        Me.StartKms.ReadOnly = True
        '
        'EndKms
        '
        Me.EndKms.DataPropertyName = "EndKms"
        Me.EndKms.HeaderText = "End Kms"
        Me.EndKms.Name = "EndKms"
        Me.EndKms.ReadOnly = True
        '
        'TotalKms
        '
        Me.TotalKms.DataPropertyName = "TotalKM"
        Me.TotalKms.HeaderText = "Total Kms"
        Me.TotalKms.Name = "TotalKms"
        Me.TotalKms.ReadOnly = True
        '
        'Activity
        '
        Me.Activity.DataPropertyName = "Activity"
        Me.Activity.HeaderText = "Activity"
        Me.Activity.Name = "Activity"
        Me.Activity.ReadOnly = True
        Me.Activity.Width = 76
        '
        'Posted
        '
        Me.Posted.DataPropertyName = "Posted"
        Me.Posted.HeaderText = "Posted"
        Me.Posted.Name = "Posted"
        Me.Posted.ReadOnly = True
        Me.Posted.Visible = False
        Me.Posted.Width = 76
        '
        'pnlEntryArea
        '
        Me.pnlEntryArea.Controls.Add(Me.txtRemarks)
        Me.pnlEntryArea.Controls.Add(Me.gbVehicleRunningData)
        Me.pnlEntryArea.Controls.Add(Me.grpDefault)
        Me.pnlEntryArea.Controls.Add(Me.lblRemarks)
        Me.pnlEntryArea.Location = New System.Drawing.Point(9, 6)
        Me.pnlEntryArea.Name = "pnlEntryArea"
        Me.pnlEntryArea.Size = New System.Drawing.Size(955, 330)
        Me.pnlEntryArea.TabIndex = 164
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(108, 296)
        Me.txtRemarks.MaxLength = 200
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(591, 22)
        Me.txtRemarks.TabIndex = 37
        '
        'gbVehicleRunningData
        '
        Me.gbVehicleRunningData.Controls.Add(Me.btnNIK)
        Me.gbVehicleRunningData.Controls.Add(Me.txtDriverName)
        Me.gbVehicleRunningData.Controls.Add(Me.Label24)
        Me.gbVehicleRunningData.Controls.Add(Me.Label25)
        Me.gbVehicleRunningData.Controls.Add(Me.txtNIK)
        Me.gbVehicleRunningData.Controls.Add(Me.Label22)
        Me.gbVehicleRunningData.Controls.Add(Me.Label23)
        Me.gbVehicleRunningData.Controls.Add(Me.txtEndHr)
        Me.gbVehicleRunningData.Controls.Add(Me.txtEndMin)
        Me.gbVehicleRunningData.Controls.Add(Me.txtStartMin)
        Me.gbVehicleRunningData.Controls.Add(Me.txtStartHr)
        Me.gbVehicleRunningData.Controls.Add(Me.Label38)
        Me.gbVehicleRunningData.Controls.Add(Me.Label36)
        Me.gbVehicleRunningData.Controls.Add(Me.Label37)
        Me.gbVehicleRunningData.Controls.Add(Me.Label20)
        Me.gbVehicleRunningData.Controls.Add(Me.Label35)
        Me.gbVehicleRunningData.Controls.Add(Me.btnLookUpSubBlock)
        Me.gbVehicleRunningData.Controls.Add(Me.btnLookUpDIV)
        Me.gbVehicleRunningData.Controls.Add(Me.txtTotalHours)
        Me.gbVehicleRunningData.Controls.Add(Me.txtShift)
        Me.gbVehicleRunningData.Controls.Add(Me.txtTotalKms)
        Me.gbVehicleRunningData.Controls.Add(Me.txtVehicleActivity)
        Me.gbVehicleRunningData.Controls.Add(Me.txtDIV)
        Me.gbVehicleRunningData.Controls.Add(Me.txtYOP)
        Me.gbVehicleRunningData.Controls.Add(Me.txtSubBlock)
        Me.gbVehicleRunningData.Controls.Add(Me.txtStartKms)
        Me.gbVehicleRunningData.Controls.Add(Me.txtEndKms)
        Me.gbVehicleRunningData.Controls.Add(Me.Label21)
        Me.gbVehicleRunningData.Controls.Add(Me.Label19)
        Me.gbVehicleRunningData.Controls.Add(Me.Label18)
        Me.gbVehicleRunningData.Controls.Add(Me.Label17)
        Me.gbVehicleRunningData.Controls.Add(Me.Label12)
        Me.gbVehicleRunningData.Controls.Add(Me.Label11)
        Me.gbVehicleRunningData.Controls.Add(Me.Label10)
        Me.gbVehicleRunningData.Controls.Add(Me.Label9)
        Me.gbVehicleRunningData.Controls.Add(Me.Label8)
        Me.gbVehicleRunningData.Controls.Add(Me.Label7)
        Me.gbVehicleRunningData.Controls.Add(Me.lblYOP)
        Me.gbVehicleRunningData.Controls.Add(Me.lblStartTime)
        Me.gbVehicleRunningData.Controls.Add(Me.lblTotalKms)
        Me.gbVehicleRunningData.Controls.Add(Me.lblStartKms)
        Me.gbVehicleRunningData.Controls.Add(Me.lblEndKms)
        Me.gbVehicleRunningData.Controls.Add(Me.lblEndTime)
        Me.gbVehicleRunningData.Controls.Add(Me.lblVehicleActivity)
        Me.gbVehicleRunningData.Controls.Add(Me.lblSubBlock)
        Me.gbVehicleRunningData.Controls.Add(Me.lblDIV)
        Me.gbVehicleRunningData.Controls.Add(Me.lblShift)
        Me.gbVehicleRunningData.Controls.Add(Me.lblTotalHours)
        Me.gbVehicleRunningData.Controls.Add(Me.Label6)
        Me.gbVehicleRunningData.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbVehicleRunningData.Location = New System.Drawing.Point(15, 140)
        Me.gbVehicleRunningData.Name = "gbVehicleRunningData"
        Me.gbVehicleRunningData.Size = New System.Drawing.Size(926, 144)
        Me.gbVehicleRunningData.TabIndex = 12
        Me.gbVehicleRunningData.TabStop = False
        Me.gbVehicleRunningData.Text = "Vehicle Running Data"
        '
        'btnNIK
        '
        Me.btnNIK.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.btnNIK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnNIK.FlatAppearance.BorderSize = 0
        Me.btnNIK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnNIK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNIK.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnNIK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNIK.Location = New System.Drawing.Point(664, 103)
        Me.btnNIK.Name = "btnNIK"
        Me.btnNIK.Size = New System.Drawing.Size(30, 31)
        Me.btnNIK.TabIndex = 255
        Me.btnNIK.TabStop = False
        Me.btnNIK.UseVisualStyleBackColor = True
        '
        'txtDriverName
        '
        Me.txtDriverName.BackColor = System.Drawing.SystemColors.Window
        Me.txtDriverName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDriverName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDriverName.Location = New System.Drawing.Point(827, 110)
        Me.txtDriverName.MaxLength = 8
        Me.txtDriverName.Name = "txtDriverName"
        Me.txtDriverName.Size = New System.Drawing.Size(84, 21)
        Me.txtDriverName.TabIndex = 252
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(809, 113)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(11, 13)
        Me.Label24.TabIndex = 254
        Me.Label24.Text = ":"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(727, 113)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(80, 13)
        Me.Label25.TabIndex = 253
        Me.Label25.Text = "Driver Name"
        '
        'txtNIK
        '
        Me.txtNIK.BackColor = System.Drawing.SystemColors.Window
        Me.txtNIK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNIK.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNIK.Location = New System.Drawing.Point(573, 109)
        Me.txtNIK.MaxLength = 8
        Me.txtNIK.Name = "txtNIK"
        Me.txtNIK.Size = New System.Drawing.Size(84, 21)
        Me.txtNIK.TabIndex = 249
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(558, 114)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(11, 13)
        Me.Label22.TabIndex = 251
        Me.Label22.Text = ":"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(485, 115)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(28, 13)
        Me.Label23.TabIndex = 250
        Me.Label23.Text = "NIK"
        '
        'txtEndHr
        '
        Me.txtEndHr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndHr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndHr.Location = New System.Drawing.Point(387, 49)
        Me.txtEndHr.MaxLength = 2
        Me.txtEndHr.Name = "txtEndHr"
        Me.txtEndHr.Size = New System.Drawing.Size(40, 21)
        Me.txtEndHr.TabIndex = 17
        '
        'txtEndMin
        '
        Me.txtEndMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndMin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndMin.Location = New System.Drawing.Point(455, 49)
        Me.txtEndMin.MaxLength = 2
        Me.txtEndMin.Name = "txtEndMin"
        Me.txtEndMin.Size = New System.Drawing.Size(40, 21)
        Me.txtEndMin.TabIndex = 18
        '
        'txtStartMin
        '
        Me.txtStartMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartMin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartMin.Location = New System.Drawing.Point(194, 49)
        Me.txtStartMin.MaxLength = 2
        Me.txtStartMin.Name = "txtStartMin"
        Me.txtStartMin.Size = New System.Drawing.Size(40, 21)
        Me.txtStartMin.TabIndex = 16
        '
        'txtStartHr
        '
        Me.txtStartHr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartHr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartHr.Location = New System.Drawing.Point(125, 49)
        Me.txtStartHr.MaxLength = 2
        Me.txtStartHr.Name = "txtStartHr"
        Me.txtStartHr.Size = New System.Drawing.Size(40, 21)
        Me.txtStartHr.TabIndex = 15
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label38.Location = New System.Drawing.Point(703, 57)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(50, 13)
        Me.Label38.TabIndex = 248
        Me.Label38.Text = "HH:mm"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(499, 57)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(26, 13)
        Me.Label36.TabIndex = 238
        Me.Label36.Text = "Min"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(430, 57)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(19, 13)
        Me.Label37.TabIndex = 237
        Me.Label37.Text = "hr"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(237, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(26, 13)
        Me.Label20.TabIndex = 233
        Me.Label20.Text = "Min"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(169, 57)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(19, 13)
        Me.Label35.TabIndex = 232
        Me.Label35.Text = "hr"
        '
        'btnLookUpSubBlock
        '
        Me.btnLookUpSubBlock.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.btnLookUpSubBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLookUpSubBlock.FlatAppearance.BorderSize = 0
        Me.btnLookUpSubBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnLookUpSubBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLookUpSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnLookUpSubBlock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLookUpSubBlock.Location = New System.Drawing.Point(707, 69)
        Me.btnLookUpSubBlock.Name = "btnLookUpSubBlock"
        Me.btnLookUpSubBlock.Size = New System.Drawing.Size(30, 35)
        Me.btnLookUpSubBlock.TabIndex = 206
        Me.btnLookUpSubBlock.TabStop = False
        Me.btnLookUpSubBlock.UseVisualStyleBackColor = True
        '
        'btnLookUpDIV
        '
        Me.btnLookUpDIV.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.btnLookUpDIV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLookUpDIV.FlatAppearance.BorderSize = 0
        Me.btnLookUpDIV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnLookUpDIV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLookUpDIV.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnLookUpDIV.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLookUpDIV.Location = New System.Drawing.Point(215, 69)
        Me.btnLookUpDIV.Name = "btnLookUpDIV"
        Me.btnLookUpDIV.Size = New System.Drawing.Size(30, 35)
        Me.btnLookUpDIV.TabIndex = 195
        Me.btnLookUpDIV.TabStop = False
        Me.btnLookUpDIV.UseVisualStyleBackColor = True
        Me.btnLookUpDIV.Visible = False
        '
        'txtTotalHours
        '
        Me.txtTotalHours.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotalHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalHours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHours.Location = New System.Drawing.Point(613, 49)
        Me.txtTotalHours.MaxLength = 8
        Me.txtTotalHours.Name = "txtTotalHours"
        Me.txtTotalHours.Size = New System.Drawing.Size(84, 21)
        Me.txtTotalHours.TabIndex = 19
        '
        'txtShift
        '
        Me.txtShift.BackColor = System.Drawing.SystemColors.Control
        Me.txtShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShift.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShift.Location = New System.Drawing.Point(824, 52)
        Me.txtShift.MaxLength = 50
        Me.txtShift.Name = "txtShift"
        Me.txtShift.ReadOnly = True
        Me.txtShift.Size = New System.Drawing.Size(84, 21)
        Me.txtShift.TabIndex = 20
        Me.txtShift.TabStop = False
        '
        'txtTotalKms
        '
        Me.txtTotalKms.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalKms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalKms.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalKms.Location = New System.Drawing.Point(613, 20)
        Me.txtTotalKms.MaxLength = 50
        Me.txtTotalKms.Name = "txtTotalKms"
        Me.txtTotalKms.ReadOnly = True
        Me.txtTotalKms.Size = New System.Drawing.Size(84, 21)
        Me.txtTotalKms.TabIndex = 203
        Me.txtTotalKms.TabStop = False
        '
        'txtVehicleActivity
        '
        Me.txtVehicleActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleActivity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleActivity.Location = New System.Drawing.Point(125, 107)
        Me.txtVehicleActivity.MaxLength = 50
        Me.txtVehicleActivity.Name = "txtVehicleActivity"
        Me.txtVehicleActivity.Size = New System.Drawing.Size(269, 21)
        Me.txtVehicleActivity.TabIndex = 24
        '
        'txtDIV
        '
        Me.txtDIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDIV.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIV.Location = New System.Drawing.Point(125, 78)
        Me.txtDIV.Name = "txtDIV"
        Me.txtDIV.ReadOnly = True
        Me.txtDIV.Size = New System.Drawing.Size(84, 21)
        Me.txtDIV.TabIndex = 21
        Me.txtDIV.TabStop = False
        '
        'txtYOP
        '
        Me.txtYOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYOP.Location = New System.Drawing.Point(387, 78)
        Me.txtYOP.MaxLength = 50
        Me.txtYOP.Name = "txtYOP"
        Me.txtYOP.ReadOnly = True
        Me.txtYOP.Size = New System.Drawing.Size(84, 21)
        Me.txtYOP.TabIndex = 22
        Me.txtYOP.TabStop = False
        '
        'txtSubBlock
        '
        Me.txtSubBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubBlock.Location = New System.Drawing.Point(613, 78)
        Me.txtSubBlock.MaxLength = 50
        Me.txtSubBlock.Name = "txtSubBlock"
        Me.txtSubBlock.Size = New System.Drawing.Size(84, 21)
        Me.txtSubBlock.TabIndex = 23
        '
        'txtStartKms
        '
        Me.txtStartKms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartKms.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartKms.Location = New System.Drawing.Point(125, 20)
        Me.txtStartKms.MaxLength = 19
        Me.txtStartKms.Name = "txtStartKms"
        Me.txtStartKms.Size = New System.Drawing.Size(86, 21)
        Me.txtStartKms.TabIndex = 13
        '
        'txtEndKms
        '
        Me.txtEndKms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndKms.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndKms.Location = New System.Drawing.Point(387, 20)
        Me.txtEndKms.MaxLength = 19
        Me.txtEndKms.Name = "txtEndKms"
        Me.txtEndKms.Size = New System.Drawing.Size(84, 21)
        Me.txtEndKms.TabIndex = 14
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(110, 114)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 13)
        Me.Label21.TabIndex = 190
        Me.Label21.Text = ":"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(598, 84)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(11, 13)
        Me.Label19.TabIndex = 188
        Me.Label19.Text = ":"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(110, 86)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(11, 13)
        Me.Label18.TabIndex = 187
        Me.Label18.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(371, 84)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 13)
        Me.Label17.TabIndex = 186
        Me.Label17.Text = ":"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(815, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 13)
        Me.Label12.TabIndex = 185
        Me.Label12.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(371, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 184
        Me.Label11.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(598, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 183
        Me.Label10.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(110, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 182
        Me.Label9.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(598, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 13)
        Me.Label8.TabIndex = 181
        Me.Label8.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(371, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 180
        Me.Label7.Text = ":"
        '
        'lblYOP
        '
        Me.lblYOP.AutoEllipsis = True
        Me.lblYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOP.ForeColor = System.Drawing.Color.Black
        Me.lblYOP.Location = New System.Drawing.Point(283, 86)
        Me.lblYOP.Name = "lblYOP"
        Me.lblYOP.Size = New System.Drawing.Size(90, 18)
        Me.lblYOP.TabIndex = 179
        Me.lblYOP.Text = "YOP"
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartTime.ForeColor = System.Drawing.Color.Black
        Me.lblStartTime.Location = New System.Drawing.Point(17, 55)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(67, 13)
        Me.lblStartTime.TabIndex = 178
        Me.lblStartTime.Text = "Start Time"
        '
        'lblTotalKms
        '
        Me.lblTotalKms.AutoSize = True
        Me.lblTotalKms.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalKms.ForeColor = System.Drawing.Color.Black
        Me.lblTotalKms.Location = New System.Drawing.Point(525, 24)
        Me.lblTotalKms.Name = "lblTotalKms"
        Me.lblTotalKms.Size = New System.Drawing.Size(58, 13)
        Me.lblTotalKms.TabIndex = 177
        Me.lblTotalKms.Text = "Total Km"
        '
        'lblStartKms
        '
        Me.lblStartKms.AutoSize = True
        Me.lblStartKms.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartKms.ForeColor = System.Drawing.Color.Black
        Me.lblStartKms.Location = New System.Drawing.Point(16, 24)
        Me.lblStartKms.Name = "lblStartKms"
        Me.lblStartKms.Size = New System.Drawing.Size(64, 13)
        Me.lblStartKms.TabIndex = 176
        Me.lblStartKms.Text = "Start Kms"
        '
        'lblEndKms
        '
        Me.lblEndKms.AutoSize = True
        Me.lblEndKms.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndKms.ForeColor = System.Drawing.Color.Black
        Me.lblEndKms.Location = New System.Drawing.Point(283, 24)
        Me.lblEndKms.Name = "lblEndKms"
        Me.lblEndKms.Size = New System.Drawing.Size(57, 13)
        Me.lblEndKms.TabIndex = 175
        Me.lblEndKms.Text = "End Kms"
        '
        'lblEndTime
        '
        Me.lblEndTime.AutoSize = True
        Me.lblEndTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndTime.ForeColor = System.Drawing.Color.Black
        Me.lblEndTime.Location = New System.Drawing.Point(283, 55)
        Me.lblEndTime.Name = "lblEndTime"
        Me.lblEndTime.Size = New System.Drawing.Size(60, 13)
        Me.lblEndTime.TabIndex = 174
        Me.lblEndTime.Text = "End Time"
        '
        'lblVehicleActivity
        '
        Me.lblVehicleActivity.AutoEllipsis = True
        Me.lblVehicleActivity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleActivity.ForeColor = System.Drawing.Color.Black
        Me.lblVehicleActivity.Location = New System.Drawing.Point(16, 111)
        Me.lblVehicleActivity.Name = "lblVehicleActivity"
        Me.lblVehicleActivity.Size = New System.Drawing.Size(94, 30)
        Me.lblVehicleActivity.TabIndex = 173
        Me.lblVehicleActivity.Text = "Vehicle Activity"
        '
        'lblSubBlock
        '
        Me.lblSubBlock.AutoSize = True
        Me.lblSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubBlock.ForeColor = System.Drawing.Color.Black
        Me.lblSubBlock.Location = New System.Drawing.Point(525, 86)
        Me.lblSubBlock.Name = "lblSubBlock"
        Me.lblSubBlock.Size = New System.Drawing.Size(48, 13)
        Me.lblSubBlock.TabIndex = 171
        Me.lblSubBlock.Text = "FieldNo"
        '
        'lblDIV
        '
        Me.lblDIV.AutoSize = True
        Me.lblDIV.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDIV.ForeColor = System.Drawing.Color.Black
        Me.lblDIV.Location = New System.Drawing.Point(16, 82)
        Me.lblDIV.Name = "lblDIV"
        Me.lblDIV.Size = New System.Drawing.Size(53, 13)
        Me.lblDIV.TabIndex = 170
        Me.lblDIV.Text = "Afdeling"
        '
        'lblShift
        '
        Me.lblShift.AutoEllipsis = True
        Me.lblShift.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Black
        Me.lblShift.Location = New System.Drawing.Point(783, 55)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(69, 14)
        Me.lblShift.TabIndex = 169
        Me.lblShift.Text = "Shift"
        '
        'lblTotalHours
        '
        Me.lblTotalHours.AutoSize = True
        Me.lblTotalHours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHours.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalHours.Location = New System.Drawing.Point(525, 55)
        Me.lblTotalHours.Name = "lblTotalHours"
        Me.lblTotalHours.Size = New System.Drawing.Size(58, 13)
        Me.lblTotalHours.TabIndex = 168
        Me.lblTotalHours.Text = "Total Hrs"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(110, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 167
        Me.Label6.Text = ":"
        '
        'grpDefault
        '
        Me.grpDefault.Controls.Add(Me.rbFFBdeliverytoMill)
        Me.grpDefault.Controls.Add(Me.ddlLocation)
        Me.grpDefault.Controls.Add(Me.Label34)
        Me.grpDefault.Controls.Add(Me.lblLocation)
        Me.grpDefault.Controls.Add(Me.btnLookUpContractNo)
        Me.grpDefault.Controls.Add(Me.ibtnSearchVehicleCode)
        Me.grpDefault.Controls.Add(Me.lblStatus)
        Me.grpDefault.Controls.Add(Me.rbOperational)
        Me.grpDefault.Controls.Add(Me.rbStandBy)
        Me.grpDefault.Controls.Add(Me.rbBreakDown)
        Me.grpDefault.Controls.Add(Me.Label5)
        Me.grpDefault.Controls.Add(Me.Label4)
        Me.grpDefault.Controls.Add(Me.Label3)
        Me.grpDefault.Controls.Add(Me.Label2)
        Me.grpDefault.Controls.Add(Me.Label1)
        Me.grpDefault.Controls.Add(Me.Label16)
        Me.grpDefault.Controls.Add(Me.txtContractNo)
        Me.grpDefault.Controls.Add(Me.txtVehicleCode)
        Me.grpDefault.Controls.Add(Me.txtBatchValue)
        Me.grpDefault.Controls.Add(Me.txtUOM)
        Me.grpDefault.Controls.Add(Me.txtVehicleModel)
        Me.grpDefault.Controls.Add(Me.txtVehicleRegNo)
        Me.grpDefault.Controls.Add(Me.lblOperatedBy)
        Me.grpDefault.Controls.Add(Me.lblVehicleModel)
        Me.grpDefault.Controls.Add(Me.lblUOM)
        Me.grpDefault.Controls.Add(Me.lblContractNo)
        Me.grpDefault.Controls.Add(Me.lblBatchValue)
        Me.grpDefault.Controls.Add(Me.lblVehicleRegNo)
        Me.grpDefault.Controls.Add(Me.lblVehicleDescription)
        Me.grpDefault.Controls.Add(Me.txtVehicleDescription)
        Me.grpDefault.Controls.Add(Me.dtpDate)
        Me.grpDefault.Controls.Add(Me.txtOperatedBy)
        Me.grpDefault.Controls.Add(Me.lblVehicleCode)
        Me.grpDefault.Controls.Add(Me.lblContractorValue)
        Me.grpDefault.Controls.Add(Me.Label13)
        Me.grpDefault.Controls.Add(Me.Label14)
        Me.grpDefault.Controls.Add(Me.Label15)
        Me.grpDefault.Controls.Add(Me.lblDate)
        Me.grpDefault.Location = New System.Drawing.Point(15, 9)
        Me.grpDefault.Name = "grpDefault"
        Me.grpDefault.Size = New System.Drawing.Size(926, 122)
        Me.grpDefault.TabIndex = 5
        Me.grpDefault.TabStop = False
        '
        'rbFFBdeliverytoMill
        '
        Me.rbFFBdeliverytoMill.AutoSize = True
        Me.rbFFBdeliverytoMill.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rbFFBdeliverytoMill.ForeColor = System.Drawing.Color.Black
        Me.rbFFBdeliverytoMill.Location = New System.Drawing.Point(406, 101)
        Me.rbFFBdeliverytoMill.Name = "rbFFBdeliverytoMill"
        Me.rbFFBdeliverytoMill.Size = New System.Drawing.Size(132, 17)
        Me.rbFFBdeliverytoMill.TabIndex = 214
        Me.rbFFBdeliverytoMill.Text = "FFB delivery to Mill"
        Me.rbFFBdeliverytoMill.UseVisualStyleBackColor = True
        Me.rbFFBdeliverytoMill.Visible = False
        '
        'ddlLocation
        '
        Me.ddlLocation.FormattingEnabled = True
        Me.ddlLocation.Items.AddRange(New Object() {"--Select--"})
        Me.ddlLocation.Location = New System.Drawing.Point(749, 95)
        Me.ddlLocation.Name = "ddlLocation"
        Me.ddlLocation.Size = New System.Drawing.Size(135, 21)
        Me.ddlLocation.Sorted = True
        Me.ddlLocation.TabIndex = 11
        Me.ddlLocation.Visible = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(734, 99)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(11, 13)
        Me.Label34.TabIndex = 213
        Me.Label34.Text = ":"
        Me.Label34.Visible = False
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.Color.Black
        Me.lblLocation.Location = New System.Drawing.Point(643, 99)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(54, 13)
        Me.lblLocation.TabIndex = 211
        Me.lblLocation.Text = "Location"
        Me.lblLocation.Visible = False
        '
        'btnLookUpContractNo
        '
        Me.btnLookUpContractNo.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.btnLookUpContractNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLookUpContractNo.FlatAppearance.BorderSize = 0
        Me.btnLookUpContractNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnLookUpContractNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLookUpContractNo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnLookUpContractNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLookUpContractNo.Location = New System.Drawing.Point(891, 57)
        Me.btnLookUpContractNo.Name = "btnLookUpContractNo"
        Me.btnLookUpContractNo.Size = New System.Drawing.Size(30, 35)
        Me.btnLookUpContractNo.TabIndex = 10
        Me.btnLookUpContractNo.TabStop = False
        Me.btnLookUpContractNo.UseVisualStyleBackColor = True
        Me.btnLookUpContractNo.Visible = False
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
        Me.ibtnSearchVehicleCode.Location = New System.Drawing.Point(611, 7)
        Me.ibtnSearchVehicleCode.Name = "ibtnSearchVehicleCode"
        Me.ibtnSearchVehicleCode.Size = New System.Drawing.Size(30, 35)
        Me.ibtnSearchVehicleCode.TabIndex = 8
        Me.ibtnSearchVehicleCode.TabStop = False
        Me.ibtnSearchVehicleCode.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(16, 103)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblStatus.TabIndex = 171
        Me.lblStatus.Text = "Status"
        '
        'rbOperational
        '
        Me.rbOperational.AutoSize = True
        Me.rbOperational.Checked = True
        Me.rbOperational.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rbOperational.ForeColor = System.Drawing.Color.Black
        Me.rbOperational.Location = New System.Drawing.Point(64, 101)
        Me.rbOperational.Name = "rbOperational"
        Me.rbOperational.Size = New System.Drawing.Size(91, 17)
        Me.rbOperational.TabIndex = 11
        Me.rbOperational.TabStop = True
        Me.rbOperational.Text = "Operational"
        Me.rbOperational.UseVisualStyleBackColor = True
        '
        'rbStandBy
        '
        Me.rbStandBy.AutoSize = True
        Me.rbStandBy.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rbStandBy.ForeColor = System.Drawing.Color.Black
        Me.rbStandBy.Location = New System.Drawing.Point(297, 101)
        Me.rbStandBy.Name = "rbStandBy"
        Me.rbStandBy.Size = New System.Drawing.Size(77, 17)
        Me.rbStandBy.TabIndex = 168
        Me.rbStandBy.Text = "Stand By"
        Me.rbStandBy.UseVisualStyleBackColor = True
        '
        'rbBreakDown
        '
        Me.rbBreakDown.AutoSize = True
        Me.rbBreakDown.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rbBreakDown.ForeColor = System.Drawing.Color.Black
        Me.rbBreakDown.Location = New System.Drawing.Point(168, 101)
        Me.rbBreakDown.Name = "rbBreakDown"
        Me.rbBreakDown.Size = New System.Drawing.Size(95, 17)
        Me.rbBreakDown.TabIndex = 169
        Me.rbBreakDown.Text = "Break Down"
        Me.rbBreakDown.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(455, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 166
        Me.Label5.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(455, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 165
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(455, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(734, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 163
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(734, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 162
        Me.Label1.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(734, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 13)
        Me.Label16.TabIndex = 161
        Me.Label16.Text = ":"
        '
        'txtContractNo
        '
        Me.txtContractNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContractNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractNo.Location = New System.Drawing.Point(749, 67)
        Me.txtContractNo.MaxLength = 50
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(135, 21)
        Me.txtContractNo.TabIndex = 9
        '
        'txtVehicleCode
        '
        Me.txtVehicleCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleCode.Location = New System.Drawing.Point(470, 14)
        Me.txtVehicleCode.MaxLength = 50
        Me.txtVehicleCode.Name = "txtVehicleCode"
        Me.txtVehicleCode.Size = New System.Drawing.Size(135, 21)
        Me.txtVehicleCode.TabIndex = 7
        '
        'txtBatchValue
        '
        Me.txtBatchValue.BackColor = System.Drawing.SystemColors.Control
        Me.txtBatchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBatchValue.Location = New System.Drawing.Point(749, 14)
        Me.txtBatchValue.MaxLength = 50
        Me.txtBatchValue.Name = "txtBatchValue"
        Me.txtBatchValue.ReadOnly = True
        Me.txtBatchValue.Size = New System.Drawing.Size(135, 21)
        Me.txtBatchValue.TabIndex = 157
        Me.txtBatchValue.TabStop = False
        '
        'txtUOM
        '
        Me.txtUOM.BackColor = System.Drawing.SystemColors.Control
        Me.txtUOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUOM.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUOM.Location = New System.Drawing.Point(749, 40)
        Me.txtUOM.MaxLength = 50
        Me.txtUOM.Name = "txtUOM"
        Me.txtUOM.ReadOnly = True
        Me.txtUOM.Size = New System.Drawing.Size(135, 21)
        Me.txtUOM.TabIndex = 156
        Me.txtUOM.TabStop = False
        '
        'txtVehicleModel
        '
        Me.txtVehicleModel.BackColor = System.Drawing.SystemColors.Control
        Me.txtVehicleModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleModel.Location = New System.Drawing.Point(470, 40)
        Me.txtVehicleModel.MaxLength = 50
        Me.txtVehicleModel.Name = "txtVehicleModel"
        Me.txtVehicleModel.ReadOnly = True
        Me.txtVehicleModel.Size = New System.Drawing.Size(135, 21)
        Me.txtVehicleModel.TabIndex = 155
        Me.txtVehicleModel.TabStop = False
        '
        'txtVehicleRegNo
        '
        Me.txtVehicleRegNo.BackColor = System.Drawing.SystemColors.Control
        Me.txtVehicleRegNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleRegNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleRegNo.Location = New System.Drawing.Point(470, 67)
        Me.txtVehicleRegNo.MaxLength = 50
        Me.txtVehicleRegNo.Name = "txtVehicleRegNo"
        Me.txtVehicleRegNo.ReadOnly = True
        Me.txtVehicleRegNo.Size = New System.Drawing.Size(135, 21)
        Me.txtVehicleRegNo.TabIndex = 154
        Me.txtVehicleRegNo.TabStop = False
        '
        'lblOperatedBy
        '
        Me.lblOperatedBy.AutoSize = True
        Me.lblOperatedBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperatedBy.ForeColor = System.Drawing.Color.Black
        Me.lblOperatedBy.Location = New System.Drawing.Point(14, 70)
        Me.lblOperatedBy.Name = "lblOperatedBy"
        Me.lblOperatedBy.Size = New System.Drawing.Size(79, 13)
        Me.lblOperatedBy.TabIndex = 153
        Me.lblOperatedBy.Text = "Operated By"
        '
        'lblVehicleModel
        '
        Me.lblVehicleModel.AutoSize = True
        Me.lblVehicleModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleModel.ForeColor = System.Drawing.Color.Black
        Me.lblVehicleModel.Location = New System.Drawing.Point(312, 45)
        Me.lblVehicleModel.Name = "lblVehicleModel"
        Me.lblVehicleModel.Size = New System.Drawing.Size(85, 13)
        Me.lblVehicleModel.TabIndex = 151
        Me.lblVehicleModel.Text = "Vehicle Model"
        '
        'lblUOM
        '
        Me.lblUOM.AutoSize = True
        Me.lblUOM.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUOM.ForeColor = System.Drawing.Color.Black
        Me.lblUOM.Location = New System.Drawing.Point(643, 47)
        Me.lblUOM.Name = "lblUOM"
        Me.lblUOM.Size = New System.Drawing.Size(33, 13)
        Me.lblUOM.TabIndex = 150
        Me.lblUOM.Text = "UOM"
        '
        'lblContractNo
        '
        Me.lblContractNo.AutoSize = True
        Me.lblContractNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContractNo.ForeColor = System.Drawing.Color.Black
        Me.lblContractNo.Location = New System.Drawing.Point(643, 71)
        Me.lblContractNo.Name = "lblContractNo"
        Me.lblContractNo.Size = New System.Drawing.Size(75, 13)
        Me.lblContractNo.TabIndex = 149
        Me.lblContractNo.Text = "Contract No"
        '
        'lblBatchValue
        '
        Me.lblBatchValue.AutoSize = True
        Me.lblBatchValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBatchValue.ForeColor = System.Drawing.Color.Black
        Me.lblBatchValue.Location = New System.Drawing.Point(643, 23)
        Me.lblBatchValue.Name = "lblBatchValue"
        Me.lblBatchValue.Size = New System.Drawing.Size(75, 13)
        Me.lblBatchValue.TabIndex = 148
        Me.lblBatchValue.Text = "Batch Value"
        '
        'lblVehicleRegNo
        '
        Me.lblVehicleRegNo.AutoSize = True
        Me.lblVehicleRegNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleRegNo.ForeColor = System.Drawing.Color.Black
        Me.lblVehicleRegNo.Location = New System.Drawing.Point(312, 70)
        Me.lblVehicleRegNo.Name = "lblVehicleRegNo"
        Me.lblVehicleRegNo.Size = New System.Drawing.Size(93, 13)
        Me.lblVehicleRegNo.TabIndex = 147
        Me.lblVehicleRegNo.Text = "Vehicle Reg No"
        '
        'lblVehicleDescription
        '
        Me.lblVehicleDescription.AutoSize = True
        Me.lblVehicleDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleDescription.ForeColor = System.Drawing.Color.Black
        Me.lblVehicleDescription.Location = New System.Drawing.Point(14, 45)
        Me.lblVehicleDescription.Name = "lblVehicleDescription"
        Me.lblVehicleDescription.Size = New System.Drawing.Size(116, 13)
        Me.lblVehicleDescription.TabIndex = 146
        Me.lblVehicleDescription.Text = "Vehicle Description"
        '
        'txtVehicleDescription
        '
        Me.txtVehicleDescription.BackColor = System.Drawing.SystemColors.Control
        Me.txtVehicleDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleDescription.Location = New System.Drawing.Point(166, 40)
        Me.txtVehicleDescription.MaxLength = 50
        Me.txtVehicleDescription.Name = "txtVehicleDescription"
        Me.txtVehicleDescription.ReadOnly = True
        Me.txtVehicleDescription.Size = New System.Drawing.Size(135, 21)
        Me.txtVehicleDescription.TabIndex = 145
        Me.txtVehicleDescription.TabStop = False
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(166, 14)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(133, 20)
        Me.dtpDate.TabIndex = 6
        '
        'txtOperatedBy
        '
        Me.txtOperatedBy.BackColor = System.Drawing.SystemColors.Control
        Me.txtOperatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperatedBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperatedBy.Location = New System.Drawing.Point(166, 67)
        Me.txtOperatedBy.MaxLength = 50
        Me.txtOperatedBy.Name = "txtOperatedBy"
        Me.txtOperatedBy.ReadOnly = True
        Me.txtOperatedBy.Size = New System.Drawing.Size(135, 21)
        Me.txtOperatedBy.TabIndex = 143
        Me.txtOperatedBy.TabStop = False
        '
        'lblVehicleCode
        '
        Me.lblVehicleCode.AutoSize = True
        Me.lblVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleCode.ForeColor = System.Drawing.Color.Red
        Me.lblVehicleCode.Location = New System.Drawing.Point(312, 20)
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
        Me.Label13.Location = New System.Drawing.Point(151, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 13)
        Me.Label13.TabIndex = 131
        Me.Label13.Text = ":"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(151, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 13)
        Me.Label14.TabIndex = 130
        Me.Label14.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(151, 17)
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
        Me.lblDate.Location = New System.Drawing.Point(14, 20)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(34, 13)
        Me.lblDate.TabIndex = 1
        Me.lblDate.Text = "Date"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(32, 302)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(58, 13)
        Me.lblRemarks.TabIndex = 147
        Me.lblRemarks.Text = "Remarks"
        '
        'tpViewVRL
        '
        Me.tpViewVRL.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tpViewVRL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpViewVRL.Controls.Add(Me.Panel1)
        Me.tpViewVRL.Controls.Add(Me.PnlSearch)
        Me.tpViewVRL.Location = New System.Drawing.Point(4, 22)
        Me.tpViewVRL.Name = "tpViewVRL"
        Me.tpViewVRL.Padding = New System.Windows.Forms.Padding(3)
        Me.tpViewVRL.Size = New System.Drawing.Size(1001, 799)
        Me.tpViewVRL.TabIndex = 1
        Me.tpViewVRL.Text = "View"
        Me.tpViewVRL.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgVehicleCode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 147)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(995, 400)
        Me.Panel1.TabIndex = 41
        '
        'dgVehicleCode
        '
        Me.dgVehicleCode.AllowUserToAddRows = False
        Me.dgVehicleCode.AllowUserToDeleteRows = False
        Me.dgVehicleCode.AllowUserToResizeColumns = False
        Me.dgVehicleCode.AllowUserToResizeRows = False
        Me.dgVehicleCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgVehicleCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgVehicleCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgVehicleCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgVehicleCode.ColumnHeadersHeight = 30
        Me.dgVehicleCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgVehicleCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvLogDate, Me.VHWSCode, Me.ViewPosted})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgVehicleCode.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgVehicleCode.EnableHeadersVisualStyles = False
        Me.dgVehicleCode.GridColor = System.Drawing.Color.Gray
        Me.dgVehicleCode.Location = New System.Drawing.Point(0, 0)
        Me.dgVehicleCode.MultiSelect = False
        Me.dgVehicleCode.Name = "dgVehicleCode"
        Me.dgVehicleCode.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgVehicleCode.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgVehicleCode.RowHeadersVisible = False
        Me.dgVehicleCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgVehicleCode.Size = New System.Drawing.Size(376, 320)
        Me.dgVehicleCode.TabIndex = 4
        Me.dgVehicleCode.VirtualMode = True
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
        Me.PnlSearch.CaptionText = "Search Vehicle Running Log"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.btnViewReport)
        Me.PnlSearch.Controls.Add(Me.lblViewVehicleCode)
        Me.PnlSearch.Controls.Add(Me.btnSearch)
        Me.PnlSearch.Controls.Add(Me.chkDate)
        Me.PnlSearch.Controls.Add(Me.lblSearchby)
        Me.PnlSearch.Controls.Add(Me.Panel2)
        Me.PnlSearch.Controls.Add(Me.dtpSearchBy)
        Me.PnlSearch.Controls.Add(Me.txtVehicleCodeView)
        Me.PnlSearch.Controls.Add(Me.Label30)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlSearch.Moveable = True
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(995, 144)
        Me.PnlSearch.TabIndex = 39
        '
        'btnViewReport
        '
        Me.btnViewReport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.Image = CType(resources.GetObject("btnViewReport.Image"), System.Drawing.Image)
        Me.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewReport.Location = New System.Drawing.Point(700, 66)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(144, 29)
        Me.btnViewReport.TabIndex = 4
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'lblViewVehicleCode
        '
        Me.lblViewVehicleCode.AutoSize = True
        Me.lblViewVehicleCode.BackColor = System.Drawing.Color.Transparent
        Me.lblViewVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblViewVehicleCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblViewVehicleCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblViewVehicleCode.Location = New System.Drawing.Point(340, 43)
        Me.lblViewVehicleCode.Name = "lblViewVehicleCode"
        Me.lblViewVehicleCode.Size = New System.Drawing.Size(82, 13)
        Me.lblViewVehicleCode.TabIndex = 92
        Me.lblViewVehicleCode.Text = "Vehicle Code"
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearch.Location = New System.Drawing.Point(536, 66)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(144, 29)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(147, 43)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(49, 17)
        Me.chkDate.TabIndex = 0
        Me.chkDate.Text = "Date"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'lblSearchby
        '
        Me.lblSearchby.AutoSize = True
        Me.lblSearchby.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchby.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearchby.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearchby.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchby.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchby.Location = New System.Drawing.Point(3, 43)
        Me.lblSearchby.Name = "lblSearchby"
        Me.lblSearchby.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchby.TabIndex = 90
        Me.lblSearchby.Text = "Search By"
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
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.Size = New System.Drawing.Size(1118, 572)
        Me.DataGridView1.TabIndex = 31
        '
        'dtpSearchBy
        '
        Me.dtpSearchBy.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchBy.Enabled = False
        Me.dtpSearchBy.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtpSearchBy.Location = New System.Drawing.Point(143, 69)
        Me.dtpSearchBy.Name = "dtpSearchBy"
        Me.dtpSearchBy.Size = New System.Drawing.Size(169, 20)
        Me.dtpSearchBy.TabIndex = 1
        '
        'txtVehicleCodeView
        '
        Me.txtVehicleCodeView.Location = New System.Drawing.Point(343, 69)
        Me.txtVehicleCodeView.MaxLength = 50
        Me.txtVehicleCodeView.Name = "txtVehicleCodeView"
        Me.txtVehicleCodeView.Size = New System.Drawing.Size(169, 20)
        Me.txtVehicleCodeView.TabIndex = 2
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(129, 43)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(12, 13)
        Me.Label30.TabIndex = 70
        Me.Label30.Text = ":"
        '
        'cmsDelete
        '
        Me.cmsDelete.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsDelete.Name = "cmsRGN"
        Me.cmsDelete.Size = New System.Drawing.Size(108, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'cmsView
        '
        Me.cmsView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiViewAdd, Me.tsmiViewEdit, Me.tsmiViewDelete})
        Me.cmsView.Name = "cmsRGN"
        Me.cmsView.Size = New System.Drawing.Size(108, 70)
        '
        'tsmiViewAdd
        '
        Me.tsmiViewAdd.Image = CType(resources.GetObject("tsmiViewAdd.Image"), System.Drawing.Image)
        Me.tsmiViewAdd.Name = "tsmiViewAdd"
        Me.tsmiViewAdd.Size = New System.Drawing.Size(107, 22)
        Me.tsmiViewAdd.Text = "Add"
        '
        'tsmiViewEdit
        '
        Me.tsmiViewEdit.Image = CType(resources.GetObject("tsmiViewEdit.Image"), System.Drawing.Image)
        Me.tsmiViewEdit.Name = "tsmiViewEdit"
        Me.tsmiViewEdit.Size = New System.Drawing.Size(107, 22)
        Me.tsmiViewEdit.Text = "Edit"
        '
        'tsmiViewDelete
        '
        Me.tsmiViewDelete.Image = CType(resources.GetObject("tsmiViewDelete.Image"), System.Drawing.Image)
        Me.tsmiViewDelete.Name = "tsmiViewDelete"
        Me.tsmiViewDelete.Size = New System.Drawing.Size(107, 22)
        Me.tsmiViewDelete.Text = "Delete"
        '
        'dgvLogDate
        '
        Me.dgvLogDate.DataPropertyName = "LogDate"
        Me.dgvLogDate.HeaderText = "Date"
        Me.dgvLogDate.Name = "dgvLogDate"
        Me.dgvLogDate.ReadOnly = True
        '
        'VHWSCode
        '
        Me.VHWSCode.DataPropertyName = "VHWSCode"
        Me.VHWSCode.HeaderText = "Vehicle Code"
        Me.VHWSCode.Name = "VHWSCode"
        Me.VHWSCode.ReadOnly = True
        Me.VHWSCode.Width = 150
        '
        'ViewPosted
        '
        Me.ViewPosted.DataPropertyName = "Posted"
        Me.ViewPosted.HeaderText = "Approve"
        Me.ViewPosted.Name = "ViewPosted"
        Me.ViewPosted.ReadOnly = True
        '
        'VehicleRunningLogFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1040, 732)
        Me.Controls.Add(Me.plIB1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "VehicleRunningLogFrm"
        Me.Text = "Vehicle Running Log"
        Me.plIB1.ResumeLayout(False)
        Me.tbVehicleRunningLog.ResumeLayout(False)
        Me.tbpgAdd.ResumeLayout(False)
        Me.gbAddReset.ResumeLayout(False)
        Me.gbListOfVehicleLog.ResumeLayout(False)
        CType(Me.dgvListOfVehicleLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEntryArea.ResumeLayout(False)
        Me.pnlEntryArea.PerformLayout()
        Me.gbVehicleRunningData.ResumeLayout(False)
        Me.gbVehicleRunningData.PerformLayout()
        Me.grpDefault.ResumeLayout(False)
        Me.grpDefault.PerformLayout()
        Me.tpViewVRL.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgVehicleCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDelete.ResumeLayout(False)
        Me.cmsView.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plIB1 As System.Windows.Forms.Panel
    Friend WithEvents tbVehicleRunningLog As System.Windows.Forms.TabControl
    Friend WithEvents tpViewVRL As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleCodeView As System.Windows.Forms.TextBox
    Friend WithEvents tbpgAdd As System.Windows.Forms.TabPage
    Friend WithEvents dtpSearchBy As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpDefault As System.Windows.Forms.GroupBox
    Friend WithEvents txtVehicleDescription As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtOperatedBy As System.Windows.Forms.TextBox
    Friend WithEvents lblVehicleCode As System.Windows.Forms.Label
    Friend WithEvents lblContractorValue As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgVehicleCode As System.Windows.Forms.DataGridView
    Friend WithEvents gbListOfVehicleLog As System.Windows.Forms.GroupBox
    Friend WithEvents dgvListOfVehicleLog As System.Windows.Forms.DataGridView
    Friend WithEvents gbVehicleRunningData As System.Windows.Forms.GroupBox
    Friend WithEvents lblVehicleDescription As System.Windows.Forms.Label
    Friend WithEvents lblUOM As System.Windows.Forms.Label
    Friend WithEvents lblContractNo As System.Windows.Forms.Label
    Friend WithEvents lblBatchValue As System.Windows.Forms.Label
    Friend WithEvents lblVehicleRegNo As System.Windows.Forms.Label
    Friend WithEvents lblVehicleModel As System.Windows.Forms.Label
    Friend WithEvents lblOperatedBy As System.Windows.Forms.Label
    Friend WithEvents txtBatchValue As System.Windows.Forms.TextBox
    Friend WithEvents txtUOM As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleModel As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleRegNo As System.Windows.Forms.TextBox
    Friend WithEvents txtContractNo As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleCode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents rbOperational As System.Windows.Forms.RadioButton
    Friend WithEvents rbStandBy As System.Windows.Forms.RadioButton
    Friend WithEvents rbBreakDown As System.Windows.Forms.RadioButton
    Friend WithEvents lblStartTime As System.Windows.Forms.Label
    Friend WithEvents lblTotalKms As System.Windows.Forms.Label
    Friend WithEvents lblStartKms As System.Windows.Forms.Label
    Friend WithEvents lblEndKms As System.Windows.Forms.Label
    Friend WithEvents lblEndTime As System.Windows.Forms.Label
    Friend WithEvents lblVehicleActivity As System.Windows.Forms.Label
    Friend WithEvents lblSubBlock As System.Windows.Forms.Label
    Friend WithEvents lblDIV As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblTotalHours As System.Windows.Forms.Label
    Friend WithEvents lblYOP As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalHours As System.Windows.Forms.TextBox
    Friend WithEvents txtShift As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalKms As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleActivity As System.Windows.Forms.TextBox
    Friend WithEvents txtDIV As System.Windows.Forms.TextBox
    Friend WithEvents txtYOP As System.Windows.Forms.TextBox
    Friend WithEvents txtSubBlock As System.Windows.Forms.TextBox
    Friend WithEvents txtStartKms As System.Windows.Forms.TextBox
    Friend WithEvents txtEndKms As System.Windows.Forms.TextBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnLookUpDIV As System.Windows.Forms.Button
    Friend WithEvents btnLookUpSubBlock As System.Windows.Forms.Button
    Friend WithEvents btnLookUpContractNo As System.Windows.Forms.Button
    Friend WithEvents ibtnSearchVehicleCode As System.Windows.Forms.Button
    Friend WithEvents gbAddReset As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrintFFBDO As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents ddlLocation As System.Windows.Forms.ComboBox
    Friend WithEvents btnSaveOrUpdate As System.Windows.Forms.Button
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblSearchby As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblViewVehicleCode As System.Windows.Forms.Label
    Friend WithEvents cmsDelete As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiViewDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiViewAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiViewEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents rbFFBdeliverytoMill As System.Windows.Forms.RadioButton
    Friend WithEvents pnlEntryArea As System.Windows.Forms.Panel
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VehicleCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalHrs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartKms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndKms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalKms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Activity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Posted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtEndHr As System.Windows.Forms.TextBox
    Friend WithEvents txtEndMin As System.Windows.Forms.TextBox
    Friend WithEvents txtStartMin As System.Windows.Forms.TextBox
    Friend WithEvents txtStartHr As System.Windows.Forms.TextBox
    Friend WithEvents btnActivity As System.Windows.Forms.Button
    Friend WithEvents btnNIK As System.Windows.Forms.Button
    Friend WithEvents txtDriverName As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtNIK As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dgvLogDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHWSCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPosted As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

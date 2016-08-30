<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadingCPOFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoadingCPOFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpLoadCPO = New System.Windows.Forms.GroupBox
        Me.txtLoadRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.btnResetLoad = New System.Windows.Forms.Button
        Me.btnAddLoad = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtLoadMonthToDate = New System.Windows.Forms.TextBox
        Me.lblLoadMonthDate = New System.Windows.Forms.Label
        Me.txtLoadQty = New System.Windows.Forms.TextBox
        Me.lblLoadQty = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblToLoading = New System.Windows.Forms.Label
        Me.cmbLoadLocation = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblLoadStorage = New System.Windows.Forms.Label
        Me.cmbLoadTank = New System.Windows.Forms.ComboBox
        Me.lblT3Name = New System.Windows.Forms.Label
        Me.lblT1Name = New System.Windows.Forms.Label
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.dtpCPOViewDate = New System.Windows.Forms.DateTimePicker
        Me.Label46 = New System.Windows.Forms.Label
        Me.btnViewSearch = New System.Windows.Forms.Button
        Me.chkCPODate = New System.Windows.Forms.CheckBox
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.lblViewStatus = New System.Windows.Forms.Label
        Me.dtpAdjustmentViewDate = New System.Windows.Forms.DateTimePicker
        Me.lblSearch = New System.Windows.Forms.Label
        Me.dgvCPOView = New System.Windows.Forms.DataGridView
        Me.gvCPODate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gvProductionID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyToday = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tpCPOView = New System.Windows.Forms.TabPage
        Me.lblAdjSearchNo = New System.Windows.Forms.Label
        Me.CMSLoadCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LoadCPOEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadCPODelete = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsStockCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StockCPOEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.StockCPODelete = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsTranshipCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TranshipEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.TranshipDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.tcLoadingCPO = New System.Windows.Forms.TabControl
        Me.tpCPOSave = New System.Windows.Forms.TabPage
        Me.panCPO = New System.Windows.Forms.Panel
        Me.btnDeleteAll = New System.Windows.Forms.Button
        Me.grpLoadCPORecords = New System.Windows.Forms.GroupBox
        Me.dgvLoadCPODetails = New System.Windows.Forms.DataGridView
        Me.dgclLoadStorageNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclLoadStorageID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclLoadStorageLocID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclToLoading = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoadDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclLoadQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclLoadMonthDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProdLoadingID1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProductionIDLoad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclCPODateLoad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclLoadRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.grpLoadDate = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpCPODate = New System.Windows.Forms.DateTimePicker
        Me.lblLoadDate = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.grpLoadCPO.SuspendLayout()
        Me.PnlSearch.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsCPO.SuspendLayout()
        CType(Me.dgvCPOView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCPOView.SuspendLayout()
        Me.CMSLoadCPO.SuspendLayout()
        Me.cmsStockCPO.SuspendLayout()
        Me.cmsTranshipCPO.SuspendLayout()
        Me.tcLoadingCPO.SuspendLayout()
        Me.tpCPOSave.SuspendLayout()
        Me.panCPO.SuspendLayout()
        Me.grpLoadCPORecords.SuspendLayout()
        CType(Me.dgvLoadCPODetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpLoadDate.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(8, -47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 14)
        Me.Label13.TabIndex = 408
        Me.Label13.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(101, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 348
        Me.Label3.Text = ":"
        '
        'grpLoadCPO
        '
        Me.grpLoadCPO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpLoadCPO.BackColor = System.Drawing.Color.Transparent
        Me.grpLoadCPO.Controls.Add(Me.Label3)
        Me.grpLoadCPO.Controls.Add(Me.txtLoadRemarks)
        Me.grpLoadCPO.Controls.Add(Me.lblRemarks)
        Me.grpLoadCPO.Controls.Add(Me.btnResetLoad)
        Me.grpLoadCPO.Controls.Add(Me.btnAddLoad)
        Me.grpLoadCPO.Controls.Add(Me.Label20)
        Me.grpLoadCPO.Controls.Add(Me.Label23)
        Me.grpLoadCPO.Controls.Add(Me.txtLoadMonthToDate)
        Me.grpLoadCPO.Controls.Add(Me.lblLoadMonthDate)
        Me.grpLoadCPO.Controls.Add(Me.txtLoadQty)
        Me.grpLoadCPO.Controls.Add(Me.lblLoadQty)
        Me.grpLoadCPO.Controls.Add(Me.Label18)
        Me.grpLoadCPO.Controls.Add(Me.lblToLoading)
        Me.grpLoadCPO.Controls.Add(Me.cmbLoadLocation)
        Me.grpLoadCPO.Controls.Add(Me.Label16)
        Me.grpLoadCPO.Controls.Add(Me.lblLoadStorage)
        Me.grpLoadCPO.Controls.Add(Me.cmbLoadTank)
        Me.grpLoadCPO.Controls.Add(Me.lblT3Name)
        Me.grpLoadCPO.Controls.Add(Me.lblT1Name)
        Me.grpLoadCPO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLoadCPO.Location = New System.Drawing.Point(0, 44)
        Me.grpLoadCPO.Name = "grpLoadCPO"
        Me.grpLoadCPO.Size = New System.Drawing.Size(689, 189)
        Me.grpLoadCPO.TabIndex = 101
        Me.grpLoadCPO.TabStop = False
        Me.grpLoadCPO.Text = "Loading CPO"
        '
        'txtLoadRemarks
        '
        Me.txtLoadRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoadRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadRemarks.Location = New System.Drawing.Point(128, 114)
        Me.txtLoadRemarks.MaxLength = 300
        Me.txtLoadRemarks.Multiline = True
        Me.txtLoadRemarks.Name = "txtLoadRemarks"
        Me.txtLoadRemarks.Size = New System.Drawing.Size(188, 64)
        Me.txtLoadRemarks.TabIndex = 105
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(9, 117)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(58, 13)
        Me.lblRemarks.TabIndex = 347
        Me.lblRemarks.Text = "Remarks"
        '
        'btnResetLoad
        '
        Me.btnResetLoad.BackgroundImage = CType(resources.GetObject("btnResetLoad.BackgroundImage"), System.Drawing.Image)
        Me.btnResetLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetLoad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetLoad.Image = CType(resources.GetObject("btnResetLoad.Image"), System.Drawing.Image)
        Me.btnResetLoad.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnResetLoad.Location = New System.Drawing.Point(469, 139)
        Me.btnResetLoad.Name = "btnResetLoad"
        Me.btnResetLoad.Size = New System.Drawing.Size(81, 22)
        Me.btnResetLoad.TabIndex = 107
        Me.btnResetLoad.Text = "Reset"
        Me.btnResetLoad.UseVisualStyleBackColor = True
        '
        'btnAddLoad
        '
        Me.btnAddLoad.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAddLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddLoad.Image = CType(resources.GetObject("btnAddLoad.Image"), System.Drawing.Image)
        Me.btnAddLoad.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAddLoad.Location = New System.Drawing.Point(375, 139)
        Me.btnAddLoad.Name = "btnAddLoad"
        Me.btnAddLoad.Size = New System.Drawing.Size(78, 22)
        Me.btnAddLoad.TabIndex = 106
        Me.btnAddLoad.Text = "Add"
        Me.btnAddLoad.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(101, 87)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 13)
        Me.Label20.TabIndex = 180
        Me.Label20.Text = ":"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(346, 87)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 179
        Me.Label23.Text = ":"
        '
        'txtLoadMonthToDate
        '
        Me.txtLoadMonthToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoadMonthToDate.Enabled = False
        Me.txtLoadMonthToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadMonthToDate.Location = New System.Drawing.Point(363, 83)
        Me.txtLoadMonthToDate.MaxLength = 18
        Me.txtLoadMonthToDate.Name = "txtLoadMonthToDate"
        Me.txtLoadMonthToDate.Size = New System.Drawing.Size(98, 21)
        Me.txtLoadMonthToDate.TabIndex = 104
        '
        'lblLoadMonthDate
        '
        Me.lblLoadMonthDate.AutoSize = True
        Me.lblLoadMonthDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadMonthDate.ForeColor = System.Drawing.Color.Red
        Me.lblLoadMonthDate.Location = New System.Drawing.Point(232, 87)
        Me.lblLoadMonthDate.Name = "lblLoadMonthDate"
        Me.lblLoadMonthDate.Size = New System.Drawing.Size(111, 13)
        Me.lblLoadMonthDate.TabIndex = 178
        Me.lblLoadMonthDate.Text = "Month To date(KG)"
        '
        'txtLoadQty
        '
        Me.txtLoadQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoadQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadQty.Location = New System.Drawing.Point(128, 83)
        Me.txtLoadQty.MaxLength = 18
        Me.txtLoadQty.Name = "txtLoadQty"
        Me.txtLoadQty.Size = New System.Drawing.Size(98, 21)
        Me.txtLoadQty.TabIndex = 103
        '
        'lblLoadQty
        '
        Me.lblLoadQty.AutoSize = True
        Me.lblLoadQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadQty.ForeColor = System.Drawing.Color.Red
        Me.lblLoadQty.Location = New System.Drawing.Point(10, 87)
        Me.lblLoadQty.Name = "lblLoadQty"
        Me.lblLoadQty.Size = New System.Drawing.Size(82, 13)
        Me.lblLoadQty.TabIndex = 177
        Me.lblLoadQty.Text = "Quantity (KG)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(101, 54)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(11, 13)
        Me.Label18.TabIndex = 176
        Me.Label18.Text = ":"
        '
        'lblToLoading
        '
        Me.lblToLoading.AutoSize = True
        Me.lblToLoading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToLoading.ForeColor = System.Drawing.Color.Red
        Me.lblToLoading.Location = New System.Drawing.Point(9, 54)
        Me.lblToLoading.Name = "lblToLoading"
        Me.lblToLoading.Size = New System.Drawing.Size(69, 13)
        Me.lblToLoading.TabIndex = 175
        Me.lblToLoading.Text = "To Loading"
        '
        'cmbLoadLocation
        '
        Me.cmbLoadLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLoadLocation.FormattingEnabled = True
        Me.cmbLoadLocation.Location = New System.Drawing.Point(128, 51)
        Me.cmbLoadLocation.Name = "cmbLoadLocation"
        Me.cmbLoadLocation.Size = New System.Drawing.Size(333, 21)
        Me.cmbLoadLocation.TabIndex = 102
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(101, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 13)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = ":"
        '
        'lblLoadStorage
        '
        Me.lblLoadStorage.AutoSize = True
        Me.lblLoadStorage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadStorage.ForeColor = System.Drawing.Color.Red
        Me.lblLoadStorage.Location = New System.Drawing.Point(9, 24)
        Me.lblLoadStorage.Name = "lblLoadStorage"
        Me.lblLoadStorage.Size = New System.Drawing.Size(52, 13)
        Me.lblLoadStorage.TabIndex = 172
        Me.lblLoadStorage.Text = "Production Volume"
        '
        'cmbLoadTank
        '
        Me.cmbLoadTank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLoadTank.FormattingEnabled = True
        Me.cmbLoadTank.Location = New System.Drawing.Point(128, 21)
        Me.cmbLoadTank.Name = "cmbLoadTank"
        Me.cmbLoadTank.Size = New System.Drawing.Size(333, 21)
        Me.cmbLoadTank.TabIndex = 101
        '
        'lblT3Name
        '
        Me.lblT3Name.AutoSize = True
        Me.lblT3Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT3Name.ForeColor = System.Drawing.Color.Black
        Me.lblT3Name.Location = New System.Drawing.Point(1247, 158)
        Me.lblT3Name.Name = "lblT3Name"
        Me.lblT3Name.Size = New System.Drawing.Size(0, 13)
        Me.lblT3Name.TabIndex = 158
        '
        'lblT1Name
        '
        Me.lblT1Name.AutoSize = True
        Me.lblT1Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT1Name.ForeColor = System.Drawing.Color.Black
        Me.lblT1Name.Location = New System.Drawing.Point(1247, 130)
        Me.lblT1Name.Name = "lblT1Name"
        Me.lblT1Name.Size = New System.Drawing.Size(0, 13)
        Me.lblT1Name.TabIndex = 157
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
        Me.PnlSearch.CaptionText = "Search Loading CPO "
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.Panel2)
        Me.PnlSearch.Controls.Add(Me.lblSearchBy)
        Me.PnlSearch.Controls.Add(Me.dtpCPOViewDate)
        Me.PnlSearch.Controls.Add(Me.Label46)
        Me.PnlSearch.Controls.Add(Me.btnViewSearch)
        Me.PnlSearch.Controls.Add(Me.chkCPODate)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(749, 105)
        Me.PnlSearch.TabIndex = 415
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
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
        'dtpCPOViewDate
        '
        Me.dtpCPOViewDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpCPOViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPOViewDate.Location = New System.Drawing.Point(189, 74)
        Me.dtpCPOViewDate.Name = "dtpCPOViewDate"
        Me.dtpCPOViewDate.Size = New System.Drawing.Size(135, 21)
        Me.dtpCPOViewDate.TabIndex = 502
        Me.dtpCPOViewDate.Value = New Date(2010, 2, 15, 11, 44, 0, 0)
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label46.Location = New System.Drawing.Point(80, 45)
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
        Me.btnViewSearch.Location = New System.Drawing.Point(561, 67)
        Me.btnViewSearch.Name = "btnViewSearch"
        Me.btnViewSearch.Size = New System.Drawing.Size(116, 29)
        Me.btnViewSearch.TabIndex = 503
        Me.btnViewSearch.Text = "Search"
        Me.btnViewSearch.UseVisualStyleBackColor = True
        '
        'chkCPODate
        '
        Me.chkCPODate.AutoSize = True
        Me.chkCPODate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkCPODate.Location = New System.Drawing.Point(116, 74)
        Me.chkCPODate.Name = "chkCPODate"
        Me.chkCPODate.Size = New System.Drawing.Size(57, 17)
        Me.chkCPODate.TabIndex = 501
        Me.chkCPODate.TabStop = False
        Me.chkCPODate.Text = " Date"
        Me.chkCPODate.UseVisualStyleBackColor = True
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'cmsCPO
        '
        Me.cmsCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsCPO.Name = "cmsIPR"
        Me.cmsCPO.Size = New System.Drawing.Size(108, 70)
        '
        'lblViewStatus
        '
        Me.lblViewStatus.AutoSize = True
        Me.lblViewStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblViewStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblViewStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblViewStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblViewStatus.Location = New System.Drawing.Point(343, -47)
        Me.lblViewStatus.Name = "lblViewStatus"
        Me.lblViewStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblViewStatus.TabIndex = 410
        Me.lblViewStatus.Text = "Status"
        '
        'dtpAdjustmentViewDate
        '
        Me.dtpAdjustmentViewDate.CalendarFont = New System.Drawing.Font("Verdana", 7.5!)
        Me.dtpAdjustmentViewDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtpAdjustmentViewDate.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.dtpAdjustmentViewDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpAdjustmentViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdjustmentViewDate.Location = New System.Drawing.Point(22, -25)
        Me.dtpAdjustmentViewDate.Name = "dtpAdjustmentViewDate"
        Me.dtpAdjustmentViewDate.Size = New System.Drawing.Size(135, 21)
        Me.dtpAdjustmentViewDate.TabIndex = 411
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearch.Location = New System.Drawing.Point(-70, -47)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(72, 13)
        Me.lblSearch.TabIndex = 407
        Me.lblSearch.Text = "Search By"
        '
        'dgvCPOView
        '
        Me.dgvCPOView.AllowUserToAddRows = False
        Me.dgvCPOView.AllowUserToDeleteRows = False
        Me.dgvCPOView.AllowUserToResizeRows = False
        Me.dgvCPOView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCPOView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCPOView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCPOView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCPOView.ColumnHeadersHeight = 30
        Me.dgvCPOView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvCPODate, Me.gvProductionID, Me.QtyToday})
        Me.dgvCPOView.ContextMenuStrip = Me.cmsCPO
        Me.dgvCPOView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCPOView.EnableHeadersVisualStyles = False
        Me.dgvCPOView.GridColor = System.Drawing.Color.Gray
        Me.dgvCPOView.Location = New System.Drawing.Point(3, 108)
        Me.dgvCPOView.MultiSelect = False
        Me.dgvCPOView.Name = "dgvCPOView"
        Me.dgvCPOView.ReadOnly = True
        Me.dgvCPOView.RowHeadersVisible = False
        Me.dgvCPOView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCPOView.Size = New System.Drawing.Size(749, 381)
        Me.dgvCPOView.TabIndex = 505
        Me.dgvCPOView.TabStop = False
        '
        'gvCPODate
        '
        Me.gvCPODate.DataPropertyName = "ProductionDate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.gvCPODate.DefaultCellStyle = DataGridViewCellStyle3
        Me.gvCPODate.HeaderText = "Date"
        Me.gvCPODate.Name = "gvCPODate"
        Me.gvCPODate.ReadOnly = True
        '
        'gvProductionID
        '
        Me.gvProductionID.DataPropertyName = "ProductionID"
        Me.gvProductionID.HeaderText = "gvProductionID"
        Me.gvProductionID.Name = "gvProductionID"
        Me.gvProductionID.ReadOnly = True
        Me.gvProductionID.Visible = False
        '
        'QtyToday
        '
        Me.QtyToday.DataPropertyName = "QtyToday"
        Me.QtyToday.HeaderText = "QtyToday"
        Me.QtyToday.Name = "QtyToday"
        Me.QtyToday.ReadOnly = True
        Me.QtyToday.Visible = False
        '
        'tpCPOView
        '
        Me.tpCPOView.AutoScroll = True
        Me.tpCPOView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tpCPOView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpCPOView.Controls.Add(Me.dgvCPOView)
        Me.tpCPOView.Controls.Add(Me.PnlSearch)
        Me.tpCPOView.Controls.Add(Me.lblViewStatus)
        Me.tpCPOView.Controls.Add(Me.dtpAdjustmentViewDate)
        Me.tpCPOView.Controls.Add(Me.lblSearch)
        Me.tpCPOView.Controls.Add(Me.Label13)
        Me.tpCPOView.Controls.Add(Me.lblAdjSearchNo)
        Me.tpCPOView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpCPOView.Location = New System.Drawing.Point(4, 22)
        Me.tpCPOView.Name = "tpCPOView"
        Me.tpCPOView.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCPOView.Size = New System.Drawing.Size(755, 492)
        Me.tpCPOView.TabIndex = 1
        Me.tpCPOView.Text = "View"
        Me.tpCPOView.UseVisualStyleBackColor = True
        '
        'lblAdjSearchNo
        '
        Me.lblAdjSearchNo.AutoSize = True
        Me.lblAdjSearchNo.BackColor = System.Drawing.Color.Transparent
        Me.lblAdjSearchNo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblAdjSearchNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAdjSearchNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAdjSearchNo.Location = New System.Drawing.Point(184, -46)
        Me.lblAdjSearchNo.Name = "lblAdjSearchNo"
        Me.lblAdjSearchNo.Size = New System.Drawing.Size(91, 13)
        Me.lblAdjSearchNo.TabIndex = 409
        Me.lblAdjSearchNo.Text = "Adjustment No"
        '
        'CMSLoadCPO
        '
        Me.CMSLoadCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadCPOEdit, Me.LoadCPODelete})
        Me.CMSLoadCPO.Name = "cmsIPR"
        Me.CMSLoadCPO.Size = New System.Drawing.Size(108, 48)
        '
        'LoadCPOEdit
        '
        Me.LoadCPOEdit.Image = CType(resources.GetObject("LoadCPOEdit.Image"), System.Drawing.Image)
        Me.LoadCPOEdit.Name = "LoadCPOEdit"
        Me.LoadCPOEdit.Size = New System.Drawing.Size(107, 22)
        Me.LoadCPOEdit.Text = "Edit"
        '
        'LoadCPODelete
        '
        Me.LoadCPODelete.Image = CType(resources.GetObject("LoadCPODelete.Image"), System.Drawing.Image)
        Me.LoadCPODelete.Name = "LoadCPODelete"
        Me.LoadCPODelete.Size = New System.Drawing.Size(107, 22)
        Me.LoadCPODelete.Text = "Delete"
        '
        'cmsStockCPO
        '
        Me.cmsStockCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StockCPOEdit, Me.StockCPODelete})
        Me.cmsStockCPO.Name = "cmsIPR"
        Me.cmsStockCPO.Size = New System.Drawing.Size(108, 48)
        '
        'StockCPOEdit
        '
        Me.StockCPOEdit.Image = CType(resources.GetObject("StockCPOEdit.Image"), System.Drawing.Image)
        Me.StockCPOEdit.Name = "StockCPOEdit"
        Me.StockCPOEdit.Size = New System.Drawing.Size(107, 22)
        Me.StockCPOEdit.Text = "Edit"
        '
        'StockCPODelete
        '
        Me.StockCPODelete.Image = CType(resources.GetObject("StockCPODelete.Image"), System.Drawing.Image)
        Me.StockCPODelete.Name = "StockCPODelete"
        Me.StockCPODelete.Size = New System.Drawing.Size(107, 22)
        Me.StockCPODelete.Text = "Delete"
        '
        'cmsTranshipCPO
        '
        Me.cmsTranshipCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TranshipEdit, Me.TranshipDelete})
        Me.cmsTranshipCPO.Name = "cmsIPR"
        Me.cmsTranshipCPO.Size = New System.Drawing.Size(108, 48)
        '
        'TranshipEdit
        '
        Me.TranshipEdit.Image = CType(resources.GetObject("TranshipEdit.Image"), System.Drawing.Image)
        Me.TranshipEdit.Name = "TranshipEdit"
        Me.TranshipEdit.Size = New System.Drawing.Size(107, 22)
        Me.TranshipEdit.Text = "Edit"
        '
        'TranshipDelete
        '
        Me.TranshipDelete.Image = CType(resources.GetObject("TranshipDelete.Image"), System.Drawing.Image)
        Me.TranshipDelete.Name = "TranshipDelete"
        Me.TranshipDelete.Size = New System.Drawing.Size(107, 22)
        Me.TranshipDelete.Text = "Delete"
        '
        'tcLoadingCPO
        '
        Me.tcLoadingCPO.Controls.Add(Me.tpCPOSave)
        Me.tcLoadingCPO.Controls.Add(Me.tpCPOView)
        Me.tcLoadingCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcLoadingCPO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcLoadingCPO.Location = New System.Drawing.Point(0, 0)
        Me.tcLoadingCPO.Name = "tcLoadingCPO"
        Me.tcLoadingCPO.SelectedIndex = 0
        Me.tcLoadingCPO.Size = New System.Drawing.Size(763, 518)
        Me.tcLoadingCPO.TabIndex = 4
        Me.tcLoadingCPO.TabStop = False
        '
        'tpCPOSave
        '
        Me.tpCPOSave.AutoScroll = True
        Me.tpCPOSave.BackgroundImage = CType(resources.GetObject("tpCPOSave.BackgroundImage"), System.Drawing.Image)
        Me.tpCPOSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpCPOSave.Controls.Add(Me.panCPO)
        Me.tpCPOSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpCPOSave.Location = New System.Drawing.Point(4, 22)
        Me.tpCPOSave.Name = "tpCPOSave"
        Me.tpCPOSave.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCPOSave.Size = New System.Drawing.Size(755, 492)
        Me.tpCPOSave.TabIndex = 0
        Me.tpCPOSave.Text = "Loading CPO "
        Me.tpCPOSave.UseVisualStyleBackColor = True
        '
        'panCPO
        '
        Me.panCPO.AutoScroll = True
        Me.panCPO.BackColor = System.Drawing.Color.Transparent
        Me.panCPO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panCPO.Controls.Add(Me.btnDeleteAll)
        Me.panCPO.Controls.Add(Me.grpLoadCPORecords)
        Me.panCPO.Controls.Add(Me.btnClose)
        Me.panCPO.Controls.Add(Me.btnReset)
        Me.panCPO.Controls.Add(Me.grpLoadDate)
        Me.panCPO.Controls.Add(Me.grpLoadCPO)
        Me.panCPO.Controls.Add(Me.btnSave)
        Me.panCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panCPO.Location = New System.Drawing.Point(3, 3)
        Me.panCPO.Name = "panCPO"
        Me.panCPO.Size = New System.Drawing.Size(749, 486)
        Me.panCPO.TabIndex = 0
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnDeleteAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteAll.Image = Global.BSP.My.Resources.Resources.icon_delete
        Me.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteAll.Location = New System.Drawing.Point(540, 404)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(117, 25)
        Me.btnDeleteAll.TabIndex = 111
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        Me.btnDeleteAll.Visible = False
        '
        'grpLoadCPORecords
        '
        Me.grpLoadCPORecords.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpLoadCPORecords.BackColor = System.Drawing.Color.Transparent
        Me.grpLoadCPORecords.Controls.Add(Me.dgvLoadCPODetails)
        Me.grpLoadCPORecords.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLoadCPORecords.Location = New System.Drawing.Point(0, 239)
        Me.grpLoadCPORecords.Name = "grpLoadCPORecords"
        Me.grpLoadCPORecords.Size = New System.Drawing.Size(687, 148)
        Me.grpLoadCPORecords.TabIndex = 181
        Me.grpLoadCPORecords.TabStop = False
        Me.grpLoadCPORecords.Text = "Load CPO Records"
        '
        'dgvLoadCPODetails
        '
        Me.dgvLoadCPODetails.AllowUserToAddRows = False
        Me.dgvLoadCPODetails.AllowUserToDeleteRows = False
        Me.dgvLoadCPODetails.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvLoadCPODetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvLoadCPODetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvLoadCPODetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvLoadCPODetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLoadCPODetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvLoadCPODetails.ColumnHeadersHeight = 30
        Me.dgvLoadCPODetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclLoadStorageNo, Me.dgclLoadStorageID, Me.dgclLoadStorageLocID, Me.dgclToLoading, Me.LoadDescription, Me.dgclLoadQuantity, Me.dgclLoadMonthDate, Me.dgclProdLoadingID1, Me.dgclProductionIDLoad, Me.dgclCPODateLoad, Me.dgclLoadRemarks})
        Me.dgvLoadCPODetails.ContextMenuStrip = Me.CMSLoadCPO
        Me.dgvLoadCPODetails.EnableHeadersVisualStyles = False
        Me.dgvLoadCPODetails.GridColor = System.Drawing.Color.Gray
        Me.dgvLoadCPODetails.Location = New System.Drawing.Point(4, 23)
        Me.dgvLoadCPODetails.MultiSelect = False
        Me.dgvLoadCPODetails.Name = "dgvLoadCPODetails"
        Me.dgvLoadCPODetails.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLoadCPODetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvLoadCPODetails.RowHeadersVisible = False
        Me.dgvLoadCPODetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLoadCPODetails.Size = New System.Drawing.Size(665, 117)
        Me.dgvLoadCPODetails.TabIndex = 319
        Me.dgvLoadCPODetails.TabStop = False
        '
        'dgclLoadStorageNo
        '
        Me.dgclLoadStorageNo.DataPropertyName = "LoadTankNo"
        Me.dgclLoadStorageNo.HeaderText = "Production Volume"
        Me.dgclLoadStorageNo.Name = "dgclLoadStorageNo"
        Me.dgclLoadStorageNo.ReadOnly = True
        '
        'dgclLoadStorageID
        '
        Me.dgclLoadStorageID.DataPropertyName = "LoadTankID"
        Me.dgclLoadStorageID.HeaderText = "LoadStorageID"
        Me.dgclLoadStorageID.Name = "dgclLoadStorageID"
        Me.dgclLoadStorageID.ReadOnly = True
        Me.dgclLoadStorageID.Visible = False
        '
        'dgclLoadStorageLocID
        '
        Me.dgclLoadStorageLocID.DataPropertyName = "LoadLocationID"
        Me.dgclLoadStorageLocID.HeaderText = "LoadStorageLocID"
        Me.dgclLoadStorageLocID.Name = "dgclLoadStorageLocID"
        Me.dgclLoadStorageLocID.ReadOnly = True
        Me.dgclLoadStorageLocID.Visible = False
        '
        'dgclToLoading
        '
        Me.dgclToLoading.DataPropertyName = "LoadLocation"
        Me.dgclToLoading.HeaderText = "To Loading"
        Me.dgclToLoading.Name = "dgclToLoading"
        Me.dgclToLoading.ReadOnly = True
        '
        'LoadDescription
        '
        Me.LoadDescription.DataPropertyName = "Descp"
        Me.LoadDescription.HeaderText = "Description"
        Me.LoadDescription.Name = "LoadDescription"
        Me.LoadDescription.ReadOnly = True
        Me.LoadDescription.Visible = False
        '
        'dgclLoadQuantity
        '
        Me.dgclLoadQuantity.DataPropertyName = "LoadQty"
        Me.dgclLoadQuantity.HeaderText = "Quantity"
        Me.dgclLoadQuantity.Name = "dgclLoadQuantity"
        Me.dgclLoadQuantity.ReadOnly = True
        Me.dgclLoadQuantity.Width = 70
        '
        'dgclLoadMonthDate
        '
        Me.dgclLoadMonthDate.DataPropertyName = "LoadMonthToDate"
        Me.dgclLoadMonthDate.HeaderText = "Month To date"
        Me.dgclLoadMonthDate.Name = "dgclLoadMonthDate"
        Me.dgclLoadMonthDate.ReadOnly = True
        Me.dgclLoadMonthDate.Width = 135
        '
        'dgclProdLoadingID1
        '
        Me.dgclProdLoadingID1.DataPropertyName = "ProdLoadingID"
        Me.dgclProdLoadingID1.HeaderText = "ProdLoadingID"
        Me.dgclProdLoadingID1.Name = "dgclProdLoadingID1"
        Me.dgclProdLoadingID1.ReadOnly = True
        Me.dgclProdLoadingID1.Visible = False
        '
        'dgclProductionIDLoad
        '
        Me.dgclProductionIDLoad.DataPropertyName = "ProductionID"
        Me.dgclProductionIDLoad.HeaderText = "ProductionID"
        Me.dgclProductionIDLoad.Name = "dgclProductionIDLoad"
        Me.dgclProductionIDLoad.ReadOnly = True
        Me.dgclProductionIDLoad.Visible = False
        '
        'dgclCPODateLoad
        '
        Me.dgclCPODateLoad.DataPropertyName = "CPOProductionDate"
        Me.dgclCPODateLoad.HeaderText = "ProductionDate"
        Me.dgclCPODateLoad.Name = "dgclCPODateLoad"
        Me.dgclCPODateLoad.ReadOnly = True
        Me.dgclCPODateLoad.Visible = False
        '
        'dgclLoadRemarks
        '
        Me.dgclLoadRemarks.DataPropertyName = "LoadRemarks"
        Me.dgclLoadRemarks.HeaderText = "Remarks"
        Me.dgclLoadRemarks.Name = "dgclLoadRemarks"
        Me.dgclLoadRemarks.ReadOnly = True
        Me.dgclLoadRemarks.Width = 80
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(436, 404)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 25)
        Me.btnClose.TabIndex = 110
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
        Me.btnReset.Location = New System.Drawing.Point(318, 404)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(112, 25)
        Me.btnReset.TabIndex = 109
        Me.btnReset.Text = "Reset All"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'grpLoadDate
        '
        Me.grpLoadDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpLoadDate.BackColor = System.Drawing.Color.Transparent
        Me.grpLoadDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.grpLoadDate.Controls.Add(Me.Label1)
        Me.grpLoadDate.Controls.Add(Me.dtpCPODate)
        Me.grpLoadDate.Controls.Add(Me.lblLoadDate)
        Me.grpLoadDate.Location = New System.Drawing.Point(0, 0)
        Me.grpLoadDate.Name = "grpLoadDate"
        Me.grpLoadDate.Size = New System.Drawing.Size(690, 43)
        Me.grpLoadDate.TabIndex = 178
        Me.grpLoadDate.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(95, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 364
        Me.Label1.Text = ":"
        '
        'dtpCPODate
        '
        Me.dtpCPODate.CustomFormat = "dd/MM/yyyy"
        Me.dtpCPODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPODate.Location = New System.Drawing.Point(122, 12)
        Me.dtpCPODate.Name = "dtpCPODate"
        Me.dtpCPODate.Size = New System.Drawing.Size(155, 21)
        Me.dtpCPODate.TabIndex = 100
        '
        'lblLoadDate
        '
        Me.lblLoadDate.AutoSize = True
        Me.lblLoadDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadDate.ForeColor = System.Drawing.Color.Red
        Me.lblLoadDate.Location = New System.Drawing.Point(10, 16)
        Me.lblLoadDate.Name = "lblLoadDate"
        Me.lblLoadDate.Size = New System.Drawing.Size(82, 13)
        Me.lblLoadDate.TabIndex = 170
        Me.lblLoadDate.Text = "Loading Date"
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(180, 404)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(132, 25)
        Me.btnSave.TabIndex = 108
        Me.btnSave.Text = "Save All"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'LoadingCPOFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(763, 518)
        Me.Controls.Add(Me.tcLoadingCPO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "LoadingCPOFrm"
        Me.Text = "LoadingCPOFrm"
        Me.grpLoadCPO.ResumeLayout(False)
        Me.grpLoadCPO.PerformLayout()
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsCPO.ResumeLayout(False)
        CType(Me.dgvCPOView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCPOView.ResumeLayout(False)
        Me.tpCPOView.PerformLayout()
        Me.CMSLoadCPO.ResumeLayout(False)
        Me.cmsStockCPO.ResumeLayout(False)
        Me.cmsTranshipCPO.ResumeLayout(False)
        Me.tcLoadingCPO.ResumeLayout(False)
        Me.tpCPOSave.ResumeLayout(False)
        Me.panCPO.ResumeLayout(False)
        Me.grpLoadCPORecords.ResumeLayout(False)
        CType(Me.dgvLoadCPODetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpLoadDate.ResumeLayout(False)
        Me.grpLoadDate.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpLoadCPO As System.Windows.Forms.GroupBox
    Friend WithEvents txtLoadRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents btnResetLoad As System.Windows.Forms.Button
    Friend WithEvents btnAddLoad As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtLoadMonthToDate As System.Windows.Forms.TextBox
    Friend WithEvents lblLoadMonthDate As System.Windows.Forms.Label
    Friend WithEvents txtLoadQty As System.Windows.Forms.TextBox
    Friend WithEvents lblLoadQty As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblToLoading As System.Windows.Forms.Label
    Friend WithEvents cmbLoadLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblLoadStorage As System.Windows.Forms.Label
    Friend WithEvents cmbLoadTank As System.Windows.Forms.ComboBox
    Friend WithEvents lblT3Name As System.Windows.Forms.Label
    Friend WithEvents lblT1Name As System.Windows.Forms.Label
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents dtpCPOViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents chkCPODate As System.Windows.Forms.CheckBox
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents lblViewStatus As System.Windows.Forms.Label
    Friend WithEvents dtpAdjustmentViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents dgvCPOView As System.Windows.Forms.DataGridView
    Friend WithEvents tpCPOView As System.Windows.Forms.TabPage
    Friend WithEvents lblAdjSearchNo As System.Windows.Forms.Label
    Friend WithEvents CMSLoadCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LoadCPOEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadCPODelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsStockCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StockCPOEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockCPODelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsTranshipCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TranshipEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TranshipDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tcLoadingCPO As System.Windows.Forms.TabControl
    Friend WithEvents tpCPOSave As System.Windows.Forms.TabPage
    Friend WithEvents panCPO As System.Windows.Forms.Panel
    Friend WithEvents grpLoadCPORecords As System.Windows.Forms.GroupBox
    Friend WithEvents dgvLoadCPODetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents grpLoadDate As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpCPODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblLoadDate As System.Windows.Forms.Label
    Friend WithEvents gvCPODate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvProductionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyToday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadStorageNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadStorageID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadStorageLocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclToLoading As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoadDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadMonthDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProdLoadingID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProductionIDLoad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclCPODateLoad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadingPKOFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoadingPKOFrm))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TranshipDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.TranshipEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.tcLoadingPKO = New System.Windows.Forms.TabControl
        Me.tpPKOSave = New System.Windows.Forms.TabPage
        Me.panCPO = New System.Windows.Forms.Panel
        Me.btnDeleteAll = New System.Windows.Forms.Button
        Me.grpLoadPKORecords = New System.Windows.Forms.GroupBox
        Me.dgvLoadPKODetails = New System.Windows.Forms.DataGridView
        Me.dgclLoadStorageNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclLoadStorageID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclLoadStorageLocID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclToLoading = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoadDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclLoadQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclLoadMonthDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProdLoadingID1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProductionIDLoad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclLoadRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CMSLoadCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LoadPKOEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadPKODelete = New System.Windows.Forms.ToolStripMenuItem
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.grpLoadDate = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpPKODate = New System.Windows.Forms.DateTimePicker
        Me.lblLoadDate = New System.Windows.Forms.Label
        Me.grpLoadPKO = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
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
        Me.btnSave = New System.Windows.Forms.Button
        Me.tpPKOView = New System.Windows.Forms.TabPage
        Me.dgvPKOView = New System.Windows.Forms.DataGridView
        Me.gvPKODate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gvProductionID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyToday = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsPKO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.dtpPKOViewDate = New System.Windows.Forms.DateTimePicker
        Me.Label46 = New System.Windows.Forms.Label
        Me.btnViewSearch = New System.Windows.Forms.Button
        Me.chkPKODate = New System.Windows.Forms.CheckBox
        Me.lblViewStatus = New System.Windows.Forms.Label
        Me.dtpAdjustmentViewDate = New System.Windows.Forms.DateTimePicker
        Me.lblSearch = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblAdjSearchNo = New System.Windows.Forms.Label
        Me.cmsTranshipCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StockCPODelete = New System.Windows.Forms.ToolStripMenuItem
        Me.StockCPOEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsStockCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tcLoadingPKO.SuspendLayout()
        Me.tpPKOSave.SuspendLayout()
        Me.panCPO.SuspendLayout()
        Me.grpLoadPKORecords.SuspendLayout()
        CType(Me.dgvLoadPKODetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSLoadCPO.SuspendLayout()
        Me.grpLoadDate.SuspendLayout()
        Me.grpLoadPKO.SuspendLayout()
        Me.tpPKOView.SuspendLayout()
        CType(Me.dgvPKOView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPKO.SuspendLayout()
        Me.PnlSearch.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsTranshipCPO.SuspendLayout()
        Me.cmsStockCPO.SuspendLayout()
        Me.SuspendLayout()
        '
        'TranshipDelete
        '
        Me.TranshipDelete.Image = CType(resources.GetObject("TranshipDelete.Image"), System.Drawing.Image)
        Me.TranshipDelete.Name = "TranshipDelete"
        Me.TranshipDelete.Size = New System.Drawing.Size(116, 22)
        Me.TranshipDelete.Text = "Delete"
        '
        'TranshipEdit
        '
        Me.TranshipEdit.Image = CType(resources.GetObject("TranshipEdit.Image"), System.Drawing.Image)
        Me.TranshipEdit.Name = "TranshipEdit"
        Me.TranshipEdit.Size = New System.Drawing.Size(116, 22)
        Me.TranshipEdit.Text = "Edit"
        '
        'tcLoadingPKO
        '
        Me.tcLoadingPKO.Controls.Add(Me.tpPKOSave)
        Me.tcLoadingPKO.Controls.Add(Me.tpPKOView)
        Me.tcLoadingPKO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcLoadingPKO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcLoadingPKO.Location = New System.Drawing.Point(0, 0)
        Me.tcLoadingPKO.Name = "tcLoadingPKO"
        Me.tcLoadingPKO.SelectedIndex = 0
        Me.tcLoadingPKO.Size = New System.Drawing.Size(763, 518)
        Me.tcLoadingPKO.TabIndex = 5
        Me.tcLoadingPKO.TabStop = False
        '
        'tpPKOSave
        '
        Me.tpPKOSave.AutoScroll = True
        Me.tpPKOSave.BackgroundImage = CType(resources.GetObject("tpPKOSave.BackgroundImage"), System.Drawing.Image)
        Me.tpPKOSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpPKOSave.Controls.Add(Me.panCPO)
        Me.tpPKOSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpPKOSave.Location = New System.Drawing.Point(4, 22)
        Me.tpPKOSave.Name = "tpPKOSave"
        Me.tpPKOSave.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPKOSave.Size = New System.Drawing.Size(755, 492)
        Me.tpPKOSave.TabIndex = 0
        Me.tpPKOSave.Text = "Loading PKO"
        Me.tpPKOSave.UseVisualStyleBackColor = True
        '
        'panCPO
        '
        Me.panCPO.AutoScroll = True
        Me.panCPO.BackColor = System.Drawing.Color.Transparent
        Me.panCPO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panCPO.Controls.Add(Me.btnDeleteAll)
        Me.panCPO.Controls.Add(Me.grpLoadPKORecords)
        Me.panCPO.Controls.Add(Me.btnClose)
        Me.panCPO.Controls.Add(Me.btnReset)
        Me.panCPO.Controls.Add(Me.grpLoadDate)
        Me.panCPO.Controls.Add(Me.grpLoadPKO)
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
        Me.btnDeleteAll.Location = New System.Drawing.Point(538, 416)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(117, 25)
        Me.btnDeleteAll.TabIndex = 352
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        Me.btnDeleteAll.Visible = False
        '
        'grpLoadPKORecords
        '
        Me.grpLoadPKORecords.BackColor = System.Drawing.Color.Transparent
        Me.grpLoadPKORecords.Controls.Add(Me.dgvLoadPKODetails)
        Me.grpLoadPKORecords.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLoadPKORecords.Location = New System.Drawing.Point(3, 251)
        Me.grpLoadPKORecords.Name = "grpLoadPKORecords"
        Me.grpLoadPKORecords.Size = New System.Drawing.Size(687, 148)
        Me.grpLoadPKORecords.TabIndex = 181
        Me.grpLoadPKORecords.TabStop = False
        Me.grpLoadPKORecords.Text = "Load PKO Records"
        '
        'dgvLoadPKODetails
        '
        Me.dgvLoadPKODetails.AllowUserToAddRows = False
        Me.dgvLoadPKODetails.AllowUserToDeleteRows = False
        Me.dgvLoadPKODetails.AllowUserToResizeRows = False
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvLoadPKODetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvLoadPKODetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvLoadPKODetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvLoadPKODetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLoadPKODetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvLoadPKODetails.ColumnHeadersHeight = 30
        Me.dgvLoadPKODetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclLoadStorageNo, Me.dgclLoadStorageID, Me.dgclLoadStorageLocID, Me.dgclToLoading, Me.LoadDescription, Me.dgclLoadQuantity, Me.dgclLoadMonthDate, Me.dgclProdLoadingID1, Me.dgclProductionIDLoad, Me.dgclLoadRemarks})
        Me.dgvLoadPKODetails.ContextMenuStrip = Me.CMSLoadCPO
        Me.dgvLoadPKODetails.EnableHeadersVisualStyles = False
        Me.dgvLoadPKODetails.GridColor = System.Drawing.Color.Gray
        Me.dgvLoadPKODetails.Location = New System.Drawing.Point(4, 23)
        Me.dgvLoadPKODetails.MultiSelect = False
        Me.dgvLoadPKODetails.Name = "dgvLoadPKODetails"
        Me.dgvLoadPKODetails.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLoadPKODetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvLoadPKODetails.RowHeadersVisible = False
        Me.dgvLoadPKODetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLoadPKODetails.Size = New System.Drawing.Size(665, 117)
        Me.dgvLoadPKODetails.TabIndex = 348
        Me.dgvLoadPKODetails.TabStop = False
        '
        'dgclLoadStorageNo
        '
        Me.dgclLoadStorageNo.DataPropertyName = "LoadTankNo"
        Me.dgclLoadStorageNo.HeaderText = "Storage"
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
        'dgclLoadRemarks
        '
        Me.dgclLoadRemarks.DataPropertyName = "LoadRemarks"
        Me.dgclLoadRemarks.HeaderText = "Remarks"
        Me.dgclLoadRemarks.Name = "dgclLoadRemarks"
        Me.dgclLoadRemarks.ReadOnly = True
        Me.dgclLoadRemarks.Width = 80
        '
        'CMSLoadCPO
        '
        Me.CMSLoadCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadPKOEdit, Me.LoadPKODelete})
        Me.CMSLoadCPO.Name = "cmsIPR"
        Me.CMSLoadCPO.Size = New System.Drawing.Size(117, 48)
        '
        'LoadPKOEdit
        '
        Me.LoadPKOEdit.Image = CType(resources.GetObject("LoadPKOEdit.Image"), System.Drawing.Image)
        Me.LoadPKOEdit.Name = "LoadPKOEdit"
        Me.LoadPKOEdit.Size = New System.Drawing.Size(116, 22)
        Me.LoadPKOEdit.Text = "Edit"
        '
        'LoadPKODelete
        '
        Me.LoadPKODelete.Image = CType(resources.GetObject("LoadPKODelete.Image"), System.Drawing.Image)
        Me.LoadPKODelete.Name = "LoadPKODelete"
        Me.LoadPKODelete.Size = New System.Drawing.Size(116, 22)
        Me.LoadPKODelete.Text = "Delete"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(434, 416)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 25)
        Me.btnClose.TabIndex = 351
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
        Me.btnReset.Location = New System.Drawing.Point(316, 416)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(112, 25)
        Me.btnReset.TabIndex = 350
        Me.btnReset.Text = "Reset All"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'grpLoadDate
        '
        Me.grpLoadDate.BackColor = System.Drawing.Color.Transparent
        Me.grpLoadDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.grpLoadDate.Controls.Add(Me.Label1)
        Me.grpLoadDate.Controls.Add(Me.dtpPKODate)
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
        'dtpPKODate
        '
        Me.dtpPKODate.CustomFormat = "dd/MM/yyyy"
        Me.dtpPKODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPKODate.Location = New System.Drawing.Point(122, 12)
        Me.dtpPKODate.Name = "dtpPKODate"
        Me.dtpPKODate.Size = New System.Drawing.Size(155, 21)
        Me.dtpPKODate.TabIndex = 340
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
        'grpLoadPKO
        '
        Me.grpLoadPKO.BackColor = System.Drawing.Color.Transparent
        Me.grpLoadPKO.Controls.Add(Me.Label3)
        Me.grpLoadPKO.Controls.Add(Me.txtLoadRemarks)
        Me.grpLoadPKO.Controls.Add(Me.lblRemarks)
        Me.grpLoadPKO.Controls.Add(Me.btnResetLoad)
        Me.grpLoadPKO.Controls.Add(Me.btnAddLoad)
        Me.grpLoadPKO.Controls.Add(Me.Label20)
        Me.grpLoadPKO.Controls.Add(Me.Label23)
        Me.grpLoadPKO.Controls.Add(Me.txtLoadMonthToDate)
        Me.grpLoadPKO.Controls.Add(Me.lblLoadMonthDate)
        Me.grpLoadPKO.Controls.Add(Me.txtLoadQty)
        Me.grpLoadPKO.Controls.Add(Me.lblLoadQty)
        Me.grpLoadPKO.Controls.Add(Me.Label18)
        Me.grpLoadPKO.Controls.Add(Me.lblToLoading)
        Me.grpLoadPKO.Controls.Add(Me.cmbLoadLocation)
        Me.grpLoadPKO.Controls.Add(Me.Label16)
        Me.grpLoadPKO.Controls.Add(Me.lblLoadStorage)
        Me.grpLoadPKO.Controls.Add(Me.cmbLoadTank)
        Me.grpLoadPKO.Controls.Add(Me.lblT3Name)
        Me.grpLoadPKO.Controls.Add(Me.lblT1Name)
        Me.grpLoadPKO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLoadPKO.Location = New System.Drawing.Point(3, 48)
        Me.grpLoadPKO.Name = "grpLoadPKO"
        Me.grpLoadPKO.Size = New System.Drawing.Size(689, 197)
        Me.grpLoadPKO.TabIndex = 340
        Me.grpLoadPKO.TabStop = False
        Me.grpLoadPKO.Text = "Loading PKO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(117, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 348
        Me.Label3.Text = ":"
        '
        'txtLoadRemarks
        '
        Me.txtLoadRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoadRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadRemarks.Location = New System.Drawing.Point(144, 119)
        Me.txtLoadRemarks.MaxLength = 300
        Me.txtLoadRemarks.Multiline = True
        Me.txtLoadRemarks.Name = "txtLoadRemarks"
        Me.txtLoadRemarks.Size = New System.Drawing.Size(188, 64)
        Me.txtLoadRemarks.TabIndex = 345
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(9, 121)
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
        Me.btnResetLoad.Location = New System.Drawing.Point(471, 138)
        Me.btnResetLoad.Name = "btnResetLoad"
        Me.btnResetLoad.Size = New System.Drawing.Size(81, 22)
        Me.btnResetLoad.TabIndex = 347
        Me.btnResetLoad.Text = "Reset"
        Me.btnResetLoad.UseVisualStyleBackColor = True
        '
        'btnAddLoad
        '
        Me.btnAddLoad.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAddLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddLoad.Image = CType(resources.GetObject("btnAddLoad.Image"), System.Drawing.Image)
        Me.btnAddLoad.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAddLoad.Location = New System.Drawing.Point(375, 138)
        Me.btnAddLoad.Name = "btnAddLoad"
        Me.btnAddLoad.Size = New System.Drawing.Size(78, 22)
        Me.btnAddLoad.TabIndex = 346
        Me.btnAddLoad.Text = "Add"
        Me.btnAddLoad.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(117, 87)
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
        Me.Label23.Location = New System.Drawing.Point(362, 87)
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
        Me.txtLoadMonthToDate.Location = New System.Drawing.Point(392, 85)
        Me.txtLoadMonthToDate.MaxLength = 18
        Me.txtLoadMonthToDate.Name = "txtLoadMonthToDate"
        Me.txtLoadMonthToDate.Size = New System.Drawing.Size(98, 21)
        Me.txtLoadMonthToDate.TabIndex = 344
        '
        'lblLoadMonthDate
        '
        Me.lblLoadMonthDate.AutoSize = True
        Me.lblLoadMonthDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadMonthDate.ForeColor = System.Drawing.Color.Red
        Me.lblLoadMonthDate.Location = New System.Drawing.Point(248, 87)
        Me.lblLoadMonthDate.Name = "lblLoadMonthDate"
        Me.lblLoadMonthDate.Size = New System.Drawing.Size(111, 13)
        Me.lblLoadMonthDate.TabIndex = 178
        Me.lblLoadMonthDate.Text = "Month To date(KG)"
        '
        'txtLoadQty
        '
        Me.txtLoadQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoadQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadQty.Location = New System.Drawing.Point(144, 85)
        Me.txtLoadQty.MaxLength = 18
        Me.txtLoadQty.Name = "txtLoadQty"
        Me.txtLoadQty.Size = New System.Drawing.Size(98, 21)
        Me.txtLoadQty.TabIndex = 343
        '
        'lblLoadQty
        '
        Me.lblLoadQty.AutoSize = True
        Me.lblLoadQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadQty.ForeColor = System.Drawing.Color.Red
        Me.lblLoadQty.Location = New System.Drawing.Point(9, 86)
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
        Me.Label18.Location = New System.Drawing.Point(117, 55)
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
        Me.cmbLoadLocation.Location = New System.Drawing.Point(144, 52)
        Me.cmbLoadLocation.Name = "cmbLoadLocation"
        Me.cmbLoadLocation.Size = New System.Drawing.Size(346, 21)
        Me.cmbLoadLocation.TabIndex = 342
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(117, 25)
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
        Me.cmbLoadTank.Location = New System.Drawing.Point(144, 22)
        Me.cmbLoadTank.Name = "cmbLoadTank"
        Me.cmbLoadTank.Size = New System.Drawing.Size(346, 21)
        Me.cmbLoadTank.TabIndex = 341
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
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(178, 416)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(132, 25)
        Me.btnSave.TabIndex = 349
        Me.btnSave.Text = "Save All"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tpPKOView
        '
        Me.tpPKOView.AutoScroll = True
        Me.tpPKOView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tpPKOView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpPKOView.Controls.Add(Me.dgvPKOView)
        Me.tpPKOView.Controls.Add(Me.PnlSearch)
        Me.tpPKOView.Controls.Add(Me.lblViewStatus)
        Me.tpPKOView.Controls.Add(Me.dtpAdjustmentViewDate)
        Me.tpPKOView.Controls.Add(Me.lblSearch)
        Me.tpPKOView.Controls.Add(Me.Label13)
        Me.tpPKOView.Controls.Add(Me.lblAdjSearchNo)
        Me.tpPKOView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpPKOView.Location = New System.Drawing.Point(4, 22)
        Me.tpPKOView.Name = "tpPKOView"
        Me.tpPKOView.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPKOView.Size = New System.Drawing.Size(755, 492)
        Me.tpPKOView.TabIndex = 1
        Me.tpPKOView.Text = "View"
        Me.tpPKOView.UseVisualStyleBackColor = True
        '
        'dgvPKOView
        '
        Me.dgvPKOView.AllowUserToAddRows = False
        Me.dgvPKOView.AllowUserToDeleteRows = False
        Me.dgvPKOView.AllowUserToResizeRows = False
        Me.dgvPKOView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPKOView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPKOView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPKOView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPKOView.ColumnHeadersHeight = 30
        Me.dgvPKOView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvPKODate, Me.gvProductionID, Me.QtyToday})
        Me.dgvPKOView.ContextMenuStrip = Me.cmsPKO
        Me.dgvPKOView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPKOView.EnableHeadersVisualStyles = False
        Me.dgvPKOView.GridColor = System.Drawing.Color.Gray
        Me.dgvPKOView.Location = New System.Drawing.Point(3, 108)
        Me.dgvPKOView.MultiSelect = False
        Me.dgvPKOView.Name = "dgvPKOView"
        Me.dgvPKOView.ReadOnly = True
        Me.dgvPKOView.RowHeadersVisible = False
        Me.dgvPKOView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPKOView.Size = New System.Drawing.Size(749, 381)
        Me.dgvPKOView.TabIndex = 505
        Me.dgvPKOView.TabStop = False
        '
        'gvPKODate
        '
        Me.gvPKODate.DataPropertyName = "ProductionDate"
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.gvPKODate.DefaultCellStyle = DataGridViewCellStyle2
        Me.gvPKODate.HeaderText = "Date"
        Me.gvPKODate.Name = "gvPKODate"
        Me.gvPKODate.ReadOnly = True
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
        'cmsPKO
        '
        Me.cmsPKO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsPKO.Name = "cmsIPR"
        Me.cmsPKO.Size = New System.Drawing.Size(117, 70)
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
        Me.PnlSearch.CaptionText = "Search Loading PKO"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.Panel2)
        Me.PnlSearch.Controls.Add(Me.lblSearchBy)
        Me.PnlSearch.Controls.Add(Me.dtpPKOViewDate)
        Me.PnlSearch.Controls.Add(Me.Label46)
        Me.PnlSearch.Controls.Add(Me.btnViewSearch)
        Me.PnlSearch.Controls.Add(Me.chkPKODate)
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
        'dtpPKOViewDate
        '
        Me.dtpPKOViewDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpPKOViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPKOViewDate.Location = New System.Drawing.Point(189, 74)
        Me.dtpPKOViewDate.Name = "dtpPKOViewDate"
        Me.dtpPKOViewDate.Size = New System.Drawing.Size(135, 21)
        Me.dtpPKOViewDate.TabIndex = 502
        Me.dtpPKOViewDate.Value = New Date(2010, 2, 15, 11, 44, 0, 0)
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
        'chkPKODate
        '
        Me.chkPKODate.AutoSize = True
        Me.chkPKODate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkPKODate.Location = New System.Drawing.Point(116, 74)
        Me.chkPKODate.Name = "chkPKODate"
        Me.chkPKODate.Size = New System.Drawing.Size(57, 17)
        Me.chkPKODate.TabIndex = 501
        Me.chkPKODate.TabStop = False
        Me.chkPKODate.Text = " Date"
        Me.chkPKODate.UseVisualStyleBackColor = True
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
        'cmsTranshipCPO
        '
        Me.cmsTranshipCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TranshipEdit, Me.TranshipDelete})
        Me.cmsTranshipCPO.Name = "cmsIPR"
        Me.cmsTranshipCPO.Size = New System.Drawing.Size(117, 48)
        '
        'StockCPODelete
        '
        Me.StockCPODelete.Image = CType(resources.GetObject("StockCPODelete.Image"), System.Drawing.Image)
        Me.StockCPODelete.Name = "StockCPODelete"
        Me.StockCPODelete.Size = New System.Drawing.Size(116, 22)
        Me.StockCPODelete.Text = "Delete"
        '
        'StockCPOEdit
        '
        Me.StockCPOEdit.Image = CType(resources.GetObject("StockCPOEdit.Image"), System.Drawing.Image)
        Me.StockCPOEdit.Name = "StockCPOEdit"
        Me.StockCPOEdit.Size = New System.Drawing.Size(116, 22)
        Me.StockCPOEdit.Text = "Edit"
        '
        'cmsStockCPO
        '
        Me.cmsStockCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StockCPOEdit, Me.StockCPODelete})
        Me.cmsStockCPO.Name = "cmsIPR"
        Me.cmsStockCPO.Size = New System.Drawing.Size(117, 48)
        '
        'LoadingPKOFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(763, 518)
        Me.Controls.Add(Me.tcLoadingPKO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "LoadingPKOFrm"
        Me.Text = "LoadingPKOFrm"
        Me.tcLoadingPKO.ResumeLayout(False)
        Me.tpPKOSave.ResumeLayout(False)
        Me.panCPO.ResumeLayout(False)
        Me.grpLoadPKORecords.ResumeLayout(False)
        CType(Me.dgvLoadPKODetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSLoadCPO.ResumeLayout(False)
        Me.grpLoadDate.ResumeLayout(False)
        Me.grpLoadDate.PerformLayout()
        Me.grpLoadPKO.ResumeLayout(False)
        Me.grpLoadPKO.PerformLayout()
        Me.tpPKOView.ResumeLayout(False)
        Me.tpPKOView.PerformLayout()
        CType(Me.dgvPKOView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPKO.ResumeLayout(False)
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsTranshipCPO.ResumeLayout(False)
        Me.cmsStockCPO.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TranshipDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TranshipEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tcLoadingPKO As System.Windows.Forms.TabControl
    Friend WithEvents tpPKOSave As System.Windows.Forms.TabPage
    Friend WithEvents panCPO As System.Windows.Forms.Panel
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents grpLoadPKORecords As System.Windows.Forms.GroupBox
    Friend WithEvents dgvLoadPKODetails As System.Windows.Forms.DataGridView
    Friend WithEvents CMSLoadCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LoadPKOEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadPKODelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents grpLoadDate As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpPKODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblLoadDate As System.Windows.Forms.Label
    Friend WithEvents grpLoadPKO As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
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
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tpPKOView As System.Windows.Forms.TabPage
    Friend WithEvents dgvPKOView As System.Windows.Forms.DataGridView
    Friend WithEvents cmsPKO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents dtpPKOViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents chkPKODate As System.Windows.Forms.CheckBox
    Friend WithEvents lblViewStatus As System.Windows.Forms.Label
    Friend WithEvents dtpAdjustmentViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblAdjSearchNo As System.Windows.Forms.Label
    Friend WithEvents cmsTranshipCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StockCPODelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockCPOEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsStockCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents gvPKODate As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents dgclLoadRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

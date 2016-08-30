<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CPOProductionFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CPOProductionFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tcCPOProduction = New System.Windows.Forms.TabControl()
        Me.tpCPOSave = New System.Windows.Forms.TabPage()
        Me.panCPO = New System.Windows.Forms.Panel()
        Me.gpLoadCPO = New System.Windows.Forms.GroupBox()
        Me.dgvLoadCPODetails = New System.Windows.Forms.DataGridView()
        Me.dgclLoadStorageLocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProdLoadID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclToLoading = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLoadCtReading = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPrevDayReadnig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLoadRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMSLoadCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LoadCPOEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadCPODelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLoadCPORemarks = New System.Windows.Forms.TextBox()
        Me.lblLoadRemarks = New System.Windows.Forms.Label()
        Me.btnLoadReset = New System.Windows.Forms.Button()
        Me.btnLoadAdd = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtLoadPrevDayReading = New System.Windows.Forms.TextBox()
        Me.lblLoadPrevReading = New System.Windows.Forms.Label()
        Me.txtLoadCtReading = New System.Windows.Forms.TextBox()
        Me.lblLoadCtReading = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.cbLoading = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.grpStockCPORecords = New System.Windows.Forms.GroupBox()
        Me.dgvCPODetails = New System.Windows.Forms.DataGridView()
        Me.dgclStorage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLoadLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLoadLocationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransLocationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLoadTankNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransTankNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProdStockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProdTranshipID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProdLoadingID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLoadQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLoadMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTranshipQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTranshipMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclprodTodayQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProdMonthQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProdYearQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLoadTankID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransTankID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockTankID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProductionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclCapacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclCurrentReading = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclWriteoff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclMeasurement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTemperature = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclFFA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclMoisture = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDirt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcBeritaAcara = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsStockCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StockCPOEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockCPODelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpProCPORecords = New System.Windows.Forms.GroupBox()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.txtProductionYear = New System.Windows.Forms.TextBox()
        Me.lblProYeardate = New System.Windows.Forms.Label()
        Me.lblTonMonth = New System.Windows.Forms.Label()
        Me.txtProductionMonth = New System.Windows.Forms.TextBox()
        Me.lblProMonthdate = New System.Windows.Forms.Label()
        Me.lblTonToday = New System.Windows.Forms.Label()
        Me.txtProductionToday = New System.Windows.Forms.TextBox()
        Me.lblProToday = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lblProStorage = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DtpProductionDate = New System.Windows.Forms.DateTimePicker()
        Me.lblProductionDate = New System.Windows.Forms.Label()
        Me.dtpCPODate = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.grpStockCPO = New System.Windows.Forms.GroupBox()
        Me.txtBeritaAcara = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtWriteoff = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.grpTransCPORecords = New System.Windows.Forms.GroupBox()
        Me.dgvTransCPODetails = New System.Windows.Forms.DataGridView()
        Me.dgclTransStorageNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransStorageID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransStorageLocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTranshipLoad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTranshipQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransMonthDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProdTranshipID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProductionIDTrans = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclCPODateTrans = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsTranshipCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TranshipEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TranshipDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpLoadCPO = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLoadRemarks = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.btnResetLoad = New System.Windows.Forms.Button()
        Me.btnAddLoad = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtLoadMonthToDate = New System.Windows.Forms.TextBox()
        Me.lblLoadMonthDate = New System.Windows.Forms.Label()
        Me.txtLoadQty = New System.Windows.Forms.TextBox()
        Me.lblLoadQty = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblToLoading = New System.Windows.Forms.Label()
        Me.cmbLoadLocation = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblLoadStorage = New System.Windows.Forms.Label()
        Me.cmbLoadTank = New System.Windows.Forms.ComboBox()
        Me.lblT3Name = New System.Windows.Forms.Label()
        Me.lblT1Name = New System.Windows.Forms.Label()
        Me.txtPrevDayReading = New System.Windows.Forms.TextBox()
        Me.btnResetMain = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblCapacityValue = New System.Windows.Forms.Label()
        Me.grpTransCPO = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTransRemarks = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnResetTrans = New System.Windows.Forms.Button()
        Me.btnAddTrans = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtTransMonthToDate = New System.Windows.Forms.TextBox()
        Me.lblTransMonthDate = New System.Windows.Forms.Label()
        Me.txtTransQty = New System.Windows.Forms.TextBox()
        Me.lblTransQty = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblTransStorage = New System.Windows.Forms.Label()
        Me.lblTransToLoading = New System.Windows.Forms.Label()
        Me.cmbTransTank = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbLoadTrans = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDirt = New System.Windows.Forms.TextBox()
        Me.lblDirt = New System.Windows.Forms.Label()
        Me.txtMoisture = New System.Windows.Forms.TextBox()
        Me.lblMoisture = New System.Windows.Forms.Label()
        Me.txtFFA = New System.Windows.Forms.TextBox()
        Me.lblFFA = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTemparature = New System.Windows.Forms.TextBox()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.txtMeasurement = New System.Windows.Forms.TextBox()
        Me.lblMeasurement = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblStockStorage = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtCurrentReading = New System.Windows.Forms.TextBox()
        Me.lblCurrentReading = New System.Windows.Forms.Label()
        Me.lblPrevDaystockReading = New System.Windows.Forms.Label()
        Me.lblCapacity = New System.Windows.Forms.Label()
        Me.cmbStockTank = New System.Windows.Forms.ComboBox()
        Me.tpCPOView = New System.Windows.Forms.TabPage()
        Me.dgvCPOView = New System.Windows.Forms.DataGridView()
        Me.gvCPODate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvProductionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvProductionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyToday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnlSearch = New Stepi.UI.ExtendedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dtpCPOViewDate = New System.Windows.Forms.DateTimePicker()
        Me.lblSearchBy = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.chkCPODate = New System.Windows.Forms.CheckBox()
        Me.btnViewSearch = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.lblViewStatus = New System.Windows.Forms.Label()
        Me.dtpAdjustmentViewDate = New System.Windows.Forms.DateTimePicker()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblAdjSearchNo = New System.Windows.Forms.Label()
        Me.tcCPOProduction.SuspendLayout()
        Me.tpCPOSave.SuspendLayout()
        Me.panCPO.SuspendLayout()
        Me.gpLoadCPO.SuspendLayout()
        CType(Me.dgvLoadCPODetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSLoadCPO.SuspendLayout()
        Me.grpStockCPORecords.SuspendLayout()
        CType(Me.dgvCPODetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsStockCPO.SuspendLayout()
        Me.grpProCPORecords.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grpStockCPO.SuspendLayout()
        Me.grpTransCPORecords.SuspendLayout()
        CType(Me.dgvTransCPODetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsTranshipCPO.SuspendLayout()
        Me.grpLoadCPO.SuspendLayout()
        Me.grpTransCPO.SuspendLayout()
        Me.tpCPOView.SuspendLayout()
        CType(Me.dgvCPOView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsCPO.SuspendLayout()
        Me.PnlSearch.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcCPOProduction
        '
        Me.tcCPOProduction.Controls.Add(Me.tpCPOSave)
        Me.tcCPOProduction.Controls.Add(Me.tpCPOView)
        Me.tcCPOProduction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcCPOProduction.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcCPOProduction.Location = New System.Drawing.Point(0, 0)
        Me.tcCPOProduction.Name = "tcCPOProduction"
        Me.tcCPOProduction.SelectedIndex = 0
        Me.tcCPOProduction.Size = New System.Drawing.Size(1000, 643)
        Me.tcCPOProduction.TabIndex = 0
        Me.tcCPOProduction.TabStop = False
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
        Me.tpCPOSave.Size = New System.Drawing.Size(992, 617)
        Me.tpCPOSave.TabIndex = 0
        Me.tpCPOSave.Text = "Production"
        Me.tpCPOSave.UseVisualStyleBackColor = True
        '
        'panCPO
        '
        Me.panCPO.AutoScroll = True
        Me.panCPO.BackColor = System.Drawing.Color.Transparent
        Me.panCPO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panCPO.Controls.Add(Me.gpLoadCPO)
        Me.panCPO.Controls.Add(Me.grpStockCPORecords)
        Me.panCPO.Controls.Add(Me.grpProCPORecords)
        Me.panCPO.Controls.Add(Me.GroupBox3)
        Me.panCPO.Controls.Add(Me.grpStockCPO)
        Me.panCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panCPO.Location = New System.Drawing.Point(3, 3)
        Me.panCPO.Name = "panCPO"
        Me.panCPO.Size = New System.Drawing.Size(986, 611)
        Me.panCPO.TabIndex = 0
        '
        'gpLoadCPO
        '
        Me.gpLoadCPO.BackColor = System.Drawing.Color.Transparent
        Me.gpLoadCPO.Controls.Add(Me.dgvLoadCPODetails)
        Me.gpLoadCPO.Controls.Add(Me.Label12)
        Me.gpLoadCPO.Controls.Add(Me.txtLoadCPORemarks)
        Me.gpLoadCPO.Controls.Add(Me.lblLoadRemarks)
        Me.gpLoadCPO.Controls.Add(Me.btnLoadReset)
        Me.gpLoadCPO.Controls.Add(Me.btnLoadAdd)
        Me.gpLoadCPO.Controls.Add(Me.Label19)
        Me.gpLoadCPO.Controls.Add(Me.Label22)
        Me.gpLoadCPO.Controls.Add(Me.txtLoadPrevDayReading)
        Me.gpLoadCPO.Controls.Add(Me.lblLoadPrevReading)
        Me.gpLoadCPO.Controls.Add(Me.txtLoadCtReading)
        Me.gpLoadCPO.Controls.Add(Me.lblLoadCtReading)
        Me.gpLoadCPO.Controls.Add(Me.Label28)
        Me.gpLoadCPO.Controls.Add(Me.lblLoading)
        Me.gpLoadCPO.Controls.Add(Me.cbLoading)
        Me.gpLoadCPO.Controls.Add(Me.Label35)
        Me.gpLoadCPO.Controls.Add(Me.Label36)
        Me.gpLoadCPO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpLoadCPO.Location = New System.Drawing.Point(1, 334)
        Me.gpLoadCPO.Name = "gpLoadCPO"
        Me.gpLoadCPO.Size = New System.Drawing.Size(956, 168)
        Me.gpLoadCPO.TabIndex = 182
        Me.gpLoadCPO.TabStop = False
        Me.gpLoadCPO.Text = "Stock CPO (Pontoon)"
        '
        'dgvLoadCPODetails
        '
        Me.dgvLoadCPODetails.AllowUserToAddRows = False
        Me.dgvLoadCPODetails.AllowUserToDeleteRows = False
        Me.dgvLoadCPODetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvLoadCPODetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLoadCPODetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvLoadCPODetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvLoadCPODetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLoadCPODetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLoadCPODetails.ColumnHeadersHeight = 30
        Me.dgvLoadCPODetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclLoadStorageLocID, Me.dgclProdLoadID, Me.dgclToLoading, Me.dgclLoadCtReading, Me.dgclPrevDayReadnig, Me.dgclLoadRemarks})
        Me.dgvLoadCPODetails.ContextMenuStrip = Me.CMSLoadCPO
        Me.dgvLoadCPODetails.EnableHeadersVisualStyles = False
        Me.dgvLoadCPODetails.GridColor = System.Drawing.Color.Gray
        Me.dgvLoadCPODetails.Location = New System.Drawing.Point(478, 19)
        Me.dgvLoadCPODetails.MultiSelect = False
        Me.dgvLoadCPODetails.Name = "dgvLoadCPODetails"
        Me.dgvLoadCPODetails.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLoadCPODetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLoadCPODetails.RowHeadersVisible = False
        Me.dgvLoadCPODetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLoadCPODetails.Size = New System.Drawing.Size(463, 140)
        Me.dgvLoadCPODetails.TabIndex = 319
        Me.dgvLoadCPODetails.TabStop = False
        '
        'dgclLoadStorageLocID
        '
        Me.dgclLoadStorageLocID.DataPropertyName = "LoadLocationID"
        Me.dgclLoadStorageLocID.HeaderText = "LoadLocationID"
        Me.dgclLoadStorageLocID.Name = "dgclLoadStorageLocID"
        Me.dgclLoadStorageLocID.ReadOnly = True
        Me.dgclLoadStorageLocID.Visible = False
        '
        'dgclProdLoadID
        '
        Me.dgclProdLoadID.DataPropertyName = "ProdLoadID"
        Me.dgclProdLoadID.HeaderText = "ProdLoadID"
        Me.dgclProdLoadID.Name = "dgclProdLoadID"
        Me.dgclProdLoadID.ReadOnly = True
        Me.dgclProdLoadID.Visible = False
        '
        'dgclToLoading
        '
        Me.dgclToLoading.DataPropertyName = "LoadLocation"
        Me.dgclToLoading.HeaderText = "Loading"
        Me.dgclToLoading.Name = "dgclToLoading"
        Me.dgclToLoading.ReadOnly = True
        '
        'dgclLoadCtReading
        '
        Me.dgclLoadCtReading.DataPropertyName = "LoadCtReading"
        Me.dgclLoadCtReading.HeaderText = "Current Reading(KG)"
        Me.dgclLoadCtReading.Name = "dgclLoadCtReading"
        Me.dgclLoadCtReading.ReadOnly = True
        '
        'dgclPrevDayReadnig
        '
        Me.dgclPrevDayReadnig.DataPropertyName = "LoadPrevDayReading"
        Me.dgclPrevDayReadnig.HeaderText = "Previous Day Reading(KG)"
        Me.dgclPrevDayReadnig.Name = "dgclPrevDayReadnig"
        Me.dgclPrevDayReadnig.ReadOnly = True
        Me.dgclPrevDayReadnig.Width = 150
        '
        'dgclLoadRemarks
        '
        Me.dgclLoadRemarks.DataPropertyName = "LoadRemarks"
        Me.dgclLoadRemarks.HeaderText = "Remarks"
        Me.dgclLoadRemarks.Name = "dgclLoadRemarks"
        Me.dgclLoadRemarks.ReadOnly = True
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(93, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 13)
        Me.Label12.TabIndex = 348
        Me.Label12.Text = ":"
        '
        'txtLoadCPORemarks
        '
        Me.txtLoadCPORemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoadCPORemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadCPORemarks.Location = New System.Drawing.Point(124, 96)
        Me.txtLoadCPORemarks.MaxLength = 300
        Me.txtLoadCPORemarks.Multiline = True
        Me.txtLoadCPORemarks.Name = "txtLoadCPORemarks"
        Me.txtLoadCPORemarks.Size = New System.Drawing.Size(302, 35)
        Me.txtLoadCPORemarks.TabIndex = 185
        '
        'lblLoadRemarks
        '
        Me.lblLoadRemarks.AutoSize = True
        Me.lblLoadRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblLoadRemarks.Location = New System.Drawing.Point(9, 96)
        Me.lblLoadRemarks.Name = "lblLoadRemarks"
        Me.lblLoadRemarks.Size = New System.Drawing.Size(58, 13)
        Me.lblLoadRemarks.TabIndex = 347
        Me.lblLoadRemarks.Text = "Remarks"
        '
        'btnLoadReset
        '
        Me.btnLoadReset.BackgroundImage = CType(resources.GetObject("btnLoadReset.BackgroundImage"), System.Drawing.Image)
        Me.btnLoadReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLoadReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadReset.Image = CType(resources.GetObject("btnLoadReset.Image"), System.Drawing.Image)
        Me.btnLoadReset.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnLoadReset.Location = New System.Drawing.Point(345, 140)
        Me.btnLoadReset.Name = "btnLoadReset"
        Me.btnLoadReset.Size = New System.Drawing.Size(81, 22)
        Me.btnLoadReset.TabIndex = 187
        Me.btnLoadReset.Text = "Reset"
        Me.btnLoadReset.UseVisualStyleBackColor = True
        '
        'btnLoadAdd
        '
        Me.btnLoadAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnLoadAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLoadAdd.Image = CType(resources.GetObject("btnLoadAdd.Image"), System.Drawing.Image)
        Me.btnLoadAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnLoadAdd.Location = New System.Drawing.Point(261, 140)
        Me.btnLoadAdd.Name = "btnLoadAdd"
        Me.btnLoadAdd.Size = New System.Drawing.Size(78, 22)
        Me.btnLoadAdd.TabIndex = 186
        Me.btnLoadAdd.Text = "Add"
        Me.btnLoadAdd.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(93, 54)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(11, 13)
        Me.Label19.TabIndex = 180
        Me.Label19.Text = ":"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(326, 54)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(11, 13)
        Me.Label22.TabIndex = 179
        Me.Label22.Text = ":"
        '
        'txtLoadPrevDayReading
        '
        Me.txtLoadPrevDayReading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoadPrevDayReading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadPrevDayReading.Location = New System.Drawing.Point(337, 54)
        Me.txtLoadPrevDayReading.MaxLength = 18
        Me.txtLoadPrevDayReading.Name = "txtLoadPrevDayReading"
        Me.txtLoadPrevDayReading.Size = New System.Drawing.Size(86, 21)
        Me.txtLoadPrevDayReading.TabIndex = 184
        '
        'lblLoadPrevReading
        '
        Me.lblLoadPrevReading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadPrevReading.ForeColor = System.Drawing.Color.Black
        Me.lblLoadPrevReading.Location = New System.Drawing.Point(238, 54)
        Me.lblLoadPrevReading.Name = "lblLoadPrevReading"
        Me.lblLoadPrevReading.Size = New System.Drawing.Size(88, 37)
        Me.lblLoadPrevReading.TabIndex = 178
        Me.lblLoadPrevReading.Text = "Previous  Day Reading (KG)"
        '
        'txtLoadCtReading
        '
        Me.txtLoadCtReading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoadCtReading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadCtReading.Location = New System.Drawing.Point(124, 54)
        Me.txtLoadCtReading.MaxLength = 18
        Me.txtLoadCtReading.Name = "txtLoadCtReading"
        Me.txtLoadCtReading.Size = New System.Drawing.Size(99, 21)
        Me.txtLoadCtReading.TabIndex = 183
        '
        'lblLoadCtReading
        '
        Me.lblLoadCtReading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadCtReading.ForeColor = System.Drawing.Color.Black
        Me.lblLoadCtReading.Location = New System.Drawing.Point(9, 54)
        Me.lblLoadCtReading.Name = "lblLoadCtReading"
        Me.lblLoadCtReading.Size = New System.Drawing.Size(82, 35)
        Me.lblLoadCtReading.TabIndex = 177
        Me.lblLoadCtReading.Text = "Current Reading (KG)"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(93, 19)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(11, 13)
        Me.Label28.TabIndex = 176
        Me.Label28.Text = ":"
        '
        'lblLoading
        '
        Me.lblLoading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.Black
        Me.lblLoading.Location = New System.Drawing.Point(9, 19)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(78, 35)
        Me.lblLoading.TabIndex = 175
        Me.lblLoading.Text = "Location / Pontoon"
        '
        'cbLoading
        '
        Me.cbLoading.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLoading.FormattingEnabled = True
        Me.cbLoading.Location = New System.Drawing.Point(124, 19)
        Me.cbLoading.Name = "cbLoading"
        Me.cbLoading.Size = New System.Drawing.Size(299, 21)
        Me.cbLoading.TabIndex = 182
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(1247, 158)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(0, 13)
        Me.Label35.TabIndex = 158
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(1247, 130)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(0, 13)
        Me.Label36.TabIndex = 157
        '
        'grpStockCPORecords
        '
        Me.grpStockCPORecords.BackColor = System.Drawing.Color.Transparent
        Me.grpStockCPORecords.Controls.Add(Me.dgvCPODetails)
        Me.grpStockCPORecords.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpStockCPORecords.Location = New System.Drawing.Point(1, 189)
        Me.grpStockCPORecords.Name = "grpStockCPORecords"
        Me.grpStockCPORecords.Size = New System.Drawing.Size(955, 139)
        Me.grpStockCPORecords.TabIndex = 180
        Me.grpStockCPORecords.TabStop = False
        Me.grpStockCPORecords.Text = "Stock Overall Records"
        '
        'dgvCPODetails
        '
        Me.dgvCPODetails.AllowUserToAddRows = False
        Me.dgvCPODetails.AllowUserToDeleteRows = False
        Me.dgvCPODetails.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvCPODetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCPODetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCPODetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCPODetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCPODetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCPODetails.ColumnHeadersHeight = 30
        Me.dgvCPODetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclStorage, Me.dgclBalance, Me.dgclLoadLocation, Me.dgclTransLocation, Me.dgclLoadLocationID, Me.dgclTransLocationID, Me.dgclLoadTankNo, Me.dgclTransTankNo, Me.dgclProdStockID, Me.dgclProdTranshipID, Me.dgclProdLoadingID, Me.dgclLoadQty, Me.dgclLoadMonth, Me.dgclTranshipQty, Me.dgclTranshipMonth, Me.dgclprodTodayQty, Me.dgclProdMonthQty, Me.dgclProdYearQty, Me.dgclLoadTankID, Me.dgclTransTankID, Me.dgclStockTankID, Me.dgclProductionID, Me.dgclCapacity, Me.dgclCurrentReading, Me.dgclWriteoff, Me.dgclReason, Me.dgclMeasurement, Me.dgclTemperature, Me.dgclFFA, Me.dgclMoisture, Me.dgclDirt, Me.dgcBeritaAcara})
        Me.dgvCPODetails.ContextMenuStrip = Me.cmsStockCPO
        Me.dgvCPODetails.EnableHeadersVisualStyles = False
        Me.dgvCPODetails.GridColor = System.Drawing.Color.Gray
        Me.dgvCPODetails.Location = New System.Drawing.Point(4, 23)
        Me.dgvCPODetails.MultiSelect = False
        Me.dgvCPODetails.Name = "dgvCPODetails"
        Me.dgvCPODetails.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCPODetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvCPODetails.RowHeadersVisible = False
        Me.dgvCPODetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCPODetails.Size = New System.Drawing.Size(939, 110)
        Me.dgvCPODetails.TabIndex = 188
        Me.dgvCPODetails.TabStop = False
        '
        'dgclStorage
        '
        Me.dgclStorage.DataPropertyName = "StockTankNo"
        Me.dgclStorage.HeaderText = "Production Volume"
        Me.dgclStorage.Name = "dgclStorage"
        Me.dgclStorage.ReadOnly = True
        Me.dgclStorage.Width = 60
        '
        'dgclBalance
        '
        Me.dgclBalance.DataPropertyName = "Balance"
        Me.dgclBalance.HeaderText = "Previous day Reading (KG)"
        Me.dgclBalance.Name = "dgclBalance"
        Me.dgclBalance.ReadOnly = True
        Me.dgclBalance.Width = 130
        '
        'dgclLoadLocation
        '
        Me.dgclLoadLocation.DataPropertyName = "LoadLocation"
        Me.dgclLoadLocation.HeaderText = "LoadLocation"
        Me.dgclLoadLocation.Name = "dgclLoadLocation"
        Me.dgclLoadLocation.ReadOnly = True
        Me.dgclLoadLocation.Visible = False
        '
        'dgclTransLocation
        '
        Me.dgclTransLocation.DataPropertyName = "TransLocation"
        Me.dgclTransLocation.HeaderText = "TransLocation"
        Me.dgclTransLocation.Name = "dgclTransLocation"
        Me.dgclTransLocation.ReadOnly = True
        Me.dgclTransLocation.Visible = False
        '
        'dgclLoadLocationID
        '
        Me.dgclLoadLocationID.DataPropertyName = "LoadLocationID"
        Me.dgclLoadLocationID.HeaderText = "LoadLocationID"
        Me.dgclLoadLocationID.Name = "dgclLoadLocationID"
        Me.dgclLoadLocationID.ReadOnly = True
        Me.dgclLoadLocationID.Visible = False
        '
        'dgclTransLocationID
        '
        Me.dgclTransLocationID.DataPropertyName = "TransLocationID"
        Me.dgclTransLocationID.HeaderText = "TransLocationID"
        Me.dgclTransLocationID.Name = "dgclTransLocationID"
        Me.dgclTransLocationID.ReadOnly = True
        Me.dgclTransLocationID.Visible = False
        '
        'dgclLoadTankNo
        '
        Me.dgclLoadTankNo.DataPropertyName = "LoadTankNo"
        Me.dgclLoadTankNo.HeaderText = "LoadTankNo"
        Me.dgclLoadTankNo.Name = "dgclLoadTankNo"
        Me.dgclLoadTankNo.ReadOnly = True
        Me.dgclLoadTankNo.Visible = False
        '
        'dgclTransTankNo
        '
        Me.dgclTransTankNo.DataPropertyName = "TransTankNo"
        Me.dgclTransTankNo.HeaderText = "TransTankNo"
        Me.dgclTransTankNo.Name = "dgclTransTankNo"
        Me.dgclTransTankNo.ReadOnly = True
        Me.dgclTransTankNo.Visible = False
        '
        'dgclProdStockID
        '
        Me.dgclProdStockID.DataPropertyName = "ProdStockID"
        Me.dgclProdStockID.HeaderText = "ProdStockID"
        Me.dgclProdStockID.Name = "dgclProdStockID"
        Me.dgclProdStockID.ReadOnly = True
        Me.dgclProdStockID.Visible = False
        '
        'dgclProdTranshipID
        '
        Me.dgclProdTranshipID.DataPropertyName = "ProdTranshipID"
        Me.dgclProdTranshipID.HeaderText = "ProdTranshipID"
        Me.dgclProdTranshipID.Name = "dgclProdTranshipID"
        Me.dgclProdTranshipID.ReadOnly = True
        Me.dgclProdTranshipID.Visible = False
        '
        'dgclProdLoadingID
        '
        Me.dgclProdLoadingID.DataPropertyName = "ProdLoadingID"
        Me.dgclProdLoadingID.HeaderText = "ProdLoadingID"
        Me.dgclProdLoadingID.Name = "dgclProdLoadingID"
        Me.dgclProdLoadingID.ReadOnly = True
        Me.dgclProdLoadingID.Visible = False
        '
        'dgclLoadQty
        '
        Me.dgclLoadQty.DataPropertyName = "LoadQty"
        Me.dgclLoadQty.HeaderText = "LoadQty"
        Me.dgclLoadQty.Name = "dgclLoadQty"
        Me.dgclLoadQty.ReadOnly = True
        Me.dgclLoadQty.Visible = False
        '
        'dgclLoadMonth
        '
        Me.dgclLoadMonth.DataPropertyName = "LoadMonth"
        Me.dgclLoadMonth.HeaderText = "LoadMonth"
        Me.dgclLoadMonth.Name = "dgclLoadMonth"
        Me.dgclLoadMonth.ReadOnly = True
        Me.dgclLoadMonth.Visible = False
        '
        'dgclTranshipQty
        '
        Me.dgclTranshipQty.DataPropertyName = "TranshipQty"
        Me.dgclTranshipQty.HeaderText = "TranshipQty"
        Me.dgclTranshipQty.Name = "dgclTranshipQty"
        Me.dgclTranshipQty.ReadOnly = True
        Me.dgclTranshipQty.Visible = False
        '
        'dgclTranshipMonth
        '
        Me.dgclTranshipMonth.DataPropertyName = "TranshipMonth"
        Me.dgclTranshipMonth.HeaderText = "TranshipMonth"
        Me.dgclTranshipMonth.Name = "dgclTranshipMonth"
        Me.dgclTranshipMonth.ReadOnly = True
        Me.dgclTranshipMonth.Visible = False
        '
        'dgclprodTodayQty
        '
        Me.dgclprodTodayQty.DataPropertyName = "prodTodayQty"
        Me.dgclprodTodayQty.HeaderText = "prodTodayQty"
        Me.dgclprodTodayQty.Name = "dgclprodTodayQty"
        Me.dgclprodTodayQty.ReadOnly = True
        Me.dgclprodTodayQty.Visible = False
        '
        'dgclProdMonthQty
        '
        Me.dgclProdMonthQty.DataPropertyName = "ProdMonthQty"
        Me.dgclProdMonthQty.HeaderText = "ProdMonthQty"
        Me.dgclProdMonthQty.Name = "dgclProdMonthQty"
        Me.dgclProdMonthQty.ReadOnly = True
        Me.dgclProdMonthQty.Visible = False
        '
        'dgclProdYearQty
        '
        Me.dgclProdYearQty.DataPropertyName = "ProdYearQty"
        Me.dgclProdYearQty.HeaderText = "ProdYearQty"
        Me.dgclProdYearQty.Name = "dgclProdYearQty"
        Me.dgclProdYearQty.ReadOnly = True
        Me.dgclProdYearQty.Visible = False
        '
        'dgclLoadTankID
        '
        Me.dgclLoadTankID.DataPropertyName = "LoadTankID"
        Me.dgclLoadTankID.HeaderText = "LoadTankID"
        Me.dgclLoadTankID.Name = "dgclLoadTankID"
        Me.dgclLoadTankID.ReadOnly = True
        Me.dgclLoadTankID.Visible = False
        '
        'dgclTransTankID
        '
        Me.dgclTransTankID.DataPropertyName = "TransTankID"
        Me.dgclTransTankID.HeaderText = "TransTankID"
        Me.dgclTransTankID.Name = "dgclTransTankID"
        Me.dgclTransTankID.ReadOnly = True
        Me.dgclTransTankID.Visible = False
        '
        'dgclStockTankID
        '
        Me.dgclStockTankID.DataPropertyName = "StockTankID"
        Me.dgclStockTankID.HeaderText = "StockTankID"
        Me.dgclStockTankID.Name = "dgclStockTankID"
        Me.dgclStockTankID.ReadOnly = True
        Me.dgclStockTankID.Visible = False
        '
        'dgclProductionID
        '
        Me.dgclProductionID.DataPropertyName = "ProductionID"
        Me.dgclProductionID.HeaderText = "ProductionID"
        Me.dgclProductionID.Name = "dgclProductionID"
        Me.dgclProductionID.ReadOnly = True
        Me.dgclProductionID.Visible = False
        '
        'dgclCapacity
        '
        Me.dgclCapacity.DataPropertyName = "Capacity"
        Me.dgclCapacity.HeaderText = "Capacity(KG)"
        Me.dgclCapacity.Name = "dgclCapacity"
        Me.dgclCapacity.ReadOnly = True
        Me.dgclCapacity.Width = 90
        '
        'dgclCurrentReading
        '
        Me.dgclCurrentReading.DataPropertyName = "CurrentReading"
        Me.dgclCurrentReading.HeaderText = "Current Reading(KG)"
        Me.dgclCurrentReading.Name = "dgclCurrentReading"
        Me.dgclCurrentReading.ReadOnly = True
        Me.dgclCurrentReading.Width = 150
        '
        'dgclWriteoff
        '
        Me.dgclWriteoff.DataPropertyName = "Writeoff"
        Me.dgclWriteoff.HeaderText = "Writeoff"
        Me.dgclWriteoff.Name = "dgclWriteoff"
        Me.dgclWriteoff.ReadOnly = True
        '
        'dgclReason
        '
        Me.dgclReason.DataPropertyName = "Reason"
        Me.dgclReason.HeaderText = "Reason"
        Me.dgclReason.Name = "dgclReason"
        Me.dgclReason.ReadOnly = True
        Me.dgclReason.Visible = False
        '
        'dgclMeasurement
        '
        Me.dgclMeasurement.DataPropertyName = "Measurement"
        Me.dgclMeasurement.HeaderText = "Measurement(cm)"
        Me.dgclMeasurement.Name = "dgclMeasurement"
        Me.dgclMeasurement.ReadOnly = True
        Me.dgclMeasurement.Width = 120
        '
        'dgclTemperature
        '
        Me.dgclTemperature.DataPropertyName = "Temperature"
        Me.dgclTemperature.HeaderText = "Temperature"
        Me.dgclTemperature.Name = "dgclTemperature"
        Me.dgclTemperature.ReadOnly = True
        Me.dgclTemperature.Width = 90
        '
        'dgclFFA
        '
        Me.dgclFFA.DataPropertyName = "FFA"
        Me.dgclFFA.HeaderText = "FFA %"
        Me.dgclFFA.Name = "dgclFFA"
        Me.dgclFFA.ReadOnly = True
        Me.dgclFFA.Visible = False
        Me.dgclFFA.Width = 70
        '
        'dgclMoisture
        '
        Me.dgclMoisture.DataPropertyName = "Moisture"
        Me.dgclMoisture.HeaderText = "Moisture %"
        Me.dgclMoisture.Name = "dgclMoisture"
        Me.dgclMoisture.ReadOnly = True
        Me.dgclMoisture.Visible = False
        '
        'dgclDirt
        '
        Me.dgclDirt.DataPropertyName = "DirtP"
        DataGridViewCellStyle6.Format = "N3"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.dgclDirt.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgclDirt.HeaderText = "Dirt %"
        Me.dgclDirt.Name = "dgclDirt"
        Me.dgclDirt.ReadOnly = True
        Me.dgclDirt.Visible = False
        Me.dgclDirt.Width = 70
        '
        'dgcBeritaAcara
        '
        Me.dgcBeritaAcara.DataPropertyName = "BeritaAcara"
        Me.dgcBeritaAcara.HeaderText = "BeritaAcara"
        Me.dgcBeritaAcara.Name = "dgcBeritaAcara"
        Me.dgcBeritaAcara.ReadOnly = True
        Me.dgcBeritaAcara.Visible = False
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
        'grpProCPORecords
        '
        Me.grpProCPORecords.BackColor = System.Drawing.Color.Transparent
        Me.grpProCPORecords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.grpProCPORecords.Controls.Add(Me.btnDeleteAll)
        Me.grpProCPORecords.Controls.Add(Me.Label8)
        Me.grpProCPORecords.Controls.Add(Me.btnReset)
        Me.grpProCPORecords.Controls.Add(Me.btnClose)
        Me.grpProCPORecords.Controls.Add(Me.btnSaveAll)
        Me.grpProCPORecords.Controls.Add(Me.txtProductionYear)
        Me.grpProCPORecords.Controls.Add(Me.lblProYeardate)
        Me.grpProCPORecords.Controls.Add(Me.lblTonMonth)
        Me.grpProCPORecords.Controls.Add(Me.txtProductionMonth)
        Me.grpProCPORecords.Controls.Add(Me.lblProMonthdate)
        Me.grpProCPORecords.Controls.Add(Me.lblTonToday)
        Me.grpProCPORecords.Controls.Add(Me.txtProductionToday)
        Me.grpProCPORecords.Controls.Add(Me.lblProToday)
        Me.grpProCPORecords.Controls.Add(Me.Label34)
        Me.grpProCPORecords.Controls.Add(Me.lblProStorage)
        Me.grpProCPORecords.Controls.Add(Me.Label42)
        Me.grpProCPORecords.Controls.Add(Me.Label43)
        Me.grpProCPORecords.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpProCPORecords.Location = New System.Drawing.Point(1, 507)
        Me.grpProCPORecords.Name = "grpProCPORecords"
        Me.grpProCPORecords.Size = New System.Drawing.Size(957, 97)
        Me.grpProCPORecords.TabIndex = 188
        Me.grpProCPORecords.TabStop = False
        Me.grpProCPORecords.Text = " Production Qty"
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnDeleteAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteAll.Image = Global.BSP.My.Resources.Resources.icon_delete
        Me.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteAll.Location = New System.Drawing.Point(751, 65)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(117, 25)
        Me.btnDeleteAll.TabIndex = 194
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        Me.btnDeleteAll.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(738, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 13)
        Me.Label8.TabIndex = 363
        Me.Label8.Text = "Kg"
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(517, 65)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(112, 25)
        Me.btnReset.TabIndex = 192
        Me.btnReset.Text = "Reset All"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(641, 65)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 25)
        Me.btnClose.TabIndex = 193
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(373, 65)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(132, 25)
        Me.btnSaveAll.TabIndex = 191
        Me.btnSaveAll.Text = "Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'txtProductionYear
        '
        Me.txtProductionYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductionYear.Enabled = False
        Me.txtProductionYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductionYear.Location = New System.Drawing.Point(574, 38)
        Me.txtProductionYear.MaxLength = 14
        Me.txtProductionYear.Name = "txtProductionYear"
        Me.txtProductionYear.Size = New System.Drawing.Size(157, 21)
        Me.txtProductionYear.TabIndex = 190
        '
        'lblProYeardate
        '
        Me.lblProYeardate.AutoSize = True
        Me.lblProYeardate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProYeardate.ForeColor = System.Drawing.Color.Black
        Me.lblProYeardate.Location = New System.Drawing.Point(609, 14)
        Me.lblProYeardate.Name = "lblProYeardate"
        Me.lblProYeardate.Size = New System.Drawing.Size(78, 13)
        Me.lblProYeardate.TabIndex = 190
        Me.lblProYeardate.Text = "Year To date"
        '
        'lblTonMonth
        '
        Me.lblTonMonth.AutoSize = True
        Me.lblTonMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTonMonth.ForeColor = System.Drawing.Color.Black
        Me.lblTonMonth.Location = New System.Drawing.Point(511, 40)
        Me.lblTonMonth.Name = "lblTonMonth"
        Me.lblTonMonth.Size = New System.Drawing.Size(22, 13)
        Me.lblTonMonth.TabIndex = 189
        Me.lblTonMonth.Text = "Kg"
        '
        'txtProductionMonth
        '
        Me.txtProductionMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductionMonth.Enabled = False
        Me.txtProductionMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductionMonth.Location = New System.Drawing.Point(348, 38)
        Me.txtProductionMonth.MaxLength = 14
        Me.txtProductionMonth.Name = "txtProductionMonth"
        Me.txtProductionMonth.Size = New System.Drawing.Size(157, 21)
        Me.txtProductionMonth.TabIndex = 189
        '
        'lblProMonthdate
        '
        Me.lblProMonthdate.AutoSize = True
        Me.lblProMonthdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProMonthdate.ForeColor = System.Drawing.Color.Black
        Me.lblProMonthdate.Location = New System.Drawing.Point(384, 14)
        Me.lblProMonthdate.Name = "lblProMonthdate"
        Me.lblProMonthdate.Size = New System.Drawing.Size(87, 13)
        Me.lblProMonthdate.TabIndex = 187
        Me.lblProMonthdate.Text = "Month To date"
        '
        'lblTonToday
        '
        Me.lblTonToday.AutoSize = True
        Me.lblTonToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTonToday.ForeColor = System.Drawing.Color.Black
        Me.lblTonToday.Location = New System.Drawing.Point(288, 40)
        Me.lblTonToday.Name = "lblTonToday"
        Me.lblTonToday.Size = New System.Drawing.Size(22, 13)
        Me.lblTonToday.TabIndex = 186
        Me.lblTonToday.Text = "Kg"
        '
        'txtProductionToday
        '
        Me.txtProductionToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductionToday.Enabled = False
        Me.txtProductionToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductionToday.Location = New System.Drawing.Point(125, 38)
        Me.txtProductionToday.MaxLength = 14
        Me.txtProductionToday.Name = "txtProductionToday"
        Me.txtProductionToday.Size = New System.Drawing.Size(157, 21)
        Me.txtProductionToday.TabIndex = 188
        '
        'lblProToday
        '
        Me.lblProToday.AutoSize = True
        Me.lblProToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProToday.ForeColor = System.Drawing.Color.Black
        Me.lblProToday.Location = New System.Drawing.Point(182, 14)
        Me.lblProToday.Name = "lblProToday"
        Me.lblProToday.Size = New System.Drawing.Size(41, 13)
        Me.lblProToday.TabIndex = 183
        Me.lblProToday.Text = "Today"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(116, 40)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(11, 13)
        Me.Label34.TabIndex = 178
        Me.Label34.Text = ":"
        '
        'lblProStorage
        '
        Me.lblProStorage.AutoSize = True
        Me.lblProStorage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProStorage.ForeColor = System.Drawing.Color.Black
        Me.lblProStorage.Location = New System.Drawing.Point(5, 40)
        Me.lblProStorage.Name = "lblProStorage"
        Me.lblProStorage.Size = New System.Drawing.Size(113, 13)
        Me.lblProStorage.TabIndex = 177
        Me.lblProStorage.Text = "Production Volume"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(1247, 158)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(0, 13)
        Me.Label42.TabIndex = 158
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(1247, 130)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(0, 13)
        Me.Label43.TabIndex = 157
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.DtpProductionDate)
        Me.GroupBox3.Controls.Add(Me.lblProductionDate)
        Me.GroupBox3.Controls.Add(Me.dtpCPODate)
        Me.GroupBox3.Controls.Add(Me.lblDate)
        Me.GroupBox3.Location = New System.Drawing.Point(2, -6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(956, 44)
        Me.GroupBox3.TabIndex = 170
        Me.GroupBox3.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(60, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 179
        Me.Label9.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(449, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 13)
        Me.Label15.TabIndex = 178
        Me.Label15.Text = ":"
        '
        'DtpProductionDate
        '
        Me.DtpProductionDate.CustomFormat = "dd/MM/yyyy"
        Me.DtpProductionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpProductionDate.Location = New System.Drawing.Point(466, 16)
        Me.DtpProductionDate.Name = "DtpProductionDate"
        Me.DtpProductionDate.Size = New System.Drawing.Size(140, 21)
        Me.DtpProductionDate.TabIndex = 171
        '
        'lblProductionDate
        '
        Me.lblProductionDate.AutoSize = True
        Me.lblProductionDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductionDate.ForeColor = System.Drawing.Color.Red
        Me.lblProductionDate.Location = New System.Drawing.Point(348, 20)
        Me.lblProductionDate.Name = "lblProductionDate"
        Me.lblProductionDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblProductionDate.Size = New System.Drawing.Size(98, 13)
        Me.lblProductionDate.TabIndex = 176
        Me.lblProductionDate.Text = "Production Date"
        '
        'dtpCPODate
        '
        Me.dtpCPODate.CustomFormat = "dd/MM/yyyy"
        Me.dtpCPODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPODate.Location = New System.Drawing.Point(80, 16)
        Me.dtpCPODate.Name = "dtpCPODate"
        Me.dtpCPODate.Size = New System.Drawing.Size(155, 21)
        Me.dtpCPODate.TabIndex = 170
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Red
        Me.lblDate.Location = New System.Drawing.Point(20, 20)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(34, 13)
        Me.lblDate.TabIndex = 170
        Me.lblDate.Text = "Date"
        '
        'grpStockCPO
        '
        Me.grpStockCPO.BackColor = System.Drawing.Color.Transparent
        Me.grpStockCPO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.grpStockCPO.Controls.Add(Me.txtBeritaAcara)
        Me.grpStockCPO.Controls.Add(Me.Label10)
        Me.grpStockCPO.Controls.Add(Me.Label11)
        Me.grpStockCPO.Controls.Add(Me.txtReason)
        Me.grpStockCPO.Controls.Add(Me.Label25)
        Me.grpStockCPO.Controls.Add(Me.Label29)
        Me.grpStockCPO.Controls.Add(Me.txtWriteoff)
        Me.grpStockCPO.Controls.Add(Me.Label17)
        Me.grpStockCPO.Controls.Add(Me.Label24)
        Me.grpStockCPO.Controls.Add(Me.grpTransCPORecords)
        Me.grpStockCPO.Controls.Add(Me.grpLoadCPO)
        Me.grpStockCPO.Controls.Add(Me.txtPrevDayReading)
        Me.grpStockCPO.Controls.Add(Me.btnResetMain)
        Me.grpStockCPO.Controls.Add(Me.btnAdd)
        Me.grpStockCPO.Controls.Add(Me.lblCapacityValue)
        Me.grpStockCPO.Controls.Add(Me.grpTransCPO)
        Me.grpStockCPO.Controls.Add(Me.txtDirt)
        Me.grpStockCPO.Controls.Add(Me.lblDirt)
        Me.grpStockCPO.Controls.Add(Me.txtMoisture)
        Me.grpStockCPO.Controls.Add(Me.lblMoisture)
        Me.grpStockCPO.Controls.Add(Me.txtFFA)
        Me.grpStockCPO.Controls.Add(Me.lblFFA)
        Me.grpStockCPO.Controls.Add(Me.Label4)
        Me.grpStockCPO.Controls.Add(Me.Label6)
        Me.grpStockCPO.Controls.Add(Me.txtTemparature)
        Me.grpStockCPO.Controls.Add(Me.lblTemperature)
        Me.grpStockCPO.Controls.Add(Me.txtMeasurement)
        Me.grpStockCPO.Controls.Add(Me.lblMeasurement)
        Me.grpStockCPO.Controls.Add(Me.Label21)
        Me.grpStockCPO.Controls.Add(Me.lblStockStorage)
        Me.grpStockCPO.Controls.Add(Me.Label39)
        Me.grpStockCPO.Controls.Add(Me.Label40)
        Me.grpStockCPO.Controls.Add(Me.Label41)
        Me.grpStockCPO.Controls.Add(Me.txtCurrentReading)
        Me.grpStockCPO.Controls.Add(Me.lblCurrentReading)
        Me.grpStockCPO.Controls.Add(Me.lblPrevDaystockReading)
        Me.grpStockCPO.Controls.Add(Me.lblCapacity)
        Me.grpStockCPO.Controls.Add(Me.cmbStockTank)
        Me.grpStockCPO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpStockCPO.Location = New System.Drawing.Point(1, 38)
        Me.grpStockCPO.Name = "grpStockCPO"
        Me.grpStockCPO.Size = New System.Drawing.Size(957, 147)
        Me.grpStockCPO.TabIndex = 172
        Me.grpStockCPO.TabStop = False
        Me.grpStockCPO.Text = "Stock Overall"
        '
        'txtBeritaAcara
        '
        Me.txtBeritaAcara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBeritaAcara.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeritaAcara.Location = New System.Drawing.Point(478, 71)
        Me.txtBeritaAcara.MaxLength = 18
        Me.txtBeritaAcara.Name = "txtBeritaAcara"
        Me.txtBeritaAcara.Size = New System.Drawing.Size(145, 21)
        Me.txtBeritaAcara.TabIndex = 195
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(461, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 194
        Me.Label10.Text = ":"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(342, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 20)
        Me.Label11.TabIndex = 193
        Me.Label11.Text = "Berita Acara"
        '
        'txtReason
        '
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReason.Location = New System.Drawing.Point(478, 96)
        Me.txtReason.MaxLength = 150
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(145, 42)
        Me.txtReason.TabIndex = 192
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(461, 93)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(11, 13)
        Me.Label25.TabIndex = 191
        Me.Label25.Text = ":"
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(343, 93)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(102, 20)
        Me.Label29.TabIndex = 190
        Me.Label29.Text = "Reason"
        '
        'txtWriteoff
        '
        Me.txtWriteoff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWriteoff.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWriteoff.Location = New System.Drawing.Point(478, 46)
        Me.txtWriteoff.MaxLength = 18
        Me.txtWriteoff.Name = "txtWriteoff"
        Me.txtWriteoff.Size = New System.Drawing.Size(145, 21)
        Me.txtWriteoff.TabIndex = 189
        Me.txtWriteoff.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(461, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 13)
        Me.Label17.TabIndex = 188
        Me.Label17.Text = ":"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(342, 47)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(102, 20)
        Me.Label24.TabIndex = 187
        Me.Label24.Text = "Writeoff"
        '
        'grpTransCPORecords
        '
        Me.grpTransCPORecords.BackColor = System.Drawing.Color.Transparent
        Me.grpTransCPORecords.Controls.Add(Me.dgvTransCPODetails)
        Me.grpTransCPORecords.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTransCPORecords.Location = New System.Drawing.Point(939, 68)
        Me.grpTransCPORecords.Name = "grpTransCPORecords"
        Me.grpTransCPORecords.Size = New System.Drawing.Size(104, 32)
        Me.grpTransCPORecords.TabIndex = 182
        Me.grpTransCPORecords.TabStop = False
        Me.grpTransCPORecords.Text = "Transshipment CPO Records"
        Me.grpTransCPORecords.Visible = False
        '
        'dgvTransCPODetails
        '
        Me.dgvTransCPODetails.AllowUserToAddRows = False
        Me.dgvTransCPODetails.AllowUserToDeleteRows = False
        Me.dgvTransCPODetails.AllowUserToResizeRows = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvTransCPODetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvTransCPODetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTransCPODetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTransCPODetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransCPODetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvTransCPODetails.ColumnHeadersHeight = 30
        Me.dgvTransCPODetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclTransStorageNo, Me.dgclTransStorageID, Me.dgclTransStorageLocID, Me.dgclTranshipLoad, Me.TransDescription, Me.dgclTranshipQuantity, Me.dgclTransMonthDate, Me.dgclProdTranshipID1, Me.dgclProductionIDTrans, Me.dgclCPODateTrans, Me.dgclTransRemarks})
        Me.dgvTransCPODetails.ContextMenuStrip = Me.cmsTranshipCPO
        Me.dgvTransCPODetails.EnableHeadersVisualStyles = False
        Me.dgvTransCPODetails.GridColor = System.Drawing.Color.Gray
        Me.dgvTransCPODetails.Location = New System.Drawing.Point(6, 23)
        Me.dgvTransCPODetails.MultiSelect = False
        Me.dgvTransCPODetails.Name = "dgvTransCPODetails"
        Me.dgvTransCPODetails.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransCPODetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvTransCPODetails.RowHeadersVisible = False
        Me.dgvTransCPODetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransCPODetails.Size = New System.Drawing.Size(474, 117)
        Me.dgvTransCPODetails.TabIndex = 319
        Me.dgvTransCPODetails.TabStop = False
        '
        'dgclTransStorageNo
        '
        Me.dgclTransStorageNo.DataPropertyName = "TransTankNo"
        Me.dgclTransStorageNo.HeaderText = "Loading"
        Me.dgclTransStorageNo.Name = "dgclTransStorageNo"
        Me.dgclTransStorageNo.ReadOnly = True
        Me.dgclTransStorageNo.Width = 80
        '
        'dgclTransStorageID
        '
        Me.dgclTransStorageID.DataPropertyName = "TransTankID"
        Me.dgclTransStorageID.HeaderText = "TransStorageID"
        Me.dgclTransStorageID.Name = "dgclTransStorageID"
        Me.dgclTransStorageID.ReadOnly = True
        Me.dgclTransStorageID.Visible = False
        '
        'dgclTransStorageLocID
        '
        Me.dgclTransStorageLocID.DataPropertyName = "TransLocationID"
        Me.dgclTransStorageLocID.HeaderText = "TransStorageLocID"
        Me.dgclTransStorageLocID.Name = "dgclTransStorageLocID"
        Me.dgclTransStorageLocID.ReadOnly = True
        Me.dgclTransStorageLocID.Visible = False
        '
        'dgclTranshipLoad
        '
        Me.dgclTranshipLoad.DataPropertyName = "TransLocation"
        Me.dgclTranshipLoad.HeaderText = "Transshipment"
        Me.dgclTranshipLoad.Name = "dgclTranshipLoad"
        Me.dgclTranshipLoad.ReadOnly = True
        '
        'TransDescription
        '
        Me.TransDescription.DataPropertyName = "Descp"
        Me.TransDescription.HeaderText = "Description"
        Me.TransDescription.Name = "TransDescription"
        Me.TransDescription.ReadOnly = True
        Me.TransDescription.Visible = False
        '
        'dgclTranshipQuantity
        '
        Me.dgclTranshipQuantity.DataPropertyName = "TransQty"
        Me.dgclTranshipQuantity.HeaderText = "Quantity"
        Me.dgclTranshipQuantity.Name = "dgclTranshipQuantity"
        Me.dgclTranshipQuantity.ReadOnly = True
        Me.dgclTranshipQuantity.Width = 70
        '
        'dgclTransMonthDate
        '
        Me.dgclTransMonthDate.DataPropertyName = "TransMonthToDate"
        Me.dgclTransMonthDate.HeaderText = "Month To date"
        Me.dgclTransMonthDate.Name = "dgclTransMonthDate"
        Me.dgclTransMonthDate.ReadOnly = True
        Me.dgclTransMonthDate.Width = 120
        '
        'dgclProdTranshipID1
        '
        Me.dgclProdTranshipID1.DataPropertyName = "ProdTranshipID"
        Me.dgclProdTranshipID1.HeaderText = "ProdTranshipID"
        Me.dgclProdTranshipID1.Name = "dgclProdTranshipID1"
        Me.dgclProdTranshipID1.ReadOnly = True
        Me.dgclProdTranshipID1.Visible = False
        '
        'dgclProductionIDTrans
        '
        Me.dgclProductionIDTrans.DataPropertyName = "ProductionID"
        Me.dgclProductionIDTrans.HeaderText = "ProductionID"
        Me.dgclProductionIDTrans.Name = "dgclProductionIDTrans"
        Me.dgclProductionIDTrans.ReadOnly = True
        Me.dgclProductionIDTrans.Visible = False
        '
        'dgclCPODateTrans
        '
        Me.dgclCPODateTrans.DataPropertyName = "CPOProductionDate"
        Me.dgclCPODateTrans.HeaderText = "ProductionDate"
        Me.dgclCPODateTrans.Name = "dgclCPODateTrans"
        Me.dgclCPODateTrans.ReadOnly = True
        Me.dgclCPODateTrans.Visible = False
        '
        'dgclTransRemarks
        '
        Me.dgclTransRemarks.DataPropertyName = "TransRemarks"
        Me.dgclTransRemarks.HeaderText = "Remarks"
        Me.dgclTransRemarks.Name = "dgclTransRemarks"
        Me.dgclTransRemarks.ReadOnly = True
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
        'grpLoadCPO
        '
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
        Me.grpLoadCPO.Location = New System.Drawing.Point(937, 30)
        Me.grpLoadCPO.Name = "grpLoadCPO"
        Me.grpLoadCPO.Size = New System.Drawing.Size(153, 88)
        Me.grpLoadCPO.TabIndex = 175
        Me.grpLoadCPO.TabStop = False
        Me.grpLoadCPO.Text = "Loading CPO"
        Me.grpLoadCPO.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(79, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 348
        Me.Label3.Text = ":"
        '
        'txtLoadRemarks
        '
        Me.txtLoadRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoadRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadRemarks.Location = New System.Drawing.Point(96, 77)
        Me.txtLoadRemarks.MaxLength = 300
        Me.txtLoadRemarks.Multiline = True
        Me.txtLoadRemarks.Name = "txtLoadRemarks"
        Me.txtLoadRemarks.Size = New System.Drawing.Size(170, 35)
        Me.txtLoadRemarks.TabIndex = 345
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(9, 77)
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
        Me.btnResetLoad.Location = New System.Drawing.Point(363, 77)
        Me.btnResetLoad.Name = "btnResetLoad"
        Me.btnResetLoad.Size = New System.Drawing.Size(81, 22)
        Me.btnResetLoad.TabIndex = 346
        Me.btnResetLoad.Text = "Reset"
        Me.btnResetLoad.UseVisualStyleBackColor = True
        '
        'btnAddLoad
        '
        Me.btnAddLoad.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAddLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddLoad.Image = CType(resources.GetObject("btnAddLoad.Image"), System.Drawing.Image)
        Me.btnAddLoad.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAddLoad.Location = New System.Drawing.Point(279, 77)
        Me.btnAddLoad.Name = "btnAddLoad"
        Me.btnAddLoad.Size = New System.Drawing.Size(78, 22)
        Me.btnAddLoad.TabIndex = 345
        Me.btnAddLoad.Text = "Add"
        Me.btnAddLoad.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(373, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 13)
        Me.Label20.TabIndex = 180
        Me.Label20.Text = ":"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(373, 50)
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
        Me.txtLoadMonthToDate.Location = New System.Drawing.Point(384, 50)
        Me.txtLoadMonthToDate.MaxLength = 14
        Me.txtLoadMonthToDate.Name = "txtLoadMonthToDate"
        Me.txtLoadMonthToDate.Size = New System.Drawing.Size(67, 21)
        Me.txtLoadMonthToDate.TabIndex = 344
        '
        'lblLoadMonthDate
        '
        Me.lblLoadMonthDate.AutoSize = True
        Me.lblLoadMonthDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadMonthDate.ForeColor = System.Drawing.Color.Black
        Me.lblLoadMonthDate.Location = New System.Drawing.Point(285, 50)
        Me.lblLoadMonthDate.Name = "lblLoadMonthDate"
        Me.lblLoadMonthDate.Size = New System.Drawing.Size(87, 13)
        Me.lblLoadMonthDate.TabIndex = 178
        Me.lblLoadMonthDate.Text = "Month To date"
        '
        'txtLoadQty
        '
        Me.txtLoadQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoadQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadQty.Location = New System.Drawing.Point(384, 22)
        Me.txtLoadQty.MaxLength = 14
        Me.txtLoadQty.Name = "txtLoadQty"
        Me.txtLoadQty.Size = New System.Drawing.Size(67, 21)
        Me.txtLoadQty.TabIndex = 343
        '
        'lblLoadQty
        '
        Me.lblLoadQty.AutoSize = True
        Me.lblLoadQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadQty.ForeColor = System.Drawing.Color.Black
        Me.lblLoadQty.Location = New System.Drawing.Point(291, 26)
        Me.lblLoadQty.Name = "lblLoadQty"
        Me.lblLoadQty.Size = New System.Drawing.Size(86, 13)
        Me.lblLoadQty.TabIndex = 177
        Me.lblLoadQty.Text = "Quantity (KG)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(79, 50)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(11, 13)
        Me.Label18.TabIndex = 176
        Me.Label18.Text = ":"
        '
        'lblToLoading
        '
        Me.lblToLoading.AutoSize = True
        Me.lblToLoading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToLoading.ForeColor = System.Drawing.Color.Black
        Me.lblToLoading.Location = New System.Drawing.Point(9, 50)
        Me.lblToLoading.Name = "lblToLoading"
        Me.lblToLoading.Size = New System.Drawing.Size(68, 13)
        Me.lblToLoading.TabIndex = 175
        Me.lblToLoading.Text = "To Loading"
        '
        'cmbLoadLocation
        '
        Me.cmbLoadLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLoadLocation.FormattingEnabled = True
        Me.cmbLoadLocation.Location = New System.Drawing.Point(96, 50)
        Me.cmbLoadLocation.Name = "cmbLoadLocation"
        Me.cmbLoadLocation.Size = New System.Drawing.Size(188, 21)
        Me.cmbLoadLocation.TabIndex = 342
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(79, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 13)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = ":"
        '
        'lblLoadStorage
        '
        Me.lblLoadStorage.AutoSize = True
        Me.lblLoadStorage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadStorage.ForeColor = System.Drawing.Color.Black
        Me.lblLoadStorage.Location = New System.Drawing.Point(9, 24)
        Me.lblLoadStorage.Name = "lblLoadStorage"
        Me.lblLoadStorage.Size = New System.Drawing.Size(113, 13)
        Me.lblLoadStorage.TabIndex = 172
        Me.lblLoadStorage.Text = "Production Volume"
        '
        'cmbLoadTank
        '
        Me.cmbLoadTank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLoadTank.FormattingEnabled = True
        Me.cmbLoadTank.Location = New System.Drawing.Point(96, 22)
        Me.cmbLoadTank.Name = "cmbLoadTank"
        Me.cmbLoadTank.Size = New System.Drawing.Size(188, 21)
        Me.cmbLoadTank.TabIndex = 341
        Me.cmbLoadTank.TabStop = False
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
        'txtPrevDayReading
        '
        Me.txtPrevDayReading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrevDayReading.Enabled = False
        Me.txtPrevDayReading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrevDayReading.Location = New System.Drawing.Point(479, 14)
        Me.txtPrevDayReading.MaxLength = 18
        Me.txtPrevDayReading.Name = "txtPrevDayReading"
        Me.txtPrevDayReading.Size = New System.Drawing.Size(144, 21)
        Me.txtPrevDayReading.TabIndex = 173
        '
        'btnResetMain
        '
        Me.btnResetMain.BackgroundImage = CType(resources.GetObject("btnResetMain.BackgroundImage"), System.Drawing.Image)
        Me.btnResetMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetMain.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetMain.Image = CType(resources.GetObject("btnResetMain.Image"), System.Drawing.Image)
        Me.btnResetMain.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnResetMain.Location = New System.Drawing.Point(723, 113)
        Me.btnResetMain.Name = "btnResetMain"
        Me.btnResetMain.Size = New System.Drawing.Size(81, 25)
        Me.btnResetMain.TabIndex = 181
        Me.btnResetMain.Text = "Reset"
        Me.btnResetMain.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAdd.Location = New System.Drawing.Point(633, 113)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 25)
        Me.btnAdd.TabIndex = 180
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblCapacityValue
        '
        Me.lblCapacityValue.AutoSize = True
        Me.lblCapacityValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacityValue.ForeColor = System.Drawing.Color.Blue
        Me.lblCapacityValue.Location = New System.Drawing.Point(179, 45)
        Me.lblCapacityValue.Name = "lblCapacityValue"
        Me.lblCapacityValue.Size = New System.Drawing.Size(57, 13)
        Me.lblCapacityValue.TabIndex = 186
        Me.lblCapacityValue.Text = "Capacity"
        '
        'grpTransCPO
        '
        Me.grpTransCPO.BackColor = System.Drawing.Color.Transparent
        Me.grpTransCPO.Controls.Add(Me.Label5)
        Me.grpTransCPO.Controls.Add(Me.txtTransRemarks)
        Me.grpTransCPO.Controls.Add(Me.Label7)
        Me.grpTransCPO.Controls.Add(Me.btnResetTrans)
        Me.grpTransCPO.Controls.Add(Me.btnAddTrans)
        Me.grpTransCPO.Controls.Add(Me.Label26)
        Me.grpTransCPO.Controls.Add(Me.Label27)
        Me.grpTransCPO.Controls.Add(Me.txtTransMonthToDate)
        Me.grpTransCPO.Controls.Add(Me.lblTransMonthDate)
        Me.grpTransCPO.Controls.Add(Me.txtTransQty)
        Me.grpTransCPO.Controls.Add(Me.lblTransQty)
        Me.grpTransCPO.Controls.Add(Me.Label30)
        Me.grpTransCPO.Controls.Add(Me.Label32)
        Me.grpTransCPO.Controls.Add(Me.lblTransStorage)
        Me.grpTransCPO.Controls.Add(Me.lblTransToLoading)
        Me.grpTransCPO.Controls.Add(Me.cmbTransTank)
        Me.grpTransCPO.Controls.Add(Me.Label1)
        Me.grpTransCPO.Controls.Add(Me.cmbLoadTrans)
        Me.grpTransCPO.Controls.Add(Me.Label2)
        Me.grpTransCPO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTransCPO.Location = New System.Drawing.Point(941, 22)
        Me.grpTransCPO.Name = "grpTransCPO"
        Me.grpTransCPO.Size = New System.Drawing.Size(133, 38)
        Me.grpTransCPO.TabIndex = 176
        Me.grpTransCPO.TabStop = False
        Me.grpTransCPO.Text = "Transshipment CPO"
        Me.grpTransCPO.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(96, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 354
        Me.Label5.Text = ":"
        '
        'txtTransRemarks
        '
        Me.txtTransRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransRemarks.Location = New System.Drawing.Point(109, 77)
        Me.txtTransRemarks.MaxLength = 300
        Me.txtTransRemarks.Multiline = True
        Me.txtTransRemarks.Name = "txtTransRemarks"
        Me.txtTransRemarks.Size = New System.Drawing.Size(188, 35)
        Me.txtTransRemarks.TabIndex = 351
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(7, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 353
        Me.Label7.Text = "Remarks"
        '
        'btnResetTrans
        '
        Me.btnResetTrans.BackgroundImage = CType(resources.GetObject("btnResetTrans.BackgroundImage"), System.Drawing.Image)
        Me.btnResetTrans.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetTrans.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetTrans.Image = CType(resources.GetObject("btnResetTrans.Image"), System.Drawing.Image)
        Me.btnResetTrans.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnResetTrans.Location = New System.Drawing.Point(398, 77)
        Me.btnResetTrans.Name = "btnResetTrans"
        Me.btnResetTrans.Size = New System.Drawing.Size(81, 23)
        Me.btnResetTrans.TabIndex = 352
        Me.btnResetTrans.Text = "Reset"
        Me.btnResetTrans.UseVisualStyleBackColor = True
        '
        'btnAddTrans
        '
        Me.btnAddTrans.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAddTrans.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddTrans.Image = CType(resources.GetObject("btnAddTrans.Image"), System.Drawing.Image)
        Me.btnAddTrans.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAddTrans.Location = New System.Drawing.Point(309, 77)
        Me.btnAddTrans.Name = "btnAddTrans"
        Me.btnAddTrans.Size = New System.Drawing.Size(83, 23)
        Me.btnAddTrans.TabIndex = 351
        Me.btnAddTrans.Text = "Add"
        Me.btnAddTrans.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(395, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(11, 13)
        Me.Label26.TabIndex = 192
        Me.Label26.Text = ":"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(397, 50)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(11, 13)
        Me.Label27.TabIndex = 191
        Me.Label27.Text = ":"
        '
        'txtTransMonthToDate
        '
        Me.txtTransMonthToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransMonthToDate.Enabled = False
        Me.txtTransMonthToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransMonthToDate.Location = New System.Drawing.Point(410, 46)
        Me.txtTransMonthToDate.MaxLength = 14
        Me.txtTransMonthToDate.Name = "txtTransMonthToDate"
        Me.txtTransMonthToDate.Size = New System.Drawing.Size(67, 21)
        Me.txtTransMonthToDate.TabIndex = 350
        '
        'lblTransMonthDate
        '
        Me.lblTransMonthDate.AutoSize = True
        Me.lblTransMonthDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransMonthDate.ForeColor = System.Drawing.Color.Black
        Me.lblTransMonthDate.Location = New System.Drawing.Point(303, 50)
        Me.lblTransMonthDate.Name = "lblTransMonthDate"
        Me.lblTransMonthDate.Size = New System.Drawing.Size(91, 13)
        Me.lblTransMonthDate.TabIndex = 190
        Me.lblTransMonthDate.Text = " Month To date"
        '
        'txtTransQty
        '
        Me.txtTransQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransQty.Location = New System.Drawing.Point(410, 17)
        Me.txtTransQty.MaxLength = 14
        Me.txtTransQty.Name = "txtTransQty"
        Me.txtTransQty.Size = New System.Drawing.Size(67, 21)
        Me.txtTransQty.TabIndex = 349
        '
        'lblTransQty
        '
        Me.lblTransQty.AutoSize = True
        Me.lblTransQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransQty.ForeColor = System.Drawing.Color.Black
        Me.lblTransQty.Location = New System.Drawing.Point(317, 21)
        Me.lblTransQty.Name = "lblTransQty"
        Me.lblTransQty.Size = New System.Drawing.Size(82, 13)
        Me.lblTransQty.TabIndex = 189
        Me.lblTransQty.Text = "Quantity(KG)"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(96, 49)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(11, 13)
        Me.Label30.TabIndex = 188
        Me.Label30.Text = ":"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(96, 21)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(11, 13)
        Me.Label32.TabIndex = 185
        Me.Label32.Text = ":"
        '
        'lblTransStorage
        '
        Me.lblTransStorage.AutoSize = True
        Me.lblTransStorage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransStorage.ForeColor = System.Drawing.Color.Black
        Me.lblTransStorage.Location = New System.Drawing.Point(7, 22)
        Me.lblTransStorage.Name = "lblTransStorage"
        Me.lblTransStorage.Size = New System.Drawing.Size(51, 13)
        Me.lblTransStorage.TabIndex = 184
        Me.lblTransStorage.Text = "Loading"
        '
        'lblTransToLoading
        '
        Me.lblTransToLoading.AutoSize = True
        Me.lblTransToLoading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransToLoading.ForeColor = System.Drawing.Color.Black
        Me.lblTransToLoading.Location = New System.Drawing.Point(7, 50)
        Me.lblTransToLoading.Name = "lblTransToLoading"
        Me.lblTransToLoading.Size = New System.Drawing.Size(90, 13)
        Me.lblTransToLoading.TabIndex = 187
        Me.lblTransToLoading.Text = "Transshipment"
        '
        'cmbTransTank
        '
        Me.cmbTransTank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransTank.FormattingEnabled = True
        Me.cmbTransTank.Location = New System.Drawing.Point(109, 18)
        Me.cmbTransTank.Name = "cmbTransTank"
        Me.cmbTransTank.Size = New System.Drawing.Size(188, 21)
        Me.cmbTransTank.TabIndex = 347
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(1247, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 158
        '
        'cmbLoadTrans
        '
        Me.cmbLoadTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLoadTrans.FormattingEnabled = True
        Me.cmbLoadTrans.Location = New System.Drawing.Point(109, 46)
        Me.cmbLoadTrans.Name = "cmbLoadTrans"
        Me.cmbLoadTrans.Size = New System.Drawing.Size(188, 21)
        Me.cmbLoadTrans.TabIndex = 348
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1247, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 157
        '
        'txtDirt
        '
        Me.txtDirt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDirt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirt.Location = New System.Drawing.Point(766, 78)
        Me.txtDirt.MaxLength = 18
        Me.txtDirt.Name = "txtDirt"
        Me.txtDirt.Size = New System.Drawing.Size(121, 21)
        Me.txtDirt.TabIndex = 179
        Me.txtDirt.Visible = False
        '
        'lblDirt
        '
        Me.lblDirt.AutoSize = True
        Me.lblDirt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirt.ForeColor = System.Drawing.Color.Black
        Me.lblDirt.Location = New System.Drawing.Point(678, 80)
        Me.lblDirt.Name = "lblDirt"
        Me.lblDirt.Size = New System.Drawing.Size(40, 13)
        Me.lblDirt.TabIndex = 181
        Me.lblDirt.Text = "Dirt%"
        Me.lblDirt.Visible = False
        '
        'txtMoisture
        '
        Me.txtMoisture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMoisture.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoisture.Location = New System.Drawing.Point(766, 42)
        Me.txtMoisture.MaxLength = 18
        Me.txtMoisture.Name = "txtMoisture"
        Me.txtMoisture.Size = New System.Drawing.Size(121, 21)
        Me.txtMoisture.TabIndex = 178
        Me.txtMoisture.Visible = False
        '
        'lblMoisture
        '
        Me.lblMoisture.AutoSize = True
        Me.lblMoisture.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoisture.ForeColor = System.Drawing.Color.Black
        Me.lblMoisture.Location = New System.Drawing.Point(678, 44)
        Me.lblMoisture.Name = "lblMoisture"
        Me.lblMoisture.Size = New System.Drawing.Size(71, 13)
        Me.lblMoisture.TabIndex = 180
        Me.lblMoisture.Text = "Moisture %"
        Me.lblMoisture.Visible = False
        '
        'txtFFA
        '
        Me.txtFFA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFFA.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFFA.Location = New System.Drawing.Point(766, 10)
        Me.txtFFA.MaxLength = 18
        Me.txtFFA.Name = "txtFFA"
        Me.txtFFA.Size = New System.Drawing.Size(121, 21)
        Me.txtFFA.TabIndex = 177
        Me.txtFFA.Visible = False
        '
        'lblFFA
        '
        Me.lblFFA.AutoSize = True
        Me.lblFFA.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFFA.ForeColor = System.Drawing.Color.Black
        Me.lblFFA.Location = New System.Drawing.Point(678, 15)
        Me.lblFFA.Name = "lblFFA"
        Me.lblFFA.Size = New System.Drawing.Size(38, 13)
        Me.lblFFA.TabIndex = 177
        Me.lblFFA.Text = "FFA%"
        Me.lblFFA.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(162, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 174
        Me.Label4.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(162, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 173
        Me.Label6.Text = ":"
        '
        'txtTemparature
        '
        Me.txtTemparature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTemparature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTemparature.Location = New System.Drawing.Point(179, 89)
        Me.txtTemparature.MaxLength = 15
        Me.txtTemparature.Name = "txtTemparature"
        Me.txtTemparature.Size = New System.Drawing.Size(121, 21)
        Me.txtTemparature.TabIndex = 176
        '
        'lblTemperature
        '
        Me.lblTemperature.AutoSize = True
        Me.lblTemperature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperature.ForeColor = System.Drawing.Color.Red
        Me.lblTemperature.Location = New System.Drawing.Point(23, 93)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Size = New System.Drawing.Size(80, 13)
        Me.lblTemperature.TabIndex = 172
        Me.lblTemperature.Text = "Temperature"
        '
        'txtMeasurement
        '
        Me.txtMeasurement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMeasurement.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeasurement.Location = New System.Drawing.Point(179, 64)
        Me.txtMeasurement.MaxLength = 18
        Me.txtMeasurement.Name = "txtMeasurement"
        Me.txtMeasurement.Size = New System.Drawing.Size(121, 21)
        Me.txtMeasurement.TabIndex = 175
        '
        'lblMeasurement
        '
        Me.lblMeasurement.AutoSize = True
        Me.lblMeasurement.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeasurement.ForeColor = System.Drawing.Color.Red
        Me.lblMeasurement.Location = New System.Drawing.Point(23, 68)
        Me.lblMeasurement.Name = "lblMeasurement"
        Me.lblMeasurement.Size = New System.Drawing.Size(115, 13)
        Me.lblMeasurement.TabIndex = 171
        Me.lblMeasurement.Text = "Measurement (cm)"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(163, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 13)
        Me.Label21.TabIndex = 170
        Me.Label21.Text = ":"
        '
        'lblStockStorage
        '
        Me.lblStockStorage.AutoSize = True
        Me.lblStockStorage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockStorage.ForeColor = System.Drawing.Color.Red
        Me.lblStockStorage.Location = New System.Drawing.Point(23, 19)
        Me.lblStockStorage.Name = "lblStockStorage"
        Me.lblStockStorage.Size = New System.Drawing.Size(113, 13)
        Me.lblStockStorage.TabIndex = 169
        Me.lblStockStorage.Text = "Production Volume"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(163, 44)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(11, 13)
        Me.Label39.TabIndex = 165
        Me.Label39.Text = ":"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(163, 118)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(11, 13)
        Me.Label40.TabIndex = 164
        Me.Label40.Text = ":"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(462, 16)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(11, 13)
        Me.Label41.TabIndex = 163
        Me.Label41.Text = ":"
        '
        'txtCurrentReading
        '
        Me.txtCurrentReading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurrentReading.Enabled = False
        Me.txtCurrentReading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentReading.Location = New System.Drawing.Point(179, 114)
        Me.txtCurrentReading.MaxLength = 18
        Me.txtCurrentReading.Name = "txtCurrentReading"
        Me.txtCurrentReading.Size = New System.Drawing.Size(121, 21)
        Me.txtCurrentReading.TabIndex = 174
        '
        'lblCurrentReading
        '
        Me.lblCurrentReading.AutoSize = True
        Me.lblCurrentReading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentReading.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentReading.Location = New System.Drawing.Point(23, 118)
        Me.lblCurrentReading.Name = "lblCurrentReading"
        Me.lblCurrentReading.Size = New System.Drawing.Size(136, 13)
        Me.lblCurrentReading.TabIndex = 162
        Me.lblCurrentReading.Text = "Current Reading  (KG)"
        '
        'lblPrevDaystockReading
        '
        Me.lblPrevDaystockReading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrevDaystockReading.ForeColor = System.Drawing.Color.Black
        Me.lblPrevDaystockReading.Location = New System.Drawing.Point(343, 12)
        Me.lblPrevDaystockReading.Name = "lblPrevDaystockReading"
        Me.lblPrevDaystockReading.Size = New System.Drawing.Size(102, 38)
        Me.lblPrevDaystockReading.TabIndex = 161
        Me.lblPrevDaystockReading.Text = "Previous Day Reading (KG)"
        '
        'lblCapacity
        '
        Me.lblCapacity.AutoSize = True
        Me.lblCapacity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity.ForeColor = System.Drawing.Color.Black
        Me.lblCapacity.Location = New System.Drawing.Point(23, 44)
        Me.lblCapacity.Name = "lblCapacity"
        Me.lblCapacity.Size = New System.Drawing.Size(84, 13)
        Me.lblCapacity.TabIndex = 160
        Me.lblCapacity.Text = "Capacity(KG)"
        '
        'cmbStockTank
        '
        Me.cmbStockTank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStockTank.FormattingEnabled = True
        Me.cmbStockTank.Location = New System.Drawing.Point(179, 14)
        Me.cmbStockTank.Name = "cmbStockTank"
        Me.cmbStockTank.Size = New System.Drawing.Size(121, 21)
        Me.cmbStockTank.TabIndex = 172
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
        Me.tpCPOView.Size = New System.Drawing.Size(992, 617)
        Me.tpCPOView.TabIndex = 1
        Me.tpCPOView.Text = "View"
        Me.tpCPOView.UseVisualStyleBackColor = True
        '
        'dgvCPOView
        '
        Me.dgvCPOView.AllowUserToAddRows = False
        Me.dgvCPOView.AllowUserToDeleteRows = False
        Me.dgvCPOView.AllowUserToResizeRows = False
        Me.dgvCPOView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCPOView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCPOView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCPOView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvCPOView.ColumnHeadersHeight = 30
        Me.dgvCPOView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvCPODate, Me.gvProductionDate, Me.gvProductionID, Me.QtyToday})
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
        Me.dgvCPOView.Size = New System.Drawing.Size(986, 506)
        Me.dgvCPOView.TabIndex = 505
        Me.dgvCPOView.TabStop = False
        '
        'gvCPODate
        '
        Me.gvCPODate.DataPropertyName = "CPODate"
        Me.gvCPODate.HeaderText = "Date"
        Me.gvCPODate.Name = "gvCPODate"
        Me.gvCPODate.ReadOnly = True
        '
        'gvProductionDate
        '
        Me.gvProductionDate.DataPropertyName = "ProductionDate"
        Me.gvProductionDate.HeaderText = "Production Date"
        Me.gvProductionDate.Name = "gvProductionDate"
        Me.gvProductionDate.ReadOnly = True
        Me.gvProductionDate.Width = 150
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
        'cmsCPO
        '
        Me.cmsCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsCPO.Name = "cmsIPR"
        Me.cmsCPO.Size = New System.Drawing.Size(108, 70)
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
        Me.PnlSearch.CaptionText = "Search Production"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.Panel2)
        Me.PnlSearch.Controls.Add(Me.dtpCPOViewDate)
        Me.PnlSearch.Controls.Add(Me.lblSearchBy)
        Me.PnlSearch.Controls.Add(Me.Label46)
        Me.PnlSearch.Controls.Add(Me.chkCPODate)
        Me.PnlSearch.Controls.Add(Me.btnViewSearch)
        Me.PnlSearch.Controls.Add(Me.btnView)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(986, 105)
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
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1118, 572)
        Me.DataGridView1.TabIndex = 31
        '
        'dtpCPOViewDate
        '
        Me.dtpCPOViewDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpCPOViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPOViewDate.Location = New System.Drawing.Point(179, 75)
        Me.dtpCPOViewDate.Name = "dtpCPOViewDate"
        Me.dtpCPOViewDate.Size = New System.Drawing.Size(135, 21)
        Me.dtpCPOViewDate.TabIndex = 502
        Me.dtpCPOViewDate.Value = New Date(2010, 2, 15, 11, 44, 0, 0)
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
        'chkCPODate
        '
        Me.chkCPODate.AutoSize = True
        Me.chkCPODate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkCPODate.Location = New System.Drawing.Point(179, 54)
        Me.chkCPODate.Name = "chkCPODate"
        Me.chkCPODate.Size = New System.Drawing.Size(121, 17)
        Me.chkCPODate.TabIndex = 501
        Me.chkCPODate.TabStop = False
        Me.chkCPODate.Text = " Production Date"
        Me.chkCPODate.UseVisualStyleBackColor = True
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
        Me.btnViewSearch.Location = New System.Drawing.Point(320, 71)
        Me.btnViewSearch.Name = "btnViewSearch"
        Me.btnViewSearch.Size = New System.Drawing.Size(116, 29)
        Me.btnViewSearch.TabIndex = 503
        Me.btnViewSearch.Text = "Search"
        Me.btnViewSearch.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnView.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnView.Location = New System.Drawing.Point(442, 71)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(116, 29)
        Me.btnView.TabIndex = 504
        Me.btnView.Text = "View Report"
        Me.btnView.UseVisualStyleBackColor = True
        Me.btnView.Visible = False
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
        'CPOProductionFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1000, 643)
        Me.Controls.Add(Me.tcCPOProduction)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "CPOProductionFrm"
        Me.Text = "CPOProductionFrm"
        Me.tcCPOProduction.ResumeLayout(False)
        Me.tpCPOSave.ResumeLayout(False)
        Me.panCPO.ResumeLayout(False)
        Me.gpLoadCPO.ResumeLayout(False)
        Me.gpLoadCPO.PerformLayout()
        CType(Me.dgvLoadCPODetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSLoadCPO.ResumeLayout(False)
        Me.grpStockCPORecords.ResumeLayout(False)
        CType(Me.dgvCPODetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsStockCPO.ResumeLayout(False)
        Me.grpProCPORecords.ResumeLayout(False)
        Me.grpProCPORecords.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grpStockCPO.ResumeLayout(False)
        Me.grpStockCPO.PerformLayout()
        Me.grpTransCPORecords.ResumeLayout(False)
        CType(Me.dgvTransCPODetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsTranshipCPO.ResumeLayout(False)
        Me.grpLoadCPO.ResumeLayout(False)
        Me.grpLoadCPO.PerformLayout()
        Me.grpTransCPO.ResumeLayout(False)
        Me.grpTransCPO.PerformLayout()
        Me.tpCPOView.ResumeLayout(False)
        Me.tpCPOView.PerformLayout()
        CType(Me.dgvCPOView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsCPO.ResumeLayout(False)
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcCPOProduction As System.Windows.Forms.TabControl
    Friend WithEvents tpCPOSave As System.Windows.Forms.TabPage
    Friend WithEvents panCPO As System.Windows.Forms.Panel
    Friend WithEvents tpCPOView As System.Windows.Forms.TabPage
    Friend WithEvents grpProCPORecords As System.Windows.Forms.GroupBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents txtProductionYear As System.Windows.Forms.TextBox
    Friend WithEvents lblProYeardate As System.Windows.Forms.Label
    Friend WithEvents lblTonMonth As System.Windows.Forms.Label
    Friend WithEvents txtProductionMonth As System.Windows.Forms.TextBox
    Friend WithEvents lblProMonthdate As System.Windows.Forms.Label
    Friend WithEvents lblTonToday As System.Windows.Forms.Label
    Friend WithEvents txtProductionToday As System.Windows.Forms.TextBox
    Friend WithEvents lblProToday As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lblProStorage As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents grpStockCPO As System.Windows.Forms.GroupBox
    Friend WithEvents lblCapacityValue As System.Windows.Forms.Label
    Friend WithEvents txtDirt As System.Windows.Forms.TextBox
    Friend WithEvents lblDirt As System.Windows.Forms.Label
    Friend WithEvents txtMoisture As System.Windows.Forms.TextBox
    Friend WithEvents lblMoisture As System.Windows.Forms.Label
    Friend WithEvents txtFFA As System.Windows.Forms.TextBox
    Friend WithEvents lblFFA As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTemparature As System.Windows.Forms.TextBox
    Friend WithEvents lblTemperature As System.Windows.Forms.Label
    Friend WithEvents txtMeasurement As System.Windows.Forms.TextBox
    Friend WithEvents lblMeasurement As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblStockStorage As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtCurrentReading As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentReading As System.Windows.Forms.Label
    Friend WithEvents lblPrevDaystockReading As System.Windows.Forms.Label
    Friend WithEvents lblCapacity As System.Windows.Forms.Label
    Friend WithEvents cmbStockTank As System.Windows.Forms.ComboBox
    Friend WithEvents grpTransCPO As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtTransMonthToDate As System.Windows.Forms.TextBox
    Friend WithEvents lblTransMonthDate As System.Windows.Forms.Label
    Friend WithEvents txtTransQty As System.Windows.Forms.TextBox
    Friend WithEvents lblTransQty As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblTransToLoading As System.Windows.Forms.Label
    Friend WithEvents cmbLoadTrans As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblTransStorage As System.Windows.Forms.Label
    Friend WithEvents cmbTransTank As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpLoadCPO As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtLoadMonthToDate As System.Windows.Forms.TextBox
    Friend WithEvents lblLoadMonthDate As System.Windows.Forms.Label
    Friend WithEvents txtLoadQty As System.Windows.Forms.TextBox
    Friend WithEvents lblLoadQty As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblToLoading As System.Windows.Forms.Label
    Friend WithEvents cmbLoadLocation As System.Windows.Forms.ComboBox
    Friend WithEvents lblT3Name As System.Windows.Forms.Label
    Friend WithEvents lblT1Name As System.Windows.Forms.Label
    Friend WithEvents lblViewStatus As System.Windows.Forms.Label
    Friend WithEvents dtpAdjustmentViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblAdjSearchNo As System.Windows.Forms.Label
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents chkCPODate As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents dgvCPOView As System.Windows.Forms.DataGridView
    Friend WithEvents cmsCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnResetMain As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents grpStockCPORecords As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCPODetails As System.Windows.Forms.DataGridView
    Friend WithEvents dtpCPOViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvLoadCPODetails As System.Windows.Forms.DataGridView
    Friend WithEvents grpTransCPORecords As System.Windows.Forms.GroupBox
    Friend WithEvents dgvTransCPODetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnResetTrans As System.Windows.Forms.Button
    Friend WithEvents btnAddTrans As System.Windows.Forms.Button
    Friend WithEvents btnResetLoad As System.Windows.Forms.Button
    Friend WithEvents btnAddLoad As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLoadRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTransRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPrevDayReading As System.Windows.Forms.TextBox
    Friend WithEvents dtpCPODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgclTransStorageNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransStorageID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransStorageLocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTranshipLoad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTranshipQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransMonthDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProdTranshipID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProductionIDTrans As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclCPODateTrans As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsStockCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StockCPOEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockCPODelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSLoadCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LoadCPOEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadCPODelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsTranshipCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TranshipEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TranshipDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DtpProductionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblProductionDate As System.Windows.Forms.Label
    Friend WithEvents gpLoadCPO As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLoadCPORemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblLoadRemarks As System.Windows.Forms.Label
    Friend WithEvents btnLoadReset As System.Windows.Forms.Button
    Friend WithEvents btnLoadAdd As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtLoadPrevDayReading As System.Windows.Forms.TextBox
    Friend WithEvents lblLoadPrevReading As System.Windows.Forms.Label
    Friend WithEvents txtLoadCtReading As System.Windows.Forms.TextBox
    Friend WithEvents lblLoadCtReading As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents cbLoading As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblLoadStorage As System.Windows.Forms.Label
    Friend WithEvents cmbLoadTank As System.Windows.Forms.ComboBox
    Friend WithEvents gvCPODate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvProductionDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvProductionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyToday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadStorageLocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProdLoadID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclToLoading As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadCtReading As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPrevDayReadnig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtWriteoff As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtBeritaAcara As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgclStorage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadLocationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransLocationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadTankNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransTankNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProdStockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProdTranshipID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProdLoadingID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTranshipQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTranshipMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclprodTodayQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProdMonthQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProdYearQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLoadTankID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransTankID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockTankID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProductionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclCapacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclCurrentReading As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclWriteoff As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclMeasurement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTemperature As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclFFA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclMoisture As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDirt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcBeritaAcara As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

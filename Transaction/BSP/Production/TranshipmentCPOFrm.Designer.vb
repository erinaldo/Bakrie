<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TranshipmentCPOFrm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TranshipmentCPOFrm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panCPO = New System.Windows.Forms.Panel()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpCPODate = New System.Windows.Forms.DateTimePicker()
        Me.lblTransDate = New System.Windows.Forms.Label()
        Me.grpTransCPO = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTermofSales = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLossInTransit = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTransRemarks = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.btnResetTrans = New System.Windows.Forms.Button()
        Me.btnAddTrans = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtTransMonthToDate = New System.Windows.Forms.TextBox()
        Me.lblTransMonthDate = New System.Windows.Forms.Label()
        Me.txtTransQty = New System.Windows.Forms.TextBox()
        Me.lblTransQty = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblToLoading = New System.Windows.Forms.Label()
        Me.cmbLoadTrans = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblTransStorage = New System.Windows.Forms.Label()
        Me.cmbTransTank = New System.Windows.Forms.ComboBox()
        Me.lblT3Name = New System.Windows.Forms.Label()
        Me.lblT1Name = New System.Windows.Forms.Label()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.dgvTransCPOView = New System.Windows.Forms.DataGridView()
        Me.gvCPODate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpCPOView = New System.Windows.Forms.TabPage()
        Me.PnlSearch = New Stepi.UI.ExtendedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblSearchBy = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.dtpCPOViewDate = New System.Windows.Forms.DateTimePicker()
        Me.chkCPODate = New System.Windows.Forms.CheckBox()
        Me.btnViewSearch = New System.Windows.Forms.Button()
        Me.lblViewStatus = New System.Windows.Forms.Label()
        Me.dtpAdjustmentViewDate = New System.Windows.Forms.DateTimePicker()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblAdjSearchNo = New System.Windows.Forms.Label()
        Me.LoadCPOEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMSLoadCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LoadCPODelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockCPODelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockCPOEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tcTransCPO = New System.Windows.Forms.TabControl()
        Me.tpCPOSave = New System.Windows.Forms.TabPage()
        Me.cmsStockCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.panCPO.SuspendLayout()
        Me.grpTransCPORecords.SuspendLayout()
        CType(Me.dgvTransCPODetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsTranshipCPO.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grpTransCPO.SuspendLayout()
        CType(Me.dgvTransCPOView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsCPO.SuspendLayout()
        Me.tpCPOView.SuspendLayout()
        Me.PnlSearch.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSLoadCPO.SuspendLayout()
        Me.tcTransCPO.SuspendLayout()
        Me.tpCPOSave.SuspendLayout()
        Me.cmsStockCPO.SuspendLayout()
        Me.SuspendLayout()
        '
        'panCPO
        '
        Me.panCPO.AutoScroll = True
        Me.panCPO.BackColor = System.Drawing.Color.Transparent
        Me.panCPO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panCPO.Controls.Add(Me.btnDeleteAll)
        Me.panCPO.Controls.Add(Me.grpTransCPORecords)
        Me.panCPO.Controls.Add(Me.btnClose)
        Me.panCPO.Controls.Add(Me.btnReset)
        Me.panCPO.Controls.Add(Me.GroupBox3)
        Me.panCPO.Controls.Add(Me.grpTransCPO)
        Me.panCPO.Controls.Add(Me.btnSaveAll)
        Me.panCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panCPO.Location = New System.Drawing.Point(3, 3)
        Me.panCPO.Name = "panCPO"
        Me.panCPO.Size = New System.Drawing.Size(748, 486)
        Me.panCPO.TabIndex = 0
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnDeleteAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteAll.Image = Global.BSP.My.Resources.Resources.icon_delete
        Me.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteAll.Location = New System.Drawing.Point(540, 441)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(117, 25)
        Me.btnDeleteAll.TabIndex = 352
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        Me.btnDeleteAll.Visible = False
        '
        'grpTransCPORecords
        '
        Me.grpTransCPORecords.BackColor = System.Drawing.Color.Transparent
        Me.grpTransCPORecords.Controls.Add(Me.dgvTransCPODetails)
        Me.grpTransCPORecords.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTransCPORecords.Location = New System.Drawing.Point(5, 284)
        Me.grpTransCPORecords.Name = "grpTransCPORecords"
        Me.grpTransCPORecords.Size = New System.Drawing.Size(669, 148)
        Me.grpTransCPORecords.TabIndex = 181
        Me.grpTransCPORecords.TabStop = False
        Me.grpTransCPORecords.Text = "Transhipment CPO Records"
        '
        'dgvTransCPODetails
        '
        Me.dgvTransCPODetails.AllowUserToAddRows = False
        Me.dgvTransCPODetails.AllowUserToDeleteRows = False
        Me.dgvTransCPODetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvTransCPODetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTransCPODetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTransCPODetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTransCPODetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransCPODetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTransCPODetails.ColumnHeadersHeight = 30
        Me.dgvTransCPODetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclTransStorageNo, Me.dgclTransStorageID, Me.dgclTransStorageLocID, Me.dgclTranshipLoad, Me.TransDescription, Me.dgclTranshipQuantity, Me.dgclTransMonthDate, Me.dgclProdTranshipID1, Me.dgclProductionIDTrans, Me.dgclCPODateTrans, Me.dgclTransRemarks})
        Me.dgvTransCPODetails.ContextMenuStrip = Me.cmsTranshipCPO
        Me.dgvTransCPODetails.EnableHeadersVisualStyles = False
        Me.dgvTransCPODetails.GridColor = System.Drawing.Color.Gray
        Me.dgvTransCPODetails.Location = New System.Drawing.Point(3, 20)
        Me.dgvTransCPODetails.MultiSelect = False
        Me.dgvTransCPODetails.Name = "dgvTransCPODetails"
        Me.dgvTransCPODetails.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransCPODetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTransCPODetails.RowHeadersVisible = False
        Me.dgvTransCPODetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransCPODetails.Size = New System.Drawing.Size(660, 117)
        Me.dgvTransCPODetails.TabIndex = 348
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
        Me.dgclTranshipLoad.HeaderText = "Transhipment"
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
        Me.dgclTransMonthDate.Width = 135
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
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(436, 441)
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
        Me.btnReset.Location = New System.Drawing.Point(318, 441)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(112, 25)
        Me.btnReset.TabIndex = 350
        Me.btnReset.Text = "Reset All"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.dtpCPODate)
        Me.GroupBox3.Controls.Add(Me.lblTransDate)
        Me.GroupBox3.Location = New System.Drawing.Point(2, -6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(672, 44)
        Me.GroupBox3.TabIndex = 178
        Me.GroupBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(129, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 364
        Me.Label1.Text = ":"
        '
        'dtpCPODate
        '
        Me.dtpCPODate.CustomFormat = "dd/MM/yyyy"
        Me.dtpCPODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPODate.Location = New System.Drawing.Point(146, 12)
        Me.dtpCPODate.Name = "dtpCPODate"
        Me.dtpCPODate.Size = New System.Drawing.Size(155, 21)
        Me.dtpCPODate.TabIndex = 340
        '
        'lblTransDate
        '
        Me.lblTransDate.AutoSize = True
        Me.lblTransDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransDate.ForeColor = System.Drawing.Color.Red
        Me.lblTransDate.Location = New System.Drawing.Point(10, 16)
        Me.lblTransDate.Name = "lblTransDate"
        Me.lblTransDate.Size = New System.Drawing.Size(116, 13)
        Me.lblTransDate.TabIndex = 170
        Me.lblTransDate.Text = "Transhipment Date"
        '
        'grpTransCPO
        '
        Me.grpTransCPO.BackColor = System.Drawing.Color.Transparent
        Me.grpTransCPO.Controls.Add(Me.Label5)
        Me.grpTransCPO.Controls.Add(Me.Label6)
        Me.grpTransCPO.Controls.Add(Me.cmbTermofSales)
        Me.grpTransCPO.Controls.Add(Me.Label2)
        Me.grpTransCPO.Controls.Add(Me.txtLossInTransit)
        Me.grpTransCPO.Controls.Add(Me.Label4)
        Me.grpTransCPO.Controls.Add(Me.Label3)
        Me.grpTransCPO.Controls.Add(Me.txtTransRemarks)
        Me.grpTransCPO.Controls.Add(Me.lblRemarks)
        Me.grpTransCPO.Controls.Add(Me.btnResetTrans)
        Me.grpTransCPO.Controls.Add(Me.btnAddTrans)
        Me.grpTransCPO.Controls.Add(Me.Label20)
        Me.grpTransCPO.Controls.Add(Me.Label23)
        Me.grpTransCPO.Controls.Add(Me.txtTransMonthToDate)
        Me.grpTransCPO.Controls.Add(Me.lblTransMonthDate)
        Me.grpTransCPO.Controls.Add(Me.txtTransQty)
        Me.grpTransCPO.Controls.Add(Me.lblTransQty)
        Me.grpTransCPO.Controls.Add(Me.Label18)
        Me.grpTransCPO.Controls.Add(Me.lblToLoading)
        Me.grpTransCPO.Controls.Add(Me.cmbLoadTrans)
        Me.grpTransCPO.Controls.Add(Me.Label16)
        Me.grpTransCPO.Controls.Add(Me.lblTransStorage)
        Me.grpTransCPO.Controls.Add(Me.cmbTransTank)
        Me.grpTransCPO.Controls.Add(Me.lblT3Name)
        Me.grpTransCPO.Controls.Add(Me.lblT1Name)
        Me.grpTransCPO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTransCPO.Location = New System.Drawing.Point(3, 44)
        Me.grpTransCPO.Name = "grpTransCPO"
        Me.grpTransCPO.Size = New System.Drawing.Size(671, 234)
        Me.grpTransCPO.TabIndex = 340
        Me.grpTransCPO.TabStop = False
        Me.grpTransCPO.Text = "Transhipment CPO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(124, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 353
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(9, 205)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 352
        Me.Label6.Text = "Term of Sales "
        '
        'cmbTermofSales
        '
        Me.cmbTermofSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTermofSales.FormattingEnabled = True
        Me.cmbTermofSales.Location = New System.Drawing.Point(145, 202)
        Me.cmbTermofSales.Name = "cmbTermofSales"
        Me.cmbTermofSales.Size = New System.Drawing.Size(304, 21)
        Me.cmbTermofSales.TabIndex = 354
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(124, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 350
        Me.Label2.Text = ":"
        '
        'txtLossInTransit
        '
        Me.txtLossInTransit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLossInTransit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLossInTransit.Location = New System.Drawing.Point(145, 175)
        Me.txtLossInTransit.MaxLength = 18
        Me.txtLossInTransit.Name = "txtLossInTransit"
        Me.txtLossInTransit.Size = New System.Drawing.Size(67, 21)
        Me.txtLossInTransit.TabIndex = 351
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(9, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 349
        Me.Label4.Text = "Loss in Transit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(124, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 348
        Me.Label3.Text = ":"
        '
        'txtTransRemarks
        '
        Me.txtTransRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransRemarks.Location = New System.Drawing.Point(145, 107)
        Me.txtTransRemarks.MaxLength = 300
        Me.txtTransRemarks.Multiline = True
        Me.txtTransRemarks.Name = "txtTransRemarks"
        Me.txtTransRemarks.Size = New System.Drawing.Size(188, 62)
        Me.txtTransRemarks.TabIndex = 345
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(9, 110)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(58, 13)
        Me.lblRemarks.TabIndex = 347
        Me.lblRemarks.Text = "Remarks"
        '
        'btnResetTrans
        '
        Me.btnResetTrans.BackgroundImage = CType(resources.GetObject("btnResetTrans.BackgroundImage"), System.Drawing.Image)
        Me.btnResetTrans.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetTrans.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetTrans.Image = CType(resources.GetObject("btnResetTrans.Image"), System.Drawing.Image)
        Me.btnResetTrans.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnResetTrans.Location = New System.Drawing.Point(489, 130)
        Me.btnResetTrans.Name = "btnResetTrans"
        Me.btnResetTrans.Size = New System.Drawing.Size(81, 22)
        Me.btnResetTrans.TabIndex = 347
        Me.btnResetTrans.Text = "Reset"
        Me.btnResetTrans.UseVisualStyleBackColor = True
        '
        'btnAddTrans
        '
        Me.btnAddTrans.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAddTrans.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddTrans.Image = CType(resources.GetObject("btnAddTrans.Image"), System.Drawing.Image)
        Me.btnAddTrans.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAddTrans.Location = New System.Drawing.Point(394, 130)
        Me.btnAddTrans.Name = "btnAddTrans"
        Me.btnAddTrans.Size = New System.Drawing.Size(78, 22)
        Me.btnAddTrans.TabIndex = 346
        Me.btnAddTrans.Text = "Add"
        Me.btnAddTrans.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(124, 83)
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
        Me.Label23.Location = New System.Drawing.Point(353, 84)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 179
        Me.Label23.Text = ":"
        '
        'txtTransMonthToDate
        '
        Me.txtTransMonthToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransMonthToDate.Enabled = False
        Me.txtTransMonthToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransMonthToDate.Location = New System.Drawing.Point(382, 81)
        Me.txtTransMonthToDate.MaxLength = 18
        Me.txtTransMonthToDate.Name = "txtTransMonthToDate"
        Me.txtTransMonthToDate.Size = New System.Drawing.Size(67, 21)
        Me.txtTransMonthToDate.TabIndex = 344
        '
        'lblTransMonthDate
        '
        Me.lblTransMonthDate.AutoSize = True
        Me.lblTransMonthDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransMonthDate.ForeColor = System.Drawing.Color.Red
        Me.lblTransMonthDate.Location = New System.Drawing.Point(236, 84)
        Me.lblTransMonthDate.Name = "lblTransMonthDate"
        Me.lblTransMonthDate.Size = New System.Drawing.Size(113, 13)
        Me.lblTransMonthDate.TabIndex = 178
        Me.lblTransMonthDate.Text = "Month To date(Kg)"
        '
        'txtTransQty
        '
        Me.txtTransQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransQty.Location = New System.Drawing.Point(145, 80)
        Me.txtTransQty.MaxLength = 18
        Me.txtTransQty.Name = "txtTransQty"
        Me.txtTransQty.Size = New System.Drawing.Size(67, 21)
        Me.txtTransQty.TabIndex = 343
        '
        'lblTransQty
        '
        Me.lblTransQty.AutoSize = True
        Me.lblTransQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransQty.ForeColor = System.Drawing.Color.Red
        Me.lblTransQty.Location = New System.Drawing.Point(9, 83)
        Me.lblTransQty.Name = "lblTransQty"
        Me.lblTransQty.Size = New System.Drawing.Size(84, 13)
        Me.lblTransQty.TabIndex = 177
        Me.lblTransQty.Text = "Quantity (Kg)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(124, 54)
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
        Me.lblToLoading.Size = New System.Drawing.Size(85, 13)
        Me.lblToLoading.TabIndex = 175
        Me.lblToLoading.Text = "Transhipment"
        '
        'cmbLoadTrans
        '
        Me.cmbLoadTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLoadTrans.FormattingEnabled = True
        Me.cmbLoadTrans.Location = New System.Drawing.Point(145, 51)
        Me.cmbLoadTrans.Name = "cmbLoadTrans"
        Me.cmbLoadTrans.Size = New System.Drawing.Size(304, 21)
        Me.cmbLoadTrans.TabIndex = 342
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(124, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 13)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = ":"
        '
        'lblTransStorage
        '
        Me.lblTransStorage.AutoSize = True
        Me.lblTransStorage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransStorage.ForeColor = System.Drawing.Color.Red
        Me.lblTransStorage.Location = New System.Drawing.Point(9, 24)
        Me.lblTransStorage.Name = "lblTransStorage"
        Me.lblTransStorage.Size = New System.Drawing.Size(51, 13)
        Me.lblTransStorage.TabIndex = 172
        Me.lblTransStorage.Text = "Loading"
        '
        'cmbTransTank
        '
        Me.cmbTransTank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransTank.FormattingEnabled = True
        Me.cmbTransTank.Location = New System.Drawing.Point(145, 21)
        Me.cmbTransTank.Name = "cmbTransTank"
        Me.cmbTransTank.Size = New System.Drawing.Size(304, 21)
        Me.cmbTransTank.TabIndex = 341
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
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(180, 441)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(132, 25)
        Me.btnSaveAll.TabIndex = 349
        Me.btnSaveAll.Text = "Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'dgvTransCPOView
        '
        Me.dgvTransCPOView.AllowUserToAddRows = False
        Me.dgvTransCPOView.AllowUserToDeleteRows = False
        Me.dgvTransCPOView.AllowUserToResizeRows = False
        Me.dgvTransCPOView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTransCPOView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTransCPOView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransCPOView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTransCPOView.ColumnHeadersHeight = 30
        Me.dgvTransCPOView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvCPODate})
        Me.dgvTransCPOView.ContextMenuStrip = Me.cmsCPO
        Me.dgvTransCPOView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTransCPOView.EnableHeadersVisualStyles = False
        Me.dgvTransCPOView.GridColor = System.Drawing.Color.Gray
        Me.dgvTransCPOView.Location = New System.Drawing.Point(3, 108)
        Me.dgvTransCPOView.MultiSelect = False
        Me.dgvTransCPOView.Name = "dgvTransCPOView"
        Me.dgvTransCPOView.ReadOnly = True
        Me.dgvTransCPOView.RowHeadersVisible = False
        Me.dgvTransCPOView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransCPOView.Size = New System.Drawing.Size(748, 381)
        Me.dgvTransCPOView.TabIndex = 505
        Me.dgvTransCPOView.TabStop = False
        '
        'gvCPODate
        '
        Me.gvCPODate.DataPropertyName = "ProductionDate"
        DataGridViewCellStyle5.Format = "dd/MM/yyyy"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.gvCPODate.DefaultCellStyle = DataGridViewCellStyle5
        Me.gvCPODate.HeaderText = "Date"
        Me.gvCPODate.Name = "gvCPODate"
        Me.gvCPODate.ReadOnly = True
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
        'tpCPOView
        '
        Me.tpCPOView.AutoScroll = True
        Me.tpCPOView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tpCPOView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpCPOView.Controls.Add(Me.dgvTransCPOView)
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
        Me.tpCPOView.Size = New System.Drawing.Size(754, 492)
        Me.tpCPOView.TabIndex = 1
        Me.tpCPOView.Text = "View"
        Me.tpCPOView.UseVisualStyleBackColor = True
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
        Me.PnlSearch.CaptionText = "Search Transhipment CPO "
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.Panel2)
        Me.PnlSearch.Controls.Add(Me.lblSearchBy)
        Me.PnlSearch.Controls.Add(Me.Label46)
        Me.PnlSearch.Controls.Add(Me.dtpCPOViewDate)
        Me.PnlSearch.Controls.Add(Me.chkCPODate)
        Me.PnlSearch.Controls.Add(Me.btnViewSearch)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(748, 105)
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
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
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
        'dtpCPOViewDate
        '
        Me.dtpCPOViewDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpCPOViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCPOViewDate.Location = New System.Drawing.Point(210, 75)
        Me.dtpCPOViewDate.Name = "dtpCPOViewDate"
        Me.dtpCPOViewDate.Size = New System.Drawing.Size(135, 21)
        Me.dtpCPOViewDate.TabIndex = 502
        Me.dtpCPOViewDate.Value = New Date(2010, 2, 15, 11, 44, 0, 0)
        '
        'chkCPODate
        '
        Me.chkCPODate.AutoSize = True
        Me.chkCPODate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkCPODate.Location = New System.Drawing.Point(133, 78)
        Me.chkCPODate.Name = "chkCPODate"
        Me.chkCPODate.Size = New System.Drawing.Size(57, 17)
        Me.chkCPODate.TabIndex = 501
        Me.chkCPODate.TabStop = False
        Me.chkCPODate.Text = " Date"
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
        Me.btnViewSearch.Location = New System.Drawing.Point(544, 71)
        Me.btnViewSearch.Name = "btnViewSearch"
        Me.btnViewSearch.Size = New System.Drawing.Size(116, 29)
        Me.btnViewSearch.TabIndex = 503
        Me.btnViewSearch.Text = "Search"
        Me.btnViewSearch.UseVisualStyleBackColor = True
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
        'LoadCPOEdit
        '
        Me.LoadCPOEdit.Image = CType(resources.GetObject("LoadCPOEdit.Image"), System.Drawing.Image)
        Me.LoadCPOEdit.Name = "LoadCPOEdit"
        Me.LoadCPOEdit.Size = New System.Drawing.Size(107, 22)
        Me.LoadCPOEdit.Text = "Edit"
        '
        'CMSLoadCPO
        '
        Me.CMSLoadCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadCPOEdit, Me.LoadCPODelete})
        Me.CMSLoadCPO.Name = "cmsIPR"
        Me.CMSLoadCPO.Size = New System.Drawing.Size(108, 48)
        '
        'LoadCPODelete
        '
        Me.LoadCPODelete.Image = CType(resources.GetObject("LoadCPODelete.Image"), System.Drawing.Image)
        Me.LoadCPODelete.Name = "LoadCPODelete"
        Me.LoadCPODelete.Size = New System.Drawing.Size(107, 22)
        Me.LoadCPODelete.Text = "Delete"
        '
        'StockCPODelete
        '
        Me.StockCPODelete.Image = CType(resources.GetObject("StockCPODelete.Image"), System.Drawing.Image)
        Me.StockCPODelete.Name = "StockCPODelete"
        Me.StockCPODelete.Size = New System.Drawing.Size(107, 22)
        Me.StockCPODelete.Text = "Delete"
        '
        'StockCPOEdit
        '
        Me.StockCPOEdit.Image = CType(resources.GetObject("StockCPOEdit.Image"), System.Drawing.Image)
        Me.StockCPOEdit.Name = "StockCPOEdit"
        Me.StockCPOEdit.Size = New System.Drawing.Size(107, 22)
        Me.StockCPOEdit.Text = "Edit"
        '
        'tcTransCPO
        '
        Me.tcTransCPO.Controls.Add(Me.tpCPOSave)
        Me.tcTransCPO.Controls.Add(Me.tpCPOView)
        Me.tcTransCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcTransCPO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcTransCPO.Location = New System.Drawing.Point(0, 0)
        Me.tcTransCPO.Name = "tcTransCPO"
        Me.tcTransCPO.SelectedIndex = 0
        Me.tcTransCPO.Size = New System.Drawing.Size(762, 518)
        Me.tcTransCPO.TabIndex = 6
        Me.tcTransCPO.TabStop = False
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
        Me.tpCPOSave.Size = New System.Drawing.Size(754, 492)
        Me.tpCPOSave.TabIndex = 0
        Me.tpCPOSave.Text = "Transhipment CPO "
        Me.tpCPOSave.UseVisualStyleBackColor = True
        '
        'cmsStockCPO
        '
        Me.cmsStockCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StockCPOEdit, Me.StockCPODelete})
        Me.cmsStockCPO.Name = "cmsIPR"
        Me.cmsStockCPO.Size = New System.Drawing.Size(108, 48)
        '
        'TranshipmentCPOFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(762, 518)
        Me.Controls.Add(Me.tcTransCPO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "TranshipmentCPOFrm"
        Me.Text = "TranshipmentCPOFrm"
        Me.panCPO.ResumeLayout(False)
        Me.grpTransCPORecords.ResumeLayout(False)
        CType(Me.dgvTransCPODetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsTranshipCPO.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grpTransCPO.ResumeLayout(False)
        Me.grpTransCPO.PerformLayout()
        CType(Me.dgvTransCPOView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsCPO.ResumeLayout(False)
        Me.tpCPOView.ResumeLayout(False)
        Me.tpCPOView.PerformLayout()
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSLoadCPO.ResumeLayout(False)
        Me.tcTransCPO.ResumeLayout(False)
        Me.tpCPOSave.ResumeLayout(False)
        Me.cmsStockCPO.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panCPO As System.Windows.Forms.Panel
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents grpTransCPORecords As System.Windows.Forms.GroupBox
    Friend WithEvents dgvTransCPODetails As System.Windows.Forms.DataGridView
    Friend WithEvents cmsTranshipCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TranshipEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TranshipDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpCPODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTransDate As System.Windows.Forms.Label
    Friend WithEvents grpTransCPO As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTransRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents btnResetTrans As System.Windows.Forms.Button
    Friend WithEvents btnAddTrans As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtTransMonthToDate As System.Windows.Forms.TextBox
    Friend WithEvents lblTransMonthDate As System.Windows.Forms.Label
    Friend WithEvents txtTransQty As System.Windows.Forms.TextBox
    Friend WithEvents lblTransQty As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblToLoading As System.Windows.Forms.Label
    Friend WithEvents cmbLoadTrans As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblTransStorage As System.Windows.Forms.Label
    Friend WithEvents cmbTransTank As System.Windows.Forms.ComboBox
    Friend WithEvents lblT3Name As System.Windows.Forms.Label
    Friend WithEvents lblT1Name As System.Windows.Forms.Label
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents dgvTransCPOView As System.Windows.Forms.DataGridView
    Friend WithEvents cmsCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tpCPOView As System.Windows.Forms.TabPage
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents dtpCPOViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents chkCPODate As System.Windows.Forms.CheckBox
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents lblViewStatus As System.Windows.Forms.Label
    Friend WithEvents dtpAdjustmentViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblAdjSearchNo As System.Windows.Forms.Label
    Friend WithEvents LoadCPOEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSLoadCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LoadCPODelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockCPODelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockCPOEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tcTransCPO As System.Windows.Forms.TabControl
    Friend WithEvents tpCPOSave As System.Windows.Forms.TabPage
    Friend WithEvents cmsStockCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents gvCPODate As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTermofSales As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLossInTransit As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

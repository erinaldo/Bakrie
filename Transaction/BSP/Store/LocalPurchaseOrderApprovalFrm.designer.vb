<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocalPurchaseOrderApprovalFrm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LocalPurchaseOrderApprovalFrm))
        Me.dgvLPOApproval = New System.Windows.Forms.DataGridView()
        Me.dgclSTLPOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTLPODetID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclOrderQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclContractID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSupplierID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLPONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLPODate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclViewDetails = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgclValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSupplierNameCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclContractNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPendingQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclModifiedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTCategoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTCategoryDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcUOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcMRCNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.btnViewReport = New System.Windows.Forms.Button()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.lblNoRecordFound = New System.Windows.Forms.Label()
        Me.lblSearchBy = New System.Windows.Forms.Label()
        Me.txtLPONoSearch = New System.Windows.Forms.TextBox()
        Me.pnlLPOApproval = New Stepi.UI.ExtendedPanel()
        Me.chkLPOViewDate = New System.Windows.Forms.CheckBox()
        Me.dtpLPOViewDate = New System.Windows.Forms.DateTimePicker()
        Me.lblLPONoSerach = New System.Windows.Forms.Label()
        CType(Me.dgvLPOApproval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGrid.SuspendLayout()
        Me.pnlLPOApproval.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvLPOApproval
        '
        Me.dgvLPOApproval.AllowUserToAddRows = False
        Me.dgvLPOApproval.AllowUserToDeleteRows = False
        Me.dgvLPOApproval.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvLPOApproval.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvLPOApproval.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLPOApproval.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLPOApproval.ColumnHeadersHeight = 30
        Me.dgvLPOApproval.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclSTLPOID, Me.dgclRejectedReason, Me.dgclSTLPODetID, Me.dgclOrderQty, Me.dgclUnitPrice, Me.dgclContractID, Me.dgclSupplierID, Me.dgclStockId, Me.dgclLPONo, Me.dgclLPODate, Me.dgclStatus, Me.dgclStockCode, Me.dgclViewDetails, Me.dgclValue, Me.dgclSupplierName, Me.dgclSupplierNameCode, Me.dgclContractNo, Me.dgclPendingQty, Me.dgclRemarks, Me.dgclID, Me.dgclModifiedOn, Me.dgclT0, Me.dgclT1, Me.dgclT2, Me.dgclT3, Me.dgclT4, Me.dgclSTCategoryID, Me.dgclSTCategoryCode, Me.dgclSTCategoryDescp, Me.dgcUOM, Me.dgcMRCNO})
        Me.dgvLPOApproval.EnableHeadersVisualStyles = False
        Me.dgvLPOApproval.GridColor = System.Drawing.Color.Gray
        Me.dgvLPOApproval.Location = New System.Drawing.Point(6, 12)
        Me.dgvLPOApproval.MultiSelect = False
        Me.dgvLPOApproval.Name = "dgvLPOApproval"
        Me.dgvLPOApproval.ReadOnly = True
        Me.dgvLPOApproval.RowHeadersVisible = False
        Me.dgvLPOApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLPOApproval.Size = New System.Drawing.Size(589, 254)
        Me.dgvLPOApproval.TabIndex = 6
        Me.dgvLPOApproval.TabStop = False
        '
        'dgclSTLPOID
        '
        Me.dgclSTLPOID.DataPropertyName = "STLPOID"
        Me.dgclSTLPOID.HeaderText = "STPOID"
        Me.dgclSTLPOID.Name = "dgclSTLPOID"
        Me.dgclSTLPOID.ReadOnly = True
        Me.dgclSTLPOID.Visible = False
        '
        'dgclRejectedReason
        '
        Me.dgclRejectedReason.HeaderText = "RejectedReason"
        Me.dgclRejectedReason.Name = "dgclRejectedReason"
        Me.dgclRejectedReason.ReadOnly = True
        Me.dgclRejectedReason.Visible = False
        '
        'dgclSTLPODetID
        '
        Me.dgclSTLPODetID.DataPropertyName = "STLPODetID"
        Me.dgclSTLPODetID.HeaderText = "STLPODetID"
        Me.dgclSTLPODetID.Name = "dgclSTLPODetID"
        Me.dgclSTLPODetID.ReadOnly = True
        Me.dgclSTLPODetID.Visible = False
        '
        'dgclOrderQty
        '
        Me.dgclOrderQty.DataPropertyName = "OrderQty"
        Me.dgclOrderQty.HeaderText = "OrderQty"
        Me.dgclOrderQty.Name = "dgclOrderQty"
        Me.dgclOrderQty.ReadOnly = True
        Me.dgclOrderQty.Visible = False
        '
        'dgclUnitPrice
        '
        Me.dgclUnitPrice.DataPropertyName = "UnitPrice"
        Me.dgclUnitPrice.HeaderText = "UnitPrice"
        Me.dgclUnitPrice.Name = "dgclUnitPrice"
        Me.dgclUnitPrice.ReadOnly = True
        Me.dgclUnitPrice.Visible = False
        '
        'dgclContractID
        '
        Me.dgclContractID.DataPropertyName = "ContractID"
        Me.dgclContractID.HeaderText = "ContractID"
        Me.dgclContractID.Name = "dgclContractID"
        Me.dgclContractID.ReadOnly = True
        Me.dgclContractID.Visible = False
        '
        'dgclSupplierID
        '
        Me.dgclSupplierID.DataPropertyName = "APSupplierID"
        Me.dgclSupplierID.HeaderText = "SupplierID"
        Me.dgclSupplierID.Name = "dgclSupplierID"
        Me.dgclSupplierID.ReadOnly = True
        Me.dgclSupplierID.Visible = False
        '
        'dgclStockId
        '
        Me.dgclStockId.DataPropertyName = "StockID"
        Me.dgclStockId.HeaderText = "StockID"
        Me.dgclStockId.Name = "dgclStockId"
        Me.dgclStockId.ReadOnly = True
        Me.dgclStockId.Visible = False
        '
        'dgclLPONo
        '
        Me.dgclLPONo.DataPropertyName = "LPONO"
        Me.dgclLPONo.HeaderText = "PO NO"
        Me.dgclLPONo.Name = "dgclLPONo"
        Me.dgclLPONo.ReadOnly = True
        Me.dgclLPONo.Width = 150
        '
        'dgclLPODate
        '
        Me.dgclLPODate.DataPropertyName = "LPODate"
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgclLPODate.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgclLPODate.HeaderText = "PO Date"
        Me.dgclLPODate.Name = "dgclLPODate"
        Me.dgclLPODate.ReadOnly = True
        Me.dgclLPODate.Width = 150
        '
        'dgclStatus
        '
        Me.dgclStatus.DataPropertyName = "MainStatus"
        Me.dgclStatus.HeaderText = "Status"
        Me.dgclStatus.Name = "dgclStatus"
        Me.dgclStatus.ReadOnly = True
        '
        'dgclStockCode
        '
        Me.dgclStockCode.DataPropertyName = "StockCode"
        Me.dgclStockCode.HeaderText = "StockCode"
        Me.dgclStockCode.Name = "dgclStockCode"
        Me.dgclStockCode.ReadOnly = True
        Me.dgclStockCode.Visible = False
        '
        'dgclViewDetails
        '
        Me.dgclViewDetails.DataPropertyName = "ViewDetails"
        Me.dgclViewDetails.HeaderText = "View Details"
        Me.dgclViewDetails.Name = "dgclViewDetails"
        Me.dgclViewDetails.ReadOnly = True
        Me.dgclViewDetails.Text = "View Details"
        Me.dgclViewDetails.UseColumnTextForButtonValue = True
        '
        'dgclValue
        '
        Me.dgclValue.DataPropertyName = "Value"
        Me.dgclValue.HeaderText = "Value"
        Me.dgclValue.Name = "dgclValue"
        Me.dgclValue.ReadOnly = True
        Me.dgclValue.Visible = False
        '
        'dgclSupplierName
        '
        Me.dgclSupplierName.DataPropertyName = "SupplierName"
        Me.dgclSupplierName.HeaderText = "SupplierName"
        Me.dgclSupplierName.Name = "dgclSupplierName"
        Me.dgclSupplierName.ReadOnly = True
        Me.dgclSupplierName.Visible = False
        '
        'dgclSupplierNameCode
        '
        Me.dgclSupplierNameCode.DataPropertyName = "SupplierNameCode"
        Me.dgclSupplierNameCode.HeaderText = "SupplierNameCode"
        Me.dgclSupplierNameCode.Name = "dgclSupplierNameCode"
        Me.dgclSupplierNameCode.ReadOnly = True
        Me.dgclSupplierNameCode.Visible = False
        '
        'dgclContractNo
        '
        Me.dgclContractNo.DataPropertyName = "ContractNo"
        Me.dgclContractNo.HeaderText = "ContractNo"
        Me.dgclContractNo.Name = "dgclContractNo"
        Me.dgclContractNo.ReadOnly = True
        Me.dgclContractNo.Visible = False
        '
        'dgclPendingQty
        '
        Me.dgclPendingQty.DataPropertyName = "PendingQty"
        Me.dgclPendingQty.HeaderText = "PendingQty"
        Me.dgclPendingQty.Name = "dgclPendingQty"
        Me.dgclPendingQty.ReadOnly = True
        Me.dgclPendingQty.Visible = False
        '
        'dgclRemarks
        '
        Me.dgclRemarks.DataPropertyName = "Remarks"
        Me.dgclRemarks.HeaderText = "Remarks"
        Me.dgclRemarks.Name = "dgclRemarks"
        Me.dgclRemarks.ReadOnly = True
        Me.dgclRemarks.Visible = False
        '
        'dgclID
        '
        Me.dgclID.DataPropertyName = "ID"
        Me.dgclID.HeaderText = "ID"
        Me.dgclID.Name = "dgclID"
        Me.dgclID.ReadOnly = True
        Me.dgclID.Visible = False
        '
        'dgclModifiedOn
        '
        Me.dgclModifiedOn.DataPropertyName = "ModifiedOn"
        Me.dgclModifiedOn.HeaderText = "ModifiedOn"
        Me.dgclModifiedOn.Name = "dgclModifiedOn"
        Me.dgclModifiedOn.ReadOnly = True
        Me.dgclModifiedOn.Visible = False
        '
        'dgclT0
        '
        Me.dgclT0.DataPropertyName = "T0Value"
        Me.dgclT0.HeaderText = "T0"
        Me.dgclT0.Name = "dgclT0"
        Me.dgclT0.ReadOnly = True
        Me.dgclT0.Visible = False
        '
        'dgclT1
        '
        Me.dgclT1.DataPropertyName = "T1Value"
        Me.dgclT1.HeaderText = "T1"
        Me.dgclT1.Name = "dgclT1"
        Me.dgclT1.ReadOnly = True
        Me.dgclT1.Visible = False
        '
        'dgclT2
        '
        Me.dgclT2.DataPropertyName = "T2Value"
        Me.dgclT2.HeaderText = "T2"
        Me.dgclT2.Name = "dgclT2"
        Me.dgclT2.ReadOnly = True
        Me.dgclT2.Visible = False
        '
        'dgclT3
        '
        Me.dgclT3.DataPropertyName = "T3Value"
        Me.dgclT3.HeaderText = "T3"
        Me.dgclT3.Name = "dgclT3"
        Me.dgclT3.ReadOnly = True
        Me.dgclT3.Visible = False
        '
        'dgclT4
        '
        Me.dgclT4.DataPropertyName = "T4Value"
        Me.dgclT4.HeaderText = "T4"
        Me.dgclT4.Name = "dgclT4"
        Me.dgclT4.ReadOnly = True
        Me.dgclT4.Visible = False
        '
        'dgclSTCategoryID
        '
        Me.dgclSTCategoryID.DataPropertyName = "STCategoryID"
        Me.dgclSTCategoryID.HeaderText = "STCategoryID"
        Me.dgclSTCategoryID.Name = "dgclSTCategoryID"
        Me.dgclSTCategoryID.ReadOnly = True
        Me.dgclSTCategoryID.Visible = False
        '
        'dgclSTCategoryCode
        '
        Me.dgclSTCategoryCode.DataPropertyName = "STCategoryCode"
        Me.dgclSTCategoryCode.HeaderText = "ST CategoryCode"
        Me.dgclSTCategoryCode.Name = "dgclSTCategoryCode"
        Me.dgclSTCategoryCode.ReadOnly = True
        Me.dgclSTCategoryCode.Visible = False
        '
        'dgclSTCategoryDescp
        '
        Me.dgclSTCategoryDescp.DataPropertyName = "STCategoryDescp"
        Me.dgclSTCategoryDescp.HeaderText = "ST Category Descp"
        Me.dgclSTCategoryDescp.Name = "dgclSTCategoryDescp"
        Me.dgclSTCategoryDescp.ReadOnly = True
        Me.dgclSTCategoryDescp.Visible = False
        '
        'dgcUOM
        '
        Me.dgcUOM.DataPropertyName = "UOM"
        Me.dgcUOM.HeaderText = "UOM"
        Me.dgcUOM.Name = "dgcUOM"
        Me.dgcUOM.ReadOnly = True
        Me.dgcUOM.Visible = False
        '
        'dgcMRCNO
        '
        Me.dgcMRCNO.DataPropertyName = "MRCNO"
        Me.dgcMRCNO.HeaderText = "MRCNO"
        Me.dgcMRCNO.Name = "dgcMRCNO"
        Me.dgcMRCNO.ReadOnly = True
        Me.dgcMRCNO.Visible = False
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
        Me.btnSearch.Location = New System.Drawing.Point(415, 58)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(116, 29)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(81, 39)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(12, 14)
        Me.Label30.TabIndex = 79
        Me.Label30.Text = ":"
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
        Me.btnViewReport.Location = New System.Drawing.Point(540, 58)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(116, 29)
        Me.btnViewReport.TabIndex = 5
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        Me.btnViewReport.Visible = False
        '
        'pnlGrid
        '
        Me.pnlGrid.BackColor = System.Drawing.Color.Transparent
        Me.pnlGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlGrid.Controls.Add(Me.lblNoRecordFound)
        Me.pnlGrid.Controls.Add(Me.dgvLPOApproval)
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGrid.Location = New System.Drawing.Point(0, 99)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(677, 311)
        Me.pnlGrid.TabIndex = 5
        '
        'lblNoRecordFound
        '
        Me.lblNoRecordFound.AutoSize = True
        Me.lblNoRecordFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecordFound.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecordFound.Location = New System.Drawing.Point(250, 121)
        Me.lblNoRecordFound.Name = "lblNoRecordFound"
        Me.lblNoRecordFound.Size = New System.Drawing.Size(115, 13)
        Me.lblNoRecordFound.TabIndex = 7
        Me.lblNoRecordFound.Text = "No Record Found !"
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearchBy.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchBy.Location = New System.Drawing.Point(3, 39)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchBy.TabIndex = 78
        Me.lblSearchBy.Text = "Search By"
        '
        'txtLPONoSearch
        '
        Me.txtLPONoSearch.Location = New System.Drawing.Point(269, 62)
        Me.txtLPONoSearch.Name = "txtLPONoSearch"
        Me.txtLPONoSearch.Size = New System.Drawing.Size(129, 20)
        Me.txtLPONoSearch.TabIndex = 3
        '
        'pnlLPOApproval
        '
        Me.pnlLPOApproval.BackColor = System.Drawing.Color.Transparent
        Me.pnlLPOApproval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlLPOApproval.BorderColor = System.Drawing.Color.Gray
        Me.pnlLPOApproval.CaptionColorOne = System.Drawing.Color.Transparent
        Me.pnlLPOApproval.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlLPOApproval.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlLPOApproval.CaptionSize = 30
        Me.pnlLPOApproval.CaptionText = "PO Approval"
        Me.pnlLPOApproval.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlLPOApproval.Controls.Add(Me.chkLPOViewDate)
        Me.pnlLPOApproval.Controls.Add(Me.dtpLPOViewDate)
        Me.pnlLPOApproval.Controls.Add(Me.lblSearchBy)
        Me.pnlLPOApproval.Controls.Add(Me.Label30)
        Me.pnlLPOApproval.Controls.Add(Me.btnSearch)
        Me.pnlLPOApproval.Controls.Add(Me.txtLPONoSearch)
        Me.pnlLPOApproval.Controls.Add(Me.btnViewReport)
        Me.pnlLPOApproval.Controls.Add(Me.lblLPONoSerach)
        Me.pnlLPOApproval.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlLPOApproval.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlLPOApproval.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlLPOApproval.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLPOApproval.Location = New System.Drawing.Point(0, 0)
        Me.pnlLPOApproval.Name = "pnlLPOApproval"
        Me.pnlLPOApproval.Size = New System.Drawing.Size(677, 99)
        Me.pnlLPOApproval.TabIndex = 4
        '
        'chkLPOViewDate
        '
        Me.chkLPOViewDate.AutoSize = True
        Me.chkLPOViewDate.Location = New System.Drawing.Point(127, 40)
        Me.chkLPOViewDate.Name = "chkLPOViewDate"
        Me.chkLPOViewDate.Size = New System.Drawing.Size(67, 17)
        Me.chkLPOViewDate.TabIndex = 1
        Me.chkLPOViewDate.Text = "PO Date"
        Me.chkLPOViewDate.UseVisualStyleBackColor = True
        '
        'dtpLPOViewDate
        '
        Me.dtpLPOViewDate.CalendarFont = New System.Drawing.Font("Verdana", 7.5!)
        Me.dtpLPOViewDate.CalendarTitleBackColor = System.Drawing.Color.Blue
        Me.dtpLPOViewDate.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.dtpLPOViewDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpLPOViewDate.Enabled = False
        Me.dtpLPOViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLPOViewDate.Location = New System.Drawing.Point(127, 62)
        Me.dtpLPOViewDate.Name = "dtpLPOViewDate"
        Me.dtpLPOViewDate.Size = New System.Drawing.Size(129, 20)
        Me.dtpLPOViewDate.TabIndex = 2
        '
        'lblLPONoSerach
        '
        Me.lblLPONoSerach.AutoSize = True
        Me.lblLPONoSerach.BackColor = System.Drawing.Color.Transparent
        Me.lblLPONoSerach.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblLPONoSerach.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLPONoSerach.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLPONoSerach.Location = New System.Drawing.Point(296, 40)
        Me.lblLPONoSerach.Name = "lblLPONoSerach"
        Me.lblLPONoSerach.Size = New System.Drawing.Size(48, 13)
        Me.lblLPONoSerach.TabIndex = 80
        Me.lblLPONoSerach.Text = "PO No"
        '
        'LocalPurchaseOrderApprovalFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(677, 410)
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.pnlLPOApproval)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "LocalPurchaseOrderApprovalFrm"
        Me.Text = "LocalPurchaseOrderApprovalFrm"
        CType(Me.dgvLPOApproval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGrid.PerformLayout()
        Me.pnlLPOApproval.ResumeLayout(False)
        Me.pnlLPOApproval.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvLPOApproval As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents txtLPONoSearch As System.Windows.Forms.TextBox
    Friend WithEvents pnlLPOApproval As Stepi.UI.ExtendedPanel
    Friend WithEvents lblLPONoSerach As System.Windows.Forms.Label
    Friend WithEvents chkLPOViewDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpLPOViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNoRecordFound As System.Windows.Forms.Label
    Friend WithEvents dgclSTLPOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTLPODetID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclOrderQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclContractID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLPONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLPODate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclViewDetails As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents dgclValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierNameCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclContractNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPendingQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclModifiedOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTCategoryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTCategoryDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcUOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcMRCNO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

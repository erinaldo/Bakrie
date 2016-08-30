<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreLPOReportFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StoreLPOReportFrm))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlSearchLPO = New Stepi.UI.ExtendedPanel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DataGridView3 = New System.Windows.Forms.DataGridView
        Me.lblSearch = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.chkLPOViewDate = New System.Windows.Forms.CheckBox
        Me.dtpLPOViewDate = New System.Windows.Forms.DateTimePicker
        Me.txtLPOViewNo = New System.Windows.Forms.TextBox
        Me.btnLPOViewSearch = New System.Windows.Forms.Button
        Me.lblLPONoView = New System.Windows.Forms.Label
        Me.dgvLPOView = New System.Windows.Forms.DataGridView
        Me.dgclLPONo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclUsageCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclUsageCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclUsageCOADescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclContractID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclLPODate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclStockCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclMainStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplierID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclT1Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclT2Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclT3Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclT4Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSTLPOID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplierAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclContractNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclTotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclT0Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewReport = New System.Windows.Forms.DataGridViewButtonColumn
        Me.dgclSTCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSTCategoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSTCategoryDescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblView = New System.Windows.Forms.Label
        Me.pnlSearchLPO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLPOView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSearchLPO
        '
        Me.pnlSearchLPO.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSearchLPO.BackColor = System.Drawing.Color.Transparent
        Me.pnlSearchLPO.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.pnlSearchLPO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSearchLPO.BorderColor = System.Drawing.Color.Gray
        Me.pnlSearchLPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearchLPO.CaptionColorOne = System.Drawing.Color.White
        Me.pnlSearchLPO.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSearchLPO.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearchLPO.CaptionSize = 40
        Me.pnlSearchLPO.CaptionText = "Search Purchase Order"
        Me.pnlSearchLPO.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSearchLPO.Controls.Add(Me.btnClose)
        Me.pnlSearchLPO.Controls.Add(Me.Panel1)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearch)
        Me.pnlSearchLPO.Controls.Add(Me.Label67)
        Me.pnlSearchLPO.Controls.Add(Me.chkLPOViewDate)
        Me.pnlSearchLPO.Controls.Add(Me.dtpLPOViewDate)
        Me.pnlSearchLPO.Controls.Add(Me.txtLPOViewNo)
        Me.pnlSearchLPO.Controls.Add(Me.btnLPOViewSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblLPONoView)
        Me.pnlSearchLPO.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSearchLPO.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSearchLPO.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSearchLPO.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearchLPO.Location = New System.Drawing.Point(0, 0)
        Me.pnlSearchLPO.Moveable = True
        Me.pnlSearchLPO.Name = "pnlSearchLPO"
        Me.pnlSearchLPO.Size = New System.Drawing.Size(842, 158)
        Me.pnlSearchLPO.TabIndex = 89
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(678, 94)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 25)
        Me.btnClose.TabIndex = 404
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView3)
        Me.Panel1.Location = New System.Drawing.Point(0, 157)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(841, 425)
        Me.Panel1.TabIndex = 33
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(3, 299)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.Size = New System.Drawing.Size(745, 276)
        Me.DataGridView3.TabIndex = 31
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearch.Location = New System.Drawing.Point(2, 45)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(72, 13)
        Me.lblSearch.TabIndex = 69
        Me.lblSearch.Text = "Search By"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label67.ForeColor = System.Drawing.Color.Black
        Me.Label67.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label67.Location = New System.Drawing.Point(76, 47)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(12, 14)
        Me.Label67.TabIndex = 70
        Me.Label67.Text = ":"
        '
        'chkLPOViewDate
        '
        Me.chkLPOViewDate.AutoSize = True
        Me.chkLPOViewDate.Location = New System.Drawing.Point(104, 77)
        Me.chkLPOViewDate.Name = "chkLPOViewDate"
        Me.chkLPOViewDate.Size = New System.Drawing.Size(73, 17)
        Me.chkLPOViewDate.TabIndex = 400
        Me.chkLPOViewDate.Text = "PO Date"
        Me.chkLPOViewDate.UseVisualStyleBackColor = True
        '
        'dtpLPOViewDate
        '
        Me.dtpLPOViewDate.CalendarFont = New System.Drawing.Font("Verdana", 7.5!)
        Me.dtpLPOViewDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtpLPOViewDate.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.dtpLPOViewDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpLPOViewDate.Enabled = False
        Me.dtpLPOViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLPOViewDate.Location = New System.Drawing.Point(104, 99)
        Me.dtpLPOViewDate.Name = "dtpLPOViewDate"
        Me.dtpLPOViewDate.Size = New System.Drawing.Size(129, 20)
        Me.dtpLPOViewDate.TabIndex = 401
        '
        'txtLPOViewNo
        '
        Me.txtLPOViewNo.Location = New System.Drawing.Point(239, 99)
        Me.txtLPOViewNo.Name = "txtLPOViewNo"
        Me.txtLPOViewNo.Size = New System.Drawing.Size(129, 20)
        Me.txtLPOViewNo.TabIndex = 402
        '
        'btnLPOViewSearch
        '
        Me.btnLPOViewSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnLPOViewSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnLPOViewSearch.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnLPOViewSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnLPOViewSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLPOViewSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnLPOViewSearch.Image = CType(resources.GetObject("btnLPOViewSearch.Image"), System.Drawing.Image)
        Me.btnLPOViewSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLPOViewSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLPOViewSearch.Location = New System.Drawing.Point(553, 95)
        Me.btnLPOViewSearch.Name = "btnLPOViewSearch"
        Me.btnLPOViewSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnLPOViewSearch.Size = New System.Drawing.Size(110, 25)
        Me.btnLPOViewSearch.TabIndex = 403
        Me.btnLPOViewSearch.Text = "Search"
        Me.btnLPOViewSearch.UseVisualStyleBackColor = True
        '
        'lblLPONoView
        '
        Me.lblLPONoView.AutoSize = True
        Me.lblLPONoView.BackColor = System.Drawing.Color.Transparent
        Me.lblLPONoView.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblLPONoView.ForeColor = System.Drawing.Color.Black
        Me.lblLPONoView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLPONoView.Location = New System.Drawing.Point(239, 77)
        Me.lblLPONoView.Name = "lblLPONoView"
        Me.lblLPONoView.Size = New System.Drawing.Size(48, 13)
        Me.lblLPONoView.TabIndex = 74
        Me.lblLPONoView.Text = "PO No"
        '
        'dgvLPOView
        '
        Me.dgvLPOView.AllowUserToAddRows = False
        Me.dgvLPOView.AllowUserToDeleteRows = False
        Me.dgvLPOView.AllowUserToResizeRows = False
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.dgvLPOView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvLPOView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvLPOView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvLPOView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLPOView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvLPOView.ColumnHeadersHeight = 30
        Me.dgvLPOView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclLPONo, Me.dgclUsageCOAID, Me.dgclUsageCOACode, Me.dgclUsageCOADescp, Me.dgclContractID, Me.dgclLPODate, Me.dgclUnitPrice, Me.dgclSupplierName, Me.dgclStockCode, Me.dgclQty, Me.dgclMainStatus, Me.dgclSupplierID, Me.dgclT1Value, Me.dgclT2Value, Me.dgclT3Value, Me.dgclT4Value, Me.dgclSTLPOID, Me.dgclSupplierAdd, Me.dgclContractNo, Me.dgclTotalPrice, Me.dgclT0Value, Me.dgclRemarks, Me.ViewReport, Me.dgclSTCategoryID, Me.dgclSTCategoryCode, Me.dgclSTCategoryDescp})
        Me.dgvLPOView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLPOView.EnableHeadersVisualStyles = False
        Me.dgvLPOView.GridColor = System.Drawing.Color.Gray
        Me.dgvLPOView.Location = New System.Drawing.Point(0, 158)
        Me.dgvLPOView.MultiSelect = False
        Me.dgvLPOView.Name = "dgvLPOView"
        Me.dgvLPOView.ReadOnly = True
        Me.dgvLPOView.RowHeadersVisible = False
        Me.dgvLPOView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLPOView.Size = New System.Drawing.Size(842, 350)
        Me.dgvLPOView.TabIndex = 407
        Me.dgvLPOView.TabStop = False
        '
        'dgclLPONo
        '
        Me.dgclLPONo.DataPropertyName = "LPONo"
        Me.dgclLPONo.HeaderText = "PO NO"
        Me.dgclLPONo.Name = "dgclLPONo"
        Me.dgclLPONo.ReadOnly = True
        '
        'dgclUsageCOAID
        '
        Me.dgclUsageCOAID.DataPropertyName = "UsageCOAID"
        Me.dgclUsageCOAID.HeaderText = "UsageCOAID"
        Me.dgclUsageCOAID.Name = "dgclUsageCOAID"
        Me.dgclUsageCOAID.ReadOnly = True
        Me.dgclUsageCOAID.Visible = False
        '
        'dgclUsageCOACode
        '
        Me.dgclUsageCOACode.DataPropertyName = "UsageCOACode"
        Me.dgclUsageCOACode.HeaderText = "Usage COA Code"
        Me.dgclUsageCOACode.Name = "dgclUsageCOACode"
        Me.dgclUsageCOACode.ReadOnly = True
        Me.dgclUsageCOACode.Visible = False
        '
        'dgclUsageCOADescp
        '
        Me.dgclUsageCOADescp.DataPropertyName = "UsageCOADescp"
        Me.dgclUsageCOADescp.HeaderText = "Usage COA Descp"
        Me.dgclUsageCOADescp.Name = "dgclUsageCOADescp"
        Me.dgclUsageCOADescp.ReadOnly = True
        Me.dgclUsageCOADescp.Visible = False
        '
        'dgclContractID
        '
        Me.dgclContractID.DataPropertyName = "ContractID"
        Me.dgclContractID.HeaderText = "ContractID"
        Me.dgclContractID.Name = "dgclContractID"
        Me.dgclContractID.ReadOnly = True
        Me.dgclContractID.Visible = False
        '
        'dgclLPODate
        '
        Me.dgclLPODate.DataPropertyName = "LPODate"
        DataGridViewCellStyle8.Format = "dd/MM/yyyy"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.dgclLPODate.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgclLPODate.HeaderText = "PO Date"
        Me.dgclLPODate.Name = "dgclLPODate"
        Me.dgclLPODate.ReadOnly = True
        '
        'dgclUnitPrice
        '
        Me.dgclUnitPrice.DataPropertyName = "UnitPrice"
        Me.dgclUnitPrice.HeaderText = "UnitPrice"
        Me.dgclUnitPrice.Name = "dgclUnitPrice"
        Me.dgclUnitPrice.ReadOnly = True
        Me.dgclUnitPrice.Visible = False
        '
        'dgclSupplierName
        '
        Me.dgclSupplierName.DataPropertyName = "SupplierName"
        Me.dgclSupplierName.HeaderText = "Supplier Name"
        Me.dgclSupplierName.Name = "dgclSupplierName"
        Me.dgclSupplierName.ReadOnly = True
        Me.dgclSupplierName.Width = 150
        '
        'dgclStockCode
        '
        Me.dgclStockCode.DataPropertyName = "StockCode"
        Me.dgclStockCode.HeaderText = "Stock Code"
        Me.dgclStockCode.Name = "dgclStockCode"
        Me.dgclStockCode.ReadOnly = True
        Me.dgclStockCode.Visible = False
        '
        'dgclQty
        '
        Me.dgclQty.DataPropertyName = "OrderQty"
        Me.dgclQty.HeaderText = "Qty"
        Me.dgclQty.Name = "dgclQty"
        Me.dgclQty.ReadOnly = True
        Me.dgclQty.Visible = False
        '
        'dgclMainStatus
        '
        Me.dgclMainStatus.DataPropertyName = "MainStatus"
        Me.dgclMainStatus.HeaderText = "Status"
        Me.dgclMainStatus.Name = "dgclMainStatus"
        Me.dgclMainStatus.ReadOnly = True
        '
        'dgclSupplierID
        '
        Me.dgclSupplierID.DataPropertyName = "APSupplierID"
        Me.dgclSupplierID.HeaderText = "APSupplierID"
        Me.dgclSupplierID.Name = "dgclSupplierID"
        Me.dgclSupplierID.ReadOnly = True
        Me.dgclSupplierID.Visible = False
        '
        'dgclT1Value
        '
        Me.dgclT1Value.DataPropertyName = "T1Value"
        Me.dgclT1Value.HeaderText = "T1"
        Me.dgclT1Value.Name = "dgclT1Value"
        Me.dgclT1Value.ReadOnly = True
        Me.dgclT1Value.Visible = False
        '
        'dgclT2Value
        '
        Me.dgclT2Value.DataPropertyName = "T2Value"
        Me.dgclT2Value.HeaderText = "T2"
        Me.dgclT2Value.Name = "dgclT2Value"
        Me.dgclT2Value.ReadOnly = True
        Me.dgclT2Value.Visible = False
        '
        'dgclT3Value
        '
        Me.dgclT3Value.DataPropertyName = "T3Value"
        Me.dgclT3Value.HeaderText = "T3"
        Me.dgclT3Value.Name = "dgclT3Value"
        Me.dgclT3Value.ReadOnly = True
        Me.dgclT3Value.Visible = False
        '
        'dgclT4Value
        '
        Me.dgclT4Value.DataPropertyName = "T4Value"
        Me.dgclT4Value.HeaderText = "T4"
        Me.dgclT4Value.Name = "dgclT4Value"
        Me.dgclT4Value.ReadOnly = True
        Me.dgclT4Value.Visible = False
        '
        'dgclSTLPOID
        '
        Me.dgclSTLPOID.DataPropertyName = "STLPOID"
        Me.dgclSTLPOID.HeaderText = "STPOID"
        Me.dgclSTLPOID.Name = "dgclSTLPOID"
        Me.dgclSTLPOID.ReadOnly = True
        Me.dgclSTLPOID.Visible = False
        '
        'dgclSupplierAdd
        '
        Me.dgclSupplierAdd.HeaderText = "SupplierAddress"
        Me.dgclSupplierAdd.Name = "dgclSupplierAdd"
        Me.dgclSupplierAdd.ReadOnly = True
        Me.dgclSupplierAdd.Visible = False
        '
        'dgclContractNo
        '
        Me.dgclContractNo.DataPropertyName = "ContractNo"
        Me.dgclContractNo.HeaderText = "Contract No"
        Me.dgclContractNo.Name = "dgclContractNo"
        Me.dgclContractNo.ReadOnly = True
        Me.dgclContractNo.Visible = False
        '
        'dgclTotalPrice
        '
        Me.dgclTotalPrice.DataPropertyName = "Value"
        Me.dgclTotalPrice.HeaderText = "Total Price"
        Me.dgclTotalPrice.Name = "dgclTotalPrice"
        Me.dgclTotalPrice.ReadOnly = True
        Me.dgclTotalPrice.Visible = False
        '
        'dgclT0Value
        '
        Me.dgclT0Value.DataPropertyName = "T0Value"
        Me.dgclT0Value.HeaderText = "T0"
        Me.dgclT0Value.Name = "dgclT0Value"
        Me.dgclT0Value.ReadOnly = True
        Me.dgclT0Value.Visible = False
        '
        'dgclRemarks
        '
        Me.dgclRemarks.DataPropertyName = "Remarks"
        Me.dgclRemarks.HeaderText = "Remarks"
        Me.dgclRemarks.Name = "dgclRemarks"
        Me.dgclRemarks.ReadOnly = True
        Me.dgclRemarks.Visible = False
        Me.dgclRemarks.Width = 200
        '
        'ViewReport
        '
        Me.ViewReport.DataPropertyName = "View Report"
        Me.ViewReport.HeaderText = "View Report"
        Me.ViewReport.Name = "ViewReport"
        Me.ViewReport.ReadOnly = True
        Me.ViewReport.Text = "View Report"
        Me.ViewReport.UseColumnTextForButtonValue = True
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
        Me.dgclSTCategoryCode.HeaderText = "STCategoryCode"
        Me.dgclSTCategoryCode.Name = "dgclSTCategoryCode"
        Me.dgclSTCategoryCode.ReadOnly = True
        Me.dgclSTCategoryCode.Visible = False
        '
        'dgclSTCategoryDescp
        '
        Me.dgclSTCategoryDescp.DataPropertyName = "STCategoryDescp"
        Me.dgclSTCategoryDescp.HeaderText = "STCategoryDescp"
        Me.dgclSTCategoryDescp.Name = "dgclSTCategoryDescp"
        Me.dgclSTCategoryDescp.ReadOnly = True
        Me.dgclSTCategoryDescp.Visible = False
        '
        'lblView
        '
        Me.lblView.AutoSize = True
        Me.lblView.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblView.ForeColor = System.Drawing.Color.Red
        Me.lblView.Location = New System.Drawing.Point(237, 264)
        Me.lblView.Name = "lblView"
        Me.lblView.Size = New System.Drawing.Size(130, 13)
        Me.lblView.TabIndex = 408
        Me.lblView.Text = "Record not found !!"
        Me.lblView.Visible = False
        '
        'StoreLPOReportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(842, 508)
        Me.Controls.Add(Me.lblView)
        Me.Controls.Add(Me.dgvLPOView)
        Me.Controls.Add(Me.pnlSearchLPO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "StoreLPOReportFrm"
        Me.Text = "StoreLPOReportFrm"
        Me.pnlSearchLPO.ResumeLayout(False)
        Me.pnlSearchLPO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLPOView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlSearchLPO As Stepi.UI.ExtendedPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents chkLPOViewDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpLPOViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLPOViewNo As System.Windows.Forms.TextBox
    Friend WithEvents btnLPOViewSearch As System.Windows.Forms.Button
    Friend WithEvents lblLPONoView As System.Windows.Forms.Label
    Friend WithEvents dgvLPOView As System.Windows.Forms.DataGridView
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgclLPONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclUsageCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclUsageCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclUsageCOADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclContractID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLPODate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclMainStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT1Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT2Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT3Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT4Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTLPOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclContractNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTotalPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT0Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewReport As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents dgclSTCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTCategoryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTCategoryDescp As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstateMillDeliveryNoteFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstateMillDeliveryNoteFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.plEstateMillDeliveryNote = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.gbDetails = New System.Windows.Forms.GroupBox()
        Me.dgvDetails = New System.Windows.Forms.DataGridView()
        Me.dgclStockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTIPRDetID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTLPODetID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTEstMillDelivID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTEstMillDelivDetID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclVarianceCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclAccountCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclAccountDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclAvailableQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRequestedQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTAnalysisID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPendingQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclReceivedQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclReceivedPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDifferenceQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsEMDN = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbDeliveySource = New System.Windows.Forms.ComboBox()
        Me.lblColon4 = New System.Windows.Forms.Label()
        Me.lblColon7 = New System.Windows.Forms.Label()
        Me.lblPONo = New System.Windows.Forms.Label()
        Me.lblDeliverySource = New System.Windows.Forms.Label()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.gbIDN = New System.Windows.Forms.GroupBox()
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.btnT0Search = New System.Windows.Forms.Button()
        Me.grpApproval = New System.Windows.Forms.GroupBox()
        Me.lblRejectedColon = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnConform = New System.Windows.Forms.Button()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.txtRejectedReason = New System.Windows.Forms.TextBox()
        Me.lblRejectedReason = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtT0 = New System.Windows.Forms.TextBox()
        Me.lblT0 = New System.Windows.Forms.Label()
        Me.gbOperatorDet = New System.Windows.Forms.GroupBox()
        Me.BtnVehicle = New System.Windows.Forms.Button()
        Me.dtpTransportDate = New System.Windows.Forms.DateTimePicker()
        Me.txtVehicleNo = New System.Windows.Forms.TextBox()
        Me.txtOperatorName = New System.Windows.Forms.TextBox()
        Me.lblVehicleNo = New System.Windows.Forms.Label()
        Me.lblColon17 = New System.Windows.Forms.Label()
        Me.lblColon18 = New System.Windows.Forms.Label()
        Me.lblOperatorName = New System.Windows.Forms.Label()
        Me.lblColon16 = New System.Windows.Forms.Label()
        Me.lblTransportDate = New System.Windows.Forms.Label()
        Me.lblColon25 = New System.Windows.Forms.Label()
        Me.btnSearchSupplier = New System.Windows.Forms.Button()
        Me.btnSearchLPONo = New System.Windows.Forms.Button()
        Me.btnSearchIPRNo = New System.Windows.Forms.Button()
        Me.cbTransType = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.lblTransType = New System.Windows.Forms.Label()
        Me.lblIPRNo = New System.Windows.Forms.Label()
        Me.lblLPONo = New System.Windows.Forms.Label()
        Me.lblStatusDesc = New System.Windows.Forms.Label()
        Me.lblColon10 = New System.Windows.Forms.Label()
        Me.lblColon9 = New System.Windows.Forms.Label()
        Me.lblColon8 = New System.Windows.Forms.Label()
        Me.dtpIDNDate = New System.Windows.Forms.DateTimePicker()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIPRNo = New System.Windows.Forms.TextBox()
        Me.lblIDNDate = New System.Windows.Forms.Label()
        Me.lblGRNNo = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtLPONo = New System.Windows.Forms.TextBox()
        Me.lblColon1 = New System.Windows.Forms.Label()
        Me.lblColon3 = New System.Windows.Forms.Label()
        Me.lblColon5 = New System.Windows.Forms.Label()
        Me.txtGRNNo = New System.Windows.Forms.TextBox()
        Me.txtIDNNo = New System.Windows.Forms.TextBox()
        Me.lblIDNNo = New System.Windows.Forms.Label()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.lblColon2 = New System.Windows.Forms.Label()
        Me.lblColon6 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.gbEdit = New System.Windows.Forms.GroupBox()
        Me.txtAvailableQty = New System.Windows.Forms.TextBox()
        Me.lblAvailableQty = New System.Windows.Forms.Label()
        Me.lbl23 = New System.Windows.Forms.Label()
        Me.txtReceivedPrice = New System.Windows.Forms.TextBox()
        Me.lblReceivedPrice = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtPendingQty = New System.Windows.Forms.TextBox()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.lblStockDesc = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtReceivedQty = New System.Windows.Forms.TextBox()
        Me.lblPendingQty = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblStockCode = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtStockDesc = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblReceivedQty = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.tcEMDN = New System.Windows.Forms.TabControl()
        Me.tbpgEMDNAdd = New System.Windows.Forms.TabPage()
        Me.tbpgEMDNView = New System.Windows.Forms.TabPage()
        Me.plITNOutView = New System.Windows.Forms.Panel()
        Me.dgvIDNView = New System.Windows.Forms.DataGridView()
        Me.dgclSTEstMillDeliveryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTPRID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTLPOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclIDNDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclIDNNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclGRNNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclIPRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLPONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDeliverySource = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSupplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSupplierID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclOperatorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransportDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclVehicleNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclViewReport = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.cmsEMDNView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditUpdateToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.plEMDNSearch = New Stepi.UI.ExtendedPanel()
        Me.cbviewDeliverySource = New System.Windows.Forms.ComboBox()
        Me.txtviewPONo = New System.Windows.Forms.TextBox()
        Me.rbtnLPONo = New System.Windows.Forms.RadioButton()
        Me.rbtnIPR = New System.Windows.Forms.RadioButton()
        Me.txtviewSupplier = New System.Windows.Forms.TextBox()
        Me.txtviewGRNNo = New System.Windows.Forms.TextBox()
        Me.txtviewIDNNo = New System.Windows.Forms.TextBox()
        Me.cbviewLPONo = New System.Windows.Forms.ComboBox()
        Me.cbviewIPRNo = New System.Windows.Forms.ComboBox()
        Me.cbviewTransType = New System.Windows.Forms.ComboBox()
        Me.lblviewSupplier = New System.Windows.Forms.Label()
        Me.lblviewPONo = New System.Windows.Forms.Label()
        Me.lblviewDeliverySource = New System.Windows.Forms.Label()
        Me.lblviewGRNNo = New System.Windows.Forms.Label()
        Me.lblsearchBy = New System.Windows.Forms.Label()
        Me.chkIDNDate = New System.Windows.Forms.CheckBox()
        Me.dtpviewIDNDate = New System.Windows.Forms.DateTimePicker()
        Me.lblviewIDNDate = New System.Windows.Forms.Label()
        Me.btnviewReport = New System.Windows.Forms.Button()
        Me.lblviewIDNNo = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cbviewStatus = New System.Windows.Forms.ComboBox()
        Me.lblviewTransType = New System.Windows.Forms.Label()
        Me.lblviewMainstatus = New System.Windows.Forms.Label()
        Me.plEstateMillDeliveryNote.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbDetails.SuspendLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsEMDN.SuspendLayout()
        Me.gbIDN.SuspendLayout()
        Me.gbMain.SuspendLayout()
        Me.grpApproval.SuspendLayout()
        Me.gbOperatorDet.SuspendLayout()
        Me.gbEdit.SuspendLayout()
        Me.tcEMDN.SuspendLayout()
        Me.tbpgEMDNAdd.SuspendLayout()
        Me.tbpgEMDNView.SuspendLayout()
        Me.plITNOutView.SuspendLayout()
        CType(Me.dgvIDNView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsEMDNView.SuspendLayout()
        Me.plEMDNSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'plEstateMillDeliveryNote
        '
        Me.plEstateMillDeliveryNote.AutoScroll = True
        Me.plEstateMillDeliveryNote.BackColor = System.Drawing.Color.Transparent
        Me.plEstateMillDeliveryNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plEstateMillDeliveryNote.Controls.Add(Me.GroupBox2)
        Me.plEstateMillDeliveryNote.Controls.Add(Me.gbDetails)
        Me.plEstateMillDeliveryNote.Controls.Add(Me.gbIDN)
        Me.plEstateMillDeliveryNote.Location = New System.Drawing.Point(3, 3)
        Me.plEstateMillDeliveryNote.Name = "plEstateMillDeliveryNote"
        Me.plEstateMillDeliveryNote.Size = New System.Drawing.Size(979, 523)
        Me.plEstateMillDeliveryNote.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnClose)
        Me.GroupBox2.Controls.Add(Me.btnSaveAll)
        Me.GroupBox2.Controls.Add(Me.btnResetAll)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 477)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(976, 41)
        Me.GroupBox2.TabIndex = 159
        Me.GroupBox2.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(867, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(101, 26)
        Me.btnClose.TabIndex = 161
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = CType(resources.GetObject("btnSaveAll.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(606, 12)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(148, 26)
        Me.btnSaveAll.TabIndex = 159
        Me.btnSaveAll.Text = "Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = CType(resources.GetObject("btnResetAll.BackgroundImage"), System.Drawing.Image)
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAll.Image = CType(resources.GetObject("btnResetAll.Image"), System.Drawing.Image)
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.Location = New System.Drawing.Point(760, 12)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(101, 26)
        Me.btnResetAll.TabIndex = 160
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'gbDetails
        '
        Me.gbDetails.Controls.Add(Me.dgvDetails)
        Me.gbDetails.Controls.Add(Me.cbDeliveySource)
        Me.gbDetails.Controls.Add(Me.lblColon4)
        Me.gbDetails.Controls.Add(Me.lblColon7)
        Me.gbDetails.Controls.Add(Me.lblPONo)
        Me.gbDetails.Controls.Add(Me.lblDeliverySource)
        Me.gbDetails.Controls.Add(Me.txtPONo)
        Me.gbDetails.Location = New System.Drawing.Point(3, 291)
        Me.gbDetails.Name = "gbDetails"
        Me.gbDetails.Size = New System.Drawing.Size(967, 185)
        Me.gbDetails.TabIndex = 131
        Me.gbDetails.TabStop = False
        Me.gbDetails.Text = "Details"
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclStockID, Me.dgclSTIPRDetID, Me.dgclSTLPODetID, Me.dgclSTEstMillDelivID, Me.dgclSTEstMillDelivDetID, Me.dgclStockCode, Me.dgclStockDesc, Me.dgclPartNo, Me.dgclCOAID, Me.dgclStockCOAID, Me.dgclVarianceCOAID, Me.dgclAccountCode, Me.dgclAccountDesc, Me.dgclAvailableQty, Me.dgclRequestedQty, Me.dgclTAnalysisID, Me.dgclT0, Me.dgclUnitPrice, Me.dgclPendingQty, Me.dgclReceivedQty, Me.dgclUnit, Me.dgclReceivedPrice, Me.dgclTotalPrice, Me.dgclDifferenceQty})
        Me.dgvDetails.ContextMenuStrip = Me.cmsEMDN
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetails.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvDetails.EnableHeadersVisualStyles = False
        Me.dgvDetails.GridColor = System.Drawing.Color.Gray
        Me.dgvDetails.Location = New System.Drawing.Point(2, 13)
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDetails.RowHeadersVisible = False
        Me.dgvDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.ShowCellErrors = False
        Me.dgvDetails.Size = New System.Drawing.Size(964, 167)
        Me.dgvDetails.TabIndex = 165
        Me.dgvDetails.TabStop = False
        '
        'dgclStockID
        '
        Me.dgclStockID.DataPropertyName = "StockID"
        Me.dgclStockID.HeaderText = "Stock ID"
        Me.dgclStockID.Name = "dgclStockID"
        Me.dgclStockID.ReadOnly = True
        Me.dgclStockID.Visible = False
        Me.dgclStockID.Width = 81
        '
        'dgclSTIPRDetID
        '
        Me.dgclSTIPRDetID.DataPropertyName = "STIPRDetID"
        Me.dgclSTIPRDetID.HeaderText = "STIPRDetID"
        Me.dgclSTIPRDetID.Name = "dgclSTIPRDetID"
        Me.dgclSTIPRDetID.ReadOnly = True
        Me.dgclSTIPRDetID.Visible = False
        '
        'dgclSTLPODetID
        '
        Me.dgclSTLPODetID.DataPropertyName = "STLPODetID"
        Me.dgclSTLPODetID.HeaderText = "STPODetID"
        Me.dgclSTLPODetID.Name = "dgclSTLPODetID"
        Me.dgclSTLPODetID.ReadOnly = True
        Me.dgclSTLPODetID.Visible = False
        Me.dgclSTLPODetID.Width = 96
        '
        'dgclSTEstMillDelivID
        '
        Me.dgclSTEstMillDelivID.DataPropertyName = "STEstMillDeliveryID"
        Me.dgclSTEstMillDelivID.HeaderText = "STEstMillDeliveryID"
        Me.dgclSTEstMillDelivID.Name = "dgclSTEstMillDelivID"
        Me.dgclSTEstMillDelivID.ReadOnly = True
        Me.dgclSTEstMillDelivID.Visible = False
        Me.dgclSTEstMillDelivID.Width = 143
        '
        'dgclSTEstMillDelivDetID
        '
        Me.dgclSTEstMillDelivDetID.DataPropertyName = "STEstMillDeliveryDetID"
        Me.dgclSTEstMillDelivDetID.HeaderText = "STEstMillDelivDet ID"
        Me.dgclSTEstMillDelivDetID.Name = "dgclSTEstMillDelivDetID"
        Me.dgclSTEstMillDelivDetID.ReadOnly = True
        Me.dgclSTEstMillDelivDetID.Visible = False
        Me.dgclSTEstMillDelivDetID.Width = 148
        '
        'dgclStockCode
        '
        Me.dgclStockCode.DataPropertyName = "StockCode"
        Me.dgclStockCode.HeaderText = "Stock Code"
        Me.dgclStockCode.Name = "dgclStockCode"
        Me.dgclStockCode.ReadOnly = True
        Me.dgclStockCode.Width = 97
        '
        'dgclStockDesc
        '
        Me.dgclStockDesc.DataPropertyName = "StockDesc"
        Me.dgclStockDesc.HeaderText = "Stock Description"
        Me.dgclStockDesc.Name = "dgclStockDesc"
        Me.dgclStockDesc.ReadOnly = True
        Me.dgclStockDesc.Width = 131
        '
        'dgclPartNo
        '
        Me.dgclPartNo.DataPropertyName = "PartNo"
        Me.dgclPartNo.HeaderText = "Part No."
        Me.dgclPartNo.Name = "dgclPartNo"
        Me.dgclPartNo.ReadOnly = True
        Me.dgclPartNo.Width = 77
        '
        'dgclCOAID
        '
        Me.dgclCOAID.DataPropertyName = "COAID"
        Me.dgclCOAID.HeaderText = "COA ID"
        Me.dgclCOAID.Name = "dgclCOAID"
        Me.dgclCOAID.ReadOnly = True
        Me.dgclCOAID.Visible = False
        Me.dgclCOAID.Width = 75
        '
        'dgclStockCOAID
        '
        Me.dgclStockCOAID.DataPropertyName = "StockCOAID"
        Me.dgclStockCOAID.HeaderText = "StockCOAID"
        Me.dgclStockCOAID.Name = "dgclStockCOAID"
        Me.dgclStockCOAID.ReadOnly = True
        Me.dgclStockCOAID.Visible = False
        Me.dgclStockCOAID.Width = 103
        '
        'dgclVarianceCOAID
        '
        Me.dgclVarianceCOAID.DataPropertyName = "VarianceCOAID"
        Me.dgclVarianceCOAID.HeaderText = "VarianceCOAID"
        Me.dgclVarianceCOAID.Name = "dgclVarianceCOAID"
        Me.dgclVarianceCOAID.ReadOnly = True
        Me.dgclVarianceCOAID.Visible = False
        Me.dgclVarianceCOAID.Width = 121
        '
        'dgclAccountCode
        '
        Me.dgclAccountCode.DataPropertyName = "COACode"
        Me.dgclAccountCode.HeaderText = "Account Code"
        Me.dgclAccountCode.Name = "dgclAccountCode"
        Me.dgclAccountCode.ReadOnly = True
        Me.dgclAccountCode.Width = 110
        '
        'dgclAccountDesc
        '
        Me.dgclAccountDesc.DataPropertyName = "COADescp"
        Me.dgclAccountDesc.HeaderText = "Account Description"
        Me.dgclAccountDesc.Name = "dgclAccountDesc"
        Me.dgclAccountDesc.ReadOnly = True
        Me.dgclAccountDesc.Width = 144
        '
        'dgclAvailableQty
        '
        Me.dgclAvailableQty.DataPropertyName = "AvailableQty"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgclAvailableQty.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgclAvailableQty.HeaderText = "Available Qty"
        Me.dgclAvailableQty.Name = "dgclAvailableQty"
        Me.dgclAvailableQty.ReadOnly = True
        Me.dgclAvailableQty.Width = 107
        '
        'dgclRequestedQty
        '
        Me.dgclRequestedQty.DataPropertyName = "RequestedQty"
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.dgclRequestedQty.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgclRequestedQty.HeaderText = "Requested Qty"
        Me.dgclRequestedQty.Name = "dgclRequestedQty"
        Me.dgclRequestedQty.ReadOnly = True
        Me.dgclRequestedQty.Width = 115
        '
        'dgclTAnalysisID
        '
        Me.dgclTAnalysisID.DataPropertyName = "TAnalysisID"
        Me.dgclTAnalysisID.HeaderText = "TAnalysisID"
        Me.dgclTAnalysisID.Name = "dgclTAnalysisID"
        Me.dgclTAnalysisID.ReadOnly = True
        Me.dgclTAnalysisID.Visible = False
        Me.dgclTAnalysisID.Width = 99
        '
        'dgclT0
        '
        Me.dgclT0.DataPropertyName = "TValue"
        Me.dgclT0.HeaderText = "T0"
        Me.dgclT0.Name = "dgclT0"
        Me.dgclT0.ReadOnly = True
        Me.dgclT0.Visible = False
        Me.dgclT0.Width = 45
        '
        'dgclUnitPrice
        '
        Me.dgclUnitPrice.DataPropertyName = "UnitPrice"
        Me.dgclUnitPrice.HeaderText = "Unit Price"
        Me.dgclUnitPrice.Name = "dgclUnitPrice"
        Me.dgclUnitPrice.ReadOnly = True
        Me.dgclUnitPrice.Visible = False
        Me.dgclUnitPrice.Width = 85
        '
        'dgclPendingQty
        '
        Me.dgclPendingQty.DataPropertyName = "PendingQty"
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.dgclPendingQty.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgclPendingQty.HeaderText = "Pending Qty"
        Me.dgclPendingQty.Name = "dgclPendingQty"
        Me.dgclPendingQty.ReadOnly = True
        '
        'dgclReceivedQty
        '
        Me.dgclReceivedQty.DataPropertyName = "ReceivedQty"
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.dgclReceivedQty.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgclReceivedQty.HeaderText = "Received Qty"
        Me.dgclReceivedQty.Name = "dgclReceivedQty"
        Me.dgclReceivedQty.ReadOnly = True
        Me.dgclReceivedQty.Width = 107
        '
        'dgclUnit
        '
        Me.dgclUnit.DataPropertyName = "Unit"
        Me.dgclUnit.HeaderText = "Unit"
        Me.dgclUnit.Name = "dgclUnit"
        Me.dgclUnit.ReadOnly = True
        Me.dgclUnit.Width = 53
        '
        'dgclReceivedPrice
        '
        Me.dgclReceivedPrice.DataPropertyName = "ReceivedPrice"
        Me.dgclReceivedPrice.HeaderText = "Received Price"
        Me.dgclReceivedPrice.Name = "dgclReceivedPrice"
        Me.dgclReceivedPrice.ReadOnly = True
        Me.dgclReceivedPrice.Width = 115
        '
        'dgclTotalPrice
        '
        Me.dgclTotalPrice.DataPropertyName = "TotalPrice"
        Me.dgclTotalPrice.HeaderText = "Total Price"
        Me.dgclTotalPrice.Name = "dgclTotalPrice"
        Me.dgclTotalPrice.ReadOnly = True
        Me.dgclTotalPrice.Visible = False
        Me.dgclTotalPrice.Width = 91
        '
        'dgclDifferenceQty
        '
        Me.dgclDifferenceQty.DataPropertyName = "DifferenceQTy"
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.dgclDifferenceQty.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgclDifferenceQty.HeaderText = "Difference Qty"
        Me.dgclDifferenceQty.Name = "dgclDifferenceQty"
        Me.dgclDifferenceQty.ReadOnly = True
        Me.dgclDifferenceQty.Width = 114
        '
        'cmsEMDN
        '
        Me.cmsEMDN.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditUpdateToolStripMenuItem, Me.DeleteToolStripMenuItem1})
        Me.cmsEMDN.Name = "cmsEMDN"
        Me.cmsEMDN.Size = New System.Drawing.Size(144, 48)
        '
        'EditUpdateToolStripMenuItem
        '
        Me.EditUpdateToolStripMenuItem.Image = CType(resources.GetObject("EditUpdateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditUpdateToolStripMenuItem.Name = "EditUpdateToolStripMenuItem"
        Me.EditUpdateToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.EditUpdateToolStripMenuItem.Text = "Edit / Update"
        '
        'DeleteToolStripMenuItem1
        '
        Me.DeleteToolStripMenuItem1.Image = CType(resources.GetObject("DeleteToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1"
        Me.DeleteToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
        Me.DeleteToolStripMenuItem1.Text = "Delete"
        '
        'cbDeliveySource
        '
        Me.cbDeliveySource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDeliveySource.FormattingEnabled = True
        Me.cbDeliveySource.Items.AddRange(New Object() {"Samarinda", "Consignment"})
        Me.cbDeliveySource.Location = New System.Drawing.Point(600, 82)
        Me.cbDeliveySource.Name = "cbDeliveySource"
        Me.cbDeliveySource.Size = New System.Drawing.Size(158, 21)
        Me.cbDeliveySource.TabIndex = 150
        Me.cbDeliveySource.Visible = False
        '
        'lblColon4
        '
        Me.lblColon4.AutoSize = True
        Me.lblColon4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon4.Location = New System.Drawing.Point(582, 21)
        Me.lblColon4.Name = "lblColon4"
        Me.lblColon4.Size = New System.Drawing.Size(12, 13)
        Me.lblColon4.TabIndex = 166
        Me.lblColon4.Text = ":"
        Me.lblColon4.Visible = False
        '
        'lblColon7
        '
        Me.lblColon7.AutoSize = True
        Me.lblColon7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon7.Location = New System.Drawing.Point(582, 85)
        Me.lblColon7.Name = "lblColon7"
        Me.lblColon7.Size = New System.Drawing.Size(12, 13)
        Me.lblColon7.TabIndex = 169
        Me.lblColon7.Text = ":"
        Me.lblColon7.Visible = False
        '
        'lblPONo
        '
        Me.lblPONo.AutoSize = True
        Me.lblPONo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPONo.ForeColor = System.Drawing.Color.Black
        Me.lblPONo.Location = New System.Drawing.Point(479, 22)
        Me.lblPONo.Name = "lblPONo"
        Me.lblPONo.Size = New System.Drawing.Size(46, 13)
        Me.lblPONo.TabIndex = 143
        Me.lblPONo.Text = "PO No."
        Me.lblPONo.Visible = False
        '
        'lblDeliverySource
        '
        Me.lblDeliverySource.AutoSize = True
        Me.lblDeliverySource.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeliverySource.ForeColor = System.Drawing.Color.Red
        Me.lblDeliverySource.Location = New System.Drawing.Point(479, 84)
        Me.lblDeliverySource.Name = "lblDeliverySource"
        Me.lblDeliverySource.Size = New System.Drawing.Size(99, 13)
        Me.lblDeliverySource.TabIndex = 151
        Me.lblDeliverySource.Text = "Delivery Source"
        Me.lblDeliverySource.Visible = False
        '
        'txtPONo
        '
        Me.txtPONo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPONo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPONo.Location = New System.Drawing.Point(600, 20)
        Me.txtPONo.MaxLength = 50
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(158, 21)
        Me.txtPONo.TabIndex = 144
        Me.txtPONo.Visible = False
        '
        'gbIDN
        '
        Me.gbIDN.Controls.Add(Me.gbMain)
        Me.gbIDN.Controls.Add(Me.btnReset)
        Me.gbIDN.Controls.Add(Me.gbEdit)
        Me.gbIDN.Controls.Add(Me.btnAdd)
        Me.gbIDN.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbIDN.Location = New System.Drawing.Point(0, 0)
        Me.gbIDN.Name = "gbIDN"
        Me.gbIDN.Size = New System.Drawing.Size(977, 292)
        Me.gbIDN.TabIndex = 130
        Me.gbIDN.TabStop = False
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.btnT0Search)
        Me.gbMain.Controls.Add(Me.grpApproval)
        Me.gbMain.Controls.Add(Me.txtT0)
        Me.gbMain.Controls.Add(Me.lblT0)
        Me.gbMain.Controls.Add(Me.gbOperatorDet)
        Me.gbMain.Controls.Add(Me.lblColon25)
        Me.gbMain.Controls.Add(Me.btnSearchSupplier)
        Me.gbMain.Controls.Add(Me.btnSearchLPONo)
        Me.gbMain.Controls.Add(Me.btnSearchIPRNo)
        Me.gbMain.Controls.Add(Me.cbTransType)
        Me.gbMain.Controls.Add(Me.lblStatus)
        Me.gbMain.Controls.Add(Me.txtRemarks)
        Me.gbMain.Controls.Add(Me.lblTransType)
        Me.gbMain.Controls.Add(Me.lblIPRNo)
        Me.gbMain.Controls.Add(Me.lblLPONo)
        Me.gbMain.Controls.Add(Me.lblStatusDesc)
        Me.gbMain.Controls.Add(Me.lblColon10)
        Me.gbMain.Controls.Add(Me.lblColon9)
        Me.gbMain.Controls.Add(Me.lblColon8)
        Me.gbMain.Controls.Add(Me.dtpIDNDate)
        Me.gbMain.Controls.Add(Me.txtSupplier)
        Me.gbMain.Controls.Add(Me.Label5)
        Me.gbMain.Controls.Add(Me.txtIPRNo)
        Me.gbMain.Controls.Add(Me.lblIDNDate)
        Me.gbMain.Controls.Add(Me.lblGRNNo)
        Me.gbMain.Controls.Add(Me.lblRemarks)
        Me.gbMain.Controls.Add(Me.txtLPONo)
        Me.gbMain.Controls.Add(Me.lblColon1)
        Me.gbMain.Controls.Add(Me.lblColon3)
        Me.gbMain.Controls.Add(Me.lblColon5)
        Me.gbMain.Controls.Add(Me.txtGRNNo)
        Me.gbMain.Controls.Add(Me.txtIDNNo)
        Me.gbMain.Controls.Add(Me.lblIDNNo)
        Me.gbMain.Controls.Add(Me.lblSupplier)
        Me.gbMain.Controls.Add(Me.lblColon2)
        Me.gbMain.Controls.Add(Me.lblColon6)
        Me.gbMain.Location = New System.Drawing.Point(3, 7)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(660, 284)
        Me.gbMain.TabIndex = 141
        Me.gbMain.TabStop = False
        Me.gbMain.Text = "Main"
        '
        'btnT0Search
        '
        Me.btnT0Search.Image = CType(resources.GetObject("btnT0Search.Image"), System.Drawing.Image)
        Me.btnT0Search.Location = New System.Drawing.Point(610, 128)
        Me.btnT0Search.Name = "btnT0Search"
        Me.btnT0Search.Size = New System.Drawing.Size(31, 26)
        Me.btnT0Search.TabIndex = 301
        Me.btnT0Search.TabStop = False
        Me.btnT0Search.UseVisualStyleBackColor = True
        Me.btnT0Search.Visible = False
        '
        'grpApproval
        '
        Me.grpApproval.Controls.Add(Me.lblRejectedColon)
        Me.grpApproval.Controls.Add(Me.Label4)
        Me.grpApproval.Controls.Add(Me.btnConform)
        Me.grpApproval.Controls.Add(Me.cmbStatus)
        Me.grpApproval.Controls.Add(Me.txtRejectedReason)
        Me.grpApproval.Controls.Add(Me.lblRejectedReason)
        Me.grpApproval.Controls.Add(Me.Label1)
        Me.grpApproval.Location = New System.Drawing.Point(322, 172)
        Me.grpApproval.Name = "grpApproval"
        Me.grpApproval.Size = New System.Drawing.Size(332, 101)
        Me.grpApproval.TabIndex = 142
        Me.grpApproval.TabStop = False
        Me.grpApproval.Text = "DN Approval"
        Me.grpApproval.Visible = False
        '
        'lblRejectedColon
        '
        Me.lblRejectedColon.AutoSize = True
        Me.lblRejectedColon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejectedColon.Location = New System.Drawing.Point(264, 17)
        Me.lblRejectedColon.Name = "lblRejectedColon"
        Me.lblRejectedColon.Size = New System.Drawing.Size(11, 13)
        Me.lblRejectedColon.TabIndex = 145
        Me.lblRejectedColon.Text = ":"
        Me.lblRejectedColon.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(52, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = ":"
        '
        'btnConform
        '
        Me.btnConform.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnConform.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConform.Image = CType(resources.GetObject("btnConform.Image"), System.Drawing.Image)
        Me.btnConform.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConform.Location = New System.Drawing.Point(6, 69)
        Me.btnConform.Name = "btnConform"
        Me.btnConform.Size = New System.Drawing.Size(98, 25)
        Me.btnConform.TabIndex = 144
        Me.btnConform.Text = "Confirm"
        Me.btnConform.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"APPROVED", "REJECTED"})
        Me.cmbStatus.Location = New System.Drawing.Point(7, 37)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(144, 21)
        Me.cmbStatus.TabIndex = 142
        '
        'txtRejectedReason
        '
        Me.txtRejectedReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRejectedReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRejectedReason.ForeColor = System.Drawing.Color.Red
        Me.txtRejectedReason.Location = New System.Drawing.Point(158, 38)
        Me.txtRejectedReason.MaxLength = 300
        Me.txtRejectedReason.Multiline = True
        Me.txtRejectedReason.Name = "txtRejectedReason"
        Me.txtRejectedReason.Size = New System.Drawing.Size(163, 56)
        Me.txtRejectedReason.TabIndex = 143
        Me.txtRejectedReason.Visible = False
        '
        'lblRejectedReason
        '
        Me.lblRejectedReason.AutoSize = True
        Me.lblRejectedReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejectedReason.ForeColor = System.Drawing.Color.Black
        Me.lblRejectedReason.Location = New System.Drawing.Point(163, 17)
        Me.lblRejectedReason.Name = "lblRejectedReason"
        Me.lblRejectedReason.Size = New System.Drawing.Size(103, 13)
        Me.lblRejectedReason.TabIndex = 143
        Me.lblRejectedReason.Text = "Rejected Reason"
        Me.lblRejectedReason.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "Status"
        '
        'txtT0
        '
        Me.txtT0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT0.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT0.Location = New System.Drawing.Point(463, 132)
        Me.txtT0.MaxLength = 50
        Me.txtT0.Name = "txtT0"
        Me.txtT0.Size = New System.Drawing.Size(144, 21)
        Me.txtT0.TabIndex = 300
        Me.txtT0.Visible = False
        '
        'lblT0
        '
        Me.lblT0.AutoSize = True
        Me.lblT0.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT0.ForeColor = System.Drawing.Color.Red
        Me.lblT0.Location = New System.Drawing.Point(340, 133)
        Me.lblT0.Name = "lblT0"
        Me.lblT0.Size = New System.Drawing.Size(21, 13)
        Me.lblT0.TabIndex = 210
        Me.lblT0.Text = "T0"
        Me.lblT0.Visible = False
        '
        'gbOperatorDet
        '
        Me.gbOperatorDet.Controls.Add(Me.BtnVehicle)
        Me.gbOperatorDet.Controls.Add(Me.dtpTransportDate)
        Me.gbOperatorDet.Controls.Add(Me.txtVehicleNo)
        Me.gbOperatorDet.Controls.Add(Me.txtOperatorName)
        Me.gbOperatorDet.Controls.Add(Me.lblVehicleNo)
        Me.gbOperatorDet.Controls.Add(Me.lblColon17)
        Me.gbOperatorDet.Controls.Add(Me.lblColon18)
        Me.gbOperatorDet.Controls.Add(Me.lblOperatorName)
        Me.gbOperatorDet.Controls.Add(Me.lblColon16)
        Me.gbOperatorDet.Controls.Add(Me.lblTransportDate)
        Me.gbOperatorDet.Location = New System.Drawing.Point(1, 178)
        Me.gbOperatorDet.Name = "gbOperatorDet"
        Me.gbOperatorDet.Size = New System.Drawing.Size(288, 101)
        Me.gbOperatorDet.TabIndex = 154
        Me.gbOperatorDet.TabStop = False
        '
        'BtnVehicle
        '
        Me.BtnVehicle.Image = CType(resources.GetObject("BtnVehicle.Image"), System.Drawing.Image)
        Me.BtnVehicle.Location = New System.Drawing.Point(229, 71)
        Me.BtnVehicle.Name = "BtnVehicle"
        Me.BtnVehicle.Size = New System.Drawing.Size(31, 26)
        Me.BtnVehicle.TabIndex = 176
        Me.BtnVehicle.TabStop = False
        Me.BtnVehicle.UseVisualStyleBackColor = True
        '
        'dtpTransportDate
        '
        Me.dtpTransportDate.Location = New System.Drawing.Point(111, 44)
        Me.dtpTransportDate.Name = "dtpTransportDate"
        Me.dtpTransportDate.Size = New System.Drawing.Size(170, 21)
        Me.dtpTransportDate.TabIndex = 155
        '
        'txtVehicleNo
        '
        Me.txtVehicleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleNo.Location = New System.Drawing.Point(111, 74)
        Me.txtVehicleNo.MaxLength = 50
        Me.txtVehicleNo.Name = "txtVehicleNo"
        Me.txtVehicleNo.Size = New System.Drawing.Size(112, 21)
        Me.txtVehicleNo.TabIndex = 156
        '
        'txtOperatorName
        '
        Me.txtOperatorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperatorName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperatorName.Location = New System.Drawing.Point(111, 14)
        Me.txtOperatorName.MaxLength = 50
        Me.txtOperatorName.Name = "txtOperatorName"
        Me.txtOperatorName.Size = New System.Drawing.Size(170, 21)
        Me.txtOperatorName.TabIndex = 154
        '
        'lblVehicleNo
        '
        Me.lblVehicleNo.AutoSize = True
        Me.lblVehicleNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleNo.Location = New System.Drawing.Point(2, 78)
        Me.lblVehicleNo.Name = "lblVehicleNo"
        Me.lblVehicleNo.Size = New System.Drawing.Size(70, 13)
        Me.lblVehicleNo.TabIndex = 119
        Me.lblVehicleNo.Text = "Vehicle No."
        '
        'lblColon17
        '
        Me.lblColon17.AutoSize = True
        Me.lblColon17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon17.Location = New System.Drawing.Point(95, 17)
        Me.lblColon17.Name = "lblColon17"
        Me.lblColon17.Size = New System.Drawing.Size(12, 13)
        Me.lblColon17.TabIndex = 128
        Me.lblColon17.Text = ":"
        '
        'lblColon18
        '
        Me.lblColon18.AutoSize = True
        Me.lblColon18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon18.Location = New System.Drawing.Point(95, 78)
        Me.lblColon18.Name = "lblColon18"
        Me.lblColon18.Size = New System.Drawing.Size(12, 13)
        Me.lblColon18.TabIndex = 121
        Me.lblColon18.Text = ":"
        '
        'lblOperatorName
        '
        Me.lblOperatorName.AutoSize = True
        Me.lblOperatorName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperatorName.Location = New System.Drawing.Point(2, 17)
        Me.lblOperatorName.Name = "lblOperatorName"
        Me.lblOperatorName.Size = New System.Drawing.Size(95, 13)
        Me.lblOperatorName.TabIndex = 125
        Me.lblOperatorName.Text = "Operator Name"
        '
        'lblColon16
        '
        Me.lblColon16.AutoSize = True
        Me.lblColon16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon16.Location = New System.Drawing.Point(95, 49)
        Me.lblColon16.Name = "lblColon16"
        Me.lblColon16.Size = New System.Drawing.Size(12, 13)
        Me.lblColon16.TabIndex = 127
        Me.lblColon16.Text = ":"
        '
        'lblTransportDate
        '
        Me.lblTransportDate.AutoSize = True
        Me.lblTransportDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransportDate.Location = New System.Drawing.Point(2, 49)
        Me.lblTransportDate.Name = "lblTransportDate"
        Me.lblTransportDate.Size = New System.Drawing.Size(92, 13)
        Me.lblTransportDate.TabIndex = 126
        Me.lblTransportDate.Text = "Transport Date"
        '
        'lblColon25
        '
        Me.lblColon25.AutoSize = True
        Me.lblColon25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon25.Location = New System.Drawing.Point(445, 132)
        Me.lblColon25.Name = "lblColon25"
        Me.lblColon25.Size = New System.Drawing.Size(12, 13)
        Me.lblColon25.TabIndex = 211
        Me.lblColon25.Text = ":"
        Me.lblColon25.Visible = False
        '
        'btnSearchSupplier
        '
        Me.btnSearchSupplier.Image = CType(resources.GetObject("btnSearchSupplier.Image"), System.Drawing.Image)
        Me.btnSearchSupplier.Location = New System.Drawing.Point(612, 73)
        Me.btnSearchSupplier.Name = "btnSearchSupplier"
        Me.btnSearchSupplier.Size = New System.Drawing.Size(31, 26)
        Me.btnSearchSupplier.TabIndex = 153
        Me.btnSearchSupplier.TabStop = False
        Me.btnSearchSupplier.UseVisualStyleBackColor = True
        '
        'btnSearchLPONo
        '
        Me.btnSearchLPONo.Image = CType(resources.GetObject("btnSearchLPONo.Image"), System.Drawing.Image)
        Me.btnSearchLPONo.Location = New System.Drawing.Point(612, 43)
        Me.btnSearchLPONo.Name = "btnSearchLPONo"
        Me.btnSearchLPONo.Size = New System.Drawing.Size(31, 26)
        Me.btnSearchLPONo.TabIndex = 147
        Me.btnSearchLPONo.TabStop = False
        Me.btnSearchLPONo.UseVisualStyleBackColor = True
        '
        'btnSearchIPRNo
        '
        Me.btnSearchIPRNo.Image = CType(resources.GetObject("btnSearchIPRNo.Image"), System.Drawing.Image)
        Me.btnSearchIPRNo.Location = New System.Drawing.Point(285, 106)
        Me.btnSearchIPRNo.Name = "btnSearchIPRNo"
        Me.btnSearchIPRNo.Size = New System.Drawing.Size(31, 26)
        Me.btnSearchIPRNo.TabIndex = 149
        Me.btnSearchIPRNo.TabStop = False
        Me.btnSearchIPRNo.UseVisualStyleBackColor = True
        '
        'cbTransType
        '
        Me.cbTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTransType.FormattingEnabled = True
        Me.cbTransType.Items.AddRange(New Object() {"PR", "PO"})
        Me.cbTransType.Location = New System.Drawing.Point(111, 17)
        Me.cbTransType.Name = "cbTransType"
        Me.cbTransType.Size = New System.Drawing.Size(170, 21)
        Me.cbTransType.TabIndex = 141
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(328, 172)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblStatus.TabIndex = 157
        Me.lblStatus.Text = "Status"
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.ForeColor = System.Drawing.Color.Black
        Me.txtRemarks.Location = New System.Drawing.Point(111, 141)
        Me.txtRemarks.MaxLength = 200
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(170, 37)
        Me.txtRemarks.TabIndex = 151
        '
        'lblTransType
        '
        Me.lblTransType.AutoSize = True
        Me.lblTransType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransType.ForeColor = System.Drawing.Color.Red
        Me.lblTransType.Location = New System.Drawing.Point(4, 18)
        Me.lblTransType.Name = "lblTransType"
        Me.lblTransType.Size = New System.Drawing.Size(73, 13)
        Me.lblTransType.TabIndex = 175
        Me.lblTransType.Text = "Trans. Type"
        '
        'lblIPRNo
        '
        Me.lblIPRNo.AutoSize = True
        Me.lblIPRNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIPRNo.ForeColor = System.Drawing.Color.Red
        Me.lblIPRNo.Location = New System.Drawing.Point(4, 111)
        Me.lblIPRNo.Name = "lblIPRNo"
        Me.lblIPRNo.Size = New System.Drawing.Size(45, 13)
        Me.lblIPRNo.TabIndex = 155
        Me.lblIPRNo.Text = "PR No."
        '
        'lblLPONo
        '
        Me.lblLPONo.AutoSize = True
        Me.lblLPONo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLPONo.Location = New System.Drawing.Point(328, 50)
        Me.lblLPONo.Name = "lblLPONo"
        Me.lblLPONo.Size = New System.Drawing.Size(46, 13)
        Me.lblLPONo.TabIndex = 153
        Me.lblLPONo.Text = "PO No."
        '
        'lblStatusDesc
        '
        Me.lblStatusDesc.AutoSize = True
        Me.lblStatusDesc.ForeColor = System.Drawing.Color.Blue
        Me.lblStatusDesc.Location = New System.Drawing.Point(447, 170)
        Me.lblStatusDesc.Name = "lblStatusDesc"
        Me.lblStatusDesc.Size = New System.Drawing.Size(38, 13)
        Me.lblStatusDesc.TabIndex = 173
        Me.lblStatusDesc.Text = "OPEN"
        '
        'lblColon10
        '
        Me.lblColon10.AutoSize = True
        Me.lblColon10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon10.Location = New System.Drawing.Point(95, 140)
        Me.lblColon10.Name = "lblColon10"
        Me.lblColon10.Size = New System.Drawing.Size(12, 13)
        Me.lblColon10.TabIndex = 172
        Me.lblColon10.Text = ":"
        '
        'lblColon9
        '
        Me.lblColon9.AutoSize = True
        Me.lblColon9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon9.Location = New System.Drawing.Point(95, 111)
        Me.lblColon9.Name = "lblColon9"
        Me.lblColon9.Size = New System.Drawing.Size(12, 13)
        Me.lblColon9.TabIndex = 171
        Me.lblColon9.Text = ":"
        '
        'lblColon8
        '
        Me.lblColon8.AutoSize = True
        Me.lblColon8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon8.Location = New System.Drawing.Point(431, 47)
        Me.lblColon8.Name = "lblColon8"
        Me.lblColon8.Size = New System.Drawing.Size(12, 13)
        Me.lblColon8.TabIndex = 170
        Me.lblColon8.Text = ":"
        '
        'dtpIDNDate
        '
        Me.dtpIDNDate.Location = New System.Drawing.Point(449, 17)
        Me.dtpIDNDate.Name = "dtpIDNDate"
        Me.dtpIDNDate.Size = New System.Drawing.Size(158, 21)
        Me.dtpIDNDate.TabIndex = 142
        '
        'txtSupplier
        '
        Me.txtSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupplier.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplier.Location = New System.Drawing.Point(449, 77)
        Me.txtSupplier.MaxLength = 50
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(158, 21)
        Me.txtSupplier.TabIndex = 152
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(431, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 13)
        Me.Label5.TabIndex = 174
        Me.Label5.Text = ":"
        '
        'txtIPRNo
        '
        Me.txtIPRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIPRNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIPRNo.Location = New System.Drawing.Point(111, 110)
        Me.txtIPRNo.MaxLength = 50
        Me.txtIPRNo.Name = "txtIPRNo"
        Me.txtIPRNo.Size = New System.Drawing.Size(170, 21)
        Me.txtIPRNo.TabIndex = 148
        '
        'lblIDNDate
        '
        Me.lblIDNDate.AutoSize = True
        Me.lblIDNDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDNDate.ForeColor = System.Drawing.Color.Red
        Me.lblIDNDate.Location = New System.Drawing.Point(328, 18)
        Me.lblIDNDate.Name = "lblIDNDate"
        Me.lblIDNDate.Size = New System.Drawing.Size(55, 13)
        Me.lblIDNDate.TabIndex = 139
        Me.lblIDNDate.Text = "DN Date"
        '
        'lblGRNNo
        '
        Me.lblGRNNo.AutoSize = True
        Me.lblGRNNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGRNNo.ForeColor = System.Drawing.Color.Black
        Me.lblGRNNo.Location = New System.Drawing.Point(4, 81)
        Me.lblGRNNo.Name = "lblGRNNo"
        Me.lblGRNNo.Size = New System.Drawing.Size(56, 13)
        Me.lblGRNNo.TabIndex = 144
        Me.lblGRNNo.Text = "MRC No."
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(4, 140)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(58, 13)
        Me.lblRemarks.TabIndex = 146
        Me.lblRemarks.Text = "Remarks"
        '
        'txtLPONo
        '
        Me.txtLPONo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLPONo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLPONo.Location = New System.Drawing.Point(449, 47)
        Me.txtLPONo.MaxLength = 50
        Me.txtLPONo.Name = "txtLPONo"
        Me.txtLPONo.Size = New System.Drawing.Size(158, 21)
        Me.txtLPONo.TabIndex = 146
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(95, 18)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(12, 13)
        Me.lblColon1.TabIndex = 163
        Me.lblColon1.Text = ":"
        '
        'lblColon3
        '
        Me.lblColon3.AutoSize = True
        Me.lblColon3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon3.Location = New System.Drawing.Point(95, 49)
        Me.lblColon3.Name = "lblColon3"
        Me.lblColon3.Size = New System.Drawing.Size(12, 13)
        Me.lblColon3.TabIndex = 165
        Me.lblColon3.Text = ":"
        '
        'lblColon5
        '
        Me.lblColon5.AutoSize = True
        Me.lblColon5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon5.Location = New System.Drawing.Point(95, 81)
        Me.lblColon5.Name = "lblColon5"
        Me.lblColon5.Size = New System.Drawing.Size(12, 13)
        Me.lblColon5.TabIndex = 167
        Me.lblColon5.Text = ":"
        '
        'txtGRNNo
        '
        Me.txtGRNNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGRNNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGRNNo.Location = New System.Drawing.Point(111, 79)
        Me.txtGRNNo.MaxLength = 50
        Me.txtGRNNo.Name = "txtGRNNo"
        Me.txtGRNNo.Size = New System.Drawing.Size(170, 21)
        Me.txtGRNNo.TabIndex = 145
        '
        'txtIDNNo
        '
        Me.txtIDNNo.BackColor = System.Drawing.Color.White
        Me.txtIDNNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIDNNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDNNo.Location = New System.Drawing.Point(111, 48)
        Me.txtIDNNo.MaxLength = 50
        Me.txtIDNNo.Name = "txtIDNNo"
        Me.txtIDNNo.Size = New System.Drawing.Size(170, 21)
        Me.txtIDNNo.TabIndex = 143
        '
        'lblIDNNo
        '
        Me.lblIDNNo.AutoSize = True
        Me.lblIDNNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDNNo.ForeColor = System.Drawing.Color.Red
        Me.lblIDNNo.Location = New System.Drawing.Point(4, 49)
        Me.lblIDNNo.Name = "lblIDNNo"
        Me.lblIDNNo.Size = New System.Drawing.Size(47, 13)
        Me.lblIDNNo.TabIndex = 140
        Me.lblIDNNo.Text = "DN No."
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplier.ForeColor = System.Drawing.Color.Red
        Me.lblSupplier.Location = New System.Drawing.Point(328, 79)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(54, 13)
        Me.lblSupplier.TabIndex = 149
        Me.lblSupplier.Text = "Supplier"
        '
        'lblColon2
        '
        Me.lblColon2.AutoSize = True
        Me.lblColon2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon2.Location = New System.Drawing.Point(431, 19)
        Me.lblColon2.Name = "lblColon2"
        Me.lblColon2.Size = New System.Drawing.Size(12, 13)
        Me.lblColon2.TabIndex = 164
        Me.lblColon2.Text = ":"
        '
        'lblColon6
        '
        Me.lblColon6.AutoSize = True
        Me.lblColon6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon6.Location = New System.Drawing.Point(431, 80)
        Me.lblColon6.Name = "lblColon6"
        Me.lblColon6.Size = New System.Drawing.Size(12, 13)
        Me.lblColon6.TabIndex = 168
        Me.lblColon6.Text = ":"
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(868, 266)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 25)
        Me.btnReset.TabIndex = 305
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'gbEdit
        '
        Me.gbEdit.Controls.Add(Me.txtAvailableQty)
        Me.gbEdit.Controls.Add(Me.lblAvailableQty)
        Me.gbEdit.Controls.Add(Me.lbl23)
        Me.gbEdit.Controls.Add(Me.txtReceivedPrice)
        Me.gbEdit.Controls.Add(Me.lblReceivedPrice)
        Me.gbEdit.Controls.Add(Me.Label2)
        Me.gbEdit.Controls.Add(Me.txtUnit)
        Me.gbEdit.Controls.Add(Me.txtPendingQty)
        Me.gbEdit.Controls.Add(Me.txtStockCode)
        Me.gbEdit.Controls.Add(Me.lblUnit)
        Me.gbEdit.Controls.Add(Me.lblStockDesc)
        Me.gbEdit.Controls.Add(Me.Label7)
        Me.gbEdit.Controls.Add(Me.txtReceivedQty)
        Me.gbEdit.Controls.Add(Me.lblPendingQty)
        Me.gbEdit.Controls.Add(Me.Label9)
        Me.gbEdit.Controls.Add(Me.lblStockCode)
        Me.gbEdit.Controls.Add(Me.Label11)
        Me.gbEdit.Controls.Add(Me.txtStockDesc)
        Me.gbEdit.Controls.Add(Me.Label12)
        Me.gbEdit.Controls.Add(Me.lblReceivedQty)
        Me.gbEdit.Controls.Add(Me.Label14)
        Me.gbEdit.Location = New System.Drawing.Point(667, 8)
        Me.gbEdit.Name = "gbEdit"
        Me.gbEdit.Size = New System.Drawing.Size(304, 254)
        Me.gbEdit.TabIndex = 300
        Me.gbEdit.TabStop = False
        Me.gbEdit.Text = "DN Details"
        '
        'txtAvailableQty
        '
        Me.txtAvailableQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAvailableQty.Enabled = False
        Me.txtAvailableQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvailableQty.Location = New System.Drawing.Point(126, 113)
        Me.txtAvailableQty.MaxLength = 50
        Me.txtAvailableQty.Name = "txtAvailableQty"
        Me.txtAvailableQty.ReadOnly = True
        Me.txtAvailableQty.Size = New System.Drawing.Size(144, 21)
        Me.txtAvailableQty.TabIndex = 204
        '
        'lblAvailableQty
        '
        Me.lblAvailableQty.AutoSize = True
        Me.lblAvailableQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailableQty.ForeColor = System.Drawing.Color.Black
        Me.lblAvailableQty.Location = New System.Drawing.Point(3, 114)
        Me.lblAvailableQty.Name = "lblAvailableQty"
        Me.lblAvailableQty.Size = New System.Drawing.Size(83, 13)
        Me.lblAvailableQty.TabIndex = 207
        Me.lblAvailableQty.Text = "Available Qty"
        '
        'lbl23
        '
        Me.lbl23.AutoSize = True
        Me.lbl23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl23.Location = New System.Drawing.Point(108, 113)
        Me.lbl23.Name = "lbl23"
        Me.lbl23.Size = New System.Drawing.Size(12, 13)
        Me.lbl23.TabIndex = 208
        Me.lbl23.Text = ":"
        '
        'txtReceivedPrice
        '
        Me.txtReceivedPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceivedPrice.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceivedPrice.Location = New System.Drawing.Point(126, 203)
        Me.txtReceivedPrice.MaxLength = 50
        Me.txtReceivedPrice.Name = "txtReceivedPrice"
        Me.txtReceivedPrice.Size = New System.Drawing.Size(144, 21)
        Me.txtReceivedPrice.TabIndex = 303
        Me.txtReceivedPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtReceivedPrice.Visible = False
        '
        'lblReceivedPrice
        '
        Me.lblReceivedPrice.AutoSize = True
        Me.lblReceivedPrice.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceivedPrice.ForeColor = System.Drawing.Color.Red
        Me.lblReceivedPrice.Location = New System.Drawing.Point(3, 202)
        Me.lblReceivedPrice.Name = "lblReceivedPrice"
        Me.lblReceivedPrice.Size = New System.Drawing.Size(91, 13)
        Me.lblReceivedPrice.TabIndex = 178
        Me.lblReceivedPrice.Text = "Received Price"
        Me.lblReceivedPrice.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(108, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 13)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = ":"
        Me.Label2.Visible = False
        '
        'txtUnit
        '
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(126, 173)
        Me.txtUnit.MaxLength = 50
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(144, 21)
        Me.txtUnit.TabIndex = 302
        '
        'txtPendingQty
        '
        Me.txtPendingQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPendingQty.Enabled = False
        Me.txtPendingQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPendingQty.Location = New System.Drawing.Point(126, 81)
        Me.txtPendingQty.MaxLength = 50
        Me.txtPendingQty.Name = "txtPendingQty"
        Me.txtPendingQty.ReadOnly = True
        Me.txtPendingQty.Size = New System.Drawing.Size(144, 21)
        Me.txtPendingQty.TabIndex = 203
        '
        'txtStockCode
        '
        Me.txtStockCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockCode.Enabled = False
        Me.txtStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockCode.Location = New System.Drawing.Point(126, 16)
        Me.txtStockCode.MaxLength = 50
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.ReadOnly = True
        Me.txtStockCode.Size = New System.Drawing.Size(144, 21)
        Me.txtStockCode.TabIndex = 201
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnit.ForeColor = System.Drawing.Color.Red
        Me.lblUnit.Location = New System.Drawing.Point(3, 172)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(29, 13)
        Me.lblUnit.TabIndex = 169
        Me.lblUnit.Text = "Unit"
        '
        'lblStockDesc
        '
        Me.lblStockDesc.AutoSize = True
        Me.lblStockDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockDesc.Location = New System.Drawing.Point(3, 50)
        Me.lblStockDesc.Name = "lblStockDesc"
        Me.lblStockDesc.Size = New System.Drawing.Size(75, 13)
        Me.lblStockDesc.TabIndex = 168
        Me.lblStockDesc.Text = "Stock Desc."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(108, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 13)
        Me.Label7.TabIndex = 174
        Me.Label7.Text = ":"
        '
        'txtReceivedQty
        '
        Me.txtReceivedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceivedQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceivedQty.Location = New System.Drawing.Point(126, 144)
        Me.txtReceivedQty.MaxLength = 50
        Me.txtReceivedQty.Name = "txtReceivedQty"
        Me.txtReceivedQty.Size = New System.Drawing.Size(144, 21)
        Me.txtReceivedQty.TabIndex = 301
        Me.txtReceivedQty.Text = "0"
        '
        'lblPendingQty
        '
        Me.lblPendingQty.AutoSize = True
        Me.lblPendingQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingQty.ForeColor = System.Drawing.Color.Black
        Me.lblPendingQty.Location = New System.Drawing.Point(3, 81)
        Me.lblPendingQty.Name = "lblPendingQty"
        Me.lblPendingQty.Size = New System.Drawing.Size(76, 13)
        Me.lblPendingQty.TabIndex = 167
        Me.lblPendingQty.Text = "Pending Qty"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(108, 174)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 13)
        Me.Label9.TabIndex = 175
        Me.Label9.Text = ":"
        '
        'lblStockCode
        '
        Me.lblStockCode.AutoSize = True
        Me.lblStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockCode.ForeColor = System.Drawing.Color.Black
        Me.lblStockCode.Location = New System.Drawing.Point(3, 18)
        Me.lblStockCode.Name = "lblStockCode"
        Me.lblStockCode.Size = New System.Drawing.Size(73, 13)
        Me.lblStockCode.TabIndex = 163
        Me.lblStockCode.Text = "Stock Code"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(108, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 13)
        Me.Label11.TabIndex = 173
        Me.Label11.Text = ":"
        '
        'txtStockDesc
        '
        Me.txtStockDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockDesc.Enabled = False
        Me.txtStockDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockDesc.Location = New System.Drawing.Point(126, 49)
        Me.txtStockDesc.MaxLength = 50
        Me.txtStockDesc.Name = "txtStockDesc"
        Me.txtStockDesc.ReadOnly = True
        Me.txtStockDesc.Size = New System.Drawing.Size(144, 21)
        Me.txtStockDesc.TabIndex = 202
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(108, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 13)
        Me.Label12.TabIndex = 171
        Me.Label12.Text = ":"
        '
        'lblReceivedQty
        '
        Me.lblReceivedQty.AutoSize = True
        Me.lblReceivedQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceivedQty.ForeColor = System.Drawing.Color.Red
        Me.lblReceivedQty.Location = New System.Drawing.Point(3, 144)
        Me.lblReceivedQty.Name = "lblReceivedQty"
        Me.lblReceivedQty.Size = New System.Drawing.Size(83, 13)
        Me.lblReceivedQty.TabIndex = 165
        Me.lblReceivedQty.Text = "Received Qty"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(108, 144)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 13)
        Me.Label14.TabIndex = 172
        Me.Label14.Text = ":"
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(767, 266)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(95, 25)
        Me.btnAdd.TabIndex = 304
        Me.btnAdd.Text = "Update"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'tcEMDN
        '
        Me.tcEMDN.Controls.Add(Me.tbpgEMDNAdd)
        Me.tcEMDN.Controls.Add(Me.tbpgEMDNView)
        Me.tcEMDN.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcEMDN.Location = New System.Drawing.Point(0, 0)
        Me.tcEMDN.Name = "tcEMDN"
        Me.tcEMDN.SelectedIndex = 0
        Me.tcEMDN.Size = New System.Drawing.Size(989, 550)
        Me.tcEMDN.TabIndex = 0
        '
        'tbpgEMDNAdd
        '
        Me.tbpgEMDNAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgEMDNAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgEMDNAdd.Controls.Add(Me.plEstateMillDeliveryNote)
        Me.tbpgEMDNAdd.Location = New System.Drawing.Point(4, 22)
        Me.tbpgEMDNAdd.Name = "tbpgEMDNAdd"
        Me.tbpgEMDNAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgEMDNAdd.Size = New System.Drawing.Size(981, 524)
        Me.tbpgEMDNAdd.TabIndex = 0
        Me.tbpgEMDNAdd.Text = "DN"
        Me.tbpgEMDNAdd.UseVisualStyleBackColor = True
        '
        'tbpgEMDNView
        '
        Me.tbpgEMDNView.Controls.Add(Me.plITNOutView)
        Me.tbpgEMDNView.Location = New System.Drawing.Point(4, 22)
        Me.tbpgEMDNView.Name = "tbpgEMDNView"
        Me.tbpgEMDNView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgEMDNView.Size = New System.Drawing.Size(981, 524)
        Me.tbpgEMDNView.TabIndex = 1
        Me.tbpgEMDNView.Text = "View"
        Me.tbpgEMDNView.UseVisualStyleBackColor = True
        '
        'plITNOutView
        '
        Me.plITNOutView.AutoScroll = True
        Me.plITNOutView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plITNOutView.Controls.Add(Me.dgvIDNView)
        Me.plITNOutView.Controls.Add(Me.plEMDNSearch)
        Me.plITNOutView.Dock = System.Windows.Forms.DockStyle.Top
        Me.plITNOutView.Location = New System.Drawing.Point(3, 3)
        Me.plITNOutView.Name = "plITNOutView"
        Me.plITNOutView.Size = New System.Drawing.Size(975, 525)
        Me.plITNOutView.TabIndex = 2
        '
        'dgvIDNView
        '
        Me.dgvIDNView.AllowUserToAddRows = False
        Me.dgvIDNView.AllowUserToDeleteRows = False
        Me.dgvIDNView.AllowUserToOrderColumns = True
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        Me.dgvIDNView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvIDNView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvIDNView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvIDNView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIDNView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIDNView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIDNView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvIDNView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclSTEstMillDeliveryID, Me.dgclSTPRID, Me.dgclSTLPOID, Me.dgclIDNDate, Me.dgclTransType, Me.dgclIDNNo, Me.dgclGRNNo, Me.dgclIPRNo, Me.dgclLPONo, Me.dgclPONo, Me.dgclDeliverySource, Me.dgclSupplier, Me.dgclSupplierID, Me.dgclStatus, Me.dgclOperatorName, Me.dgclTransportDate, Me.dgclVehicleNo, Me.dgclRemarks, Me.dgclRejectedReason, Me.dgclViewReport})
        Me.dgvIDNView.ContextMenuStrip = Me.cmsEMDNView
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIDNView.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvIDNView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIDNView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvIDNView.EnableHeadersVisualStyles = False
        Me.dgvIDNView.GridColor = System.Drawing.Color.Gray
        Me.dgvIDNView.Location = New System.Drawing.Point(0, 212)
        Me.dgvIDNView.Name = "dgvIDNView"
        Me.dgvIDNView.ReadOnly = True
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIDNView.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvIDNView.RowHeadersVisible = False
        Me.dgvIDNView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvIDNView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIDNView.ShowCellErrors = False
        Me.dgvIDNView.Size = New System.Drawing.Size(973, 311)
        Me.dgvIDNView.TabIndex = 16
        Me.dgvIDNView.TabStop = False
        '
        'dgclSTEstMillDeliveryID
        '
        Me.dgclSTEstMillDeliveryID.DataPropertyName = "STEstMillDeliveryID"
        Me.dgclSTEstMillDeliveryID.HeaderText = "Estate Mill Delivery ID"
        Me.dgclSTEstMillDeliveryID.Name = "dgclSTEstMillDeliveryID"
        Me.dgclSTEstMillDeliveryID.ReadOnly = True
        Me.dgclSTEstMillDeliveryID.Visible = False
        Me.dgclSTEstMillDeliveryID.Width = 158
        '
        'dgclSTPRID
        '
        Me.dgclSTPRID.DataPropertyName = "STIPRID"
        Me.dgclSTPRID.HeaderText = "STPRID"
        Me.dgclSTPRID.Name = "dgclSTPRID"
        Me.dgclSTPRID.ReadOnly = True
        Me.dgclSTPRID.Visible = False
        Me.dgclSTPRID.Width = 80
        '
        'dgclSTLPOID
        '
        Me.dgclSTLPOID.DataPropertyName = "STLPOID"
        Me.dgclSTLPOID.HeaderText = "STPOID"
        Me.dgclSTLPOID.Name = "dgclSTLPOID"
        Me.dgclSTLPOID.ReadOnly = True
        Me.dgclSTLPOID.Visible = False
        Me.dgclSTLPOID.Width = 82
        '
        'dgclIDNDate
        '
        Me.dgclIDNDate.DataPropertyName = "IDNDate"
        Me.dgclIDNDate.HeaderText = "DN Date"
        Me.dgclIDNDate.Name = "dgclIDNDate"
        Me.dgclIDNDate.ReadOnly = True
        Me.dgclIDNDate.Width = 79
        '
        'dgclTransType
        '
        Me.dgclTransType.DataPropertyName = "LPOorIPR"
        Me.dgclTransType.HeaderText = "Trans. Type"
        Me.dgclTransType.Name = "dgclTransType"
        Me.dgclTransType.ReadOnly = True
        Me.dgclTransType.Width = 97
        '
        'dgclIDNNo
        '
        Me.dgclIDNNo.DataPropertyName = "IDNNo"
        Me.dgclIDNNo.HeaderText = "DN No."
        Me.dgclIDNNo.Name = "dgclIDNNo"
        Me.dgclIDNNo.ReadOnly = True
        Me.dgclIDNNo.Width = 71
        '
        'dgclGRNNo
        '
        Me.dgclGRNNo.DataPropertyName = "GRNNo"
        Me.dgclGRNNo.HeaderText = "MRC No."
        Me.dgclGRNNo.Name = "dgclGRNNo"
        Me.dgclGRNNo.ReadOnly = True
        Me.dgclGRNNo.Width = 80
        '
        'dgclIPRNo
        '
        Me.dgclIPRNo.DataPropertyName = "IPRNo"
        Me.dgclIPRNo.HeaderText = "IPR No."
        Me.dgclIPRNo.Name = "dgclIPRNo"
        Me.dgclIPRNo.ReadOnly = True
        Me.dgclIPRNo.Width = 74
        '
        'dgclLPONo
        '
        Me.dgclLPONo.DataPropertyName = "LPONo"
        Me.dgclLPONo.HeaderText = "PO No."
        Me.dgclLPONo.Name = "dgclLPONo"
        Me.dgclLPONo.ReadOnly = True
        Me.dgclLPONo.Width = 70
        '
        'dgclPONo
        '
        Me.dgclPONo.DataPropertyName = "PONo"
        Me.dgclPONo.HeaderText = "PO No."
        Me.dgclPONo.Name = "dgclPONo"
        Me.dgclPONo.ReadOnly = True
        Me.dgclPONo.Width = 70
        '
        'dgclDeliverySource
        '
        Me.dgclDeliverySource.DataPropertyName = "DeliverySource"
        Me.dgclDeliverySource.HeaderText = "Delivery Source"
        Me.dgclDeliverySource.Name = "dgclDeliverySource"
        Me.dgclDeliverySource.ReadOnly = True
        Me.dgclDeliverySource.Width = 123
        '
        'dgclSupplier
        '
        Me.dgclSupplier.DataPropertyName = "SupplierName"
        Me.dgclSupplier.HeaderText = "Supplier"
        Me.dgclSupplier.Name = "dgclSupplier"
        Me.dgclSupplier.ReadOnly = True
        Me.dgclSupplier.Width = 78
        '
        'dgclSupplierID
        '
        Me.dgclSupplierID.DataPropertyName = "SupplierID"
        Me.dgclSupplierID.HeaderText = "SupplierID"
        Me.dgclSupplierID.Name = "dgclSupplierID"
        Me.dgclSupplierID.ReadOnly = True
        Me.dgclSupplierID.Visible = False
        Me.dgclSupplierID.Width = 92
        '
        'dgclStatus
        '
        Me.dgclStatus.DataPropertyName = "Status"
        Me.dgclStatus.HeaderText = "Status"
        Me.dgclStatus.Name = "dgclStatus"
        Me.dgclStatus.ReadOnly = True
        Me.dgclStatus.Width = 67
        '
        'dgclOperatorName
        '
        Me.dgclOperatorName.DataPropertyName = "OperatorName"
        Me.dgclOperatorName.HeaderText = "Operator Name"
        Me.dgclOperatorName.Name = "dgclOperatorName"
        Me.dgclOperatorName.ReadOnly = True
        Me.dgclOperatorName.Visible = False
        Me.dgclOperatorName.Width = 119
        '
        'dgclTransportDate
        '
        Me.dgclTransportDate.DataPropertyName = "TransportDate"
        Me.dgclTransportDate.HeaderText = "Transport Date"
        Me.dgclTransportDate.Name = "dgclTransportDate"
        Me.dgclTransportDate.ReadOnly = True
        Me.dgclTransportDate.Visible = False
        Me.dgclTransportDate.Width = 117
        '
        'dgclVehicleNo
        '
        Me.dgclVehicleNo.DataPropertyName = "VehicleNo"
        Me.dgclVehicleNo.HeaderText = "Vehicle No."
        Me.dgclVehicleNo.Name = "dgclVehicleNo"
        Me.dgclVehicleNo.ReadOnly = True
        Me.dgclVehicleNo.Visible = False
        Me.dgclVehicleNo.Width = 95
        '
        'dgclRemarks
        '
        Me.dgclRemarks.DataPropertyName = "Remarks"
        Me.dgclRemarks.HeaderText = "Remarks"
        Me.dgclRemarks.Name = "dgclRemarks"
        Me.dgclRemarks.ReadOnly = True
        Me.dgclRemarks.Visible = False
        Me.dgclRemarks.Width = 82
        '
        'dgclRejectedReason
        '
        Me.dgclRejectedReason.DataPropertyName = "RejectedReason"
        Me.dgclRejectedReason.HeaderText = "Rejected Reason"
        Me.dgclRejectedReason.Name = "dgclRejectedReason"
        Me.dgclRejectedReason.ReadOnly = True
        Me.dgclRejectedReason.Visible = False
        Me.dgclRejectedReason.Width = 127
        '
        'dgclViewReport
        '
        Me.dgclViewReport.HeaderText = "View Report"
        Me.dgclViewReport.Name = "dgclViewReport"
        Me.dgclViewReport.ReadOnly = True
        Me.dgclViewReport.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgclViewReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgclViewReport.Text = "View Report"
        Me.dgclViewReport.UseColumnTextForButtonValue = True
        '
        'cmsEMDNView
        '
        Me.cmsEMDNView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditUpdateToolStripMenuItem1, Me.DeleteToolStripMenuItem})
        Me.cmsEMDNView.Name = "cmsEMDNView"
        Me.cmsEMDNView.Size = New System.Drawing.Size(144, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditUpdateToolStripMenuItem1
        '
        Me.EditUpdateToolStripMenuItem1.Image = CType(resources.GetObject("EditUpdateToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.EditUpdateToolStripMenuItem1.Name = "EditUpdateToolStripMenuItem1"
        Me.EditUpdateToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
        Me.EditUpdateToolStripMenuItem1.Text = "Edit / Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'plEMDNSearch
        '
        Me.plEMDNSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plEMDNSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plEMDNSearch.BorderColor = System.Drawing.Color.Gray
        Me.plEMDNSearch.CaptionColorOne = System.Drawing.Color.White
        Me.plEMDNSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plEMDNSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plEMDNSearch.CaptionSize = 40
        Me.plEMDNSearch.CaptionText = "Search EMDN  Details"
        Me.plEMDNSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.plEMDNSearch.Controls.Add(Me.cbviewDeliverySource)
        Me.plEMDNSearch.Controls.Add(Me.txtviewPONo)
        Me.plEMDNSearch.Controls.Add(Me.rbtnLPONo)
        Me.plEMDNSearch.Controls.Add(Me.rbtnIPR)
        Me.plEMDNSearch.Controls.Add(Me.txtviewSupplier)
        Me.plEMDNSearch.Controls.Add(Me.txtviewGRNNo)
        Me.plEMDNSearch.Controls.Add(Me.txtviewIDNNo)
        Me.plEMDNSearch.Controls.Add(Me.cbviewLPONo)
        Me.plEMDNSearch.Controls.Add(Me.cbviewIPRNo)
        Me.plEMDNSearch.Controls.Add(Me.cbviewTransType)
        Me.plEMDNSearch.Controls.Add(Me.lblviewSupplier)
        Me.plEMDNSearch.Controls.Add(Me.lblviewPONo)
        Me.plEMDNSearch.Controls.Add(Me.lblviewDeliverySource)
        Me.plEMDNSearch.Controls.Add(Me.lblviewGRNNo)
        Me.plEMDNSearch.Controls.Add(Me.lblsearchBy)
        Me.plEMDNSearch.Controls.Add(Me.chkIDNDate)
        Me.plEMDNSearch.Controls.Add(Me.dtpviewIDNDate)
        Me.plEMDNSearch.Controls.Add(Me.lblviewIDNDate)
        Me.plEMDNSearch.Controls.Add(Me.btnviewReport)
        Me.plEMDNSearch.Controls.Add(Me.lblviewIDNNo)
        Me.plEMDNSearch.Controls.Add(Me.btnSearch)
        Me.plEMDNSearch.Controls.Add(Me.cbviewStatus)
        Me.plEMDNSearch.Controls.Add(Me.lblviewTransType)
        Me.plEMDNSearch.Controls.Add(Me.lblviewMainstatus)
        Me.plEMDNSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plEMDNSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plEMDNSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plEMDNSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.plEMDNSearch.ForeColor = System.Drawing.Color.Black
        Me.plEMDNSearch.Location = New System.Drawing.Point(0, 0)
        Me.plEMDNSearch.Name = "plEMDNSearch"
        Me.plEMDNSearch.Size = New System.Drawing.Size(973, 212)
        Me.plEMDNSearch.TabIndex = 146
        '
        'cbviewDeliverySource
        '
        Me.cbviewDeliverySource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbviewDeliverySource.FormattingEnabled = True
        Me.cbviewDeliverySource.Items.AddRange(New Object() {"Consignment", "Samarinda", "SELECT ALL"})
        Me.cbviewDeliverySource.Location = New System.Drawing.Point(38, 185)
        Me.cbviewDeliverySource.MaxLength = 50
        Me.cbviewDeliverySource.Name = "cbviewDeliverySource"
        Me.cbviewDeliverySource.Size = New System.Drawing.Size(165, 21)
        Me.cbviewDeliverySource.TabIndex = 11
        Me.cbviewDeliverySource.Visible = False
        '
        'txtviewPONo
        '
        Me.txtviewPONo.Location = New System.Drawing.Point(225, 132)
        Me.txtviewPONo.Name = "txtviewPONo"
        Me.txtviewPONo.Size = New System.Drawing.Size(165, 21)
        Me.txtviewPONo.TabIndex = 10
        '
        'rbtnLPONo
        '
        Me.rbtnLPONo.AutoSize = True
        Me.rbtnLPONo.Location = New System.Drawing.Point(76, 109)
        Me.rbtnLPONo.Name = "rbtnLPONo"
        Me.rbtnLPONo.Size = New System.Drawing.Size(64, 17)
        Me.rbtnLPONo.TabIndex = 8
        Me.rbtnLPONo.TabStop = True
        Me.rbtnLPONo.Text = "PO No."
        Me.rbtnLPONo.UseVisualStyleBackColor = True
        '
        'rbtnIPR
        '
        Me.rbtnIPR.AutoSize = True
        Me.rbtnIPR.Location = New System.Drawing.Point(828, 53)
        Me.rbtnIPR.Name = "rbtnIPR"
        Me.rbtnIPR.Size = New System.Drawing.Size(63, 17)
        Me.rbtnIPR.TabIndex = 6
        Me.rbtnIPR.TabStop = True
        Me.rbtnIPR.Text = "PR No."
        Me.rbtnIPR.UseVisualStyleBackColor = True
        '
        'txtviewSupplier
        '
        Me.txtviewSupplier.Location = New System.Drawing.Point(411, 132)
        Me.txtviewSupplier.Name = "txtviewSupplier"
        Me.txtviewSupplier.Size = New System.Drawing.Size(165, 21)
        Me.txtviewSupplier.TabIndex = 12
        '
        'txtviewGRNNo
        '
        Me.txtviewGRNNo.Location = New System.Drawing.Point(411, 79)
        Me.txtviewGRNNo.Name = "txtviewGRNNo"
        Me.txtviewGRNNo.Size = New System.Drawing.Size(165, 21)
        Me.txtviewGRNNo.TabIndex = 4
        '
        'txtviewIDNNo
        '
        Me.txtviewIDNNo.Location = New System.Drawing.Point(225, 78)
        Me.txtviewIDNNo.Name = "txtviewIDNNo"
        Me.txtviewIDNNo.Size = New System.Drawing.Size(165, 21)
        Me.txtviewIDNNo.TabIndex = 3
        '
        'cbviewLPONo
        '
        Me.cbviewLPONo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbviewLPONo.FormattingEnabled = True
        Me.cbviewLPONo.Items.AddRange(New Object() {"--SELECT--"})
        Me.cbviewLPONo.Location = New System.Drawing.Point(38, 132)
        Me.cbviewLPONo.MaxLength = 50
        Me.cbviewLPONo.Name = "cbviewLPONo"
        Me.cbviewLPONo.Size = New System.Drawing.Size(165, 21)
        Me.cbviewLPONo.TabIndex = 9
        '
        'cbviewIPRNo
        '
        Me.cbviewIPRNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbviewIPRNo.FormattingEnabled = True
        Me.cbviewIPRNo.Items.AddRange(New Object() {"--SELECT--"})
        Me.cbviewIPRNo.Location = New System.Drawing.Point(785, 77)
        Me.cbviewIPRNo.MaxLength = 50
        Me.cbviewIPRNo.Name = "cbviewIPRNo"
        Me.cbviewIPRNo.Size = New System.Drawing.Size(165, 21)
        Me.cbviewIPRNo.TabIndex = 7
        '
        'cbviewTransType
        '
        Me.cbviewTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbviewTransType.FormattingEnabled = True
        Me.cbviewTransType.Items.AddRange(New Object() {"PR", "PO"})
        Me.cbviewTransType.Location = New System.Drawing.Point(598, 77)
        Me.cbviewTransType.MaxLength = 50
        Me.cbviewTransType.Name = "cbviewTransType"
        Me.cbviewTransType.Size = New System.Drawing.Size(165, 21)
        Me.cbviewTransType.TabIndex = 5
        '
        'lblviewSupplier
        '
        Me.lblviewSupplier.AutoSize = True
        Me.lblviewSupplier.ForeColor = System.Drawing.Color.Black
        Me.lblviewSupplier.Location = New System.Drawing.Point(452, 113)
        Me.lblviewSupplier.Name = "lblviewSupplier"
        Me.lblviewSupplier.Size = New System.Drawing.Size(54, 13)
        Me.lblviewSupplier.TabIndex = 126
        Me.lblviewSupplier.Text = "Supplier"
        '
        'lblviewPONo
        '
        Me.lblviewPONo.AutoSize = True
        Me.lblviewPONo.ForeColor = System.Drawing.Color.Black
        Me.lblviewPONo.Location = New System.Drawing.Point(280, 113)
        Me.lblviewPONo.Name = "lblviewPONo"
        Me.lblviewPONo.Size = New System.Drawing.Size(46, 13)
        Me.lblviewPONo.TabIndex = 124
        Me.lblviewPONo.Text = "PO No."
        '
        'lblviewDeliverySource
        '
        Me.lblviewDeliverySource.AutoSize = True
        Me.lblviewDeliverySource.ForeColor = System.Drawing.Color.Black
        Me.lblviewDeliverySource.Location = New System.Drawing.Point(82, 166)
        Me.lblviewDeliverySource.Name = "lblviewDeliverySource"
        Me.lblviewDeliverySource.Size = New System.Drawing.Size(99, 13)
        Me.lblviewDeliverySource.TabIndex = 121
        Me.lblviewDeliverySource.Text = "Delivery Source"
        Me.lblviewDeliverySource.Visible = False
        '
        'lblviewGRNNo
        '
        Me.lblviewGRNNo.AutoSize = True
        Me.lblviewGRNNo.ForeColor = System.Drawing.Color.Black
        Me.lblviewGRNNo.Location = New System.Drawing.Point(455, 57)
        Me.lblviewGRNNo.Name = "lblviewGRNNo"
        Me.lblviewGRNNo.Size = New System.Drawing.Size(56, 13)
        Me.lblviewGRNNo.TabIndex = 116
        Me.lblviewGRNNo.Text = "MRC No."
        '
        'lblsearchBy
        '
        Me.lblsearchBy.AutoSize = True
        Me.lblsearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblsearchBy.Location = New System.Drawing.Point(1, 41)
        Me.lblsearchBy.Name = "lblsearchBy"
        Me.lblsearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchBy.TabIndex = 54
        Me.lblsearchBy.Text = "Search By"
        '
        'chkIDNDate
        '
        Me.chkIDNDate.AutoSize = True
        Me.chkIDNDate.Location = New System.Drawing.Point(76, 57)
        Me.chkIDNDate.Name = "chkIDNDate"
        Me.chkIDNDate.Size = New System.Drawing.Size(15, 14)
        Me.chkIDNDate.TabIndex = 1
        Me.chkIDNDate.UseVisualStyleBackColor = True
        '
        'dtpviewIDNDate
        '
        Me.dtpviewIDNDate.Enabled = False
        Me.dtpviewIDNDate.Location = New System.Drawing.Point(38, 77)
        Me.dtpviewIDNDate.Name = "dtpviewIDNDate"
        Me.dtpviewIDNDate.Size = New System.Drawing.Size(165, 21)
        Me.dtpviewIDNDate.TabIndex = 2
        '
        'lblviewIDNDate
        '
        Me.lblviewIDNDate.AutoSize = True
        Me.lblviewIDNDate.ForeColor = System.Drawing.Color.Black
        Me.lblviewIDNDate.Location = New System.Drawing.Point(97, 57)
        Me.lblviewIDNDate.Name = "lblviewIDNDate"
        Me.lblviewIDNDate.Size = New System.Drawing.Size(55, 13)
        Me.lblviewIDNDate.TabIndex = 40
        Me.lblviewIDNDate.Text = "DN Date"
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(822, 170)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(128, 25)
        Me.btnviewReport.TabIndex = 15
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'lblviewIDNNo
        '
        Me.lblviewIDNNo.AutoSize = True
        Me.lblviewIDNNo.ForeColor = System.Drawing.Color.Black
        Me.lblviewIDNNo.Location = New System.Drawing.Point(280, 57)
        Me.lblviewIDNNo.Name = "lblviewIDNNo"
        Me.lblviewIDNNo.Size = New System.Drawing.Size(47, 13)
        Me.lblviewIDNNo.TabIndex = 17
        Me.lblviewIDNNo.Text = "DN No."
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(688, 170)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 14
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cbviewStatus
        '
        Me.cbviewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbviewStatus.FormattingEnabled = True
        Me.cbviewStatus.Items.AddRange(New Object() {"OPEN", "APPROVED", "REJECTED", "SELECT ALL"})
        Me.cbviewStatus.Location = New System.Drawing.Point(598, 132)
        Me.cbviewStatus.MaxLength = 50
        Me.cbviewStatus.Name = "cbviewStatus"
        Me.cbviewStatus.Size = New System.Drawing.Size(165, 21)
        Me.cbviewStatus.TabIndex = 13
        '
        'lblviewTransType
        '
        Me.lblviewTransType.AutoSize = True
        Me.lblviewTransType.ForeColor = System.Drawing.Color.Black
        Me.lblviewTransType.Location = New System.Drawing.Point(639, 57)
        Me.lblviewTransType.Name = "lblviewTransType"
        Me.lblviewTransType.Size = New System.Drawing.Size(73, 13)
        Me.lblviewTransType.TabIndex = 18
        Me.lblviewTransType.Text = "Trans. Type"
        '
        'lblviewMainstatus
        '
        Me.lblviewMainstatus.AutoSize = True
        Me.lblviewMainstatus.ForeColor = System.Drawing.Color.Black
        Me.lblviewMainstatus.Location = New System.Drawing.Point(656, 113)
        Me.lblviewMainstatus.Name = "lblviewMainstatus"
        Me.lblviewMainstatus.Size = New System.Drawing.Size(43, 13)
        Me.lblviewMainstatus.TabIndex = 22
        Me.lblviewMainstatus.Text = "Status"
        '
        'EstateMillDeliveryNoteFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(990, 548)
        Me.Controls.Add(Me.tcEMDN)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "EstateMillDeliveryNoteFrm"
        Me.Text = "EstateMillDeliveryNoteFrm"
        Me.plEstateMillDeliveryNote.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.gbDetails.ResumeLayout(False)
        Me.gbDetails.PerformLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsEMDN.ResumeLayout(False)
        Me.gbIDN.ResumeLayout(False)
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.grpApproval.ResumeLayout(False)
        Me.grpApproval.PerformLayout()
        Me.gbOperatorDet.ResumeLayout(False)
        Me.gbOperatorDet.PerformLayout()
        Me.gbEdit.ResumeLayout(False)
        Me.gbEdit.PerformLayout()
        Me.tcEMDN.ResumeLayout(False)
        Me.tbpgEMDNAdd.ResumeLayout(False)
        Me.tbpgEMDNView.ResumeLayout(False)
        Me.plITNOutView.ResumeLayout(False)
        CType(Me.dgvIDNView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsEMDNView.ResumeLayout(False)
        Me.plEMDNSearch.ResumeLayout(False)
        Me.plEMDNSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plEstateMillDeliveryNote As System.Windows.Forms.Panel
    Friend WithEvents gbDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents cmsEMDN As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tcEMDN As System.Windows.Forms.TabControl
    Friend WithEvents tbpgEMDNAdd As System.Windows.Forms.TabPage
    Friend WithEvents tbpgEMDNView As System.Windows.Forms.TabPage
    Friend WithEvents plITNOutView As System.Windows.Forms.Panel
    Friend WithEvents dgvIDNView As System.Windows.Forms.DataGridView
    Friend WithEvents plEMDNSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents chkIDNDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpviewIDNDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewIDNDate As System.Windows.Forms.Label
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents lblviewIDNNo As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cbviewStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblviewTransType As System.Windows.Forms.Label
    Friend WithEvents lblviewMainstatus As System.Windows.Forms.Label
    Friend WithEvents lblviewGRNNo As System.Windows.Forms.Label
    Friend WithEvents lblviewSupplier As System.Windows.Forms.Label
    Friend WithEvents lblviewPONo As System.Windows.Forms.Label
    Friend WithEvents lblviewDeliverySource As System.Windows.Forms.Label
    Friend WithEvents cbviewIPRNo As System.Windows.Forms.ComboBox
    Friend WithEvents cbviewTransType As System.Windows.Forms.ComboBox
    Friend WithEvents cbviewLPONo As System.Windows.Forms.ComboBox
    Friend WithEvents cmsEMDNView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUpdateToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbMain As System.Windows.Forms.GroupBox
    Friend WithEvents gbIDN As System.Windows.Forms.GroupBox
    Friend WithEvents gbOperatorDet As System.Windows.Forms.GroupBox
    Friend WithEvents dtpTransportDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtVehicleNo As System.Windows.Forms.TextBox
    Friend WithEvents txtOperatorName As System.Windows.Forms.TextBox
    Friend WithEvents lblVehicleNo As System.Windows.Forms.Label
    Friend WithEvents lblColon17 As System.Windows.Forms.Label
    Friend WithEvents lblColon18 As System.Windows.Forms.Label
    Friend WithEvents lblOperatorName As System.Windows.Forms.Label
    Friend WithEvents lblColon16 As System.Windows.Forms.Label
    Friend WithEvents lblTransportDate As System.Windows.Forms.Label
    Friend WithEvents btnSearchSupplier As System.Windows.Forms.Button
    Friend WithEvents btnSearchLPONo As System.Windows.Forms.Button
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchIPRNo As System.Windows.Forms.Button
    Friend WithEvents cbDeliveySource As System.Windows.Forms.ComboBox
    Friend WithEvents cbTransType As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblTransType As System.Windows.Forms.Label
    Friend WithEvents lblIPRNo As System.Windows.Forms.Label
    Friend WithEvents lblLPONo As System.Windows.Forms.Label
    Friend WithEvents lblStatusDesc As System.Windows.Forms.Label
    Friend WithEvents lblColon10 As System.Windows.Forms.Label
    Friend WithEvents lblColon9 As System.Windows.Forms.Label
    Friend WithEvents lblColon8 As System.Windows.Forms.Label
    Friend WithEvents dtpIDNDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents lblDeliverySource As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIPRNo As System.Windows.Forms.TextBox
    Friend WithEvents lblIDNDate As System.Windows.Forms.Label
    Friend WithEvents lblPONo As System.Windows.Forms.Label
    Friend WithEvents lblColon7 As System.Windows.Forms.Label
    Friend WithEvents lblGRNNo As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtLPONo As System.Windows.Forms.TextBox
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents lblColon3 As System.Windows.Forms.Label
    Friend WithEvents lblColon4 As System.Windows.Forms.Label
    Friend WithEvents lblColon5 As System.Windows.Forms.Label
    Friend WithEvents txtGRNNo As System.Windows.Forms.TextBox
    Friend WithEvents txtIDNNo As System.Windows.Forms.TextBox
    Friend WithEvents lblIDNNo As System.Windows.Forms.Label
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents lblColon2 As System.Windows.Forms.Label
    Friend WithEvents lblColon6 As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents gbEdit As System.Windows.Forms.GroupBox
    Friend WithEvents txtAvailableQty As System.Windows.Forms.TextBox
    Friend WithEvents lblAvailableQty As System.Windows.Forms.Label
    Friend WithEvents lbl23 As System.Windows.Forms.Label
    Friend WithEvents txtReceivedPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblReceivedPrice As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtPendingQty As System.Windows.Forms.TextBox
    Friend WithEvents txtStockCode As System.Windows.Forms.TextBox
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents lblStockDesc As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtReceivedQty As System.Windows.Forms.TextBox
    Friend WithEvents lblPendingQty As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblStockCode As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtStockDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblReceivedQty As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtviewSupplier As System.Windows.Forms.TextBox
    Friend WithEvents txtviewGRNNo As System.Windows.Forms.TextBox
    Friend WithEvents txtviewIDNNo As System.Windows.Forms.TextBox
    Friend WithEvents txtT0 As System.Windows.Forms.TextBox
    Friend WithEvents lblT0 As System.Windows.Forms.Label
    Friend WithEvents lblColon25 As System.Windows.Forms.Label
    Friend WithEvents btnT0Search As System.Windows.Forms.Button
    Friend WithEvents grpApproval As System.Windows.Forms.GroupBox
    Friend WithEvents lblRejectedColon As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnConform As System.Windows.Forms.Button
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtRejectedReason As System.Windows.Forms.TextBox
    Friend WithEvents lblRejectedReason As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbtnIPR As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnLPONo As System.Windows.Forms.RadioButton
    Friend WithEvents DeleteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbviewDeliverySource As System.Windows.Forms.ComboBox
    Friend WithEvents txtviewPONo As System.Windows.Forms.TextBox
    Friend WithEvents dgclSTEstMillDeliveryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTIPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTLPOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIDNDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIDNNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclGRNNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIPRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLPONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDeliverySource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclOperatorName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransportDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVehicleNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclViewReport As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents BtnVehicle As System.Windows.Forms.Button
    Friend WithEvents dgclSTPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTIPRDetID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTLPODetID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTEstMillDelivID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTEstMillDelivDetID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVarianceCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAccountCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAccountDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAvailableQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRequestedQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTAnalysisID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPendingQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceivedQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceivedPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTotalPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDifferenceQty As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PettyCashPaymentFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PettyCashPaymentFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbPCP = New System.Windows.Forms.TabControl()
        Me.tbAdd = New System.Windows.Forms.TabPage()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.btnResetIB = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.DgvMultipleEntry = New System.Windows.Forms.DataGridView()
        Me.CMSMultipleentry = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpVoucherDetails = New System.Windows.Forms.GroupBox()
        Me.lblDetailCostDescp = New System.Windows.Forms.Label()
        Me.lblVehicleDescp = New System.Windows.Forms.Label()
        Me.btnSearchVehicleDetailCostCode = New System.Windows.Forms.Button()
        Me.btnSearchVehicleCode = New System.Windows.Forms.Button()
        Me.lblVehicleCode = New System.Windows.Forms.Label()
        Me.txtDetailCostCode = New System.Windows.Forms.TextBox()
        Me.txtVehicleCode = New System.Windows.Forms.TextBox()
        Me.lblDetailCostCode = New System.Windows.Forms.Label()
        Me.ddlTranscationType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTrancactionType = New System.Windows.Forms.Label()
        Me.lblUOMDescp = New System.Windows.Forms.Label()
        Me.btnUOM = New System.Windows.Forms.Button()
        Me.txtUOM = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.grpApproval = New System.Windows.Forms.GroupBox()
        Me.txtRejectedReason = New System.Windows.Forms.TextBox()
        Me.lblRejColon = New System.Windows.Forms.Label()
        Me.lblRejReason = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnConform = New System.Windows.Forms.Button()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatusApproval = New System.Windows.Forms.Label()
        Me.lblOldAccountCode = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnResetMultipleEntryGrp = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblDescp = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblT4Name = New System.Windows.Forms.Label()
        Me.lblT3Name = New System.Windows.Forms.Label()
        Me.lblT2Name = New System.Windows.Forms.Label()
        Me.lblT1Name = New System.Windows.Forms.Label()
        Me.lblT0Name = New System.Windows.Forms.Label()
        Me.lblAccountDescp = New System.Windows.Forms.Label()
        Me.btnSearchT4 = New System.Windows.Forms.Button()
        Me.btnSearchT3 = New System.Windows.Forms.Button()
        Me.btnSearchT2 = New System.Windows.Forms.Button()
        Me.btnSearchT1 = New System.Windows.Forms.Button()
        Me.btnSearchT0 = New System.Windows.Forms.Button()
        Me.txtT4 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblT4 = New System.Windows.Forms.Label()
        Me.txtT3 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblT3 = New System.Windows.Forms.Label()
        Me.txtT2 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblT2 = New System.Windows.Forms.Label()
        Me.txtT1 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblT1 = New System.Windows.Forms.Label()
        Me.txtT0 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblT0 = New System.Windows.Forms.Label()
        Me.btnAccountCodeLookup = New System.Windows.Forms.Button()
        Me.txtAccountCode = New System.Windows.Forms.TextBox()
        Me.lblAccountCode = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.grpVoucherNo = New System.Windows.Forms.GroupBox()
        Me.txtPaidTo = New System.Windows.Forms.TextBox()
        Me.dtpApprovalDate = New System.Windows.Forms.DateTimePicker()
        Me.lblColon13 = New System.Windows.Forms.Label()
        Me.lblApprovalDate = New System.Windows.Forms.Label()
        Me.lblRejectedReasonValue = New System.Windows.Forms.Label()
        Me.lblColon = New System.Windows.Forms.Label()
        Me.lblRecjectedReason = New System.Windows.Forms.Label()
        Me.CbPayTo = New System.Windows.Forms.ComboBox()
        Me.cbDiscrepancytransaction = New System.Windows.Forms.CheckBox()
        Me.txtDescp = New System.Windows.Forms.TextBox()
        Me.lblStatusValue = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPayto = New System.Windows.Forms.Label()
        Me.dtpVoucherDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVoucherNo = New System.Windows.Forms.TextBox()
        Me.lblVoucherNo = New System.Windows.Forms.Label()
        Me.lblVoucherDate = New System.Windows.Forms.Label()
        Me.tbView = New System.Windows.Forms.TabPage()
        Me.plIPRView = New System.Windows.Forms.Panel()
        Me.dgvPettyCashPaymentView = New System.Windows.Forms.DataGridView()
        Me.dgclVoucherNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPayToID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclVoucherDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDistributionDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPaidTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPaymentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDiscrepancyTransaction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclApproved = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsPCP = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnlSearch = New Stepi.UI.ExtendedPanel()
        Me.lblsearchBy = New System.Windows.Forms.Label()
        Me.lblSearchStatus = New System.Windows.Forms.Label()
        Me.cmbSearchStatus = New System.Windows.Forms.ComboBox()
        Me.txtVoucherNoSearch = New System.Windows.Forms.TextBox()
        Me.chkVoucherDate = New System.Windows.Forms.CheckBox()
        Me.btnviewReport = New System.Windows.Forms.Button()
        Me.lblvoucherNoSearch = New System.Windows.Forms.Label()
        Me.dtpviewVoucherDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DgMeTransactionType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VHID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VHDetailCostCodeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeAccountCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeUOMID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeUOMDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgmeOldCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeAccountDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeUOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VHWSCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VHDetailCostCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeTAnalysisCode0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeTAnalysisCode1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeTAnalysisCode2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeTAnalysisCode3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeTAnalysisCode4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeTAnalysisDescp0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeTAnalysisDescp1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeTAnalysisDescp2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeTAnalysisDescp3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeTAnalysisDescp4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeT0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeT1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeT2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeT3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeT4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMePaymentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeremarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbPCP.SuspendLayout()
        Me.tbAdd.SuspendLayout()
        CType(Me.DgvMultipleEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSMultipleentry.SuspendLayout()
        Me.grpVoucherDetails.SuspendLayout()
        Me.grpApproval.SuspendLayout()
        Me.grpVoucherNo.SuspendLayout()
        Me.tbView.SuspendLayout()
        Me.plIPRView.SuspendLayout()
        CType(Me.dgvPettyCashPaymentView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPCP.SuspendLayout()
        Me.PnlSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbPCP
        '
        Me.tbPCP.Controls.Add(Me.tbAdd)
        Me.tbPCP.Controls.Add(Me.tbView)
        Me.tbPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCP.Location = New System.Drawing.Point(0, 0)
        Me.tbPCP.Name = "tbPCP"
        Me.tbPCP.SelectedIndex = 0
        Me.tbPCP.Size = New System.Drawing.Size(1061, 858)
        Me.tbPCP.TabIndex = 202
        '
        'tbAdd
        '
        Me.tbAdd.AutoScroll = True
        Me.tbAdd.BackColor = System.Drawing.Color.Transparent
        Me.tbAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbAdd.Controls.Add(Me.btnDeleteAll)
        Me.tbAdd.Controls.Add(Me.btnResetIB)
        Me.tbAdd.Controls.Add(Me.btnSave)
        Me.tbAdd.Controls.Add(Me.btnClose)
        Me.tbAdd.Controls.Add(Me.DgvMultipleEntry)
        Me.tbAdd.Controls.Add(Me.grpVoucherDetails)
        Me.tbAdd.Controls.Add(Me.grpVoucherNo)
        Me.tbAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAdd.Location = New System.Drawing.Point(4, 29)
        Me.tbAdd.Name = "tbAdd"
        Me.tbAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAdd.Size = New System.Drawing.Size(1053, 825)
        Me.tbAdd.TabIndex = 0
        Me.tbAdd.Text = "Petty Cash Payment"
        Me.tbAdd.UseVisualStyleBackColor = True
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnDeleteAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteAll.Image = Global.BSP.My.Resources.Resources.icon_delete
        Me.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteAll.Location = New System.Drawing.Point(907, 791)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(117, 25)
        Me.btnDeleteAll.TabIndex = 110
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        Me.btnDeleteAll.Visible = False
        '
        'btnResetIB
        '
        Me.btnResetIB.BackgroundImage = CType(resources.GetObject("btnResetIB.BackgroundImage"), System.Drawing.Image)
        Me.btnResetIB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetIB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetIB.Image = CType(resources.GetObject("btnResetIB.Image"), System.Drawing.Image)
        Me.btnResetIB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetIB.Location = New System.Drawing.Point(661, 791)
        Me.btnResetIB.Name = "btnResetIB"
        Me.btnResetIB.Size = New System.Drawing.Size(117, 25)
        Me.btnResetIB.TabIndex = 108
        Me.btnResetIB.Text = "Reset"
        Me.btnResetIB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnResetIB.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(538, 791)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(117, 25)
        Me.btnSave.TabIndex = 107
        Me.btnSave.Text = "Save All"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(784, 791)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(117, 25)
        Me.btnClose.TabIndex = 109
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'DgvMultipleEntry
        '
        Me.DgvMultipleEntry.AllowUserToAddRows = False
        Me.DgvMultipleEntry.AllowUserToDeleteRows = False
        Me.DgvMultipleEntry.AllowUserToResizeRows = False
        Me.DgvMultipleEntry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvMultipleEntry.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DgvMultipleEntry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvMultipleEntry.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvMultipleEntry.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvMultipleEntry.ColumnHeadersHeight = 30
        Me.DgvMultipleEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DgMeTransactionType, Me.VHID, Me.VHDetailCostCodeID, Me.DgMeAccountCode, Me.dgMeUOMID, Me.dgMeUOMDescp, Me.dgmeOldCOACode, Me.DgMeAccountDescp, Me.DgMeAmount, Me.DgMeQty, Me.dgMeUOM, Me.VHWSCode, Me.VHDetailCostCode, Me.DgMeTAnalysisCode0, Me.DgMeTAnalysisCode1, Me.DgMeTAnalysisCode2, Me.DgMeTAnalysisCode3, Me.DgMeTAnalysisCode4, Me.DgMeCOAID, Me.DgMeTAnalysisDescp0, Me.DgMeTAnalysisDescp1, Me.DgMeTAnalysisDescp2, Me.DgMeTAnalysisDescp3, Me.DgMeTAnalysisDescp4, Me.DgMeT0, Me.DgMeT1, Me.DgMeT2, Me.DgMeT3, Me.DgMeT4, Me.DgMePaymentID, Me.DgMeremarks})
        Me.DgvMultipleEntry.ContextMenuStrip = Me.CMSMultipleentry
        Me.DgvMultipleEntry.EnableHeadersVisualStyles = False
        Me.DgvMultipleEntry.GridColor = System.Drawing.Color.Gray
        Me.DgvMultipleEntry.Location = New System.Drawing.Point(2, 598)
        Me.DgvMultipleEntry.MultiSelect = False
        Me.DgvMultipleEntry.Name = "DgvMultipleEntry"
        Me.DgvMultipleEntry.ReadOnly = True
        Me.DgvMultipleEntry.RowHeadersVisible = False
        Me.DgvMultipleEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvMultipleEntry.Size = New System.Drawing.Size(1029, 187)
        Me.DgvMultipleEntry.TabIndex = 106
        '
        'CMSMultipleentry
        '
        Me.CMSMultipleentry.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.CMSMultipleentry.Name = "cmsIPR"
        Me.CMSMultipleentry.Size = New System.Drawing.Size(135, 94)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(134, 30)
        Me.ToolStripMenuItem1.Text = "Add"
        Me.ToolStripMenuItem1.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(134, 30)
        Me.ToolStripMenuItem2.Text = "Edit"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(134, 30)
        Me.ToolStripMenuItem3.Text = "Delete"
        '
        'grpVoucherDetails
        '
        Me.grpVoucherDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVoucherDetails.Controls.Add(Me.Label13)
        Me.grpVoucherDetails.Controls.Add(Me.Label5)
        Me.grpVoucherDetails.Controls.Add(Me.lblDetailCostDescp)
        Me.grpVoucherDetails.Controls.Add(Me.lblVehicleDescp)
        Me.grpVoucherDetails.Controls.Add(Me.btnSearchVehicleDetailCostCode)
        Me.grpVoucherDetails.Controls.Add(Me.btnSearchVehicleCode)
        Me.grpVoucherDetails.Controls.Add(Me.lblVehicleCode)
        Me.grpVoucherDetails.Controls.Add(Me.txtDetailCostCode)
        Me.grpVoucherDetails.Controls.Add(Me.txtVehicleCode)
        Me.grpVoucherDetails.Controls.Add(Me.lblDetailCostCode)
        Me.grpVoucherDetails.Controls.Add(Me.ddlTranscationType)
        Me.grpVoucherDetails.Controls.Add(Me.Label3)
        Me.grpVoucherDetails.Controls.Add(Me.lblTrancactionType)
        Me.grpVoucherDetails.Controls.Add(Me.lblUOMDescp)
        Me.grpVoucherDetails.Controls.Add(Me.btnUOM)
        Me.grpVoucherDetails.Controls.Add(Me.txtUOM)
        Me.grpVoucherDetails.Controls.Add(Me.Label14)
        Me.grpVoucherDetails.Controls.Add(Me.lblUnit)
        Me.grpVoucherDetails.Controls.Add(Me.grpApproval)
        Me.grpVoucherDetails.Controls.Add(Me.lblOldAccountCode)
        Me.grpVoucherDetails.Controls.Add(Me.Label11)
        Me.grpVoucherDetails.Controls.Add(Me.Label10)
        Me.grpVoucherDetails.Controls.Add(Me.btnResetMultipleEntryGrp)
        Me.grpVoucherDetails.Controls.Add(Me.btnAdd)
        Me.grpVoucherDetails.Controls.Add(Me.lblDescp)
        Me.grpVoucherDetails.Controls.Add(Me.txtQty)
        Me.grpVoucherDetails.Controls.Add(Me.Label9)
        Me.grpVoucherDetails.Controls.Add(Me.lblQty)
        Me.grpVoucherDetails.Controls.Add(Me.txtRemarks)
        Me.grpVoucherDetails.Controls.Add(Me.Label8)
        Me.grpVoucherDetails.Controls.Add(Me.txtAmount)
        Me.grpVoucherDetails.Controls.Add(Me.lblAmount)
        Me.grpVoucherDetails.Controls.Add(Me.Label7)
        Me.grpVoucherDetails.Controls.Add(Me.lblT4Name)
        Me.grpVoucherDetails.Controls.Add(Me.lblT3Name)
        Me.grpVoucherDetails.Controls.Add(Me.lblT2Name)
        Me.grpVoucherDetails.Controls.Add(Me.lblT1Name)
        Me.grpVoucherDetails.Controls.Add(Me.lblT0Name)
        Me.grpVoucherDetails.Controls.Add(Me.lblAccountDescp)
        Me.grpVoucherDetails.Controls.Add(Me.btnSearchT4)
        Me.grpVoucherDetails.Controls.Add(Me.btnSearchT3)
        Me.grpVoucherDetails.Controls.Add(Me.btnSearchT2)
        Me.grpVoucherDetails.Controls.Add(Me.btnSearchT1)
        Me.grpVoucherDetails.Controls.Add(Me.btnSearchT0)
        Me.grpVoucherDetails.Controls.Add(Me.txtT4)
        Me.grpVoucherDetails.Controls.Add(Me.Label33)
        Me.grpVoucherDetails.Controls.Add(Me.lblT4)
        Me.grpVoucherDetails.Controls.Add(Me.txtT3)
        Me.grpVoucherDetails.Controls.Add(Me.Label30)
        Me.grpVoucherDetails.Controls.Add(Me.lblT3)
        Me.grpVoucherDetails.Controls.Add(Me.txtT2)
        Me.grpVoucherDetails.Controls.Add(Me.Label27)
        Me.grpVoucherDetails.Controls.Add(Me.lblT2)
        Me.grpVoucherDetails.Controls.Add(Me.txtT1)
        Me.grpVoucherDetails.Controls.Add(Me.Label26)
        Me.grpVoucherDetails.Controls.Add(Me.lblT1)
        Me.grpVoucherDetails.Controls.Add(Me.txtT0)
        Me.grpVoucherDetails.Controls.Add(Me.Label29)
        Me.grpVoucherDetails.Controls.Add(Me.lblT0)
        Me.grpVoucherDetails.Controls.Add(Me.btnAccountCodeLookup)
        Me.grpVoucherDetails.Controls.Add(Me.txtAccountCode)
        Me.grpVoucherDetails.Controls.Add(Me.lblAccountCode)
        Me.grpVoucherDetails.Controls.Add(Me.Label32)
        Me.grpVoucherDetails.Location = New System.Drawing.Point(8, 173)
        Me.grpVoucherDetails.Name = "grpVoucherDetails"
        Me.grpVoucherDetails.Size = New System.Drawing.Size(1023, 419)
        Me.grpVoucherDetails.TabIndex = 6
        Me.grpVoucherDetails.TabStop = False
        Me.grpVoucherDetails.Text = "Voucher Details (Multiple Entry)"
        '
        'lblDetailCostDescp
        '
        Me.lblDetailCostDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetailCostDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblDetailCostDescp.Location = New System.Drawing.Point(346, 207)
        Me.lblDetailCostDescp.Name = "lblDetailCostDescp"
        Me.lblDetailCostDescp.Size = New System.Drawing.Size(170, 29)
        Me.lblDetailCostDescp.TabIndex = 267
        Me.lblDetailCostDescp.Text = "DetailCostDescp"
        '
        'lblVehicleDescp
        '
        Me.lblVehicleDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblVehicleDescp.Location = New System.Drawing.Point(346, 177)
        Me.lblVehicleDescp.Name = "lblVehicleDescp"
        Me.lblVehicleDescp.Size = New System.Drawing.Size(170, 27)
        Me.lblVehicleDescp.TabIndex = 266
        Me.lblVehicleDescp.Text = "VehicleDescp"
        '
        'btnSearchVehicleDetailCostCode
        '
        Me.btnSearchVehicleDetailCostCode.BackgroundImage = CType(resources.GetObject("btnSearchVehicleDetailCostCode.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchVehicleDetailCostCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVehicleDetailCostCode.FlatAppearance.BorderSize = 0
        Me.btnSearchVehicleDetailCostCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVehicleDetailCostCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVehicleDetailCostCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVehicleDetailCostCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVehicleDetailCostCode.Location = New System.Drawing.Point(313, 202)
        Me.btnSearchVehicleDetailCostCode.Name = "btnSearchVehicleDetailCostCode"
        Me.btnSearchVehicleDetailCostCode.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchVehicleDetailCostCode.TabIndex = 263
        Me.btnSearchVehicleDetailCostCode.TabStop = False
        Me.btnSearchVehicleDetailCostCode.UseVisualStyleBackColor = True
        '
        'btnSearchVehicleCode
        '
        Me.btnSearchVehicleCode.BackgroundImage = CType(resources.GetObject("btnSearchVehicleCode.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchVehicleCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVehicleCode.FlatAppearance.BorderSize = 0
        Me.btnSearchVehicleCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVehicleCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVehicleCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVehicleCode.Location = New System.Drawing.Point(313, 172)
        Me.btnSearchVehicleCode.Name = "btnSearchVehicleCode"
        Me.btnSearchVehicleCode.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchVehicleCode.TabIndex = 261
        Me.btnSearchVehicleCode.TabStop = False
        Me.btnSearchVehicleCode.UseVisualStyleBackColor = True
        '
        'lblVehicleCode
        '
        Me.lblVehicleCode.AutoSize = True
        Me.lblVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleCode.Location = New System.Drawing.Point(16, 181)
        Me.lblVehicleCode.Name = "lblVehicleCode"
        Me.lblVehicleCode.Size = New System.Drawing.Size(119, 20)
        Me.lblVehicleCode.TabIndex = 264
        Me.lblVehicleCode.Text = "Vehicle Code"
        '
        'txtDetailCostCode
        '
        Me.txtDetailCostCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetailCostCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetailCostCode.Location = New System.Drawing.Point(154, 207)
        Me.txtDetailCostCode.MaxLength = 50
        Me.txtDetailCostCode.Name = "txtDetailCostCode"
        Me.txtDetailCostCode.Size = New System.Drawing.Size(151, 28)
        Me.txtDetailCostCode.TabIndex = 262
        '
        'txtVehicleCode
        '
        Me.txtVehicleCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleCode.Location = New System.Drawing.Point(154, 177)
        Me.txtVehicleCode.MaxLength = 50
        Me.txtVehicleCode.Name = "txtVehicleCode"
        Me.txtVehicleCode.Size = New System.Drawing.Size(151, 28)
        Me.txtVehicleCode.TabIndex = 260
        '
        'lblDetailCostCode
        '
        Me.lblDetailCostCode.AutoSize = True
        Me.lblDetailCostCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetailCostCode.Location = New System.Drawing.Point(16, 211)
        Me.lblDetailCostCode.Name = "lblDetailCostCode"
        Me.lblDetailCostCode.Size = New System.Drawing.Size(108, 20)
        Me.lblDetailCostCode.TabIndex = 265
        Me.lblDetailCostCode.Text = "Detail Code"
        '
        'ddlTranscationType
        '
        Me.ddlTranscationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlTranscationType.FormattingEnabled = True
        Me.ddlTranscationType.Items.AddRange(New Object() {"Debit", "Credit"})
        Me.ddlTranscationType.Location = New System.Drawing.Point(154, 20)
        Me.ddlTranscationType.Name = "ddlTranscationType"
        Me.ddlTranscationType.Size = New System.Drawing.Size(118, 28)
        Me.ddlTranscationType.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(138, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 20)
        Me.Label3.TabIndex = 259
        Me.Label3.Text = ":"
        '
        'lblTrancactionType
        '
        Me.lblTrancactionType.AutoSize = True
        Me.lblTrancactionType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrancactionType.ForeColor = System.Drawing.Color.Black
        Me.lblTrancactionType.Location = New System.Drawing.Point(17, 22)
        Me.lblTrancactionType.Name = "lblTrancactionType"
        Me.lblTrancactionType.Size = New System.Drawing.Size(151, 20)
        Me.lblTrancactionType.TabIndex = 258
        Me.lblTrancactionType.Text = "Transaction Type"
        '
        'lblUOMDescp
        '
        Me.lblUOMDescp.AutoSize = True
        Me.lblUOMDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUOMDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblUOMDescp.Location = New System.Drawing.Point(322, 150)
        Me.lblUOMDescp.Name = "lblUOMDescp"
        Me.lblUOMDescp.Size = New System.Drawing.Size(100, 20)
        Me.lblUOMDescp.TabIndex = 257
        Me.lblUOMDescp.Text = "UOMDescp"
        '
        'btnUOM
        '
        Me.btnUOM.BackgroundImage = CType(resources.GetObject("btnUOM.BackgroundImage"), System.Drawing.Image)
        Me.btnUOM.Enabled = False
        Me.btnUOM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUOM.FlatAppearance.BorderSize = 0
        Me.btnUOM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnUOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUOM.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnUOM.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnUOM.Location = New System.Drawing.Point(283, 139)
        Me.btnUOM.Name = "btnUOM"
        Me.btnUOM.Size = New System.Drawing.Size(30, 26)
        Me.btnUOM.TabIndex = 12
        Me.btnUOM.TabStop = False
        Me.btnUOM.UseVisualStyleBackColor = True
        '
        'txtUOM
        '
        Me.txtUOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUOM.Enabled = False
        Me.txtUOM.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUOM.Location = New System.Drawing.Point(154, 146)
        Me.txtUOM.MaxLength = 50
        Me.txtUOM.Name = "txtUOM"
        Me.txtUOM.Size = New System.Drawing.Size(118, 28)
        Me.txtUOM.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(138, 150)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(16, 20)
        Me.Label14.TabIndex = 256
        Me.Label14.Text = ":"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnit.Location = New System.Drawing.Point(17, 150)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(44, 20)
        Me.lblUnit.TabIndex = 255
        Me.lblUnit.Text = "Unit"
        '
        'grpApproval
        '
        Me.grpApproval.Controls.Add(Me.txtRejectedReason)
        Me.grpApproval.Controls.Add(Me.lblRejColon)
        Me.grpApproval.Controls.Add(Me.lblRejReason)
        Me.grpApproval.Controls.Add(Me.Label12)
        Me.grpApproval.Controls.Add(Me.btnConform)
        Me.grpApproval.Controls.Add(Me.cmbStatus)
        Me.grpApproval.Controls.Add(Me.lblStatusApproval)
        Me.grpApproval.Location = New System.Drawing.Point(586, 227)
        Me.grpApproval.Name = "grpApproval"
        Me.grpApproval.Size = New System.Drawing.Size(345, 104)
        Me.grpApproval.TabIndex = 252
        Me.grpApproval.TabStop = False
        Me.grpApproval.Text = "Petty Cash Payment Approval"
        Me.grpApproval.Visible = False
        '
        'txtRejectedReason
        '
        Me.txtRejectedReason.AcceptsReturn = True
        Me.txtRejectedReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRejectedReason.Location = New System.Drawing.Point(91, 61)
        Me.txtRejectedReason.Multiline = True
        Me.txtRejectedReason.Name = "txtRejectedReason"
        Me.txtRejectedReason.Size = New System.Drawing.Size(230, 39)
        Me.txtRejectedReason.TabIndex = 260
        '
        'lblRejColon
        '
        Me.lblRejColon.AutoSize = True
        Me.lblRejColon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejColon.Location = New System.Drawing.Point(74, 68)
        Me.lblRejColon.Name = "lblRejColon"
        Me.lblRejColon.Size = New System.Drawing.Size(16, 20)
        Me.lblRejColon.TabIndex = 259
        Me.lblRejColon.Text = ":"
        '
        'lblRejReason
        '
        Me.lblRejReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejReason.ForeColor = System.Drawing.Color.Black
        Me.lblRejReason.Location = New System.Drawing.Point(7, 64)
        Me.lblRejReason.Name = "lblRejReason"
        Me.lblRejReason.Size = New System.Drawing.Size(65, 36)
        Me.lblRejReason.TabIndex = 258
        Me.lblRejReason.Text = "Rejected Reason"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(107, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 20)
        Me.Label12.TabIndex = 144
        Me.Label12.Text = ":"
        '
        'btnConform
        '
        Me.btnConform.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnConform.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConform.Image = CType(resources.GetObject("btnConform.Image"), System.Drawing.Image)
        Me.btnConform.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConform.Location = New System.Drawing.Point(147, 29)
        Me.btnConform.Name = "btnConform"
        Me.btnConform.Size = New System.Drawing.Size(114, 25)
        Me.btnConform.TabIndex = 202
        Me.btnConform.Text = "Confirm"
        Me.btnConform.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"APPROVED", "REJECTED"})
        Me.cmbStatus.Location = New System.Drawing.Point(6, 33)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(135, 28)
        Me.cmbStatus.TabIndex = 200
        '
        'lblStatusApproval
        '
        Me.lblStatusApproval.AutoSize = True
        Me.lblStatusApproval.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusApproval.ForeColor = System.Drawing.Color.Black
        Me.lblStatusApproval.Location = New System.Drawing.Point(6, 15)
        Me.lblStatusApproval.Name = "lblStatusApproval"
        Me.lblStatusApproval.Size = New System.Drawing.Size(65, 20)
        Me.lblStatusApproval.TabIndex = 142
        Me.lblStatusApproval.Text = "Status"
        '
        'lblOldAccountCode
        '
        Me.lblOldAccountCode.AutoSize = True
        Me.lblOldAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOldAccountCode.ForeColor = System.Drawing.Color.Blue
        Me.lblOldAccountCode.Location = New System.Drawing.Point(151, 74)
        Me.lblOldAccountCode.Name = "lblOldAccountCode"
        Me.lblOldAccountCode.Size = New System.Drawing.Size(162, 20)
        Me.lblOldAccountCode.TabIndex = 251
        Me.lblOldAccountCode.Text = "Old Account Code"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(138, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 20)
        Me.Label11.TabIndex = 250
        Me.Label11.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(17, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(162, 20)
        Me.Label10.TabIndex = 249
        Me.Label10.Text = "Old Account Code"
        '
        'btnResetMultipleEntryGrp
        '
        Me.btnResetMultipleEntryGrp.BackgroundImage = CType(resources.GetObject("btnResetMultipleEntryGrp.BackgroundImage"), System.Drawing.Image)
        Me.btnResetMultipleEntryGrp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetMultipleEntryGrp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetMultipleEntryGrp.Image = CType(resources.GetObject("btnResetMultipleEntryGrp.Image"), System.Drawing.Image)
        Me.btnResetMultipleEntryGrp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetMultipleEntryGrp.Location = New System.Drawing.Point(282, 347)
        Me.btnResetMultipleEntryGrp.Name = "btnResetMultipleEntryGrp"
        Me.btnResetMultipleEntryGrp.Size = New System.Drawing.Size(117, 25)
        Me.btnResetMultipleEntryGrp.TabIndex = 25
        Me.btnResetMultipleEntryGrp.Text = "Reset"
        Me.btnResetMultipleEntryGrp.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(155, 347)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(117, 25)
        Me.btnAdd.TabIndex = 24
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblDescp
        '
        Me.lblDescp.AutoEllipsis = True
        Me.lblDescp.ForeColor = System.Drawing.Color.Red
        Me.lblDescp.Location = New System.Drawing.Point(16, 243)
        Me.lblDescp.Name = "lblDescp"
        Me.lblDescp.Size = New System.Drawing.Size(114, 22)
        Me.lblDescp.TabIndex = 143
        Me.lblDescp.Text = "Description"
        '
        'txtQty
        '
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(154, 120)
        Me.txtQty.MaxLength = 18
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(118, 28)
        Me.txtQty.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(138, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 20)
        Me.Label9.TabIndex = 246
        Me.Label9.Text = ":"
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty.Location = New System.Drawing.Point(17, 124)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(39, 20)
        Me.lblQty.TabIndex = 245
        Me.lblQty.Text = "Qty"
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(154, 243)
        Me.txtRemarks.MaxLength = 200
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(362, 86)
        Me.txtRemarks.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(137, 243)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 20)
        Me.Label8.TabIndex = 243
        Me.Label8.Text = ":"
        '
        'txtAmount
        '
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(154, 95)
        Me.txtAmount.MaxLength = 18
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(118, 28)
        Me.txtAmount.TabIndex = 9
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Red
        Me.lblAmount.Location = New System.Drawing.Point(17, 99)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(77, 20)
        Me.lblAmount.TabIndex = 238
        Me.lblAmount.Text = "Amount"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(138, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 20)
        Me.Label7.TabIndex = 239
        Me.Label7.Text = ":"
        '
        'lblT4Name
        '
        Me.lblT4Name.AutoSize = True
        Me.lblT4Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT4Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT4Name.Location = New System.Drawing.Point(870, 118)
        Me.lblT4Name.Name = "lblT4Name"
        Me.lblT4Name.Size = New System.Drawing.Size(80, 20)
        Me.lblT4Name.TabIndex = 237
        Me.lblT4Name.Text = "T4Name"
        Me.lblT4Name.Visible = False
        '
        'lblT3Name
        '
        Me.lblT3Name.AutoSize = True
        Me.lblT3Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT3Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT3Name.Location = New System.Drawing.Point(870, 93)
        Me.lblT3Name.Name = "lblT3Name"
        Me.lblT3Name.Size = New System.Drawing.Size(80, 20)
        Me.lblT3Name.TabIndex = 236
        Me.lblT3Name.Text = "T3Name"
        Me.lblT3Name.Visible = False
        '
        'lblT2Name
        '
        Me.lblT2Name.AutoSize = True
        Me.lblT2Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT2Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT2Name.Location = New System.Drawing.Point(870, 68)
        Me.lblT2Name.Name = "lblT2Name"
        Me.lblT2Name.Size = New System.Drawing.Size(80, 20)
        Me.lblT2Name.TabIndex = 235
        Me.lblT2Name.Text = "T2Name"
        Me.lblT2Name.Visible = False
        '
        'lblT1Name
        '
        Me.lblT1Name.AutoSize = True
        Me.lblT1Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT1Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT1Name.Location = New System.Drawing.Point(870, 43)
        Me.lblT1Name.Name = "lblT1Name"
        Me.lblT1Name.Size = New System.Drawing.Size(80, 20)
        Me.lblT1Name.TabIndex = 234
        Me.lblT1Name.Text = "T1Name"
        Me.lblT1Name.Visible = False
        '
        'lblT0Name
        '
        Me.lblT0Name.AutoSize = True
        Me.lblT0Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT0Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT0Name.Location = New System.Drawing.Point(870, 18)
        Me.lblT0Name.Name = "lblT0Name"
        Me.lblT0Name.Size = New System.Drawing.Size(80, 20)
        Me.lblT0Name.TabIndex = 233
        Me.lblT0Name.Text = "T0Name"
        Me.lblT0Name.Visible = False
        '
        'lblAccountDescp
        '
        Me.lblAccountDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblAccountDescp.Location = New System.Drawing.Point(377, 38)
        Me.lblAccountDescp.Name = "lblAccountDescp"
        Me.lblAccountDescp.Size = New System.Drawing.Size(158, 35)
        Me.lblAccountDescp.TabIndex = 232
        Me.lblAccountDescp.Text = "Account Descp"
        '
        'btnSearchT4
        '
        Me.btnSearchT4.BackgroundImage = CType(resources.GetObject("btnSearchT4.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchT4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchT4.FlatAppearance.BorderSize = 0
        Me.btnSearchT4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchT4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchT4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchT4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchT4.Location = New System.Drawing.Point(837, 109)
        Me.btnSearchT4.Name = "btnSearchT4"
        Me.btnSearchT4.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchT4.TabIndex = 22
        Me.btnSearchT4.TabStop = False
        Me.btnSearchT4.UseVisualStyleBackColor = True
        Me.btnSearchT4.Visible = False
        '
        'btnSearchT3
        '
        Me.btnSearchT3.BackgroundImage = CType(resources.GetObject("btnSearchT3.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchT3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchT3.FlatAppearance.BorderSize = 0
        Me.btnSearchT3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchT3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchT3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchT3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchT3.Location = New System.Drawing.Point(837, 84)
        Me.btnSearchT3.Name = "btnSearchT3"
        Me.btnSearchT3.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchT3.TabIndex = 20
        Me.btnSearchT3.TabStop = False
        Me.btnSearchT3.UseVisualStyleBackColor = True
        Me.btnSearchT3.Visible = False
        '
        'btnSearchT2
        '
        Me.btnSearchT2.BackgroundImage = CType(resources.GetObject("btnSearchT2.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchT2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchT2.FlatAppearance.BorderSize = 0
        Me.btnSearchT2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchT2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchT2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchT2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchT2.Location = New System.Drawing.Point(837, 59)
        Me.btnSearchT2.Name = "btnSearchT2"
        Me.btnSearchT2.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchT2.TabIndex = 18
        Me.btnSearchT2.TabStop = False
        Me.btnSearchT2.UseVisualStyleBackColor = True
        Me.btnSearchT2.Visible = False
        '
        'btnSearchT1
        '
        Me.btnSearchT1.BackgroundImage = CType(resources.GetObject("btnSearchT1.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchT1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchT1.FlatAppearance.BorderSize = 0
        Me.btnSearchT1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchT1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchT1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchT1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchT1.Location = New System.Drawing.Point(837, 34)
        Me.btnSearchT1.Name = "btnSearchT1"
        Me.btnSearchT1.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchT1.TabIndex = 16
        Me.btnSearchT1.TabStop = False
        Me.btnSearchT1.UseVisualStyleBackColor = True
        Me.btnSearchT1.Visible = False
        '
        'btnSearchT0
        '
        Me.btnSearchT0.BackgroundImage = CType(resources.GetObject("btnSearchT0.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchT0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchT0.FlatAppearance.BorderSize = 0
        Me.btnSearchT0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchT0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchT0.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchT0.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchT0.Location = New System.Drawing.Point(837, 5)
        Me.btnSearchT0.Name = "btnSearchT0"
        Me.btnSearchT0.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchT0.TabIndex = 14
        Me.btnSearchT0.TabStop = False
        Me.btnSearchT0.UseVisualStyleBackColor = True
        Me.btnSearchT0.Visible = False
        '
        'txtT4
        '
        Me.txtT4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT4.Location = New System.Drawing.Point(771, 114)
        Me.txtT4.MaxLength = 50
        Me.txtT4.Name = "txtT4"
        Me.txtT4.Size = New System.Drawing.Size(60, 28)
        Me.txtT4.TabIndex = 21
        Me.txtT4.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(756, 118)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(16, 20)
        Me.Label33.TabIndex = 225
        Me.Label33.Text = ":"
        Me.Label33.Visible = False
        '
        'lblT4
        '
        Me.lblT4.AutoSize = True
        Me.lblT4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT4.Location = New System.Drawing.Point(732, 118)
        Me.lblT4.Name = "lblT4"
        Me.lblT4.Size = New System.Drawing.Size(30, 20)
        Me.lblT4.TabIndex = 224
        Me.lblT4.Text = "T4"
        Me.lblT4.Visible = False
        '
        'txtT3
        '
        Me.txtT3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT3.Location = New System.Drawing.Point(771, 89)
        Me.txtT3.MaxLength = 50
        Me.txtT3.Name = "txtT3"
        Me.txtT3.Size = New System.Drawing.Size(60, 28)
        Me.txtT3.TabIndex = 19
        Me.txtT3.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(756, 93)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(16, 20)
        Me.Label30.TabIndex = 222
        Me.Label30.Text = ":"
        Me.Label30.Visible = False
        '
        'lblT3
        '
        Me.lblT3.AutoSize = True
        Me.lblT3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT3.Location = New System.Drawing.Point(732, 93)
        Me.lblT3.Name = "lblT3"
        Me.lblT3.Size = New System.Drawing.Size(30, 20)
        Me.lblT3.TabIndex = 221
        Me.lblT3.Text = "T3"
        Me.lblT3.Visible = False
        '
        'txtT2
        '
        Me.txtT2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT2.Location = New System.Drawing.Point(771, 64)
        Me.txtT2.MaxLength = 50
        Me.txtT2.Name = "txtT2"
        Me.txtT2.Size = New System.Drawing.Size(60, 28)
        Me.txtT2.TabIndex = 17
        Me.txtT2.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(756, 68)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(16, 20)
        Me.Label27.TabIndex = 219
        Me.Label27.Text = ":"
        Me.Label27.Visible = False
        '
        'lblT2
        '
        Me.lblT2.AutoSize = True
        Me.lblT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT2.Location = New System.Drawing.Point(732, 68)
        Me.lblT2.Name = "lblT2"
        Me.lblT2.Size = New System.Drawing.Size(30, 20)
        Me.lblT2.TabIndex = 218
        Me.lblT2.Text = "T2"
        Me.lblT2.Visible = False
        '
        'txtT1
        '
        Me.txtT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT1.Location = New System.Drawing.Point(771, 39)
        Me.txtT1.MaxLength = 50
        Me.txtT1.Name = "txtT1"
        Me.txtT1.Size = New System.Drawing.Size(60, 28)
        Me.txtT1.TabIndex = 15
        Me.txtT1.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(756, 43)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(16, 20)
        Me.Label26.TabIndex = 216
        Me.Label26.Text = ":"
        Me.Label26.Visible = False
        '
        'lblT1
        '
        Me.lblT1.AutoSize = True
        Me.lblT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT1.Location = New System.Drawing.Point(732, 43)
        Me.lblT1.Name = "lblT1"
        Me.lblT1.Size = New System.Drawing.Size(30, 20)
        Me.lblT1.TabIndex = 215
        Me.lblT1.Text = "T1"
        Me.lblT1.Visible = False
        '
        'txtT0
        '
        Me.txtT0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT0.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT0.Location = New System.Drawing.Point(771, 14)
        Me.txtT0.MaxLength = 50
        Me.txtT0.Name = "txtT0"
        Me.txtT0.Size = New System.Drawing.Size(60, 28)
        Me.txtT0.TabIndex = 13
        Me.txtT0.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Red
        Me.Label29.Location = New System.Drawing.Point(756, 18)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(16, 20)
        Me.Label29.TabIndex = 213
        Me.Label29.Text = ":"
        Me.Label29.Visible = False
        '
        'lblT0
        '
        Me.lblT0.AutoSize = True
        Me.lblT0.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT0.ForeColor = System.Drawing.Color.Red
        Me.lblT0.Location = New System.Drawing.Point(732, 18)
        Me.lblT0.Name = "lblT0"
        Me.lblT0.Size = New System.Drawing.Size(30, 20)
        Me.lblT0.TabIndex = 212
        Me.lblT0.Text = "T0"
        Me.lblT0.Visible = False
        '
        'btnAccountCodeLookup
        '
        Me.btnAccountCodeLookup.BackgroundImage = CType(resources.GetObject("btnAccountCodeLookup.BackgroundImage"), System.Drawing.Image)
        Me.btnAccountCodeLookup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAccountCodeLookup.FlatAppearance.BorderSize = 0
        Me.btnAccountCodeLookup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAccountCodeLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccountCodeLookup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnAccountCodeLookup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAccountCodeLookup.Location = New System.Drawing.Point(340, 42)
        Me.btnAccountCodeLookup.Name = "btnAccountCodeLookup"
        Me.btnAccountCodeLookup.Size = New System.Drawing.Size(30, 26)
        Me.btnAccountCodeLookup.TabIndex = 8
        Me.btnAccountCodeLookup.TabStop = False
        Me.btnAccountCodeLookup.UseVisualStyleBackColor = True
        '
        'txtAccountCode
        '
        Me.txtAccountCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountCode.Location = New System.Drawing.Point(154, 45)
        Me.txtAccountCode.MaxLength = 50
        Me.txtAccountCode.Name = "txtAccountCode"
        Me.txtAccountCode.Size = New System.Drawing.Size(180, 28)
        Me.txtAccountCode.TabIndex = 7
        '
        'lblAccountCode
        '
        Me.lblAccountCode.AutoSize = True
        Me.lblAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountCode.ForeColor = System.Drawing.Color.Red
        Me.lblAccountCode.Location = New System.Drawing.Point(17, 49)
        Me.lblAccountCode.Name = "lblAccountCode"
        Me.lblAccountCode.Size = New System.Drawing.Size(127, 20)
        Me.lblAccountCode.TabIndex = 169
        Me.lblAccountCode.Text = "Account Code"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(138, 49)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(16, 20)
        Me.Label32.TabIndex = 170
        Me.Label32.Text = ":"
        '
        'grpVoucherNo
        '
        Me.grpVoucherNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVoucherNo.Controls.Add(Me.txtPaidTo)
        Me.grpVoucherNo.Controls.Add(Me.dtpApprovalDate)
        Me.grpVoucherNo.Controls.Add(Me.lblColon13)
        Me.grpVoucherNo.Controls.Add(Me.lblApprovalDate)
        Me.grpVoucherNo.Controls.Add(Me.lblRejectedReasonValue)
        Me.grpVoucherNo.Controls.Add(Me.lblColon)
        Me.grpVoucherNo.Controls.Add(Me.lblRecjectedReason)
        Me.grpVoucherNo.Controls.Add(Me.CbPayTo)
        Me.grpVoucherNo.Controls.Add(Me.cbDiscrepancytransaction)
        Me.grpVoucherNo.Controls.Add(Me.txtDescp)
        Me.grpVoucherNo.Controls.Add(Me.lblStatusValue)
        Me.grpVoucherNo.Controls.Add(Me.Label2)
        Me.grpVoucherNo.Controls.Add(Me.lblStatus)
        Me.grpVoucherNo.Controls.Add(Me.lblRemarks)
        Me.grpVoucherNo.Controls.Add(Me.Label1)
        Me.grpVoucherNo.Controls.Add(Me.lblPayto)
        Me.grpVoucherNo.Controls.Add(Me.dtpVoucherDate)
        Me.grpVoucherNo.Controls.Add(Me.Label4)
        Me.grpVoucherNo.Controls.Add(Me.Label6)
        Me.grpVoucherNo.Controls.Add(Me.txtVoucherNo)
        Me.grpVoucherNo.Controls.Add(Me.lblVoucherNo)
        Me.grpVoucherNo.Controls.Add(Me.lblVoucherDate)
        Me.grpVoucherNo.Location = New System.Drawing.Point(8, 0)
        Me.grpVoucherNo.Name = "grpVoucherNo"
        Me.grpVoucherNo.Size = New System.Drawing.Size(1023, 169)
        Me.grpVoucherNo.TabIndex = 0
        Me.grpVoucherNo.TabStop = False
        '
        'txtPaidTo
        '
        Me.txtPaidTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaidTo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaidTo.Location = New System.Drawing.Point(172, 91)
        Me.txtPaidTo.MaxLength = 300
        Me.txtPaidTo.Name = "txtPaidTo"
        Me.txtPaidTo.Size = New System.Drawing.Size(180, 28)
        Me.txtPaidTo.TabIndex = 3
        '
        'dtpApprovalDate
        '
        Me.dtpApprovalDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpApprovalDate.Enabled = False
        Me.dtpApprovalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpApprovalDate.Location = New System.Drawing.Point(555, 57)
        Me.dtpApprovalDate.Name = "dtpApprovalDate"
        Me.dtpApprovalDate.Size = New System.Drawing.Size(180, 28)
        Me.dtpApprovalDate.TabIndex = 264
        '
        'lblColon13
        '
        Me.lblColon13.AutoSize = True
        Me.lblColon13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon13.Location = New System.Drawing.Point(526, 61)
        Me.lblColon13.Name = "lblColon13"
        Me.lblColon13.Size = New System.Drawing.Size(16, 20)
        Me.lblColon13.TabIndex = 265
        Me.lblColon13.Text = ":"
        '
        'lblApprovalDate
        '
        Me.lblApprovalDate.AutoSize = True
        Me.lblApprovalDate.ForeColor = System.Drawing.Color.Black
        Me.lblApprovalDate.Location = New System.Drawing.Point(427, 62)
        Me.lblApprovalDate.Name = "lblApprovalDate"
        Me.lblApprovalDate.Size = New System.Drawing.Size(131, 20)
        Me.lblApprovalDate.TabIndex = 263
        Me.lblApprovalDate.Text = "Approval Date"
        '
        'lblRejectedReasonValue
        '
        Me.lblRejectedReasonValue.AutoSize = True
        Me.lblRejectedReasonValue.ForeColor = System.Drawing.Color.Blue
        Me.lblRejectedReasonValue.Location = New System.Drawing.Point(553, 130)
        Me.lblRejectedReasonValue.Name = "lblRejectedReasonValue"
        Me.lblRejectedReasonValue.Size = New System.Drawing.Size(56, 20)
        Me.lblRejectedReasonValue.TabIndex = 262
        Me.lblRejectedReasonValue.Text = "OPEN"
        Me.lblRejectedReasonValue.Visible = False
        '
        'lblColon
        '
        Me.lblColon.AutoSize = True
        Me.lblColon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon.Location = New System.Drawing.Point(528, 130)
        Me.lblColon.Name = "lblColon"
        Me.lblColon.Size = New System.Drawing.Size(16, 20)
        Me.lblColon.TabIndex = 261
        Me.lblColon.Text = ":"
        Me.lblColon.Visible = False
        '
        'lblRecjectedReason
        '
        Me.lblRecjectedReason.ForeColor = System.Drawing.Color.Black
        Me.lblRecjectedReason.Location = New System.Drawing.Point(429, 130)
        Me.lblRecjectedReason.Name = "lblRecjectedReason"
        Me.lblRecjectedReason.Size = New System.Drawing.Size(57, 37)
        Me.lblRecjectedReason.TabIndex = 260
        Me.lblRecjectedReason.Text = "Rejected Reason"
        Me.lblRecjectedReason.Visible = False
        '
        'CbPayTo
        '
        Me.CbPayTo.DisplayMember = "DistributionSetupID"
        Me.CbPayTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbPayTo.Enabled = False
        Me.CbPayTo.FormattingEnabled = True
        Me.CbPayTo.Location = New System.Drawing.Point(646, 106)
        Me.CbPayTo.Name = "CbPayTo"
        Me.CbPayTo.Size = New System.Drawing.Size(180, 28)
        Me.CbPayTo.TabIndex = 3
        Me.CbPayTo.ValueMember = "DistributionDescp"
        Me.CbPayTo.Visible = False
        '
        'cbDiscrepancytransaction
        '
        Me.cbDiscrepancytransaction.AutoSize = True
        Me.cbDiscrepancytransaction.Location = New System.Drawing.Point(172, 126)
        Me.cbDiscrepancytransaction.Name = "cbDiscrepancytransaction"
        Me.cbDiscrepancytransaction.Size = New System.Drawing.Size(243, 24)
        Me.cbDiscrepancytransaction.TabIndex = 5
        Me.cbDiscrepancytransaction.Text = "Discripancy Transaction "
        Me.cbDiscrepancytransaction.UseVisualStyleBackColor = True
        '
        'txtDescp
        '
        Me.txtDescp.AcceptsReturn = True
        Me.txtDescp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescp.Location = New System.Drawing.Point(743, 57)
        Me.txtDescp.MaxLength = 300
        Me.txtDescp.Multiline = True
        Me.txtDescp.Name = "txtDescp"
        Me.txtDescp.Size = New System.Drawing.Size(88, 33)
        Me.txtDescp.TabIndex = 4
        Me.txtDescp.Text = "."
        Me.txtDescp.Visible = False
        '
        'lblStatusValue
        '
        Me.lblStatusValue.AutoSize = True
        Me.lblStatusValue.ForeColor = System.Drawing.Color.Blue
        Me.lblStatusValue.Location = New System.Drawing.Point(552, 90)
        Me.lblStatusValue.Name = "lblStatusValue"
        Me.lblStatusValue.Size = New System.Drawing.Size(56, 20)
        Me.lblStatusValue.TabIndex = 142
        Me.lblStatusValue.Text = "OPEN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(526, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 20)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = ":"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(427, 90)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(65, 20)
        Me.lblStatus.TabIndex = 140
        Me.lblStatus.Text = "Status"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Red
        Me.lblRemarks.Location = New System.Drawing.Point(738, 77)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(106, 20)
        Me.lblRemarks.TabIndex = 242
        Me.lblRemarks.Text = "Description"
        Me.lblRemarks.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(157, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 20)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = ":"
        '
        'lblPayto
        '
        Me.lblPayto.AutoSize = True
        Me.lblPayto.ForeColor = System.Drawing.Color.Red
        Me.lblPayto.Location = New System.Drawing.Point(17, 92)
        Me.lblPayto.Name = "lblPayto"
        Me.lblPayto.Size = New System.Drawing.Size(63, 20)
        Me.lblPayto.TabIndex = 137
        Me.lblPayto.Text = "Pay To"
        '
        'dtpVoucherDate
        '
        Me.dtpVoucherDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpVoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVoucherDate.Location = New System.Drawing.Point(172, 57)
        Me.dtpVoucherDate.Name = "dtpVoucherDate"
        Me.dtpVoucherDate.Size = New System.Drawing.Size(180, 28)
        Me.dtpVoucherDate.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(157, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 20)
        Me.Label4.TabIndex = 136
        Me.Label4.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(157, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = ":"
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.AcceptsReturn = True
        Me.txtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVoucherNo.Location = New System.Drawing.Point(172, 28)
        Me.txtVoucherNo.MaxLength = 50
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(180, 28)
        Me.txtVoucherNo.TabIndex = 1
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = True
        Me.lblVoucherNo.ForeColor = System.Drawing.Color.Red
        Me.lblVoucherNo.Location = New System.Drawing.Point(17, 31)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(153, 20)
        Me.lblVoucherNo.TabIndex = 1
        Me.lblVoucherNo.Text = "Voucher Number"
        '
        'lblVoucherDate
        '
        Me.lblVoucherDate.AutoSize = True
        Me.lblVoucherDate.ForeColor = System.Drawing.Color.Red
        Me.lblVoucherDate.Location = New System.Drawing.Point(17, 61)
        Me.lblVoucherDate.Name = "lblVoucherDate"
        Me.lblVoucherDate.Size = New System.Drawing.Size(124, 20)
        Me.lblVoucherDate.TabIndex = 0
        Me.lblVoucherDate.Text = "Voucher Date"
        '
        'tbView
        '
        Me.tbView.AutoScroll = True
        Me.tbView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbView.Controls.Add(Me.plIPRView)
        Me.tbView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbView.Location = New System.Drawing.Point(4, 29)
        Me.tbView.Name = "tbView"
        Me.tbView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbView.Size = New System.Drawing.Size(1053, 825)
        Me.tbView.TabIndex = 1
        Me.tbView.Text = "View"
        Me.tbView.UseVisualStyleBackColor = True
        '
        'plIPRView
        '
        Me.plIPRView.Controls.Add(Me.dgvPettyCashPaymentView)
        Me.plIPRView.Controls.Add(Me.PnlSearch)
        Me.plIPRView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plIPRView.Location = New System.Drawing.Point(3, 3)
        Me.plIPRView.Name = "plIPRView"
        Me.plIPRView.Size = New System.Drawing.Size(1047, 819)
        Me.plIPRView.TabIndex = 45
        '
        'dgvPettyCashPaymentView
        '
        Me.dgvPettyCashPaymentView.AllowUserToAddRows = False
        Me.dgvPettyCashPaymentView.AllowUserToDeleteRows = False
        Me.dgvPettyCashPaymentView.AllowUserToResizeRows = False
        Me.dgvPettyCashPaymentView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPettyCashPaymentView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPettyCashPaymentView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPettyCashPaymentView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPettyCashPaymentView.ColumnHeadersHeight = 30
        Me.dgvPettyCashPaymentView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclVoucherNo, Me.dgclRejectedReason, Me.dgclPayToID, Me.dgclVoucherDate, Me.dgclDistributionDescp, Me.dgclPaidTo, Me.dgclPaymentID, Me.dgclDiscrepancyTransaction, Me.dgclDescription, Me.dgclApproved})
        Me.dgvPettyCashPaymentView.ContextMenuStrip = Me.cmsPCP
        Me.dgvPettyCashPaymentView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPettyCashPaymentView.EnableHeadersVisualStyles = False
        Me.dgvPettyCashPaymentView.GridColor = System.Drawing.Color.Gray
        Me.dgvPettyCashPaymentView.Location = New System.Drawing.Point(0, 168)
        Me.dgvPettyCashPaymentView.MultiSelect = False
        Me.dgvPettyCashPaymentView.Name = "dgvPettyCashPaymentView"
        Me.dgvPettyCashPaymentView.ReadOnly = True
        Me.dgvPettyCashPaymentView.RowHeadersVisible = False
        Me.dgvPettyCashPaymentView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPettyCashPaymentView.Size = New System.Drawing.Size(1047, 651)
        Me.dgvPettyCashPaymentView.TabIndex = 105
        '
        'dgclVoucherNo
        '
        Me.dgclVoucherNo.DataPropertyName = "VoucherNo"
        Me.dgclVoucherNo.HeaderText = "Voucher No"
        Me.dgclVoucherNo.Name = "dgclVoucherNo"
        Me.dgclVoucherNo.ReadOnly = True
        '
        'dgclRejectedReason
        '
        Me.dgclRejectedReason.DataPropertyName = "RejectedReason"
        Me.dgclRejectedReason.HeaderText = "RejectedReason"
        Me.dgclRejectedReason.Name = "dgclRejectedReason"
        Me.dgclRejectedReason.ReadOnly = True
        Me.dgclRejectedReason.Visible = False
        '
        'dgclPayToID
        '
        Me.dgclPayToID.DataPropertyName = "PayToID"
        Me.dgclPayToID.HeaderText = "PayToID"
        Me.dgclPayToID.Name = "dgclPayToID"
        Me.dgclPayToID.ReadOnly = True
        Me.dgclPayToID.Visible = False
        '
        'dgclVoucherDate
        '
        Me.dgclVoucherDate.DataPropertyName = "VoucherDate"
        DataGridViewCellStyle4.Format = "dd/MM/yyyy"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.dgclVoucherDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgclVoucherDate.HeaderText = "Voucher Date"
        Me.dgclVoucherDate.Name = "dgclVoucherDate"
        Me.dgclVoucherDate.ReadOnly = True
        Me.dgclVoucherDate.Width = 150
        '
        'dgclDistributionDescp
        '
        Me.dgclDistributionDescp.DataPropertyName = "DistributionDescp"
        Me.dgclDistributionDescp.HeaderText = "PayTo"
        Me.dgclDistributionDescp.Name = "dgclDistributionDescp"
        Me.dgclDistributionDescp.ReadOnly = True
        Me.dgclDistributionDescp.Visible = False
        Me.dgclDistributionDescp.Width = 150
        '
        'dgclPaidTo
        '
        Me.dgclPaidTo.DataPropertyName = "PaidTo"
        Me.dgclPaidTo.HeaderText = "Pay To"
        Me.dgclPaidTo.Name = "dgclPaidTo"
        Me.dgclPaidTo.ReadOnly = True
        '
        'dgclPaymentID
        '
        Me.dgclPaymentID.DataPropertyName = "PaymentID"
        Me.dgclPaymentID.HeaderText = "PaymentID"
        Me.dgclPaymentID.Name = "dgclPaymentID"
        Me.dgclPaymentID.ReadOnly = True
        Me.dgclPaymentID.Visible = False
        '
        'dgclDiscrepancyTransaction
        '
        Me.dgclDiscrepancyTransaction.DataPropertyName = "DiscrepancyTransaction"
        Me.dgclDiscrepancyTransaction.HeaderText = "DiscrepancyTransaction"
        Me.dgclDiscrepancyTransaction.Name = "dgclDiscrepancyTransaction"
        Me.dgclDiscrepancyTransaction.ReadOnly = True
        Me.dgclDiscrepancyTransaction.Visible = False
        '
        'dgclDescription
        '
        Me.dgclDescription.DataPropertyName = "PayDescp"
        Me.dgclDescription.HeaderText = "Description"
        Me.dgclDescription.Name = "dgclDescription"
        Me.dgclDescription.ReadOnly = True
        Me.dgclDescription.Visible = False
        '
        'dgclApproved
        '
        Me.dgclApproved.DataPropertyName = "Approved"
        Me.dgclApproved.HeaderText = "Status"
        Me.dgclApproved.Name = "dgclApproved"
        Me.dgclApproved.ReadOnly = True
        '
        'cmsPCP
        '
        Me.cmsPCP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsPCP.Name = "cmsIPR"
        Me.cmsPCP.Size = New System.Drawing.Size(135, 94)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(134, 30)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(134, 30)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(134, 30)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PnlSearch
        '
        Me.PnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlSearch.BorderColor = System.Drawing.Color.Gray
        Me.PnlSearch.CaptionColorOne = System.Drawing.Color.White
        Me.PnlSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlSearch.CaptionSize = 40
        Me.PnlSearch.CaptionText = "Search Petty Cash Payment"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.lblsearchBy)
        Me.PnlSearch.Controls.Add(Me.lblSearchStatus)
        Me.PnlSearch.Controls.Add(Me.cmbSearchStatus)
        Me.PnlSearch.Controls.Add(Me.txtVoucherNoSearch)
        Me.PnlSearch.Controls.Add(Me.chkVoucherDate)
        Me.PnlSearch.Controls.Add(Me.btnviewReport)
        Me.PnlSearch.Controls.Add(Me.lblvoucherNoSearch)
        Me.PnlSearch.Controls.Add(Me.dtpviewVoucherDate)
        Me.PnlSearch.Controls.Add(Me.btnSearch)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.ForeColor = System.Drawing.Color.Black
        Me.PnlSearch.Location = New System.Drawing.Point(0, 0)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(1047, 168)
        Me.PnlSearch.TabIndex = 116
        '
        'lblsearchBy
        '
        Me.lblsearchBy.AutoSize = True
        Me.lblsearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblsearchBy.Location = New System.Drawing.Point(1, 59)
        Me.lblsearchBy.Name = "lblsearchBy"
        Me.lblsearchBy.Size = New System.Drawing.Size(103, 20)
        Me.lblsearchBy.TabIndex = 54
        Me.lblsearchBy.Text = "Search By"
        '
        'lblSearchStatus
        '
        Me.lblSearchStatus.AutoSize = True
        Me.lblSearchStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSearchStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSearchStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchStatus.Location = New System.Drawing.Point(436, 61)
        Me.lblSearchStatus.Name = "lblSearchStatus"
        Me.lblSearchStatus.Size = New System.Drawing.Size(65, 20)
        Me.lblSearchStatus.TabIndex = 223
        Me.lblSearchStatus.Text = "Status"
        '
        'cmbSearchStatus
        '
        Me.cmbSearchStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchStatus.FormattingEnabled = True
        Me.cmbSearchStatus.Items.AddRange(New Object() {"Select All", "OPEN", "APPROVED"})
        Me.cmbSearchStatus.Location = New System.Drawing.Point(439, 92)
        Me.cmbSearchStatus.Name = "cmbSearchStatus"
        Me.cmbSearchStatus.Size = New System.Drawing.Size(140, 28)
        Me.cmbSearchStatus.TabIndex = 103
        '
        'txtVoucherNoSearch
        '
        Me.txtVoucherNoSearch.Location = New System.Drawing.Point(289, 92)
        Me.txtVoucherNoSearch.Name = "txtVoucherNoSearch"
        Me.txtVoucherNoSearch.Size = New System.Drawing.Size(140, 28)
        Me.txtVoucherNoSearch.TabIndex = 102
        '
        'chkVoucherDate
        '
        Me.chkVoucherDate.AutoSize = True
        Me.chkVoucherDate.Location = New System.Drawing.Point(142, 59)
        Me.chkVoucherDate.Name = "chkVoucherDate"
        Me.chkVoucherDate.Size = New System.Drawing.Size(150, 24)
        Me.chkVoucherDate.TabIndex = 100
        Me.chkVoucherDate.Text = "Voucher Date"
        Me.chkVoucherDate.UseVisualStyleBackColor = True
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(724, 90)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(122, 25)
        Me.btnviewReport.TabIndex = 105
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'lblvoucherNoSearch
        '
        Me.lblvoucherNoSearch.AutoSize = True
        Me.lblvoucherNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblvoucherNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblvoucherNoSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblvoucherNoSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblvoucherNoSearch.Location = New System.Drawing.Point(287, 61)
        Me.lblvoucherNoSearch.Name = "lblvoucherNoSearch"
        Me.lblvoucherNoSearch.Size = New System.Drawing.Size(107, 20)
        Me.lblvoucherNoSearch.TabIndex = 120
        Me.lblvoucherNoSearch.Text = "Voucher No"
        '
        'dtpviewVoucherDate
        '
        Me.dtpviewVoucherDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpviewVoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpviewVoucherDate.Location = New System.Drawing.Point(137, 92)
        Me.dtpviewVoucherDate.Name = "dtpviewVoucherDate"
        Me.dtpviewVoucherDate.Size = New System.Drawing.Size(140, 28)
        Me.dtpviewVoucherDate.TabIndex = 101
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(593, 90)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 104
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(137, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 20)
        Me.Label5.TabIndex = 268
        Me.Label5.Text = ":"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(137, 181)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 20)
        Me.Label13.TabIndex = 269
        Me.Label13.Text = ":"
        '
        'DgMeTransactionType
        '
        Me.DgMeTransactionType.DataPropertyName = "TransactionType"
        Me.DgMeTransactionType.HeaderText = "Transaction Type"
        Me.DgMeTransactionType.Name = "DgMeTransactionType"
        Me.DgMeTransactionType.ReadOnly = True
        Me.DgMeTransactionType.Width = 140
        '
        'VHID
        '
        Me.VHID.DataPropertyName = "VHID"
        Me.VHID.HeaderText = "VHID"
        Me.VHID.Name = "VHID"
        Me.VHID.ReadOnly = True
        Me.VHID.Visible = False
        '
        'VHDetailCostCodeID
        '
        Me.VHDetailCostCodeID.DataPropertyName = "VHDetailCostCodeID"
        Me.VHDetailCostCodeID.HeaderText = "VHDetailCostCodeID"
        Me.VHDetailCostCodeID.Name = "VHDetailCostCodeID"
        Me.VHDetailCostCodeID.ReadOnly = True
        Me.VHDetailCostCodeID.Visible = False
        '
        'DgMeAccountCode
        '
        Me.DgMeAccountCode.DataPropertyName = "COACode"
        Me.DgMeAccountCode.HeaderText = "Account Code"
        Me.DgMeAccountCode.Name = "DgMeAccountCode"
        Me.DgMeAccountCode.ReadOnly = True
        Me.DgMeAccountCode.Width = 110
        '
        'dgMeUOMID
        '
        Me.dgMeUOMID.DataPropertyName = "UOMID"
        Me.dgMeUOMID.HeaderText = "UOMID"
        Me.dgMeUOMID.Name = "dgMeUOMID"
        Me.dgMeUOMID.ReadOnly = True
        Me.dgMeUOMID.Visible = False
        '
        'dgMeUOMDescp
        '
        Me.dgMeUOMDescp.DataPropertyName = "UOMDescp"
        Me.dgMeUOMDescp.HeaderText = "UOMDescp"
        Me.dgMeUOMDescp.Name = "dgMeUOMDescp"
        Me.dgMeUOMDescp.ReadOnly = True
        Me.dgMeUOMDescp.Visible = False
        '
        'dgmeOldCOACode
        '
        Me.dgmeOldCOACode.DataPropertyName = "OldCOACode"
        Me.dgmeOldCOACode.HeaderText = "Old COA Code"
        Me.dgmeOldCOACode.Name = "dgmeOldCOACode"
        Me.dgmeOldCOACode.ReadOnly = True
        '
        'DgMeAccountDescp
        '
        Me.DgMeAccountDescp.DataPropertyName = "COADescp"
        Me.DgMeAccountDescp.HeaderText = "Account Descp"
        Me.DgMeAccountDescp.Name = "DgMeAccountDescp"
        Me.DgMeAccountDescp.ReadOnly = True
        '
        'DgMeAmount
        '
        Me.DgMeAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DgMeAmount.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgMeAmount.HeaderText = "Amount"
        Me.DgMeAmount.Name = "DgMeAmount"
        Me.DgMeAmount.ReadOnly = True
        Me.DgMeAmount.Width = 140
        '
        'DgMeQty
        '
        Me.DgMeQty.DataPropertyName = "Qty"
        Me.DgMeQty.HeaderText = "Qty"
        Me.DgMeQty.Name = "DgMeQty"
        Me.DgMeQty.ReadOnly = True
        Me.DgMeQty.Width = 140
        '
        'dgMeUOM
        '
        Me.dgMeUOM.DataPropertyName = "UOM"
        Me.dgMeUOM.HeaderText = "Unit"
        Me.dgMeUOM.Name = "dgMeUOM"
        Me.dgMeUOM.ReadOnly = True
        Me.dgMeUOM.Width = 40
        '
        'VHWSCode
        '
        Me.VHWSCode.DataPropertyName = "VHWSCode"
        Me.VHWSCode.HeaderText = "Vehicle Code"
        Me.VHWSCode.Name = "VHWSCode"
        Me.VHWSCode.ReadOnly = True
        '
        'VHDetailCostCode
        '
        Me.VHDetailCostCode.DataPropertyName = "VHDetailCostCode"
        Me.VHDetailCostCode.HeaderText = "Detail Code"
        Me.VHDetailCostCode.Name = "VHDetailCostCode"
        Me.VHDetailCostCode.ReadOnly = True
        '
        'DgMeTAnalysisCode0
        '
        Me.DgMeTAnalysisCode0.DataPropertyName = "TAnalysisCode0"
        Me.DgMeTAnalysisCode0.HeaderText = "T0"
        Me.DgMeTAnalysisCode0.Name = "DgMeTAnalysisCode0"
        Me.DgMeTAnalysisCode0.ReadOnly = True
        Me.DgMeTAnalysisCode0.Width = 40
        '
        'DgMeTAnalysisCode1
        '
        Me.DgMeTAnalysisCode1.DataPropertyName = "TAnalysisCode1"
        Me.DgMeTAnalysisCode1.HeaderText = "T1"
        Me.DgMeTAnalysisCode1.Name = "DgMeTAnalysisCode1"
        Me.DgMeTAnalysisCode1.ReadOnly = True
        Me.DgMeTAnalysisCode1.Width = 40
        '
        'DgMeTAnalysisCode2
        '
        Me.DgMeTAnalysisCode2.DataPropertyName = "TAnalysisCode2"
        Me.DgMeTAnalysisCode2.HeaderText = "T2"
        Me.DgMeTAnalysisCode2.Name = "DgMeTAnalysisCode2"
        Me.DgMeTAnalysisCode2.ReadOnly = True
        Me.DgMeTAnalysisCode2.Width = 40
        '
        'DgMeTAnalysisCode3
        '
        Me.DgMeTAnalysisCode3.DataPropertyName = "TAnalysisCode3"
        Me.DgMeTAnalysisCode3.HeaderText = "T3"
        Me.DgMeTAnalysisCode3.Name = "DgMeTAnalysisCode3"
        Me.DgMeTAnalysisCode3.ReadOnly = True
        Me.DgMeTAnalysisCode3.Width = 40
        '
        'DgMeTAnalysisCode4
        '
        Me.DgMeTAnalysisCode4.DataPropertyName = "TAnalysisCode4"
        Me.DgMeTAnalysisCode4.HeaderText = "T4"
        Me.DgMeTAnalysisCode4.Name = "DgMeTAnalysisCode4"
        Me.DgMeTAnalysisCode4.ReadOnly = True
        Me.DgMeTAnalysisCode4.Width = 40
        '
        'DgMeCOAID
        '
        Me.DgMeCOAID.DataPropertyName = "COAID"
        Me.DgMeCOAID.HeaderText = "COAID"
        Me.DgMeCOAID.Name = "DgMeCOAID"
        Me.DgMeCOAID.ReadOnly = True
        Me.DgMeCOAID.Visible = False
        '
        'DgMeTAnalysisDescp0
        '
        Me.DgMeTAnalysisDescp0.DataPropertyName = "TAnalysisDescp0"
        Me.DgMeTAnalysisDescp0.HeaderText = "TAnalysisDescp0"
        Me.DgMeTAnalysisDescp0.Name = "DgMeTAnalysisDescp0"
        Me.DgMeTAnalysisDescp0.ReadOnly = True
        Me.DgMeTAnalysisDescp0.Visible = False
        '
        'DgMeTAnalysisDescp1
        '
        Me.DgMeTAnalysisDescp1.DataPropertyName = "TAnalysisDescp1"
        Me.DgMeTAnalysisDescp1.HeaderText = "TAnalysisDescp1"
        Me.DgMeTAnalysisDescp1.Name = "DgMeTAnalysisDescp1"
        Me.DgMeTAnalysisDescp1.ReadOnly = True
        Me.DgMeTAnalysisDescp1.Visible = False
        '
        'DgMeTAnalysisDescp2
        '
        Me.DgMeTAnalysisDescp2.DataPropertyName = "TAnalysisDescp2"
        Me.DgMeTAnalysisDescp2.HeaderText = "TAnalysisDescp2"
        Me.DgMeTAnalysisDescp2.Name = "DgMeTAnalysisDescp2"
        Me.DgMeTAnalysisDescp2.ReadOnly = True
        Me.DgMeTAnalysisDescp2.Visible = False
        '
        'DgMeTAnalysisDescp3
        '
        Me.DgMeTAnalysisDescp3.DataPropertyName = "TAnalysisDescp3"
        Me.DgMeTAnalysisDescp3.HeaderText = "TAnalysisDescp3"
        Me.DgMeTAnalysisDescp3.Name = "DgMeTAnalysisDescp3"
        Me.DgMeTAnalysisDescp3.ReadOnly = True
        Me.DgMeTAnalysisDescp3.Visible = False
        '
        'DgMeTAnalysisDescp4
        '
        Me.DgMeTAnalysisDescp4.DataPropertyName = "TAnalysisDescp4"
        Me.DgMeTAnalysisDescp4.HeaderText = "TAnalysisDescp4"
        Me.DgMeTAnalysisDescp4.Name = "DgMeTAnalysisDescp4"
        Me.DgMeTAnalysisDescp4.ReadOnly = True
        Me.DgMeTAnalysisDescp4.Visible = False
        '
        'DgMeT0
        '
        Me.DgMeT0.DataPropertyName = "T0"
        Me.DgMeT0.HeaderText = "T0"
        Me.DgMeT0.Name = "DgMeT0"
        Me.DgMeT0.ReadOnly = True
        Me.DgMeT0.Visible = False
        '
        'DgMeT1
        '
        Me.DgMeT1.DataPropertyName = "T1"
        Me.DgMeT1.HeaderText = "T1"
        Me.DgMeT1.Name = "DgMeT1"
        Me.DgMeT1.ReadOnly = True
        Me.DgMeT1.Visible = False
        '
        'DgMeT2
        '
        Me.DgMeT2.DataPropertyName = "T2"
        Me.DgMeT2.HeaderText = "T2"
        Me.DgMeT2.Name = "DgMeT2"
        Me.DgMeT2.ReadOnly = True
        Me.DgMeT2.Visible = False
        '
        'DgMeT3
        '
        Me.DgMeT3.DataPropertyName = "T3"
        Me.DgMeT3.HeaderText = "T3"
        Me.DgMeT3.Name = "DgMeT3"
        Me.DgMeT3.ReadOnly = True
        Me.DgMeT3.Visible = False
        '
        'DgMeT4
        '
        Me.DgMeT4.DataPropertyName = "T4"
        Me.DgMeT4.HeaderText = "T4"
        Me.DgMeT4.Name = "DgMeT4"
        Me.DgMeT4.ReadOnly = True
        Me.DgMeT4.Visible = False
        '
        'DgMePaymentID
        '
        Me.DgMePaymentID.DataPropertyName = "PaymentID"
        Me.DgMePaymentID.HeaderText = "PaymentID"
        Me.DgMePaymentID.Name = "DgMePaymentID"
        Me.DgMePaymentID.ReadOnly = True
        Me.DgMePaymentID.Visible = False
        '
        'DgMeremarks
        '
        Me.DgMeremarks.DataPropertyName = "Remarks"
        Me.DgMeremarks.HeaderText = "Description"
        Me.DgMeremarks.Name = "DgMeremarks"
        Me.DgMeremarks.ReadOnly = True
        '
        'PettyCashPaymentFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1061, 858)
        Me.Controls.Add(Me.tbPCP)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "PettyCashPaymentFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PettyCastPaymentFrm"
        Me.tbPCP.ResumeLayout(False)
        Me.tbAdd.ResumeLayout(False)
        CType(Me.DgvMultipleEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSMultipleentry.ResumeLayout(False)
        Me.grpVoucherDetails.ResumeLayout(False)
        Me.grpVoucherDetails.PerformLayout()
        Me.grpApproval.ResumeLayout(False)
        Me.grpApproval.PerformLayout()
        Me.grpVoucherNo.ResumeLayout(False)
        Me.grpVoucherNo.PerformLayout()
        Me.tbView.ResumeLayout(False)
        Me.plIPRView.ResumeLayout(False)
        CType(Me.dgvPettyCashPaymentView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPCP.ResumeLayout(False)
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbPCP As System.Windows.Forms.TabControl
    Friend WithEvents tbAdd As System.Windows.Forms.TabPage
    Friend WithEvents grpVoucherNo As System.Windows.Forms.GroupBox
    Friend WithEvents dtpVoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Friend WithEvents lblVoucherNo As System.Windows.Forms.Label
    Friend WithEvents lblVoucherDate As System.Windows.Forms.Label
    Friend WithEvents tbView As System.Windows.Forms.TabPage
    Friend WithEvents plIPRView As System.Windows.Forms.Panel
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents dtpviewVoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblStatusValue As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPayto As System.Windows.Forms.Label
    Friend WithEvents cbDiscrepancytransaction As System.Windows.Forms.CheckBox
    Friend WithEvents txtDescp As System.Windows.Forms.TextBox
    Friend WithEvents grpVoucherDetails As System.Windows.Forms.GroupBox
    Friend WithEvents btnAccountCodeLookup As System.Windows.Forms.Button
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountCode As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnSearchT4 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT3 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT2 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT1 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT0 As System.Windows.Forms.Button
    Friend WithEvents txtT4 As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblT4 As System.Windows.Forms.Label
    Friend WithEvents txtT3 As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblT3 As System.Windows.Forms.Label
    Friend WithEvents txtT2 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblT2 As System.Windows.Forms.Label
    Friend WithEvents txtT1 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblT1 As System.Windows.Forms.Label
    Friend WithEvents txtT0 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblT0 As System.Windows.Forms.Label
    Friend WithEvents lblT4Name As System.Windows.Forms.Label
    Friend WithEvents lblT3Name As System.Windows.Forms.Label
    Friend WithEvents lblT2Name As System.Windows.Forms.Label
    Friend WithEvents lblT1Name As System.Windows.Forms.Label
    Friend WithEvents lblT0Name As System.Windows.Forms.Label
    Friend WithEvents lblAccountDescp As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents chkVoucherDate As System.Windows.Forms.CheckBox
    Friend WithEvents txtVoucherNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblvoucherNoSearch As System.Windows.Forms.Label
    Friend WithEvents dgvPettyCashPaymentView As System.Windows.Forms.DataGridView
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents cmsPCP As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DgvMultipleEntry As System.Windows.Forms.DataGridView
    Friend WithEvents btnResetMultipleEntryGrp As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents CMSMultipleentry As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnResetIB As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents CbPayTo As System.Windows.Forms.ComboBox
    Friend WithEvents lblOldAccountCode As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grpApproval As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnConform As System.Windows.Forms.Button
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatusApproval As System.Windows.Forms.Label
    Friend WithEvents lblSearchStatus As System.Windows.Forms.Label
    Friend WithEvents cmbSearchStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtRejectedReason As System.Windows.Forms.TextBox
    Friend WithEvents lblRejColon As System.Windows.Forms.Label
    Friend WithEvents lblRejReason As System.Windows.Forms.Label
    Friend WithEvents lblRejectedReasonValue As System.Windows.Forms.Label
    Friend WithEvents lblColon As System.Windows.Forms.Label
    Friend WithEvents lblRecjectedReason As System.Windows.Forms.Label
    Friend WithEvents lblUOMDescp As System.Windows.Forms.Label
    Friend WithEvents btnUOM As System.Windows.Forms.Button
    Friend WithEvents txtUOM As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents dtpApprovalDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblColon13 As System.Windows.Forms.Label
    Friend WithEvents lblApprovalDate As System.Windows.Forms.Label
    Friend WithEvents lblDescp As System.Windows.Forms.Label
    Friend WithEvents txtPaidTo As System.Windows.Forms.TextBox
    Friend WithEvents dgclVoucherNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPayToID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVoucherDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDistributionDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPaidTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPaymentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDiscrepancyTransaction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclApproved As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents ddlTranscationType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTrancactionType As System.Windows.Forms.Label
    Friend WithEvents lblDetailCostDescp As System.Windows.Forms.Label
    Friend WithEvents lblVehicleDescp As System.Windows.Forms.Label
    Friend WithEvents btnSearchVehicleDetailCostCode As System.Windows.Forms.Button
    Friend WithEvents btnSearchVehicleCode As System.Windows.Forms.Button
    Friend WithEvents lblVehicleCode As System.Windows.Forms.Label
    Friend WithEvents txtDetailCostCode As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDetailCostCode As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DgMeTransactionType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDetailCostCodeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeAccountCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeUOMID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeUOMDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgmeOldCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeAccountDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeUOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHWSCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDetailCostCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeTAnalysisCode0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeTAnalysisCode1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeTAnalysisCode2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeTAnalysisCode3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeTAnalysisCode4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeTAnalysisDescp0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeTAnalysisDescp1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeTAnalysisDescp2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeTAnalysisDescp3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeTAnalysisDescp4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeT0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeT2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeT3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeT4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMePaymentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeremarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JournalFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JournalFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbJournal = New System.Windows.Forms.TabControl()
        Me.tbAdd = New System.Windows.Forms.TabPage()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.btnApprovalClose = New System.Windows.Forms.Button()
        Me.btnResetMultipleEntryGrp = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvMultipleEntry = New System.Windows.Forms.DataGridView()
        Me.dgMeAccJournalID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeOldCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeCOADescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeDivID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeYOPID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeBlockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeVHID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeVHDetailCostCodeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgmeVHType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeDiv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeYOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeSubBlock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeStationCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeVHWSCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeVHDetailCostCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeStationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeTAnalysisCode0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeTAnalysisCode1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeTAnalysisCode2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeTAnalysisCode3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeTAnalysisCode4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeT0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeT1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeT2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeT3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeT4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeTAnalysisDescp0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeDivName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeYOPName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeBlockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeStationDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgVHDetailCostDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgmeVehicleDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeTAnalysisDescp1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeTAnalysisDescp2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeTAnalysisDescp3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeTAnalysisDescp4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMSMultipleentry = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCreditKeenValue = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblDebitKeenValue = New System.Windows.Forms.Label()
        Me.txtDebitKeenValue = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblCreditKeenValue = New System.Windows.Forms.Label()
        Me.grpTAnalysis = New System.Windows.Forms.GroupBox()
        Me.grpApproval = New System.Windows.Forms.GroupBox()
        Me.txtRejectedReason = New System.Windows.Forms.TextBox()
        Me.lblRejColon = New System.Windows.Forms.Label()
        Me.lblRejReason = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnConform = New System.Windows.Forms.Button()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatusApproval = New System.Windows.Forms.Label()
        Me.lblT4Name = New System.Windows.Forms.Label()
        Me.lblT3Name = New System.Windows.Forms.Label()
        Me.lblT2Name = New System.Windows.Forms.Label()
        Me.lblT1Name = New System.Windows.Forms.Label()
        Me.lblT0Name = New System.Windows.Forms.Label()
        Me.lblStationDescp = New System.Windows.Forms.Label()
        Me.btnSearchT4 = New System.Windows.Forms.Button()
        Me.btnSearchT3 = New System.Windows.Forms.Button()
        Me.btnSearchT2 = New System.Windows.Forms.Button()
        Me.btnSearchT1 = New System.Windows.Forms.Button()
        Me.btnSearchT0 = New System.Windows.Forms.Button()
        Me.txtT4 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnSearchStation = New System.Windows.Forms.Button()
        Me.lblT4 = New System.Windows.Forms.Label()
        Me.txtT3 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblT3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtT2 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblT2 = New System.Windows.Forms.Label()
        Me.txtStation = New System.Windows.Forms.TextBox()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.txtT1 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblT1 = New System.Windows.Forms.Label()
        Me.txtT0 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblT0 = New System.Windows.Forms.Label()
        Me.grpAccountCode = New System.Windows.Forms.GroupBox()
        Me.txtDescp = New System.Windows.Forms.TextBox()
        Me.lblDescp = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblOldAccountCode = New System.Windows.Forms.Label()
        Me.lblDetailCostDescp = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblVehicleDescp = New System.Windows.Forms.Label()
        Me.lblBlockStatus = New System.Windows.Forms.Label()
        Me.lblYOPName = New System.Windows.Forms.Label()
        Me.lblDivName = New System.Windows.Forms.Label()
        Me.txtAccountCode = New System.Windows.Forms.TextBox()
        Me.txtSubBlock = New System.Windows.Forms.TextBox()
        Me.lblSubBlock = New System.Windows.Forms.Label()
        Me.lblAccountDescp = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnSearchSubBlock = New System.Windows.Forms.Button()
        Me.btnDivSearch = New System.Windows.Forms.Button()
        Me.txtYOP = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnSearchVehicleDetailCostCode = New System.Windows.Forms.Button()
        Me.lblYOP = New System.Windows.Forms.Label()
        Me.txtDiv = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblDiv = New System.Windows.Forms.Label()
        Me.btnAccountCodeLookup = New System.Windows.Forms.Button()
        Me.btnSearchVehicleCode = New System.Windows.Forms.Button()
        Me.lblAccountCode = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblVehicleCode = New System.Windows.Forms.Label()
        Me.txtDetailCostCode = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtVehicleCode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblDetailCostCode = New System.Windows.Forms.Label()
        Me.btnResetIB = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpDedit = New System.Windows.Forms.GroupBox()
        Me.txtDiff = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblDiff = New System.Windows.Forms.Label()
        Me.txtCredit = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblDebit = New System.Windows.Forms.Label()
        Me.txtDebit = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblCredit = New System.Windows.Forms.Label()
        Me.grpLedgerValues = New System.Windows.Forms.GroupBox()
        Me.lblRejectedReasonValue = New System.Windows.Forms.Label()
        Me.lblColon = New System.Windows.Forms.Label()
        Me.lblRecjectedReason = New System.Windows.Forms.Label()
        Me.lblStatusValue = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.chkRecurringJournals = New System.Windows.Forms.CheckBox()
        Me.lblContractName = New System.Windows.Forms.Label()
        Me.ddlLedgerType = New System.Windows.Forms.ComboBox()
        Me.btnSearchContractNo = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtJournalDescp = New System.Windows.Forms.TextBox()
        Me.lblJournalDescp = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblBatchTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblledgerNo = New System.Windows.Forms.Label()
        Me.dtpJournalDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblledgerType = New System.Windows.Forms.Label()
        Me.lblJournalDate = New System.Windows.Forms.Label()
        Me.txtLedgerNo = New System.Windows.Forms.TextBox()
        Me.txtBatchTotal = New System.Windows.Forms.TextBox()
        Me.lblContractNo = New System.Windows.Forms.Label()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.tbView = New System.Windows.Forms.TabPage()
        Me.dgvJournalView = New System.Windows.Forms.DataGridView()
        Me.dgclLedgerType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclJournalDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLedgerNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclAccBatchTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclAccJournalID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclContractNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclJournalDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLedgerSetupID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclAccBatchID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclContractID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclContractName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRecuuringJournal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsJournal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnlSearch = New Stepi.UI.ExtendedPanel()
        Me.lblSearchStatus = New System.Windows.Forms.Label()
        Me.cmbSearchStatus = New System.Windows.Forms.ComboBox()
        Me.btnviewReport = New System.Windows.Forms.Button()
        Me.ddlLedgerTypeSearch = New System.Windows.Forms.ComboBox()
        Me.lblLedgerNoSearch = New System.Windows.Forms.Label()
        Me.lblLedgerTypeSearch = New System.Windows.Forms.Label()
        Me.txtLedgerNoSearch = New System.Windows.Forms.TextBox()
        Me.lblsearchBy = New System.Windows.Forms.Label()
        Me.chkJournalDate = New System.Windows.Forms.CheckBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dtpviewJournalDate = New System.Windows.Forms.DateTimePicker()
        Me.tbJournal.SuspendLayout()
        Me.tbAdd.SuspendLayout()
        CType(Me.dgvMultipleEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSMultipleentry.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpTAnalysis.SuspendLayout()
        Me.grpApproval.SuspendLayout()
        Me.grpAccountCode.SuspendLayout()
        Me.grpDedit.SuspendLayout()
        Me.grpLedgerValues.SuspendLayout()
        Me.tbView.SuspendLayout()
        CType(Me.dgvJournalView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsJournal.SuspendLayout()
        Me.PnlSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbJournal
        '
        Me.tbJournal.Controls.Add(Me.tbAdd)
        Me.tbJournal.Controls.Add(Me.tbView)
        Me.tbJournal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbJournal.Location = New System.Drawing.Point(0, 0)
        Me.tbJournal.Name = "tbJournal"
        Me.tbJournal.SelectedIndex = 0
        Me.tbJournal.Size = New System.Drawing.Size(1014, 698)
        Me.tbJournal.TabIndex = 203
        '
        'tbAdd
        '
        Me.tbAdd.AutoScroll = True
        Me.tbAdd.BackColor = System.Drawing.Color.Transparent
        Me.tbAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbAdd.Controls.Add(Me.btnDeleteAll)
        Me.tbAdd.Controls.Add(Me.btnApprovalClose)
        Me.tbAdd.Controls.Add(Me.btnResetMultipleEntryGrp)
        Me.tbAdd.Controls.Add(Me.btnAdd)
        Me.tbAdd.Controls.Add(Me.dgvMultipleEntry)
        Me.tbAdd.Controls.Add(Me.GroupBox1)
        Me.tbAdd.Controls.Add(Me.grpTAnalysis)
        Me.tbAdd.Controls.Add(Me.grpAccountCode)
        Me.tbAdd.Controls.Add(Me.btnResetIB)
        Me.tbAdd.Controls.Add(Me.btnSave)
        Me.tbAdd.Controls.Add(Me.btnClose)
        Me.tbAdd.Controls.Add(Me.grpDedit)
        Me.tbAdd.Controls.Add(Me.grpLedgerValues)
        Me.tbAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAdd.Location = New System.Drawing.Point(4, 22)
        Me.tbAdd.Name = "tbAdd"
        Me.tbAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAdd.Size = New System.Drawing.Size(1006, 672)
        Me.tbAdd.TabIndex = 0
        Me.tbAdd.Text = "Journal"
        Me.tbAdd.UseVisualStyleBackColor = True
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnDeleteAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteAll.Image = Global.BSP.My.Resources.Resources.icon_delete
        Me.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteAll.Location = New System.Drawing.Point(801, 717)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(117, 25)
        Me.btnDeleteAll.TabIndex = 45
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        Me.btnDeleteAll.Visible = False
        '
        'btnApprovalClose
        '
        Me.btnApprovalClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnApprovalClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnApprovalClose.Image = CType(resources.GetObject("btnApprovalClose.Image"), System.Drawing.Image)
        Me.btnApprovalClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApprovalClose.Location = New System.Drawing.Point(548, 532)
        Me.btnApprovalClose.Name = "btnApprovalClose"
        Me.btnApprovalClose.Size = New System.Drawing.Size(117, 25)
        Me.btnApprovalClose.TabIndex = 108
        Me.btnApprovalClose.Text = "Close"
        Me.btnApprovalClose.UseVisualStyleBackColor = True
        '
        'btnResetMultipleEntryGrp
        '
        Me.btnResetMultipleEntryGrp.BackgroundImage = CType(resources.GetObject("btnResetMultipleEntryGrp.BackgroundImage"), System.Drawing.Image)
        Me.btnResetMultipleEntryGrp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetMultipleEntryGrp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetMultipleEntryGrp.Image = CType(resources.GetObject("btnResetMultipleEntryGrp.Image"), System.Drawing.Image)
        Me.btnResetMultipleEntryGrp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetMultipleEntryGrp.Location = New System.Drawing.Point(796, 532)
        Me.btnResetMultipleEntryGrp.Name = "btnResetMultipleEntryGrp"
        Me.btnResetMultipleEntryGrp.Size = New System.Drawing.Size(117, 25)
        Me.btnResetMultipleEntryGrp.TabIndex = 41
        Me.btnResetMultipleEntryGrp.Text = "Reset"
        Me.btnResetMultipleEntryGrp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnResetMultipleEntryGrp.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(673, 532)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(117, 25)
        Me.btnAdd.TabIndex = 40
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvMultipleEntry
        '
        Me.dgvMultipleEntry.AllowUserToAddRows = False
        Me.dgvMultipleEntry.AllowUserToDeleteRows = False
        Me.dgvMultipleEntry.AllowUserToResizeRows = False
        Me.dgvMultipleEntry.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvMultipleEntry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMultipleEntry.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMultipleEntry.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMultipleEntry.ColumnHeadersHeight = 30
        Me.dgvMultipleEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgMeAccJournalID, Me.DgMeCOACode, Me.dgMeOldCOACode, Me.DgMeCOADescp, Me.dgMeDescription, Me.dgMeDebit, Me.dgMeCredit, Me.DgMeDivID, Me.DgMeYOPID, Me.DgMeBlockID, Me.DgMeVHID, Me.dgMeVHDetailCostCodeID, Me.dgmeVHType, Me.DgMeDiv, Me.dgMeYOP, Me.DgMeSubBlock, Me.DgMeStationCode, Me.dgMeVHWSCode, Me.dgMeVHDetailCostCode, Me.DgMeStationID, Me.dgMeTAnalysisCode0, Me.dgMeTAnalysisCode1, Me.dgMeTAnalysisCode2, Me.dgMeTAnalysisCode3, Me.dgMeTAnalysisCode4, Me.dgMeCOAID, Me.dgMeT0, Me.dgMeT1, Me.dgMeT2, Me.dgMeT3, Me.dgMeT4, Me.dgMeTAnalysisDescp0, Me.dgMeDivName, Me.dgMeYOPName, Me.dgMeBlockStatus, Me.dgMeStationDescp, Me.dgVHDetailCostDescp, Me.DgmeVehicleDescp, Me.dgMeTAnalysisDescp1, Me.dgMeTAnalysisDescp2, Me.dgMeTAnalysisDescp3, Me.dgMeTAnalysisDescp4})
        Me.dgvMultipleEntry.ContextMenuStrip = Me.CMSMultipleentry
        Me.dgvMultipleEntry.EnableHeadersVisualStyles = False
        Me.dgvMultipleEntry.GridColor = System.Drawing.Color.Gray
        Me.dgvMultipleEntry.Location = New System.Drawing.Point(-1, 577)
        Me.dgvMultipleEntry.MultiSelect = False
        Me.dgvMultipleEntry.Name = "dgvMultipleEntry"
        Me.dgvMultipleEntry.ReadOnly = True
        Me.dgvMultipleEntry.RowHeadersVisible = False
        Me.dgvMultipleEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMultipleEntry.Size = New System.Drawing.Size(914, 127)
        Me.dgvMultipleEntry.TabIndex = 107
        '
        'dgMeAccJournalID
        '
        Me.dgMeAccJournalID.DataPropertyName = "AccJournalID"
        Me.dgMeAccJournalID.HeaderText = "AccJournalID"
        Me.dgMeAccJournalID.Name = "dgMeAccJournalID"
        Me.dgMeAccJournalID.ReadOnly = True
        Me.dgMeAccJournalID.Visible = False
        '
        'DgMeCOACode
        '
        Me.DgMeCOACode.DataPropertyName = "COACode"
        Me.DgMeCOACode.HeaderText = "Account Code"
        Me.DgMeCOACode.Name = "DgMeCOACode"
        Me.DgMeCOACode.ReadOnly = True
        Me.DgMeCOACode.Width = 110
        '
        'dgMeOldCOACode
        '
        Me.dgMeOldCOACode.DataPropertyName = "OldCOACode"
        Me.dgMeOldCOACode.HeaderText = "Old Account Code"
        Me.dgMeOldCOACode.Name = "dgMeOldCOACode"
        Me.dgMeOldCOACode.ReadOnly = True
        '
        'DgMeCOADescp
        '
        Me.DgMeCOADescp.DataPropertyName = "COADescp"
        Me.DgMeCOADescp.HeaderText = "Account Descp"
        Me.DgMeCOADescp.Name = "DgMeCOADescp"
        Me.DgMeCOADescp.ReadOnly = True
        '
        'dgMeDescription
        '
        Me.dgMeDescription.DataPropertyName = "Description"
        Me.dgMeDescription.HeaderText = "Description"
        Me.dgMeDescription.Name = "dgMeDescription"
        Me.dgMeDescription.ReadOnly = True
        '
        'dgMeDebit
        '
        Me.dgMeDebit.DataPropertyName = "Debit"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgMeDebit.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgMeDebit.HeaderText = "Debit"
        Me.dgMeDebit.Name = "dgMeDebit"
        Me.dgMeDebit.ReadOnly = True
        Me.dgMeDebit.Width = 140
        '
        'dgMeCredit
        '
        Me.dgMeCredit.DataPropertyName = "Credit"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgMeCredit.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgMeCredit.HeaderText = "Credit"
        Me.dgMeCredit.Name = "dgMeCredit"
        Me.dgMeCredit.ReadOnly = True
        Me.dgMeCredit.Width = 140
        '
        'DgMeDivID
        '
        Me.DgMeDivID.DataPropertyName = "DivID"
        Me.DgMeDivID.HeaderText = "Afdeling ID"
        Me.DgMeDivID.Name = "DgMeDivID"
        Me.DgMeDivID.ReadOnly = True
        Me.DgMeDivID.Visible = False
        '
        'DgMeYOPID
        '
        Me.DgMeYOPID.DataPropertyName = "YOPID"
        Me.DgMeYOPID.HeaderText = "YOPID"
        Me.DgMeYOPID.Name = "DgMeYOPID"
        Me.DgMeYOPID.ReadOnly = True
        Me.DgMeYOPID.Visible = False
        '
        'DgMeBlockID
        '
        Me.DgMeBlockID.DataPropertyName = "BlockID"
        Me.DgMeBlockID.HeaderText = "FieldNoID"
        Me.DgMeBlockID.Name = "DgMeBlockID"
        Me.DgMeBlockID.ReadOnly = True
        Me.DgMeBlockID.Visible = False
        '
        'DgMeVHID
        '
        Me.DgMeVHID.DataPropertyName = "VHID"
        Me.DgMeVHID.HeaderText = "VHID"
        Me.DgMeVHID.Name = "DgMeVHID"
        Me.DgMeVHID.ReadOnly = True
        Me.DgMeVHID.Visible = False
        '
        'dgMeVHDetailCostCodeID
        '
        Me.dgMeVHDetailCostCodeID.DataPropertyName = "VHDetailCostCodeID"
        Me.dgMeVHDetailCostCodeID.HeaderText = "VHDetailCostcodeID"
        Me.dgMeVHDetailCostCodeID.Name = "dgMeVHDetailCostCodeID"
        Me.dgMeVHDetailCostCodeID.ReadOnly = True
        Me.dgMeVHDetailCostCodeID.Visible = False
        '
        'dgmeVHType
        '
        Me.dgmeVHType.DataPropertyName = "VehicleType"
        Me.dgmeVHType.HeaderText = "Vehicle Type"
        Me.dgmeVHType.Name = "dgmeVHType"
        Me.dgmeVHType.ReadOnly = True
        Me.dgmeVHType.Visible = False
        '
        'DgMeDiv
        '
        Me.DgMeDiv.DataPropertyName = "Div"
        Me.DgMeDiv.HeaderText = "Afdeling"
        Me.DgMeDiv.Name = "DgMeDiv"
        Me.DgMeDiv.ReadOnly = True
        Me.DgMeDiv.Width = 30
        '
        'dgMeYOP
        '
        Me.dgMeYOP.DataPropertyName = "YOP"
        Me.dgMeYOP.HeaderText = "YOP"
        Me.dgMeYOP.Name = "dgMeYOP"
        Me.dgMeYOP.ReadOnly = True
        Me.dgMeYOP.Width = 30
        '
        'DgMeSubBlock
        '
        Me.DgMeSubBlock.DataPropertyName = "BlockName"
        Me.DgMeSubBlock.HeaderText = "Field No"
        Me.DgMeSubBlock.Name = "DgMeSubBlock"
        Me.DgMeSubBlock.ReadOnly = True
        Me.DgMeSubBlock.Width = 60
        '
        'DgMeStationCode
        '
        Me.DgMeStationCode.DataPropertyName = "Stationcode"
        Me.DgMeStationCode.HeaderText = "Station "
        Me.DgMeStationCode.Name = "DgMeStationCode"
        Me.DgMeStationCode.ReadOnly = True
        Me.DgMeStationCode.Width = 50
        '
        'dgMeVHWSCode
        '
        Me.dgMeVHWSCode.DataPropertyName = "VHWSCode"
        Me.dgMeVHWSCode.HeaderText = "Vehicle Code"
        Me.dgMeVHWSCode.Name = "dgMeVHWSCode"
        Me.dgMeVHWSCode.ReadOnly = True
        Me.dgMeVHWSCode.Width = 70
        '
        'dgMeVHDetailCostCode
        '
        Me.dgMeVHDetailCostCode.DataPropertyName = "VHDetailCostCode"
        Me.dgMeVHDetailCostCode.HeaderText = "Detail Cost Code"
        Me.dgMeVHDetailCostCode.Name = "dgMeVHDetailCostCode"
        Me.dgMeVHDetailCostCode.ReadOnly = True
        Me.dgMeVHDetailCostCode.Width = 80
        '
        'DgMeStationID
        '
        Me.DgMeStationID.DataPropertyName = "StationID"
        Me.DgMeStationID.HeaderText = "StationID"
        Me.DgMeStationID.Name = "DgMeStationID"
        Me.DgMeStationID.ReadOnly = True
        Me.DgMeStationID.Visible = False
        '
        'dgMeTAnalysisCode0
        '
        Me.dgMeTAnalysisCode0.DataPropertyName = "TAnalysisCode0"
        Me.dgMeTAnalysisCode0.HeaderText = "T0"
        Me.dgMeTAnalysisCode0.Name = "dgMeTAnalysisCode0"
        Me.dgMeTAnalysisCode0.ReadOnly = True
        Me.dgMeTAnalysisCode0.Width = 30
        '
        'dgMeTAnalysisCode1
        '
        Me.dgMeTAnalysisCode1.DataPropertyName = "TAnalysisCode1"
        Me.dgMeTAnalysisCode1.HeaderText = "T1"
        Me.dgMeTAnalysisCode1.Name = "dgMeTAnalysisCode1"
        Me.dgMeTAnalysisCode1.ReadOnly = True
        Me.dgMeTAnalysisCode1.Width = 30
        '
        'dgMeTAnalysisCode2
        '
        Me.dgMeTAnalysisCode2.DataPropertyName = "TAnalysisCode2"
        Me.dgMeTAnalysisCode2.HeaderText = "T2"
        Me.dgMeTAnalysisCode2.Name = "dgMeTAnalysisCode2"
        Me.dgMeTAnalysisCode2.ReadOnly = True
        Me.dgMeTAnalysisCode2.Width = 30
        '
        'dgMeTAnalysisCode3
        '
        Me.dgMeTAnalysisCode3.DataPropertyName = "TAnalysisCode3"
        Me.dgMeTAnalysisCode3.HeaderText = "T3"
        Me.dgMeTAnalysisCode3.Name = "dgMeTAnalysisCode3"
        Me.dgMeTAnalysisCode3.ReadOnly = True
        Me.dgMeTAnalysisCode3.Width = 30
        '
        'dgMeTAnalysisCode4
        '
        Me.dgMeTAnalysisCode4.DataPropertyName = "TAnalysisCode4"
        Me.dgMeTAnalysisCode4.HeaderText = "T4"
        Me.dgMeTAnalysisCode4.Name = "dgMeTAnalysisCode4"
        Me.dgMeTAnalysisCode4.ReadOnly = True
        Me.dgMeTAnalysisCode4.Width = 30
        '
        'dgMeCOAID
        '
        Me.dgMeCOAID.DataPropertyName = "COAID"
        Me.dgMeCOAID.HeaderText = "COAID"
        Me.dgMeCOAID.Name = "dgMeCOAID"
        Me.dgMeCOAID.ReadOnly = True
        Me.dgMeCOAID.Visible = False
        '
        'dgMeT0
        '
        Me.dgMeT0.DataPropertyName = "T0"
        Me.dgMeT0.HeaderText = "T0"
        Me.dgMeT0.Name = "dgMeT0"
        Me.dgMeT0.ReadOnly = True
        Me.dgMeT0.Visible = False
        '
        'dgMeT1
        '
        Me.dgMeT1.DataPropertyName = "T1"
        Me.dgMeT1.HeaderText = "T1"
        Me.dgMeT1.Name = "dgMeT1"
        Me.dgMeT1.ReadOnly = True
        Me.dgMeT1.Visible = False
        '
        'dgMeT2
        '
        Me.dgMeT2.DataPropertyName = "T2"
        Me.dgMeT2.HeaderText = "T2"
        Me.dgMeT2.Name = "dgMeT2"
        Me.dgMeT2.ReadOnly = True
        Me.dgMeT2.Visible = False
        '
        'dgMeT3
        '
        Me.dgMeT3.DataPropertyName = "T3"
        Me.dgMeT3.HeaderText = "T3"
        Me.dgMeT3.Name = "dgMeT3"
        Me.dgMeT3.ReadOnly = True
        Me.dgMeT3.Visible = False
        '
        'dgMeT4
        '
        Me.dgMeT4.DataPropertyName = "T4"
        Me.dgMeT4.HeaderText = "T4"
        Me.dgMeT4.Name = "dgMeT4"
        Me.dgMeT4.ReadOnly = True
        Me.dgMeT4.Visible = False
        '
        'dgMeTAnalysisDescp0
        '
        Me.dgMeTAnalysisDescp0.DataPropertyName = "TAnalysisDescp0"
        Me.dgMeTAnalysisDescp0.HeaderText = "TAnalysisDescp0"
        Me.dgMeTAnalysisDescp0.Name = "dgMeTAnalysisDescp0"
        Me.dgMeTAnalysisDescp0.ReadOnly = True
        Me.dgMeTAnalysisDescp0.Visible = False
        '
        'dgMeDivName
        '
        Me.dgMeDivName.DataPropertyName = "DivName"
        Me.dgMeDivName.HeaderText = "AfdelingName"
        Me.dgMeDivName.Name = "dgMeDivName"
        Me.dgMeDivName.ReadOnly = True
        Me.dgMeDivName.Visible = False
        '
        'dgMeYOPName
        '
        Me.dgMeYOPName.DataPropertyName = "YOPName"
        Me.dgMeYOPName.HeaderText = "YOPName"
        Me.dgMeYOPName.Name = "dgMeYOPName"
        Me.dgMeYOPName.ReadOnly = True
        Me.dgMeYOPName.Visible = False
        '
        'dgMeBlockStatus
        '
        Me.dgMeBlockStatus.DataPropertyName = "BlockStatus"
        Me.dgMeBlockStatus.HeaderText = "FieldNoStatus"
        Me.dgMeBlockStatus.Name = "dgMeBlockStatus"
        Me.dgMeBlockStatus.ReadOnly = True
        Me.dgMeBlockStatus.Visible = False
        '
        'dgMeStationDescp
        '
        Me.dgMeStationDescp.DataPropertyName = "StationDescp"
        Me.dgMeStationDescp.HeaderText = "StationDescp"
        Me.dgMeStationDescp.Name = "dgMeStationDescp"
        Me.dgMeStationDescp.ReadOnly = True
        Me.dgMeStationDescp.Visible = False
        '
        'dgVHDetailCostDescp
        '
        Me.dgVHDetailCostDescp.DataPropertyName = "VHDetailCostDescp"
        Me.dgVHDetailCostDescp.HeaderText = "DetailCostDescp"
        Me.dgVHDetailCostDescp.Name = "dgVHDetailCostDescp"
        Me.dgVHDetailCostDescp.ReadOnly = True
        Me.dgVHDetailCostDescp.Visible = False
        '
        'DgmeVehicleDescp
        '
        Me.DgmeVehicleDescp.DataPropertyName = "VehicleDescp"
        Me.DgmeVehicleDescp.HeaderText = "VehicleDescp"
        Me.DgmeVehicleDescp.Name = "DgmeVehicleDescp"
        Me.DgmeVehicleDescp.ReadOnly = True
        Me.DgmeVehicleDescp.Visible = False
        '
        'dgMeTAnalysisDescp1
        '
        Me.dgMeTAnalysisDescp1.DataPropertyName = "TAnalysisDescp1"
        Me.dgMeTAnalysisDescp1.HeaderText = "TAnalysisDescp1"
        Me.dgMeTAnalysisDescp1.Name = "dgMeTAnalysisDescp1"
        Me.dgMeTAnalysisDescp1.ReadOnly = True
        Me.dgMeTAnalysisDescp1.Visible = False
        '
        'dgMeTAnalysisDescp2
        '
        Me.dgMeTAnalysisDescp2.DataPropertyName = "TAnalysisDescp2"
        Me.dgMeTAnalysisDescp2.HeaderText = "TAnalysisDescp2"
        Me.dgMeTAnalysisDescp2.Name = "dgMeTAnalysisDescp2"
        Me.dgMeTAnalysisDescp2.ReadOnly = True
        Me.dgMeTAnalysisDescp2.Visible = False
        '
        'dgMeTAnalysisDescp3
        '
        Me.dgMeTAnalysisDescp3.DataPropertyName = "TAnalysisDescp3"
        Me.dgMeTAnalysisDescp3.HeaderText = "TAnalysisDescp3"
        Me.dgMeTAnalysisDescp3.Name = "dgMeTAnalysisDescp3"
        Me.dgMeTAnalysisDescp3.ReadOnly = True
        Me.dgMeTAnalysisDescp3.Visible = False
        '
        'dgMeTAnalysisDescp4
        '
        Me.dgMeTAnalysisDescp4.DataPropertyName = "TAnalysisDescp4"
        Me.dgMeTAnalysisDescp4.HeaderText = "TAnalysisDescp4"
        Me.dgMeTAnalysisDescp4.Name = "dgMeTAnalysisDescp4"
        Me.dgMeTAnalysisDescp4.ReadOnly = True
        Me.dgMeTAnalysisDescp4.Visible = False
        '
        'CMSMultipleentry
        '
        Me.CMSMultipleentry.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.CMSMultipleentry.Name = "cmsIPR"
        Me.CMSMultipleentry.Size = New System.Drawing.Size(108, 70)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.ToolStripMenuItem1.Text = "Add"
        Me.ToolStripMenuItem1.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(107, 22)
        Me.ToolStripMenuItem2.Text = "Edit"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(107, 22)
        Me.ToolStripMenuItem3.Text = "Delete"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtCreditKeenValue)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.lblDebitKeenValue)
        Me.GroupBox1.Controls.Add(Me.txtDebitKeenValue)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.lblCreditKeenValue)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 523)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(517, 42)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(477, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 13)
        Me.Label10.TabIndex = 239
        Me.Label10.Text = "Rp"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(228, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 13)
        Me.Label9.TabIndex = 238
        Me.Label9.Text = "Rp"
        '
        'txtCreditKeenValue
        '
        Me.txtCreditKeenValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditKeenValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreditKeenValue.Location = New System.Drawing.Point(322, 14)
        Me.txtCreditKeenValue.MaxLength = 18
        Me.txtCreditKeenValue.Name = "txtCreditKeenValue"
        Me.txtCreditKeenValue.Size = New System.Drawing.Size(150, 21)
        Me.txtCreditKeenValue.TabIndex = 39
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(310, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 13)
        Me.Label14.TabIndex = 222
        Me.Label14.Text = ":"
        '
        'lblDebitKeenValue
        '
        Me.lblDebitKeenValue.AutoSize = True
        Me.lblDebitKeenValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebitKeenValue.Location = New System.Drawing.Point(17, 18)
        Me.lblDebitKeenValue.Name = "lblDebitKeenValue"
        Me.lblDebitKeenValue.Size = New System.Drawing.Size(37, 13)
        Me.lblDebitKeenValue.TabIndex = 221
        Me.lblDebitKeenValue.Text = "Debit"
        '
        'txtDebitKeenValue
        '
        Me.txtDebitKeenValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitKeenValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDebitKeenValue.Location = New System.Drawing.Point(75, 14)
        Me.txtDebitKeenValue.MaxLength = 18
        Me.txtDebitKeenValue.Name = "txtDebitKeenValue"
        Me.txtDebitKeenValue.Size = New System.Drawing.Size(150, 21)
        Me.txtDebitKeenValue.TabIndex = 38
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(54, 18)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 13)
        Me.Label21.TabIndex = 219
        Me.Label21.Text = ":"
        '
        'lblCreditKeenValue
        '
        Me.lblCreditKeenValue.AutoSize = True
        Me.lblCreditKeenValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditKeenValue.Location = New System.Drawing.Point(266, 18)
        Me.lblCreditKeenValue.Name = "lblCreditKeenValue"
        Me.lblCreditKeenValue.Size = New System.Drawing.Size(42, 13)
        Me.lblCreditKeenValue.TabIndex = 218
        Me.lblCreditKeenValue.Text = "Credit"
        '
        'grpTAnalysis
        '
        Me.grpTAnalysis.Controls.Add(Me.grpApproval)
        Me.grpTAnalysis.Controls.Add(Me.lblT4Name)
        Me.grpTAnalysis.Controls.Add(Me.lblT3Name)
        Me.grpTAnalysis.Controls.Add(Me.lblT2Name)
        Me.grpTAnalysis.Controls.Add(Me.lblT1Name)
        Me.grpTAnalysis.Controls.Add(Me.lblT0Name)
        Me.grpTAnalysis.Controls.Add(Me.lblStationDescp)
        Me.grpTAnalysis.Controls.Add(Me.btnSearchT4)
        Me.grpTAnalysis.Controls.Add(Me.btnSearchT3)
        Me.grpTAnalysis.Controls.Add(Me.btnSearchT2)
        Me.grpTAnalysis.Controls.Add(Me.btnSearchT1)
        Me.grpTAnalysis.Controls.Add(Me.btnSearchT0)
        Me.grpTAnalysis.Controls.Add(Me.txtT4)
        Me.grpTAnalysis.Controls.Add(Me.Label15)
        Me.grpTAnalysis.Controls.Add(Me.btnSearchStation)
        Me.grpTAnalysis.Controls.Add(Me.lblT4)
        Me.grpTAnalysis.Controls.Add(Me.txtT3)
        Me.grpTAnalysis.Controls.Add(Me.Label16)
        Me.grpTAnalysis.Controls.Add(Me.lblT3)
        Me.grpTAnalysis.Controls.Add(Me.Label7)
        Me.grpTAnalysis.Controls.Add(Me.txtT2)
        Me.grpTAnalysis.Controls.Add(Me.Label17)
        Me.grpTAnalysis.Controls.Add(Me.lblT2)
        Me.grpTAnalysis.Controls.Add(Me.txtStation)
        Me.grpTAnalysis.Controls.Add(Me.lblStation)
        Me.grpTAnalysis.Controls.Add(Me.txtT1)
        Me.grpTAnalysis.Controls.Add(Me.Label18)
        Me.grpTAnalysis.Controls.Add(Me.lblT1)
        Me.grpTAnalysis.Controls.Add(Me.txtT0)
        Me.grpTAnalysis.Controls.Add(Me.Label19)
        Me.grpTAnalysis.Controls.Add(Me.lblT0)
        Me.grpTAnalysis.Location = New System.Drawing.Point(530, 228)
        Me.grpTAnalysis.Name = "grpTAnalysis"
        Me.grpTAnalysis.Size = New System.Drawing.Size(420, 289)
        Me.grpTAnalysis.TabIndex = 26
        Me.grpTAnalysis.TabStop = False
        Me.grpTAnalysis.Visible = False
        '
        'grpApproval
        '
        Me.grpApproval.Controls.Add(Me.txtRejectedReason)
        Me.grpApproval.Controls.Add(Me.lblRejColon)
        Me.grpApproval.Controls.Add(Me.lblRejReason)
        Me.grpApproval.Controls.Add(Me.Label23)
        Me.grpApproval.Controls.Add(Me.btnConform)
        Me.grpApproval.Controls.Add(Me.cmbStatus)
        Me.grpApproval.Controls.Add(Me.lblStatusApproval)
        Me.grpApproval.Location = New System.Drawing.Point(5, 191)
        Me.grpApproval.Name = "grpApproval"
        Me.grpApproval.Size = New System.Drawing.Size(320, 83)
        Me.grpApproval.TabIndex = 253
        Me.grpApproval.TabStop = False
        Me.grpApproval.Text = "Journal Approval"
        Me.grpApproval.Visible = False
        '
        'txtRejectedReason
        '
        Me.txtRejectedReason.AcceptsReturn = True
        Me.txtRejectedReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRejectedReason.Location = New System.Drawing.Point(79, 42)
        Me.txtRejectedReason.Multiline = True
        Me.txtRejectedReason.Name = "txtRejectedReason"
        Me.txtRejectedReason.Size = New System.Drawing.Size(232, 33)
        Me.txtRejectedReason.TabIndex = 260
        '
        'lblRejColon
        '
        Me.lblRejColon.AutoSize = True
        Me.lblRejColon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejColon.Location = New System.Drawing.Point(63, 45)
        Me.lblRejColon.Name = "lblRejColon"
        Me.lblRejColon.Size = New System.Drawing.Size(11, 13)
        Me.lblRejColon.TabIndex = 259
        Me.lblRejColon.Text = ":"
        '
        'lblRejReason
        '
        Me.lblRejReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejReason.ForeColor = System.Drawing.Color.Black
        Me.lblRejReason.Location = New System.Drawing.Point(5, 41)
        Me.lblRejReason.Name = "lblRejReason"
        Me.lblRejReason.Size = New System.Drawing.Size(68, 30)
        Me.lblRejReason.TabIndex = 258
        Me.lblRejReason.Text = "Rejected Reason"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(63, 21)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 144
        Me.Label23.Text = ":"
        '
        'btnConform
        '
        Me.btnConform.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnConform.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConform.Image = CType(resources.GetObject("btnConform.Image"), System.Drawing.Image)
        Me.btnConform.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConform.Location = New System.Drawing.Point(197, 14)
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
        Me.cmbStatus.Location = New System.Drawing.Point(79, 16)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(108, 21)
        Me.cmbStatus.TabIndex = 200
        '
        'lblStatusApproval
        '
        Me.lblStatusApproval.AutoSize = True
        Me.lblStatusApproval.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusApproval.ForeColor = System.Drawing.Color.Black
        Me.lblStatusApproval.Location = New System.Drawing.Point(6, 20)
        Me.lblStatusApproval.Name = "lblStatusApproval"
        Me.lblStatusApproval.Size = New System.Drawing.Size(43, 13)
        Me.lblStatusApproval.TabIndex = 142
        Me.lblStatusApproval.Text = "Status"
        '
        'lblT4Name
        '
        Me.lblT4Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT4Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT4Name.Location = New System.Drawing.Point(235, 168)
        Me.lblT4Name.Name = "lblT4Name"
        Me.lblT4Name.Size = New System.Drawing.Size(174, 34)
        Me.lblT4Name.TabIndex = 237
        Me.lblT4Name.Text = "T4Name"
        Me.lblT4Name.Visible = False
        '
        'lblT3Name
        '
        Me.lblT3Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT3Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT3Name.Location = New System.Drawing.Point(235, 140)
        Me.lblT3Name.Name = "lblT3Name"
        Me.lblT3Name.Size = New System.Drawing.Size(174, 28)
        Me.lblT3Name.TabIndex = 236
        Me.lblT3Name.Text = "T3Name"
        Me.lblT3Name.Visible = False
        '
        'lblT2Name
        '
        Me.lblT2Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT2Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT2Name.Location = New System.Drawing.Point(235, 108)
        Me.lblT2Name.Name = "lblT2Name"
        Me.lblT2Name.Size = New System.Drawing.Size(174, 32)
        Me.lblT2Name.TabIndex = 235
        Me.lblT2Name.Text = "T2Name"
        Me.lblT2Name.Visible = False
        '
        'lblT1Name
        '
        Me.lblT1Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT1Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT1Name.Location = New System.Drawing.Point(235, 80)
        Me.lblT1Name.Name = "lblT1Name"
        Me.lblT1Name.Size = New System.Drawing.Size(174, 28)
        Me.lblT1Name.TabIndex = 234
        Me.lblT1Name.Text = "T1Name"
        Me.lblT1Name.Visible = False
        '
        'lblT0Name
        '
        Me.lblT0Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT0Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT0Name.Location = New System.Drawing.Point(235, 50)
        Me.lblT0Name.Name = "lblT0Name"
        Me.lblT0Name.Size = New System.Drawing.Size(174, 30)
        Me.lblT0Name.TabIndex = 233
        Me.lblT0Name.Text = "T0Name"
        '
        'lblStationDescp
        '
        Me.lblStationDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStationDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblStationDescp.Location = New System.Drawing.Point(235, 21)
        Me.lblStationDescp.Name = "lblStationDescp"
        Me.lblStationDescp.Size = New System.Drawing.Size(174, 24)
        Me.lblStationDescp.TabIndex = 242
        Me.lblStationDescp.Text = "StationDescp"
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
        Me.btnSearchT4.Location = New System.Drawing.Point(202, 161)
        Me.btnSearchT4.Name = "btnSearchT4"
        Me.btnSearchT4.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchT4.TabIndex = 37
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
        Me.btnSearchT3.Location = New System.Drawing.Point(202, 131)
        Me.btnSearchT3.Name = "btnSearchT3"
        Me.btnSearchT3.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchT3.TabIndex = 35
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
        Me.btnSearchT2.Location = New System.Drawing.Point(202, 101)
        Me.btnSearchT2.Name = "btnSearchT2"
        Me.btnSearchT2.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchT2.TabIndex = 33
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
        Me.btnSearchT1.Location = New System.Drawing.Point(202, 71)
        Me.btnSearchT1.Name = "btnSearchT1"
        Me.btnSearchT1.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchT1.TabIndex = 31
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
        Me.btnSearchT0.Location = New System.Drawing.Point(202, 41)
        Me.btnSearchT0.Name = "btnSearchT0"
        Me.btnSearchT0.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchT0.TabIndex = 29
        Me.btnSearchT0.TabStop = False
        Me.btnSearchT0.UseVisualStyleBackColor = True
        '
        'txtT4
        '
        Me.txtT4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT4.Location = New System.Drawing.Point(97, 166)
        Me.txtT4.MaxLength = 50
        Me.txtT4.Name = "txtT4"
        Me.txtT4.Size = New System.Drawing.Size(100, 21)
        Me.txtT4.TabIndex = 36
        Me.txtT4.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(81, 170)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 13)
        Me.Label15.TabIndex = 225
        Me.Label15.Text = ":"
        Me.Label15.Visible = False
        '
        'btnSearchStation
        '
        Me.btnSearchStation.BackgroundImage = CType(resources.GetObject("btnSearchStation.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchStation.Enabled = False
        Me.btnSearchStation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchStation.FlatAppearance.BorderSize = 0
        Me.btnSearchStation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchStation.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchStation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchStation.Location = New System.Drawing.Point(201, 12)
        Me.btnSearchStation.Name = "btnSearchStation"
        Me.btnSearchStation.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchStation.TabIndex = 27
        Me.btnSearchStation.TabStop = False
        Me.btnSearchStation.UseVisualStyleBackColor = True
        '
        'lblT4
        '
        Me.lblT4.AutoSize = True
        Me.lblT4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT4.Location = New System.Drawing.Point(7, 170)
        Me.lblT4.Name = "lblT4"
        Me.lblT4.Size = New System.Drawing.Size(21, 13)
        Me.lblT4.TabIndex = 224
        Me.lblT4.Text = "T4"
        Me.lblT4.Visible = False
        '
        'txtT3
        '
        Me.txtT3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT3.Location = New System.Drawing.Point(97, 136)
        Me.txtT3.MaxLength = 50
        Me.txtT3.Name = "txtT3"
        Me.txtT3.Size = New System.Drawing.Size(100, 21)
        Me.txtT3.TabIndex = 34
        Me.txtT3.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(81, 140)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 13)
        Me.Label16.TabIndex = 222
        Me.Label16.Text = ":"
        Me.Label16.Visible = False
        '
        'lblT3
        '
        Me.lblT3.AutoSize = True
        Me.lblT3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT3.Location = New System.Drawing.Point(7, 140)
        Me.lblT3.Name = "lblT3"
        Me.lblT3.Size = New System.Drawing.Size(21, 13)
        Me.lblT3.TabIndex = 221
        Me.lblT3.Text = "T3"
        Me.lblT3.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(81, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 236
        Me.Label7.Text = ":"
        '
        'txtT2
        '
        Me.txtT2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT2.Location = New System.Drawing.Point(97, 106)
        Me.txtT2.MaxLength = 50
        Me.txtT2.Name = "txtT2"
        Me.txtT2.Size = New System.Drawing.Size(100, 21)
        Me.txtT2.TabIndex = 32
        Me.txtT2.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(81, 110)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 13)
        Me.Label17.TabIndex = 219
        Me.Label17.Text = ":"
        Me.Label17.Visible = False
        '
        'lblT2
        '
        Me.lblT2.AutoSize = True
        Me.lblT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT2.Location = New System.Drawing.Point(7, 110)
        Me.lblT2.Name = "lblT2"
        Me.lblT2.Size = New System.Drawing.Size(21, 13)
        Me.lblT2.TabIndex = 218
        Me.lblT2.Text = "T2"
        Me.lblT2.Visible = False
        '
        'txtStation
        '
        Me.txtStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStation.Enabled = False
        Me.txtStation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStation.Location = New System.Drawing.Point(97, 17)
        Me.txtStation.MaxLength = 50
        Me.txtStation.Name = "txtStation"
        Me.txtStation.Size = New System.Drawing.Size(100, 21)
        Me.txtStation.TabIndex = 26
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStation.ForeColor = System.Drawing.Color.Black
        Me.lblStation.Location = New System.Drawing.Point(7, 21)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(47, 13)
        Me.lblStation.TabIndex = 235
        Me.lblStation.Text = "Station"
        '
        'txtT1
        '
        Me.txtT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT1.Location = New System.Drawing.Point(97, 76)
        Me.txtT1.MaxLength = 50
        Me.txtT1.Name = "txtT1"
        Me.txtT1.Size = New System.Drawing.Size(100, 21)
        Me.txtT1.TabIndex = 30
        Me.txtT1.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(81, 80)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(11, 13)
        Me.Label18.TabIndex = 216
        Me.Label18.Text = ":"
        Me.Label18.Visible = False
        '
        'lblT1
        '
        Me.lblT1.AutoSize = True
        Me.lblT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT1.Location = New System.Drawing.Point(7, 80)
        Me.lblT1.Name = "lblT1"
        Me.lblT1.Size = New System.Drawing.Size(21, 13)
        Me.lblT1.TabIndex = 215
        Me.lblT1.Text = "T1"
        Me.lblT1.Visible = False
        '
        'txtT0
        '
        Me.txtT0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT0.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT0.Location = New System.Drawing.Point(97, 46)
        Me.txtT0.MaxLength = 50
        Me.txtT0.Name = "txtT0"
        Me.txtT0.Size = New System.Drawing.Size(100, 21)
        Me.txtT0.TabIndex = 28
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(81, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(11, 13)
        Me.Label19.TabIndex = 213
        Me.Label19.Text = ":"
        '
        'lblT0
        '
        Me.lblT0.AutoSize = True
        Me.lblT0.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT0.ForeColor = System.Drawing.Color.Red
        Me.lblT0.Location = New System.Drawing.Point(7, 50)
        Me.lblT0.Name = "lblT0"
        Me.lblT0.Size = New System.Drawing.Size(21, 13)
        Me.lblT0.TabIndex = 212
        Me.lblT0.Text = "T0"
        '
        'grpAccountCode
        '
        Me.grpAccountCode.Controls.Add(Me.txtDescp)
        Me.grpAccountCode.Controls.Add(Me.lblDescp)
        Me.grpAccountCode.Controls.Add(Me.Label25)
        Me.grpAccountCode.Controls.Add(Me.lblOldAccountCode)
        Me.grpAccountCode.Controls.Add(Me.lblDetailCostDescp)
        Me.grpAccountCode.Controls.Add(Me.Label20)
        Me.grpAccountCode.Controls.Add(Me.Label22)
        Me.grpAccountCode.Controls.Add(Me.lblVehicleDescp)
        Me.grpAccountCode.Controls.Add(Me.lblBlockStatus)
        Me.grpAccountCode.Controls.Add(Me.lblYOPName)
        Me.grpAccountCode.Controls.Add(Me.lblDivName)
        Me.grpAccountCode.Controls.Add(Me.txtAccountCode)
        Me.grpAccountCode.Controls.Add(Me.txtSubBlock)
        Me.grpAccountCode.Controls.Add(Me.lblSubBlock)
        Me.grpAccountCode.Controls.Add(Me.lblAccountDescp)
        Me.grpAccountCode.Controls.Add(Me.Label13)
        Me.grpAccountCode.Controls.Add(Me.btnSearchSubBlock)
        Me.grpAccountCode.Controls.Add(Me.btnDivSearch)
        Me.grpAccountCode.Controls.Add(Me.txtYOP)
        Me.grpAccountCode.Controls.Add(Me.Label26)
        Me.grpAccountCode.Controls.Add(Me.btnSearchVehicleDetailCostCode)
        Me.grpAccountCode.Controls.Add(Me.lblYOP)
        Me.grpAccountCode.Controls.Add(Me.txtDiv)
        Me.grpAccountCode.Controls.Add(Me.Label29)
        Me.grpAccountCode.Controls.Add(Me.lblDiv)
        Me.grpAccountCode.Controls.Add(Me.btnAccountCodeLookup)
        Me.grpAccountCode.Controls.Add(Me.btnSearchVehicleCode)
        Me.grpAccountCode.Controls.Add(Me.lblAccountCode)
        Me.grpAccountCode.Controls.Add(Me.Label32)
        Me.grpAccountCode.Controls.Add(Me.lblVehicleCode)
        Me.grpAccountCode.Controls.Add(Me.txtDetailCostCode)
        Me.grpAccountCode.Controls.Add(Me.Label12)
        Me.grpAccountCode.Controls.Add(Me.txtVehicleCode)
        Me.grpAccountCode.Controls.Add(Me.Label11)
        Me.grpAccountCode.Controls.Add(Me.lblDetailCostCode)
        Me.grpAccountCode.Location = New System.Drawing.Point(9, 227)
        Me.grpAccountCode.Name = "grpAccountCode"
        Me.grpAccountCode.Size = New System.Drawing.Size(515, 290)
        Me.grpAccountCode.TabIndex = 10
        Me.grpAccountCode.TabStop = False
        '
        'txtDescp
        '
        Me.txtDescp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescp.Location = New System.Drawing.Point(137, 79)
        Me.txtDescp.MaxLength = 300
        Me.txtDescp.Multiline = True
        Me.txtDescp.Name = "txtDescp"
        Me.txtDescp.Size = New System.Drawing.Size(347, 45)
        Me.txtDescp.TabIndex = 15
        '
        'lblDescp
        '
        Me.lblDescp.AutoSize = True
        Me.lblDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescp.ForeColor = System.Drawing.Color.Red
        Me.lblDescp.Location = New System.Drawing.Point(15, 79)
        Me.lblDescp.Name = "lblDescp"
        Me.lblDescp.Size = New System.Drawing.Size(71, 13)
        Me.lblDescp.TabIndex = 256
        Me.lblDescp.Text = "Description"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(120, 79)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(11, 13)
        Me.Label25.TabIndex = 257
        Me.Label25.Text = ":"
        '
        'lblOldAccountCode
        '
        Me.lblOldAccountCode.AutoSize = True
        Me.lblOldAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOldAccountCode.ForeColor = System.Drawing.Color.Blue
        Me.lblOldAccountCode.Location = New System.Drawing.Point(137, 52)
        Me.lblOldAccountCode.Name = "lblOldAccountCode"
        Me.lblOldAccountCode.Size = New System.Drawing.Size(109, 13)
        Me.lblOldAccountCode.TabIndex = 254
        Me.lblOldAccountCode.Text = "Old Account Code"
        '
        'lblDetailCostDescp
        '
        Me.lblDetailCostDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetailCostDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblDetailCostDescp.Location = New System.Drawing.Point(328, 253)
        Me.lblDetailCostDescp.Name = "lblDetailCostDescp"
        Me.lblDetailCostDescp.Size = New System.Drawing.Size(170, 29)
        Me.lblDetailCostDescp.TabIndex = 241
        Me.lblDetailCostDescp.Text = "DetailCostDescp"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(121, 52)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 13)
        Me.Label20.TabIndex = 253
        Me.Label20.Text = ":"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(15, 52)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(109, 13)
        Me.Label22.TabIndex = 252
        Me.Label22.Text = "Old Account Code"
        '
        'lblVehicleDescp
        '
        Me.lblVehicleDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblVehicleDescp.Location = New System.Drawing.Point(328, 223)
        Me.lblVehicleDescp.Name = "lblVehicleDescp"
        Me.lblVehicleDescp.Size = New System.Drawing.Size(170, 27)
        Me.lblVehicleDescp.TabIndex = 240
        Me.lblVehicleDescp.Text = "VehicleDescp"
        '
        'lblBlockStatus
        '
        Me.lblBlockStatus.AutoSize = True
        Me.lblBlockStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlockStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblBlockStatus.Location = New System.Drawing.Point(328, 136)
        Me.lblBlockStatus.Name = "lblBlockStatus"
        Me.lblBlockStatus.Size = New System.Drawing.Size(84, 13)
        Me.lblBlockStatus.TabIndex = 239
        Me.lblBlockStatus.Text = "FieldNoStatus"
        '
        'lblYOPName
        '
        Me.lblYOPName.AutoSize = True
        Me.lblYOPName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOPName.ForeColor = System.Drawing.Color.Blue
        Me.lblYOPName.Location = New System.Drawing.Point(328, 166)
        Me.lblYOPName.Name = "lblYOPName"
        Me.lblYOPName.Size = New System.Drawing.Size(63, 13)
        Me.lblYOPName.TabIndex = 238
        Me.lblYOPName.Text = "YOPName"
        '
        'lblDivName
        '
        Me.lblDivName.AutoSize = True
        Me.lblDivName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivName.ForeColor = System.Drawing.Color.Blue
        Me.lblDivName.Location = New System.Drawing.Point(328, 196)
        Me.lblDivName.Name = "lblDivName"
        Me.lblDivName.Size = New System.Drawing.Size(86, 13)
        Me.lblDivName.TabIndex = 237
        Me.lblDivName.Text = "AfdelingName"
        '
        'txtAccountCode
        '
        Me.txtAccountCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountCode.Location = New System.Drawing.Point(137, 18)
        Me.txtAccountCode.MaxLength = 50
        Me.txtAccountCode.Name = "txtAccountCode"
        Me.txtAccountCode.Size = New System.Drawing.Size(150, 21)
        Me.txtAccountCode.TabIndex = 13
        '
        'txtSubBlock
        '
        Me.txtSubBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubBlock.Location = New System.Drawing.Point(137, 132)
        Me.txtSubBlock.MaxLength = 50
        Me.txtSubBlock.Name = "txtSubBlock"
        Me.txtSubBlock.Size = New System.Drawing.Size(150, 21)
        Me.txtSubBlock.TabIndex = 15
        '
        'lblSubBlock
        '
        Me.lblSubBlock.AutoSize = True
        Me.lblSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubBlock.Location = New System.Drawing.Point(17, 136)
        Me.lblSubBlock.Name = "lblSubBlock"
        Me.lblSubBlock.Size = New System.Drawing.Size(56, 13)
        Me.lblSubBlock.TabIndex = 218
        Me.lblSubBlock.Text = "Field No."
        Me.lblSubBlock.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblAccountDescp
        '
        Me.lblAccountDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblAccountDescp.Location = New System.Drawing.Point(328, 26)
        Me.lblAccountDescp.Name = "lblAccountDescp"
        Me.lblAccountDescp.Size = New System.Drawing.Size(181, 28)
        Me.lblAccountDescp.TabIndex = 232
        Me.lblAccountDescp.Text = "Account Descp"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(121, 136)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 13)
        Me.Label13.TabIndex = 219
        Me.Label13.Text = ":"
        '
        'btnSearchSubBlock
        '
        Me.btnSearchSubBlock.BackgroundImage = CType(resources.GetObject("btnSearchSubBlock.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchSubBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchSubBlock.FlatAppearance.BorderSize = 0
        Me.btnSearchSubBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchSubBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchSubBlock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchSubBlock.Location = New System.Drawing.Point(293, 127)
        Me.btnSearchSubBlock.Name = "btnSearchSubBlock"
        Me.btnSearchSubBlock.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchSubBlock.TabIndex = 16
        Me.btnSearchSubBlock.TabStop = False
        Me.btnSearchSubBlock.UseVisualStyleBackColor = True
        '
        'btnDivSearch
        '
        Me.btnDivSearch.BackgroundImage = CType(resources.GetObject("btnDivSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnDivSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDivSearch.FlatAppearance.BorderSize = 0
        Me.btnDivSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnDivSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDivSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnDivSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDivSearch.Location = New System.Drawing.Point(295, 187)
        Me.btnDivSearch.Name = "btnDivSearch"
        Me.btnDivSearch.Size = New System.Drawing.Size(30, 26)
        Me.btnDivSearch.TabIndex = 19
        Me.btnDivSearch.TabStop = False
        Me.btnDivSearch.UseVisualStyleBackColor = True
        '
        'txtYOP
        '
        Me.txtYOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYOP.Enabled = False
        Me.txtYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYOP.Location = New System.Drawing.Point(137, 162)
        Me.txtYOP.MaxLength = 50
        Me.txtYOP.Name = "txtYOP"
        Me.txtYOP.Size = New System.Drawing.Size(150, 21)
        Me.txtYOP.TabIndex = 17
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(121, 166)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(11, 13)
        Me.Label26.TabIndex = 216
        Me.Label26.Text = ":"
        '
        'btnSearchVehicleDetailCostCode
        '
        Me.btnSearchVehicleDetailCostCode.BackgroundImage = CType(resources.GetObject("btnSearchVehicleDetailCostCode.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchVehicleDetailCostCode.Enabled = False
        Me.btnSearchVehicleDetailCostCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVehicleDetailCostCode.FlatAppearance.BorderSize = 0
        Me.btnSearchVehicleDetailCostCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVehicleDetailCostCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVehicleDetailCostCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVehicleDetailCostCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVehicleDetailCostCode.Location = New System.Drawing.Point(295, 248)
        Me.btnSearchVehicleDetailCostCode.Name = "btnSearchVehicleDetailCostCode"
        Me.btnSearchVehicleDetailCostCode.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchVehicleDetailCostCode.TabIndex = 25
        Me.btnSearchVehicleDetailCostCode.TabStop = False
        Me.btnSearchVehicleDetailCostCode.UseVisualStyleBackColor = True
        '
        'lblYOP
        '
        Me.lblYOP.AutoSize = True
        Me.lblYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOP.Location = New System.Drawing.Point(17, 166)
        Me.lblYOP.Name = "lblYOP"
        Me.lblYOP.Size = New System.Drawing.Size(30, 13)
        Me.lblYOP.TabIndex = 215
        Me.lblYOP.Text = "YOP"
        '
        'txtDiv
        '
        Me.txtDiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiv.Location = New System.Drawing.Point(137, 192)
        Me.txtDiv.MaxLength = 50
        Me.txtDiv.Name = "txtDiv"
        Me.txtDiv.Size = New System.Drawing.Size(150, 21)
        Me.txtDiv.TabIndex = 18
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(121, 196)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(11, 13)
        Me.Label29.TabIndex = 213
        Me.Label29.Text = ":"
        '
        'lblDiv
        '
        Me.lblDiv.AutoSize = True
        Me.lblDiv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiv.Location = New System.Drawing.Point(17, 196)
        Me.lblDiv.Name = "lblDiv"
        Me.lblDiv.Size = New System.Drawing.Size(53, 13)
        Me.lblDiv.TabIndex = 212
        Me.lblDiv.Text = "Afdeling"
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
        Me.btnAccountCodeLookup.Location = New System.Drawing.Point(295, 13)
        Me.btnAccountCodeLookup.Name = "btnAccountCodeLookup"
        Me.btnAccountCodeLookup.Size = New System.Drawing.Size(30, 26)
        Me.btnAccountCodeLookup.TabIndex = 14
        Me.btnAccountCodeLookup.TabStop = False
        Me.btnAccountCodeLookup.UseVisualStyleBackColor = True
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
        Me.btnSearchVehicleCode.Location = New System.Drawing.Point(295, 218)
        Me.btnSearchVehicleCode.Name = "btnSearchVehicleCode"
        Me.btnSearchVehicleCode.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchVehicleCode.TabIndex = 21
        Me.btnSearchVehicleCode.TabStop = False
        Me.btnSearchVehicleCode.UseVisualStyleBackColor = True
        '
        'lblAccountCode
        '
        Me.lblAccountCode.AutoSize = True
        Me.lblAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountCode.ForeColor = System.Drawing.Color.Red
        Me.lblAccountCode.Location = New System.Drawing.Point(17, 22)
        Me.lblAccountCode.Name = "lblAccountCode"
        Me.lblAccountCode.Size = New System.Drawing.Size(86, 13)
        Me.lblAccountCode.TabIndex = 169
        Me.lblAccountCode.Text = "Account Code"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(121, 22)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(11, 13)
        Me.Label32.TabIndex = 170
        Me.Label32.Text = ":"
        '
        'lblVehicleCode
        '
        Me.lblVehicleCode.AutoSize = True
        Me.lblVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleCode.Location = New System.Drawing.Point(17, 227)
        Me.lblVehicleCode.Name = "lblVehicleCode"
        Me.lblVehicleCode.Size = New System.Drawing.Size(81, 13)
        Me.lblVehicleCode.TabIndex = 221
        Me.lblVehicleCode.Text = "Vehicle Code"
        '
        'txtDetailCostCode
        '
        Me.txtDetailCostCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetailCostCode.Enabled = False
        Me.txtDetailCostCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetailCostCode.Location = New System.Drawing.Point(136, 253)
        Me.txtDetailCostCode.MaxLength = 50
        Me.txtDetailCostCode.Name = "txtDetailCostCode"
        Me.txtDetailCostCode.Size = New System.Drawing.Size(151, 21)
        Me.txtDetailCostCode.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(121, 227)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 13)
        Me.Label12.TabIndex = 222
        Me.Label12.Text = ":"
        '
        'txtVehicleCode
        '
        Me.txtVehicleCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleCode.Location = New System.Drawing.Point(136, 223)
        Me.txtVehicleCode.MaxLength = 50
        Me.txtVehicleCode.Name = "txtVehicleCode"
        Me.txtVehicleCode.Size = New System.Drawing.Size(151, 21)
        Me.txtVehicleCode.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(121, 257)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 225
        Me.Label11.Text = ":"
        '
        'lblDetailCostCode
        '
        Me.lblDetailCostCode.AutoSize = True
        Me.lblDetailCostCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetailCostCode.Location = New System.Drawing.Point(17, 257)
        Me.lblDetailCostCode.Name = "lblDetailCostCode"
        Me.lblDetailCostCode.Size = New System.Drawing.Size(101, 13)
        Me.lblDetailCostCode.TabIndex = 224
        Me.lblDetailCostCode.Text = "Detail cost Code"
        '
        'btnResetIB
        '
        Me.btnResetIB.BackgroundImage = CType(resources.GetObject("btnResetIB.BackgroundImage"), System.Drawing.Image)
        Me.btnResetIB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetIB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetIB.Image = CType(resources.GetObject("btnResetIB.Image"), System.Drawing.Image)
        Me.btnResetIB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetIB.Location = New System.Drawing.Point(551, 717)
        Me.btnResetIB.Name = "btnResetIB"
        Me.btnResetIB.Size = New System.Drawing.Size(117, 25)
        Me.btnResetIB.TabIndex = 43
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
        Me.btnSave.Location = New System.Drawing.Point(426, 717)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(117, 25)
        Me.btnSave.TabIndex = 42
        Me.btnSave.Text = "Save All"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(676, 717)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(117, 25)
        Me.btnClose.TabIndex = 44
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpDedit
        '
        Me.grpDedit.Controls.Add(Me.txtDiff)
        Me.grpDedit.Controls.Add(Me.Label33)
        Me.grpDedit.Controls.Add(Me.lblDiff)
        Me.grpDedit.Controls.Add(Me.txtCredit)
        Me.grpDedit.Controls.Add(Me.Label30)
        Me.grpDedit.Controls.Add(Me.lblDebit)
        Me.grpDedit.Controls.Add(Me.txtDebit)
        Me.grpDedit.Controls.Add(Me.Label27)
        Me.grpDedit.Controls.Add(Me.lblCredit)
        Me.grpDedit.Location = New System.Drawing.Point(8, 183)
        Me.grpDedit.Name = "grpDedit"
        Me.grpDedit.Size = New System.Drawing.Size(942, 43)
        Me.grpDedit.TabIndex = 9
        Me.grpDedit.TabStop = False
        '
        'txtDiff
        '
        Me.txtDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiff.Enabled = False
        Me.txtDiff.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiff.Location = New System.Drawing.Point(618, 17)
        Me.txtDiff.MaxLength = 18
        Me.txtDiff.Name = "txtDiff"
        Me.txtDiff.Size = New System.Drawing.Size(180, 21)
        Me.txtDiff.TabIndex = 12
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(601, 21)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(11, 13)
        Me.Label33.TabIndex = 225
        Me.Label33.Text = ":"
        '
        'lblDiff
        '
        Me.lblDiff.AutoSize = True
        Me.lblDiff.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiff.Location = New System.Drawing.Point(541, 21)
        Me.lblDiff.Name = "lblDiff"
        Me.lblDiff.Size = New System.Drawing.Size(27, 13)
        Me.lblDiff.TabIndex = 224
        Me.lblDiff.Text = "Diff"
        '
        'txtCredit
        '
        Me.txtCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCredit.Enabled = False
        Me.txtCredit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCredit.Location = New System.Drawing.Point(351, 17)
        Me.txtCredit.MaxLength = 18
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.Size = New System.Drawing.Size(180, 21)
        Me.txtCredit.TabIndex = 11
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(334, 21)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(11, 13)
        Me.Label30.TabIndex = 222
        Me.Label30.Text = ":"
        '
        'lblDebit
        '
        Me.lblDebit.AutoSize = True
        Me.lblDebit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebit.Location = New System.Drawing.Point(17, 21)
        Me.lblDebit.Name = "lblDebit"
        Me.lblDebit.Size = New System.Drawing.Size(37, 13)
        Me.lblDebit.TabIndex = 221
        Me.lblDebit.Text = "Debit"
        '
        'txtDebit
        '
        Me.txtDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebit.Enabled = False
        Me.txtDebit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDebit.Location = New System.Drawing.Point(85, 17)
        Me.txtDebit.MaxLength = 18
        Me.txtDebit.Name = "txtDebit"
        Me.txtDebit.Size = New System.Drawing.Size(180, 21)
        Me.txtDebit.TabIndex = 10
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(66, 21)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(11, 13)
        Me.Label27.TabIndex = 219
        Me.Label27.Text = ":"
        '
        'lblCredit
        '
        Me.lblCredit.AutoSize = True
        Me.lblCredit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredit.Location = New System.Drawing.Point(280, 21)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.Size = New System.Drawing.Size(42, 13)
        Me.lblCredit.TabIndex = 218
        Me.lblCredit.Text = "Credit"
        '
        'grpLedgerValues
        '
        Me.grpLedgerValues.Controls.Add(Me.lblRejectedReasonValue)
        Me.grpLedgerValues.Controls.Add(Me.lblColon)
        Me.grpLedgerValues.Controls.Add(Me.lblRecjectedReason)
        Me.grpLedgerValues.Controls.Add(Me.lblStatusValue)
        Me.grpLedgerValues.Controls.Add(Me.Label24)
        Me.grpLedgerValues.Controls.Add(Me.lblStatus)
        Me.grpLedgerValues.Controls.Add(Me.chkRecurringJournals)
        Me.grpLedgerValues.Controls.Add(Me.lblContractName)
        Me.grpLedgerValues.Controls.Add(Me.ddlLedgerType)
        Me.grpLedgerValues.Controls.Add(Me.btnSearchContractNo)
        Me.grpLedgerValues.Controls.Add(Me.Label3)
        Me.grpLedgerValues.Controls.Add(Me.txtJournalDescp)
        Me.grpLedgerValues.Controls.Add(Me.lblJournalDescp)
        Me.grpLedgerValues.Controls.Add(Me.Label2)
        Me.grpLedgerValues.Controls.Add(Me.Label8)
        Me.grpLedgerValues.Controls.Add(Me.lblBatchTotal)
        Me.grpLedgerValues.Controls.Add(Me.Label1)
        Me.grpLedgerValues.Controls.Add(Me.lblledgerNo)
        Me.grpLedgerValues.Controls.Add(Me.dtpJournalDate)
        Me.grpLedgerValues.Controls.Add(Me.Label4)
        Me.grpLedgerValues.Controls.Add(Me.Label6)
        Me.grpLedgerValues.Controls.Add(Me.lblledgerType)
        Me.grpLedgerValues.Controls.Add(Me.lblJournalDate)
        Me.grpLedgerValues.Controls.Add(Me.txtLedgerNo)
        Me.grpLedgerValues.Controls.Add(Me.txtBatchTotal)
        Me.grpLedgerValues.Controls.Add(Me.lblContractNo)
        Me.grpLedgerValues.Controls.Add(Me.txtContractNo)
        Me.grpLedgerValues.Location = New System.Drawing.Point(8, 2)
        Me.grpLedgerValues.Name = "grpLedgerValues"
        Me.grpLedgerValues.Size = New System.Drawing.Size(942, 179)
        Me.grpLedgerValues.TabIndex = 0
        Me.grpLedgerValues.TabStop = False
        '
        'lblRejectedReasonValue
        '
        Me.lblRejectedReasonValue.AutoSize = True
        Me.lblRejectedReasonValue.ForeColor = System.Drawing.Color.Blue
        Me.lblRejectedReasonValue.Location = New System.Drawing.Point(623, 135)
        Me.lblRejectedReasonValue.Name = "lblRejectedReasonValue"
        Me.lblRejectedReasonValue.Size = New System.Drawing.Size(38, 13)
        Me.lblRejectedReasonValue.TabIndex = 251
        Me.lblRejectedReasonValue.Text = "OPEN"
        Me.lblRejectedReasonValue.Visible = False
        '
        'lblColon
        '
        Me.lblColon.AutoSize = True
        Me.lblColon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon.Location = New System.Drawing.Point(602, 135)
        Me.lblColon.Name = "lblColon"
        Me.lblColon.Size = New System.Drawing.Size(11, 13)
        Me.lblColon.TabIndex = 250
        Me.lblColon.Text = ":"
        Me.lblColon.Visible = False
        '
        'lblRecjectedReason
        '
        Me.lblRecjectedReason.ForeColor = System.Drawing.Color.Black
        Me.lblRecjectedReason.Location = New System.Drawing.Point(542, 135)
        Me.lblRecjectedReason.Name = "lblRecjectedReason"
        Me.lblRecjectedReason.Size = New System.Drawing.Size(57, 37)
        Me.lblRecjectedReason.TabIndex = 249
        Me.lblRecjectedReason.Text = "Rejected Reason"
        Me.lblRecjectedReason.Visible = False
        '
        'lblStatusValue
        '
        Me.lblStatusValue.AutoSize = True
        Me.lblStatusValue.ForeColor = System.Drawing.Color.Blue
        Me.lblStatusValue.Location = New System.Drawing.Point(623, 111)
        Me.lblStatusValue.Name = "lblStatusValue"
        Me.lblStatusValue.Size = New System.Drawing.Size(38, 13)
        Me.lblStatusValue.TabIndex = 248
        Me.lblStatusValue.Text = "OPEN"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(602, 110)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(11, 13)
        Me.Label24.TabIndex = 247
        Me.Label24.Text = ":"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(542, 111)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblStatus.TabIndex = 246
        Me.lblStatus.Text = "Status"
        '
        'chkRecurringJournals
        '
        Me.chkRecurringJournals.AutoSize = True
        Me.chkRecurringJournals.Location = New System.Drawing.Point(384, 111)
        Me.chkRecurringJournals.Name = "chkRecurringJournals"
        Me.chkRecurringJournals.Size = New System.Drawing.Size(126, 17)
        Me.chkRecurringJournals.TabIndex = 9
        Me.chkRecurringJournals.Text = "Recurring Journal"
        Me.chkRecurringJournals.UseVisualStyleBackColor = True
        '
        'lblContractName
        '
        Me.lblContractName.AutoSize = True
        Me.lblContractName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContractName.ForeColor = System.Drawing.Color.Blue
        Me.lblContractName.Location = New System.Drawing.Point(406, 79)
        Me.lblContractName.Name = "lblContractName"
        Me.lblContractName.Size = New System.Drawing.Size(93, 13)
        Me.lblContractName.TabIndex = 245
        Me.lblContractName.Text = "Contract Name"
        '
        'ddlLedgerType
        '
        Me.ddlLedgerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlLedgerType.FormattingEnabled = True
        Me.ddlLedgerType.Location = New System.Drawing.Point(155, 15)
        Me.ddlLedgerType.Name = "ddlLedgerType"
        Me.ddlLedgerType.Size = New System.Drawing.Size(180, 21)
        Me.ddlLedgerType.TabIndex = 1
        '
        'btnSearchContractNo
        '
        Me.btnSearchContractNo.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.btnSearchContractNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchContractNo.FlatAppearance.BorderSize = 0
        Me.btnSearchContractNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchContractNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchContractNo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchContractNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchContractNo.Location = New System.Drawing.Point(343, 70)
        Me.btnSearchContractNo.Name = "btnSearchContractNo"
        Me.btnSearchContractNo.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchContractNo.TabIndex = 7
        Me.btnSearchContractNo.TabStop = False
        Me.btnSearchContractNo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(138, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = ":"
        '
        'txtJournalDescp
        '
        Me.txtJournalDescp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJournalDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJournalDescp.Location = New System.Drawing.Point(155, 109)
        Me.txtJournalDescp.MaxLength = 300
        Me.txtJournalDescp.Multiline = True
        Me.txtJournalDescp.Name = "txtJournalDescp"
        Me.txtJournalDescp.Size = New System.Drawing.Size(218, 63)
        Me.txtJournalDescp.TabIndex = 8
        '
        'lblJournalDescp
        '
        Me.lblJournalDescp.AutoSize = True
        Me.lblJournalDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJournalDescp.ForeColor = System.Drawing.Color.Red
        Me.lblJournalDescp.Location = New System.Drawing.Point(17, 109)
        Me.lblJournalDescp.Name = "lblJournalDescp"
        Me.lblJournalDescp.Size = New System.Drawing.Size(87, 13)
        Me.lblJournalDescp.TabIndex = 242
        Me.lblJournalDescp.Text = "Journal Descp"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(505, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(138, 109)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 13)
        Me.Label8.TabIndex = 243
        Me.Label8.Text = ":"
        '
        'lblBatchTotal
        '
        Me.lblBatchTotal.AutoSize = True
        Me.lblBatchTotal.ForeColor = System.Drawing.Color.Black
        Me.lblBatchTotal.Location = New System.Drawing.Point(406, 49)
        Me.lblBatchTotal.Name = "lblBatchTotal"
        Me.lblBatchTotal.Size = New System.Drawing.Size(70, 13)
        Me.lblBatchTotal.TabIndex = 140
        Me.lblBatchTotal.Text = "Batch Total"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(138, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = ":"
        '
        'lblledgerNo
        '
        Me.lblledgerNo.AutoSize = True
        Me.lblledgerNo.ForeColor = System.Drawing.Color.Red
        Me.lblledgerNo.Location = New System.Drawing.Point(17, 49)
        Me.lblledgerNo.Name = "lblledgerNo"
        Me.lblledgerNo.Size = New System.Drawing.Size(65, 13)
        Me.lblledgerNo.TabIndex = 137
        Me.lblledgerNo.Text = "Ledger No"
        '
        'dtpJournalDate
        '
        Me.dtpJournalDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpJournalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpJournalDate.Location = New System.Drawing.Point(525, 15)
        Me.dtpJournalDate.Name = "dtpJournalDate"
        Me.dtpJournalDate.Size = New System.Drawing.Size(180, 21)
        Me.dtpJournalDate.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(138, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 136
        Me.Label4.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(505, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = ":"
        '
        'lblledgerType
        '
        Me.lblledgerType.AutoSize = True
        Me.lblledgerType.ForeColor = System.Drawing.Color.Red
        Me.lblledgerType.Location = New System.Drawing.Point(17, 19)
        Me.lblledgerType.Name = "lblledgerType"
        Me.lblledgerType.Size = New System.Drawing.Size(77, 13)
        Me.lblledgerType.TabIndex = 1
        Me.lblledgerType.Text = "Ledger Type"
        '
        'lblJournalDate
        '
        Me.lblJournalDate.AutoSize = True
        Me.lblJournalDate.ForeColor = System.Drawing.Color.Red
        Me.lblJournalDate.Location = New System.Drawing.Point(406, 19)
        Me.lblJournalDate.Name = "lblJournalDate"
        Me.lblJournalDate.Size = New System.Drawing.Size(79, 13)
        Me.lblJournalDate.TabIndex = 0
        Me.lblJournalDate.Text = "Journal Date"
        '
        'txtLedgerNo
        '
        Me.txtLedgerNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLedgerNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLedgerNo.Location = New System.Drawing.Point(155, 45)
        Me.txtLedgerNo.MaxLength = 50
        Me.txtLedgerNo.Name = "txtLedgerNo"
        Me.txtLedgerNo.Size = New System.Drawing.Size(180, 21)
        Me.txtLedgerNo.TabIndex = 3
        '
        'txtBatchTotal
        '
        Me.txtBatchTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchTotal.Enabled = False
        Me.txtBatchTotal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBatchTotal.Location = New System.Drawing.Point(525, 45)
        Me.txtBatchTotal.MaxLength = 50
        Me.txtBatchTotal.Name = "txtBatchTotal"
        Me.txtBatchTotal.Size = New System.Drawing.Size(180, 21)
        Me.txtBatchTotal.TabIndex = 5
        '
        'lblContractNo
        '
        Me.lblContractNo.AutoSize = True
        Me.lblContractNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContractNo.Location = New System.Drawing.Point(17, 79)
        Me.lblContractNo.Name = "lblContractNo"
        Me.lblContractNo.Size = New System.Drawing.Size(75, 13)
        Me.lblContractNo.TabIndex = 212
        Me.lblContractNo.Text = "Contract No"
        '
        'txtContractNo
        '
        Me.txtContractNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContractNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractNo.Location = New System.Drawing.Point(155, 75)
        Me.txtContractNo.MaxLength = 50
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(180, 21)
        Me.txtContractNo.TabIndex = 6
        '
        'tbView
        '
        Me.tbView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbView.Controls.Add(Me.dgvJournalView)
        Me.tbView.Controls.Add(Me.PnlSearch)
        Me.tbView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbView.Location = New System.Drawing.Point(4, 22)
        Me.tbView.Name = "tbView"
        Me.tbView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbView.Size = New System.Drawing.Size(1006, 672)
        Me.tbView.TabIndex = 1
        Me.tbView.Text = "View"
        Me.tbView.UseVisualStyleBackColor = True
        '
        'dgvJournalView
        '
        Me.dgvJournalView.AllowUserToAddRows = False
        Me.dgvJournalView.AllowUserToDeleteRows = False
        Me.dgvJournalView.AllowUserToResizeRows = False
        Me.dgvJournalView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvJournalView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvJournalView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvJournalView.ColumnHeadersHeight = 30
        Me.dgvJournalView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclLedgerType, Me.dgclRejectedReason, Me.dgclJournalDate, Me.dgclLedgerNo, Me.dgclAccBatchTotal, Me.dgclAccJournalID, Me.dgclContractNo, Me.dgclJournalDescp, Me.dgclLedgerSetupID, Me.dgclAccBatchID, Me.dgclStatus, Me.dgclContractID, Me.dgclContractName, Me.dgclRecuuringJournal})
        Me.dgvJournalView.ContextMenuStrip = Me.cmsJournal
        Me.dgvJournalView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvJournalView.EnableHeadersVisualStyles = False
        Me.dgvJournalView.GridColor = System.Drawing.Color.Gray
        Me.dgvJournalView.Location = New System.Drawing.Point(3, 174)
        Me.dgvJournalView.MultiSelect = False
        Me.dgvJournalView.Name = "dgvJournalView"
        Me.dgvJournalView.ReadOnly = True
        Me.dgvJournalView.RowHeadersVisible = False
        Me.dgvJournalView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJournalView.Size = New System.Drawing.Size(1000, 495)
        Me.dgvJournalView.TabIndex = 118
        '
        'dgclLedgerType
        '
        Me.dgclLedgerType.DataPropertyName = "LedgerType"
        Me.dgclLedgerType.HeaderText = "Ledger Type"
        Me.dgclLedgerType.Name = "dgclLedgerType"
        Me.dgclLedgerType.ReadOnly = True
        Me.dgclLedgerType.Width = 120
        '
        'dgclRejectedReason
        '
        Me.dgclRejectedReason.DataPropertyName = "RejectedReason"
        Me.dgclRejectedReason.HeaderText = "RejectedReason"
        Me.dgclRejectedReason.Name = "dgclRejectedReason"
        Me.dgclRejectedReason.ReadOnly = True
        Me.dgclRejectedReason.Visible = False
        '
        'dgclJournalDate
        '
        Me.dgclJournalDate.DataPropertyName = "JournalDate"
        DataGridViewCellStyle5.Format = "dd/MM/yyyy"
        Me.dgclJournalDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgclJournalDate.HeaderText = "Journal Date"
        Me.dgclJournalDate.Name = "dgclJournalDate"
        Me.dgclJournalDate.ReadOnly = True
        Me.dgclJournalDate.Width = 120
        '
        'dgclLedgerNo
        '
        Me.dgclLedgerNo.DataPropertyName = "LedgerNo"
        Me.dgclLedgerNo.HeaderText = "Ledger No"
        Me.dgclLedgerNo.Name = "dgclLedgerNo"
        Me.dgclLedgerNo.ReadOnly = True
        '
        'dgclAccBatchTotal
        '
        Me.dgclAccBatchTotal.DataPropertyName = "AccBatchTotal"
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.dgclAccBatchTotal.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgclAccBatchTotal.HeaderText = "Batch Total"
        Me.dgclAccBatchTotal.Name = "dgclAccBatchTotal"
        Me.dgclAccBatchTotal.ReadOnly = True
        Me.dgclAccBatchTotal.Width = 150
        '
        'dgclAccJournalID
        '
        Me.dgclAccJournalID.DataPropertyName = "AccJournalID"
        Me.dgclAccJournalID.HeaderText = "AccJournalID"
        Me.dgclAccJournalID.Name = "dgclAccJournalID"
        Me.dgclAccJournalID.ReadOnly = True
        Me.dgclAccJournalID.Visible = False
        '
        'dgclContractNo
        '
        Me.dgclContractNo.DataPropertyName = "ContractNo"
        Me.dgclContractNo.HeaderText = "Contract No"
        Me.dgclContractNo.Name = "dgclContractNo"
        Me.dgclContractNo.ReadOnly = True
        '
        'dgclJournalDescp
        '
        Me.dgclJournalDescp.DataPropertyName = "Description"
        Me.dgclJournalDescp.HeaderText = "Journal Descp"
        Me.dgclJournalDescp.Name = "dgclJournalDescp"
        Me.dgclJournalDescp.ReadOnly = True
        Me.dgclJournalDescp.Width = 200
        '
        'dgclLedgerSetupID
        '
        Me.dgclLedgerSetupID.DataPropertyName = "LedgerSetupID"
        Me.dgclLedgerSetupID.HeaderText = "LedgerSetupID"
        Me.dgclLedgerSetupID.Name = "dgclLedgerSetupID"
        Me.dgclLedgerSetupID.ReadOnly = True
        Me.dgclLedgerSetupID.Visible = False
        '
        'dgclAccBatchID
        '
        Me.dgclAccBatchID.DataPropertyName = "AccBatchID"
        Me.dgclAccBatchID.HeaderText = "AccBatchID"
        Me.dgclAccBatchID.Name = "dgclAccBatchID"
        Me.dgclAccBatchID.ReadOnly = True
        Me.dgclAccBatchID.Visible = False
        '
        'dgclStatus
        '
        Me.dgclStatus.DataPropertyName = "Status"
        Me.dgclStatus.HeaderText = "Status"
        Me.dgclStatus.Name = "dgclStatus"
        Me.dgclStatus.ReadOnly = True
        '
        'dgclContractID
        '
        Me.dgclContractID.DataPropertyName = "ContractID"
        Me.dgclContractID.HeaderText = "ContractID"
        Me.dgclContractID.Name = "dgclContractID"
        Me.dgclContractID.ReadOnly = True
        Me.dgclContractID.Visible = False
        '
        'dgclContractName
        '
        Me.dgclContractName.DataPropertyName = "ContractName"
        Me.dgclContractName.HeaderText = "Contract Name"
        Me.dgclContractName.Name = "dgclContractName"
        Me.dgclContractName.ReadOnly = True
        Me.dgclContractName.Visible = False
        '
        'dgclRecuuringJournal
        '
        Me.dgclRecuuringJournal.DataPropertyName = "RecurringJournal"
        Me.dgclRecuuringJournal.HeaderText = "RecuuringJournal"
        Me.dgclRecuuringJournal.Name = "dgclRecuuringJournal"
        Me.dgclRecuuringJournal.ReadOnly = True
        Me.dgclRecuuringJournal.Visible = False
        '
        'cmsJournal
        '
        Me.cmsJournal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsJournal.Name = "cmsIPR"
        Me.cmsJournal.Size = New System.Drawing.Size(108, 70)
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
        Me.PnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlSearch.BorderColor = System.Drawing.Color.Gray
        Me.PnlSearch.CaptionColorOne = System.Drawing.Color.White
        Me.PnlSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlSearch.CaptionSize = 40
        Me.PnlSearch.CaptionText = "Search Journal "
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.lblSearchStatus)
        Me.PnlSearch.Controls.Add(Me.cmbSearchStatus)
        Me.PnlSearch.Controls.Add(Me.btnviewReport)
        Me.PnlSearch.Controls.Add(Me.ddlLedgerTypeSearch)
        Me.PnlSearch.Controls.Add(Me.lblLedgerNoSearch)
        Me.PnlSearch.Controls.Add(Me.lblLedgerTypeSearch)
        Me.PnlSearch.Controls.Add(Me.txtLedgerNoSearch)
        Me.PnlSearch.Controls.Add(Me.lblsearchBy)
        Me.PnlSearch.Controls.Add(Me.chkJournalDate)
        Me.PnlSearch.Controls.Add(Me.btnSearch)
        Me.PnlSearch.Controls.Add(Me.dtpviewJournalDate)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.ForeColor = System.Drawing.Color.Black
        Me.PnlSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(1000, 171)
        Me.PnlSearch.TabIndex = 100
        '
        'lblSearchStatus
        '
        Me.lblSearchStatus.AutoSize = True
        Me.lblSearchStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSearchStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSearchStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchStatus.Location = New System.Drawing.Point(386, 112)
        Me.lblSearchStatus.Name = "lblSearchStatus"
        Me.lblSearchStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblSearchStatus.TabIndex = 219
        Me.lblSearchStatus.Text = "Status"
        '
        'cmbSearchStatus
        '
        Me.cmbSearchStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchStatus.FormattingEnabled = True
        Me.cmbSearchStatus.Items.AddRange(New Object() {"Select All", "OPEN", "APPROVED"})
        Me.cmbSearchStatus.Location = New System.Drawing.Point(390, 135)
        Me.cmbSearchStatus.Name = "cmbSearchStatus"
        Me.cmbSearchStatus.Size = New System.Drawing.Size(192, 21)
        Me.cmbSearchStatus.TabIndex = 107
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(744, 133)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(122, 25)
        Me.btnviewReport.TabIndex = 109
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'ddlLedgerTypeSearch
        '
        Me.ddlLedgerTypeSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlLedgerTypeSearch.FormattingEnabled = True
        Me.ddlLedgerTypeSearch.Location = New System.Drawing.Point(390, 80)
        Me.ddlLedgerTypeSearch.Name = "ddlLedgerTypeSearch"
        Me.ddlLedgerTypeSearch.Size = New System.Drawing.Size(192, 21)
        Me.ddlLedgerTypeSearch.TabIndex = 105
        '
        'lblLedgerNoSearch
        '
        Me.lblLedgerNoSearch.AutoSize = True
        Me.lblLedgerNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblLedgerNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblLedgerNoSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLedgerNoSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLedgerNoSearch.Location = New System.Drawing.Point(148, 112)
        Me.lblLedgerNoSearch.Name = "lblLedgerNoSearch"
        Me.lblLedgerNoSearch.Size = New System.Drawing.Size(65, 13)
        Me.lblLedgerNoSearch.TabIndex = 216
        Me.lblLedgerNoSearch.Text = "Ledger No"
        '
        'lblLedgerTypeSearch
        '
        Me.lblLedgerTypeSearch.AutoSize = True
        Me.lblLedgerTypeSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblLedgerTypeSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblLedgerTypeSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLedgerTypeSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLedgerTypeSearch.Location = New System.Drawing.Point(386, 59)
        Me.lblLedgerTypeSearch.Name = "lblLedgerTypeSearch"
        Me.lblLedgerTypeSearch.Size = New System.Drawing.Size(77, 13)
        Me.lblLedgerTypeSearch.TabIndex = 120
        Me.lblLedgerTypeSearch.Text = "Ledger Type"
        '
        'txtLedgerNoSearch
        '
        Me.txtLedgerNoSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLedgerNoSearch.Location = New System.Drawing.Point(151, 135)
        Me.txtLedgerNoSearch.Name = "txtLedgerNoSearch"
        Me.txtLedgerNoSearch.Size = New System.Drawing.Size(192, 21)
        Me.txtLedgerNoSearch.TabIndex = 106
        '
        'lblsearchBy
        '
        Me.lblsearchBy.AutoSize = True
        Me.lblsearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblsearchBy.Location = New System.Drawing.Point(6, 59)
        Me.lblsearchBy.Name = "lblsearchBy"
        Me.lblsearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchBy.TabIndex = 54
        Me.lblsearchBy.Text = "Search By"
        '
        'chkJournalDate
        '
        Me.chkJournalDate.AutoSize = True
        Me.chkJournalDate.Location = New System.Drawing.Point(151, 57)
        Me.chkJournalDate.Name = "chkJournalDate"
        Me.chkJournalDate.Size = New System.Drawing.Size(98, 17)
        Me.chkJournalDate.TabIndex = 103
        Me.chkJournalDate.Text = "Journal Date"
        Me.chkJournalDate.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(610, 133)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 108
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dtpviewJournalDate
        '
        Me.dtpviewJournalDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpviewJournalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpviewJournalDate.Location = New System.Drawing.Point(151, 80)
        Me.dtpviewJournalDate.Name = "dtpviewJournalDate"
        Me.dtpviewJournalDate.Size = New System.Drawing.Size(192, 21)
        Me.dtpviewJournalDate.TabIndex = 104
        '
        'JournalFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1014, 698)
        Me.Controls.Add(Me.tbJournal)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(817, 0)
        Me.Name = "JournalFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JournalFrm"
        Me.tbJournal.ResumeLayout(False)
        Me.tbAdd.ResumeLayout(False)
        CType(Me.dgvMultipleEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSMultipleentry.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpTAnalysis.ResumeLayout(False)
        Me.grpTAnalysis.PerformLayout()
        Me.grpApproval.ResumeLayout(False)
        Me.grpApproval.PerformLayout()
        Me.grpAccountCode.ResumeLayout(False)
        Me.grpAccountCode.PerformLayout()
        Me.grpDedit.ResumeLayout(False)
        Me.grpDedit.PerformLayout()
        Me.grpLedgerValues.ResumeLayout(False)
        Me.grpLedgerValues.PerformLayout()
        Me.tbView.ResumeLayout(False)
        CType(Me.dgvJournalView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsJournal.ResumeLayout(False)
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbJournal As System.Windows.Forms.TabControl
    Friend WithEvents tbAdd As System.Windows.Forms.TabPage
    Friend WithEvents btnResetIB As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtDiff As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblDiff As System.Windows.Forms.Label
    Friend WithEvents txtCredit As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblDebit As System.Windows.Forms.Label
    Friend WithEvents txtDebit As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents tbView As System.Windows.Forms.TabPage
    Friend WithEvents grpAccountCode As System.Windows.Forms.GroupBox
    Friend WithEvents lblAccountDescp As System.Windows.Forms.Label
    Friend WithEvents btnSearchVehicleDetailCostCode As System.Windows.Forms.Button
    Friend WithEvents btnSearchVehicleCode As System.Windows.Forms.Button
    Friend WithEvents btnSearchSubBlock As System.Windows.Forms.Button
    Friend WithEvents btnDivSearch As System.Windows.Forms.Button
    Friend WithEvents txtDetailCostCode As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblDetailCostCode As System.Windows.Forms.Label
    Friend WithEvents txtVehicleCode As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblVehicleCode As System.Windows.Forms.Label
    Friend WithEvents txtSubBlock As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblSubBlock As System.Windows.Forms.Label
    Friend WithEvents txtYOP As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblYOP As System.Windows.Forms.Label
    Friend WithEvents txtDiv As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblDiv As System.Windows.Forms.Label
    Friend WithEvents btnAccountCodeLookup As System.Windows.Forms.Button
    Friend WithEvents lblAccountCode As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchStation As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtStation As System.Windows.Forms.TextBox
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCreditKeenValue As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblDebitKeenValue As System.Windows.Forms.Label
    Friend WithEvents txtDebitKeenValue As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblCreditKeenValue As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmsJournal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvMultipleEntry As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblDivName As System.Windows.Forms.Label
    Friend WithEvents lblStationDescp As System.Windows.Forms.Label
    Friend WithEvents lblDetailCostDescp As System.Windows.Forms.Label
    Friend WithEvents lblVehicleDescp As System.Windows.Forms.Label
    Friend WithEvents lblBlockStatus As System.Windows.Forms.Label
    Friend WithEvents lblYOPName As System.Windows.Forms.Label
    Friend WithEvents CMSMultipleentry As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents ddlLedgerTypeSearch As System.Windows.Forms.ComboBox
    Friend WithEvents txtLedgerNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblLedgerNoSearch As System.Windows.Forms.Label
    Friend WithEvents chkJournalDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblLedgerTypeSearch As System.Windows.Forms.Label
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dtpviewJournalDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpDedit As System.Windows.Forms.GroupBox
    Friend WithEvents dgvJournalView As System.Windows.Forms.DataGridView
    Friend WithEvents lblOldAccountCode As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents lblSearchStatus As System.Windows.Forms.Label
    Friend WithEvents cmbSearchStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnResetMultipleEntryGrp As System.Windows.Forms.Button
    Friend WithEvents grpTAnalysis As System.Windows.Forms.GroupBox
    Friend WithEvents grpApproval As System.Windows.Forms.GroupBox
    Friend WithEvents txtRejectedReason As System.Windows.Forms.TextBox
    Friend WithEvents lblRejColon As System.Windows.Forms.Label
    Friend WithEvents lblRejReason As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnConform As System.Windows.Forms.Button
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatusApproval As System.Windows.Forms.Label
    Friend WithEvents lblT4Name As System.Windows.Forms.Label
    Friend WithEvents lblT3Name As System.Windows.Forms.Label
    Friend WithEvents lblT2Name As System.Windows.Forms.Label
    Friend WithEvents lblT1Name As System.Windows.Forms.Label
    Friend WithEvents lblT0Name As System.Windows.Forms.Label
    Friend WithEvents btnSearchT4 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT3 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT2 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT1 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT0 As System.Windows.Forms.Button
    Friend WithEvents txtT4 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblT4 As System.Windows.Forms.Label
    Friend WithEvents txtT3 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblT3 As System.Windows.Forms.Label
    Friend WithEvents txtT2 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblT2 As System.Windows.Forms.Label
    Friend WithEvents txtT1 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblT1 As System.Windows.Forms.Label
    Friend WithEvents txtT0 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblT0 As System.Windows.Forms.Label
    Friend WithEvents dgclLedgerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclJournalDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLedgerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAccBatchTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAccJournalID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclContractNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclJournalDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLedgerSetupID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAccBatchID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclContractID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclContractName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRecuuringJournal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnApprovalClose As System.Windows.Forms.Button
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents txtDescp As System.Windows.Forms.TextBox
    Friend WithEvents lblDescp As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dgMeAccJournalID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeOldCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeCOADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeDivID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeYOPID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeBlockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeVHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeVHDetailCostCodeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgmeVHType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeDiv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeYOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeSubBlock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeStationCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeVHWSCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeVHDetailCostCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeStationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeTAnalysisCode0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeTAnalysisCode1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeTAnalysisCode2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeTAnalysisCode3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeTAnalysisCode4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeT0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeT2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeT3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeT4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeTAnalysisDescp0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeDivName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeYOPName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeBlockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeStationDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgVHDetailCostDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgmeVehicleDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeTAnalysisDescp1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeTAnalysisDescp2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeTAnalysisDescp3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeTAnalysisDescp4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpLedgerValues As System.Windows.Forms.GroupBox
    Friend WithEvents lblRejectedReasonValue As System.Windows.Forms.Label
    Friend WithEvents lblColon As System.Windows.Forms.Label
    Friend WithEvents lblRecjectedReason As System.Windows.Forms.Label
    Friend WithEvents lblStatusValue As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents chkRecurringJournals As System.Windows.Forms.CheckBox
    Friend WithEvents lblContractName As System.Windows.Forms.Label
    Friend WithEvents ddlLedgerType As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearchContractNo As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtJournalDescp As System.Windows.Forms.TextBox
    Friend WithEvents lblJournalDescp As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblBatchTotal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblledgerNo As System.Windows.Forms.Label
    Friend WithEvents dtpJournalDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblledgerType As System.Windows.Forms.Label
    Friend WithEvents lblJournalDate As System.Windows.Forms.Label
    Friend WithEvents txtLedgerNo As System.Windows.Forms.TextBox
    Friend WithEvents txtBatchTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblContractNo As System.Windows.Forms.Label
    Friend WithEvents txtContractNo As System.Windows.Forms.TextBox
End Class

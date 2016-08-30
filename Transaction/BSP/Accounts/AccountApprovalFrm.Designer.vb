<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountApprovalFrm
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountApprovalFrm))
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvJournalApproval = New System.Windows.Forms.DataGridView()
        Me.dgclDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclAccBatchID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLedgerType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLedgerNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgVStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclBatchTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclViewDetails = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lblSelectTransaction = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnLedgerNoSearch = New System.Windows.Forms.Button()
        Me.ddlTransaction = New System.Windows.Forms.ComboBox()
        Me.lblledgerType = New System.Windows.Forms.Label()
        Me.lblledgerNo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.plAccountsApproval = New Stepi.UI.ExtendedPanel()
        Me.btnClos = New System.Windows.Forms.Button()
        Me.cbLedgerType = New System.Windows.Forms.CheckBox()
        Me.txtLedgerNo = New System.Windows.Forms.TextBox()
        Me.btnApproval = New System.Windows.Forms.Button()
        Me.cbAllRecordsTransaction = New System.Windows.Forms.CheckBox()
        Me.btnResetIB = New System.Windows.Forms.Button()
        Me.ddlLedgerType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvPettyCashPayment = New System.Windows.Forms.DataGridView()
        Me.dgPVoucherDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPVoucherNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPPayTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPPayDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgPViewDetails = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgPettyCashReciept = New System.Windows.Forms.DataGridView()
        Me.dgPRReceiptDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dbPRReceiptID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRCashReconcilationDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRReceiptDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRViewDetails = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DgPRT0PC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRT1PC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgPRT2PC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgPRT3PC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgT4PC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRT0SAM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRT1SAM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRT2SAM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRT3SAM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPRT4SAM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvMultipleEntry = New System.Windows.Forms.DataGridView()
        Me.dgMeAccJournalID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeTransactiontype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgMeCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeOldCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        CType(Me.dgvJournalApproval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.plAccountsApproval.SuspendLayout()
        CType(Me.dgvPettyCashPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPettyCashReciept, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMultipleEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvJournalApproval
        '
        Me.dgvJournalApproval.AllowUserToAddRows = False
        Me.dgvJournalApproval.AllowUserToDeleteRows = False
        Me.dgvJournalApproval.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvJournalApproval.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvJournalApproval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvJournalApproval.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvJournalApproval.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvJournalApproval.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvJournalApproval.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalApproval.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvJournalApproval.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclDate, Me.dgclAccBatchID, Me.dgclLedgerType, Me.dgclLedgerNo, Me.dgclDescription, Me.dgVStatus, Me.dgclBatchTotal, Me.dgclViewDetails})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJournalApproval.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvJournalApproval.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvJournalApproval.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvJournalApproval.EnableHeadersVisualStyles = False
        Me.dgvJournalApproval.GridColor = System.Drawing.Color.Gray
        Me.dgvJournalApproval.Location = New System.Drawing.Point(0, 224)
        Me.dgvJournalApproval.Name = "dgvJournalApproval"
        Me.dgvJournalApproval.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalApproval.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvJournalApproval.RowHeadersVisible = False
        Me.dgvJournalApproval.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvJournalApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJournalApproval.ShowCellErrors = False
        Me.dgvJournalApproval.Size = New System.Drawing.Size(856, 262)
        Me.dgvJournalApproval.TabIndex = 149
        '
        'dgclDate
        '
        Me.dgclDate.DataPropertyName = "JournalDate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgclDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgclDate.HeaderText = "Journal Date"
        Me.dgclDate.Name = "dgclDate"
        Me.dgclDate.ReadOnly = True
        Me.dgclDate.Width = 103
        '
        'dgclAccBatchID
        '
        Me.dgclAccBatchID.DataPropertyName = "AccBatchID"
        Me.dgclAccBatchID.HeaderText = "AccBatchID"
        Me.dgclAccBatchID.Name = "dgclAccBatchID"
        Me.dgclAccBatchID.ReadOnly = True
        Me.dgclAccBatchID.Visible = False
        Me.dgclAccBatchID.Width = 97
        '
        'dgclLedgerType
        '
        Me.dgclLedgerType.DataPropertyName = "LedgerType"
        Me.dgclLedgerType.HeaderText = "Ledger Type"
        Me.dgclLedgerType.Name = "dgclLedgerType"
        Me.dgclLedgerType.ReadOnly = True
        Me.dgclLedgerType.Width = 102
        '
        'dgclLedgerNo
        '
        Me.dgclLedgerNo.DataPropertyName = "LedgerNo"
        Me.dgclLedgerNo.HeaderText = "Ledger No"
        Me.dgclLedgerNo.Name = "dgclLedgerNo"
        Me.dgclLedgerNo.ReadOnly = True
        Me.dgclLedgerNo.Width = 89
        '
        'dgclDescription
        '
        Me.dgclDescription.DataPropertyName = "Description"
        Me.dgclDescription.HeaderText = "Description"
        Me.dgclDescription.Name = "dgclDescription"
        Me.dgclDescription.ReadOnly = True
        Me.dgclDescription.Width = 95
        '
        'dgVStatus
        '
        DataGridViewCellStyle4.NullValue = "OPEN"
        Me.dgVStatus.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgVStatus.HeaderText = "Status"
        Me.dgVStatus.Name = "dgVStatus"
        Me.dgVStatus.ReadOnly = True
        Me.dgVStatus.Width = 67
        '
        'dgclBatchTotal
        '
        Me.dgclBatchTotal.DataPropertyName = "AccBatchTotal"
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.dgclBatchTotal.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgclBatchTotal.HeaderText = "Batch Total"
        Me.dgclBatchTotal.Name = "dgclBatchTotal"
        Me.dgclBatchTotal.ReadOnly = True
        Me.dgclBatchTotal.Width = 95
        '
        'dgclViewDetails
        '
        Me.dgclViewDetails.DataPropertyName = "ViewDetails"
        Me.dgclViewDetails.HeaderText = "View Details"
        Me.dgclViewDetails.Name = "dgclViewDetails"
        Me.dgclViewDetails.ReadOnly = True
        Me.dgclViewDetails.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgclViewDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgclViewDetails.Text = "View Details"
        Me.dgclViewDetails.UseColumnTextForButtonValue = True
        Me.dgclViewDetails.Width = 101
        '
        'lblSelectTransaction
        '
        Me.lblSelectTransaction.AutoSize = True
        Me.lblSelectTransaction.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectTransaction.ForeColor = System.Drawing.Color.Black
        Me.lblSelectTransaction.Location = New System.Drawing.Point(41, 60)
        Me.lblSelectTransaction.Name = "lblSelectTransaction"
        Me.lblSelectTransaction.Size = New System.Drawing.Size(112, 13)
        Me.lblSelectTransaction.TabIndex = 17
        Me.lblSelectTransaction.Text = "Select Transaction"
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(290, 173)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(102, 23)
        Me.btnSearch.TabIndex = 107
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnLedgerNoSearch
        '
        Me.btnLedgerNoSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLedgerNoSearch.FlatAppearance.BorderSize = 0
        Me.btnLedgerNoSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnLedgerNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLedgerNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnLedgerNoSearch.Image = CType(resources.GetObject("btnLedgerNoSearch.Image"), System.Drawing.Image)
        Me.btnLedgerNoSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLedgerNoSearch.Location = New System.Drawing.Point(364, 106)
        Me.btnLedgerNoSearch.Name = "btnLedgerNoSearch"
        Me.btnLedgerNoSearch.Size = New System.Drawing.Size(26, 31)
        Me.btnLedgerNoSearch.TabIndex = 105
        Me.btnLedgerNoSearch.TabStop = False
        Me.btnLedgerNoSearch.UseVisualStyleBackColor = True
        '
        'ddlTransaction
        '
        Me.ddlTransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlTransaction.FormattingEnabled = True
        Me.ddlTransaction.Items.AddRange(New Object() {"Journal", "Petty Cash Payment", "Petty Cash Receipt"})
        Me.ddlTransaction.Location = New System.Drawing.Point(178, 57)
        Me.ddlTransaction.Name = "ddlTransaction"
        Me.ddlTransaction.Size = New System.Drawing.Size(180, 21)
        Me.ddlTransaction.TabIndex = 100
        '
        'lblledgerType
        '
        Me.lblledgerType.AutoSize = True
        Me.lblledgerType.ForeColor = System.Drawing.Color.Black
        Me.lblledgerType.Location = New System.Drawing.Point(41, 90)
        Me.lblledgerType.Name = "lblledgerType"
        Me.lblledgerType.Size = New System.Drawing.Size(78, 13)
        Me.lblledgerType.TabIndex = 109
        Me.lblledgerType.Text = "Ledger Type"
        '
        'lblledgerNo
        '
        Me.lblledgerNo.AutoSize = True
        Me.lblledgerNo.ForeColor = System.Drawing.Color.Black
        Me.lblledgerNo.Location = New System.Drawing.Point(41, 120)
        Me.lblledgerNo.Name = "lblledgerNo"
        Me.lblledgerNo.Size = New System.Drawing.Size(65, 13)
        Me.lblledgerNo.TabIndex = 138
        Me.lblledgerNo.Text = "Ledger No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(162, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = ":"
        '
        'plAccountsApproval
        '
        Me.plAccountsApproval.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plAccountsApproval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plAccountsApproval.BorderColor = System.Drawing.Color.Gray
        Me.plAccountsApproval.CaptionColorOne = System.Drawing.Color.White
        Me.plAccountsApproval.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plAccountsApproval.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plAccountsApproval.CaptionSize = 40
        Me.plAccountsApproval.CaptionText = "Accounts Approval"
        Me.plAccountsApproval.CaptionTextColor = System.Drawing.Color.Black
        Me.plAccountsApproval.Controls.Add(Me.btnClos)
        Me.plAccountsApproval.Controls.Add(Me.cbLedgerType)
        Me.plAccountsApproval.Controls.Add(Me.txtLedgerNo)
        Me.plAccountsApproval.Controls.Add(Me.btnApproval)
        Me.plAccountsApproval.Controls.Add(Me.cbAllRecordsTransaction)
        Me.plAccountsApproval.Controls.Add(Me.btnResetIB)
        Me.plAccountsApproval.Controls.Add(Me.ddlLedgerType)
        Me.plAccountsApproval.Controls.Add(Me.Label2)
        Me.plAccountsApproval.Controls.Add(Me.Label1)
        Me.plAccountsApproval.Controls.Add(Me.Label4)
        Me.plAccountsApproval.Controls.Add(Me.lblledgerNo)
        Me.plAccountsApproval.Controls.Add(Me.lblledgerType)
        Me.plAccountsApproval.Controls.Add(Me.ddlTransaction)
        Me.plAccountsApproval.Controls.Add(Me.btnLedgerNoSearch)
        Me.plAccountsApproval.Controls.Add(Me.lblSelectTransaction)
        Me.plAccountsApproval.Controls.Add(Me.btnSearch)
        Me.plAccountsApproval.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plAccountsApproval.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plAccountsApproval.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plAccountsApproval.Dock = System.Windows.Forms.DockStyle.Top
        Me.plAccountsApproval.ForeColor = System.Drawing.Color.Black
        Me.plAccountsApproval.Location = New System.Drawing.Point(0, 0)
        Me.plAccountsApproval.Name = "plAccountsApproval"
        Me.plAccountsApproval.Size = New System.Drawing.Size(856, 224)
        Me.plAccountsApproval.TabIndex = 148
        '
        'btnClos
        '
        Me.btnClos.BackgroundImage = CType(resources.GetObject("btnClos.BackgroundImage"), System.Drawing.Image)
        Me.btnClos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClos.Image = CType(resources.GetObject("btnClos.Image"), System.Drawing.Image)
        Me.btnClos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClos.Location = New System.Drawing.Point(506, 173)
        Me.btnClos.Name = "btnClos"
        Me.btnClos.Size = New System.Drawing.Size(102, 23)
        Me.btnClos.TabIndex = 109
        Me.btnClos.Text = "Close"
        Me.btnClos.UseVisualStyleBackColor = True
        '
        'cbLedgerType
        '
        Me.cbLedgerType.AutoSize = True
        Me.cbLedgerType.Location = New System.Drawing.Point(364, 88)
        Me.cbLedgerType.Name = "cbLedgerType"
        Me.cbLedgerType.Size = New System.Drawing.Size(90, 17)
        Me.cbLedgerType.TabIndex = 103
        Me.cbLedgerType.Text = "All Records"
        Me.cbLedgerType.UseVisualStyleBackColor = True
        '
        'txtLedgerNo
        '
        Me.txtLedgerNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLedgerNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLedgerNo.Location = New System.Drawing.Point(178, 116)
        Me.txtLedgerNo.MaxLength = 50
        Me.txtLedgerNo.Name = "txtLedgerNo"
        Me.txtLedgerNo.Size = New System.Drawing.Size(180, 21)
        Me.txtLedgerNo.TabIndex = 104
        '
        'btnApproval
        '
        Me.btnApproval.BackgroundImage = CType(resources.GetObject("btnApproval.BackgroundImage"), System.Drawing.Image)
        Me.btnApproval.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnApproval.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApproval.ForeColor = System.Drawing.Color.Black
        Me.btnApproval.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApproval.Location = New System.Drawing.Point(182, 173)
        Me.btnApproval.Name = "btnApproval"
        Me.btnApproval.Size = New System.Drawing.Size(102, 23)
        Me.btnApproval.TabIndex = 106
        Me.btnApproval.Text = "Post All"
        Me.btnApproval.UseVisualStyleBackColor = True
        '
        'cbAllRecordsTransaction
        '
        Me.cbAllRecordsTransaction.AutoSize = True
        Me.cbAllRecordsTransaction.Location = New System.Drawing.Point(364, 61)
        Me.cbAllRecordsTransaction.Name = "cbAllRecordsTransaction"
        Me.cbAllRecordsTransaction.Size = New System.Drawing.Size(90, 17)
        Me.cbAllRecordsTransaction.TabIndex = 101
        Me.cbAllRecordsTransaction.Text = "All Records"
        Me.cbAllRecordsTransaction.UseVisualStyleBackColor = True
        '
        'btnResetIB
        '
        Me.btnResetIB.BackgroundImage = CType(resources.GetObject("btnResetIB.BackgroundImage"), System.Drawing.Image)
        Me.btnResetIB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetIB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetIB.Image = CType(resources.GetObject("btnResetIB.Image"), System.Drawing.Image)
        Me.btnResetIB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetIB.Location = New System.Drawing.Point(398, 173)
        Me.btnResetIB.Name = "btnResetIB"
        Me.btnResetIB.Size = New System.Drawing.Size(102, 23)
        Me.btnResetIB.TabIndex = 108
        Me.btnResetIB.Text = "Reset"
        Me.btnResetIB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnResetIB.UseVisualStyleBackColor = True
        '
        'ddlLedgerType
        '
        Me.ddlLedgerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlLedgerType.FormattingEnabled = True
        Me.ddlLedgerType.Location = New System.Drawing.Point(178, 86)
        Me.ddlLedgerType.Name = "ddlLedgerType"
        Me.ddlLedgerType.Size = New System.Drawing.Size(180, 21)
        Me.ddlLedgerType.TabIndex = 102
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(162, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(162, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = ":"
        '
        'dgvPettyCashPayment
        '
        Me.dgvPettyCashPayment.AllowUserToAddRows = False
        Me.dgvPettyCashPayment.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        Me.dgvPettyCashPayment.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvPettyCashPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPettyCashPayment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPettyCashPayment.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPettyCashPayment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPettyCashPayment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPettyCashPayment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPettyCashPayment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgPVoucherDate, Me.dgPVoucherNo, Me.dgPPayTo, Me.dgPPayDescp, Me.dgPStatus, Me.DgPViewDetails})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPettyCashPayment.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvPettyCashPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPettyCashPayment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvPettyCashPayment.EnableHeadersVisualStyles = False
        Me.dgvPettyCashPayment.GridColor = System.Drawing.Color.Gray
        Me.dgvPettyCashPayment.Location = New System.Drawing.Point(0, 224)
        Me.dgvPettyCashPayment.Name = "dgvPettyCashPayment"
        Me.dgvPettyCashPayment.ReadOnly = True
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPettyCashPayment.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvPettyCashPayment.RowHeadersVisible = False
        Me.dgvPettyCashPayment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvPettyCashPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPettyCashPayment.ShowCellErrors = False
        Me.dgvPettyCashPayment.Size = New System.Drawing.Size(856, 262)
        Me.dgvPettyCashPayment.TabIndex = 150
        '
        'dgPVoucherDate
        '
        Me.dgPVoucherDate.DataPropertyName = "VoucherDate"
        DataGridViewCellStyle10.Format = "dd/MM/yyyy"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.dgPVoucherDate.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgPVoucherDate.HeaderText = "Voucher Date"
        Me.dgPVoucherDate.Name = "dgPVoucherDate"
        Me.dgPVoucherDate.ReadOnly = True
        Me.dgPVoucherDate.Width = 109
        '
        'dgPVoucherNo
        '
        Me.dgPVoucherNo.DataPropertyName = "VoucherNo"
        Me.dgPVoucherNo.HeaderText = "VoucherNo"
        Me.dgPVoucherNo.Name = "dgPVoucherNo"
        Me.dgPVoucherNo.ReadOnly = True
        Me.dgPVoucherNo.Width = 93
        '
        'dgPPayTo
        '
        Me.dgPPayTo.DataPropertyName = "DistributionDescp"
        Me.dgPPayTo.HeaderText = "Pay To"
        Me.dgPPayTo.Name = "dgPPayTo"
        Me.dgPPayTo.ReadOnly = True
        Me.dgPPayTo.Width = 70
        '
        'dgPPayDescp
        '
        Me.dgPPayDescp.DataPropertyName = "PayDescp"
        Me.dgPPayDescp.HeaderText = "Pay Description"
        Me.dgPPayDescp.Name = "dgPPayDescp"
        Me.dgPPayDescp.ReadOnly = True
        Me.dgPPayDescp.Visible = False
        Me.dgPPayDescp.Width = 120
        '
        'dgPStatus
        '
        DataGridViewCellStyle11.NullValue = "OPEN"
        Me.dgPStatus.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgPStatus.HeaderText = "Status"
        Me.dgPStatus.Name = "dgPStatus"
        Me.dgPStatus.ReadOnly = True
        Me.dgPStatus.Width = 67
        '
        'DgPViewDetails
        '
        Me.DgPViewDetails.DataPropertyName = "ViewDetails"
        Me.DgPViewDetails.HeaderText = "View Details"
        Me.DgPViewDetails.Name = "DgPViewDetails"
        Me.DgPViewDetails.ReadOnly = True
        Me.DgPViewDetails.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgPViewDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DgPViewDetails.Text = "View Details"
        Me.DgPViewDetails.UseColumnTextForButtonValue = True
        Me.DgPViewDetails.Width = 101
        '
        'dgPettyCashReciept
        '
        Me.dgPettyCashReciept.AllowUserToAddRows = False
        Me.dgPettyCashReciept.AllowUserToDeleteRows = False
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White
        Me.dgPettyCashReciept.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dgPettyCashReciept.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgPettyCashReciept.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgPettyCashReciept.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgPettyCashReciept.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgPettyCashReciept.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPettyCashReciept.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgPettyCashReciept.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgPRReceiptDate, Me.dbPRReceiptID, Me.dgPRReceiptNo, Me.dgPRCashReconcilationDate, Me.dgPRReceiptDescp, Me.dgPRAmount, Me.dgPRStatus, Me.dgPRViewDetails, Me.DgPRT0PC, Me.dgPRT1PC, Me.DgPRT2PC, Me.DgPRT3PC, Me.dgT4PC, Me.dgPRT0SAM, Me.dgPRT1SAM, Me.dgPRT2SAM, Me.dgPRT3SAM, Me.dgPRT4SAM})
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPettyCashReciept.DefaultCellStyle = DataGridViewCellStyle19
        Me.dgPettyCashReciept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPettyCashReciept.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgPettyCashReciept.EnableHeadersVisualStyles = False
        Me.dgPettyCashReciept.GridColor = System.Drawing.Color.Gray
        Me.dgPettyCashReciept.Location = New System.Drawing.Point(0, 224)
        Me.dgPettyCashReciept.Name = "dgPettyCashReciept"
        Me.dgPettyCashReciept.ReadOnly = True
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPettyCashReciept.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgPettyCashReciept.RowHeadersVisible = False
        Me.dgPettyCashReciept.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgPettyCashReciept.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPettyCashReciept.ShowCellErrors = False
        Me.dgPettyCashReciept.Size = New System.Drawing.Size(856, 262)
        Me.dgPettyCashReciept.TabIndex = 151
        '
        'dgPRReceiptDate
        '
        Me.dgPRReceiptDate.DataPropertyName = "ReceiptDate"
        DataGridViewCellStyle16.Format = "dd/MM/yyyy"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.dgPRReceiptDate.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgPRReceiptDate.HeaderText = "Receipt Date"
        Me.dgPRReceiptDate.Name = "dgPRReceiptDate"
        Me.dgPRReceiptDate.ReadOnly = True
        Me.dgPRReceiptDate.Width = 104
        '
        'dbPRReceiptID
        '
        Me.dbPRReceiptID.DataPropertyName = "ReceiptID"
        Me.dbPRReceiptID.HeaderText = "ReceiptID"
        Me.dbPRReceiptID.Name = "dbPRReceiptID"
        Me.dbPRReceiptID.ReadOnly = True
        Me.dbPRReceiptID.Visible = False
        Me.dbPRReceiptID.Width = 87
        '
        'dgPRReceiptNo
        '
        Me.dgPRReceiptNo.DataPropertyName = "ReceiptNo"
        Me.dgPRReceiptNo.HeaderText = "ReceiptNo"
        Me.dgPRReceiptNo.Name = "dgPRReceiptNo"
        Me.dgPRReceiptNo.ReadOnly = True
        Me.dgPRReceiptNo.Width = 88
        '
        'dgPRCashReconcilationDate
        '
        Me.dgPRCashReconcilationDate.DataPropertyName = "CashReconcilationDate"
        DataGridViewCellStyle17.Format = "dd/MM/yyyy"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.dgPRCashReconcilationDate.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgPRCashReconcilationDate.HeaderText = "Cash Reconcilation Date"
        Me.dgPRCashReconcilationDate.Name = "dgPRCashReconcilationDate"
        Me.dgPRCashReconcilationDate.ReadOnly = True
        Me.dgPRCashReconcilationDate.Width = 170
        '
        'dgPRReceiptDescp
        '
        Me.dgPRReceiptDescp.DataPropertyName = "ReceiptDescp"
        Me.dgPRReceiptDescp.HeaderText = "Receipt Descp"
        Me.dgPRReceiptDescp.Name = "dgPRReceiptDescp"
        Me.dgPRReceiptDescp.ReadOnly = True
        Me.dgPRReceiptDescp.Width = 112
        '
        'dgPRAmount
        '
        Me.dgPRAmount.DataPropertyName = "Amount"
        Me.dgPRAmount.HeaderText = "Amount"
        Me.dgPRAmount.Name = "dgPRAmount"
        Me.dgPRAmount.ReadOnly = True
        Me.dgPRAmount.Width = 75
        '
        'dgPRStatus
        '
        DataGridViewCellStyle18.NullValue = "OPEN"
        Me.dgPRStatus.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgPRStatus.HeaderText = "Status"
        Me.dgPRStatus.Name = "dgPRStatus"
        Me.dgPRStatus.ReadOnly = True
        Me.dgPRStatus.Width = 67
        '
        'dgPRViewDetails
        '
        Me.dgPRViewDetails.DataPropertyName = "ViewDetails"
        Me.dgPRViewDetails.HeaderText = "View Details"
        Me.dgPRViewDetails.Name = "dgPRViewDetails"
        Me.dgPRViewDetails.ReadOnly = True
        Me.dgPRViewDetails.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPRViewDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgPRViewDetails.Text = "View Details"
        Me.dgPRViewDetails.UseColumnTextForButtonValue = True
        Me.dgPRViewDetails.Width = 101
        '
        'DgPRT0PC
        '
        Me.DgPRT0PC.DataPropertyName = "T0PC"
        Me.DgPRT0PC.HeaderText = "T0PC"
        Me.DgPRT0PC.Name = "DgPRT0PC"
        Me.DgPRT0PC.ReadOnly = True
        Me.DgPRT0PC.Visible = False
        Me.DgPRT0PC.Width = 61
        '
        'dgPRT1PC
        '
        Me.dgPRT1PC.DataPropertyName = "T1PC"
        Me.dgPRT1PC.HeaderText = "T1PC"
        Me.dgPRT1PC.Name = "dgPRT1PC"
        Me.dgPRT1PC.ReadOnly = True
        Me.dgPRT1PC.Visible = False
        Me.dgPRT1PC.Width = 61
        '
        'DgPRT2PC
        '
        Me.DgPRT2PC.DataPropertyName = "T2PC"
        Me.DgPRT2PC.HeaderText = "T2PC"
        Me.DgPRT2PC.Name = "DgPRT2PC"
        Me.DgPRT2PC.ReadOnly = True
        Me.DgPRT2PC.Visible = False
        Me.DgPRT2PC.Width = 61
        '
        'DgPRT3PC
        '
        Me.DgPRT3PC.DataPropertyName = "T3PC"
        Me.DgPRT3PC.HeaderText = "T3PC"
        Me.DgPRT3PC.Name = "DgPRT3PC"
        Me.DgPRT3PC.ReadOnly = True
        Me.DgPRT3PC.Visible = False
        Me.DgPRT3PC.Width = 61
        '
        'dgT4PC
        '
        Me.dgT4PC.DataPropertyName = "T4PC"
        Me.dgT4PC.HeaderText = "T4PC"
        Me.dgT4PC.Name = "dgT4PC"
        Me.dgT4PC.ReadOnly = True
        Me.dgT4PC.Visible = False
        Me.dgT4PC.Width = 61
        '
        'dgPRT0SAM
        '
        Me.dgPRT0SAM.DataPropertyName = "T0SAM"
        Me.dgPRT0SAM.HeaderText = "T0SAM"
        Me.dgPRT0SAM.Name = "dgPRT0SAM"
        Me.dgPRT0SAM.ReadOnly = True
        Me.dgPRT0SAM.Visible = False
        Me.dgPRT0SAM.Width = 70
        '
        'dgPRT1SAM
        '
        Me.dgPRT1SAM.DataPropertyName = "T1SAM"
        Me.dgPRT1SAM.HeaderText = "T1SAM"
        Me.dgPRT1SAM.Name = "dgPRT1SAM"
        Me.dgPRT1SAM.ReadOnly = True
        Me.dgPRT1SAM.Visible = False
        Me.dgPRT1SAM.Width = 70
        '
        'dgPRT2SAM
        '
        Me.dgPRT2SAM.DataPropertyName = "T2SAM"
        Me.dgPRT2SAM.HeaderText = "T2SAM"
        Me.dgPRT2SAM.Name = "dgPRT2SAM"
        Me.dgPRT2SAM.ReadOnly = True
        Me.dgPRT2SAM.Visible = False
        Me.dgPRT2SAM.Width = 70
        '
        'dgPRT3SAM
        '
        Me.dgPRT3SAM.DataPropertyName = "T3SAM"
        Me.dgPRT3SAM.HeaderText = "T3SAM"
        Me.dgPRT3SAM.Name = "dgPRT3SAM"
        Me.dgPRT3SAM.ReadOnly = True
        Me.dgPRT3SAM.Visible = False
        Me.dgPRT3SAM.Width = 70
        '
        'dgPRT4SAM
        '
        Me.dgPRT4SAM.DataPropertyName = "T4SAM"
        Me.dgPRT4SAM.HeaderText = "T4SAM"
        Me.dgPRT4SAM.Name = "dgPRT4SAM"
        Me.dgPRT4SAM.ReadOnly = True
        Me.dgPRT4SAM.Visible = False
        Me.dgPRT4SAM.Width = 70
        '
        'dgvMultipleEntry
        '
        Me.dgvMultipleEntry.AllowUserToAddRows = False
        Me.dgvMultipleEntry.AllowUserToDeleteRows = False
        Me.dgvMultipleEntry.AllowUserToResizeRows = False
        Me.dgvMultipleEntry.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvMultipleEntry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMultipleEntry.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMultipleEntry.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvMultipleEntry.ColumnHeadersHeight = 30
        Me.dgvMultipleEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgMeAccJournalID, Me.DgMeTransactiontype, Me.DgMeRemarks, Me.DgMeCOACode, Me.dgMeOldCOACode, Me.dgMeAmount, Me.DgMeCOADescp, Me.dgMeDescription, Me.dgMeDebit, Me.dgMeCredit, Me.DgMeDivID, Me.DgMeYOPID, Me.DgMeBlockID, Me.DgMeVHID, Me.dgMeVHDetailCostCodeID, Me.dgmeVHType, Me.DgMeDiv, Me.dgMeYOP, Me.DgMeSubBlock, Me.DgMeStationCode, Me.dgMeVHWSCode, Me.dgMeVHDetailCostCode, Me.DgMeStationID, Me.dgMeTAnalysisCode0, Me.dgMeTAnalysisCode1, Me.dgMeTAnalysisCode2, Me.dgMeTAnalysisCode3, Me.dgMeTAnalysisCode4, Me.dgMeCOAID, Me.dgMeT0, Me.dgMeT1, Me.dgMeT2, Me.dgMeT3, Me.dgMeT4, Me.dgMeTAnalysisDescp0, Me.dgMeDivName, Me.dgMeYOPName, Me.dgMeBlockStatus, Me.dgMeStationDescp, Me.dgVHDetailCostDescp, Me.DgmeVehicleDescp, Me.dgMeTAnalysisDescp1, Me.dgMeTAnalysisDescp2, Me.dgMeTAnalysisDescp3, Me.dgMeTAnalysisDescp4})
        Me.dgvMultipleEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMultipleEntry.EnableHeadersVisualStyles = False
        Me.dgvMultipleEntry.GridColor = System.Drawing.Color.Gray
        Me.dgvMultipleEntry.Location = New System.Drawing.Point(0, 224)
        Me.dgvMultipleEntry.MultiSelect = False
        Me.dgvMultipleEntry.Name = "dgvMultipleEntry"
        Me.dgvMultipleEntry.ReadOnly = True
        Me.dgvMultipleEntry.RowHeadersVisible = False
        Me.dgvMultipleEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMultipleEntry.Size = New System.Drawing.Size(856, 262)
        Me.dgvMultipleEntry.TabIndex = 152
        Me.dgvMultipleEntry.Visible = False
        '
        'dgMeAccJournalID
        '
        Me.dgMeAccJournalID.DataPropertyName = "AccJournalID"
        Me.dgMeAccJournalID.HeaderText = "AccJournalID"
        Me.dgMeAccJournalID.Name = "dgMeAccJournalID"
        Me.dgMeAccJournalID.ReadOnly = True
        Me.dgMeAccJournalID.Visible = False
        '
        'DgMeTransactiontype
        '
        Me.DgMeTransactiontype.DataPropertyName = "Transactiontype"
        Me.DgMeTransactiontype.HeaderText = "Transaction Type"
        Me.DgMeTransactiontype.Name = "DgMeTransactiontype"
        Me.DgMeTransactiontype.ReadOnly = True
        '
        'DgMeRemarks
        '
        Me.DgMeRemarks.DataPropertyName = "Remarks"
        Me.DgMeRemarks.HeaderText = "PCPDescription"
        Me.DgMeRemarks.Name = "DgMeRemarks"
        Me.DgMeRemarks.ReadOnly = True
        Me.DgMeRemarks.Visible = False
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
        'dgMeAmount
        '
        Me.dgMeAmount.DataPropertyName = "Amount"
        Me.dgMeAmount.HeaderText = "Amount"
        Me.dgMeAmount.Name = "dgMeAmount"
        Me.dgMeAmount.ReadOnly = True
        Me.dgMeAmount.Visible = False
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
        Me.dgMeDescription.Visible = False
        '
        'dgMeDebit
        '
        Me.dgMeDebit.DataPropertyName = "Debit"
        DataGridViewCellStyle22.Format = "N0"
        DataGridViewCellStyle22.NullValue = Nothing
        Me.dgMeDebit.DefaultCellStyle = DataGridViewCellStyle22
        Me.dgMeDebit.HeaderText = "Debit"
        Me.dgMeDebit.Name = "dgMeDebit"
        Me.dgMeDebit.ReadOnly = True
        Me.dgMeDebit.Width = 140
        '
        'dgMeCredit
        '
        Me.dgMeCredit.DataPropertyName = "Credit"
        DataGridViewCellStyle23.Format = "N0"
        DataGridViewCellStyle23.NullValue = Nothing
        Me.dgMeCredit.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgMeCredit.HeaderText = "Credit"
        Me.dgMeCredit.Name = "dgMeCredit"
        Me.dgMeCredit.ReadOnly = True
        Me.dgMeCredit.Width = 140
        '
        'DgMeDivID
        '
        Me.DgMeDivID.DataPropertyName = "DivID"
        Me.DgMeDivID.HeaderText = "AfdelingID"
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
        Me.dgMeDivName.HeaderText = "Afdeling Name"
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
        'AccountApprovalFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(856, 486)
        Me.Controls.Add(Me.dgvMultipleEntry)
        Me.Controls.Add(Me.dgPettyCashReciept)
        Me.Controls.Add(Me.dgvPettyCashPayment)
        Me.Controls.Add(Me.dgvJournalApproval)
        Me.Controls.Add(Me.plAccountsApproval)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "AccountApprovalFrm"
        Me.Text = "AccountApprovalFrm"
        CType(Me.dgvJournalApproval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.plAccountsApproval.ResumeLayout(False)
        Me.plAccountsApproval.PerformLayout()
        CType(Me.dgvPettyCashPayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPettyCashReciept, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMultipleEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvJournalApproval As System.Windows.Forms.DataGridView
    Friend WithEvents lblSelectTransaction As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnLedgerNoSearch As System.Windows.Forms.Button
    Friend WithEvents ddlTransaction As System.Windows.Forms.ComboBox
    Friend WithEvents lblledgerType As System.Windows.Forms.Label
    Friend WithEvents lblledgerNo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents plAccountsApproval As Stepi.UI.ExtendedPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ddlLedgerType As System.Windows.Forms.ComboBox
    Friend WithEvents btnResetIB As System.Windows.Forms.Button
    Friend WithEvents txtLedgerNo As System.Windows.Forms.TextBox
    Friend WithEvents dgvPettyCashPayment As System.Windows.Forms.DataGridView
    Friend WithEvents dgPettyCashReciept As System.Windows.Forms.DataGridView
    Friend WithEvents cbAllRecordsTransaction As System.Windows.Forms.CheckBox
    Friend WithEvents btnApproval As System.Windows.Forms.Button
    Friend WithEvents dgvMultipleEntry As System.Windows.Forms.DataGridView
    Friend WithEvents cbLedgerType As System.Windows.Forms.CheckBox
    Friend WithEvents btnClos As System.Windows.Forms.Button
    Friend WithEvents dgPVoucherDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPVoucherNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPPayTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPPayDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgPViewDetails As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents dgPRReceiptDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dbPRReceiptID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRCashReconcilationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRReceiptDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRViewDetails As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DgPRT0PC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRT1PC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgPRT2PC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgPRT3PC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgT4PC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRT0SAM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRT1SAM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRT2SAM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRT3SAM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRT4SAM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAccBatchID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLedgerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLedgerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgVStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBatchTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclViewDetails As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents dgMeAccJournalID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeTransactiontype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgMeCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeOldCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeAmount As System.Windows.Forms.DataGridViewTextBoxColumn
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
End Class

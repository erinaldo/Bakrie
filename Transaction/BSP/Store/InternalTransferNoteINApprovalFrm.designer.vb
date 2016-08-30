<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InternalTransferNoteINApprovalFrm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InternalTransferNoteINApprovalFrm))
        Me.plITNInApproval = New System.Windows.Forms.Panel()
        Me.lblNoRecord = New System.Windows.Forms.Label()
        Me.dgvITNInApproval = New System.Windows.Forms.DataGridView()
        Me.dgclSTITNInID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclITNDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclITNInNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSupplierCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSendersLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDistributionSetupID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclModifiedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclViewDetails = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgclT0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcOperatorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTransportDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcVehicleNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcMRCNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plITNInApprovalSearch = New Stepi.UI.ExtendedPanel()
        Me.lblsearchBy = New System.Windows.Forms.Label()
        Me.chkITNDate = New System.Windows.Forms.CheckBox()
        Me.lblviewITNDate = New System.Windows.Forms.Label()
        Me.btnviewReport = New System.Windows.Forms.Button()
        Me.dtpviewITNDate = New System.Windows.Forms.DateTimePicker()
        Me.lblviewITNIntNo = New System.Windows.Forms.Label()
        Me.btnviewSendLoc = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtviewSendLoc = New System.Windows.Forms.TextBox()
        Me.txtviewITNInNo = New System.Windows.Forms.TextBox()
        Me.lblviewSendersLoc = New System.Windows.Forms.Label()
        Me.plITNInApproval.SuspendLayout()
        CType(Me.dgvITNInApproval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.plITNInApprovalSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'plITNInApproval
        '
        Me.plITNInApproval.BackColor = System.Drawing.Color.Transparent
        Me.plITNInApproval.Controls.Add(Me.lblNoRecord)
        Me.plITNInApproval.Controls.Add(Me.dgvITNInApproval)
        Me.plITNInApproval.Controls.Add(Me.plITNInApprovalSearch)
        Me.plITNInApproval.Location = New System.Drawing.Point(1, 1)
        Me.plITNInApproval.Name = "plITNInApproval"
        Me.plITNInApproval.Size = New System.Drawing.Size(980, 551)
        Me.plITNInApproval.TabIndex = 1
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(205, 325)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 113
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'dgvITNInApproval
        '
        Me.dgvITNInApproval.AllowUserToAddRows = False
        Me.dgvITNInApproval.AllowUserToDeleteRows = False
        Me.dgvITNInApproval.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvITNInApproval.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvITNInApproval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvITNInApproval.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvITNInApproval.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvITNInApproval.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvITNInApproval.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvITNInApproval.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvITNInApproval.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclSTITNInID, Me.dgclITNDate, Me.dgclITNInNo, Me.dgclSupplierCOAID, Me.dgclSendersLocation, Me.dgclDistributionSetupID, Me.dgclStatus, Me.dgclModifiedOn, Me.dgclRemarks, Me.dgclViewDetails, Me.dgclT0, Me.dgclT1, Me.dgclT2, Me.dgclT3, Me.dgclT4, Me.dgcOperatorName, Me.dgcTransportDate, Me.dgcVehicleNo, Me.dgcMRCNo})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvITNInApproval.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvITNInApproval.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvITNInApproval.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvITNInApproval.EnableHeadersVisualStyles = False
        Me.dgvITNInApproval.GridColor = System.Drawing.Color.Gray
        Me.dgvITNInApproval.Location = New System.Drawing.Point(0, 188)
        Me.dgvITNInApproval.Name = "dgvITNInApproval"
        Me.dgvITNInApproval.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvITNInApproval.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvITNInApproval.RowHeadersVisible = False
        Me.dgvITNInApproval.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvITNInApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvITNInApproval.ShowCellErrors = False
        Me.dgvITNInApproval.Size = New System.Drawing.Size(980, 363)
        Me.dgvITNInApproval.TabIndex = 148
        Me.dgvITNInApproval.TabStop = False
        '
        'dgclSTITNInID
        '
        Me.dgclSTITNInID.DataPropertyName = "STInternalTransferInID"
        Me.dgclSTITNInID.HeaderText = "STITNInID"
        Me.dgclSTITNInID.Name = "dgclSTITNInID"
        Me.dgclSTITNInID.ReadOnly = True
        Me.dgclSTITNInID.Visible = False
        Me.dgclSTITNInID.Width = 92
        '
        'dgclITNDate
        '
        Me.dgclITNDate.DataPropertyName = "ITNDate"
        Me.dgclITNDate.HeaderText = "TN IN Date"
        Me.dgclITNDate.Name = "dgclITNDate"
        Me.dgclITNDate.ReadOnly = True
        Me.dgclITNDate.Width = 99
        '
        'dgclITNInNo
        '
        Me.dgclITNInNo.DataPropertyName = "ItnInNo"
        Me.dgclITNInNo.HeaderText = "TN IN No."
        Me.dgclITNInNo.Name = "dgclITNInNo"
        Me.dgclITNInNo.ReadOnly = True
        Me.dgclITNInNo.Width = 91
        '
        'dgclSupplierCOAID
        '
        Me.dgclSupplierCOAID.DataPropertyName = "SupplierCOAID"
        Me.dgclSupplierCOAID.HeaderText = "SupplierCOAID"
        Me.dgclSupplierCOAID.Name = "dgclSupplierCOAID"
        Me.dgclSupplierCOAID.ReadOnly = True
        Me.dgclSupplierCOAID.Visible = False
        Me.dgclSupplierCOAID.Width = 118
        '
        'dgclSendersLocation
        '
        Me.dgclSendersLocation.DataPropertyName = "SendersLocation"
        Me.dgclSendersLocation.HeaderText = "Senders Location"
        Me.dgclSendersLocation.Name = "dgclSendersLocation"
        Me.dgclSendersLocation.ReadOnly = True
        Me.dgclSendersLocation.Width = 129
        '
        'dgclDistributionSetupID
        '
        Me.dgclDistributionSetupID.DataPropertyName = "DistributionSetupID"
        Me.dgclDistributionSetupID.HeaderText = "DistributionSetupID"
        Me.dgclDistributionSetupID.Name = "dgclDistributionSetupID"
        Me.dgclDistributionSetupID.ReadOnly = True
        Me.dgclDistributionSetupID.Visible = False
        Me.dgclDistributionSetupID.Width = 143
        '
        'dgclStatus
        '
        Me.dgclStatus.DataPropertyName = "Status"
        Me.dgclStatus.HeaderText = "Status"
        Me.dgclStatus.Name = "dgclStatus"
        Me.dgclStatus.ReadOnly = True
        Me.dgclStatus.Width = 67
        '
        'dgclModifiedOn
        '
        Me.dgclModifiedOn.DataPropertyName = "ModifiedOn"
        Me.dgclModifiedOn.HeaderText = "Modified On"
        Me.dgclModifiedOn.Name = "dgclModifiedOn"
        Me.dgclModifiedOn.ReadOnly = True
        Me.dgclModifiedOn.Visible = False
        Me.dgclModifiedOn.Width = 98
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
        'dgclViewDetails
        '
        Me.dgclViewDetails.HeaderText = "View Details"
        Me.dgclViewDetails.Name = "dgclViewDetails"
        Me.dgclViewDetails.ReadOnly = True
        Me.dgclViewDetails.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgclViewDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgclViewDetails.Text = "View Details"
        Me.dgclViewDetails.UseColumnTextForButtonValue = True
        Me.dgclViewDetails.Width = 101
        '
        'dgclT0
        '
        Me.dgclT0.DataPropertyName = "T0"
        Me.dgclT0.HeaderText = "T0"
        Me.dgclT0.Name = "dgclT0"
        Me.dgclT0.ReadOnly = True
        Me.dgclT0.Visible = False
        Me.dgclT0.Width = 45
        '
        'dgclT1
        '
        Me.dgclT1.DataPropertyName = "T1"
        Me.dgclT1.HeaderText = "T1"
        Me.dgclT1.Name = "dgclT1"
        Me.dgclT1.ReadOnly = True
        Me.dgclT1.Visible = False
        Me.dgclT1.Width = 45
        '
        'dgclT2
        '
        Me.dgclT2.DataPropertyName = "T2"
        Me.dgclT2.HeaderText = "T2"
        Me.dgclT2.Name = "dgclT2"
        Me.dgclT2.ReadOnly = True
        Me.dgclT2.Visible = False
        Me.dgclT2.Width = 45
        '
        'dgclT3
        '
        Me.dgclT3.DataPropertyName = "T3"
        Me.dgclT3.HeaderText = "T3"
        Me.dgclT3.Name = "dgclT3"
        Me.dgclT3.ReadOnly = True
        Me.dgclT3.Visible = False
        Me.dgclT3.Width = 45
        '
        'dgclT4
        '
        Me.dgclT4.DataPropertyName = "T4"
        Me.dgclT4.HeaderText = "T4"
        Me.dgclT4.Name = "dgclT4"
        Me.dgclT4.ReadOnly = True
        Me.dgclT4.Visible = False
        Me.dgclT4.Width = 45
        '
        'dgcOperatorName
        '
        Me.dgcOperatorName.DataPropertyName = "OperatorName"
        Me.dgcOperatorName.HeaderText = "OperatorName"
        Me.dgcOperatorName.Name = "dgcOperatorName"
        Me.dgcOperatorName.ReadOnly = True
        Me.dgcOperatorName.Visible = False
        Me.dgcOperatorName.Width = 115
        '
        'dgcTransportDate
        '
        Me.dgcTransportDate.DataPropertyName = "TransportDate"
        Me.dgcTransportDate.HeaderText = "TransportDate"
        Me.dgcTransportDate.Name = "dgcTransportDate"
        Me.dgcTransportDate.ReadOnly = True
        Me.dgcTransportDate.Visible = False
        Me.dgcTransportDate.Width = 113
        '
        'dgcVehicleNo
        '
        Me.dgcVehicleNo.DataPropertyName = "VehicleNo"
        Me.dgcVehicleNo.HeaderText = "VehicleNo"
        Me.dgcVehicleNo.Name = "dgcVehicleNo"
        Me.dgcVehicleNo.ReadOnly = True
        Me.dgcVehicleNo.Visible = False
        Me.dgcVehicleNo.Width = 87
        '
        'dgcMRCNo
        '
        Me.dgcMRCNo.DataPropertyName = "MRCNo"
        Me.dgcMRCNo.HeaderText = "MRCNo"
        Me.dgcMRCNo.Name = "dgcMRCNo"
        Me.dgcMRCNo.ReadOnly = True
        Me.dgcMRCNo.Visible = False
        Me.dgcMRCNo.Width = 72
        '
        'plITNInApprovalSearch
        '
        Me.plITNInApprovalSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plITNInApprovalSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plITNInApprovalSearch.BorderColor = System.Drawing.Color.Gray
        Me.plITNInApprovalSearch.CaptionColorOne = System.Drawing.Color.White
        Me.plITNInApprovalSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plITNInApprovalSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plITNInApprovalSearch.CaptionSize = 40
        Me.plITNInApprovalSearch.CaptionText = "Transfer Note IN Approval"
        Me.plITNInApprovalSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.plITNInApprovalSearch.Controls.Add(Me.lblsearchBy)
        Me.plITNInApprovalSearch.Controls.Add(Me.chkITNDate)
        Me.plITNInApprovalSearch.Controls.Add(Me.lblviewITNDate)
        Me.plITNInApprovalSearch.Controls.Add(Me.btnviewReport)
        Me.plITNInApprovalSearch.Controls.Add(Me.dtpviewITNDate)
        Me.plITNInApprovalSearch.Controls.Add(Me.lblviewITNIntNo)
        Me.plITNInApprovalSearch.Controls.Add(Me.btnviewSendLoc)
        Me.plITNInApprovalSearch.Controls.Add(Me.btnSearch)
        Me.plITNInApprovalSearch.Controls.Add(Me.txtviewSendLoc)
        Me.plITNInApprovalSearch.Controls.Add(Me.txtviewITNInNo)
        Me.plITNInApprovalSearch.Controls.Add(Me.lblviewSendersLoc)
        Me.plITNInApprovalSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plITNInApprovalSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plITNInApprovalSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plITNInApprovalSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.plITNInApprovalSearch.ForeColor = System.Drawing.Color.Black
        Me.plITNInApprovalSearch.Location = New System.Drawing.Point(0, 0)
        Me.plITNInApprovalSearch.Name = "plITNInApprovalSearch"
        Me.plITNInApprovalSearch.Size = New System.Drawing.Size(980, 188)
        Me.plITNInApprovalSearch.TabIndex = 147
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
        'chkITNDate
        '
        Me.chkITNDate.AutoSize = True
        Me.chkITNDate.Location = New System.Drawing.Point(94, 65)
        Me.chkITNDate.Name = "chkITNDate"
        Me.chkITNDate.Size = New System.Drawing.Size(15, 14)
        Me.chkITNDate.TabIndex = 0
        Me.chkITNDate.UseVisualStyleBackColor = True
        '
        'lblviewITNDate
        '
        Me.lblviewITNDate.AutoSize = True
        Me.lblviewITNDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewITNDate.ForeColor = System.Drawing.Color.Black
        Me.lblviewITNDate.Location = New System.Drawing.Point(115, 65)
        Me.lblviewITNDate.Name = "lblviewITNDate"
        Me.lblviewITNDate.Size = New System.Drawing.Size(75, 13)
        Me.lblviewITNDate.TabIndex = 16
        Me.lblviewITNDate.Text = "TN IN Date"
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(803, 146)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(121, 25)
        Me.btnviewReport.TabIndex = 6
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        Me.btnviewReport.Visible = False
        '
        'dtpviewITNDate
        '
        Me.dtpviewITNDate.Enabled = False
        Me.dtpviewITNDate.Location = New System.Drawing.Point(67, 96)
        Me.dtpviewITNDate.Name = "dtpviewITNDate"
        Me.dtpviewITNDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpviewITNDate.TabIndex = 1
        '
        'lblviewITNIntNo
        '
        Me.lblviewITNIntNo.AutoSize = True
        Me.lblviewITNIntNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewITNIntNo.ForeColor = System.Drawing.Color.Black
        Me.lblviewITNIntNo.Location = New System.Drawing.Point(326, 65)
        Me.lblviewITNIntNo.Name = "lblviewITNIntNo"
        Me.lblviewITNIntNo.Size = New System.Drawing.Size(67, 13)
        Me.lblviewITNIntNo.TabIndex = 17
        Me.lblviewITNIntNo.Text = "TN IN No."
        '
        'btnviewSendLoc
        '
        Me.btnviewSendLoc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnviewSendLoc.FlatAppearance.BorderSize = 0
        Me.btnviewSendLoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnviewSendLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnviewSendLoc.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnviewSendLoc.Image = CType(resources.GetObject("btnviewSendLoc.Image"), System.Drawing.Image)
        Me.btnviewSendLoc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnviewSendLoc.Location = New System.Drawing.Point(655, 88)
        Me.btnviewSendLoc.Name = "btnviewSendLoc"
        Me.btnviewSendLoc.Size = New System.Drawing.Size(30, 33)
        Me.btnviewSendLoc.TabIndex = 4
        Me.btnviewSendLoc.TabStop = False
        Me.btnviewSendLoc.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(680, 146)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtviewSendLoc
        '
        Me.txtviewSendLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewSendLoc.Location = New System.Drawing.Point(484, 96)
        Me.txtviewSendLoc.MaxLength = 50
        Me.txtviewSendLoc.Name = "txtviewSendLoc"
        Me.txtviewSendLoc.Size = New System.Drawing.Size(165, 20)
        Me.txtviewSendLoc.TabIndex = 3
        '
        'txtviewITNInNo
        '
        Me.txtviewITNInNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewITNInNo.Location = New System.Drawing.Point(277, 96)
        Me.txtviewITNInNo.MaxLength = 50
        Me.txtviewITNInNo.Name = "txtviewITNInNo"
        Me.txtviewITNInNo.Size = New System.Drawing.Size(165, 20)
        Me.txtviewITNInNo.TabIndex = 2
        '
        'lblviewSendersLoc
        '
        Me.lblviewSendersLoc.AutoSize = True
        Me.lblviewSendersLoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewSendersLoc.ForeColor = System.Drawing.Color.Black
        Me.lblviewSendersLoc.Location = New System.Drawing.Point(520, 65)
        Me.lblviewSendersLoc.Name = "lblviewSendersLoc"
        Me.lblviewSendersLoc.Size = New System.Drawing.Size(105, 13)
        Me.lblviewSendersLoc.TabIndex = 18
        Me.lblviewSendersLoc.Text = "Senders Location"
        '
        'InternalTransferNoteINApprovalFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 555)
        Me.Controls.Add(Me.plITNInApproval)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "InternalTransferNoteINApprovalFrm"
        Me.Text = "InternalTransferNoteINApprovalFrm"
        Me.plITNInApproval.ResumeLayout(False)
        Me.plITNInApproval.PerformLayout()
        CType(Me.dgvITNInApproval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.plITNInApprovalSearch.ResumeLayout(False)
        Me.plITNInApprovalSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plITNInApproval As System.Windows.Forms.Panel
    Friend WithEvents plITNInApprovalSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents chkITNDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblviewITNDate As System.Windows.Forms.Label
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents dtpviewITNDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewITNIntNo As System.Windows.Forms.Label
    Friend WithEvents btnviewSendLoc As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtviewSendLoc As System.Windows.Forms.TextBox
    Friend WithEvents txtviewITNInNo As System.Windows.Forms.TextBox
    Friend WithEvents lblviewSendersLoc As System.Windows.Forms.Label
    Friend WithEvents dgvITNInApproval As System.Windows.Forms.DataGridView
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents dgclSTITNInID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclITNDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclITNInNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSendersLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDistributionSetupID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclModifiedOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclViewDetails As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents dgclT0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcOperatorName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcTransportDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcVehicleNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcMRCNo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InternalTransferNoteOUTApprovalFrm
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InternalTransferNoteOUTApprovalFrm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblNoRecord = New System.Windows.Forms.Label()
        Me.dgvITNOutApproval = New System.Windows.Forms.DataGridView()
        Me.plITNOutApproval = New Stepi.UI.ExtendedPanel()
        Me.lblsearchby = New System.Windows.Forms.Label()
        Me.chkITNOutdate = New System.Windows.Forms.CheckBox()
        Me.lblviewITNDate = New System.Windows.Forms.Label()
        Me.dtpviewITNDate = New System.Windows.Forms.DateTimePicker()
        Me.btnviewReport = New System.Windows.Forms.Button()
        Me.btnviewRecLoc = New System.Windows.Forms.Button()
        Me.txtviewRecLoc = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblviewITNOutNo = New System.Windows.Forms.Label()
        Me.lblviewReceivedLoc = New System.Windows.Forms.Label()
        Me.txtviewITNOutNo = New System.Windows.Forms.TextBox()
        Me.dgclITNOutDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclITNOutNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclReceivedLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclViewDetails = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgclSTITNOutID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSupplierCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSupplierID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcOperatorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcTransportDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcVehicleNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcMRCNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvITNOutApproval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.plITNOutApproval.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.lblNoRecord)
        Me.Panel1.Controls.Add(Me.dgvITNOutApproval)
        Me.Panel1.Controls.Add(Me.plITNOutApproval)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(983, 557)
        Me.Panel1.TabIndex = 0
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(243, 333)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 148
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'dgvITNOutApproval
        '
        Me.dgvITNOutApproval.AllowUserToAddRows = False
        Me.dgvITNOutApproval.AllowUserToDeleteRows = False
        Me.dgvITNOutApproval.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.dgvITNOutApproval.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvITNOutApproval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvITNOutApproval.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvITNOutApproval.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvITNOutApproval.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvITNOutApproval.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvITNOutApproval.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvITNOutApproval.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclITNOutDate, Me.dgclITNOutNo, Me.dgclStatus, Me.dgclRemarks, Me.dgclReceivedLocation, Me.dgclViewDetails, Me.dgclSTITNOutID, Me.dgclSupplierCOAID, Me.dgclSupplierID, Me.dgclT0, Me.dgclT1, Me.dgclT2, Me.dgclT3, Me.dgclT4, Me.dgcOperatorName, Me.dgcTransportDate, Me.dgcVehicleNo, Me.dgcMRCNo})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvITNOutApproval.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvITNOutApproval.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvITNOutApproval.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvITNOutApproval.EnableHeadersVisualStyles = False
        Me.dgvITNOutApproval.GridColor = System.Drawing.Color.Gray
        Me.dgvITNOutApproval.Location = New System.Drawing.Point(0, 177)
        Me.dgvITNOutApproval.Name = "dgvITNOutApproval"
        Me.dgvITNOutApproval.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvITNOutApproval.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvITNOutApproval.RowHeadersVisible = False
        Me.dgvITNOutApproval.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvITNOutApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvITNOutApproval.ShowCellErrors = False
        Me.dgvITNOutApproval.Size = New System.Drawing.Size(983, 380)
        Me.dgvITNOutApproval.TabIndex = 8
        Me.dgvITNOutApproval.TabStop = False
        '
        'plITNOutApproval
        '
        Me.plITNOutApproval.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plITNOutApproval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plITNOutApproval.BorderColor = System.Drawing.Color.Gray
        Me.plITNOutApproval.CaptionColorOne = System.Drawing.Color.White
        Me.plITNOutApproval.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plITNOutApproval.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plITNOutApproval.CaptionSize = 40
        Me.plITNOutApproval.CaptionText = "Transfer Out Approval"
        Me.plITNOutApproval.CaptionTextColor = System.Drawing.Color.Black
        Me.plITNOutApproval.Controls.Add(Me.lblsearchby)
        Me.plITNOutApproval.Controls.Add(Me.chkITNOutdate)
        Me.plITNOutApproval.Controls.Add(Me.lblviewITNDate)
        Me.plITNOutApproval.Controls.Add(Me.dtpviewITNDate)
        Me.plITNOutApproval.Controls.Add(Me.btnviewReport)
        Me.plITNOutApproval.Controls.Add(Me.btnviewRecLoc)
        Me.plITNOutApproval.Controls.Add(Me.txtviewRecLoc)
        Me.plITNOutApproval.Controls.Add(Me.btnSearch)
        Me.plITNOutApproval.Controls.Add(Me.lblviewITNOutNo)
        Me.plITNOutApproval.Controls.Add(Me.lblviewReceivedLoc)
        Me.plITNOutApproval.Controls.Add(Me.txtviewITNOutNo)
        Me.plITNOutApproval.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plITNOutApproval.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plITNOutApproval.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plITNOutApproval.Dock = System.Windows.Forms.DockStyle.Top
        Me.plITNOutApproval.ForeColor = System.Drawing.Color.Black
        Me.plITNOutApproval.Location = New System.Drawing.Point(0, 0)
        Me.plITNOutApproval.Name = "plITNOutApproval"
        Me.plITNOutApproval.Size = New System.Drawing.Size(983, 177)
        Me.plITNOutApproval.TabIndex = 147
        '
        'lblsearchby
        '
        Me.lblsearchby.AutoSize = True
        Me.lblsearchby.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchby.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchby.ForeColor = System.Drawing.Color.Black
        Me.lblsearchby.Location = New System.Drawing.Point(1, 41)
        Me.lblsearchby.Name = "lblsearchby"
        Me.lblsearchby.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchby.TabIndex = 54
        Me.lblsearchby.Text = "Search By"
        '
        'chkITNOutdate
        '
        Me.chkITNOutdate.AutoSize = True
        Me.chkITNOutdate.Location = New System.Drawing.Point(86, 64)
        Me.chkITNOutdate.Name = "chkITNOutdate"
        Me.chkITNOutdate.Size = New System.Drawing.Size(15, 14)
        Me.chkITNOutdate.TabIndex = 1
        Me.chkITNOutdate.UseVisualStyleBackColor = True
        '
        'lblviewITNDate
        '
        Me.lblviewITNDate.AutoSize = True
        Me.lblviewITNDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewITNDate.ForeColor = System.Drawing.Color.Black
        Me.lblviewITNDate.Location = New System.Drawing.Point(102, 64)
        Me.lblviewITNDate.Name = "lblviewITNDate"
        Me.lblviewITNDate.Size = New System.Drawing.Size(86, 13)
        Me.lblviewITNDate.TabIndex = 16
        Me.lblviewITNDate.Text = "ITN OUT Date"
        '
        'dtpviewITNDate
        '
        Me.dtpviewITNDate.Enabled = False
        Me.dtpviewITNDate.Location = New System.Drawing.Point(50, 95)
        Me.dtpviewITNDate.Name = "dtpviewITNDate"
        Me.dtpviewITNDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpviewITNDate.TabIndex = 2
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(756, 144)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(128, 25)
        Me.btnviewReport.TabIndex = 7
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        Me.btnviewReport.Visible = False
        '
        'btnviewRecLoc
        '
        Me.btnviewRecLoc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnviewRecLoc.FlatAppearance.BorderSize = 0
        Me.btnviewRecLoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnviewRecLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnviewRecLoc.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnviewRecLoc.Image = CType(resources.GetObject("btnviewRecLoc.Image"), System.Drawing.Image)
        Me.btnviewRecLoc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnviewRecLoc.Location = New System.Drawing.Point(647, 83)
        Me.btnviewRecLoc.Name = "btnviewRecLoc"
        Me.btnviewRecLoc.Size = New System.Drawing.Size(30, 33)
        Me.btnviewRecLoc.TabIndex = 5
        Me.btnviewRecLoc.TabStop = False
        Me.btnviewRecLoc.UseVisualStyleBackColor = True
        '
        'txtviewRecLoc
        '
        Me.txtviewRecLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewRecLoc.Location = New System.Drawing.Point(476, 95)
        Me.txtviewRecLoc.MaxLength = 50
        Me.txtviewRecLoc.Name = "txtviewRecLoc"
        Me.txtviewRecLoc.Size = New System.Drawing.Size(165, 20)
        Me.txtviewRecLoc.TabIndex = 4
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(633, 144)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblviewITNOutNo
        '
        Me.lblviewITNOutNo.AutoSize = True
        Me.lblviewITNOutNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewITNOutNo.ForeColor = System.Drawing.Color.Black
        Me.lblviewITNOutNo.Location = New System.Drawing.Point(306, 64)
        Me.lblviewITNOutNo.Name = "lblviewITNOutNo"
        Me.lblviewITNOutNo.Size = New System.Drawing.Size(78, 13)
        Me.lblviewITNOutNo.TabIndex = 17
        Me.lblviewITNOutNo.Text = "ITN OUT No."
        '
        'lblviewReceivedLoc
        '
        Me.lblviewReceivedLoc.AutoSize = True
        Me.lblviewReceivedLoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewReceivedLoc.ForeColor = System.Drawing.Color.Black
        Me.lblviewReceivedLoc.Location = New System.Drawing.Point(497, 64)
        Me.lblviewReceivedLoc.Name = "lblviewReceivedLoc"
        Me.lblviewReceivedLoc.Size = New System.Drawing.Size(110, 13)
        Me.lblviewReceivedLoc.TabIndex = 18
        Me.lblviewReceivedLoc.Text = "Received Location"
        '
        'txtviewITNOutNo
        '
        Me.txtviewITNOutNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewITNOutNo.Location = New System.Drawing.Point(263, 95)
        Me.txtviewITNOutNo.MaxLength = 50
        Me.txtviewITNOutNo.Name = "txtviewITNOutNo"
        Me.txtviewITNOutNo.Size = New System.Drawing.Size(165, 20)
        Me.txtviewITNOutNo.TabIndex = 3
        '
        'dgclITNOutDate
        '
        Me.dgclITNOutDate.DataPropertyName = "ITNDate"
        Me.dgclITNOutDate.HeaderText = "TN OUT Date"
        Me.dgclITNOutDate.Name = "dgclITNOutDate"
        Me.dgclITNOutDate.ReadOnly = True
        Me.dgclITNOutDate.Width = 110
        '
        'dgclITNOutNo
        '
        Me.dgclITNOutNo.DataPropertyName = "ItnOutNo"
        Me.dgclITNOutNo.HeaderText = "TN OUT No."
        Me.dgclITNOutNo.Name = "dgclITNOutNo"
        Me.dgclITNOutNo.ReadOnly = True
        Me.dgclITNOutNo.Width = 102
        '
        'dgclStatus
        '
        Me.dgclStatus.DataPropertyName = "Status"
        Me.dgclStatus.HeaderText = "Status"
        Me.dgclStatus.Name = "dgclStatus"
        Me.dgclStatus.ReadOnly = True
        Me.dgclStatus.Width = 67
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
        'dgclReceivedLocation
        '
        Me.dgclReceivedLocation.DataPropertyName = "ReceivedLocation"
        Me.dgclReceivedLocation.HeaderText = "Received Location"
        Me.dgclReceivedLocation.Name = "dgclReceivedLocation"
        Me.dgclReceivedLocation.ReadOnly = True
        Me.dgclReceivedLocation.Width = 134
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
        'dgclSTITNOutID
        '
        Me.dgclSTITNOutID.DataPropertyName = "STInternalTransferoutID"
        Me.dgclSTITNOutID.HeaderText = "STTNOutID"
        Me.dgclSTITNOutID.Name = "dgclSTITNOutID"
        Me.dgclSTITNOutID.ReadOnly = True
        Me.dgclSTITNOutID.Visible = False
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
        'dgclSupplierID
        '
        Me.dgclSupplierID.DataPropertyName = "SupplierID"
        Me.dgclSupplierID.HeaderText = "SupplierID"
        Me.dgclSupplierID.Name = "dgclSupplierID"
        Me.dgclSupplierID.ReadOnly = True
        Me.dgclSupplierID.Visible = False
        Me.dgclSupplierID.Width = 92
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
        'InternalTransferNoteOUTApprovalFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 557)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "InternalTransferNoteOUTApprovalFrm"
        Me.Text = "InternalTransferNoteOUTApprovalFrm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvITNOutApproval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.plITNOutApproval.ResumeLayout(False)
        Me.plITNOutApproval.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents plITNOutApproval As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchby As System.Windows.Forms.Label
    Friend WithEvents chkITNOutdate As System.Windows.Forms.CheckBox
    Friend WithEvents lblviewITNDate As System.Windows.Forms.Label
    Friend WithEvents dtpviewITNDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents btnviewRecLoc As System.Windows.Forms.Button
    Friend WithEvents txtviewRecLoc As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblviewITNOutNo As System.Windows.Forms.Label
    Friend WithEvents lblviewReceivedLoc As System.Windows.Forms.Label
    Friend WithEvents txtviewITNOutNo As System.Windows.Forms.TextBox
    Friend WithEvents dgvITNOutApproval As System.Windows.Forms.DataGridView
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents dgclITNOutDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclITNOutNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceivedLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclViewDetails As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents dgclSTITNOutID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierID As System.Windows.Forms.DataGridViewTextBoxColumn
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

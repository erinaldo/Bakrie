<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ITNINReportInterfacefrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ITNINReportInterfacefrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlITNINRpt = New Stepi.UI.ExtendedPanel
        Me.btnviewReport = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.chkITNDate = New System.Windows.Forms.CheckBox
        Me.lblviewITNDate = New System.Windows.Forms.Label
        Me.dtpviewITNDate = New System.Windows.Forms.DateTimePicker
        Me.lblviewITNIntNo = New System.Windows.Forms.Label
        Me.btnviewSendLoc = New System.Windows.Forms.Button
        Me.txtviewSendLoc = New System.Windows.Forms.TextBox
        Me.txtviewITNInNo = New System.Windows.Forms.TextBox
        Me.lblviewSendersLoc = New System.Windows.Forms.Label
        Me.lblsearchBy = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.dgvviewCReceived = New System.Windows.Forms.DataGridView
        Me.dgvITNInReport = New System.Windows.Forms.DataGridView
        Me.dgclSTITNInID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplierID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclITNDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclITNInNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSendersLocation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewReport = New System.Windows.Forms.DataGridViewButtonColumn
        Me.pnlITNINRpt.SuspendLayout()
        CType(Me.dgvviewCReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvITNInReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlITNINRpt
        '
        Me.pnlITNINRpt.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlITNINRpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlITNINRpt.BorderColor = System.Drawing.Color.Gray
        Me.pnlITNINRpt.CaptionColorOne = System.Drawing.Color.White
        Me.pnlITNINRpt.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlITNINRpt.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlITNINRpt.CaptionSize = 40
        Me.pnlITNINRpt.CaptionText = "TN IN Report"
        Me.pnlITNINRpt.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlITNINRpt.Controls.Add(Me.btnviewReport)
        Me.pnlITNINRpt.Controls.Add(Me.btnSearch)
        Me.pnlITNINRpt.Controls.Add(Me.chkITNDate)
        Me.pnlITNINRpt.Controls.Add(Me.lblviewITNDate)
        Me.pnlITNINRpt.Controls.Add(Me.dtpviewITNDate)
        Me.pnlITNINRpt.Controls.Add(Me.lblviewITNIntNo)
        Me.pnlITNINRpt.Controls.Add(Me.btnviewSendLoc)
        Me.pnlITNINRpt.Controls.Add(Me.txtviewSendLoc)
        Me.pnlITNINRpt.Controls.Add(Me.txtviewITNInNo)
        Me.pnlITNINRpt.Controls.Add(Me.lblviewSendersLoc)
        Me.pnlITNINRpt.Controls.Add(Me.lblsearchBy)
        Me.pnlITNINRpt.Controls.Add(Me.btnClose)
        Me.pnlITNINRpt.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlITNINRpt.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlITNINRpt.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlITNINRpt.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlITNINRpt.ForeColor = System.Drawing.Color.Black
        Me.pnlITNINRpt.Location = New System.Drawing.Point(0, 0)
        Me.pnlITNINRpt.Name = "pnlITNINRpt"
        Me.pnlITNINRpt.Size = New System.Drawing.Size(857, 194)
        Me.pnlITNINRpt.TabIndex = 122
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(610, 147)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(121, 25)
        Me.btnviewReport.TabIndex = 7
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(487, 147)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'chkITNDate
        '
        Me.chkITNDate.AutoSize = True
        Me.chkITNDate.Location = New System.Drawing.Point(49, 76)
        Me.chkITNDate.Name = "chkITNDate"
        Me.chkITNDate.Size = New System.Drawing.Size(15, 14)
        Me.chkITNDate.TabIndex = 1
        Me.chkITNDate.UseVisualStyleBackColor = True
        '
        'lblviewITNDate
        '
        Me.lblviewITNDate.AutoSize = True
        Me.lblviewITNDate.ForeColor = System.Drawing.Color.Black
        Me.lblviewITNDate.Location = New System.Drawing.Point(70, 76)
        Me.lblviewITNDate.Name = "lblviewITNDate"
        Me.lblviewITNDate.Size = New System.Drawing.Size(65, 13)
        Me.lblviewITNDate.TabIndex = 150
        Me.lblviewITNDate.Text = "TN IN Date"
        '
        'dtpviewITNDate
        '
        Me.dtpviewITNDate.Enabled = False
        Me.dtpviewITNDate.Location = New System.Drawing.Point(22, 101)
        Me.dtpviewITNDate.Name = "dtpviewITNDate"
        Me.dtpviewITNDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpviewITNDate.TabIndex = 2
        '
        'lblviewITNIntNo
        '
        Me.lblviewITNIntNo.AutoSize = True
        Me.lblviewITNIntNo.ForeColor = System.Drawing.Color.Black
        Me.lblviewITNIntNo.Location = New System.Drawing.Point(281, 76)
        Me.lblviewITNIntNo.Name = "lblviewITNIntNo"
        Me.lblviewITNIntNo.Size = New System.Drawing.Size(59, 13)
        Me.lblviewITNIntNo.TabIndex = 151
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
        Me.btnviewSendLoc.Location = New System.Drawing.Point(610, 93)
        Me.btnviewSendLoc.Name = "btnviewSendLoc"
        Me.btnviewSendLoc.Size = New System.Drawing.Size(30, 33)
        Me.btnviewSendLoc.TabIndex = 5
        Me.btnviewSendLoc.TabStop = False
        Me.btnviewSendLoc.UseVisualStyleBackColor = True
        '
        'txtviewSendLoc
        '
        Me.txtviewSendLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewSendLoc.Location = New System.Drawing.Point(439, 101)
        Me.txtviewSendLoc.MaxLength = 50
        Me.txtviewSendLoc.Name = "txtviewSendLoc"
        Me.txtviewSendLoc.Size = New System.Drawing.Size(165, 20)
        Me.txtviewSendLoc.TabIndex = 4
        '
        'txtviewITNInNo
        '
        Me.txtviewITNInNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewITNInNo.Location = New System.Drawing.Point(232, 101)
        Me.txtviewITNInNo.MaxLength = 50
        Me.txtviewITNInNo.Name = "txtviewITNInNo"
        Me.txtviewITNInNo.Size = New System.Drawing.Size(165, 20)
        Me.txtviewITNInNo.TabIndex = 3
        '
        'lblviewSendersLoc
        '
        Me.lblviewSendersLoc.AutoSize = True
        Me.lblviewSendersLoc.ForeColor = System.Drawing.Color.Black
        Me.lblviewSendersLoc.Location = New System.Drawing.Point(466, 76)
        Me.lblviewSendersLoc.Name = "lblviewSendersLoc"
        Me.lblviewSendersLoc.Size = New System.Drawing.Size(90, 13)
        Me.lblviewSendersLoc.TabIndex = 152
        Me.lblviewSendersLoc.Text = "Senders Location"
        '
        'lblsearchBy
        '
        Me.lblsearchBy.AutoSize = True
        Me.lblsearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblsearchBy.Location = New System.Drawing.Point(8, 50)
        Me.lblsearchBy.Name = "lblsearchBy"
        Me.lblsearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchBy.TabIndex = 54
        Me.lblsearchBy.Text = "Search By"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(739, 147)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(101, 25)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dgvviewCReceived
        '
        Me.dgvviewCReceived.AllowUserToAddRows = False
        Me.dgvviewCReceived.AllowUserToDeleteRows = False
        Me.dgvviewCReceived.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvviewCReceived.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvviewCReceived.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvviewCReceived.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvviewCReceived.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvviewCReceived.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvviewCReceived.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvviewCReceived.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvviewCReceived.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvviewCReceived.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvviewCReceived.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvviewCReceived.EnableHeadersVisualStyles = False
        Me.dgvviewCReceived.GridColor = System.Drawing.Color.Gray
        Me.dgvviewCReceived.Location = New System.Drawing.Point(0, 194)
        Me.dgvviewCReceived.Name = "dgvviewCReceived"
        Me.dgvviewCReceived.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvviewCReceived.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvviewCReceived.RowHeadersVisible = False
        Me.dgvviewCReceived.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvviewCReceived.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvviewCReceived.ShowCellErrors = False
        Me.dgvviewCReceived.Size = New System.Drawing.Size(857, 297)
        Me.dgvviewCReceived.TabIndex = 123
        Me.dgvviewCReceived.TabStop = False
        '
        'dgvITNInReport
        '
        Me.dgvITNInReport.AllowUserToAddRows = False
        Me.dgvITNInReport.AllowUserToDeleteRows = False
        Me.dgvITNInReport.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.dgvITNInReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvITNInReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvITNInReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvITNInReport.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvITNInReport.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvITNInReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvITNInReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvITNInReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclSTITNInID, Me.dgclSupplierID, Me.dgclITNDate, Me.dgclITNInNo, Me.dgclSendersLocation, Me.dgclRemarks, Me.dgclStatus, Me.dgclRejectedReason, Me.ViewReport})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvITNInReport.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvITNInReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvITNInReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvITNInReport.EnableHeadersVisualStyles = False
        Me.dgvITNInReport.GridColor = System.Drawing.Color.Gray
        Me.dgvITNInReport.Location = New System.Drawing.Point(0, 194)
        Me.dgvITNInReport.Name = "dgvITNInReport"
        Me.dgvITNInReport.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvITNInReport.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvITNInReport.RowHeadersVisible = False
        Me.dgvITNInReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvITNInReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvITNInReport.ShowCellErrors = False
        Me.dgvITNInReport.Size = New System.Drawing.Size(857, 297)
        Me.dgvITNInReport.TabIndex = 10
        Me.dgvITNInReport.TabStop = False
        '
        'dgclSTITNInID
        '
        Me.dgclSTITNInID.DataPropertyName = "STInternalTransferInID"
        Me.dgclSTITNInID.HeaderText = "STTNInID"
        Me.dgclSTITNInID.Name = "dgclSTITNInID"
        Me.dgclSTITNInID.ReadOnly = True
        Me.dgclSTITNInID.Visible = False
        Me.dgclSTITNInID.Width = 92
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
        'dgclSendersLocation
        '
        Me.dgclSendersLocation.DataPropertyName = "SendersLocation"
        Me.dgclSendersLocation.HeaderText = "Senders Location"
        Me.dgclSendersLocation.Name = "dgclSendersLocation"
        Me.dgclSendersLocation.ReadOnly = True
        Me.dgclSendersLocation.Width = 129
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
        'dgclStatus
        '
        Me.dgclStatus.DataPropertyName = "Status"
        Me.dgclStatus.HeaderText = "Status"
        Me.dgclStatus.Name = "dgclStatus"
        Me.dgclStatus.ReadOnly = True
        Me.dgclStatus.Visible = False
        Me.dgclStatus.Width = 67
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
        'ViewReport
        '
        Me.ViewReport.HeaderText = "ViewReport"
        Me.ViewReport.Name = "ViewReport"
        Me.ViewReport.ReadOnly = True
        Me.ViewReport.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ViewReport.Text = "ViewReport"
        Me.ViewReport.UseColumnTextForButtonValue = True
        Me.ViewReport.Width = 96
        '
        'ITNINReportInterfacefrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(857, 491)
        Me.Controls.Add(Me.dgvITNInReport)
        Me.Controls.Add(Me.dgvviewCReceived)
        Me.Controls.Add(Me.pnlITNINRpt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ITNINReportInterfacefrm"
        Me.Text = "ITNINReportInterfacefrm"
        Me.pnlITNINRpt.ResumeLayout(False)
        Me.pnlITNINRpt.PerformLayout()
        CType(Me.dgvviewCReceived, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvITNInReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlITNINRpt As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents dgvviewCReceived As System.Windows.Forms.DataGridView
    Friend WithEvents chkITNDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblviewITNDate As System.Windows.Forms.Label
    Friend WithEvents dtpviewITNDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewITNIntNo As System.Windows.Forms.Label
    Friend WithEvents btnviewSendLoc As System.Windows.Forms.Button
    Friend WithEvents txtviewSendLoc As System.Windows.Forms.TextBox
    Friend WithEvents txtviewITNInNo As System.Windows.Forms.TextBox
    Friend WithEvents lblviewSendersLoc As System.Windows.Forms.Label
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvITNInReport As System.Windows.Forms.DataGridView
    Friend WithEvents dgclSTITNInID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclITNDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclITNInNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSendersLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewReport As System.Windows.Forms.DataGridViewButtonColumn
End Class

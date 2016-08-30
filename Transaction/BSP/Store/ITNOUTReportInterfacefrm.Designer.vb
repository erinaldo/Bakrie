<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ITNOUTReportInterfacefrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ITNOUTReportInterfacefrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlITNoutRpt = New Stepi.UI.ExtendedPanel
        Me.btnviewReport = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.chkITNDate = New System.Windows.Forms.CheckBox
        Me.lblviewITNDate = New System.Windows.Forms.Label
        Me.dtpviewITNDate = New System.Windows.Forms.DateTimePicker
        Me.lblviewITNIntNo = New System.Windows.Forms.Label
        Me.btnviewRecLoc = New System.Windows.Forms.Button
        Me.txtviewReceLoc = New System.Windows.Forms.TextBox
        Me.txtviewITNOUTNo = New System.Windows.Forms.TextBox
        Me.lblviewReceiversLoc = New System.Windows.Forms.Label
        Me.lblsearchBy = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.dgvITNOut = New System.Windows.Forms.DataGridView
        Me.dgclITNOutDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSTITNOutID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclITNOutNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclReceivedLocation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclReceivedLocationID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewReport = New System.Windows.Forms.DataGridViewButtonColumn
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.pnlITNoutRpt.SuspendLayout()
        CType(Me.dgvITNOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlITNoutRpt
        '
        Me.pnlITNoutRpt.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlITNoutRpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlITNoutRpt.BorderColor = System.Drawing.Color.Gray
        Me.pnlITNoutRpt.CaptionColorOne = System.Drawing.Color.White
        Me.pnlITNoutRpt.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlITNoutRpt.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlITNoutRpt.CaptionSize = 40
        Me.pnlITNoutRpt.CaptionText = "ITN OUT Report"
        Me.pnlITNoutRpt.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlITNoutRpt.Controls.Add(Me.btnviewReport)
        Me.pnlITNoutRpt.Controls.Add(Me.btnSearch)
        Me.pnlITNoutRpt.Controls.Add(Me.chkITNDate)
        Me.pnlITNoutRpt.Controls.Add(Me.lblviewITNDate)
        Me.pnlITNoutRpt.Controls.Add(Me.dtpviewITNDate)
        Me.pnlITNoutRpt.Controls.Add(Me.lblviewITNIntNo)
        Me.pnlITNoutRpt.Controls.Add(Me.btnviewRecLoc)
        Me.pnlITNoutRpt.Controls.Add(Me.txtviewReceLoc)
        Me.pnlITNoutRpt.Controls.Add(Me.txtviewITNOUTNo)
        Me.pnlITNoutRpt.Controls.Add(Me.lblviewReceiversLoc)
        Me.pnlITNoutRpt.Controls.Add(Me.lblsearchBy)
        Me.pnlITNoutRpt.Controls.Add(Me.btnClose)
        Me.pnlITNoutRpt.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlITNoutRpt.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlITNoutRpt.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlITNoutRpt.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlITNoutRpt.ForeColor = System.Drawing.Color.Black
        Me.pnlITNoutRpt.Location = New System.Drawing.Point(0, 0)
        Me.pnlITNoutRpt.Name = "pnlITNoutRpt"
        Me.pnlITNoutRpt.Size = New System.Drawing.Size(850, 194)
        Me.pnlITNoutRpt.TabIndex = 123
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
        Me.lblviewITNDate.Size = New System.Drawing.Size(77, 13)
        Me.lblviewITNDate.TabIndex = 150
        Me.lblviewITNDate.Text = "TN OUT Date"
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
        Me.lblviewITNIntNo.Size = New System.Drawing.Size(71, 13)
        Me.lblviewITNIntNo.TabIndex = 151
        Me.lblviewITNIntNo.Text = "TN OUT No."
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
        Me.btnviewRecLoc.Location = New System.Drawing.Point(610, 93)
        Me.btnviewRecLoc.Name = "btnviewRecLoc"
        Me.btnviewRecLoc.Size = New System.Drawing.Size(30, 33)
        Me.btnviewRecLoc.TabIndex = 5
        Me.btnviewRecLoc.TabStop = False
        Me.btnviewRecLoc.UseVisualStyleBackColor = True
        '
        'txtviewReceLoc
        '
        Me.txtviewReceLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewReceLoc.Location = New System.Drawing.Point(439, 101)
        Me.txtviewReceLoc.MaxLength = 50
        Me.txtviewReceLoc.Name = "txtviewReceLoc"
        Me.txtviewReceLoc.Size = New System.Drawing.Size(165, 20)
        Me.txtviewReceLoc.TabIndex = 4
        '
        'txtviewITNOUTNo
        '
        Me.txtviewITNOUTNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewITNOUTNo.Location = New System.Drawing.Point(232, 101)
        Me.txtviewITNOUTNo.MaxLength = 50
        Me.txtviewITNOUTNo.Name = "txtviewITNOUTNo"
        Me.txtviewITNOUTNo.Size = New System.Drawing.Size(165, 20)
        Me.txtviewITNOUTNo.TabIndex = 3
        '
        'lblviewReceiversLoc
        '
        Me.lblviewReceiversLoc.AutoSize = True
        Me.lblviewReceiversLoc.ForeColor = System.Drawing.Color.Black
        Me.lblviewReceiversLoc.Location = New System.Drawing.Point(466, 76)
        Me.lblviewReceiversLoc.Name = "lblviewReceiversLoc"
        Me.lblviewReceiversLoc.Size = New System.Drawing.Size(99, 13)
        Me.lblviewReceiversLoc.TabIndex = 152
        Me.lblviewReceiversLoc.Text = "Receivers Location"
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
        'dgvITNOut
        '
        Me.dgvITNOut.AllowUserToAddRows = False
        Me.dgvITNOut.AllowUserToDeleteRows = False
        Me.dgvITNOut.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvITNOut.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvITNOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvITNOut.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvITNOut.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvITNOut.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvITNOut.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvITNOut.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvITNOut.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclITNOutDate, Me.dgclSTITNOutID, Me.dgclITNOutNo, Me.dgclReceivedLocation, Me.dgclReceivedLocationID, Me.dgclRemarks, Me.dgclStatus, Me.dgclRejectedReason, Me.ViewReport})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvITNOut.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvITNOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvITNOut.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvITNOut.EnableHeadersVisualStyles = False
        Me.dgvITNOut.GridColor = System.Drawing.Color.Gray
        Me.dgvITNOut.Location = New System.Drawing.Point(0, 194)
        Me.dgvITNOut.Name = "dgvITNOut"
        Me.dgvITNOut.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvITNOut.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvITNOut.RowHeadersVisible = False
        Me.dgvITNOut.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvITNOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvITNOut.ShowCellErrors = False
        Me.dgvITNOut.Size = New System.Drawing.Size(850, 263)
        Me.dgvITNOut.TabIndex = 124
        Me.dgvITNOut.TabStop = False
        '
        'dgclITNOutDate
        '
        Me.dgclITNOutDate.DataPropertyName = "ITNDate"
        Me.dgclITNOutDate.HeaderText = "TN OUT Date"
        Me.dgclITNOutDate.Name = "dgclITNOutDate"
        Me.dgclITNOutDate.ReadOnly = True
        Me.dgclITNOutDate.Width = 110
        '
        'dgclSTITNOutID
        '
        Me.dgclSTITNOutID.DataPropertyName = "STInternalTransferoutID"
        Me.dgclSTITNOutID.HeaderText = "STTNOutID"
        Me.dgclSTITNOutID.Name = "dgclSTITNOutID"
        Me.dgclSTITNOutID.ReadOnly = True
        Me.dgclSTITNOutID.Visible = False
        '
        'dgclITNOutNo
        '
        Me.dgclITNOutNo.DataPropertyName = "ItnOutNo"
        Me.dgclITNOutNo.HeaderText = "TN OUT No."
        Me.dgclITNOutNo.Name = "dgclITNOutNo"
        Me.dgclITNOutNo.ReadOnly = True
        Me.dgclITNOutNo.Width = 102
        '
        'dgclReceivedLocation
        '
        Me.dgclReceivedLocation.DataPropertyName = "ReceivedLocation"
        Me.dgclReceivedLocation.HeaderText = "Received Location"
        Me.dgclReceivedLocation.Name = "dgclReceivedLocation"
        Me.dgclReceivedLocation.ReadOnly = True
        Me.dgclReceivedLocation.Width = 134
        '
        'dgclReceivedLocationID
        '
        Me.dgclReceivedLocationID.DataPropertyName = "SupplierID"
        Me.dgclReceivedLocationID.HeaderText = "Received Location ID"
        Me.dgclReceivedLocationID.Name = "dgclReceivedLocationID"
        Me.dgclReceivedLocationID.ReadOnly = True
        Me.dgclReceivedLocationID.Visible = False
        Me.dgclReceivedLocationID.Width = 152
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
        Me.ViewReport.HeaderText = "View Report"
        Me.ViewReport.Name = "ViewReport"
        Me.ViewReport.ReadOnly = True
        Me.ViewReport.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ViewReport.Text = "View Report"
        Me.ViewReport.UseColumnTextForButtonValue = True
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(147, 301)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 125
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'ITNOUTReportInterfacefrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 457)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgvITNOut)
        Me.Controls.Add(Me.pnlITNoutRpt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ITNOUTReportInterfacefrm"
        Me.Text = "ITNOUTReportInterfacefrm"
        Me.pnlITNoutRpt.ResumeLayout(False)
        Me.pnlITNoutRpt.PerformLayout()
        CType(Me.dgvITNOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlITNoutRpt As Stepi.UI.ExtendedPanel
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents chkITNDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblviewITNDate As System.Windows.Forms.Label
    Friend WithEvents dtpviewITNDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewITNIntNo As System.Windows.Forms.Label
    Friend WithEvents btnviewRecLoc As System.Windows.Forms.Button
    Friend WithEvents txtviewReceLoc As System.Windows.Forms.TextBox
    Friend WithEvents txtviewITNOUTNo As System.Windows.Forms.TextBox
    Friend WithEvents lblviewReceiversLoc As System.Windows.Forms.Label
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvITNOut As System.Windows.Forms.DataGridView
    Friend WithEvents dgclITNOutDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTITNOutID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclITNOutNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceivedLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceivedLocationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewReport As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
End Class

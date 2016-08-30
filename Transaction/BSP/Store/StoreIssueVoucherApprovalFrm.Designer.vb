<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreIssueVoucherApprovalFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StoreIssueVoucherApprovalFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlSIVApproval = New Stepi.UI.ExtendedPanel
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.chkViewSIVDate = New System.Windows.Forms.CheckBox
        Me.txtSIVDateSearch = New System.Windows.Forms.DateTimePicker
        Me.txtSIVNoSearch = New System.Windows.Forms.TextBox
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.lblSIVNoSerach = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.pnlGrid = New System.Windows.Forms.Panel
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.dgViewIssueVoucher = New System.Windows.Forms.DataGridView
        Me.SIVNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SIVDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewDetails = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContractID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STIssueID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STIssueBatchID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlSIVApproval.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        CType(Me.dgViewIssueVoucher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSIVApproval
        '
        Me.pnlSIVApproval.BackColor = System.Drawing.Color.Transparent
        Me.pnlSIVApproval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlSIVApproval.BorderColor = System.Drawing.Color.Gray
        Me.pnlSIVApproval.CaptionColorOne = System.Drawing.Color.Transparent
        Me.pnlSIVApproval.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSIVApproval.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSIVApproval.CaptionSize = 30
        Me.pnlSIVApproval.CaptionText = " Store Issue Voucher Approval"
        Me.pnlSIVApproval.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSIVApproval.Controls.Add(Me.btnViewReport)
        Me.pnlSIVApproval.Controls.Add(Me.btnSearch)
        Me.pnlSIVApproval.Controls.Add(Me.chkViewSIVDate)
        Me.pnlSIVApproval.Controls.Add(Me.txtSIVDateSearch)
        Me.pnlSIVApproval.Controls.Add(Me.txtSIVNoSearch)
        Me.pnlSIVApproval.Controls.Add(Me.lblSearchBy)
        Me.pnlSIVApproval.Controls.Add(Me.lblSIVNoSerach)
        Me.pnlSIVApproval.Controls.Add(Me.Label30)
        Me.pnlSIVApproval.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSIVApproval.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSIVApproval.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSIVApproval.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSIVApproval.ForeColor = System.Drawing.Color.Black
        Me.pnlSIVApproval.Location = New System.Drawing.Point(0, 0)
        Me.pnlSIVApproval.Name = "pnlSIVApproval"
        Me.pnlSIVApproval.Size = New System.Drawing.Size(622, 112)
        Me.pnlSIVApproval.TabIndex = 0
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
        Me.btnViewReport.Location = New System.Drawing.Point(418, 74)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(116, 29)
        Me.btnViewReport.TabIndex = 5
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        Me.btnViewReport.Visible = False
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
        Me.btnSearch.Location = New System.Drawing.Point(293, 74)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(116, 29)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'chkViewSIVDate
        '
        Me.chkViewSIVDate.AutoSize = True
        Me.chkViewSIVDate.Location = New System.Drawing.Point(23, 57)
        Me.chkViewSIVDate.Name = "chkViewSIVDate"
        Me.chkViewSIVDate.Size = New System.Drawing.Size(69, 17)
        Me.chkViewSIVDate.TabIndex = 1
        Me.chkViewSIVDate.Text = "SIV Date"
        Me.chkViewSIVDate.UseVisualStyleBackColor = True
        '
        'txtSIVDateSearch
        '
        Me.txtSIVDateSearch.CalendarFont = New System.Drawing.Font("Verdana", 7.5!)
        Me.txtSIVDateSearch.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSIVDateSearch.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.txtSIVDateSearch.CustomFormat = "dd/MM/yyyy"
        Me.txtSIVDateSearch.Enabled = False
        Me.txtSIVDateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtSIVDateSearch.Location = New System.Drawing.Point(23, 79)
        Me.txtSIVDateSearch.Name = "txtSIVDateSearch"
        Me.txtSIVDateSearch.Size = New System.Drawing.Size(129, 20)
        Me.txtSIVDateSearch.TabIndex = 2
        '
        'txtSIVNoSearch
        '
        Me.txtSIVNoSearch.Location = New System.Drawing.Point(158, 79)
        Me.txtSIVNoSearch.Name = "txtSIVNoSearch"
        Me.txtSIVNoSearch.Size = New System.Drawing.Size(129, 20)
        Me.txtSIVNoSearch.TabIndex = 3
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearchBy.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchBy.Location = New System.Drawing.Point(3, 35)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchBy.TabIndex = 78
        Me.lblSearchBy.Text = "Search By"
        '
        'lblSIVNoSerach
        '
        Me.lblSIVNoSerach.AutoSize = True
        Me.lblSIVNoSerach.BackColor = System.Drawing.Color.Transparent
        Me.lblSIVNoSerach.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSIVNoSerach.ForeColor = System.Drawing.Color.Black
        Me.lblSIVNoSerach.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSIVNoSerach.Location = New System.Drawing.Point(158, 57)
        Me.lblSIVNoSerach.Name = "lblSIVNoSerach"
        Me.lblSIVNoSerach.Size = New System.Drawing.Size(47, 13)
        Me.lblSIVNoSerach.TabIndex = 80
        Me.lblSIVNoSerach.Text = "SIV No"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(81, 36)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(12, 14)
        Me.Label30.TabIndex = 79
        Me.Label30.Text = ":"
        '
        'pnlGrid
        '
        Me.pnlGrid.BackColor = System.Drawing.Color.Transparent
        Me.pnlGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlGrid.Controls.Add(Me.lblNoRecord)
        Me.pnlGrid.Controls.Add(Me.dgViewIssueVoucher)
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGrid.Location = New System.Drawing.Point(0, 112)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(622, 311)
        Me.pnlGrid.TabIndex = 1
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(112, 109)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 114
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'dgViewIssueVoucher
        '
        Me.dgViewIssueVoucher.AllowUserToAddRows = False
        Me.dgViewIssueVoucher.AllowUserToDeleteRows = False
        Me.dgViewIssueVoucher.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgViewIssueVoucher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgViewIssueVoucher.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewIssueVoucher.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgViewIssueVoucher.ColumnHeadersHeight = 30
        Me.dgViewIssueVoucher.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SIVNO, Me.SIVDate, Me.Status, Me.ViewDetails, Me.Remarks, Me.ContractID, Me.STIssueID, Me.STIssueBatchID})
        Me.dgViewIssueVoucher.EnableHeadersVisualStyles = False
        Me.dgViewIssueVoucher.GridColor = System.Drawing.Color.Gray
        Me.dgViewIssueVoucher.Location = New System.Drawing.Point(6, 12)
        Me.dgViewIssueVoucher.MultiSelect = False
        Me.dgViewIssueVoucher.Name = "dgViewIssueVoucher"
        Me.dgViewIssueVoucher.ReadOnly = True
        Me.dgViewIssueVoucher.RowHeadersVisible = False
        Me.dgViewIssueVoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgViewIssueVoucher.Size = New System.Drawing.Size(589, 254)
        Me.dgViewIssueVoucher.TabIndex = 87
        Me.dgViewIssueVoucher.TabStop = False
        '
        'SIVNO
        '
        Me.SIVNO.DataPropertyName = "SIVNO"
        Me.SIVNO.HeaderText = "SIV NO"
        Me.SIVNO.Name = "SIVNO"
        Me.SIVNO.ReadOnly = True
        '
        'SIVDate
        '
        Me.SIVDate.DataPropertyName = "SIVDate"
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.SIVDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.SIVDate.HeaderText = "SIV Date"
        Me.SIVDate.Name = "SIVDate"
        Me.SIVDate.ReadOnly = True
        Me.SIVDate.Width = 150
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'ViewDetails
        '
        Me.ViewDetails.DataPropertyName = "ViewDetails"
        Me.ViewDetails.HeaderText = "View Details"
        Me.ViewDetails.Name = "ViewDetails"
        Me.ViewDetails.ReadOnly = True
        Me.ViewDetails.Text = "View Details"
        Me.ViewDetails.UseColumnTextForButtonValue = True
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        Me.Remarks.Visible = False
        '
        'ContractID
        '
        Me.ContractID.DataPropertyName = "ContractID"
        Me.ContractID.HeaderText = "ContractID"
        Me.ContractID.Name = "ContractID"
        Me.ContractID.ReadOnly = True
        Me.ContractID.Visible = False
        '
        'STIssueID
        '
        Me.STIssueID.DataPropertyName = "STIssueID"
        Me.STIssueID.HeaderText = "STIssueID"
        Me.STIssueID.Name = "STIssueID"
        Me.STIssueID.ReadOnly = True
        Me.STIssueID.Visible = False
        '
        'STIssueBatchID
        '
        Me.STIssueBatchID.DataPropertyName = "STIssueBatchID"
        Me.STIssueBatchID.HeaderText = "STIssueBatchID"
        Me.STIssueBatchID.Name = "STIssueBatchID"
        Me.STIssueBatchID.ReadOnly = True
        Me.STIssueBatchID.Visible = False
        '
        'StoreIssueVoucherApprovalFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(622, 411)
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.pnlSIVApproval)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "StoreIssueVoucherApprovalFrm"
        Me.Text = "Store Issue Voucher Approval"
        Me.pnlSIVApproval.ResumeLayout(False)
        Me.pnlSIVApproval.PerformLayout()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGrid.PerformLayout()
        CType(Me.dgViewIssueVoucher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSIVApproval As Stepi.UI.ExtendedPanel
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents dgViewIssueVoucher As System.Windows.Forms.DataGridView
    Friend WithEvents chkViewSIVDate As System.Windows.Forms.CheckBox
    Friend WithEvents txtSIVDateSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSIVNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents lblSIVNoSerach As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents SIVNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIVDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewDetails As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STIssueID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STIssueBatchID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
End Class

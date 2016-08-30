<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PettyCashPaymentReportFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PettyCashPaymentReportFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtVoucherNoSearch = New System.Windows.Forms.TextBox
        Me.chkVoucherDate = New System.Windows.Forms.CheckBox
        Me.lblsearchBy = New System.Windows.Forms.Label
        Me.lblvoucherNoSearch = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.dtpviewVoucherDate = New System.Windows.Forms.DateTimePicker
        Me.dgvPettyCashPaymentView = New System.Windows.Forms.DataGridView
        Me.dgclVoucherNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclPayToID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVoucherDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclDistributionDescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclPaymentID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclDiscrepancyTransaction = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclApproved = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewReport = New System.Windows.Forms.DataGridViewButtonColumn
        Me.PnlSearch.SuspendLayout()
        CType(Me.dgvPettyCashPaymentView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.PnlSearch.Controls.Add(Me.Label5)
        Me.PnlSearch.Controls.Add(Me.txtVoucherNoSearch)
        Me.PnlSearch.Controls.Add(Me.chkVoucherDate)
        Me.PnlSearch.Controls.Add(Me.lblsearchBy)
        Me.PnlSearch.Controls.Add(Me.lblvoucherNoSearch)
        Me.PnlSearch.Controls.Add(Me.btnSearch)
        Me.PnlSearch.Controls.Add(Me.dtpviewVoucherDate)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlSearch.ForeColor = System.Drawing.Color.Black
        Me.PnlSearch.Location = New System.Drawing.Point(0, 0)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(705, 153)
        Me.PnlSearch.TabIndex = 117
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(87, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 214
        Me.Label5.Text = ":"
        '
        'txtVoucherNoSearch
        '
        Me.txtVoucherNoSearch.Location = New System.Drawing.Point(279, 90)
        Me.txtVoucherNoSearch.Name = "txtVoucherNoSearch"
        Me.txtVoucherNoSearch.Size = New System.Drawing.Size(163, 21)
        Me.txtVoucherNoSearch.TabIndex = 102
        '
        'chkVoucherDate
        '
        Me.chkVoucherDate.AutoSize = True
        Me.chkVoucherDate.Location = New System.Drawing.Point(107, 57)
        Me.chkVoucherDate.Name = "chkVoucherDate"
        Me.chkVoucherDate.Size = New System.Drawing.Size(104, 17)
        Me.chkVoucherDate.TabIndex = 100
        Me.chkVoucherDate.Text = "Voucher Date"
        Me.chkVoucherDate.UseVisualStyleBackColor = True
        '
        'lblsearchBy
        '
        Me.lblsearchBy.AutoSize = True
        Me.lblsearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblsearchBy.Location = New System.Drawing.Point(-1, 59)
        Me.lblsearchBy.Name = "lblsearchBy"
        Me.lblsearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchBy.TabIndex = 54
        Me.lblsearchBy.Text = "Search By"
        '
        'lblvoucherNoSearch
        '
        Me.lblvoucherNoSearch.AutoSize = True
        Me.lblvoucherNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblvoucherNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblvoucherNoSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblvoucherNoSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblvoucherNoSearch.Location = New System.Drawing.Point(276, 59)
        Me.lblvoucherNoSearch.Name = "lblvoucherNoSearch"
        Me.lblvoucherNoSearch.Size = New System.Drawing.Size(73, 13)
        Me.lblvoucherNoSearch.TabIndex = 120
        Me.lblvoucherNoSearch.Text = "Voucher No"
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(457, 88)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 25)
        Me.btnSearch.TabIndex = 103
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dtpviewVoucherDate
        '
        Me.dtpviewVoucherDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpviewVoucherDate.Enabled = False
        Me.dtpviewVoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpviewVoucherDate.Location = New System.Drawing.Point(101, 90)
        Me.dtpviewVoucherDate.Name = "dtpviewVoucherDate"
        Me.dtpviewVoucherDate.Size = New System.Drawing.Size(163, 21)
        Me.dtpviewVoucherDate.TabIndex = 101
        '
        'dgvPettyCashPaymentView
        '
        Me.dgvPettyCashPaymentView.AllowUserToAddRows = False
        Me.dgvPettyCashPaymentView.AllowUserToDeleteRows = False
        Me.dgvPettyCashPaymentView.AllowUserToResizeRows = False
        Me.dgvPettyCashPaymentView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPettyCashPaymentView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPettyCashPaymentView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPettyCashPaymentView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPettyCashPaymentView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPettyCashPaymentView.ColumnHeadersHeight = 30
        Me.dgvPettyCashPaymentView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclVoucherNo, Me.dgclRejectedReason, Me.dgclPayToID, Me.dgclVoucherDate, Me.dgclDistributionDescp, Me.dgclPaymentID, Me.dgclDiscrepancyTransaction, Me.dgclDescription, Me.dgclApproved, Me.ViewReport})
        Me.dgvPettyCashPaymentView.EnableHeadersVisualStyles = False
        Me.dgvPettyCashPaymentView.GridColor = System.Drawing.Color.Gray
        Me.dgvPettyCashPaymentView.Location = New System.Drawing.Point(0, 150)
        Me.dgvPettyCashPaymentView.MultiSelect = False
        Me.dgvPettyCashPaymentView.Name = "dgvPettyCashPaymentView"
        Me.dgvPettyCashPaymentView.ReadOnly = True
        Me.dgvPettyCashPaymentView.RowHeadersVisible = False
        Me.dgvPettyCashPaymentView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPettyCashPaymentView.Size = New System.Drawing.Size(705, 288)
        Me.dgvPettyCashPaymentView.TabIndex = 106
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
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgclVoucherDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgclVoucherDate.HeaderText = "Voucher Date"
        Me.dgclVoucherDate.Name = "dgclVoucherDate"
        Me.dgclVoucherDate.ReadOnly = True
        Me.dgclVoucherDate.Width = 150
        '
        'dgclDistributionDescp
        '
        Me.dgclDistributionDescp.DataPropertyName = "DistributionDescp"
        Me.dgclDistributionDescp.HeaderText = "Pay To"
        Me.dgclDistributionDescp.Name = "dgclDistributionDescp"
        Me.dgclDistributionDescp.ReadOnly = True
        Me.dgclDistributionDescp.Width = 150
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
        Me.dgclApproved.Visible = False
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
        Me.ViewReport.Width = 150
        '
        'PettyCashPaymentReportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(705, 439)
        Me.Controls.Add(Me.PnlSearch)
        Me.Controls.Add(Me.dgvPettyCashPaymentView)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "PettyCashPaymentReportFrm"
        Me.Text = "Petty Cash Payment Report"
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        CType(Me.dgvPettyCashPaymentView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtVoucherNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents chkVoucherDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents lblvoucherNoSearch As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dtpviewVoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvPettyCashPaymentView As System.Windows.Forms.DataGridView
    Friend WithEvents dgclVoucherNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPayToID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVoucherDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDistributionDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPaymentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDiscrepancyTransaction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclApproved As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewReport As System.Windows.Forms.DataGridViewButtonColumn
End Class

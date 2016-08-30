<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PenerimaanCashReceiptReportFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PenerimaanCashReceiptReportFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtVoucherNoSearch = New System.Windows.Forms.TextBox
        Me.chkVoucherDate = New System.Windows.Forms.CheckBox
        Me.lblsearchBy = New System.Windows.Forms.Label
        Me.lblvoucherNoSearch = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.dtpviewVoucherDate = New System.Windows.Forms.DateTimePicker
        Me.dgvReceiptView = New System.Windows.Forms.DataGridView
        Me.dgclReceiptDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclReceivedFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclReceiptDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclReconcilationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnViewReport = New System.Windows.Forms.DataGridViewButtonColumn
        Me.PnlSearch.SuspendLayout()
        CType(Me.dgvReceiptView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PnlSearch.CaptionText = "Search Penerimaan Cash Receipt"
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
        Me.PnlSearch.Size = New System.Drawing.Size(733, 153)
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
        Me.chkVoucherDate.Size = New System.Drawing.Size(99, 17)
        Me.chkVoucherDate.TabIndex = 100
        Me.chkVoucherDate.Text = "Receipt Date"
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
        Me.lblvoucherNoSearch.Size = New System.Drawing.Size(68, 13)
        Me.lblvoucherNoSearch.TabIndex = 120
        Me.lblvoucherNoSearch.Text = "Receipt No"
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
        'dgvReceiptView
        '
        Me.dgvReceiptView.AllowUserToAddRows = False
        Me.dgvReceiptView.AllowUserToDeleteRows = False
        Me.dgvReceiptView.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvReceiptView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReceiptView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvReceiptView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvReceiptView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvReceiptView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReceiptView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReceiptView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReceiptView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclReceiptDate, Me.dgclReceiptNo, Me.dgclReceivedFrom, Me.dgclReceiptDesc, Me.dgclReconcilationDate, Me.dgclAmount, Me.btnViewReport})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReceiptView.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvReceiptView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReceiptView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvReceiptView.EnableHeadersVisualStyles = False
        Me.dgvReceiptView.GridColor = System.Drawing.Color.Gray
        Me.dgvReceiptView.Location = New System.Drawing.Point(0, 153)
        Me.dgvReceiptView.Name = "dgvReceiptView"
        Me.dgvReceiptView.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReceiptView.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvReceiptView.RowHeadersVisible = False
        Me.dgvReceiptView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvReceiptView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReceiptView.ShowCellErrors = False
        Me.dgvReceiptView.Size = New System.Drawing.Size(733, 286)
        Me.dgvReceiptView.TabIndex = 118
        '
        'dgclReceiptDate
        '
        Me.dgclReceiptDate.DataPropertyName = "ReceiptDate"
        Me.dgclReceiptDate.HeaderText = "Receipt Date"
        Me.dgclReceiptDate.Name = "dgclReceiptDate"
        Me.dgclReceiptDate.ReadOnly = True
        Me.dgclReceiptDate.Width = 104
        '
        'dgclReceiptNo
        '
        Me.dgclReceiptNo.DataPropertyName = "ReceiptNo"
        Me.dgclReceiptNo.HeaderText = "Receipt No"
        Me.dgclReceiptNo.Name = "dgclReceiptNo"
        Me.dgclReceiptNo.ReadOnly = True
        Me.dgclReceiptNo.Width = 92
        '
        'dgclReceivedFrom
        '
        Me.dgclReceivedFrom.DataPropertyName = "ReceivedFrom"
        Me.dgclReceivedFrom.HeaderText = "Received From"
        Me.dgclReceivedFrom.Name = "dgclReceivedFrom"
        Me.dgclReceivedFrom.ReadOnly = True
        Me.dgclReceivedFrom.Width = 116
        '
        'dgclReceiptDesc
        '
        Me.dgclReceiptDesc.DataPropertyName = "ReceiptDescp"
        Me.dgclReceiptDesc.HeaderText = "Receipt Desc"
        Me.dgclReceiptDesc.Name = "dgclReceiptDesc"
        Me.dgclReceiptDesc.ReadOnly = True
        Me.dgclReceiptDesc.Visible = False
        Me.dgclReceiptDesc.Width = 105
        '
        'dgclReconcilationDate
        '
        Me.dgclReconcilationDate.DataPropertyName = "CashReconcilationDate"
        Me.dgclReconcilationDate.HeaderText = "Cash Reconcilation Form Date"
        Me.dgclReconcilationDate.Name = "dgclReconcilationDate"
        Me.dgclReconcilationDate.ReadOnly = True
        Me.dgclReconcilationDate.Width = 203
        '
        'dgclAmount
        '
        Me.dgclAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgclAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgclAmount.HeaderText = "Amount"
        Me.dgclAmount.Name = "dgclAmount"
        Me.dgclAmount.ReadOnly = True
        Me.dgclAmount.Width = 75
        '
        'btnViewReport
        '
        Me.btnViewReport.HeaderText = "View Report"
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.ReadOnly = True
        Me.btnViewReport.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnViewReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseColumnTextForButtonValue = True
        '
        'PenerimaanCashReceiptReportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(733, 439)
        Me.Controls.Add(Me.dgvReceiptView)
        Me.Controls.Add(Me.PnlSearch)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "PenerimaanCashReceiptReportFrm"
        Me.Text = "Petty Cash Payment Report"
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        CType(Me.dgvReceiptView, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvReceiptView As System.Windows.Forms.DataGridView
    Friend WithEvents dgclReceiptDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceivedFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceiptDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReconcilationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnViewReport As System.Windows.Forms.DataGridViewButtonColumn
End Class

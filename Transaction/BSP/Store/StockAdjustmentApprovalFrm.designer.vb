<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockAdjustmentApprovalFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockAdjustmentApprovalFrm))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvAdjustmentApproval = New System.Windows.Forms.DataGridView()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.txtAdjustNoSearch = New System.Windows.Forms.TextBox()
        Me.lblSearchBy = New System.Windows.Forms.Label()
        Me.pnlSIVApproval = New Stepi.UI.ExtendedPanel()
        Me.chkAdjustDate = New System.Windows.Forms.CheckBox()
        Me.dtpAdjustmentViewDate = New System.Windows.Forms.DateTimePicker()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnViewReport = New System.Windows.Forms.Button()
        Me.lblAdjustmentNoSerach = New System.Windows.Forms.Label()
        Me.dgclSTAdjustmentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclAdjustmentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclAdjustmentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclViewDetails = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgclStockCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclAdjQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclAdjValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDIVID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclYopID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclBlockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclModifiedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcBeritaAcaraAudit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvAdjustmentApproval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGrid.SuspendLayout()
        Me.pnlSIVApproval.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvAdjustmentApproval
        '
        Me.dgvAdjustmentApproval.AllowUserToAddRows = False
        Me.dgvAdjustmentApproval.AllowUserToDeleteRows = False
        Me.dgvAdjustmentApproval.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvAdjustmentApproval.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvAdjustmentApproval.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdjustmentApproval.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAdjustmentApproval.ColumnHeadersHeight = 30
        Me.dgvAdjustmentApproval.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclSTAdjustmentID, Me.dgclStockId, Me.dgclAdjustmentNo, Me.dgclAdjustmentDate, Me.dgclStatus, Me.dgclViewDetails, Me.dgclStockCode, Me.dgclID, Me.dgclRemarks, Me.dgclRejectedReason, Me.dgclAdjQty, Me.dgclAdjValue, Me.dgclCOAID, Me.dgclDIVID, Me.dgclYopID, Me.dgclBlockID, Me.dgclT0, Me.dgclT1, Me.dgclT2, Me.dgclT3, Me.dgclT4, Me.dgclModifiedOn, Me.dgcBeritaAcaraAudit})
        Me.dgvAdjustmentApproval.EnableHeadersVisualStyles = False
        Me.dgvAdjustmentApproval.GridColor = System.Drawing.Color.Gray
        Me.dgvAdjustmentApproval.Location = New System.Drawing.Point(6, 12)
        Me.dgvAdjustmentApproval.MultiSelect = False
        Me.dgvAdjustmentApproval.Name = "dgvAdjustmentApproval"
        Me.dgvAdjustmentApproval.ReadOnly = True
        Me.dgvAdjustmentApproval.RowHeadersVisible = False
        Me.dgvAdjustmentApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAdjustmentApproval.Size = New System.Drawing.Size(589, 254)
        Me.dgvAdjustmentApproval.TabIndex = 407
        Me.dgvAdjustmentApproval.TabStop = False
        '
        'pnlGrid
        '
        Me.pnlGrid.BackColor = System.Drawing.Color.Transparent
        Me.pnlGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlGrid.Controls.Add(Me.dgvAdjustmentApproval)
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGrid.Location = New System.Drawing.Point(0, 99)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(628, 311)
        Me.pnlGrid.TabIndex = 3
        '
        'txtAdjustNoSearch
        '
        Me.txtAdjustNoSearch.Location = New System.Drawing.Point(238, 63)
        Me.txtAdjustNoSearch.Name = "txtAdjustNoSearch"
        Me.txtAdjustNoSearch.Size = New System.Drawing.Size(129, 20)
        Me.txtAdjustNoSearch.TabIndex = 404
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearchBy.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchBy.Location = New System.Drawing.Point(3, 39)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchBy.TabIndex = 78
        Me.lblSearchBy.Text = "Search By"
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
        Me.pnlSIVApproval.CaptionText = "Stock Adjustment Approval"
        Me.pnlSIVApproval.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSIVApproval.Controls.Add(Me.chkAdjustDate)
        Me.pnlSIVApproval.Controls.Add(Me.dtpAdjustmentViewDate)
        Me.pnlSIVApproval.Controls.Add(Me.lblSearchBy)
        Me.pnlSIVApproval.Controls.Add(Me.Label30)
        Me.pnlSIVApproval.Controls.Add(Me.btnSearch)
        Me.pnlSIVApproval.Controls.Add(Me.btnViewReport)
        Me.pnlSIVApproval.Controls.Add(Me.txtAdjustNoSearch)
        Me.pnlSIVApproval.Controls.Add(Me.lblAdjustmentNoSerach)
        Me.pnlSIVApproval.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSIVApproval.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSIVApproval.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSIVApproval.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSIVApproval.Location = New System.Drawing.Point(0, 0)
        Me.pnlSIVApproval.Name = "pnlSIVApproval"
        Me.pnlSIVApproval.Size = New System.Drawing.Size(628, 99)
        Me.pnlSIVApproval.TabIndex = 2
        '
        'chkAdjustDate
        '
        Me.chkAdjustDate.AutoSize = True
        Me.chkAdjustDate.Location = New System.Drawing.Point(99, 39)
        Me.chkAdjustDate.Name = "chkAdjustDate"
        Me.chkAdjustDate.Size = New System.Drawing.Size(104, 17)
        Me.chkAdjustDate.TabIndex = 402
        Me.chkAdjustDate.Text = "Adjustment Date"
        Me.chkAdjustDate.UseVisualStyleBackColor = True
        '
        'dtpAdjustmentViewDate
        '
        Me.dtpAdjustmentViewDate.CalendarFont = New System.Drawing.Font("Verdana", 7.5!)
        Me.dtpAdjustmentViewDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtpAdjustmentViewDate.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.dtpAdjustmentViewDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpAdjustmentViewDate.Enabled = False
        Me.dtpAdjustmentViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdjustmentViewDate.Location = New System.Drawing.Point(86, 62)
        Me.dtpAdjustmentViewDate.Name = "dtpAdjustmentViewDate"
        Me.dtpAdjustmentViewDate.Size = New System.Drawing.Size(135, 20)
        Me.dtpAdjustmentViewDate.TabIndex = 403
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(81, 39)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(12, 14)
        Me.Label30.TabIndex = 79
        Me.Label30.Text = ":"
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
        Me.btnSearch.Location = New System.Drawing.Point(376, 54)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(116, 29)
        Me.btnSearch.TabIndex = 405
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
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
        Me.btnViewReport.Location = New System.Drawing.Point(501, 54)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(116, 29)
        Me.btnViewReport.TabIndex = 406
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        Me.btnViewReport.Visible = False
        '
        'lblAdjustmentNoSerach
        '
        Me.lblAdjustmentNoSerach.AutoSize = True
        Me.lblAdjustmentNoSerach.BackColor = System.Drawing.Color.Transparent
        Me.lblAdjustmentNoSerach.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblAdjustmentNoSerach.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAdjustmentNoSerach.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAdjustmentNoSerach.Location = New System.Drawing.Point(237, 40)
        Me.lblAdjustmentNoSerach.Name = "lblAdjustmentNoSerach"
        Me.lblAdjustmentNoSerach.Size = New System.Drawing.Size(91, 13)
        Me.lblAdjustmentNoSerach.TabIndex = 80
        Me.lblAdjustmentNoSerach.Text = "Adjustment No"
        '
        'dgclSTAdjustmentID
        '
        Me.dgclSTAdjustmentID.DataPropertyName = "STAdjustmentID"
        Me.dgclSTAdjustmentID.HeaderText = "STAdjustmentID"
        Me.dgclSTAdjustmentID.Name = "dgclSTAdjustmentID"
        Me.dgclSTAdjustmentID.ReadOnly = True
        Me.dgclSTAdjustmentID.Visible = False
        '
        'dgclStockId
        '
        Me.dgclStockId.DataPropertyName = "StockID"
        Me.dgclStockId.HeaderText = "StockID"
        Me.dgclStockId.Name = "dgclStockId"
        Me.dgclStockId.ReadOnly = True
        Me.dgclStockId.Visible = False
        '
        'dgclAdjustmentNo
        '
        Me.dgclAdjustmentNo.DataPropertyName = "AdjustmentNO"
        Me.dgclAdjustmentNo.HeaderText = "Adjustment NO"
        Me.dgclAdjustmentNo.Name = "dgclAdjustmentNo"
        Me.dgclAdjustmentNo.ReadOnly = True
        Me.dgclAdjustmentNo.Width = 150
        '
        'dgclAdjustmentDate
        '
        Me.dgclAdjustmentDate.DataPropertyName = "AdjustmentDate"
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgclAdjustmentDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgclAdjustmentDate.HeaderText = "Adjustment Date"
        Me.dgclAdjustmentDate.Name = "dgclAdjustmentDate"
        Me.dgclAdjustmentDate.ReadOnly = True
        Me.dgclAdjustmentDate.Width = 150
        '
        'dgclStatus
        '
        Me.dgclStatus.DataPropertyName = "Status"
        Me.dgclStatus.HeaderText = "Status"
        Me.dgclStatus.Name = "dgclStatus"
        Me.dgclStatus.ReadOnly = True
        '
        'dgclViewDetails
        '
        Me.dgclViewDetails.DataPropertyName = "ViewDetails"
        Me.dgclViewDetails.HeaderText = "View Details"
        Me.dgclViewDetails.Name = "dgclViewDetails"
        Me.dgclViewDetails.ReadOnly = True
        Me.dgclViewDetails.Text = "View Details"
        Me.dgclViewDetails.UseColumnTextForButtonValue = True
        '
        'dgclStockCode
        '
        Me.dgclStockCode.DataPropertyName = "StockCode"
        Me.dgclStockCode.HeaderText = "StockCode"
        Me.dgclStockCode.Name = "dgclStockCode"
        Me.dgclStockCode.ReadOnly = True
        Me.dgclStockCode.Visible = False
        '
        'dgclID
        '
        Me.dgclID.DataPropertyName = "ID"
        Me.dgclID.HeaderText = "ID"
        Me.dgclID.Name = "dgclID"
        Me.dgclID.ReadOnly = True
        Me.dgclID.Visible = False
        '
        'dgclRemarks
        '
        Me.dgclRemarks.DataPropertyName = "Remarks"
        Me.dgclRemarks.HeaderText = "Remarks"
        Me.dgclRemarks.Name = "dgclRemarks"
        Me.dgclRemarks.ReadOnly = True
        Me.dgclRemarks.Visible = False
        '
        'dgclRejectedReason
        '
        Me.dgclRejectedReason.DataPropertyName = "RejectedReason"
        Me.dgclRejectedReason.HeaderText = "RejectedReason"
        Me.dgclRejectedReason.Name = "dgclRejectedReason"
        Me.dgclRejectedReason.ReadOnly = True
        Me.dgclRejectedReason.Visible = False
        '
        'dgclAdjQty
        '
        Me.dgclAdjQty.DataPropertyName = "AdjQty"
        Me.dgclAdjQty.HeaderText = "AdjQty"
        Me.dgclAdjQty.Name = "dgclAdjQty"
        Me.dgclAdjQty.ReadOnly = True
        Me.dgclAdjQty.Visible = False
        '
        'dgclAdjValue
        '
        Me.dgclAdjValue.DataPropertyName = "AdjValue"
        Me.dgclAdjValue.HeaderText = "AdjValue"
        Me.dgclAdjValue.Name = "dgclAdjValue"
        Me.dgclAdjValue.ReadOnly = True
        Me.dgclAdjValue.Visible = False
        '
        'dgclCOAID
        '
        Me.dgclCOAID.DataPropertyName = "COAID"
        Me.dgclCOAID.HeaderText = "COAID"
        Me.dgclCOAID.Name = "dgclCOAID"
        Me.dgclCOAID.ReadOnly = True
        Me.dgclCOAID.Visible = False
        '
        'dgclDIVID
        '
        Me.dgclDIVID.DataPropertyName = "DIVID"
        Me.dgclDIVID.HeaderText = "Afdeling ID"
        Me.dgclDIVID.Name = "dgclDIVID"
        Me.dgclDIVID.ReadOnly = True
        Me.dgclDIVID.Visible = False
        '
        'dgclYopID
        '
        Me.dgclYopID.DataPropertyName = "YopID"
        Me.dgclYopID.HeaderText = "YopID"
        Me.dgclYopID.Name = "dgclYopID"
        Me.dgclYopID.ReadOnly = True
        Me.dgclYopID.Visible = False
        '
        'dgclBlockID
        '
        Me.dgclBlockID.DataPropertyName = "BlockID"
        Me.dgclBlockID.HeaderText = "FieldNoID"
        Me.dgclBlockID.Name = "dgclBlockID"
        Me.dgclBlockID.ReadOnly = True
        Me.dgclBlockID.Visible = False
        '
        'dgclT0
        '
        Me.dgclT0.DataPropertyName = "T0Value"
        Me.dgclT0.HeaderText = "T0"
        Me.dgclT0.Name = "dgclT0"
        Me.dgclT0.ReadOnly = True
        Me.dgclT0.Visible = False
        '
        'dgclT1
        '
        Me.dgclT1.DataPropertyName = "T1Value"
        Me.dgclT1.HeaderText = "T1"
        Me.dgclT1.Name = "dgclT1"
        Me.dgclT1.ReadOnly = True
        Me.dgclT1.Visible = False
        '
        'dgclT2
        '
        Me.dgclT2.DataPropertyName = "T2Value"
        Me.dgclT2.HeaderText = "T2"
        Me.dgclT2.Name = "dgclT2"
        Me.dgclT2.ReadOnly = True
        Me.dgclT2.Visible = False
        '
        'dgclT3
        '
        Me.dgclT3.DataPropertyName = "T3Value"
        Me.dgclT3.HeaderText = "T3"
        Me.dgclT3.Name = "dgclT3"
        Me.dgclT3.ReadOnly = True
        Me.dgclT3.Visible = False
        '
        'dgclT4
        '
        Me.dgclT4.DataPropertyName = "T4Value"
        Me.dgclT4.HeaderText = "T4"
        Me.dgclT4.Name = "dgclT4"
        Me.dgclT4.ReadOnly = True
        Me.dgclT4.Visible = False
        '
        'dgclModifiedOn
        '
        Me.dgclModifiedOn.DataPropertyName = "ModifiedOn"
        Me.dgclModifiedOn.HeaderText = "ModifiedOn"
        Me.dgclModifiedOn.Name = "dgclModifiedOn"
        Me.dgclModifiedOn.ReadOnly = True
        Me.dgclModifiedOn.Visible = False
        '
        'dgcBeritaAcaraAudit
        '
        Me.dgcBeritaAcaraAudit.DataPropertyName = "BeritaAcaraAudit"
        Me.dgcBeritaAcaraAudit.HeaderText = "BeritaAcaraAudit"
        Me.dgcBeritaAcaraAudit.Name = "dgcBeritaAcaraAudit"
        Me.dgcBeritaAcaraAudit.ReadOnly = True
        Me.dgcBeritaAcaraAudit.Visible = False
        '
        'StockAdjustmentApprovalFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(628, 393)
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.pnlSIVApproval)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "StockAdjustmentApprovalFrm"
        Me.Text = "StockAdjustmentApprovalFrm"
        CType(Me.dgvAdjustmentApproval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlSIVApproval.ResumeLayout(False)
        Me.pnlSIVApproval.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAdjustmentApproval As System.Windows.Forms.DataGridView
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtAdjustNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents pnlSIVApproval As Stepi.UI.ExtendedPanel
    Friend WithEvents lblAdjustmentNoSerach As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents chkAdjustDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpAdjustmentViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgclSTAdjustmentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAdjustmentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAdjustmentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclViewDetails As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents dgclStockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAdjQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAdjValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDIVID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclYopID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBlockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclModifiedOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcBeritaAcaraAudit As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

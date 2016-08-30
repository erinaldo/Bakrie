<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsignmentReceivedApprovalFrm
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsignmentReceivedApprovalFrm))
        Me.plIPRView = New System.Windows.Forms.Panel
        Me.lblNoRecordFound = New System.Windows.Forms.Label
        Me.dgvviewCReceived = New System.Windows.Forms.DataGridView
        Me.ReceivedDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STConsignmentMasterID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivedQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StConsignmentID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UOMID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UOM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockBalance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewDetails = New System.Windows.Forms.DataGridViewButtonColumn
        Me.pnlConsignmentReceived = New Stepi.UI.ExtendedPanel
        Me.txtviewStockCode = New System.Windows.Forms.TextBox
        Me.lblviewStockCode = New System.Windows.Forms.Label
        Me.chkviewCRDate = New System.Windows.Forms.CheckBox
        Me.lblviewISRSearchBy = New System.Windows.Forms.Label
        Me.dtpviewCRDate = New System.Windows.Forms.DateTimePicker
        Me.lblviewReferenceno = New System.Windows.Forms.Label
        Me.txtviewCRNo = New System.Windows.Forms.TextBox
        Me.btnviewCRSearch = New System.Windows.Forms.Button
        Me.plIPRView.SuspendLayout()
        CType(Me.dgvviewCReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConsignmentReceived.SuspendLayout()
        Me.SuspendLayout()
        '
        'plIPRView
        '
        Me.plIPRView.Controls.Add(Me.lblNoRecordFound)
        Me.plIPRView.Controls.Add(Me.dgvviewCReceived)
        Me.plIPRView.Controls.Add(Me.pnlConsignmentReceived)
        Me.plIPRView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plIPRView.Location = New System.Drawing.Point(0, 0)
        Me.plIPRView.Name = "plIPRView"
        Me.plIPRView.Size = New System.Drawing.Size(919, 732)
        Me.plIPRView.TabIndex = 46
        '
        'lblNoRecordFound
        '
        Me.lblNoRecordFound.AutoSize = True
        Me.lblNoRecordFound.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblNoRecordFound.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecordFound.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecordFound.Location = New System.Drawing.Point(247, 225)
        Me.lblNoRecordFound.Name = "lblNoRecordFound"
        Me.lblNoRecordFound.Size = New System.Drawing.Size(130, 13)
        Me.lblNoRecordFound.TabIndex = 121
        Me.lblNoRecordFound.Text = "Record not found !!"
        Me.lblNoRecordFound.Visible = False
        '
        'dgvviewCReceived
        '
        Me.dgvviewCReceived.AllowUserToAddRows = False
        Me.dgvviewCReceived.AllowUserToDeleteRows = False
        Me.dgvviewCReceived.AllowUserToOrderColumns = True
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvviewCReceived.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvviewCReceived.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvviewCReceived.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvviewCReceived.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvviewCReceived.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvviewCReceived.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvviewCReceived.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvviewCReceived.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReceivedDate, Me.ReferenceNo, Me.STCode, Me.STConsignmentMasterID, Me.STDesc, Me.ReceivedQty, Me.StConsignmentID, Me.UOMID, Me.UOM, Me.PartNo, Me.StockBalance, Me.Remarks, Me.ViewDetails})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvviewCReceived.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvviewCReceived.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvviewCReceived.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvviewCReceived.EnableHeadersVisualStyles = False
        Me.dgvviewCReceived.GridColor = System.Drawing.Color.Gray
        Me.dgvviewCReceived.Location = New System.Drawing.Point(0, 135)
        Me.dgvviewCReceived.Name = "dgvviewCReceived"
        Me.dgvviewCReceived.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvviewCReceived.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvviewCReceived.RowHeadersVisible = False
        Me.dgvviewCReceived.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvviewCReceived.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvviewCReceived.ShowCellErrors = False
        Me.dgvviewCReceived.Size = New System.Drawing.Size(919, 597)
        Me.dgvviewCReceived.TabIndex = 117
        Me.dgvviewCReceived.TabStop = False
        '
        'ReceivedDate
        '
        Me.ReceivedDate.DataPropertyName = "ReceivedDate"
        DataGridViewCellStyle8.Format = "dd/MM/yyyy"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ReceivedDate.DefaultCellStyle = DataGridViewCellStyle8
        Me.ReceivedDate.HeaderText = "Received Date"
        Me.ReceivedDate.Name = "ReceivedDate"
        Me.ReceivedDate.ReadOnly = True
        Me.ReceivedDate.Width = 114
        '
        'ReferenceNo
        '
        Me.ReferenceNo.DataPropertyName = "ReferenceNo"
        Me.ReferenceNo.HeaderText = "Reference No"
        Me.ReferenceNo.Name = "ReferenceNo"
        Me.ReferenceNo.ReadOnly = True
        Me.ReferenceNo.Width = 108
        '
        'STCode
        '
        Me.STCode.DataPropertyName = "STCode"
        Me.STCode.HeaderText = "Consignment Stock Code"
        Me.STCode.Name = "STCode"
        Me.STCode.ReadOnly = True
        Me.STCode.Width = 176
        '
        'STConsignmentMasterID
        '
        Me.STConsignmentMasterID.DataPropertyName = "STConsignmentMasterID"
        Me.STConsignmentMasterID.HeaderText = "STConsignment MasterID"
        Me.STConsignmentMasterID.Name = "STConsignmentMasterID"
        Me.STConsignmentMasterID.ReadOnly = True
        Me.STConsignmentMasterID.Visible = False
        Me.STConsignmentMasterID.Width = 177
        '
        'STDesc
        '
        Me.STDesc.DataPropertyName = "STDesc"
        Me.STDesc.HeaderText = "STDesc"
        Me.STDesc.Name = "STDesc"
        Me.STDesc.ReadOnly = True
        Me.STDesc.Visible = False
        Me.STDesc.Width = 74
        '
        'ReceivedQty
        '
        Me.ReceivedQty.DataPropertyName = "ReceivedQty"
        Me.ReceivedQty.HeaderText = "Received Qty"
        Me.ReceivedQty.Name = "ReceivedQty"
        Me.ReceivedQty.ReadOnly = True
        Me.ReceivedQty.Visible = False
        Me.ReceivedQty.Width = 107
        '
        'StConsignmentID
        '
        Me.StConsignmentID.DataPropertyName = "StConsignmentID"
        Me.StConsignmentID.HeaderText = "StConsignmentID"
        Me.StConsignmentID.Name = "StConsignmentID"
        Me.StConsignmentID.ReadOnly = True
        Me.StConsignmentID.Visible = False
        Me.StConsignmentID.Width = 132
        '
        'UOMID
        '
        Me.UOMID.DataPropertyName = "UOMID"
        Me.UOMID.HeaderText = "UOMID"
        Me.UOMID.Name = "UOMID"
        Me.UOMID.ReadOnly = True
        Me.UOMID.Visible = False
        Me.UOMID.Width = 71
        '
        'UOM
        '
        Me.UOM.DataPropertyName = "UOM"
        Me.UOM.HeaderText = "UOM"
        Me.UOM.Name = "UOM"
        Me.UOM.ReadOnly = True
        Me.UOM.Width = 57
        '
        'PartNo
        '
        Me.PartNo.DataPropertyName = "PartNo"
        Me.PartNo.HeaderText = "Part No."
        Me.PartNo.Name = "PartNo"
        Me.PartNo.ReadOnly = True
        Me.PartNo.Width = 77
        '
        'StockBalance
        '
        Me.StockBalance.DataPropertyName = "StockBalance"
        Me.StockBalance.HeaderText = "Stock Balance"
        Me.StockBalance.Name = "StockBalance"
        Me.StockBalance.ReadOnly = True
        Me.StockBalance.Width = 112
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        Me.Remarks.Width = 82
        '
        'ViewDetails
        '
        Me.ViewDetails.DataPropertyName = "ViewDetails"
        Me.ViewDetails.HeaderText = "View Details"
        Me.ViewDetails.Name = "ViewDetails"
        Me.ViewDetails.ReadOnly = True
        Me.ViewDetails.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ViewDetails.Text = "View Details"
        Me.ViewDetails.UseColumnTextForButtonValue = True
        Me.ViewDetails.Width = 101
        '
        'pnlConsignmentReceived
        '
        Me.pnlConsignmentReceived.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlConsignmentReceived.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlConsignmentReceived.BorderColor = System.Drawing.Color.Gray
        Me.pnlConsignmentReceived.CaptionColorOne = System.Drawing.Color.White
        Me.pnlConsignmentReceived.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlConsignmentReceived.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlConsignmentReceived.CaptionSize = 40
        Me.pnlConsignmentReceived.CaptionText = "Search ConsignmentReceived"
        Me.pnlConsignmentReceived.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlConsignmentReceived.Controls.Add(Me.txtviewStockCode)
        Me.pnlConsignmentReceived.Controls.Add(Me.lblviewStockCode)
        Me.pnlConsignmentReceived.Controls.Add(Me.chkviewCRDate)
        Me.pnlConsignmentReceived.Controls.Add(Me.lblviewISRSearchBy)
        Me.pnlConsignmentReceived.Controls.Add(Me.dtpviewCRDate)
        Me.pnlConsignmentReceived.Controls.Add(Me.lblviewReferenceno)
        Me.pnlConsignmentReceived.Controls.Add(Me.txtviewCRNo)
        Me.pnlConsignmentReceived.Controls.Add(Me.btnviewCRSearch)
        Me.pnlConsignmentReceived.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlConsignmentReceived.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlConsignmentReceived.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlConsignmentReceived.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlConsignmentReceived.ForeColor = System.Drawing.Color.Black
        Me.pnlConsignmentReceived.Location = New System.Drawing.Point(0, 0)
        Me.pnlConsignmentReceived.Name = "pnlConsignmentReceived"
        Me.pnlConsignmentReceived.Size = New System.Drawing.Size(919, 135)
        Me.pnlConsignmentReceived.TabIndex = 18
        '
        'txtviewStockCode
        '
        Me.txtviewStockCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewStockCode.Location = New System.Drawing.Point(421, 87)
        Me.txtviewStockCode.MaxLength = 50
        Me.txtviewStockCode.Name = "txtviewStockCode"
        Me.txtviewStockCode.Size = New System.Drawing.Size(196, 20)
        Me.txtviewStockCode.TabIndex = 15
        '
        'lblviewStockCode
        '
        Me.lblviewStockCode.AutoSize = True
        Me.lblviewStockCode.Location = New System.Drawing.Point(418, 65)
        Me.lblviewStockCode.Name = "lblviewStockCode"
        Me.lblviewStockCode.Size = New System.Drawing.Size(60, 13)
        Me.lblviewStockCode.TabIndex = 118
        Me.lblviewStockCode.Text = "StockCode"
        '
        'chkviewCRDate
        '
        Me.chkviewCRDate.AutoSize = True
        Me.chkviewCRDate.Location = New System.Drawing.Point(74, 64)
        Me.chkviewCRDate.Name = "chkviewCRDate"
        Me.chkviewCRDate.Size = New System.Drawing.Size(98, 17)
        Me.chkviewCRDate.TabIndex = 12
        Me.chkviewCRDate.Text = "Received Date"
        Me.chkviewCRDate.UseVisualStyleBackColor = True
        '
        'lblviewISRSearchBy
        '
        Me.lblviewISRSearchBy.AutoSize = True
        Me.lblviewISRSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblviewISRSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewISRSearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblviewISRSearchBy.Location = New System.Drawing.Point(1, 41)
        Me.lblviewISRSearchBy.Name = "lblviewISRSearchBy"
        Me.lblviewISRSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblviewISRSearchBy.TabIndex = 54
        Me.lblviewISRSearchBy.Text = "Search By"
        '
        'dtpviewCRDate
        '
        Me.dtpviewCRDate.Enabled = False
        Me.dtpviewCRDate.Location = New System.Drawing.Point(74, 87)
        Me.dtpviewCRDate.Name = "dtpviewCRDate"
        Me.dtpviewCRDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpviewCRDate.TabIndex = 13
        '
        'lblviewReferenceno
        '
        Me.lblviewReferenceno.AutoSize = True
        Me.lblviewReferenceno.ForeColor = System.Drawing.Color.Black
        Me.lblviewReferenceno.Location = New System.Drawing.Point(247, 64)
        Me.lblviewReferenceno.Name = "lblviewReferenceno"
        Me.lblviewReferenceno.Size = New System.Drawing.Size(74, 13)
        Me.lblviewReferenceno.TabIndex = 17
        Me.lblviewReferenceno.Text = "Reference No"
        '
        'txtviewCRNo
        '
        Me.txtviewCRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewCRNo.Location = New System.Drawing.Point(250, 87)
        Me.txtviewCRNo.MaxLength = 50
        Me.txtviewCRNo.Name = "txtviewCRNo"
        Me.txtviewCRNo.Size = New System.Drawing.Size(165, 20)
        Me.txtviewCRNo.TabIndex = 14
        '
        'btnviewCRSearch
        '
        Me.btnviewCRSearch.BackgroundImage = CType(resources.GetObject("btnviewCRSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnviewCRSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewCRSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewCRSearch.ForeColor = System.Drawing.Color.Black
        Me.btnviewCRSearch.Image = CType(resources.GetObject("btnviewCRSearch.Image"), System.Drawing.Image)
        Me.btnviewCRSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewCRSearch.Location = New System.Drawing.Point(640, 83)
        Me.btnviewCRSearch.Name = "btnviewCRSearch"
        Me.btnviewCRSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnviewCRSearch.TabIndex = 16
        Me.btnviewCRSearch.Text = "Search"
        Me.btnviewCRSearch.UseVisualStyleBackColor = True
        '
        'ConsignmentReceivedApprovalFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 732)
        Me.Controls.Add(Me.plIPRView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ConsignmentReceivedApprovalFrm"
        Me.Text = "Consignment Received Approval Form"
        Me.plIPRView.ResumeLayout(False)
        Me.plIPRView.PerformLayout()
        CType(Me.dgvviewCReceived, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConsignmentReceived.ResumeLayout(False)
        Me.pnlConsignmentReceived.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plIPRView As System.Windows.Forms.Panel
    Friend WithEvents lblNoRecordFound As System.Windows.Forms.Label
    Friend WithEvents dgvviewCReceived As System.Windows.Forms.DataGridView
    Friend WithEvents pnlConsignmentReceived As Stepi.UI.ExtendedPanel
    Friend WithEvents txtviewStockCode As System.Windows.Forms.TextBox
    Friend WithEvents lblviewStockCode As System.Windows.Forms.Label
    Friend WithEvents chkviewCRDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblviewISRSearchBy As System.Windows.Forms.Label
    Friend WithEvents dtpviewCRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewReferenceno As System.Windows.Forms.Label
    Friend WithEvents txtviewCRNo As System.Windows.Forms.TextBox
    Friend WithEvents btnviewCRSearch As System.Windows.Forms.Button
    Friend WithEvents ReceivedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STConsignmentMasterID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StConsignmentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOMID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewDetails As System.Windows.Forms.DataGridViewButtonColumn
End Class

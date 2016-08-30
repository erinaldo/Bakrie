<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockCodeLookUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockCodeLookUp))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlStockCodeSearch = New Stepi.UI.ExtendedPanel()
        Me.txtPartNosearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPartNo = New System.Windows.Forms.Label()
        Me.txtStockDescsearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStockDesc = New System.Windows.Forms.Label()
        Me.lblStockCode = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSearchby = New System.Windows.Forms.Label()
        Me.btnStcokCodeSearch = New System.Windows.Forms.Button()
        Me.txtStockCodesearch = New System.Windows.Forms.TextBox()
        Me.lblNoRecord = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvStockCode = New System.Windows.Forms.DataGridView()
        Me.gvStockCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvStockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvStockDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvLastPurchasePrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvAvailableQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvUnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvMinQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvMaxQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvReOrderQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvAccountCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvAccountDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvStockCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvVarianceCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvUom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlStockCodeSearch.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvStockCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlStockCodeSearch
        '
        Me.pnlStockCodeSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlStockCodeSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlStockCodeSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlStockCodeSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlStockCodeSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlStockCodeSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlStockCodeSearch.CaptionSize = 40
        Me.pnlStockCodeSearch.CaptionText = "Search Stock Code"
        Me.pnlStockCodeSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlStockCodeSearch.Controls.Add(Me.txtPartNosearch)
        Me.pnlStockCodeSearch.Controls.Add(Me.Label2)
        Me.pnlStockCodeSearch.Controls.Add(Me.lblPartNo)
        Me.pnlStockCodeSearch.Controls.Add(Me.txtStockDescsearch)
        Me.pnlStockCodeSearch.Controls.Add(Me.Label1)
        Me.pnlStockCodeSearch.Controls.Add(Me.lblStockDesc)
        Me.pnlStockCodeSearch.Controls.Add(Me.lblStockCode)
        Me.pnlStockCodeSearch.Controls.Add(Me.btnClose)
        Me.pnlStockCodeSearch.Controls.Add(Me.Label4)
        Me.pnlStockCodeSearch.Controls.Add(Me.lblSearchby)
        Me.pnlStockCodeSearch.Controls.Add(Me.btnStcokCodeSearch)
        Me.pnlStockCodeSearch.Controls.Add(Me.txtStockCodesearch)
        Me.pnlStockCodeSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlStockCodeSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlStockCodeSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlStockCodeSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlStockCodeSearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlStockCodeSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlStockCodeSearch.Name = "pnlStockCodeSearch"
        Me.pnlStockCodeSearch.Size = New System.Drawing.Size(815, 141)
        Me.pnlStockCodeSearch.TabIndex = 13
        '
        'txtPartNosearch
        '
        Me.txtPartNosearch.Location = New System.Drawing.Point(148, 115)
        Me.txtPartNosearch.Name = "txtPartNosearch"
        Me.txtPartNosearch.Size = New System.Drawing.Size(172, 20)
        Me.txtPartNosearch.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(136, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = ":"
        '
        'lblPartNo
        '
        Me.lblPartNo.AutoSize = True
        Me.lblPartNo.BackColor = System.Drawing.Color.Transparent
        Me.lblPartNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNo.Location = New System.Drawing.Point(15, 115)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Size = New System.Drawing.Size(55, 13)
        Me.lblPartNo.TabIndex = 68
        Me.lblPartNo.Text = "Part No"
        '
        'txtStockDescsearch
        '
        Me.txtStockDescsearch.Location = New System.Drawing.Point(148, 89)
        Me.txtStockDescsearch.Name = "txtStockDescsearch"
        Me.txtStockDescsearch.Size = New System.Drawing.Size(172, 20)
        Me.txtStockDescsearch.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(136, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 14)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = ":"
        '
        'lblStockDesc
        '
        Me.lblStockDesc.AutoSize = True
        Me.lblStockDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblStockDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockDesc.Location = New System.Drawing.Point(15, 89)
        Me.lblStockDesc.Name = "lblStockDesc"
        Me.lblStockDesc.Size = New System.Drawing.Size(121, 13)
        Me.lblStockDesc.TabIndex = 65
        Me.lblStockDesc.Text = "Stock Description"
        '
        'lblStockCode
        '
        Me.lblStockCode.AutoSize = True
        Me.lblStockCode.BackColor = System.Drawing.Color.Transparent
        Me.lblStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockCode.Location = New System.Drawing.Point(15, 66)
        Me.lblStockCode.Name = "lblStockCode"
        Me.lblStockCode.Size = New System.Drawing.Size(79, 13)
        Me.lblStockCode.TabIndex = 64
        Me.lblStockCode.Text = "Stock Code"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(367, 115)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 5
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(136, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = ":"
        '
        'lblSearchby
        '
        Me.lblSearchby.AutoSize = True
        Me.lblSearchby.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchby.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchby.Location = New System.Drawing.Point(4, 42)
        Me.lblSearchby.Name = "lblSearchby"
        Me.lblSearchby.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchby.TabIndex = 54
        Me.lblSearchby.Text = "Search By"
        '
        'btnStcokCodeSearch
        '
        Me.btnStcokCodeSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnStcokCodeSearch.BackgroundImage = CType(resources.GetObject("btnStcokCodeSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnStcokCodeSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnStcokCodeSearch.FlatAppearance.BorderSize = 0
        Me.btnStcokCodeSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnStcokCodeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStcokCodeSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStcokCodeSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStcokCodeSearch.Location = New System.Drawing.Point(332, 115)
        Me.btnStcokCodeSearch.Name = "btnStcokCodeSearch"
        Me.btnStcokCodeSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnStcokCodeSearch.TabIndex = 4
        Me.btnStcokCodeSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStcokCodeSearch.UseVisualStyleBackColor = False
        '
        'txtStockCodesearch
        '
        Me.txtStockCodesearch.Location = New System.Drawing.Point(148, 64)
        Me.txtStockCodesearch.Name = "txtStockCodesearch"
        Me.txtStockCodesearch.Size = New System.Drawing.Size(172, 20)
        Me.txtStockCodesearch.TabIndex = 1
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(32, 140)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 111
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvStockCode)
        Me.Panel1.Controls.Add(Me.lblNoRecord)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 141)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(815, 363)
        Me.Panel1.TabIndex = 112
        '
        'dgvStockCode
        '
        Me.dgvStockCode.AllowUserToAddRows = False
        Me.dgvStockCode.AllowUserToDeleteRows = False
        Me.dgvStockCode.AllowUserToOrderColumns = True
        Me.dgvStockCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvStockCode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvStockCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvStockCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStockCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStockCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvStockCode, Me.gvStockID, Me.gvStockDesc, Me.gvUnitPrice, Me.gvLastPurchasePrice, Me.gvAvailableQty, Me.gvUnit, Me.gvPartNo, Me.gvUnitDesc, Me.gvMinQty, Me.gvMaxQty, Me.gvReOrderQty, Me.gvAccountCode, Me.gvAccountDesc, Me.gvStockCOAID, Me.gvVarianceCOAID, Me.gvUom})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStockCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvStockCode.EnableHeadersVisualStyles = False
        Me.dgvStockCode.GridColor = System.Drawing.Color.Gray
        Me.dgvStockCode.Location = New System.Drawing.Point(3, 0)
        Me.dgvStockCode.MultiSelect = False
        Me.dgvStockCode.Name = "dgvStockCode"
        Me.dgvStockCode.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStockCode.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvStockCode.RowHeadersVisible = False
        Me.dgvStockCode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvStockCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStockCode.Size = New System.Drawing.Size(815, 360)
        Me.dgvStockCode.TabIndex = 6
        Me.dgvStockCode.TabStop = False
        '
        'gvStockCode
        '
        Me.gvStockCode.DataPropertyName = "StockCode"
        Me.gvStockCode.HeaderText = "Stock Code"
        Me.gvStockCode.Name = "gvStockCode"
        Me.gvStockCode.ReadOnly = True
        Me.gvStockCode.Width = 97
        '
        'gvStockID
        '
        Me.gvStockID.DataPropertyName = "StockID"
        Me.gvStockID.HeaderText = "Stock ID"
        Me.gvStockID.Name = "gvStockID"
        Me.gvStockID.ReadOnly = True
        Me.gvStockID.Visible = False
        Me.gvStockID.Width = 81
        '
        'gvStockDesc
        '
        Me.gvStockDesc.DataPropertyName = "StockDesc"
        Me.gvStockDesc.HeaderText = "Stock Description"
        Me.gvStockDesc.Name = "gvStockDesc"
        Me.gvStockDesc.ReadOnly = True
        Me.gvStockDesc.Width = 131
        '
        'gvUnitPrice
        '
        Me.gvUnitPrice.DataPropertyName = "UnitPrice"
        Me.gvUnitPrice.HeaderText = "Unit Price"
        Me.gvUnitPrice.Name = "gvUnitPrice"
        Me.gvUnitPrice.ReadOnly = True
        Me.gvUnitPrice.Visible = False
        Me.gvUnitPrice.Width = 85
        '
        'gvLastPurchasePrice
        '
        Me.gvLastPurchasePrice.DataPropertyName = "LastPurchasePrice"
        Me.gvLastPurchasePrice.HeaderText = "Las tPurchase Price"
        Me.gvLastPurchasePrice.Name = "gvLastPurchasePrice"
        Me.gvLastPurchasePrice.ReadOnly = True
        Me.gvLastPurchasePrice.Width = 142
        '
        'gvAvailableQty
        '
        Me.gvAvailableQty.DataPropertyName = "AvailableQty"
        Me.gvAvailableQty.HeaderText = "AvailableQty"
        Me.gvAvailableQty.Name = "gvAvailableQty"
        Me.gvAvailableQty.ReadOnly = True
        Me.gvAvailableQty.Width = 103
        '
        'gvUnit
        '
        Me.gvUnit.DataPropertyName = "UOM"
        Me.gvUnit.HeaderText = "Unit"
        Me.gvUnit.Name = "gvUnit"
        Me.gvUnit.ReadOnly = True
        Me.gvUnit.Width = 53
        '
        'gvPartNo
        '
        Me.gvPartNo.DataPropertyName = "PartNo"
        Me.gvPartNo.HeaderText = "PartNo"
        Me.gvPartNo.Name = "gvPartNo"
        Me.gvPartNo.ReadOnly = True
        Me.gvPartNo.Width = 69
        '
        'gvUnitDesc
        '
        Me.gvUnitDesc.DataPropertyName = "Description"
        Me.gvUnitDesc.HeaderText = "Unit Description"
        Me.gvUnitDesc.Name = "gvUnitDesc"
        Me.gvUnitDesc.ReadOnly = True
        Me.gvUnitDesc.Width = 121
        '
        'gvMinQty
        '
        Me.gvMinQty.DataPropertyName = "MinQty"
        Me.gvMinQty.HeaderText = "MinQty"
        Me.gvMinQty.Name = "gvMinQty"
        Me.gvMinQty.ReadOnly = True
        Me.gvMinQty.Width = 70
        '
        'gvMaxQty
        '
        Me.gvMaxQty.DataPropertyName = "MaxQty"
        Me.gvMaxQty.HeaderText = "MaxQty"
        Me.gvMaxQty.Name = "gvMaxQty"
        Me.gvMaxQty.ReadOnly = True
        Me.gvMaxQty.Width = 74
        '
        'gvReOrderQty
        '
        Me.gvReOrderQty.DataPropertyName = "ReOrderQty"
        Me.gvReOrderQty.HeaderText = "ReOrder Qty"
        Me.gvReOrderQty.Name = "gvReOrderQty"
        Me.gvReOrderQty.ReadOnly = True
        Me.gvReOrderQty.Width = 103
        '
        'gvAccountCode
        '
        Me.gvAccountCode.DataPropertyName = "AccountCode"
        Me.gvAccountCode.HeaderText = "AccountCode"
        Me.gvAccountCode.Name = "gvAccountCode"
        Me.gvAccountCode.ReadOnly = True
        Me.gvAccountCode.Visible = False
        Me.gvAccountCode.Width = 106
        '
        'gvAccountDesc
        '
        Me.gvAccountDesc.DataPropertyName = "AccountDesc"
        Me.gvAccountDesc.HeaderText = "AccountDesc"
        Me.gvAccountDesc.Name = "gvAccountDesc"
        Me.gvAccountDesc.ReadOnly = True
        Me.gvAccountDesc.Visible = False
        Me.gvAccountDesc.Width = 104
        '
        'gvStockCOAID
        '
        Me.gvStockCOAID.DataPropertyName = "StockCOAID"
        Me.gvStockCOAID.HeaderText = "StockCOAID"
        Me.gvStockCOAID.Name = "gvStockCOAID"
        Me.gvStockCOAID.ReadOnly = True
        Me.gvStockCOAID.Visible = False
        Me.gvStockCOAID.Width = 103
        '
        'gvVarianceCOAID
        '
        Me.gvVarianceCOAID.DataPropertyName = "VarianceCOAID"
        Me.gvVarianceCOAID.HeaderText = "VarianceCOAID"
        Me.gvVarianceCOAID.Name = "gvVarianceCOAID"
        Me.gvVarianceCOAID.ReadOnly = True
        Me.gvVarianceCOAID.Visible = False
        Me.gvVarianceCOAID.Width = 121
        '
        'gvUom
        '
        Me.gvUom.DataPropertyName = "UOM"
        Me.gvUom.HeaderText = "UOM"
        Me.gvUom.Name = "gvUom"
        Me.gvUom.ReadOnly = True
        Me.gvUom.Width = 57
        '
        'StockCodeLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(815, 500)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlStockCodeSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "StockCodeLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Code Lookup"
        Me.pnlStockCodeSearch.ResumeLayout(False)
        Me.pnlStockCodeSearch.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvStockCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlStockCodeSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSearchby As System.Windows.Forms.Label
    Friend WithEvents btnStcokCodeSearch As System.Windows.Forms.Button
    Friend WithEvents txtStockCodesearch As System.Windows.Forms.TextBox
    Friend WithEvents lblStockCode As System.Windows.Forms.Label
    Friend WithEvents txtStockDescsearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStockDesc As System.Windows.Forms.Label
    Friend WithEvents txtPartNosearch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPartNo As System.Windows.Forms.Label
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvStockCode As System.Windows.Forms.DataGridView
    Friend WithEvents gvStockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvStockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvStockDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvLastPurchasePrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvAvailableQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvUnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvMinQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvMaxQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvReOrderQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvAccountCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvAccountDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvStockCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvVarianceCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvUom As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

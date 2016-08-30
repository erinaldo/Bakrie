<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockCodeByCategoryLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockCodeByCategoryLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlStockCodeSearch = New Stepi.UI.ExtendedPanel()
        Me.cmbStockCategory = New System.Windows.Forms.ComboBox()
        Me.txtPartNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkSelectAllCategory = New System.Windows.Forms.CheckBox()
        Me.lblPartNo = New System.Windows.Forms.Label()
        Me.lblStockCategory = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStockDescsearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStockDesc = New System.Windows.Forms.Label()
        Me.lblStockCode = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblSearchby = New System.Windows.Forms.Label()
        Me.txtStockCodesearch = New System.Windows.Forms.TextBox()
        Me.btnStcokCodeSearch = New System.Windows.Forms.Button()
        Me.dgvStockCode = New System.Windows.Forms.DataGridView()
        Me.gvSTCategoryDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvStockCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvStockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvStockDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvStockCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvVarianceCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblNoRecord = New System.Windows.Forms.Label()
        Me.pnlStockCodeSearch.SuspendLayout()
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
        Me.pnlStockCodeSearch.Controls.Add(Me.cmbStockCategory)
        Me.pnlStockCodeSearch.Controls.Add(Me.txtPartNo)
        Me.pnlStockCodeSearch.Controls.Add(Me.Label2)
        Me.pnlStockCodeSearch.Controls.Add(Me.chkSelectAllCategory)
        Me.pnlStockCodeSearch.Controls.Add(Me.lblPartNo)
        Me.pnlStockCodeSearch.Controls.Add(Me.lblStockCategory)
        Me.pnlStockCodeSearch.Controls.Add(Me.Label6)
        Me.pnlStockCodeSearch.Controls.Add(Me.txtStockDescsearch)
        Me.pnlStockCodeSearch.Controls.Add(Me.Label1)
        Me.pnlStockCodeSearch.Controls.Add(Me.lblStockDesc)
        Me.pnlStockCodeSearch.Controls.Add(Me.lblStockCode)
        Me.pnlStockCodeSearch.Controls.Add(Me.Label4)
        Me.pnlStockCodeSearch.Controls.Add(Me.btnClose)
        Me.pnlStockCodeSearch.Controls.Add(Me.lblSearchby)
        Me.pnlStockCodeSearch.Controls.Add(Me.txtStockCodesearch)
        Me.pnlStockCodeSearch.Controls.Add(Me.btnStcokCodeSearch)
        Me.pnlStockCodeSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlStockCodeSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlStockCodeSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlStockCodeSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlStockCodeSearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlStockCodeSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlStockCodeSearch.Name = "pnlStockCodeSearch"
        Me.pnlStockCodeSearch.Size = New System.Drawing.Size(850, 119)
        Me.pnlStockCodeSearch.TabIndex = 13
        '
        'cmbStockCategory
        '
        Me.cmbStockCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStockCategory.Enabled = False
        Me.cmbStockCategory.FormattingEnabled = True
        Me.cmbStockCategory.Location = New System.Drawing.Point(459, 66)
        Me.cmbStockCategory.Name = "cmbStockCategory"
        Me.cmbStockCategory.Size = New System.Drawing.Size(172, 21)
        Me.cmbStockCategory.TabIndex = 3
        '
        'txtPartNo
        '
        Me.txtPartNo.Location = New System.Drawing.Point(459, 90)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(172, 20)
        Me.txtPartNo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(447, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = ":"
        '
        'chkSelectAllCategory
        '
        Me.chkSelectAllCategory.AutoSize = True
        Me.chkSelectAllCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSelectAllCategory.ForeColor = System.Drawing.Color.DimGray
        Me.chkSelectAllCategory.Location = New System.Drawing.Point(637, 93)
        Me.chkSelectAllCategory.Name = "chkSelectAllCategory"
        Me.chkSelectAllCategory.Size = New System.Drawing.Size(154, 17)
        Me.chkSelectAllCategory.TabIndex = 5
        Me.chkSelectAllCategory.Text = "Select All Category "
        Me.chkSelectAllCategory.UseVisualStyleBackColor = True
        '
        'lblPartNo
        '
        Me.lblPartNo.AutoSize = True
        Me.lblPartNo.BackColor = System.Drawing.Color.Transparent
        Me.lblPartNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNo.Location = New System.Drawing.Point(326, 90)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Size = New System.Drawing.Size(51, 13)
        Me.lblPartNo.TabIndex = 71
        Me.lblPartNo.Text = "PartNo"
        '
        'lblStockCategory
        '
        Me.lblStockCategory.AutoSize = True
        Me.lblStockCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblStockCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockCategory.Location = New System.Drawing.Point(326, 67)
        Me.lblStockCategory.Name = "lblStockCategory"
        Me.lblStockCategory.Size = New System.Drawing.Size(106, 13)
        Me.lblStockCategory.TabIndex = 70
        Me.lblStockCategory.Text = "Stock Category"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(447, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = ":"
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
        Me.btnClose.Location = New System.Drawing.Point(670, 63)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 7
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
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
        'txtStockCodesearch
        '
        Me.txtStockCodesearch.Location = New System.Drawing.Point(148, 64)
        Me.txtStockCodesearch.Name = "txtStockCodesearch"
        Me.txtStockCodesearch.Size = New System.Drawing.Size(172, 20)
        Me.txtStockCodesearch.TabIndex = 1
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
        Me.btnStcokCodeSearch.Location = New System.Drawing.Point(635, 63)
        Me.btnStcokCodeSearch.Name = "btnStcokCodeSearch"
        Me.btnStcokCodeSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnStcokCodeSearch.TabIndex = 6
        Me.btnStcokCodeSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStcokCodeSearch.UseVisualStyleBackColor = False
        '
        'dgvStockCode
        '
        Me.dgvStockCode.AllowUserToAddRows = False
        Me.dgvStockCode.AllowUserToDeleteRows = False
        Me.dgvStockCode.AllowUserToOrderColumns = True
        Me.dgvStockCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvStockCode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvStockCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvStockCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvStockCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStockCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStockCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvSTCategoryDescp, Me.gvStockCode, Me.gvStockID, Me.gvStockDesc, Me.gvPartNo, Me.gvStockCOAID, Me.gvVarianceCOAID})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStockCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvStockCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStockCode.EnableHeadersVisualStyles = False
        Me.dgvStockCode.GridColor = System.Drawing.Color.Gray
        Me.dgvStockCode.Location = New System.Drawing.Point(0, 119)
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
        Me.dgvStockCode.Size = New System.Drawing.Size(850, 377)
        Me.dgvStockCode.TabIndex = 8
        Me.dgvStockCode.TabStop = False
        '
        'gvSTCategoryDescp
        '
        Me.gvSTCategoryDescp.DataPropertyName = "STCategoryDescp"
        Me.gvSTCategoryDescp.HeaderText = "Stock Category"
        Me.gvSTCategoryDescp.Name = "gvSTCategoryDescp"
        Me.gvSTCategoryDescp.ReadOnly = True
        Me.gvSTCategoryDescp.Width = 120
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
        'gvPartNo
        '
        Me.gvPartNo.DataPropertyName = "PartNo"
        Me.gvPartNo.HeaderText = "PartNo"
        Me.gvPartNo.Name = "gvPartNo"
        Me.gvPartNo.ReadOnly = True
        Me.gvPartNo.Width = 69
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
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(363, 242)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 112
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'StockCodeByCategoryLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(850, 496)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgvStockCode)
        Me.Controls.Add(Me.pnlStockCodeSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "StockCodeByCategoryLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Code Lookup"
        Me.pnlStockCodeSearch.ResumeLayout(False)
        Me.pnlStockCodeSearch.PerformLayout()
        CType(Me.dgvStockCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlStockCodeSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSearchby As System.Windows.Forms.Label
    Friend WithEvents btnStcokCodeSearch As System.Windows.Forms.Button
    Friend WithEvents txtStockCodesearch As System.Windows.Forms.TextBox
    Friend WithEvents dgvStockCode As System.Windows.Forms.DataGridView
    Friend WithEvents lblStockCode As System.Windows.Forms.Label
    Friend WithEvents txtStockDescsearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStockDesc As System.Windows.Forms.Label
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPartNo As System.Windows.Forms.Label
    Friend WithEvents lblStockCategory As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbStockCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents chkSelectAllCategory As System.Windows.Forms.CheckBox
    Friend WithEvents gvSTCategoryDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvStockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvStockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvStockDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvStockCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvVarianceCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsignmentStockLookUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsignmentStockLookUp))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlStockCodeLookupSearch = New Stepi.UI.ExtendedPanel
        Me.txtConsignmentStockDescsearch = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblStockDesc = New System.Windows.Forms.Label
        Me.lblStockCode = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblSearchby = New System.Windows.Forms.Label
        Me.btnStcokCodeSearch = New System.Windows.Forms.Button
        Me.txtConsignmentStockSearch = New System.Windows.Forms.TextBox
        Me.lblNoRecordFound = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgvConsignmentStockCode = New System.Windows.Forms.DataGridView
        Me.STConsignmentMasterID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UOM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlStockCodeLookupSearch.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvConsignmentStockCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlStockCodeLookupSearch
        '
        Me.pnlStockCodeLookupSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlStockCodeLookupSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlStockCodeLookupSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlStockCodeLookupSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlStockCodeLookupSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlStockCodeLookupSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlStockCodeLookupSearch.CaptionSize = 40
        Me.pnlStockCodeLookupSearch.CaptionText = "Search Consignment Stock Code"
        Me.pnlStockCodeLookupSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlStockCodeLookupSearch.Controls.Add(Me.txtConsignmentStockDescsearch)
        Me.pnlStockCodeLookupSearch.Controls.Add(Me.Label1)
        Me.pnlStockCodeLookupSearch.Controls.Add(Me.lblStockDesc)
        Me.pnlStockCodeLookupSearch.Controls.Add(Me.lblStockCode)
        Me.pnlStockCodeLookupSearch.Controls.Add(Me.btnClose)
        Me.pnlStockCodeLookupSearch.Controls.Add(Me.Label4)
        Me.pnlStockCodeLookupSearch.Controls.Add(Me.lblSearchby)
        Me.pnlStockCodeLookupSearch.Controls.Add(Me.btnStcokCodeSearch)
        Me.pnlStockCodeLookupSearch.Controls.Add(Me.txtConsignmentStockSearch)
        Me.pnlStockCodeLookupSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlStockCodeLookupSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlStockCodeLookupSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlStockCodeLookupSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlStockCodeLookupSearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlStockCodeLookupSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlStockCodeLookupSearch.Name = "pnlStockCodeLookupSearch"
        Me.pnlStockCodeLookupSearch.Size = New System.Drawing.Size(511, 119)
        Me.pnlStockCodeLookupSearch.TabIndex = 13
        '
        'txtConsignmentStockDescsearch
        '
        Me.txtConsignmentStockDescsearch.Location = New System.Drawing.Point(148, 89)
        Me.txtConsignmentStockDescsearch.Name = "txtConsignmentStockDescsearch"
        Me.txtConsignmentStockDescsearch.Size = New System.Drawing.Size(172, 20)
        Me.txtConsignmentStockDescsearch.TabIndex = 2
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
        Me.btnClose.Location = New System.Drawing.Point(367, 83)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 4
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
        Me.btnStcokCodeSearch.Location = New System.Drawing.Point(332, 83)
        Me.btnStcokCodeSearch.Name = "btnStcokCodeSearch"
        Me.btnStcokCodeSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnStcokCodeSearch.TabIndex = 3
        Me.btnStcokCodeSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStcokCodeSearch.UseVisualStyleBackColor = False
        '
        'txtConsignmentStockSearch
        '
        Me.txtConsignmentStockSearch.Location = New System.Drawing.Point(148, 64)
        Me.txtConsignmentStockSearch.Name = "txtConsignmentStockSearch"
        Me.txtConsignmentStockSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtConsignmentStockSearch.TabIndex = 1
        '
        'lblNoRecordFound
        '
        Me.lblNoRecordFound.AutoSize = True
        Me.lblNoRecordFound.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblNoRecordFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecordFound.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecordFound.Location = New System.Drawing.Point(136, 87)
        Me.lblNoRecordFound.Name = "lblNoRecordFound"
        Me.lblNoRecordFound.Size = New System.Drawing.Size(119, 13)
        Me.lblNoRecordFound.TabIndex = 4
        Me.lblNoRecordFound.Text = "No Record Found !."
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvConsignmentStockCode)
        Me.Panel1.Controls.Add(Me.lblNoRecordFound)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 119)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(511, 295)
        Me.Panel1.TabIndex = 14
        '
        'dgvConsignmentStockCode
        '
        Me.dgvConsignmentStockCode.AllowUserToAddRows = False
        Me.dgvConsignmentStockCode.AllowUserToDeleteRows = False
        Me.dgvConsignmentStockCode.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvConsignmentStockCode.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvConsignmentStockCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvConsignmentStockCode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvConsignmentStockCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvConsignmentStockCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvConsignmentStockCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsignmentStockCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvConsignmentStockCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.STConsignmentMasterID, Me.STCode, Me.STDesc, Me.Qty, Me.PartNo, Me.UOM})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvConsignmentStockCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvConsignmentStockCode.EnableHeadersVisualStyles = False
        Me.dgvConsignmentStockCode.GridColor = System.Drawing.Color.Gray
        Me.dgvConsignmentStockCode.Location = New System.Drawing.Point(1, 0)
        Me.dgvConsignmentStockCode.MultiSelect = False
        Me.dgvConsignmentStockCode.Name = "dgvConsignmentStockCode"
        Me.dgvConsignmentStockCode.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsignmentStockCode.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvConsignmentStockCode.RowHeadersVisible = False
        Me.dgvConsignmentStockCode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvConsignmentStockCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConsignmentStockCode.ShowCellErrors = False
        Me.dgvConsignmentStockCode.ShowRowErrors = False
        Me.dgvConsignmentStockCode.Size = New System.Drawing.Size(510, 295)
        Me.dgvConsignmentStockCode.TabIndex = 6
        '
        'STConsignmentMasterID
        '
        Me.STConsignmentMasterID.DataPropertyName = "STConsignmentMasterID"
        Me.STConsignmentMasterID.HeaderText = "STConsignmentMasterID"
        Me.STConsignmentMasterID.Name = "STConsignmentMasterID"
        Me.STConsignmentMasterID.ReadOnly = True
        Me.STConsignmentMasterID.Visible = False
        Me.STConsignmentMasterID.Width = 173
        '
        'STCode
        '
        Me.STCode.DataPropertyName = "STCode"
        Me.STCode.HeaderText = "StockCode"
        Me.STCode.Name = "STCode"
        Me.STCode.ReadOnly = True
        Me.STCode.Width = 93
        '
        'STDesc
        '
        Me.STDesc.DataPropertyName = "STDesc"
        Me.STDesc.HeaderText = "Stock Code Description"
        Me.STDesc.Name = "STDesc"
        Me.STDesc.ReadOnly = True
        Me.STDesc.Width = 165
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 51
        '
        'PartNo
        '
        Me.PartNo.DataPropertyName = "PartNo"
        Me.PartNo.HeaderText = "Part No"
        Me.PartNo.Name = "PartNo"
        Me.PartNo.ReadOnly = True
        Me.PartNo.Width = 73
        '
        'UOM
        '
        Me.UOM.DataPropertyName = "UOM"
        Me.UOM.HeaderText = "UOM"
        Me.UOM.Name = "UOM"
        Me.UOM.ReadOnly = True
        Me.UOM.Width = 57
        '
        'ConsignmentStockLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(511, 415)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlStockCodeLookupSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "ConsignmentStockLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Code"
        Me.pnlStockCodeLookupSearch.ResumeLayout(False)
        Me.pnlStockCodeLookupSearch.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvConsignmentStockCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlStockCodeLookupSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSearchby As System.Windows.Forms.Label
    Friend WithEvents btnStcokCodeSearch As System.Windows.Forms.Button
    Friend WithEvents txtConsignmentStockSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblStockCode As System.Windows.Forms.Label
    Friend WithEvents txtConsignmentStockDescsearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStockDesc As System.Windows.Forms.Label
    Friend WithEvents lblNoRecordFound As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvConsignmentStockCode As System.Windows.Forms.DataGridView
    Friend WithEvents STConsignmentMasterID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

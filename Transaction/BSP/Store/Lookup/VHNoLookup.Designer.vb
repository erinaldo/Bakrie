<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VHNoLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VHNoLookup))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panVHNoLookUp = New Stepi.UI.ExtendedPanel
        Me.lblVHType = New System.Windows.Forms.Label
        Me.cmbVHType = New System.Windows.Forms.ComboBox
        Me.lblVHCategory = New System.Windows.Forms.Label
        Me.cmbVHCategory = New System.Windows.Forms.ComboBox
        Me.lblVechileDesc = New System.Windows.Forms.Label
        Me.txtVHDescSearch = New System.Windows.Forms.TextBox
        Me.lblVHNo = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnVHNoSearch = New System.Windows.Forms.Button
        Me.lblsearchVHNo = New System.Windows.Forms.Label
        Me.txtVHNoSearch = New System.Windows.Forms.TextBox
        Me.dgVHNo = New System.Windows.Forms.DataGridView
        Me.dgclCategory = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVHCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVHNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVHID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVHDescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclUOM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.panVHNoLookUp.SuspendLayout()
        CType(Me.dgVHNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panVHNoLookUp
        '
        Me.panVHNoLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panVHNoLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panVHNoLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panVHNoLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panVHNoLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panVHNoLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panVHNoLookUp.CaptionSize = 40
        Me.panVHNoLookUp.CaptionText = "Select VHNo"
        Me.panVHNoLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panVHNoLookUp.Controls.Add(Me.lblVHType)
        Me.panVHNoLookUp.Controls.Add(Me.cmbVHType)
        Me.panVHNoLookUp.Controls.Add(Me.lblVHCategory)
        Me.panVHNoLookUp.Controls.Add(Me.cmbVHCategory)
        Me.panVHNoLookUp.Controls.Add(Me.lblVechileDesc)
        Me.panVHNoLookUp.Controls.Add(Me.txtVHDescSearch)
        Me.panVHNoLookUp.Controls.Add(Me.lblVHNo)
        Me.panVHNoLookUp.Controls.Add(Me.btnClose)
        Me.panVHNoLookUp.Controls.Add(Me.btnVHNoSearch)
        Me.panVHNoLookUp.Controls.Add(Me.lblsearchVHNo)
        Me.panVHNoLookUp.Controls.Add(Me.txtVHNoSearch)
        Me.panVHNoLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panVHNoLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panVHNoLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panVHNoLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panVHNoLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panVHNoLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panVHNoLookUp.Name = "panVHNoLookUp"
        Me.panVHNoLookUp.Size = New System.Drawing.Size(546, 176)
        Me.panVHNoLookUp.TabIndex = 16
        '
        'lblVHType
        '
        Me.lblVHType.AutoSize = True
        Me.lblVHType.BackColor = System.Drawing.Color.Transparent
        Me.lblVHType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHType.Location = New System.Drawing.Point(184, 112)
        Me.lblVHType.Name = "lblVHType"
        Me.lblVHType.Size = New System.Drawing.Size(60, 13)
        Me.lblVHType.TabIndex = 111
        Me.lblVHType.Text = "VH Type"
        '
        'cmbVHType
        '
        Me.cmbVHType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVHType.FormattingEnabled = True
        Me.cmbVHType.Items.AddRange(New Object() {"--Select VH Type--", "Vehicle", "Workshop", "Others", "NOWorkshop"})
        Me.cmbVHType.Location = New System.Drawing.Point(184, 128)
        Me.cmbVHType.Name = "cmbVHType"
        Me.cmbVHType.Size = New System.Drawing.Size(172, 21)
        Me.cmbVHType.TabIndex = 4
        '
        'lblVHCategory
        '
        Me.lblVHCategory.AutoSize = True
        Me.lblVHCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblVHCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHCategory.Location = New System.Drawing.Point(3, 112)
        Me.lblVHCategory.Name = "lblVHCategory"
        Me.lblVHCategory.Size = New System.Drawing.Size(87, 13)
        Me.lblVHCategory.TabIndex = 109
        Me.lblVHCategory.Text = "VH Category"
        '
        'cmbVHCategory
        '
        Me.cmbVHCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVHCategory.FormattingEnabled = True
        Me.cmbVHCategory.Location = New System.Drawing.Point(3, 128)
        Me.cmbVHCategory.Name = "cmbVHCategory"
        Me.cmbVHCategory.Size = New System.Drawing.Size(172, 21)
        Me.cmbVHCategory.TabIndex = 3
        '
        'lblVechileDesc
        '
        Me.lblVechileDesc.AutoSize = True
        Me.lblVechileDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblVechileDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVechileDesc.Location = New System.Drawing.Point(184, 72)
        Me.lblVechileDesc.Name = "lblVechileDesc"
        Me.lblVechileDesc.Size = New System.Drawing.Size(132, 13)
        Me.lblVechileDesc.TabIndex = 106
        Me.lblVechileDesc.Text = "Vehicle Description"
        '
        'txtVHDescSearch
        '
        Me.txtVHDescSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtVHDescSearch.Location = New System.Drawing.Point(184, 90)
        Me.txtVHDescSearch.Name = "txtVHDescSearch"
        Me.txtVHDescSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtVHDescSearch.TabIndex = 2
        '
        'lblVHNo
        '
        Me.lblVHNo.AutoSize = True
        Me.lblVHNo.BackColor = System.Drawing.Color.Transparent
        Me.lblVHNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHNo.Location = New System.Drawing.Point(3, 71)
        Me.lblVHNo.Name = "lblVHNo"
        Me.lblVHNo.Size = New System.Drawing.Size(41, 13)
        Me.lblVHNo.TabIndex = 104
        Me.lblVHNo.Text = "VHNo"
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
        Me.btnClose.Location = New System.Drawing.Point(400, 85)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 6
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnVHNoSearch
        '
        Me.btnVHNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnVHNoSearch.BackgroundImage = CType(resources.GetObject("btnVHNoSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnVHNoSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnVHNoSearch.FlatAppearance.BorderSize = 0
        Me.btnVHNoSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnVHNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVHNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVHNoSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVHNoSearch.Location = New System.Drawing.Point(365, 85)
        Me.btnVHNoSearch.Name = "btnVHNoSearch"
        Me.btnVHNoSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnVHNoSearch.TabIndex = 5
        Me.btnVHNoSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVHNoSearch.UseVisualStyleBackColor = False
        '
        'lblsearchVHNo
        '
        Me.lblsearchVHNo.AutoSize = True
        Me.lblsearchVHNo.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchVHNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchVHNo.Location = New System.Drawing.Point(3, 45)
        Me.lblsearchVHNo.Name = "lblsearchVHNo"
        Me.lblsearchVHNo.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchVHNo.TabIndex = 54
        Me.lblsearchVHNo.Text = "Search By"
        '
        'txtVHNoSearch
        '
        Me.txtVHNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtVHNoSearch.Location = New System.Drawing.Point(3, 89)
        Me.txtVHNoSearch.Name = "txtVHNoSearch"
        Me.txtVHNoSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtVHNoSearch.TabIndex = 1
        '
        'dgVHNo
        '
        Me.dgVHNo.AllowUserToAddRows = False
        Me.dgVHNo.AllowUserToDeleteRows = False
        Me.dgVHNo.AllowUserToOrderColumns = True
        Me.dgVHNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgVHNo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgVHNo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgVHNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgVHNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgVHNo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgVHNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclCategory, Me.dgclVHCategoryID, Me.dgclVHNo, Me.dgclVHID, Me.dgclVHDescp, Me.dgclType, Me.dgclUOM})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgVHNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgVHNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgVHNo.EnableHeadersVisualStyles = False
        Me.dgVHNo.GridColor = System.Drawing.Color.Gray
        Me.dgVHNo.Location = New System.Drawing.Point(0, 176)
        Me.dgVHNo.MultiSelect = False
        Me.dgVHNo.Name = "dgVHNo"
        Me.dgVHNo.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgVHNo.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgVHNo.RowHeadersVisible = False
        Me.dgVHNo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgVHNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgVHNo.Size = New System.Drawing.Size(546, 287)
        Me.dgVHNo.TabIndex = 114
        '
        'dgclCategory
        '
        Me.dgclCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclCategory.DataPropertyName = "Category"
        Me.dgclCategory.HeaderText = "VH Category"
        Me.dgclCategory.Name = "dgclCategory"
        Me.dgclCategory.ReadOnly = True
        '
        'dgclVHCategoryID
        '
        Me.dgclVHCategoryID.DataPropertyName = "VHCategoryID"
        Me.dgclVHCategoryID.HeaderText = "VHCategoryID"
        Me.dgclVHCategoryID.Name = "dgclVHCategoryID"
        Me.dgclVHCategoryID.ReadOnly = True
        Me.dgclVHCategoryID.Visible = False
        Me.dgclVHCategoryID.Width = 114
        '
        'dgclVHNo
        '
        Me.dgclVHNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclVHNo.DataPropertyName = "VHNo"
        Me.dgclVHNo.HeaderText = "VHNo"
        Me.dgclVHNo.Name = "dgclVHNo"
        Me.dgclVHNo.ReadOnly = True
        '
        'dgclVHID
        '
        Me.dgclVHID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclVHID.DataPropertyName = "VHID"
        Me.dgclVHID.HeaderText = "VHID"
        Me.dgclVHID.Name = "dgclVHID"
        Me.dgclVHID.ReadOnly = True
        Me.dgclVHID.Visible = False
        Me.dgclVHID.Width = 300
        '
        'dgclVHDescp
        '
        Me.dgclVHDescp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclVHDescp.DataPropertyName = "VHDescp"
        Me.dgclVHDescp.HeaderText = "VH Descp"
        Me.dgclVHDescp.Name = "dgclVHDescp"
        Me.dgclVHDescp.ReadOnly = True
        Me.dgclVHDescp.Width = 150
        '
        'dgclType
        '
        Me.dgclType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclType.DataPropertyName = "Type"
        Me.dgclType.HeaderText = "VH Type"
        Me.dgclType.Name = "dgclType"
        Me.dgclType.ReadOnly = True
        '
        'dgclUOM
        '
        Me.dgclUOM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclUOM.DataPropertyName = "UOM"
        Me.dgclUOM.HeaderText = "UOM"
        Me.dgclUOM.Name = "dgclUOM"
        Me.dgclUOM.ReadOnly = True
        Me.dgclUOM.Width = 75
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(168, 275)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 115
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'VHNoLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(546, 463)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgVHNo)
        Me.Controls.Add(Me.panVHNoLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "VHNoLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "VH No Lookup"
        Me.panVHNoLookUp.ResumeLayout(False)
        Me.panVHNoLookUp.PerformLayout()
        CType(Me.dgVHNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panVHNoLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchVHNo As System.Windows.Forms.Label
    Friend WithEvents btnVHNoSearch As System.Windows.Forms.Button
    Friend WithEvents txtVHNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblVechileDesc As System.Windows.Forms.Label
    Friend WithEvents txtVHDescSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblVHNo As System.Windows.Forms.Label
    Friend WithEvents lblVHType As System.Windows.Forms.Label
    Friend WithEvents cmbVHType As System.Windows.Forms.ComboBox
    Friend WithEvents lblVHCategory As System.Windows.Forms.Label
    Friend WithEvents cmbVHCategory As System.Windows.Forms.ComboBox
    Friend WithEvents dgVHNo As System.Windows.Forms.DataGridView
    Friend WithEvents dgclCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclUOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
End Class

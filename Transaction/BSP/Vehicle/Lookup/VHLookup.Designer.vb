<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VHLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VHLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panVHNoLookUp = New Stepi.UI.ExtendedPanel
        Me.lblVHCategory = New System.Windows.Forms.Label
        Me.cmbVHCategory = New System.Windows.Forms.ComboBox
        Me.lblVechileName = New System.Windows.Forms.Label
        Me.txtVehicleName = New System.Windows.Forms.TextBox
        Me.lblVHNo = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnVHNoSearch = New System.Windows.Forms.Button
        Me.lblsearchVHNo = New System.Windows.Forms.Label
        Me.txtVHNoSearch = New System.Windows.Forms.TextBox
        Me.dgvVehicleDetails = New System.Windows.Forms.DataGridView
        Me.dgclCategory = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVHCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVHWSCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVHID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVHDescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclUOM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.panVHNoLookUp.SuspendLayout()
        CType(Me.dgvVehicleDetails, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.panVHNoLookUp.Controls.Add(Me.lblVHCategory)
        Me.panVHNoLookUp.Controls.Add(Me.cmbVHCategory)
        Me.panVHNoLookUp.Controls.Add(Me.lblVechileName)
        Me.panVHNoLookUp.Controls.Add(Me.txtVehicleName)
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
        Me.panVHNoLookUp.Size = New System.Drawing.Size(444, 176)
        Me.panVHNoLookUp.TabIndex = 16
        '
        'lblVHCategory
        '
        Me.lblVHCategory.AutoSize = True
        Me.lblVHCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblVHCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHCategory.Location = New System.Drawing.Point(3, 112)
        Me.lblVHCategory.Name = "lblVHCategory"
        Me.lblVHCategory.Size = New System.Drawing.Size(45, 13)
        Me.lblVHCategory.TabIndex = 109
        Me.lblVHCategory.Text = "Model"
        '
        'cmbVHCategory
        '
        Me.cmbVHCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVHCategory.FormattingEnabled = True
        Me.cmbVHCategory.Location = New System.Drawing.Point(3, 128)
        Me.cmbVHCategory.Name = "cmbVHCategory"
        Me.cmbVHCategory.Size = New System.Drawing.Size(172, 21)
        Me.cmbVHCategory.TabIndex = 108
        '
        'lblVechileName
        '
        Me.lblVechileName.AutoSize = True
        Me.lblVechileName.BackColor = System.Drawing.Color.Transparent
        Me.lblVechileName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVechileName.Location = New System.Drawing.Point(184, 72)
        Me.lblVechileName.Name = "lblVechileName"
        Me.lblVechileName.Size = New System.Drawing.Size(95, 13)
        Me.lblVechileName.TabIndex = 106
        Me.lblVechileName.Text = "Vehicle Name"
        '
        'txtVehicleName
        '
        Me.txtVehicleName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtVehicleName.Location = New System.Drawing.Point(184, 90)
        Me.txtVehicleName.Name = "txtVehicleName"
        Me.txtVehicleName.Size = New System.Drawing.Size(172, 20)
        Me.txtVehicleName.TabIndex = 105
        '
        'lblVHNo
        '
        Me.lblVHNo.AutoSize = True
        Me.lblVHNo.BackColor = System.Drawing.Color.Transparent
        Me.lblVHNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHNo.Location = New System.Drawing.Point(3, 71)
        Me.lblVHNo.Name = "lblVHNo"
        Me.lblVHNo.Size = New System.Drawing.Size(90, 13)
        Me.lblVHNo.TabIndex = 104
        Me.lblVHNo.Text = "Vehicle Code"
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
        Me.btnClose.TabIndex = 103
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
        Me.btnVHNoSearch.TabIndex = 102
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
        Me.txtVHNoSearch.TabIndex = 101
        '
        'dgvVehicleDetails
        '
        Me.dgvVehicleDetails.AllowUserToAddRows = False
        Me.dgvVehicleDetails.AllowUserToDeleteRows = False
        Me.dgvVehicleDetails.AllowUserToOrderColumns = True
        Me.dgvVehicleDetails.AllowUserToResizeColumns = False
        Me.dgvVehicleDetails.AllowUserToResizeRows = False
        Me.dgvVehicleDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvVehicleDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvVehicleDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVehicleDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVehicleDetails.ColumnHeadersHeight = 30
        Me.dgvVehicleDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvVehicleDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclCategory, Me.dgclVHCategoryID, Me.dgclVHWSCode, Me.dgclVHID, Me.dgclVHDescp, Me.dgclType, Me.dgclUOM})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVehicleDetails.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVehicleDetails.EnableHeadersVisualStyles = False
        Me.dgvVehicleDetails.GridColor = System.Drawing.Color.Gray
        Me.dgvVehicleDetails.Location = New System.Drawing.Point(0, 176)
        Me.dgvVehicleDetails.MultiSelect = False
        Me.dgvVehicleDetails.Name = "dgvVehicleDetails"
        Me.dgvVehicleDetails.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVehicleDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVehicleDetails.RowHeadersVisible = False
        Me.dgvVehicleDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVehicleDetails.Size = New System.Drawing.Size(444, 284)
        Me.dgvVehicleDetails.TabIndex = 17
        Me.dgvVehicleDetails.VirtualMode = True
        '
        'dgclCategory
        '
        Me.dgclCategory.DataPropertyName = "Category"
        Me.dgclCategory.HeaderText = "VHCategory"
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
        'dgclVHWSCode
        '
        Me.dgclVHWSCode.DataPropertyName = "VHWSCode"
        Me.dgclVHWSCode.HeaderText = "Vehicle Code"
        Me.dgclVHWSCode.Name = "dgclVHWSCode"
        Me.dgclVHWSCode.ReadOnly = True
        Me.dgclVHWSCode.Width = 106
        '
        'dgclVHID
        '
        Me.dgclVHID.DataPropertyName = "VHID"
        Me.dgclVHID.HeaderText = "Vehicle ID"
        Me.dgclVHID.Name = "dgclVHID"
        Me.dgclVHID.ReadOnly = True
        Me.dgclVHID.Visible = False
        Me.dgclVHID.Width = 90
        '
        'dgclVHDescp
        '
        Me.dgclVHDescp.DataPropertyName = "VHDescp"
        Me.dgclVHDescp.HeaderText = "VHDescp"
        Me.dgclVHDescp.Name = "dgclVHDescp"
        Me.dgclVHDescp.ReadOnly = True
        Me.dgclVHDescp.Width = 82
        '
        'dgclType
        '
        Me.dgclType.DataPropertyName = "Type"
        Me.dgclType.HeaderText = "VHType"
        Me.dgclType.Name = "dgclType"
        Me.dgclType.ReadOnly = True
        Me.dgclType.Width = 75
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
        Me.lblNoRecord.Location = New System.Drawing.Point(80, 233)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 113
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'VHLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(444, 460)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgvVehicleDetails)
        Me.Controls.Add(Me.panVHNoLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "VHLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "VH No Lookup"
        Me.panVHNoLookUp.ResumeLayout(False)
        Me.panVHNoLookUp.PerformLayout()
        CType(Me.dgvVehicleDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panVHNoLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchVHNo As System.Windows.Forms.Label
    Friend WithEvents btnVHNoSearch As System.Windows.Forms.Button
    Friend WithEvents txtVHNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgvVehicleDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblVechileName As System.Windows.Forms.Label
    Friend WithEvents txtVehicleName As System.Windows.Forms.TextBox
    Friend WithEvents lblVHNo As System.Windows.Forms.Label
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents lblVHCategory As System.Windows.Forms.Label
    Friend WithEvents cmbVHCategory As System.Windows.Forms.ComboBox
    Friend WithEvents dgclCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHWSCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclUOM As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

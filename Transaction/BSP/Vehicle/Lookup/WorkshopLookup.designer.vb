<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkshopLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkshopLookup))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panWorkshopLookUp = New Stepi.UI.ExtendedPanel
        Me.lblVHCategory = New System.Windows.Forms.Label
        Me.cmbVHCategory = New System.Windows.Forms.ComboBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtVehicleName = New System.Windows.Forms.TextBox
        Me.lblVHNo = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnVHNoSearch = New System.Windows.Forms.Button
        Me.lblsearchVHNo = New System.Windows.Forms.Label
        Me.txtVHNoSearch = New System.Windows.Forms.TextBox
        Me.dgvWorkshop = New System.Windows.Forms.DataGridView
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.dgclCategory = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVHCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclWorkshopVHID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVHModel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVHID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclUOM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.panWorkshopLookUp.SuspendLayout()
        CType(Me.dgvWorkshop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panWorkshopLookUp
        '
        Me.panWorkshopLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panWorkshopLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panWorkshopLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panWorkshopLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panWorkshopLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panWorkshopLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panWorkshopLookUp.CaptionSize = 40
        Me.panWorkshopLookUp.CaptionText = "Select Workshop"
        Me.panWorkshopLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panWorkshopLookUp.Controls.Add(Me.lblVHCategory)
        Me.panWorkshopLookUp.Controls.Add(Me.cmbVHCategory)
        Me.panWorkshopLookUp.Controls.Add(Me.lblName)
        Me.panWorkshopLookUp.Controls.Add(Me.txtVehicleName)
        Me.panWorkshopLookUp.Controls.Add(Me.lblVHNo)
        Me.panWorkshopLookUp.Controls.Add(Me.btnClose)
        Me.panWorkshopLookUp.Controls.Add(Me.btnVHNoSearch)
        Me.panWorkshopLookUp.Controls.Add(Me.lblsearchVHNo)
        Me.panWorkshopLookUp.Controls.Add(Me.txtVHNoSearch)
        Me.panWorkshopLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panWorkshopLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panWorkshopLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panWorkshopLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panWorkshopLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panWorkshopLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panWorkshopLookUp.Name = "panWorkshopLookUp"
        Me.panWorkshopLookUp.Size = New System.Drawing.Size(444, 176)
        Me.panWorkshopLookUp.TabIndex = 16
        '
        'lblVHCategory
        '
        Me.lblVHCategory.AutoSize = True
        Me.lblVHCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblVHCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHCategory.Location = New System.Drawing.Point(3, 112)
        Me.lblVHCategory.Name = "lblVHCategory"
        Me.lblVHCategory.Size = New System.Drawing.Size(74, 13)
        Me.lblVHCategory.TabIndex = 109
        Me.lblVHCategory.Text = "Category :"
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
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(184, 72)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(52, 13)
        Me.lblName.TabIndex = 106
        Me.lblName.Text = "Name :"
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
        Me.lblVHNo.Size = New System.Drawing.Size(116, 13)
        Me.lblVHNo.TabIndex = 104
        Me.lblVHNo.Text = "Workshop Code :"
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
        Me.lblsearchVHNo.Size = New System.Drawing.Size(80, 13)
        Me.lblsearchVHNo.TabIndex = 54
        Me.lblsearchVHNo.Text = "Search By :"
        '
        'txtVHNoSearch
        '
        Me.txtVHNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtVHNoSearch.Location = New System.Drawing.Point(3, 89)
        Me.txtVHNoSearch.Name = "txtVHNoSearch"
        Me.txtVHNoSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtVHNoSearch.TabIndex = 101
        '
        'dgvWorkshop
        '
        Me.dgvWorkshop.AllowUserToAddRows = False
        Me.dgvWorkshop.AllowUserToDeleteRows = False
        Me.dgvWorkshop.AllowUserToOrderColumns = True
        Me.dgvWorkshop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvWorkshop.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvWorkshop.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvWorkshop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvWorkshop.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWorkshop.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvWorkshop.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclCategory, Me.dgclVHCategoryID, Me.dgclWorkshopVHID, Me.dgclVHModel, Me.dgclVHID, Me.dgclType, Me.dgclUOM})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvWorkshop.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvWorkshop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWorkshop.EnableHeadersVisualStyles = False
        Me.dgvWorkshop.GridColor = System.Drawing.Color.Gray
        Me.dgvWorkshop.Location = New System.Drawing.Point(0, 176)
        Me.dgvWorkshop.MultiSelect = False
        Me.dgvWorkshop.Name = "dgvWorkshop"
        Me.dgvWorkshop.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWorkshop.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvWorkshop.RowHeadersVisible = False
        Me.dgvWorkshop.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvWorkshop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWorkshop.Size = New System.Drawing.Size(444, 284)
        Me.dgvWorkshop.TabIndex = 17
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
        'dgclWorkshopVHID
        '
        Me.dgclWorkshopVHID.DataPropertyName = "WorkshopVHID"
        Me.dgclWorkshopVHID.HeaderText = "Vehicle Code"
        Me.dgclWorkshopVHID.Name = "dgclWorkshopVHID"
        Me.dgclWorkshopVHID.ReadOnly = True
        Me.dgclWorkshopVHID.Width = 106
        '
        'dgclVHModel
        '
        Me.dgclVHModel.DataPropertyName = "VHModel"
        Me.dgclVHModel.HeaderText = "Model"
        Me.dgclVHModel.Name = "dgclVHModel"
        Me.dgclVHModel.ReadOnly = True
        Me.dgclVHModel.Width = 64
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
        'WorkshopLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(444, 460)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgvWorkshop)
        Me.Controls.Add(Me.panWorkshopLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "WorkshopLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Workshop Lookup"
        Me.panWorkshopLookUp.ResumeLayout(False)
        Me.panWorkshopLookUp.PerformLayout()
        CType(Me.dgvWorkshop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panWorkshopLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchVHNo As System.Windows.Forms.Label
    Friend WithEvents btnVHNoSearch As System.Windows.Forms.Button
    Friend WithEvents txtVHNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgvWorkshop As System.Windows.Forms.DataGridView
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtVehicleName As System.Windows.Forms.TextBox
    Friend WithEvents lblVHNo As System.Windows.Forms.Label
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents lblVHCategory As System.Windows.Forms.Label
    Friend WithEvents cmbVHCategory As System.Windows.Forms.ComboBox
    Friend WithEvents dgclCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclWorkshopVHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHModel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclUOM As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

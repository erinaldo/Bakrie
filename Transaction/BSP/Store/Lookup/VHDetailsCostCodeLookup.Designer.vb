<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VHDetailsCostCodeLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VHDetailsCostCodeLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblsearchVHDetailsCostCode = New System.Windows.Forms.Label()
        Me.dgVHDetailsCostcode = New System.Windows.Forms.DataGridView()
        Me.dgclVHDetailCostCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclVHDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclVHDetailCostCodeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnVHDetailsCostCodeSearch = New System.Windows.Forms.Button()
        Me.txtVHDetailsCostCodeSearch = New System.Windows.Forms.TextBox()
        Me.panVHDetailsCostcodeLookUp = New Stepi.UI.ExtendedPanel()
        Me.lblVHDetailsCostCode = New System.Windows.Forms.Label()
        Me.lblVHDetailsCostCodeDesc = New System.Windows.Forms.Label()
        Me.txtVHDetailsCostdesc = New System.Windows.Forms.TextBox()
        Me.lblNoRecord = New System.Windows.Forms.Label()
        CType(Me.dgVHDetailsCostcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panVHDetailsCostcodeLookUp.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btnClose.Location = New System.Drawing.Point(544, 128)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(51, 42)
        Me.btnClose.TabIndex = 104
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblsearchVHDetailsCostCode
        '
        Me.lblsearchVHDetailsCostCode.AutoSize = True
        Me.lblsearchVHDetailsCostCode.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchVHDetailsCostCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchVHDetailsCostCode.Location = New System.Drawing.Point(4, 66)
        Me.lblsearchVHDetailsCostCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsearchVHDetailsCostCode.Name = "lblsearchVHDetailsCostCode"
        Me.lblsearchVHDetailsCostCode.Size = New System.Drawing.Size(103, 20)
        Me.lblsearchVHDetailsCostCode.TabIndex = 54
        Me.lblsearchVHDetailsCostCode.Text = "Search By"
        '
        'dgVHDetailsCostcode
        '
        Me.dgVHDetailsCostcode.AllowUserToAddRows = False
        Me.dgVHDetailsCostcode.AllowUserToDeleteRows = False
        Me.dgVHDetailsCostcode.AllowUserToOrderColumns = True
        Me.dgVHDetailsCostcode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgVHDetailsCostcode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgVHDetailsCostcode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgVHDetailsCostcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgVHDetailsCostcode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgVHDetailsCostcode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgVHDetailsCostcode.ColumnHeadersHeight = 40
        Me.dgVHDetailsCostcode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclVHDetailCostCode, Me.dgclVHDescp, Me.dgclVHDetailCostCodeID, Me.dgclType})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgVHDetailsCostcode.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgVHDetailsCostcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgVHDetailsCostcode.EnableHeadersVisualStyles = False
        Me.dgVHDetailsCostcode.GridColor = System.Drawing.Color.Gray
        Me.dgVHDetailsCostcode.Location = New System.Drawing.Point(0, 243)
        Me.dgVHDetailsCostcode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgVHDetailsCostcode.MultiSelect = False
        Me.dgVHDetailsCostcode.Name = "dgVHDetailsCostcode"
        Me.dgVHDetailsCostcode.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgVHDetailsCostcode.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgVHDetailsCostcode.RowHeadersVisible = False
        Me.dgVHDetailsCostcode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgVHDetailsCostcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgVHDetailsCostcode.Size = New System.Drawing.Size(603, 486)
        Me.dgVHDetailsCostcode.TabIndex = 105
        '
        'dgclVHDetailCostCode
        '
        Me.dgclVHDetailCostCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclVHDetailCostCode.DataPropertyName = "VHDetailCostCode"
        Me.dgclVHDetailCostCode.HeaderText = "Vehicle Detail Cost Code"
        Me.dgclVHDetailCostCode.Name = "dgclVHDetailCostCode"
        Me.dgclVHDetailCostCode.ReadOnly = True
        Me.dgclVHDetailCostCode.Width = 150
        '
        'dgclVHDescp
        '
        Me.dgclVHDescp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclVHDescp.DataPropertyName = "VHDescp"
        Me.dgclVHDescp.HeaderText = "Vehicle Detail Cost code Descp"
        Me.dgclVHDescp.Name = "dgclVHDescp"
        Me.dgclVHDescp.ReadOnly = True
        Me.dgclVHDescp.Width = 200
        '
        'dgclVHDetailCostCodeID
        '
        Me.dgclVHDetailCostCodeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclVHDetailCostCodeID.DataPropertyName = "VHDetailCostCodeID"
        Me.dgclVHDetailCostCodeID.HeaderText = "Vehicle Details Cost Code ID"
        Me.dgclVHDetailCostCodeID.Name = "dgclVHDetailCostCodeID"
        Me.dgclVHDetailCostCodeID.ReadOnly = True
        Me.dgclVHDetailCostCodeID.Visible = False
        '
        'dgclType
        '
        Me.dgclType.DataPropertyName = "Type"
        Me.dgclType.HeaderText = "Type"
        Me.dgclType.Name = "dgclType"
        Me.dgclType.ReadOnly = True
        Me.dgclType.Visible = False
        Me.dgclType.Width = 73
        '
        'btnVHDetailsCostCodeSearch
        '
        Me.btnVHDetailsCostCodeSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnVHDetailsCostCodeSearch.BackgroundImage = CType(resources.GetObject("btnVHDetailsCostCodeSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnVHDetailsCostCodeSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnVHDetailsCostCodeSearch.FlatAppearance.BorderSize = 0
        Me.btnVHDetailsCostCodeSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnVHDetailsCostCodeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVHDetailsCostCodeSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVHDetailsCostCodeSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVHDetailsCostCodeSearch.Location = New System.Drawing.Point(492, 128)
        Me.btnVHDetailsCostCodeSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnVHDetailsCostCodeSearch.Name = "btnVHDetailsCostCodeSearch"
        Me.btnVHDetailsCostCodeSearch.Size = New System.Drawing.Size(40, 46)
        Me.btnVHDetailsCostCodeSearch.TabIndex = 103
        Me.btnVHDetailsCostCodeSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVHDetailsCostCodeSearch.UseVisualStyleBackColor = False
        '
        'txtVHDetailsCostCodeSearch
        '
        Me.txtVHDetailsCostCodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtVHDetailsCostCodeSearch.Location = New System.Drawing.Point(9, 137)
        Me.txtVHDetailsCostCodeSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtVHDetailsCostCodeSearch.Name = "txtVHDetailsCostCodeSearch"
        Me.txtVHDetailsCostCodeSearch.Size = New System.Drawing.Size(256, 26)
        Me.txtVHDetailsCostCodeSearch.TabIndex = 101
        '
        'panVHDetailsCostcodeLookUp
        '
        Me.panVHDetailsCostcodeLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panVHDetailsCostcodeLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panVHDetailsCostcodeLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panVHDetailsCostcodeLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panVHDetailsCostcodeLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panVHDetailsCostcodeLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panVHDetailsCostcodeLookUp.CaptionSize = 40
        Me.panVHDetailsCostcodeLookUp.CaptionText = "Select Vehicle Details Cost Code"
        Me.panVHDetailsCostcodeLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panVHDetailsCostcodeLookUp.Controls.Add(Me.lblVHDetailsCostCode)
        Me.panVHDetailsCostcodeLookUp.Controls.Add(Me.lblVHDetailsCostCodeDesc)
        Me.panVHDetailsCostcodeLookUp.Controls.Add(Me.txtVHDetailsCostdesc)
        Me.panVHDetailsCostcodeLookUp.Controls.Add(Me.lblsearchVHDetailsCostCode)
        Me.panVHDetailsCostcodeLookUp.Controls.Add(Me.btnClose)
        Me.panVHDetailsCostcodeLookUp.Controls.Add(Me.btnVHDetailsCostCodeSearch)
        Me.panVHDetailsCostcodeLookUp.Controls.Add(Me.txtVHDetailsCostCodeSearch)
        Me.panVHDetailsCostcodeLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panVHDetailsCostcodeLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panVHDetailsCostcodeLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panVHDetailsCostcodeLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panVHDetailsCostcodeLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panVHDetailsCostcodeLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panVHDetailsCostcodeLookUp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.panVHDetailsCostcodeLookUp.Name = "panVHDetailsCostcodeLookUp"
        Me.panVHDetailsCostcodeLookUp.Size = New System.Drawing.Size(603, 243)
        Me.panVHDetailsCostcodeLookUp.TabIndex = 18
        '
        'lblVHDetailsCostCode
        '
        Me.lblVHDetailsCostCode.AutoSize = True
        Me.lblVHDetailsCostCode.BackColor = System.Drawing.Color.Transparent
        Me.lblVHDetailsCostCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHDetailsCostCode.Location = New System.Drawing.Point(4, 112)
        Me.lblVHDetailsCostCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVHDetailsCostCode.Name = "lblVHDetailsCostCode"
        Me.lblVHDetailsCostCode.Size = New System.Drawing.Size(251, 20)
        Me.lblVHDetailsCostCode.TabIndex = 104
        Me.lblVHDetailsCostCode.Text = "Vehicle Details Cost Code"
        '
        'lblVHDetailsCostCodeDesc
        '
        Me.lblVHDetailsCostCodeDesc.AutoSize = True
        Me.lblVHDetailsCostCodeDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblVHDetailsCostCodeDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHDetailsCostCodeDesc.Location = New System.Drawing.Point(4, 180)
        Me.lblVHDetailsCostCodeDesc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVHDetailsCostCodeDesc.Name = "lblVHDetailsCostCodeDesc"
        Me.lblVHDetailsCostCodeDesc.Size = New System.Drawing.Size(193, 20)
        Me.lblVHDetailsCostCodeDesc.TabIndex = 106
        Me.lblVHDetailsCostCodeDesc.Text = "Vehicle Description"
        '
        'txtVHDetailsCostdesc
        '
        Me.txtVHDetailsCostdesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtVHDetailsCostdesc.Location = New System.Drawing.Point(9, 205)
        Me.txtVHDetailsCostdesc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtVHDetailsCostdesc.Name = "txtVHDetailsCostdesc"
        Me.txtVHDetailsCostdesc.Size = New System.Drawing.Size(256, 26)
        Me.txtVHDetailsCostdesc.TabIndex = 102
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(122, 378)
        Me.lblNoRecord.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(185, 20)
        Me.lblNoRecord.TabIndex = 113
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'VHDetailsCostCodeLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(603, 729)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgVHDetailsCostcode)
        Me.Controls.Add(Me.panVHDetailsCostcodeLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "VHDetailsCostCodeLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "VH Details Cost Code Lookup"
        CType(Me.dgVHDetailsCostcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panVHDetailsCostcodeLookUp.ResumeLayout(False)
        Me.panVHDetailsCostcodeLookUp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchVHDetailsCostCode As System.Windows.Forms.Label
    Friend WithEvents dgVHDetailsCostcode As System.Windows.Forms.DataGridView
    Friend WithEvents btnVHDetailsCostCodeSearch As System.Windows.Forms.Button
    Friend WithEvents txtVHDetailsCostCodeSearch As System.Windows.Forms.TextBox
    Friend WithEvents panVHDetailsCostcodeLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents lblVHDetailsCostCode As System.Windows.Forms.Label
    Friend WithEvents lblVHDetailsCostCodeDesc As System.Windows.Forms.Label
    Friend WithEvents txtVHDetailsCostdesc As System.Windows.Forms.TextBox
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents dgclVHDetailCostCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHDetailCostCodeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclType As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

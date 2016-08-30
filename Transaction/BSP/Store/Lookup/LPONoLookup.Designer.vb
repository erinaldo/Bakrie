<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LPONoLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LPONoLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlLPONoSearch = New Stepi.UI.ExtendedPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblLPONo = New System.Windows.Forms.Label()
        Me.btnLPONoSearch = New System.Windows.Forms.Button()
        Me.lblsearchCategory = New System.Windows.Forms.Label()
        Me.txtLPONo = New System.Windows.Forms.TextBox()
        Me.dgvLPONo = New System.Windows.Forms.DataGridView()
        Me.dgclSTLPOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLPOSupplierID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLPONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLPOSupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTLPODetID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlLPONoSearch.SuspendLayout()
        CType(Me.dgvLPONo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlLPONoSearch
        '
        Me.pnlLPONoSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlLPONoSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlLPONoSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlLPONoSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlLPONoSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlLPONoSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlLPONoSearch.CaptionSize = 40
        Me.pnlLPONoSearch.CaptionText = "Search PO No."
        Me.pnlLPONoSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlLPONoSearch.Controls.Add(Me.Label3)
        Me.pnlLPONoSearch.Controls.Add(Me.btnClose)
        Me.pnlLPONoSearch.Controls.Add(Me.lblLPONo)
        Me.pnlLPONoSearch.Controls.Add(Me.btnLPONoSearch)
        Me.pnlLPONoSearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlLPONoSearch.Controls.Add(Me.txtLPONo)
        Me.pnlLPONoSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlLPONoSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlLPONoSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlLPONoSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLPONoSearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlLPONoSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlLPONoSearch.Name = "pnlLPONoSearch"
        Me.pnlLPONoSearch.Size = New System.Drawing.Size(541, 119)
        Me.pnlLPONoSearch.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(108, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = ":"
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
        Me.btnClose.Location = New System.Drawing.Point(348, 79)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 3
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblLPONo
        '
        Me.lblLPONo.AutoSize = True
        Me.lblLPONo.BackColor = System.Drawing.Color.Transparent
        Me.lblLPONo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLPONo.Location = New System.Drawing.Point(48, 86)
        Me.lblLPONo.Name = "lblLPONo"
        Me.lblLPONo.Size = New System.Drawing.Size(49, 13)
        Me.lblLPONo.TabIndex = 105
        Me.lblLPONo.Text = "PO No."
        '
        'btnLPONoSearch
        '
        Me.btnLPONoSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnLPONoSearch.BackgroundImage = CType(resources.GetObject("btnLPONoSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnLPONoSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnLPONoSearch.FlatAppearance.BorderSize = 0
        Me.btnLPONoSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnLPONoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLPONoSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLPONoSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLPONoSearch.Location = New System.Drawing.Point(313, 79)
        Me.btnLPONoSearch.Name = "btnLPONoSearch"
        Me.btnLPONoSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnLPONoSearch.TabIndex = 2
        Me.btnLPONoSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLPONoSearch.UseVisualStyleBackColor = False
        '
        'lblsearchCategory
        '
        Me.lblsearchCategory.AutoSize = True
        Me.lblsearchCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchCategory.Location = New System.Drawing.Point(1, 41)
        Me.lblsearchCategory.Name = "lblsearchCategory"
        Me.lblsearchCategory.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchCategory.TabIndex = 54
        Me.lblsearchCategory.Text = "Search By"
        '
        'txtLPONo
        '
        Me.txtLPONo.Location = New System.Drawing.Point(120, 83)
        Me.txtLPONo.Name = "txtLPONo"
        Me.txtLPONo.Size = New System.Drawing.Size(172, 20)
        Me.txtLPONo.TabIndex = 1
        '
        'dgvLPONo
        '
        Me.dgvLPONo.AllowUserToAddRows = False
        Me.dgvLPONo.AllowUserToDeleteRows = False
        Me.dgvLPONo.AllowUserToOrderColumns = True
        Me.dgvLPONo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvLPONo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvLPONo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvLPONo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvLPONo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLPONo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLPONo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclSTLPOID, Me.dgclLPOSupplierID, Me.dgclLPONo, Me.dgclLPOSupplierName, Me.Remarks, Me.dgclSTLPODetID})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLPONo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLPONo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLPONo.EnableHeadersVisualStyles = False
        Me.dgvLPONo.GridColor = System.Drawing.Color.Gray
        Me.dgvLPONo.Location = New System.Drawing.Point(0, 119)
        Me.dgvLPONo.MultiSelect = False
        Me.dgvLPONo.Name = "dgvLPONo"
        Me.dgvLPONo.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLPONo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLPONo.RowHeadersVisible = False
        Me.dgvLPONo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvLPONo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLPONo.Size = New System.Drawing.Size(541, 296)
        Me.dgvLPONo.TabIndex = 4
        Me.dgvLPONo.TabStop = False
        '
        'dgclSTLPOID
        '
        Me.dgclSTLPOID.DataPropertyName = "STLPOID"
        Me.dgclSTLPOID.HeaderText = "STPO ID"
        Me.dgclSTLPOID.Name = "dgclSTLPOID"
        Me.dgclSTLPOID.ReadOnly = True
        Me.dgclSTLPOID.Visible = False
        Me.dgclSTLPOID.Width = 80
        '
        'dgclLPOSupplierID
        '
        Me.dgclLPOSupplierID.DataPropertyName = "APSupplierID"
        Me.dgclLPOSupplierID.HeaderText = "POSupplierID"
        Me.dgclLPOSupplierID.Name = "dgclLPOSupplierID"
        Me.dgclLPOSupplierID.ReadOnly = True
        Me.dgclLPOSupplierID.Visible = False
        Me.dgclLPOSupplierID.Width = 108
        '
        'dgclLPONo
        '
        Me.dgclLPONo.DataPropertyName = "LPONo"
        Me.dgclLPONo.HeaderText = "PO No."
        Me.dgclLPONo.Name = "dgclLPONo"
        Me.dgclLPONo.ReadOnly = True
        Me.dgclLPONo.Width = 70
        '
        'dgclLPOSupplierName
        '
        Me.dgclLPOSupplierName.DataPropertyName = "SupplierName"
        Me.dgclLPOSupplierName.HeaderText = "Supplier Name"
        Me.dgclLPOSupplierName.Name = "dgclLPOSupplierName"
        Me.dgclLPOSupplierName.ReadOnly = True
        Me.dgclLPOSupplierName.Width = 115
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        Me.Remarks.Width = 82
        '
        'dgclSTLPODetID
        '
        Me.dgclSTLPODetID.DataPropertyName = "STLPODetID"
        Me.dgclSTLPODetID.HeaderText = "STPODetID"
        Me.dgclSTLPODetID.Name = "dgclSTLPODetID"
        Me.dgclSTLPODetID.ReadOnly = True
        Me.dgclSTLPODetID.Visible = False
        Me.dgclSTLPODetID.Width = 96
        '
        'LPONoLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(541, 415)
        Me.Controls.Add(Me.dgvLPONo)
        Me.Controls.Add(Me.pnlLPONoSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "LPONoLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PONo Lookup"
        Me.pnlLPONoSearch.ResumeLayout(False)
        Me.pnlLPONoSearch.PerformLayout()
        CType(Me.dgvLPONo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLPONoSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblLPONo As System.Windows.Forms.Label
    Friend WithEvents btnLPONoSearch As System.Windows.Forms.Button
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents txtLPONo As System.Windows.Forms.TextBox
    Friend WithEvents dgvLPONo As System.Windows.Forms.DataGridView
    Friend WithEvents dgclSTLPOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLPOSupplierID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLPONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLPOSupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTLPODetID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

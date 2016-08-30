<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupplierLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SupplierLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlSupplierSearch = New Stepi.UI.ExtendedPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSupplierSearch = New System.Windows.Forms.Button
        Me.lblSupplier = New System.Windows.Forms.Label
        Me.lblsearchCategory = New System.Windows.Forms.Label
        Me.txtSupplier = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgvSupplier = New System.Windows.Forms.DataGridView
        Me.dgclSupplierID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlSupplierSearch.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSupplierSearch
        '
        Me.pnlSupplierSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSupplierSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSupplierSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlSupplierSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlSupplierSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSupplierSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSupplierSearch.CaptionSize = 40
        Me.pnlSupplierSearch.CaptionText = "Search Supplier"
        Me.pnlSupplierSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSupplierSearch.Controls.Add(Me.Label3)
        Me.pnlSupplierSearch.Controls.Add(Me.btnClose)
        Me.pnlSupplierSearch.Controls.Add(Me.btnSupplierSearch)
        Me.pnlSupplierSearch.Controls.Add(Me.lblSupplier)
        Me.pnlSupplierSearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlSupplierSearch.Controls.Add(Me.txtSupplier)
        Me.pnlSupplierSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSupplierSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSupplierSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSupplierSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSupplierSearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlSupplierSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlSupplierSearch.Name = "pnlSupplierSearch"
        Me.pnlSupplierSearch.Size = New System.Drawing.Size(410, 119)
        Me.pnlSupplierSearch.TabIndex = 14
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
        'btnSupplierSearch
        '
        Me.btnSupplierSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSupplierSearch.BackgroundImage = CType(resources.GetObject("btnSupplierSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSupplierSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnSupplierSearch.FlatAppearance.BorderSize = 0
        Me.btnSupplierSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnSupplierSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupplierSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplierSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSupplierSearch.Location = New System.Drawing.Point(313, 79)
        Me.btnSupplierSearch.Name = "btnSupplierSearch"
        Me.btnSupplierSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnSupplierSearch.TabIndex = 2
        Me.btnSupplierSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSupplierSearch.UseVisualStyleBackColor = False
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
        Me.lblSupplier.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplier.Location = New System.Drawing.Point(41, 85)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(61, 13)
        Me.lblSupplier.TabIndex = 105
        Me.lblSupplier.Text = "Supplier"
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
        'txtSupplier
        '
        Me.txtSupplier.Location = New System.Drawing.Point(120, 83)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(172, 20)
        Me.txtSupplier.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvSupplier)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 119)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(410, 297)
        Me.Panel1.TabIndex = 105
        '
        'dgvSupplier
        '
        Me.dgvSupplier.AllowUserToAddRows = False
        Me.dgvSupplier.AllowUserToDeleteRows = False
        Me.dgvSupplier.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvSupplier.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSupplier.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSupplier.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSupplier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSupplier.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSupplier.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSupplier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclSupplierID, Me.dgclSupplier})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSupplier.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSupplier.EnableHeadersVisualStyles = False
        Me.dgvSupplier.GridColor = System.Drawing.Color.Gray
        Me.dgvSupplier.Location = New System.Drawing.Point(0, 1)
        Me.dgvSupplier.MultiSelect = False
        Me.dgvSupplier.Name = "dgvSupplier"
        Me.dgvSupplier.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSupplier.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSupplier.RowHeadersVisible = False
        Me.dgvSupplier.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSupplier.Size = New System.Drawing.Size(410, 294)
        Me.dgvSupplier.TabIndex = 4
        Me.dgvSupplier.TabStop = False
        '
        'dgclSupplierID
        '
        Me.dgclSupplierID.DataPropertyName = "DistributionSetupID"
        Me.dgclSupplierID.HeaderText = "Supplier ID"
        Me.dgclSupplierID.Name = "dgclSupplierID"
        Me.dgclSupplierID.ReadOnly = True
        Me.dgclSupplierID.Visible = False
        Me.dgclSupplierID.Width = 96
        '
        'dgclSupplier
        '
        Me.dgclSupplier.DataPropertyName = "DistributionDescp"
        Me.dgclSupplier.HeaderText = "Supplier Description"
        Me.dgclSupplier.Name = "dgclSupplier"
        Me.dgclSupplier.ReadOnly = True
        Me.dgclSupplier.Width = 146
        '
        'SupplierLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(410, 415)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlSupplierSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "SupplierLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supplier Lookup"
        Me.pnlSupplierSearch.ResumeLayout(False)
        Me.pnlSupplierSearch.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSupplierSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents btnSupplierSearch As System.Windows.Forms.Button
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvSupplier As System.Windows.Forms.DataGridView
    Friend WithEvents dgclSupplierID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplier As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

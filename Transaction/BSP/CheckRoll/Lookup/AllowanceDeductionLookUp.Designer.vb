<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AllowanceDeductionLookUp
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AllowanceDeductionLookUp))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvADCode = New System.Windows.Forms.DataGridView
        Me.btnClose = New System.Windows.Forms.Button
        Me.pnlCategorySearch = New Stepi.UI.ExtendedPanel
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.lblsearchCategory = New System.Windows.Forms.Label
        Me.txtallCode = New System.Windows.Forms.TextBox
        Me.btnVehicleSearch = New System.Windows.Forms.Button
        Me.SubBlock = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvADCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCategorySearch.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(94, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Code"
        '
        'dgvADCode
        '
        Me.dgvADCode.AllowUserToAddRows = False
        Me.dgvADCode.AllowUserToDeleteRows = False
        Me.dgvADCode.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvADCode.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvADCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvADCode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvADCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvADCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvADCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvADCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvADCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvADCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvADCode.EnableHeadersVisualStyles = False
        Me.dgvADCode.GridColor = System.Drawing.Color.Gray
        Me.dgvADCode.Location = New System.Drawing.Point(0, 105)
        Me.dgvADCode.MultiSelect = False
        Me.dgvADCode.Name = "dgvADCode"
        Me.dgvADCode.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvADCode.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvADCode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvADCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvADCode.Size = New System.Drawing.Size(562, 324)
        Me.dgvADCode.TabIndex = 23
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(504, 64)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'pnlCategorySearch
        '
        Me.pnlCategorySearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlCategorySearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCategorySearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlCategorySearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlCategorySearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlCategorySearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCategorySearch.CaptionSize = 40
        Me.pnlCategorySearch.CaptionText = "Search Allowance & Deduction Code"
        Me.pnlCategorySearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Controls.Add(Me.lblRemarks)
        Me.pnlCategorySearch.Controls.Add(Me.Label1)
        Me.pnlCategorySearch.Controls.Add(Me.Label3)
        Me.pnlCategorySearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlCategorySearch.Controls.Add(Me.txtallCode)
        Me.pnlCategorySearch.Controls.Add(Me.btnClose)
        Me.pnlCategorySearch.Controls.Add(Me.btnVehicleSearch)
        Me.pnlCategorySearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlCategorySearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlCategorySearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlCategorySearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCategorySearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlCategorySearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategorySearch.Name = "pnlCategorySearch"
        Me.pnlCategorySearch.Size = New System.Drawing.Size(562, 105)
        Me.pnlCategorySearch.TabIndex = 22
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Blue
        Me.lblRemarks.Location = New System.Drawing.Point(294, 67)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(81, 13)
        Me.lblRemarks.TabIndex = 108
        Me.lblRemarks.Text = "Description"
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
        'txtallCode
        '
        Me.txtallCode.Location = New System.Drawing.Point(112, 64)
        Me.txtallCode.Name = "txtallCode"
        Me.txtallCode.Size = New System.Drawing.Size(159, 20)
        Me.txtallCode.TabIndex = 101
        '
        'btnVehicleSearch
        '
        Me.btnVehicleSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnVehicleSearch.BackgroundImage = CType(resources.GetObject("btnVehicleSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnVehicleSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnVehicleSearch.FlatAppearance.BorderSize = 0
        Me.btnVehicleSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnVehicleSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVehicleSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehicleSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVehicleSearch.Location = New System.Drawing.Point(471, 64)
        Me.btnVehicleSearch.Name = "btnVehicleSearch"
        Me.btnVehicleSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnVehicleSearch.TabIndex = 102
        Me.btnVehicleSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVehicleSearch.UseVisualStyleBackColor = False
        '
        'SubBlock
        '
        Me.SubBlock.HeaderText = "Field No"
        Me.SubBlock.Name = "SubBlock"
        Me.SubBlock.ReadOnly = True
        Me.SubBlock.Width = 88
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "STCategoryDescp"
        Me.DataGridViewTextBoxColumn3.HeaderText = "YOP"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 54
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.SubBlock})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.Gray
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(562, 429)
        Me.DataGridView1.TabIndex = 24
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "STCategoryCode"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Field No Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 122
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "NIK"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Afdeling"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 53
        '
        'AllowanceDeductionLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 429)
        Me.Controls.Add(Me.dgvADCode)
        Me.Controls.Add(Me.pnlCategorySearch)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AllowanceDeductionLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvADCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCategorySearch.ResumeLayout(False)
        Me.pnlCategorySearch.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvADCode As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pnlCategorySearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents txtallCode As System.Windows.Forms.TextBox
    Friend WithEvents btnVehicleSearch As System.Windows.Forms.Button
    Friend WithEvents SubBlock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
End Class

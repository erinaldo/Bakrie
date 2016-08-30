<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GradeLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GradeLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlCategorySearch = New Stepi.UI.ExtendedPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtestateName = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnVehicleSearch = New System.Windows.Forms.Button()
        Me.lblsearchCategory = New System.Windows.Forms.Label()
        Me.txtestateCode = New System.Windows.Forms.TextBox()
        Me.gvSTCategoryDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvSTCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvStockCategory = New System.Windows.Forms.DataGridView()
        Me.gvSTCategoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEstateView = New System.Windows.Forms.DataGridView()
        Me.dgcGradeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcGrade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlCategorySearch.SuspendLayout()
        CType(Me.dgvStockCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEstateView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(132, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Grade Name"
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
        Me.pnlCategorySearch.CaptionText = "Search Grade"
        Me.pnlCategorySearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Controls.Add(Me.Label3)
        Me.pnlCategorySearch.Controls.Add(Me.Label2)
        Me.pnlCategorySearch.Controls.Add(Me.Label1)
        Me.pnlCategorySearch.Controls.Add(Me.txtestateName)
        Me.pnlCategorySearch.Controls.Add(Me.btnClose)
        Me.pnlCategorySearch.Controls.Add(Me.Label4)
        Me.pnlCategorySearch.Controls.Add(Me.btnVehicleSearch)
        Me.pnlCategorySearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlCategorySearch.Controls.Add(Me.txtestateCode)
        Me.pnlCategorySearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlCategorySearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlCategorySearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlCategorySearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCategorySearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlCategorySearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategorySearch.Name = "pnlCategorySearch"
        Me.pnlCategorySearch.Size = New System.Drawing.Size(475, 133)
        Me.pnlCategorySearch.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Grade Code"
        '
        'txtestateName
        '
        Me.txtestateName.Location = New System.Drawing.Point(144, 90)
        Me.txtestateName.Name = "txtestateName"
        Me.txtestateName.Size = New System.Drawing.Size(172, 20)
        Me.txtestateName.TabIndex = 104
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
        Me.btnClose.Location = New System.Drawing.Point(367, 83)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(131, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = ":"
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
        Me.btnVehicleSearch.Location = New System.Drawing.Point(332, 83)
        Me.btnVehicleSearch.Name = "btnVehicleSearch"
        Me.btnVehicleSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnVehicleSearch.TabIndex = 102
        Me.btnVehicleSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVehicleSearch.UseVisualStyleBackColor = False
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
        'txtestateCode
        '
        Me.txtestateCode.Enabled = False
        Me.txtestateCode.Location = New System.Drawing.Point(144, 63)
        Me.txtestateCode.Name = "txtestateCode"
        Me.txtestateCode.Size = New System.Drawing.Size(172, 20)
        Me.txtestateCode.TabIndex = 101
        '
        'gvSTCategoryDesc
        '
        Me.gvSTCategoryDesc.DataPropertyName = "STCategoryDescp"
        Me.gvSTCategoryDesc.HeaderText = "Employee Name"
        Me.gvSTCategoryDesc.Name = "gvSTCategoryDesc"
        Me.gvSTCategoryDesc.ReadOnly = True
        Me.gvSTCategoryDesc.Width = 124
        '
        'gvSTCategoryID
        '
        Me.gvSTCategoryID.DataPropertyName = "NIK"
        Me.gvSTCategoryID.HeaderText = "NIK"
        Me.gvSTCategoryID.Name = "gvSTCategoryID"
        Me.gvSTCategoryID.ReadOnly = True
        Me.gvSTCategoryID.Visible = False
        Me.gvSTCategoryID.Width = 52
        '
        'dgvStockCategory
        '
        Me.dgvStockCategory.AllowUserToAddRows = False
        Me.dgvStockCategory.AllowUserToDeleteRows = False
        Me.dgvStockCategory.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvStockCategory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStockCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvStockCategory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvStockCategory.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvStockCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvStockCategory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStockCategory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvStockCategory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvSTCategoryCode, Me.gvSTCategoryID, Me.gvSTCategoryDesc})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStockCategory.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvStockCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStockCategory.EnableHeadersVisualStyles = False
        Me.dgvStockCategory.GridColor = System.Drawing.Color.Gray
        Me.dgvStockCategory.Location = New System.Drawing.Point(0, 0)
        Me.dgvStockCategory.MultiSelect = False
        Me.dgvStockCategory.Name = "dgvStockCategory"
        Me.dgvStockCategory.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStockCategory.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvStockCategory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvStockCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStockCategory.Size = New System.Drawing.Size(475, 417)
        Me.dgvStockCategory.TabIndex = 17
        '
        'gvSTCategoryCode
        '
        Me.gvSTCategoryCode.DataPropertyName = "STCategoryCode"
        Me.gvSTCategoryCode.HeaderText = "Emp Code"
        Me.gvSTCategoryCode.Name = "gvSTCategoryCode"
        Me.gvSTCategoryCode.ReadOnly = True
        Me.gvSTCategoryCode.Width = 90
        '
        'dgvEstateView
        '
        Me.dgvEstateView.AllowUserToAddRows = False
        Me.dgvEstateView.AllowUserToDeleteRows = False
        Me.dgvEstateView.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvEstateView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvEstateView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvEstateView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvEstateView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvEstateView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvEstateView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEstateView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvEstateView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcGradeId, Me.dgcGrade})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEstateView.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvEstateView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEstateView.EnableHeadersVisualStyles = False
        Me.dgvEstateView.GridColor = System.Drawing.Color.Gray
        Me.dgvEstateView.Location = New System.Drawing.Point(0, 133)
        Me.dgvEstateView.MultiSelect = False
        Me.dgvEstateView.Name = "dgvEstateView"
        Me.dgvEstateView.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEstateView.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvEstateView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvEstateView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEstateView.Size = New System.Drawing.Size(475, 284)
        Me.dgvEstateView.TabIndex = 0
        '
        'dgcGradeId
        '
        Me.dgcGradeId.DataPropertyName = "GradeId"
        Me.dgcGradeId.HeaderText = "GradeId"
        Me.dgcGradeId.Name = "dgcGradeId"
        Me.dgcGradeId.ReadOnly = True
        Me.dgcGradeId.Width = 78
        '
        'dgcGrade
        '
        Me.dgcGrade.DataPropertyName = "Grade"
        Me.dgcGrade.HeaderText = "Grade"
        Me.dgcGrade.Name = "dgcGrade"
        Me.dgcGrade.ReadOnly = True
        Me.dgcGrade.Width = 66
        '
        'EstateLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 417)
        Me.Controls.Add(Me.dgvEstateView)
        Me.Controls.Add(Me.pnlCategorySearch)
        Me.Controls.Add(Me.dgvStockCategory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EstateLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EstateLookup"
        Me.TopMost = True
        Me.pnlCategorySearch.ResumeLayout(False)
        Me.pnlCategorySearch.PerformLayout()
        CType(Me.dgvStockCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEstateView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlCategorySearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtestateName As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnVehicleSearch As System.Windows.Forms.Button
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents txtestateCode As System.Windows.Forms.TextBox
    Friend WithEvents gvSTCategoryDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvSTCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvStockCategory As System.Windows.Forms.DataGridView
    Friend WithEvents gvSTCategoryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvEstateView As System.Windows.Forms.DataGridView
    Friend WithEvents dgcGradeId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcGrade As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

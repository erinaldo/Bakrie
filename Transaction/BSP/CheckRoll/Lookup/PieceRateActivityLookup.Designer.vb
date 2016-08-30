<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PieceRateActivityLookup
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PieceRateActivityLookup))
        Me.dgvPieceRate = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBlockName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colJobRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMandorRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colKeraniRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colActivityBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlCategorySearch = New Stepi.UI.ExtendedPanel()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblsearchCategory = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblVHcode = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtActivityDescription = New System.Windows.Forms.TextBox()
        Me.lblVHDesc = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbActivityRefNo = New System.Windows.Forms.ComboBox()
        CType(Me.dgvPieceRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCategorySearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvPieceRate
        '
        Me.dgvPieceRate.AllowUserToAddRows = False
        Me.dgvPieceRate.AllowUserToDeleteRows = False
        Me.dgvPieceRate.AllowUserToOrderColumns = True
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        Me.dgvPieceRate.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvPieceRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPieceRate.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPieceRate.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPieceRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPieceRate.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPieceRate.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvPieceRate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colBlockName, Me.colDescription, Me.colRefNo, Me.colJobRate, Me.colMandorRate, Me.colKeraniRate, Me.colUnit, Me.colTotalUnit, Me.colStartDate, Me.colEndDate, Me.colActivityBy})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPieceRate.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvPieceRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPieceRate.EnableHeadersVisualStyles = False
        Me.dgvPieceRate.GridColor = System.Drawing.Color.Gray
        Me.dgvPieceRate.Location = New System.Drawing.Point(0, 154)
        Me.dgvPieceRate.MultiSelect = False
        Me.dgvPieceRate.Name = "dgvPieceRate"
        Me.dgvPieceRate.ReadOnly = True
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPieceRate.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvPieceRate.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvPieceRate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPieceRate.Size = New System.Drawing.Size(609, 251)
        Me.dgvPieceRate.TabIndex = 23
        '
        'colId
        '
        Me.colId.DataPropertyName = "Id"
        Me.colId.HeaderText = "Id"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Width = 43
        '
        'colBlockName
        '
        Me.colBlockName.DataPropertyName = "BlockName"
        Me.colBlockName.HeaderText = "FieldNo Name"
        Me.colBlockName.Name = "colBlockName"
        Me.colBlockName.ReadOnly = True
        Me.colBlockName.Width = 99
        '
        'colDescription
        '
        Me.colDescription.DataPropertyName = "Description"
        Me.colDescription.HeaderText = "Activity"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        Me.colDescription.Width = 73
        '
        'colRefNo
        '
        Me.colRefNo.DataPropertyName = "ReferenceNo"
        Me.colRefNo.HeaderText = "Reference No"
        Me.colRefNo.Name = "colRefNo"
        Me.colRefNo.ReadOnly = True
        Me.colRefNo.Width = 108
        '
        'colJobRate
        '
        Me.colJobRate.DataPropertyName = "JobRate"
        Me.colJobRate.HeaderText = "Job Rate"
        Me.colJobRate.Name = "colJobRate"
        Me.colJobRate.ReadOnly = True
        Me.colJobRate.Width = 80
        '
        'colMandorRate
        '
        Me.colMandorRate.DataPropertyName = "MandoreRate"
        Me.colMandorRate.HeaderText = "Mandor Rate"
        Me.colMandorRate.Name = "colMandorRate"
        Me.colMandorRate.ReadOnly = True
        Me.colMandorRate.Width = 103
        '
        'colKeraniRate
        '
        Me.colKeraniRate.DataPropertyName = "KeraniRate"
        Me.colKeraniRate.HeaderText = "Kerani Rate"
        Me.colKeraniRate.Name = "colKeraniRate"
        Me.colKeraniRate.ReadOnly = True
        Me.colKeraniRate.Width = 98
        '
        'colUnit
        '
        Me.colUnit.DataPropertyName = "Unit"
        Me.colUnit.HeaderText = "Unit"
        Me.colUnit.Name = "colUnit"
        Me.colUnit.ReadOnly = True
        Me.colUnit.Width = 53
        '
        'colTotalUnit
        '
        Me.colTotalUnit.DataPropertyName = "TotalUnit"
        Me.colTotalUnit.HeaderText = "Total Unit"
        Me.colTotalUnit.Name = "colTotalUnit"
        Me.colTotalUnit.ReadOnly = True
        Me.colTotalUnit.Width = 85
        '
        'colStartDate
        '
        Me.colStartDate.DataPropertyName = "StartDate"
        Me.colStartDate.HeaderText = "Start Date"
        Me.colStartDate.Name = "colStartDate"
        Me.colStartDate.ReadOnly = True
        Me.colStartDate.Width = 90
        '
        'colEndDate
        '
        Me.colEndDate.DataPropertyName = "EndDate"
        Me.colEndDate.HeaderText = "End Date"
        Me.colEndDate.Name = "colEndDate"
        Me.colEndDate.ReadOnly = True
        Me.colEndDate.Width = 83
        '
        'colActivityBy
        '
        Me.colActivityBy.DataPropertyName = "ActivityBy"
        Me.colActivityBy.HeaderText = "Activity By"
        Me.colActivityBy.Name = "colActivityBy"
        Me.colActivityBy.ReadOnly = True
        Me.colActivityBy.Visible = False
        Me.colActivityBy.Width = 92
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
        Me.pnlCategorySearch.CaptionText = "Search Piece Rate Activity"
        Me.pnlCategorySearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Controls.Add(Me.cmbActivityRefNo)
        Me.pnlCategorySearch.Controls.Add(Me.dtpDate)
        Me.pnlCategorySearch.Controls.Add(Me.Label1)
        Me.pnlCategorySearch.Controls.Add(Me.Label4)
        Me.pnlCategorySearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlCategorySearch.Controls.Add(Me.Label2)
        Me.pnlCategorySearch.Controls.Add(Me.Label3)
        Me.pnlCategorySearch.Controls.Add(Me.lblVHcode)
        Me.pnlCategorySearch.Controls.Add(Me.btnClose)
        Me.pnlCategorySearch.Controls.Add(Me.txtActivityDescription)
        Me.pnlCategorySearch.Controls.Add(Me.lblVHDesc)
        Me.pnlCategorySearch.Controls.Add(Me.btnSearch)
        Me.pnlCategorySearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlCategorySearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlCategorySearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlCategorySearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCategorySearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlCategorySearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategorySearch.Name = "pnlCategorySearch"
        Me.pnlCategorySearch.Size = New System.Drawing.Size(609, 154)
        Me.pnlCategorySearch.TabIndex = 24
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(187, 68)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(207, 20)
        Me.dtpDate.TabIndex = 198
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(169, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 14)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Activity Date"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(169, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(169, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = ":"
        '
        'lblVHcode
        '
        Me.lblVHcode.AutoSize = True
        Me.lblVHcode.BackColor = System.Drawing.Color.Transparent
        Me.lblVHcode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHcode.Location = New System.Drawing.Point(19, 97)
        Me.lblVHcode.Name = "lblVHcode"
        Me.lblVHcode.Size = New System.Drawing.Size(152, 13)
        Me.lblVHcode.TabIndex = 109
        Me.lblVHcode.Text = "Activity Reference No."
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
        Me.btnClose.Location = New System.Drawing.Point(466, 116)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtActivityDescription
        '
        Me.txtActivityDescription.Location = New System.Drawing.Point(187, 120)
        Me.txtActivityDescription.Name = "txtActivityDescription"
        Me.txtActivityDescription.Size = New System.Drawing.Size(207, 20)
        Me.txtActivityDescription.TabIndex = 101
        '
        'lblVHDesc
        '
        Me.lblVHDesc.AutoSize = True
        Me.lblVHDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblVHDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHDesc.Location = New System.Drawing.Point(18, 123)
        Me.lblVHDesc.Name = "lblVHDesc"
        Me.lblVHDesc.Size = New System.Drawing.Size(135, 13)
        Me.lblVHDesc.TabIndex = 105
        Me.lblVHDesc.Text = "Activity Description"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(433, 116)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnSearch.TabIndex = 102
        Me.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'cmbActivityRefNo
        '
        Me.cmbActivityRefNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActivityRefNo.FormattingEnabled = True
        Me.cmbActivityRefNo.Location = New System.Drawing.Point(187, 94)
        Me.cmbActivityRefNo.Name = "cmbActivityRefNo"
        Me.cmbActivityRefNo.Size = New System.Drawing.Size(207, 21)
        Me.cmbActivityRefNo.TabIndex = 199
        '
        'PieceRateActivityLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 405)
        Me.Controls.Add(Me.dgvPieceRate)
        Me.Controls.Add(Me.pnlCategorySearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PieceRateActivityLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Piece Rate Activity Lookup"
        Me.TopMost = True
        CType(Me.dgvPieceRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCategorySearch.ResumeLayout(False)
        Me.pnlCategorySearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvPieceRate As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCategorySearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVHcode As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtActivityDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblVHDesc As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBlockName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colJobRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMandorRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colKeraniRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActivityBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbActivityRefNo As System.Windows.Forms.ComboBox
End Class

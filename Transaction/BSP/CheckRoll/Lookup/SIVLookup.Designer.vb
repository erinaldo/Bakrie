<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SIVLookup
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SIVLookup))
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reamrks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvStockCategory = New System.Windows.Forms.DataGridView
        Me.gvSTCategoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gvSTCategoryDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnVehicleSearch = New System.Windows.Forms.Button
        Me.pnlCategorySearch = New Stepi.UI.ExtendedPanel
        Me.msktxtDate = New System.Windows.Forms.MaskedTextBox
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblColon1 = New System.Windows.Forms.Label
        Me.lblsearchCategory = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtCategoryCode = New System.Windows.Forms.TextBox
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStockCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCategorySearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Station Code"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Station Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 105
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.Reamrks})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.EnableHeadersVisualStyles = False
        Me.DataGridView2.GridColor = System.Drawing.Color.Gray
        Me.DataGridView2.Location = New System.Drawing.Point(0, 133)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(738, 436)
        Me.DataGridView2.TabIndex = 32
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "STCategoryCode"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 58
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "STCategoryDescp"
        Me.DataGridViewTextBoxColumn4.HeaderText = "SIV Number"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 101
        '
        'Reamrks
        '
        Me.Reamrks.HeaderText = "Remarks"
        Me.Reamrks.Name = "Reamrks"
        Me.Reamrks.ReadOnly = True
        Me.Reamrks.Width = 82
        '
        'dgvStockCategory
        '
        Me.dgvStockCategory.AllowUserToAddRows = False
        Me.dgvStockCategory.AllowUserToDeleteRows = False
        Me.dgvStockCategory.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvStockCategory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvStockCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvStockCategory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvStockCategory.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvStockCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvStockCategory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStockCategory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvStockCategory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvSTCategoryCode, Me.gvSTCategoryDesc})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStockCategory.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvStockCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStockCategory.EnableHeadersVisualStyles = False
        Me.dgvStockCategory.GridColor = System.Drawing.Color.Gray
        Me.dgvStockCategory.Location = New System.Drawing.Point(0, 133)
        Me.dgvStockCategory.MultiSelect = False
        Me.dgvStockCategory.Name = "dgvStockCategory"
        Me.dgvStockCategory.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStockCategory.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvStockCategory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvStockCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStockCategory.Size = New System.Drawing.Size(738, 436)
        Me.dgvStockCategory.TabIndex = 30
        '
        'gvSTCategoryCode
        '
        Me.gvSTCategoryCode.DataPropertyName = "STCategoryCode"
        Me.gvSTCategoryCode.HeaderText = "Vehicle Code"
        Me.gvSTCategoryCode.Name = "gvSTCategoryCode"
        Me.gvSTCategoryCode.ReadOnly = True
        Me.gvSTCategoryCode.Width = 106
        '
        'gvSTCategoryDesc
        '
        Me.gvSTCategoryDesc.DataPropertyName = "STCategoryDescp"
        Me.gvSTCategoryDesc.HeaderText = "Vehicle Name"
        Me.gvSTCategoryDesc.Name = "gvSTCategoryDesc"
        Me.gvSTCategoryDesc.ReadOnly = True
        Me.gvSTCategoryDesc.Width = 109
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.Gray
        Me.DataGridView1.Location = New System.Drawing.Point(0, 133)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(738, 436)
        Me.DataGridView1.TabIndex = 31
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "NIK"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Station"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 71
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
        Me.btnVehicleSearch.Location = New System.Drawing.Point(375, 94)
        Me.btnVehicleSearch.Name = "btnVehicleSearch"
        Me.btnVehicleSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnVehicleSearch.TabIndex = 102
        Me.btnVehicleSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVehicleSearch.UseVisualStyleBackColor = False
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
        Me.pnlCategorySearch.CaptionText = "Search SIV (Store Issue Voucher) "
        Me.pnlCategorySearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Controls.Add(Me.msktxtDate)
        Me.pnlCategorySearch.Controls.Add(Me.lblDate)
        Me.pnlCategorySearch.Controls.Add(Me.lblColon1)
        Me.pnlCategorySearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlCategorySearch.Controls.Add(Me.Label3)
        Me.pnlCategorySearch.Controls.Add(Me.Label1)
        Me.pnlCategorySearch.Controls.Add(Me.btnClose)
        Me.pnlCategorySearch.Controls.Add(Me.txtCategoryCode)
        Me.pnlCategorySearch.Controls.Add(Me.btnVehicleSearch)
        Me.pnlCategorySearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlCategorySearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlCategorySearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlCategorySearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCategorySearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlCategorySearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategorySearch.Name = "pnlCategorySearch"
        Me.pnlCategorySearch.Size = New System.Drawing.Size(738, 133)
        Me.pnlCategorySearch.TabIndex = 29
        '
        'msktxtDate
        '
        Me.msktxtDate.Location = New System.Drawing.Point(197, 68)
        Me.msktxtDate.Mask = "00/00/0000"
        Me.msktxtDate.Name = "msktxtDate"
        Me.msktxtDate.Size = New System.Drawing.Size(172, 20)
        Me.msktxtDate.TabIndex = 149
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.DimGray
        Me.lblDate.Location = New System.Drawing.Point(42, 71)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(37, 13)
        Me.lblDate.TabIndex = 147
        Me.lblDate.Text = "Date"
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(180, 69)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(12, 13)
        Me.lblColon1.TabIndex = 148
        Me.lblColon1.Text = ":"
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(165, 96)
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
        Me.Label1.Location = New System.Drawing.Point(42, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "SIV Number"
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
        Me.btnClose.Location = New System.Drawing.Point(408, 94)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtCategoryCode
        '
        Me.txtCategoryCode.Enabled = False
        Me.txtCategoryCode.Location = New System.Drawing.Point(197, 94)
        Me.txtCategoryCode.Name = "txtCategoryCode"
        Me.txtCategoryCode.Size = New System.Drawing.Size(172, 20)
        Me.txtCategoryCode.TabIndex = 101
        '
        'SIVLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 569)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.dgvStockCategory)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.pnlCategorySearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SIVLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SIVLookup"
        Me.TopMost = True
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStockCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCategorySearch.ResumeLayout(False)
        Me.pnlCategorySearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvStockCategory As System.Windows.Forms.DataGridView
    Friend WithEvents gvSTCategoryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvSTCategoryDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnVehicleSearch As System.Windows.Forms.Button
    Friend WithEvents pnlCategorySearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents txtCategoryCode As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reamrks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents msktxtDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
End Class

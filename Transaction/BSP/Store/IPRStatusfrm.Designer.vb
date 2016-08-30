<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IPRStatusfrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IPRStatusfrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlIPRStatus = New Stepi.UI.ExtendedPanel()
        Me.chkIPRdate = New System.Windows.Forms.CheckBox()
        Me.lblsearchCategory = New System.Windows.Forms.Label()
        Me.dtpviewIPRDate = New System.Windows.Forms.DateTimePicker()
        Me.lblviewIPRDate = New System.Windows.Forms.Label()
        Me.btnviewCategory = New System.Windows.Forms.Button()
        Me.lblviewIPRno = New System.Windows.Forms.Label()
        Me.txtviewIPRNo = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.txtviewRequiredfor = New System.Windows.Forms.TextBox()
        Me.lblviewMainstatus = New System.Windows.Forms.Label()
        Me.txtviewDeliveredto = New System.Windows.Forms.TextBox()
        Me.txtviewCategory = New System.Windows.Forms.TextBox()
        Me.lblviewDeliveredto = New System.Windows.Forms.Label()
        Me.txtviewClassification = New System.Windows.Forms.TextBox()
        Me.lblviewCategory = New System.Windows.Forms.Label()
        Me.lblviewRequiredfor = New System.Windows.Forms.Label()
        Me.lblviewClassification = New System.Windows.Forms.Label()
        Me.dgvIRPView = New System.Windows.Forms.DataGridView()
        Me.gvIPRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvUsageCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvUsageCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvUsageCOADescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvIPRdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvSTCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvClassification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvlRequiredDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvRequiredfor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvDeliveredto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvMainStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvIPRID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvSTCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvMakeModel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvEngine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvFixedAssetNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvChassisSerialNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvCategoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlIPRStatus.SuspendLayout()
        CType(Me.dgvIRPView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlIPRStatus
        '
        Me.pnlIPRStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlIPRStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlIPRStatus.BorderColor = System.Drawing.Color.Gray
        Me.pnlIPRStatus.CaptionColorOne = System.Drawing.Color.White
        Me.pnlIPRStatus.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlIPRStatus.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlIPRStatus.CaptionSize = 40
        Me.pnlIPRStatus.CaptionText = "PR Status"
        Me.pnlIPRStatus.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlIPRStatus.Controls.Add(Me.chkIPRdate)
        Me.pnlIPRStatus.Controls.Add(Me.lblsearchCategory)
        Me.pnlIPRStatus.Controls.Add(Me.dtpviewIPRDate)
        Me.pnlIPRStatus.Controls.Add(Me.lblviewIPRDate)
        Me.pnlIPRStatus.Controls.Add(Me.btnviewCategory)
        Me.pnlIPRStatus.Controls.Add(Me.lblviewIPRno)
        Me.pnlIPRStatus.Controls.Add(Me.txtviewIPRNo)
        Me.pnlIPRStatus.Controls.Add(Me.btnSearch)
        Me.pnlIPRStatus.Controls.Add(Me.cmbStatus)
        Me.pnlIPRStatus.Controls.Add(Me.txtviewRequiredfor)
        Me.pnlIPRStatus.Controls.Add(Me.lblviewMainstatus)
        Me.pnlIPRStatus.Controls.Add(Me.txtviewDeliveredto)
        Me.pnlIPRStatus.Controls.Add(Me.txtviewCategory)
        Me.pnlIPRStatus.Controls.Add(Me.lblviewDeliveredto)
        Me.pnlIPRStatus.Controls.Add(Me.txtviewClassification)
        Me.pnlIPRStatus.Controls.Add(Me.lblviewCategory)
        Me.pnlIPRStatus.Controls.Add(Me.lblviewRequiredfor)
        Me.pnlIPRStatus.Controls.Add(Me.lblviewClassification)
        Me.pnlIPRStatus.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlIPRStatus.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlIPRStatus.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlIPRStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlIPRStatus.ForeColor = System.Drawing.Color.Black
        Me.pnlIPRStatus.Location = New System.Drawing.Point(0, 0)
        Me.pnlIPRStatus.Name = "pnlIPRStatus"
        Me.pnlIPRStatus.Size = New System.Drawing.Size(896, 176)
        Me.pnlIPRStatus.TabIndex = 117
        '
        'chkIPRdate
        '
        Me.chkIPRdate.AutoSize = True
        Me.chkIPRdate.Location = New System.Drawing.Point(74, 64)
        Me.chkIPRdate.Name = "chkIPRdate"
        Me.chkIPRdate.Size = New System.Drawing.Size(15, 14)
        Me.chkIPRdate.TabIndex = 40
        Me.chkIPRdate.UseVisualStyleBackColor = True
        '
        'lblsearchCategory
        '
        Me.lblsearchCategory.AutoSize = True
        Me.lblsearchCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchCategory.ForeColor = System.Drawing.Color.Black
        Me.lblsearchCategory.Location = New System.Drawing.Point(1, 41)
        Me.lblsearchCategory.Name = "lblsearchCategory"
        Me.lblsearchCategory.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchCategory.TabIndex = 54
        Me.lblsearchCategory.Text = "Search By"
        '
        'dtpviewIPRDate
        '
        Me.dtpviewIPRDate.Enabled = False
        Me.dtpviewIPRDate.Location = New System.Drawing.Point(74, 87)
        Me.dtpviewIPRDate.Name = "dtpviewIPRDate"
        Me.dtpviewIPRDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpviewIPRDate.TabIndex = 41
        '
        'lblviewIPRDate
        '
        Me.lblviewIPRDate.AutoSize = True
        Me.lblviewIPRDate.ForeColor = System.Drawing.Color.Black
        Me.lblviewIPRDate.Location = New System.Drawing.Point(90, 64)
        Me.lblviewIPRDate.Name = "lblviewIPRDate"
        Me.lblviewIPRDate.Size = New System.Drawing.Size(51, 13)
        Me.lblviewIPRDate.TabIndex = 40
        Me.lblviewIPRDate.Text = "PR Date"
        '
        'btnviewCategory
        '
        Me.btnviewCategory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnviewCategory.FlatAppearance.BorderSize = 0
        Me.btnviewCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnviewCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnviewCategory.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnviewCategory.Image = CType(resources.GetObject("btnviewCategory.Image"), System.Drawing.Image)
        Me.btnviewCategory.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnviewCategory.Location = New System.Drawing.Point(597, 78)
        Me.btnviewCategory.Name = "btnviewCategory"
        Me.btnviewCategory.Size = New System.Drawing.Size(30, 33)
        Me.btnviewCategory.TabIndex = 44
        Me.btnviewCategory.TabStop = False
        Me.btnviewCategory.UseVisualStyleBackColor = True
        '
        'lblviewIPRno
        '
        Me.lblviewIPRno.AutoSize = True
        Me.lblviewIPRno.ForeColor = System.Drawing.Color.Black
        Me.lblviewIPRno.Location = New System.Drawing.Point(300, 64)
        Me.lblviewIPRno.Name = "lblviewIPRno"
        Me.lblviewIPRno.Size = New System.Drawing.Size(45, 13)
        Me.lblviewIPRno.TabIndex = 17
        Me.lblviewIPRno.Text = "PR No."
        '
        'txtviewIPRNo
        '
        Me.txtviewIPRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewIPRNo.Location = New System.Drawing.Point(250, 87)
        Me.txtviewIPRNo.MaxLength = 50
        Me.txtviewIPRNo.Name = "txtviewIPRNo"
        Me.txtviewIPRNo.Size = New System.Drawing.Size(165, 20)
        Me.txtviewIPRNo.TabIndex = 42
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(642, 141)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 49
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"OPEN", "MANAGER APPROVED", "EXPORTED", "CENTRAL EXPORTED", "REJECTED", "DELIVERED", "SELECT ALL"})
        Me.cmbStatus.Location = New System.Drawing.Point(426, 144)
        Me.cmbStatus.MaxLength = 50
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(165, 21)
        Me.cmbStatus.TabIndex = 48
        '
        'txtviewRequiredfor
        '
        Me.txtviewRequiredfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewRequiredfor.Location = New System.Drawing.Point(74, 144)
        Me.txtviewRequiredfor.MaxLength = 50
        Me.txtviewRequiredfor.Name = "txtviewRequiredfor"
        Me.txtviewRequiredfor.Size = New System.Drawing.Size(165, 20)
        Me.txtviewRequiredfor.TabIndex = 46
        '
        'lblviewMainstatus
        '
        Me.lblviewMainstatus.AutoSize = True
        Me.lblviewMainstatus.ForeColor = System.Drawing.Color.Black
        Me.lblviewMainstatus.Location = New System.Drawing.Point(489, 125)
        Me.lblviewMainstatus.Name = "lblviewMainstatus"
        Me.lblviewMainstatus.Size = New System.Drawing.Size(37, 13)
        Me.lblviewMainstatus.TabIndex = 22
        Me.lblviewMainstatus.Text = "Status"
        '
        'txtviewDeliveredto
        '
        Me.txtviewDeliveredto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewDeliveredto.Location = New System.Drawing.Point(250, 144)
        Me.txtviewDeliveredto.MaxLength = 50
        Me.txtviewDeliveredto.Name = "txtviewDeliveredto"
        Me.txtviewDeliveredto.Size = New System.Drawing.Size(165, 20)
        Me.txtviewDeliveredto.TabIndex = 47
        '
        'txtviewCategory
        '
        Me.txtviewCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewCategory.Location = New System.Drawing.Point(426, 87)
        Me.txtviewCategory.MaxLength = 50
        Me.txtviewCategory.Name = "txtviewCategory"
        Me.txtviewCategory.Size = New System.Drawing.Size(165, 20)
        Me.txtviewCategory.TabIndex = 43
        '
        'lblviewDeliveredto
        '
        Me.lblviewDeliveredto.AutoSize = True
        Me.lblviewDeliveredto.ForeColor = System.Drawing.Color.Black
        Me.lblviewDeliveredto.Location = New System.Drawing.Point(288, 123)
        Me.lblviewDeliveredto.Name = "lblviewDeliveredto"
        Me.lblviewDeliveredto.Size = New System.Drawing.Size(68, 13)
        Me.lblviewDeliveredto.TabIndex = 21
        Me.lblviewDeliveredto.Text = "Delivered To"
        '
        'txtviewClassification
        '
        Me.txtviewClassification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewClassification.Location = New System.Drawing.Point(637, 87)
        Me.txtviewClassification.MaxLength = 50
        Me.txtviewClassification.Name = "txtviewClassification"
        Me.txtviewClassification.Size = New System.Drawing.Size(165, 20)
        Me.txtviewClassification.TabIndex = 45
        '
        'lblviewCategory
        '
        Me.lblviewCategory.AutoSize = True
        Me.lblviewCategory.ForeColor = System.Drawing.Color.Black
        Me.lblviewCategory.Location = New System.Drawing.Point(483, 66)
        Me.lblviewCategory.Name = "lblviewCategory"
        Me.lblviewCategory.Size = New System.Drawing.Size(49, 13)
        Me.lblviewCategory.TabIndex = 18
        Me.lblviewCategory.Text = "Category"
        '
        'lblviewRequiredfor
        '
        Me.lblviewRequiredfor.AutoSize = True
        Me.lblviewRequiredfor.ForeColor = System.Drawing.Color.Black
        Me.lblviewRequiredfor.Location = New System.Drawing.Point(116, 123)
        Me.lblviewRequiredfor.Name = "lblviewRequiredfor"
        Me.lblviewRequiredfor.Size = New System.Drawing.Size(68, 13)
        Me.lblviewRequiredfor.TabIndex = 20
        Me.lblviewRequiredfor.Text = "Required For"
        '
        'lblviewClassification
        '
        Me.lblviewClassification.AutoSize = True
        Me.lblviewClassification.ForeColor = System.Drawing.Color.Black
        Me.lblviewClassification.Location = New System.Drawing.Point(678, 66)
        Me.lblviewClassification.Name = "lblviewClassification"
        Me.lblviewClassification.Size = New System.Drawing.Size(68, 13)
        Me.lblviewClassification.TabIndex = 19
        Me.lblviewClassification.Text = "Classification"
        '
        'dgvIRPView
        '
        Me.dgvIRPView.AllowUserToAddRows = False
        Me.dgvIRPView.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvIRPView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIRPView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvIRPView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvIRPView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIRPView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIRPView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIRPView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIRPView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvIPRNo, Me.gvUsageCOAID, Me.gvUsageCOACode, Me.gvUsageCOADescp, Me.gvIPRdate, Me.gvSTCategory, Me.gvClassification, Me.gvlRequiredDate, Me.gvRequiredfor, Me.gvDeliveredto, Me.gvRemarks, Me.gvMainStatus, Me.gvIPRID, Me.gvSTCategoryID, Me.gvMakeModel, Me.gvEngine, Me.gvFixedAssetNo, Me.gvChassisSerialNo, Me.gvCategoryCode, Me.gvRejectedReason})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIRPView.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvIRPView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIRPView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvIRPView.EnableHeadersVisualStyles = False
        Me.dgvIRPView.GridColor = System.Drawing.Color.Gray
        Me.dgvIRPView.Location = New System.Drawing.Point(0, 176)
        Me.dgvIRPView.MultiSelect = False
        Me.dgvIRPView.Name = "dgvIRPView"
        Me.dgvIRPView.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIRPView.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvIRPView.RowHeadersVisible = False
        Me.dgvIRPView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvIRPView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIRPView.ShowCellErrors = False
        Me.dgvIRPView.Size = New System.Drawing.Size(896, 293)
        Me.dgvIRPView.TabIndex = 118
        Me.dgvIRPView.TabStop = False
        '
        'gvIPRNo
        '
        Me.gvIPRNo.DataPropertyName = "IPRNo"
        Me.gvIPRNo.HeaderText = "PR No."
        Me.gvIPRNo.Name = "gvIPRNo"
        Me.gvIPRNo.ReadOnly = True
        Me.gvIPRNo.Width = 69
        '
        'gvUsageCOAID
        '
        Me.gvUsageCOAID.DataPropertyName = "UsageCOAID"
        Me.gvUsageCOAID.HeaderText = "Usage COAID"
        Me.gvUsageCOAID.Name = "gvUsageCOAID"
        Me.gvUsageCOAID.ReadOnly = True
        Me.gvUsageCOAID.Visible = False
        Me.gvUsageCOAID.Width = 110
        '
        'gvUsageCOACode
        '
        Me.gvUsageCOACode.DataPropertyName = "UsageCOACode"
        Me.gvUsageCOACode.HeaderText = "Usage COA Code"
        Me.gvUsageCOACode.Name = "gvUsageCOACode"
        Me.gvUsageCOACode.ReadOnly = True
        Me.gvUsageCOACode.Visible = False
        Me.gvUsageCOACode.Width = 130
        '
        'gvUsageCOADescp
        '
        Me.gvUsageCOADescp.DataPropertyName = "UsageCOADescp"
        Me.gvUsageCOADescp.HeaderText = "Usage COA Descp"
        Me.gvUsageCOADescp.Name = "gvUsageCOADescp"
        Me.gvUsageCOADescp.ReadOnly = True
        Me.gvUsageCOADescp.Visible = False
        Me.gvUsageCOADescp.Width = 135
        '
        'gvIPRdate
        '
        Me.gvIPRdate.DataPropertyName = "IPRdate"
        Me.gvIPRdate.HeaderText = "PR Date"
        Me.gvIPRdate.Name = "gvIPRdate"
        Me.gvIPRdate.ReadOnly = True
        Me.gvIPRdate.Width = 77
        '
        'gvSTCategory
        '
        Me.gvSTCategory.DataPropertyName = "STCategoryDescp"
        Me.gvSTCategory.HeaderText = "Category"
        Me.gvSTCategory.Name = "gvSTCategory"
        Me.gvSTCategory.ReadOnly = True
        Me.gvSTCategory.Width = 84
        '
        'gvClassification
        '
        Me.gvClassification.DataPropertyName = "Classification"
        Me.gvClassification.HeaderText = "Classification"
        Me.gvClassification.Name = "gvClassification"
        Me.gvClassification.ReadOnly = True
        Me.gvClassification.Width = 106
        '
        'gvlRequiredDate
        '
        Me.gvlRequiredDate.DataPropertyName = "RequiredDate"
        Me.gvlRequiredDate.HeaderText = "Required Date"
        Me.gvlRequiredDate.Name = "gvlRequiredDate"
        Me.gvlRequiredDate.ReadOnly = True
        Me.gvlRequiredDate.Width = 113
        '
        'gvRequiredfor
        '
        Me.gvRequiredfor.DataPropertyName = "RequiredFor"
        Me.gvRequiredfor.HeaderText = "Required For"
        Me.gvRequiredfor.Name = "gvRequiredfor"
        Me.gvRequiredfor.ReadOnly = True
        Me.gvRequiredfor.Width = 104
        '
        'gvDeliveredto
        '
        Me.gvDeliveredto.DataPropertyName = "DeliveredTo"
        Me.gvDeliveredto.HeaderText = "Delivered To"
        Me.gvDeliveredto.Name = "gvDeliveredto"
        Me.gvDeliveredto.ReadOnly = True
        Me.gvDeliveredto.Width = 104
        '
        'gvRemarks
        '
        Me.gvRemarks.DataPropertyName = "Remarks"
        Me.gvRemarks.HeaderText = "Remarks"
        Me.gvRemarks.Name = "gvRemarks"
        Me.gvRemarks.ReadOnly = True
        Me.gvRemarks.Visible = False
        Me.gvRemarks.Width = 82
        '
        'gvMainStatus
        '
        Me.gvMainStatus.DataPropertyName = "MainStatus"
        Me.gvMainStatus.HeaderText = "Status"
        Me.gvMainStatus.Name = "gvMainStatus"
        Me.gvMainStatus.ReadOnly = True
        Me.gvMainStatus.Width = 67
        '
        'gvIPRID
        '
        Me.gvIPRID.DataPropertyName = "STIPRID"
        Me.gvIPRID.HeaderText = "PRID"
        Me.gvIPRID.Name = "gvIPRID"
        Me.gvIPRID.ReadOnly = True
        Me.gvIPRID.Visible = False
        Me.gvIPRID.Width = 65
        '
        'gvSTCategoryID
        '
        Me.gvSTCategoryID.DataPropertyName = "STCategoryID"
        Me.gvSTCategoryID.HeaderText = "STCategory ID"
        Me.gvSTCategoryID.Name = "gvSTCategoryID"
        Me.gvSTCategoryID.ReadOnly = True
        Me.gvSTCategoryID.Visible = False
        Me.gvSTCategoryID.Width = 117
        '
        'gvMakeModel
        '
        Me.gvMakeModel.DataPropertyName = "MakeModel"
        Me.gvMakeModel.HeaderText = "Make Model"
        Me.gvMakeModel.Name = "gvMakeModel"
        Me.gvMakeModel.ReadOnly = True
        Me.gvMakeModel.Visible = False
        Me.gvMakeModel.Width = 98
        '
        'gvEngine
        '
        Me.gvEngine.DataPropertyName = "Engine"
        Me.gvEngine.HeaderText = "Engine"
        Me.gvEngine.Name = "gvEngine"
        Me.gvEngine.ReadOnly = True
        Me.gvEngine.Visible = False
        Me.gvEngine.Width = 69
        '
        'gvFixedAssetNo
        '
        Me.gvFixedAssetNo.DataPropertyName = "FixedAssetNo"
        Me.gvFixedAssetNo.HeaderText = "Fixed Asset No."
        Me.gvFixedAssetNo.Name = "gvFixedAssetNo"
        Me.gvFixedAssetNo.ReadOnly = True
        Me.gvFixedAssetNo.Visible = False
        Me.gvFixedAssetNo.Width = 119
        '
        'gvChassisSerialNo
        '
        Me.gvChassisSerialNo.DataPropertyName = "ChassisSerialNo"
        Me.gvChassisSerialNo.HeaderText = "Chassis Serial No."
        Me.gvChassisSerialNo.Name = "gvChassisSerialNo"
        Me.gvChassisSerialNo.ReadOnly = True
        Me.gvChassisSerialNo.Visible = False
        Me.gvChassisSerialNo.Width = 135
        '
        'gvCategoryCode
        '
        Me.gvCategoryCode.DataPropertyName = "STCategoryCode"
        Me.gvCategoryCode.HeaderText = "Category Code"
        Me.gvCategoryCode.Name = "gvCategoryCode"
        Me.gvCategoryCode.ReadOnly = True
        Me.gvCategoryCode.Visible = False
        Me.gvCategoryCode.Width = 118
        '
        'gvRejectedReason
        '
        Me.gvRejectedReason.DataPropertyName = "RejectedReason"
        Me.gvRejectedReason.HeaderText = "Rejected Reason"
        Me.gvRejectedReason.Name = "gvRejectedReason"
        Me.gvRejectedReason.ReadOnly = True
        Me.gvRejectedReason.Visible = False
        Me.gvRejectedReason.Width = 127
        '
        'IPRStatusfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 469)
        Me.Controls.Add(Me.dgvIRPView)
        Me.Controls.Add(Me.pnlIPRStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "IPRStatusfrm"
        Me.Text = "IPRStatusfrm"
        Me.pnlIPRStatus.ResumeLayout(False)
        Me.pnlIPRStatus.PerformLayout()
        CType(Me.dgvIRPView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlIPRStatus As Stepi.UI.ExtendedPanel
    Friend WithEvents chkIPRdate As System.Windows.Forms.CheckBox
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents dtpviewIPRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewIPRDate As System.Windows.Forms.Label
    Friend WithEvents btnviewCategory As System.Windows.Forms.Button
    Friend WithEvents lblviewIPRno As System.Windows.Forms.Label
    Friend WithEvents txtviewIPRNo As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtviewRequiredfor As System.Windows.Forms.TextBox
    Friend WithEvents lblviewMainstatus As System.Windows.Forms.Label
    Friend WithEvents txtviewDeliveredto As System.Windows.Forms.TextBox
    Friend WithEvents txtviewCategory As System.Windows.Forms.TextBox
    Friend WithEvents lblviewDeliveredto As System.Windows.Forms.Label
    Friend WithEvents txtviewClassification As System.Windows.Forms.TextBox
    Friend WithEvents lblviewCategory As System.Windows.Forms.Label
    Friend WithEvents lblviewRequiredfor As System.Windows.Forms.Label
    Friend WithEvents lblviewClassification As System.Windows.Forms.Label
    Friend WithEvents dgvIRPView As System.Windows.Forms.DataGridView
    Friend WithEvents gvIPRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvUsageCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvUsageCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvUsageCOADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvIPRdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvSTCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvClassification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvlRequiredDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvRequiredfor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvDeliveredto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvMainStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvIPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvSTCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvMakeModel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvEngine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvFixedAssetNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvChassisSerialNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvCategoryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

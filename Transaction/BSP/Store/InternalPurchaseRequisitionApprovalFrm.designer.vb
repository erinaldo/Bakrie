<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InternalPurchaseRequisitionApprovalFrm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InternalPurchaseRequisitionApprovalFrm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblNoRecordFound = New System.Windows.Forms.Label()
        Me.dgvIPRApproval = New System.Windows.Forms.DataGridView()
        Me.plIPRSearch = New Stepi.UI.ExtendedPanel()
        Me.chkIPRdate = New System.Windows.Forms.CheckBox()
        Me.dtpviewIPRDate = New System.Windows.Forms.DateTimePicker()
        Me.lblviewIPRDate = New System.Windows.Forms.Label()
        Me.btnviewCategory = New System.Windows.Forms.Button()
        Me.lblviewIPRno = New System.Windows.Forms.Label()
        Me.txtviewIPRNo = New System.Windows.Forms.TextBox()
        Me.txtviewCategory = New System.Windows.Forms.TextBox()
        Me.txtviewRequiredfor = New System.Windows.Forms.TextBox()
        Me.txtviewDeliveredto = New System.Windows.Forms.TextBox()
        Me.lblviewCategory = New System.Windows.Forms.Label()
        Me.lblviewDeliveredto = New System.Windows.Forms.Label()
        Me.lblsearchBy = New System.Windows.Forms.Label()
        Me.txtviewClassification = New System.Windows.Forms.TextBox()
        Me.lblviewRequiredfor = New System.Windows.Forms.Label()
        Me.lblviewClassification = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgclIPRID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclIPRDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclIPRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTCategoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRequiredfor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRequiredDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDeliveredTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclClassification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclMakeModel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclEngine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclFixedAssetNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclChassisSerialNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclModifiedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclViewDetails = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.gvUsageCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvUsageCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvUsageCOADescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MRCNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvIPRApproval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.plIPRSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.lblNoRecordFound)
        Me.Panel1.Controls.Add(Me.dgvIPRApproval)
        Me.Panel1.Controls.Add(Me.plIPRSearch)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(978, 550)
        Me.Panel1.TabIndex = 0
        '
        'lblNoRecordFound
        '
        Me.lblNoRecordFound.AutoSize = True
        Me.lblNoRecordFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecordFound.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecordFound.Location = New System.Drawing.Point(284, 311)
        Me.lblNoRecordFound.Name = "lblNoRecordFound"
        Me.lblNoRecordFound.Size = New System.Drawing.Size(115, 13)
        Me.lblNoRecordFound.TabIndex = 127
        Me.lblNoRecordFound.Text = "No Record Found !"
        '
        'dgvIPRApproval
        '
        Me.dgvIPRApproval.AllowUserToAddRows = False
        Me.dgvIPRApproval.AllowUserToDeleteRows = False
        Me.dgvIPRApproval.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvIPRApproval.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIPRApproval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvIPRApproval.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvIPRApproval.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIPRApproval.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIPRApproval.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPRApproval.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIPRApproval.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclIPRID, Me.dgclIPRDate, Me.dgclIPRNo, Me.dgclCategory, Me.dgclSTCategoryCode, Me.dgclRequiredfor, Me.dgclRequiredDate, Me.dgclD, Me.dgclDeliveredTo, Me.dgclClassification, Me.dgclRemarks, Me.dgclStatus, Me.dgclMakeModel, Me.dgclEngine, Me.dgclFixedAssetNo, Me.dgclChassisSerialNo, Me.dgclModifiedOn, Me.dgclViewDetails, Me.gvUsageCOAID, Me.gvUsageCOACode, Me.gvUsageCOADescp, Me.MRCNo})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPRApproval.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvIPRApproval.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPRApproval.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvIPRApproval.EnableHeadersVisualStyles = False
        Me.dgvIPRApproval.GridColor = System.Drawing.Color.Gray
        Me.dgvIPRApproval.Location = New System.Drawing.Point(0, 176)
        Me.dgvIPRApproval.Name = "dgvIPRApproval"
        Me.dgvIPRApproval.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPRApproval.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvIPRApproval.RowHeadersVisible = False
        Me.dgvIPRApproval.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvIPRApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIPRApproval.ShowCellErrors = False
        Me.dgvIPRApproval.Size = New System.Drawing.Size(978, 374)
        Me.dgvIPRApproval.TabIndex = 111
        Me.dgvIPRApproval.TabStop = False
        '
        'plIPRSearch
        '
        Me.plIPRSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plIPRSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plIPRSearch.BorderColor = System.Drawing.Color.Gray
        Me.plIPRSearch.CaptionColorOne = System.Drawing.Color.White
        Me.plIPRSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plIPRSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plIPRSearch.CaptionSize = 40
        Me.plIPRSearch.CaptionText = "Purchase Requisition Approval"
        Me.plIPRSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.plIPRSearch.Controls.Add(Me.chkIPRdate)
        Me.plIPRSearch.Controls.Add(Me.dtpviewIPRDate)
        Me.plIPRSearch.Controls.Add(Me.lblviewIPRDate)
        Me.plIPRSearch.Controls.Add(Me.btnviewCategory)
        Me.plIPRSearch.Controls.Add(Me.lblviewIPRno)
        Me.plIPRSearch.Controls.Add(Me.txtviewIPRNo)
        Me.plIPRSearch.Controls.Add(Me.txtviewCategory)
        Me.plIPRSearch.Controls.Add(Me.txtviewRequiredfor)
        Me.plIPRSearch.Controls.Add(Me.txtviewDeliveredto)
        Me.plIPRSearch.Controls.Add(Me.lblviewCategory)
        Me.plIPRSearch.Controls.Add(Me.lblviewDeliveredto)
        Me.plIPRSearch.Controls.Add(Me.lblsearchBy)
        Me.plIPRSearch.Controls.Add(Me.txtviewClassification)
        Me.plIPRSearch.Controls.Add(Me.lblviewRequiredfor)
        Me.plIPRSearch.Controls.Add(Me.lblviewClassification)
        Me.plIPRSearch.Controls.Add(Me.btnSearch)
        Me.plIPRSearch.Controls.Add(Me.btnClose)
        Me.plIPRSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plIPRSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plIPRSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plIPRSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.plIPRSearch.ForeColor = System.Drawing.Color.Black
        Me.plIPRSearch.Location = New System.Drawing.Point(0, 0)
        Me.plIPRSearch.Name = "plIPRSearch"
        Me.plIPRSearch.Size = New System.Drawing.Size(978, 176)
        Me.plIPRSearch.TabIndex = 117
        '
        'chkIPRdate
        '
        Me.chkIPRdate.AutoSize = True
        Me.chkIPRdate.Location = New System.Drawing.Point(80, 61)
        Me.chkIPRdate.Name = "chkIPRdate"
        Me.chkIPRdate.Size = New System.Drawing.Size(15, 14)
        Me.chkIPRdate.TabIndex = 101
        Me.chkIPRdate.UseVisualStyleBackColor = True
        '
        'dtpviewIPRDate
        '
        Me.dtpviewIPRDate.Enabled = False
        Me.dtpviewIPRDate.Location = New System.Drawing.Point(35, 84)
        Me.dtpviewIPRDate.Name = "dtpviewIPRDate"
        Me.dtpviewIPRDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpviewIPRDate.TabIndex = 102
        '
        'lblviewIPRDate
        '
        Me.lblviewIPRDate.AutoSize = True
        Me.lblviewIPRDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewIPRDate.ForeColor = System.Drawing.Color.Black
        Me.lblviewIPRDate.Location = New System.Drawing.Point(96, 62)
        Me.lblviewIPRDate.Name = "lblviewIPRDate"
        Me.lblviewIPRDate.Size = New System.Drawing.Size(53, 13)
        Me.lblviewIPRDate.TabIndex = 119
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
        Me.btnviewCategory.Location = New System.Drawing.Point(558, 75)
        Me.btnviewCategory.Name = "btnviewCategory"
        Me.btnviewCategory.Size = New System.Drawing.Size(30, 33)
        Me.btnviewCategory.TabIndex = 105
        Me.btnviewCategory.TabStop = False
        Me.btnviewCategory.UseVisualStyleBackColor = True
        '
        'lblviewIPRno
        '
        Me.lblviewIPRno.AutoSize = True
        Me.lblviewIPRno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewIPRno.ForeColor = System.Drawing.Color.Black
        Me.lblviewIPRno.Location = New System.Drawing.Point(261, 61)
        Me.lblviewIPRno.Name = "lblviewIPRno"
        Me.lblviewIPRno.Size = New System.Drawing.Size(45, 13)
        Me.lblviewIPRno.TabIndex = 120
        Me.lblviewIPRno.Text = "PR No."
        '
        'txtviewIPRNo
        '
        Me.txtviewIPRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewIPRNo.Location = New System.Drawing.Point(211, 84)
        Me.txtviewIPRNo.MaxLength = 50
        Me.txtviewIPRNo.Name = "txtviewIPRNo"
        Me.txtviewIPRNo.Size = New System.Drawing.Size(165, 20)
        Me.txtviewIPRNo.TabIndex = 103
        '
        'txtviewCategory
        '
        Me.txtviewCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewCategory.Location = New System.Drawing.Point(387, 84)
        Me.txtviewCategory.MaxLength = 50
        Me.txtviewCategory.Name = "txtviewCategory"
        Me.txtviewCategory.Size = New System.Drawing.Size(165, 20)
        Me.txtviewCategory.TabIndex = 104
        '
        'txtviewRequiredfor
        '
        Me.txtviewRequiredfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewRequiredfor.Location = New System.Drawing.Point(211, 141)
        Me.txtviewRequiredfor.MaxLength = 50
        Me.txtviewRequiredfor.Name = "txtviewRequiredfor"
        Me.txtviewRequiredfor.Size = New System.Drawing.Size(165, 20)
        Me.txtviewRequiredfor.TabIndex = 107
        '
        'txtviewDeliveredto
        '
        Me.txtviewDeliveredto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewDeliveredto.Location = New System.Drawing.Point(387, 141)
        Me.txtviewDeliveredto.MaxLength = 50
        Me.txtviewDeliveredto.Name = "txtviewDeliveredto"
        Me.txtviewDeliveredto.Size = New System.Drawing.Size(165, 20)
        Me.txtviewDeliveredto.TabIndex = 108
        '
        'lblviewCategory
        '
        Me.lblviewCategory.AutoSize = True
        Me.lblviewCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewCategory.ForeColor = System.Drawing.Color.Black
        Me.lblviewCategory.Location = New System.Drawing.Point(430, 63)
        Me.lblviewCategory.Name = "lblviewCategory"
        Me.lblviewCategory.Size = New System.Drawing.Size(60, 13)
        Me.lblviewCategory.TabIndex = 121
        Me.lblviewCategory.Text = "Category"
        '
        'lblviewDeliveredto
        '
        Me.lblviewDeliveredto.AutoSize = True
        Me.lblviewDeliveredto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewDeliveredto.ForeColor = System.Drawing.Color.Black
        Me.lblviewDeliveredto.Location = New System.Drawing.Point(425, 120)
        Me.lblviewDeliveredto.Name = "lblviewDeliveredto"
        Me.lblviewDeliveredto.Size = New System.Drawing.Size(80, 13)
        Me.lblviewDeliveredto.TabIndex = 124
        Me.lblviewDeliveredto.Text = "Delivered To"
        '
        'lblsearchBy
        '
        Me.lblsearchBy.AutoSize = True
        Me.lblsearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblsearchBy.Location = New System.Drawing.Point(1, 41)
        Me.lblsearchBy.Name = "lblsearchBy"
        Me.lblsearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchBy.TabIndex = 54
        Me.lblsearchBy.Text = "Search By"
        '
        'txtviewClassification
        '
        Me.txtviewClassification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewClassification.Location = New System.Drawing.Point(35, 141)
        Me.txtviewClassification.MaxLength = 50
        Me.txtviewClassification.Name = "txtviewClassification"
        Me.txtviewClassification.Size = New System.Drawing.Size(165, 20)
        Me.txtviewClassification.TabIndex = 106
        '
        'lblviewRequiredfor
        '
        Me.lblviewRequiredfor.AutoSize = True
        Me.lblviewRequiredfor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewRequiredfor.ForeColor = System.Drawing.Color.Black
        Me.lblviewRequiredfor.Location = New System.Drawing.Point(253, 120)
        Me.lblviewRequiredfor.Name = "lblviewRequiredfor"
        Me.lblviewRequiredfor.Size = New System.Drawing.Size(80, 13)
        Me.lblviewRequiredfor.TabIndex = 123
        Me.lblviewRequiredfor.Text = "Required For"
        '
        'lblviewClassification
        '
        Me.lblviewClassification.AutoSize = True
        Me.lblviewClassification.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewClassification.ForeColor = System.Drawing.Color.Black
        Me.lblviewClassification.Location = New System.Drawing.Point(76, 120)
        Me.lblviewClassification.Name = "lblviewClassification"
        Me.lblviewClassification.Size = New System.Drawing.Size(82, 13)
        Me.lblviewClassification.TabIndex = 122
        Me.lblviewClassification.Text = "Classification"
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(592, 136)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 109
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(715, 136)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 25)
        Me.btnClose.TabIndex = 110
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dgclIPRID
        '
        Me.dgclIPRID.DataPropertyName = "STIPRID"
        Me.dgclIPRID.HeaderText = "STPR ID"
        Me.dgclIPRID.Name = "dgclIPRID"
        Me.dgclIPRID.ReadOnly = True
        Me.dgclIPRID.Visible = False
        Me.dgclIPRID.Width = 79
        '
        'dgclIPRDate
        '
        Me.dgclIPRDate.DataPropertyName = "IPRdate"
        Me.dgclIPRDate.HeaderText = "PR Date"
        Me.dgclIPRDate.Name = "dgclIPRDate"
        Me.dgclIPRDate.ReadOnly = True
        Me.dgclIPRDate.Width = 77
        '
        'dgclIPRNo
        '
        Me.dgclIPRNo.DataPropertyName = "IPRNo"
        Me.dgclIPRNo.HeaderText = "PR No."
        Me.dgclIPRNo.Name = "dgclIPRNo"
        Me.dgclIPRNo.ReadOnly = True
        Me.dgclIPRNo.Width = 69
        '
        'dgclCategory
        '
        Me.dgclCategory.DataPropertyName = "STCategoryDescp"
        Me.dgclCategory.HeaderText = "Category"
        Me.dgclCategory.Name = "dgclCategory"
        Me.dgclCategory.ReadOnly = True
        Me.dgclCategory.Width = 84
        '
        'dgclSTCategoryCode
        '
        Me.dgclSTCategoryCode.DataPropertyName = "STCategoryCode"
        Me.dgclSTCategoryCode.HeaderText = "STCategory Code"
        Me.dgclSTCategoryCode.Name = "dgclSTCategoryCode"
        Me.dgclSTCategoryCode.ReadOnly = True
        Me.dgclSTCategoryCode.Visible = False
        Me.dgclSTCategoryCode.Width = 133
        '
        'dgclRequiredfor
        '
        Me.dgclRequiredfor.DataPropertyName = "RequiredFor"
        Me.dgclRequiredfor.HeaderText = "Required For"
        Me.dgclRequiredfor.Name = "dgclRequiredfor"
        Me.dgclRequiredfor.ReadOnly = True
        Me.dgclRequiredfor.Width = 104
        '
        'dgclRequiredDate
        '
        Me.dgclRequiredDate.DataPropertyName = "RequiredDate"
        Me.dgclRequiredDate.HeaderText = "RequiredDate"
        Me.dgclRequiredDate.Name = "dgclRequiredDate"
        Me.dgclRequiredDate.ReadOnly = True
        Me.dgclRequiredDate.Visible = False
        Me.dgclRequiredDate.Width = 109
        '
        'dgclD
        '
        Me.dgclD.DataPropertyName = "D"
        Me.dgclD.HeaderText = "D"
        Me.dgclD.Name = "dgclD"
        Me.dgclD.ReadOnly = True
        Me.dgclD.Visible = False
        Me.dgclD.Width = 40
        '
        'dgclDeliveredTo
        '
        Me.dgclDeliveredTo.DataPropertyName = "DeliveredTo"
        Me.dgclDeliveredTo.HeaderText = "Delivered To"
        Me.dgclDeliveredTo.Name = "dgclDeliveredTo"
        Me.dgclDeliveredTo.ReadOnly = True
        Me.dgclDeliveredTo.Width = 104
        '
        'dgclClassification
        '
        Me.dgclClassification.DataPropertyName = "Classification"
        Me.dgclClassification.HeaderText = "Classification"
        Me.dgclClassification.Name = "dgclClassification"
        Me.dgclClassification.ReadOnly = True
        Me.dgclClassification.Width = 106
        '
        'dgclRemarks
        '
        Me.dgclRemarks.DataPropertyName = "Remarks"
        Me.dgclRemarks.HeaderText = "Remarks"
        Me.dgclRemarks.Name = "dgclRemarks"
        Me.dgclRemarks.ReadOnly = True
        Me.dgclRemarks.Visible = False
        Me.dgclRemarks.Width = 82
        '
        'dgclStatus
        '
        Me.dgclStatus.DataPropertyName = "MainStatus"
        Me.dgclStatus.HeaderText = "Status"
        Me.dgclStatus.Name = "dgclStatus"
        Me.dgclStatus.ReadOnly = True
        Me.dgclStatus.Width = 67
        '
        'dgclMakeModel
        '
        Me.dgclMakeModel.DataPropertyName = "MakeModel"
        Me.dgclMakeModel.HeaderText = "Make Model"
        Me.dgclMakeModel.Name = "dgclMakeModel"
        Me.dgclMakeModel.ReadOnly = True
        Me.dgclMakeModel.Visible = False
        Me.dgclMakeModel.Width = 98
        '
        'dgclEngine
        '
        Me.dgclEngine.DataPropertyName = "Engine"
        Me.dgclEngine.HeaderText = "Engine"
        Me.dgclEngine.Name = "dgclEngine"
        Me.dgclEngine.ReadOnly = True
        Me.dgclEngine.Visible = False
        Me.dgclEngine.Width = 69
        '
        'dgclFixedAssetNo
        '
        Me.dgclFixedAssetNo.DataPropertyName = "FixedAssetNo"
        Me.dgclFixedAssetNo.HeaderText = "FixedAssetNo"
        Me.dgclFixedAssetNo.Name = "dgclFixedAssetNo"
        Me.dgclFixedAssetNo.ReadOnly = True
        Me.dgclFixedAssetNo.Visible = False
        Me.dgclFixedAssetNo.Width = 107
        '
        'dgclChassisSerialNo
        '
        Me.dgclChassisSerialNo.DataPropertyName = "ChassisSerialNo"
        Me.dgclChassisSerialNo.HeaderText = "Chassis Serial No."
        Me.dgclChassisSerialNo.Name = "dgclChassisSerialNo"
        Me.dgclChassisSerialNo.ReadOnly = True
        Me.dgclChassisSerialNo.Visible = False
        Me.dgclChassisSerialNo.Width = 135
        '
        'dgclModifiedOn
        '
        Me.dgclModifiedOn.DataPropertyName = "ModifiedOn"
        Me.dgclModifiedOn.HeaderText = "Modified On"
        Me.dgclModifiedOn.Name = "dgclModifiedOn"
        Me.dgclModifiedOn.ReadOnly = True
        Me.dgclModifiedOn.Visible = False
        Me.dgclModifiedOn.Width = 98
        '
        'dgclViewDetails
        '
        Me.dgclViewDetails.HeaderText = "View Details"
        Me.dgclViewDetails.Name = "dgclViewDetails"
        Me.dgclViewDetails.ReadOnly = True
        Me.dgclViewDetails.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgclViewDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgclViewDetails.Text = "View Details"
        Me.dgclViewDetails.UseColumnTextForButtonValue = True
        Me.dgclViewDetails.Width = 101
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
        Me.gvUsageCOADescp.HeaderText = "UsageCOADescp"
        Me.gvUsageCOADescp.Name = "gvUsageCOADescp"
        Me.gvUsageCOADescp.ReadOnly = True
        Me.gvUsageCOADescp.Visible = False
        Me.gvUsageCOADescp.Width = 127
        '
        'MRCNo
        '
        Me.MRCNo.DataPropertyName = "MRCNo"
        Me.MRCNo.HeaderText = "MRCNo"
        Me.MRCNo.Name = "MRCNo"
        Me.MRCNo.ReadOnly = True
        Me.MRCNo.Visible = False
        Me.MRCNo.Width = 72
        '
        'InternalPurchaseRequisitionApprovalFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(978, 550)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "InternalPurchaseRequisitionApprovalFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InternalPurchaseRequisitionApprovalFrm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvIPRApproval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.plIPRSearch.ResumeLayout(False)
        Me.plIPRSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents plIPRSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvIPRApproval As System.Windows.Forms.DataGridView
    Friend WithEvents chkIPRdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpviewIPRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewIPRDate As System.Windows.Forms.Label
    Friend WithEvents btnviewCategory As System.Windows.Forms.Button
    Friend WithEvents lblviewIPRno As System.Windows.Forms.Label
    Friend WithEvents txtviewIPRNo As System.Windows.Forms.TextBox
    Friend WithEvents txtviewRequiredfor As System.Windows.Forms.TextBox
    Friend WithEvents txtviewDeliveredto As System.Windows.Forms.TextBox
    Friend WithEvents txtviewCategory As System.Windows.Forms.TextBox
    Friend WithEvents lblviewDeliveredto As System.Windows.Forms.Label
    Friend WithEvents txtviewClassification As System.Windows.Forms.TextBox
    Friend WithEvents lblviewCategory As System.Windows.Forms.Label
    Friend WithEvents lblviewRequiredfor As System.Windows.Forms.Label
    Friend WithEvents lblviewClassification As System.Windows.Forms.Label
    Friend WithEvents lblNoRecordFound As System.Windows.Forms.Label
    Friend WithEvents dgclIPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIPRDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIPRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTCategoryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRequiredfor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRequiredDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDeliveredTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclClassification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclMakeModel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclEngine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclFixedAssetNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclChassisSerialNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclModifiedOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclViewDetails As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents gvUsageCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvUsageCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvUsageCOADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MRCNo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstateMillDeliveryNoteApprovalFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstateMillDeliveryNoteApprovalFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.plEMDNSearch = New Stepi.UI.ExtendedPanel()
        Me.cbviewPONo = New System.Windows.Forms.TextBox()
        Me.ChkLPO = New System.Windows.Forms.CheckBox()
        Me.ChkIPR = New System.Windows.Forms.CheckBox()
        Me.txtviewSupplier = New System.Windows.Forms.TextBox()
        Me.txtviewGRNNo = New System.Windows.Forms.TextBox()
        Me.cbviewDeliverySource = New System.Windows.Forms.ComboBox()
        Me.txtviewIDNNo = New System.Windows.Forms.TextBox()
        Me.cbviewLPONo = New System.Windows.Forms.ComboBox()
        Me.cbviewIPRNo = New System.Windows.Forms.ComboBox()
        Me.cbviewTransType = New System.Windows.Forms.ComboBox()
        Me.lblviewSupplier = New System.Windows.Forms.Label()
        Me.lblviewPONo = New System.Windows.Forms.Label()
        Me.lblviewLPONo = New System.Windows.Forms.Label()
        Me.lblviewDeliverySource = New System.Windows.Forms.Label()
        Me.lblviewIPRNo = New System.Windows.Forms.Label()
        Me.lblviewGRNNo = New System.Windows.Forms.Label()
        Me.lblsearchCategory = New System.Windows.Forms.Label()
        Me.chkIDNDate = New System.Windows.Forms.CheckBox()
        Me.dtpviewIDNDate = New System.Windows.Forms.DateTimePicker()
        Me.lblviewIDNDate = New System.Windows.Forms.Label()
        Me.btnviewReport = New System.Windows.Forms.Button()
        Me.lblviewIDNNo = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cbviewStatus = New System.Windows.Forms.ComboBox()
        Me.lblviewTransType = New System.Windows.Forms.Label()
        Me.lblviewMainstatus = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblNoRecordFound = New System.Windows.Forms.Label()
        Me.dgvIDNView = New System.Windows.Forms.DataGridView()
        Me.dgclSTEstMillDeliveryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclIDNDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclIDNNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclGRNNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclIPRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLPONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDeliverySource = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSupplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSupplierID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclOperatorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTransportDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclVehicleNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclViewDetails = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgclSupplierCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTIPRID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTLPOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plEMDNSearch.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvIDNView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'plEMDNSearch
        '
        Me.plEMDNSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plEMDNSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plEMDNSearch.BorderColor = System.Drawing.Color.Gray
        Me.plEMDNSearch.CaptionColorOne = System.Drawing.Color.White
        Me.plEMDNSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plEMDNSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plEMDNSearch.CaptionSize = 40
        Me.plEMDNSearch.CaptionText = "Search DN  Details"
        Me.plEMDNSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.plEMDNSearch.Controls.Add(Me.cbviewPONo)
        Me.plEMDNSearch.Controls.Add(Me.ChkLPO)
        Me.plEMDNSearch.Controls.Add(Me.ChkIPR)
        Me.plEMDNSearch.Controls.Add(Me.txtviewSupplier)
        Me.plEMDNSearch.Controls.Add(Me.txtviewGRNNo)
        Me.plEMDNSearch.Controls.Add(Me.cbviewDeliverySource)
        Me.plEMDNSearch.Controls.Add(Me.txtviewIDNNo)
        Me.plEMDNSearch.Controls.Add(Me.cbviewLPONo)
        Me.plEMDNSearch.Controls.Add(Me.cbviewIPRNo)
        Me.plEMDNSearch.Controls.Add(Me.cbviewTransType)
        Me.plEMDNSearch.Controls.Add(Me.lblviewSupplier)
        Me.plEMDNSearch.Controls.Add(Me.lblviewPONo)
        Me.plEMDNSearch.Controls.Add(Me.lblviewLPONo)
        Me.plEMDNSearch.Controls.Add(Me.lblviewDeliverySource)
        Me.plEMDNSearch.Controls.Add(Me.lblviewIPRNo)
        Me.plEMDNSearch.Controls.Add(Me.lblviewGRNNo)
        Me.plEMDNSearch.Controls.Add(Me.lblsearchCategory)
        Me.plEMDNSearch.Controls.Add(Me.chkIDNDate)
        Me.plEMDNSearch.Controls.Add(Me.dtpviewIDNDate)
        Me.plEMDNSearch.Controls.Add(Me.lblviewIDNDate)
        Me.plEMDNSearch.Controls.Add(Me.btnviewReport)
        Me.plEMDNSearch.Controls.Add(Me.lblviewIDNNo)
        Me.plEMDNSearch.Controls.Add(Me.btnSearch)
        Me.plEMDNSearch.Controls.Add(Me.cbviewStatus)
        Me.plEMDNSearch.Controls.Add(Me.lblviewTransType)
        Me.plEMDNSearch.Controls.Add(Me.lblviewMainstatus)
        Me.plEMDNSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plEMDNSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plEMDNSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plEMDNSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.plEMDNSearch.ForeColor = System.Drawing.Color.Black
        Me.plEMDNSearch.Location = New System.Drawing.Point(0, 0)
        Me.plEMDNSearch.Name = "plEMDNSearch"
        Me.plEMDNSearch.Size = New System.Drawing.Size(985, 213)
        Me.plEMDNSearch.TabIndex = 147
        '
        'cbviewPONo
        '
        Me.cbviewPONo.Location = New System.Drawing.Point(225, 133)
        Me.cbviewPONo.Name = "cbviewPONo"
        Me.cbviewPONo.Size = New System.Drawing.Size(165, 20)
        Me.cbviewPONo.TabIndex = 10
        '
        'ChkLPO
        '
        Me.ChkLPO.AutoSize = True
        Me.ChkLPO.Location = New System.Drawing.Point(38, 113)
        Me.ChkLPO.Name = "ChkLPO"
        Me.ChkLPO.Size = New System.Drawing.Size(15, 14)
        Me.ChkLPO.TabIndex = 8
        Me.ChkLPO.UseVisualStyleBackColor = True
        '
        'ChkIPR
        '
        Me.ChkIPR.AutoSize = True
        Me.ChkIPR.Location = New System.Drawing.Point(786, 57)
        Me.ChkIPR.Name = "ChkIPR"
        Me.ChkIPR.Size = New System.Drawing.Size(15, 14)
        Me.ChkIPR.TabIndex = 6
        Me.ChkIPR.UseVisualStyleBackColor = True
        '
        'txtviewSupplier
        '
        Me.txtviewSupplier.Location = New System.Drawing.Point(411, 133)
        Me.txtviewSupplier.Name = "txtviewSupplier"
        Me.txtviewSupplier.Size = New System.Drawing.Size(165, 20)
        Me.txtviewSupplier.TabIndex = 12
        '
        'txtviewGRNNo
        '
        Me.txtviewGRNNo.Location = New System.Drawing.Point(411, 79)
        Me.txtviewGRNNo.Name = "txtviewGRNNo"
        Me.txtviewGRNNo.Size = New System.Drawing.Size(165, 20)
        Me.txtviewGRNNo.TabIndex = 4
        '
        'cbviewDeliverySource
        '
        Me.cbviewDeliverySource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbviewDeliverySource.FormattingEnabled = True
        Me.cbviewDeliverySource.Items.AddRange(New Object() {"Samarinda", "Consignment"})
        Me.cbviewDeliverySource.Location = New System.Drawing.Point(38, 178)
        Me.cbviewDeliverySource.MaxLength = 50
        Me.cbviewDeliverySource.Name = "cbviewDeliverySource"
        Me.cbviewDeliverySource.Size = New System.Drawing.Size(165, 21)
        Me.cbviewDeliverySource.TabIndex = 11
        Me.cbviewDeliverySource.Visible = False
        '
        'txtviewIDNNo
        '
        Me.txtviewIDNNo.Location = New System.Drawing.Point(225, 78)
        Me.txtviewIDNNo.Name = "txtviewIDNNo"
        Me.txtviewIDNNo.Size = New System.Drawing.Size(165, 20)
        Me.txtviewIDNNo.TabIndex = 3
        '
        'cbviewLPONo
        '
        Me.cbviewLPONo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbviewLPONo.FormattingEnabled = True
        Me.cbviewLPONo.Items.AddRange(New Object() {"--SELECT--"})
        Me.cbviewLPONo.Location = New System.Drawing.Point(38, 132)
        Me.cbviewLPONo.MaxLength = 50
        Me.cbviewLPONo.Name = "cbviewLPONo"
        Me.cbviewLPONo.Size = New System.Drawing.Size(165, 21)
        Me.cbviewLPONo.TabIndex = 9
        '
        'cbviewIPRNo
        '
        Me.cbviewIPRNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbviewIPRNo.FormattingEnabled = True
        Me.cbviewIPRNo.Items.AddRange(New Object() {"--SELECT--"})
        Me.cbviewIPRNo.Location = New System.Drawing.Point(785, 77)
        Me.cbviewIPRNo.MaxLength = 50
        Me.cbviewIPRNo.Name = "cbviewIPRNo"
        Me.cbviewIPRNo.Size = New System.Drawing.Size(165, 21)
        Me.cbviewIPRNo.TabIndex = 7
        '
        'cbviewTransType
        '
        Me.cbviewTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbviewTransType.FormattingEnabled = True
        Me.cbviewTransType.Items.AddRange(New Object() {"PR", "PO"})
        Me.cbviewTransType.Location = New System.Drawing.Point(601, 77)
        Me.cbviewTransType.MaxLength = 50
        Me.cbviewTransType.Name = "cbviewTransType"
        Me.cbviewTransType.Size = New System.Drawing.Size(165, 21)
        Me.cbviewTransType.TabIndex = 5
        '
        'lblviewSupplier
        '
        Me.lblviewSupplier.AutoSize = True
        Me.lblviewSupplier.ForeColor = System.Drawing.Color.Black
        Me.lblviewSupplier.Location = New System.Drawing.Point(411, 114)
        Me.lblviewSupplier.Name = "lblviewSupplier"
        Me.lblviewSupplier.Size = New System.Drawing.Size(45, 13)
        Me.lblviewSupplier.TabIndex = 126
        Me.lblviewSupplier.Text = "Supplier"
        '
        'lblviewPONo
        '
        Me.lblviewPONo.AutoSize = True
        Me.lblviewPONo.ForeColor = System.Drawing.Color.Black
        Me.lblviewPONo.Location = New System.Drawing.Point(225, 113)
        Me.lblviewPONo.Name = "lblviewPONo"
        Me.lblviewPONo.Size = New System.Drawing.Size(42, 13)
        Me.lblviewPONo.TabIndex = 124
        Me.lblviewPONo.Text = "PO No."
        '
        'lblviewLPONo
        '
        Me.lblviewLPONo.AutoSize = True
        Me.lblviewLPONo.ForeColor = System.Drawing.Color.Black
        Me.lblviewLPONo.Location = New System.Drawing.Point(58, 113)
        Me.lblviewLPONo.Name = "lblviewLPONo"
        Me.lblviewLPONo.Size = New System.Drawing.Size(42, 13)
        Me.lblviewLPONo.TabIndex = 120
        Me.lblviewLPONo.Text = "PO No."
        '
        'lblviewDeliverySource
        '
        Me.lblviewDeliverySource.AutoSize = True
        Me.lblviewDeliverySource.ForeColor = System.Drawing.Color.Black
        Me.lblviewDeliverySource.Location = New System.Drawing.Point(38, 159)
        Me.lblviewDeliverySource.Name = "lblviewDeliverySource"
        Me.lblviewDeliverySource.Size = New System.Drawing.Size(82, 13)
        Me.lblviewDeliverySource.TabIndex = 121
        Me.lblviewDeliverySource.Text = "Delivery Source"
        Me.lblviewDeliverySource.Visible = False
        '
        'lblviewIPRNo
        '
        Me.lblviewIPRNo.AutoSize = True
        Me.lblviewIPRNo.ForeColor = System.Drawing.Color.Black
        Me.lblviewIPRNo.Location = New System.Drawing.Point(804, 57)
        Me.lblviewIPRNo.Name = "lblviewIPRNo"
        Me.lblviewIPRNo.Size = New System.Drawing.Size(42, 13)
        Me.lblviewIPRNo.TabIndex = 118
        Me.lblviewIPRNo.Text = "PR No."
        '
        'lblviewGRNNo
        '
        Me.lblviewGRNNo.AutoSize = True
        Me.lblviewGRNNo.ForeColor = System.Drawing.Color.Black
        Me.lblviewGRNNo.Location = New System.Drawing.Point(411, 57)
        Me.lblviewGRNNo.Name = "lblviewGRNNo"
        Me.lblviewGRNNo.Size = New System.Drawing.Size(51, 13)
        Me.lblviewGRNNo.TabIndex = 116
        Me.lblviewGRNNo.Text = "MRC No."
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
        'chkIDNDate
        '
        Me.chkIDNDate.AutoSize = True
        Me.chkIDNDate.Location = New System.Drawing.Point(38, 57)
        Me.chkIDNDate.Name = "chkIDNDate"
        Me.chkIDNDate.Size = New System.Drawing.Size(15, 14)
        Me.chkIDNDate.TabIndex = 1
        Me.chkIDNDate.UseVisualStyleBackColor = True
        '
        'dtpviewIDNDate
        '
        Me.dtpviewIDNDate.Enabled = False
        Me.dtpviewIDNDate.Location = New System.Drawing.Point(38, 77)
        Me.dtpviewIDNDate.Name = "dtpviewIDNDate"
        Me.dtpviewIDNDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpviewIDNDate.TabIndex = 2
        '
        'lblviewIDNDate
        '
        Me.lblviewIDNDate.AutoSize = True
        Me.lblviewIDNDate.ForeColor = System.Drawing.Color.Black
        Me.lblviewIDNDate.Location = New System.Drawing.Point(58, 57)
        Me.lblviewIDNDate.Name = "lblviewIDNDate"
        Me.lblviewIDNDate.Size = New System.Drawing.Size(49, 13)
        Me.lblviewIDNDate.TabIndex = 16
        Me.lblviewIDNDate.Text = "DN Date"
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(822, 174)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(128, 25)
        Me.btnviewReport.TabIndex = 15
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'lblviewIDNNo
        '
        Me.lblviewIDNNo.AutoSize = True
        Me.lblviewIDNNo.ForeColor = System.Drawing.Color.Black
        Me.lblviewIDNNo.Location = New System.Drawing.Point(225, 57)
        Me.lblviewIDNNo.Name = "lblviewIDNNo"
        Me.lblviewIDNNo.Size = New System.Drawing.Size(43, 13)
        Me.lblviewIDNNo.TabIndex = 17
        Me.lblviewIDNNo.Text = "DN No."
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(699, 174)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 14
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cbviewStatus
        '
        Me.cbviewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbviewStatus.FormattingEnabled = True
        Me.cbviewStatus.Items.AddRange(New Object() {"OPEN", "MANAGER APPROVED", "REJECTED", "SELECT ALL"})
        Me.cbviewStatus.Location = New System.Drawing.Point(595, 133)
        Me.cbviewStatus.MaxLength = 50
        Me.cbviewStatus.Name = "cbviewStatus"
        Me.cbviewStatus.Size = New System.Drawing.Size(165, 21)
        Me.cbviewStatus.TabIndex = 13
        Me.cbviewStatus.Visible = False
        '
        'lblviewTransType
        '
        Me.lblviewTransType.AutoSize = True
        Me.lblviewTransType.ForeColor = System.Drawing.Color.Black
        Me.lblviewTransType.Location = New System.Drawing.Point(601, 57)
        Me.lblviewTransType.Name = "lblviewTransType"
        Me.lblviewTransType.Size = New System.Drawing.Size(64, 13)
        Me.lblviewTransType.TabIndex = 18
        Me.lblviewTransType.Text = "Trans. Type"
        '
        'lblviewMainstatus
        '
        Me.lblviewMainstatus.AutoSize = True
        Me.lblviewMainstatus.ForeColor = System.Drawing.Color.Black
        Me.lblviewMainstatus.Location = New System.Drawing.Point(596, 114)
        Me.lblviewMainstatus.Name = "lblviewMainstatus"
        Me.lblviewMainstatus.Size = New System.Drawing.Size(37, 13)
        Me.lblviewMainstatus.TabIndex = 22
        Me.lblviewMainstatus.Text = "Status"
        Me.lblviewMainstatus.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.lblNoRecordFound)
        Me.Panel1.Controls.Add(Me.dgvIDNView)
        Me.Panel1.Location = New System.Drawing.Point(0, 219)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(985, 287)
        Me.Panel1.TabIndex = 167
        '
        'lblNoRecordFound
        '
        Me.lblNoRecordFound.AutoSize = True
        Me.lblNoRecordFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecordFound.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecordFound.Location = New System.Drawing.Point(435, 137)
        Me.lblNoRecordFound.Name = "lblNoRecordFound"
        Me.lblNoRecordFound.Size = New System.Drawing.Size(115, 13)
        Me.lblNoRecordFound.TabIndex = 8
        Me.lblNoRecordFound.Text = "No Record Found !"
        '
        'dgvIDNView
        '
        Me.dgvIDNView.AllowUserToAddRows = False
        Me.dgvIDNView.AllowUserToDeleteRows = False
        Me.dgvIDNView.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvIDNView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIDNView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvIDNView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvIDNView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIDNView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIDNView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIDNView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIDNView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclSTEstMillDeliveryID, Me.dgclIDNDate, Me.dgclTransType, Me.dgclIDNNo, Me.dgclGRNNo, Me.dgclIPRNo, Me.dgclLPONo, Me.dgclPONo, Me.dgclDeliverySource, Me.dgclSupplier, Me.dgclSupplierID, Me.dgclStatus, Me.dgclOperatorName, Me.dgclTransportDate, Me.dgclVehicleNo, Me.dgclRemarks, Me.dgclRejectedReason, Me.dgclViewDetails, Me.dgclSupplierCOAID, Me.dgclSTIPRID, Me.dgclSTLPOID, Me.dgclT0, Me.dgclT1, Me.dgclT2, Me.dgclT3, Me.dgclT4})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIDNView.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvIDNView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIDNView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvIDNView.EnableHeadersVisualStyles = False
        Me.dgvIDNView.GridColor = System.Drawing.Color.Gray
        Me.dgvIDNView.Location = New System.Drawing.Point(0, 0)
        Me.dgvIDNView.Name = "dgvIDNView"
        Me.dgvIDNView.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIDNView.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvIDNView.RowHeadersVisible = False
        Me.dgvIDNView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvIDNView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIDNView.ShowCellErrors = False
        Me.dgvIDNView.Size = New System.Drawing.Size(985, 287)
        Me.dgvIDNView.TabIndex = 16
        Me.dgvIDNView.TabStop = False
        '
        'dgclSTEstMillDeliveryID
        '
        Me.dgclSTEstMillDeliveryID.DataPropertyName = "STEstMillDeliveryID"
        Me.dgclSTEstMillDeliveryID.HeaderText = "Estate Mill Delivery ID"
        Me.dgclSTEstMillDeliveryID.Name = "dgclSTEstMillDeliveryID"
        Me.dgclSTEstMillDeliveryID.ReadOnly = True
        Me.dgclSTEstMillDeliveryID.Visible = False
        Me.dgclSTEstMillDeliveryID.Width = 158
        '
        'dgclIDNDate
        '
        Me.dgclIDNDate.DataPropertyName = "IDNDate"
        Me.dgclIDNDate.HeaderText = "DN Date"
        Me.dgclIDNDate.Name = "dgclIDNDate"
        Me.dgclIDNDate.ReadOnly = True
        Me.dgclIDNDate.Width = 79
        '
        'dgclTransType
        '
        Me.dgclTransType.DataPropertyName = "LPOorIPR"
        Me.dgclTransType.HeaderText = "Trans. Type"
        Me.dgclTransType.Name = "dgclTransType"
        Me.dgclTransType.ReadOnly = True
        Me.dgclTransType.Width = 99
        '
        'dgclIDNNo
        '
        Me.dgclIDNNo.DataPropertyName = "IDNNo"
        Me.dgclIDNNo.HeaderText = "DN No."
        Me.dgclIDNNo.Name = "dgclIDNNo"
        Me.dgclIDNNo.ReadOnly = True
        Me.dgclIDNNo.Width = 71
        '
        'dgclGRNNo
        '
        Me.dgclGRNNo.DataPropertyName = "GRNNo"
        Me.dgclGRNNo.HeaderText = "MRC No."
        Me.dgclGRNNo.Name = "dgclGRNNo"
        Me.dgclGRNNo.ReadOnly = True
        Me.dgclGRNNo.Width = 80
        '
        'dgclIPRNo
        '
        Me.dgclIPRNo.DataPropertyName = "IPRNo"
        Me.dgclIPRNo.HeaderText = "PR No."
        Me.dgclIPRNo.Name = "dgclIPRNo"
        Me.dgclIPRNo.ReadOnly = True
        Me.dgclIPRNo.Width = 69
        '
        'dgclLPONo
        '
        Me.dgclLPONo.DataPropertyName = "LPONo"
        Me.dgclLPONo.HeaderText = "PO No."
        Me.dgclLPONo.Name = "dgclLPONo"
        Me.dgclLPONo.ReadOnly = True
        Me.dgclLPONo.Width = 70
        '
        'dgclPONo
        '
        Me.dgclPONo.DataPropertyName = "PONo"
        Me.dgclPONo.HeaderText = "PO No."
        Me.dgclPONo.Name = "dgclPONo"
        Me.dgclPONo.ReadOnly = True
        Me.dgclPONo.Width = 70
        '
        'dgclDeliverySource
        '
        Me.dgclDeliverySource.DataPropertyName = "DeliverySource"
        Me.dgclDeliverySource.HeaderText = "Delivery Source"
        Me.dgclDeliverySource.Name = "dgclDeliverySource"
        Me.dgclDeliverySource.ReadOnly = True
        Me.dgclDeliverySource.Width = 123
        '
        'dgclSupplier
        '
        Me.dgclSupplier.DataPropertyName = "DistributionDescp"
        Me.dgclSupplier.HeaderText = "Supplier"
        Me.dgclSupplier.Name = "dgclSupplier"
        Me.dgclSupplier.ReadOnly = True
        Me.dgclSupplier.Width = 78
        '
        'dgclSupplierID
        '
        Me.dgclSupplierID.DataPropertyName = "DistributionSetupID"
        Me.dgclSupplierID.HeaderText = "SupplierID"
        Me.dgclSupplierID.Name = "dgclSupplierID"
        Me.dgclSupplierID.ReadOnly = True
        Me.dgclSupplierID.Visible = False
        Me.dgclSupplierID.Width = 92
        '
        'dgclStatus
        '
        Me.dgclStatus.DataPropertyName = "Status"
        Me.dgclStatus.HeaderText = "Status"
        Me.dgclStatus.Name = "dgclStatus"
        Me.dgclStatus.ReadOnly = True
        Me.dgclStatus.Width = 67
        '
        'dgclOperatorName
        '
        Me.dgclOperatorName.DataPropertyName = "OperatorName"
        Me.dgclOperatorName.HeaderText = "Operator Name"
        Me.dgclOperatorName.Name = "dgclOperatorName"
        Me.dgclOperatorName.ReadOnly = True
        Me.dgclOperatorName.Visible = False
        Me.dgclOperatorName.Width = 119
        '
        'dgclTransportDate
        '
        Me.dgclTransportDate.DataPropertyName = "TransportDate"
        Me.dgclTransportDate.HeaderText = "Transport Date"
        Me.dgclTransportDate.Name = "dgclTransportDate"
        Me.dgclTransportDate.ReadOnly = True
        Me.dgclTransportDate.Visible = False
        Me.dgclTransportDate.Width = 117
        '
        'dgclVehicleNo
        '
        Me.dgclVehicleNo.DataPropertyName = "VehicleNo"
        Me.dgclVehicleNo.HeaderText = "Vehicle No."
        Me.dgclVehicleNo.Name = "dgclVehicleNo"
        Me.dgclVehicleNo.ReadOnly = True
        Me.dgclVehicleNo.Visible = False
        Me.dgclVehicleNo.Width = 95
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
        'dgclRejectedReason
        '
        Me.dgclRejectedReason.DataPropertyName = "RejectedReason"
        Me.dgclRejectedReason.HeaderText = "Rejected Reason"
        Me.dgclRejectedReason.Name = "dgclRejectedReason"
        Me.dgclRejectedReason.ReadOnly = True
        Me.dgclRejectedReason.Visible = False
        Me.dgclRejectedReason.Width = 127
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
        'dgclSupplierCOAID
        '
        Me.dgclSupplierCOAID.DataPropertyName = "SupplierCOAID"
        Me.dgclSupplierCOAID.HeaderText = "SupplierCOAID"
        Me.dgclSupplierCOAID.Name = "dgclSupplierCOAID"
        Me.dgclSupplierCOAID.ReadOnly = True
        Me.dgclSupplierCOAID.Visible = False
        Me.dgclSupplierCOAID.Width = 118
        '
        'dgclSTIPRID
        '
        Me.dgclSTIPRID.DataPropertyName = "STIPRID"
        Me.dgclSTIPRID.HeaderText = "STPRID"
        Me.dgclSTIPRID.Name = "dgclSTIPRID"
        Me.dgclSTIPRID.ReadOnly = True
        Me.dgclSTIPRID.Visible = False
        Me.dgclSTIPRID.Width = 80
        '
        'dgclSTLPOID
        '
        Me.dgclSTLPOID.DataPropertyName = "STLPOID"
        Me.dgclSTLPOID.HeaderText = "STPOID"
        Me.dgclSTLPOID.Name = "dgclSTLPOID"
        Me.dgclSTLPOID.ReadOnly = True
        Me.dgclSTLPOID.Visible = False
        Me.dgclSTLPOID.Width = 82
        '
        'dgclT0
        '
        Me.dgclT0.DataPropertyName = "T0"
        Me.dgclT0.HeaderText = "T0"
        Me.dgclT0.Name = "dgclT0"
        Me.dgclT0.ReadOnly = True
        Me.dgclT0.Visible = False
        Me.dgclT0.Width = 45
        '
        'dgclT1
        '
        Me.dgclT1.DataPropertyName = "T1"
        Me.dgclT1.HeaderText = "T1"
        Me.dgclT1.Name = "dgclT1"
        Me.dgclT1.ReadOnly = True
        Me.dgclT1.Visible = False
        Me.dgclT1.Width = 45
        '
        'dgclT2
        '
        Me.dgclT2.DataPropertyName = "T2"
        Me.dgclT2.HeaderText = "T2"
        Me.dgclT2.Name = "dgclT2"
        Me.dgclT2.ReadOnly = True
        Me.dgclT2.Visible = False
        Me.dgclT2.Width = 45
        '
        'dgclT3
        '
        Me.dgclT3.DataPropertyName = "T3"
        Me.dgclT3.HeaderText = "T3"
        Me.dgclT3.Name = "dgclT3"
        Me.dgclT3.ReadOnly = True
        Me.dgclT3.Visible = False
        Me.dgclT3.Width = 45
        '
        'dgclT4
        '
        Me.dgclT4.DataPropertyName = "T4"
        Me.dgclT4.HeaderText = "T4"
        Me.dgclT4.Name = "dgclT4"
        Me.dgclT4.ReadOnly = True
        Me.dgclT4.Visible = False
        Me.dgclT4.Width = 45
        '
        'EstateMillDeliveryNoteApprovalFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(985, 507)
        Me.Controls.Add(Me.plEMDNSearch)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "EstateMillDeliveryNoteApprovalFrm"
        Me.Text = "Estate Mill Delivery Note Approval Form"
        Me.plEMDNSearch.ResumeLayout(False)
        Me.plEMDNSearch.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvIDNView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plEMDNSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents txtviewSupplier As System.Windows.Forms.TextBox
    Friend WithEvents txtviewGRNNo As System.Windows.Forms.TextBox
    Friend WithEvents cbviewDeliverySource As System.Windows.Forms.ComboBox
    Friend WithEvents txtviewIDNNo As System.Windows.Forms.TextBox
    Friend WithEvents cbviewLPONo As System.Windows.Forms.ComboBox
    Friend WithEvents cbviewIPRNo As System.Windows.Forms.ComboBox
    Friend WithEvents cbviewTransType As System.Windows.Forms.ComboBox
    Friend WithEvents lblviewSupplier As System.Windows.Forms.Label
    Friend WithEvents lblviewPONo As System.Windows.Forms.Label
    Friend WithEvents lblviewLPONo As System.Windows.Forms.Label
    Friend WithEvents lblviewDeliverySource As System.Windows.Forms.Label
    Friend WithEvents lblviewIPRNo As System.Windows.Forms.Label
    Friend WithEvents lblviewGRNNo As System.Windows.Forms.Label
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents chkIDNDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpviewIDNDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewIDNDate As System.Windows.Forms.Label
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents lblviewIDNNo As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cbviewStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblviewTransType As System.Windows.Forms.Label
    Friend WithEvents lblviewMainstatus As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvIDNView As System.Windows.Forms.DataGridView
    Friend WithEvents ChkIPR As System.Windows.Forms.CheckBox
    Friend WithEvents ChkLPO As System.Windows.Forms.CheckBox
    Friend WithEvents dgclSTEstMillDeliveryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIDNDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIDNNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclGRNNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIPRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLPONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDeliverySource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclOperatorName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTransportDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVehicleNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclViewDetails As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents dgclSupplierCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTIPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTLPOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNoRecordFound As System.Windows.Forms.Label
    Friend WithEvents cbviewPONo As System.Windows.Forms.TextBox
End Class

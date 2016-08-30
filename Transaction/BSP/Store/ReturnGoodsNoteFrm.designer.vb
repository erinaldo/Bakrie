<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReturnGoodsNoteFrm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReturnGoodsNoteFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbRGN = New System.Windows.Forms.TabControl()
        Me.tbpgRGN = New System.Windows.Forms.TabPage()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.grpApproval = New System.Windows.Forms.GroupBox()
        Me.lblRejectedColon = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnConform = New System.Windows.Forms.Button()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.txtRejectedReason = New System.Windows.Forms.TextBox()
        Me.lblRejectedReason = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgRGN = New System.Windows.Forms.DataGridView()
        Me.dgclStockCategoryId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTIssueId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTIssueDetailsID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTReturnGoodsDetailsID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTReturnGoodsNoteID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SIVCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SIVCOACODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SIVCOADESCP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclVarianceCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT0Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT1Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT2Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT3Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclT4Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDiv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDivId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclYOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclYOPId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclBlock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclBlockId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclVHNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclVHID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclVHDetailCostCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclVHDetailCostCodeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStationId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclODOReading = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclIssueQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclIssueValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclReturnQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclReturnedValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsRGNAddEdit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpRGNStockDetails = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblSIVVHDetailCostCode = New System.Windows.Forms.Label()
        Me.lblSIVVHNo = New System.Windows.Forms.Label()
        Me.lblSIVODOReading = New System.Windows.Forms.Label()
        Me.lblSIVDiv = New System.Windows.Forms.Label()
        Me.lblSIVYOP = New System.Windows.Forms.Label()
        Me.lblSIVBlock = New System.Windows.Forms.Label()
        Me.lblSIVStation = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblsubBlock = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblVHDetailsCostCode = New System.Windows.Forms.Label()
        Me.lblOdoReading = New System.Windows.Forms.Label()
        Me.lblVHNo = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.lblYOP = New System.Windows.Forms.Label()
        Me.lblDiv = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblSIVT4Value = New System.Windows.Forms.Label()
        Me.lblT0 = New System.Windows.Forms.Label()
        Me.lblSIVT3Value = New System.Windows.Forms.Label()
        Me.lblT1 = New System.Windows.Forms.Label()
        Me.lblSIVT2Value = New System.Windows.Forms.Label()
        Me.lblT2 = New System.Windows.Forms.Label()
        Me.lblSIVT1Value = New System.Windows.Forms.Label()
        Me.lblT3 = New System.Windows.Forms.Label()
        Me.lblSIVT0Value = New System.Windows.Forms.Label()
        Me.lblT4 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtIssueValue = New System.Windows.Forms.Label()
        Me.txtIssueQty = New System.Windows.Forms.Label()
        Me.lblPartNo = New System.Windows.Forms.Label()
        Me.txtReturnedValue = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblPart = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtReturnedQty = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblReturnedValue = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblReturnedQty = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblIssueValue = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblIssueQty = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.lblUOM = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblStockDescription = New System.Windows.Forms.Label()
        Me.btnSearchStockCode = New System.Windows.Forms.Button()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblStockCode = New System.Windows.Forms.Label()
        Me.grpRGN = New System.Windows.Forms.GroupBox()
        Me.lblRejectedReasonValue = New System.Windows.Forms.Label()
        Me.lblRejReasonColon = New System.Windows.Forms.Label()
        Me.lblRejectedReason1 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.btnSearchSIVNo = New System.Windows.Forms.Button()
        Me.txtSIVNo = New System.Windows.Forms.TextBox()
        Me.txtRGNNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpRGNDate = New System.Windows.Forms.DateTimePicker()
        Me.lblRGNStatus = New System.Windows.Forms.Label()
        Me.lblRGNDate = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.lblSIVNo = New System.Windows.Forms.Label()
        Me.lblRGNNo = New System.Windows.Forms.Label()
        Me.tbpgView = New System.Windows.Forms.TabPage()
        Me.PnlGrid = New System.Windows.Forms.Panel()
        Me.lblNoRecord = New System.Windows.Forms.Label()
        Me.dgViewRGN = New System.Windows.Forms.DataGridView()
        Me.dgclRGNNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRGNDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSIVNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRejectedStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTRGNID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclViewSTIssueID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsRGN = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnlSearch = New Stepi.UI.ExtendedPanel()
        Me.txtSIVNoSearch = New System.Windows.Forms.TextBox()
        Me.lblStatusSearch = New System.Windows.Forms.Label()
        Me.cmbStatusSearch = New System.Windows.Forms.ComboBox()
        Me.lblSIVNoSerach = New System.Windows.Forms.Label()
        Me.chkViewRGNDate = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dtpRGNDateSearch = New System.Windows.Forms.DateTimePicker()
        Me.txtRGNNoSearch = New System.Windows.Forms.TextBox()
        Me.lblSearchBy = New System.Windows.Forms.Label()
        Me.lblRGNNoSerach = New System.Windows.Forms.Label()
        Me.btnViewReport = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.tbRGN.SuspendLayout()
        Me.tbpgRGN.SuspendLayout()
        Me.grpApproval.SuspendLayout()
        CType(Me.dgRGN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsRGNAddEdit.SuspendLayout()
        Me.grpRGNStockDetails.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpRGN.SuspendLayout()
        Me.tbpgView.SuspendLayout()
        Me.PnlGrid.SuspendLayout()
        CType(Me.dgViewRGN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsRGN.SuspendLayout()
        Me.PnlSearch.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbRGN
        '
        Me.tbRGN.Controls.Add(Me.tbpgRGN)
        Me.tbRGN.Controls.Add(Me.tbpgView)
        Me.tbRGN.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRGN.Location = New System.Drawing.Point(-6, 3)
        Me.tbRGN.Name = "tbRGN"
        Me.tbRGN.SelectedIndex = 0
        Me.tbRGN.Size = New System.Drawing.Size(993, 550)
        Me.tbRGN.TabIndex = 0
        '
        'tbpgRGN
        '
        Me.tbpgRGN.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgRGN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgRGN.Controls.Add(Me.btnDeleteAll)
        Me.tbpgRGN.Controls.Add(Me.grpApproval)
        Me.tbpgRGN.Controls.Add(Me.btnResetAll)
        Me.tbpgRGN.Controls.Add(Me.btnSaveAll)
        Me.tbpgRGN.Controls.Add(Me.btnPrint)
        Me.tbpgRGN.Controls.Add(Me.btnClose)
        Me.tbpgRGN.Controls.Add(Me.dgRGN)
        Me.tbpgRGN.Controls.Add(Me.grpRGNStockDetails)
        Me.tbpgRGN.Controls.Add(Me.grpRGN)
        Me.tbpgRGN.Location = New System.Drawing.Point(4, 22)
        Me.tbpgRGN.Name = "tbpgRGN"
        Me.tbpgRGN.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgRGN.Size = New System.Drawing.Size(985, 524)
        Me.tbpgRGN.TabIndex = 0
        Me.tbpgRGN.Text = "Return To Store"
        Me.tbpgRGN.UseVisualStyleBackColor = True
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackgroundImage = CType(resources.GetObject("btnDeleteAll.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteAll.Location = New System.Drawing.Point(420, 496)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(98, 25)
        Me.btnDeleteAll.TabIndex = 17
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        Me.btnDeleteAll.Visible = False
        '
        'grpApproval
        '
        Me.grpApproval.Controls.Add(Me.lblRejectedColon)
        Me.grpApproval.Controls.Add(Me.Label4)
        Me.grpApproval.Controls.Add(Me.btnConform)
        Me.grpApproval.Controls.Add(Me.cmbStatus)
        Me.grpApproval.Controls.Add(Me.txtRejectedReason)
        Me.grpApproval.Controls.Add(Me.lblRejectedReason)
        Me.grpApproval.Controls.Add(Me.Label14)
        Me.grpApproval.Location = New System.Drawing.Point(700, 12)
        Me.grpApproval.Name = "grpApproval"
        Me.grpApproval.Size = New System.Drawing.Size(267, 101)
        Me.grpApproval.TabIndex = 18
        Me.grpApproval.TabStop = False
        Me.grpApproval.Text = "SIV Approval"
        Me.grpApproval.Visible = False
        '
        'lblRejectedColon
        '
        Me.lblRejectedColon.AutoSize = True
        Me.lblRejectedColon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejectedColon.Location = New System.Drawing.Point(107, 55)
        Me.lblRejectedColon.Name = "lblRejectedColon"
        Me.lblRejectedColon.Size = New System.Drawing.Size(11, 13)
        Me.lblRejectedColon.TabIndex = 145
        Me.lblRejectedColon.Text = ":"
        Me.lblRejectedColon.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(107, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = ":"
        '
        'btnConform
        '
        Me.btnConform.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnConform.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConform.Image = CType(resources.GetObject("btnConform.Image"), System.Drawing.Image)
        Me.btnConform.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConform.Location = New System.Drawing.Point(147, 29)
        Me.btnConform.Name = "btnConform"
        Me.btnConform.Size = New System.Drawing.Size(114, 25)
        Me.btnConform.TabIndex = 21
        Me.btnConform.Text = "Confirm"
        Me.btnConform.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConform.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"APPROVED", "REJECTED"})
        Me.cmbStatus.Location = New System.Drawing.Point(6, 31)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(135, 21)
        Me.cmbStatus.TabIndex = 19
        '
        'txtRejectedReason
        '
        Me.txtRejectedReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRejectedReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtRejectedReason.ForeColor = System.Drawing.Color.Red
        Me.txtRejectedReason.Location = New System.Drawing.Point(8, 68)
        Me.txtRejectedReason.MaxLength = 300
        Me.txtRejectedReason.Multiline = True
        Me.txtRejectedReason.Name = "txtRejectedReason"
        Me.txtRejectedReason.Size = New System.Drawing.Size(236, 23)
        Me.txtRejectedReason.TabIndex = 20
        Me.txtRejectedReason.Visible = False
        '
        'lblRejectedReason
        '
        Me.lblRejectedReason.AutoSize = True
        Me.lblRejectedReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejectedReason.ForeColor = System.Drawing.Color.Black
        Me.lblRejectedReason.Location = New System.Drawing.Point(6, 53)
        Me.lblRejectedReason.Name = "lblRejectedReason"
        Me.lblRejectedReason.Size = New System.Drawing.Size(103, 13)
        Me.lblRejectedReason.TabIndex = 143
        Me.lblRejectedReason.Text = "Rejected Reason"
        Me.lblRejectedReason.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(6, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 142
        Me.Label14.Text = "Status"
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = CType(resources.GetObject("btnResetAll.BackgroundImage"), System.Drawing.Image)
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAll.Image = CType(resources.GetObject("btnResetAll.Image"), System.Drawing.Image)
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.Location = New System.Drawing.Point(658, 496)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(112, 25)
        Me.btnResetAll.TabIndex = 14
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(521, 496)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(137, 25)
        Me.btnSaveAll.TabIndex = 13
        Me.btnSaveAll.Text = "Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrint.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(868, 496)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(98, 25)
        Me.btnPrint.TabIndex = 16
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(770, 496)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 25)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dgRGN
        '
        Me.dgRGN.AllowUserToAddRows = False
        Me.dgRGN.AllowUserToDeleteRows = False
        Me.dgRGN.AllowUserToResizeRows = False
        Me.dgRGN.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgRGN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgRGN.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRGN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgRGN.ColumnHeadersHeight = 30
        Me.dgRGN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclStockCategoryId, Me.dgclStockCode, Me.dgclStockId, Me.dgclStockDesc, Me.dgclUnit, Me.dgclPartNo, Me.dgclSTIssueId, Me.dgclSTIssueDetailsID, Me.dgclSTReturnGoodsDetailsID, Me.dgclSTReturnGoodsNoteID, Me.dgclStockCOAID, Me.SIVCOAID, Me.SIVCOACODE, Me.SIVCOADESCP, Me.dgclVarianceCOAID, Me.dgclT0, Me.dgclT0Id, Me.dgclT1, Me.dgclT1Id, Me.dgclT2, Me.dgclT2Id, Me.dgclT3, Me.dgclT3Id, Me.dgclT4, Me.dgclT4Id, Me.dgclDiv, Me.dgclDivId, Me.dgclYOP, Me.dgclYOPId, Me.dgclBlock, Me.dgclBlockId, Me.dgclVHNo, Me.dgclVHID, Me.dgclVHDetailCostCode, Me.dgclVHDetailCostCodeID, Me.dgclStation, Me.dgclStationId, Me.dgclODOReading, Me.dgclIssueQty, Me.dgclIssueValue, Me.dgclReturnQty, Me.dgclReturnedValue})
        Me.dgRGN.ContextMenuStrip = Me.cmsRGNAddEdit
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRGN.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgRGN.EnableHeadersVisualStyles = False
        Me.dgRGN.GridColor = System.Drawing.Color.Gray
        Me.dgRGN.Location = New System.Drawing.Point(6, 367)
        Me.dgRGN.MultiSelect = False
        Me.dgRGN.Name = "dgRGN"
        Me.dgRGN.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRGN.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgRGN.RowHeadersVisible = False
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.dgRGN.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgRGN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRGN.Size = New System.Drawing.Size(961, 125)
        Me.dgRGN.TabIndex = 12
        Me.dgRGN.TabStop = False
        '
        'dgclStockCategoryId
        '
        Me.dgclStockCategoryId.DataPropertyName = "StockCategoryId"
        Me.dgclStockCategoryId.HeaderText = "StockCategoryId"
        Me.dgclStockCategoryId.Name = "dgclStockCategoryId"
        Me.dgclStockCategoryId.ReadOnly = True
        Me.dgclStockCategoryId.Visible = False
        '
        'dgclStockCode
        '
        Me.dgclStockCode.DataPropertyName = "StockCode"
        Me.dgclStockCode.HeaderText = "Stock Code"
        Me.dgclStockCode.Name = "dgclStockCode"
        Me.dgclStockCode.ReadOnly = True
        '
        'dgclStockId
        '
        Me.dgclStockId.DataPropertyName = "StockId"
        Me.dgclStockId.HeaderText = "StockId"
        Me.dgclStockId.Name = "dgclStockId"
        Me.dgclStockId.ReadOnly = True
        Me.dgclStockId.Visible = False
        '
        'dgclStockDesc
        '
        Me.dgclStockDesc.DataPropertyName = "StockDesc"
        Me.dgclStockDesc.HeaderText = "Stock Description"
        Me.dgclStockDesc.Name = "dgclStockDesc"
        Me.dgclStockDesc.ReadOnly = True
        Me.dgclStockDesc.Width = 150
        '
        'dgclUnit
        '
        Me.dgclUnit.DataPropertyName = "Unit"
        Me.dgclUnit.HeaderText = "Unit"
        Me.dgclUnit.Name = "dgclUnit"
        Me.dgclUnit.ReadOnly = True
        '
        'dgclPartNo
        '
        Me.dgclPartNo.DataPropertyName = "PartNo"
        Me.dgclPartNo.HeaderText = "PartNo"
        Me.dgclPartNo.Name = "dgclPartNo"
        Me.dgclPartNo.ReadOnly = True
        '
        'dgclSTIssueId
        '
        Me.dgclSTIssueId.DataPropertyName = "STIssueId"
        Me.dgclSTIssueId.HeaderText = "STIssueId"
        Me.dgclSTIssueId.Name = "dgclSTIssueId"
        Me.dgclSTIssueId.ReadOnly = True
        Me.dgclSTIssueId.Visible = False
        '
        'dgclSTIssueDetailsID
        '
        Me.dgclSTIssueDetailsID.DataPropertyName = "STIssueDetailsID"
        Me.dgclSTIssueDetailsID.HeaderText = "STIssueDetailsID"
        Me.dgclSTIssueDetailsID.Name = "dgclSTIssueDetailsID"
        Me.dgclSTIssueDetailsID.ReadOnly = True
        Me.dgclSTIssueDetailsID.Visible = False
        '
        'dgclSTReturnGoodsDetailsID
        '
        Me.dgclSTReturnGoodsDetailsID.DataPropertyName = "STReturnGoodsDetailsID"
        Me.dgclSTReturnGoodsDetailsID.HeaderText = "STReturnGoodsDetailsID"
        Me.dgclSTReturnGoodsDetailsID.Name = "dgclSTReturnGoodsDetailsID"
        Me.dgclSTReturnGoodsDetailsID.ReadOnly = True
        Me.dgclSTReturnGoodsDetailsID.Visible = False
        '
        'dgclSTReturnGoodsNoteID
        '
        Me.dgclSTReturnGoodsNoteID.DataPropertyName = "STReturnGoodsNoteID"
        Me.dgclSTReturnGoodsNoteID.HeaderText = "STReturnGoodsNoteID"
        Me.dgclSTReturnGoodsNoteID.Name = "dgclSTReturnGoodsNoteID"
        Me.dgclSTReturnGoodsNoteID.ReadOnly = True
        Me.dgclSTReturnGoodsNoteID.Visible = False
        '
        'dgclStockCOAID
        '
        Me.dgclStockCOAID.DataPropertyName = "dgclStockCOAID"
        Me.dgclStockCOAID.HeaderText = "StockCOAID"
        Me.dgclStockCOAID.Name = "dgclStockCOAID"
        Me.dgclStockCOAID.ReadOnly = True
        Me.dgclStockCOAID.Visible = False
        '
        'SIVCOAID
        '
        Me.SIVCOAID.DataPropertyName = "SIVCOAID"
        Me.SIVCOAID.HeaderText = "SIVCOAID"
        Me.SIVCOAID.Name = "SIVCOAID"
        Me.SIVCOAID.ReadOnly = True
        Me.SIVCOAID.Visible = False
        '
        'SIVCOACODE
        '
        Me.SIVCOACODE.DataPropertyName = "SIVCOACODE"
        Me.SIVCOACODE.HeaderText = "Acc.Code"
        Me.SIVCOACODE.Name = "SIVCOACODE"
        Me.SIVCOACODE.ReadOnly = True
        '
        'SIVCOADESCP
        '
        Me.SIVCOADESCP.DataPropertyName = "SIVCOADESCP"
        Me.SIVCOADESCP.HeaderText = "Acc.Descp"
        Me.SIVCOADESCP.Name = "SIVCOADESCP"
        Me.SIVCOADESCP.ReadOnly = True
        '
        'dgclVarianceCOAID
        '
        Me.dgclVarianceCOAID.DataPropertyName = "VarianceCOAID"
        Me.dgclVarianceCOAID.HeaderText = "VarianceCOAID"
        Me.dgclVarianceCOAID.Name = "dgclVarianceCOAID"
        Me.dgclVarianceCOAID.ReadOnly = True
        Me.dgclVarianceCOAID.Visible = False
        '
        'dgclT0
        '
        Me.dgclT0.DataPropertyName = "T0"
        Me.dgclT0.HeaderText = "T0"
        Me.dgclT0.Name = "dgclT0"
        Me.dgclT0.ReadOnly = True
        Me.dgclT0.Visible = False
        '
        'dgclT0Id
        '
        Me.dgclT0Id.DataPropertyName = "T0Id"
        Me.dgclT0Id.HeaderText = "T0Id"
        Me.dgclT0Id.Name = "dgclT0Id"
        Me.dgclT0Id.ReadOnly = True
        Me.dgclT0Id.Visible = False
        '
        'dgclT1
        '
        Me.dgclT1.DataPropertyName = "T1"
        Me.dgclT1.HeaderText = "T1"
        Me.dgclT1.Name = "dgclT1"
        Me.dgclT1.ReadOnly = True
        Me.dgclT1.Visible = False
        '
        'dgclT1Id
        '
        Me.dgclT1Id.DataPropertyName = "T1Id"
        Me.dgclT1Id.HeaderText = "T1Id"
        Me.dgclT1Id.Name = "dgclT1Id"
        Me.dgclT1Id.ReadOnly = True
        Me.dgclT1Id.Visible = False
        '
        'dgclT2
        '
        Me.dgclT2.DataPropertyName = "T2"
        Me.dgclT2.HeaderText = "T2"
        Me.dgclT2.Name = "dgclT2"
        Me.dgclT2.ReadOnly = True
        Me.dgclT2.Visible = False
        '
        'dgclT2Id
        '
        Me.dgclT2Id.DataPropertyName = "T2Id"
        Me.dgclT2Id.HeaderText = "T2Id"
        Me.dgclT2Id.Name = "dgclT2Id"
        Me.dgclT2Id.ReadOnly = True
        Me.dgclT2Id.Visible = False
        '
        'dgclT3
        '
        Me.dgclT3.DataPropertyName = "T3"
        Me.dgclT3.HeaderText = "T3"
        Me.dgclT3.Name = "dgclT3"
        Me.dgclT3.ReadOnly = True
        Me.dgclT3.Visible = False
        '
        'dgclT3Id
        '
        Me.dgclT3Id.DataPropertyName = "T3Id"
        Me.dgclT3Id.HeaderText = "T3Id"
        Me.dgclT3Id.Name = "dgclT3Id"
        Me.dgclT3Id.ReadOnly = True
        Me.dgclT3Id.Visible = False
        '
        'dgclT4
        '
        Me.dgclT4.DataPropertyName = "T4"
        Me.dgclT4.HeaderText = "T4"
        Me.dgclT4.Name = "dgclT4"
        Me.dgclT4.ReadOnly = True
        Me.dgclT4.Visible = False
        '
        'dgclT4Id
        '
        Me.dgclT4Id.DataPropertyName = "T4Id"
        Me.dgclT4Id.HeaderText = "T4Id"
        Me.dgclT4Id.Name = "dgclT4Id"
        Me.dgclT4Id.ReadOnly = True
        Me.dgclT4Id.Visible = False
        '
        'dgclDiv
        '
        Me.dgclDiv.DataPropertyName = "Div"
        Me.dgclDiv.HeaderText = "Afdeling"
        Me.dgclDiv.Name = "dgclDiv"
        Me.dgclDiv.ReadOnly = True
        '
        'dgclDivId
        '
        Me.dgclDivId.DataPropertyName = "DivId"
        Me.dgclDivId.HeaderText = "Afdeling Id"
        Me.dgclDivId.Name = "dgclDivId"
        Me.dgclDivId.ReadOnly = True
        Me.dgclDivId.Visible = False
        '
        'dgclYOP
        '
        Me.dgclYOP.DataPropertyName = "YOP"
        Me.dgclYOP.HeaderText = "YOP"
        Me.dgclYOP.Name = "dgclYOP"
        Me.dgclYOP.ReadOnly = True
        '
        'dgclYOPId
        '
        Me.dgclYOPId.DataPropertyName = "YOPId"
        Me.dgclYOPId.HeaderText = "YOPId"
        Me.dgclYOPId.Name = "dgclYOPId"
        Me.dgclYOPId.ReadOnly = True
        Me.dgclYOPId.Visible = False
        '
        'dgclBlock
        '
        Me.dgclBlock.DataPropertyName = "Block"
        Me.dgclBlock.HeaderText = "FieldNo"
        Me.dgclBlock.Name = "dgclBlock"
        Me.dgclBlock.ReadOnly = True
        '
        'dgclBlockId
        '
        Me.dgclBlockId.DataPropertyName = "BlockId"
        Me.dgclBlockId.HeaderText = "FieldNoId"
        Me.dgclBlockId.Name = "dgclBlockId"
        Me.dgclBlockId.ReadOnly = True
        Me.dgclBlockId.Visible = False
        '
        'dgclVHNo
        '
        Me.dgclVHNo.DataPropertyName = "VHNo"
        Me.dgclVHNo.HeaderText = "VH/WS No"
        Me.dgclVHNo.Name = "dgclVHNo"
        Me.dgclVHNo.ReadOnly = True
        '
        'dgclVHID
        '
        Me.dgclVHID.DataPropertyName = "VHID"
        Me.dgclVHID.HeaderText = "VHID"
        Me.dgclVHID.Name = "dgclVHID"
        Me.dgclVHID.ReadOnly = True
        Me.dgclVHID.Visible = False
        '
        'dgclVHDetailCostCode
        '
        Me.dgclVHDetailCostCode.DataPropertyName = "VHDetailCostCode"
        Me.dgclVHDetailCostCode.HeaderText = "VH Detail Cost Code"
        Me.dgclVHDetailCostCode.Name = "dgclVHDetailCostCode"
        Me.dgclVHDetailCostCode.ReadOnly = True
        '
        'dgclVHDetailCostCodeID
        '
        Me.dgclVHDetailCostCodeID.DataPropertyName = "VHDetailCostCodeID"
        Me.dgclVHDetailCostCodeID.HeaderText = "VHDetailCostCodeID"
        Me.dgclVHDetailCostCodeID.Name = "dgclVHDetailCostCodeID"
        Me.dgclVHDetailCostCodeID.ReadOnly = True
        Me.dgclVHDetailCostCodeID.Visible = False
        '
        'dgclStation
        '
        Me.dgclStation.DataPropertyName = "Station"
        Me.dgclStation.HeaderText = "Station"
        Me.dgclStation.Name = "dgclStation"
        Me.dgclStation.ReadOnly = True
        '
        'dgclStationId
        '
        Me.dgclStationId.DataPropertyName = "StationId"
        Me.dgclStationId.HeaderText = "StationId"
        Me.dgclStationId.Name = "dgclStationId"
        Me.dgclStationId.ReadOnly = True
        Me.dgclStationId.Visible = False
        '
        'dgclODOReading
        '
        Me.dgclODOReading.DataPropertyName = "ODOReading"
        Me.dgclODOReading.HeaderText = "ODOReading"
        Me.dgclODOReading.Name = "dgclODOReading"
        Me.dgclODOReading.ReadOnly = True
        Me.dgclODOReading.Visible = False
        '
        'dgclIssueQty
        '
        Me.dgclIssueQty.DataPropertyName = "IssueQty"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgclIssueQty.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgclIssueQty.HeaderText = "Issue Qty"
        Me.dgclIssueQty.Name = "dgclIssueQty"
        Me.dgclIssueQty.ReadOnly = True
        '
        'dgclIssueValue
        '
        Me.dgclIssueValue.DataPropertyName = "IssueValue"
        Me.dgclIssueValue.HeaderText = "Issue Value"
        Me.dgclIssueValue.Name = "dgclIssueValue"
        Me.dgclIssueValue.ReadOnly = True
        Me.dgclIssueValue.Visible = False
        '
        'dgclReturnQty
        '
        Me.dgclReturnQty.DataPropertyName = "ReturnQty"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgclReturnQty.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgclReturnQty.HeaderText = "Return Qty"
        Me.dgclReturnQty.Name = "dgclReturnQty"
        Me.dgclReturnQty.ReadOnly = True
        Me.dgclReturnQty.Width = 110
        '
        'dgclReturnedValue
        '
        Me.dgclReturnedValue.DataPropertyName = "ReturnedValue"
        Me.dgclReturnedValue.HeaderText = "Returned Value"
        Me.dgclReturnedValue.Name = "dgclReturnedValue"
        Me.dgclReturnedValue.ReadOnly = True
        Me.dgclReturnedValue.Visible = False
        Me.dgclReturnedValue.Width = 150
        '
        'cmsRGNAddEdit
        '
        Me.cmsRGNAddEdit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem1, Me.EditToolStripMenuItem1})
        Me.cmsRGNAddEdit.Name = "cmsRGN"
        Me.cmsRGNAddEdit.Size = New System.Drawing.Size(108, 48)
        '
        'DeleteToolStripMenuItem1
        '
        Me.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1"
        Me.DeleteToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem1.Text = "Delete"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'grpRGNStockDetails
        '
        Me.grpRGNStockDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.grpRGNStockDetails.Controls.Add(Me.GroupBox2)
        Me.grpRGNStockDetails.Controls.Add(Me.GroupBox1)
        Me.grpRGNStockDetails.Controls.Add(Me.txtIssueValue)
        Me.grpRGNStockDetails.Controls.Add(Me.txtIssueQty)
        Me.grpRGNStockDetails.Controls.Add(Me.lblPartNo)
        Me.grpRGNStockDetails.Controls.Add(Me.txtReturnedValue)
        Me.grpRGNStockDetails.Controls.Add(Me.Label7)
        Me.grpRGNStockDetails.Controls.Add(Me.lblPart)
        Me.grpRGNStockDetails.Controls.Add(Me.Label12)
        Me.grpRGNStockDetails.Controls.Add(Me.txtReturnedQty)
        Me.grpRGNStockDetails.Controls.Add(Me.Label11)
        Me.grpRGNStockDetails.Controls.Add(Me.lblReturnedValue)
        Me.grpRGNStockDetails.Controls.Add(Me.btnReset)
        Me.grpRGNStockDetails.Controls.Add(Me.btnAdd)
        Me.grpRGNStockDetails.Controls.Add(Me.lblReturnedQty)
        Me.grpRGNStockDetails.Controls.Add(Me.Label10)
        Me.grpRGNStockDetails.Controls.Add(Me.lblIssueValue)
        Me.grpRGNStockDetails.Controls.Add(Me.Label9)
        Me.grpRGNStockDetails.Controls.Add(Me.lblIssueQty)
        Me.grpRGNStockDetails.Controls.Add(Me.Label26)
        Me.grpRGNStockDetails.Controls.Add(Me.Label8)
        Me.grpRGNStockDetails.Controls.Add(Me.lblUnit)
        Me.grpRGNStockDetails.Controls.Add(Me.lblUOM)
        Me.grpRGNStockDetails.Controls.Add(Me.lblDescription)
        Me.grpRGNStockDetails.Controls.Add(Me.lblStockDescription)
        Me.grpRGNStockDetails.Controls.Add(Me.btnSearchStockCode)
        Me.grpRGNStockDetails.Controls.Add(Me.txtStockCode)
        Me.grpRGNStockDetails.Controls.Add(Me.Label27)
        Me.grpRGNStockDetails.Controls.Add(Me.lblStockCode)
        Me.grpRGNStockDetails.Location = New System.Drawing.Point(3, 119)
        Me.grpRGNStockDetails.Name = "grpRGNStockDetails"
        Me.grpRGNStockDetails.Size = New System.Drawing.Size(964, 242)
        Me.grpRGNStockDetails.TabIndex = 6
        Me.grpRGNStockDetails.TabStop = False
        Me.grpRGNStockDetails.Text = "Stock Details"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblSIVVHDetailCostCode)
        Me.GroupBox2.Controls.Add(Me.lblSIVVHNo)
        Me.GroupBox2.Controls.Add(Me.lblSIVODOReading)
        Me.GroupBox2.Controls.Add(Me.lblSIVDiv)
        Me.GroupBox2.Controls.Add(Me.lblSIVYOP)
        Me.GroupBox2.Controls.Add(Me.lblSIVBlock)
        Me.GroupBox2.Controls.Add(Me.lblSIVStation)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.lblsubBlock)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.lblVHDetailsCostCode)
        Me.GroupBox2.Controls.Add(Me.lblOdoReading)
        Me.GroupBox2.Controls.Add(Me.lblVHNo)
        Me.GroupBox2.Controls.Add(Me.lblStation)
        Me.GroupBox2.Controls.Add(Me.lblYOP)
        Me.GroupBox2.Controls.Add(Me.lblDiv)
        Me.GroupBox2.Location = New System.Drawing.Point(559, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(399, 224)
        Me.GroupBox2.TabIndex = 210
        Me.GroupBox2.TabStop = False
        '
        'lblSIVVHDetailCostCode
        '
        Me.lblSIVVHDetailCostCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVVHDetailCostCode.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVVHDetailCostCode.Location = New System.Drawing.Point(184, 204)
        Me.lblSIVVHDetailCostCode.Name = "lblSIVVHDetailCostCode"
        Me.lblSIVVHDetailCostCode.Size = New System.Drawing.Size(138, 13)
        Me.lblSIVVHDetailCostCode.TabIndex = 191
        '
        'lblSIVVHNo
        '
        Me.lblSIVVHNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVVHNo.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVVHNo.Location = New System.Drawing.Point(184, 173)
        Me.lblSIVVHNo.Name = "lblSIVVHNo"
        Me.lblSIVVHNo.Size = New System.Drawing.Size(138, 13)
        Me.lblSIVVHNo.TabIndex = 190
        '
        'lblSIVODOReading
        '
        Me.lblSIVODOReading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVODOReading.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVODOReading.Location = New System.Drawing.Point(184, 141)
        Me.lblSIVODOReading.Name = "lblSIVODOReading"
        Me.lblSIVODOReading.Size = New System.Drawing.Size(138, 13)
        Me.lblSIVODOReading.TabIndex = 189
        '
        'lblSIVDiv
        '
        Me.lblSIVDiv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVDiv.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVDiv.Location = New System.Drawing.Point(184, 109)
        Me.lblSIVDiv.Name = "lblSIVDiv"
        Me.lblSIVDiv.Size = New System.Drawing.Size(138, 13)
        Me.lblSIVDiv.TabIndex = 188
        '
        'lblSIVYOP
        '
        Me.lblSIVYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVYOP.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVYOP.Location = New System.Drawing.Point(184, 77)
        Me.lblSIVYOP.Name = "lblSIVYOP"
        Me.lblSIVYOP.Size = New System.Drawing.Size(138, 13)
        Me.lblSIVYOP.TabIndex = 187
        '
        'lblSIVBlock
        '
        Me.lblSIVBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVBlock.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVBlock.Location = New System.Drawing.Point(184, 46)
        Me.lblSIVBlock.Name = "lblSIVBlock"
        Me.lblSIVBlock.Size = New System.Drawing.Size(138, 13)
        Me.lblSIVBlock.TabIndex = 186
        '
        'lblSIVStation
        '
        Me.lblSIVStation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVStation.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVStation.Location = New System.Drawing.Point(184, 14)
        Me.lblSIVStation.Name = "lblSIVStation"
        Me.lblSIVStation.Size = New System.Drawing.Size(138, 13)
        Me.lblSIVStation.TabIndex = 185
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(167, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 184
        Me.Label23.Text = ":"
        '
        'lblsubBlock
        '
        Me.lblsubBlock.AutoSize = True
        Me.lblsubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubBlock.ForeColor = System.Drawing.Color.Black
        Me.lblsubBlock.Location = New System.Drawing.Point(31, 46)
        Me.lblsubBlock.Name = "lblsubBlock"
        Me.lblsubBlock.Size = New System.Drawing.Size(82, 13)
        Me.lblsubBlock.TabIndex = 183
        Me.lblsubBlock.Text = "Field Number"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(167, 204)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(11, 13)
        Me.Label28.TabIndex = 182
        Me.Label28.Text = ":"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(167, 173)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 13)
        Me.Label20.TabIndex = 181
        Me.Label20.Text = ":"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(167, 109)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(11, 13)
        Me.Label24.TabIndex = 180
        Me.Label24.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(167, 141)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 13)
        Me.Label17.TabIndex = 179
        Me.Label17.Text = ":"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(167, 14)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(11, 13)
        Me.Label18.TabIndex = 178
        Me.Label18.Text = ":"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(167, 77)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(11, 13)
        Me.Label19.TabIndex = 177
        Me.Label19.Text = ":"
        '
        'lblVHDetailsCostCode
        '
        Me.lblVHDetailsCostCode.AutoSize = True
        Me.lblVHDetailsCostCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHDetailsCostCode.ForeColor = System.Drawing.Color.Black
        Me.lblVHDetailsCostCode.Location = New System.Drawing.Point(31, 204)
        Me.lblVHDetailsCostCode.Name = "lblVHDetailsCostCode"
        Me.lblVHDetailsCostCode.Size = New System.Drawing.Size(130, 13)
        Me.lblVHDetailsCostCode.TabIndex = 176
        Me.lblVHDetailsCostCode.Text = "VH Details Cost Code"
        '
        'lblOdoReading
        '
        Me.lblOdoReading.AutoSize = True
        Me.lblOdoReading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOdoReading.ForeColor = System.Drawing.Color.Black
        Me.lblOdoReading.Location = New System.Drawing.Point(31, 141)
        Me.lblOdoReading.Name = "lblOdoReading"
        Me.lblOdoReading.Size = New System.Drawing.Size(80, 13)
        Me.lblOdoReading.TabIndex = 175
        Me.lblOdoReading.Text = "Odo Reading"
        '
        'lblVHNo
        '
        Me.lblVHNo.AutoSize = True
        Me.lblVHNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVHNo.ForeColor = System.Drawing.Color.Black
        Me.lblVHNo.Location = New System.Drawing.Point(31, 173)
        Me.lblVHNo.Name = "lblVHNo"
        Me.lblVHNo.Size = New System.Drawing.Size(119, 13)
        Me.lblVHNo.TabIndex = 174
        Me.lblVHNo.Text = "VHNo/Workshop No"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStation.ForeColor = System.Drawing.Color.Black
        Me.lblStation.Location = New System.Drawing.Point(31, 14)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(47, 13)
        Me.lblStation.TabIndex = 173
        Me.lblStation.Text = "Station"
        '
        'lblYOP
        '
        Me.lblYOP.AutoSize = True
        Me.lblYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOP.ForeColor = System.Drawing.Color.Black
        Me.lblYOP.Location = New System.Drawing.Point(31, 77)
        Me.lblYOP.Name = "lblYOP"
        Me.lblYOP.Size = New System.Drawing.Size(30, 13)
        Me.lblYOP.TabIndex = 172
        Me.lblYOP.Text = "YOP"
        '
        'lblDiv
        '
        Me.lblDiv.AutoSize = True
        Me.lblDiv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiv.ForeColor = System.Drawing.Color.Black
        Me.lblDiv.Location = New System.Drawing.Point(31, 109)
        Me.lblDiv.Name = "lblDiv"
        Me.lblDiv.Size = New System.Drawing.Size(53, 13)
        Me.lblDiv.TabIndex = 171
        Me.lblDiv.Text = "Afdeling"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblSIVT4Value)
        Me.GroupBox1.Controls.Add(Me.lblT0)
        Me.GroupBox1.Controls.Add(Me.lblSIVT3Value)
        Me.GroupBox1.Controls.Add(Me.lblT1)
        Me.GroupBox1.Controls.Add(Me.lblSIVT2Value)
        Me.GroupBox1.Controls.Add(Me.lblT2)
        Me.GroupBox1.Controls.Add(Me.lblSIVT1Value)
        Me.GroupBox1.Controls.Add(Me.lblT3)
        Me.GroupBox1.Controls.Add(Me.lblSIVT0Value)
        Me.GroupBox1.Controls.Add(Me.lblT4)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(327, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 186)
        Me.GroupBox1.TabIndex = 209
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(41, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 13)
        Me.Label13.TabIndex = 201
        Me.Label13.Text = ":"
        '
        'lblSIVT4Value
        '
        Me.lblSIVT4Value.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVT4Value.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVT4Value.Location = New System.Drawing.Point(57, 137)
        Me.lblSIVT4Value.Name = "lblSIVT4Value"
        Me.lblSIVT4Value.Size = New System.Drawing.Size(115, 13)
        Me.lblSIVT4Value.TabIndex = 208
        '
        'lblT0
        '
        Me.lblT0.AutoSize = True
        Me.lblT0.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT0.ForeColor = System.Drawing.Color.Black
        Me.lblT0.Location = New System.Drawing.Point(9, 13)
        Me.lblT0.Name = "lblT0"
        Me.lblT0.Size = New System.Drawing.Size(21, 13)
        Me.lblT0.TabIndex = 194
        Me.lblT0.Text = "T0"
        '
        'lblSIVT3Value
        '
        Me.lblSIVT3Value.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVT3Value.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVT3Value.Location = New System.Drawing.Point(58, 106)
        Me.lblSIVT3Value.Name = "lblSIVT3Value"
        Me.lblSIVT3Value.Size = New System.Drawing.Size(115, 13)
        Me.lblSIVT3Value.TabIndex = 207
        '
        'lblT1
        '
        Me.lblT1.AutoSize = True
        Me.lblT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT1.ForeColor = System.Drawing.Color.Black
        Me.lblT1.Location = New System.Drawing.Point(9, 44)
        Me.lblT1.Name = "lblT1"
        Me.lblT1.Size = New System.Drawing.Size(21, 13)
        Me.lblT1.TabIndex = 195
        Me.lblT1.Text = "T1"
        '
        'lblSIVT2Value
        '
        Me.lblSIVT2Value.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVT2Value.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVT2Value.Location = New System.Drawing.Point(60, 75)
        Me.lblSIVT2Value.Name = "lblSIVT2Value"
        Me.lblSIVT2Value.Size = New System.Drawing.Size(115, 13)
        Me.lblSIVT2Value.TabIndex = 206
        '
        'lblT2
        '
        Me.lblT2.AutoSize = True
        Me.lblT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT2.ForeColor = System.Drawing.Color.Black
        Me.lblT2.Location = New System.Drawing.Point(9, 75)
        Me.lblT2.Name = "lblT2"
        Me.lblT2.Size = New System.Drawing.Size(21, 13)
        Me.lblT2.TabIndex = 196
        Me.lblT2.Text = "T2"
        '
        'lblSIVT1Value
        '
        Me.lblSIVT1Value.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVT1Value.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVT1Value.Location = New System.Drawing.Point(57, 44)
        Me.lblSIVT1Value.Name = "lblSIVT1Value"
        Me.lblSIVT1Value.Size = New System.Drawing.Size(115, 13)
        Me.lblSIVT1Value.TabIndex = 205
        '
        'lblT3
        '
        Me.lblT3.AutoSize = True
        Me.lblT3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT3.ForeColor = System.Drawing.Color.Black
        Me.lblT3.Location = New System.Drawing.Point(9, 106)
        Me.lblT3.Name = "lblT3"
        Me.lblT3.Size = New System.Drawing.Size(21, 13)
        Me.lblT3.TabIndex = 197
        Me.lblT3.Text = "T3"
        '
        'lblSIVT0Value
        '
        Me.lblSIVT0Value.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVT0Value.ForeColor = System.Drawing.Color.Blue
        Me.lblSIVT0Value.Location = New System.Drawing.Point(60, 13)
        Me.lblSIVT0Value.Name = "lblSIVT0Value"
        Me.lblSIVT0Value.Size = New System.Drawing.Size(115, 13)
        Me.lblSIVT0Value.TabIndex = 204
        '
        'lblT4
        '
        Me.lblT4.AutoSize = True
        Me.lblT4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT4.ForeColor = System.Drawing.Color.Black
        Me.lblT4.Location = New System.Drawing.Point(9, 137)
        Me.lblT4.Name = "lblT4"
        Me.lblT4.Size = New System.Drawing.Size(21, 13)
        Me.lblT4.TabIndex = 198
        Me.lblT4.Text = "T4"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(41, 44)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 13)
        Me.Label21.TabIndex = 203
        Me.Label21.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(41, 137)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 13)
        Me.Label16.TabIndex = 199
        Me.Label16.Text = ":"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(41, 106)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(11, 13)
        Me.Label22.TabIndex = 202
        Me.Label22.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(41, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 13)
        Me.Label15.TabIndex = 200
        Me.Label15.Text = ":"
        '
        'txtIssueValue
        '
        Me.txtIssueValue.ForeColor = System.Drawing.Color.Blue
        Me.txtIssueValue.Location = New System.Drawing.Point(153, 156)
        Me.txtIssueValue.Name = "txtIssueValue"
        Me.txtIssueValue.Size = New System.Drawing.Size(135, 13)
        Me.txtIssueValue.TabIndex = 183
        Me.txtIssueValue.Visible = False
        '
        'txtIssueQty
        '
        Me.txtIssueQty.ForeColor = System.Drawing.Color.Blue
        Me.txtIssueQty.Location = New System.Drawing.Point(153, 139)
        Me.txtIssueQty.Name = "txtIssueQty"
        Me.txtIssueQty.Size = New System.Drawing.Size(135, 13)
        Me.txtIssueQty.TabIndex = 182
        '
        'lblPartNo
        '
        Me.lblPartNo.ForeColor = System.Drawing.Color.Blue
        Me.lblPartNo.Location = New System.Drawing.Point(153, 111)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Size = New System.Drawing.Size(135, 13)
        Me.lblPartNo.TabIndex = 181
        '
        'txtReturnedValue
        '
        Me.txtReturnedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnedValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturnedValue.Location = New System.Drawing.Point(150, 198)
        Me.txtReturnedValue.MaxLength = 18
        Me.txtReturnedValue.Name = "txtReturnedValue"
        Me.txtReturnedValue.Size = New System.Drawing.Size(135, 21)
        Me.txtReturnedValue.TabIndex = 9
        Me.txtReturnedValue.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(118, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 180
        Me.Label7.Text = ":"
        '
        'lblPart
        '
        Me.lblPart.AutoSize = True
        Me.lblPart.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPart.ForeColor = System.Drawing.Color.Black
        Me.lblPart.Location = New System.Drawing.Point(19, 111)
        Me.lblPart.Name = "lblPart"
        Me.lblPart.Size = New System.Drawing.Size(49, 13)
        Me.lblPart.TabIndex = 179
        Me.lblPart.Text = "Part No"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(118, 203)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 13)
        Me.Label12.TabIndex = 178
        Me.Label12.Text = ":"
        Me.Label12.Visible = False
        '
        'txtReturnedQty
        '
        Me.txtReturnedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnedQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturnedQty.Location = New System.Drawing.Point(150, 170)
        Me.txtReturnedQty.MaxLength = 18
        Me.txtReturnedQty.Name = "txtReturnedQty"
        Me.txtReturnedQty.Size = New System.Drawing.Size(135, 21)
        Me.txtReturnedQty.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(118, 174)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 175
        Me.Label11.Text = ":"
        '
        'lblReturnedValue
        '
        Me.lblReturnedValue.AutoSize = True
        Me.lblReturnedValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReturnedValue.ForeColor = System.Drawing.Color.Black
        Me.lblReturnedValue.Location = New System.Drawing.Point(19, 204)
        Me.lblReturnedValue.Name = "lblReturnedValue"
        Me.lblReturnedValue.Size = New System.Drawing.Size(95, 13)
        Me.lblReturnedValue.TabIndex = 177
        Me.lblReturnedValue.Text = "Returned Value"
        Me.lblReturnedValue.Visible = False
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(431, 211)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(98, 25)
        Me.btnReset.TabIndex = 11
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(327, 211)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(98, 25)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblReturnedQty
        '
        Me.lblReturnedQty.AutoSize = True
        Me.lblReturnedQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReturnedQty.ForeColor = System.Drawing.Color.Red
        Me.lblReturnedQty.Location = New System.Drawing.Point(19, 174)
        Me.lblReturnedQty.Name = "lblReturnedQty"
        Me.lblReturnedQty.Size = New System.Drawing.Size(83, 13)
        Me.lblReturnedQty.TabIndex = 174
        Me.lblReturnedQty.Text = "Returned Qty"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(118, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 172
        Me.Label10.Text = ":"
        Me.Label10.Visible = False
        '
        'lblIssueValue
        '
        Me.lblIssueValue.AutoSize = True
        Me.lblIssueValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssueValue.ForeColor = System.Drawing.Color.Black
        Me.lblIssueValue.Location = New System.Drawing.Point(19, 154)
        Me.lblIssueValue.Name = "lblIssueValue"
        Me.lblIssueValue.Size = New System.Drawing.Size(74, 13)
        Me.lblIssueValue.TabIndex = 171
        Me.lblIssueValue.Text = "Issue Value"
        Me.lblIssueValue.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(118, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 169
        Me.Label9.Text = ":"
        '
        'lblIssueQty
        '
        Me.lblIssueQty.AutoSize = True
        Me.lblIssueQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssueQty.ForeColor = System.Drawing.Color.Black
        Me.lblIssueQty.Location = New System.Drawing.Point(19, 139)
        Me.lblIssueQty.Name = "lblIssueQty"
        Me.lblIssueQty.Size = New System.Drawing.Size(62, 13)
        Me.lblIssueQty.TabIndex = 168
        Me.lblIssueQty.Text = "Issue Qty"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(118, 80)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(11, 13)
        Me.Label26.TabIndex = 167
        Me.Label26.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(118, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 13)
        Me.Label8.TabIndex = 166
        Me.Label8.Text = ":"
        '
        'lblUnit
        '
        Me.lblUnit.ForeColor = System.Drawing.Color.Blue
        Me.lblUnit.Location = New System.Drawing.Point(153, 80)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(135, 13)
        Me.lblUnit.TabIndex = 165
        '
        'lblUOM
        '
        Me.lblUOM.AutoSize = True
        Me.lblUOM.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUOM.ForeColor = System.Drawing.Color.Black
        Me.lblUOM.Location = New System.Drawing.Point(19, 80)
        Me.lblUOM.Name = "lblUOM"
        Me.lblUOM.Size = New System.Drawing.Size(37, 13)
        Me.lblUOM.TabIndex = 164
        Me.lblUOM.Text = "Unit  "
        '
        'lblDescription
        '
        Me.lblDescription.ForeColor = System.Drawing.Color.Blue
        Me.lblDescription.Location = New System.Drawing.Point(153, 49)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(166, 31)
        Me.lblDescription.TabIndex = 163
        '
        'lblStockDescription
        '
        Me.lblStockDescription.AutoSize = True
        Me.lblStockDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockDescription.ForeColor = System.Drawing.Color.Black
        Me.lblStockDescription.Location = New System.Drawing.Point(19, 49)
        Me.lblStockDescription.Name = "lblStockDescription"
        Me.lblStockDescription.Size = New System.Drawing.Size(83, 13)
        Me.lblStockDescription.TabIndex = 162
        Me.lblStockDescription.Text = "Description   "
        '
        'btnSearchStockCode
        '
        Me.btnSearchStockCode.BackgroundImage = CType(resources.GetObject("btnSearchStockCode.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchStockCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchStockCode.FlatAppearance.BorderSize = 0
        Me.btnSearchStockCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchStockCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchStockCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchStockCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchStockCode.Location = New System.Drawing.Point(291, 18)
        Me.btnSearchStockCode.Name = "btnSearchStockCode"
        Me.btnSearchStockCode.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchStockCode.TabIndex = 7
        Me.btnSearchStockCode.TabStop = False
        Me.btnSearchStockCode.UseVisualStyleBackColor = True
        '
        'txtStockCode
        '
        Me.txtStockCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockCode.Location = New System.Drawing.Point(153, 18)
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(135, 21)
        Me.txtStockCode.TabIndex = 6
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(118, 18)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(11, 13)
        Me.Label27.TabIndex = 157
        Me.Label27.Text = ":"
        '
        'lblStockCode
        '
        Me.lblStockCode.AutoSize = True
        Me.lblStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockCode.ForeColor = System.Drawing.Color.Red
        Me.lblStockCode.Location = New System.Drawing.Point(19, 18)
        Me.lblStockCode.Name = "lblStockCode"
        Me.lblStockCode.Size = New System.Drawing.Size(73, 13)
        Me.lblStockCode.TabIndex = 155
        Me.lblStockCode.Text = "Stock Code"
        '
        'grpRGN
        '
        Me.grpRGN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.grpRGN.Controls.Add(Me.lblRejectedReasonValue)
        Me.grpRGN.Controls.Add(Me.lblRejReasonColon)
        Me.grpRGN.Controls.Add(Me.lblRejectedReason1)
        Me.grpRGN.Controls.Add(Me.txtRemarks)
        Me.grpRGN.Controls.Add(Me.btnSearchSIVNo)
        Me.grpRGN.Controls.Add(Me.txtSIVNo)
        Me.grpRGN.Controls.Add(Me.txtRGNNo)
        Me.grpRGN.Controls.Add(Me.Label6)
        Me.grpRGN.Controls.Add(Me.Label5)
        Me.grpRGN.Controls.Add(Me.lblStatus)
        Me.grpRGN.Controls.Add(Me.Label3)
        Me.grpRGN.Controls.Add(Me.Label2)
        Me.grpRGN.Controls.Add(Me.Label1)
        Me.grpRGN.Controls.Add(Me.dtpRGNDate)
        Me.grpRGN.Controls.Add(Me.lblRGNStatus)
        Me.grpRGN.Controls.Add(Me.lblRGNDate)
        Me.grpRGN.Controls.Add(Me.lblRemarks)
        Me.grpRGN.Controls.Add(Me.lblSIVNo)
        Me.grpRGN.Controls.Add(Me.lblRGNNo)
        Me.grpRGN.Location = New System.Drawing.Point(3, 6)
        Me.grpRGN.Name = "grpRGN"
        Me.grpRGN.Size = New System.Drawing.Size(691, 107)
        Me.grpRGN.TabIndex = 0
        Me.grpRGN.TabStop = False
        Me.grpRGN.Text = "RTS"
        '
        'lblRejectedReasonValue
        '
        Me.lblRejectedReasonValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejectedReasonValue.ForeColor = System.Drawing.Color.Blue
        Me.lblRejectedReasonValue.Location = New System.Drawing.Point(547, 74)
        Me.lblRejectedReasonValue.Name = "lblRejectedReasonValue"
        Me.lblRejectedReasonValue.Size = New System.Drawing.Size(397, 23)
        Me.lblRejectedReasonValue.TabIndex = 148
        Me.lblRejectedReasonValue.Visible = False
        '
        'lblRejReasonColon
        '
        Me.lblRejReasonColon.AutoSize = True
        Me.lblRejReasonColon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejReasonColon.ForeColor = System.Drawing.Color.Black
        Me.lblRejReasonColon.Location = New System.Drawing.Point(512, 72)
        Me.lblRejReasonColon.Name = "lblRejReasonColon"
        Me.lblRejReasonColon.Size = New System.Drawing.Size(11, 13)
        Me.lblRejReasonColon.TabIndex = 147
        Me.lblRejReasonColon.Text = ":"
        '
        'lblRejectedReason1
        '
        Me.lblRejectedReason1.AutoSize = True
        Me.lblRejectedReason1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejectedReason1.ForeColor = System.Drawing.Color.Black
        Me.lblRejectedReason1.Location = New System.Drawing.Point(407, 72)
        Me.lblRejectedReason1.Name = "lblRejectedReason1"
        Me.lblRejectedReason1.Size = New System.Drawing.Size(103, 13)
        Me.lblRejectedReason1.TabIndex = 146
        Me.lblRejectedReason1.Text = "Rejected Reason"
        Me.lblRejectedReason1.Visible = False
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.ForeColor = System.Drawing.Color.Black
        Me.txtRemarks.Location = New System.Drawing.Point(149, 70)
        Me.txtRemarks.MaxLength = 200
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(248, 31)
        Me.txtRemarks.TabIndex = 5
        '
        'btnSearchSIVNo
        '
        Me.btnSearchSIVNo.BackgroundImage = CType(resources.GetObject("btnSearchSIVNo.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchSIVNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchSIVNo.FlatAppearance.BorderSize = 0
        Me.btnSearchSIVNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchSIVNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchSIVNo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchSIVNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchSIVNo.Location = New System.Drawing.Point(289, 39)
        Me.btnSearchSIVNo.Name = "btnSearchSIVNo"
        Me.btnSearchSIVNo.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchSIVNo.TabIndex = 4
        Me.btnSearchSIVNo.TabStop = False
        Me.btnSearchSIVNo.UseVisualStyleBackColor = True
        '
        'txtSIVNo
        '
        Me.txtSIVNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIVNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIVNo.Location = New System.Drawing.Point(150, 44)
        Me.txtSIVNo.Name = "txtSIVNo"
        Me.txtSIVNo.Size = New System.Drawing.Size(135, 21)
        Me.txtSIVNo.TabIndex = 3
        '
        'txtRGNNo
        '
        Me.txtRGNNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRGNNo.Enabled = False
        Me.txtRGNNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRGNNo.Location = New System.Drawing.Point(150, 15)
        Me.txtRGNNo.Name = "txtRGNNo"
        Me.txtRGNNo.Size = New System.Drawing.Size(135, 21)
        Me.txtRGNNo.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(512, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(512, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = ":"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblStatus.Location = New System.Drawing.Point(547, 46)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(38, 13)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "OPEN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(118, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(118, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(118, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ":"
        '
        'dtpRGNDate
        '
        Me.dtpRGNDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRGNDate.Location = New System.Drawing.Point(547, 15)
        Me.dtpRGNDate.Name = "dtpRGNDate"
        Me.dtpRGNDate.Size = New System.Drawing.Size(135, 21)
        Me.dtpRGNDate.TabIndex = 2
        '
        'lblRGNStatus
        '
        Me.lblRGNStatus.AutoSize = True
        Me.lblRGNStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRGNStatus.Location = New System.Drawing.Point(407, 46)
        Me.lblRGNStatus.Name = "lblRGNStatus"
        Me.lblRGNStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblRGNStatus.TabIndex = 4
        Me.lblRGNStatus.Text = "Status"
        '
        'lblRGNDate
        '
        Me.lblRGNDate.AutoSize = True
        Me.lblRGNDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRGNDate.ForeColor = System.Drawing.Color.Red
        Me.lblRGNDate.Location = New System.Drawing.Point(407, 15)
        Me.lblRGNDate.Name = "lblRGNDate"
        Me.lblRGNDate.Size = New System.Drawing.Size(61, 13)
        Me.lblRGNDate.TabIndex = 3
        Me.lblRGNDate.Text = "RTS Date"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.Location = New System.Drawing.Point(19, 72)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(58, 13)
        Me.lblRemarks.TabIndex = 2
        Me.lblRemarks.Text = "Remarks"
        '
        'lblSIVNo
        '
        Me.lblSIVNo.AutoSize = True
        Me.lblSIVNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVNo.ForeColor = System.Drawing.Color.Red
        Me.lblSIVNo.Location = New System.Drawing.Point(19, 44)
        Me.lblSIVNo.Name = "lblSIVNo"
        Me.lblSIVNo.Size = New System.Drawing.Size(47, 13)
        Me.lblSIVNo.TabIndex = 1
        Me.lblSIVNo.Text = "SIV No"
        '
        'lblRGNNo
        '
        Me.lblRGNNo.AutoSize = True
        Me.lblRGNNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRGNNo.ForeColor = System.Drawing.Color.Red
        Me.lblRGNNo.Location = New System.Drawing.Point(19, 16)
        Me.lblRGNNo.Name = "lblRGNNo"
        Me.lblRGNNo.Size = New System.Drawing.Size(49, 13)
        Me.lblRGNNo.TabIndex = 0
        Me.lblRGNNo.Text = "RTS No"
        '
        'tbpgView
        '
        Me.tbpgView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgView.Controls.Add(Me.PnlGrid)
        Me.tbpgView.Controls.Add(Me.PnlSearch)
        Me.tbpgView.Location = New System.Drawing.Point(4, 22)
        Me.tbpgView.Name = "tbpgView"
        Me.tbpgView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgView.Size = New System.Drawing.Size(985, 524)
        Me.tbpgView.TabIndex = 1
        Me.tbpgView.Text = "View"
        Me.tbpgView.UseVisualStyleBackColor = True
        '
        'PnlGrid
        '
        Me.PnlGrid.Controls.Add(Me.lblNoRecord)
        Me.PnlGrid.Controls.Add(Me.dgViewRGN)
        Me.PnlGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlGrid.Location = New System.Drawing.Point(3, 139)
        Me.PnlGrid.Name = "PnlGrid"
        Me.PnlGrid.Size = New System.Drawing.Size(979, 367)
        Me.PnlGrid.TabIndex = 88
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(130, 119)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 111
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'dgViewRGN
        '
        Me.dgViewRGN.AllowUserToAddRows = False
        Me.dgViewRGN.AllowUserToDeleteRows = False
        Me.dgViewRGN.AllowUserToResizeRows = False
        Me.dgViewRGN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgViewRGN.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgViewRGN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgViewRGN.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewRGN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgViewRGN.ColumnHeadersHeight = 30
        Me.dgViewRGN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclRGNNo, Me.dgclRGNDate, Me.dgclSIVNO, Me.dgclRemarks, Me.dgclStatus, Me.dgclRejectedStatus, Me.dgclSTRGNID, Me.dgclViewSTIssueID})
        Me.dgViewRGN.ContextMenuStrip = Me.cmsRGN
        Me.dgViewRGN.EnableHeadersVisualStyles = False
        Me.dgViewRGN.GridColor = System.Drawing.Color.Gray
        Me.dgViewRGN.Location = New System.Drawing.Point(0, 0)
        Me.dgViewRGN.MultiSelect = False
        Me.dgViewRGN.Name = "dgViewRGN"
        Me.dgViewRGN.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewRGN.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgViewRGN.RowHeadersVisible = False
        Me.dgViewRGN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgViewRGN.Size = New System.Drawing.Size(979, 345)
        Me.dgViewRGN.TabIndex = 8
        Me.dgViewRGN.TabStop = False
        '
        'dgclRGNNo
        '
        Me.dgclRGNNo.DataPropertyName = "RGNNo"
        Me.dgclRGNNo.HeaderText = "RTS No"
        Me.dgclRGNNo.Name = "dgclRGNNo"
        Me.dgclRGNNo.ReadOnly = True
        '
        'dgclRGNDate
        '
        Me.dgclRGNDate.DataPropertyName = "RGNDate"
        DataGridViewCellStyle8.Format = "dd/MM/yyyy"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.dgclRGNDate.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgclRGNDate.HeaderText = "RTS Date"
        Me.dgclRGNDate.Name = "dgclRGNDate"
        Me.dgclRGNDate.ReadOnly = True
        Me.dgclRGNDate.Width = 150
        '
        'dgclSIVNO
        '
        Me.dgclSIVNO.DataPropertyName = "SIVNO"
        Me.dgclSIVNO.HeaderText = "SIV NO"
        Me.dgclSIVNO.Name = "dgclSIVNO"
        Me.dgclSIVNO.ReadOnly = True
        '
        'dgclRemarks
        '
        Me.dgclRemarks.DataPropertyName = "Remarks"
        Me.dgclRemarks.HeaderText = "Remarks"
        Me.dgclRemarks.Name = "dgclRemarks"
        Me.dgclRemarks.ReadOnly = True
        Me.dgclRemarks.Width = 200
        '
        'dgclStatus
        '
        Me.dgclStatus.DataPropertyName = "Status"
        Me.dgclStatus.HeaderText = "Status"
        Me.dgclStatus.Name = "dgclStatus"
        Me.dgclStatus.ReadOnly = True
        '
        'dgclRejectedStatus
        '
        Me.dgclRejectedStatus.DataPropertyName = "RejectedStatus"
        Me.dgclRejectedStatus.HeaderText = "RejectedStatus"
        Me.dgclRejectedStatus.Name = "dgclRejectedStatus"
        Me.dgclRejectedStatus.ReadOnly = True
        Me.dgclRejectedStatus.Visible = False
        '
        'dgclSTRGNID
        '
        Me.dgclSTRGNID.DataPropertyName = "STRGNID"
        Me.dgclSTRGNID.HeaderText = "STRTSID"
        Me.dgclSTRGNID.Name = "dgclSTRGNID"
        Me.dgclSTRGNID.ReadOnly = True
        Me.dgclSTRGNID.Visible = False
        Me.dgclSTRGNID.Width = 150
        '
        'dgclViewSTIssueID
        '
        Me.dgclViewSTIssueID.DataPropertyName = "STIssueID"
        Me.dgclViewSTIssueID.HeaderText = "STIssueID"
        Me.dgclViewSTIssueID.Name = "dgclViewSTIssueID"
        Me.dgclViewSTIssueID.ReadOnly = True
        Me.dgclViewSTIssueID.Visible = False
        '
        'cmsRGN
        '
        Me.cmsRGN.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.cmsRGN.Name = "cmsRGN"
        Me.cmsRGN.Size = New System.Drawing.Size(108, 70)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'PnlSearch
        '
        Me.PnlSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PnlSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.PnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlSearch.BorderColor = System.Drawing.Color.Gray
        Me.PnlSearch.CaptionColorOne = System.Drawing.Color.White
        Me.PnlSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlSearch.CaptionSize = 40
        Me.PnlSearch.CaptionText = "Search Return To Store"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.txtSIVNoSearch)
        Me.PnlSearch.Controls.Add(Me.lblStatusSearch)
        Me.PnlSearch.Controls.Add(Me.cmbStatusSearch)
        Me.PnlSearch.Controls.Add(Me.lblSIVNoSerach)
        Me.PnlSearch.Controls.Add(Me.chkViewRGNDate)
        Me.PnlSearch.Controls.Add(Me.Panel2)
        Me.PnlSearch.Controls.Add(Me.dtpRGNDateSearch)
        Me.PnlSearch.Controls.Add(Me.txtRGNNoSearch)
        Me.PnlSearch.Controls.Add(Me.lblSearchBy)
        Me.PnlSearch.Controls.Add(Me.lblRGNNoSerach)
        Me.PnlSearch.Controls.Add(Me.btnViewReport)
        Me.PnlSearch.Controls.Add(Me.btnSearch)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlSearch.Moveable = True
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(979, 136)
        Me.PnlSearch.TabIndex = 87
        '
        'txtSIVNoSearch
        '
        Me.txtSIVNoSearch.Location = New System.Drawing.Point(368, 86)
        Me.txtSIVNoSearch.Name = "txtSIVNoSearch"
        Me.txtSIVNoSearch.Size = New System.Drawing.Size(129, 21)
        Me.txtSIVNoSearch.TabIndex = 4
        '
        'lblStatusSearch
        '
        Me.lblStatusSearch.AutoSize = True
        Me.lblStatusSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblStatusSearch.ForeColor = System.Drawing.Color.Black
        Me.lblStatusSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStatusSearch.Location = New System.Drawing.Point(500, 63)
        Me.lblStatusSearch.Name = "lblStatusSearch"
        Me.lblStatusSearch.Size = New System.Drawing.Size(43, 13)
        Me.lblStatusSearch.TabIndex = 89
        Me.lblStatusSearch.Text = "Status"
        '
        'cmbStatusSearch
        '
        Me.cmbStatusSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatusSearch.FormattingEnabled = True
        Me.cmbStatusSearch.Items.AddRange(New Object() {"SELECT ALL", "OPEN", "REJECTED", "APPROVED"})
        Me.cmbStatusSearch.Location = New System.Drawing.Point(503, 85)
        Me.cmbStatusSearch.Name = "cmbStatusSearch"
        Me.cmbStatusSearch.Size = New System.Drawing.Size(135, 21)
        Me.cmbStatusSearch.TabIndex = 5
        '
        'lblSIVNoSerach
        '
        Me.lblSIVNoSerach.AutoSize = True
        Me.lblSIVNoSerach.BackColor = System.Drawing.Color.Transparent
        Me.lblSIVNoSerach.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSIVNoSerach.ForeColor = System.Drawing.Color.Black
        Me.lblSIVNoSerach.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSIVNoSerach.Location = New System.Drawing.Point(368, 64)
        Me.lblSIVNoSerach.Name = "lblSIVNoSerach"
        Me.lblSIVNoSerach.Size = New System.Drawing.Size(47, 13)
        Me.lblSIVNoSerach.TabIndex = 87
        Me.lblSIVNoSerach.Text = "SIV No"
        '
        'chkViewRGNDate
        '
        Me.chkViewRGNDate.AutoSize = True
        Me.chkViewRGNDate.Location = New System.Drawing.Point(94, 64)
        Me.chkViewRGNDate.Name = "chkViewRGNDate"
        Me.chkViewRGNDate.Size = New System.Drawing.Size(80, 17)
        Me.chkViewRGNDate.TabIndex = 1
        Me.chkViewRGNDate.Text = "RTS Date"
        Me.chkViewRGNDate.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Location = New System.Drawing.Point(0, 157)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1124, 425)
        Me.Panel2.TabIndex = 33
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1118, 572)
        Me.DataGridView1.TabIndex = 31
        '
        'dtpRGNDateSearch
        '
        Me.dtpRGNDateSearch.CalendarFont = New System.Drawing.Font("Verdana", 7.5!)
        Me.dtpRGNDateSearch.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtpRGNDateSearch.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.dtpRGNDateSearch.CustomFormat = "dd/MM/yyyy"
        Me.dtpRGNDateSearch.Enabled = False
        Me.dtpRGNDateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRGNDateSearch.Location = New System.Drawing.Point(94, 86)
        Me.dtpRGNDateSearch.Name = "dtpRGNDateSearch"
        Me.dtpRGNDateSearch.Size = New System.Drawing.Size(129, 21)
        Me.dtpRGNDateSearch.TabIndex = 2
        '
        'txtRGNNoSearch
        '
        Me.txtRGNNoSearch.Location = New System.Drawing.Point(229, 86)
        Me.txtRGNNoSearch.Name = "txtRGNNoSearch"
        Me.txtRGNNoSearch.Size = New System.Drawing.Size(129, 21)
        Me.txtRGNNoSearch.TabIndex = 3
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearchBy.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchBy.Location = New System.Drawing.Point(2, 45)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchBy.TabIndex = 69
        Me.lblSearchBy.Text = "Search By"
        '
        'lblRGNNoSerach
        '
        Me.lblRGNNoSerach.AutoSize = True
        Me.lblRGNNoSerach.BackColor = System.Drawing.Color.Transparent
        Me.lblRGNNoSerach.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblRGNNoSerach.ForeColor = System.Drawing.Color.Black
        Me.lblRGNNoSerach.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRGNNoSerach.Location = New System.Drawing.Point(229, 64)
        Me.lblRGNNoSerach.Name = "lblRGNNoSerach"
        Me.lblRGNNoSerach.Size = New System.Drawing.Size(49, 13)
        Me.lblRGNNoSerach.TabIndex = 74
        Me.lblRGNNoSerach.Text = "RTS No"
        '
        'btnViewReport
        '
        Me.btnViewReport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.Image = CType(resources.GetObject("btnViewReport.Image"), System.Drawing.Image)
        Me.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewReport.Location = New System.Drawing.Point(774, 82)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(116, 29)
        Me.btnViewReport.TabIndex = 7
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearch.Location = New System.Drawing.Point(649, 82)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(116, 29)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'ReturnGoodsNoteFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(992, 546)
        Me.Controls.Add(Me.tbRGN)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ReturnGoodsNoteFrm"
        Me.Text = "Return To Store"
        Me.tbRGN.ResumeLayout(False)
        Me.tbpgRGN.ResumeLayout(False)
        Me.grpApproval.ResumeLayout(False)
        Me.grpApproval.PerformLayout()
        CType(Me.dgRGN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsRGNAddEdit.ResumeLayout(False)
        Me.grpRGNStockDetails.ResumeLayout(False)
        Me.grpRGNStockDetails.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpRGN.ResumeLayout(False)
        Me.grpRGN.PerformLayout()
        Me.tbpgView.ResumeLayout(False)
        Me.PnlGrid.ResumeLayout(False)
        Me.PnlGrid.PerformLayout()
        CType(Me.dgViewRGN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsRGN.ResumeLayout(False)
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbRGN As System.Windows.Forms.TabControl
    Friend WithEvents tbpgRGN As System.Windows.Forms.TabPage
    Friend WithEvents tbpgView As System.Windows.Forms.TabPage
    Friend WithEvents grpRGNStockDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents lblUOM As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblStockDescription As System.Windows.Forms.Label
    Friend WithEvents btnSearchStockCode As System.Windows.Forms.Button
    Friend WithEvents txtStockCode As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblStockCode As System.Windows.Forms.Label
    Friend WithEvents grpRGN As System.Windows.Forms.GroupBox
    Friend WithEvents txtSIVNo As System.Windows.Forms.TextBox
    Friend WithEvents txtRGNNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpRGNDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRGNStatus As System.Windows.Forms.Label
    Friend WithEvents lblRGNDate As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents lblSIVNo As System.Windows.Forms.Label
    Friend WithEvents lblRGNNo As System.Windows.Forms.Label
    Friend WithEvents btnSearchSIVNo As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblIssueValue As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblIssueQty As System.Windows.Forms.Label
    Friend WithEvents txtReturnedValue As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblReturnedValue As System.Windows.Forms.Label
    Friend WithEvents txtReturnedQty As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblReturnedQty As System.Windows.Forms.Label
    Friend WithEvents dgRGN As System.Windows.Forms.DataGridView
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PnlGrid As System.Windows.Forms.Panel
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents chkViewRGNDate As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents dtpRGNDateSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRGNNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents lblRGNNoSerach As System.Windows.Forms.Label
    Friend WithEvents txtSIVNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSIVNoSerach As System.Windows.Forms.Label
    Friend WithEvents dgViewRGN As System.Windows.Forms.DataGridView
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cmbStatusSearch As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatusSearch As System.Windows.Forms.Label
    Friend WithEvents cmsRGN As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents grpApproval As System.Windows.Forms.GroupBox
    Friend WithEvents lblRejectedColon As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnConform As System.Windows.Forms.Button
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtRejectedReason As System.Windows.Forms.TextBox
    Friend WithEvents lblRejectedReason As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPartNo As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblPart As System.Windows.Forms.Label
    Friend WithEvents txtIssueValue As System.Windows.Forms.Label
    Friend WithEvents txtIssueQty As System.Windows.Forms.Label
    Friend WithEvents dgclRGNNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRGNDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSIVNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTRGNID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclViewSTIssueID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblT4 As System.Windows.Forms.Label
    Friend WithEvents lblT3 As System.Windows.Forms.Label
    Friend WithEvents lblT2 As System.Windows.Forms.Label
    Friend WithEvents lblT1 As System.Windows.Forms.Label
    Friend WithEvents lblT0 As System.Windows.Forms.Label
    Friend WithEvents lblSIVT0Value As System.Windows.Forms.Label
    Friend WithEvents lblSIVT4Value As System.Windows.Forms.Label
    Friend WithEvents lblSIVT3Value As System.Windows.Forms.Label
    Friend WithEvents lblSIVT2Value As System.Windows.Forms.Label
    Friend WithEvents lblSIVT1Value As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblsubBlock As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblVHDetailsCostCode As System.Windows.Forms.Label
    Friend WithEvents lblOdoReading As System.Windows.Forms.Label
    Friend WithEvents lblVHNo As System.Windows.Forms.Label
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents lblYOP As System.Windows.Forms.Label
    Friend WithEvents lblDiv As System.Windows.Forms.Label
    Friend WithEvents lblSIVStation As System.Windows.Forms.Label
    Friend WithEvents lblSIVVHDetailCostCode As System.Windows.Forms.Label
    Friend WithEvents lblSIVVHNo As System.Windows.Forms.Label
    Friend WithEvents lblSIVODOReading As System.Windows.Forms.Label
    Friend WithEvents lblSIVDiv As System.Windows.Forms.Label
    Friend WithEvents lblSIVYOP As System.Windows.Forms.Label
    Friend WithEvents lblSIVBlock As System.Windows.Forms.Label
    Friend WithEvents lblRejReasonColon As System.Windows.Forms.Label
    Friend WithEvents lblRejectedReason1 As System.Windows.Forms.Label
    Friend WithEvents lblRejectedReasonValue As System.Windows.Forms.Label
    Friend WithEvents cmsRGNAddEdit As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents dgclStockCategoryId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTIssueId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTIssueDetailsID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTReturnGoodsDetailsID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTReturnGoodsNoteID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIVCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIVCOACODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIVCOADESCP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVarianceCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT0Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT1Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT2Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT3Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT4Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDiv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDivId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclYOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclYOPId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBlock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBlockId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHDetailCostCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVHDetailCostCodeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStationId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclODOReading As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIssueQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIssueValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReturnQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReturnedValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

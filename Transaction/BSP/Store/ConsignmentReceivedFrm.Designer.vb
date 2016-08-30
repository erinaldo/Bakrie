<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsignmentReceivedFrm
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsignmentReceivedFrm))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tcConsiognmentReceived = New System.Windows.Forms.TabControl
        Me.tbpgConsignmentReceived = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblCRRejectedReasonColon = New System.Windows.Forms.Label
        Me.lblCRRejectedReasonValue = New System.Windows.Forms.Label
        Me.lblCRRejectedReason = New System.Windows.Forms.Label
        Me.grpApproval = New System.Windows.Forms.GroupBox
        Me.lblRejectedColon = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnConform = New System.Windows.Forms.Button
        Me.cmbStatus = New System.Windows.Forms.ComboBox
        Me.txtRejectedReason = New System.Windows.Forms.TextBox
        Me.lblRejectedReason = New System.Windows.Forms.Label
        Me.lblApprovalStatus = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblCRStatus = New System.Windows.Forms.Label
        Me.lblPartNoValue = New System.Windows.Forms.Label
        Me.lblStockBalanceValue = New System.Windows.Forms.Label
        Me.lblUOMValue = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblPartNo = New System.Windows.Forms.Label
        Me.lblStockBalance = New System.Windows.Forms.Label
        Me.lblUOM = New System.Windows.Forms.Label
        Me.dtpReceivedDate = New System.Windows.Forms.DateTimePicker
        Me.lblConsignmentStockcodeDesc = New System.Windows.Forms.Label
        Me.btnSearchStockCode = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblReferenceNo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblConsignmentStockCode = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblReceivedQty = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.txtReferenceNo = New System.Windows.Forms.TextBox
        Me.txtConsignmentStockCode = New System.Windows.Forms.TextBox
        Me.txtReceivedQty = New System.Windows.Forms.TextBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblReceivedDate = New System.Windows.Forms.Label
        Me.tbpgView = New System.Windows.Forms.TabPage
        Me.plIPRView = New System.Windows.Forms.Panel
        Me.lblNoRecordFound = New System.Windows.Forms.Label
        Me.dgvviewCReceived = New System.Windows.Forms.DataGridView
        Me.ReceivedDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STConsignmentMasterID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StConsignmentID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UOMID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UOM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockBalance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivedQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsCReceived = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlConsignmentReceived = New Stepi.UI.ExtendedPanel
        Me.lblViewStatus = New System.Windows.Forms.Label
        Me.cmbStatusSearch = New System.Windows.Forms.ComboBox
        Me.txtviewStockCode = New System.Windows.Forms.TextBox
        Me.lblviewStockCode = New System.Windows.Forms.Label
        Me.chkviewCRDate = New System.Windows.Forms.CheckBox
        Me.lblviewISRSearchBy = New System.Windows.Forms.Label
        Me.dtpviewCRDate = New System.Windows.Forms.DateTimePicker
        Me.lblviewReferenceno = New System.Windows.Forms.Label
        Me.txtviewCRNo = New System.Windows.Forms.TextBox
        Me.btnviewCRReport = New System.Windows.Forms.Button
        Me.btnviewCRSearch = New System.Windows.Forms.Button
        Me.tcConsiognmentReceived.SuspendLayout()
        Me.tbpgConsignmentReceived.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpApproval.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tbpgView.SuspendLayout()
        Me.plIPRView.SuspendLayout()
        CType(Me.dgvviewCReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsCReceived.SuspendLayout()
        Me.pnlConsignmentReceived.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcConsiognmentReceived
        '
        Me.tcConsiognmentReceived.Controls.Add(Me.tbpgConsignmentReceived)
        Me.tcConsiognmentReceived.Controls.Add(Me.tbpgView)
        Me.tcConsiognmentReceived.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcConsiognmentReceived.Location = New System.Drawing.Point(0, 0)
        Me.tcConsiognmentReceived.Name = "tcConsiognmentReceived"
        Me.tcConsiognmentReceived.SelectedIndex = 0
        Me.tcConsiognmentReceived.Size = New System.Drawing.Size(1015, 732)
        Me.tcConsiognmentReceived.TabIndex = 1
        Me.tcConsiognmentReceived.TabStop = False
        '
        'tbpgConsignmentReceived
        '
        Me.tbpgConsignmentReceived.AutoScroll = True
        Me.tbpgConsignmentReceived.BackColor = System.Drawing.Color.Transparent
        Me.tbpgConsignmentReceived.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgConsignmentReceived.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgConsignmentReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbpgConsignmentReceived.Controls.Add(Me.GroupBox1)
        Me.tbpgConsignmentReceived.Location = New System.Drawing.Point(4, 22)
        Me.tbpgConsignmentReceived.Name = "tbpgConsignmentReceived"
        Me.tbpgConsignmentReceived.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgConsignmentReceived.Size = New System.Drawing.Size(1007, 706)
        Me.tbpgConsignmentReceived.TabIndex = 0
        Me.tbpgConsignmentReceived.Text = "Consignment Received"
        Me.tbpgConsignmentReceived.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.lblCRRejectedReasonColon)
        Me.GroupBox1.Controls.Add(Me.lblCRRejectedReasonValue)
        Me.GroupBox1.Controls.Add(Me.lblCRRejectedReason)
        Me.GroupBox1.Controls.Add(Me.grpApproval)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Controls.Add(Me.lblCRStatus)
        Me.GroupBox1.Controls.Add(Me.lblPartNoValue)
        Me.GroupBox1.Controls.Add(Me.lblStockBalanceValue)
        Me.GroupBox1.Controls.Add(Me.lblUOMValue)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblPartNo)
        Me.GroupBox1.Controls.Add(Me.lblStockBalance)
        Me.GroupBox1.Controls.Add(Me.lblUOM)
        Me.GroupBox1.Controls.Add(Me.dtpReceivedDate)
        Me.GroupBox1.Controls.Add(Me.lblConsignmentStockcodeDesc)
        Me.GroupBox1.Controls.Add(Me.btnSearchStockCode)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblReferenceNo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblConsignmentStockCode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblReceivedQty)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblRemarks)
        Me.GroupBox1.Controls.Add(Me.txtReferenceNo)
        Me.GroupBox1.Controls.Add(Me.txtConsignmentStockCode)
        Me.GroupBox1.Controls.Add(Me.txtReceivedQty)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.lblReceivedDate)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(738, 317)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'lblCRRejectedReasonColon
        '
        Me.lblCRRejectedReasonColon.AutoSize = True
        Me.lblCRRejectedReasonColon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCRRejectedReasonColon.ForeColor = System.Drawing.Color.Black
        Me.lblCRRejectedReasonColon.Location = New System.Drawing.Point(557, 50)
        Me.lblCRRejectedReasonColon.Name = "lblCRRejectedReasonColon"
        Me.lblCRRejectedReasonColon.Size = New System.Drawing.Size(11, 13)
        Me.lblCRRejectedReasonColon.TabIndex = 173
        Me.lblCRRejectedReasonColon.Text = ":"
        '
        'lblCRRejectedReasonValue
        '
        Me.lblCRRejectedReasonValue.AutoSize = True
        Me.lblCRRejectedReasonValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCRRejectedReasonValue.ForeColor = System.Drawing.Color.Blue
        Me.lblCRRejectedReasonValue.Location = New System.Drawing.Point(589, 50)
        Me.lblCRRejectedReasonValue.Name = "lblCRRejectedReasonValue"
        Me.lblCRRejectedReasonValue.Size = New System.Drawing.Size(0, 13)
        Me.lblCRRejectedReasonValue.TabIndex = 172
        '
        'lblCRRejectedReason
        '
        Me.lblCRRejectedReason.AutoSize = True
        Me.lblCRRejectedReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCRRejectedReason.Location = New System.Drawing.Point(453, 50)
        Me.lblCRRejectedReason.Name = "lblCRRejectedReason"
        Me.lblCRRejectedReason.Size = New System.Drawing.Size(103, 13)
        Me.lblCRRejectedReason.TabIndex = 171
        Me.lblCRRejectedReason.Text = "Rejected Reason"
        '
        'grpApproval
        '
        Me.grpApproval.Controls.Add(Me.lblRejectedColon)
        Me.grpApproval.Controls.Add(Me.Label7)
        Me.grpApproval.Controls.Add(Me.btnConform)
        Me.grpApproval.Controls.Add(Me.cmbStatus)
        Me.grpApproval.Controls.Add(Me.txtRejectedReason)
        Me.grpApproval.Controls.Add(Me.lblRejectedReason)
        Me.grpApproval.Controls.Add(Me.lblApprovalStatus)
        Me.grpApproval.Location = New System.Drawing.Point(450, 92)
        Me.grpApproval.Name = "grpApproval"
        Me.grpApproval.Size = New System.Drawing.Size(267, 101)
        Me.grpApproval.TabIndex = 170
        Me.grpApproval.TabStop = False
        Me.grpApproval.Text = "Consignment Received Approval"
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(107, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = ":"
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
        Me.btnConform.TabIndex = 137
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
        Me.cmbStatus.TabIndex = 142
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
        Me.txtRejectedReason.TabIndex = 142
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
        'lblApprovalStatus
        '
        Me.lblApprovalStatus.AutoSize = True
        Me.lblApprovalStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovalStatus.ForeColor = System.Drawing.Color.Black
        Me.lblApprovalStatus.Location = New System.Drawing.Point(6, 15)
        Me.lblApprovalStatus.Name = "lblApprovalStatus"
        Me.lblApprovalStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblApprovalStatus.TabIndex = 142
        Me.lblApprovalStatus.Text = "Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(554, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = ":"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblStatus.Location = New System.Drawing.Point(589, 21)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(38, 13)
        Me.lblStatus.TabIndex = 121
        Me.lblStatus.Text = "OPEN"
        '
        'lblCRStatus
        '
        Me.lblCRStatus.AutoSize = True
        Me.lblCRStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCRStatus.Location = New System.Drawing.Point(449, 21)
        Me.lblCRStatus.Name = "lblCRStatus"
        Me.lblCRStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblCRStatus.TabIndex = 120
        Me.lblCRStatus.Text = "Status"
        '
        'lblPartNoValue
        '
        Me.lblPartNoValue.AutoSize = True
        Me.lblPartNoValue.BackColor = System.Drawing.Color.Transparent
        Me.lblPartNoValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNoValue.ForeColor = System.Drawing.Color.Blue
        Me.lblPartNoValue.Location = New System.Drawing.Point(189, 144)
        Me.lblPartNoValue.Name = "lblPartNoValue"
        Me.lblPartNoValue.Size = New System.Drawing.Size(0, 13)
        Me.lblPartNoValue.TabIndex = 119
        '
        'lblStockBalanceValue
        '
        Me.lblStockBalanceValue.AutoSize = True
        Me.lblStockBalanceValue.BackColor = System.Drawing.Color.Transparent
        Me.lblStockBalanceValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockBalanceValue.ForeColor = System.Drawing.Color.Blue
        Me.lblStockBalanceValue.Location = New System.Drawing.Point(189, 119)
        Me.lblStockBalanceValue.Name = "lblStockBalanceValue"
        Me.lblStockBalanceValue.Size = New System.Drawing.Size(0, 13)
        Me.lblStockBalanceValue.TabIndex = 118
        '
        'lblUOMValue
        '
        Me.lblUOMValue.AutoSize = True
        Me.lblUOMValue.BackColor = System.Drawing.Color.Transparent
        Me.lblUOMValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUOMValue.ForeColor = System.Drawing.Color.Blue
        Me.lblUOMValue.Location = New System.Drawing.Point(189, 94)
        Me.lblUOMValue.Name = "lblUOMValue"
        Me.lblUOMValue.Size = New System.Drawing.Size(0, 13)
        Me.lblUOMValue.TabIndex = 117
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(171, 144)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 116
        Me.Label11.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(172, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(172, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 112
        Me.Label10.Text = ":"
        '
        'lblPartNo
        '
        Me.lblPartNo.AutoSize = True
        Me.lblPartNo.BackColor = System.Drawing.Color.Transparent
        Me.lblPartNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNo.ForeColor = System.Drawing.Color.Black
        Me.lblPartNo.Location = New System.Drawing.Point(16, 144)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Size = New System.Drawing.Size(49, 13)
        Me.lblPartNo.TabIndex = 111
        Me.lblPartNo.Text = "Part No"
        '
        'lblStockBalance
        '
        Me.lblStockBalance.AutoSize = True
        Me.lblStockBalance.BackColor = System.Drawing.Color.Transparent
        Me.lblStockBalance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockBalance.ForeColor = System.Drawing.Color.Black
        Me.lblStockBalance.Location = New System.Drawing.Point(16, 119)
        Me.lblStockBalance.Name = "lblStockBalance"
        Me.lblStockBalance.Size = New System.Drawing.Size(88, 13)
        Me.lblStockBalance.TabIndex = 110
        Me.lblStockBalance.Text = "Stock Balance"
        '
        'lblUOM
        '
        Me.lblUOM.AutoSize = True
        Me.lblUOM.BackColor = System.Drawing.Color.Transparent
        Me.lblUOM.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUOM.ForeColor = System.Drawing.Color.Black
        Me.lblUOM.Location = New System.Drawing.Point(16, 94)
        Me.lblUOM.Name = "lblUOM"
        Me.lblUOM.Size = New System.Drawing.Size(33, 13)
        Me.lblUOM.TabIndex = 109
        Me.lblUOM.Text = "UOM"
        '
        'dtpReceivedDate
        '
        Me.dtpReceivedDate.Location = New System.Drawing.Point(188, 18)
        Me.dtpReceivedDate.Name = "dtpReceivedDate"
        Me.dtpReceivedDate.Size = New System.Drawing.Size(185, 20)
        Me.dtpReceivedDate.TabIndex = 2
        '
        'lblConsignmentStockcodeDesc
        '
        Me.lblConsignmentStockcodeDesc.AutoSize = True
        Me.lblConsignmentStockcodeDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblConsignmentStockcodeDesc.ForeColor = System.Drawing.Color.Blue
        Me.lblConsignmentStockcodeDesc.Location = New System.Drawing.Point(416, 71)
        Me.lblConsignmentStockcodeDesc.Name = "lblConsignmentStockcodeDesc"
        Me.lblConsignmentStockcodeDesc.Size = New System.Drawing.Size(0, 13)
        Me.lblConsignmentStockcodeDesc.TabIndex = 108
        '
        'btnSearchStockCode
        '
        Me.btnSearchStockCode.Image = CType(resources.GetObject("btnSearchStockCode.Image"), System.Drawing.Image)
        Me.btnSearchStockCode.Location = New System.Drawing.Point(379, 65)
        Me.btnSearchStockCode.Name = "btnSearchStockCode"
        Me.btnSearchStockCode.Size = New System.Drawing.Size(31, 26)
        Me.btnSearchStockCode.TabIndex = 5
        Me.btnSearchStockCode.TabStop = False
        Me.btnSearchStockCode.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.btnReset)
        Me.GroupBox2.Controls.Add(Me.btnClose)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 250)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(722, 58)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(503, 19)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 28)
        Me.btnReset.TabIndex = 9
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(604, 19)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 28)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(402, 19)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 28)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(170, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(170, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = ":"
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.AutoSize = True
        Me.lblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.lblReferenceNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReferenceNo.ForeColor = System.Drawing.Color.Red
        Me.lblReferenceNo.Location = New System.Drawing.Point(16, 44)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Size = New System.Drawing.Size(84, 13)
        Me.lblReferenceNo.TabIndex = 1
        Me.lblReferenceNo.Text = "Reference No"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(171, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = ":"
        '
        'lblConsignmentStockCode
        '
        Me.lblConsignmentStockCode.AutoSize = True
        Me.lblConsignmentStockCode.BackColor = System.Drawing.Color.Transparent
        Me.lblConsignmentStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsignmentStockCode.ForeColor = System.Drawing.Color.Red
        Me.lblConsignmentStockCode.Location = New System.Drawing.Point(16, 69)
        Me.lblConsignmentStockCode.Name = "lblConsignmentStockCode"
        Me.lblConsignmentStockCode.Size = New System.Drawing.Size(152, 13)
        Me.lblConsignmentStockCode.TabIndex = 2
        Me.lblConsignmentStockCode.Text = "Consignment Stock Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(171, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = ":"
        '
        'lblReceivedQty
        '
        Me.lblReceivedQty.AutoSize = True
        Me.lblReceivedQty.BackColor = System.Drawing.Color.Transparent
        Me.lblReceivedQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceivedQty.ForeColor = System.Drawing.Color.Red
        Me.lblReceivedQty.Location = New System.Drawing.Point(16, 169)
        Me.lblReceivedQty.Name = "lblReceivedQty"
        Me.lblReceivedQty.Size = New System.Drawing.Size(83, 13)
        Me.lblReceivedQty.TabIndex = 3
        Me.lblReceivedQty.Text = "Received Qty"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(171, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = ":"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(16, 193)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(58, 13)
        Me.lblRemarks.TabIndex = 4
        Me.lblRemarks.Text = "Remarks"
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNo.Location = New System.Drawing.Point(187, 43)
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.Size = New System.Drawing.Size(186, 20)
        Me.txtReferenceNo.TabIndex = 3
        '
        'txtConsignmentStockCode
        '
        Me.txtConsignmentStockCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConsignmentStockCode.Location = New System.Drawing.Point(187, 68)
        Me.txtConsignmentStockCode.Name = "txtConsignmentStockCode"
        Me.txtConsignmentStockCode.Size = New System.Drawing.Size(186, 20)
        Me.txtConsignmentStockCode.TabIndex = 4
        '
        'txtReceivedQty
        '
        Me.txtReceivedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceivedQty.Location = New System.Drawing.Point(188, 168)
        Me.txtReceivedQty.Name = "txtReceivedQty"
        Me.txtReceivedQty.Size = New System.Drawing.Size(186, 20)
        Me.txtReceivedQty.TabIndex = 6
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Location = New System.Drawing.Point(187, 193)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(263, 51)
        Me.txtRemarks.TabIndex = 7
        '
        'lblReceivedDate
        '
        Me.lblReceivedDate.AutoSize = True
        Me.lblReceivedDate.BackColor = System.Drawing.Color.Transparent
        Me.lblReceivedDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceivedDate.ForeColor = System.Drawing.Color.Red
        Me.lblReceivedDate.Location = New System.Drawing.Point(16, 19)
        Me.lblReceivedDate.Name = "lblReceivedDate"
        Me.lblReceivedDate.Size = New System.Drawing.Size(90, 13)
        Me.lblReceivedDate.TabIndex = 0
        Me.lblReceivedDate.Text = "Received Date"
        '
        'tbpgView
        '
        Me.tbpgView.AutoScroll = True
        Me.tbpgView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgView.Controls.Add(Me.plIPRView)
        Me.tbpgView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpgView.Location = New System.Drawing.Point(4, 22)
        Me.tbpgView.Name = "tbpgView"
        Me.tbpgView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgView.Size = New System.Drawing.Size(1007, 706)
        Me.tbpgView.TabIndex = 1
        Me.tbpgView.Text = "View"
        Me.tbpgView.UseVisualStyleBackColor = True
        '
        'plIPRView
        '
        Me.plIPRView.Controls.Add(Me.lblNoRecordFound)
        Me.plIPRView.Controls.Add(Me.dgvviewCReceived)
        Me.plIPRView.Controls.Add(Me.pnlConsignmentReceived)
        Me.plIPRView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plIPRView.Location = New System.Drawing.Point(3, 3)
        Me.plIPRView.Name = "plIPRView"
        Me.plIPRView.Size = New System.Drawing.Size(1001, 700)
        Me.plIPRView.TabIndex = 45
        '
        'lblNoRecordFound
        '
        Me.lblNoRecordFound.AutoSize = True
        Me.lblNoRecordFound.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblNoRecordFound.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecordFound.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecordFound.Location = New System.Drawing.Point(247, 225)
        Me.lblNoRecordFound.Name = "lblNoRecordFound"
        Me.lblNoRecordFound.Size = New System.Drawing.Size(130, 13)
        Me.lblNoRecordFound.TabIndex = 121
        Me.lblNoRecordFound.Text = "Record not found !!"
        Me.lblNoRecordFound.Visible = False
        '
        'dgvviewCReceived
        '
        Me.dgvviewCReceived.AllowUserToAddRows = False
        Me.dgvviewCReceived.AllowUserToDeleteRows = False
        Me.dgvviewCReceived.AllowUserToOrderColumns = True
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvviewCReceived.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvviewCReceived.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvviewCReceived.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvviewCReceived.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvviewCReceived.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvviewCReceived.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvviewCReceived.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvviewCReceived.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReceivedDate, Me.ReferenceNo, Me.STCode, Me.STConsignmentMasterID, Me.STDesc, Me.StConsignmentID, Me.UOMID, Me.UOM, Me.PartNo, Me.StockBalance, Me.ReceivedQty, Me.Remarks, Me.Status, Me.RejectedReason})
        Me.dgvviewCReceived.ContextMenuStrip = Me.cmsCReceived
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvviewCReceived.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvviewCReceived.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvviewCReceived.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvviewCReceived.EnableHeadersVisualStyles = False
        Me.dgvviewCReceived.GridColor = System.Drawing.Color.Gray
        Me.dgvviewCReceived.Location = New System.Drawing.Point(0, 135)
        Me.dgvviewCReceived.Name = "dgvviewCReceived"
        Me.dgvviewCReceived.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvviewCReceived.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvviewCReceived.RowHeadersVisible = False
        Me.dgvviewCReceived.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvviewCReceived.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvviewCReceived.ShowCellErrors = False
        Me.dgvviewCReceived.Size = New System.Drawing.Size(1001, 565)
        Me.dgvviewCReceived.TabIndex = 117
        Me.dgvviewCReceived.TabStop = False
        '
        'ReceivedDate
        '
        Me.ReceivedDate.DataPropertyName = "ReceivedDate"
        DataGridViewCellStyle8.Format = "dd/MM/yyyy"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ReceivedDate.DefaultCellStyle = DataGridViewCellStyle8
        Me.ReceivedDate.HeaderText = "Received Date"
        Me.ReceivedDate.Name = "ReceivedDate"
        Me.ReceivedDate.ReadOnly = True
        Me.ReceivedDate.Width = 114
        '
        'ReferenceNo
        '
        Me.ReferenceNo.DataPropertyName = "ReferenceNo"
        Me.ReferenceNo.HeaderText = "Reference No"
        Me.ReferenceNo.Name = "ReferenceNo"
        Me.ReferenceNo.ReadOnly = True
        Me.ReferenceNo.Width = 108
        '
        'STCode
        '
        Me.STCode.DataPropertyName = "STCode"
        Me.STCode.HeaderText = "Consignment Stock Code"
        Me.STCode.Name = "STCode"
        Me.STCode.ReadOnly = True
        Me.STCode.Width = 176
        '
        'STConsignmentMasterID
        '
        Me.STConsignmentMasterID.DataPropertyName = "STConsignmentMasterID"
        Me.STConsignmentMasterID.HeaderText = "STConsignment MasterID"
        Me.STConsignmentMasterID.Name = "STConsignmentMasterID"
        Me.STConsignmentMasterID.ReadOnly = True
        Me.STConsignmentMasterID.Visible = False
        Me.STConsignmentMasterID.Width = 177
        '
        'STDesc
        '
        Me.STDesc.DataPropertyName = "STDesc"
        Me.STDesc.HeaderText = "STDesc"
        Me.STDesc.Name = "STDesc"
        Me.STDesc.ReadOnly = True
        Me.STDesc.Visible = False
        Me.STDesc.Width = 74
        '
        'StConsignmentID
        '
        Me.StConsignmentID.DataPropertyName = "StConsignmentID"
        Me.StConsignmentID.HeaderText = "StConsignmentID"
        Me.StConsignmentID.Name = "StConsignmentID"
        Me.StConsignmentID.ReadOnly = True
        Me.StConsignmentID.Visible = False
        Me.StConsignmentID.Width = 132
        '
        'UOMID
        '
        Me.UOMID.DataPropertyName = "UOMID"
        Me.UOMID.HeaderText = "UOMID"
        Me.UOMID.Name = "UOMID"
        Me.UOMID.ReadOnly = True
        Me.UOMID.Visible = False
        Me.UOMID.Width = 71
        '
        'UOM
        '
        Me.UOM.DataPropertyName = "UOM"
        Me.UOM.HeaderText = "UOM"
        Me.UOM.Name = "UOM"
        Me.UOM.ReadOnly = True
        Me.UOM.Width = 57
        '
        'PartNo
        '
        Me.PartNo.DataPropertyName = "PartNo"
        Me.PartNo.HeaderText = "Part No."
        Me.PartNo.Name = "PartNo"
        Me.PartNo.ReadOnly = True
        Me.PartNo.Width = 77
        '
        'StockBalance
        '
        Me.StockBalance.DataPropertyName = "StockBalance"
        Me.StockBalance.HeaderText = "Stock Balance"
        Me.StockBalance.Name = "StockBalance"
        Me.StockBalance.ReadOnly = True
        Me.StockBalance.Width = 112
        '
        'ReceivedQty
        '
        Me.ReceivedQty.DataPropertyName = "ReceivedQty"
        Me.ReceivedQty.HeaderText = "Received Qty"
        Me.ReceivedQty.Name = "ReceivedQty"
        Me.ReceivedQty.ReadOnly = True
        Me.ReceivedQty.Width = 107
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        Me.Remarks.Width = 82
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 67
        '
        'RejectedReason
        '
        Me.RejectedReason.DataPropertyName = "RejectedReason"
        Me.RejectedReason.HeaderText = "RejectedReason"
        Me.RejectedReason.Name = "RejectedReason"
        Me.RejectedReason.ReadOnly = True
        Me.RejectedReason.Visible = False
        Me.RejectedReason.Width = 123
        '
        'cmsCReceived
        '
        Me.cmsCReceived.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsCReceived.Name = "cmsIPR"
        Me.cmsCReceived.Size = New System.Drawing.Size(149, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.EditToolStripMenuItem.Text = "Edit / Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'pnlConsignmentReceived
        '
        Me.pnlConsignmentReceived.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlConsignmentReceived.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlConsignmentReceived.BorderColor = System.Drawing.Color.Gray
        Me.pnlConsignmentReceived.CaptionColorOne = System.Drawing.Color.White
        Me.pnlConsignmentReceived.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlConsignmentReceived.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlConsignmentReceived.CaptionSize = 40
        Me.pnlConsignmentReceived.CaptionText = "Search ConsignmentReceived"
        Me.pnlConsignmentReceived.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlConsignmentReceived.Controls.Add(Me.lblViewStatus)
        Me.pnlConsignmentReceived.Controls.Add(Me.cmbStatusSearch)
        Me.pnlConsignmentReceived.Controls.Add(Me.txtviewStockCode)
        Me.pnlConsignmentReceived.Controls.Add(Me.lblviewStockCode)
        Me.pnlConsignmentReceived.Controls.Add(Me.chkviewCRDate)
        Me.pnlConsignmentReceived.Controls.Add(Me.lblviewISRSearchBy)
        Me.pnlConsignmentReceived.Controls.Add(Me.dtpviewCRDate)
        Me.pnlConsignmentReceived.Controls.Add(Me.lblviewReferenceno)
        Me.pnlConsignmentReceived.Controls.Add(Me.txtviewCRNo)
        Me.pnlConsignmentReceived.Controls.Add(Me.btnviewCRReport)
        Me.pnlConsignmentReceived.Controls.Add(Me.btnviewCRSearch)
        Me.pnlConsignmentReceived.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlConsignmentReceived.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlConsignmentReceived.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlConsignmentReceived.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlConsignmentReceived.ForeColor = System.Drawing.Color.Black
        Me.pnlConsignmentReceived.Location = New System.Drawing.Point(0, 0)
        Me.pnlConsignmentReceived.Name = "pnlConsignmentReceived"
        Me.pnlConsignmentReceived.Size = New System.Drawing.Size(1001, 135)
        Me.pnlConsignmentReceived.TabIndex = 18
        '
        'lblViewStatus
        '
        Me.lblViewStatus.AutoSize = True
        Me.lblViewStatus.Location = New System.Drawing.Point(609, 64)
        Me.lblViewStatus.Name = "lblViewStatus"
        Me.lblViewStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblViewStatus.TabIndex = 120
        Me.lblViewStatus.Text = "Status"
        '
        'cmbStatusSearch
        '
        Me.cmbStatusSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatusSearch.FormattingEnabled = True
        Me.cmbStatusSearch.Items.AddRange(New Object() {"SELECT ALL", "OPEN", "REJECTED", "APPROVED"})
        Me.cmbStatusSearch.Location = New System.Drawing.Point(612, 83)
        Me.cmbStatusSearch.Name = "cmbStatusSearch"
        Me.cmbStatusSearch.Size = New System.Drawing.Size(135, 21)
        Me.cmbStatusSearch.TabIndex = 16
        '
        'txtviewStockCode
        '
        Me.txtviewStockCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewStockCode.Location = New System.Drawing.Point(413, 83)
        Me.txtviewStockCode.MaxLength = 50
        Me.txtviewStockCode.Name = "txtviewStockCode"
        Me.txtviewStockCode.Size = New System.Drawing.Size(196, 21)
        Me.txtviewStockCode.TabIndex = 15
        '
        'lblviewStockCode
        '
        Me.lblviewStockCode.AutoSize = True
        Me.lblviewStockCode.Location = New System.Drawing.Point(410, 65)
        Me.lblviewStockCode.Name = "lblviewStockCode"
        Me.lblviewStockCode.Size = New System.Drawing.Size(69, 13)
        Me.lblviewStockCode.TabIndex = 118
        Me.lblviewStockCode.Text = "StockCode"
        '
        'chkviewCRDate
        '
        Me.chkviewCRDate.AutoSize = True
        Me.chkviewCRDate.Enabled = False
        Me.chkviewCRDate.Location = New System.Drawing.Point(74, 64)
        Me.chkviewCRDate.Name = "chkviewCRDate"
        Me.chkviewCRDate.Size = New System.Drawing.Size(109, 17)
        Me.chkviewCRDate.TabIndex = 12
        Me.chkviewCRDate.Text = "Received Date"
        Me.chkviewCRDate.UseVisualStyleBackColor = True
        '
        'lblviewISRSearchBy
        '
        Me.lblviewISRSearchBy.AutoSize = True
        Me.lblviewISRSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblviewISRSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewISRSearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblviewISRSearchBy.Location = New System.Drawing.Point(1, 41)
        Me.lblviewISRSearchBy.Name = "lblviewISRSearchBy"
        Me.lblviewISRSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblviewISRSearchBy.TabIndex = 54
        Me.lblviewISRSearchBy.Text = "Search By"
        '
        'dtpviewCRDate
        '
        Me.dtpviewCRDate.Enabled = False
        Me.dtpviewCRDate.Location = New System.Drawing.Point(74, 83)
        Me.dtpviewCRDate.Name = "dtpviewCRDate"
        Me.dtpviewCRDate.Size = New System.Drawing.Size(165, 21)
        Me.dtpviewCRDate.TabIndex = 13
        '
        'lblviewReferenceno
        '
        Me.lblviewReferenceno.AutoSize = True
        Me.lblviewReferenceno.ForeColor = System.Drawing.Color.Black
        Me.lblviewReferenceno.Location = New System.Drawing.Point(239, 64)
        Me.lblviewReferenceno.Name = "lblviewReferenceno"
        Me.lblviewReferenceno.Size = New System.Drawing.Size(84, 13)
        Me.lblviewReferenceno.TabIndex = 17
        Me.lblviewReferenceno.Text = "Reference No"
        '
        'txtviewCRNo
        '
        Me.txtviewCRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewCRNo.Location = New System.Drawing.Point(242, 83)
        Me.txtviewCRNo.MaxLength = 50
        Me.txtviewCRNo.Name = "txtviewCRNo"
        Me.txtviewCRNo.Size = New System.Drawing.Size(165, 21)
        Me.txtviewCRNo.TabIndex = 14
        '
        'btnviewCRReport
        '
        Me.btnviewCRReport.BackgroundImage = CType(resources.GetObject("btnviewCRReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewCRReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewCRReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewCRReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewCRReport.Image = CType(resources.GetObject("btnviewCRReport.Image"), System.Drawing.Image)
        Me.btnviewCRReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewCRReport.Location = New System.Drawing.Point(870, 83)
        Me.btnviewCRReport.Name = "btnviewCRReport"
        Me.btnviewCRReport.Size = New System.Drawing.Size(126, 25)
        Me.btnviewCRReport.TabIndex = 17
        Me.btnviewCRReport.Text = "View Report"
        Me.btnviewCRReport.UseVisualStyleBackColor = True
        Me.btnviewCRReport.Visible = False
        '
        'btnviewCRSearch
        '
        Me.btnviewCRSearch.BackgroundImage = CType(resources.GetObject("btnviewCRSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnviewCRSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewCRSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewCRSearch.ForeColor = System.Drawing.Color.Black
        Me.btnviewCRSearch.Image = CType(resources.GetObject("btnviewCRSearch.Image"), System.Drawing.Image)
        Me.btnviewCRSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewCRSearch.Location = New System.Drawing.Point(749, 83)
        Me.btnviewCRSearch.Name = "btnviewCRSearch"
        Me.btnviewCRSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnviewCRSearch.TabIndex = 17
        Me.btnviewCRSearch.Text = "Search"
        Me.btnviewCRSearch.UseVisualStyleBackColor = True
        '
        'ConsignmentReceivedFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1015, 732)
        Me.Controls.Add(Me.tcConsiognmentReceived)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ConsignmentReceivedFrm"
        Me.Text = "ConsignmentReceivedFrm"
        Me.tcConsiognmentReceived.ResumeLayout(False)
        Me.tbpgConsignmentReceived.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpApproval.ResumeLayout(False)
        Me.grpApproval.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.tbpgView.ResumeLayout(False)
        Me.plIPRView.ResumeLayout(False)
        Me.plIPRView.PerformLayout()
        CType(Me.dgvviewCReceived, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsCReceived.ResumeLayout(False)
        Me.pnlConsignmentReceived.ResumeLayout(False)
        Me.pnlConsignmentReceived.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcConsiognmentReceived As System.Windows.Forms.TabControl
    Friend WithEvents tbpgConsignmentReceived As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblConsignmentStockcodeDesc As System.Windows.Forms.Label
    Friend WithEvents btnSearchStockCode As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblReferenceNo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblConsignmentStockCode As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblReceivedQty As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtReferenceNo As System.Windows.Forms.TextBox
    Friend WithEvents txtConsignmentStockCode As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivedQty As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblReceivedDate As System.Windows.Forms.Label
    Friend WithEvents tbpgView As System.Windows.Forms.TabPage
    Friend WithEvents plIPRView As System.Windows.Forms.Panel
    Friend WithEvents dgvviewCReceived As System.Windows.Forms.DataGridView
    Friend WithEvents pnlConsignmentReceived As Stepi.UI.ExtendedPanel
    Friend WithEvents chkviewCRDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblviewISRSearchBy As System.Windows.Forms.Label
    Friend WithEvents dtpviewCRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewReferenceno As System.Windows.Forms.Label
    Friend WithEvents txtviewCRNo As System.Windows.Forms.TextBox
    Friend WithEvents btnviewCRSearch As System.Windows.Forms.Button
    Friend WithEvents lblviewStockCode As System.Windows.Forms.Label
    Friend WithEvents txtviewStockCode As System.Windows.Forms.TextBox
    Friend WithEvents dtpReceivedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmsCReceived As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPartNo As System.Windows.Forms.Label
    Friend WithEvents lblStockBalance As System.Windows.Forms.Label
    Friend WithEvents lblUOM As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblStockBalanceValue As System.Windows.Forms.Label
    Friend WithEvents lblUOMValue As System.Windows.Forms.Label
    Friend WithEvents lblPartNoValue As System.Windows.Forms.Label
    Friend WithEvents lblNoRecordFound As System.Windows.Forms.Label
    Friend WithEvents btnviewCRReport As System.Windows.Forms.Button
    Friend WithEvents cmbStatusSearch As System.Windows.Forms.ComboBox
    Friend WithEvents lblViewStatus As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblCRStatus As System.Windows.Forms.Label
    Friend WithEvents grpApproval As System.Windows.Forms.GroupBox
    Friend WithEvents lblRejectedColon As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnConform As System.Windows.Forms.Button
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtRejectedReason As System.Windows.Forms.TextBox
    Friend WithEvents lblRejectedReason As System.Windows.Forms.Label
    Friend WithEvents lblApprovalStatus As System.Windows.Forms.Label
    Friend WithEvents lblCRRejectedReasonColon As System.Windows.Forms.Label
    Friend WithEvents lblCRRejectedReasonValue As System.Windows.Forms.Label
    Friend WithEvents lblCRRejectedReason As System.Windows.Forms.Label
    Friend WithEvents ReceivedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STConsignmentMasterID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StConsignmentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOMID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PettyCashReceiptFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PettyCashReceiptFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panAddLedgerBatch = New System.Windows.Forms.Panel
        Me.tbPCR = New System.Windows.Forms.TabControl
        Me.tbAdd = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtReceivedFrom = New System.Windows.Forms.TextBox
        Me.lblReceivedFrom = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblRejectedReasonValue = New System.Windows.Forms.Label
        Me.lblColon = New System.Windows.Forms.Label
        Me.lblRecjectedReason = New System.Windows.Forms.Label
        Me.lblStatusValue = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.grpApproval = New System.Windows.Forms.GroupBox
        Me.txtRejectedReason = New System.Windows.Forms.TextBox
        Me.lblRejColon = New System.Windows.Forms.Label
        Me.lblRejReason = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnConform = New System.Windows.Forms.Button
        Me.cmbStatus = New System.Windows.Forms.ComboBox
        Me.lblStatusApproval = New System.Windows.Forms.Label
        Me.dtpReconDate = New System.Windows.Forms.DateTimePicker
        Me.dtpReceiptDate = New System.Windows.Forms.DateTimePicker
        Me.btnReceiptReset = New System.Windows.Forms.Button
        Me.btnReceiptClose = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.lblAmount = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnReceiptSave = New System.Windows.Forms.Button
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.txtReceiptNo = New System.Windows.Forms.TextBox
        Me.lblReconcilationDt = New System.Windows.Forms.Label
        Me.lblReceiptDesc = New System.Windows.Forms.Label
        Me.lblReceiptNumber = New System.Windows.Forms.Label
        Me.lblReceiptDt = New System.Windows.Forms.Label
        Me.tbView = New System.Windows.Forms.TabPage
        Me.plIPRView = New System.Windows.Forms.Panel
        Me.lblView = New System.Windows.Forms.Label
        Me.dgvReceiptView = New System.Windows.Forms.DataGridView
        Me.dgclReceiptID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclReceiptDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclReceivedFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclReceiptDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclReconcilationDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgPRStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsPCR = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlCategorySearch = New Stepi.UI.ExtendedPanel
        Me.lblSearchStatus = New System.Windows.Forms.Label
        Me.cmbSearchStatus = New System.Windows.Forms.ComboBox
        Me.chkReceiptdate = New System.Windows.Forms.CheckBox
        Me.lblsearchCategory = New System.Windows.Forms.Label
        Me.dtpviewReceiptDate = New System.Windows.Forms.DateTimePicker
        Me.lblviewReceiptDate = New System.Windows.Forms.Label
        Me.txtReceiptViewNo = New System.Windows.Forms.TextBox
        Me.lblviewReceiptNo = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnviewReport = New System.Windows.Forms.Button
        Me.gbLedgerBatch = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblColon4 = New System.Windows.Forms.Label
        Me.lblColon2 = New System.Windows.Forms.Label
        Me.lblColon3 = New System.Windows.Forms.Label
        Me.lblColon1 = New System.Windows.Forms.Label
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtBatchTotal = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtLedgerNumber = New System.Windows.Forms.TextBox
        Me.txtLedgerType = New System.Windows.Forms.TextBox
        Me.lblBatchTotal = New System.Windows.Forms.Label
        Me.lblDescription = New System.Windows.Forms.Label
        Me.lblReceiptNo = New System.Windows.Forms.Label
        Me.lblReceiptDate = New System.Windows.Forms.Label
        Me.panAddLedgerBatch.SuspendLayout()
        Me.tbPCR.SuspendLayout()
        Me.tbAdd.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpApproval.SuspendLayout()
        Me.tbView.SuspendLayout()
        Me.plIPRView.SuspendLayout()
        CType(Me.dgvReceiptView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPCR.SuspendLayout()
        Me.pnlCategorySearch.SuspendLayout()
        Me.gbLedgerBatch.SuspendLayout()
        Me.SuspendLayout()
        '
        'panAddLedgerBatch
        '
        Me.panAddLedgerBatch.BackColor = System.Drawing.Color.Transparent
        Me.panAddLedgerBatch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.panAddLedgerBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panAddLedgerBatch.Controls.Add(Me.tbPCR)
        Me.panAddLedgerBatch.Controls.Add(Me.gbLedgerBatch)
        Me.panAddLedgerBatch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panAddLedgerBatch.Location = New System.Drawing.Point(0, 0)
        Me.panAddLedgerBatch.Name = "panAddLedgerBatch"
        Me.panAddLedgerBatch.Size = New System.Drawing.Size(761, 479)
        Me.panAddLedgerBatch.TabIndex = 1
        '
        'tbPCR
        '
        Me.tbPCR.Controls.Add(Me.tbAdd)
        Me.tbPCR.Controls.Add(Me.tbView)
        Me.tbPCR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCR.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPCR.Location = New System.Drawing.Point(0, 0)
        Me.tbPCR.Name = "tbPCR"
        Me.tbPCR.SelectedIndex = 0
        Me.tbPCR.Size = New System.Drawing.Size(761, 479)
        Me.tbPCR.TabIndex = 201
        '
        'tbAdd
        '
        Me.tbAdd.AutoScroll = True
        Me.tbAdd.BackColor = System.Drawing.Color.Transparent
        Me.tbAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbAdd.Controls.Add(Me.GroupBox1)
        Me.tbAdd.Location = New System.Drawing.Point(4, 22)
        Me.tbAdd.Name = "tbAdd"
        Me.tbAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAdd.Size = New System.Drawing.Size(753, 453)
        Me.tbAdd.TabIndex = 0
        Me.tbAdd.Text = "Petty Cash Receipt"
        Me.tbAdd.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtReceivedFrom)
        Me.GroupBox1.Controls.Add(Me.lblReceivedFrom)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblRejectedReasonValue)
        Me.GroupBox1.Controls.Add(Me.lblColon)
        Me.GroupBox1.Controls.Add(Me.lblRecjectedReason)
        Me.GroupBox1.Controls.Add(Me.lblStatusValue)
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Controls.Add(Me.grpApproval)
        Me.GroupBox1.Controls.Add(Me.dtpReconDate)
        Me.GroupBox1.Controls.Add(Me.dtpReceiptDate)
        Me.GroupBox1.Controls.Add(Me.btnReceiptReset)
        Me.GroupBox1.Controls.Add(Me.btnReceiptClose)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Controls.Add(Me.lblAmount)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnReceiptSave)
        Me.GroupBox1.Controls.Add(Me.txtDesc)
        Me.GroupBox1.Controls.Add(Me.txtReceiptNo)
        Me.GroupBox1.Controls.Add(Me.lblReconcilationDt)
        Me.GroupBox1.Controls.Add(Me.lblReceiptDesc)
        Me.GroupBox1.Controls.Add(Me.lblReceiptNumber)
        Me.GroupBox1.Controls.Add(Me.lblReceiptDt)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(731, 427)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(177, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 263
        Me.Label7.Text = ":"
        '
        'txtReceivedFrom
        '
        Me.txtReceivedFrom.AcceptsReturn = True
        Me.txtReceivedFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceivedFrom.Location = New System.Drawing.Point(206, 102)
        Me.txtReceivedFrom.MaxLength = 300
        Me.txtReceivedFrom.Name = "txtReceivedFrom"
        Me.txtReceivedFrom.Size = New System.Drawing.Size(195, 21)
        Me.txtReceivedFrom.TabIndex = 3
        '
        'lblReceivedFrom
        '
        Me.lblReceivedFrom.AutoSize = True
        Me.lblReceivedFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceivedFrom.ForeColor = System.Drawing.Color.Red
        Me.lblReceivedFrom.Location = New System.Drawing.Point(7, 106)
        Me.lblReceivedFrom.Name = "lblReceivedFrom"
        Me.lblReceivedFrom.Size = New System.Drawing.Size(92, 13)
        Me.lblReceivedFrom.TabIndex = 261
        Me.lblReceivedFrom.Text = "Received From"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(494, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 260
        Me.Label10.Text = ":"
        '
        'lblRejectedReasonValue
        '
        Me.lblRejectedReasonValue.AutoSize = True
        Me.lblRejectedReasonValue.ForeColor = System.Drawing.Color.Blue
        Me.lblRejectedReasonValue.Location = New System.Drawing.Point(525, 66)
        Me.lblRejectedReasonValue.Name = "lblRejectedReasonValue"
        Me.lblRejectedReasonValue.Size = New System.Drawing.Size(38, 13)
        Me.lblRejectedReasonValue.TabIndex = 259
        Me.lblRejectedReasonValue.Text = "OPEN"
        Me.lblRejectedReasonValue.Visible = False
        '
        'lblColon
        '
        Me.lblColon.AutoSize = True
        Me.lblColon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon.Location = New System.Drawing.Point(496, 66)
        Me.lblColon.Name = "lblColon"
        Me.lblColon.Size = New System.Drawing.Size(11, 13)
        Me.lblColon.TabIndex = 258
        Me.lblColon.Text = ":"
        Me.lblColon.Visible = False
        '
        'lblRecjectedReason
        '
        Me.lblRecjectedReason.ForeColor = System.Drawing.Color.Black
        Me.lblRecjectedReason.Location = New System.Drawing.Point(430, 66)
        Me.lblRecjectedReason.Name = "lblRecjectedReason"
        Me.lblRecjectedReason.Size = New System.Drawing.Size(66, 37)
        Me.lblRecjectedReason.TabIndex = 257
        Me.lblRecjectedReason.Text = "Rejected Reason"
        Me.lblRecjectedReason.Visible = False
        '
        'lblStatusValue
        '
        Me.lblStatusValue.AutoSize = True
        Me.lblStatusValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusValue.ForeColor = System.Drawing.Color.Blue
        Me.lblStatusValue.Location = New System.Drawing.Point(525, 42)
        Me.lblStatusValue.Name = "lblStatusValue"
        Me.lblStatusValue.Size = New System.Drawing.Size(38, 13)
        Me.lblStatusValue.TabIndex = 256
        Me.lblStatusValue.Text = "OPEN"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(430, 42)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblStatus.TabIndex = 254
        Me.lblStatus.Text = "Status"
        '
        'grpApproval
        '
        Me.grpApproval.Controls.Add(Me.txtRejectedReason)
        Me.grpApproval.Controls.Add(Me.lblRejColon)
        Me.grpApproval.Controls.Add(Me.lblRejReason)
        Me.grpApproval.Controls.Add(Me.Label12)
        Me.grpApproval.Controls.Add(Me.btnConform)
        Me.grpApproval.Controls.Add(Me.cmbStatus)
        Me.grpApproval.Controls.Add(Me.lblStatusApproval)
        Me.grpApproval.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpApproval.Location = New System.Drawing.Point(409, 136)
        Me.grpApproval.Name = "grpApproval"
        Me.grpApproval.Size = New System.Drawing.Size(311, 120)
        Me.grpApproval.TabIndex = 253
        Me.grpApproval.TabStop = False
        Me.grpApproval.Text = "Petty Cash Receipt Approval"
        Me.grpApproval.Visible = False
        '
        'txtRejectedReason
        '
        Me.txtRejectedReason.AcceptsReturn = True
        Me.txtRejectedReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRejectedReason.Location = New System.Drawing.Point(105, 63)
        Me.txtRejectedReason.Multiline = True
        Me.txtRejectedReason.Name = "txtRejectedReason"
        Me.txtRejectedReason.Size = New System.Drawing.Size(195, 51)
        Me.txtRejectedReason.TabIndex = 257
        '
        'lblRejColon
        '
        Me.lblRejColon.AutoSize = True
        Me.lblRejColon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejColon.Location = New System.Drawing.Point(85, 70)
        Me.lblRejColon.Name = "lblRejColon"
        Me.lblRejColon.Size = New System.Drawing.Size(11, 13)
        Me.lblRejColon.TabIndex = 256
        Me.lblRejColon.Text = ":"
        '
        'lblRejReason
        '
        Me.lblRejReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejReason.ForeColor = System.Drawing.Color.Black
        Me.lblRejReason.Location = New System.Drawing.Point(7, 66)
        Me.lblRejReason.Name = "lblRejReason"
        Me.lblRejReason.Size = New System.Drawing.Size(76, 36)
        Me.lblRejReason.TabIndex = 255
        Me.lblRejReason.Text = "Rejected Reason"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(85, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 13)
        Me.Label12.TabIndex = 144
        Me.Label12.Text = ":"
        '
        'btnConform
        '
        Me.btnConform.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnConform.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConform.Image = CType(resources.GetObject("btnConform.Image"), System.Drawing.Image)
        Me.btnConform.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConform.Location = New System.Drawing.Point(171, 29)
        Me.btnConform.Name = "btnConform"
        Me.btnConform.Size = New System.Drawing.Size(133, 25)
        Me.btnConform.TabIndex = 202
        Me.btnConform.Text = "Confirm"
        Me.btnConform.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"APPROVED", "REJECTED"})
        Me.cmbStatus.Location = New System.Drawing.Point(7, 31)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(157, 21)
        Me.cmbStatus.TabIndex = 200
        '
        'lblStatusApproval
        '
        Me.lblStatusApproval.AutoSize = True
        Me.lblStatusApproval.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusApproval.ForeColor = System.Drawing.Color.Black
        Me.lblStatusApproval.Location = New System.Drawing.Point(7, 15)
        Me.lblStatusApproval.Name = "lblStatusApproval"
        Me.lblStatusApproval.Size = New System.Drawing.Size(43, 13)
        Me.lblStatusApproval.TabIndex = 142
        Me.lblStatusApproval.Text = "Status"
        '
        'dtpReconDate
        '
        Me.dtpReconDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpReconDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReconDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReconDate.Location = New System.Drawing.Point(209, 198)
        Me.dtpReconDate.Name = "dtpReconDate"
        Me.dtpReconDate.Size = New System.Drawing.Size(193, 21)
        Me.dtpReconDate.TabIndex = 5
        Me.dtpReconDate.Value = New Date(2009, 11, 3, 0, 0, 0, 0)
        '
        'dtpReceiptDate
        '
        Me.dtpReceiptDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpReceiptDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReceiptDate.Location = New System.Drawing.Point(207, 37)
        Me.dtpReceiptDate.Name = "dtpReceiptDate"
        Me.dtpReceiptDate.Size = New System.Drawing.Size(194, 21)
        Me.dtpReceiptDate.TabIndex = 1
        Me.dtpReceiptDate.Value = New Date(2009, 11, 3, 0, 0, 0, 0)
        '
        'btnReceiptReset
        '
        Me.btnReceiptReset.BackgroundImage = CType(resources.GetObject("btnReceiptReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReceiptReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReceiptReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiptReset.Image = CType(resources.GetObject("btnReceiptReset.Image"), System.Drawing.Image)
        Me.btnReceiptReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReceiptReset.Location = New System.Drawing.Point(434, 282)
        Me.btnReceiptReset.Name = "btnReceiptReset"
        Me.btnReceiptReset.Size = New System.Drawing.Size(111, 25)
        Me.btnReceiptReset.TabIndex = 8
        Me.btnReceiptReset.Text = "Reset"
        Me.btnReceiptReset.UseVisualStyleBackColor = True
        '
        'btnReceiptClose
        '
        Me.btnReceiptClose.BackgroundImage = CType(resources.GetObject("btnReceiptClose.BackgroundImage"), System.Drawing.Image)
        Me.btnReceiptClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReceiptClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiptClose.Image = CType(resources.GetObject("btnReceiptClose.Image"), System.Drawing.Image)
        Me.btnReceiptClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReceiptClose.Location = New System.Drawing.Point(548, 282)
        Me.btnReceiptClose.Name = "btnReceiptClose"
        Me.btnReceiptClose.Size = New System.Drawing.Size(111, 25)
        Me.btnReceiptClose.TabIndex = 9
        Me.btnReceiptClose.Text = "Close"
        Me.btnReceiptClose.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(178, 237)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 140
        Me.Label9.Text = ":"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(206, 235)
        Me.txtAmount.MaxLength = 18
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(195, 21)
        Me.txtAmount.TabIndex = 6
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Red
        Me.lblAmount.Location = New System.Drawing.Point(7, 238)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(51, 13)
        Me.lblAmount.TabIndex = 138
        Me.lblAmount.Text = "Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(177, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 137
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(177, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 136
        Me.Label4.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(177, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 135
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(178, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = ":"
        '
        'btnReceiptSave
        '
        Me.btnReceiptSave.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnReceiptSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReceiptSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiptSave.Image = Global.BSP.My.Resources.Resources.user_add1
        Me.btnReceiptSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReceiptSave.Location = New System.Drawing.Point(325, 282)
        Me.btnReceiptSave.Name = "btnReceiptSave"
        Me.btnReceiptSave.Size = New System.Drawing.Size(101, 25)
        Me.btnReceiptSave.TabIndex = 7
        Me.btnReceiptSave.Text = "Save"
        Me.btnReceiptSave.UseVisualStyleBackColor = True
        '
        'txtDesc
        '
        Me.txtDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(206, 136)
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(195, 50)
        Me.txtDesc.TabIndex = 4
        '
        'txtReceiptNo
        '
        Me.txtReceiptNo.AcceptsReturn = True
        Me.txtReceiptNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiptNo.Location = New System.Drawing.Point(206, 73)
        Me.txtReceiptNo.Name = "txtReceiptNo"
        Me.txtReceiptNo.Size = New System.Drawing.Size(195, 21)
        Me.txtReceiptNo.TabIndex = 2
        '
        'lblReconcilationDt
        '
        Me.lblReconcilationDt.AutoSize = True
        Me.lblReconcilationDt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReconcilationDt.ForeColor = System.Drawing.Color.Red
        Me.lblReconcilationDt.Location = New System.Drawing.Point(3, 202)
        Me.lblReconcilationDt.Name = "lblReconcilationDt"
        Me.lblReconcilationDt.Size = New System.Drawing.Size(179, 13)
        Me.lblReconcilationDt.TabIndex = 3
        Me.lblReconcilationDt.Text = "Cash Reconcilation Form Date"
        '
        'lblReceiptDesc
        '
        Me.lblReceiptDesc.AutoSize = True
        Me.lblReceiptDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptDesc.ForeColor = System.Drawing.Color.Red
        Me.lblReceiptDesc.Location = New System.Drawing.Point(7, 139)
        Me.lblReceiptDesc.Name = "lblReceiptDesc"
        Me.lblReceiptDesc.Size = New System.Drawing.Size(71, 13)
        Me.lblReceiptDesc.TabIndex = 2
        Me.lblReceiptDesc.Text = "Description"
        '
        'lblReceiptNumber
        '
        Me.lblReceiptNumber.AutoSize = True
        Me.lblReceiptNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptNumber.ForeColor = System.Drawing.Color.Red
        Me.lblReceiptNumber.Location = New System.Drawing.Point(7, 76)
        Me.lblReceiptNumber.Name = "lblReceiptNumber"
        Me.lblReceiptNumber.Size = New System.Drawing.Size(98, 13)
        Me.lblReceiptNumber.TabIndex = 1
        Me.lblReceiptNumber.Text = "Receipt Number"
        '
        'lblReceiptDt
        '
        Me.lblReceiptDt.AutoSize = True
        Me.lblReceiptDt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptDt.ForeColor = System.Drawing.Color.Red
        Me.lblReceiptDt.Location = New System.Drawing.Point(7, 42)
        Me.lblReceiptDt.Name = "lblReceiptDt"
        Me.lblReceiptDt.Size = New System.Drawing.Size(80, 13)
        Me.lblReceiptDt.TabIndex = 0
        Me.lblReceiptDt.Text = "Receipt Date"
        '
        'tbView
        '
        Me.tbView.AutoScroll = True
        Me.tbView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbView.Controls.Add(Me.plIPRView)
        Me.tbView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbView.Location = New System.Drawing.Point(4, 22)
        Me.tbView.Name = "tbView"
        Me.tbView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbView.Size = New System.Drawing.Size(753, 453)
        Me.tbView.TabIndex = 1
        Me.tbView.Text = "View"
        Me.tbView.UseVisualStyleBackColor = True
        '
        'plIPRView
        '
        Me.plIPRView.Controls.Add(Me.lblView)
        Me.plIPRView.Controls.Add(Me.dgvReceiptView)
        Me.plIPRView.Controls.Add(Me.pnlCategorySearch)
        Me.plIPRView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plIPRView.Location = New System.Drawing.Point(3, 3)
        Me.plIPRView.Name = "plIPRView"
        Me.plIPRView.Size = New System.Drawing.Size(747, 447)
        Me.plIPRView.TabIndex = 45
        '
        'lblView
        '
        Me.lblView.AutoSize = True
        Me.lblView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblView.ForeColor = System.Drawing.Color.Red
        Me.lblView.Location = New System.Drawing.Point(188, 235)
        Me.lblView.Name = "lblView"
        Me.lblView.Size = New System.Drawing.Size(130, 13)
        Me.lblView.TabIndex = 118
        Me.lblView.Text = "Record not found !!"
        Me.lblView.Visible = False
        '
        'dgvReceiptView
        '
        Me.dgvReceiptView.AllowUserToAddRows = False
        Me.dgvReceiptView.AllowUserToDeleteRows = False
        Me.dgvReceiptView.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvReceiptView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReceiptView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvReceiptView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvReceiptView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvReceiptView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReceiptView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReceiptView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReceiptView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclReceiptID, Me.dgclReceiptDate, Me.dgclReceiptNo, Me.dgclReceivedFrom, Me.dgclReceiptDesc, Me.dgclReconcilationDate, Me.dgclAmount, Me.dgclRejectedReason, Me.dgPRStatus})
        Me.dgvReceiptView.ContextMenuStrip = Me.cmsPCR
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReceiptView.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvReceiptView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReceiptView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvReceiptView.EnableHeadersVisualStyles = False
        Me.dgvReceiptView.GridColor = System.Drawing.Color.Gray
        Me.dgvReceiptView.Location = New System.Drawing.Point(0, 142)
        Me.dgvReceiptView.Name = "dgvReceiptView"
        Me.dgvReceiptView.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReceiptView.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvReceiptView.RowHeadersVisible = False
        Me.dgvReceiptView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvReceiptView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReceiptView.ShowCellErrors = False
        Me.dgvReceiptView.Size = New System.Drawing.Size(747, 305)
        Me.dgvReceiptView.TabIndex = 57
        '
        'dgclReceiptID
        '
        Me.dgclReceiptID.DataPropertyName = "ReceiptID"
        Me.dgclReceiptID.HeaderText = "ReceiptID"
        Me.dgclReceiptID.Name = "dgclReceiptID"
        Me.dgclReceiptID.ReadOnly = True
        Me.dgclReceiptID.Visible = False
        Me.dgclReceiptID.Width = 87
        '
        'dgclReceiptDate
        '
        Me.dgclReceiptDate.DataPropertyName = "ReceiptDate"
        Me.dgclReceiptDate.HeaderText = "Receipt Date"
        Me.dgclReceiptDate.Name = "dgclReceiptDate"
        Me.dgclReceiptDate.ReadOnly = True
        Me.dgclReceiptDate.Width = 104
        '
        'dgclReceiptNo
        '
        Me.dgclReceiptNo.DataPropertyName = "ReceiptNo"
        Me.dgclReceiptNo.HeaderText = "Receipt No"
        Me.dgclReceiptNo.Name = "dgclReceiptNo"
        Me.dgclReceiptNo.ReadOnly = True
        Me.dgclReceiptNo.Width = 92
        '
        'dgclReceivedFrom
        '
        Me.dgclReceivedFrom.DataPropertyName = "ReceivedFrom"
        Me.dgclReceivedFrom.HeaderText = "Received From"
        Me.dgclReceivedFrom.Name = "dgclReceivedFrom"
        Me.dgclReceivedFrom.ReadOnly = True
        Me.dgclReceivedFrom.Width = 116
        '
        'dgclReceiptDesc
        '
        Me.dgclReceiptDesc.DataPropertyName = "ReceiptDescp"
        Me.dgclReceiptDesc.HeaderText = "Receipt Desc"
        Me.dgclReceiptDesc.Name = "dgclReceiptDesc"
        Me.dgclReceiptDesc.ReadOnly = True
        Me.dgclReceiptDesc.Visible = False
        Me.dgclReceiptDesc.Width = 105
        '
        'dgclReconcilationDate
        '
        Me.dgclReconcilationDate.DataPropertyName = "CashReconcilationDate"
        Me.dgclReconcilationDate.HeaderText = "Cash Reconcilation Form Date"
        Me.dgclReconcilationDate.Name = "dgclReconcilationDate"
        Me.dgclReconcilationDate.ReadOnly = True
        Me.dgclReconcilationDate.Width = 203
        '
        'dgclAmount
        '
        Me.dgclAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgclAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgclAmount.HeaderText = "Amount"
        Me.dgclAmount.Name = "dgclAmount"
        Me.dgclAmount.ReadOnly = True
        Me.dgclAmount.Width = 75
        '
        'dgclRejectedReason
        '
        Me.dgclRejectedReason.DataPropertyName = "RejectedReason"
        Me.dgclRejectedReason.HeaderText = "RejectedReason"
        Me.dgclRejectedReason.Name = "dgclRejectedReason"
        Me.dgclRejectedReason.ReadOnly = True
        Me.dgclRejectedReason.Visible = False
        Me.dgclRejectedReason.Width = 123
        '
        'dgPRStatus
        '
        Me.dgPRStatus.DataPropertyName = "Approved"
        Me.dgPRStatus.HeaderText = "Status"
        Me.dgPRStatus.Name = "dgPRStatus"
        Me.dgPRStatus.ReadOnly = True
        Me.dgPRStatus.Width = 67
        '
        'cmsPCR
        '
        Me.cmsPCR.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsPCR.Name = "cmsIPR"
        Me.cmsPCR.Size = New System.Drawing.Size(117, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
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
        Me.pnlCategorySearch.CaptionText = "Search Petty Cash Receipt"
        Me.pnlCategorySearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Controls.Add(Me.lblSearchStatus)
        Me.pnlCategorySearch.Controls.Add(Me.cmbSearchStatus)
        Me.pnlCategorySearch.Controls.Add(Me.chkReceiptdate)
        Me.pnlCategorySearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlCategorySearch.Controls.Add(Me.dtpviewReceiptDate)
        Me.pnlCategorySearch.Controls.Add(Me.lblviewReceiptDate)
        Me.pnlCategorySearch.Controls.Add(Me.txtReceiptViewNo)
        Me.pnlCategorySearch.Controls.Add(Me.lblviewReceiptNo)
        Me.pnlCategorySearch.Controls.Add(Me.btnSearch)
        Me.pnlCategorySearch.Controls.Add(Me.btnviewReport)
        Me.pnlCategorySearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlCategorySearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlCategorySearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlCategorySearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCategorySearch.ForeColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategorySearch.Name = "pnlCategorySearch"
        Me.pnlCategorySearch.Size = New System.Drawing.Size(747, 142)
        Me.pnlCategorySearch.TabIndex = 116
        '
        'lblSearchStatus
        '
        Me.lblSearchStatus.AutoSize = True
        Me.lblSearchStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSearchStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSearchStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchStatus.Location = New System.Drawing.Point(381, 64)
        Me.lblSearchStatus.Name = "lblSearchStatus"
        Me.lblSearchStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblSearchStatus.TabIndex = 221
        Me.lblSearchStatus.Text = "Status"
        '
        'cmbSearchStatus
        '
        Me.cmbSearchStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchStatus.FormattingEnabled = True
        Me.cmbSearchStatus.Items.AddRange(New Object() {"Select All", "OPEN", "APPROVED"})
        Me.cmbSearchStatus.Location = New System.Drawing.Point(385, 87)
        Me.cmbSearchStatus.Name = "cmbSearchStatus"
        Me.cmbSearchStatus.Size = New System.Drawing.Size(163, 21)
        Me.cmbSearchStatus.TabIndex = 54
        '
        'chkReceiptdate
        '
        Me.chkReceiptdate.AutoSize = True
        Me.chkReceiptdate.Location = New System.Drawing.Point(38, 64)
        Me.chkReceiptdate.Name = "chkReceiptdate"
        Me.chkReceiptdate.Size = New System.Drawing.Size(15, 14)
        Me.chkReceiptdate.TabIndex = 51
        Me.chkReceiptdate.UseVisualStyleBackColor = True
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
        'dtpviewReceiptDate
        '
        Me.dtpviewReceiptDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpviewReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpviewReceiptDate.Location = New System.Drawing.Point(38, 87)
        Me.dtpviewReceiptDate.Name = "dtpviewReceiptDate"
        Me.dtpviewReceiptDate.Size = New System.Drawing.Size(163, 21)
        Me.dtpviewReceiptDate.TabIndex = 52
        Me.dtpviewReceiptDate.Value = New Date(2009, 11, 3, 0, 0, 0, 0)
        '
        'lblviewReceiptDate
        '
        Me.lblviewReceiptDate.AutoSize = True
        Me.lblviewReceiptDate.ForeColor = System.Drawing.Color.Black
        Me.lblviewReceiptDate.Location = New System.Drawing.Point(57, 64)
        Me.lblviewReceiptDate.Name = "lblviewReceiptDate"
        Me.lblviewReceiptDate.Size = New System.Drawing.Size(80, 13)
        Me.lblviewReceiptDate.TabIndex = 51
        Me.lblviewReceiptDate.Text = "Receipt Date"
        '
        'txtReceiptViewNo
        '
        Me.txtReceiptViewNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceiptViewNo.Location = New System.Drawing.Point(212, 87)
        Me.txtReceiptViewNo.MaxLength = 50
        Me.txtReceiptViewNo.Name = "txtReceiptViewNo"
        Me.txtReceiptViewNo.Size = New System.Drawing.Size(163, 21)
        Me.txtReceiptViewNo.TabIndex = 53
        '
        'lblviewReceiptNo
        '
        Me.lblviewReceiptNo.AutoSize = True
        Me.lblviewReceiptNo.ForeColor = System.Drawing.Color.Black
        Me.lblviewReceiptNo.Location = New System.Drawing.Point(209, 64)
        Me.lblviewReceiptNo.Name = "lblviewReceiptNo"
        Me.lblviewReceiptNo.Size = New System.Drawing.Size(72, 13)
        Me.lblviewReceiptNo.TabIndex = 17
        Me.lblviewReceiptNo.Text = "Receipt No."
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(554, 85)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(128, 25)
        Me.btnSearch.TabIndex = 55
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(689, 85)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(140, 25)
        Me.btnviewReport.TabIndex = 56
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'gbLedgerBatch
        '
        Me.gbLedgerBatch.Controls.Add(Me.Label1)
        Me.gbLedgerBatch.Controls.Add(Me.TextBox1)
        Me.gbLedgerBatch.Controls.Add(Me.Label2)
        Me.gbLedgerBatch.Controls.Add(Me.lblColon4)
        Me.gbLedgerBatch.Controls.Add(Me.lblColon2)
        Me.gbLedgerBatch.Controls.Add(Me.lblColon3)
        Me.gbLedgerBatch.Controls.Add(Me.lblColon1)
        Me.gbLedgerBatch.Controls.Add(Me.btnReset)
        Me.gbLedgerBatch.Controls.Add(Me.btnClose)
        Me.gbLedgerBatch.Controls.Add(Me.btnSave)
        Me.gbLedgerBatch.Controls.Add(Me.txtBatchTotal)
        Me.gbLedgerBatch.Controls.Add(Me.txtDescription)
        Me.gbLedgerBatch.Controls.Add(Me.txtLedgerNumber)
        Me.gbLedgerBatch.Controls.Add(Me.txtLedgerType)
        Me.gbLedgerBatch.Controls.Add(Me.lblBatchTotal)
        Me.gbLedgerBatch.Controls.Add(Me.lblDescription)
        Me.gbLedgerBatch.Controls.Add(Me.lblReceiptNo)
        Me.gbLedgerBatch.Controls.Add(Me.lblReceiptDate)
        Me.gbLedgerBatch.Location = New System.Drawing.Point(491, 472)
        Me.gbLedgerBatch.Name = "gbLedgerBatch"
        Me.gbLedgerBatch.Size = New System.Drawing.Size(642, 321)
        Me.gbLedgerBatch.TabIndex = 0
        Me.gbLedgerBatch.TabStop = False
        Me.gbLedgerBatch.Text = "Petty Cash Receipt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(209, 212)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = ":"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(239, 209)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(195, 21)
        Me.TextBox1.TabIndex = 139
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(34, 213)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "Amount"
        '
        'lblColon4
        '
        Me.lblColon4.AutoSize = True
        Me.lblColon4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon4.Location = New System.Drawing.Point(208, 171)
        Me.lblColon4.Name = "lblColon4"
        Me.lblColon4.Size = New System.Drawing.Size(15, 13)
        Me.lblColon4.TabIndex = 137
        Me.lblColon4.Text = ": "
        '
        'lblColon2
        '
        Me.lblColon2.AutoSize = True
        Me.lblColon2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon2.Location = New System.Drawing.Point(205, 75)
        Me.lblColon2.Name = "lblColon2"
        Me.lblColon2.Size = New System.Drawing.Size(11, 13)
        Me.lblColon2.TabIndex = 136
        Me.lblColon2.Text = ":"
        '
        'lblColon3
        '
        Me.lblColon3.AutoSize = True
        Me.lblColon3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon3.Location = New System.Drawing.Point(205, 109)
        Me.lblColon3.Name = "lblColon3"
        Me.lblColon3.Size = New System.Drawing.Size(11, 13)
        Me.lblColon3.TabIndex = 135
        Me.lblColon3.Text = ":"
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(205, 42)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(11, 13)
        Me.lblColon1.TabIndex = 132
        Me.lblColon1.Text = ":"
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(273, 277)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(101, 25)
        Me.btnReset.TabIndex = 6
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(152, 277)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(101, 25)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.BSP.My.Resources.Resources.user_add1
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(30, 277)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(101, 25)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtBatchTotal
        '
        Me.txtBatchTotal.Location = New System.Drawing.Point(237, 168)
        Me.txtBatchTotal.Multiline = True
        Me.txtBatchTotal.Name = "txtBatchTotal"
        Me.txtBatchTotal.Size = New System.Drawing.Size(195, 20)
        Me.txtBatchTotal.TabIndex = 3
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(236, 105)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(195, 50)
        Me.txtDescription.TabIndex = 2
        '
        'txtLedgerNumber
        '
        Me.txtLedgerNumber.Location = New System.Drawing.Point(236, 72)
        Me.txtLedgerNumber.Name = "txtLedgerNumber"
        Me.txtLedgerNumber.Size = New System.Drawing.Size(195, 21)
        Me.txtLedgerNumber.TabIndex = 1
        '
        'txtLedgerType
        '
        Me.txtLedgerType.Enabled = False
        Me.txtLedgerType.Location = New System.Drawing.Point(236, 38)
        Me.txtLedgerType.Name = "txtLedgerType"
        Me.txtLedgerType.Size = New System.Drawing.Size(195, 21)
        Me.txtLedgerType.TabIndex = 0
        '
        'lblBatchTotal
        '
        Me.lblBatchTotal.AutoSize = True
        Me.lblBatchTotal.ForeColor = System.Drawing.Color.Red
        Me.lblBatchTotal.Location = New System.Drawing.Point(30, 172)
        Me.lblBatchTotal.Name = "lblBatchTotal"
        Me.lblBatchTotal.Size = New System.Drawing.Size(179, 13)
        Me.lblBatchTotal.TabIndex = 3
        Me.lblBatchTotal.Text = "Cash Reconcilation Form Date"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.ForeColor = System.Drawing.Color.Red
        Me.lblDescription.Location = New System.Drawing.Point(30, 109)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(71, 13)
        Me.lblDescription.TabIndex = 2
        Me.lblDescription.Text = "Description"
        '
        'lblReceiptNo
        '
        Me.lblReceiptNo.AutoSize = True
        Me.lblReceiptNo.ForeColor = System.Drawing.Color.Red
        Me.lblReceiptNo.Location = New System.Drawing.Point(30, 76)
        Me.lblReceiptNo.Name = "lblReceiptNo"
        Me.lblReceiptNo.Size = New System.Drawing.Size(98, 13)
        Me.lblReceiptNo.TabIndex = 1
        Me.lblReceiptNo.Text = "Receipt Number"
        '
        'lblReceiptDate
        '
        Me.lblReceiptDate.AutoSize = True
        Me.lblReceiptDate.ForeColor = System.Drawing.Color.Red
        Me.lblReceiptDate.Location = New System.Drawing.Point(30, 42)
        Me.lblReceiptDate.Name = "lblReceiptDate"
        Me.lblReceiptDate.Size = New System.Drawing.Size(80, 13)
        Me.lblReceiptDate.TabIndex = 0
        Me.lblReceiptDate.Text = "Receipt Date"
        '
        'PettyCashReceiptFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 479)
        Me.Controls.Add(Me.panAddLedgerBatch)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "PettyCashReceiptFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PettyCashReceiptFrm"
        Me.panAddLedgerBatch.ResumeLayout(False)
        Me.tbPCR.ResumeLayout(False)
        Me.tbAdd.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpApproval.ResumeLayout(False)
        Me.grpApproval.PerformLayout()
        Me.tbView.ResumeLayout(False)
        Me.plIPRView.ResumeLayout(False)
        Me.plIPRView.PerformLayout()
        CType(Me.dgvReceiptView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPCR.ResumeLayout(False)
        Me.pnlCategorySearch.ResumeLayout(False)
        Me.pnlCategorySearch.PerformLayout()
        Me.gbLedgerBatch.ResumeLayout(False)
        Me.gbLedgerBatch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblColon2 As System.Windows.Forms.Label
    Friend WithEvents lblColon3 As System.Windows.Forms.Label
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents panAddLedgerBatch As System.Windows.Forms.Panel
    Friend WithEvents gbLedgerBatch As System.Windows.Forms.GroupBox
    Friend WithEvents lblColon4 As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtBatchTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtLedgerNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtLedgerType As System.Windows.Forms.TextBox
    Friend WithEvents lblBatchTotal As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblReceiptNo As System.Windows.Forms.Label
    Friend WithEvents lblReceiptDate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbPCR As System.Windows.Forms.TabControl
    Friend WithEvents tbAdd As System.Windows.Forms.TabPage
    Friend WithEvents tbView As System.Windows.Forms.TabPage
    Friend WithEvents plIPRView As System.Windows.Forms.Panel
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents dgvReceiptView As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCategorySearch As Stepi.UI.ExtendedPanel
    Friend WithEvents chkReceiptdate As System.Windows.Forms.CheckBox
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents dtpviewReceiptDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewReceiptDate As System.Windows.Forms.Label
    Friend WithEvents lblviewReceiptNo As System.Windows.Forms.Label
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents txtReceiptViewNo As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnReceiptSave As System.Windows.Forms.Button
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtReceiptNo As System.Windows.Forms.TextBox
    Friend WithEvents lblReconcilationDt As System.Windows.Forms.Label
    Friend WithEvents lblReceiptDesc As System.Windows.Forms.Label
    Friend WithEvents lblReceiptNumber As System.Windows.Forms.Label
    Friend WithEvents lblReceiptDt As System.Windows.Forms.Label
    Friend WithEvents btnReceiptClose As System.Windows.Forms.Button
    Friend WithEvents btnReceiptReset As System.Windows.Forms.Button
    Friend WithEvents dtpReceiptDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReconDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmsPCR As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpApproval As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnConform As System.Windows.Forms.Button
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatusApproval As System.Windows.Forms.Label
    Friend WithEvents lblSearchStatus As System.Windows.Forms.Label
    Friend WithEvents cmbSearchStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatusValue As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtRejectedReason As System.Windows.Forms.TextBox
    Friend WithEvents lblRejColon As System.Windows.Forms.Label
    Friend WithEvents lblRejReason As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblRejectedReasonValue As System.Windows.Forms.Label
    Friend WithEvents lblColon As System.Windows.Forms.Label
    Friend WithEvents lblRecjectedReason As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtReceivedFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblReceivedFrom As System.Windows.Forms.Label
    Friend WithEvents dgclReceiptID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceiptDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceivedFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReceiptDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclReconcilationDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPRStatus As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StandardPinkSlipFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StandardPinkSlipFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tbBudgetPinkSlip = New System.Windows.Forms.TabControl
        Me.tbPinkSlip = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSaveAll = New System.Windows.Forms.Button
        Me.btnResetAll = New System.Windows.Forms.Button
        Me.grpCentralInformation = New System.Windows.Forms.GroupBox
        Me.cmbApprovalStatus = New System.Windows.Forms.ComboBox
        Me.lblApprovalStatus = New System.Windows.Forms.Label
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.txtRejectedReason = New System.Windows.Forms.TextBox
        Me.lblRejectedReason = New System.Windows.Forms.Label
        Me.txtApprovedAmount = New System.Windows.Forms.TextBox
        Me.btnResetGeneral = New System.Windows.Forms.Button
        Me.lblApprovedAmountL = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblStatusL = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblActualToDate = New System.Windows.Forms.Label
        Me.lblBudgetAmount = New System.Windows.Forms.Label
        Me.lblActualToDateL = New System.Windows.Forms.Label
        Me.lblBudgetAmountL = New System.Windows.Forms.Label
        Me.lblOldCOACode = New System.Windows.Forms.Label
        Me.lblCOADescp = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnSearchAccountCode = New System.Windows.Forms.Button
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.txtRequestAmount = New System.Windows.Forms.TextBox
        Me.txtCOACode = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblReasonL = New System.Windows.Forms.Label
        Me.lblRequestAmountL = New System.Windows.Forms.Label
        Me.lblAccountcodeL = New System.Windows.Forms.Label
        Me.grpPinkSlipGrid = New System.Windows.Forms.GroupBox
        Me.dgPinkSlip = New System.Windows.Forms.DataGridView
        Me.PinkSlipId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkSlipDetailId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RefNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateRequest = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COACode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COADescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RequestedAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActualToDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApprovedAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reason = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsPinkSlip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.grpPinkSlip = New System.Windows.Forms.GroupBox
        Me.dtpDateRequest = New System.Windows.Forms.DateTimePicker
        Me.lblRefNo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblDateRequestL = New System.Windows.Forms.Label
        Me.lblPinkSlipRefNoL = New System.Windows.Forms.Label
        Me.tbView = New System.Windows.Forms.TabPage
        Me.pnlPinkSlipSearch = New Stepi.UI.ExtendedPanel
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnviewReport = New System.Windows.Forms.Button
        Me.cmbStatus = New System.Windows.Forms.ComboBox
        Me.lblStatusView = New System.Windows.Forms.Label
        Me.lblsearchCategory = New System.Windows.Forms.Label
        Me.txtPinkSlipNoView = New System.Windows.Forms.TextBox
        Me.lblPinkSlipNoView = New System.Windows.Forms.Label
        Me.chkDateRequest = New System.Windows.Forms.CheckBox
        Me.dtpDateRequestView = New System.Windows.Forms.DateTimePicker
        Me.dgPinkSlipView = New System.Windows.Forms.DataGridView
        Me.StatusView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApprovedAmtView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReasonView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RequestedAmtView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActualToDateView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RejectedReasonView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetAmountView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COADescpView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COACodeView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateRequestView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RefNoView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkSlipDetailIdView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkSlipIdView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.tbBudgetPinkSlip.SuspendLayout()
        Me.tbPinkSlip.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpCentralInformation.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpPinkSlipGrid.SuspendLayout()
        CType(Me.dgPinkSlip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPinkSlip.SuspendLayout()
        Me.grpPinkSlip.SuspendLayout()
        Me.tbView.SuspendLayout()
        Me.pnlPinkSlipSearch.SuspendLayout()
        CType(Me.dgPinkSlipView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbBudgetPinkSlip
        '
        Me.tbBudgetPinkSlip.Controls.Add(Me.tbPinkSlip)
        Me.tbBudgetPinkSlip.Controls.Add(Me.tbView)
        Me.tbBudgetPinkSlip.Location = New System.Drawing.Point(12, 4)
        Me.tbBudgetPinkSlip.Name = "tbBudgetPinkSlip"
        Me.tbBudgetPinkSlip.SelectedIndex = 0
        Me.tbBudgetPinkSlip.Size = New System.Drawing.Size(940, 514)
        Me.tbBudgetPinkSlip.TabIndex = 10
        '
        'tbPinkSlip
        '
        Me.tbPinkSlip.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbPinkSlip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbPinkSlip.Controls.Add(Me.GroupBox2)
        Me.tbPinkSlip.Controls.Add(Me.grpCentralInformation)
        Me.tbPinkSlip.Controls.Add(Me.txtApprovedAmount)
        Me.tbPinkSlip.Controls.Add(Me.btnResetGeneral)
        Me.tbPinkSlip.Controls.Add(Me.lblApprovedAmountL)
        Me.tbPinkSlip.Controls.Add(Me.btnAdd)
        Me.tbPinkSlip.Controls.Add(Me.GroupBox1)
        Me.tbPinkSlip.Controls.Add(Me.grpPinkSlipGrid)
        Me.tbPinkSlip.Controls.Add(Me.grpPinkSlip)
        Me.tbPinkSlip.Location = New System.Drawing.Point(4, 22)
        Me.tbPinkSlip.Name = "tbPinkSlip"
        Me.tbPinkSlip.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPinkSlip.Size = New System.Drawing.Size(932, 488)
        Me.tbPinkSlip.TabIndex = 0
        Me.tbPinkSlip.Text = "Pink Slip"
        Me.tbPinkSlip.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnClose)
        Me.GroupBox2.Controls.Add(Me.btnSaveAll)
        Me.GroupBox2.Controls.Add(Me.btnResetAll)
        Me.GroupBox2.Location = New System.Drawing.Point(553, 438)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(330, 41)
        Me.GroupBox2.TabIndex = 321
        Me.GroupBox2.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(219, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 25)
        Me.btnClose.TabIndex = 16
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = CType(resources.GetObject("btnSaveAll.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(17, 12)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(95, 25)
        Me.btnSaveAll.TabIndex = 14
        Me.btnSaveAll.Text = "Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = CType(resources.GetObject("btnResetAll.BackgroundImage"), System.Drawing.Image)
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAll.Image = CType(resources.GetObject("btnResetAll.Image"), System.Drawing.Image)
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.Location = New System.Drawing.Point(118, 12)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(95, 25)
        Me.btnResetAll.TabIndex = 15
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'grpCentralInformation
        '
        Me.grpCentralInformation.BackColor = System.Drawing.Color.Transparent
        Me.grpCentralInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.grpCentralInformation.Controls.Add(Me.cmbApprovalStatus)
        Me.grpCentralInformation.Controls.Add(Me.lblApprovalStatus)
        Me.grpCentralInformation.Controls.Add(Me.btnConfirm)
        Me.grpCentralInformation.Controls.Add(Me.txtRejectedReason)
        Me.grpCentralInformation.Controls.Add(Me.lblRejectedReason)
        Me.grpCentralInformation.Location = New System.Drawing.Point(553, 60)
        Me.grpCentralInformation.Name = "grpCentralInformation"
        Me.grpCentralInformation.Size = New System.Drawing.Size(360, 109)
        Me.grpCentralInformation.TabIndex = 320
        Me.grpCentralInformation.TabStop = False
        Me.grpCentralInformation.Text = "Central Information"
        '
        'cmbApprovalStatus
        '
        Me.cmbApprovalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbApprovalStatus.FormattingEnabled = True
        Me.cmbApprovalStatus.Items.AddRange(New Object() {"APPROVED", "REJECTED"})
        Me.cmbApprovalStatus.Location = New System.Drawing.Point(182, 15)
        Me.cmbApprovalStatus.Name = "cmbApprovalStatus"
        Me.cmbApprovalStatus.Size = New System.Drawing.Size(148, 21)
        Me.cmbApprovalStatus.TabIndex = 314
        '
        'lblApprovalStatus
        '
        Me.lblApprovalStatus.AutoSize = True
        Me.lblApprovalStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovalStatus.ForeColor = System.Drawing.Color.Black
        Me.lblApprovalStatus.Location = New System.Drawing.Point(27, 23)
        Me.lblApprovalStatus.Name = "lblApprovalStatus"
        Me.lblApprovalStatus.Size = New System.Drawing.Size(128, 13)
        Me.lblApprovalStatus.TabIndex = 316
        Me.lblApprovalStatus.Text = "Status                    :"
        '
        'btnConfirm
        '
        Me.btnConfirm.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConfirm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.Image = CType(resources.GetObject("btnConfirm.Image"), System.Drawing.Image)
        Me.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirm.Location = New System.Drawing.Point(183, 75)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(111, 28)
        Me.btnConfirm.TabIndex = 184
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'txtRejectedReason
        '
        Me.txtRejectedReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRejectedReason.Location = New System.Drawing.Point(183, 48)
        Me.txtRejectedReason.Name = "txtRejectedReason"
        Me.txtRejectedReason.Size = New System.Drawing.Size(116, 21)
        Me.txtRejectedReason.TabIndex = 182
        '
        'lblRejectedReason
        '
        Me.lblRejectedReason.AutoSize = True
        Me.lblRejectedReason.BackColor = System.Drawing.Color.Transparent
        Me.lblRejectedReason.ForeColor = System.Drawing.Color.Black
        Me.lblRejectedReason.Location = New System.Drawing.Point(27, 48)
        Me.lblRejectedReason.Name = "lblRejectedReason"
        Me.lblRejectedReason.Size = New System.Drawing.Size(128, 13)
        Me.lblRejectedReason.TabIndex = 183
        Me.lblRejectedReason.Text = "Rejected Reason     :"
        '
        'txtApprovedAmount
        '
        Me.txtApprovedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApprovedAmount.Location = New System.Drawing.Point(733, 196)
        Me.txtApprovedAmount.Name = "txtApprovedAmount"
        Me.txtApprovedAmount.Size = New System.Drawing.Size(116, 21)
        Me.txtApprovedAmount.TabIndex = 319
        '
        'btnResetGeneral
        '
        Me.btnResetGeneral.BackgroundImage = CType(resources.GetObject("btnResetGeneral.BackgroundImage"), System.Drawing.Image)
        Me.btnResetGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetGeneral.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetGeneral.Image = CType(resources.GetObject("btnResetGeneral.Image"), System.Drawing.Image)
        Me.btnResetGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetGeneral.Location = New System.Drawing.Point(736, 255)
        Me.btnResetGeneral.Name = "btnResetGeneral"
        Me.btnResetGeneral.Size = New System.Drawing.Size(95, 25)
        Me.btnResetGeneral.TabIndex = 149
        Me.btnResetGeneral.Text = "Reset"
        Me.btnResetGeneral.UseVisualStyleBackColor = True
        '
        'lblApprovedAmountL
        '
        Me.lblApprovedAmountL.AutoSize = True
        Me.lblApprovedAmountL.BackColor = System.Drawing.Color.Transparent
        Me.lblApprovedAmountL.ForeColor = System.Drawing.Color.Black
        Me.lblApprovedAmountL.Location = New System.Drawing.Point(572, 196)
        Me.lblApprovedAmountL.Name = "lblApprovedAmountL"
        Me.lblApprovedAmountL.Size = New System.Drawing.Size(131, 13)
        Me.lblApprovedAmountL.TabIndex = 318
        Me.lblApprovedAmountL.Text = "Approved Amount    :"
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(635, 255)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(95, 25)
        Me.btnAdd.TabIndex = 148
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblStatusL)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblActualToDate)
        Me.GroupBox1.Controls.Add(Me.lblBudgetAmount)
        Me.GroupBox1.Controls.Add(Me.lblActualToDateL)
        Me.GroupBox1.Controls.Add(Me.lblBudgetAmountL)
        Me.GroupBox1.Controls.Add(Me.lblOldCOACode)
        Me.GroupBox1.Controls.Add(Me.lblCOADescp)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btnSearchAccountCode)
        Me.GroupBox1.Controls.Add(Me.txtReason)
        Me.GroupBox1.Controls.Add(Me.txtRequestAmount)
        Me.GroupBox1.Controls.Add(Me.txtCOACode)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblReasonL)
        Me.GroupBox1.Controls.Add(Me.lblRequestAmountL)
        Me.GroupBox1.Controls.Add(Me.lblAccountcodeL)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(536, 221)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(189, 203)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(108, 13)
        Me.lblStatus.TabIndex = 204
        Me.lblStatus.Text = "Open"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(143, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 13)
        Me.Label8.TabIndex = 203
        Me.Label8.Text = ":"
        '
        'lblStatusL
        '
        Me.lblStatusL.AutoSize = True
        Me.lblStatusL.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusL.ForeColor = System.Drawing.Color.Black
        Me.lblStatusL.Location = New System.Drawing.Point(22, 203)
        Me.lblStatusL.Name = "lblStatusL"
        Me.lblStatusL.Size = New System.Drawing.Size(43, 13)
        Me.lblStatusL.TabIndex = 202
        Me.lblStatusL.Text = "Status"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(143, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 201
        Me.Label7.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(143, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 200
        Me.Label4.Text = ":"
        '
        'lblActualToDate
        '
        Me.lblActualToDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblActualToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActualToDate.ForeColor = System.Drawing.Color.Red
        Me.lblActualToDate.Location = New System.Drawing.Point(183, 171)
        Me.lblActualToDate.Name = "lblActualToDate"
        Me.lblActualToDate.Size = New System.Drawing.Size(119, 21)
        Me.lblActualToDate.TabIndex = 199
        '
        'lblBudgetAmount
        '
        Me.lblBudgetAmount.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetAmount.ForeColor = System.Drawing.Color.Red
        Me.lblBudgetAmount.Location = New System.Drawing.Point(183, 135)
        Me.lblBudgetAmount.Name = "lblBudgetAmount"
        Me.lblBudgetAmount.Size = New System.Drawing.Size(119, 21)
        Me.lblBudgetAmount.TabIndex = 198
        '
        'lblActualToDateL
        '
        Me.lblActualToDateL.AutoSize = True
        Me.lblActualToDateL.BackColor = System.Drawing.Color.Transparent
        Me.lblActualToDateL.Location = New System.Drawing.Point(22, 171)
        Me.lblActualToDateL.Name = "lblActualToDateL"
        Me.lblActualToDateL.Size = New System.Drawing.Size(115, 13)
        Me.lblActualToDateL.TabIndex = 197
        Me.lblActualToDateL.Text = "Actual To Date      "
        '
        'lblBudgetAmountL
        '
        Me.lblBudgetAmountL.AutoSize = True
        Me.lblBudgetAmountL.BackColor = System.Drawing.Color.Transparent
        Me.lblBudgetAmountL.Location = New System.Drawing.Point(22, 136)
        Me.lblBudgetAmountL.Name = "lblBudgetAmountL"
        Me.lblBudgetAmountL.Size = New System.Drawing.Size(115, 13)
        Me.lblBudgetAmountL.TabIndex = 196
        Me.lblBudgetAmountL.Text = "Budget Amount     "
        '
        'lblOldCOACode
        '
        Me.lblOldCOACode.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblOldCOACode.Location = New System.Drawing.Point(179, 42)
        Me.lblOldCOACode.Name = "lblOldCOACode"
        Me.lblOldCOACode.Size = New System.Drawing.Size(118, 15)
        Me.lblOldCOACode.TabIndex = 190
        Me.lblOldCOACode.Text = "Old COACode"
        Me.lblOldCOACode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCOADescp
        '
        Me.lblCOADescp.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCOADescp.Location = New System.Drawing.Point(349, 17)
        Me.lblCOADescp.Name = "lblCOADescp"
        Me.lblCOADescp.Size = New System.Drawing.Size(187, 27)
        Me.lblCOADescp.TabIndex = 187
        Me.lblCOADescp.Text = "COA Descp"
        Me.lblCOADescp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(313, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 186
        Me.Label12.Text = "IDR"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(837, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 13)
        Me.Label11.TabIndex = 185
        Me.Label11.Text = "IDR"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(837, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 184
        Me.Label9.Text = "IDR"
        '
        'btnSearchAccountCode
        '
        Me.btnSearchAccountCode.BackgroundImage = CType(resources.GetObject("btnSearchAccountCode.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchAccountCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchAccountCode.FlatAppearance.BorderSize = 0
        Me.btnSearchAccountCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchAccountCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchAccountCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchAccountCode.Location = New System.Drawing.Point(313, 12)
        Me.btnSearchAccountCode.Name = "btnSearchAccountCode"
        Me.btnSearchAccountCode.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchAccountCode.TabIndex = 123
        Me.btnSearchAccountCode.TabStop = False
        Me.btnSearchAccountCode.UseVisualStyleBackColor = True
        '
        'txtReason
        '
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.Location = New System.Drawing.Point(181, 91)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(334, 34)
        Me.txtReason.TabIndex = 10
        '
        'txtRequestAmount
        '
        Me.txtRequestAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRequestAmount.Location = New System.Drawing.Point(181, 60)
        Me.txtRequestAmount.Name = "txtRequestAmount"
        Me.txtRequestAmount.Size = New System.Drawing.Size(116, 21)
        Me.txtRequestAmount.TabIndex = 9
        '
        'txtCOACode
        '
        Me.txtCOACode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCOACode.Location = New System.Drawing.Point(181, 17)
        Me.txtCOACode.Name = "txtCOACode"
        Me.txtCOACode.Size = New System.Drawing.Size(116, 21)
        Me.txtCOACode.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(143, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(143, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 181
        Me.Label5.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(143, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 178
        Me.Label2.Text = ":"
        '
        'lblReasonL
        '
        Me.lblReasonL.AutoSize = True
        Me.lblReasonL.BackColor = System.Drawing.Color.Transparent
        Me.lblReasonL.ForeColor = System.Drawing.Color.Red
        Me.lblReasonL.Location = New System.Drawing.Point(22, 91)
        Me.lblReasonL.Name = "lblReasonL"
        Me.lblReasonL.Size = New System.Drawing.Size(49, 13)
        Me.lblReasonL.TabIndex = 177
        Me.lblReasonL.Text = "Reason"
        '
        'lblRequestAmountL
        '
        Me.lblRequestAmountL.AutoSize = True
        Me.lblRequestAmountL.BackColor = System.Drawing.Color.Transparent
        Me.lblRequestAmountL.ForeColor = System.Drawing.Color.Red
        Me.lblRequestAmountL.Location = New System.Drawing.Point(22, 60)
        Me.lblRequestAmountL.Name = "lblRequestAmountL"
        Me.lblRequestAmountL.Size = New System.Drawing.Size(101, 13)
        Me.lblRequestAmountL.TabIndex = 176
        Me.lblRequestAmountL.Text = "Request Amount"
        '
        'lblAccountcodeL
        '
        Me.lblAccountcodeL.AutoSize = True
        Me.lblAccountcodeL.BackColor = System.Drawing.Color.Transparent
        Me.lblAccountcodeL.ForeColor = System.Drawing.Color.Red
        Me.lblAccountcodeL.Location = New System.Drawing.Point(22, 17)
        Me.lblAccountcodeL.Name = "lblAccountcodeL"
        Me.lblAccountcodeL.Size = New System.Drawing.Size(86, 13)
        Me.lblAccountcodeL.TabIndex = 170
        Me.lblAccountcodeL.Text = "Account Code"
        '
        'grpPinkSlipGrid
        '
        Me.grpPinkSlipGrid.BackColor = System.Drawing.Color.Transparent
        Me.grpPinkSlipGrid.Controls.Add(Me.dgPinkSlip)
        Me.grpPinkSlipGrid.Location = New System.Drawing.Point(6, 283)
        Me.grpPinkSlipGrid.Name = "grpPinkSlipGrid"
        Me.grpPinkSlipGrid.Size = New System.Drawing.Size(880, 153)
        Me.grpPinkSlipGrid.TabIndex = 8
        Me.grpPinkSlipGrid.TabStop = False
        '
        'dgPinkSlip
        '
        Me.dgPinkSlip.AllowUserToAddRows = False
        Me.dgPinkSlip.AllowUserToDeleteRows = False
        Me.dgPinkSlip.AllowUserToResizeRows = False
        Me.dgPinkSlip.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgPinkSlip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgPinkSlip.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPinkSlip.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgPinkSlip.ColumnHeadersHeight = 28
        Me.dgPinkSlip.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PinkSlipId, Me.PinkSlipDetailId, Me.EstateID, Me.COAID, Me.RefNo, Me.DateRequest, Me.COACode, Me.COADescp, Me.RequestedAmt, Me.BudgetAmount, Me.ActualToDate, Me.ApprovedAmt, Me.Reason, Me.Status})
        Me.dgPinkSlip.ContextMenuStrip = Me.cmsPinkSlip
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPinkSlip.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgPinkSlip.EnableHeadersVisualStyles = False
        Me.dgPinkSlip.GridColor = System.Drawing.Color.Gray
        Me.dgPinkSlip.Location = New System.Drawing.Point(3, 17)
        Me.dgPinkSlip.MultiSelect = False
        Me.dgPinkSlip.Name = "dgPinkSlip"
        Me.dgPinkSlip.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPinkSlip.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgPinkSlip.RowHeadersVisible = False
        Me.dgPinkSlip.RowHeadersWidth = 75
        Me.dgPinkSlip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPinkSlip.Size = New System.Drawing.Size(874, 130)
        Me.dgPinkSlip.TabIndex = 6
        Me.dgPinkSlip.TabStop = False
        '
        'PinkSlipId
        '
        Me.PinkSlipId.DataPropertyName = "PinkSlipId"
        Me.PinkSlipId.HeaderText = "PinkSlipId"
        Me.PinkSlipId.Name = "PinkSlipId"
        Me.PinkSlipId.ReadOnly = True
        Me.PinkSlipId.Visible = False
        '
        'PinkSlipDetailId
        '
        Me.PinkSlipDetailId.DataPropertyName = "PinkSlipDetailId"
        Me.PinkSlipDetailId.HeaderText = "PinkSlipDetailId"
        Me.PinkSlipDetailId.Name = "PinkSlipDetailId"
        Me.PinkSlipDetailId.ReadOnly = True
        Me.PinkSlipDetailId.Visible = False
        '
        'EstateID
        '
        Me.EstateID.DataPropertyName = "EstateID"
        Me.EstateID.HeaderText = "EstateID"
        Me.EstateID.Name = "EstateID"
        Me.EstateID.ReadOnly = True
        Me.EstateID.Visible = False
        '
        'COAID
        '
        Me.COAID.DataPropertyName = "COAID"
        Me.COAID.HeaderText = "COAID"
        Me.COAID.Name = "COAID"
        Me.COAID.ReadOnly = True
        Me.COAID.Visible = False
        '
        'RefNo
        '
        Me.RefNo.DataPropertyName = "RefNo"
        Me.RefNo.HeaderText = "Pink Slip Reference No"
        Me.RefNo.Name = "RefNo"
        Me.RefNo.ReadOnly = True
        Me.RefNo.Visible = False
        Me.RefNo.Width = 150
        '
        'DateRequest
        '
        Me.DateRequest.DataPropertyName = "DateRequest"
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DateRequest.DefaultCellStyle = DataGridViewCellStyle2
        Me.DateRequest.HeaderText = "Date Requested"
        Me.DateRequest.Name = "DateRequest"
        Me.DateRequest.ReadOnly = True
        Me.DateRequest.Visible = False
        Me.DateRequest.Width = 125
        '
        'COACode
        '
        Me.COACode.DataPropertyName = "COACode"
        Me.COACode.HeaderText = "Account Code"
        Me.COACode.Name = "COACode"
        Me.COACode.ReadOnly = True
        '
        'COADescp
        '
        Me.COADescp.DataPropertyName = "COADescp"
        Me.COADescp.HeaderText = "Account Descp"
        Me.COADescp.Name = "COADescp"
        Me.COADescp.ReadOnly = True
        '
        'RequestedAmt
        '
        Me.RequestedAmt.DataPropertyName = "RequestedAmt"
        Me.RequestedAmt.HeaderText = "Requested Amount"
        Me.RequestedAmt.Name = "RequestedAmt"
        Me.RequestedAmt.ReadOnly = True
        Me.RequestedAmt.Width = 150
        '
        'BudgetAmount
        '
        Me.BudgetAmount.DataPropertyName = "BudgetAmount"
        Me.BudgetAmount.HeaderText = "Budget Amount"
        Me.BudgetAmount.Name = "BudgetAmount"
        Me.BudgetAmount.ReadOnly = True
        '
        'ActualToDate
        '
        Me.ActualToDate.DataPropertyName = "ActualToDate"
        Me.ActualToDate.HeaderText = "ActualToDate"
        Me.ActualToDate.Name = "ActualToDate"
        Me.ActualToDate.ReadOnly = True
        '
        'ApprovedAmt
        '
        Me.ApprovedAmt.DataPropertyName = "ApprovedAmt"
        Me.ApprovedAmt.HeaderText = "ApprovedAmt"
        Me.ApprovedAmt.Name = "ApprovedAmt"
        Me.ApprovedAmt.ReadOnly = True
        '
        'Reason
        '
        Me.Reason.DataPropertyName = "Reason"
        Me.Reason.HeaderText = "Reason"
        Me.Reason.Name = "Reason"
        Me.Reason.ReadOnly = True
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Visible = False
        '
        'cmsPinkSlip
        '
        Me.cmsPinkSlip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditUpdateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsPinkSlip.Name = "cmsITNIn"
        Me.cmsPinkSlip.Size = New System.Drawing.Size(160, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditUpdateToolStripMenuItem
        '
        Me.EditUpdateToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditUpdateToolStripMenuItem.Image = CType(resources.GetObject("EditUpdateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditUpdateToolStripMenuItem.Name = "EditUpdateToolStripMenuItem"
        Me.EditUpdateToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.EditUpdateToolStripMenuItem.Text = "Edit / Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'grpPinkSlip
        '
        Me.grpPinkSlip.BackColor = System.Drawing.Color.Transparent
        Me.grpPinkSlip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.grpPinkSlip.Controls.Add(Me.dtpDateRequest)
        Me.grpPinkSlip.Controls.Add(Me.lblRefNo)
        Me.grpPinkSlip.Controls.Add(Me.Label1)
        Me.grpPinkSlip.Controls.Add(Me.Label10)
        Me.grpPinkSlip.Controls.Add(Me.lblDateRequestL)
        Me.grpPinkSlip.Controls.Add(Me.lblPinkSlipRefNoL)
        Me.grpPinkSlip.Location = New System.Drawing.Point(10, 4)
        Me.grpPinkSlip.Name = "grpPinkSlip"
        Me.grpPinkSlip.Size = New System.Drawing.Size(880, 53)
        Me.grpPinkSlip.TabIndex = 5
        Me.grpPinkSlip.TabStop = False
        Me.grpPinkSlip.Text = "Pink Slip "
        '
        'dtpDateRequest
        '
        Me.dtpDateRequest.Location = New System.Drawing.Point(592, 21)
        Me.dtpDateRequest.Name = "dtpDateRequest"
        Me.dtpDateRequest.Size = New System.Drawing.Size(115, 21)
        Me.dtpDateRequest.TabIndex = 145
        '
        'lblRefNo
        '
        Me.lblRefNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRefNo.ForeColor = System.Drawing.Color.Black
        Me.lblRefNo.Location = New System.Drawing.Point(248, 17)
        Me.lblRefNo.Name = "lblRefNo"
        Me.lblRefNo.Size = New System.Drawing.Size(121, 21)
        Me.lblRefNo.TabIndex = 144
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(523, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(200, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = ":"
        '
        'lblDateRequestL
        '
        Me.lblDateRequestL.AutoSize = True
        Me.lblDateRequestL.BackColor = System.Drawing.Color.Transparent
        Me.lblDateRequestL.ForeColor = System.Drawing.Color.Red
        Me.lblDateRequestL.Location = New System.Drawing.Point(403, 21)
        Me.lblDateRequestL.Name = "lblDateRequestL"
        Me.lblDateRequestL.Size = New System.Drawing.Size(84, 13)
        Me.lblDateRequestL.TabIndex = 1
        Me.lblDateRequestL.Text = "Date Request"
        '
        'lblPinkSlipRefNoL
        '
        Me.lblPinkSlipRefNoL.AutoSize = True
        Me.lblPinkSlipRefNoL.BackColor = System.Drawing.Color.Transparent
        Me.lblPinkSlipRefNoL.ForeColor = System.Drawing.Color.Red
        Me.lblPinkSlipRefNoL.Location = New System.Drawing.Point(27, 20)
        Me.lblPinkSlipRefNoL.Name = "lblPinkSlipRefNoL"
        Me.lblPinkSlipRefNoL.Size = New System.Drawing.Size(137, 13)
        Me.lblPinkSlipRefNoL.TabIndex = 0
        Me.lblPinkSlipRefNoL.Text = "Pink Slip Reference No"
        '
        'tbView
        '
        Me.tbView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbView.Controls.Add(Me.GroupBox3)
        Me.tbView.Location = New System.Drawing.Point(4, 22)
        Me.tbView.Name = "tbView"
        Me.tbView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbView.Size = New System.Drawing.Size(932, 488)
        Me.tbView.TabIndex = 1
        Me.tbView.Text = "View"
        Me.tbView.UseVisualStyleBackColor = True
        '
        'pnlPinkSlipSearch
        '
        Me.pnlPinkSlipSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlPinkSlipSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlPinkSlipSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlPinkSlipSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlPinkSlipSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlPinkSlipSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPinkSlipSearch.CaptionSize = 40
        Me.pnlPinkSlipSearch.CaptionText = "Search Pink Slip"
        Me.pnlPinkSlipSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlPinkSlipSearch.Controls.Add(Me.dtpDateRequestView)
        Me.pnlPinkSlipSearch.Controls.Add(Me.chkDateRequest)
        Me.pnlPinkSlipSearch.Controls.Add(Me.lblPinkSlipNoView)
        Me.pnlPinkSlipSearch.Controls.Add(Me.txtPinkSlipNoView)
        Me.pnlPinkSlipSearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlPinkSlipSearch.Controls.Add(Me.lblStatusView)
        Me.pnlPinkSlipSearch.Controls.Add(Me.cmbStatus)
        Me.pnlPinkSlipSearch.Controls.Add(Me.btnviewReport)
        Me.pnlPinkSlipSearch.Controls.Add(Me.btnSearch)
        Me.pnlPinkSlipSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlPinkSlipSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlPinkSlipSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlPinkSlipSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPinkSlipSearch.ForeColor = System.Drawing.Color.Black
        Me.pnlPinkSlipSearch.Location = New System.Drawing.Point(3, 17)
        Me.pnlPinkSlipSearch.Name = "pnlPinkSlipSearch"
        Me.pnlPinkSlipSearch.Size = New System.Drawing.Size(916, 124)
        Me.pnlPinkSlipSearch.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(596, 74)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 3
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
        Me.btnviewReport.Location = New System.Drawing.Point(719, 74)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(126, 25)
        Me.btnviewReport.TabIndex = 4
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"SELECT ALL", "OPEN", "REJECTED", "APPROVED"})
        Me.cmbStatus.Location = New System.Drawing.Point(428, 78)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(121, 21)
        Me.cmbStatus.TabIndex = 2
        '
        'lblStatusView
        '
        Me.lblStatusView.AutoSize = True
        Me.lblStatusView.ForeColor = System.Drawing.Color.Black
        Me.lblStatusView.Location = New System.Drawing.Point(425, 51)
        Me.lblStatusView.Name = "lblStatusView"
        Me.lblStatusView.Size = New System.Drawing.Size(43, 13)
        Me.lblStatusView.TabIndex = 16
        Me.lblStatusView.Text = "Status"
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
        'txtPinkSlipNoView
        '
        Me.txtPinkSlipNoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPinkSlipNoView.Location = New System.Drawing.Point(95, 78)
        Me.txtPinkSlipNoView.MaxLength = 50
        Me.txtPinkSlipNoView.Name = "txtPinkSlipNoView"
        Me.txtPinkSlipNoView.Size = New System.Drawing.Size(115, 21)
        Me.txtPinkSlipNoView.TabIndex = 0
        '
        'lblPinkSlipNoView
        '
        Me.lblPinkSlipNoView.AutoSize = True
        Me.lblPinkSlipNoView.ForeColor = System.Drawing.Color.Black
        Me.lblPinkSlipNoView.Location = New System.Drawing.Point(92, 51)
        Me.lblPinkSlipNoView.Name = "lblPinkSlipNoView"
        Me.lblPinkSlipNoView.Size = New System.Drawing.Size(75, 13)
        Me.lblPinkSlipNoView.TabIndex = 122
        Me.lblPinkSlipNoView.Text = "Pink Slip No"
        '
        'chkDateRequest
        '
        Me.chkDateRequest.AutoSize = True
        Me.chkDateRequest.Location = New System.Drawing.Point(264, 50)
        Me.chkDateRequest.Name = "chkDateRequest"
        Me.chkDateRequest.Size = New System.Drawing.Size(103, 17)
        Me.chkDateRequest.TabIndex = 1
        Me.chkDateRequest.Text = "Date Request"
        Me.chkDateRequest.UseVisualStyleBackColor = True
        '
        'dtpDateRequestView
        '
        Me.dtpDateRequestView.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateRequestView.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateRequestView.Location = New System.Drawing.Point(264, 78)
        Me.dtpDateRequestView.Name = "dtpDateRequestView"
        Me.dtpDateRequestView.Size = New System.Drawing.Size(117, 21)
        Me.dtpDateRequestView.TabIndex = 1
        '
        'dgPinkSlipView
        '
        Me.dgPinkSlipView.AllowUserToAddRows = False
        Me.dgPinkSlipView.AllowUserToDeleteRows = False
        Me.dgPinkSlipView.AllowUserToResizeRows = False
        Me.dgPinkSlipView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgPinkSlipView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgPinkSlipView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPinkSlipView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgPinkSlipView.ColumnHeadersHeight = 28
        Me.dgPinkSlipView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PinkSlipIdView, Me.PinkSlipDetailIdView, Me.EstateIDView, Me.COAIDView, Me.RefNoView, Me.DateRequestView, Me.COACodeView, Me.COADescpView, Me.BudgetAmountView, Me.RejectedReasonView, Me.ActualToDateView, Me.RequestedAmtView, Me.ReasonView, Me.ApprovedAmtView, Me.StatusView})
        Me.dgPinkSlipView.ContextMenuStrip = Me.cmsPinkSlip
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPinkSlipView.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgPinkSlipView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPinkSlipView.EnableHeadersVisualStyles = False
        Me.dgPinkSlipView.Location = New System.Drawing.Point(3, 141)
        Me.dgPinkSlipView.MultiSelect = False
        Me.dgPinkSlipView.Name = "dgPinkSlipView"
        Me.dgPinkSlipView.ReadOnly = True
        Me.dgPinkSlipView.RowHeadersVisible = False
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.dgPinkSlipView.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgPinkSlipView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPinkSlipView.Size = New System.Drawing.Size(916, 312)
        Me.dgPinkSlipView.TabIndex = 9
        Me.dgPinkSlipView.TabStop = False
        '
        'StatusView
        '
        Me.StatusView.DataPropertyName = "Status"
        Me.StatusView.HeaderText = "Status"
        Me.StatusView.Name = "StatusView"
        Me.StatusView.ReadOnly = True
        '
        'ApprovedAmtView
        '
        Me.ApprovedAmtView.DataPropertyName = "ApprovedAmt"
        Me.ApprovedAmtView.HeaderText = "ApprovedAmt"
        Me.ApprovedAmtView.Name = "ApprovedAmtView"
        Me.ApprovedAmtView.ReadOnly = True
        Me.ApprovedAmtView.Visible = False
        '
        'ReasonView
        '
        Me.ReasonView.DataPropertyName = "Reason"
        Me.ReasonView.HeaderText = "Reason"
        Me.ReasonView.Name = "ReasonView"
        Me.ReasonView.ReadOnly = True
        Me.ReasonView.Visible = False
        '
        'RequestedAmtView
        '
        Me.RequestedAmtView.DataPropertyName = "RequestedAmt"
        Me.RequestedAmtView.HeaderText = "Requested Amount"
        Me.RequestedAmtView.Name = "RequestedAmtView"
        Me.RequestedAmtView.ReadOnly = True
        Me.RequestedAmtView.Visible = False
        '
        'ActualToDateView
        '
        Me.ActualToDateView.DataPropertyName = "ActualToDateView"
        Me.ActualToDateView.HeaderText = "ActualToDate"
        Me.ActualToDateView.Name = "ActualToDateView"
        Me.ActualToDateView.ReadOnly = True
        Me.ActualToDateView.Visible = False
        '
        'RejectedReasonView
        '
        Me.RejectedReasonView.DataPropertyName = "RejectedReason"
        Me.RejectedReasonView.HeaderText = "RejectedReason"
        Me.RejectedReasonView.Name = "RejectedReasonView"
        Me.RejectedReasonView.ReadOnly = True
        Me.RejectedReasonView.Visible = False
        '
        'BudgetAmountView
        '
        Me.BudgetAmountView.DataPropertyName = "BudgetAmountView"
        Me.BudgetAmountView.HeaderText = "BudgetAmount"
        Me.BudgetAmountView.Name = "BudgetAmountView"
        Me.BudgetAmountView.ReadOnly = True
        Me.BudgetAmountView.Visible = False
        '
        'COADescpView
        '
        Me.COADescpView.DataPropertyName = "COADescp"
        Me.COADescpView.HeaderText = "Account Descp"
        Me.COADescpView.Name = "COADescpView"
        Me.COADescpView.ReadOnly = True
        Me.COADescpView.Visible = False
        '
        'COACodeView
        '
        Me.COACodeView.DataPropertyName = "COACode"
        Me.COACodeView.HeaderText = "Account Code"
        Me.COACodeView.Name = "COACodeView"
        Me.COACodeView.ReadOnly = True
        Me.COACodeView.Visible = False
        '
        'DateRequestView
        '
        Me.DateRequestView.DataPropertyName = "DateRequest"
        Me.DateRequestView.HeaderText = "Date Requested"
        Me.DateRequestView.Name = "DateRequestView"
        Me.DateRequestView.ReadOnly = True
        Me.DateRequestView.Width = 125
        '
        'RefNoView
        '
        Me.RefNoView.DataPropertyName = "RefNo"
        Me.RefNoView.HeaderText = "Pink Slip Reference No"
        Me.RefNoView.Name = "RefNoView"
        Me.RefNoView.ReadOnly = True
        Me.RefNoView.Width = 150
        '
        'COAIDView
        '
        Me.COAIDView.DataPropertyName = "COAID"
        Me.COAIDView.HeaderText = "COAID"
        Me.COAIDView.Name = "COAIDView"
        Me.COAIDView.ReadOnly = True
        Me.COAIDView.Visible = False
        '
        'EstateIDView
        '
        Me.EstateIDView.DataPropertyName = "EstateID"
        Me.EstateIDView.HeaderText = "EstateID"
        Me.EstateIDView.Name = "EstateIDView"
        Me.EstateIDView.ReadOnly = True
        Me.EstateIDView.Visible = False
        '
        'PinkSlipDetailIdView
        '
        Me.PinkSlipDetailIdView.DataPropertyName = "PinkSlipDetailId"
        Me.PinkSlipDetailIdView.HeaderText = "PinkSlipDetailId"
        Me.PinkSlipDetailIdView.Name = "PinkSlipDetailIdView"
        Me.PinkSlipDetailIdView.ReadOnly = True
        Me.PinkSlipDetailIdView.Visible = False
        '
        'PinkSlipIdView
        '
        Me.PinkSlipIdView.DataPropertyName = "PinkSlipId"
        Me.PinkSlipIdView.HeaderText = "PinkSlipId"
        Me.PinkSlipIdView.Name = "PinkSlipIdView"
        Me.PinkSlipIdView.ReadOnly = True
        Me.PinkSlipIdView.Visible = False
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(391, 274)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 114
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblNoRecord)
        Me.GroupBox3.Controls.Add(Me.dgPinkSlipView)
        Me.GroupBox3.Controls.Add(Me.pnlPinkSlipSearch)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(922, 456)
        Me.GroupBox3.TabIndex = 114
        Me.GroupBox3.TabStop = False
        '
        'StandardPinkSlipFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(993, 522)
        Me.Controls.Add(Me.tbBudgetPinkSlip)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "StandardPinkSlipFrm"
        Me.Text = "StandardPinkSlipFrm"
        Me.tbBudgetPinkSlip.ResumeLayout(False)
        Me.tbPinkSlip.ResumeLayout(False)
        Me.tbPinkSlip.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.grpCentralInformation.ResumeLayout(False)
        Me.grpCentralInformation.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpPinkSlipGrid.ResumeLayout(False)
        CType(Me.dgPinkSlip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPinkSlip.ResumeLayout(False)
        Me.grpPinkSlip.ResumeLayout(False)
        Me.grpPinkSlip.PerformLayout()
        Me.tbView.ResumeLayout(False)
        Me.pnlPinkSlipSearch.ResumeLayout(False)
        Me.pnlPinkSlipSearch.PerformLayout()
        CType(Me.dgPinkSlipView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbBudgetPinkSlip As System.Windows.Forms.TabControl
    Friend WithEvents tbPinkSlip As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCOADescp As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSearchAccountCode As System.Windows.Forms.Button
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents txtRequestAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCOACode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblReasonL As System.Windows.Forms.Label
    Friend WithEvents lblRequestAmountL As System.Windows.Forms.Label
    Friend WithEvents lblAccountcodeL As System.Windows.Forms.Label
    Friend WithEvents grpPinkSlipGrid As System.Windows.Forms.GroupBox
    Friend WithEvents dgPinkSlip As System.Windows.Forms.DataGridView
    Friend WithEvents grpPinkSlip As System.Windows.Forms.GroupBox
    Friend WithEvents lblRefNo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblDateRequestL As System.Windows.Forms.Label
    Friend WithEvents lblPinkSlipRefNoL As System.Windows.Forms.Label
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents cmsPinkSlip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblOldCOACode As System.Windows.Forms.Label
    Friend WithEvents dtpDateRequest As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnResetGeneral As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtApprovedAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblApprovedAmountL As System.Windows.Forms.Label
    Friend WithEvents grpCentralInformation As System.Windows.Forms.GroupBox
    Friend WithEvents cmbApprovalStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblApprovalStatus As System.Windows.Forms.Label
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents txtRejectedReason As System.Windows.Forms.TextBox
    Friend WithEvents lblRejectedReason As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblStatusL As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblActualToDate As System.Windows.Forms.Label
    Friend WithEvents lblBudgetAmount As System.Windows.Forms.Label
    Friend WithEvents lblActualToDateL As System.Windows.Forms.Label
    Friend WithEvents lblBudgetAmountL As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PinkSlipId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkSlipDetailId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateRequest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequestedAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActualToDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovedAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbView As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents dgPinkSlipView As System.Windows.Forms.DataGridView
    Friend WithEvents PinkSlipIdView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkSlipDetailIdView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefNoView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateRequestView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COACodeView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COADescpView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetAmountView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RejectedReasonView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActualToDateView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequestedAmtView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReasonView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovedAmtView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlPinkSlipSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents dtpDateRequestView As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkDateRequest As System.Windows.Forms.CheckBox
    Friend WithEvents lblPinkSlipNoView As System.Windows.Forms.Label
    Friend WithEvents txtPinkSlipNoView As System.Windows.Forms.TextBox
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents lblStatusView As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
End Class

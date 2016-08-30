<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstateGrading
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstateGrading))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmsAdvancePaymentDet = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteMIAdvancePaymentDet = New System.Windows.Forms.ToolStripMenuItem()
        Me.s = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabAdvancePayment = New System.Windows.Forms.TabPage()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblGredValue = New System.Windows.Forms.Label()
        Me.lblFieldNoValue = New System.Windows.Forms.Label()
        Me.lblGangTeamValue = New System.Windows.Forms.Label()
        Me.lblAfdelingValue = New System.Windows.Forms.Label()
        Me.lblEstateValue = New System.Windows.Forms.Label()
        Me.BtnGredLookUp = New System.Windows.Forms.Button()
        Me.BtnGangLookUp = New System.Windows.Forms.Button()
        Me.BtnFieldNoLookUp = New System.Windows.Forms.Button()
        Me.BtnMasterLookUp = New System.Windows.Forms.Button()
        Me.BtnEstateLookUp = New System.Windows.Forms.Button()
        Me.txtGred = New System.Windows.Forms.TextBox()
        Me.LblMandorValue = New System.Windows.Forms.Label()
        Me.txtMandor = New System.Windows.Forms.TextBox()
        Me.BtnAfdelingLookUp = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFieldNo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtGangTeam = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAfdeling = New System.Windows.Forms.TextBox()
        Me.dtpMonth = New System.Windows.Forms.DateTimePicker()
        Me.txtEstate = New System.Windows.Forms.TextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblColon1 = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblAPremium = New System.Windows.Forms.Label()
        Me.lblColon3 = New System.Windows.Forms.Label()
        Me.lblColon2 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gbEnquipmentData = New System.Windows.Forms.GroupBox()
        Me.dgvEstateGrading = New System.Windows.Forms.DataGridView()
        Me.dgcMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcEstate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcAfdeling = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcMandor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcGangTeam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcFieldNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcGred = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tcAdvancePayment = New System.Windows.Forms.TabControl()
        Me.cmsAdvancePaymentDet.SuspendLayout()
        Me.tabAdvancePayment.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbEnquipmentData.SuspendLayout()
        CType(Me.dgvEstateGrading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcAdvancePayment.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsAdvancePaymentDet
        '
        Me.cmsAdvancePaymentDet.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteMIAdvancePaymentDet})
        Me.cmsAdvancePaymentDet.Name = "cmsAdvancePaymentDet"
        Me.cmsAdvancePaymentDet.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteMIAdvancePaymentDet
        '
        Me.DeleteMIAdvancePaymentDet.Name = "DeleteMIAdvancePaymentDet"
        Me.DeleteMIAdvancePaymentDet.Size = New System.Drawing.Size(107, 22)
        Me.DeleteMIAdvancePaymentDet.Text = "Delete"
        '
        's
        '
        Me.s.HeaderText = "Select"
        Me.s.Name = "s"
        Me.s.ReadOnly = True
        Me.s.Width = 66
        '
        'NIK
        '
        Me.NIK.HeaderText = "NIK"
        Me.NIK.Name = "NIK"
        Me.NIK.ReadOnly = True
        Me.NIK.Width = 52
        '
        'Category
        '
        Me.Category.HeaderText = "Category"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        Me.Category.Width = 84
        '
        'HK
        '
        Me.HK.HeaderText = "HK"
        Me.HK.Name = "HK"
        Me.HK.ReadOnly = True
        Me.HK.Width = 47
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        Me.Amount.Width = 75
        '
        'tabAdvancePayment
        '
        Me.tabAdvancePayment.AutoScroll = True
        Me.tabAdvancePayment.BackColor = System.Drawing.Color.Transparent
        Me.tabAdvancePayment.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tabAdvancePayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabAdvancePayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabAdvancePayment.Controls.Add(Me.btnAdd)
        Me.tabAdvancePayment.Controls.Add(Me.btnSaveAll)
        Me.tabAdvancePayment.Controls.Add(Me.btnReset)
        Me.tabAdvancePayment.Controls.Add(Me.GroupBox1)
        Me.tabAdvancePayment.Controls.Add(Me.btnClose)
        Me.tabAdvancePayment.Controls.Add(Me.gbEnquipmentData)
        Me.tabAdvancePayment.Location = New System.Drawing.Point(4, 22)
        Me.tabAdvancePayment.Name = "tabAdvancePayment"
        Me.tabAdvancePayment.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAdvancePayment.Size = New System.Drawing.Size(908, 524)
        Me.tabAdvancePayment.TabIndex = 0
        Me.tabAdvancePayment.Text = "Estate Grading"
        Me.tabAdvancePayment.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(15, 163)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(105, 30)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = CType(resources.GetObject("btnSaveAll.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(15, 341)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(105, 30)
        Me.btnSaveAll.TabIndex = 15
        Me.btnSaveAll.Text = "&Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(126, 163)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(105, 30)
        Me.btnReset.TabIndex = 9
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblGredValue)
        Me.GroupBox1.Controls.Add(Me.lblFieldNoValue)
        Me.GroupBox1.Controls.Add(Me.lblGangTeamValue)
        Me.GroupBox1.Controls.Add(Me.lblAfdelingValue)
        Me.GroupBox1.Controls.Add(Me.lblEstateValue)
        Me.GroupBox1.Controls.Add(Me.BtnGredLookUp)
        Me.GroupBox1.Controls.Add(Me.BtnGangLookUp)
        Me.GroupBox1.Controls.Add(Me.BtnFieldNoLookUp)
        Me.GroupBox1.Controls.Add(Me.BtnMasterLookUp)
        Me.GroupBox1.Controls.Add(Me.BtnEstateLookUp)
        Me.GroupBox1.Controls.Add(Me.txtGred)
        Me.GroupBox1.Controls.Add(Me.LblMandorValue)
        Me.GroupBox1.Controls.Add(Me.txtMandor)
        Me.GroupBox1.Controls.Add(Me.BtnAfdelingLookUp)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtFieldNo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtGangTeam)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtAfdeling)
        Me.GroupBox1.Controls.Add(Me.dtpMonth)
        Me.GroupBox1.Controls.Add(Me.txtEstate)
        Me.GroupBox1.Controls.Add(Me.lblDate)
        Me.GroupBox1.Controls.Add(Me.lblColon1)
        Me.GroupBox1.Controls.Add(Me.lblCategory)
        Me.GroupBox1.Controls.Add(Me.lblAPremium)
        Me.GroupBox1.Controls.Add(Me.lblColon3)
        Me.GroupBox1.Controls.Add(Me.lblColon2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(859, 148)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblGredValue
        '
        Me.lblGredValue.AutoSize = True
        Me.lblGredValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGredValue.ForeColor = System.Drawing.Color.Black
        Me.lblGredValue.Location = New System.Drawing.Point(676, 108)
        Me.lblGredValue.Name = "lblGredValue"
        Me.lblGredValue.Size = New System.Drawing.Size(11, 13)
        Me.lblGredValue.TabIndex = 165
        Me.lblGredValue.Text = "."
        '
        'lblFieldNoValue
        '
        Me.lblFieldNoValue.AutoSize = True
        Me.lblFieldNoValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFieldNoValue.ForeColor = System.Drawing.Color.Black
        Me.lblFieldNoValue.Location = New System.Drawing.Point(675, 74)
        Me.lblFieldNoValue.Name = "lblFieldNoValue"
        Me.lblFieldNoValue.Size = New System.Drawing.Size(11, 13)
        Me.lblFieldNoValue.TabIndex = 164
        Me.lblFieldNoValue.Text = "."
        '
        'lblGangTeamValue
        '
        Me.lblGangTeamValue.AutoSize = True
        Me.lblGangTeamValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGangTeamValue.ForeColor = System.Drawing.Color.Black
        Me.lblGangTeamValue.Location = New System.Drawing.Point(676, 40)
        Me.lblGangTeamValue.Name = "lblGangTeamValue"
        Me.lblGangTeamValue.Size = New System.Drawing.Size(11, 13)
        Me.lblGangTeamValue.TabIndex = 163
        Me.lblGangTeamValue.Text = "."
        '
        'lblAfdelingValue
        '
        Me.lblAfdelingValue.AutoSize = True
        Me.lblAfdelingValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAfdelingValue.ForeColor = System.Drawing.Color.Black
        Me.lblAfdelingValue.Location = New System.Drawing.Point(288, 78)
        Me.lblAfdelingValue.Name = "lblAfdelingValue"
        Me.lblAfdelingValue.Size = New System.Drawing.Size(11, 13)
        Me.lblAfdelingValue.TabIndex = 161
        Me.lblAfdelingValue.Text = "."
        '
        'lblEstateValue
        '
        Me.lblEstateValue.AutoSize = True
        Me.lblEstateValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstateValue.ForeColor = System.Drawing.Color.Black
        Me.lblEstateValue.Location = New System.Drawing.Point(288, 44)
        Me.lblEstateValue.Name = "lblEstateValue"
        Me.lblEstateValue.Size = New System.Drawing.Size(11, 13)
        Me.lblEstateValue.TabIndex = 160
        Me.lblEstateValue.Text = "."
        '
        'BtnGredLookUp
        '
        Me.BtnGredLookUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGredLookUp.Image = CType(resources.GetObject("BtnGredLookUp.Image"), System.Drawing.Image)
        Me.BtnGredLookUp.Location = New System.Drawing.Point(639, 108)
        Me.BtnGredLookUp.Name = "BtnGredLookUp"
        Me.BtnGredLookUp.Size = New System.Drawing.Size(31, 26)
        Me.BtnGredLookUp.TabIndex = 159
        Me.BtnGredLookUp.TabStop = False
        Me.BtnGredLookUp.UseVisualStyleBackColor = True
        '
        'BtnGangLookUp
        '
        Me.BtnGangLookUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGangLookUp.Image = CType(resources.GetObject("BtnGangLookUp.Image"), System.Drawing.Image)
        Me.BtnGangLookUp.Location = New System.Drawing.Point(639, 40)
        Me.BtnGangLookUp.Name = "BtnGangLookUp"
        Me.BtnGangLookUp.Size = New System.Drawing.Size(31, 26)
        Me.BtnGangLookUp.TabIndex = 158
        Me.BtnGangLookUp.TabStop = False
        Me.BtnGangLookUp.UseVisualStyleBackColor = True
        '
        'BtnFieldNoLookUp
        '
        Me.BtnFieldNoLookUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFieldNoLookUp.Image = CType(resources.GetObject("BtnFieldNoLookUp.Image"), System.Drawing.Image)
        Me.BtnFieldNoLookUp.Location = New System.Drawing.Point(638, 74)
        Me.BtnFieldNoLookUp.Name = "BtnFieldNoLookUp"
        Me.BtnFieldNoLookUp.Size = New System.Drawing.Size(31, 26)
        Me.BtnFieldNoLookUp.TabIndex = 157
        Me.BtnFieldNoLookUp.TabStop = False
        Me.BtnFieldNoLookUp.UseVisualStyleBackColor = True
        '
        'BtnMasterLookUp
        '
        Me.BtnMasterLookUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMasterLookUp.Image = CType(resources.GetObject("BtnMasterLookUp.Image"), System.Drawing.Image)
        Me.BtnMasterLookUp.Location = New System.Drawing.Point(249, 110)
        Me.BtnMasterLookUp.Name = "BtnMasterLookUp"
        Me.BtnMasterLookUp.Size = New System.Drawing.Size(31, 26)
        Me.BtnMasterLookUp.TabIndex = 156
        Me.BtnMasterLookUp.TabStop = False
        Me.BtnMasterLookUp.UseVisualStyleBackColor = True
        '
        'BtnEstateLookUp
        '
        Me.BtnEstateLookUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEstateLookUp.Image = CType(resources.GetObject("BtnEstateLookUp.Image"), System.Drawing.Image)
        Me.BtnEstateLookUp.Location = New System.Drawing.Point(251, 42)
        Me.BtnEstateLookUp.Name = "BtnEstateLookUp"
        Me.BtnEstateLookUp.Size = New System.Drawing.Size(31, 26)
        Me.BtnEstateLookUp.TabIndex = 155
        Me.BtnEstateLookUp.TabStop = False
        Me.BtnEstateLookUp.UseVisualStyleBackColor = True
        '
        'txtGred
        '
        Me.txtGred.BackColor = System.Drawing.SystemColors.Window
        Me.txtGred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGred.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGred.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGred.Location = New System.Drawing.Point(497, 111)
        Me.txtGred.MaxLength = 50
        Me.txtGred.Name = "txtGred"
        Me.txtGred.ReadOnly = True
        Me.txtGred.Size = New System.Drawing.Size(135, 21)
        Me.txtGred.TabIndex = 154
        '
        'LblMandorValue
        '
        Me.LblMandorValue.AutoSize = True
        Me.LblMandorValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMandorValue.ForeColor = System.Drawing.Color.Blue
        Me.LblMandorValue.Location = New System.Drawing.Point(288, 112)
        Me.LblMandorValue.Name = "LblMandorValue"
        Me.LblMandorValue.Size = New System.Drawing.Size(11, 13)
        Me.LblMandorValue.TabIndex = 153
        Me.LblMandorValue.Text = "."
        '
        'txtMandor
        '
        Me.txtMandor.BackColor = System.Drawing.SystemColors.Window
        Me.txtMandor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMandor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMandor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMandor.Location = New System.Drawing.Point(108, 112)
        Me.txtMandor.MaxLength = 50
        Me.txtMandor.Name = "txtMandor"
        Me.txtMandor.ReadOnly = True
        Me.txtMandor.Size = New System.Drawing.Size(135, 21)
        Me.txtMandor.TabIndex = 152
        '
        'BtnAfdelingLookUp
        '
        Me.BtnAfdelingLookUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAfdelingLookUp.Image = CType(resources.GetObject("BtnAfdelingLookUp.Image"), System.Drawing.Image)
        Me.BtnAfdelingLookUp.Location = New System.Drawing.Point(250, 76)
        Me.BtnAfdelingLookUp.Name = "BtnAfdelingLookUp"
        Me.BtnAfdelingLookUp.Size = New System.Drawing.Size(31, 26)
        Me.BtnAfdelingLookUp.TabIndex = 151
        Me.BtnAfdelingLookUp.TabStop = False
        Me.BtnAfdelingLookUp.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(406, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 137
        Me.Label12.Text = "Gred"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(480, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 13)
        Me.Label13.TabIndex = 138
        Me.Label13.Text = ":"
        '
        'txtFieldNo
        '
        Me.txtFieldNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtFieldNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFieldNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFieldNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFieldNo.Location = New System.Drawing.Point(497, 78)
        Me.txtFieldNo.MaxLength = 50
        Me.txtFieldNo.Name = "txtFieldNo"
        Me.txtFieldNo.ReadOnly = True
        Me.txtFieldNo.Size = New System.Drawing.Size(135, 21)
        Me.txtFieldNo.TabIndex = 135
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(406, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 133
        Me.Label10.Text = "Field No."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(480, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 134
        Me.Label11.Text = ":"
        '
        'txtGangTeam
        '
        Me.txtGangTeam.BackColor = System.Drawing.SystemColors.Window
        Me.txtGangTeam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGangTeam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGangTeam.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGangTeam.Location = New System.Drawing.Point(497, 44)
        Me.txtGangTeam.MaxLength = 50
        Me.txtGangTeam.Name = "txtGangTeam"
        Me.txtGangTeam.ReadOnly = True
        Me.txtGangTeam.Size = New System.Drawing.Size(135, 21)
        Me.txtGangTeam.TabIndex = 130
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(406, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 131
        Me.Label8.Text = "Gang/Team"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(480, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 132
        Me.Label9.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(17, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "Mandor"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(91, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 129
        Me.Label7.Text = ":"
        '
        'txtAfdeling
        '
        Me.txtAfdeling.BackColor = System.Drawing.SystemColors.Window
        Me.txtAfdeling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAfdeling.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAfdeling.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAfdeling.Location = New System.Drawing.Point(108, 78)
        Me.txtAfdeling.MaxLength = 50
        Me.txtAfdeling.Name = "txtAfdeling"
        Me.txtAfdeling.ReadOnly = True
        Me.txtAfdeling.Size = New System.Drawing.Size(135, 21)
        Me.txtAfdeling.TabIndex = 127
        '
        'dtpMonth
        '
        Me.dtpMonth.CustomFormat = "dd/MM/yyyy"
        Me.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMonth.Location = New System.Drawing.Point(108, 17)
        Me.dtpMonth.Name = "dtpMonth"
        Me.dtpMonth.Size = New System.Drawing.Size(135, 20)
        Me.dtpMonth.TabIndex = 0
        '
        'txtEstate
        '
        Me.txtEstate.BackColor = System.Drawing.SystemColors.Window
        Me.txtEstate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEstate.Location = New System.Drawing.Point(108, 44)
        Me.txtEstate.MaxLength = 50
        Me.txtEstate.Name = "txtEstate"
        Me.txtEstate.ReadOnly = True
        Me.txtEstate.Size = New System.Drawing.Size(135, 21)
        Me.txtEstate.TabIndex = 3
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(18, 21)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(41, 13)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Month"
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(92, 19)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(11, 13)
        Me.lblColon1.TabIndex = 19
        Me.lblColon1.Text = ":"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.Color.Red
        Me.lblCategory.Location = New System.Drawing.Point(17, 46)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(42, 13)
        Me.lblCategory.TabIndex = 15
        Me.lblCategory.Text = "Estate"
        '
        'lblAPremium
        '
        Me.lblAPremium.AutoSize = True
        Me.lblAPremium.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAPremium.ForeColor = System.Drawing.Color.Red
        Me.lblAPremium.Location = New System.Drawing.Point(17, 79)
        Me.lblAPremium.Name = "lblAPremium"
        Me.lblAPremium.Size = New System.Drawing.Size(53, 13)
        Me.lblAPremium.TabIndex = 16
        Me.lblAPremium.Text = "Afdeling"
        '
        'lblColon3
        '
        Me.lblColon3.AutoSize = True
        Me.lblColon3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon3.ForeColor = System.Drawing.Color.Red
        Me.lblColon3.Location = New System.Drawing.Point(91, 78)
        Me.lblColon3.Name = "lblColon3"
        Me.lblColon3.Size = New System.Drawing.Size(11, 13)
        Me.lblColon3.TabIndex = 30
        Me.lblColon3.Text = ":"
        '
        'lblColon2
        '
        Me.lblColon2.AutoSize = True
        Me.lblColon2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon2.ForeColor = System.Drawing.Color.Red
        Me.lblColon2.Location = New System.Drawing.Point(91, 45)
        Me.lblColon2.Name = "lblColon2"
        Me.lblColon2.Size = New System.Drawing.Size(11, 13)
        Me.lblColon2.TabIndex = 29
        Me.lblColon2.Text = ":"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(126, 341)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 30)
        Me.btnClose.TabIndex = 16
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'gbEnquipmentData
        '
        Me.gbEnquipmentData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEnquipmentData.Controls.Add(Me.dgvEstateGrading)
        Me.gbEnquipmentData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEnquipmentData.Location = New System.Drawing.Point(9, 196)
        Me.gbEnquipmentData.Name = "gbEnquipmentData"
        Me.gbEnquipmentData.Size = New System.Drawing.Size(859, 133)
        Me.gbEnquipmentData.TabIndex = 2
        Me.gbEnquipmentData.TabStop = False
        '
        'dgvEstateGrading
        '
        Me.dgvEstateGrading.AllowUserToAddRows = False
        Me.dgvEstateGrading.AllowUserToDeleteRows = False
        Me.dgvEstateGrading.AllowUserToOrderColumns = True
        Me.dgvEstateGrading.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvEstateGrading.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEstateGrading.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEstateGrading.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvEstateGrading.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvEstateGrading.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEstateGrading.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEstateGrading.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEstateGrading.ColumnHeadersHeight = 30
        Me.dgvEstateGrading.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgcMonth, Me.dgcEstate, Me.dgcAfdeling, Me.dgcMandor, Me.dgcGangTeam, Me.dgcFieldNo, Me.dgcGred})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEstateGrading.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEstateGrading.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvEstateGrading.EnableHeadersVisualStyles = False
        Me.dgvEstateGrading.GridColor = System.Drawing.Color.Gray
        Me.dgvEstateGrading.Location = New System.Drawing.Point(6, 20)
        Me.dgvEstateGrading.MultiSelect = False
        Me.dgvEstateGrading.Name = "dgvEstateGrading"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEstateGrading.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvEstateGrading.RowHeadersVisible = False
        Me.dgvEstateGrading.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvEstateGrading.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEstateGrading.ShowCellErrors = False
        Me.dgvEstateGrading.Size = New System.Drawing.Size(847, 205)
        Me.dgvEstateGrading.TabIndex = 14
        '
        'dgcMonth
        '
        Me.dgcMonth.DataPropertyName = "Month"
        Me.dgcMonth.HeaderText = "Month"
        Me.dgcMonth.Name = "dgcMonth"
        '
        'dgcEstate
        '
        Me.dgcEstate.DataPropertyName = "Estate"
        Me.dgcEstate.HeaderText = "Estate"
        Me.dgcEstate.Name = "dgcEstate"
        '
        'dgcAfdeling
        '
        Me.dgcAfdeling.DataPropertyName = "Afdeling"
        Me.dgcAfdeling.HeaderText = "Afdeling"
        Me.dgcAfdeling.Name = "dgcAfdeling"
        '
        'dgcMandor
        '
        Me.dgcMandor.DataPropertyName = "Mandor"
        Me.dgcMandor.HeaderText = "Mandor"
        Me.dgcMandor.Name = "dgcMandor"
        '
        'dgcGangTeam
        '
        Me.dgcGangTeam.DataPropertyName = "GangTeam"
        Me.dgcGangTeam.HeaderText = "Gang / Team"
        Me.dgcGangTeam.Name = "dgcGangTeam"
        '
        'dgcFieldNo
        '
        Me.dgcFieldNo.DataPropertyName = "FieldNo"
        Me.dgcFieldNo.HeaderText = "Field No"
        Me.dgcFieldNo.Name = "dgcFieldNo"
        '
        'dgcGred
        '
        Me.dgcGred.DataPropertyName = "Gred"
        Me.dgcGred.HeaderText = "Gred"
        Me.dgcGred.Name = "dgcGred"
        '
        'tcAdvancePayment
        '
        Me.tcAdvancePayment.Controls.Add(Me.tabAdvancePayment)
        Me.tcAdvancePayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcAdvancePayment.Location = New System.Drawing.Point(0, 0)
        Me.tcAdvancePayment.Name = "tcAdvancePayment"
        Me.tcAdvancePayment.SelectedIndex = 0
        Me.tcAdvancePayment.Size = New System.Drawing.Size(916, 550)
        Me.tcAdvancePayment.TabIndex = 204
        '
        'EstateGrading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(916, 550)
        Me.Controls.Add(Me.tcAdvancePayment)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "EstateGrading"
        Me.Text = "AdvancePayment"
        Me.cmsAdvancePaymentDet.ResumeLayout(False)
        Me.tabAdvancePayment.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbEnquipmentData.ResumeLayout(False)
        CType(Me.dgvEstateGrading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcAdvancePayment.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsAdvancePaymentDet As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteMIAdvancePaymentDet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabAdvancePayment As System.Windows.Forms.TabPage
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblMandorValue As System.Windows.Forms.Label
    Friend WithEvents txtMandor As System.Windows.Forms.TextBox
    Friend WithEvents BtnAfdelingLookUp As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFieldNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtGangTeam As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAfdeling As System.Windows.Forms.TextBox
    Friend WithEvents dtpMonth As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEstate As System.Windows.Forms.TextBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblAPremium As System.Windows.Forms.Label
    Friend WithEvents lblColon3 As System.Windows.Forms.Label
    Friend WithEvents lblColon2 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents gbEnquipmentData As System.Windows.Forms.GroupBox
    Friend WithEvents dgvEstateGrading As System.Windows.Forms.DataGridView
    Friend WithEvents dgcMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcEstate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcAfdeling As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcMandor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcGangTeam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcFieldNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcGred As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tcAdvancePayment As System.Windows.Forms.TabControl
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents txtGred As System.Windows.Forms.TextBox
    Friend WithEvents lblGredValue As System.Windows.Forms.Label
    Friend WithEvents lblFieldNoValue As System.Windows.Forms.Label
    Friend WithEvents lblGangTeamValue As System.Windows.Forms.Label
    Friend WithEvents lblAfdelingValue As System.Windows.Forms.Label
    Friend WithEvents lblEstateValue As System.Windows.Forms.Label
    Friend WithEvents BtnGredLookUp As System.Windows.Forms.Button
    Friend WithEvents BtnGangLookUp As System.Windows.Forms.Button
    Friend WithEvents BtnFieldNoLookUp As System.Windows.Forms.Button
    Friend WithEvents BtnMasterLookUp As System.Windows.Forms.Button
    Friend WithEvents BtnEstateLookUp As System.Windows.Forms.Button
End Class

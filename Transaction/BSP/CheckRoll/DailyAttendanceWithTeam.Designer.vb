<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyAttendanceWithTeam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DailyAttendanceWithTeam))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tcDailyAttendance = New System.Windows.Forms.TabControl()
        Me.tabInput = New System.Windows.Forms.TabPage()
        Me.lblTotalOT = New System.Windows.Forms.Label()
        Me.BtnCalculate = New System.Windows.Forms.Button()
        Me.LblTtlHK = New System.Windows.Forms.Label()
        Me.LblLTtlHK = New System.Windows.Forms.Label()
        Me.lblTotalHK = New System.Windows.Forms.Label()
        Me.lblLTotalOT = New System.Windows.Forms.Label()
        Me.lblLTotalHK = New System.Windows.Forms.Label()
        Me.lblBrondalanValue = New System.Windows.Forms.Label()
        Me.lblHa = New System.Windows.Forms.Label()
        Me.lblHaValue = New System.Windows.Forms.Label()
        Me.lblBrondalan = New System.Windows.Forms.Label()
        Me.lblJjgActualNormal = New System.Windows.Forms.Label()
        Me.lblJjgActualBorongan = New System.Windows.Forms.Label()
        Me.lblBrdNormal = New System.Windows.Forms.Label()
        Me.lblBrdBorongan = New System.Windows.Forms.Label()
        Me.lblJJGActB = New System.Windows.Forms.Label()
        Me.lblBrdN = New System.Windows.Forms.Label()
        Me.lblBrdB = New System.Windows.Forms.Label()
        Me.lblJJGActN = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvDailyAttendance = New System.Windows.Forms.DataGridView()
        Me.DARDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DAGangNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DAEmpCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcOldNIK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DAEmpNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DAAttendanceCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DADistributionSetupIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DADistributionColumn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DAConcurrencyIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DATotalOTColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DAAttendanceSetupIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DAColumnTotalOTValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsDailyAttendance = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditMIDA = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.btnSearchLocation = New System.Windows.Forms.Button()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalOTValue = New System.Windows.Forms.TextBox()
        Me.txtBasicRate = New System.Windows.Forms.TextBox()
        Me.txtOTResult = New System.Windows.Forms.TextBox()
        Me.txtH4 = New System.Windows.Forms.TextBox()
        Me.txtMax4 = New System.Windows.Forms.TextBox()
        Me.txtH3 = New System.Windows.Forms.TextBox()
        Me.txtMax3 = New System.Windows.Forms.TextBox()
        Me.txtH2 = New System.Windows.Forms.TextBox()
        Me.txtOT4 = New System.Windows.Forms.TextBox()
        Me.txtMax2 = New System.Windows.Forms.TextBox()
        Me.txtOT3 = New System.Windows.Forms.TextBox()
        Me.txtH1 = New System.Windows.Forms.TextBox()
        Me.txtOT2 = New System.Windows.Forms.TextBox()
        Me.txtMax1 = New System.Windows.Forms.TextBox()
        Me.txtOT1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDailyTeamActivityID = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblEmpCategory = New System.Windows.Forms.Label()
        Me.lblEmpId = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblOldNIK = New System.Windows.Forms.Label()
        Me.lblRestDay = New System.Windows.Forms.Label()
        Me.LblBasicPay = New System.Windows.Forms.Label()
        Me.lblAttendanceSetupID = New System.Windows.Forms.Label()
        Me.txtOTHours = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAttendType = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAttendanceSetupLookup = New System.Windows.Forms.Button()
        Me.lblColon6 = New System.Windows.Forms.Label()
        Me.lblBNik = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblAttCode = New System.Windows.Forms.Label()
        Me.lblColon2 = New System.Windows.Forms.Label()
        Me.lblColon8 = New System.Windows.Forms.Label()
        Me.lblColon4 = New System.Windows.Forms.Label()
        Me.txtNIK = New System.Windows.Forms.TextBox()
        Me.txtAttendanceCode = New System.Windows.Forms.TextBox()
        Me.lblEmpName = New System.Windows.Forms.Label()
        Me.lblDistributionSetupID = New System.Windows.Forms.Label()
        Me.lblActivity = New System.Windows.Forms.Label()
        Me.lblGangMasterID = New System.Windows.Forms.Label()
        Me.dtpRDate = New System.Windows.Forms.DateTimePicker()
        Me.DgvOTDetail = New System.Windows.Forms.DataGridView()
        Me.lblKraniEmpName = New System.Windows.Forms.Label()
        Me.lblKraniID = New System.Windows.Forms.Label()
        Me.lblMandorEmpName = New System.Windows.Forms.Label()
        Me.lblDailyReceiptionID = New System.Windows.Forms.Label()
        Me.lblMandoreID = New System.Windows.Forms.Label()
        Me.btnTeamLookup = New System.Windows.Forms.Button()
        Me.txtTeam = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTeam = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblColon1 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnActivity = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnEditOrUpdate = New System.Windows.Forms.Button()
        Me.tabView = New System.Windows.Forms.TabPage()
        Me.dgvDailyAWTView = New System.Windows.Forms.DataGridView()
        Me.RDateViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GangNameViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MandorViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KraniViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActivityViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyTeamActivityIDViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GangMasterIDViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MandoreIDViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KraniIDViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlCategorySearch = New Stepi.UI.ExtendedPanel()
        Me.btnProcessOT = New System.Windows.Forms.Button()
        Me.btnProcessPremi = New System.Windows.Forms.Button()
        Me.btnAttendanceReport = New System.Windows.Forms.Button()
        Me.btnReceiptionReport = New System.Windows.Forms.Button()
        Me.txtTeamNameView = New System.Windows.Forms.TextBox()
        Me.txtMandorNameView = New System.Windows.Forms.TextBox()
        Me.cboActivityView = New System.Windows.Forms.ComboBox()
        Me.chkDateView = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.dtpRDateView = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnSearchView = New System.Windows.Forms.Button()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.lblviewDate = New System.Windows.Forms.Label()
        Me.lblviewTeam = New System.Windows.Forms.Label()
        Me.CmbTeam = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblTotalLatex = New System.Windows.Forms.Label()
        Me.lblTotalCupLump = New System.Windows.Forms.Label()
        Me.lblTotalTreelace = New System.Windows.Forms.Label()
        Me.tcDailyAttendance.SuspendLayout()
        Me.tabInput.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvDailyAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDailyAttendance.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DgvOTDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabView.SuspendLayout()
        CType(Me.dgvDailyAWTView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCategorySearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcDailyAttendance
        '
        Me.tcDailyAttendance.Controls.Add(Me.tabInput)
        Me.tcDailyAttendance.Controls.Add(Me.tabView)
        Me.tcDailyAttendance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcDailyAttendance.Location = New System.Drawing.Point(0, 0)
        Me.tcDailyAttendance.Name = "tcDailyAttendance"
        Me.tcDailyAttendance.SelectedIndex = 0
        Me.tcDailyAttendance.Size = New System.Drawing.Size(896, 592)
        Me.tcDailyAttendance.TabIndex = 0
        '
        'tabInput
        '
        Me.tabInput.AutoScroll = True
        Me.tabInput.BackColor = System.Drawing.Color.Transparent
        Me.tabInput.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tabInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabInput.Controls.Add(Me.lblTotalTreelace)
        Me.tabInput.Controls.Add(Me.lblTotalCupLump)
        Me.tabInput.Controls.Add(Me.lblTotalLatex)
        Me.tabInput.Controls.Add(Me.lblTotalOT)
        Me.tabInput.Controls.Add(Me.BtnCalculate)
        Me.tabInput.Controls.Add(Me.LblTtlHK)
        Me.tabInput.Controls.Add(Me.LblLTtlHK)
        Me.tabInput.Controls.Add(Me.lblTotalHK)
        Me.tabInput.Controls.Add(Me.lblLTotalOT)
        Me.tabInput.Controls.Add(Me.lblLTotalHK)
        Me.tabInput.Controls.Add(Me.lblBrondalanValue)
        Me.tabInput.Controls.Add(Me.lblHa)
        Me.tabInput.Controls.Add(Me.lblHaValue)
        Me.tabInput.Controls.Add(Me.lblBrondalan)
        Me.tabInput.Controls.Add(Me.lblJjgActualNormal)
        Me.tabInput.Controls.Add(Me.lblJjgActualBorongan)
        Me.tabInput.Controls.Add(Me.lblBrdNormal)
        Me.tabInput.Controls.Add(Me.lblBrdBorongan)
        Me.tabInput.Controls.Add(Me.lblJJGActB)
        Me.tabInput.Controls.Add(Me.lblBrdN)
        Me.tabInput.Controls.Add(Me.lblBrdB)
        Me.tabInput.Controls.Add(Me.lblJJGActN)
        Me.tabInput.Controls.Add(Me.GroupBox3)
        Me.tabInput.Controls.Add(Me.btnResetAll)
        Me.tabInput.Controls.Add(Me.btnReset)
        Me.tabInput.Controls.Add(Me.GroupBox2)
        Me.tabInput.Controls.Add(Me.GroupBox1)
        Me.tabInput.Controls.Add(Me.btnActivity)
        Me.tabInput.Controls.Add(Me.btnClose)
        Me.tabInput.Controls.Add(Me.btnSaveAll)
        Me.tabInput.Controls.Add(Me.btnEditOrUpdate)
        Me.tabInput.Location = New System.Drawing.Point(4, 22)
        Me.tabInput.Name = "tabInput"
        Me.tabInput.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInput.Size = New System.Drawing.Size(888, 566)
        Me.tabInput.TabIndex = 0
        Me.tabInput.Text = "Daily Attendance With Team"
        Me.tabInput.UseVisualStyleBackColor = True
        '
        'lblTotalOT
        '
        Me.lblTotalOT.AutoSize = True
        Me.lblTotalOT.Location = New System.Drawing.Point(520, 183)
        Me.lblTotalOT.Name = "lblTotalOT"
        Me.lblTotalOT.Size = New System.Drawing.Size(0, 13)
        Me.lblTotalOT.TabIndex = 178
        '
        'BtnCalculate
        '
        Me.BtnCalculate.BackgroundImage = CType(resources.GetObject("BtnCalculate.BackgroundImage"), System.Drawing.Image)
        Me.BtnCalculate.Enabled = False
        Me.BtnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCalculate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCalculate.Location = New System.Drawing.Point(224, 176)
        Me.BtnCalculate.Name = "BtnCalculate"
        Me.BtnCalculate.Size = New System.Drawing.Size(95, 25)
        Me.BtnCalculate.TabIndex = 183
        Me.BtnCalculate.Text = "Calculate Premi"
        Me.BtnCalculate.UseVisualStyleBackColor = True
        '
        'LblTtlHK
        '
        Me.LblTtlHK.AutoSize = True
        Me.LblTtlHK.Location = New System.Drawing.Point(779, 522)
        Me.LblTtlHK.Name = "LblTtlHK"
        Me.LblTtlHK.Size = New System.Drawing.Size(0, 13)
        Me.LblTtlHK.TabIndex = 182
        '
        'LblLTtlHK
        '
        Me.LblLTtlHK.AutoSize = True
        Me.LblLTtlHK.Location = New System.Drawing.Point(688, 522)
        Me.LblLTtlHK.Name = "LblLTtlHK"
        Me.LblLTtlHK.Size = New System.Drawing.Size(55, 13)
        Me.LblLTtlHK.TabIndex = 181
        Me.LblLTtlHK.Text = "Total HK :"
        '
        'lblTotalHK
        '
        Me.lblTotalHK.AutoSize = True
        Me.lblTotalHK.Location = New System.Drawing.Point(396, 182)
        Me.lblTotalHK.Name = "lblTotalHK"
        Me.lblTotalHK.Size = New System.Drawing.Size(0, 13)
        Me.lblTotalHK.TabIndex = 180
        '
        'lblLTotalOT
        '
        Me.lblLTotalOT.AutoSize = True
        Me.lblLTotalOT.Location = New System.Drawing.Point(459, 182)
        Me.lblLTotalOT.Name = "lblLTotalOT"
        Me.lblLTotalOT.Size = New System.Drawing.Size(55, 13)
        Me.lblLTotalOT.TabIndex = 179
        Me.lblLTotalOT.Text = "Total OT :"
        '
        'lblLTotalHK
        '
        Me.lblLTotalHK.AutoSize = True
        Me.lblLTotalHK.Location = New System.Drawing.Point(339, 182)
        Me.lblLTotalHK.Name = "lblLTotalHK"
        Me.lblLTotalHK.Size = New System.Drawing.Size(55, 13)
        Me.lblLTotalHK.TabIndex = 177
        Me.lblLTotalHK.Text = "Total HK :"
        '
        'lblBrondalanValue
        '
        Me.lblBrondalanValue.AutoSize = True
        Me.lblBrondalanValue.Location = New System.Drawing.Point(671, 182)
        Me.lblBrondalanValue.Name = "lblBrondalanValue"
        Me.lblBrondalanValue.Size = New System.Drawing.Size(0, 13)
        Me.lblBrondalanValue.TabIndex = 176
        '
        'lblHa
        '
        Me.lblHa.AutoSize = True
        Me.lblHa.Location = New System.Drawing.Point(735, 181)
        Me.lblHa.Name = "lblHa"
        Me.lblHa.Size = New System.Drawing.Size(27, 13)
        Me.lblHa.TabIndex = 175
        Me.lblHa.Text = "Ha :"
        '
        'lblHaValue
        '
        Me.lblHaValue.AutoSize = True
        Me.lblHaValue.Location = New System.Drawing.Point(771, 183)
        Me.lblHaValue.Name = "lblHaValue"
        Me.lblHaValue.Size = New System.Drawing.Size(0, 13)
        Me.lblHaValue.TabIndex = 174
        '
        'lblBrondalan
        '
        Me.lblBrondalan.AutoSize = True
        Me.lblBrondalan.Location = New System.Drawing.Point(607, 181)
        Me.lblBrondalan.Name = "lblBrondalan"
        Me.lblBrondalan.Size = New System.Drawing.Size(61, 13)
        Me.lblBrondalan.TabIndex = 173
        Me.lblBrondalan.Text = "Brondalan :"
        '
        'lblJjgActualNormal
        '
        Me.lblJjgActualNormal.AutoSize = True
        Me.lblJjgActualNormal.Location = New System.Drawing.Point(458, 522)
        Me.lblJjgActualNormal.Name = "lblJjgActualNormal"
        Me.lblJjgActualNormal.Size = New System.Drawing.Size(0, 13)
        Me.lblJjgActualNormal.TabIndex = 172
        '
        'lblJjgActualBorongan
        '
        Me.lblJjgActualBorongan.AutoSize = True
        Me.lblJjgActualBorongan.Location = New System.Drawing.Point(458, 548)
        Me.lblJjgActualBorongan.Name = "lblJjgActualBorongan"
        Me.lblJjgActualBorongan.Size = New System.Drawing.Size(0, 13)
        Me.lblJjgActualBorongan.TabIndex = 171
        '
        'lblBrdNormal
        '
        Me.lblBrdNormal.AutoSize = True
        Me.lblBrdNormal.Location = New System.Drawing.Point(645, 522)
        Me.lblBrdNormal.Name = "lblBrdNormal"
        Me.lblBrdNormal.Size = New System.Drawing.Size(0, 13)
        Me.lblBrdNormal.TabIndex = 170
        '
        'lblBrdBorongan
        '
        Me.lblBrdBorongan.AutoSize = True
        Me.lblBrdBorongan.Location = New System.Drawing.Point(645, 548)
        Me.lblBrdBorongan.Name = "lblBrdBorongan"
        Me.lblBrdBorongan.Size = New System.Drawing.Size(0, 13)
        Me.lblBrdBorongan.TabIndex = 169
        '
        'lblJJGActB
        '
        Me.lblJJGActB.AutoSize = True
        Me.lblJJGActB.Location = New System.Drawing.Point(335, 548)
        Me.lblJJGActB.Name = "lblJJGActB"
        Me.lblJJGActB.Size = New System.Drawing.Size(108, 13)
        Me.lblJJGActB.TabIndex = 168
        Me.lblJJGActB.Text = "Jjg Actual Borongan :"
        '
        'lblBrdN
        '
        Me.lblBrdN.AutoSize = True
        Me.lblBrdN.Location = New System.Drawing.Point(544, 522)
        Me.lblBrdN.Name = "lblBrdN"
        Me.lblBrdN.Size = New System.Drawing.Size(65, 13)
        Me.lblBrdN.TabIndex = 167
        Me.lblBrdN.Text = "Brd Normal :"
        '
        'lblBrdB
        '
        Me.lblBrdB.AutoSize = True
        Me.lblBrdB.Location = New System.Drawing.Point(544, 548)
        Me.lblBrdB.Name = "lblBrdB"
        Me.lblBrdB.Size = New System.Drawing.Size(78, 13)
        Me.lblBrdB.TabIndex = 166
        Me.lblBrdB.Text = "Brd Borongan :"
        '
        'lblJJGActN
        '
        Me.lblJJGActN.AutoSize = True
        Me.lblJJGActN.Location = New System.Drawing.Point(348, 522)
        Me.lblJJGActN.Name = "lblJJGActN"
        Me.lblJJGActN.Size = New System.Drawing.Size(95, 13)
        Me.lblJJGActN.TabIndex = 165
        Me.lblJJGActN.Text = "Jjg Actual Normal :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.dgvDailyAttendance)
        Me.GroupBox3.Controls.Add(Me.lblLocation)
        Me.GroupBox3.Controls.Add(Me.txtLocation)
        Me.GroupBox3.Controls.Add(Me.btnSearchLocation)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 206)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(886, 308)
        Me.GroupBox3.TabIndex = 143
        Me.GroupBox3.TabStop = False
        '
        'dgvDailyAttendance
        '
        Me.dgvDailyAttendance.AllowUserToAddRows = False
        Me.dgvDailyAttendance.AllowUserToDeleteRows = False
        Me.dgvDailyAttendance.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvDailyAttendance.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDailyAttendance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDailyAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDailyAttendance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDailyAttendance.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvDailyAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDailyAttendance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDailyAttendance.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDailyAttendance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DARDateColumn, Me.DAGangNameColumn, Me.DAEmpCodeColumn, Me.dgcOldNIK, Me.DAEmpNameColumn, Me.dgcCategory, Me.DAAttendanceCodeColumn, Me.DADistributionSetupIDColumn, Me.DADistributionColumn, Me.DAConcurrencyIdColumn, Me.DATotalOTColumn, Me.DAAttendanceSetupIDColumn, Me.DAColumnTotalOTValue})
        Me.dgvDailyAttendance.ContextMenuStrip = Me.cmsDailyAttendance
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDailyAttendance.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDailyAttendance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvDailyAttendance.EnableHeadersVisualStyles = False
        Me.dgvDailyAttendance.GridColor = System.Drawing.Color.Gray
        Me.dgvDailyAttendance.Location = New System.Drawing.Point(9, 18)
        Me.dgvDailyAttendance.MultiSelect = False
        Me.dgvDailyAttendance.Name = "dgvDailyAttendance"
        Me.dgvDailyAttendance.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDailyAttendance.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDailyAttendance.RowHeadersVisible = False
        Me.dgvDailyAttendance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvDailyAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDailyAttendance.ShowCellErrors = False
        Me.dgvDailyAttendance.Size = New System.Drawing.Size(855, 290)
        Me.dgvDailyAttendance.TabIndex = 6
        '
        'DARDateColumn
        '
        Me.DARDateColumn.DataPropertyName = "RDate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        Me.DARDateColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DARDateColumn.HeaderText = "Date"
        Me.DARDateColumn.Name = "DARDateColumn"
        Me.DARDateColumn.ReadOnly = True
        Me.DARDateColumn.Width = 58
        '
        'DAGangNameColumn
        '
        Me.DAGangNameColumn.DataPropertyName = "GangName"
        Me.DAGangNameColumn.HeaderText = "Team"
        Me.DAGangNameColumn.Name = "DAGangNameColumn"
        Me.DAGangNameColumn.ReadOnly = True
        Me.DAGangNameColumn.Width = 62
        '
        'DAEmpCodeColumn
        '
        Me.DAEmpCodeColumn.DataPropertyName = "EmpCode"
        Me.DAEmpCodeColumn.HeaderText = "Nik"
        Me.DAEmpCodeColumn.Name = "DAEmpCodeColumn"
        Me.DAEmpCodeColumn.ReadOnly = True
        Me.DAEmpCodeColumn.Width = 49
        '
        'dgcOldNIK
        '
        Me.dgcOldNIK.DataPropertyName = "AccountNo"
        Me.dgcOldNIK.HeaderText = "Old NIK"
        Me.dgcOldNIK.Name = "dgcOldNIK"
        Me.dgcOldNIK.ReadOnly = True
        Me.dgcOldNIK.Width = 75
        '
        'DAEmpNameColumn
        '
        Me.DAEmpNameColumn.DataPropertyName = "EmpName"
        Me.DAEmpNameColumn.HeaderText = "Name"
        Me.DAEmpNameColumn.Name = "DAEmpNameColumn"
        Me.DAEmpNameColumn.ReadOnly = True
        Me.DAEmpNameColumn.Width = 64
        '
        'dgcCategory
        '
        Me.dgcCategory.DataPropertyName = "Category"
        Me.dgcCategory.HeaderText = "Category"
        Me.dgcCategory.Name = "dgcCategory"
        Me.dgcCategory.ReadOnly = True
        Me.dgcCategory.Width = 84
        '
        'DAAttendanceCodeColumn
        '
        Me.DAAttendanceCodeColumn.DataPropertyName = "AttendanceCode"
        Me.DAAttendanceCodeColumn.HeaderText = "Att Code"
        Me.DAAttendanceCodeColumn.Name = "DAAttendanceCodeColumn"
        Me.DAAttendanceCodeColumn.ReadOnly = True
        Me.DAAttendanceCodeColumn.Width = 81
        '
        'DADistributionSetupIDColumn
        '
        Me.DADistributionSetupIDColumn.DataPropertyName = "DistributionSetupID"
        Me.DADistributionSetupIDColumn.HeaderText = "Location"
        Me.DADistributionSetupIDColumn.Name = "DADistributionSetupIDColumn"
        Me.DADistributionSetupIDColumn.ReadOnly = True
        Me.DADistributionSetupIDColumn.Width = 78
        '
        'DADistributionColumn
        '
        Me.DADistributionColumn.HeaderText = "Distribution"
        Me.DADistributionColumn.Name = "DADistributionColumn"
        Me.DADistributionColumn.ReadOnly = True
        Me.DADistributionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DADistributionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DADistributionColumn.Text = "Reception"
        Me.DADistributionColumn.ToolTipText = "Reception"
        Me.DADistributionColumn.Width = 96
        '
        'DAConcurrencyIdColumn
        '
        Me.DAConcurrencyIdColumn.DataPropertyName = "ConcurrencyId"
        Me.DAConcurrencyIdColumn.HeaderText = "ConcurrencyId"
        Me.DAConcurrencyIdColumn.Name = "DAConcurrencyIdColumn"
        Me.DAConcurrencyIdColumn.ReadOnly = True
        Me.DAConcurrencyIdColumn.Width = 116
        '
        'DATotalOTColumn
        '
        Me.DATotalOTColumn.DataPropertyName = "TotalOT"
        Me.DATotalOTColumn.HeaderText = "Daily OT"
        Me.DATotalOTColumn.Name = "DATotalOTColumn"
        Me.DATotalOTColumn.ReadOnly = True
        Me.DATotalOTColumn.Visible = False
        Me.DATotalOTColumn.Width = 80
        '
        'DAAttendanceSetupIDColumn
        '
        Me.DAAttendanceSetupIDColumn.DataPropertyName = "AttendanceSetupID"
        Me.DAAttendanceSetupIDColumn.HeaderText = "AttendanceSetupID"
        Me.DAAttendanceSetupIDColumn.Name = "DAAttendanceSetupIDColumn"
        Me.DAAttendanceSetupIDColumn.ReadOnly = True
        Me.DAAttendanceSetupIDColumn.Width = 142
        '
        'DAColumnTotalOTValue
        '
        Me.DAColumnTotalOTValue.DataPropertyName = "TotalOTValue"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.DAColumnTotalOTValue.DefaultCellStyle = DataGridViewCellStyle4
        Me.DAColumnTotalOTValue.HeaderText = "TotalOTValue"
        Me.DAColumnTotalOTValue.Name = "DAColumnTotalOTValue"
        Me.DAColumnTotalOTValue.ReadOnly = True
        Me.DAColumnTotalOTValue.Visible = False
        Me.DAColumnTotalOTValue.Width = 107
        '
        'cmsDailyAttendance
        '
        Me.cmsDailyAttendance.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditMIDA})
        Me.cmsDailyAttendance.Name = "cmsDailyAttendance"
        Me.cmsDailyAttendance.Size = New System.Drawing.Size(95, 26)
        '
        'EditMIDA
        '
        Me.EditMIDA.Name = "EditMIDA"
        Me.EditMIDA.Size = New System.Drawing.Size(94, 22)
        Me.EditMIDA.Text = "Edit"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.Location = New System.Drawing.Point(596, 105)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(58, 13)
        Me.lblLocation.TabIndex = 168
        Me.lblLocation.Text = "Location "
        Me.lblLocation.Visible = False
        '
        'txtLocation
        '
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(660, 99)
        Me.txtLocation.MaxLength = 50
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(135, 21)
        Me.txtLocation.TabIndex = 163
        Me.txtLocation.Visible = False
        '
        'btnSearchLocation
        '
        Me.btnSearchLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchLocation.Image = CType(resources.GetObject("btnSearchLocation.Image"), System.Drawing.Image)
        Me.btnSearchLocation.Location = New System.Drawing.Point(801, 99)
        Me.btnSearchLocation.Name = "btnSearchLocation"
        Me.btnSearchLocation.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchLocation.TabIndex = 164
        Me.btnSearchLocation.UseVisualStyleBackColor = True
        Me.btnSearchLocation.Visible = False
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = CType(resources.GetObject("btnResetAll.BackgroundImage"), System.Drawing.Image)
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAll.Image = CType(resources.GetObject("btnResetAll.Image"), System.Drawing.Image)
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.Location = New System.Drawing.Point(112, 520)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(95, 30)
        Me.btnResetAll.TabIndex = 8
        Me.btnResetAll.Text = "&Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.Enabled = False
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(122, 176)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 25)
        Me.btnReset.TabIndex = 6
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtTotalOTValue)
        Me.GroupBox2.Controls.Add(Me.txtBasicRate)
        Me.GroupBox2.Controls.Add(Me.txtOTResult)
        Me.GroupBox2.Controls.Add(Me.txtH4)
        Me.GroupBox2.Controls.Add(Me.txtMax4)
        Me.GroupBox2.Controls.Add(Me.txtH3)
        Me.GroupBox2.Controls.Add(Me.txtMax3)
        Me.GroupBox2.Controls.Add(Me.txtH2)
        Me.GroupBox2.Controls.Add(Me.txtOT4)
        Me.GroupBox2.Controls.Add(Me.txtMax2)
        Me.GroupBox2.Controls.Add(Me.txtOT3)
        Me.GroupBox2.Controls.Add(Me.txtH1)
        Me.GroupBox2.Controls.Add(Me.txtOT2)
        Me.GroupBox2.Controls.Add(Me.txtMax1)
        Me.GroupBox2.Controls.Add(Me.txtOT1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(866, 40)
        Me.GroupBox2.TabIndex = 162
        Me.GroupBox2.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(774, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 13)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "TotalOTValue"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(665, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "BasicRate"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(596, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 13)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Hasil OT"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(533, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(22, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "H4"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(392, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "H3"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(242, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "H2"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(101, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "H1"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(492, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 13)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Max4"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(350, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Max3"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(200, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Max2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(60, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Max1"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(451, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(30, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "OT4"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(307, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "OT3"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(159, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "OT2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "OT1"
        '
        'txtTotalOTValue
        '
        Me.txtTotalOTValue.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotalOTValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalOTValue.Enabled = False
        Me.txtTotalOTValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalOTValue.Location = New System.Drawing.Point(777, 32)
        Me.txtTotalOTValue.MaxLength = 50
        Me.txtTotalOTValue.Name = "txtTotalOTValue"
        Me.txtTotalOTValue.Size = New System.Drawing.Size(80, 21)
        Me.txtTotalOTValue.TabIndex = 3
        '
        'txtBasicRate
        '
        Me.txtBasicRate.BackColor = System.Drawing.SystemColors.Window
        Me.txtBasicRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBasicRate.Enabled = False
        Me.txtBasicRate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBasicRate.Location = New System.Drawing.Point(668, 32)
        Me.txtBasicRate.MaxLength = 50
        Me.txtBasicRate.Name = "txtBasicRate"
        Me.txtBasicRate.Size = New System.Drawing.Size(69, 21)
        Me.txtBasicRate.TabIndex = 3
        '
        'txtOTResult
        '
        Me.txtOTResult.BackColor = System.Drawing.SystemColors.Window
        Me.txtOTResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOTResult.Enabled = False
        Me.txtOTResult.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOTResult.Location = New System.Drawing.Point(599, 32)
        Me.txtOTResult.MaxLength = 50
        Me.txtOTResult.Name = "txtOTResult"
        Me.txtOTResult.Size = New System.Drawing.Size(45, 21)
        Me.txtOTResult.TabIndex = 3
        '
        'txtH4
        '
        Me.txtH4.BackColor = System.Drawing.SystemColors.Window
        Me.txtH4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtH4.Enabled = False
        Me.txtH4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtH4.Location = New System.Drawing.Point(536, 32)
        Me.txtH4.MaxLength = 50
        Me.txtH4.Name = "txtH4"
        Me.txtH4.Size = New System.Drawing.Size(38, 21)
        Me.txtH4.TabIndex = 3
        '
        'txtMax4
        '
        Me.txtMax4.BackColor = System.Drawing.SystemColors.Window
        Me.txtMax4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMax4.Enabled = False
        Me.txtMax4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMax4.Location = New System.Drawing.Point(495, 32)
        Me.txtMax4.MaxLength = 50
        Me.txtMax4.Name = "txtMax4"
        Me.txtMax4.Size = New System.Drawing.Size(38, 21)
        Me.txtMax4.TabIndex = 3
        Me.txtMax4.Text = "2"
        '
        'txtH3
        '
        Me.txtH3.BackColor = System.Drawing.SystemColors.Window
        Me.txtH3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtH3.Enabled = False
        Me.txtH3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtH3.Location = New System.Drawing.Point(395, 32)
        Me.txtH3.MaxLength = 50
        Me.txtH3.Name = "txtH3"
        Me.txtH3.Size = New System.Drawing.Size(38, 21)
        Me.txtH3.TabIndex = 3
        '
        'txtMax3
        '
        Me.txtMax3.BackColor = System.Drawing.SystemColors.Window
        Me.txtMax3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMax3.Enabled = False
        Me.txtMax3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMax3.Location = New System.Drawing.Point(353, 32)
        Me.txtMax3.MaxLength = 50
        Me.txtMax3.Name = "txtMax3"
        Me.txtMax3.Size = New System.Drawing.Size(38, 21)
        Me.txtMax3.TabIndex = 3
        Me.txtMax3.Text = "1"
        '
        'txtH2
        '
        Me.txtH2.BackColor = System.Drawing.SystemColors.Window
        Me.txtH2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtH2.Enabled = False
        Me.txtH2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtH2.Location = New System.Drawing.Point(245, 32)
        Me.txtH2.MaxLength = 50
        Me.txtH2.Name = "txtH2"
        Me.txtH2.Size = New System.Drawing.Size(38, 21)
        Me.txtH2.TabIndex = 3
        '
        'txtOT4
        '
        Me.txtOT4.BackColor = System.Drawing.SystemColors.Window
        Me.txtOT4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOT4.Enabled = False
        Me.txtOT4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOT4.Location = New System.Drawing.Point(455, 32)
        Me.txtOT4.MaxLength = 50
        Me.txtOT4.Name = "txtOT4"
        Me.txtOT4.Size = New System.Drawing.Size(38, 21)
        Me.txtOT4.TabIndex = 3
        Me.txtOT4.Text = "4"
        '
        'txtMax2
        '
        Me.txtMax2.BackColor = System.Drawing.SystemColors.Window
        Me.txtMax2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMax2.Enabled = False
        Me.txtMax2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMax2.Location = New System.Drawing.Point(203, 32)
        Me.txtMax2.MaxLength = 50
        Me.txtMax2.Name = "txtMax2"
        Me.txtMax2.Size = New System.Drawing.Size(38, 21)
        Me.txtMax2.TabIndex = 3
        Me.txtMax2.Text = "7"
        '
        'txtOT3
        '
        Me.txtOT3.BackColor = System.Drawing.SystemColors.Window
        Me.txtOT3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOT3.Enabled = False
        Me.txtOT3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOT3.Location = New System.Drawing.Point(311, 32)
        Me.txtOT3.MaxLength = 50
        Me.txtOT3.Name = "txtOT3"
        Me.txtOT3.Size = New System.Drawing.Size(38, 21)
        Me.txtOT3.TabIndex = 3
        Me.txtOT3.Text = "3"
        '
        'txtH1
        '
        Me.txtH1.BackColor = System.Drawing.SystemColors.Window
        Me.txtH1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtH1.Enabled = False
        Me.txtH1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtH1.Location = New System.Drawing.Point(104, 32)
        Me.txtH1.MaxLength = 50
        Me.txtH1.Name = "txtH1"
        Me.txtH1.Size = New System.Drawing.Size(38, 21)
        Me.txtH1.TabIndex = 3
        '
        'txtOT2
        '
        Me.txtOT2.BackColor = System.Drawing.SystemColors.Window
        Me.txtOT2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOT2.Enabled = False
        Me.txtOT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOT2.Location = New System.Drawing.Point(163, 32)
        Me.txtOT2.MaxLength = 50
        Me.txtOT2.Name = "txtOT2"
        Me.txtOT2.Size = New System.Drawing.Size(38, 21)
        Me.txtOT2.TabIndex = 3
        Me.txtOT2.Text = "2"
        '
        'txtMax1
        '
        Me.txtMax1.BackColor = System.Drawing.SystemColors.Window
        Me.txtMax1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMax1.Enabled = False
        Me.txtMax1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMax1.Location = New System.Drawing.Point(63, 32)
        Me.txtMax1.MaxLength = 50
        Me.txtMax1.Name = "txtMax1"
        Me.txtMax1.Size = New System.Drawing.Size(38, 21)
        Me.txtMax1.TabIndex = 3
        Me.txtMax1.Text = "1"
        '
        'txtOT1
        '
        Me.txtOT1.BackColor = System.Drawing.SystemColors.Window
        Me.txtOT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOT1.Enabled = False
        Me.txtOT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOT1.Location = New System.Drawing.Point(22, 32)
        Me.txtOT1.MaxLength = 50
        Me.txtOT1.Name = "txtOT1"
        Me.txtOT1.Size = New System.Drawing.Size(38, 21)
        Me.txtOT1.TabIndex = 3
        Me.txtOT1.Text = "1.5"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblDailyTeamActivityID)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.lblEmpCategory)
        Me.GroupBox1.Controls.Add(Me.lblEmpId)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.lblDistributionSetupID)
        Me.GroupBox1.Controls.Add(Me.lblActivity)
        Me.GroupBox1.Controls.Add(Me.lblGangMasterID)
        Me.GroupBox1.Controls.Add(Me.dtpRDate)
        Me.GroupBox1.Controls.Add(Me.DgvOTDetail)
        Me.GroupBox1.Controls.Add(Me.lblKraniEmpName)
        Me.GroupBox1.Controls.Add(Me.lblKraniID)
        Me.GroupBox1.Controls.Add(Me.lblMandorEmpName)
        Me.GroupBox1.Controls.Add(Me.lblDailyReceiptionID)
        Me.GroupBox1.Controls.Add(Me.lblMandoreID)
        Me.GroupBox1.Controls.Add(Me.btnTeamLookup)
        Me.GroupBox1.Controls.Add(Me.txtTeam)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblTeam)
        Me.GroupBox1.Controls.Add(Me.lblDate)
        Me.GroupBox1.Controls.Add(Me.lblColon1)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(882, 164)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        '
        'lblDailyTeamActivityID
        '
        Me.lblDailyTeamActivityID.AutoSize = True
        Me.lblDailyTeamActivityID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDailyTeamActivityID.ForeColor = System.Drawing.Color.Blue
        Me.lblDailyTeamActivityID.Location = New System.Drawing.Point(718, 57)
        Me.lblDailyTeamActivityID.Name = "lblDailyTeamActivityID"
        Me.lblDailyTeamActivityID.Size = New System.Drawing.Size(123, 13)
        Me.lblDailyTeamActivityID.TabIndex = 145
        Me.lblDailyTeamActivityID.Text = "DailyTeamActivityID"
        Me.lblDailyTeamActivityID.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(581, 65)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(11, 13)
        Me.Label30.TabIndex = 162
        Me.Label30.Text = ":"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(478, 64)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(60, 13)
        Me.Label31.TabIndex = 161
        Me.Label31.Text = "Category"
        '
        'lblEmpCategory
        '
        Me.lblEmpCategory.AutoSize = True
        Me.lblEmpCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpCategory.ForeColor = System.Drawing.Color.Blue
        Me.lblEmpCategory.Location = New System.Drawing.Point(597, 64)
        Me.lblEmpCategory.Name = "lblEmpCategory"
        Me.lblEmpCategory.Size = New System.Drawing.Size(98, 13)
        Me.lblEmpCategory.TabIndex = 177
        Me.lblEmpCategory.Text = "lblEmpCategory"
        '
        'lblEmpId
        '
        Me.lblEmpId.AutoSize = True
        Me.lblEmpId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpId.ForeColor = System.Drawing.Color.Red
        Me.lblEmpId.Location = New System.Drawing.Point(718, 40)
        Me.lblEmpId.Name = "lblEmpId"
        Me.lblEmpId.Size = New System.Drawing.Size(57, 13)
        Me.lblEmpId.TabIndex = 160
        Me.lblEmpId.Text = "lblEmpId"
        Me.lblEmpId.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Controls.Add(Me.lblOldNIK)
        Me.GroupBox4.Controls.Add(Me.lblRestDay)
        Me.GroupBox4.Controls.Add(Me.LblBasicPay)
        Me.GroupBox4.Controls.Add(Me.lblAttendanceSetupID)
        Me.GroupBox4.Controls.Add(Me.txtOTHours)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.lblAttendType)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.btnAttendanceSetupLookup)
        Me.GroupBox4.Controls.Add(Me.lblColon6)
        Me.GroupBox4.Controls.Add(Me.lblBNik)
        Me.GroupBox4.Controls.Add(Me.lblName)
        Me.GroupBox4.Controls.Add(Me.lblAttCode)
        Me.GroupBox4.Controls.Add(Me.lblColon2)
        Me.GroupBox4.Controls.Add(Me.lblColon8)
        Me.GroupBox4.Controls.Add(Me.lblColon4)
        Me.GroupBox4.Controls.Add(Me.txtNIK)
        Me.GroupBox4.Controls.Add(Me.txtAttendanceCode)
        Me.GroupBox4.Controls.Add(Me.lblEmpName)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 80)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(854, 77)
        Me.GroupBox4.TabIndex = 159
        Me.GroupBox4.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(575, 28)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(11, 13)
        Me.Label27.TabIndex = 182
        Me.Label27.Text = ":"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(472, 28)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(51, 13)
        Me.Label29.TabIndex = 181
        Me.Label29.Text = "Old NIK"
        '
        'lblOldNIK
        '
        Me.lblOldNIK.AutoSize = True
        Me.lblOldNIK.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOldNIK.ForeColor = System.Drawing.Color.Blue
        Me.lblOldNIK.Location = New System.Drawing.Point(593, 28)
        Me.lblOldNIK.Name = "lblOldNIK"
        Me.lblOldNIK.Size = New System.Drawing.Size(51, 13)
        Me.lblOldNIK.TabIndex = 180
        Me.lblOldNIK.Text = "Old NIK"
        '
        'lblRestDay
        '
        Me.lblRestDay.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRestDay.ForeColor = System.Drawing.Color.Blue
        Me.lblRestDay.Location = New System.Drawing.Point(750, 57)
        Me.lblRestDay.Name = "lblRestDay"
        Me.lblRestDay.Size = New System.Drawing.Size(75, 13)
        Me.lblRestDay.TabIndex = 179
        Me.lblRestDay.Text = "lblRestDay"
        Me.lblRestDay.Visible = False
        '
        'LblBasicPay
        '
        Me.LblBasicPay.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBasicPay.ForeColor = System.Drawing.Color.Blue
        Me.LblBasicPay.Location = New System.Drawing.Point(750, 44)
        Me.LblBasicPay.Name = "LblBasicPay"
        Me.LblBasicPay.Size = New System.Drawing.Size(75, 13)
        Me.LblBasicPay.TabIndex = 179
        Me.LblBasicPay.Text = "lblBasicPay"
        Me.LblBasicPay.Visible = False
        '
        'lblAttendanceSetupID
        '
        Me.lblAttendanceSetupID.AutoSize = True
        Me.lblAttendanceSetupID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttendanceSetupID.ForeColor = System.Drawing.Color.Blue
        Me.lblAttendanceSetupID.Location = New System.Drawing.Point(314, 23)
        Me.lblAttendanceSetupID.Name = "lblAttendanceSetupID"
        Me.lblAttendanceSetupID.Size = New System.Drawing.Size(131, 13)
        Me.lblAttendanceSetupID.TabIndex = 178
        Me.lblAttendanceSetupID.Text = "lblAttendanceSetupID"
        Me.lblAttendanceSetupID.Visible = False
        '
        'txtOTHours
        '
        Me.txtOTHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOTHours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOTHours.Location = New System.Drawing.Point(593, 47)
        Me.txtOTHours.Name = "txtOTHours"
        Me.txtOTHours.Size = New System.Drawing.Size(76, 21)
        Me.txtOTHours.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(675, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 174
        Me.Label1.Text = "Hrs"
        '
        'lblAttendType
        '
        Me.lblAttendType.AutoSize = True
        Me.lblAttendType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttendType.ForeColor = System.Drawing.Color.Blue
        Me.lblAttendType.Location = New System.Drawing.Point(314, 52)
        Me.lblAttendType.Name = "lblAttendType"
        Me.lblAttendType.Size = New System.Drawing.Size(84, 13)
        Me.lblAttendType.TabIndex = 172
        Me.lblAttendType.Text = "lblAttendType"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(575, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(472, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 175
        Me.Label7.Text = "Daily OT"
        '
        'btnAttendanceSetupLookup
        '
        Me.btnAttendanceSetupLookup.Enabled = False
        Me.btnAttendanceSetupLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAttendanceSetupLookup.Image = CType(resources.GetObject("btnAttendanceSetupLookup.Image"), System.Drawing.Image)
        Me.btnAttendanceSetupLookup.Location = New System.Drawing.Point(269, 45)
        Me.btnAttendanceSetupLookup.Name = "btnAttendanceSetupLookup"
        Me.btnAttendanceSetupLookup.Size = New System.Drawing.Size(30, 26)
        Me.btnAttendanceSetupLookup.TabIndex = 162
        Me.btnAttendanceSetupLookup.TabStop = False
        Me.btnAttendanceSetupLookup.UseVisualStyleBackColor = True
        '
        'lblColon6
        '
        Me.lblColon6.AutoSize = True
        Me.lblColon6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon6.Location = New System.Drawing.Point(575, 11)
        Me.lblColon6.Name = "lblColon6"
        Me.lblColon6.Size = New System.Drawing.Size(11, 13)
        Me.lblColon6.TabIndex = 171
        Me.lblColon6.Text = ":"
        '
        'lblBNik
        '
        Me.lblBNik.AutoSize = True
        Me.lblBNik.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBNik.ForeColor = System.Drawing.Color.Black
        Me.lblBNik.Location = New System.Drawing.Point(7, 19)
        Me.lblBNik.Name = "lblBNik"
        Me.lblBNik.Size = New System.Drawing.Size(28, 13)
        Me.lblBNik.TabIndex = 158
        Me.lblBNik.Text = "NIK"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(472, 11)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(40, 13)
        Me.lblName.TabIndex = 170
        Me.lblName.Text = "Name"
        '
        'lblAttCode
        '
        Me.lblAttCode.AutoSize = True
        Me.lblAttCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttCode.ForeColor = System.Drawing.Color.Red
        Me.lblAttCode.Location = New System.Drawing.Point(7, 50)
        Me.lblAttCode.Name = "lblAttCode"
        Me.lblAttCode.Size = New System.Drawing.Size(105, 13)
        Me.lblAttCode.TabIndex = 160
        Me.lblAttCode.Text = "Attendance Code"
        '
        'lblColon2
        '
        Me.lblColon2.AutoSize = True
        Me.lblColon2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon2.Location = New System.Drawing.Point(110, 17)
        Me.lblColon2.Name = "lblColon2"
        Me.lblColon2.Size = New System.Drawing.Size(11, 13)
        Me.lblColon2.TabIndex = 165
        Me.lblColon2.Text = ":"
        '
        'lblColon8
        '
        Me.lblColon8.AutoSize = True
        Me.lblColon8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon8.Location = New System.Drawing.Point(528, 72)
        Me.lblColon8.Name = "lblColon8"
        Me.lblColon8.Size = New System.Drawing.Size(11, 13)
        Me.lblColon8.TabIndex = 169
        Me.lblColon8.Text = ":"
        Me.lblColon8.Visible = False
        '
        'lblColon4
        '
        Me.lblColon4.AutoSize = True
        Me.lblColon4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon4.Location = New System.Drawing.Point(111, 49)
        Me.lblColon4.Name = "lblColon4"
        Me.lblColon4.Size = New System.Drawing.Size(11, 13)
        Me.lblColon4.TabIndex = 166
        Me.lblColon4.Text = ":"
        '
        'txtNIK
        '
        Me.txtNIK.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtNIK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNIK.Enabled = False
        Me.txtNIK.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNIK.Location = New System.Drawing.Point(128, 15)
        Me.txtNIK.MaxLength = 50
        Me.txtNIK.Name = "txtNIK"
        Me.txtNIK.Size = New System.Drawing.Size(135, 21)
        Me.txtNIK.TabIndex = 2
        '
        'txtAttendanceCode
        '
        Me.txtAttendanceCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAttendanceCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAttendanceCode.Enabled = False
        Me.txtAttendanceCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttendanceCode.Location = New System.Drawing.Point(128, 48)
        Me.txtAttendanceCode.Name = "txtAttendanceCode"
        Me.txtAttendanceCode.Size = New System.Drawing.Size(135, 21)
        Me.txtAttendanceCode.TabIndex = 3
        '
        'lblEmpName
        '
        Me.lblEmpName.AutoSize = True
        Me.lblEmpName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpName.ForeColor = System.Drawing.Color.Blue
        Me.lblEmpName.Location = New System.Drawing.Point(593, 11)
        Me.lblEmpName.Name = "lblEmpName"
        Me.lblEmpName.Size = New System.Drawing.Size(40, 13)
        Me.lblEmpName.TabIndex = 167
        Me.lblEmpName.Text = "Name"
        '
        'lblDistributionSetupID
        '
        Me.lblDistributionSetupID.AutoSize = True
        Me.lblDistributionSetupID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistributionSetupID.Location = New System.Drawing.Point(718, 27)
        Me.lblDistributionSetupID.Name = "lblDistributionSetupID"
        Me.lblDistributionSetupID.Size = New System.Drawing.Size(132, 13)
        Me.lblDistributionSetupID.TabIndex = 158
        Me.lblDistributionSetupID.Text = "lblDistributionSetupID"
        Me.lblDistributionSetupID.Visible = False
        '
        'lblActivity
        '
        Me.lblActivity.AutoSize = True
        Me.lblActivity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivity.ForeColor = System.Drawing.Color.Red
        Me.lblActivity.Location = New System.Drawing.Point(320, 57)
        Me.lblActivity.Name = "lblActivity"
        Me.lblActivity.Size = New System.Drawing.Size(62, 13)
        Me.lblActivity.TabIndex = 155
        Me.lblActivity.Text = "lblActivity"
        '
        'lblGangMasterID
        '
        Me.lblGangMasterID.AutoSize = True
        Me.lblGangMasterID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGangMasterID.ForeColor = System.Drawing.Color.Red
        Me.lblGangMasterID.Location = New System.Drawing.Point(320, 25)
        Me.lblGangMasterID.Name = "lblGangMasterID"
        Me.lblGangMasterID.Size = New System.Drawing.Size(102, 13)
        Me.lblGangMasterID.TabIndex = 155
        Me.lblGangMasterID.Text = "lblGangMasterID"
        Me.lblGangMasterID.Visible = False
        '
        'dtpRDate
        '
        Me.dtpRDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRDate.Location = New System.Drawing.Point(134, 20)
        Me.dtpRDate.Name = "dtpRDate"
        Me.dtpRDate.Size = New System.Drawing.Size(135, 20)
        Me.dtpRDate.TabIndex = 0
        '
        'DgvOTDetail
        '
        Me.DgvOTDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvOTDetail.Location = New System.Drawing.Point(405, -6)
        Me.DgvOTDetail.Name = "DgvOTDetail"
        Me.DgvOTDetail.Size = New System.Drawing.Size(400, 27)
        Me.DgvOTDetail.TabIndex = 164
        Me.DgvOTDetail.Visible = False
        '
        'lblKraniEmpName
        '
        Me.lblKraniEmpName.AutoSize = True
        Me.lblKraniEmpName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKraniEmpName.ForeColor = System.Drawing.Color.Blue
        Me.lblKraniEmpName.Location = New System.Drawing.Point(596, 44)
        Me.lblKraniEmpName.Name = "lblKraniEmpName"
        Me.lblKraniEmpName.Size = New System.Drawing.Size(70, 13)
        Me.lblKraniEmpName.TabIndex = 145
        Me.lblKraniEmpName.Text = "KraniName"
        '
        'lblKraniID
        '
        Me.lblKraniID.AutoSize = True
        Me.lblKraniID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKraniID.ForeColor = System.Drawing.Color.Blue
        Me.lblKraniID.Location = New System.Drawing.Point(794, 78)
        Me.lblKraniID.Name = "lblKraniID"
        Me.lblKraniID.Size = New System.Drawing.Size(51, 13)
        Me.lblKraniID.TabIndex = 145
        Me.lblKraniID.Text = "KraniID"
        Me.lblKraniID.Visible = False
        '
        'lblMandorEmpName
        '
        Me.lblMandorEmpName.AutoSize = True
        Me.lblMandorEmpName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMandorEmpName.ForeColor = System.Drawing.Color.Blue
        Me.lblMandorEmpName.Location = New System.Drawing.Point(596, 24)
        Me.lblMandorEmpName.Name = "lblMandorEmpName"
        Me.lblMandorEmpName.Size = New System.Drawing.Size(89, 13)
        Me.lblMandorEmpName.TabIndex = 145
        Me.lblMandorEmpName.Text = "MandoreName"
        '
        'lblDailyReceiptionID
        '
        Me.lblDailyReceiptionID.AutoSize = True
        Me.lblDailyReceiptionID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDailyReceiptionID.ForeColor = System.Drawing.Color.Blue
        Me.lblDailyReceiptionID.Location = New System.Drawing.Point(522, 78)
        Me.lblDailyReceiptionID.Name = "lblDailyReceiptionID"
        Me.lblDailyReceiptionID.Size = New System.Drawing.Size(122, 13)
        Me.lblDailyReceiptionID.TabIndex = 145
        Me.lblDailyReceiptionID.Text = "lblDailyReceiptionID"
        Me.lblDailyReceiptionID.Visible = False
        '
        'lblMandoreID
        '
        Me.lblMandoreID.AutoSize = True
        Me.lblMandoreID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMandoreID.ForeColor = System.Drawing.Color.Blue
        Me.lblMandoreID.Location = New System.Drawing.Point(677, 78)
        Me.lblMandoreID.Name = "lblMandoreID"
        Me.lblMandoreID.Size = New System.Drawing.Size(70, 13)
        Me.lblMandoreID.TabIndex = 145
        Me.lblMandoreID.Text = "MandoreID"
        Me.lblMandoreID.Visible = False
        '
        'btnTeamLookup
        '
        Me.btnTeamLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTeamLookup.Image = CType(resources.GetObject("btnTeamLookup.Image"), System.Drawing.Image)
        Me.btnTeamLookup.Location = New System.Drawing.Point(275, 48)
        Me.btnTeamLookup.Name = "btnTeamLookup"
        Me.btnTeamLookup.Size = New System.Drawing.Size(30, 26)
        Me.btnTeamLookup.TabIndex = 2
        Me.btnTeamLookup.TabStop = False
        Me.btnTeamLookup.UseVisualStyleBackColor = True
        '
        'txtTeam
        '
        Me.txtTeam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTeam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeam.Location = New System.Drawing.Point(134, 53)
        Me.txtTeam.MaxLength = 50
        Me.txtTeam.Name = "txtTeam"
        Me.txtTeam.Size = New System.Drawing.Size(135, 21)
        Me.txtTeam.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(117, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = ":"
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTeam.ForeColor = System.Drawing.Color.Red
        Me.lblTeam.Location = New System.Drawing.Point(13, 54)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(38, 13)
        Me.lblTeam.TabIndex = 141
        Me.lblTeam.Text = "Team"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Red
        Me.lblDate.Location = New System.Drawing.Point(13, 24)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(34, 13)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Date"
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(117, 24)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(11, 13)
        Me.lblColon1.TabIndex = 19
        Me.lblColon1.Text = ":"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(581, 44)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(11, 13)
        Me.Label25.TabIndex = 121
        Me.Label25.Text = ":"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(581, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 121
        Me.Label23.Text = ":"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(478, 44)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 13)
        Me.Label24.TabIndex = 119
        Me.Label24.Text = "Krani Name"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(478, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(86, 13)
        Me.Label22.TabIndex = 119
        Me.Label22.Text = "Mandor Name"
        '
        'btnActivity
        '
        Me.btnActivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActivity.BackgroundImage = CType(resources.GetObject("btnActivity.BackgroundImage"), System.Drawing.Image)
        Me.btnActivity.Enabled = False
        Me.btnActivity.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnActivity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActivity.Image = CType(resources.GetObject("btnActivity.Image"), System.Drawing.Image)
        Me.btnActivity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActivity.Location = New System.Drawing.Point(749, 520)
        Me.btnActivity.Name = "btnActivity"
        Me.btnActivity.Size = New System.Drawing.Size(139, 30)
        Me.btnActivity.TabIndex = 10
        Me.btnActivity.Text = "&Activity"
        Me.btnActivity.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(209, 520)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 30)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = CType(resources.GetObject("btnSaveAll.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(5, 520)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(105, 30)
        Me.btnSaveAll.TabIndex = 7
        Me.btnSaveAll.Text = "&Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnEditOrUpdate
        '
        Me.btnEditOrUpdate.BackgroundImage = CType(resources.GetObject("btnEditOrUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnEditOrUpdate.Enabled = False
        Me.btnEditOrUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditOrUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditOrUpdate.Image = CType(resources.GetObject("btnEditOrUpdate.Image"), System.Drawing.Image)
        Me.btnEditOrUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditOrUpdate.Location = New System.Drawing.Point(9, 175)
        Me.btnEditOrUpdate.Name = "btnEditOrUpdate"
        Me.btnEditOrUpdate.Size = New System.Drawing.Size(107, 25)
        Me.btnEditOrUpdate.TabIndex = 5
        Me.btnEditOrUpdate.Text = "&Update"
        Me.btnEditOrUpdate.UseVisualStyleBackColor = True
        '
        'tabView
        '
        Me.tabView.AutoScroll = True
        Me.tabView.BackgroundImage = CType(resources.GetObject("tabView.BackgroundImage"), System.Drawing.Image)
        Me.tabView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabView.Controls.Add(Me.dgvDailyAWTView)
        Me.tabView.Controls.Add(Me.pnlCategorySearch)
        Me.tabView.Location = New System.Drawing.Point(4, 22)
        Me.tabView.Name = "tabView"
        Me.tabView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabView.Size = New System.Drawing.Size(888, 566)
        Me.tabView.TabIndex = 1
        Me.tabView.Text = "Tab View"
        Me.tabView.UseVisualStyleBackColor = True
        '
        'dgvDailyAWTView
        '
        Me.dgvDailyAWTView.AllowUserToAddRows = False
        Me.dgvDailyAWTView.AllowUserToDeleteRows = False
        Me.dgvDailyAWTView.AllowUserToOrderColumns = True
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvDailyAWTView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDailyAWTView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDailyAWTView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDailyAWTView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDailyAWTView.BackgroundColor = System.Drawing.Color.Gray
        Me.dgvDailyAWTView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDailyAWTView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDailyAWTView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDailyAWTView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RDateViewColumn, Me.GangNameViewColumn, Me.MandorViewColumn, Me.KraniViewColumn, Me.ActivityViewColumn, Me.CategoryViewColumn, Me.DailyTeamActivityIDViewColumn, Me.GangMasterIDViewColumn, Me.MandoreIDViewColumn, Me.KraniIDViewColumn})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDailyAWTView.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvDailyAWTView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvDailyAWTView.EnableHeadersVisualStyles = False
        Me.dgvDailyAWTView.GridColor = System.Drawing.Color.Gray
        Me.dgvDailyAWTView.Location = New System.Drawing.Point(15, 139)
        Me.dgvDailyAWTView.Name = "dgvDailyAWTView"
        Me.dgvDailyAWTView.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDailyAWTView.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDailyAWTView.RowHeadersVisible = False
        Me.dgvDailyAWTView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvDailyAWTView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDailyAWTView.ShowCellErrors = False
        Me.dgvDailyAWTView.Size = New System.Drawing.Size(865, 417)
        Me.dgvDailyAWTView.TabIndex = 9
        Me.dgvDailyAWTView.TabStop = False
        '
        'RDateViewColumn
        '
        Me.RDateViewColumn.DataPropertyName = "RDate"
        DataGridViewCellStyle9.Format = "dd/MM/yyyy"
        Me.RDateViewColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.RDateViewColumn.HeaderText = "Date"
        Me.RDateViewColumn.Name = "RDateViewColumn"
        Me.RDateViewColumn.ReadOnly = True
        Me.RDateViewColumn.Width = 58
        '
        'GangNameViewColumn
        '
        Me.GangNameViewColumn.DataPropertyName = "GangName"
        Me.GangNameViewColumn.HeaderText = "Team"
        Me.GangNameViewColumn.Name = "GangNameViewColumn"
        Me.GangNameViewColumn.ReadOnly = True
        Me.GangNameViewColumn.Width = 62
        '
        'MandorViewColumn
        '
        Me.MandorViewColumn.DataPropertyName = "Mandor"
        Me.MandorViewColumn.HeaderText = "Mandor"
        Me.MandorViewColumn.Name = "MandorViewColumn"
        Me.MandorViewColumn.ReadOnly = True
        Me.MandorViewColumn.Width = 73
        '
        'KraniViewColumn
        '
        Me.KraniViewColumn.DataPropertyName = "Krani"
        Me.KraniViewColumn.HeaderText = "Krani"
        Me.KraniViewColumn.Name = "KraniViewColumn"
        Me.KraniViewColumn.ReadOnly = True
        Me.KraniViewColumn.Width = 61
        '
        'ActivityViewColumn
        '
        Me.ActivityViewColumn.DataPropertyName = "Activity"
        Me.ActivityViewColumn.HeaderText = "Activity"
        Me.ActivityViewColumn.Name = "ActivityViewColumn"
        Me.ActivityViewColumn.ReadOnly = True
        Me.ActivityViewColumn.Width = 73
        '
        'CategoryViewColumn
        '
        Me.CategoryViewColumn.DataPropertyName = "Category"
        Me.CategoryViewColumn.HeaderText = "Category"
        Me.CategoryViewColumn.Name = "CategoryViewColumn"
        Me.CategoryViewColumn.ReadOnly = True
        Me.CategoryViewColumn.Visible = False
        Me.CategoryViewColumn.Width = 84
        '
        'DailyTeamActivityIDViewColumn
        '
        Me.DailyTeamActivityIDViewColumn.DataPropertyName = "DailyTeamActivityID"
        Me.DailyTeamActivityIDViewColumn.HeaderText = "DailyTeamActivityID"
        Me.DailyTeamActivityIDViewColumn.Name = "DailyTeamActivityIDViewColumn"
        Me.DailyTeamActivityIDViewColumn.ReadOnly = True
        Me.DailyTeamActivityIDViewColumn.Visible = False
        Me.DailyTeamActivityIDViewColumn.Width = 148
        '
        'GangMasterIDViewColumn
        '
        Me.GangMasterIDViewColumn.DataPropertyName = "GangMasterID"
        Me.GangMasterIDViewColumn.HeaderText = "GangMasterID"
        Me.GangMasterIDViewColumn.Name = "GangMasterIDViewColumn"
        Me.GangMasterIDViewColumn.ReadOnly = True
        Me.GangMasterIDViewColumn.Visible = False
        Me.GangMasterIDViewColumn.Width = 113
        '
        'MandoreIDViewColumn
        '
        Me.MandoreIDViewColumn.DataPropertyName = "MandoreID"
        Me.MandoreIDViewColumn.HeaderText = "MandoreID"
        Me.MandoreIDViewColumn.Name = "MandoreIDViewColumn"
        Me.MandoreIDViewColumn.ReadOnly = True
        Me.MandoreIDViewColumn.Visible = False
        Me.MandoreIDViewColumn.Width = 94
        '
        'KraniIDViewColumn
        '
        Me.KraniIDViewColumn.DataPropertyName = "KraniID"
        Me.KraniIDViewColumn.HeaderText = "KraniID"
        Me.KraniIDViewColumn.Name = "KraniIDViewColumn"
        Me.KraniIDViewColumn.ReadOnly = True
        Me.KraniIDViewColumn.Visible = False
        Me.KraniIDViewColumn.Width = 75
        '
        'pnlCategorySearch
        '
        Me.pnlCategorySearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCategorySearch.BackColor = System.Drawing.Color.White
        Me.pnlCategorySearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.pnlCategorySearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCategorySearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlCategorySearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlCategorySearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlCategorySearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCategorySearch.CaptionSize = 40
        Me.pnlCategorySearch.CaptionText = "Search Daily Attendance"
        Me.pnlCategorySearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Controls.Add(Me.btnProcessOT)
        Me.pnlCategorySearch.Controls.Add(Me.btnProcessPremi)
        Me.pnlCategorySearch.Controls.Add(Me.btnAttendanceReport)
        Me.pnlCategorySearch.Controls.Add(Me.btnReceiptionReport)
        Me.pnlCategorySearch.Controls.Add(Me.txtTeamNameView)
        Me.pnlCategorySearch.Controls.Add(Me.txtMandorNameView)
        Me.pnlCategorySearch.Controls.Add(Me.cboActivityView)
        Me.pnlCategorySearch.Controls.Add(Me.chkDateView)
        Me.pnlCategorySearch.Controls.Add(Me.CheckBox3)
        Me.pnlCategorySearch.Controls.Add(Me.dtpRDateView)
        Me.pnlCategorySearch.Controls.Add(Me.Label5)
        Me.pnlCategorySearch.Controls.Add(Me.Button1)
        Me.pnlCategorySearch.Controls.Add(Me.Label26)
        Me.pnlCategorySearch.Controls.Add(Me.Label6)
        Me.pnlCategorySearch.Controls.Add(Me.Label28)
        Me.pnlCategorySearch.Controls.Add(Me.btnSearchView)
        Me.pnlCategorySearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlCategorySearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlCategorySearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlCategorySearch.ForeColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Location = New System.Drawing.Point(15, 6)
        Me.pnlCategorySearch.Name = "pnlCategorySearch"
        Me.pnlCategorySearch.Size = New System.Drawing.Size(865, 127)
        Me.pnlCategorySearch.TabIndex = 128
        '
        'btnProcessOT
        '
        Me.btnProcessOT.Image = Global.BSP.My.Resources.Resources._001_25
        Me.btnProcessOT.Location = New System.Drawing.Point(390, 98)
        Me.btnProcessOT.Name = "btnProcessOT"
        Me.btnProcessOT.Size = New System.Drawing.Size(31, 26)
        Me.btnProcessOT.TabIndex = 156
        Me.btnProcessOT.UseVisualStyleBackColor = True
        '
        'btnProcessPremi
        '
        Me.btnProcessPremi.Image = Global.BSP.My.Resources.Resources._001_25
        Me.btnProcessPremi.Location = New System.Drawing.Point(353, 98)
        Me.btnProcessPremi.Name = "btnProcessPremi"
        Me.btnProcessPremi.Size = New System.Drawing.Size(31, 26)
        Me.btnProcessPremi.TabIndex = 155
        Me.btnProcessPremi.UseVisualStyleBackColor = True
        '
        'btnAttendanceReport
        '
        Me.btnAttendanceReport.BackColor = System.Drawing.Color.Transparent
        Me.btnAttendanceReport.BackgroundImage = CType(resources.GetObject("btnAttendanceReport.BackgroundImage"), System.Drawing.Image)
        Me.btnAttendanceReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAttendanceReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttendanceReport.ForeColor = System.Drawing.Color.Black
        Me.btnAttendanceReport.Image = CType(resources.GetObject("btnAttendanceReport.Image"), System.Drawing.Image)
        Me.btnAttendanceReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAttendanceReport.Location = New System.Drawing.Point(551, 70)
        Me.btnAttendanceReport.Name = "btnAttendanceReport"
        Me.btnAttendanceReport.Size = New System.Drawing.Size(178, 31)
        Me.btnAttendanceReport.TabIndex = 7
        Me.btnAttendanceReport.Text = "Laporan Mandor Report"
        Me.btnAttendanceReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAttendanceReport.UseVisualStyleBackColor = False
        '
        'btnReceiptionReport
        '
        Me.btnReceiptionReport.BackColor = System.Drawing.Color.Transparent
        Me.btnReceiptionReport.BackgroundImage = CType(resources.GetObject("btnReceiptionReport.BackgroundImage"), System.Drawing.Image)
        Me.btnReceiptionReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReceiptionReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiptionReport.ForeColor = System.Drawing.Color.Black
        Me.btnReceiptionReport.Image = CType(resources.GetObject("btnReceiptionReport.Image"), System.Drawing.Image)
        Me.btnReceiptionReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReceiptionReport.Location = New System.Drawing.Point(726, 70)
        Me.btnReceiptionReport.Name = "btnReceiptionReport"
        Me.btnReceiptionReport.Size = New System.Drawing.Size(139, 31)
        Me.btnReceiptionReport.TabIndex = 8
        Me.btnReceiptionReport.TabStop = False
        Me.btnReceiptionReport.Text = "Reception Report"
        Me.btnReceiptionReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReceiptionReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReceiptionReport.UseVisualStyleBackColor = False
        '
        'txtTeamNameView
        '
        Me.txtTeamNameView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTeamNameView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeamNameView.Location = New System.Drawing.Point(97, 72)
        Me.txtTeamNameView.MaxLength = 50
        Me.txtTeamNameView.Name = "txtTeamNameView"
        Me.txtTeamNameView.Size = New System.Drawing.Size(118, 21)
        Me.txtTeamNameView.TabIndex = 3
        '
        'txtMandorNameView
        '
        Me.txtMandorNameView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMandorNameView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMandorNameView.Location = New System.Drawing.Point(216, 72)
        Me.txtMandorNameView.MaxLength = 50
        Me.txtMandorNameView.Name = "txtMandorNameView"
        Me.txtMandorNameView.Size = New System.Drawing.Size(135, 21)
        Me.txtMandorNameView.TabIndex = 4
        '
        'cboActivityView
        '
        Me.cboActivityView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActivityView.FormattingEnabled = True
        Me.cboActivityView.Items.AddRange(New Object() {"All", "PANEN", "LAIN"})
        Me.cboActivityView.Location = New System.Drawing.Point(352, 72)
        Me.cboActivityView.Name = "cboActivityView"
        Me.cboActivityView.Size = New System.Drawing.Size(116, 21)
        Me.cboActivityView.TabIndex = 5
        '
        'chkDateView
        '
        Me.chkDateView.AutoSize = True
        Me.chkDateView.Location = New System.Drawing.Point(6, 53)
        Me.chkDateView.Name = "chkDateView"
        Me.chkDateView.Size = New System.Drawing.Size(15, 14)
        Me.chkDateView.TabIndex = 0
        Me.chkDateView.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(105, 52)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.UseVisualStyleBackColor = True
        Me.CheckBox3.Visible = False
        '
        'dtpRDateView
        '
        Me.dtpRDateView.CustomFormat = "dd/MM/yyyy"
        Me.dtpRDateView.Enabled = False
        Me.dtpRDateView.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRDateView.Location = New System.Drawing.Point(1, 73)
        Me.dtpRDateView.Name = "dtpRDateView"
        Me.dtpRDateView.Size = New System.Drawing.Size(94, 20)
        Me.dtpRDateView.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(27, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Date"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(831, 45)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 26)
        Me.Button1.TabIndex = 154
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(213, 52)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(43, 13)
        Me.Label26.TabIndex = 118
        Me.Label26.Text = "Mandor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(126, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 118
        Me.Label6.Text = "Team"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(350, 52)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 13)
        Me.Label28.TabIndex = 118
        Me.Label28.Text = "Activity"
        '
        'btnSearchView
        '
        Me.btnSearchView.BackgroundImage = CType(resources.GetObject("btnSearchView.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearchView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchView.ForeColor = System.Drawing.Color.Black
        Me.btnSearchView.Image = CType(resources.GetObject("btnSearchView.Image"), System.Drawing.Image)
        Me.btnSearchView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearchView.Location = New System.Drawing.Point(469, 70)
        Me.btnSearchView.Name = "btnSearchView"
        Me.btnSearchView.Size = New System.Drawing.Size(82, 31)
        Me.btnSearchView.TabIndex = 6
        Me.btnSearchView.Text = "Search"
        Me.btnSearchView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSearchView.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(171, 57)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox2.TabIndex = 152
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(22, 53)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 151
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(50, 73)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(135, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'lblviewDate
        '
        Me.lblviewDate.AutoSize = True
        Me.lblviewDate.BackColor = System.Drawing.Color.Transparent
        Me.lblviewDate.ForeColor = System.Drawing.Color.Black
        Me.lblviewDate.Location = New System.Drawing.Point(43, 53)
        Me.lblviewDate.Name = "lblviewDate"
        Me.lblviewDate.Size = New System.Drawing.Size(30, 13)
        Me.lblviewDate.TabIndex = 16
        Me.lblviewDate.Text = "Date"
        '
        'lblviewTeam
        '
        Me.lblviewTeam.AutoSize = True
        Me.lblviewTeam.BackColor = System.Drawing.Color.Transparent
        Me.lblviewTeam.ForeColor = System.Drawing.Color.Black
        Me.lblviewTeam.Location = New System.Drawing.Point(192, 57)
        Me.lblviewTeam.Name = "lblviewTeam"
        Me.lblviewTeam.Size = New System.Drawing.Size(34, 13)
        Me.lblviewTeam.TabIndex = 118
        Me.lblviewTeam.Text = "Team"
        '
        'CmbTeam
        '
        Me.CmbTeam.FormattingEnabled = True
        Me.CmbTeam.Location = New System.Drawing.Point(171, 73)
        Me.CmbTeam.Name = "CmbTeam"
        Me.CmbTeam.Size = New System.Drawing.Size(148, 21)
        Me.CmbTeam.TabIndex = 117
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(335, 73)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(134, 25)
        Me.btnSearch.TabIndex = 112
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblTotalLatex
        '
        Me.lblTotalLatex.AutoSize = True
        Me.lblTotalLatex.Location = New System.Drawing.Point(340, 198)
        Me.lblTotalLatex.Name = "lblTotalLatex"
        Me.lblTotalLatex.Size = New System.Drawing.Size(60, 13)
        Me.lblTotalLatex.TabIndex = 184
        Me.lblTotalLatex.Text = "Total Latex"
        Me.lblTotalLatex.Visible = False
        '
        'lblTotalCupLump
        '
        Me.lblTotalCupLump.AutoSize = True
        Me.lblTotalCupLump.Location = New System.Drawing.Point(461, 197)
        Me.lblTotalCupLump.Name = "lblTotalCupLump"
        Me.lblTotalCupLump.Size = New System.Drawing.Size(82, 13)
        Me.lblTotalCupLump.TabIndex = 185
        Me.lblTotalCupLump.Text = "Total Cup Lump"
        Me.lblTotalCupLump.Visible = False
        '
        'lblTotalTreelace
        '
        Me.lblTotalTreelace.AutoSize = True
        Me.lblTotalTreelace.Location = New System.Drawing.Point(607, 197)
        Me.lblTotalTreelace.Name = "lblTotalTreelace"
        Me.lblTotalTreelace.Size = New System.Drawing.Size(80, 13)
        Me.lblTotalTreelace.TabIndex = 187
        Me.lblTotalTreelace.Text = "Total TreeLace"
        Me.lblTotalTreelace.Visible = False
        '
        'DailyAttendanceWithTeam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(896, 592)
        Me.Controls.Add(Me.tcDailyAttendance)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "DailyAttendanceWithTeam"
        Me.Text = "DailyAttendance"
        Me.tcDailyAttendance.ResumeLayout(False)
        Me.tabInput.ResumeLayout(False)
        Me.tabInput.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvDailyAttendance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDailyAttendance.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DgvOTDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabView.ResumeLayout(False)
        CType(Me.dgvDailyAWTView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCategorySearch.ResumeLayout(False)
        Me.pnlCategorySearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcDailyAttendance As System.Windows.Forms.TabControl
    Friend WithEvents tabInput As System.Windows.Forms.TabPage
    Friend WithEvents tabView As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnTeamLookup As System.Windows.Forms.Button
    Friend WithEvents txtTeam As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewDate As System.Windows.Forms.Label
    Friend WithEvents lblviewTeam As System.Windows.Forms.Label
    Friend WithEvents CmbTeam As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblGangMasterID As System.Windows.Forms.Label
    Friend WithEvents lblDistributionSetupID As System.Windows.Forms.Label
    Friend WithEvents btnEditOrUpdate As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDailyAttendance As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDailyAWTView As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCategorySearch As Stepi.UI.ExtendedPanel
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDateView As System.Windows.Forms.CheckBox
    Friend WithEvents dtpRDateView As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSearchView As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnActivity As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOT1 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtH4 As System.Windows.Forms.TextBox
    Friend WithEvents txtMax4 As System.Windows.Forms.TextBox
    Friend WithEvents txtH3 As System.Windows.Forms.TextBox
    Friend WithEvents txtMax3 As System.Windows.Forms.TextBox
    Friend WithEvents txtH2 As System.Windows.Forms.TextBox
    Friend WithEvents txtOT4 As System.Windows.Forms.TextBox
    Friend WithEvents txtMax2 As System.Windows.Forms.TextBox
    Friend WithEvents txtOT3 As System.Windows.Forms.TextBox
    Friend WithEvents txtH1 As System.Windows.Forms.TextBox
    Friend WithEvents txtOT2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMax1 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtOTResult As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTotalOTValue As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtBasicRate As System.Windows.Forms.TextBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents cmsDailyAttendance As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditMIDA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtTeamNameView As System.Windows.Forms.TextBox
    Friend WithEvents lblKraniEmpName As System.Windows.Forms.Label
    Friend WithEvents lblKraniID As System.Windows.Forms.Label
    Friend WithEvents lblMandorEmpName As System.Windows.Forms.Label
    Friend WithEvents lblMandoreID As System.Windows.Forms.Label
    Friend WithEvents lblActivity As System.Windows.Forms.Label
    Friend WithEvents lblDailyTeamActivityID As System.Windows.Forms.Label
    Friend WithEvents lblDailyReceiptionID As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LblBasicPay As System.Windows.Forms.Label
    Friend WithEvents lblAttendanceSetupID As System.Windows.Forms.Label
    Friend WithEvents lblEmpCategory As System.Windows.Forms.Label
    Friend WithEvents txtOTHours As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAttendType As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchLocation As System.Windows.Forms.Button
    Friend WithEvents btnAttendanceSetupLookup As System.Windows.Forms.Button
    Friend WithEvents lblColon6 As System.Windows.Forms.Label
    Friend WithEvents lblBNik As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblAttCode As System.Windows.Forms.Label
    Friend WithEvents lblColon2 As System.Windows.Forms.Label
    Friend WithEvents lblColon8 As System.Windows.Forms.Label
    Friend WithEvents lblColon4 As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents txtNIK As System.Windows.Forms.TextBox
    Friend WithEvents txtAttendanceCode As System.Windows.Forms.TextBox
    Friend WithEvents lblEmpName As System.Windows.Forms.Label
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents txtMandorNameView As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cboActivityView As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblEmpId As System.Windows.Forms.Label
    Friend WithEvents DgvOTDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblRestDay As System.Windows.Forms.Label
    Friend WithEvents btnReceiptionReport As System.Windows.Forms.Button
    Friend WithEvents btnAttendanceReport As System.Windows.Forms.Button
    Friend WithEvents lblJjgActualNormal As System.Windows.Forms.Label
    Friend WithEvents lblJjgActualBorongan As System.Windows.Forms.Label
    Friend WithEvents lblBrdNormal As System.Windows.Forms.Label
    Friend WithEvents lblBrdBorongan As System.Windows.Forms.Label
    Friend WithEvents lblJJGActB As System.Windows.Forms.Label
    Friend WithEvents lblBrdN As System.Windows.Forms.Label
    Friend WithEvents lblBrdB As System.Windows.Forms.Label
    Friend WithEvents lblJJGActN As System.Windows.Forms.Label
    Friend WithEvents lblBrondalanValue As System.Windows.Forms.Label
    Friend WithEvents lblHa As System.Windows.Forms.Label
    Friend WithEvents lblHaValue As System.Windows.Forms.Label
    Friend WithEvents lblBrondalan As System.Windows.Forms.Label
    Friend WithEvents lblTotalHK As System.Windows.Forms.Label
    Friend WithEvents lblLTotalOT As System.Windows.Forms.Label
    Friend WithEvents lblTotalOT As System.Windows.Forms.Label
    Friend WithEvents lblLTotalHK As System.Windows.Forms.Label
    Friend WithEvents LblTtlHK As System.Windows.Forms.Label
    Friend WithEvents LblLTtlHK As System.Windows.Forms.Label
    Friend WithEvents btnProcessPremi As System.Windows.Forms.Button
    Friend WithEvents RDateViewColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GangNameViewColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MandorViewColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KraniViewColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivityViewColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategoryViewColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyTeamActivityIDViewColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GangMasterIDViewColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MandoreIDViewColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KraniIDViewColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblOldNIK As System.Windows.Forms.Label
    Friend WithEvents DARDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DAGangNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DAEmpCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcOldNIK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DAEmpNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DAAttendanceCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DADistributionSetupIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DADistributionColumn As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DAConcurrencyIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DATotalOTColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DAAttendanceSetupIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DAColumnTotalOTValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnCalculate As System.Windows.Forms.Button
    Friend WithEvents btnProcessOT As System.Windows.Forms.Button
    Friend WithEvents lblTotalTreelace As System.Windows.Forms.Label
    Friend WithEvents lblTotalCupLump As System.Windows.Forms.Label
    Friend WithEvents lblTotalLatex As System.Windows.Forms.Label
End Class

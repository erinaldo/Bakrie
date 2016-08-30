<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PieceRate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PieceRate))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPieceRateRefNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtJobDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnPieceRateRefLookup = New System.Windows.Forms.Button()
        Me.gbEmployee = New System.Windows.Forms.GroupBox()
        Me.cmbEmployee = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbMandor = New System.Windows.Forms.ComboBox()
        Me.gbContractor = New System.Windows.Forms.GroupBox()
        Me.cmbContractor = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtTotalUnit = New System.Windows.Forms.TextBox()
        Me.txtBalanceUnit = New System.Windows.Forms.TextBox()
        Me.txtUnitCompleted = New System.Windows.Forms.TextBox()
        Me.txtJobRate = New System.Windows.Forms.TextBox()
        Me.txtMandorRate = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtVehicleNo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnVehicleLookup = New System.Windows.Forms.Button()
        Me.btnSubStationLookup = New System.Windows.Forms.Button()
        Me.txtSubStationID = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dgvPRTransactions = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContractName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitCompleted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VHWSCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PieceRateActivityId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContractID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubStationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VHID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifiedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifiedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtBlockName = New System.Windows.Forms.TextBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtActivityId = New System.Windows.Forms.Label()
        Me.lblVHID = New System.Windows.Forms.Label()
        Me.lblTransactionId = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtStation = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMDelete = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MSDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtProduction = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.gbEmployee.SuspendLayout()
        Me.gbContractor.SuspendLayout()
        CType(Me.dgvPRTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMDelete.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(102, 20)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(123, 20)
        Me.dtpDate.TabIndex = 197
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(19, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 198
        Me.Label1.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(240, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 13)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "Piece Rate Reference No."
        '
        'txtPieceRateRefNo
        '
        Me.txtPieceRateRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPieceRateRefNo.Location = New System.Drawing.Point(379, 20)
        Me.txtPieceRateRefNo.Name = "txtPieceRateRefNo"
        Me.txtPieceRateRefNo.Size = New System.Drawing.Size(117, 20)
        Me.txtPieceRateRefNo.TabIndex = 200
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(293, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "Job Description"
        '
        'txtJobDescription
        '
        Me.txtJobDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJobDescription.Location = New System.Drawing.Point(379, 46)
        Me.txtJobDescription.Name = "txtJobDescription"
        Me.txtJobDescription.ReadOnly = True
        Me.txtJobDescription.Size = New System.Drawing.Size(251, 20)
        Me.txtJobDescription.TabIndex = 202
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(518, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 203
        Me.Label4.Text = "Mandor"
        Me.Label4.Visible = False
        '
        'btnPieceRateRefLookup
        '
        Me.btnPieceRateRefLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPieceRateRefLookup.Image = CType(resources.GetObject("btnPieceRateRefLookup.Image"), System.Drawing.Image)
        Me.btnPieceRateRefLookup.Location = New System.Drawing.Point(502, 13)
        Me.btnPieceRateRefLookup.Name = "btnPieceRateRefLookup"
        Me.btnPieceRateRefLookup.Size = New System.Drawing.Size(30, 26)
        Me.btnPieceRateRefLookup.TabIndex = 205
        Me.btnPieceRateRefLookup.TabStop = False
        Me.btnPieceRateRefLookup.UseVisualStyleBackColor = True
        '
        'gbEmployee
        '
        Me.gbEmployee.BackColor = System.Drawing.Color.Transparent
        Me.gbEmployee.Controls.Add(Me.cmbEmployee)
        Me.gbEmployee.Controls.Add(Me.Label5)
        Me.gbEmployee.Enabled = False
        Me.gbEmployee.Location = New System.Drawing.Point(22, 100)
        Me.gbEmployee.Name = "gbEmployee"
        Me.gbEmployee.Size = New System.Drawing.Size(293, 70)
        Me.gbEmployee.TabIndex = 207
        Me.gbEmployee.TabStop = False
        Me.gbEmployee.Text = "Employee"
        '
        'cmbEmployee
        '
        Me.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmployee.FormattingEnabled = True
        Me.cmbEmployee.Location = New System.Drawing.Point(87, 19)
        Me.cmbEmployee.Name = "cmbEmployee"
        Me.cmbEmployee.Size = New System.Drawing.Size(200, 21)
        Me.cmbEmployee.TabIndex = 234
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(20, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 207
        Me.Label5.Text = "Employee"
        '
        'cmbMandor
        '
        Me.cmbMandor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMandor.FormattingEnabled = True
        Me.cmbMandor.Location = New System.Drawing.Point(578, 197)
        Me.cmbMandor.Name = "cmbMandor"
        Me.cmbMandor.Size = New System.Drawing.Size(43, 21)
        Me.cmbMandor.TabIndex = 233
        Me.cmbMandor.Visible = False
        '
        'gbContractor
        '
        Me.gbContractor.BackColor = System.Drawing.Color.Transparent
        Me.gbContractor.Controls.Add(Me.cmbContractor)
        Me.gbContractor.Controls.Add(Me.Label7)
        Me.gbContractor.Enabled = False
        Me.gbContractor.Location = New System.Drawing.Point(333, 100)
        Me.gbContractor.Name = "gbContractor"
        Me.gbContractor.Size = New System.Drawing.Size(338, 70)
        Me.gbContractor.TabIndex = 208
        Me.gbContractor.TabStop = False
        Me.gbContractor.Text = "Contractor"
        '
        'cmbContractor
        '
        Me.cmbContractor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbContractor.FormattingEnabled = True
        Me.cmbContractor.Location = New System.Drawing.Point(75, 19)
        Me.cmbContractor.Name = "cmbContractor"
        Me.cmbContractor.Size = New System.Drawing.Size(249, 21)
        Me.cmbContractor.TabIndex = 235
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(13, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 211
        Me.Label7.Text = "Contractor"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(19, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 209
        Me.Label9.Text = "FieldNo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(20, 181)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 210
        Me.Label10.Text = "Unit"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(125, 182)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 211
        Me.Label11.Text = "Total Unit"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(248, 182)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 13)
        Me.Label12.TabIndex = 212
        Me.Label12.Text = "Balance Unit"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(382, 182)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 213
        Me.Label13.Text = "Unit Completed"
        '
        'txtUnit
        '
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit.Location = New System.Drawing.Point(23, 198)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.ReadOnly = True
        Me.txtUnit.Size = New System.Drawing.Size(88, 20)
        Me.txtUnit.TabIndex = 215
        '
        'txtTotalUnit
        '
        Me.txtTotalUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalUnit.Location = New System.Drawing.Point(128, 199)
        Me.txtTotalUnit.Name = "txtTotalUnit"
        Me.txtTotalUnit.ReadOnly = True
        Me.txtTotalUnit.Size = New System.Drawing.Size(87, 20)
        Me.txtTotalUnit.TabIndex = 216
        '
        'txtBalanceUnit
        '
        Me.txtBalanceUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalanceUnit.Location = New System.Drawing.Point(243, 199)
        Me.txtBalanceUnit.Name = "txtBalanceUnit"
        Me.txtBalanceUnit.ReadOnly = True
        Me.txtBalanceUnit.Size = New System.Drawing.Size(123, 20)
        Me.txtBalanceUnit.TabIndex = 217
        '
        'txtUnitCompleted
        '
        Me.txtUnitCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCompleted.Location = New System.Drawing.Point(385, 198)
        Me.txtUnitCompleted.Name = "txtUnitCompleted"
        Me.txtUnitCompleted.Size = New System.Drawing.Size(123, 20)
        Me.txtUnitCompleted.TabIndex = 218
        '
        'txtJobRate
        '
        Me.txtJobRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJobRate.Location = New System.Drawing.Point(128, 246)
        Me.txtJobRate.Name = "txtJobRate"
        Me.txtJobRate.ReadOnly = True
        Me.txtJobRate.Size = New System.Drawing.Size(87, 20)
        Me.txtJobRate.TabIndex = 222
        '
        'txtMandorRate
        '
        Me.txtMandorRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMandorRate.Location = New System.Drawing.Point(22, 246)
        Me.txtMandorRate.Name = "txtMandorRate"
        Me.txtMandorRate.ReadOnly = True
        Me.txtMandorRate.Size = New System.Drawing.Size(89, 20)
        Me.txtMandorRate.TabIndex = 221
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(125, 229)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 220
        Me.Label14.Text = "Job Rate"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(19, 229)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 13)
        Me.Label15.TabIndex = 219
        Me.Label15.Text = "Mandor Rate"
        '
        'txtVehicleNo
        '
        Me.txtVehicleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleNo.Location = New System.Drawing.Point(243, 246)
        Me.txtVehicleNo.Name = "txtVehicleNo"
        Me.txtVehicleNo.Size = New System.Drawing.Size(87, 20)
        Me.txtVehicleNo.TabIndex = 224
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(240, 230)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 13)
        Me.Label16.TabIndex = 223
        Me.Label16.Text = "Vehicle No."
        '
        'btnVehicleLookup
        '
        Me.btnVehicleLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVehicleLookup.Image = CType(resources.GetObject("btnVehicleLookup.Image"), System.Drawing.Image)
        Me.btnVehicleLookup.Location = New System.Drawing.Point(336, 240)
        Me.btnVehicleLookup.Name = "btnVehicleLookup"
        Me.btnVehicleLookup.Size = New System.Drawing.Size(30, 26)
        Me.btnVehicleLookup.TabIndex = 225
        Me.btnVehicleLookup.TabStop = False
        Me.btnVehicleLookup.UseVisualStyleBackColor = True
        '
        'btnSubStationLookup
        '
        Me.btnSubStationLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubStationLookup.Image = CType(resources.GetObject("btnSubStationLookup.Image"), System.Drawing.Image)
        Me.btnSubStationLookup.Location = New System.Drawing.Point(478, 239)
        Me.btnSubStationLookup.Name = "btnSubStationLookup"
        Me.btnSubStationLookup.Size = New System.Drawing.Size(30, 26)
        Me.btnSubStationLookup.TabIndex = 228
        Me.btnSubStationLookup.TabStop = False
        Me.btnSubStationLookup.UseVisualStyleBackColor = True
        Me.btnSubStationLookup.Visible = False
        '
        'txtSubStationID
        '
        Me.txtSubStationID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubStationID.Location = New System.Drawing.Point(385, 245)
        Me.txtSubStationID.Name = "txtSubStationID"
        Me.txtSubStationID.Size = New System.Drawing.Size(87, 20)
        Me.txtSubStationID.TabIndex = 227
        Me.txtSubStationID.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(382, 229)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 13)
        Me.Label17.TabIndex = 226
        Me.Label17.Text = "Sub-Station Code"
        Me.Label17.Visible = False
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Location = New System.Drawing.Point(22, 288)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(308, 32)
        Me.txtRemarks.TabIndex = 230
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(19, 272)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 229
        Me.Label18.Text = "Remarks"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(336, 288)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(136, 32)
        Me.btnSave.TabIndex = 231
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'dgvPRTransactions
        '
        Me.dgvPRTransactions.AllowUserToAddRows = False
        Me.dgvPRTransactions.AllowUserToDeleteRows = False
        Me.dgvPRTransactions.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvPRTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPRTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPRTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPRTransactions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPRTransactions.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPRTransactions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPRTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPRTransactions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPRTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPRTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colDate, Me.EmpName, Me.ContractName, Me.UnitCompleted, Me.VHWSCode, Me.Remarks, Me.PieceRateActivityId, Me.EmpID, Me.ContractID, Me.SubStationID, Me.VHID, Me.CreatedBy, Me.CreatedOn, Me.ModifiedBy, Me.ModifiedOn})
        Me.dgvPRTransactions.EnableHeadersVisualStyles = False
        Me.dgvPRTransactions.Location = New System.Drawing.Point(22, 336)
        Me.dgvPRTransactions.MultiSelect = False
        Me.dgvPRTransactions.Name = "dgvPRTransactions"
        Me.dgvPRTransactions.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPRTransactions.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPRTransactions.RowHeadersVisible = False
        Me.dgvPRTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPRTransactions.ShowCellErrors = False
        Me.dgvPRTransactions.Size = New System.Drawing.Size(649, 136)
        Me.dgvPRTransactions.TabIndex = 232
        '
        'colId
        '
        Me.colId.DataPropertyName = "Id"
        Me.colId.HeaderText = "ID"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Visible = False
        Me.colId.Width = 23
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "Date"
        Me.colDate.HeaderText = "Date"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        Me.colDate.Width = 54
        '
        'EmpName
        '
        Me.EmpName.DataPropertyName = "EmpName"
        Me.EmpName.HeaderText = "Employee"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        Me.EmpName.Width = 77
        '
        'ContractName
        '
        Me.ContractName.DataPropertyName = "ContractName"
        Me.ContractName.HeaderText = "Contractor"
        Me.ContractName.Name = "ContractName"
        Me.ContractName.ReadOnly = True
        Me.ContractName.Width = 80
        '
        'UnitCompleted
        '
        Me.UnitCompleted.DataPropertyName = "UnitCompleted"
        Me.UnitCompleted.HeaderText = "Unit Completed"
        Me.UnitCompleted.Name = "UnitCompleted"
        Me.UnitCompleted.ReadOnly = True
        Me.UnitCompleted.Width = 95
        '
        'VHWSCode
        '
        Me.VHWSCode.DataPropertyName = "VHWSCode"
        Me.VHWSCode.HeaderText = "Vehicle No"
        Me.VHWSCode.Name = "VHWSCode"
        Me.VHWSCode.ReadOnly = True
        Me.VHWSCode.Width = 77
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        Me.Remarks.Width = 73
        '
        'PieceRateActivityId
        '
        Me.PieceRateActivityId.DataPropertyName = "PieceRateActivityId"
        Me.PieceRateActivityId.HeaderText = "PieceRateActivityId"
        Me.PieceRateActivityId.Name = "PieceRateActivityId"
        Me.PieceRateActivityId.ReadOnly = True
        Me.PieceRateActivityId.Visible = False
        Me.PieceRateActivityId.Width = 124
        '
        'EmpID
        '
        Me.EmpID.DataPropertyName = "EmpID"
        Me.EmpID.HeaderText = "EmpID"
        Me.EmpID.Name = "EmpID"
        Me.EmpID.ReadOnly = True
        Me.EmpID.Visible = False
        Me.EmpID.Width = 63
        '
        'ContractID
        '
        Me.ContractID.DataPropertyName = "ContractID"
        Me.ContractID.HeaderText = "ContractID"
        Me.ContractID.Name = "ContractID"
        Me.ContractID.ReadOnly = True
        Me.ContractID.Visible = False
        Me.ContractID.Width = 82
        '
        'SubStationID
        '
        Me.SubStationID.DataPropertyName = "SubStationID"
        Me.SubStationID.HeaderText = "SubStationID"
        Me.SubStationID.Name = "SubStationID"
        Me.SubStationID.ReadOnly = True
        Me.SubStationID.Visible = False
        Me.SubStationID.Width = 94
        '
        'VHID
        '
        Me.VHID.DataPropertyName = "VHID"
        Me.VHID.HeaderText = "VHID"
        Me.VHID.Name = "VHID"
        Me.VHID.ReadOnly = True
        Me.VHID.Visible = False
        Me.VHID.Width = 57
        '
        'CreatedBy
        '
        Me.CreatedBy.DataPropertyName = "CreatedBy"
        Me.CreatedBy.HeaderText = "CreatedBy"
        Me.CreatedBy.Name = "CreatedBy"
        Me.CreatedBy.ReadOnly = True
        Me.CreatedBy.Visible = False
        Me.CreatedBy.Width = 80
        '
        'CreatedOn
        '
        Me.CreatedOn.DataPropertyName = "CreatedOn"
        Me.CreatedOn.HeaderText = "CreatedOn"
        Me.CreatedOn.Name = "CreatedOn"
        Me.CreatedOn.ReadOnly = True
        Me.CreatedOn.Visible = False
        Me.CreatedOn.Width = 82
        '
        'ModifiedBy
        '
        Me.ModifiedBy.DataPropertyName = "ModifiedBy"
        Me.ModifiedBy.HeaderText = "ModifiedBy"
        Me.ModifiedBy.Name = "ModifiedBy"
        Me.ModifiedBy.ReadOnly = True
        Me.ModifiedBy.Visible = False
        Me.ModifiedBy.Width = 83
        '
        'ModifiedOn
        '
        Me.ModifiedOn.DataPropertyName = "ModifiedOn"
        Me.ModifiedOn.HeaderText = "ModifiedOn"
        Me.ModifiedOn.Name = "ModifiedOn"
        Me.ModifiedOn.ReadOnly = True
        Me.ModifiedOn.Visible = False
        Me.ModifiedOn.Width = 85
        '
        'txtBlockName
        '
        Me.txtBlockName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBlockName.Location = New System.Drawing.Point(102, 46)
        Me.txtBlockName.Name = "txtBlockName"
        Me.txtBlockName.ReadOnly = True
        Me.txtBlockName.Size = New System.Drawing.Size(123, 20)
        Me.txtBlockName.TabIndex = 233
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(577, 288)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(94, 32)
        Me.btnReset.TabIndex = 234
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'txtActivityId
        '
        Me.txtActivityId.AutoSize = True
        Me.txtActivityId.Location = New System.Drawing.Point(539, 25)
        Me.txtActivityId.Name = "txtActivityId"
        Me.txtActivityId.Size = New System.Drawing.Size(13, 13)
        Me.txtActivityId.TabIndex = 235
        Me.txtActivityId.Text = "0"
        Me.txtActivityId.Visible = False
        '
        'lblVHID
        '
        Me.lblVHID.AutoSize = True
        Me.lblVHID.Location = New System.Drawing.Point(243, 272)
        Me.lblVHID.Name = "lblVHID"
        Me.lblVHID.Size = New System.Drawing.Size(13, 13)
        Me.lblVHID.TabIndex = 236
        Me.lblVHID.Text = "0"
        Me.lblVHID.Visible = False
        '
        'lblTransactionId
        '
        Me.lblTransactionId.AutoSize = True
        Me.lblTransactionId.Location = New System.Drawing.Point(558, 26)
        Me.lblTransactionId.Name = "lblTransactionId"
        Me.lblTransactionId.Size = New System.Drawing.Size(13, 13)
        Me.lblTransactionId.TabIndex = 237
        Me.lblTransactionId.Text = "0"
        Me.lblTransactionId.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Image)
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(478, 289)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(93, 30)
        Me.btnDelete.TabIndex = 238
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtStation
        '
        Me.txtStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStation.Location = New System.Drawing.Point(102, 71)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.ReadOnly = True
        Me.txtStation.Size = New System.Drawing.Size(123, 20)
        Me.txtStation.TabIndex = 240
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(19, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 239
        Me.Label6.Text = "Station"
        '
        'CMDelete
        '
        Me.CMDelete.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MSDelete})
        Me.CMDelete.Name = "CMDelete"
        Me.CMDelete.Size = New System.Drawing.Size(108, 26)
        '
        'MSDelete
        '
        Me.MSDelete.Name = "MSDelete"
        Me.MSDelete.Size = New System.Drawing.Size(107, 22)
        Me.MSDelete.Text = "Delete"
        '
        'txtProduction
        '
        Me.txtProduction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProduction.Location = New System.Drawing.Point(521, 246)
        Me.txtProduction.Name = "txtProduction"
        Me.txtProduction.Size = New System.Drawing.Size(117, 20)
        Me.txtProduction.TabIndex = 242
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(518, 230)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 241
        Me.Label8.Text = "Production"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(639, 248)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(20, 13)
        Me.Label19.TabIndex = 243
        Me.Label19.Text = "Kg"
        '
        'PieceRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(684, 484)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtProduction)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtStation)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbMandor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblTransactionId)
        Me.Controls.Add(Me.lblVHID)
        Me.Controls.Add(Me.txtActivityId)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.txtBlockName)
        Me.Controls.Add(Me.dgvPRTransactions)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.btnSubStationLookup)
        Me.Controls.Add(Me.txtSubStationID)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnVehicleLookup)
        Me.Controls.Add(Me.txtVehicleNo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtJobRate)
        Me.Controls.Add(Me.txtMandorRate)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtUnitCompleted)
        Me.Controls.Add(Me.txtBalanceUnit)
        Me.Controls.Add(Me.txtTotalUnit)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.gbContractor)
        Me.Controls.Add(Me.gbEmployee)
        Me.Controls.Add(Me.btnPieceRateRefLookup)
        Me.Controls.Add(Me.txtJobDescription)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPieceRateRefNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PieceRate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Piece Rate"
        Me.gbEmployee.ResumeLayout(False)
        Me.gbEmployee.PerformLayout()
        Me.gbContractor.ResumeLayout(False)
        Me.gbContractor.PerformLayout()
        CType(Me.dgvPRTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMDelete.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPieceRateRefNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtJobDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPieceRateRefLookup As System.Windows.Forms.Button
    Friend WithEvents gbEmployee As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbContractor As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtBalanceUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitCompleted As System.Windows.Forms.TextBox
    Friend WithEvents txtJobRate As System.Windows.Forms.TextBox
    Friend WithEvents txtMandorRate As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleNo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnVehicleLookup As System.Windows.Forms.Button
    Friend WithEvents btnSubStationLookup As System.Windows.Forms.Button
    Friend WithEvents txtSubStationID As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dgvPRTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents cmbEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMandor As System.Windows.Forms.ComboBox
    Friend WithEvents cmbContractor As System.Windows.Forms.ComboBox
    Friend WithEvents txtBlockName As System.Windows.Forms.TextBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents txtActivityId As System.Windows.Forms.Label
    Friend WithEvents lblVHID As System.Windows.Forms.Label
    Friend WithEvents lblTransactionId As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents txtStation As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCompleted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHWSCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceRateActivityId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubStationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifiedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifiedOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMDelete As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MSDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtProduction As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class

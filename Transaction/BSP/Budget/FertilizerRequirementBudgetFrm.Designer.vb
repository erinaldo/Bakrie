<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FertilizerRequirementBudgetFrm
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FertilizerRequirementBudgetFrm))
        Me.tbFertilizerRequirementBudget = New System.Windows.Forms.TabControl
        Me.tbFertilizer = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgYieldBudget = New System.Windows.Forms.DataGridView
        Me.YieldBudgetID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YieldID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YOPID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlockID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnSaveAll = New System.Windows.Forms.Button
        Me.btnResetAll = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.lblRounds = New System.Windows.Forms.Label
        Me.cmbRounds = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblOrganic = New System.Windows.Forms.Label
        Me.cmbOrganic = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtOrganicKG = New System.Windows.Forms.TextBox
        Me.lblOrganicKG = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtStockKG = New System.Windows.Forms.TextBox
        Me.lblStockKg = New System.Windows.Forms.Label
        Me.lblOrganicTons = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblOrganicTonsL = New System.Windows.Forms.Label
        Me.lblStockTons = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblStockTonsL = New System.Windows.Forms.Label
        Me.lblStockCode = New System.Windows.Forms.Label
        Me.btnSearchStockCode = New System.Windows.Forms.Button
        Me.txtStockCode = New System.Windows.Forms.TextBox
        Me.lblColon4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblSPH = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblSPHL = New System.Windows.Forms.Label
        Me.lblTotalStands = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblTotalStandsL = New System.Windows.Forms.Label
        Me.lblSupplying = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblSupplyingL = New System.Windows.Forms.Label
        Me.lblInfilling = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblInFillingL = New System.Windows.Forms.Label
        Me.lblOriginal = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblOriginalL = New System.Windows.Forms.Label
        Me.lblHect = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblHecterage = New System.Windows.Forms.Label
        Me.btnSearchSubBlock = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtSubBlock = New System.Windows.Forms.TextBox
        Me.lblsubBlock = New System.Windows.Forms.Label
        Me.lblYOPName = New System.Windows.Forms.Label
        Me.lblDivName = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtYOP = New System.Windows.Forms.TextBox
        Me.lblYOP = New System.Windows.Forms.Label
        Me.txtDiv = New System.Windows.Forms.TextBox
        Me.lblDiv = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblBudgetYear = New System.Windows.Forms.Label
        Me.lblBudgetyearL = New System.Windows.Forms.Label
        Me.tbView = New System.Windows.Forms.TabPage
        Me.tbFertilizerRequirementBudget.SuspendLayout()
        Me.tbFertilizer.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgYieldBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbFertilizerRequirementBudget
        '
        Me.tbFertilizerRequirementBudget.Controls.Add(Me.tbFertilizer)
        Me.tbFertilizerRequirementBudget.Controls.Add(Me.tbView)
        Me.tbFertilizerRequirementBudget.Location = New System.Drawing.Point(12, 2)
        Me.tbFertilizerRequirementBudget.Name = "tbFertilizerRequirementBudget"
        Me.tbFertilizerRequirementBudget.SelectedIndex = 0
        Me.tbFertilizerRequirementBudget.Size = New System.Drawing.Size(1009, 638)
        Me.tbFertilizerRequirementBudget.TabIndex = 0
        '
        'tbFertilizer
        '
        Me.tbFertilizer.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbFertilizer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbFertilizer.Controls.Add(Me.GroupBox3)
        Me.tbFertilizer.Controls.Add(Me.btnSaveAll)
        Me.tbFertilizer.Controls.Add(Me.btnResetAll)
        Me.tbFertilizer.Controls.Add(Me.btnClose)
        Me.tbFertilizer.Controls.Add(Me.btnReset)
        Me.tbFertilizer.Controls.Add(Me.btnAdd)
        Me.tbFertilizer.Controls.Add(Me.lblRounds)
        Me.tbFertilizer.Controls.Add(Me.cmbRounds)
        Me.tbFertilizer.Controls.Add(Me.Label6)
        Me.tbFertilizer.Controls.Add(Me.GroupBox2)
        Me.tbFertilizer.Controls.Add(Me.GroupBox1)
        Me.tbFertilizer.Controls.Add(Me.lblHect)
        Me.tbFertilizer.Controls.Add(Me.Label3)
        Me.tbFertilizer.Controls.Add(Me.lblHecterage)
        Me.tbFertilizer.Controls.Add(Me.btnSearchSubBlock)
        Me.tbFertilizer.Controls.Add(Me.Label23)
        Me.tbFertilizer.Controls.Add(Me.txtSubBlock)
        Me.tbFertilizer.Controls.Add(Me.lblsubBlock)
        Me.tbFertilizer.Controls.Add(Me.lblYOPName)
        Me.tbFertilizer.Controls.Add(Me.lblDivName)
        Me.tbFertilizer.Controls.Add(Me.Label24)
        Me.tbFertilizer.Controls.Add(Me.Label8)
        Me.tbFertilizer.Controls.Add(Me.txtYOP)
        Me.tbFertilizer.Controls.Add(Me.lblYOP)
        Me.tbFertilizer.Controls.Add(Me.txtDiv)
        Me.tbFertilizer.Controls.Add(Me.lblDiv)
        Me.tbFertilizer.Controls.Add(Me.Label2)
        Me.tbFertilizer.Controls.Add(Me.lblBudgetYear)
        Me.tbFertilizer.Controls.Add(Me.lblBudgetyearL)
        Me.tbFertilizer.Location = New System.Drawing.Point(4, 22)
        Me.tbFertilizer.Name = "tbFertilizer"
        Me.tbFertilizer.Padding = New System.Windows.Forms.Padding(3)
        Me.tbFertilizer.Size = New System.Drawing.Size(1001, 612)
        Me.tbFertilizer.TabIndex = 0
        Me.tbFertilizer.Text = "Fertilizer Requirement"
        Me.tbFertilizer.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgYieldBudget)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 312)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(953, 232)
        Me.GroupBox3.TabIndex = 440
        Me.GroupBox3.TabStop = False
        '
        'dgYieldBudget
        '
        Me.dgYieldBudget.AllowUserToAddRows = False
        Me.dgYieldBudget.AllowUserToDeleteRows = False
        Me.dgYieldBudget.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgYieldBudget.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgYieldBudget.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgYieldBudget.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.YieldBudgetID, Me.EstateID, Me.BudgetYear, Me.YieldID, Me.Column1, Me.DivID, Me.Column2, Me.YOPID, Me.BlockID, Me.Column3, Me.Column6, Me.Column4, Me.Column5})
        Me.dgYieldBudget.EnableHeadersVisualStyles = False
        Me.dgYieldBudget.Location = New System.Drawing.Point(8, 10)
        Me.dgYieldBudget.Name = "dgYieldBudget"
        Me.dgYieldBudget.RowHeadersVisible = False
        Me.dgYieldBudget.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgYieldBudget.ShowCellErrors = False
        Me.dgYieldBudget.Size = New System.Drawing.Size(930, 216)
        Me.dgYieldBudget.TabIndex = 0
        '
        'YieldBudgetID
        '
        Me.YieldBudgetID.DataPropertyName = "YieldBudgetID"
        Me.YieldBudgetID.HeaderText = "YieldBudgetID"
        Me.YieldBudgetID.Name = "YieldBudgetID"
        Me.YieldBudgetID.Visible = False
        '
        'EstateID
        '
        Me.EstateID.DataPropertyName = "EstateID"
        Me.EstateID.HeaderText = "EstateID"
        Me.EstateID.Name = "EstateID"
        Me.EstateID.Visible = False
        '
        'BudgetYear
        '
        Me.BudgetYear.DataPropertyName = "BudgetYear"
        Me.BudgetYear.HeaderText = "BudgetYear"
        Me.BudgetYear.Name = "BudgetYear"
        '
        'YieldID
        '
        Me.YieldID.DataPropertyName = "YieldID"
        Me.YieldID.HeaderText = "YieldID"
        Me.YieldID.Name = "YieldID"
        Me.YieldID.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "YOP"
        Me.Column1.Name = "Column1"
        '
        'DivID
        '
        Me.DivID.DataPropertyName = "DivID"
        Me.DivID.HeaderText = "AfdelingID"
        Me.DivID.Name = "DivID"
        Me.DivID.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Afdeling"
        Me.Column2.Name = "Column2"
        '
        'YOPID
        '
        Me.YOPID.DataPropertyName = "YOPID"
        Me.YOPID.HeaderText = "YOPID"
        Me.YOPID.Name = "YOPID"
        Me.YOPID.Visible = False
        '
        'BlockID
        '
        Me.BlockID.DataPropertyName = "BlockID"
        Me.BlockID.HeaderText = "FieldNoID"
        Me.BlockID.Name = "BlockID"
        Me.BlockID.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "Field No"
        Me.Column3.Name = "Column3"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Rounds"
        Me.Column6.Name = "Column6"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Stock Code"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Organic"
        Me.Column5.Name = "Column5"
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(641, 572)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(97, 25)
        Me.btnSaveAll.TabIndex = 437
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
        Me.btnResetAll.Location = New System.Drawing.Point(741, 572)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(97, 25)
        Me.btnResetAll.TabIndex = 438
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(841, 572)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(97, 25)
        Me.btnClose.TabIndex = 439
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(776, 281)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(97, 25)
        Me.btnReset.TabIndex = 436
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(673, 281)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(97, 25)
        Me.btnAdd.TabIndex = 435
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblRounds
        '
        Me.lblRounds.AutoSize = True
        Me.lblRounds.ForeColor = System.Drawing.Color.Red
        Me.lblRounds.Location = New System.Drawing.Point(19, 132)
        Me.lblRounds.Name = "lblRounds"
        Me.lblRounds.Size = New System.Drawing.Size(49, 13)
        Me.lblRounds.TabIndex = 433
        Me.lblRounds.Text = "Rounds"
        '
        'cmbRounds
        '
        Me.cmbRounds.FormattingEnabled = True
        Me.cmbRounds.Location = New System.Drawing.Point(138, 130)
        Me.cmbRounds.Name = "cmbRounds"
        Me.cmbRounds.Size = New System.Drawing.Size(135, 21)
        Me.cmbRounds.TabIndex = 432
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(113, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 434
        Me.Label6.Text = ":"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblOrganic)
        Me.GroupBox2.Controls.Add(Me.cmbOrganic)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtOrganicKG)
        Me.GroupBox2.Controls.Add(Me.lblOrganicKG)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtStockKG)
        Me.GroupBox2.Controls.Add(Me.lblStockKg)
        Me.GroupBox2.Controls.Add(Me.lblOrganicTons)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblOrganicTonsL)
        Me.GroupBox2.Controls.Add(Me.lblStockTons)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lblStockTonsL)
        Me.GroupBox2.Controls.Add(Me.lblStockCode)
        Me.GroupBox2.Controls.Add(Me.btnSearchStockCode)
        Me.GroupBox2.Controls.Add(Me.txtStockCode)
        Me.GroupBox2.Controls.Add(Me.lblColon4)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(643, 133)
        Me.GroupBox2.TabIndex = 236
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Details"
        '
        'lblOrganic
        '
        Me.lblOrganic.AutoSize = True
        Me.lblOrganic.ForeColor = System.Drawing.Color.Red
        Me.lblOrganic.Location = New System.Drawing.Point(365, 19)
        Me.lblOrganic.Name = "lblOrganic"
        Me.lblOrganic.Size = New System.Drawing.Size(51, 13)
        Me.lblOrganic.TabIndex = 430
        Me.lblOrganic.Text = "Organic"
        '
        'cmbOrganic
        '
        Me.cmbOrganic.FormattingEnabled = True
        Me.cmbOrganic.Location = New System.Drawing.Point(478, 17)
        Me.cmbOrganic.Name = "cmbOrganic"
        Me.cmbOrganic.Size = New System.Drawing.Size(135, 21)
        Me.cmbOrganic.TabIndex = 429
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(461, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(11, 13)
        Me.Label19.TabIndex = 431
        Me.Label19.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(461, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 13)
        Me.Label16.TabIndex = 428
        Me.Label16.Text = ":"
        '
        'txtOrganicKG
        '
        Me.txtOrganicKG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrganicKG.Enabled = False
        Me.txtOrganicKG.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrganicKG.Location = New System.Drawing.Point(478, 52)
        Me.txtOrganicKG.Name = "txtOrganicKG"
        Me.txtOrganicKG.Size = New System.Drawing.Size(135, 21)
        Me.txtOrganicKG.TabIndex = 426
        '
        'lblOrganicKG
        '
        Me.lblOrganicKG.AutoSize = True
        Me.lblOrganicKG.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrganicKG.ForeColor = System.Drawing.Color.Red
        Me.lblOrganicKG.Location = New System.Drawing.Point(365, 52)
        Me.lblOrganicKG.Name = "lblOrganicKG"
        Me.lblOrganicKG.Size = New System.Drawing.Size(65, 13)
        Me.lblOrganicKG.TabIndex = 427
        Me.lblOrganicKG.Text = "KG / Palm"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(114, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 13)
        Me.Label13.TabIndex = 425
        Me.Label13.Text = ":"
        '
        'txtStockKG
        '
        Me.txtStockKG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockKG.Enabled = False
        Me.txtStockKG.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockKG.Location = New System.Drawing.Point(138, 52)
        Me.txtStockKG.Name = "txtStockKG"
        Me.txtStockKG.Size = New System.Drawing.Size(135, 21)
        Me.txtStockKG.TabIndex = 423
        '
        'lblStockKg
        '
        Me.lblStockKg.AutoSize = True
        Me.lblStockKg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockKg.ForeColor = System.Drawing.Color.Red
        Me.lblStockKg.Location = New System.Drawing.Point(6, 52)
        Me.lblStockKg.Name = "lblStockKg"
        Me.lblStockKg.Size = New System.Drawing.Size(65, 13)
        Me.lblStockKg.TabIndex = 424
        Me.lblStockKg.Text = "KG / Palm"
        '
        'lblOrganicTons
        '
        Me.lblOrganicTons.BackColor = System.Drawing.SystemColors.Control
        Me.lblOrganicTons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrganicTons.Location = New System.Drawing.Point(478, 85)
        Me.lblOrganicTons.Name = "lblOrganicTons"
        Me.lblOrganicTons.Size = New System.Drawing.Size(135, 21)
        Me.lblOrganicTons.TabIndex = 422
        Me.lblOrganicTons.Text = " "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(461, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 421
        Me.Label10.Text = ":"
        '
        'lblOrganicTonsL
        '
        Me.lblOrganicTonsL.AutoSize = True
        Me.lblOrganicTonsL.Location = New System.Drawing.Point(365, 85)
        Me.lblOrganicTonsL.Name = "lblOrganicTonsL"
        Me.lblOrganicTonsL.Size = New System.Drawing.Size(34, 13)
        Me.lblOrganicTonsL.TabIndex = 420
        Me.lblOrganicTonsL.Text = "Tons"
        '
        'lblStockTons
        '
        Me.lblStockTons.BackColor = System.Drawing.SystemColors.Control
        Me.lblStockTons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStockTons.Location = New System.Drawing.Point(138, 86)
        Me.lblStockTons.Name = "lblStockTons"
        Me.lblStockTons.Size = New System.Drawing.Size(135, 21)
        Me.lblStockTons.TabIndex = 419
        Me.lblStockTons.Text = " "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(114, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 418
        Me.Label5.Text = ":"
        '
        'lblStockTonsL
        '
        Me.lblStockTonsL.AutoSize = True
        Me.lblStockTonsL.Location = New System.Drawing.Point(6, 85)
        Me.lblStockTonsL.Name = "lblStockTonsL"
        Me.lblStockTonsL.Size = New System.Drawing.Size(34, 13)
        Me.lblStockTonsL.TabIndex = 417
        Me.lblStockTonsL.Text = "Tons"
        '
        'lblStockCode
        '
        Me.lblStockCode.AutoSize = True
        Me.lblStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockCode.ForeColor = System.Drawing.Color.Red
        Me.lblStockCode.Location = New System.Drawing.Point(6, 17)
        Me.lblStockCode.Name = "lblStockCode"
        Me.lblStockCode.Size = New System.Drawing.Size(73, 13)
        Me.lblStockCode.TabIndex = 414
        Me.lblStockCode.Text = "Stock Code"
        '
        'btnSearchStockCode
        '
        Me.btnSearchStockCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchStockCode.Image = CType(resources.GetObject("btnSearchStockCode.Image"), System.Drawing.Image)
        Me.btnSearchStockCode.Location = New System.Drawing.Point(298, 10)
        Me.btnSearchStockCode.Name = "btnSearchStockCode"
        Me.btnSearchStockCode.Size = New System.Drawing.Size(31, 26)
        Me.btnSearchStockCode.TabIndex = 416
        Me.btnSearchStockCode.TabStop = False
        Me.btnSearchStockCode.UseVisualStyleBackColor = True
        '
        'txtStockCode
        '
        Me.txtStockCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockCode.Location = New System.Drawing.Point(138, 14)
        Me.txtStockCode.MaxLength = 50
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(135, 21)
        Me.txtStockCode.TabIndex = 415
        '
        'lblColon4
        '
        Me.lblColon4.AutoSize = True
        Me.lblColon4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon4.Location = New System.Drawing.Point(113, 17)
        Me.lblColon4.Name = "lblColon4"
        Me.lblColon4.Size = New System.Drawing.Size(12, 13)
        Me.lblColon4.TabIndex = 413
        Me.lblColon4.Text = ":"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSPH)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lblSPHL)
        Me.GroupBox1.Controls.Add(Me.lblTotalStands)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblTotalStandsL)
        Me.GroupBox1.Controls.Add(Me.lblSupplying)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.lblSupplyingL)
        Me.GroupBox1.Controls.Add(Me.lblInfilling)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblInFillingL)
        Me.GroupBox1.Controls.Add(Me.lblOriginal)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblOriginalL)
        Me.GroupBox1.Location = New System.Drawing.Point(655, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 200)
        Me.GroupBox1.TabIndex = 235
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Population Palm From YOP &&  Block Setup"
        '
        'lblSPH
        '
        Me.lblSPH.BackColor = System.Drawing.SystemColors.Control
        Me.lblSPH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSPH.Location = New System.Drawing.Point(135, 170)
        Me.lblSPH.Name = "lblSPH"
        Me.lblSPH.Size = New System.Drawing.Size(136, 21)
        Me.lblSPH.TabIndex = 249
        Me.lblSPH.Text = " "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(118, 171)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 13)
        Me.Label17.TabIndex = 248
        Me.Label17.Text = ":"
        '
        'lblSPHL
        '
        Me.lblSPHL.AutoSize = True
        Me.lblSPHL.Location = New System.Drawing.Point(20, 170)
        Me.lblSPHL.Name = "lblSPHL"
        Me.lblSPHL.Size = New System.Drawing.Size(38, 13)
        Me.lblSPHL.TabIndex = 247
        Me.lblSPHL.Text = "S.P.H"
        '
        'lblTotalStands
        '
        Me.lblTotalStands.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotalStands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalStands.Location = New System.Drawing.Point(135, 137)
        Me.lblTotalStands.Name = "lblTotalStands"
        Me.lblTotalStands.Size = New System.Drawing.Size(136, 21)
        Me.lblTotalStands.TabIndex = 246
        Me.lblTotalStands.Text = " "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(118, 138)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 245
        Me.Label11.Text = ":"
        '
        'lblTotalStandsL
        '
        Me.lblTotalStandsL.AutoSize = True
        Me.lblTotalStandsL.Location = New System.Drawing.Point(20, 137)
        Me.lblTotalStandsL.Name = "lblTotalStandsL"
        Me.lblTotalStandsL.Size = New System.Drawing.Size(78, 13)
        Me.lblTotalStandsL.TabIndex = 244
        Me.lblTotalStandsL.Text = "Total Stands"
        '
        'lblSupplying
        '
        Me.lblSupplying.BackColor = System.Drawing.SystemColors.Control
        Me.lblSupplying.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSupplying.Location = New System.Drawing.Point(135, 101)
        Me.lblSupplying.Name = "lblSupplying"
        Me.lblSupplying.Size = New System.Drawing.Size(136, 21)
        Me.lblSupplying.TabIndex = 243
        Me.lblSupplying.Text = " "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(118, 102)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 13)
        Me.Label14.TabIndex = 242
        Me.Label14.Text = ":"
        '
        'lblSupplyingL
        '
        Me.lblSupplyingL.AutoSize = True
        Me.lblSupplyingL.Location = New System.Drawing.Point(20, 101)
        Me.lblSupplyingL.Name = "lblSupplyingL"
        Me.lblSupplyingL.Size = New System.Drawing.Size(63, 13)
        Me.lblSupplyingL.TabIndex = 241
        Me.lblSupplyingL.Text = "Supplying"
        '
        'lblInfilling
        '
        Me.lblInfilling.BackColor = System.Drawing.SystemColors.Control
        Me.lblInfilling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInfilling.Location = New System.Drawing.Point(135, 64)
        Me.lblInfilling.Name = "lblInfilling"
        Me.lblInfilling.Size = New System.Drawing.Size(136, 21)
        Me.lblInfilling.TabIndex = 240
        Me.lblInfilling.Text = " "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(118, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 239
        Me.Label7.Text = ":"
        '
        'lblInFillingL
        '
        Me.lblInFillingL.AutoSize = True
        Me.lblInFillingL.Location = New System.Drawing.Point(20, 64)
        Me.lblInFillingL.Name = "lblInFillingL"
        Me.lblInFillingL.Size = New System.Drawing.Size(51, 13)
        Me.lblInFillingL.TabIndex = 238
        Me.lblInFillingL.Text = "InFilling"
        '
        'lblOriginal
        '
        Me.lblOriginal.BackColor = System.Drawing.SystemColors.Control
        Me.lblOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOriginal.Location = New System.Drawing.Point(135, 28)
        Me.lblOriginal.Name = "lblOriginal"
        Me.lblOriginal.Size = New System.Drawing.Size(136, 21)
        Me.lblOriginal.TabIndex = 237
        Me.lblOriginal.Text = " "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(118, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 236
        Me.Label4.Text = ":"
        '
        'lblOriginalL
        '
        Me.lblOriginalL.AutoSize = True
        Me.lblOriginalL.Location = New System.Drawing.Point(20, 28)
        Me.lblOriginalL.Name = "lblOriginalL"
        Me.lblOriginalL.Size = New System.Drawing.Size(51, 13)
        Me.lblOriginalL.TabIndex = 235
        Me.lblOriginalL.Text = "Original"
        '
        'lblHect
        '
        Me.lblHect.BackColor = System.Drawing.SystemColors.Control
        Me.lblHect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHect.Location = New System.Drawing.Point(449, 36)
        Me.lblHect.Name = "lblHect"
        Me.lblHect.Size = New System.Drawing.Size(104, 21)
        Me.lblHect.TabIndex = 234
        Me.lblHect.Text = " "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(432, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 233
        Me.Label3.Text = ":"
        '
        'lblHecterage
        '
        Me.lblHecterage.AutoSize = True
        Me.lblHecterage.Location = New System.Drawing.Point(357, 37)
        Me.lblHecterage.Name = "lblHecterage"
        Me.lblHecterage.Size = New System.Drawing.Size(65, 13)
        Me.lblHecterage.TabIndex = 232
        Me.lblHecterage.Text = "Hecterage"
        '
        'btnSearchSubBlock
        '
        Me.btnSearchSubBlock.BackgroundImage = CType(resources.GetObject("btnSearchSubBlock.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchSubBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchSubBlock.FlatAppearance.BorderSize = 0
        Me.btnSearchSubBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchSubBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchSubBlock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchSubBlock.Location = New System.Drawing.Point(298, 26)
        Me.btnSearchSubBlock.Name = "btnSearchSubBlock"
        Me.btnSearchSubBlock.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchSubBlock.TabIndex = 220
        Me.btnSearchSubBlock.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(113, 37)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 231
        Me.Label23.Text = ":"
        '
        'txtSubBlock
        '
        Me.txtSubBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubBlock.Location = New System.Drawing.Point(138, 35)
        Me.txtSubBlock.Name = "txtSubBlock"
        Me.txtSubBlock.Size = New System.Drawing.Size(135, 21)
        Me.txtSubBlock.TabIndex = 219
        '
        'lblsubBlock
        '
        Me.lblsubBlock.AutoSize = True
        Me.lblsubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubBlock.ForeColor = System.Drawing.Color.Red
        Me.lblsubBlock.Location = New System.Drawing.Point(19, 35)
        Me.lblsubBlock.Name = "lblsubBlock"
        Me.lblsubBlock.Size = New System.Drawing.Size(64, 13)
        Me.lblsubBlock.TabIndex = 230
        Me.lblsubBlock.Text = "Field No"
        '
        'lblYOPName
        '
        Me.lblYOPName.ForeColor = System.Drawing.Color.Blue
        Me.lblYOPName.Location = New System.Drawing.Point(298, 72)
        Me.lblYOPName.Name = "lblYOPName"
        Me.lblYOPName.Size = New System.Drawing.Size(101, 12)
        Me.lblYOPName.TabIndex = 229
        '
        'lblDivName
        '
        Me.lblDivName.ForeColor = System.Drawing.Color.Blue
        Me.lblDivName.Location = New System.Drawing.Point(343, 106)
        Me.lblDivName.Name = "lblDivName"
        Me.lblDivName.Size = New System.Drawing.Size(101, 12)
        Me.lblDivName.TabIndex = 228
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(113, 104)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(11, 13)
        Me.Label24.TabIndex = 227
        Me.Label24.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(113, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 13)
        Me.Label8.TabIndex = 226
        Me.Label8.Text = ":"
        '
        'txtYOP
        '
        Me.txtYOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYOP.Enabled = False
        Me.txtYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYOP.Location = New System.Drawing.Point(138, 67)
        Me.txtYOP.Name = "txtYOP"
        Me.txtYOP.Size = New System.Drawing.Size(135, 21)
        Me.txtYOP.TabIndex = 221
        '
        'lblYOP
        '
        Me.lblYOP.AutoSize = True
        Me.lblYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOP.ForeColor = System.Drawing.Color.Red
        Me.lblYOP.Location = New System.Drawing.Point(19, 67)
        Me.lblYOP.Name = "lblYOP"
        Me.lblYOP.Size = New System.Drawing.Size(30, 13)
        Me.lblYOP.TabIndex = 225
        Me.lblYOP.Text = "YOP"
        '
        'txtDiv
        '
        Me.txtDiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiv.Location = New System.Drawing.Point(138, 97)
        Me.txtDiv.Name = "txtDiv"
        Me.txtDiv.Size = New System.Drawing.Size(135, 21)
        Me.txtDiv.TabIndex = 222
        '
        'lblDiv
        '
        Me.lblDiv.AutoSize = True
        Me.lblDiv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiv.ForeColor = System.Drawing.Color.Red
        Me.lblDiv.Location = New System.Drawing.Point(19, 97)
        Me.lblDiv.Name = "lblDiv"
        Me.lblDiv.Size = New System.Drawing.Size(26, 13)
        Me.lblDiv.TabIndex = 224
        Me.lblDiv.Text = "Afdeling"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(111, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 218
        Me.Label2.Text = ":"
        '
        'lblBudgetYear
        '
        Me.lblBudgetYear.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetYear.Location = New System.Drawing.Point(138, 3)
        Me.lblBudgetYear.Name = "lblBudgetYear"
        Me.lblBudgetYear.Size = New System.Drawing.Size(136, 21)
        Me.lblBudgetYear.TabIndex = 217
        Me.lblBudgetYear.Text = " "
        '
        'lblBudgetyearL
        '
        Me.lblBudgetyearL.AutoSize = True
        Me.lblBudgetyearL.Location = New System.Drawing.Point(17, 3)
        Me.lblBudgetyearL.Name = "lblBudgetyearL"
        Me.lblBudgetyearL.Size = New System.Drawing.Size(77, 13)
        Me.lblBudgetyearL.TabIndex = 216
        Me.lblBudgetyearL.Text = "Budget Year"
        '
        'tbView
        '
        Me.tbView.Location = New System.Drawing.Point(4, 22)
        Me.tbView.Name = "tbView"
        Me.tbView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbView.Size = New System.Drawing.Size(1001, 612)
        Me.tbView.TabIndex = 1
        Me.tbView.Text = "View"
        Me.tbView.UseVisualStyleBackColor = True
        '
        'FertilizerRequirementBudgetFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1266, 652)
        Me.Controls.Add(Me.tbFertilizerRequirementBudget)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FertilizerRequirementBudgetFrm"
        Me.Text = "FertilizerRequirementBudgetFrm"
        Me.tbFertilizerRequirementBudget.ResumeLayout(False)
        Me.tbFertilizer.ResumeLayout(False)
        Me.tbFertilizer.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgYieldBudget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbFertilizerRequirementBudget As System.Windows.Forms.TabControl
    Friend WithEvents tbFertilizer As System.Windows.Forms.TabPage
    Friend WithEvents tbView As System.Windows.Forms.TabPage
    Friend WithEvents btnSearchSubBlock As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtSubBlock As System.Windows.Forms.TextBox
    Friend WithEvents lblsubBlock As System.Windows.Forms.Label
    Friend WithEvents lblYOPName As System.Windows.Forms.Label
    Friend WithEvents lblDivName As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtYOP As System.Windows.Forms.TextBox
    Friend WithEvents lblYOP As System.Windows.Forms.Label
    Friend WithEvents txtDiv As System.Windows.Forms.TextBox
    Friend WithEvents lblDiv As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBudgetYear As System.Windows.Forms.Label
    Friend WithEvents lblBudgetyearL As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblHect As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblHecterage As System.Windows.Forms.Label
    Friend WithEvents lblInfilling As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblInFillingL As System.Windows.Forms.Label
    Friend WithEvents lblOriginal As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblOriginalL As System.Windows.Forms.Label
    Friend WithEvents lblSPH As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblSPHL As System.Windows.Forms.Label
    Friend WithEvents lblTotalStands As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblTotalStandsL As System.Windows.Forms.Label
    Friend WithEvents lblSupplying As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblSupplyingL As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblOrganicTons As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblOrganicTonsL As System.Windows.Forms.Label
    Friend WithEvents lblStockTons As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblStockTonsL As System.Windows.Forms.Label
    Friend WithEvents lblStockCode As System.Windows.Forms.Label
    Friend WithEvents btnSearchStockCode As System.Windows.Forms.Button
    Friend WithEvents txtStockCode As System.Windows.Forms.TextBox
    Friend WithEvents lblColon4 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtOrganicKG As System.Windows.Forms.TextBox
    Friend WithEvents lblOrganicKG As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtStockKG As System.Windows.Forms.TextBox
    Friend WithEvents lblStockKg As System.Windows.Forms.Label
    Friend WithEvents lblOrganic As System.Windows.Forms.Label
    Friend WithEvents cmbOrganic As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblRounds As System.Windows.Forms.Label
    Friend WithEvents cmbRounds As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgYieldBudget As System.Windows.Forms.DataGridView
    Friend WithEvents YieldBudgetID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YieldID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YOPID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

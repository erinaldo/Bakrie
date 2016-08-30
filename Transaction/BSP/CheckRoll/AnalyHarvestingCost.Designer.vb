<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnalyHarvestingCost
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnalyHarvestingCost))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panCPO = New System.Windows.Forms.Panel
        Me.btnDeleteAll = New System.Windows.Forms.Button
        Me.grpTransKernelRecords = New System.Windows.Forms.GroupBox
        Me.dgvWBFruitWt = New System.Windows.Forms.DataGridView
        Me.dgclYOP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclFFBWt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclFFBBunches = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclOtherSeperate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclHarvestor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclYOPValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsTranshipKernel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TranshipEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.TranshipDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblMonthYear = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblTransDate = New System.Windows.Forms.Label
        Me.grpTransKernel = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFFBBunches = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblToLoading = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtHarvestorWt = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnResetTrans = New System.Windows.Forms.Button
        Me.btnAddTrans = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtOtherSeperateWt = New System.Windows.Forms.TextBox
        Me.lblTransMonthDate = New System.Windows.Forms.Label
        Me.txtFFBWt = New System.Windows.Forms.TextBox
        Me.lblTransQty = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblTransStorage = New System.Windows.Forms.Label
        Me.cmbYOP = New System.Windows.Forms.ComboBox
        Me.lblT3Name = New System.Windows.Forms.Label
        Me.lblT1Name = New System.Windows.Forms.Label
        Me.btnSaveAll = New System.Windows.Forms.Button
        Me.tpKernelView = New System.Windows.Forms.TabPage
        Me.dgvWBFruitWtDetailsView = New System.Windows.Forms.DataGridView
        Me.dgclMonthYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclWBFruitWtID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsKernel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.lblViewStatus = New System.Windows.Forms.Label
        Me.dtpAdjustmentViewDate = New System.Windows.Forms.DateTimePicker
        Me.lblSearch = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblAdjSearchNo = New System.Windows.Forms.Label
        Me.CMSLoadCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LoadCPOEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadCPODelete = New System.Windows.Forms.ToolStripMenuItem
        Me.tpKernelSave = New System.Windows.Forms.TabPage
        Me.StockCPODelete = New System.Windows.Forms.ToolStripMenuItem
        Me.tcTransKernel = New System.Windows.Forms.TabControl
        Me.StockCPOEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsStockCPO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.panCPO.SuspendLayout()
        Me.grpTransKernelRecords.SuspendLayout()
        CType(Me.dgvWBFruitWt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsTranshipKernel.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grpTransKernel.SuspendLayout()
        Me.tpKernelView.SuspendLayout()
        CType(Me.dgvWBFruitWtDetailsView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsKernel.SuspendLayout()
        Me.CMSLoadCPO.SuspendLayout()
        Me.tpKernelSave.SuspendLayout()
        Me.tcTransKernel.SuspendLayout()
        Me.cmsStockCPO.SuspendLayout()
        Me.SuspendLayout()
        '
        'panCPO
        '
        Me.panCPO.AutoScroll = True
        Me.panCPO.BackColor = System.Drawing.Color.Transparent
        Me.panCPO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panCPO.Controls.Add(Me.btnDeleteAll)
        Me.panCPO.Controls.Add(Me.grpTransKernelRecords)
        Me.panCPO.Controls.Add(Me.btnClose)
        Me.panCPO.Controls.Add(Me.btnReset)
        Me.panCPO.Controls.Add(Me.GroupBox3)
        Me.panCPO.Controls.Add(Me.grpTransKernel)
        Me.panCPO.Controls.Add(Me.btnSaveAll)
        Me.panCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panCPO.Location = New System.Drawing.Point(3, 3)
        Me.panCPO.Name = "panCPO"
        Me.panCPO.Size = New System.Drawing.Size(748, 486)
        Me.panCPO.TabIndex = 0
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnDeleteAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteAll.Image = Global.BSP.My.Resources.Resources.icon_delete
        Me.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteAll.Location = New System.Drawing.Point(540, 427)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(117, 25)
        Me.btnDeleteAll.TabIndex = 6
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        Me.btnDeleteAll.Visible = False
        '
        'grpTransKernelRecords
        '
        Me.grpTransKernelRecords.BackColor = System.Drawing.Color.Transparent
        Me.grpTransKernelRecords.Controls.Add(Me.dgvWBFruitWt)
        Me.grpTransKernelRecords.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTransKernelRecords.Location = New System.Drawing.Point(5, 262)
        Me.grpTransKernelRecords.Name = "grpTransKernelRecords"
        Me.grpTransKernelRecords.Size = New System.Drawing.Size(669, 148)
        Me.grpTransKernelRecords.TabIndex = 2
        Me.grpTransKernelRecords.TabStop = False
        '
        'dgvWBFruitWt
        '
        Me.dgvWBFruitWt.AllowUserToAddRows = False
        Me.dgvWBFruitWt.AllowUserToDeleteRows = False
        Me.dgvWBFruitWt.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvWBFruitWt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvWBFruitWt.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvWBFruitWt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvWBFruitWt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWBFruitWt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvWBFruitWt.ColumnHeadersHeight = 30
        Me.dgvWBFruitWt.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclYOP, Me.dgclFFBWt, Me.dgclFFBBunches, Me.dgclOtherSeperate, Me.dgclHarvestor, Me.dgclYOPValue})
        Me.dgvWBFruitWt.ContextMenuStrip = Me.cmsTranshipKernel
        Me.dgvWBFruitWt.EnableHeadersVisualStyles = False
        Me.dgvWBFruitWt.GridColor = System.Drawing.Color.Gray
        Me.dgvWBFruitWt.Location = New System.Drawing.Point(3, 20)
        Me.dgvWBFruitWt.MultiSelect = False
        Me.dgvWBFruitWt.Name = "dgvWBFruitWt"
        Me.dgvWBFruitWt.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWBFruitWt.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvWBFruitWt.RowHeadersVisible = False
        Me.dgvWBFruitWt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWBFruitWt.Size = New System.Drawing.Size(660, 117)
        Me.dgvWBFruitWt.TabIndex = 0
        Me.dgvWBFruitWt.TabStop = False
        '
        'dgclYOP
        '
        Me.dgclYOP.DataPropertyName = "YOP"
        Me.dgclYOP.HeaderText = "Afdeling - YOP"
        Me.dgclYOP.Name = "dgclYOP"
        Me.dgclYOP.ReadOnly = True
        Me.dgclYOP.Width = 200
        '
        'dgclFFBWt
        '
        Me.dgclFFBWt.DataPropertyName = "FFBWt"
        Me.dgclFFBWt.HeaderText = "Mill Weight"
        Me.dgclFFBWt.Name = "dgclFFBWt"
        Me.dgclFFBWt.ReadOnly = True
        '
        'dgclFFBBunches
        '
        Me.dgclFFBBunches.DataPropertyName = "FFBBunches"
        Me.dgclFFBBunches.HeaderText = "Mill Bunches"
        Me.dgclFFBBunches.Name = "dgclFFBBunches"
        Me.dgclFFBBunches.ReadOnly = True
        Me.dgclFFBBunches.Width = 125
        '
        'dgclOtherSeperate
        '
        Me.dgclOtherSeperate.DataPropertyName = "OthersWt"
        Me.dgclOtherSeperate.HeaderText = "LF - Other/Seperate"
        Me.dgclOtherSeperate.Name = "dgclOtherSeperate"
        Me.dgclOtherSeperate.ReadOnly = True
        Me.dgclOtherSeperate.Width = 150
        '
        'dgclHarvestor
        '
        Me.dgclHarvestor.DataPropertyName = "HarvestersWt"
        Me.dgclHarvestor.HeaderText = "LF - Harvester"
        Me.dgclHarvestor.Name = "dgclHarvestor"
        Me.dgclHarvestor.ReadOnly = True
        Me.dgclHarvestor.Visible = False
        Me.dgclHarvestor.Width = 125
        '
        'dgclYOPValue
        '
        Me.dgclYOPValue.DataPropertyName = "YOPValue"
        Me.dgclYOPValue.HeaderText = "YOPValue"
        Me.dgclYOPValue.Name = "dgclYOPValue"
        Me.dgclYOPValue.ReadOnly = True
        Me.dgclYOPValue.Visible = False
        '
        'cmsTranshipKernel
        '
        Me.cmsTranshipKernel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TranshipEdit, Me.TranshipDelete})
        Me.cmsTranshipKernel.Name = "cmsIPR"
        Me.cmsTranshipKernel.Size = New System.Drawing.Size(117, 48)
        '
        'TranshipEdit
        '
        Me.TranshipEdit.Image = CType(resources.GetObject("TranshipEdit.Image"), System.Drawing.Image)
        Me.TranshipEdit.Name = "TranshipEdit"
        Me.TranshipEdit.Size = New System.Drawing.Size(116, 22)
        Me.TranshipEdit.Text = "Edit"
        '
        'TranshipDelete
        '
        Me.TranshipDelete.Image = CType(resources.GetObject("TranshipDelete.Image"), System.Drawing.Image)
        Me.TranshipDelete.Name = "TranshipDelete"
        Me.TranshipDelete.Size = New System.Drawing.Size(116, 22)
        Me.TranshipDelete.Text = "Delete"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(436, 427)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 25)
        Me.btnClose.TabIndex = 5
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
        Me.btnReset.Location = New System.Drawing.Point(318, 427)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(112, 25)
        Me.btnReset.TabIndex = 4
        Me.btnReset.Text = "Reset All"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox3.Controls.Add(Me.lblMonthYear)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.lblTransDate)
        Me.GroupBox3.Location = New System.Drawing.Point(2, -6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(672, 44)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'lblMonthYear
        '
        Me.lblMonthYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMonthYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblMonthYear.Location = New System.Drawing.Point(191, 15)
        Me.lblMonthYear.Name = "lblMonthYear"
        Me.lblMonthYear.Size = New System.Drawing.Size(71, 16)
        Me.lblMonthYear.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(160, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = ":"
        '
        'lblTransDate
        '
        Me.lblTransDate.AutoSize = True
        Me.lblTransDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransDate.Location = New System.Drawing.Point(10, 16)
        Me.lblTransDate.Name = "lblTransDate"
        Me.lblTransDate.Size = New System.Drawing.Size(41, 13)
        Me.lblTransDate.TabIndex = 0
        Me.lblTransDate.Text = "Month"
        '
        'grpTransKernel
        '
        Me.grpTransKernel.BackColor = System.Drawing.Color.Transparent
        Me.grpTransKernel.Controls.Add(Me.Label2)
        Me.grpTransKernel.Controls.Add(Me.txtFFBBunches)
        Me.grpTransKernel.Controls.Add(Me.Label3)
        Me.grpTransKernel.Controls.Add(Me.Label4)
        Me.grpTransKernel.Controls.Add(Me.lblToLoading)
        Me.grpTransKernel.Controls.Add(Me.Label5)
        Me.grpTransKernel.Controls.Add(Me.txtHarvestorWt)
        Me.grpTransKernel.Controls.Add(Me.Label6)
        Me.grpTransKernel.Controls.Add(Me.btnResetTrans)
        Me.grpTransKernel.Controls.Add(Me.btnAddTrans)
        Me.grpTransKernel.Controls.Add(Me.Label20)
        Me.grpTransKernel.Controls.Add(Me.Label23)
        Me.grpTransKernel.Controls.Add(Me.txtOtherSeperateWt)
        Me.grpTransKernel.Controls.Add(Me.lblTransMonthDate)
        Me.grpTransKernel.Controls.Add(Me.txtFFBWt)
        Me.grpTransKernel.Controls.Add(Me.lblTransQty)
        Me.grpTransKernel.Controls.Add(Me.Label16)
        Me.grpTransKernel.Controls.Add(Me.lblTransStorage)
        Me.grpTransKernel.Controls.Add(Me.cmbYOP)
        Me.grpTransKernel.Controls.Add(Me.lblT3Name)
        Me.grpTransKernel.Controls.Add(Me.lblT1Name)
        Me.grpTransKernel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTransKernel.Location = New System.Drawing.Point(3, 44)
        Me.grpTransKernel.Name = "grpTransKernel"
        Me.grpTransKernel.Size = New System.Drawing.Size(671, 212)
        Me.grpTransKernel.TabIndex = 1
        Me.grpTransKernel.TabStop = False
        Me.grpTransKernel.Text = "WB Weight Details"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(159, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = ":"
        '
        'txtFFBBunches
        '
        Me.txtFFBBunches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFFBBunches.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFFBBunches.Location = New System.Drawing.Point(190, 98)
        Me.txtFFBBunches.MaxLength = 18
        Me.txtFFBBunches.Name = "txtFFBBunches"
        Me.txtFFBBunches.Size = New System.Drawing.Size(98, 21)
        Me.txtFFBBunches.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(11, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Bunches"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Loose Fruit"
        '
        'lblToLoading
        '
        Me.lblToLoading.AutoSize = True
        Me.lblToLoading.Font = New System.Drawing.Font("Verdana", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToLoading.Location = New System.Drawing.Point(6, 51)
        Me.lblToLoading.Name = "lblToLoading"
        Me.lblToLoading.Size = New System.Drawing.Size(29, 13)
        Me.lblToLoading.TabIndex = 3
        Me.lblToLoading.Text = "Mill"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(159, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = ":"
        Me.Label5.Visible = False
        '
        'txtHarvestorWt
        '
        Me.txtHarvestorWt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHarvestorWt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHarvestorWt.Location = New System.Drawing.Point(190, 176)
        Me.txtHarvestorWt.MaxLength = 18
        Me.txtHarvestorWt.Name = "txtHarvestorWt"
        Me.txtHarvestorWt.Size = New System.Drawing.Size(98, 21)
        Me.txtHarvestorWt.TabIndex = 16
        Me.txtHarvestorWt.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Harvester (Kg)"
        Me.Label6.Visible = False
        '
        'btnResetTrans
        '
        Me.btnResetTrans.BackgroundImage = CType(resources.GetObject("btnResetTrans.BackgroundImage"), System.Drawing.Image)
        Me.btnResetTrans.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetTrans.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetTrans.Image = CType(resources.GetObject("btnResetTrans.Image"), System.Drawing.Image)
        Me.btnResetTrans.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnResetTrans.Location = New System.Drawing.Point(515, 169)
        Me.btnResetTrans.Name = "btnResetTrans"
        Me.btnResetTrans.Size = New System.Drawing.Size(81, 22)
        Me.btnResetTrans.TabIndex = 18
        Me.btnResetTrans.Text = "Reset"
        Me.btnResetTrans.UseVisualStyleBackColor = True
        '
        'btnAddTrans
        '
        Me.btnAddTrans.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAddTrans.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddTrans.Image = CType(resources.GetObject("btnAddTrans.Image"), System.Drawing.Image)
        Me.btnAddTrans.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAddTrans.Location = New System.Drawing.Point(420, 169)
        Me.btnAddTrans.Name = "btnAddTrans"
        Me.btnAddTrans.Size = New System.Drawing.Size(78, 22)
        Me.btnAddTrans.TabIndex = 17
        Me.btnAddTrans.Text = "Add"
        Me.btnAddTrans.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(159, 73)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = ":"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(159, 151)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = ":"
        '
        'txtOtherSeperateWt
        '
        Me.txtOtherSeperateWt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOtherSeperateWt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtherSeperateWt.Location = New System.Drawing.Point(190, 149)
        Me.txtOtherSeperateWt.MaxLength = 18
        Me.txtOtherSeperateWt.Name = "txtOtherSeperateWt"
        Me.txtOtherSeperateWt.Size = New System.Drawing.Size(98, 21)
        Me.txtOtherSeperateWt.TabIndex = 13
        '
        'lblTransMonthDate
        '
        Me.lblTransMonthDate.AutoSize = True
        Me.lblTransMonthDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransMonthDate.Location = New System.Drawing.Point(11, 151)
        Me.lblTransMonthDate.Name = "lblTransMonthDate"
        Me.lblTransMonthDate.Size = New System.Drawing.Size(137, 13)
        Me.lblTransMonthDate.TabIndex = 11
        Me.lblTransMonthDate.Text = "Other / Separate  (Kg)"
        '
        'txtFFBWt
        '
        Me.txtFFBWt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFFBWt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFFBWt.Location = New System.Drawing.Point(190, 71)
        Me.txtFFBWt.MaxLength = 18
        Me.txtFFBWt.Name = "txtFFBWt"
        Me.txtFFBWt.Size = New System.Drawing.Size(98, 21)
        Me.txtFFBWt.TabIndex = 6
        '
        'lblTransQty
        '
        Me.lblTransQty.AutoSize = True
        Me.lblTransQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransQty.ForeColor = System.Drawing.Color.Red
        Me.lblTransQty.Location = New System.Drawing.Point(11, 73)
        Me.lblTransQty.Name = "lblTransQty"
        Me.lblTransQty.Size = New System.Drawing.Size(75, 13)
        Me.lblTransQty.TabIndex = 4
        Me.lblTransQty.Text = "Weight (Kg)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(159, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = ":"
        '
        'lblTransStorage
        '
        Me.lblTransStorage.AutoSize = True
        Me.lblTransStorage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransStorage.ForeColor = System.Drawing.Color.Red
        Me.lblTransStorage.Location = New System.Drawing.Point(11, 24)
        Me.lblTransStorage.Name = "lblTransStorage"
        Me.lblTransStorage.Size = New System.Drawing.Size(62, 13)
        Me.lblTransStorage.TabIndex = 0
        Me.lblTransStorage.Text = "Afdeling - YOP"
        '
        'cmbYOP
        '
        Me.cmbYOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYOP.FormattingEnabled = True
        Me.cmbYOP.Location = New System.Drawing.Point(190, 20)
        Me.cmbYOP.Name = "cmbYOP"
        Me.cmbYOP.Size = New System.Drawing.Size(222, 21)
        Me.cmbYOP.TabIndex = 2
        '
        'lblT3Name
        '
        Me.lblT3Name.AutoSize = True
        Me.lblT3Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT3Name.ForeColor = System.Drawing.Color.Black
        Me.lblT3Name.Location = New System.Drawing.Point(1247, 158)
        Me.lblT3Name.Name = "lblT3Name"
        Me.lblT3Name.Size = New System.Drawing.Size(0, 13)
        Me.lblT3Name.TabIndex = 158
        '
        'lblT1Name
        '
        Me.lblT1Name.AutoSize = True
        Me.lblT1Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT1Name.ForeColor = System.Drawing.Color.Black
        Me.lblT1Name.Location = New System.Drawing.Point(1247, 130)
        Me.lblT1Name.Name = "lblT1Name"
        Me.lblT1Name.Size = New System.Drawing.Size(0, 13)
        Me.lblT1Name.TabIndex = 157
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(180, 427)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(132, 25)
        Me.btnSaveAll.TabIndex = 3
        Me.btnSaveAll.Text = "Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'tpKernelView
        '
        Me.tpKernelView.AutoScroll = True
        Me.tpKernelView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tpKernelView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpKernelView.Controls.Add(Me.dgvWBFruitWtDetailsView)
        Me.tpKernelView.Controls.Add(Me.lblViewStatus)
        Me.tpKernelView.Controls.Add(Me.dtpAdjustmentViewDate)
        Me.tpKernelView.Controls.Add(Me.lblSearch)
        Me.tpKernelView.Controls.Add(Me.Label13)
        Me.tpKernelView.Controls.Add(Me.lblAdjSearchNo)
        Me.tpKernelView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpKernelView.Location = New System.Drawing.Point(4, 22)
        Me.tpKernelView.Name = "tpKernelView"
        Me.tpKernelView.Padding = New System.Windows.Forms.Padding(3)
        Me.tpKernelView.Size = New System.Drawing.Size(754, 492)
        Me.tpKernelView.TabIndex = 1
        Me.tpKernelView.Text = "View"
        Me.tpKernelView.UseVisualStyleBackColor = True
        '
        'dgvWBFruitWtDetailsView
        '
        Me.dgvWBFruitWtDetailsView.AllowUserToAddRows = False
        Me.dgvWBFruitWtDetailsView.AllowUserToDeleteRows = False
        Me.dgvWBFruitWtDetailsView.AllowUserToResizeRows = False
        Me.dgvWBFruitWtDetailsView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvWBFruitWtDetailsView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvWBFruitWtDetailsView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWBFruitWtDetailsView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvWBFruitWtDetailsView.ColumnHeadersHeight = 30
        Me.dgvWBFruitWtDetailsView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclMonthYear, Me.dgclWBFruitWtID})
        Me.dgvWBFruitWtDetailsView.ContextMenuStrip = Me.cmsKernel
        Me.dgvWBFruitWtDetailsView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWBFruitWtDetailsView.EnableHeadersVisualStyles = False
        Me.dgvWBFruitWtDetailsView.GridColor = System.Drawing.Color.Gray
        Me.dgvWBFruitWtDetailsView.Location = New System.Drawing.Point(3, 3)
        Me.dgvWBFruitWtDetailsView.MultiSelect = False
        Me.dgvWBFruitWtDetailsView.Name = "dgvWBFruitWtDetailsView"
        Me.dgvWBFruitWtDetailsView.ReadOnly = True
        Me.dgvWBFruitWtDetailsView.RowHeadersVisible = False
        Me.dgvWBFruitWtDetailsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWBFruitWtDetailsView.Size = New System.Drawing.Size(748, 486)
        Me.dgvWBFruitWtDetailsView.TabIndex = 1
        Me.dgvWBFruitWtDetailsView.TabStop = False
        '
        'dgclMonthYear
        '
        Me.dgclMonthYear.DataPropertyName = "MonthYear"
        DataGridViewCellStyle5.Format = "dd/MM/yyyy"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.dgclMonthYear.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgclMonthYear.HeaderText = "Month Year"
        Me.dgclMonthYear.Name = "dgclMonthYear"
        Me.dgclMonthYear.ReadOnly = True
        '
        'dgclWBFruitWtID
        '
        Me.dgclWBFruitWtID.DataPropertyName = "WBFruitWtID"
        Me.dgclWBFruitWtID.HeaderText = "WBFruitWtID"
        Me.dgclWBFruitWtID.Name = "dgclWBFruitWtID"
        Me.dgclWBFruitWtID.ReadOnly = True
        Me.dgclWBFruitWtID.Visible = False
        '
        'cmsKernel
        '
        Me.cmsKernel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsKernel.Name = "cmsIPR"
        Me.cmsKernel.Size = New System.Drawing.Size(117, 70)
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
        'lblViewStatus
        '
        Me.lblViewStatus.AutoSize = True
        Me.lblViewStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblViewStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblViewStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblViewStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblViewStatus.Location = New System.Drawing.Point(343, -47)
        Me.lblViewStatus.Name = "lblViewStatus"
        Me.lblViewStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblViewStatus.TabIndex = 410
        Me.lblViewStatus.Text = "Status"
        '
        'dtpAdjustmentViewDate
        '
        Me.dtpAdjustmentViewDate.CalendarFont = New System.Drawing.Font("Verdana", 7.5!)
        Me.dtpAdjustmentViewDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtpAdjustmentViewDate.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.dtpAdjustmentViewDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpAdjustmentViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdjustmentViewDate.Location = New System.Drawing.Point(22, -25)
        Me.dtpAdjustmentViewDate.Name = "dtpAdjustmentViewDate"
        Me.dtpAdjustmentViewDate.Size = New System.Drawing.Size(135, 21)
        Me.dtpAdjustmentViewDate.TabIndex = 411
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearch.Location = New System.Drawing.Point(-70, -47)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(72, 13)
        Me.lblSearch.TabIndex = 407
        Me.lblSearch.Text = "Search By"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(8, -47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 14)
        Me.Label13.TabIndex = 408
        Me.Label13.Text = ":"
        '
        'lblAdjSearchNo
        '
        Me.lblAdjSearchNo.AutoSize = True
        Me.lblAdjSearchNo.BackColor = System.Drawing.Color.Transparent
        Me.lblAdjSearchNo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblAdjSearchNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAdjSearchNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAdjSearchNo.Location = New System.Drawing.Point(184, -46)
        Me.lblAdjSearchNo.Name = "lblAdjSearchNo"
        Me.lblAdjSearchNo.Size = New System.Drawing.Size(91, 13)
        Me.lblAdjSearchNo.TabIndex = 409
        Me.lblAdjSearchNo.Text = "Adjustment No"
        '
        'CMSLoadCPO
        '
        Me.CMSLoadCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadCPOEdit, Me.LoadCPODelete})
        Me.CMSLoadCPO.Name = "cmsIPR"
        Me.CMSLoadCPO.Size = New System.Drawing.Size(117, 48)
        '
        'LoadCPOEdit
        '
        Me.LoadCPOEdit.Image = CType(resources.GetObject("LoadCPOEdit.Image"), System.Drawing.Image)
        Me.LoadCPOEdit.Name = "LoadCPOEdit"
        Me.LoadCPOEdit.Size = New System.Drawing.Size(116, 22)
        Me.LoadCPOEdit.Text = "Edit"
        '
        'LoadCPODelete
        '
        Me.LoadCPODelete.Image = CType(resources.GetObject("LoadCPODelete.Image"), System.Drawing.Image)
        Me.LoadCPODelete.Name = "LoadCPODelete"
        Me.LoadCPODelete.Size = New System.Drawing.Size(116, 22)
        Me.LoadCPODelete.Text = "Delete"
        '
        'tpKernelSave
        '
        Me.tpKernelSave.AutoScroll = True
        Me.tpKernelSave.BackgroundImage = CType(resources.GetObject("tpKernelSave.BackgroundImage"), System.Drawing.Image)
        Me.tpKernelSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpKernelSave.Controls.Add(Me.panCPO)
        Me.tpKernelSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpKernelSave.Location = New System.Drawing.Point(4, 22)
        Me.tpKernelSave.Name = "tpKernelSave"
        Me.tpKernelSave.Padding = New System.Windows.Forms.Padding(3)
        Me.tpKernelSave.Size = New System.Drawing.Size(754, 492)
        Me.tpKernelSave.TabIndex = 0
        Me.tpKernelSave.Text = "WB Fruit Weight Details" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.tpKernelSave.UseVisualStyleBackColor = True
        '
        'StockCPODelete
        '
        Me.StockCPODelete.Image = CType(resources.GetObject("StockCPODelete.Image"), System.Drawing.Image)
        Me.StockCPODelete.Name = "StockCPODelete"
        Me.StockCPODelete.Size = New System.Drawing.Size(116, 22)
        Me.StockCPODelete.Text = "Delete"
        '
        'tcTransKernel
        '
        Me.tcTransKernel.Controls.Add(Me.tpKernelSave)
        Me.tcTransKernel.Controls.Add(Me.tpKernelView)
        Me.tcTransKernel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcTransKernel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcTransKernel.Location = New System.Drawing.Point(0, 0)
        Me.tcTransKernel.Name = "tcTransKernel"
        Me.tcTransKernel.SelectedIndex = 0
        Me.tcTransKernel.Size = New System.Drawing.Size(762, 518)
        Me.tcTransKernel.TabIndex = 0
        Me.tcTransKernel.TabStop = False
        '
        'StockCPOEdit
        '
        Me.StockCPOEdit.Image = CType(resources.GetObject("StockCPOEdit.Image"), System.Drawing.Image)
        Me.StockCPOEdit.Name = "StockCPOEdit"
        Me.StockCPOEdit.Size = New System.Drawing.Size(116, 22)
        Me.StockCPOEdit.Text = "Edit"
        '
        'cmsStockCPO
        '
        Me.cmsStockCPO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StockCPOEdit, Me.StockCPODelete})
        Me.cmsStockCPO.Name = "cmsIPR"
        Me.cmsStockCPO.Size = New System.Drawing.Size(117, 48)
        '
        'AnalyHarvestingCost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(762, 518)
        Me.Controls.Add(Me.tcTransKernel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "AnalyHarvestingCost"
        Me.Text = "AnalyHarvestingCost"
        Me.panCPO.ResumeLayout(False)
        Me.grpTransKernelRecords.ResumeLayout(False)
        CType(Me.dgvWBFruitWt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsTranshipKernel.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grpTransKernel.ResumeLayout(False)
        Me.grpTransKernel.PerformLayout()
        Me.tpKernelView.ResumeLayout(False)
        Me.tpKernelView.PerformLayout()
        CType(Me.dgvWBFruitWtDetailsView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsKernel.ResumeLayout(False)
        Me.CMSLoadCPO.ResumeLayout(False)
        Me.tpKernelSave.ResumeLayout(False)
        Me.tcTransKernel.ResumeLayout(False)
        Me.cmsStockCPO.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panCPO As System.Windows.Forms.Panel
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents grpTransKernelRecords As System.Windows.Forms.GroupBox
    Friend WithEvents dgvWBFruitWt As System.Windows.Forms.DataGridView
    Friend WithEvents cmsTranshipKernel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TranshipEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TranshipDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTransDate As System.Windows.Forms.Label
    Friend WithEvents grpTransKernel As System.Windows.Forms.GroupBox
    Friend WithEvents btnResetTrans As System.Windows.Forms.Button
    Friend WithEvents btnAddTrans As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtOtherSeperateWt As System.Windows.Forms.TextBox
    Friend WithEvents lblTransMonthDate As System.Windows.Forms.Label
    Friend WithEvents txtFFBWt As System.Windows.Forms.TextBox
    Friend WithEvents lblTransQty As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblTransStorage As System.Windows.Forms.Label
    Friend WithEvents cmbYOP As System.Windows.Forms.ComboBox
    Friend WithEvents lblT3Name As System.Windows.Forms.Label
    Friend WithEvents lblT1Name As System.Windows.Forms.Label
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents tpKernelView As System.Windows.Forms.TabPage
    Friend WithEvents dgvWBFruitWtDetailsView As System.Windows.Forms.DataGridView
    Friend WithEvents cmsKernel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblViewStatus As System.Windows.Forms.Label
    Friend WithEvents dtpAdjustmentViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblAdjSearchNo As System.Windows.Forms.Label
    Friend WithEvents CMSLoadCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LoadCPOEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadCPODelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tpKernelSave As System.Windows.Forms.TabPage
    Friend WithEvents StockCPODelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tcTransKernel As System.Windows.Forms.TabControl
    Friend WithEvents StockCPOEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsStockCPO As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents lblMonthYear As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHarvestorWt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblToLoading As System.Windows.Forms.Label
    Friend WithEvents dgclMonthYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclWBFruitWtID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFFBBunches As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgclYOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclFFBWt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclFFBBunches As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclOtherSeperate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclHarvestor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclYOPValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

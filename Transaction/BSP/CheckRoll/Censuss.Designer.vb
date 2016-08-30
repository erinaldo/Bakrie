<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Censuss
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Censuss))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tcCensus = New System.Windows.Forms.TabControl
        Me.tabMaterial = New System.Windows.Forms.TabPage
        Me.btnSaveAll = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpCensusDate = New System.Windows.Forms.DateTimePicker
        Me.txtTLCollectionRoad = New System.Windows.Forms.TextBox
        Me.SubBlockLookupButton = New System.Windows.Forms.Button
        Me.txtPlantDensityActual = New System.Windows.Forms.TextBox
        Me.lblTotalFFB = New System.Windows.Forms.Label
        Me.lblPlantDensityActual = New System.Windows.Forms.Label
        Me.lblColon10 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTotalFFB = New System.Windows.Forms.TextBox
        Me.txtPlantDensityRequired = New System.Windows.Forms.TextBox
        Me.lblAreaPlanted = New System.Windows.Forms.Label
        Me.txtAreaPlanted = New System.Windows.Forms.TextBox
        Me.lblPlantDensityRequired = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblColon5 = New System.Windows.Forms.Label
        Me.txtSubBlock = New System.Windows.Forms.TextBox
        Me.lblNoOfBunches = New System.Windows.Forms.Label
        Me.lblColon9 = New System.Windows.Forms.Label
        Me.lblSuBlock = New System.Windows.Forms.Label
        Me.txtNoOfBunches = New System.Windows.Forms.TextBox
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblTLCollectionRoad = New System.Windows.Forms.Label
        Me.lblColon4 = New System.Windows.Forms.Label
        Me.lblColon8 = New System.Windows.Forms.Label
        Me.txtTLMainRoad = New System.Windows.Forms.TextBox
        Me.lblColon1 = New System.Windows.Forms.Label
        Me.lblTLJalanPoros = New System.Windows.Forms.Label
        Me.txtYOP = New System.Windows.Forms.TextBox
        Me.txtTLJalanPoros = New System.Windows.Forms.TextBox
        Me.lblTLMainRoad = New System.Windows.Forms.Label
        Me.lblColon7 = New System.Windows.Forms.Label
        Me.lblSubBlockID = New System.Windows.Forms.Label
        Me.lblYOPID = New System.Windows.Forms.Label
        Me.lblDivID = New System.Windows.Forms.Label
        Me.lblDiv = New System.Windows.Forms.Label
        Me.lblColon6 = New System.Windows.Forms.Label
        Me.txtDIV = New System.Windows.Forms.TextBox
        Me.lblYOP = New System.Windows.Forms.Label
        Me.lblColon3 = New System.Windows.Forms.Label
        Me.lblColon2 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.gbEnquipmentData = New System.Windows.Forms.GroupBox
        Me.dgvCensus = New System.Windows.Forms.DataGridView
        Me.CensusDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YOP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlockName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AreaPlanted = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PlantDensityRequired = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PlantDensityActual = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PorosInArea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MainRoadInArea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CollectionRoadInArea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoOfBunches = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalFFB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CensusColumnConcurrencyId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsCensus = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditCensusFromdgvCensusMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteCensusFromdgvCensusMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.txtChange = New System.Windows.Forms.TextBox
        Me.tabView = New System.Windows.Forms.TabPage
        Me.plIPRView = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DgvCensussView = New System.Windows.Forms.DataGridView
        Me.CensusDateView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CensusViewColumnConcurrencyId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlCategorySearch = New Stepi.UI.ExtendedPanel
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.chkDate = New System.Windows.Forms.CheckBox
        Me.dtpCensusDateStartSearch = New System.Windows.Forms.DateTimePicker
        Me.dtpCensusDateEndSearch = New System.Windows.Forms.DateTimePicker
        Me.lblViewStartDate = New System.Windows.Forms.Label
        Me.lblViewEndtDate = New System.Windows.Forms.Label
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tcCensus.SuspendLayout()
        Me.tabMaterial.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbEnquipmentData.SuspendLayout()
        CType(Me.dgvCensus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsCensus.SuspendLayout()
        Me.tabView.SuspendLayout()
        Me.plIPRView.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvCensussView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCategorySearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcCensus
        '
        Me.tcCensus.Controls.Add(Me.tabMaterial)
        Me.tcCensus.Controls.Add(Me.tabView)
        Me.tcCensus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcCensus.Location = New System.Drawing.Point(0, 0)
        Me.tcCensus.Name = "tcCensus"
        Me.tcCensus.SelectedIndex = 0
        Me.tcCensus.Size = New System.Drawing.Size(901, 599)
        Me.tcCensus.TabIndex = 203
        '
        'tabMaterial
        '
        Me.tabMaterial.AutoScroll = True
        Me.tabMaterial.BackColor = System.Drawing.Color.Transparent
        Me.tabMaterial.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tabMaterial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabMaterial.Controls.Add(Me.btnSaveAll)
        Me.tabMaterial.Controls.Add(Me.btnAdd)
        Me.tabMaterial.Controls.Add(Me.btnReset)
        Me.tabMaterial.Controls.Add(Me.GroupBox1)
        Me.tabMaterial.Controls.Add(Me.btnClose)
        Me.tabMaterial.Controls.Add(Me.gbEnquipmentData)
        Me.tabMaterial.Controls.Add(Me.txtChange)
        Me.tabMaterial.Location = New System.Drawing.Point(4, 22)
        Me.tabMaterial.Name = "tabMaterial"
        Me.tabMaterial.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMaterial.Size = New System.Drawing.Size(893, 573)
        Me.tabMaterial.TabIndex = 0
        Me.tabMaterial.Text = "Census"
        Me.tabMaterial.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = CType(resources.GetObject("btnSaveAll.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveAll.Enabled = False
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(9, 525)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(105, 30)
        Me.btnSaveAll.TabIndex = 15
        Me.btnSaveAll.Text = "&Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(9, 248)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(105, 30)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(119, 248)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(105, 30)
        Me.btnReset.TabIndex = 13
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpCensusDate)
        Me.GroupBox1.Controls.Add(Me.txtTLCollectionRoad)
        Me.GroupBox1.Controls.Add(Me.SubBlockLookupButton)
        Me.GroupBox1.Controls.Add(Me.txtPlantDensityActual)
        Me.GroupBox1.Controls.Add(Me.lblTotalFFB)
        Me.GroupBox1.Controls.Add(Me.lblPlantDensityActual)
        Me.GroupBox1.Controls.Add(Me.lblColon10)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtTotalFFB)
        Me.GroupBox1.Controls.Add(Me.txtPlantDensityRequired)
        Me.GroupBox1.Controls.Add(Me.lblAreaPlanted)
        Me.GroupBox1.Controls.Add(Me.txtAreaPlanted)
        Me.GroupBox1.Controls.Add(Me.lblPlantDensityRequired)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblColon5)
        Me.GroupBox1.Controls.Add(Me.txtSubBlock)
        Me.GroupBox1.Controls.Add(Me.lblNoOfBunches)
        Me.GroupBox1.Controls.Add(Me.lblColon9)
        Me.GroupBox1.Controls.Add(Me.lblSuBlock)
        Me.GroupBox1.Controls.Add(Me.txtNoOfBunches)
        Me.GroupBox1.Controls.Add(Me.lblDate)
        Me.GroupBox1.Controls.Add(Me.lblTLCollectionRoad)
        Me.GroupBox1.Controls.Add(Me.lblColon4)
        Me.GroupBox1.Controls.Add(Me.lblColon8)
        Me.GroupBox1.Controls.Add(Me.txtTLMainRoad)
        Me.GroupBox1.Controls.Add(Me.lblColon1)
        Me.GroupBox1.Controls.Add(Me.lblTLJalanPoros)
        Me.GroupBox1.Controls.Add(Me.txtYOP)
        Me.GroupBox1.Controls.Add(Me.txtTLJalanPoros)
        Me.GroupBox1.Controls.Add(Me.lblTLMainRoad)
        Me.GroupBox1.Controls.Add(Me.lblColon7)
        Me.GroupBox1.Controls.Add(Me.lblSubBlockID)
        Me.GroupBox1.Controls.Add(Me.lblYOPID)
        Me.GroupBox1.Controls.Add(Me.lblDivID)
        Me.GroupBox1.Controls.Add(Me.lblDiv)
        Me.GroupBox1.Controls.Add(Me.lblColon6)
        Me.GroupBox1.Controls.Add(Me.txtDIV)
        Me.GroupBox1.Controls.Add(Me.lblYOP)
        Me.GroupBox1.Controls.Add(Me.lblColon3)
        Me.GroupBox1.Controls.Add(Me.lblColon2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(866, 231)
        Me.GroupBox1.TabIndex = 129
        Me.GroupBox1.TabStop = False
        '
        'dtpCensusDate
        '
        Me.dtpCensusDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpCensusDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCensusDate.Location = New System.Drawing.Point(206, 26)
        Me.dtpCensusDate.Name = "dtpCensusDate"
        Me.dtpCensusDate.Size = New System.Drawing.Size(135, 20)
        Me.dtpCensusDate.TabIndex = 0
        '
        'txtTLCollectionRoad
        '
        Me.txtTLCollectionRoad.BackColor = System.Drawing.Color.White
        Me.txtTLCollectionRoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTLCollectionRoad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTLCollectionRoad.Location = New System.Drawing.Point(678, 81)
        Me.txtTLCollectionRoad.MaxLength = 50
        Me.txtTLCollectionRoad.Name = "txtTLCollectionRoad"
        Me.txtTLCollectionRoad.Size = New System.Drawing.Size(138, 21)
        Me.txtTLCollectionRoad.TabIndex = 9
        '
        'SubBlockLookupButton
        '
        Me.SubBlockLookupButton.Image = CType(resources.GetObject("SubBlockLookupButton.Image"), System.Drawing.Image)
        Me.SubBlockLookupButton.Location = New System.Drawing.Point(310, 105)
        Me.SubBlockLookupButton.Name = "SubBlockLookupButton"
        Me.SubBlockLookupButton.Size = New System.Drawing.Size(31, 26)
        Me.SubBlockLookupButton.TabIndex = 152
        Me.SubBlockLookupButton.TabStop = False
        Me.SubBlockLookupButton.UseVisualStyleBackColor = True
        '
        'txtPlantDensityActual
        '
        Me.txtPlantDensityActual.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlantDensityActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlantDensityActual.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlantDensityActual.Location = New System.Drawing.Point(204, 191)
        Me.txtPlantDensityActual.MaxLength = 50
        Me.txtPlantDensityActual.Name = "txtPlantDensityActual"
        Me.txtPlantDensityActual.Size = New System.Drawing.Size(100, 21)
        Me.txtPlantDensityActual.TabIndex = 6
        '
        'lblTotalFFB
        '
        Me.lblTotalFFB.AutoSize = True
        Me.lblTotalFFB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFFB.ForeColor = System.Drawing.Color.Black
        Me.lblTotalFFB.Location = New System.Drawing.Point(417, 141)
        Me.lblTotalFFB.Name = "lblTotalFFB"
        Me.lblTotalFFB.Size = New System.Drawing.Size(59, 13)
        Me.lblTotalFFB.TabIndex = 149
        Me.lblTotalFFB.Text = "Total FFB"
        '
        'lblPlantDensityActual
        '
        Me.lblPlantDensityActual.AutoSize = True
        Me.lblPlantDensityActual.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlantDensityActual.ForeColor = System.Drawing.Color.Black
        Me.lblPlantDensityActual.Location = New System.Drawing.Point(15, 188)
        Me.lblPlantDensityActual.Name = "lblPlantDensityActual"
        Me.lblPlantDensityActual.Size = New System.Drawing.Size(121, 13)
        Me.lblPlantDensityActual.TabIndex = 147
        Me.lblPlantDensityActual.Text = "Plant Density Actual"
        '
        'lblColon10
        '
        Me.lblColon10.AutoSize = True
        Me.lblColon10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon10.Location = New System.Drawing.Point(662, 140)
        Me.lblColon10.Name = "lblColon10"
        Me.lblColon10.Size = New System.Drawing.Size(11, 13)
        Me.lblColon10.TabIndex = 150
        Me.lblColon10.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(187, 193)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = ":"
        '
        'txtTotalFFB
        '
        Me.txtTotalFFB.BackColor = System.Drawing.Color.White
        Me.txtTotalFFB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalFFB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFFB.Location = New System.Drawing.Point(678, 135)
        Me.txtTotalFFB.MaxLength = 50
        Me.txtTotalFFB.Name = "txtTotalFFB"
        Me.txtTotalFFB.Size = New System.Drawing.Size(76, 21)
        Me.txtTotalFFB.TabIndex = 11
        '
        'txtPlantDensityRequired
        '
        Me.txtPlantDensityRequired.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlantDensityRequired.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlantDensityRequired.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlantDensityRequired.Location = New System.Drawing.Point(204, 161)
        Me.txtPlantDensityRequired.MaxLength = 50
        Me.txtPlantDensityRequired.Name = "txtPlantDensityRequired"
        Me.txtPlantDensityRequired.Size = New System.Drawing.Size(100, 21)
        Me.txtPlantDensityRequired.TabIndex = 5
        '
        'lblAreaPlanted
        '
        Me.lblAreaPlanted.AutoSize = True
        Me.lblAreaPlanted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAreaPlanted.Location = New System.Drawing.Point(17, 135)
        Me.lblAreaPlanted.Name = "lblAreaPlanted"
        Me.lblAreaPlanted.Size = New System.Drawing.Size(139, 13)
        Me.lblAreaPlanted.TabIndex = 141
        Me.lblAreaPlanted.Text = "Area Planted / tobe Planted"
        '
        'txtAreaPlanted
        '
        Me.txtAreaPlanted.BackColor = System.Drawing.SystemColors.Window
        Me.txtAreaPlanted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAreaPlanted.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAreaPlanted.Location = New System.Drawing.Point(204, 133)
        Me.txtAreaPlanted.MaxLength = 100
        Me.txtAreaPlanted.Name = "txtAreaPlanted"
        Me.txtAreaPlanted.Size = New System.Drawing.Size(100, 21)
        Me.txtAreaPlanted.TabIndex = 4
        '
        'lblPlantDensityRequired
        '
        Me.lblPlantDensityRequired.AutoSize = True
        Me.lblPlantDensityRequired.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlantDensityRequired.Location = New System.Drawing.Point(15, 161)
        Me.lblPlantDensityRequired.Name = "lblPlantDensityRequired"
        Me.lblPlantDensityRequired.Size = New System.Drawing.Size(137, 13)
        Me.lblPlantDensityRequired.TabIndex = 142
        Me.lblPlantDensityRequired.Text = "Plant Density Required"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(187, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 144
        Me.Label5.Text = ":"
        '
        'lblColon5
        '
        Me.lblColon5.AutoSize = True
        Me.lblColon5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon5.Location = New System.Drawing.Point(187, 135)
        Me.lblColon5.Name = "lblColon5"
        Me.lblColon5.Size = New System.Drawing.Size(11, 13)
        Me.lblColon5.TabIndex = 143
        Me.lblColon5.Text = ":"
        '
        'txtSubBlock
        '
        Me.txtSubBlock.BackColor = System.Drawing.Color.White
        Me.txtSubBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubBlock.Location = New System.Drawing.Point(204, 106)
        Me.txtSubBlock.MaxLength = 50
        Me.txtSubBlock.Name = "txtSubBlock"
        Me.txtSubBlock.Size = New System.Drawing.Size(100, 21)
        Me.txtSubBlock.TabIndex = 3
        '
        'lblNoOfBunches
        '
        Me.lblNoOfBunches.AutoSize = True
        Me.lblNoOfBunches.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoOfBunches.ForeColor = System.Drawing.Color.Black
        Me.lblNoOfBunches.Location = New System.Drawing.Point(418, 117)
        Me.lblNoOfBunches.Name = "lblNoOfBunches"
        Me.lblNoOfBunches.Size = New System.Drawing.Size(91, 13)
        Me.lblNoOfBunches.TabIndex = 140
        Me.lblNoOfBunches.Text = "No Of Bunches"
        '
        'lblColon9
        '
        Me.lblColon9.AutoSize = True
        Me.lblColon9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon9.Location = New System.Drawing.Point(662, 111)
        Me.lblColon9.Name = "lblColon9"
        Me.lblColon9.Size = New System.Drawing.Size(11, 13)
        Me.lblColon9.TabIndex = 141
        Me.lblColon9.Text = ":"
        '
        'lblSuBlock
        '
        Me.lblSuBlock.AutoSize = True
        Me.lblSuBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuBlock.ForeColor = System.Drawing.Color.Red
        Me.lblSuBlock.Location = New System.Drawing.Point(17, 106)
        Me.lblSuBlock.Name = "lblSuBlock"
        Me.lblSuBlock.Size = New System.Drawing.Size(64, 13)
        Me.lblSuBlock.TabIndex = 126
        Me.lblSuBlock.Text = "Field No"
        '
        'txtNoOfBunches
        '
        Me.txtNoOfBunches.BackColor = System.Drawing.Color.White
        Me.txtNoOfBunches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoOfBunches.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoOfBunches.Location = New System.Drawing.Point(678, 107)
        Me.txtNoOfBunches.MaxLength = 50
        Me.txtNoOfBunches.Name = "txtNoOfBunches"
        Me.txtNoOfBunches.Size = New System.Drawing.Size(76, 21)
        Me.txtNoOfBunches.TabIndex = 10
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Red
        Me.lblDate.Location = New System.Drawing.Point(17, 31)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(125, 13)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Date of last Censuss"
        '
        'lblTLCollectionRoad
        '
        Me.lblTLCollectionRoad.AutoSize = True
        Me.lblTLCollectionRoad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTLCollectionRoad.ForeColor = System.Drawing.Color.Black
        Me.lblTLCollectionRoad.Location = New System.Drawing.Point(417, 86)
        Me.lblTLCollectionRoad.Name = "lblTLCollectionRoad"
        Me.lblTLCollectionRoad.Size = New System.Drawing.Size(215, 13)
        Me.lblTLCollectionRoad.TabIndex = 137
        Me.lblTLCollectionRoad.Text = "Total Length / Collection in this Area"
        '
        'lblColon4
        '
        Me.lblColon4.AutoSize = True
        Me.lblColon4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon4.Location = New System.Drawing.Point(187, 107)
        Me.lblColon4.Name = "lblColon4"
        Me.lblColon4.Size = New System.Drawing.Size(11, 13)
        Me.lblColon4.TabIndex = 127
        Me.lblColon4.Text = ":"
        '
        'lblColon8
        '
        Me.lblColon8.AutoSize = True
        Me.lblColon8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon8.Location = New System.Drawing.Point(661, 83)
        Me.lblColon8.Name = "lblColon8"
        Me.lblColon8.Size = New System.Drawing.Size(11, 13)
        Me.lblColon8.TabIndex = 138
        Me.lblColon8.Text = ":"
        '
        'txtTLMainRoad
        '
        Me.txtTLMainRoad.BackColor = System.Drawing.Color.White
        Me.txtTLMainRoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTLMainRoad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTLMainRoad.Location = New System.Drawing.Point(678, 54)
        Me.txtTLMainRoad.MaxLength = 50
        Me.txtTLMainRoad.Name = "txtTLMainRoad"
        Me.txtTLMainRoad.Size = New System.Drawing.Size(138, 21)
        Me.txtTLMainRoad.TabIndex = 8
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(188, 28)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(11, 13)
        Me.lblColon1.TabIndex = 19
        Me.lblColon1.Text = ":"
        '
        'lblTLJalanPoros
        '
        Me.lblTLJalanPoros.AutoSize = True
        Me.lblTLJalanPoros.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTLJalanPoros.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTLJalanPoros.Location = New System.Drawing.Point(418, 30)
        Me.lblTLJalanPoros.Name = "lblTLJalanPoros"
        Me.lblTLJalanPoros.Size = New System.Drawing.Size(224, 13)
        Me.lblTLJalanPoros.TabIndex = 131
        Me.lblTLJalanPoros.Text = "Total Length / Jalan Poros in this Area"
        '
        'txtYOP
        '
        Me.txtYOP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtYOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYOP.Enabled = False
        Me.txtYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYOP.Location = New System.Drawing.Point(204, 79)
        Me.txtYOP.MaxLength = 50
        Me.txtYOP.Name = "txtYOP"
        Me.txtYOP.Size = New System.Drawing.Size(100, 21)
        Me.txtYOP.TabIndex = 2
        '
        'txtTLJalanPoros
        '
        Me.txtTLJalanPoros.BackColor = System.Drawing.Color.White
        Me.txtTLJalanPoros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTLJalanPoros.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTLJalanPoros.Location = New System.Drawing.Point(678, 28)
        Me.txtTLJalanPoros.MaxLength = 100
        Me.txtTLJalanPoros.Name = "txtTLJalanPoros"
        Me.txtTLJalanPoros.Size = New System.Drawing.Size(138, 21)
        Me.txtTLJalanPoros.TabIndex = 7
        '
        'lblTLMainRoad
        '
        Me.lblTLMainRoad.AutoSize = True
        Me.lblTLMainRoad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTLMainRoad.Location = New System.Drawing.Point(418, 58)
        Me.lblTLMainRoad.Name = "lblTLMainRoad"
        Me.lblTLMainRoad.Size = New System.Drawing.Size(218, 13)
        Me.lblTLMainRoad.TabIndex = 132
        Me.lblTLMainRoad.Text = "Total Length / Main Road in this Area"
        '
        'lblColon7
        '
        Me.lblColon7.AutoSize = True
        Me.lblColon7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon7.Location = New System.Drawing.Point(661, 56)
        Me.lblColon7.Name = "lblColon7"
        Me.lblColon7.Size = New System.Drawing.Size(11, 13)
        Me.lblColon7.TabIndex = 134
        Me.lblColon7.Text = ":"
        '
        'lblSubBlockID
        '
        Me.lblSubBlockID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubBlockID.Location = New System.Drawing.Point(338, 114)
        Me.lblSubBlockID.Name = "lblSubBlockID"
        Me.lblSubBlockID.Size = New System.Drawing.Size(45, 13)
        Me.lblSubBlockID.TabIndex = 15
        Me.lblSubBlockID.Text = "FieldNo"
        Me.lblSubBlockID.Visible = False
        '
        'lblYOPID
        '
        Me.lblYOPID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOPID.Location = New System.Drawing.Point(307, 81)
        Me.lblYOPID.Name = "lblYOPID"
        Me.lblYOPID.Size = New System.Drawing.Size(45, 13)
        Me.lblYOPID.TabIndex = 15
        Me.lblYOPID.Text = "YOPID"
        Me.lblYOPID.Visible = False
        '
        'lblDivID
        '
        Me.lblDivID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivID.Location = New System.Drawing.Point(307, 54)
        Me.lblDivID.Name = "lblDivID"
        Me.lblDivID.Size = New System.Drawing.Size(45, 13)
        Me.lblDivID.TabIndex = 15
        Me.lblDivID.Text = "Afdeling ID"
        Me.lblDivID.Visible = False
        '
        'lblDiv
        '
        Me.lblDiv.AutoSize = True
        Me.lblDiv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiv.ForeColor = System.Drawing.Color.Red
        Me.lblDiv.Location = New System.Drawing.Point(17, 53)
        Me.lblDiv.Name = "lblDiv"
        Me.lblDiv.Size = New System.Drawing.Size(26, 13)
        Me.lblDiv.TabIndex = 15
        Me.lblDiv.Text = "Afdeling"
        '
        'lblColon6
        '
        Me.lblColon6.AutoSize = True
        Me.lblColon6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon6.Location = New System.Drawing.Point(660, 31)
        Me.lblColon6.Name = "lblColon6"
        Me.lblColon6.Size = New System.Drawing.Size(11, 13)
        Me.lblColon6.TabIndex = 133
        Me.lblColon6.Text = ":"
        '
        'txtDIV
        '
        Me.txtDIV.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDIV.Enabled = False
        Me.txtDIV.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIV.Location = New System.Drawing.Point(204, 53)
        Me.txtDIV.MaxLength = 100
        Me.txtDIV.Name = "txtDIV"
        Me.txtDIV.Size = New System.Drawing.Size(100, 21)
        Me.txtDIV.TabIndex = 1
        '
        'lblYOP
        '
        Me.lblYOP.AutoSize = True
        Me.lblYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOP.ForeColor = System.Drawing.Color.Red
        Me.lblYOP.Location = New System.Drawing.Point(17, 79)
        Me.lblYOP.Name = "lblYOP"
        Me.lblYOP.Size = New System.Drawing.Size(30, 13)
        Me.lblYOP.TabIndex = 16
        Me.lblYOP.Text = "YOP"
        '
        'lblColon3
        '
        Me.lblColon3.AutoSize = True
        Me.lblColon3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon3.Location = New System.Drawing.Point(187, 82)
        Me.lblColon3.Name = "lblColon3"
        Me.lblColon3.Size = New System.Drawing.Size(11, 13)
        Me.lblColon3.TabIndex = 30
        Me.lblColon3.Text = ":"
        '
        'lblColon2
        '
        Me.lblColon2.AutoSize = True
        Me.lblColon2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon2.Location = New System.Drawing.Point(187, 54)
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
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(119, 525)
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
        Me.gbEnquipmentData.Controls.Add(Me.dgvCensus)
        Me.gbEnquipmentData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEnquipmentData.Location = New System.Drawing.Point(7, 280)
        Me.gbEnquipmentData.Name = "gbEnquipmentData"
        Me.gbEnquipmentData.Size = New System.Drawing.Size(868, 239)
        Me.gbEnquipmentData.TabIndex = 14
        Me.gbEnquipmentData.TabStop = False
        '
        'dgvCensus
        '
        Me.dgvCensus.AllowUserToAddRows = False
        Me.dgvCensus.AllowUserToDeleteRows = False
        Me.dgvCensus.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvCensus.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCensus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCensus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCensus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCensus.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCensus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCensus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCensus.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCensus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CensusDate, Me.DivName, Me.YOP, Me.BlockName, Me.AreaPlanted, Me.PlantDensityRequired, Me.PlantDensityActual, Me.PorosInArea, Me.MainRoadInArea, Me.CollectionRoadInArea, Me.NoOfBunches, Me.TotalFFB, Me.CensusColumnConcurrencyId})
        Me.dgvCensus.ContextMenuStrip = Me.cmsCensus
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCensus.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCensus.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCensus.EnableHeadersVisualStyles = False
        Me.dgvCensus.GridColor = System.Drawing.Color.Gray
        Me.dgvCensus.Location = New System.Drawing.Point(7, 16)
        Me.dgvCensus.Name = "dgvCensus"
        Me.dgvCensus.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCensus.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvCensus.RowHeadersVisible = False
        Me.dgvCensus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvCensus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCensus.ShowCellErrors = False
        Me.dgvCensus.Size = New System.Drawing.Size(855, 217)
        Me.dgvCensus.TabIndex = 14
        Me.dgvCensus.TabStop = False
        '
        'CensusDate
        '
        Me.CensusDate.DataPropertyName = "CensusDate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CensusDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.CensusDate.HeaderText = "Date of last Censuss"
        Me.CensusDate.Name = "CensusDate"
        Me.CensusDate.ReadOnly = True
        Me.CensusDate.Width = 149
        '
        'DivName
        '
        Me.DivName.DataPropertyName = "DivName"
        Me.DivName.HeaderText = "Afdeling"
        Me.DivName.Name = "DivName"
        Me.DivName.ReadOnly = True
        Me.DivName.Width = 50
        '
        'YOP
        '
        Me.YOP.DataPropertyName = "YOP"
        Me.YOP.HeaderText = "YOP"
        Me.YOP.Name = "YOP"
        Me.YOP.ReadOnly = True
        Me.YOP.Width = 54
        '
        'BlockName
        '
        Me.BlockName.DataPropertyName = "BlockName"
        Me.BlockName.HeaderText = "Field No"
        Me.BlockName.Name = "BlockName"
        Me.BlockName.ReadOnly = True
        Me.BlockName.Width = 88
        '
        'AreaPlanted
        '
        Me.AreaPlanted.DataPropertyName = "AreaPlanted"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.AreaPlanted.DefaultCellStyle = DataGridViewCellStyle4
        Me.AreaPlanted.HeaderText = "Area Planted"
        Me.AreaPlanted.Name = "AreaPlanted"
        Me.AreaPlanted.ReadOnly = True
        Me.AreaPlanted.Width = 104
        '
        'PlantDensityRequired
        '
        Me.PlantDensityRequired.DataPropertyName = "PlantdensityRequired"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.PlantDensityRequired.DefaultCellStyle = DataGridViewCellStyle5
        Me.PlantDensityRequired.HeaderText = "Plant Density Required"
        Me.PlantDensityRequired.Name = "PlantDensityRequired"
        Me.PlantDensityRequired.ReadOnly = True
        Me.PlantDensityRequired.Width = 161
        '
        'PlantDensityActual
        '
        Me.PlantDensityActual.DataPropertyName = "PlantDensityActual"
        Me.PlantDensityActual.HeaderText = "Plant Density Actual"
        Me.PlantDensityActual.Name = "PlantDensityActual"
        Me.PlantDensityActual.ReadOnly = True
        Me.PlantDensityActual.Width = 145
        '
        'PorosInArea
        '
        Me.PorosInArea.DataPropertyName = "PorosinArea"
        Me.PorosInArea.HeaderText = "Total Length / Jalan Poros In this Area"
        Me.PorosInArea.Name = "PorosInArea"
        Me.PorosInArea.ReadOnly = True
        Me.PorosInArea.Width = 250
        '
        'MainRoadInArea
        '
        Me.MainRoadInArea.DataPropertyName = "MainRoadInArea"
        Me.MainRoadInArea.HeaderText = "Total Length / Main Road In this Area"
        Me.MainRoadInArea.Name = "MainRoadInArea"
        Me.MainRoadInArea.ReadOnly = True
        Me.MainRoadInArea.Width = 244
        '
        'CollectionRoadInArea
        '
        Me.CollectionRoadInArea.DataPropertyName = "CollectionRoadInArea"
        Me.CollectionRoadInArea.HeaderText = "Total Length / Collection In this Area"
        Me.CollectionRoadInArea.Name = "CollectionRoadInArea"
        Me.CollectionRoadInArea.ReadOnly = True
        Me.CollectionRoadInArea.Width = 241
        '
        'NoOfBunches
        '
        Me.NoOfBunches.DataPropertyName = "NoOfBunches"
        Me.NoOfBunches.HeaderText = "No Of Bunches"
        Me.NoOfBunches.Name = "NoOfBunches"
        Me.NoOfBunches.ReadOnly = True
        Me.NoOfBunches.Width = 115
        '
        'TotalFFB
        '
        Me.TotalFFB.DataPropertyName = "TotalFFB"
        Me.TotalFFB.HeaderText = "Total FFB"
        Me.TotalFFB.Name = "TotalFFB"
        Me.TotalFFB.ReadOnly = True
        Me.TotalFFB.Width = 83
        '
        'CensusColumnConcurrencyId
        '
        Me.CensusColumnConcurrencyId.DataPropertyName = "ConcurrencyId"
        Me.CensusColumnConcurrencyId.HeaderText = "ConcurrencyId"
        Me.CensusColumnConcurrencyId.Name = "CensusColumnConcurrencyId"
        Me.CensusColumnConcurrencyId.ReadOnly = True
        Me.CensusColumnConcurrencyId.Width = 116
        '
        'cmsCensus
        '
        Me.cmsCensus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditCensusFromdgvCensusMenu, Me.DeleteCensusFromdgvCensusMenu})
        Me.cmsCensus.Name = "cmsCensus"
        Me.cmsCensus.Size = New System.Drawing.Size(117, 48)
        '
        'EditCensusFromdgvCensusMenu
        '
        Me.EditCensusFromdgvCensusMenu.Name = "EditCensusFromdgvCensusMenu"
        Me.EditCensusFromdgvCensusMenu.Size = New System.Drawing.Size(116, 22)
        Me.EditCensusFromdgvCensusMenu.Text = "Edit"
        '
        'DeleteCensusFromdgvCensusMenu
        '
        Me.DeleteCensusFromdgvCensusMenu.Name = "DeleteCensusFromdgvCensusMenu"
        Me.DeleteCensusFromdgvCensusMenu.Size = New System.Drawing.Size(116, 22)
        Me.DeleteCensusFromdgvCensusMenu.Text = "Delete"
        '
        'txtChange
        '
        Me.txtChange.Location = New System.Drawing.Point(733, 482)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Size = New System.Drawing.Size(120, 20)
        Me.txtChange.TabIndex = 149
        Me.txtChange.Visible = False
        '
        'tabView
        '
        Me.tabView.AutoScroll = True
        Me.tabView.BackgroundImage = CType(resources.GetObject("tabView.BackgroundImage"), System.Drawing.Image)
        Me.tabView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabView.Controls.Add(Me.plIPRView)
        Me.tabView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabView.Location = New System.Drawing.Point(4, 22)
        Me.tabView.Name = "tabView"
        Me.tabView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabView.Size = New System.Drawing.Size(893, 573)
        Me.tabView.TabIndex = 1
        Me.tabView.Text = "View"
        Me.tabView.UseVisualStyleBackColor = True
        '
        'plIPRView
        '
        Me.plIPRView.Controls.Add(Me.GroupBox2)
        Me.plIPRView.Controls.Add(Me.pnlCategorySearch)
        Me.plIPRView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plIPRView.Location = New System.Drawing.Point(3, 3)
        Me.plIPRView.Name = "plIPRView"
        Me.plIPRView.Size = New System.Drawing.Size(887, 567)
        Me.plIPRView.TabIndex = 45
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.DgvCensussView)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(879, 422)
        Me.GroupBox2.TabIndex = 129
        Me.GroupBox2.TabStop = False
        '
        'DgvCensussView
        '
        Me.DgvCensussView.AllowUserToAddRows = False
        Me.DgvCensussView.AllowUserToDeleteRows = False
        Me.DgvCensussView.AllowUserToOrderColumns = True
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.DgvCensussView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DgvCensussView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvCensussView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgvCensussView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgvCensussView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DgvCensussView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCensussView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvCensussView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DgvCensussView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CensusDateView, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.CensusViewColumnConcurrencyId})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvCensussView.DefaultCellStyle = DataGridViewCellStyle11
        Me.DgvCensussView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DgvCensussView.EnableHeadersVisualStyles = False
        Me.DgvCensussView.GridColor = System.Drawing.Color.Gray
        Me.DgvCensussView.Location = New System.Drawing.Point(7, 19)
        Me.DgvCensussView.Name = "DgvCensussView"
        Me.DgvCensussView.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvCensussView.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DgvCensussView.RowHeadersVisible = False
        Me.DgvCensussView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DgvCensussView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCensussView.ShowCellErrors = False
        Me.DgvCensussView.Size = New System.Drawing.Size(866, 387)
        Me.DgvCensussView.TabIndex = 5
        '
        'CensusDateView
        '
        Me.CensusDateView.DataPropertyName = "CensusDate"
        DataGridViewCellStyle10.Format = "dd/MM/yyyy"
        Me.CensusDateView.DefaultCellStyle = DataGridViewCellStyle10
        Me.CensusDateView.HeaderText = "Date of last Censuss"
        Me.CensusDateView.Name = "CensusDateView"
        Me.CensusDateView.ReadOnly = True
        Me.CensusDateView.Width = 149
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DivName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Afdeling"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 50
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "YOP"
        Me.DataGridViewTextBoxColumn3.HeaderText = "YOP"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 54
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "BlockName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Field No"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 88
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "AreaPlanted"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Area Planted"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 104
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "PlantdensityRequired"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Plant Density Required"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 161
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "PlantDensityActual"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Plant Density Actual"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 145
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "PorosinArea"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Total Length / Jalan Poros In this Area"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 250
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "MainRoadInArea"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Total Length / Main Road In this Area"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 244
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "CollectionRoadInArea"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Total Length / Collection In this Area"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 241
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "NoOfBunches"
        Me.DataGridViewTextBoxColumn11.HeaderText = "No Of Bunches"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 115
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "TotalFFB"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Total FFB"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 83
        '
        'CensusViewColumnConcurrencyId
        '
        Me.CensusViewColumnConcurrencyId.DataPropertyName = "concurrencyId"
        Me.CensusViewColumnConcurrencyId.HeaderText = "ConcurrencyId"
        Me.CensusViewColumnConcurrencyId.Name = "CensusViewColumnConcurrencyId"
        Me.CensusViewColumnConcurrencyId.ReadOnly = True
        Me.CensusViewColumnConcurrencyId.Width = 116
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
        Me.pnlCategorySearch.CaptionText = "Search Census"
        Me.pnlCategorySearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Controls.Add(Me.btnSearch)
        Me.pnlCategorySearch.Controls.Add(Me.btnViewReport)
        Me.pnlCategorySearch.Controls.Add(Me.chkDate)
        Me.pnlCategorySearch.Controls.Add(Me.dtpCensusDateStartSearch)
        Me.pnlCategorySearch.Controls.Add(Me.dtpCensusDateEndSearch)
        Me.pnlCategorySearch.Controls.Add(Me.lblViewStartDate)
        Me.pnlCategorySearch.Controls.Add(Me.lblViewEndtDate)
        Me.pnlCategorySearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlCategorySearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlCategorySearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlCategorySearch.ForeColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Location = New System.Drawing.Point(3, 3)
        Me.pnlCategorySearch.Name = "pnlCategorySearch"
        Me.pnlCategorySearch.Size = New System.Drawing.Size(875, 119)
        Me.pnlCategorySearch.TabIndex = 128
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(440, 78)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnViewReport
        '
        Me.btnViewReport.BackgroundImage = CType(resources.GetObject("btnViewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.ForeColor = System.Drawing.Color.Black
        Me.btnViewReport.Image = CType(resources.GetObject("btnViewReport.Image"), System.Drawing.Image)
        Me.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewReport.Location = New System.Drawing.Point(563, 78)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(126, 25)
        Me.btnViewReport.TabIndex = 4
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.BackColor = System.Drawing.Color.Transparent
        Me.chkDate.Location = New System.Drawing.Point(49, 54)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(57, 17)
        Me.chkDate.TabIndex = 0
        Me.chkDate.Text = "Date "
        Me.chkDate.UseVisualStyleBackColor = False
        '
        'dtpCensusDateStartSearch
        '
        Me.dtpCensusDateStartSearch.CustomFormat = "dd/MM/yyyy"
        Me.dtpCensusDateStartSearch.Enabled = False
        Me.dtpCensusDateStartSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCensusDateStartSearch.Location = New System.Drawing.Point(118, 80)
        Me.dtpCensusDateStartSearch.Name = "dtpCensusDateStartSearch"
        Me.dtpCensusDateStartSearch.Size = New System.Drawing.Size(106, 21)
        Me.dtpCensusDateStartSearch.TabIndex = 1
        '
        'dtpCensusDateEndSearch
        '
        Me.dtpCensusDateEndSearch.CustomFormat = "dd/MM/yyyy"
        Me.dtpCensusDateEndSearch.Enabled = False
        Me.dtpCensusDateEndSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCensusDateEndSearch.Location = New System.Drawing.Point(295, 80)
        Me.dtpCensusDateEndSearch.Name = "dtpCensusDateEndSearch"
        Me.dtpCensusDateEndSearch.Size = New System.Drawing.Size(106, 21)
        Me.dtpCensusDateEndSearch.TabIndex = 2
        '
        'lblViewStartDate
        '
        Me.lblViewStartDate.AutoSize = True
        Me.lblViewStartDate.BackColor = System.Drawing.Color.Transparent
        Me.lblViewStartDate.ForeColor = System.Drawing.Color.Black
        Me.lblViewStartDate.Location = New System.Drawing.Point(46, 84)
        Me.lblViewStartDate.Name = "lblViewStartDate"
        Me.lblViewStartDate.Size = New System.Drawing.Size(66, 13)
        Me.lblViewStartDate.TabIndex = 16
        Me.lblViewStartDate.Text = "Start Date"
        '
        'lblViewEndtDate
        '
        Me.lblViewEndtDate.AutoSize = True
        Me.lblViewEndtDate.BackColor = System.Drawing.Color.Transparent
        Me.lblViewEndtDate.ForeColor = System.Drawing.Color.Black
        Me.lblViewEndtDate.Location = New System.Drawing.Point(230, 84)
        Me.lblViewEndtDate.Name = "lblViewEndtDate"
        Me.lblViewEndtDate.Size = New System.Drawing.Size(59, 13)
        Me.lblViewEndtDate.TabIndex = 16
        Me.lblViewEndtDate.Text = "End Date"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'Censuss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(901, 599)
        Me.Controls.Add(Me.tcCensus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Censuss"
        Me.Text = "Censuss"
        Me.tcCensus.ResumeLayout(False)
        Me.tabMaterial.ResumeLayout(False)
        Me.tabMaterial.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbEnquipmentData.ResumeLayout(False)
        CType(Me.dgvCensus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsCensus.ResumeLayout(False)
        Me.tabView.ResumeLayout(False)
        Me.plIPRView.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DgvCensussView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCategorySearch.ResumeLayout(False)
        Me.pnlCategorySearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcCensus As System.Windows.Forms.TabControl
    Friend WithEvents tabMaterial As System.Windows.Forms.TabPage
    Friend WithEvents lblTotalFFB As System.Windows.Forms.Label
    Friend WithEvents lblColon10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalFFB As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblNoOfBunches As System.Windows.Forms.Label
    Friend WithEvents lblColon9 As System.Windows.Forms.Label
    Friend WithEvents txtNoOfBunches As System.Windows.Forms.TextBox
    Friend WithEvents lblTLCollectionRoad As System.Windows.Forms.Label
    Friend WithEvents lblColon8 As System.Windows.Forms.Label
    Friend WithEvents txtTLMainRoad As System.Windows.Forms.TextBox
    Friend WithEvents lblTLJalanPoros As System.Windows.Forms.Label
    Friend WithEvents txtTLJalanPoros As System.Windows.Forms.TextBox
    Friend WithEvents lblTLMainRoad As System.Windows.Forms.Label
    Friend WithEvents lblColon7 As System.Windows.Forms.Label
    Friend WithEvents lblColon6 As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents txtSubBlock As System.Windows.Forms.TextBox
    Friend WithEvents lblSuBlock As System.Windows.Forms.Label
    Friend WithEvents lblColon4 As System.Windows.Forms.Label
    Friend WithEvents txtYOP As System.Windows.Forms.TextBox
    Friend WithEvents lblDiv As System.Windows.Forms.Label
    Friend WithEvents txtDIV As System.Windows.Forms.TextBox
    Friend WithEvents lblYOP As System.Windows.Forms.Label
    Friend WithEvents lblColon3 As System.Windows.Forms.Label
    Friend WithEvents lblColon2 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents gbEnquipmentData As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCensus As System.Windows.Forms.DataGridView
    Friend WithEvents tabView As System.Windows.Forms.TabPage
    Friend WithEvents plIPRView As System.Windows.Forms.Panel
    Friend WithEvents pnlCategorySearch As Stepi.UI.ExtendedPanel
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents lblViewStartDate As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtTLCollectionRoad As System.Windows.Forms.TextBox
    Friend WithEvents SubBlockLookupButton As System.Windows.Forms.Button
    Friend WithEvents txtPlantDensityActual As System.Windows.Forms.TextBox
    Friend WithEvents lblPlantDensityActual As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPlantDensityRequired As System.Windows.Forms.TextBox
    Friend WithEvents lblAreaPlanted As System.Windows.Forms.Label
    Friend WithEvents txtAreaPlanted As System.Windows.Forms.TextBox
    Friend WithEvents lblPlantDensityRequired As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblColon5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DgvCensussView As System.Windows.Forms.DataGridView
    Friend WithEvents dtpCensusDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDivID As System.Windows.Forms.Label
    Friend WithEvents lblYOPID As System.Windows.Forms.Label
    Friend WithEvents lblSubBlockID As System.Windows.Forms.Label
    Friend WithEvents dtpCensusDateStartSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCensusDateEndSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblViewEndtDate As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents cmsCensus As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditCensusFromdgvCensusMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteCensusFromdgvCensusMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents txtChange As System.Windows.Forms.TextBox
    Friend WithEvents CensusDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlockName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AreaPlanted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlantDensityRequired As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlantDensityActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PorosInArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MainRoadInArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CollectionRoadInArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoOfBunches As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalFFB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CensusColumnConcurrencyId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CensusDateView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CensusViewColumnConcurrencyId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
End Class

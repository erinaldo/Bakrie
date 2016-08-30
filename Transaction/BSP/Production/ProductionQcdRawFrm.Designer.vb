<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionQcdRawFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionQcdRawFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabContainerMain = New System.Windows.Forms.TabControl()
        Me.cmsProductionQCDRaw = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabSave = New System.Windows.Forms.TabPage()
        Me.btnraw = New System.Windows.Forms.Button()
        Me.btnestate = New System.Windows.Forms.Button()
        Me.txtEstate = New System.Windows.Forms.TextBox()
        Me.btnTicket = New System.Windows.Forms.Button()
        Me.txtTicket = New System.Windows.Forms.TextBox()
        Me.txtRawMaterial = New System.Windows.Forms.TextBox()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDrcEstate = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtAsh = New System.Windows.Forms.TextBox()
        Me.txtDirt = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtVfaNo = New System.Windows.Forms.TextBox()
        Me.txtNh33 = New System.Windows.Forms.TextBox()
        Me.txtDrcNgrr = New System.Windows.Forms.TextBox()
        Me.txtDrc1 = New System.Windows.Forms.TextBox()
        Me.txtNh3Estate = New System.Windows.Forms.TextBox()
        Me.txtNh32 = New System.Windows.Forms.TextBox()
        Me.txtDrc3 = New System.Windows.Forms.TextBox()
        Me.txtQtyFactory = New System.Windows.Forms.TextBox()
        Me.txtNh3Ngrr = New System.Windows.Forms.TextBox()
        Me.txtNh31 = New System.Windows.Forms.TextBox()
        Me.txtDrc2 = New System.Windows.Forms.TextBox()
        Me.txtQtyEstate = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtDivision = New System.Windows.Forms.TextBox()
        Me.txtCarNo = New System.Windows.Forms.TextBox()
        Me.lblrm = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabSearchView = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.dgtxtDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtDocDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtticket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvtxtestate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlSearchLPO = New Stepi.UI.ExtendedPanel()
        Me.txtSearchEstate = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblSearchEstate = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.chkDocDate = New System.Windows.Forms.CheckBox()
        Me.dtpSearchDocDate = New System.Windows.Forms.DateTimePicker()
        Me.btnLPOViewReport = New System.Windows.Forms.Button()
        Me.txtSearchTicket = New System.Windows.Forms.TextBox()
        Me.btnViewSearch = New System.Windows.Forms.Button()
        Me.lblSearchTicket = New System.Windows.Forms.Label()
        Me.TabContainerMain.SuspendLayout()
        Me.cmsProductionQCDRaw.SuspendLayout()
        Me.tabSave.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabSearchView.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearchLPO.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabContainerMain
        '
        Me.TabContainerMain.ContextMenuStrip = Me.cmsProductionQCDRaw
        Me.TabContainerMain.Controls.Add(Me.tabSave)
        Me.TabContainerMain.Controls.Add(Me.tabSearchView)
        Me.TabContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabContainerMain.Location = New System.Drawing.Point(0, 0)
        Me.TabContainerMain.Name = "TabContainerMain"
        Me.TabContainerMain.SelectedIndex = 0
        Me.TabContainerMain.Size = New System.Drawing.Size(950, 522)
        Me.TabContainerMain.TabIndex = 0
        '
        'cmsProductionQCDRaw
        '
        Me.cmsProductionQCDRaw.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsProductionQCDRaw.Name = "cmsIPR"
        Me.cmsProductionQCDRaw.Size = New System.Drawing.Size(108, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'tabSave
        '
        Me.tabSave.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tabSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabSave.Controls.Add(Me.btnraw)
        Me.tabSave.Controls.Add(Me.btnestate)
        Me.tabSave.Controls.Add(Me.txtEstate)
        Me.tabSave.Controls.Add(Me.btnTicket)
        Me.tabSave.Controls.Add(Me.txtTicket)
        Me.tabSave.Controls.Add(Me.txtRawMaterial)
        Me.tabSave.Controls.Add(Me.btnSaveAll)
        Me.tabSave.Controls.Add(Me.btnUpdate)
        Me.tabSave.Controls.Add(Me.btnResetAll)
        Me.tabSave.Controls.Add(Me.btnClose)
        Me.tabSave.Controls.Add(Me.GroupBox1)
        Me.tabSave.Controls.Add(Me.dtpDate)
        Me.tabSave.Controls.Add(Me.txtDivision)
        Me.tabSave.Controls.Add(Me.txtCarNo)
        Me.tabSave.Controls.Add(Me.lblrm)
        Me.tabSave.Controls.Add(Me.Label5)
        Me.tabSave.Controls.Add(Me.Label4)
        Me.tabSave.Controls.Add(Me.Label3)
        Me.tabSave.Controls.Add(Me.Label2)
        Me.tabSave.Controls.Add(Me.Label1)
        Me.tabSave.Location = New System.Drawing.Point(4, 22)
        Me.tabSave.Name = "tabSave"
        Me.tabSave.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSave.Size = New System.Drawing.Size(942, 496)
        Me.tabSave.TabIndex = 0
        Me.tabSave.Text = "QCD Raw Details"
        Me.tabSave.UseVisualStyleBackColor = True
        '
        'btnraw
        '
        Me.btnraw.BackgroundImage = CType(resources.GetObject("btnraw.BackgroundImage"), System.Drawing.Image)
        Me.btnraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnraw.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnraw.FlatAppearance.BorderSize = 0
        Me.btnraw.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnraw.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnraw.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnraw.Location = New System.Drawing.Point(891, 52)
        Me.btnraw.Margin = New System.Windows.Forms.Padding(2)
        Me.btnraw.Name = "btnraw"
        Me.btnraw.Size = New System.Drawing.Size(32, 39)
        Me.btnraw.TabIndex = 36
        Me.btnraw.TabStop = False
        Me.btnraw.UseVisualStyleBackColor = True
        '
        'btnestate
        '
        Me.btnestate.BackgroundImage = CType(resources.GetObject("btnestate.BackgroundImage"), System.Drawing.Image)
        Me.btnestate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnestate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnestate.FlatAppearance.BorderSize = 0
        Me.btnestate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnestate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnestate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnestate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnestate.Location = New System.Drawing.Point(891, 11)
        Me.btnestate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnestate.Name = "btnestate"
        Me.btnestate.Size = New System.Drawing.Size(32, 39)
        Me.btnestate.TabIndex = 35
        Me.btnestate.TabStop = False
        Me.btnestate.UseVisualStyleBackColor = True
        '
        'txtEstate
        '
        Me.txtEstate.Enabled = False
        Me.txtEstate.Location = New System.Drawing.Point(756, 17)
        Me.txtEstate.Name = "txtEstate"
        Me.txtEstate.Size = New System.Drawing.Size(121, 20)
        Me.txtEstate.TabIndex = 4
        '
        'btnTicket
        '
        Me.btnTicket.BackgroundImage = CType(resources.GetObject("btnTicket.BackgroundImage"), System.Drawing.Image)
        Me.btnTicket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnTicket.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnTicket.FlatAppearance.BorderSize = 0
        Me.btnTicket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTicket.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnTicket.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnTicket.Location = New System.Drawing.Point(574, 11)
        Me.btnTicket.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTicket.Name = "btnTicket"
        Me.btnTicket.Size = New System.Drawing.Size(32, 39)
        Me.btnTicket.TabIndex = 3
        Me.btnTicket.TabStop = False
        Me.btnTicket.UseVisualStyleBackColor = True
        '
        'txtTicket
        '
        Me.txtTicket.Enabled = False
        Me.txtTicket.Location = New System.Drawing.Point(448, 17)
        Me.txtTicket.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.Size = New System.Drawing.Size(121, 20)
        Me.txtTicket.TabIndex = 2
        '
        'txtRawMaterial
        '
        Me.txtRawMaterial.Enabled = False
        Me.txtRawMaterial.Location = New System.Drawing.Point(756, 62)
        Me.txtRawMaterial.Name = "txtRawMaterial"
        Me.txtRawMaterial.Size = New System.Drawing.Size(121, 20)
        Me.txtRawMaterial.TabIndex = 7
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnSaveAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSaveAll.Location = New System.Drawing.Point(373, 459)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(127, 29)
        Me.btnSaveAll.TabIndex = 24
        Me.btnSaveAll.Text = "Save"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUpdate.Image = Global.BSP.My.Resources.Resources.user_add
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnUpdate.Location = New System.Drawing.Point(506, 459)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(127, 29)
        Me.btnUpdate.TabIndex = 25
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnResetAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Image = Global.BSP.My.Resources.Resources.refresh
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnResetAll.Location = New System.Drawing.Point(639, 459)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(127, 29)
        Me.btnResetAll.TabIndex = 26
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = Global.BSP.My.Resources.Resources.Close_32
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnClose.Location = New System.Drawing.Point(772, 459)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 29)
        Me.btnClose.TabIndex = 27
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDrcEstate)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtAsh)
        Me.GroupBox1.Controls.Add(Me.txtDirt)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtVfaNo)
        Me.GroupBox1.Controls.Add(Me.txtNh33)
        Me.GroupBox1.Controls.Add(Me.txtDrcNgrr)
        Me.GroupBox1.Controls.Add(Me.txtDrc1)
        Me.GroupBox1.Controls.Add(Me.txtNh3Estate)
        Me.GroupBox1.Controls.Add(Me.txtNh32)
        Me.GroupBox1.Controls.Add(Me.txtDrc3)
        Me.GroupBox1.Controls.Add(Me.txtQtyFactory)
        Me.GroupBox1.Controls.Add(Me.txtNh3Ngrr)
        Me.GroupBox1.Controls.Add(Me.txtNh31)
        Me.GroupBox1.Controls.Add(Me.txtDrc2)
        Me.GroupBox1.Controls.Add(Me.txtQtyEstate)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(928, 310)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "QCD Raw Details"
        '
        'txtDrcEstate
        '
        Me.txtDrcEstate.Location = New System.Drawing.Point(777, 157)
        Me.txtDrcEstate.Name = "txtDrcEstate"
        Me.txtDrcEstate.Size = New System.Drawing.Size(121, 20)
        Me.txtDrcEstate.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(630, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 13)
        Me.Label6.TabIndex = 318
        Me.Label6.Text = "DRC % (Mix RT Estate)"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(141, 240)
        Me.txtRemarks.MaxLength = 200
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(486, 54)
        Me.txtRemarks.TabIndex = 23
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(6, 247)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 13)
        Me.Label21.TabIndex = 316
        Me.Label21.Text = "Remarks"
        '
        'txtAsh
        '
        Me.txtAsh.Location = New System.Drawing.Point(777, 198)
        Me.txtAsh.Name = "txtAsh"
        Me.txtAsh.Size = New System.Drawing.Size(121, 20)
        Me.txtAsh.TabIndex = 22
        '
        'txtDirt
        '
        Me.txtDirt.Location = New System.Drawing.Point(434, 198)
        Me.txtDirt.Name = "txtDirt"
        Me.txtDirt.Size = New System.Drawing.Size(121, 20)
        Me.txtDirt.TabIndex = 21
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(630, 205)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 13)
        Me.Label20.TabIndex = 48
        Me.Label20.Text = "Ash Content (%)"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(287, 205)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 13)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "Dirt Content (%)"
        '
        'txtVfaNo
        '
        Me.txtVfaNo.Location = New System.Drawing.Point(141, 194)
        Me.txtVfaNo.Name = "txtVfaNo"
        Me.txtVfaNo.Size = New System.Drawing.Size(121, 20)
        Me.txtVfaNo.TabIndex = 20
        '
        'txtNh33
        '
        Me.txtNh33.Location = New System.Drawing.Point(777, 115)
        Me.txtNh33.Name = "txtNh33"
        Me.txtNh33.Size = New System.Drawing.Size(121, 20)
        Me.txtNh33.TabIndex = 16
        '
        'txtDrcNgrr
        '
        Me.txtDrcNgrr.Location = New System.Drawing.Point(777, 71)
        Me.txtDrcNgrr.Name = "txtDrcNgrr"
        Me.txtDrcNgrr.Size = New System.Drawing.Size(121, 20)
        Me.txtDrcNgrr.TabIndex = 13
        '
        'txtDrc1
        '
        Me.txtDrc1.Location = New System.Drawing.Point(777, 33)
        Me.txtDrc1.Name = "txtDrc1"
        Me.txtDrc1.Size = New System.Drawing.Size(121, 20)
        Me.txtDrc1.TabIndex = 10
        '
        'txtNh3Estate
        '
        Me.txtNh3Estate.Location = New System.Drawing.Point(434, 156)
        Me.txtNh3Estate.Name = "txtNh3Estate"
        Me.txtNh3Estate.Size = New System.Drawing.Size(121, 20)
        Me.txtNh3Estate.TabIndex = 18
        '
        'txtNh32
        '
        Me.txtNh32.Location = New System.Drawing.Point(434, 115)
        Me.txtNh32.Name = "txtNh32"
        Me.txtNh32.Size = New System.Drawing.Size(121, 20)
        Me.txtNh32.TabIndex = 15
        '
        'txtDrc3
        '
        Me.txtDrc3.Location = New System.Drawing.Point(434, 71)
        Me.txtDrc3.Name = "txtDrc3"
        Me.txtDrc3.Size = New System.Drawing.Size(121, 20)
        Me.txtDrc3.TabIndex = 12
        '
        'txtQtyFactory
        '
        Me.txtQtyFactory.Location = New System.Drawing.Point(434, 28)
        Me.txtQtyFactory.Name = "txtQtyFactory"
        Me.txtQtyFactory.Size = New System.Drawing.Size(121, 20)
        Me.txtQtyFactory.TabIndex = 9
        '
        'txtNh3Ngrr
        '
        Me.txtNh3Ngrr.Location = New System.Drawing.Point(141, 156)
        Me.txtNh3Ngrr.Name = "txtNh3Ngrr"
        Me.txtNh3Ngrr.Size = New System.Drawing.Size(121, 20)
        Me.txtNh3Ngrr.TabIndex = 17
        '
        'txtNh31
        '
        Me.txtNh31.Location = New System.Drawing.Point(141, 115)
        Me.txtNh31.Name = "txtNh31"
        Me.txtNh31.Size = New System.Drawing.Size(121, 20)
        Me.txtNh31.TabIndex = 14
        '
        'txtDrc2
        '
        Me.txtDrc2.Location = New System.Drawing.Point(141, 71)
        Me.txtDrc2.Name = "txtDrc2"
        Me.txtDrc2.Size = New System.Drawing.Size(121, 20)
        Me.txtDrc2.TabIndex = 11
        '
        'txtQtyEstate
        '
        Me.txtQtyEstate.Location = New System.Drawing.Point(141, 28)
        Me.txtQtyEstate.Name = "txtQtyEstate"
        Me.txtQtyEstate.Size = New System.Drawing.Size(121, 20)
        Me.txtQtyEstate.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(6, 204)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 13)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "VFA No."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(287, 162)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(137, 13)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "NH3 % (Mix RT Estate)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(6, 162)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 13)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "NH3 % (CAR)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(630, 122)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(116, 13)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "NH3 % (INDV RT3)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(287, 122)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(116, 13)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "NH3 % (INDV RT2)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(6, 122)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "NH3 % (INDV RT1)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(630, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "DRC % (CAR)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(287, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "DRC % (INDV RT3)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(6, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "DRC % (INDV RT2)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(630, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "DRC % (INDV RT1)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(287, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Quantity (Factory)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(6, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Quantity (Estate)"
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(147, 17)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(121, 20)
        Me.dtpDate.TabIndex = 1
        '
        'txtDivision
        '
        Me.txtDivision.Location = New System.Drawing.Point(448, 59)
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Size = New System.Drawing.Size(121, 20)
        Me.txtDivision.TabIndex = 6
        '
        'txtCarNo
        '
        Me.txtCarNo.Location = New System.Drawing.Point(147, 57)
        Me.txtCarNo.Name = "txtCarNo"
        Me.txtCarNo.Size = New System.Drawing.Size(121, 20)
        Me.txtCarNo.TabIndex = 5
        '
        'lblrm
        '
        Me.lblrm.AutoSize = True
        Me.lblrm.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblrm.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblrm.Location = New System.Drawing.Point(645, 63)
        Me.lblrm.Name = "lblrm"
        Me.lblrm.Size = New System.Drawing.Size(111, 13)
        Me.lblrm.TabIndex = 18
        Me.lblrm.Text = "Raw Material Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(322, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Ticket No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(12, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Car No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(322, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Division"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(645, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Estate"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Date"
        '
        'tabSearchView
        '
        Me.tabSearchView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tabSearchView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabSearchView.Controls.Add(Me.lblView)
        Me.tabSearchView.Controls.Add(Me.dgvView)
        Me.tabSearchView.Controls.Add(Me.pnlSearchLPO)
        Me.tabSearchView.Location = New System.Drawing.Point(4, 22)
        Me.tabSearchView.Name = "tabSearchView"
        Me.tabSearchView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSearchView.Size = New System.Drawing.Size(942, 496)
        Me.tabSearchView.TabIndex = 1
        Me.tabSearchView.Text = "View"
        Me.tabSearchView.UseVisualStyleBackColor = True
        '
        'lblView
        '
        Me.lblView.AutoSize = True
        Me.lblView.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblView.ForeColor = System.Drawing.Color.Red
        Me.lblView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblView.Location = New System.Drawing.Point(427, 281)
        Me.lblView.Name = "lblView"
        Me.lblView.Size = New System.Drawing.Size(130, 13)
        Me.lblView.TabIndex = 415
        Me.lblView.Text = "Record not found !!"
        Me.lblView.Visible = False
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvView.ColumnHeadersHeight = 30
        Me.dgvView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgtxtDocID, Me.dgtxtDocDate, Me.dgtxtticket, Me.dgvtxtestate})
        Me.dgvView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvView.EnableHeadersVisualStyles = False
        Me.dgvView.GridColor = System.Drawing.Color.Gray
        Me.dgvView.Location = New System.Drawing.Point(3, 141)
        Me.dgvView.MultiSelect = False
        Me.dgvView.Name = "dgvView"
        Me.dgvView.ReadOnly = True
        Me.dgvView.RowHeadersVisible = False
        Me.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvView.Size = New System.Drawing.Size(936, 352)
        Me.dgvView.TabIndex = 414
        '
        'dgtxtDocID
        '
        Me.dgtxtDocID.DataPropertyName = "TransId"
        Me.dgtxtDocID.HeaderText = "Doc ID"
        Me.dgtxtDocID.Name = "dgtxtDocID"
        Me.dgtxtDocID.ReadOnly = True
        Me.dgtxtDocID.Visible = False
        '
        'dgtxtDocDate
        '
        Me.dgtxtDocDate.DataPropertyName = "DocDate"
        Me.dgtxtDocDate.HeaderText = "Date"
        Me.dgtxtDocDate.Name = "dgtxtDocDate"
        Me.dgtxtDocDate.ReadOnly = True
        '
        'dgtxtticket
        '
        Me.dgtxtticket.DataPropertyName = "TicketNo"
        Me.dgtxtticket.HeaderText = "Ticket No."
        Me.dgtxtticket.Name = "dgtxtticket"
        Me.dgtxtticket.ReadOnly = True
        '
        'dgvtxtestate
        '
        Me.dgvtxtestate.DataPropertyName = "Estate"
        Me.dgvtxtestate.HeaderText = "Estate"
        Me.dgvtxtestate.Name = "dgvtxtestate"
        Me.dgvtxtestate.ReadOnly = True
        '
        'pnlSearchLPO
        '
        Me.pnlSearchLPO.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSearchLPO.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.pnlSearchLPO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSearchLPO.BorderColor = System.Drawing.Color.Gray
        Me.pnlSearchLPO.CaptionColorOne = System.Drawing.Color.White
        Me.pnlSearchLPO.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSearchLPO.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearchLPO.CaptionSize = 40
        Me.pnlSearchLPO.CaptionText = "Search ProductionLog QCD Raw Material Details"
        Me.pnlSearchLPO.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchEstate)
        Me.pnlSearchLPO.Controls.Add(Me.Panel1)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearchEstate)
        Me.pnlSearchLPO.Controls.Add(Me.Label67)
        Me.pnlSearchLPO.Controls.Add(Me.chkDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.dtpSearchDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.btnLPOViewReport)
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchTicket)
        Me.pnlSearchLPO.Controls.Add(Me.btnViewSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearchTicket)
        Me.pnlSearchLPO.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSearchLPO.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSearchLPO.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSearchLPO.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearchLPO.Location = New System.Drawing.Point(3, 3)
        Me.pnlSearchLPO.Moveable = True
        Me.pnlSearchLPO.Name = "pnlSearchLPO"
        Me.pnlSearchLPO.Size = New System.Drawing.Size(936, 138)
        Me.pnlSearchLPO.TabIndex = 94
        '
        'txtSearchEstate
        '
        Me.txtSearchEstate.Location = New System.Drawing.Point(379, 99)
        Me.txtSearchEstate.Name = "txtSearchEstate"
        Me.txtSearchEstate.Size = New System.Drawing.Size(129, 20)
        Me.txtSearchEstate.TabIndex = 33
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(0, 157)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1124, 425)
        Me.Panel1.TabIndex = 33
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearch.Location = New System.Drawing.Point(2, 45)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(72, 13)
        Me.lblSearch.TabIndex = 69
        Me.lblSearch.Text = "Search By"
        '
        'lblSearchEstate
        '
        Me.lblSearchEstate.AutoSize = True
        Me.lblSearchEstate.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchEstate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSearchEstate.ForeColor = System.Drawing.Color.Black
        Me.lblSearchEstate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchEstate.Location = New System.Drawing.Point(376, 76)
        Me.lblSearchEstate.Name = "lblSearchEstate"
        Me.lblSearchEstate.Size = New System.Drawing.Size(42, 13)
        Me.lblSearchEstate.TabIndex = 91
        Me.lblSearchEstate.Text = "Estate"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label67.ForeColor = System.Drawing.Color.Black
        Me.Label67.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label67.Location = New System.Drawing.Point(76, 47)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(12, 14)
        Me.Label67.TabIndex = 70
        Me.Label67.Text = ":"
        '
        'chkDocDate
        '
        Me.chkDocDate.AutoSize = True
        Me.chkDocDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkDocDate.Location = New System.Drawing.Point(104, 77)
        Me.chkDocDate.Name = "chkDocDate"
        Me.chkDocDate.Size = New System.Drawing.Size(49, 17)
        Me.chkDocDate.TabIndex = 30
        Me.chkDocDate.Text = "Date"
        Me.chkDocDate.UseVisualStyleBackColor = True
        '
        'dtpSearchDocDate
        '
        Me.dtpSearchDocDate.CalendarFont = New System.Drawing.Font("Verdana", 7.5!)
        Me.dtpSearchDocDate.CalendarTitleBackColor = System.Drawing.Color.Blue
        Me.dtpSearchDocDate.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.dtpSearchDocDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchDocDate.Enabled = False
        Me.dtpSearchDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchDocDate.Location = New System.Drawing.Point(104, 99)
        Me.dtpSearchDocDate.Name = "dtpSearchDocDate"
        Me.dtpSearchDocDate.Size = New System.Drawing.Size(129, 20)
        Me.dtpSearchDocDate.TabIndex = 31
        '
        'btnLPOViewReport
        '
        Me.btnLPOViewReport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnLPOViewReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnLPOViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnLPOViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLPOViewReport.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnLPOViewReport.Image = CType(resources.GetObject("btnLPOViewReport.Image"), System.Drawing.Image)
        Me.btnLPOViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLPOViewReport.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLPOViewReport.Location = New System.Drawing.Point(670, 95)
        Me.btnLPOViewReport.Name = "btnLPOViewReport"
        Me.btnLPOViewReport.Size = New System.Drawing.Size(110, 25)
        Me.btnLPOViewReport.TabIndex = 405
        Me.btnLPOViewReport.Text = "View Report"
        Me.btnLPOViewReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLPOViewReport.UseVisualStyleBackColor = True
        Me.btnLPOViewReport.Visible = False
        '
        'txtSearchTicket
        '
        Me.txtSearchTicket.Location = New System.Drawing.Point(239, 99)
        Me.txtSearchTicket.Name = "txtSearchTicket"
        Me.txtSearchTicket.Size = New System.Drawing.Size(129, 20)
        Me.txtSearchTicket.TabIndex = 32
        '
        'btnViewSearch
        '
        Me.btnViewSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnViewSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnViewSearch.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnViewSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnViewSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnViewSearch.Image = CType(resources.GetObject("btnViewSearch.Image"), System.Drawing.Image)
        Me.btnViewSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnViewSearch.Location = New System.Drawing.Point(555, 95)
        Me.btnViewSearch.Name = "btnViewSearch"
        Me.btnViewSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnViewSearch.Size = New System.Drawing.Size(110, 25)
        Me.btnViewSearch.TabIndex = 34
        Me.btnViewSearch.Text = "Search"
        Me.btnViewSearch.UseVisualStyleBackColor = True
        '
        'lblSearchTicket
        '
        Me.lblSearchTicket.AutoSize = True
        Me.lblSearchTicket.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchTicket.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSearchTicket.ForeColor = System.Drawing.Color.Black
        Me.lblSearchTicket.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchTicket.Location = New System.Drawing.Point(239, 77)
        Me.lblSearchTicket.Name = "lblSearchTicket"
        Me.lblSearchTicket.Size = New System.Drawing.Size(64, 13)
        Me.lblSearchTicket.TabIndex = 74
        Me.lblSearchTicket.Text = "Ticket No."
        '
        'ProductionQcdRawFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(950, 522)
        Me.Controls.Add(Me.TabContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductionQcdRawFrm"
        Me.Text = "ProductionQcdRawFrm"
        Me.TabContainerMain.ResumeLayout(False)
        Me.cmsProductionQCDRaw.ResumeLayout(False)
        Me.tabSave.ResumeLayout(False)
        Me.tabSave.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabSearchView.ResumeLayout(False)
        Me.tabSearchView.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearchLPO.ResumeLayout(False)
        Me.pnlSearchLPO.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabContainerMain As System.Windows.Forms.TabControl
    Friend WithEvents tabSave As System.Windows.Forms.TabPage
    Friend WithEvents tabSearchView As System.Windows.Forms.TabPage
    Friend WithEvents lblrm As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCarNo As System.Windows.Forms.TextBox
    Friend WithEvents txtDivision As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNh3Ngrr As System.Windows.Forms.TextBox
    Friend WithEvents txtNh31 As System.Windows.Forms.TextBox
    Friend WithEvents txtDrc2 As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyEstate As System.Windows.Forms.TextBox
    Friend WithEvents txtNh3Estate As System.Windows.Forms.TextBox
    Friend WithEvents txtNh32 As System.Windows.Forms.TextBox
    Friend WithEvents txtDrc3 As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyFactory As System.Windows.Forms.TextBox
    Friend WithEvents txtVfaNo As System.Windows.Forms.TextBox
    Friend WithEvents txtNh33 As System.Windows.Forms.TextBox
    Friend WithEvents txtDrcNgrr As System.Windows.Forms.TextBox
    Friend WithEvents txtDrc1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtAsh As System.Windows.Forms.TextBox
    Friend WithEvents txtDirt As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtRawMaterial As System.Windows.Forms.TextBox
    Friend WithEvents txtEstate As System.Windows.Forms.TextBox
    Friend WithEvents btnTicket As System.Windows.Forms.Button
    Friend WithEvents txtTicket As System.Windows.Forms.TextBox
    Friend WithEvents cmsProductionQCDRaw As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlSearchLPO As Stepi.UI.ExtendedPanel
    Friend WithEvents txtSearchEstate As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents lblSearchEstate As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents chkDocDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpSearchDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLPOViewReport As System.Windows.Forms.Button
    Friend WithEvents txtSearchTicket As System.Windows.Forms.TextBox
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearchTicket As System.Windows.Forms.Label
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents dgvView As System.Windows.Forms.DataGridView
    Friend WithEvents dgtxtDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtDocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtticket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvtxtestate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDrcEstate As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnestate As System.Windows.Forms.Button
    Friend WithEvents btnraw As System.Windows.Forms.Button
End Class

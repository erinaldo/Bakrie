<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionQcdOtherFrm
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionQcdOtherFrm))
        Me.TabContainerMain = New System.Windows.Forms.TabControl()
        Me.cmsProductionQCDOther = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabSave = New System.Windows.Forms.TabPage()
        Me.txtCRubber10VK = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtStorage = New System.Windows.Forms.TextBox()
        Me.txtBcDRC = New System.Windows.Forms.TextBox()
        Me.txtBsrDRC = New System.Windows.Forms.TextBox()
        Me.txtAsh = New System.Windows.Forms.TextBox()
        Me.txtDirt = New System.Windows.Forms.TextBox()
        Me.txtCRubberDRC = New System.Windows.Forms.TextBox()
        Me.txtRssDRC = New System.Windows.Forms.TextBox()
        Me.txtMG = New System.Windows.Forms.TextBox()
        Me.txtCenexNh3 = New System.Windows.Forms.TextBox()
        Me.txtCenexDRC = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnUpdateAll = New System.Windows.Forms.Button()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.txtCRubber3CV = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.tabSearchView = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.dgtxtDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtDocDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtstorage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvtxtCRubber3CV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlSearchLPO = New Stepi.UI.ExtendedPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.chkDocDate = New System.Windows.Forms.CheckBox()
        Me.dtpSearchDocDate = New System.Windows.Forms.DateTimePicker()
        Me.btnLPOViewReport = New System.Windows.Forms.Button()
        Me.txtSearchStorage = New System.Windows.Forms.TextBox()
        Me.btnViewSearch = New System.Windows.Forms.Button()
        Me.lblSearchStorage = New System.Windows.Forms.Label()
        Me.TabContainerMain.SuspendLayout()
        Me.cmsProductionQCDOther.SuspendLayout()
        Me.tabSave.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabSearchView.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearchLPO.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabContainerMain
        '
        Me.TabContainerMain.ContextMenuStrip = Me.cmsProductionQCDOther
        Me.TabContainerMain.Controls.Add(Me.tabSave)
        Me.TabContainerMain.Controls.Add(Me.tabSearchView)
        Me.TabContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabContainerMain.Location = New System.Drawing.Point(0, 0)
        Me.TabContainerMain.Name = "TabContainerMain"
        Me.TabContainerMain.SelectedIndex = 0
        Me.TabContainerMain.Size = New System.Drawing.Size(950, 522)
        Me.TabContainerMain.TabIndex = 0
        '
        'cmsProductionQCDOther
        '
        Me.cmsProductionQCDOther.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsProductionQCDOther.Name = "cmsIPR"
        Me.cmsProductionQCDOther.Size = New System.Drawing.Size(108, 70)
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
        Me.tabSave.Controls.Add(Me.txtCRubber10VK)
        Me.tabSave.Controls.Add(Me.Label14)
        Me.tabSave.Controls.Add(Me.btnSaveAll)
        Me.tabSave.Controls.Add(Me.GroupBox1)
        Me.tabSave.Controls.Add(Me.btnUpdateAll)
        Me.tabSave.Controls.Add(Me.btnResetAll)
        Me.tabSave.Controls.Add(Me.txtCRubber3CV)
        Me.tabSave.Controls.Add(Me.btnClose)
        Me.tabSave.Controls.Add(Me.dtpDate)
        Me.tabSave.Controls.Add(Me.Label3)
        Me.tabSave.Controls.Add(Me.Label2)
        Me.tabSave.Controls.Add(Me.Label1)
        Me.tabSave.Controls.Add(Me.lbldate)
        Me.tabSave.Location = New System.Drawing.Point(4, 22)
        Me.tabSave.Name = "tabSave"
        Me.tabSave.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSave.Size = New System.Drawing.Size(942, 496)
        Me.tabSave.TabIndex = 0
        Me.tabSave.Text = "QCD Others"
        Me.tabSave.UseVisualStyleBackColor = True
        '
        'txtCRubber10VK
        '
        Me.txtCRubber10VK.Location = New System.Drawing.Point(794, 28)
        Me.txtCRubber10VK.Name = "txtCRubber10VK"
        Me.txtCRubber10VK.Size = New System.Drawing.Size(121, 20)
        Me.txtCRubber10VK.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(562, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(223, 13)
        Me.Label14.TabIndex = 320
        Me.Label14.Text = "Crumb Rubber SIR 10/10VK/20/20VK"
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnSaveAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSaveAll.Location = New System.Drawing.Point(389, 424)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(127, 29)
        Me.btnSaveAll.TabIndex = 14
        Me.btnSaveAll.Text = "Save"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtStorage)
        Me.GroupBox1.Controls.Add(Me.txtBcDRC)
        Me.GroupBox1.Controls.Add(Me.txtBsrDRC)
        Me.GroupBox1.Controls.Add(Me.txtAsh)
        Me.GroupBox1.Controls.Add(Me.txtDirt)
        Me.GroupBox1.Controls.Add(Me.txtCRubberDRC)
        Me.GroupBox1.Controls.Add(Me.txtRssDRC)
        Me.GroupBox1.Controls.Add(Me.txtMG)
        Me.GroupBox1.Controls.Add(Me.txtCenexNh3)
        Me.GroupBox1.Controls.Add(Me.txtCenexDRC)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(933, 262)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "QCD Other Details"
        '
        'txtStorage
        '
        Me.txtStorage.Location = New System.Drawing.Point(154, 32)
        Me.txtStorage.Name = "txtStorage"
        Me.txtStorage.Size = New System.Drawing.Size(121, 20)
        Me.txtStorage.TabIndex = 4
        '
        'txtBcDRC
        '
        Me.txtBcDRC.Location = New System.Drawing.Point(614, 223)
        Me.txtBcDRC.Name = "txtBcDRC"
        Me.txtBcDRC.Size = New System.Drawing.Size(121, 20)
        Me.txtBcDRC.TabIndex = 13
        '
        'txtBsrDRC
        '
        Me.txtBsrDRC.Location = New System.Drawing.Point(614, 180)
        Me.txtBsrDRC.Name = "txtBsrDRC"
        Me.txtBsrDRC.Size = New System.Drawing.Size(121, 20)
        Me.txtBsrDRC.TabIndex = 11
        '
        'txtAsh
        '
        Me.txtAsh.Location = New System.Drawing.Point(614, 130)
        Me.txtAsh.Name = "txtAsh"
        Me.txtAsh.Size = New System.Drawing.Size(121, 20)
        Me.txtAsh.TabIndex = 9
        '
        'txtDirt
        '
        Me.txtDirt.Location = New System.Drawing.Point(614, 87)
        Me.txtDirt.Name = "txtDirt"
        Me.txtDirt.Size = New System.Drawing.Size(121, 20)
        Me.txtDirt.TabIndex = 7
        '
        'txtCRubberDRC
        '
        Me.txtCRubberDRC.Location = New System.Drawing.Point(614, 37)
        Me.txtCRubberDRC.Name = "txtCRubberDRC"
        Me.txtCRubberDRC.Size = New System.Drawing.Size(121, 20)
        Me.txtCRubberDRC.TabIndex = 5
        '
        'txtRssDRC
        '
        Me.txtRssDRC.Location = New System.Drawing.Point(154, 223)
        Me.txtRssDRC.Name = "txtRssDRC"
        Me.txtRssDRC.Size = New System.Drawing.Size(121, 20)
        Me.txtRssDRC.TabIndex = 12
        '
        'txtMG
        '
        Me.txtMG.Location = New System.Drawing.Point(154, 179)
        Me.txtMG.Name = "txtMG"
        Me.txtMG.Size = New System.Drawing.Size(121, 20)
        Me.txtMG.TabIndex = 10
        '
        'txtCenexNh3
        '
        Me.txtCenexNh3.Location = New System.Drawing.Point(154, 128)
        Me.txtCenexNh3.Name = "txtCenexNh3"
        Me.txtCenexNh3.Size = New System.Drawing.Size(121, 20)
        Me.txtCenexNh3.TabIndex = 8
        '
        'txtCenexDRC
        '
        Me.txtCenexDRC.Location = New System.Drawing.Point(154, 84)
        Me.txtCenexDRC.Name = "txtCenexDRC"
        Me.txtCenexDRC.Size = New System.Drawing.Size(121, 20)
        Me.txtCenexDRC.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(440, 230)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(138, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Brown Creep DRC (%)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(440, 186)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 13)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "BSR DRC (%)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(440, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Ash Content (%)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(440, 91)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 13)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Dirt Content (%)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(440, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(121, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Crumb Rubber DRC"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(14, 230)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "RSS DRC (%)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(14, 186)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Mg"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(14, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Cenex NH3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(14, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Cenex DRC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(14, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Storage RM"
        '
        'btnUpdateAll
        '
        Me.btnUpdateAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnUpdateAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnUpdateAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUpdateAll.Image = Global.BSP.My.Resources.Resources.user_add
        Me.btnUpdateAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateAll.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnUpdateAll.Location = New System.Drawing.Point(522, 424)
        Me.btnUpdateAll.Name = "btnUpdateAll"
        Me.btnUpdateAll.Size = New System.Drawing.Size(127, 29)
        Me.btnUpdateAll.TabIndex = 15
        Me.btnUpdateAll.Text = "Update"
        Me.btnUpdateAll.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnResetAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Image = Global.BSP.My.Resources.Resources.refresh
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnResetAll.Location = New System.Drawing.Point(655, 424)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(127, 29)
        Me.btnResetAll.TabIndex = 16
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'txtCRubber3CV
        '
        Me.txtCRubber3CV.Location = New System.Drawing.Point(413, 28)
        Me.txtCRubber3CV.Name = "txtCRubber3CV"
        Me.txtCRubber3CV.Size = New System.Drawing.Size(121, 20)
        Me.txtCRubber3CV.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = Global.BSP.My.Resources.Resources.Close_32
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnClose.Location = New System.Drawing.Point(788, 424)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 29)
        Me.btnClose.TabIndex = 17
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(57, 28)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(121, 20)
        Me.dtpDate.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(28, 265)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(28, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(194, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 13)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Crumb Rubber SIR 3CV/L DRC (%)"
        '
        'lbldate
        '
        Me.lbldate.AutoSize = True
        Me.lbldate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lbldate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbldate.Location = New System.Drawing.Point(17, 31)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(34, 13)
        Me.lbldate.TabIndex = 120
        Me.lbldate.Text = "Date"
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
        Me.lblView.TabIndex = 417
        Me.lblView.Text = "Record not found !!"
        Me.lblView.Visible = False
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.AllowUserToResizeRows = False
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.dgvView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvView.ColumnHeadersHeight = 30
        Me.dgvView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgtxtDocID, Me.dgtxtDocDate, Me.dgtxtstorage, Me.dgvtxtCRubber3CV})
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
        Me.dgvView.TabIndex = 416
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
        'dgtxtstorage
        '
        Me.dgtxtstorage.DataPropertyName = "Storage"
        Me.dgtxtstorage.HeaderText = "Storage RM"
        Me.dgtxtstorage.Name = "dgtxtstorage"
        Me.dgtxtstorage.ReadOnly = True
        '
        'dgvtxtCRubber3CV
        '
        Me.dgvtxtCRubber3CV.DataPropertyName = "CRubber3CV"
        Me.dgvtxtCRubber3CV.HeaderText = "Crumb Rubber SIR 3CV/L DRC %"
        Me.dgvtxtCRubber3CV.Name = "dgvtxtCRubber3CV"
        Me.dgvtxtCRubber3CV.ReadOnly = True
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
        Me.pnlSearchLPO.CaptionText = "Search ProductionLog QCD Other Details"
        Me.pnlSearchLPO.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSearchLPO.Controls.Add(Me.Panel1)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearch)
        Me.pnlSearchLPO.Controls.Add(Me.Label67)
        Me.pnlSearchLPO.Controls.Add(Me.chkDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.dtpSearchDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.btnLPOViewReport)
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchStorage)
        Me.pnlSearchLPO.Controls.Add(Me.btnViewSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearchStorage)
        Me.pnlSearchLPO.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSearchLPO.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSearchLPO.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSearchLPO.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearchLPO.Location = New System.Drawing.Point(3, 3)
        Me.pnlSearchLPO.Moveable = True
        Me.pnlSearchLPO.Name = "pnlSearchLPO"
        Me.pnlSearchLPO.Size = New System.Drawing.Size(936, 138)
        Me.pnlSearchLPO.TabIndex = 95
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
        Me.chkDocDate.TabIndex = 200
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
        Me.dtpSearchDocDate.TabIndex = 201
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
        Me.btnLPOViewReport.TabIndex = 204
        Me.btnLPOViewReport.Text = "View Report"
        Me.btnLPOViewReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLPOViewReport.UseVisualStyleBackColor = True
        Me.btnLPOViewReport.Visible = False
        '
        'txtSearchStorage
        '
        Me.txtSearchStorage.Location = New System.Drawing.Point(268, 99)
        Me.txtSearchStorage.Name = "txtSearchStorage"
        Me.txtSearchStorage.Size = New System.Drawing.Size(129, 20)
        Me.txtSearchStorage.TabIndex = 202
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
        Me.btnViewSearch.TabIndex = 203
        Me.btnViewSearch.Text = "Search"
        Me.btnViewSearch.UseVisualStyleBackColor = True
        '
        'lblSearchStorage
        '
        Me.lblSearchStorage.AutoSize = True
        Me.lblSearchStorage.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchStorage.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSearchStorage.ForeColor = System.Drawing.Color.Black
        Me.lblSearchStorage.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchStorage.Location = New System.Drawing.Point(268, 77)
        Me.lblSearchStorage.Name = "lblSearchStorage"
        Me.lblSearchStorage.Size = New System.Drawing.Size(73, 13)
        Me.lblSearchStorage.TabIndex = 74
        Me.lblSearchStorage.Text = "Storage RM"
        '
        'ProductionQcdOtherFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(950, 522)
        Me.Controls.Add(Me.TabContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductionQcdOtherFrm"
        Me.Text = "ProductionQcdOtherFrm"
        Me.TabContainerMain.ResumeLayout(False)
        Me.cmsProductionQCDOther.ResumeLayout(False)
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCRubber3CV As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRssDRC As System.Windows.Forms.TextBox
    Friend WithEvents txtMG As System.Windows.Forms.TextBox
    Friend WithEvents txtCenexNh3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCenexDRC As System.Windows.Forms.TextBox
    Friend WithEvents txtCRubberDRC As System.Windows.Forms.TextBox
    Friend WithEvents txtDirt As System.Windows.Forms.TextBox
    Friend WithEvents txtBcDRC As System.Windows.Forms.TextBox
    Friend WithEvents txtBsrDRC As System.Windows.Forms.TextBox
    Friend WithEvents txtAsh As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnUpdateAll As System.Windows.Forms.Button
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtStorage As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCRubber10VK As System.Windows.Forms.TextBox
    Friend WithEvents cmsProductionQCDOther As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlSearchLPO As Stepi.UI.ExtendedPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents chkDocDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpSearchDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLPOViewReport As System.Windows.Forms.Button
    Friend WithEvents txtSearchStorage As System.Windows.Forms.TextBox
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearchStorage As System.Windows.Forms.Label
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents dgvView As System.Windows.Forms.DataGridView
    Friend WithEvents dgtxtDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtDocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtstorage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvtxtCRubber3CV As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

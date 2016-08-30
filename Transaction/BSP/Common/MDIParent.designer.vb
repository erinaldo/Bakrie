<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIParent))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLogoutMDI = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.lblEstate = New System.Windows.Forms.Label()
        Me.lblEstateName = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblLoginYear = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblAyear = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblMenuName = New System.Windows.Forms.Label()
        Me.lblVersionNo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblmesg = New System.Windows.Forms.Label()
        Me.lplmesg = New System.Windows.Forms.Label()
        Me.ExtendedPanel1 = New Stepi.UI.ExtendedPanel()
        Me.tvMDIMenu = New System.Windows.Forms.TreeView()
        Me.plTopMenuMDI = New System.Windows.Forms.Panel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbtnBudget = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnCheckrollMDI = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnStore = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnVehicleMDI = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnWeighBridge = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnAccounts = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnProductionMDI = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnCentral = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnSystem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnAdmin = New System.Windows.Forms.ToolStripButton()
        Me.ExtendedPanel2 = New Stepi.UI.ExtendedPanel()
        Me.pnlFooter.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ExtendedPanel1.SuspendLayout()
        Me.plTopMenuMDI.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.ExtendedPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLogoutMDI
        '
        Me.btnLogoutMDI.BackColor = System.Drawing.Color.Transparent
        Me.btnLogoutMDI.BackgroundImage = Global.BSP.My.Resources.Resources.logout
        Me.btnLogoutMDI.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnLogoutMDI.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnLogoutMDI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnLogoutMDI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogoutMDI.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnLogoutMDI.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnLogoutMDI.Location = New System.Drawing.Point(996, 0)
        Me.btnLogoutMDI.Name = "btnLogoutMDI"
        Me.btnLogoutMDI.Size = New System.Drawing.Size(32, 26)
        Me.btnLogoutMDI.TabIndex = 61
        Me.btnLogoutMDI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.btnLogoutMDI, "Log Out")
        Me.btnLogoutMDI.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1.png")
        Me.ImageList1.Images.SetKeyName(1, "001_54.png")
        '
        'pnlFooter
        '
        Me.pnlFooter.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlFooter.Controls.Add(Me.lblEstate)
        Me.pnlFooter.Controls.Add(Me.lblEstateName)
        Me.pnlFooter.Controls.Add(Me.PictureBox4)
        Me.pnlFooter.Controls.Add(Me.Label2)
        Me.pnlFooter.Controls.Add(Me.Label1)
        Me.pnlFooter.Controls.Add(Me.PictureBox3)
        Me.pnlFooter.Controls.Add(Me.lblLoginYear)
        Me.pnlFooter.Controls.Add(Me.PictureBox2)
        Me.pnlFooter.Controls.Add(Me.lblAyear)
        Me.pnlFooter.Controls.Add(Me.PictureBox1)
        Me.pnlFooter.Controls.Add(Me.lblUserName)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 623)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(1028, 28)
        Me.pnlFooter.TabIndex = 14
        '
        'lblEstate
        '
        Me.lblEstate.AutoSize = True
        Me.lblEstate.BackColor = System.Drawing.Color.Transparent
        Me.lblEstate.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.lblEstate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEstate.Location = New System.Drawing.Point(649, 8)
        Me.lblEstate.Name = "lblEstate"
        Me.lblEstate.Size = New System.Drawing.Size(48, 12)
        Me.lblEstate.TabIndex = 20
        Me.lblEstate.Text = "Estate :"
        '
        'lblEstateName
        '
        Me.lblEstateName.AutoSize = True
        Me.lblEstateName.BackColor = System.Drawing.Color.Transparent
        Me.lblEstateName.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.lblEstateName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstateName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEstateName.Location = New System.Drawing.Point(696, 8)
        Me.lblEstateName.Name = "lblEstateName"
        Me.lblEstateName.Size = New System.Drawing.Size(39, 12)
        Me.lblEstateName.TabIndex = 19
        Me.lblEstateName.Text = "Estate"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox4.Location = New System.Drawing.Point(642, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(1, 21)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 18
        Me.PictureBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(378, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 12)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Login Month/Year :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(127, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Active Month/Year:"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox3.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(29, 34)
        Me.PictureBox3.TabIndex = 15
        Me.PictureBox3.TabStop = False
        '
        'lblLoginYear
        '
        Me.lblLoginYear.AutoSize = True
        Me.lblLoginYear.BackColor = System.Drawing.Color.Transparent
        Me.lblLoginYear.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.lblLoginYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblLoginYear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLoginYear.Location = New System.Drawing.Point(489, 8)
        Me.lblLoginYear.Name = "lblLoginYear"
        Me.lblLoginYear.Size = New System.Drawing.Size(111, 12)
        Me.lblLoginYear.TabIndex = 12
        Me.lblLoginYear.Text = "Login Month/Year :"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox2.Location = New System.Drawing.Point(354, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1, 21)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'lblAyear
        '
        Me.lblAyear.AutoSize = True
        Me.lblAyear.BackColor = System.Drawing.Color.Transparent
        Me.lblAyear.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.lblAyear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblAyear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAyear.Location = New System.Drawing.Point(236, 8)
        Me.lblAyear.Name = "lblAyear"
        Me.lblAyear.Size = New System.Drawing.Size(109, 12)
        Me.lblAyear.TabIndex = 10
        Me.lblAyear.Text = "Active Month/Year:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(120, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.lblUserName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUserName.Location = New System.Drawing.Point(39, 8)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(62, 12)
        Me.lblUserName.TabIndex = 0
        Me.lblUserName.Text = "UserName"
        '
        'lblMenuName
        '
        Me.lblMenuName.AutoSize = True
        Me.lblMenuName.BackColor = System.Drawing.Color.Transparent
        Me.lblMenuName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMenuName.ForeColor = System.Drawing.Color.Navy
        Me.lblMenuName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMenuName.Location = New System.Drawing.Point(22, 13)
        Me.lblMenuName.Name = "lblMenuName"
        Me.lblMenuName.Size = New System.Drawing.Size(0, 13)
        Me.lblMenuName.TabIndex = 14
        '
        'lblVersionNo
        '
        Me.lblVersionNo.AutoSize = True
        Me.lblVersionNo.BackColor = System.Drawing.Color.Transparent
        Me.lblVersionNo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblVersionNo.ForeColor = System.Drawing.Color.Navy
        Me.lblVersionNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVersionNo.Location = New System.Drawing.Point(1093, 7)
        Me.lblVersionNo.Name = "lblVersionNo"
        Me.lblVersionNo.Size = New System.Drawing.Size(49, 13)
        Me.lblVersionNo.TabIndex = 1
        Me.lblVersionNo.Text = "Version"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.Panel1.Controls.Add(Me.lblmesg)
        Me.Panel1.Controls.Add(Me.lplmesg)
        Me.Panel1.Controls.Add(Me.lblVersionNo)
        Me.Panel1.Controls.Add(Me.lblMenuName)
        Me.Panel1.Controls.Add(Me.btnLogoutMDI)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1028, 26)
        Me.Panel1.TabIndex = 67
        '
        'lblmesg
        '
        Me.lblmesg.AutoSize = True
        Me.lblmesg.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lblmesg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmesg.ForeColor = System.Drawing.Color.Maroon
        Me.lblmesg.Location = New System.Drawing.Point(301, 7)
        Me.lblmesg.Name = "lblmesg"
        Me.lblmesg.Size = New System.Drawing.Size(0, 13)
        Me.lblmesg.TabIndex = 63
        '
        'lplmesg
        '
        Me.lplmesg.AutoSize = True
        Me.lplmesg.Location = New System.Drawing.Point(302, 13)
        Me.lplmesg.Name = "lplmesg"
        Me.lplmesg.Size = New System.Drawing.Size(0, 13)
        Me.lplmesg.TabIndex = 62
        '
        'ExtendedPanel1
        '
        Me.ExtendedPanel1.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.ExtendedPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ExtendedPanel1.BorderColor = System.Drawing.Color.DimGray
        Me.ExtendedPanel1.CaptionAlign = Stepi.UI.DirectionStyle.Left
        Me.ExtendedPanel1.CaptionColorOne = System.Drawing.Color.Empty
        Me.ExtendedPanel1.CaptionColorTwo = System.Drawing.Color.Empty
        Me.ExtendedPanel1.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExtendedPanel1.CaptionSize = 30
        Me.ExtendedPanel1.CaptionText = ""
        Me.ExtendedPanel1.CaptionTextColor = System.Drawing.Color.Black
        Me.ExtendedPanel1.Controls.Add(Me.tvMDIMenu)
        Me.ExtendedPanel1.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.ExtendedPanel1.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.ExtendedPanel1.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.ExtendedPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExtendedPanel1.Location = New System.Drawing.Point(0, 83)
        Me.ExtendedPanel1.Name = "ExtendedPanel1"
        Me.ExtendedPanel1.Size = New System.Drawing.Size(294, 540)
        Me.ExtendedPanel1.TabIndex = 68
        '
        'tvMDIMenu
        '
        Me.tvMDIMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tvMDIMenu.Dock = System.Windows.Forms.DockStyle.Right
        Me.tvMDIMenu.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvMDIMenu.ForeColor = System.Drawing.Color.Navy
        Me.tvMDIMenu.Indent = 25
        Me.tvMDIMenu.ItemHeight = 22
        Me.tvMDIMenu.Location = New System.Drawing.Point(28, 0)
        Me.tvMDIMenu.Name = "tvMDIMenu"
        Me.tvMDIMenu.ShowNodeToolTips = True
        Me.tvMDIMenu.Size = New System.Drawing.Size(266, 540)
        Me.tvMDIMenu.TabIndex = 0
        '
        'plTopMenuMDI
        '
        Me.plTopMenuMDI.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.plTopMenuMDI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plTopMenuMDI.Controls.Add(Me.ToolStrip)
        Me.plTopMenuMDI.Dock = System.Windows.Forms.DockStyle.Top
        Me.plTopMenuMDI.Location = New System.Drawing.Point(0, 0)
        Me.plTopMenuMDI.Name = "plTopMenuMDI"
        Me.plTopMenuMDI.Size = New System.Drawing.Size(1028, 54)
        Me.plTopMenuMDI.TabIndex = 13
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(35, 35)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnBudget, Me.ToolStripSeparator1, Me.tsbtnCheckrollMDI, Me.ToolStripSeparator2, Me.tsbtnStore, Me.ToolStripSeparator3, Me.tsbtnVehicleMDI, Me.ToolStripSeparator4, Me.tsbtnWeighBridge, Me.ToolStripSeparator5, Me.tsbtnAccounts, Me.ToolStripSeparator6, Me.tsbtnProductionMDI, Me.ToolStripSeparator7, Me.tsbtnCentral, Me.ToolStripSeparator8, Me.tsbtnSystem, Me.ToolStripSeparator9, Me.tsbtnAdmin})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 23)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(916, 31)
        Me.ToolStrip.TabIndex = 9
        Me.ToolStrip.Text = " "
        '
        'tsbtnBudget
        '
        Me.tsbtnBudget.AutoSize = False
        Me.tsbtnBudget.BackColor = System.Drawing.Color.Transparent
        Me.tsbtnBudget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tsbtnBudget.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnBudget.ForeColor = System.Drawing.Color.Navy
        Me.tsbtnBudget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsbtnBudget.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbtnBudget.Name = "tsbtnBudget"
        Me.tsbtnBudget.Size = New System.Drawing.Size(80, 28)
        Me.tsbtnBudget.Text = "Budget"
        Me.tsbtnBudget.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'tsbtnCheckrollMDI
        '
        Me.tsbtnCheckrollMDI.AutoSize = False
        Me.tsbtnCheckrollMDI.BackColor = System.Drawing.Color.Transparent
        Me.tsbtnCheckrollMDI.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnCheckrollMDI.ForeColor = System.Drawing.Color.Navy
        Me.tsbtnCheckrollMDI.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbtnCheckrollMDI.Name = "tsbtnCheckrollMDI"
        Me.tsbtnCheckrollMDI.Size = New System.Drawing.Size(90, 28)
        Me.tsbtnCheckrollMDI.Text = "Check Roll"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'tsbtnStore
        '
        Me.tsbtnStore.AutoSize = False
        Me.tsbtnStore.BackColor = System.Drawing.Color.Transparent
        Me.tsbtnStore.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnStore.ForeColor = System.Drawing.Color.Navy
        Me.tsbtnStore.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbtnStore.Name = "tsbtnStore"
        Me.tsbtnStore.Size = New System.Drawing.Size(70, 28)
        Me.tsbtnStore.Text = "Store"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'tsbtnVehicleMDI
        '
        Me.tsbtnVehicleMDI.AutoSize = False
        Me.tsbtnVehicleMDI.BackColor = System.Drawing.Color.Transparent
        Me.tsbtnVehicleMDI.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnVehicleMDI.ForeColor = System.Drawing.Color.Navy
        Me.tsbtnVehicleMDI.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbtnVehicleMDI.Name = "tsbtnVehicleMDI"
        Me.tsbtnVehicleMDI.Size = New System.Drawing.Size(70, 28)
        Me.tsbtnVehicleMDI.Text = "Vehicle"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'tsbtnWeighBridge
        '
        Me.tsbtnWeighBridge.AutoSize = False
        Me.tsbtnWeighBridge.BackColor = System.Drawing.Color.Transparent
        Me.tsbtnWeighBridge.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnWeighBridge.ForeColor = System.Drawing.Color.Navy
        Me.tsbtnWeighBridge.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbtnWeighBridge.Name = "tsbtnWeighBridge"
        Me.tsbtnWeighBridge.Size = New System.Drawing.Size(120, 28)
        Me.tsbtnWeighBridge.Text = "Weigh Bridge"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'tsbtnAccounts
        '
        Me.tsbtnAccounts.AutoSize = False
        Me.tsbtnAccounts.BackColor = System.Drawing.Color.Transparent
        Me.tsbtnAccounts.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnAccounts.ForeColor = System.Drawing.Color.Navy
        Me.tsbtnAccounts.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbtnAccounts.Name = "tsbtnAccounts"
        Me.tsbtnAccounts.Size = New System.Drawing.Size(100, 28)
        Me.tsbtnAccounts.Text = "Accounts"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'tsbtnProductionMDI
        '
        Me.tsbtnProductionMDI.AutoSize = False
        Me.tsbtnProductionMDI.BackColor = System.Drawing.Color.Transparent
        Me.tsbtnProductionMDI.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnProductionMDI.ForeColor = System.Drawing.Color.Navy
        Me.tsbtnProductionMDI.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbtnProductionMDI.Name = "tsbtnProductionMDI"
        Me.tsbtnProductionMDI.Size = New System.Drawing.Size(100, 28)
        Me.tsbtnProductionMDI.Text = "Production"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'tsbtnCentral
        '
        Me.tsbtnCentral.AutoSize = False
        Me.tsbtnCentral.BackColor = System.Drawing.Color.Transparent
        Me.tsbtnCentral.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnCentral.ForeColor = System.Drawing.Color.Navy
        Me.tsbtnCentral.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbtnCentral.Name = "tsbtnCentral"
        Me.tsbtnCentral.Size = New System.Drawing.Size(70, 28)
        Me.tsbtnCentral.Text = "Central"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'tsbtnSystem
        '
        Me.tsbtnSystem.AutoSize = False
        Me.tsbtnSystem.BackColor = System.Drawing.Color.Transparent
        Me.tsbtnSystem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnSystem.ForeColor = System.Drawing.Color.Navy
        Me.tsbtnSystem.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbtnSystem.Name = "tsbtnSystem"
        Me.tsbtnSystem.Size = New System.Drawing.Size(150, 28)
        Me.tsbtnSystem.Text = "Management Reports"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'tsbtnAdmin
        '
        Me.tsbtnAdmin.AutoSize = False
        Me.tsbtnAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tsbtnAdmin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tsbtnAdmin.ForeColor = System.Drawing.Color.Navy
        Me.tsbtnAdmin.Image = Global.BSP.My.Resources.Resources.User_32x32
        Me.tsbtnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsbtnAdmin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAdmin.Name = "tsbtnAdmin"
        Me.tsbtnAdmin.Size = New System.Drawing.Size(80, 28)
        Me.tsbtnAdmin.Text = "Admin"
        Me.tsbtnAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ExtendedPanel2
        '
        Me.ExtendedPanel2.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.ExtendedPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ExtendedPanel2.BorderColor = System.Drawing.Color.Gray
        Me.ExtendedPanel2.CaptionColorOne = System.Drawing.Color.Transparent
        Me.ExtendedPanel2.CaptionColorTwo = System.Drawing.Color.Transparent
        Me.ExtendedPanel2.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExtendedPanel2.CaptionSize = 20
        Me.ExtendedPanel2.CaptionText = ""
        Me.ExtendedPanel2.CaptionTextColor = System.Drawing.Color.Black
        Me.ExtendedPanel2.Controls.Add(Me.plTopMenuMDI)
        Me.ExtendedPanel2.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.ExtendedPanel2.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.ExtendedPanel2.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.ExtendedPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExtendedPanel2.Location = New System.Drawing.Point(0, 0)
        Me.ExtendedPanel2.Name = "ExtendedPanel2"
        Me.ExtendedPanel2.Size = New System.Drawing.Size(1028, 57)
        Me.ExtendedPanel2.TabIndex = 65
        '
        'MDIParent
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1028, 651)
        Me.Controls.Add(Me.ExtendedPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ExtendedPanel2)
        Me.Controls.Add(Me.pnlFooter)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "MDIParent"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BSP Application"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlFooter.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ExtendedPanel1.ResumeLayout(False)
        Me.plTopMenuMDI.ResumeLayout(False)
        Me.plTopMenuMDI.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ExtendedPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblLoginYear As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblAyear As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblEstateName As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstate As System.Windows.Forms.Label
    Friend WithEvents lblMenuName As System.Windows.Forms.Label
    Friend WithEvents btnLogoutMDI As System.Windows.Forms.Button
    Friend WithEvents lblVersionNo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ExtendedPanel1 As Stepi.UI.ExtendedPanel
    Friend WithEvents tvMDIMenu As System.Windows.Forms.TreeView
    Friend WithEvents plTopMenuMDI As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnBudget As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnCheckrollMDI As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnStore As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnVehicleMDI As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnWeighBridge As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnAccounts As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnProductionMDI As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnCentral As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnSystem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnAdmin As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExtendedPanel2 As Stepi.UI.ExtendedPanel
    Friend WithEvents lplmesg As System.Windows.Forms.Label
    Friend WithEvents lblmesg As System.Windows.Forms.Label

End Class

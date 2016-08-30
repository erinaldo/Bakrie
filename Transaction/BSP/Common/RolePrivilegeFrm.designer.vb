<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RolePrivilegeFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RolePrivilegeFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PlRolePrivilege = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gpView = New System.Windows.Forms.GroupBox()
        Me.dgvViewPrivilege = New System.Windows.Forms.DataGridView()
        Me.RolePrivilegeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RoleID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuGroupID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RoleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModuleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Visible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AllowAdd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AllowEdit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AllowDelete = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveUPdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gpRolePrivilege = New System.Windows.Forms.GroupBox()
        Me.chkIncludeAllMenuGroup = New System.Windows.Forms.CheckBox()
        Me.chkIncludeAllMenu = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbAllowDelete = New System.Windows.Forms.ComboBox()
        Me.lblAllowDelete = New System.Windows.Forms.Label()
        Me.cbAllowUpdate = New System.Windows.Forms.ComboBox()
        Me.lblAllowUpdate = New System.Windows.Forms.Label()
        Me.cbAllowAdd = New System.Windows.Forms.ComboBox()
        Me.lblAllowAdd = New System.Windows.Forms.Label()
        Me.cbVisible = New System.Windows.Forms.ComboBox()
        Me.lblVisible = New System.Windows.Forms.Label()
        Me.cbMenu = New System.Windows.Forms.ComboBox()
        Me.cbMenuGroup = New System.Windows.Forms.ComboBox()
        Me.cbModule = New System.Windows.Forms.ComboBox()
        Me.cbRoleName = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMenu = New System.Windows.Forms.Label()
        Me.lblMenuGroup = New System.Windows.Forms.Label()
        Me.lblModule = New System.Windows.Forms.Label()
        Me.lblRoleName = New System.Windows.Forms.Label()
        Me.PlRolePrivilege.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpView.SuspendLayout()
        CType(Me.dgvViewPrivilege, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.gpRolePrivilege.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PlRolePrivilege
        '
        Me.PlRolePrivilege.BackColor = System.Drawing.Color.Transparent
        Me.PlRolePrivilege.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PlRolePrivilege.Controls.Add(Me.GroupBox1)
        Me.PlRolePrivilege.Controls.Add(Me.gpView)
        Me.PlRolePrivilege.Controls.Add(Me.gpRolePrivilege)
        Me.PlRolePrivilege.Location = New System.Drawing.Point(0, 0)
        Me.PlRolePrivilege.Name = "PlRolePrivilege"
        Me.PlRolePrivilege.Size = New System.Drawing.Size(875, 666)
        Me.PlRolePrivilege.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnReset)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 189)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(775, 53)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Image)
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(546, 19)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 25)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(651, 19)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 25)
        Me.btnReset.TabIndex = 11
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(445, 19)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 25)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save "
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gpView
        '
        Me.gpView.Controls.Add(Me.dgvViewPrivilege)
        Me.gpView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpView.Location = New System.Drawing.Point(12, 246)
        Me.gpView.Name = "gpView"
        Me.gpView.Size = New System.Drawing.Size(775, 321)
        Me.gpView.TabIndex = 10
        Me.gpView.TabStop = False
        Me.gpView.Text = "View Privilege"
        '
        'dgvViewPrivilege
        '
        Me.dgvViewPrivilege.AllowUserToAddRows = False
        Me.dgvViewPrivilege.AllowUserToDeleteRows = False
        Me.dgvViewPrivilege.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvViewPrivilege.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.dgvViewPrivilege.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvViewPrivilege.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvViewPrivilege.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvViewPrivilege.ColumnHeadersHeight = 30
        Me.dgvViewPrivilege.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RolePrivilegeID, Me.MenuID, Me.RoleID, Me.ModId, Me.MenuGroupID, Me.RoleName, Me.ModuleName, Me.MenuGroup, Me.MenuName, Me.Visible, Me.AllowAdd, Me.AllowEdit, Me.AllowDelete})
        Me.dgvViewPrivilege.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvViewPrivilege.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvViewPrivilege.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvViewPrivilege.EnableHeadersVisualStyles = False
        Me.dgvViewPrivilege.GridColor = System.Drawing.Color.Gray
        Me.dgvViewPrivilege.Location = New System.Drawing.Point(3, 17)
        Me.dgvViewPrivilege.MultiSelect = False
        Me.dgvViewPrivilege.Name = "dgvViewPrivilege"
        Me.dgvViewPrivilege.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvViewPrivilege.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvViewPrivilege.RowHeadersVisible = False
        Me.dgvViewPrivilege.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvViewPrivilege.ShowCellErrors = False
        Me.dgvViewPrivilege.Size = New System.Drawing.Size(769, 301)
        Me.dgvViewPrivilege.TabIndex = 1
        Me.dgvViewPrivilege.TabStop = False
        '
        'RolePrivilegeID
        '
        Me.RolePrivilegeID.DataPropertyName = "RolePrivilegeID"
        Me.RolePrivilegeID.HeaderText = "RolePrivilegeID"
        Me.RolePrivilegeID.Name = "RolePrivilegeID"
        Me.RolePrivilegeID.ReadOnly = True
        Me.RolePrivilegeID.Visible = False
        '
        'MenuID
        '
        Me.MenuID.DataPropertyName = "MenuID"
        Me.MenuID.HeaderText = "MenuID"
        Me.MenuID.Name = "MenuID"
        Me.MenuID.ReadOnly = True
        Me.MenuID.Visible = False
        '
        'RoleID
        '
        Me.RoleID.DataPropertyName = "RoleID"
        Me.RoleID.HeaderText = "RoleID"
        Me.RoleID.Name = "RoleID"
        Me.RoleID.ReadOnly = True
        Me.RoleID.Visible = False
        '
        'ModId
        '
        Me.ModId.DataPropertyName = "ModID"
        Me.ModId.HeaderText = "ModId"
        Me.ModId.Name = "ModId"
        Me.ModId.ReadOnly = True
        Me.ModId.Visible = False
        '
        'MenuGroupID
        '
        Me.MenuGroupID.DataPropertyName = "MenuGroupID"
        Me.MenuGroupID.HeaderText = "MenuGroupID"
        Me.MenuGroupID.Name = "MenuGroupID"
        Me.MenuGroupID.ReadOnly = True
        Me.MenuGroupID.Visible = False
        '
        'RoleName
        '
        Me.RoleName.DataPropertyName = "RoleName"
        Me.RoleName.HeaderText = "Role Name"
        Me.RoleName.Name = "RoleName"
        Me.RoleName.ReadOnly = True
        Me.RoleName.Width = 87
        '
        'ModuleName
        '
        Me.ModuleName.DataPropertyName = "ModName"
        Me.ModuleName.HeaderText = "Module"
        Me.ModuleName.Name = "ModuleName"
        Me.ModuleName.ReadOnly = True
        Me.ModuleName.Width = 86
        '
        'MenuGroup
        '
        Me.MenuGroup.DataPropertyName = "MenuGroup"
        Me.MenuGroup.HeaderText = "Menu Group"
        Me.MenuGroup.Name = "MenuGroup"
        Me.MenuGroup.ReadOnly = True
        Me.MenuGroup.Width = 88
        '
        'MenuName
        '
        Me.MenuName.DataPropertyName = "MenuName"
        Me.MenuName.HeaderText = "Menu"
        Me.MenuName.Name = "MenuName"
        Me.MenuName.ReadOnly = True
        Me.MenuName.Width = 88
        '
        'Visible
        '
        Me.Visible.DataPropertyName = "Visible"
        Me.Visible.HeaderText = "Visible"
        Me.Visible.Name = "Visible"
        Me.Visible.ReadOnly = True
        Me.Visible.Width = 87
        '
        'AllowAdd
        '
        Me.AllowAdd.DataPropertyName = "RAdd"
        Me.AllowAdd.HeaderText = "Allow Add"
        Me.AllowAdd.Name = "AllowAdd"
        Me.AllowAdd.ReadOnly = True
        Me.AllowAdd.Width = 88
        '
        'AllowEdit
        '
        Me.AllowEdit.DataPropertyName = "RUpdate"
        Me.AllowEdit.HeaderText = "Allow Edit"
        Me.AllowEdit.Name = "AllowEdit"
        Me.AllowEdit.ReadOnly = True
        Me.AllowEdit.Width = 87
        '
        'AllowDelete
        '
        Me.AllowDelete.DataPropertyName = "RDelete"
        Me.AllowDelete.HeaderText = "Allow Delete"
        Me.AllowDelete.Name = "AllowDelete"
        Me.AllowDelete.ReadOnly = True
        Me.AllowDelete.Width = 88
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.SaveUPdateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(138, 70)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.SaveToolStripMenuItem.Text = "Add"
        '
        'SaveUPdateToolStripMenuItem
        '
        Me.SaveUPdateToolStripMenuItem.Image = CType(resources.GetObject("SaveUPdateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveUPdateToolStripMenuItem.Name = "SaveUPdateToolStripMenuItem"
        Me.SaveUPdateToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.SaveUPdateToolStripMenuItem.Text = "Edit/Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'gpRolePrivilege
        '
        Me.gpRolePrivilege.Controls.Add(Me.chkIncludeAllMenuGroup)
        Me.gpRolePrivilege.Controls.Add(Me.chkIncludeAllMenu)
        Me.gpRolePrivilege.Controls.Add(Me.PictureBox2)
        Me.gpRolePrivilege.Controls.Add(Me.PictureBox1)
        Me.gpRolePrivilege.Controls.Add(Me.Label5)
        Me.gpRolePrivilege.Controls.Add(Me.Label6)
        Me.gpRolePrivilege.Controls.Add(Me.Label7)
        Me.gpRolePrivilege.Controls.Add(Me.Label8)
        Me.gpRolePrivilege.Controls.Add(Me.cbAllowDelete)
        Me.gpRolePrivilege.Controls.Add(Me.lblAllowDelete)
        Me.gpRolePrivilege.Controls.Add(Me.cbAllowUpdate)
        Me.gpRolePrivilege.Controls.Add(Me.lblAllowUpdate)
        Me.gpRolePrivilege.Controls.Add(Me.cbAllowAdd)
        Me.gpRolePrivilege.Controls.Add(Me.lblAllowAdd)
        Me.gpRolePrivilege.Controls.Add(Me.cbVisible)
        Me.gpRolePrivilege.Controls.Add(Me.lblVisible)
        Me.gpRolePrivilege.Controls.Add(Me.cbMenu)
        Me.gpRolePrivilege.Controls.Add(Me.cbMenuGroup)
        Me.gpRolePrivilege.Controls.Add(Me.cbModule)
        Me.gpRolePrivilege.Controls.Add(Me.cbRoleName)
        Me.gpRolePrivilege.Controls.Add(Me.Label4)
        Me.gpRolePrivilege.Controls.Add(Me.Label3)
        Me.gpRolePrivilege.Controls.Add(Me.Label2)
        Me.gpRolePrivilege.Controls.Add(Me.Label1)
        Me.gpRolePrivilege.Controls.Add(Me.lblMenu)
        Me.gpRolePrivilege.Controls.Add(Me.lblMenuGroup)
        Me.gpRolePrivilege.Controls.Add(Me.lblModule)
        Me.gpRolePrivilege.Controls.Add(Me.lblRoleName)
        Me.gpRolePrivilege.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpRolePrivilege.Location = New System.Drawing.Point(12, 13)
        Me.gpRolePrivilege.Name = "gpRolePrivilege"
        Me.gpRolePrivilege.Size = New System.Drawing.Size(775, 170)
        Me.gpRolePrivilege.TabIndex = 0
        Me.gpRolePrivilege.TabStop = False
        Me.gpRolePrivilege.Text = "Role Privilege"
        '
        'chkIncludeAllMenuGroup
        '
        Me.chkIncludeAllMenuGroup.AutoSize = True
        Me.chkIncludeAllMenuGroup.Checked = True
        Me.chkIncludeAllMenuGroup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeAllMenuGroup.Location = New System.Drawing.Point(426, 97)
        Me.chkIncludeAllMenuGroup.Name = "chkIncludeAllMenuGroup"
        Me.chkIncludeAllMenuGroup.Size = New System.Drawing.Size(86, 17)
        Me.chkIncludeAllMenuGroup.TabIndex = 3
        Me.chkIncludeAllMenuGroup.Text = "Include All"
        Me.chkIncludeAllMenuGroup.UseVisualStyleBackColor = True
        '
        'chkIncludeAllMenu
        '
        Me.chkIncludeAllMenu.AutoSize = True
        Me.chkIncludeAllMenu.Checked = True
        Me.chkIncludeAllMenu.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeAllMenu.Location = New System.Drawing.Point(426, 136)
        Me.chkIncludeAllMenu.Name = "chkIncludeAllMenu"
        Me.chkIncludeAllMenu.Size = New System.Drawing.Size(86, 17)
        Me.chkIncludeAllMenu.TabIndex = 5
        Me.chkIncludeAllMenu.Text = "Include All"
        Me.chkIncludeAllMenu.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Silver
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox2.Location = New System.Drawing.Point(534, 25)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(2, 122)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 26
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(437, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(2, 122)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 25
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(646, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(646, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(647, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(647, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = ":"
        '
        'cbAllowDelete
        '
        Me.cbAllowDelete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAllowDelete.FormattingEnabled = True
        Me.cbAllowDelete.Items.AddRange(New Object() {"Yes", "No"})
        Me.cbAllowDelete.Location = New System.Drawing.Point(662, 131)
        Me.cbAllowDelete.Name = "cbAllowDelete"
        Me.cbAllowDelete.Size = New System.Drawing.Size(83, 21)
        Me.cbAllowDelete.TabIndex = 9
        '
        'lblAllowDelete
        '
        Me.lblAllowDelete.AutoSize = True
        Me.lblAllowDelete.Location = New System.Drawing.Point(557, 134)
        Me.lblAllowDelete.Name = "lblAllowDelete"
        Me.lblAllowDelete.Size = New System.Drawing.Size(78, 13)
        Me.lblAllowDelete.TabIndex = 20
        Me.lblAllowDelete.Text = "Allow Delete"
        '
        'cbAllowUpdate
        '
        Me.cbAllowUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAllowUpdate.FormattingEnabled = True
        Me.cbAllowUpdate.Items.AddRange(New Object() {"Yes", "No"})
        Me.cbAllowUpdate.Location = New System.Drawing.Point(662, 94)
        Me.cbAllowUpdate.Name = "cbAllowUpdate"
        Me.cbAllowUpdate.Size = New System.Drawing.Size(83, 21)
        Me.cbAllowUpdate.TabIndex = 8
        '
        'lblAllowUpdate
        '
        Me.lblAllowUpdate.AutoSize = True
        Me.lblAllowUpdate.Location = New System.Drawing.Point(557, 98)
        Me.lblAllowUpdate.Name = "lblAllowUpdate"
        Me.lblAllowUpdate.Size = New System.Drawing.Size(81, 13)
        Me.lblAllowUpdate.TabIndex = 18
        Me.lblAllowUpdate.Text = "Allow Update"
        '
        'cbAllowAdd
        '
        Me.cbAllowAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAllowAdd.FormattingEnabled = True
        Me.cbAllowAdd.Items.AddRange(New Object() {"Yes", "No"})
        Me.cbAllowAdd.Location = New System.Drawing.Point(662, 57)
        Me.cbAllowAdd.Name = "cbAllowAdd"
        Me.cbAllowAdd.Size = New System.Drawing.Size(83, 21)
        Me.cbAllowAdd.TabIndex = 7
        '
        'lblAllowAdd
        '
        Me.lblAllowAdd.AutoSize = True
        Me.lblAllowAdd.Location = New System.Drawing.Point(557, 62)
        Me.lblAllowAdd.Name = "lblAllowAdd"
        Me.lblAllowAdd.Size = New System.Drawing.Size(63, 13)
        Me.lblAllowAdd.TabIndex = 16
        Me.lblAllowAdd.Text = "Allow Add"
        '
        'cbVisible
        '
        Me.cbVisible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVisible.FormattingEnabled = True
        Me.cbVisible.Items.AddRange(New Object() {"Yes", "No"})
        Me.cbVisible.Location = New System.Drawing.Point(662, 20)
        Me.cbVisible.Name = "cbVisible"
        Me.cbVisible.Size = New System.Drawing.Size(83, 21)
        Me.cbVisible.TabIndex = 6
        '
        'lblVisible
        '
        Me.lblVisible.AutoSize = True
        Me.lblVisible.Location = New System.Drawing.Point(557, 27)
        Me.lblVisible.Name = "lblVisible"
        Me.lblVisible.Size = New System.Drawing.Size(44, 13)
        Me.lblVisible.TabIndex = 14
        Me.lblVisible.Text = "Visible"
        '
        'cbMenu
        '
        Me.cbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMenu.FormattingEnabled = True
        Me.cbMenu.Location = New System.Drawing.Point(124, 132)
        Me.cbMenu.Name = "cbMenu"
        Me.cbMenu.Size = New System.Drawing.Size(287, 21)
        Me.cbMenu.TabIndex = 4
        '
        'cbMenuGroup
        '
        Me.cbMenuGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMenuGroup.FormattingEnabled = True
        Me.cbMenuGroup.Location = New System.Drawing.Point(124, 95)
        Me.cbMenuGroup.Name = "cbMenuGroup"
        Me.cbMenuGroup.Size = New System.Drawing.Size(287, 21)
        Me.cbMenuGroup.TabIndex = 2
        '
        'cbModule
        '
        Me.cbModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModule.FormattingEnabled = True
        Me.cbModule.Location = New System.Drawing.Point(124, 58)
        Me.cbModule.Name = "cbModule"
        Me.cbModule.Size = New System.Drawing.Size(287, 21)
        Me.cbModule.TabIndex = 1
        '
        'cbRoleName
        '
        Me.cbRoleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRoleName.FormattingEnabled = True
        Me.cbRoleName.Location = New System.Drawing.Point(124, 23)
        Me.cbRoleName.Name = "cbRoleName"
        Me.cbRoleName.Size = New System.Drawing.Size(287, 21)
        Me.cbRoleName.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(108, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(107, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(107, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(107, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ":"
        '
        'lblMenu
        '
        Me.lblMenu.AutoSize = True
        Me.lblMenu.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenu.ForeColor = System.Drawing.Color.Red
        Me.lblMenu.Location = New System.Drawing.Point(29, 134)
        Me.lblMenu.Name = "lblMenu"
        Me.lblMenu.Size = New System.Drawing.Size(37, 13)
        Me.lblMenu.TabIndex = 3
        Me.lblMenu.Text = "Menu"
        '
        'lblMenuGroup
        '
        Me.lblMenuGroup.AutoSize = True
        Me.lblMenuGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenuGroup.ForeColor = System.Drawing.Color.Red
        Me.lblMenuGroup.Location = New System.Drawing.Point(29, 98)
        Me.lblMenuGroup.Name = "lblMenuGroup"
        Me.lblMenuGroup.Size = New System.Drawing.Size(72, 13)
        Me.lblMenuGroup.TabIndex = 2
        Me.lblMenuGroup.Text = "MenuGroup"
        '
        'lblModule
        '
        Me.lblModule.AutoSize = True
        Me.lblModule.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModule.ForeColor = System.Drawing.Color.Red
        Me.lblModule.Location = New System.Drawing.Point(29, 62)
        Me.lblModule.Name = "lblModule"
        Me.lblModule.Size = New System.Drawing.Size(47, 13)
        Me.lblModule.TabIndex = 1
        Me.lblModule.Text = "Module"
        '
        'lblRoleName
        '
        Me.lblRoleName.AutoSize = True
        Me.lblRoleName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoleName.ForeColor = System.Drawing.Color.Red
        Me.lblRoleName.Location = New System.Drawing.Point(29, 26)
        Me.lblRoleName.Name = "lblRoleName"
        Me.lblRoleName.Size = New System.Drawing.Size(69, 13)
        Me.lblRoleName.TabIndex = 0
        Me.lblRoleName.Text = "Role Name"
        '
        'RolePrivilegeFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(887, 683)
        Me.Controls.Add(Me.PlRolePrivilege)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RolePrivilegeFrm"
        Me.Text = "Role Previlege"
        Me.PlRolePrivilege.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.gpView.ResumeLayout(False)
        CType(Me.dgvViewPrivilege, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.gpRolePrivilege.ResumeLayout(False)
        Me.gpRolePrivilege.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlRolePrivilege As System.Windows.Forms.Panel
    Friend WithEvents gpRolePrivilege As System.Windows.Forms.GroupBox
    Friend WithEvents lblMenu As System.Windows.Forms.Label
    Friend WithEvents lblMenuGroup As System.Windows.Forms.Label
    Friend WithEvents lblModule As System.Windows.Forms.Label
    Friend WithEvents lblRoleName As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbMenu As System.Windows.Forms.ComboBox
    Friend WithEvents cbMenuGroup As System.Windows.Forms.ComboBox
    Friend WithEvents cbModule As System.Windows.Forms.ComboBox
    Friend WithEvents cbRoleName As System.Windows.Forms.ComboBox
    Friend WithEvents cbAllowDelete As System.Windows.Forms.ComboBox
    Friend WithEvents lblAllowDelete As System.Windows.Forms.Label
    Friend WithEvents cbAllowUpdate As System.Windows.Forms.ComboBox
    Friend WithEvents lblAllowUpdate As System.Windows.Forms.Label
    Friend WithEvents cbAllowAdd As System.Windows.Forms.ComboBox
    Friend WithEvents lblAllowAdd As System.Windows.Forms.Label
    Friend WithEvents cbVisible As System.Windows.Forms.ComboBox
    Friend WithEvents lblVisible As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents gpView As System.Windows.Forms.GroupBox
    Friend WithEvents dgvViewPrivilege As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkIncludeAllMenuGroup As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncludeAllMenu As System.Windows.Forms.CheckBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveUPdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RolePrivilegeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuGroupID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoleName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModuleName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Visible As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AllowAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AllowEdit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AllowDelete As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

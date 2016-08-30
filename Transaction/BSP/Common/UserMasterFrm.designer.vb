<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserMasterFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserMasterFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PlUserMaster = New System.Windows.Forms.Panel
        Me.gbbuttons = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.gpUserDetails = New System.Windows.Forms.GroupBox
        Me.dgvUser = New System.Windows.Forms.DataGridView
        Me.UserName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Password = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DesgID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RoleID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DisplayName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Designation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Role = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsUser = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveUPdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.gpAddUserDetails = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cbRole = New System.Windows.Forms.ComboBox
        Me.cbDesignation = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblRole = New System.Windows.Forms.Label
        Me.lblDesignation = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtDisplayName = New System.Windows.Forms.TextBox
        Me.lblConfirmPassword = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblDisplayName = New System.Windows.Forms.Label
        Me.lblUserName = New System.Windows.Forms.Label
        Me.PlUserMaster.SuspendLayout()
        Me.gbbuttons.SuspendLayout()
        Me.gpUserDetails.SuspendLayout()
        CType(Me.dgvUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsUser.SuspendLayout()
        Me.gpAddUserDetails.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PlUserMaster
        '
        Me.PlUserMaster.BackColor = System.Drawing.Color.Transparent
        Me.PlUserMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PlUserMaster.Controls.Add(Me.gbbuttons)
        Me.PlUserMaster.Controls.Add(Me.gpUserDetails)
        Me.PlUserMaster.Controls.Add(Me.gpAddUserDetails)
        Me.PlUserMaster.ForeColor = System.Drawing.Color.Red
        Me.PlUserMaster.Location = New System.Drawing.Point(0, 0)
        Me.PlUserMaster.Name = "PlUserMaster"
        Me.PlUserMaster.Size = New System.Drawing.Size(911, 476)
        Me.PlUserMaster.TabIndex = 0
        '
        'gbbuttons
        '
        Me.gbbuttons.Controls.Add(Me.btnDelete)
        Me.gbbuttons.Controls.Add(Me.btnReset)
        Me.gbbuttons.Controls.Add(Me.btnSave)
        Me.gbbuttons.Location = New System.Drawing.Point(12, 173)
        Me.gbbuttons.Name = "gbbuttons"
        Me.gbbuttons.Size = New System.Drawing.Size(842, 62)
        Me.gbbuttons.TabIndex = 1
        Me.gbbuttons.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Image)
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.Black
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(618, 22)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 25)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.Black
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(724, 22)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 25)
        Me.btnReset.TabIndex = 7
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(522, 22)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 25)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gpUserDetails
        '
        Me.gpUserDetails.Controls.Add(Me.dgvUser)
        Me.gpUserDetails.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpUserDetails.ForeColor = System.Drawing.Color.Black
        Me.gpUserDetails.Location = New System.Drawing.Point(12, 242)
        Me.gpUserDetails.Name = "gpUserDetails"
        Me.gpUserDetails.Size = New System.Drawing.Size(842, 202)
        Me.gpUserDetails.TabIndex = 10
        Me.gpUserDetails.TabStop = False
        Me.gpUserDetails.Text = "User Details"
        '
        'dgvUser
        '
        Me.dgvUser.AllowUserToAddRows = False
        Me.dgvUser.AllowUserToDeleteRows = False
        Me.dgvUser.AllowUserToOrderColumns = True
        Me.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgvUser.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUser.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvUser.ColumnHeadersHeight = 30
        Me.dgvUser.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserName, Me.Password, Me.DesgID, Me.RoleID, Me.DisplayName, Me.UserID, Me.Designation, Me.Role})
        Me.dgvUser.ContextMenuStrip = Me.cmsUser
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUser.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUser.EnableHeadersVisualStyles = False
        Me.dgvUser.GridColor = System.Drawing.Color.Gray
        Me.dgvUser.Location = New System.Drawing.Point(3, 17)
        Me.dgvUser.MultiSelect = False
        Me.dgvUser.Name = "dgvUser"
        Me.dgvUser.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUser.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvUser.RowHeadersVisible = False
        Me.dgvUser.RowHeadersWidth = 50
        Me.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUser.ShowCellErrors = False
        Me.dgvUser.Size = New System.Drawing.Size(836, 182)
        Me.dgvUser.TabIndex = 99
        Me.dgvUser.TabStop = False
        '
        'UserName
        '
        Me.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.UserName.DataPropertyName = "UserName"
        Me.UserName.FillWeight = 200.0!
        Me.UserName.HeaderText = "User Name"
        Me.UserName.Name = "UserName"
        Me.UserName.ReadOnly = True
        Me.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Password
        '
        Me.Password.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Password.DataPropertyName = "Pwd"
        Me.Password.HeaderText = "Password"
        Me.Password.Name = "Password"
        Me.Password.ReadOnly = True
        Me.Password.Visible = False
        Me.Password.Width = 85
        '
        'DesgID
        '
        Me.DesgID.DataPropertyName = "DesgID"
        Me.DesgID.HeaderText = "DesgID"
        Me.DesgID.Name = "DesgID"
        Me.DesgID.ReadOnly = True
        Me.DesgID.Visible = False
        Me.DesgID.Width = 75
        '
        'RoleID
        '
        Me.RoleID.DataPropertyName = "RoleID"
        Me.RoleID.HeaderText = "RoleID"
        Me.RoleID.Name = "RoleID"
        Me.RoleID.ReadOnly = True
        Me.RoleID.Visible = False
        Me.RoleID.Width = 71
        '
        'DisplayName
        '
        Me.DisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DisplayName.DataPropertyName = "DispName"
        Me.DisplayName.FillWeight = 150.0!
        Me.DisplayName.HeaderText = "Display Name"
        Me.DisplayName.Name = "DisplayName"
        Me.DisplayName.ReadOnly = True
        Me.DisplayName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "UserID"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        Me.UserID.Visible = False
        Me.UserID.Width = 72
        '
        'Designation
        '
        Me.Designation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Designation.DataPropertyName = "Desg"
        Me.Designation.FillWeight = 150.0!
        Me.Designation.HeaderText = "Designation"
        Me.Designation.Name = "Designation"
        Me.Designation.ReadOnly = True
        Me.Designation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Role
        '
        Me.Role.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Role.DataPropertyName = "RoleName"
        Me.Role.FillWeight = 150.0!
        Me.Role.HeaderText = "Role"
        Me.Role.Name = "Role"
        Me.Role.ReadOnly = True
        Me.Role.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cmsUser
        '
        Me.cmsUser.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.SaveUPdateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsUser.Name = "ContextMenuStrip1"
        Me.cmsUser.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.cmsUser.Size = New System.Drawing.Size(143, 70)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.SaveToolStripMenuItem.Text = "Add"
        '
        'SaveUPdateToolStripMenuItem
        '
        Me.SaveUPdateToolStripMenuItem.Image = CType(resources.GetObject("SaveUPdateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveUPdateToolStripMenuItem.Name = "SaveUPdateToolStripMenuItem"
        Me.SaveUPdateToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.SaveUPdateToolStripMenuItem.Text = "Edit/Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'gpAddUserDetails
        '
        Me.gpAddUserDetails.Controls.Add(Me.PictureBox1)
        Me.gpAddUserDetails.Controls.Add(Me.cbRole)
        Me.gpAddUserDetails.Controls.Add(Me.cbDesignation)
        Me.gpAddUserDetails.Controls.Add(Me.Label5)
        Me.gpAddUserDetails.Controls.Add(Me.Label6)
        Me.gpAddUserDetails.Controls.Add(Me.lblRole)
        Me.gpAddUserDetails.Controls.Add(Me.lblDesignation)
        Me.gpAddUserDetails.Controls.Add(Me.Label4)
        Me.gpAddUserDetails.Controls.Add(Me.Label3)
        Me.gpAddUserDetails.Controls.Add(Me.Label2)
        Me.gpAddUserDetails.Controls.Add(Me.Label1)
        Me.gpAddUserDetails.Controls.Add(Me.txtUserName)
        Me.gpAddUserDetails.Controls.Add(Me.txtConfirmPassword)
        Me.gpAddUserDetails.Controls.Add(Me.txtPassword)
        Me.gpAddUserDetails.Controls.Add(Me.txtDisplayName)
        Me.gpAddUserDetails.Controls.Add(Me.lblConfirmPassword)
        Me.gpAddUserDetails.Controls.Add(Me.lblPassword)
        Me.gpAddUserDetails.Controls.Add(Me.lblDisplayName)
        Me.gpAddUserDetails.Controls.Add(Me.lblUserName)
        Me.gpAddUserDetails.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpAddUserDetails.Location = New System.Drawing.Point(12, 12)
        Me.gpAddUserDetails.Name = "gpAddUserDetails"
        Me.gpAddUserDetails.Size = New System.Drawing.Size(845, 155)
        Me.gpAddUserDetails.TabIndex = 0
        Me.gpAddUserDetails.TabStop = False
        Me.gpAddUserDetails.Text = "Add User Details"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(423, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1, 122)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'cbRole
        '
        Me.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRole.FormattingEnabled = True
        Me.cbRole.Items.AddRange(New Object() {"<--Select Role-->"})
        Me.cbRole.Location = New System.Drawing.Point(597, 68)
        Me.cbRole.Name = "cbRole"
        Me.cbRole.Size = New System.Drawing.Size(222, 21)
        Me.cbRole.TabIndex = 3
        '
        'cbDesignation
        '
        Me.cbDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDesignation.FormattingEnabled = True
        Me.cbDesignation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cbDesignation.Location = New System.Drawing.Point(139, 70)
        Me.cbDesignation.Name = "cbDesignation"
        Me.cbDesignation.Size = New System.Drawing.Size(247, 21)
        Me.cbDesignation.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(580, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(122, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = ":"
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRole.ForeColor = System.Drawing.Color.Red
        Me.lblRole.Location = New System.Drawing.Point(452, 71)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(32, 13)
        Me.lblRole.TabIndex = 13
        Me.lblRole.Text = "Role"
        '
        'lblDesignation
        '
        Me.lblDesignation.AutoSize = True
        Me.lblDesignation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignation.ForeColor = System.Drawing.Color.Red
        Me.lblDesignation.Location = New System.Drawing.Point(27, 73)
        Me.lblDesignation.Name = "lblDesignation"
        Me.lblDesignation.Size = New System.Drawing.Size(74, 13)
        Me.lblDesignation.TabIndex = 12
        Me.lblDesignation.Text = "Designation"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(580, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(122, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(581, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(122, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ":"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(139, 28)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(247, 21)
        Me.txtUserName.TabIndex = 0
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(596, 111)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(223, 21)
        Me.txtConfirmPassword.TabIndex = 5
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(139, 108)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(247, 21)
        Me.txtPassword.TabIndex = 4
        '
        'txtDisplayName
        '
        Me.txtDisplayName.Location = New System.Drawing.Point(597, 26)
        Me.txtDisplayName.Name = "txtDisplayName"
        Me.txtDisplayName.Size = New System.Drawing.Size(222, 21)
        Me.txtDisplayName.TabIndex = 1
        '
        'lblConfirmPassword
        '
        Me.lblConfirmPassword.AutoSize = True
        Me.lblConfirmPassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmPassword.ForeColor = System.Drawing.Color.Red
        Me.lblConfirmPassword.Location = New System.Drawing.Point(452, 114)
        Me.lblConfirmPassword.Name = "lblConfirmPassword"
        Me.lblConfirmPassword.Size = New System.Drawing.Size(111, 13)
        Me.lblConfirmPassword.TabIndex = 3
        Me.lblConfirmPassword.Text = "Confirm Password"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.Red
        Me.lblPassword.Location = New System.Drawing.Point(27, 110)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(61, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password"
        '
        'lblDisplayName
        '
        Me.lblDisplayName.AutoSize = True
        Me.lblDisplayName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayName.ForeColor = System.Drawing.Color.Red
        Me.lblDisplayName.Location = New System.Drawing.Point(452, 30)
        Me.lblDisplayName.Name = "lblDisplayName"
        Me.lblDisplayName.Size = New System.Drawing.Size(86, 13)
        Me.lblDisplayName.TabIndex = 1
        Me.lblDisplayName.Text = "Display Name"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Red
        Me.lblUserName.Location = New System.Drawing.Point(27, 34)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(70, 13)
        Me.lblUserName.TabIndex = 0
        Me.lblUserName.Text = "User Name"
        '
        'UserMasterFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(923, 501)
        Me.Controls.Add(Me.PlUserMaster)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UserMasterFrm"
        Me.Text = "User Master"
        Me.PlUserMaster.ResumeLayout(False)
        Me.gbbuttons.ResumeLayout(False)
        Me.gpUserDetails.ResumeLayout(False)
        CType(Me.dgvUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsUser.ResumeLayout(False)
        Me.gpAddUserDetails.ResumeLayout(False)
        Me.gpAddUserDetails.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlUserMaster As System.Windows.Forms.Panel
    Friend WithEvents gpUserDetails As System.Windows.Forms.GroupBox
    Friend WithEvents gpAddUserDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmPassword As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblDisplayName As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbRole As System.Windows.Forms.ComboBox
    Friend WithEvents cbDesignation As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents lblDesignation As System.Windows.Forms.Label
    Friend WithEvents dgvUser As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents gbbuttons As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents UserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Password As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesgID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DisplayName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Designation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Role As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsUser As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveUPdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

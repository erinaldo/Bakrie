<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RoleMasterFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RoleMasterFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PlRoleMaster = New System.Windows.Forms.Panel
        Me.gpButtons = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.gpViewUserRole = New System.Windows.Forms.GroupBox
        Me.dgvViewUserRoleName = New System.Windows.Forms.DataGridView
        Me.RoleNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RoleName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DesgIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuBNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DesgDescDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrVisibleDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PrAddDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PrUpdateDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PrDeleteDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CreatedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreatedOnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModifiedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModifiedOnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConcurrencyIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsRole = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RoleMasterPPTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.gpAddUserRole = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUserRoleName = New System.Windows.Forms.TextBox
        Me.lblUserRoleName = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PlRoleMaster.SuspendLayout()
        Me.gpButtons.SuspendLayout()
        Me.gpViewUserRole.SuspendLayout()
        CType(Me.dgvViewUserRoleName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsRole.SuspendLayout()
        CType(Me.RoleMasterPPTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpAddUserRole.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PlRoleMaster
        '
        Me.PlRoleMaster.BackColor = System.Drawing.Color.Transparent
        Me.PlRoleMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PlRoleMaster.Controls.Add(Me.gpButtons)
        Me.PlRoleMaster.Controls.Add(Me.gpViewUserRole)
        Me.PlRoleMaster.Controls.Add(Me.gpAddUserRole)
        Me.PlRoleMaster.Location = New System.Drawing.Point(0, 0)
        Me.PlRoleMaster.Name = "PlRoleMaster"
        Me.PlRoleMaster.Size = New System.Drawing.Size(689, 401)
        Me.PlRoleMaster.TabIndex = 0
        '
        'gpButtons
        '
        Me.gpButtons.Controls.Add(Me.btnDelete)
        Me.gpButtons.Controls.Add(Me.btnReset)
        Me.gpButtons.Controls.Add(Me.btnSave)
        Me.gpButtons.Location = New System.Drawing.Point(11, 88)
        Me.gpButtons.Name = "gpButtons"
        Me.gpButtons.Size = New System.Drawing.Size(419, 51)
        Me.gpButtons.TabIndex = 1
        Me.gpButtons.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Image)
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(205, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 25)
        Me.btnDelete.TabIndex = 3
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
        Me.btnReset.Location = New System.Drawing.Point(310, 16)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(93, 25)
        Me.btnReset.TabIndex = 2
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
        Me.btnSave.Location = New System.Drawing.Point(112, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 25)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gpViewUserRole
        '
        Me.gpViewUserRole.Controls.Add(Me.dgvViewUserRoleName)
        Me.gpViewUserRole.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpViewUserRole.Location = New System.Drawing.Point(11, 143)
        Me.gpViewUserRole.Name = "gpViewUserRole"
        Me.gpViewUserRole.Size = New System.Drawing.Size(419, 171)
        Me.gpViewUserRole.TabIndex = 100
        Me.gpViewUserRole.TabStop = False
        Me.gpViewUserRole.Text = "View User Role"
        '
        'dgvViewUserRoleName
        '
        Me.dgvViewUserRoleName.AllowUserToAddRows = False
        Me.dgvViewUserRoleName.AllowUserToDeleteRows = False
        Me.dgvViewUserRoleName.AllowUserToOrderColumns = True
        Me.dgvViewUserRoleName.AutoGenerateColumns = False
        Me.dgvViewUserRoleName.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.dgvViewUserRoleName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvViewUserRoleName.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvViewUserRoleName.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvViewUserRoleName.ColumnHeadersHeight = 30
        Me.dgvViewUserRoleName.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RoleNo, Me.RoleName, Me.MenuIDDataGridViewTextBoxColumn, Me.DesgIDDataGridViewTextBoxColumn, Me.MenuNameDataGridViewTextBoxColumn, Me.MenuBNameDataGridViewTextBoxColumn, Me.DesgDescDataGridViewTextBoxColumn, Me.PrVisibleDataGridViewCheckBoxColumn, Me.PrAddDataGridViewCheckBoxColumn, Me.PrUpdateDataGridViewCheckBoxColumn, Me.PrDeleteDataGridViewCheckBoxColumn, Me.CreatedByDataGridViewTextBoxColumn, Me.CreatedOnDataGridViewTextBoxColumn, Me.ModifiedByDataGridViewTextBoxColumn, Me.ModifiedOnDataGridViewTextBoxColumn, Me.EstateCodeDataGridViewTextBoxColumn, Me.ConcurrencyIdDataGridViewTextBoxColumn})
        Me.dgvViewUserRoleName.ContextMenuStrip = Me.cmsRole
        Me.dgvViewUserRoleName.DataSource = Me.RoleMasterPPTBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvViewUserRoleName.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvViewUserRoleName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvViewUserRoleName.EnableHeadersVisualStyles = False
        Me.dgvViewUserRoleName.GridColor = System.Drawing.Color.Gray
        Me.dgvViewUserRoleName.Location = New System.Drawing.Point(3, 17)
        Me.dgvViewUserRoleName.MultiSelect = False
        Me.dgvViewUserRoleName.Name = "dgvViewUserRoleName"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvViewUserRoleName.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvViewUserRoleName.RowHeadersVisible = False
        Me.dgvViewUserRoleName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvViewUserRoleName.Size = New System.Drawing.Size(413, 151)
        Me.dgvViewUserRoleName.TabIndex = 150
        Me.dgvViewUserRoleName.TabStop = False
        '
        'RoleNo
        '
        Me.RoleNo.DataPropertyName = "RoleID"
        Me.RoleNo.HeaderText = "RoleID"
        Me.RoleNo.Name = "RoleNo"
        Me.RoleNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RoleNo.Visible = False
        '
        'RoleName
        '
        Me.RoleName.DataPropertyName = "RoleName"
        Me.RoleName.HeaderText = "Role Name"
        Me.RoleName.Name = "RoleName"
        '
        'MenuIDDataGridViewTextBoxColumn
        '
        Me.MenuIDDataGridViewTextBoxColumn.DataPropertyName = "MenuID"
        Me.MenuIDDataGridViewTextBoxColumn.HeaderText = "MenuID"
        Me.MenuIDDataGridViewTextBoxColumn.Name = "MenuIDDataGridViewTextBoxColumn"
        Me.MenuIDDataGridViewTextBoxColumn.Visible = False
        '
        'DesgIDDataGridViewTextBoxColumn
        '
        Me.DesgIDDataGridViewTextBoxColumn.DataPropertyName = "DesgID"
        Me.DesgIDDataGridViewTextBoxColumn.HeaderText = "DesgID"
        Me.DesgIDDataGridViewTextBoxColumn.Name = "DesgIDDataGridViewTextBoxColumn"
        Me.DesgIDDataGridViewTextBoxColumn.Visible = False
        '
        'MenuNameDataGridViewTextBoxColumn
        '
        Me.MenuNameDataGridViewTextBoxColumn.DataPropertyName = "MenuName"
        Me.MenuNameDataGridViewTextBoxColumn.HeaderText = "MenuName"
        Me.MenuNameDataGridViewTextBoxColumn.Name = "MenuNameDataGridViewTextBoxColumn"
        Me.MenuNameDataGridViewTextBoxColumn.Visible = False
        '
        'MenuBNameDataGridViewTextBoxColumn
        '
        Me.MenuBNameDataGridViewTextBoxColumn.DataPropertyName = "MenuBName"
        Me.MenuBNameDataGridViewTextBoxColumn.HeaderText = "MenuBName"
        Me.MenuBNameDataGridViewTextBoxColumn.Name = "MenuBNameDataGridViewTextBoxColumn"
        Me.MenuBNameDataGridViewTextBoxColumn.Visible = False
        '
        'DesgDescDataGridViewTextBoxColumn
        '
        Me.DesgDescDataGridViewTextBoxColumn.DataPropertyName = "DesgDesc"
        Me.DesgDescDataGridViewTextBoxColumn.HeaderText = "DesgDesc"
        Me.DesgDescDataGridViewTextBoxColumn.Name = "DesgDescDataGridViewTextBoxColumn"
        Me.DesgDescDataGridViewTextBoxColumn.Visible = False
        '
        'PrVisibleDataGridViewCheckBoxColumn
        '
        Me.PrVisibleDataGridViewCheckBoxColumn.DataPropertyName = "PrVisible"
        Me.PrVisibleDataGridViewCheckBoxColumn.HeaderText = "PrVisible"
        Me.PrVisibleDataGridViewCheckBoxColumn.Name = "PrVisibleDataGridViewCheckBoxColumn"
        Me.PrVisibleDataGridViewCheckBoxColumn.Visible = False
        '
        'PrAddDataGridViewCheckBoxColumn
        '
        Me.PrAddDataGridViewCheckBoxColumn.DataPropertyName = "PrAdd"
        Me.PrAddDataGridViewCheckBoxColumn.HeaderText = "PrAdd"
        Me.PrAddDataGridViewCheckBoxColumn.Name = "PrAddDataGridViewCheckBoxColumn"
        Me.PrAddDataGridViewCheckBoxColumn.Visible = False
        '
        'PrUpdateDataGridViewCheckBoxColumn
        '
        Me.PrUpdateDataGridViewCheckBoxColumn.DataPropertyName = "PrUpdate"
        Me.PrUpdateDataGridViewCheckBoxColumn.HeaderText = "PrUpdate"
        Me.PrUpdateDataGridViewCheckBoxColumn.Name = "PrUpdateDataGridViewCheckBoxColumn"
        Me.PrUpdateDataGridViewCheckBoxColumn.Visible = False
        '
        'PrDeleteDataGridViewCheckBoxColumn
        '
        Me.PrDeleteDataGridViewCheckBoxColumn.DataPropertyName = "PrDelete"
        Me.PrDeleteDataGridViewCheckBoxColumn.HeaderText = "PrDelete"
        Me.PrDeleteDataGridViewCheckBoxColumn.Name = "PrDeleteDataGridViewCheckBoxColumn"
        Me.PrDeleteDataGridViewCheckBoxColumn.Visible = False
        '
        'CreatedByDataGridViewTextBoxColumn
        '
        Me.CreatedByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy"
        Me.CreatedByDataGridViewTextBoxColumn.HeaderText = "CreatedBy"
        Me.CreatedByDataGridViewTextBoxColumn.Name = "CreatedByDataGridViewTextBoxColumn"
        Me.CreatedByDataGridViewTextBoxColumn.Visible = False
        '
        'CreatedOnDataGridViewTextBoxColumn
        '
        Me.CreatedOnDataGridViewTextBoxColumn.DataPropertyName = "CreatedOn"
        Me.CreatedOnDataGridViewTextBoxColumn.HeaderText = "CreatedOn"
        Me.CreatedOnDataGridViewTextBoxColumn.Name = "CreatedOnDataGridViewTextBoxColumn"
        Me.CreatedOnDataGridViewTextBoxColumn.Visible = False
        '
        'ModifiedByDataGridViewTextBoxColumn
        '
        Me.ModifiedByDataGridViewTextBoxColumn.DataPropertyName = "ModifiedBy"
        Me.ModifiedByDataGridViewTextBoxColumn.HeaderText = "ModifiedBy"
        Me.ModifiedByDataGridViewTextBoxColumn.Name = "ModifiedByDataGridViewTextBoxColumn"
        Me.ModifiedByDataGridViewTextBoxColumn.Visible = False
        '
        'ModifiedOnDataGridViewTextBoxColumn
        '
        Me.ModifiedOnDataGridViewTextBoxColumn.DataPropertyName = "ModifiedOn"
        Me.ModifiedOnDataGridViewTextBoxColumn.HeaderText = "ModifiedOn"
        Me.ModifiedOnDataGridViewTextBoxColumn.Name = "ModifiedOnDataGridViewTextBoxColumn"
        Me.ModifiedOnDataGridViewTextBoxColumn.Visible = False
        '
        'EstateCodeDataGridViewTextBoxColumn
        '
        Me.EstateCodeDataGridViewTextBoxColumn.DataPropertyName = "EstateCode"
        Me.EstateCodeDataGridViewTextBoxColumn.HeaderText = "EstateCode"
        Me.EstateCodeDataGridViewTextBoxColumn.Name = "EstateCodeDataGridViewTextBoxColumn"
        Me.EstateCodeDataGridViewTextBoxColumn.Visible = False
        '
        'ConcurrencyIdDataGridViewTextBoxColumn
        '
        Me.ConcurrencyIdDataGridViewTextBoxColumn.DataPropertyName = "ConcurrencyId"
        Me.ConcurrencyIdDataGridViewTextBoxColumn.HeaderText = "ConcurrencyId"
        Me.ConcurrencyIdDataGridViewTextBoxColumn.Name = "ConcurrencyIdDataGridViewTextBoxColumn"
        Me.ConcurrencyIdDataGridViewTextBoxColumn.Visible = False
        '
        'cmsRole
        '
        Me.cmsRole.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditUpdateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsRole.Name = "ContextMenuStrip1"
        Me.cmsRole.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.cmsRole.Size = New System.Drawing.Size(143, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditUpdateToolStripMenuItem
        '
        Me.EditUpdateToolStripMenuItem.Image = CType(resources.GetObject("EditUpdateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditUpdateToolStripMenuItem.Name = "EditUpdateToolStripMenuItem"
        Me.EditUpdateToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.EditUpdateToolStripMenuItem.Text = "Edit/Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'RoleMasterPPTBindingSource
        '
        Me.RoleMasterPPTBindingSource.DataSource = GetType(Common_PPT.RoleMasterPPT)
        '
        'gpAddUserRole
        '
        Me.gpAddUserRole.Controls.Add(Me.Label1)
        Me.gpAddUserRole.Controls.Add(Me.txtUserRoleName)
        Me.gpAddUserRole.Controls.Add(Me.lblUserRoleName)
        Me.gpAddUserRole.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpAddUserRole.Location = New System.Drawing.Point(12, 12)
        Me.gpAddUserRole.Name = "gpAddUserRole"
        Me.gpAddUserRole.Size = New System.Drawing.Size(419, 76)
        Me.gpAddUserRole.TabIndex = 0
        Me.gpAddUserRole.TabStop = False
        Me.gpAddUserRole.Text = "Add User Role"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(125, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ":"
        '
        'txtUserRoleName
        '
        Me.txtUserRoleName.Location = New System.Drawing.Point(141, 30)
        Me.txtUserRoleName.Name = "txtUserRoleName"
        Me.txtUserRoleName.Size = New System.Drawing.Size(259, 21)
        Me.txtUserRoleName.TabIndex = 0
        '
        'lblUserRoleName
        '
        Me.lblUserRoleName.AutoSize = True
        Me.lblUserRoleName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserRoleName.ForeColor = System.Drawing.Color.Red
        Me.lblUserRoleName.Location = New System.Drawing.Point(15, 33)
        Me.lblUserRoleName.Name = "lblUserRoleName"
        Me.lblUserRoleName.Size = New System.Drawing.Size(99, 13)
        Me.lblUserRoleName.TabIndex = 0
        Me.lblUserRoleName.Text = "User Role Name"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'RoleMasterFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(691, 401)
        Me.Controls.Add(Me.PlRoleMaster)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RoleMasterFrm"
        Me.Text = "Role Master"
        Me.PlRoleMaster.ResumeLayout(False)
        Me.gpButtons.ResumeLayout(False)
        Me.gpViewUserRole.ResumeLayout(False)
        CType(Me.dgvViewUserRoleName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsRole.ResumeLayout(False)
        CType(Me.RoleMasterPPTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpAddUserRole.ResumeLayout(False)
        Me.gpAddUserRole.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlRoleMaster As System.Windows.Forms.Panel
    Friend WithEvents gpViewUserRole As System.Windows.Forms.GroupBox
    Friend WithEvents gpAddUserRole As System.Windows.Forms.GroupBox
    Friend WithEvents txtUserRoleName As System.Windows.Forms.TextBox
    Friend WithEvents lblUserRoleName As System.Windows.Forms.Label
    Friend WithEvents dgvViewUserRoleName As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents RoleMasterPPTBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RoleNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoleName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesgIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuBNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesgDescDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrVisibleDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PrAddDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PrUpdateDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PrDeleteDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CreatedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedOnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifiedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifiedOnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConcurrencyIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsRole As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

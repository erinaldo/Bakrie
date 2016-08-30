<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignationFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DesignationFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PlDesignationMaster = New System.Windows.Forms.Panel
        Me.gpButtons = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.gpViewDesignation = New System.Windows.Forms.GroupBox
        Me.dgvViewDesignation = New System.Windows.Forms.DataGridView
        Me.MSUserIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MSUserNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MSDispNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MSPwdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MSDesgIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MSRoleIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MSPwdByteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PassDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn
        Me.TmpPassDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DispNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DesgNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Designation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DLevels = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConcurrencyIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreatedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreatedOnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModifiedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModifiedOnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsDesig = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveUPdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UserMasterPPTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.gpDesignation = New System.Windows.Forms.GroupBox
        Me.lblDesignationLevel = New System.Windows.Forms.Label
        Me.cbDesignationLevel = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDesignation = New System.Windows.Forms.TextBox
        Me.lblDesignation = New System.Windows.Forms.Label
        Me.PlDesignationMaster.SuspendLayout()
        Me.gpButtons.SuspendLayout()
        Me.gpViewDesignation.SuspendLayout()
        CType(Me.dgvViewDesignation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDesig.SuspendLayout()
        CType(Me.UserMasterPPTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDesignation.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlDesignationMaster
        '
        Me.PlDesignationMaster.BackColor = System.Drawing.Color.Transparent
        Me.PlDesignationMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PlDesignationMaster.Controls.Add(Me.gpButtons)
        Me.PlDesignationMaster.Controls.Add(Me.gpViewDesignation)
        Me.PlDesignationMaster.Controls.Add(Me.gpDesignation)
        Me.PlDesignationMaster.Location = New System.Drawing.Point(0, 0)
        Me.PlDesignationMaster.Name = "PlDesignationMaster"
        Me.PlDesignationMaster.Size = New System.Drawing.Size(772, 431)
        Me.PlDesignationMaster.TabIndex = 0
        '
        'gpButtons
        '
        Me.gpButtons.Controls.Add(Me.btnDelete)
        Me.gpButtons.Controls.Add(Me.btnReset)
        Me.gpButtons.Controls.Add(Me.btnSave)
        Me.gpButtons.Location = New System.Drawing.Point(12, 124)
        Me.gpButtons.Name = "gpButtons"
        Me.gpButtons.Size = New System.Drawing.Size(466, 53)
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
        Me.btnDelete.Location = New System.Drawing.Point(255, 17)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(95, 25)
        Me.btnDelete.TabIndex = 4
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
        Me.btnReset.Location = New System.Drawing.Point(356, 17)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 25)
        Me.btnReset.TabIndex = 3
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
        Me.btnSave.Location = New System.Drawing.Point(154, 17)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 25)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gpViewDesignation
        '
        Me.gpViewDesignation.Controls.Add(Me.dgvViewDesignation)
        Me.gpViewDesignation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpViewDesignation.Location = New System.Drawing.Point(12, 183)
        Me.gpViewDesignation.Name = "gpViewDesignation"
        Me.gpViewDesignation.Size = New System.Drawing.Size(466, 181)
        Me.gpViewDesignation.TabIndex = 10
        Me.gpViewDesignation.TabStop = False
        Me.gpViewDesignation.Text = "View Designation"
        '
        'dgvViewDesignation
        '
        Me.dgvViewDesignation.AllowUserToAddRows = False
        Me.dgvViewDesignation.AllowUserToDeleteRows = False
        Me.dgvViewDesignation.AllowUserToOrderColumns = True
        Me.dgvViewDesignation.AutoGenerateColumns = False
        Me.dgvViewDesignation.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.dgvViewDesignation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvViewDesignation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvViewDesignation.ColumnHeadersHeight = 30
        Me.dgvViewDesignation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MSUserIDDataGridViewTextBoxColumn, Me.MSUserNameDataGridViewTextBoxColumn, Me.MSDispNameDataGridViewTextBoxColumn, Me.MSPwdDataGridViewTextBoxColumn, Me.MSDesgIDDataGridViewTextBoxColumn, Me.MSRoleIDDataGridViewTextBoxColumn, Me.MSPwdByteDataGridViewTextBoxColumn, Me.UserIDDataGridViewTextBoxColumn, Me.UserNameDataGridViewTextBoxColumn, Me.PassDataGridViewImageColumn, Me.TmpPassDataGridViewTextBoxColumn, Me.DispNameDataGridViewTextBoxColumn, Me.DesgNo, Me.Designation, Me.DLevels, Me.ConcurrencyIdDataGridViewTextBoxColumn, Me.EstateCodeDataGridViewTextBoxColumn, Me.CreatedByDataGridViewTextBoxColumn, Me.CreatedOnDataGridViewTextBoxColumn, Me.ModifiedByDataGridViewTextBoxColumn, Me.ModifiedOnDataGridViewTextBoxColumn})
        Me.dgvViewDesignation.ContextMenuStrip = Me.cmsDesig
        Me.dgvViewDesignation.DataSource = Me.UserMasterPPTBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvViewDesignation.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvViewDesignation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvViewDesignation.EnableHeadersVisualStyles = False
        Me.dgvViewDesignation.GridColor = System.Drawing.Color.Gray
        Me.dgvViewDesignation.Location = New System.Drawing.Point(3, 17)
        Me.dgvViewDesignation.MultiSelect = False
        Me.dgvViewDesignation.Name = "dgvViewDesignation"
        Me.dgvViewDesignation.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvViewDesignation.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvViewDesignation.RowHeadersVisible = False
        Me.dgvViewDesignation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvViewDesignation.Size = New System.Drawing.Size(460, 161)
        Me.dgvViewDesignation.TabIndex = 150
        Me.dgvViewDesignation.TabStop = False
        '
        'MSUserIDDataGridViewTextBoxColumn
        '
        Me.MSUserIDDataGridViewTextBoxColumn.DataPropertyName = "MSUserID"
        Me.MSUserIDDataGridViewTextBoxColumn.HeaderText = "MSUserID"
        Me.MSUserIDDataGridViewTextBoxColumn.Name = "MSUserIDDataGridViewTextBoxColumn"
        Me.MSUserIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.MSUserIDDataGridViewTextBoxColumn.Visible = False
        '
        'MSUserNameDataGridViewTextBoxColumn
        '
        Me.MSUserNameDataGridViewTextBoxColumn.DataPropertyName = "MSUserName"
        Me.MSUserNameDataGridViewTextBoxColumn.HeaderText = "MSUserName"
        Me.MSUserNameDataGridViewTextBoxColumn.Name = "MSUserNameDataGridViewTextBoxColumn"
        Me.MSUserNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.MSUserNameDataGridViewTextBoxColumn.Visible = False
        '
        'MSDispNameDataGridViewTextBoxColumn
        '
        Me.MSDispNameDataGridViewTextBoxColumn.DataPropertyName = "MSDispName"
        Me.MSDispNameDataGridViewTextBoxColumn.HeaderText = "MSDispName"
        Me.MSDispNameDataGridViewTextBoxColumn.Name = "MSDispNameDataGridViewTextBoxColumn"
        Me.MSDispNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.MSDispNameDataGridViewTextBoxColumn.Visible = False
        '
        'MSPwdDataGridViewTextBoxColumn
        '
        Me.MSPwdDataGridViewTextBoxColumn.DataPropertyName = "MSPwd"
        Me.MSPwdDataGridViewTextBoxColumn.HeaderText = "MSPwd"
        Me.MSPwdDataGridViewTextBoxColumn.Name = "MSPwdDataGridViewTextBoxColumn"
        Me.MSPwdDataGridViewTextBoxColumn.ReadOnly = True
        Me.MSPwdDataGridViewTextBoxColumn.Visible = False
        '
        'MSDesgIDDataGridViewTextBoxColumn
        '
        Me.MSDesgIDDataGridViewTextBoxColumn.DataPropertyName = "MSDesgID"
        Me.MSDesgIDDataGridViewTextBoxColumn.HeaderText = "MSDesgID"
        Me.MSDesgIDDataGridViewTextBoxColumn.Name = "MSDesgIDDataGridViewTextBoxColumn"
        Me.MSDesgIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.MSDesgIDDataGridViewTextBoxColumn.Visible = False
        '
        'MSRoleIDDataGridViewTextBoxColumn
        '
        Me.MSRoleIDDataGridViewTextBoxColumn.DataPropertyName = "MSRoleID"
        Me.MSRoleIDDataGridViewTextBoxColumn.HeaderText = "MSRoleID"
        Me.MSRoleIDDataGridViewTextBoxColumn.Name = "MSRoleIDDataGridViewTextBoxColumn"
        Me.MSRoleIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.MSRoleIDDataGridViewTextBoxColumn.Visible = False
        '
        'MSPwdByteDataGridViewTextBoxColumn
        '
        Me.MSPwdByteDataGridViewTextBoxColumn.DataPropertyName = "MSPwdByte"
        Me.MSPwdByteDataGridViewTextBoxColumn.HeaderText = "MSPwdByte"
        Me.MSPwdByteDataGridViewTextBoxColumn.Name = "MSPwdByteDataGridViewTextBoxColumn"
        Me.MSPwdByteDataGridViewTextBoxColumn.ReadOnly = True
        Me.MSPwdByteDataGridViewTextBoxColumn.Visible = False
        '
        'UserIDDataGridViewTextBoxColumn
        '
        Me.UserIDDataGridViewTextBoxColumn.DataPropertyName = "UserID"
        Me.UserIDDataGridViewTextBoxColumn.HeaderText = "UserID"
        Me.UserIDDataGridViewTextBoxColumn.Name = "UserIDDataGridViewTextBoxColumn"
        Me.UserIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.UserIDDataGridViewTextBoxColumn.Visible = False
        '
        'UserNameDataGridViewTextBoxColumn
        '
        Me.UserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName"
        Me.UserNameDataGridViewTextBoxColumn.HeaderText = "UserName"
        Me.UserNameDataGridViewTextBoxColumn.Name = "UserNameDataGridViewTextBoxColumn"
        Me.UserNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.UserNameDataGridViewTextBoxColumn.Visible = False
        '
        'PassDataGridViewImageColumn
        '
        Me.PassDataGridViewImageColumn.DataPropertyName = "Pass"
        Me.PassDataGridViewImageColumn.HeaderText = "Pass"
        Me.PassDataGridViewImageColumn.Name = "PassDataGridViewImageColumn"
        Me.PassDataGridViewImageColumn.ReadOnly = True
        Me.PassDataGridViewImageColumn.Visible = False
        '
        'TmpPassDataGridViewTextBoxColumn
        '
        Me.TmpPassDataGridViewTextBoxColumn.DataPropertyName = "TmpPass"
        Me.TmpPassDataGridViewTextBoxColumn.HeaderText = "TmpPass"
        Me.TmpPassDataGridViewTextBoxColumn.Name = "TmpPassDataGridViewTextBoxColumn"
        Me.TmpPassDataGridViewTextBoxColumn.ReadOnly = True
        Me.TmpPassDataGridViewTextBoxColumn.Visible = False
        '
        'DispNameDataGridViewTextBoxColumn
        '
        Me.DispNameDataGridViewTextBoxColumn.DataPropertyName = "DispName"
        Me.DispNameDataGridViewTextBoxColumn.HeaderText = "DispName"
        Me.DispNameDataGridViewTextBoxColumn.Name = "DispNameDataGridViewTextBoxColumn"
        Me.DispNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.DispNameDataGridViewTextBoxColumn.Visible = False
        '
        'DesgNo
        '
        Me.DesgNo.DataPropertyName = "DesgID"
        Me.DesgNo.HeaderText = "DesgID"
        Me.DesgNo.Name = "DesgNo"
        Me.DesgNo.ReadOnly = True
        Me.DesgNo.Visible = False
        '
        'Designation
        '
        Me.Designation.DataPropertyName = "Desg"
        Me.Designation.HeaderText = "Designation"
        Me.Designation.Name = "Designation"
        Me.Designation.ReadOnly = True
        Me.Designation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DLevels
        '
        Me.DLevels.DataPropertyName = "DLevel"
        Me.DLevels.FillWeight = 125.0!
        Me.DLevels.HeaderText = "Designation Level"
        Me.DLevels.Name = "DLevels"
        Me.DLevels.ReadOnly = True
        Me.DLevels.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DLevels.Width = 125
        '
        'ConcurrencyIdDataGridViewTextBoxColumn
        '
        Me.ConcurrencyIdDataGridViewTextBoxColumn.DataPropertyName = "ConcurrencyId"
        Me.ConcurrencyIdDataGridViewTextBoxColumn.HeaderText = "ConcurrencyId"
        Me.ConcurrencyIdDataGridViewTextBoxColumn.Name = "ConcurrencyIdDataGridViewTextBoxColumn"
        Me.ConcurrencyIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.ConcurrencyIdDataGridViewTextBoxColumn.Visible = False
        '
        'EstateCodeDataGridViewTextBoxColumn
        '
        Me.EstateCodeDataGridViewTextBoxColumn.DataPropertyName = "EstateCode"
        Me.EstateCodeDataGridViewTextBoxColumn.HeaderText = "EstateCode"
        Me.EstateCodeDataGridViewTextBoxColumn.Name = "EstateCodeDataGridViewTextBoxColumn"
        Me.EstateCodeDataGridViewTextBoxColumn.ReadOnly = True
        Me.EstateCodeDataGridViewTextBoxColumn.Visible = False
        '
        'CreatedByDataGridViewTextBoxColumn
        '
        Me.CreatedByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy"
        Me.CreatedByDataGridViewTextBoxColumn.HeaderText = "CreatedBy"
        Me.CreatedByDataGridViewTextBoxColumn.Name = "CreatedByDataGridViewTextBoxColumn"
        Me.CreatedByDataGridViewTextBoxColumn.ReadOnly = True
        Me.CreatedByDataGridViewTextBoxColumn.Visible = False
        '
        'CreatedOnDataGridViewTextBoxColumn
        '
        Me.CreatedOnDataGridViewTextBoxColumn.DataPropertyName = "CreatedOn"
        Me.CreatedOnDataGridViewTextBoxColumn.HeaderText = "CreatedOn"
        Me.CreatedOnDataGridViewTextBoxColumn.Name = "CreatedOnDataGridViewTextBoxColumn"
        Me.CreatedOnDataGridViewTextBoxColumn.ReadOnly = True
        Me.CreatedOnDataGridViewTextBoxColumn.Visible = False
        '
        'ModifiedByDataGridViewTextBoxColumn
        '
        Me.ModifiedByDataGridViewTextBoxColumn.DataPropertyName = "ModifiedBy"
        Me.ModifiedByDataGridViewTextBoxColumn.HeaderText = "ModifiedBy"
        Me.ModifiedByDataGridViewTextBoxColumn.Name = "ModifiedByDataGridViewTextBoxColumn"
        Me.ModifiedByDataGridViewTextBoxColumn.ReadOnly = True
        Me.ModifiedByDataGridViewTextBoxColumn.Visible = False
        '
        'ModifiedOnDataGridViewTextBoxColumn
        '
        Me.ModifiedOnDataGridViewTextBoxColumn.DataPropertyName = "ModifiedOn"
        Me.ModifiedOnDataGridViewTextBoxColumn.HeaderText = "ModifiedOn"
        Me.ModifiedOnDataGridViewTextBoxColumn.Name = "ModifiedOnDataGridViewTextBoxColumn"
        Me.ModifiedOnDataGridViewTextBoxColumn.ReadOnly = True
        Me.ModifiedOnDataGridViewTextBoxColumn.Visible = False
        '
        'cmsDesig
        '
        Me.cmsDesig.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.SaveUPdateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsDesig.Name = "ContextMenuStrip1"
        Me.cmsDesig.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.cmsDesig.Size = New System.Drawing.Size(143, 70)
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
        'UserMasterPPTBindingSource
        '
        Me.UserMasterPPTBindingSource.DataSource = GetType(Common_PPT.UserMasterPPT)
        '
        'gpDesignation
        '
        Me.gpDesignation.Controls.Add(Me.lblDesignationLevel)
        Me.gpDesignation.Controls.Add(Me.cbDesignationLevel)
        Me.gpDesignation.Controls.Add(Me.Label2)
        Me.gpDesignation.Controls.Add(Me.Label1)
        Me.gpDesignation.Controls.Add(Me.txtDesignation)
        Me.gpDesignation.Controls.Add(Me.lblDesignation)
        Me.gpDesignation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDesignation.Location = New System.Drawing.Point(12, 12)
        Me.gpDesignation.Name = "gpDesignation"
        Me.gpDesignation.Size = New System.Drawing.Size(466, 106)
        Me.gpDesignation.TabIndex = 0
        Me.gpDesignation.TabStop = False
        Me.gpDesignation.Text = "Add Designation"
        '
        'lblDesignationLevel
        '
        Me.lblDesignationLevel.AutoSize = True
        Me.lblDesignationLevel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignationLevel.ForeColor = System.Drawing.Color.Red
        Me.lblDesignationLevel.Location = New System.Drawing.Point(32, 68)
        Me.lblDesignationLevel.Name = "lblDesignationLevel"
        Me.lblDesignationLevel.Size = New System.Drawing.Size(108, 13)
        Me.lblDesignationLevel.TabIndex = 8
        Me.lblDesignationLevel.Text = "Designation Level"
        '
        'cbDesignationLevel
        '
        Me.cbDesignationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDesignationLevel.FormattingEnabled = True
        Me.cbDesignationLevel.Items.AddRange(New Object() {"--Select--", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cbDesignationLevel.Location = New System.Drawing.Point(162, 64)
        Me.cbDesignationLevel.Name = "cbDesignationLevel"
        Me.cbDesignationLevel.Size = New System.Drawing.Size(87, 21)
        Me.cbDesignationLevel.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(146, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(146, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ":"
        '
        'txtDesignation
        '
        Me.txtDesignation.Location = New System.Drawing.Point(162, 30)
        Me.txtDesignation.Name = "txtDesignation"
        Me.txtDesignation.Size = New System.Drawing.Size(262, 21)
        Me.txtDesignation.TabIndex = 0
        '
        'lblDesignation
        '
        Me.lblDesignation.AutoSize = True
        Me.lblDesignation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignation.ForeColor = System.Drawing.Color.Red
        Me.lblDesignation.Location = New System.Drawing.Point(32, 30)
        Me.lblDesignation.Name = "lblDesignation"
        Me.lblDesignation.Size = New System.Drawing.Size(74, 13)
        Me.lblDesignation.TabIndex = 0
        Me.lblDesignation.Text = "Designation"
        '
        'DesignationFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(773, 431)
        Me.Controls.Add(Me.PlDesignationMaster)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DesignationFrm"
        Me.Text = "Designation Master"
        Me.PlDesignationMaster.ResumeLayout(False)
        Me.gpButtons.ResumeLayout(False)
        Me.gpViewDesignation.ResumeLayout(False)
        CType(Me.dgvViewDesignation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDesig.ResumeLayout(False)
        CType(Me.UserMasterPPTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDesignation.ResumeLayout(False)
        Me.gpDesignation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlDesignationMaster As System.Windows.Forms.Panel
    Friend WithEvents gpViewDesignation As System.Windows.Forms.GroupBox
    Friend WithEvents gpDesignation As System.Windows.Forms.GroupBox
    Friend WithEvents txtDesignation As System.Windows.Forms.TextBox
    Friend WithEvents lblDesignation As System.Windows.Forms.Label
    Friend WithEvents dgvViewDesignation As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbDesignationLevel As System.Windows.Forms.ComboBox
    Friend WithEvents gpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents UserMasterPPTBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents lblDesignationLevel As System.Windows.Forms.Label
    Friend WithEvents cmsDesig As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveUPdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MSUserIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MSUserNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MSDispNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MSPwdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MSDesgIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MSRoleIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MSPwdByteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PassDataGridViewImageColumn As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents TmpPassDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DispNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesgNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Designation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DLevels As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConcurrencyIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedOnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifiedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifiedOnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

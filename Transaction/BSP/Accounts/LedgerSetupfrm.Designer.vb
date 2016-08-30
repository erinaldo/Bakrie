<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerSetupfrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LedgerSetupfrm))
        Me.gpLedgerTypeToGridDisplay = New System.Windows.Forms.GroupBox
        Me.dgLedgerTypeDetails = New System.Windows.Forms.DataGridView
        Me.LedgerType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LedgerDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LedgerSetUpId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsLedgerDetail = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.gpAddLedgerType = New System.Windows.Forms.GroupBox
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.lblColon2 = New System.Windows.Forms.Label
        Me.lblColon1 = New System.Windows.Forms.Label
        Me.txtLedgerDescription = New System.Windows.Forms.TextBox
        Me.txtLedgerType = New System.Windows.Forms.TextBox
        Me.lblLedgerDescription = New System.Windows.Forms.Label
        Me.lblLedgerType = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.gpLedgerTypeToGridDisplay.SuspendLayout()
        CType(Me.dgLedgerTypeDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsLedgerDetail.SuspendLayout()
        Me.gpAddLedgerType.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpLedgerTypeToGridDisplay
        '
        Me.gpLedgerTypeToGridDisplay.Controls.Add(Me.dgLedgerTypeDetails)
        Me.gpLedgerTypeToGridDisplay.Location = New System.Drawing.Point(25, 191)
        Me.gpLedgerTypeToGridDisplay.Name = "gpLedgerTypeToGridDisplay"
        Me.gpLedgerTypeToGridDisplay.Size = New System.Drawing.Size(466, 193)
        Me.gpLedgerTypeToGridDisplay.TabIndex = 7
        Me.gpLedgerTypeToGridDisplay.TabStop = False
        Me.gpLedgerTypeToGridDisplay.Text = "View Ledger Type"
        '
        'dgLedgerTypeDetails
        '
        Me.dgLedgerTypeDetails.AllowUserToAddRows = False
        Me.dgLedgerTypeDetails.AllowUserToDeleteRows = False
        Me.dgLedgerTypeDetails.AllowUserToResizeRows = False
        Me.dgLedgerTypeDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgLedgerTypeDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgLedgerTypeDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLedgerTypeDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLedgerTypeDetails.ColumnHeadersHeight = 30
        Me.dgLedgerTypeDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LedgerType, Me.LedgerDescription, Me.LedgerSetUpId})
        Me.dgLedgerTypeDetails.ContextMenuStrip = Me.cmsLedgerDetail
        Me.dgLedgerTypeDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgLedgerTypeDetails.EnableHeadersVisualStyles = False
        Me.dgLedgerTypeDetails.GridColor = System.Drawing.Color.Gray
        Me.dgLedgerTypeDetails.Location = New System.Drawing.Point(17, 31)
        Me.dgLedgerTypeDetails.Name = "dgLedgerTypeDetails"
        Me.dgLedgerTypeDetails.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLedgerTypeDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgLedgerTypeDetails.RowHeadersVisible = False
        Me.dgLedgerTypeDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLedgerTypeDetails.Size = New System.Drawing.Size(425, 146)
        Me.dgLedgerTypeDetails.TabIndex = 8
        '
        'LedgerType
        '
        Me.LedgerType.DataPropertyName = "LedgerType"
        Me.LedgerType.HeaderText = "Ledger Type"
        Me.LedgerType.Name = "LedgerType"
        Me.LedgerType.ReadOnly = True
        Me.LedgerType.Width = 102
        '
        'LedgerDescription
        '
        Me.LedgerDescription.DataPropertyName = "LedgerTypeDescp"
        Me.LedgerDescription.HeaderText = "Ledger Description"
        Me.LedgerDescription.Name = "LedgerDescription"
        Me.LedgerDescription.ReadOnly = True
        Me.LedgerDescription.Width = 138
        '
        'LedgerSetUpId
        '
        Me.LedgerSetUpId.DataPropertyName = "LedgerSetUpId"
        Me.LedgerSetUpId.HeaderText = "LedgerSetUpId"
        Me.LedgerSetUpId.Name = "LedgerSetUpId"
        Me.LedgerSetUpId.ReadOnly = True
        Me.LedgerSetUpId.Visible = False
        Me.LedgerSetUpId.Width = 5
        '
        'cmsLedgerDetail
        '
        Me.cmsLedgerDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditUpdateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsLedgerDetail.Name = "cmsLedgerDetail"
        Me.cmsLedgerDetail.Size = New System.Drawing.Size(117, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditUpdateToolStripMenuItem
        '
        Me.EditUpdateToolStripMenuItem.Name = "EditUpdateToolStripMenuItem"
        Me.EditUpdateToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.EditUpdateToolStripMenuItem.Text = "Edit "
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'gpAddLedgerType
        '
        Me.gpAddLedgerType.Controls.Add(Me.btnReset)
        Me.gpAddLedgerType.Controls.Add(Me.btnClose)
        Me.gpAddLedgerType.Controls.Add(Me.btnSave)
        Me.gpAddLedgerType.Controls.Add(Me.lblColon2)
        Me.gpAddLedgerType.Controls.Add(Me.lblColon1)
        Me.gpAddLedgerType.Controls.Add(Me.txtLedgerDescription)
        Me.gpAddLedgerType.Controls.Add(Me.txtLedgerType)
        Me.gpAddLedgerType.Controls.Add(Me.lblLedgerDescription)
        Me.gpAddLedgerType.Controls.Add(Me.lblLedgerType)
        Me.gpAddLedgerType.Location = New System.Drawing.Point(25, 17)
        Me.gpAddLedgerType.Name = "gpAddLedgerType"
        Me.gpAddLedgerType.Size = New System.Drawing.Size(466, 168)
        Me.gpAddLedgerType.TabIndex = 1
        Me.gpAddLedgerType.TabStop = False
        Me.gpAddLedgerType.Text = " "
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(312, 137)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(110, 25)
        Me.btnReset.TabIndex = 6
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(214, 137)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 25)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(93, 137)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(118, 25)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblColon2
        '
        Me.lblColon2.AutoSize = True
        Me.lblColon2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon2.Location = New System.Drawing.Point(183, 78)
        Me.lblColon2.Name = "lblColon2"
        Me.lblColon2.Size = New System.Drawing.Size(11, 13)
        Me.lblColon2.TabIndex = 130
        Me.lblColon2.Text = ":"
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(183, 31)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(11, 13)
        Me.lblColon1.TabIndex = 129
        Me.lblColon1.Text = ":"
        '
        'txtLedgerDescription
        '
        Me.txtLedgerDescription.Location = New System.Drawing.Point(200, 64)
        Me.txtLedgerDescription.Multiline = True
        Me.txtLedgerDescription.Name = "txtLedgerDescription"
        Me.txtLedgerDescription.Size = New System.Drawing.Size(207, 52)
        Me.txtLedgerDescription.TabIndex = 3
        '
        'txtLedgerType
        '
        Me.txtLedgerType.Location = New System.Drawing.Point(200, 31)
        Me.txtLedgerType.Name = "txtLedgerType"
        Me.txtLedgerType.Size = New System.Drawing.Size(207, 21)
        Me.txtLedgerType.TabIndex = 2
        '
        'lblLedgerDescription
        '
        Me.lblLedgerDescription.AutoSize = True
        Me.lblLedgerDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLedgerDescription.Location = New System.Drawing.Point(67, 78)
        Me.lblLedgerDescription.Name = "lblLedgerDescription"
        Me.lblLedgerDescription.Size = New System.Drawing.Size(114, 13)
        Me.lblLedgerDescription.TabIndex = 1
        Me.lblLedgerDescription.Text = "Ledger Description"
        '
        'lblLedgerType
        '
        Me.lblLedgerType.AutoSize = True
        Me.lblLedgerType.ForeColor = System.Drawing.Color.Red
        Me.lblLedgerType.Location = New System.Drawing.Point(67, 31)
        Me.lblLedgerType.Name = "lblLedgerType"
        Me.lblLedgerType.Size = New System.Drawing.Size(78, 13)
        Me.lblLedgerType.TabIndex = 0
        Me.lblLedgerType.Text = "Ledger Type"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(1, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(521, 447)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.gpLedgerTypeToGridDisplay)
        Me.TabPage1.Controls.Add(Me.gpAddLedgerType)
        Me.TabPage1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(513, 421)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ledger Setup"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LedgerSetupfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(526, 460)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "LedgerSetupfrm"
        Me.Text = "LedgerSetupfrm"
        Me.gpLedgerTypeToGridDisplay.ResumeLayout(False)
        CType(Me.dgLedgerTypeDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsLedgerDetail.ResumeLayout(False)
        Me.gpAddLedgerType.ResumeLayout(False)
        Me.gpAddLedgerType.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpAddLedgerType As System.Windows.Forms.GroupBox
    Friend WithEvents txtLedgerDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtLedgerType As System.Windows.Forms.TextBox
    Friend WithEvents lblLedgerDescription As System.Windows.Forms.Label
    Friend WithEvents lblLedgerType As System.Windows.Forms.Label
    Friend WithEvents gpLedgerTypeToGridDisplay As System.Windows.Forms.GroupBox
    Friend WithEvents cmsLedgerDetail As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblColon2 As System.Windows.Forms.Label
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents dgLedgerTypeDetails As System.Windows.Forms.DataGridView
    Friend WithEvents LedgerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LedgerDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LedgerSetUpId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
End Class

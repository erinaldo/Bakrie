<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleRunningLogPostingFrm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VehicleRunningLogPostingFrm))
        Me.pnlVehicleRunningLogPosting = New System.Windows.Forms.Panel
        Me.lblApprovalMsg1 = New System.Windows.Forms.Label
        Me.lblApproveMessage = New System.Windows.Forms.Label
        Me.dgvPostingNonPostedVehicleRunningLog = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHWSCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalHrsOrKm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Details = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Post = New System.Windows.Forms.DataGridViewButtonColumn
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnApproveAll = New System.Windows.Forms.Button
        Me.cmsVehicleRunningLogPosting = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlVehicleRunningLogPosting.SuspendLayout()
        CType(Me.dgvPostingNonPostedVehicleRunningLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsVehicleRunningLogPosting.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlVehicleRunningLogPosting
        '
        Me.pnlVehicleRunningLogPosting.AutoScroll = True
        Me.pnlVehicleRunningLogPosting.BackColor = System.Drawing.Color.Transparent
        Me.pnlVehicleRunningLogPosting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlVehicleRunningLogPosting.Controls.Add(Me.lblApprovalMsg1)
        Me.pnlVehicleRunningLogPosting.Controls.Add(Me.lblApproveMessage)
        Me.pnlVehicleRunningLogPosting.Controls.Add(Me.dgvPostingNonPostedVehicleRunningLog)
        Me.pnlVehicleRunningLogPosting.Controls.Add(Me.btnClose)
        Me.pnlVehicleRunningLogPosting.Controls.Add(Me.btnApproveAll)
        Me.pnlVehicleRunningLogPosting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlVehicleRunningLogPosting.Location = New System.Drawing.Point(0, 0)
        Me.pnlVehicleRunningLogPosting.Name = "pnlVehicleRunningLogPosting"
        Me.pnlVehicleRunningLogPosting.Size = New System.Drawing.Size(956, 732)
        Me.pnlVehicleRunningLogPosting.TabIndex = 12
        '
        'lblApprovalMsg1
        '
        Me.lblApprovalMsg1.AutoSize = True
        Me.lblApprovalMsg1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovalMsg1.ForeColor = System.Drawing.Color.Red
        Me.lblApprovalMsg1.Location = New System.Drawing.Point(241, 38)
        Me.lblApprovalMsg1.Name = "lblApprovalMsg1"
        Me.lblApprovalMsg1.Size = New System.Drawing.Size(560, 13)
        Me.lblApprovalMsg1.TabIndex = 12
        Me.lblApprovalMsg1.Text = "Once vehicle approved for the day, cannot enter any more vehicle running for the " & _
            "same vehicle."
        '
        'lblApproveMessage
        '
        Me.lblApproveMessage.AutoSize = True
        Me.lblApproveMessage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproveMessage.Location = New System.Drawing.Point(242, 22)
        Me.lblApproveMessage.Name = "lblApproveMessage"
        Me.lblApproveMessage.Size = New System.Drawing.Size(322, 13)
        Me.lblApproveMessage.TabIndex = 11
        Me.lblApproveMessage.Text = "A vehicle record Approved cannot be Edited or Deleted"
        '
        'dgvPostingNonPostedVehicleRunningLog
        '
        Me.dgvPostingNonPostedVehicleRunningLog.AllowUserToAddRows = False
        Me.dgvPostingNonPostedVehicleRunningLog.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPostingNonPostedVehicleRunningLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPostingNonPostedVehicleRunningLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPostingNonPostedVehicleRunningLog.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPostingNonPostedVehicleRunningLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPostingNonPostedVehicleRunningLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPostingNonPostedVehicleRunningLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.LogDate, Me.VHWSCode, Me.TotalHrsOrKm, Me.Details, Me.Post})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPostingNonPostedVehicleRunningLog.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPostingNonPostedVehicleRunningLog.EnableHeadersVisualStyles = False
        Me.dgvPostingNonPostedVehicleRunningLog.Location = New System.Drawing.Point(12, 68)
        Me.dgvPostingNonPostedVehicleRunningLog.MultiSelect = False
        Me.dgvPostingNonPostedVehicleRunningLog.Name = "dgvPostingNonPostedVehicleRunningLog"
        Me.dgvPostingNonPostedVehicleRunningLog.ReadOnly = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPostingNonPostedVehicleRunningLog.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPostingNonPostedVehicleRunningLog.RowHeadersVisible = False
        Me.dgvPostingNonPostedVehicleRunningLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPostingNonPostedVehicleRunningLog.Size = New System.Drawing.Size(932, 388)
        Me.dgvPostingNonPostedVehicleRunningLog.TabIndex = 0
        Me.dgvPostingNonPostedVehicleRunningLog.TabStop = False
        '
        'Id
        '
        Me.Id.DataPropertyName = "ID"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        '
        'LogDate
        '
        Me.LogDate.DataPropertyName = "LogDate"
        Me.LogDate.FillWeight = 132.5166!
        Me.LogDate.HeaderText = "Date"
        Me.LogDate.Name = "LogDate"
        Me.LogDate.ReadOnly = True
        '
        'VHWSCode
        '
        Me.VHWSCode.DataPropertyName = "VHWSCode"
        Me.VHWSCode.FillWeight = 132.5166!
        Me.VHWSCode.HeaderText = "Vehicle Code"
        Me.VHWSCode.Name = "VHWSCode"
        Me.VHWSCode.ReadOnly = True
        '
        'TotalHrsOrKm
        '
        Me.TotalHrsOrKm.DataPropertyName = "TotalHrsOrKm"
        Me.TotalHrsOrKm.FillWeight = 132.5166!
        Me.TotalHrsOrKm.HeaderText = "Total Hrs / Km"
        Me.TotalHrsOrKm.Name = "TotalHrsOrKm"
        Me.TotalHrsOrKm.ReadOnly = True
        '
        'Details
        '
        Me.Details.FillWeight = 50.76142!
        Me.Details.HeaderText = "Details"
        Me.Details.Name = "Details"
        Me.Details.ReadOnly = True
        Me.Details.Text = "Details"
        Me.Details.UseColumnTextForButtonValue = True
        '
        'Post
        '
        Me.Post.FillWeight = 51.68864!
        Me.Post.HeaderText = "Approval"
        Me.Post.Name = "Post"
        Me.Post.ReadOnly = True
        Me.Post.Text = "Approve"
        Me.Post.UseColumnTextForButtonValue = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(135, 20)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 28)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnApproveAll
        '
        Me.btnApproveAll.BackgroundImage = CType(resources.GetObject("btnApproveAll.BackgroundImage"), System.Drawing.Image)
        Me.btnApproveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnApproveAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApproveAll.Image = CType(resources.GetObject("btnApproveAll.Image"), System.Drawing.Image)
        Me.btnApproveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApproveAll.Location = New System.Drawing.Point(22, 20)
        Me.btnApproveAll.Name = "btnApproveAll"
        Me.btnApproveAll.Size = New System.Drawing.Size(107, 28)
        Me.btnApproveAll.TabIndex = 1
        Me.btnApproveAll.Text = "Approval All"
        Me.btnApproveAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnApproveAll.UseVisualStyleBackColor = True
        '
        'cmsVehicleRunningLogPosting
        '
        Me.cmsVehicleRunningLogPosting.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsVehicleRunningLogPosting.Name = "cmsIPR"
        Me.cmsVehicleRunningLogPosting.Size = New System.Drawing.Size(149, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.EditToolStripMenuItem.Text = "Edit / Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'VehicleRunningLogPostingFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(956, 732)
        Me.Controls.Add(Me.pnlVehicleRunningLogPosting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VehicleRunningLogPostingFrm"
        Me.Text = "Vehicle Distribution"
        Me.pnlVehicleRunningLogPosting.ResumeLayout(False)
        Me.pnlVehicleRunningLogPosting.PerformLayout()
        CType(Me.dgvPostingNonPostedVehicleRunningLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsVehicleRunningLogPosting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlVehicleRunningLogPosting As System.Windows.Forms.Panel
    Friend WithEvents cmsVehicleRunningLogPosting As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnApproveAll As System.Windows.Forms.Button
    Friend WithEvents dgvPostingNonPostedVehicleRunningLog As System.Windows.Forms.DataGridView
    Friend WithEvents lblApproveMessage As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHWSCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalHrsOrKm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Details As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Post As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lblApprovalMsg1 As System.Windows.Forms.Label
End Class

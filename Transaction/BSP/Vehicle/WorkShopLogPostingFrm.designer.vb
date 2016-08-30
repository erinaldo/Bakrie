<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkShopLogPostingFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkShopLogPostingFrm))
        Me.pnlVehicleDistributionPosting = New System.Windows.Forms.Panel
        Me.dgvPostingNonPostedWorkshopLog = New System.Windows.Forms.DataGridView
        Me.lblApproveMessage = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnApproveAll = New System.Windows.Forms.Button
        Me.cmsWorkshopLogPosting = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkshopNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalHrs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Details = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Post = New System.Windows.Forms.DataGridViewButtonColumn
        Me.pnlVehicleDistributionPosting.SuspendLayout()
        CType(Me.dgvPostingNonPostedWorkshopLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsWorkshopLogPosting.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlVehicleDistributionPosting
        '
        Me.pnlVehicleDistributionPosting.AutoScroll = True
        Me.pnlVehicleDistributionPosting.BackColor = System.Drawing.Color.Transparent
        Me.pnlVehicleDistributionPosting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlVehicleDistributionPosting.Controls.Add(Me.dgvPostingNonPostedWorkshopLog)
        Me.pnlVehicleDistributionPosting.Controls.Add(Me.lblApproveMessage)
        Me.pnlVehicleDistributionPosting.Controls.Add(Me.btnClose)
        Me.pnlVehicleDistributionPosting.Controls.Add(Me.btnApproveAll)
        Me.pnlVehicleDistributionPosting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlVehicleDistributionPosting.Location = New System.Drawing.Point(0, 0)
        Me.pnlVehicleDistributionPosting.Name = "pnlVehicleDistributionPosting"
        Me.pnlVehicleDistributionPosting.Size = New System.Drawing.Size(956, 732)
        Me.pnlVehicleDistributionPosting.TabIndex = 12
        '
        'dgvPostingNonPostedWorkshopLog
        '
        Me.dgvPostingNonPostedWorkshopLog.AllowUserToAddRows = False
        Me.dgvPostingNonPostedWorkshopLog.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPostingNonPostedWorkshopLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPostingNonPostedWorkshopLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPostingNonPostedWorkshopLog.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPostingNonPostedWorkshopLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPostingNonPostedWorkshopLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPostingNonPostedWorkshopLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.LogDate, Me.WorkshopNo, Me.VHID, Me.TotalHrs, Me.Details, Me.Post})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPostingNonPostedWorkshopLog.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPostingNonPostedWorkshopLog.EnableHeadersVisualStyles = False
        Me.dgvPostingNonPostedWorkshopLog.Location = New System.Drawing.Point(12, 68)
        Me.dgvPostingNonPostedWorkshopLog.MultiSelect = False
        Me.dgvPostingNonPostedWorkshopLog.Name = "dgvPostingNonPostedWorkshopLog"
        Me.dgvPostingNonPostedWorkshopLog.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPostingNonPostedWorkshopLog.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPostingNonPostedWorkshopLog.RowHeadersVisible = False
        Me.dgvPostingNonPostedWorkshopLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPostingNonPostedWorkshopLog.Size = New System.Drawing.Size(932, 388)
        Me.dgvPostingNonPostedWorkshopLog.TabIndex = 3
        Me.dgvPostingNonPostedWorkshopLog.TabStop = False
        '
        'lblApproveMessage
        '
        Me.lblApproveMessage.AutoSize = True
        Me.lblApproveMessage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproveMessage.Location = New System.Drawing.Point(235, 32)
        Me.lblApproveMessage.Name = "lblApproveMessage"
        Me.lblApproveMessage.Size = New System.Drawing.Size(337, 13)
        Me.lblApproveMessage.TabIndex = 10
        Me.lblApproveMessage.Text = "A workshop record Approved cannot be Edited or Deleted"
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
        Me.btnClose.TabIndex = 1
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
        Me.btnApproveAll.TabIndex = 0
        Me.btnApproveAll.Text = "Approval All"
        Me.btnApproveAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnApproveAll.UseVisualStyleBackColor = True
        '
        'cmsWorkshopLogPosting
        '
        Me.cmsWorkshopLogPosting.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsWorkshopLogPosting.Name = "cmsIPR"
        Me.cmsWorkshopLogPosting.Size = New System.Drawing.Size(149, 70)
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
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        '
        'LogDate
        '
        Me.LogDate.DataPropertyName = "LogDate"
        Me.LogDate.FillWeight = 119.3774!
        Me.LogDate.HeaderText = "Date"
        Me.LogDate.Name = "LogDate"
        Me.LogDate.ReadOnly = True
        '
        'WorkshopNo
        '
        Me.WorkshopNo.DataPropertyName = "WorkVHID"
        Me.WorkshopNo.FillWeight = 119.3774!
        Me.WorkshopNo.HeaderText = "Workshop No"
        Me.WorkshopNo.Name = "WorkshopNo"
        Me.WorkshopNo.ReadOnly = True
        '
        'VHID
        '
        Me.VHID.DataPropertyName = "VHID"
        Me.VHID.FillWeight = 119.3774!
        Me.VHID.HeaderText = "Vehicle Code"
        Me.VHID.Name = "VHID"
        Me.VHID.ReadOnly = True
        '
        'TotalHrs
        '
        Me.TotalHrs.DataPropertyName = "TotalHrs"
        Me.TotalHrs.FillWeight = 119.3774!
        Me.TotalHrs.HeaderText = "Total Hrs"
        Me.TotalHrs.Name = "TotalHrs"
        Me.TotalHrs.ReadOnly = True
        '
        'Details
        '
        Me.Details.FillWeight = 60.9137!
        Me.Details.HeaderText = "Details"
        Me.Details.Name = "Details"
        Me.Details.ReadOnly = True
        Me.Details.Text = "Details"
        Me.Details.UseColumnTextForButtonValue = True
        '
        'Post
        '
        Me.Post.FillWeight = 61.57676!
        Me.Post.HeaderText = "Approval"
        Me.Post.Name = "Post"
        Me.Post.ReadOnly = True
        Me.Post.Text = "Approve"
        Me.Post.UseColumnTextForButtonValue = True
        '
        'WorkShopLogPostingFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(956, 732)
        Me.Controls.Add(Me.pnlVehicleDistributionPosting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WorkShopLogPostingFrm"
        Me.Text = "Vehicle Distribution"
        Me.pnlVehicleDistributionPosting.ResumeLayout(False)
        Me.pnlVehicleDistributionPosting.PerformLayout()
        CType(Me.dgvPostingNonPostedWorkshopLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsWorkshopLogPosting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlVehicleDistributionPosting As System.Windows.Forms.Panel
    Friend WithEvents cmsWorkshopLogPosting As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblApproveMessage As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnApproveAll As System.Windows.Forms.Button
    Friend WithEvents dgvPostingNonPostedWorkshopLog As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkshopNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalHrs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Details As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Post As System.Windows.Forms.DataGridViewButtonColumn
End Class

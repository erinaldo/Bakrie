<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleDistributionPostingFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VehicleDistributionPostingFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlVehicleDistributionPosting = New System.Windows.Forms.Panel
        Me.lblApproveMessage = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnApproveAll = New System.Windows.Forms.Button
        Me.dgvPostingNonPostedVehicleDistribution = New System.Windows.Forms.DataGridView
        Me.cmsVehicleDistributionPosting = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalRunningKmHrs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDistributedKmHrs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Details = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Approval = New System.Windows.Forms.DataGridViewButtonColumn
        Me.pnlVehicleDistributionPosting.SuspendLayout()
        CType(Me.dgvPostingNonPostedVehicleDistribution, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsVehicleDistributionPosting.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlVehicleDistributionPosting
        '
        Me.pnlVehicleDistributionPosting.AutoScroll = True
        Me.pnlVehicleDistributionPosting.BackColor = System.Drawing.Color.Transparent
        Me.pnlVehicleDistributionPosting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlVehicleDistributionPosting.Controls.Add(Me.lblApproveMessage)
        Me.pnlVehicleDistributionPosting.Controls.Add(Me.btnClose)
        Me.pnlVehicleDistributionPosting.Controls.Add(Me.btnApproveAll)
        Me.pnlVehicleDistributionPosting.Controls.Add(Me.dgvPostingNonPostedVehicleDistribution)
        Me.pnlVehicleDistributionPosting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlVehicleDistributionPosting.Location = New System.Drawing.Point(0, 0)
        Me.pnlVehicleDistributionPosting.Name = "pnlVehicleDistributionPosting"
        Me.pnlVehicleDistributionPosting.Size = New System.Drawing.Size(956, 732)
        Me.pnlVehicleDistributionPosting.TabIndex = 12
        '
        'lblApproveMessage
        '
        Me.lblApproveMessage.AutoSize = True
        Me.lblApproveMessage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproveMessage.Location = New System.Drawing.Point(244, 29)
        Me.lblApproveMessage.Name = "lblApproveMessage"
        Me.lblApproveMessage.Size = New System.Drawing.Size(322, 13)
        Me.lblApproveMessage.TabIndex = 428
        Me.lblApproveMessage.Text = "A vehicle record Approved cannot be Edited or Deleted"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(138, 21)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 28)
        Me.btnClose.TabIndex = 427
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
        Me.btnApproveAll.Location = New System.Drawing.Point(22, 21)
        Me.btnApproveAll.Name = "btnApproveAll"
        Me.btnApproveAll.Size = New System.Drawing.Size(107, 28)
        Me.btnApproveAll.TabIndex = 426
        Me.btnApproveAll.Text = "Approval All"
        Me.btnApproveAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnApproveAll.UseVisualStyleBackColor = True
        '
        'dgvPostingNonPostedVehicleDistribution
        '
        Me.dgvPostingNonPostedVehicleDistribution.AllowUserToAddRows = False
        Me.dgvPostingNonPostedVehicleDistribution.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvPostingNonPostedVehicleDistribution.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPostingNonPostedVehicleDistribution.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPostingNonPostedVehicleDistribution.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPostingNonPostedVehicleDistribution.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPostingNonPostedVehicleDistribution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPostingNonPostedVehicleDistribution.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.LogDate, Me.VHID, Me.TotalRunningKmHrs, Me.TotalDistributedKmHrs, Me.Details, Me.Approval})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPostingNonPostedVehicleDistribution.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPostingNonPostedVehicleDistribution.EnableHeadersVisualStyles = False
        Me.dgvPostingNonPostedVehicleDistribution.Location = New System.Drawing.Point(12, 68)
        Me.dgvPostingNonPostedVehicleDistribution.MultiSelect = False
        Me.dgvPostingNonPostedVehicleDistribution.Name = "dgvPostingNonPostedVehicleDistribution"
        Me.dgvPostingNonPostedVehicleDistribution.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPostingNonPostedVehicleDistribution.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPostingNonPostedVehicleDistribution.RowHeadersVisible = False
        Me.dgvPostingNonPostedVehicleDistribution.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvPostingNonPostedVehicleDistribution.RowTemplate.Height = 23
        Me.dgvPostingNonPostedVehicleDistribution.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPostingNonPostedVehicleDistribution.Size = New System.Drawing.Size(932, 388)
        Me.dgvPostingNonPostedVehicleDistribution.TabIndex = 7
        Me.dgvPostingNonPostedVehicleDistribution.TabStop = False
        '
        'cmsVehicleDistributionPosting
        '
        Me.cmsVehicleDistributionPosting.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsVehicleDistributionPosting.Name = "cmsIPR"
        Me.cmsVehicleDistributionPosting.Size = New System.Drawing.Size(149, 70)
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
        Me.LogDate.DataPropertyName = "DistributionDT"
        Me.LogDate.FillWeight = 119.4885!
        Me.LogDate.HeaderText = "Date"
        Me.LogDate.Name = "LogDate"
        Me.LogDate.ReadOnly = True
        '
        'VHID
        '
        Me.VHID.DataPropertyName = "VHID"
        Me.VHID.FillWeight = 119.4885!
        Me.VHID.HeaderText = "VehicleCode"
        Me.VHID.Name = "VHID"
        Me.VHID.ReadOnly = True
        '
        'TotalRunningKmHrs
        '
        Me.TotalRunningKmHrs.DataPropertyName = "TotalRunningKmHours"
        Me.TotalRunningKmHrs.FillWeight = 119.4885!
        Me.TotalRunningKmHrs.HeaderText = "Total Running Km/Hrs"
        Me.TotalRunningKmHrs.Name = "TotalRunningKmHrs"
        Me.TotalRunningKmHrs.ReadOnly = True
        '
        'TotalDistributedKmHrs
        '
        Me.TotalDistributedKmHrs.DataPropertyName = "TotalKmHoursDistributed"
        Me.TotalDistributedKmHrs.FillWeight = 119.4885!
        Me.TotalDistributedKmHrs.HeaderText = "Total Distributed Km/Hrs"
        Me.TotalDistributedKmHrs.Name = "TotalDistributedKmHrs"
        Me.TotalDistributedKmHrs.ReadOnly = True
        '
        'Details
        '
        Me.Details.FillWeight = 61.13227!
        Me.Details.HeaderText = "Details"
        Me.Details.Name = "Details"
        Me.Details.ReadOnly = True
        Me.Details.Text = "Details"
        Me.Details.UseColumnTextForButtonValue = True
        '
        'Approval
        '
        Me.Approval.FillWeight = 60.91371!
        Me.Approval.HeaderText = "Approval"
        Me.Approval.Name = "Approval"
        Me.Approval.ReadOnly = True
        Me.Approval.Text = "Approval"
        Me.Approval.UseColumnTextForButtonValue = True
        '
        'VehicleDistributionPostingFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(956, 732)
        Me.Controls.Add(Me.pnlVehicleDistributionPosting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VehicleDistributionPostingFrm"
        Me.Text = "Vehicle Distribution"
        Me.pnlVehicleDistributionPosting.ResumeLayout(False)
        Me.pnlVehicleDistributionPosting.PerformLayout()
        CType(Me.dgvPostingNonPostedVehicleDistribution, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsVehicleDistributionPosting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlVehicleDistributionPosting As System.Windows.Forms.Panel
    Friend WithEvents cmsVehicleDistributionPosting As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvPostingNonPostedVehicleDistribution As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnApproveAll As System.Windows.Forms.Button
    Friend WithEvents lblApproveMessage As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalRunningKmHrs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDistributedKmHrs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Details As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Approval As System.Windows.Forms.DataGridViewButtonColumn
End Class

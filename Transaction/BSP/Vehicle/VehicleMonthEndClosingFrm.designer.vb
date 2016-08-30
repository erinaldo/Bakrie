<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleMonthEndClosingFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VehicleMonthEndClosingFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.EstateId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.grpVehicleMonthEndClosing = New System.Windows.Forms.GroupBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnProc = New System.Windows.Forms.Button
        Me.pnlGrid = New System.Windows.Forms.Panel
        Me.gvTaskStatus = New System.Windows.Forms.DataGridView
        Me.TASK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Complete = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActiveMonthYearID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LblStatus = New System.Windows.Forms.Label
        Me.grpVehicleMonthEndClosing.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        CType(Me.gvTaskStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EstateId
        '
        Me.EstateId.DataPropertyName = "EstateID"
        Me.EstateId.HeaderText = "Estate Id"
        Me.EstateId.Name = "EstateId"
        Me.EstateId.ReadOnly = True
        Me.EstateId.Visible = False
        Me.EstateId.Width = 82
        '
        'PnlSearch
        '
        Me.PnlSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PnlSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.PnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlSearch.BorderColor = System.Drawing.Color.Gray
        Me.PnlSearch.CaptionColorOne = System.Drawing.Color.White
        Me.PnlSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlSearch.CaptionSize = 40
        Me.PnlSearch.CaptionText = "Task Status"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Location = New System.Drawing.Point(6, 19)
        Me.PnlSearch.Moveable = True
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(797, 55)
        Me.PnlSearch.TabIndex = 41
        '
        'grpVehicleMonthEndClosing
        '
        Me.grpVehicleMonthEndClosing.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.grpVehicleMonthEndClosing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.grpVehicleMonthEndClosing.Controls.Add(Me.LblStatus)
        Me.grpVehicleMonthEndClosing.Controls.Add(Me.btnClose)
        Me.grpVehicleMonthEndClosing.Controls.Add(Me.btnProc)
        Me.grpVehicleMonthEndClosing.Controls.Add(Me.PnlSearch)
        Me.grpVehicleMonthEndClosing.Controls.Add(Me.pnlGrid)
        Me.grpVehicleMonthEndClosing.Location = New System.Drawing.Point(12, 12)
        Me.grpVehicleMonthEndClosing.Name = "grpVehicleMonthEndClosing"
        Me.grpVehicleMonthEndClosing.Size = New System.Drawing.Size(826, 463)
        Me.grpVehicleMonthEndClosing.TabIndex = 43
        Me.grpVehicleMonthEndClosing.TabStop = False
        Me.grpVehicleMonthEndClosing.Text = "Vehicle Month End Closing"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(137, 425)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 30)
        Me.btnClose.TabIndex = 164
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnProc
        '
        Me.btnProc.BackColor = System.Drawing.Color.Transparent
        Me.btnProc.BackgroundImage = CType(resources.GetObject("btnProc.BackgroundImage"), System.Drawing.Image)
        Me.btnProc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProc.Image = CType(resources.GetObject("btnProc.Image"), System.Drawing.Image)
        Me.btnProc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProc.Location = New System.Drawing.Point(4, 425)
        Me.btnProc.Name = "btnProc"
        Me.btnProc.Size = New System.Drawing.Size(127, 30)
        Me.btnProc.TabIndex = 163
        Me.btnProc.Text = "&Process"
        Me.btnProc.UseVisualStyleBackColor = False
        '
        'pnlGrid
        '
        Me.pnlGrid.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.pnlGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlGrid.Controls.Add(Me.gvTaskStatus)
        Me.pnlGrid.Location = New System.Drawing.Point(6, 80)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(797, 339)
        Me.pnlGrid.TabIndex = 32
        '
        'gvTaskStatus
        '
        Me.gvTaskStatus.AllowUserToAddRows = False
        Me.gvTaskStatus.AllowUserToDeleteRows = False
        Me.gvTaskStatus.AllowUserToOrderColumns = True
        Me.gvTaskStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gvTaskStatus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gvTaskStatus.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gvTaskStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gvTaskStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvTaskStatus.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvTaskStatus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TASK, Me.Complete, Me.ModID, Me.ActiveMonthYearID, Me.EstateId})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvTaskStatus.DefaultCellStyle = DataGridViewCellStyle2
        Me.gvTaskStatus.EnableHeadersVisualStyles = False
        Me.gvTaskStatus.GridColor = System.Drawing.Color.Gray
        Me.gvTaskStatus.Location = New System.Drawing.Point(3, 0)
        Me.gvTaskStatus.MultiSelect = False
        Me.gvTaskStatus.Name = "gvTaskStatus"
        Me.gvTaskStatus.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvTaskStatus.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gvTaskStatus.RowHeadersVisible = False
        Me.gvTaskStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.gvTaskStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvTaskStatus.Size = New System.Drawing.Size(778, 326)
        Me.gvTaskStatus.TabIndex = 1
        '
        'TASK
        '
        Me.TASK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TASK.DataPropertyName = "Task"
        Me.TASK.HeaderText = "TASK"
        Me.TASK.Name = "TASK"
        Me.TASK.ReadOnly = True
        Me.TASK.Width = 400
        '
        'Complete
        '
        Me.Complete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Complete.DataPropertyName = "Complete"
        Me.Complete.HeaderText = "Complete Status"
        Me.Complete.Name = "Complete"
        Me.Complete.ReadOnly = True
        Me.Complete.Width = 200
        '
        'ModID
        '
        Me.ModID.DataPropertyName = "ModID"
        Me.ModID.HeaderText = "ModID"
        Me.ModID.Name = "ModID"
        Me.ModID.ReadOnly = True
        Me.ModID.Visible = False
        Me.ModID.Width = 68
        '
        'ActiveMonthYearID
        '
        Me.ActiveMonthYearID.DataPropertyName = "ActiveMonthYearID"
        Me.ActiveMonthYearID.HeaderText = "ActiveMonthYearID"
        Me.ActiveMonthYearID.Name = "ActiveMonthYearID"
        Me.ActiveMonthYearID.ReadOnly = True
        Me.ActiveMonthYearID.Visible = False
        Me.ActiveMonthYearID.Width = 140
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.ForeColor = System.Drawing.Color.Black
        Me.LblStatus.Location = New System.Drawing.Point(341, 434)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(49, 13)
        Me.LblStatus.TabIndex = 206
        Me.LblStatus.Text = "Period"
        Me.LblStatus.Visible = False
        '
        'VehicleMonthEndClosingFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(838, 499)
        Me.Controls.Add(Me.grpVehicleMonthEndClosing)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VehicleMonthEndClosingFrm"
        Me.Text = "Vehicle Distribution"
        Me.grpVehicleMonthEndClosing.ResumeLayout(False)
        Me.grpVehicleMonthEndClosing.PerformLayout()
        Me.pnlGrid.ResumeLayout(False)
        CType(Me.gvTaskStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EstateId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents grpVehicleMonthEndClosing As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnProc As System.Windows.Forms.Button
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents gvTaskStatus As System.Windows.Forms.DataGridView
    Friend WithEvents TASK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Complete As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActiveMonthYearID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblStatus As System.Windows.Forms.Label
End Class

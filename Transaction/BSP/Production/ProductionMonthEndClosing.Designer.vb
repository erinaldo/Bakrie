<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionMonthEndClosing
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionMonthEndClosing))
        Me.gpProductionMonthEndClosing = New System.Windows.Forms.GroupBox
        Me.gvTaskStatus = New System.Windows.Forms.DataGridView
        Me.TASK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Complete = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActiveMonthYearID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.btnProcessing = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.gpProductionMonthEndClosing.SuspendLayout()
        CType(Me.gvTaskStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpProductionMonthEndClosing
        '
        Me.gpProductionMonthEndClosing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpProductionMonthEndClosing.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.gpProductionMonthEndClosing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gpProductionMonthEndClosing.Controls.Add(Me.gvTaskStatus)
        Me.gpProductionMonthEndClosing.Controls.Add(Me.PnlSearch)
        Me.gpProductionMonthEndClosing.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpProductionMonthEndClosing.Location = New System.Drawing.Point(1, 16)
        Me.gpProductionMonthEndClosing.Name = "gpProductionMonthEndClosing"
        Me.gpProductionMonthEndClosing.Size = New System.Drawing.Size(779, 433)
        Me.gpProductionMonthEndClosing.TabIndex = 43
        Me.gpProductionMonthEndClosing.TabStop = False
        Me.gpProductionMonthEndClosing.Text = "Production Month End Closing"
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.gvTaskStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvTaskStatus.EnableHeadersVisualStyles = False
        Me.gvTaskStatus.GridColor = System.Drawing.Color.Gray
        Me.gvTaskStatus.Location = New System.Drawing.Point(3, 96)
        Me.gvTaskStatus.MultiSelect = False
        Me.gvTaskStatus.Name = "gvTaskStatus"
        Me.gvTaskStatus.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvTaskStatus.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gvTaskStatus.RowHeadersVisible = False
        Me.gvTaskStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.gvTaskStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvTaskStatus.Size = New System.Drawing.Size(773, 334)
        Me.gvTaskStatus.TabIndex = 1
        '
        'TASK
        '
        Me.TASK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TASK.DataPropertyName = "Task"
        Me.TASK.HeaderText = "Task"
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
        Me.PnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.ForeColor = System.Drawing.Color.Black
        Me.PnlSearch.Location = New System.Drawing.Point(3, 17)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(773, 79)
        Me.PnlSearch.TabIndex = 166
        '
        'btnProcessing
        '
        Me.btnProcessing.BackgroundImage = CType(resources.GetObject("btnProcessing.BackgroundImage"), System.Drawing.Image)
        Me.btnProcessing.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProcessing.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcessing.Image = CType(resources.GetObject("btnProcessing.Image"), System.Drawing.Image)
        Me.btnProcessing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcessing.Location = New System.Drawing.Point(12, 461)
        Me.btnProcessing.Name = "btnProcessing"
        Me.btnProcessing.Size = New System.Drawing.Size(140, 25)
        Me.btnProcessing.TabIndex = 167
        Me.btnProcessing.Text = "Process"
        Me.btnProcessing.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(158, 461)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(140, 25)
        Me.btnClose.TabIndex = 166
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ProductionMonthEndClosing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(781, 498)
        Me.Controls.Add(Me.btnProcessing)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.gpProductionMonthEndClosing)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ProductionMonthEndClosing"
        Me.Text = "ProductionMonthEndClosing"
        Me.gpProductionMonthEndClosing.ResumeLayout(False)
        CType(Me.gvTaskStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpProductionMonthEndClosing As System.Windows.Forms.GroupBox
    Friend WithEvents gvTaskStatus As System.Windows.Forms.DataGridView
    Friend WithEvents TASK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Complete As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActiveMonthYearID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents btnProcessing As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class

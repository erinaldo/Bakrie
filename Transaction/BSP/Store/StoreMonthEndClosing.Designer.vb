<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreMonthEndClosing
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StoreMonthEndClosing))
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.gvTaskStatus = New System.Windows.Forms.DataGridView()
        Me.TASK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Complete = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActiveMonthYearID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstateId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnlSearch = New Stepi.UI.ExtendedPanel()
        Me.grpStoreMonthEndClosing = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnProc = New System.Windows.Forms.Button()
        Me.pnlGrid.SuspendLayout()
        CType(Me.gvTaskStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStoreMonthEndClosing.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlGrid
        '
        Me.pnlGrid.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.pnlGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlGrid.Controls.Add(Me.gvTaskStatus)
        Me.pnlGrid.Location = New System.Drawing.Point(9, 123)
        Me.pnlGrid.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(1196, 522)
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
        Me.gvTaskStatus.Location = New System.Drawing.Point(4, 0)
        Me.gvTaskStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
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
        Me.gvTaskStatus.Size = New System.Drawing.Size(1167, 502)
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
        Me.PnlSearch.Location = New System.Drawing.Point(9, 29)
        Me.PnlSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PnlSearch.Moveable = True
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(1196, 85)
        Me.PnlSearch.TabIndex = 41
        '
        'grpStoreMonthEndClosing
        '
        Me.grpStoreMonthEndClosing.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.grpStoreMonthEndClosing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.grpStoreMonthEndClosing.Controls.Add(Me.btnClose)
        Me.grpStoreMonthEndClosing.Controls.Add(Me.btnProc)
        Me.grpStoreMonthEndClosing.Controls.Add(Me.PnlSearch)
        Me.grpStoreMonthEndClosing.Controls.Add(Me.pnlGrid)
        Me.grpStoreMonthEndClosing.Location = New System.Drawing.Point(0, 0)
        Me.grpStoreMonthEndClosing.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpStoreMonthEndClosing.Name = "grpStoreMonthEndClosing"
        Me.grpStoreMonthEndClosing.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpStoreMonthEndClosing.Size = New System.Drawing.Size(1239, 712)
        Me.grpStoreMonthEndClosing.TabIndex = 42
        Me.grpStoreMonthEndClosing.TabStop = False
        Me.grpStoreMonthEndClosing.Text = "Store Month End Closing"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(206, 654)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(190, 46)
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
        Me.btnProc.Location = New System.Drawing.Point(6, 654)
        Me.btnProc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnProc.Name = "btnProc"
        Me.btnProc.Size = New System.Drawing.Size(190, 46)
        Me.btnProc.TabIndex = 163
        Me.btnProc.Text = "&Process"
        Me.btnProc.UseVisualStyleBackColor = False
        '
        'StoreMonthEndClosing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1257, 768)
        Me.Controls.Add(Me.grpStoreMonthEndClosing)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "StoreMonthEndClosing"
        Me.Text = "Store Month End Closing"
        Me.pnlGrid.ResumeLayout(False)
        CType(Me.gvTaskStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStoreMonthEndClosing.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents grpStoreMonthEndClosing As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnProc As System.Windows.Forms.Button
    Friend WithEvents gvTaskStatus As System.Windows.Forms.DataGridView
    Friend WithEvents TASK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Complete As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActiveMonthYearID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateId As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

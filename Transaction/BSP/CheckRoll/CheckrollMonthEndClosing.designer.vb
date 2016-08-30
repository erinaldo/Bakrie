<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckrollMonthEndClosing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckrollMonthEndClosing))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.LblMsg = New System.Windows.Forms.Label
        Me.LblTitle = New System.Windows.Forms.Label
        Me.btnProcess = New System.Windows.Forms.Button
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.dgvTaskMonitor = New System.Windows.Forms.DataGridView
        Me.TASK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Complete = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActiveMonthYearID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnClose = New System.Windows.Forms.Button
        Me.gbDetail = New System.Windows.Forms.GroupBox
        Me.dgvDistibutionDetails = New System.Windows.Forms.DataGridView
        Me.DARDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DAGangNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DAEmpCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DAEmpNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DAAttendanceCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DADistributionSetupIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvAttendanceHarvNoReceiptionDetails = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvTaskMonitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetail.SuspendLayout()
        CType(Me.dgvDistibutionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAttendanceHarvNoReceiptionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.BackColor = System.Drawing.Color.Transparent
        Me.LblMsg.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsg.Location = New System.Drawing.Point(174, 175)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(317, 14)
        Me.LblMsg.TabIndex = 0
        Me.LblMsg.Text = "Please wait, Month End Closing is in progress..."
        Me.LblMsg.Visible = False
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.BackColor = System.Drawing.Color.Transparent
        Me.LblTitle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.ForeColor = System.Drawing.Color.Red
        Me.LblTitle.Location = New System.Drawing.Point(20, 19)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(595, 14)
        Me.LblTitle.TabIndex = 1
        Me.LblTitle.Text = "Please be careful, make sure all data already processed, before doing Month End C" & _
            "losing."
        '
        'btnProcess
        '
        Me.btnProcess.BackColor = System.Drawing.Color.Transparent
        Me.btnProcess.BackgroundImage = CType(resources.GetObject("btnProcess.BackgroundImage"), System.Drawing.Image)
        Me.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProcess.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcess.Image = CType(resources.GetObject("btnProcess.Image"), System.Drawing.Image)
        Me.btnProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcess.Location = New System.Drawing.Point(5, 195)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(127, 30)
        Me.btnProcess.TabIndex = 160
        Me.btnProcess.Text = "&Process"
        Me.btnProcess.UseVisualStyleBackColor = False
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
        Me.PnlSearch.Location = New System.Drawing.Point(5, 1)
        Me.PnlSearch.Moveable = True
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(782, 55)
        Me.PnlSearch.TabIndex = 161
        '
        'dgvTaskMonitor
        '
        Me.dgvTaskMonitor.AllowUserToAddRows = False
        Me.dgvTaskMonitor.AllowUserToDeleteRows = False
        Me.dgvTaskMonitor.AllowUserToOrderColumns = True
        Me.dgvTaskMonitor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTaskMonitor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTaskMonitor.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTaskMonitor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTaskMonitor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTaskMonitor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTaskMonitor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TASK, Me.Complete, Me.ModID, Me.ActiveMonthYearID, Me.EstateId})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTaskMonitor.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTaskMonitor.EnableHeadersVisualStyles = False
        Me.dgvTaskMonitor.GridColor = System.Drawing.Color.Gray
        Me.dgvTaskMonitor.Location = New System.Drawing.Point(5, 62)
        Me.dgvTaskMonitor.MultiSelect = False
        Me.dgvTaskMonitor.Name = "dgvTaskMonitor"
        Me.dgvTaskMonitor.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTaskMonitor.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTaskMonitor.RowHeadersVisible = False
        Me.dgvTaskMonitor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvTaskMonitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTaskMonitor.Size = New System.Drawing.Size(778, 127)
        Me.dgvTaskMonitor.TabIndex = 162
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
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(138, 195)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 30)
        Me.btnClose.TabIndex = 165
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'gbDetail
        '
        Me.gbDetail.BackColor = System.Drawing.Color.Transparent
        Me.gbDetail.Controls.Add(Me.dgvDistibutionDetails)
        Me.gbDetail.Controls.Add(Me.dgvAttendanceHarvNoReceiptionDetails)
        Me.gbDetail.Location = New System.Drawing.Point(12, 231)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(626, 256)
        Me.gbDetail.TabIndex = 166
        Me.gbDetail.TabStop = False
        Me.gbDetail.Visible = False
        '
        'dgvDistibutionDetails
        '
        Me.dgvDistibutionDetails.AllowUserToAddRows = False
        Me.dgvDistibutionDetails.AllowUserToDeleteRows = False
        Me.dgvDistibutionDetails.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvDistibutionDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDistibutionDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDistibutionDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDistibutionDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDistibutionDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvDistibutionDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDistibutionDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDistibutionDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDistibutionDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DARDateColumn, Me.DAGangNameColumn, Me.DAEmpCodeColumn, Me.DAEmpNameColumn, Me.DAAttendanceCodeColumn, Me.DADistributionSetupIDColumn})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDistibutionDetails.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDistibutionDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvDistibutionDetails.EnableHeadersVisualStyles = False
        Me.dgvDistibutionDetails.GridColor = System.Drawing.Color.Gray
        Me.dgvDistibutionDetails.Location = New System.Drawing.Point(13, 19)
        Me.dgvDistibutionDetails.MultiSelect = False
        Me.dgvDistibutionDetails.Name = "dgvDistibutionDetails"
        Me.dgvDistibutionDetails.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDistibutionDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDistibutionDetails.RowHeadersVisible = False
        Me.dgvDistibutionDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvDistibutionDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDistibutionDetails.ShowCellErrors = False
        Me.dgvDistibutionDetails.Size = New System.Drawing.Size(607, 241)
        Me.dgvDistibutionDetails.TabIndex = 7
        '
        'DARDateColumn
        '
        Me.DARDateColumn.DataPropertyName = "DistbDate"
        DataGridViewCellStyle6.Format = "dd/MM/yyyy"
        Me.DARDateColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.DARDateColumn.HeaderText = "Date"
        Me.DARDateColumn.Name = "DARDateColumn"
        Me.DARDateColumn.ReadOnly = True
        Me.DARDateColumn.Width = 58
        '
        'DAGangNameColumn
        '
        Me.DAGangNameColumn.DataPropertyName = "GangName"
        Me.DAGangNameColumn.HeaderText = "Team"
        Me.DAGangNameColumn.Name = "DAGangNameColumn"
        Me.DAGangNameColumn.ReadOnly = True
        Me.DAGangNameColumn.Width = 63
        '
        'DAEmpCodeColumn
        '
        Me.DAEmpCodeColumn.DataPropertyName = "TotalHK"
        Me.DAEmpCodeColumn.HeaderText = "Total HK"
        Me.DAEmpCodeColumn.Name = "DAEmpCodeColumn"
        Me.DAEmpCodeColumn.ReadOnly = True
        Me.DAEmpCodeColumn.Width = 79
        '
        'DAEmpNameColumn
        '
        Me.DAEmpNameColumn.DataPropertyName = "DistributedHK"
        Me.DAEmpNameColumn.HeaderText = "Distributed HK"
        Me.DAEmpNameColumn.Name = "DAEmpNameColumn"
        Me.DAEmpNameColumn.ReadOnly = True
        Me.DAEmpNameColumn.Width = 113
        '
        'DAAttendanceCodeColumn
        '
        Me.DAAttendanceCodeColumn.DataPropertyName = "TotalOT"
        Me.DAAttendanceCodeColumn.HeaderText = "Total OT"
        Me.DAAttendanceCodeColumn.Name = "DAAttendanceCodeColumn"
        Me.DAAttendanceCodeColumn.ReadOnly = True
        Me.DAAttendanceCodeColumn.Width = 79
        '
        'DADistributionSetupIDColumn
        '
        Me.DADistributionSetupIDColumn.DataPropertyName = "DistributedOT"
        Me.DADistributionSetupIDColumn.HeaderText = "Distributed OT"
        Me.DADistributionSetupIDColumn.Name = "DADistributionSetupIDColumn"
        Me.DADistributionSetupIDColumn.ReadOnly = True
        Me.DADistributionSetupIDColumn.Width = 113
        '
        'dgvAttendanceHarvNoReceiptionDetails
        '
        Me.dgvAttendanceHarvNoReceiptionDetails.AllowUserToAddRows = False
        Me.dgvAttendanceHarvNoReceiptionDetails.AllowUserToDeleteRows = False
        Me.dgvAttendanceHarvNoReceiptionDetails.AllowUserToOrderColumns = True
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvAttendanceHarvNoReceiptionDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvAttendanceHarvNoReceiptionDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAttendanceHarvNoReceiptionDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAttendanceHarvNoReceiptionDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvAttendanceHarvNoReceiptionDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvAttendanceHarvNoReceiptionDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAttendanceHarvNoReceiptionDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAttendanceHarvNoReceiptionDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvAttendanceHarvNoReceiptionDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAttendanceHarvNoReceiptionDetails.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvAttendanceHarvNoReceiptionDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvAttendanceHarvNoReceiptionDetails.EnableHeadersVisualStyles = False
        Me.dgvAttendanceHarvNoReceiptionDetails.GridColor = System.Drawing.Color.Gray
        Me.dgvAttendanceHarvNoReceiptionDetails.Location = New System.Drawing.Point(6, 9)
        Me.dgvAttendanceHarvNoReceiptionDetails.MultiSelect = False
        Me.dgvAttendanceHarvNoReceiptionDetails.Name = "dgvAttendanceHarvNoReceiptionDetails"
        Me.dgvAttendanceHarvNoReceiptionDetails.ReadOnly = True
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAttendanceHarvNoReceiptionDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvAttendanceHarvNoReceiptionDetails.RowHeadersVisible = False
        Me.dgvAttendanceHarvNoReceiptionDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvAttendanceHarvNoReceiptionDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAttendanceHarvNoReceiptionDetails.ShowCellErrors = False
        Me.dgvAttendanceHarvNoReceiptionDetails.Size = New System.Drawing.Size(601, 241)
        Me.dgvAttendanceHarvNoReceiptionDetails.TabIndex = 9
        Me.dgvAttendanceHarvNoReceiptionDetails.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "RDate"
        DataGridViewCellStyle11.Format = "dd/MM/yyyy"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 58
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "GangName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Team"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 63
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "EmpCode"
        Me.DataGridViewTextBoxColumn3.HeaderText = "NIK"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 52
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "EmpName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 64
        '
        'CheckrollMonthEndClosing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(858, 499)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvTaskMonitor)
        Me.Controls.Add(Me.PnlSearch)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.LblTitle)
        Me.Controls.Add(Me.LblMsg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CheckrollMonthEndClosing"
        Me.Text = "v"
        CType(Me.dgvTaskMonitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetail.ResumeLayout(False)
        CType(Me.dgvDistibutionDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAttendanceHarvNoReceiptionDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents dgvTaskMonitor As System.Windows.Forms.DataGridView
    Friend WithEvents TASK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Complete As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActiveMonthYearID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDistibutionDetails As System.Windows.Forms.DataGridView
    Friend WithEvents DARDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DAGangNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DAEmpCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DAEmpNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DAAttendanceCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DADistributionSetupIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvAttendanceHarvNoReceiptionDetails As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

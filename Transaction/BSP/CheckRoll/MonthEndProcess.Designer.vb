<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthEndProcess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MonthEndProcess))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grp1 = New System.Windows.Forms.GroupBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.EndDate = New System.Windows.Forms.DateTimePicker()
        Me.StartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDateProc = New System.Windows.Forms.DateTimePicker()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnProc = New System.Windows.Forms.Button()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.dgvDistibutionDetails = New System.Windows.Forms.DataGridView()
        Me.DARDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DAGangNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DAEmpCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DAEmpNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DAAttendanceCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DADistributionSetupIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvAttendanceHarvNoReceiptionDetails = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grp1.SuspendLayout()
        Me.gbDetail.SuspendLayout()
        CType(Me.dgvDistibutionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAttendanceHarvNoReceiptionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grp1
        '
        Me.Grp1.BackColor = System.Drawing.Color.Transparent
        Me.Grp1.Controls.Add(Me.LblStatus)
        Me.Grp1.Controls.Add(Me.Label5)
        Me.Grp1.Controls.Add(Me.EndDate)
        Me.Grp1.Controls.Add(Me.StartDate)
        Me.Grp1.Controls.Add(Me.Label3)
        Me.Grp1.Controls.Add(Me.Label4)
        Me.Grp1.Controls.Add(Me.Label2)
        Me.Grp1.Controls.Add(Me.Label1)
        Me.Grp1.Controls.Add(Me.dtpDateProc)
        Me.Grp1.Controls.Add(Me.btnClose)
        Me.Grp1.Controls.Add(Me.btnProc)
        Me.Grp1.Location = New System.Drawing.Point(8, 0)
        Me.Grp1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Grp1.Name = "Grp1"
        Me.Grp1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Grp1.Size = New System.Drawing.Size(939, 243)
        Me.Grp1.TabIndex = 161
        Me.Grp1.TabStop = False
        '
        'LblStatus
        '
        Me.LblStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.ForeColor = System.Drawing.Color.Black
        Me.LblStatus.Location = New System.Drawing.Point(12, 206)
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(898, 32)
        Me.LblStatus.TabIndex = 205
        Me.LblStatus.Text = "Period"
        Me.LblStatus.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(428, 42)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 20)
        Me.Label5.TabIndex = 204
        Me.Label5.Text = "to"
        '
        'EndDate
        '
        Me.EndDate.CustomFormat = "dd/MM/yyyy"
        Me.EndDate.Enabled = False
        Me.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EndDate.Location = New System.Drawing.Point(464, 38)
        Me.EndDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.EndDate.Name = "EndDate"
        Me.EndDate.Size = New System.Drawing.Size(200, 26)
        Me.EndDate.TabIndex = 203
        '
        'StartDate
        '
        Me.StartDate.CustomFormat = "dd/MM/yyyy"
        Me.StartDate.Enabled = False
        Me.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.StartDate.Location = New System.Drawing.Point(216, 38)
        Me.StartDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StartDate.Name = "StartDate"
        Me.StartDate.Size = New System.Drawing.Size(200, 26)
        Me.StartDate.TabIndex = 202
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(189, 42)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 20)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(27, 42)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 20)
        Me.Label4.TabIndex = 200
        Me.Label4.Text = "Period"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(189, 85)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 20)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 85)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 20)
        Me.Label1.TabIndex = 198
        Me.Label1.Text = "Processing Date "
        '
        'dtpDateProc
        '
        Me.dtpDateProc.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateProc.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateProc.Location = New System.Drawing.Point(216, 78)
        Me.dtpDateProc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpDateProc.Name = "dtpDateProc"
        Me.dtpDateProc.Size = New System.Drawing.Size(200, 26)
        Me.dtpDateProc.TabIndex = 197
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(216, 142)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(190, 46)
        Me.btnClose.TabIndex = 162
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
        Me.btnProc.Location = New System.Drawing.Point(16, 142)
        Me.btnProc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnProc.Name = "btnProc"
        Me.btnProc.Size = New System.Drawing.Size(190, 46)
        Me.btnProc.TabIndex = 159
        Me.btnProc.Text = "&Processing"
        Me.btnProc.UseVisualStyleBackColor = False
        '
        'gbDetail
        '
        Me.gbDetail.BackColor = System.Drawing.Color.Transparent
        Me.gbDetail.Controls.Add(Me.dgvDistibutionDetails)
        Me.gbDetail.Controls.Add(Me.dgvAttendanceHarvNoReceiptionDetails)
        Me.gbDetail.Location = New System.Drawing.Point(8, 280)
        Me.gbDetail.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbDetail.Size = New System.Drawing.Size(939, 431)
        Me.gbDetail.TabIndex = 162
        Me.gbDetail.TabStop = False
        Me.gbDetail.Visible = False
        '
        'dgvDistibutionDetails
        '
        Me.dgvDistibutionDetails.AllowUserToAddRows = False
        Me.dgvDistibutionDetails.AllowUserToDeleteRows = False
        Me.dgvDistibutionDetails.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvDistibutionDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDistibutionDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDistibutionDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDistibutionDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDistibutionDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvDistibutionDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDistibutionDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDistibutionDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDistibutionDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DARDateColumn, Me.DAGangNameColumn, Me.DAEmpCodeColumn, Me.DAEmpNameColumn, Me.DAAttendanceCodeColumn, Me.DADistributionSetupIDColumn})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDistibutionDetails.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDistibutionDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvDistibutionDetails.EnableHeadersVisualStyles = False
        Me.dgvDistibutionDetails.GridColor = System.Drawing.Color.Gray
        Me.dgvDistibutionDetails.Location = New System.Drawing.Point(28, 51)
        Me.dgvDistibutionDetails.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvDistibutionDetails.MultiSelect = False
        Me.dgvDistibutionDetails.Name = "dgvDistibutionDetails"
        Me.dgvDistibutionDetails.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDistibutionDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDistibutionDetails.RowHeadersVisible = False
        Me.dgvDistibutionDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvDistibutionDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDistibutionDetails.ShowCellErrors = False
        Me.dgvDistibutionDetails.Size = New System.Drawing.Size(902, 371)
        Me.dgvDistibutionDetails.TabIndex = 7
        Me.dgvDistibutionDetails.Visible = False
        '
        'DARDateColumn
        '
        Me.DARDateColumn.DataPropertyName = "DistbDate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        Me.DARDateColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DARDateColumn.HeaderText = "Date"
        Me.DARDateColumn.Name = "DARDateColumn"
        Me.DARDateColumn.ReadOnly = True
        Me.DARDateColumn.Width = 73
        '
        'DAGangNameColumn
        '
        Me.DAGangNameColumn.DataPropertyName = "GangName"
        Me.DAGangNameColumn.HeaderText = "Team"
        Me.DAGangNameColumn.Name = "DAGangNameColumn"
        Me.DAGangNameColumn.ReadOnly = True
        Me.DAGangNameColumn.Width = 78
        '
        'DAEmpCodeColumn
        '
        Me.DAEmpCodeColumn.DataPropertyName = "TotalHK"
        Me.DAEmpCodeColumn.HeaderText = "Total HK"
        Me.DAEmpCodeColumn.Name = "DAEmpCodeColumn"
        Me.DAEmpCodeColumn.ReadOnly = True
        Me.DAEmpCodeColumn.Width = 104
        '
        'DAEmpNameColumn
        '
        Me.DAEmpNameColumn.DataPropertyName = "DistributedHK"
        Me.DAEmpNameColumn.HeaderText = "Distributed HK"
        Me.DAEmpNameColumn.Name = "DAEmpNameColumn"
        Me.DAEmpNameColumn.ReadOnly = True
        Me.DAEmpNameColumn.Width = 160
        '
        'DAAttendanceCodeColumn
        '
        Me.DAAttendanceCodeColumn.DataPropertyName = "TotalOT"
        Me.DAAttendanceCodeColumn.HeaderText = "Total OT"
        Me.DAAttendanceCodeColumn.Name = "DAAttendanceCodeColumn"
        Me.DAAttendanceCodeColumn.ReadOnly = True
        Me.DAAttendanceCodeColumn.Width = 102
        '
        'DADistributionSetupIDColumn
        '
        Me.DADistributionSetupIDColumn.DataPropertyName = "DistributedOT"
        Me.DADistributionSetupIDColumn.HeaderText = "Distributed OT"
        Me.DADistributionSetupIDColumn.Name = "DADistributionSetupIDColumn"
        Me.DADistributionSetupIDColumn.ReadOnly = True
        Me.DADistributionSetupIDColumn.Width = 158
        '
        'dgvAttendanceHarvNoReceiptionDetails
        '
        Me.dgvAttendanceHarvNoReceiptionDetails.AllowUserToAddRows = False
        Me.dgvAttendanceHarvNoReceiptionDetails.AllowUserToDeleteRows = False
        Me.dgvAttendanceHarvNoReceiptionDetails.AllowUserToOrderColumns = True
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvAttendanceHarvNoReceiptionDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvAttendanceHarvNoReceiptionDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAttendanceHarvNoReceiptionDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAttendanceHarvNoReceiptionDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvAttendanceHarvNoReceiptionDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvAttendanceHarvNoReceiptionDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAttendanceHarvNoReceiptionDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAttendanceHarvNoReceiptionDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvAttendanceHarvNoReceiptionDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAttendanceHarvNoReceiptionDetails.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvAttendanceHarvNoReceiptionDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvAttendanceHarvNoReceiptionDetails.EnableHeadersVisualStyles = False
        Me.dgvAttendanceHarvNoReceiptionDetails.GridColor = System.Drawing.Color.Gray
        Me.dgvAttendanceHarvNoReceiptionDetails.Location = New System.Drawing.Point(16, 29)
        Me.dgvAttendanceHarvNoReceiptionDetails.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvAttendanceHarvNoReceiptionDetails.MultiSelect = False
        Me.dgvAttendanceHarvNoReceiptionDetails.Name = "dgvAttendanceHarvNoReceiptionDetails"
        Me.dgvAttendanceHarvNoReceiptionDetails.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAttendanceHarvNoReceiptionDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvAttendanceHarvNoReceiptionDetails.RowHeadersVisible = False
        Me.dgvAttendanceHarvNoReceiptionDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvAttendanceHarvNoReceiptionDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAttendanceHarvNoReceiptionDetails.ShowCellErrors = False
        Me.dgvAttendanceHarvNoReceiptionDetails.Size = New System.Drawing.Size(902, 371)
        Me.dgvAttendanceHarvNoReceiptionDetails.TabIndex = 8
        Me.dgvAttendanceHarvNoReceiptionDetails.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "RDate"
        DataGridViewCellStyle8.Format = "dd/MM/yyyy"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 73
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "GangName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Team"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 78
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "EmpCode"
        Me.DataGridViewTextBoxColumn3.HeaderText = "NIK"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 66
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "EmpName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 83
        '
        'MonthEndProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1248, 755)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.Grp1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "MonthEndProcess"
        Me.Text = "MonthEndProcess"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Grp1.ResumeLayout(False)
        Me.Grp1.PerformLayout()
        Me.gbDetail.ResumeLayout(False)
        CType(Me.dgvDistibutionDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAttendanceHarvNoReceiptionDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grp1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnProc As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dtpDateProc As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents EndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents StartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
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

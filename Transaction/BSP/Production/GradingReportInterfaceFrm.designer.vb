<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GradingReportInterfaceFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GradingReportInterfaceFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlGradingreport = New Stepi.UI.ExtendedPanel
        Me.txtWBTicketno = New System.Windows.Forms.TextBox
        Me.Chkdate = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblMonth = New System.Windows.Forms.Label
        Me.cbYear = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblYear = New System.Windows.Forms.Label
        Me.cbMonth = New System.Windows.Forms.ComboBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblWBTicketNo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblsearchBy = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.dgvGradingrpt = New System.Windows.Forms.DataGridView
        Me.WeighingID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActiveMonthYearID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WBTicketNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WeighingDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GradingDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewReport = New System.Windows.Forms.DataGridViewButtonColumn
        Me.pnlGradingreport.SuspendLayout()
        CType(Me.dgvGradingrpt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlGradingreport
        '
        Me.pnlGradingreport.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlGradingreport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlGradingreport.BorderColor = System.Drawing.Color.Gray
        Me.pnlGradingreport.CaptionColorOne = System.Drawing.Color.White
        Me.pnlGradingreport.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlGradingreport.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlGradingreport.CaptionSize = 40
        Me.pnlGradingreport.CaptionText = "Grading Report"
        Me.pnlGradingreport.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlGradingreport.Controls.Add(Me.txtWBTicketno)
        Me.pnlGradingreport.Controls.Add(Me.Chkdate)
        Me.pnlGradingreport.Controls.Add(Me.Label3)
        Me.pnlGradingreport.Controls.Add(Me.lblMonth)
        Me.pnlGradingreport.Controls.Add(Me.cbYear)
        Me.pnlGradingreport.Controls.Add(Me.Label4)
        Me.pnlGradingreport.Controls.Add(Me.lblYear)
        Me.pnlGradingreport.Controls.Add(Me.cbMonth)
        Me.pnlGradingreport.Controls.Add(Me.dtpDate)
        Me.pnlGradingreport.Controls.Add(Me.Label2)
        Me.pnlGradingreport.Controls.Add(Me.lblWBTicketNo)
        Me.pnlGradingreport.Controls.Add(Me.Label1)
        Me.pnlGradingreport.Controls.Add(Me.lblsearchBy)
        Me.pnlGradingreport.Controls.Add(Me.btnSearch)
        Me.pnlGradingreport.Controls.Add(Me.btnClose)
        Me.pnlGradingreport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlGradingreport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlGradingreport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlGradingreport.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGradingreport.ForeColor = System.Drawing.Color.Black
        Me.pnlGradingreport.Location = New System.Drawing.Point(0, 0)
        Me.pnlGradingreport.Name = "pnlGradingreport"
        Me.pnlGradingreport.Size = New System.Drawing.Size(1020, 179)
        Me.pnlGradingreport.TabIndex = 122
        '
        'txtWBTicketno
        '
        Me.txtWBTicketno.Location = New System.Drawing.Point(114, 127)
        Me.txtWBTicketno.Name = "txtWBTicketno"
        Me.txtWBTicketno.Size = New System.Drawing.Size(140, 20)
        Me.txtWBTicketno.TabIndex = 151
        '
        'Chkdate
        '
        Me.Chkdate.AutoSize = True
        Me.Chkdate.Location = New System.Drawing.Point(332, 127)
        Me.Chkdate.Name = "Chkdate"
        Me.Chkdate.Size = New System.Drawing.Size(89, 17)
        Me.Chkdate.TabIndex = 152
        Me.Chkdate.Text = "Grading Date"
        Me.Chkdate.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(418, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = ":"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.ForeColor = System.Drawing.Color.Black
        Me.lblMonth.Location = New System.Drawing.Point(50, 91)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(41, 13)
        Me.lblMonth.TabIndex = 146
        Me.lblMonth.Text = "Month"
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(431, 90)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(140, 21)
        Me.cbYear.TabIndex = 145
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(98, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = ":"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.Location = New System.Drawing.Point(387, 93)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(33, 13)
        Me.lblYear.TabIndex = 143
        Me.lblYear.Text = "Year"
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(114, 89)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(140, 21)
        Me.cbMonth.TabIndex = 142
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/mm/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(431, 125)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(140, 20)
        Me.dtpDate.TabIndex = 153
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(418, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = ":"
        '
        'lblWBTicketNo
        '
        Me.lblWBTicketNo.AutoSize = True
        Me.lblWBTicketNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWBTicketNo.ForeColor = System.Drawing.Color.Black
        Me.lblWBTicketNo.Location = New System.Drawing.Point(11, 126)
        Me.lblWBTicketNo.Name = "lblWBTicketNo"
        Me.lblWBTicketNo.Size = New System.Drawing.Size(83, 13)
        Me.lblWBTicketNo.TabIndex = 139
        Me.lblWBTicketNo.Text = "WB Ticket No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = ":"
        '
        'lblsearchBy
        '
        Me.lblsearchBy.AutoSize = True
        Me.lblsearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblsearchBy.Location = New System.Drawing.Point(10, 52)
        Me.lblsearchBy.Name = "lblsearchBy"
        Me.lblsearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchBy.TabIndex = 54
        Me.lblsearchBy.Text = "Search By"
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(606, 123)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(88, 25)
        Me.btnSearch.TabIndex = 154
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(700, 123)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(101, 25)
        Me.btnClose.TabIndex = 155
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dgvGradingrpt
        '
        Me.dgvGradingrpt.AllowUserToAddRows = False
        Me.dgvGradingrpt.AllowUserToDeleteRows = False
        Me.dgvGradingrpt.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvGradingrpt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGradingrpt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvGradingrpt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvGradingrpt.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvGradingrpt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvGradingrpt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGradingrpt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvGradingrpt.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WeighingID, Me.ActiveMonthYearID, Me.WBTicketNo, Me.WeighingDate, Me.GradingDate, Me.ViewReport})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGradingrpt.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvGradingrpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGradingrpt.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvGradingrpt.EnableHeadersVisualStyles = False
        Me.dgvGradingrpt.GridColor = System.Drawing.Color.Gray
        Me.dgvGradingrpt.Location = New System.Drawing.Point(0, 179)
        Me.dgvGradingrpt.Name = "dgvGradingrpt"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGradingrpt.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvGradingrpt.RowHeadersVisible = False
        Me.dgvGradingrpt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvGradingrpt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGradingrpt.ShowCellErrors = False
        Me.dgvGradingrpt.Size = New System.Drawing.Size(1020, 349)
        Me.dgvGradingrpt.TabIndex = 128
        '
        'WeighingID
        '
        Me.WeighingID.DataPropertyName = "WeighingID"
        Me.WeighingID.HeaderText = "WeighingID"
        Me.WeighingID.Name = "WeighingID"
        Me.WeighingID.Visible = False
        Me.WeighingID.Width = 97
        '
        'ActiveMonthYearID
        '
        Me.ActiveMonthYearID.DataPropertyName = "ActiveMonthYearID"
        Me.ActiveMonthYearID.HeaderText = "ActiveMonthYearID"
        Me.ActiveMonthYearID.Name = "ActiveMonthYearID"
        Me.ActiveMonthYearID.Visible = False
        Me.ActiveMonthYearID.Width = 140
        '
        'WBTicketNo
        '
        Me.WBTicketNo.DataPropertyName = "WBTicketNo"
        Me.WBTicketNo.HeaderText = "WBTicket No"
        Me.WBTicketNo.Name = "WBTicketNo"
        Me.WBTicketNo.Width = 103
        '
        'WeighingDate
        '
        Me.WeighingDate.DataPropertyName = "WeighingDate"
        Me.WeighingDate.HeaderText = "Weighing Date"
        Me.WeighingDate.Name = "WeighingDate"
        Me.WeighingDate.Width = 114
        '
        'GradingDate
        '
        Me.GradingDate.DataPropertyName = "GradingDate"
        Me.GradingDate.HeaderText = "Grading Date"
        Me.GradingDate.Name = "GradingDate"
        Me.GradingDate.Width = 107
        '
        'ViewReport
        '
        Me.ViewReport.HeaderText = "View Report"
        Me.ViewReport.Name = "ViewReport"
        Me.ViewReport.Text = "View Report"
        Me.ViewReport.UseColumnTextForButtonValue = True
        Me.ViewReport.Width = 81
        '
        'GradingReportInterfaceFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 528)
        Me.Controls.Add(Me.dgvGradingrpt)
        Me.Controls.Add(Me.pnlGradingreport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "GradingReportInterfaceFrm"
        Me.Text = "GradingReportInterfaceFrm"
        Me.pnlGradingreport.ResumeLayout(False)
        Me.pnlGradingreport.PerformLayout()
        CType(Me.dgvGradingrpt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblWBTicketNo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents Chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dgvGradingrpt As System.Windows.Forms.DataGridView
    Friend WithEvents txtWBTicketno As System.Windows.Forms.TextBox
    Friend WithEvents pnlGradingreport As Stepi.UI.ExtendedPanel
    Friend WithEvents WeighingID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActiveMonthYearID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WBTicketNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeighingDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GradingDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewReport As System.Windows.Forms.DataGridViewButtonColumn
End Class

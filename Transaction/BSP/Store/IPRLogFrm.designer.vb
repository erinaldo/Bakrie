<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IPRLogFrm
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IPRLogFrm))
        Me.plIPRView = New System.Windows.Forms.Panel()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvIRPView = New System.Windows.Forms.DataGridView()
        Me.IPRDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IPRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Person = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlCategorySearch = New Stepi.UI.ExtendedPanel()
        Me.chkIPRdate = New System.Windows.Forms.CheckBox()
        Me.lblsearchCategory = New System.Windows.Forms.Label()
        Me.txtviewIPRNo = New System.Windows.Forms.TextBox()
        Me.dtpIPRDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblviewIPRDate = New System.Windows.Forms.Label()
        Me.lblviewIPRno = New System.Windows.Forms.Label()
        Me.lblviewMainstatus = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.plIPRView.SuspendLayout()
        CType(Me.dgvIRPView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCategorySearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'plIPRView
        '
        Me.plIPRView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.plIPRView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plIPRView.Controls.Add(Me.lblView)
        Me.plIPRView.Controls.Add(Me.dgvIRPView)
        Me.plIPRView.Controls.Add(Me.pnlCategorySearch)
        Me.plIPRView.Dock = System.Windows.Forms.DockStyle.Top
        Me.plIPRView.Location = New System.Drawing.Point(0, 0)
        Me.plIPRView.Name = "plIPRView"
        Me.plIPRView.Size = New System.Drawing.Size(862, 485)
        Me.plIPRView.TabIndex = 46
        '
        'lblView
        '
        Me.lblView.AutoSize = True
        Me.lblView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblView.ForeColor = System.Drawing.Color.Red
        Me.lblView.Location = New System.Drawing.Point(126, 307)
        Me.lblView.Name = "lblView"
        Me.lblView.Size = New System.Drawing.Size(130, 13)
        Me.lblView.TabIndex = 118
        Me.lblView.Text = "Record not found !!"
        Me.lblView.Visible = False
        '
        'dgvIRPView
        '
        Me.dgvIRPView.AllowUserToAddRows = False
        Me.dgvIRPView.AllowUserToDeleteRows = False
        Me.dgvIRPView.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvIRPView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIRPView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvIRPView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvIRPView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIRPView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIRPView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIRPView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIRPView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IPRDate, Me.IPRNo, Me.Estate, Me.Status, Me.Person, Me.StatusDate})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIRPView.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvIRPView.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvIRPView.EnableHeadersVisualStyles = False
        Me.dgvIRPView.GridColor = System.Drawing.Color.Gray
        Me.dgvIRPView.Location = New System.Drawing.Point(0, 156)
        Me.dgvIRPView.Name = "dgvIRPView"
        Me.dgvIRPView.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIRPView.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvIRPView.RowHeadersVisible = False
        Me.dgvIRPView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        Me.dgvIRPView.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvIRPView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIRPView.ShowCellErrors = False
        Me.dgvIRPView.Size = New System.Drawing.Size(862, 326)
        Me.dgvIRPView.TabIndex = 6
        Me.dgvIRPView.TabStop = False
        '
        'IPRDate
        '
        Me.IPRDate.DataPropertyName = "IPRdate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.IPRDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.IPRDate.HeaderText = "PRDate"
        Me.IPRDate.Name = "IPRDate"
        Me.IPRDate.ReadOnly = True
        Me.IPRDate.Width = 73
        '
        'IPRNo
        '
        Me.IPRNo.DataPropertyName = "IPRNo"
        Me.IPRNo.HeaderText = "PRNo"
        Me.IPRNo.Name = "IPRNo"
        Me.IPRNo.ReadOnly = True
        Me.IPRNo.Width = 61
        '
        'Estate
        '
        Me.Estate.DataPropertyName = "EstateName"
        Me.Estate.HeaderText = "Estate"
        Me.Estate.Name = "Estate"
        Me.Estate.ReadOnly = True
        Me.Estate.Width = 66
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 67
        '
        'Person
        '
        Me.Person.DataPropertyName = "PersonName"
        Me.Person.HeaderText = "Person"
        Me.Person.Name = "Person"
        Me.Person.ReadOnly = True
        Me.Person.Width = 70
        '
        'StatusDate
        '
        Me.StatusDate.DataPropertyName = "StatusDate"
        DataGridViewCellStyle4.Format = "dd/MM/yyyy"
        Me.StatusDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.StatusDate.HeaderText = "Status Date"
        Me.StatusDate.Name = "StatusDate"
        Me.StatusDate.ReadOnly = True
        Me.StatusDate.Width = 98
        '
        'pnlCategorySearch
        '
        Me.pnlCategorySearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlCategorySearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCategorySearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlCategorySearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlCategorySearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlCategorySearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCategorySearch.CaptionSize = 40
        Me.pnlCategorySearch.CaptionText = "Search PR "
        Me.pnlCategorySearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Controls.Add(Me.chkIPRdate)
        Me.pnlCategorySearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlCategorySearch.Controls.Add(Me.txtviewIPRNo)
        Me.pnlCategorySearch.Controls.Add(Me.dtpIPRDate)
        Me.pnlCategorySearch.Controls.Add(Me.btnSearch)
        Me.pnlCategorySearch.Controls.Add(Me.lblviewIPRDate)
        Me.pnlCategorySearch.Controls.Add(Me.lblviewIPRno)
        Me.pnlCategorySearch.Controls.Add(Me.lblviewMainstatus)
        Me.pnlCategorySearch.Controls.Add(Me.cmbStatus)
        Me.pnlCategorySearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlCategorySearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlCategorySearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlCategorySearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCategorySearch.ForeColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategorySearch.Name = "pnlCategorySearch"
        Me.pnlCategorySearch.Size = New System.Drawing.Size(862, 156)
        Me.pnlCategorySearch.TabIndex = 116
        '
        'chkIPRdate
        '
        Me.chkIPRdate.AutoSize = True
        Me.chkIPRdate.Location = New System.Drawing.Point(37, 85)
        Me.chkIPRdate.Name = "chkIPRdate"
        Me.chkIPRdate.Size = New System.Drawing.Size(15, 14)
        Me.chkIPRdate.TabIndex = 1
        Me.chkIPRdate.UseVisualStyleBackColor = True
        '
        'lblsearchCategory
        '
        Me.lblsearchCategory.AutoSize = True
        Me.lblsearchCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchCategory.ForeColor = System.Drawing.Color.Black
        Me.lblsearchCategory.Location = New System.Drawing.Point(1, 41)
        Me.lblsearchCategory.Name = "lblsearchCategory"
        Me.lblsearchCategory.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchCategory.TabIndex = 54
        Me.lblsearchCategory.Text = "Search By"
        '
        'txtviewIPRNo
        '
        Me.txtviewIPRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewIPRNo.Location = New System.Drawing.Point(227, 110)
        Me.txtviewIPRNo.MaxLength = 50
        Me.txtviewIPRNo.Name = "txtviewIPRNo"
        Me.txtviewIPRNo.Size = New System.Drawing.Size(165, 20)
        Me.txtviewIPRNo.TabIndex = 3
        '
        'dtpIPRDate
        '
        Me.dtpIPRDate.Enabled = False
        Me.dtpIPRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIPRDate.Location = New System.Drawing.Point(37, 107)
        Me.dtpIPRDate.Name = "dtpIPRDate"
        Me.dtpIPRDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpIPRDate.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(610, 105)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblviewIPRDate
        '
        Me.lblviewIPRDate.AutoSize = True
        Me.lblviewIPRDate.ForeColor = System.Drawing.Color.Black
        Me.lblviewIPRDate.Location = New System.Drawing.Point(60, 85)
        Me.lblviewIPRDate.Name = "lblviewIPRDate"
        Me.lblviewIPRDate.Size = New System.Drawing.Size(51, 13)
        Me.lblviewIPRDate.TabIndex = 16
        Me.lblviewIPRDate.Text = "PR Date"
        '
        'lblviewIPRno
        '
        Me.lblviewIPRno.AutoSize = True
        Me.lblviewIPRno.ForeColor = System.Drawing.Color.Black
        Me.lblviewIPRno.Location = New System.Drawing.Point(227, 84)
        Me.lblviewIPRno.Name = "lblviewIPRno"
        Me.lblviewIPRno.Size = New System.Drawing.Size(42, 13)
        Me.lblviewIPRno.TabIndex = 17
        Me.lblviewIPRno.Text = "PR No"
        '
        'lblviewMainstatus
        '
        Me.lblviewMainstatus.AutoSize = True
        Me.lblviewMainstatus.ForeColor = System.Drawing.Color.Black
        Me.lblviewMainstatus.Location = New System.Drawing.Point(414, 85)
        Me.lblviewMainstatus.Name = "lblviewMainstatus"
        Me.lblviewMainstatus.Size = New System.Drawing.Size(37, 13)
        Me.lblviewMainstatus.TabIndex = 22
        Me.lblviewMainstatus.Text = "Status"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"OPEN", "MANAGER APPROVED", "EXPORTED", "CENTRAL EXPORTED", "REJECTED", "SELECT ALL"})
        Me.cmbStatus.Location = New System.Drawing.Point(414, 108)
        Me.cmbStatus.MaxLength = 50
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(165, 21)
        Me.cmbStatus.TabIndex = 4
        '
        'IPRLogFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(862, 489)
        Me.Controls.Add(Me.plIPRView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "IPRLogFrm"
        Me.Text = "IPRLogFrm"
        Me.plIPRView.ResumeLayout(False)
        Me.plIPRView.PerformLayout()
        CType(Me.dgvIRPView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCategorySearch.ResumeLayout(False)
        Me.pnlCategorySearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plIPRView As System.Windows.Forms.Panel
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents dgvIRPView As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCategorySearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents dtpIPRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewIPRDate As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblviewIPRno As System.Windows.Forms.Label
    Friend WithEvents txtviewIPRNo As System.Windows.Forms.TextBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblviewMainstatus As System.Windows.Forms.Label
    Friend WithEvents chkIPRdate As System.Windows.Forms.CheckBox
    Friend WithEvents IPRDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IPRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Person As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

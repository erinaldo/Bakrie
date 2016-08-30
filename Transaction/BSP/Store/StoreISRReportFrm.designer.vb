<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreISRReportFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StoreISRReportFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlISRSearch = New Stepi.UI.ExtendedPanel
        Me.btnClose = New System.Windows.Forms.Button
        Me.chkviewISRDate = New System.Windows.Forms.CheckBox
        Me.lblviewISRSearchBy = New System.Windows.Forms.Label
        Me.dtpviewISRDate = New System.Windows.Forms.DateTimePicker
        Me.lblviewISRDate = New System.Windows.Forms.Label
        Me.lblviewISRno = New System.Windows.Forms.Label
        Me.txtviewISRNo = New System.Windows.Forms.TextBox
        Me.btnviewISRSearch = New System.Windows.Forms.Button
        Me.dgvviewISR = New System.Windows.Forms.DataGridView
        Me.ISRDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ISRNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MakeModel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Engine = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChassisNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FixedAssetNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STISRID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActiveMonthYearID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Requiredfor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewReport = New System.Windows.Forms.DataGridViewButtonColumn
        Me.lblRecordNotFound = New System.Windows.Forms.Label
        Me.pnlISRSearch.SuspendLayout()
        CType(Me.dgvviewISR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlISRSearch
        '
        Me.pnlISRSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlISRSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlISRSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlISRSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlISRSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlISRSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlISRSearch.CaptionSize = 40
        Me.pnlISRSearch.CaptionText = "Search ISR "
        Me.pnlISRSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlISRSearch.Controls.Add(Me.btnClose)
        Me.pnlISRSearch.Controls.Add(Me.chkviewISRDate)
        Me.pnlISRSearch.Controls.Add(Me.lblviewISRSearchBy)
        Me.pnlISRSearch.Controls.Add(Me.dtpviewISRDate)
        Me.pnlISRSearch.Controls.Add(Me.lblviewISRDate)
        Me.pnlISRSearch.Controls.Add(Me.lblviewISRno)
        Me.pnlISRSearch.Controls.Add(Me.txtviewISRNo)
        Me.pnlISRSearch.Controls.Add(Me.btnviewISRSearch)
        Me.pnlISRSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlISRSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlISRSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlISRSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlISRSearch.ForeColor = System.Drawing.Color.Black
        Me.pnlISRSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlISRSearch.Name = "pnlISRSearch"
        Me.pnlISRSearch.Size = New System.Drawing.Size(791, 135)
        Me.pnlISRSearch.TabIndex = 117
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(593, 83)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 25)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'chkviewISRDate
        '
        Me.chkviewISRDate.AutoSize = True
        Me.chkviewISRDate.Location = New System.Drawing.Point(74, 64)
        Me.chkviewISRDate.Name = "chkviewISRDate"
        Me.chkviewISRDate.Size = New System.Drawing.Size(15, 14)
        Me.chkviewISRDate.TabIndex = 1
        Me.chkviewISRDate.UseVisualStyleBackColor = True
        '
        'lblviewISRSearchBy
        '
        Me.lblviewISRSearchBy.AutoSize = True
        Me.lblviewISRSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblviewISRSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewISRSearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblviewISRSearchBy.Location = New System.Drawing.Point(1, 41)
        Me.lblviewISRSearchBy.Name = "lblviewISRSearchBy"
        Me.lblviewISRSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblviewISRSearchBy.TabIndex = 54
        Me.lblviewISRSearchBy.Text = "Search By"
        '
        'dtpviewISRDate
        '
        Me.dtpviewISRDate.Enabled = False
        Me.dtpviewISRDate.Location = New System.Drawing.Point(74, 87)
        Me.dtpviewISRDate.Name = "dtpviewISRDate"
        Me.dtpviewISRDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpviewISRDate.TabIndex = 2
        '
        'lblviewISRDate
        '
        Me.lblviewISRDate.AutoSize = True
        Me.lblviewISRDate.ForeColor = System.Drawing.Color.Black
        Me.lblviewISRDate.Location = New System.Drawing.Point(90, 64)
        Me.lblviewISRDate.Name = "lblviewISRDate"
        Me.lblviewISRDate.Size = New System.Drawing.Size(51, 13)
        Me.lblviewISRDate.TabIndex = 27
        Me.lblviewISRDate.Text = "ISR Date"
        '
        'lblviewISRno
        '
        Me.lblviewISRno.AutoSize = True
        Me.lblviewISRno.ForeColor = System.Drawing.Color.Black
        Me.lblviewISRno.Location = New System.Drawing.Point(300, 64)
        Me.lblviewISRno.Name = "lblviewISRno"
        Me.lblviewISRno.Size = New System.Drawing.Size(45, 13)
        Me.lblviewISRno.TabIndex = 17
        Me.lblviewISRno.Text = "ISR No."
        '
        'txtviewISRNo
        '
        Me.txtviewISRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewISRNo.Location = New System.Drawing.Point(250, 87)
        Me.txtviewISRNo.MaxLength = 50
        Me.txtviewISRNo.Name = "txtviewISRNo"
        Me.txtviewISRNo.Size = New System.Drawing.Size(165, 20)
        Me.txtviewISRNo.TabIndex = 3
        '
        'btnviewISRSearch
        '
        Me.btnviewISRSearch.BackgroundImage = CType(resources.GetObject("btnviewISRSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnviewISRSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewISRSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewISRSearch.ForeColor = System.Drawing.Color.Black
        Me.btnviewISRSearch.Image = CType(resources.GetObject("btnviewISRSearch.Image"), System.Drawing.Image)
        Me.btnviewISRSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewISRSearch.Location = New System.Drawing.Point(450, 83)
        Me.btnviewISRSearch.Name = "btnviewISRSearch"
        Me.btnviewISRSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnviewISRSearch.TabIndex = 4
        Me.btnviewISRSearch.Text = "Search"
        Me.btnviewISRSearch.UseVisualStyleBackColor = True
        '
        'dgvviewISR
        '
        Me.dgvviewISR.AllowUserToAddRows = False
        Me.dgvviewISR.AllowUserToDeleteRows = False
        Me.dgvviewISR.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvviewISR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvviewISR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvviewISR.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvviewISR.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.dgvviewISR.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvviewISR.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvviewISR.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvviewISR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ISRDate, Me.ISRNo, Me.Supplier, Me.MakeModel, Me.Engine, Me.ChassisNo, Me.FixedAssetNo, Me.STISRID, Me.EstateID, Me.ActiveMonthYearID, Me.Requiredfor, Me.ViewReport})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvviewISR.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvviewISR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvviewISR.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvviewISR.EnableHeadersVisualStyles = False
        Me.dgvviewISR.GridColor = System.Drawing.Color.Gray
        Me.dgvviewISR.Location = New System.Drawing.Point(0, 135)
        Me.dgvviewISR.Name = "dgvviewISR"
        Me.dgvviewISR.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvviewISR.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvviewISR.RowHeadersVisible = False
        Me.dgvviewISR.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvviewISR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvviewISR.ShowCellErrors = False
        Me.dgvviewISR.Size = New System.Drawing.Size(791, 344)
        Me.dgvviewISR.TabIndex = 6
        Me.dgvviewISR.TabStop = False
        '
        'ISRDate
        '
        Me.ISRDate.DataPropertyName = "ISRDate"
        Me.ISRDate.HeaderText = "ISRDate"
        Me.ISRDate.Name = "ISRDate"
        Me.ISRDate.ReadOnly = True
        Me.ISRDate.Width = 79
        '
        'ISRNo
        '
        Me.ISRNo.DataPropertyName = "ISRNo"
        Me.ISRNo.HeaderText = "ISRNo"
        Me.ISRNo.Name = "ISRNo"
        Me.ISRNo.ReadOnly = True
        Me.ISRNo.Width = 67
        '
        'Supplier
        '
        Me.Supplier.DataPropertyName = "Supplier"
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.Name = "Supplier"
        Me.Supplier.ReadOnly = True
        Me.Supplier.Width = 78
        '
        'MakeModel
        '
        Me.MakeModel.DataPropertyName = "MakeModel"
        Me.MakeModel.HeaderText = "MakeModel"
        Me.MakeModel.Name = "MakeModel"
        Me.MakeModel.ReadOnly = True
        Me.MakeModel.Width = 94
        '
        'Engine
        '
        Me.Engine.DataPropertyName = "Engine"
        Me.Engine.HeaderText = "Engine"
        Me.Engine.Name = "Engine"
        Me.Engine.ReadOnly = True
        Me.Engine.Width = 69
        '
        'ChassisNo
        '
        Me.ChassisNo.DataPropertyName = "ChassisNo"
        Me.ChassisNo.HeaderText = "ChassisNo"
        Me.ChassisNo.Name = "ChassisNo"
        Me.ChassisNo.ReadOnly = True
        Me.ChassisNo.Width = 90
        '
        'FixedAssetNo
        '
        Me.FixedAssetNo.DataPropertyName = "FixedAssetNo"
        Me.FixedAssetNo.HeaderText = "FixedAssetNo"
        Me.FixedAssetNo.Name = "FixedAssetNo"
        Me.FixedAssetNo.ReadOnly = True
        Me.FixedAssetNo.Width = 107
        '
        'STISRID
        '
        Me.STISRID.DataPropertyName = "STISRID"
        Me.STISRID.HeaderText = "STISRID"
        Me.STISRID.Name = "STISRID"
        Me.STISRID.ReadOnly = True
        Me.STISRID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.STISRID.Visible = False
        Me.STISRID.Width = 81
        '
        'EstateID
        '
        Me.EstateID.DataPropertyName = "EstateID"
        Me.EstateID.HeaderText = "EstateID"
        Me.EstateID.Name = "EstateID"
        Me.EstateID.ReadOnly = True
        Me.EstateID.Visible = False
        Me.EstateID.Width = 80
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
        'Requiredfor
        '
        Me.Requiredfor.DataPropertyName = "RequiredFor"
        Me.Requiredfor.HeaderText = "RequiredFor"
        Me.Requiredfor.Name = "Requiredfor"
        Me.Requiredfor.ReadOnly = True
        Me.Requiredfor.Visible = False
        '
        'ViewReport
        '
        Me.ViewReport.DataPropertyName = "ViewReport"
        Me.ViewReport.HeaderText = "View Report"
        Me.ViewReport.Name = "ViewReport"
        Me.ViewReport.ReadOnly = True
        Me.ViewReport.Text = "View Report"
        Me.ViewReport.UseColumnTextForButtonValue = True
        Me.ViewReport.Width = 81
        '
        'lblRecordNotFound
        '
        Me.lblRecordNotFound.AutoSize = True
        Me.lblRecordNotFound.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lblRecordNotFound.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordNotFound.ForeColor = System.Drawing.Color.Red
        Me.lblRecordNotFound.Location = New System.Drawing.Point(274, 220)
        Me.lblRecordNotFound.Name = "lblRecordNotFound"
        Me.lblRecordNotFound.Size = New System.Drawing.Size(130, 13)
        Me.lblRecordNotFound.TabIndex = 120
        Me.lblRecordNotFound.Text = "Record not found !!"
        Me.lblRecordNotFound.Visible = False
        '
        'StoreISRReportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(791, 479)
        Me.Controls.Add(Me.lblRecordNotFound)
        Me.Controls.Add(Me.dgvviewISR)
        Me.Controls.Add(Me.pnlISRSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "StoreISRReportFrm"
        Me.Text = "StoreISRReportFrm"
        Me.pnlISRSearch.ResumeLayout(False)
        Me.pnlISRSearch.PerformLayout()
        CType(Me.dgvviewISR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlISRSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents chkviewISRDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblviewISRSearchBy As System.Windows.Forms.Label
    Friend WithEvents dtpviewISRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblviewISRDate As System.Windows.Forms.Label
    Friend WithEvents lblviewISRno As System.Windows.Forms.Label
    Friend WithEvents txtviewISRNo As System.Windows.Forms.TextBox
    Friend WithEvents btnviewISRSearch As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvviewISR As System.Windows.Forms.DataGridView
    Friend WithEvents ISRDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ISRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Supplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MakeModel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Engine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChassisNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FixedAssetNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STISRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActiveMonthYearID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Requiredfor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewReport As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lblRecordNotFound As System.Windows.Forms.Label
End Class

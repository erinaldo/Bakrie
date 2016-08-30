<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdviceofCPOLoadingRptFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdviceofCPOLoadingRptFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtBAPNo = New System.Windows.Forms.TextBox()
        Me.lblColon1 = New System.Windows.Forms.Label()
        Me.lblBAPNo = New System.Windows.Forms.Label()
        Me.plCPOSearch = New Stepi.UI.ExtendedPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkCPOdate = New System.Windows.Forms.CheckBox()
        Me.dtpCPODate = New System.Windows.Forms.DateTimePicker()
        Me.lblsearchBy = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvCPOLoading = New System.Windows.Forms.DataGridView()
        Me.dgclDispatchID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDispatchDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclBAPNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclShip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDOA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDOATime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDOL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDOLTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDCL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDCLTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDepartureDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgclDepartureTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ViewReport = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lblView = New System.Windows.Forms.Label()
        Me.plCPOSearch.SuspendLayout()
        CType(Me.dgvCPOLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(97, 102)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(34, 13)
        Me.lblDate.TabIndex = 10
        Me.lblDate.Text = "Date"
        '
        'txtBAPNo
        '
        Me.txtBAPNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBAPNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBAPNo.Location = New System.Drawing.Point(443, 98)
        Me.txtBAPNo.MaxLength = 50
        Me.txtBAPNo.Name = "txtBAPNo"
        Me.txtBAPNo.Size = New System.Drawing.Size(179, 21)
        Me.txtBAPNo.TabIndex = 136
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(420, 102)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(11, 13)
        Me.lblColon1.TabIndex = 136
        Me.lblColon1.Text = ":"
        '
        'lblBAPNo
        '
        Me.lblBAPNo.AutoSize = True
        Me.lblBAPNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBAPNo.ForeColor = System.Drawing.Color.Black
        Me.lblBAPNo.Location = New System.Drawing.Point(361, 102)
        Me.lblBAPNo.Name = "lblBAPNo"
        Me.lblBAPNo.Size = New System.Drawing.Size(53, 13)
        Me.lblBAPNo.TabIndex = 11
        Me.lblBAPNo.Text = "BAP No."
        '
        'plCPOSearch
        '
        Me.plCPOSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plCPOSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plCPOSearch.BorderColor = System.Drawing.Color.Gray
        Me.plCPOSearch.CaptionColorOne = System.Drawing.Color.White
        Me.plCPOSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plCPOSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plCPOSearch.CaptionSize = 40
        Me.plCPOSearch.CaptionText = "Advice of CPO Loading"
        Me.plCPOSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.plCPOSearch.Controls.Add(Me.Label1)
        Me.plCPOSearch.Controls.Add(Me.txtBAPNo)
        Me.plCPOSearch.Controls.Add(Me.chkCPOdate)
        Me.plCPOSearch.Controls.Add(Me.lblDate)
        Me.plCPOSearch.Controls.Add(Me.dtpCPODate)
        Me.plCPOSearch.Controls.Add(Me.lblsearchBy)
        Me.plCPOSearch.Controls.Add(Me.lblColon1)
        Me.plCPOSearch.Controls.Add(Me.btnClose)
        Me.plCPOSearch.Controls.Add(Me.lblBAPNo)
        Me.plCPOSearch.Controls.Add(Me.btnSearch)
        Me.plCPOSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plCPOSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plCPOSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plCPOSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.plCPOSearch.ForeColor = System.Drawing.Color.Black
        Me.plCPOSearch.Location = New System.Drawing.Point(0, 0)
        Me.plCPOSearch.Name = "plCPOSearch"
        Me.plCPOSearch.Size = New System.Drawing.Size(1022, 176)
        Me.plCPOSearch.TabIndex = 118
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(131, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = ":"
        '
        'chkCPOdate
        '
        Me.chkCPOdate.AutoSize = True
        Me.chkCPOdate.Location = New System.Drawing.Point(76, 101)
        Me.chkCPOdate.Name = "chkCPOdate"
        Me.chkCPOdate.Size = New System.Drawing.Size(15, 14)
        Me.chkCPOdate.TabIndex = 134
        Me.chkCPOdate.UseVisualStyleBackColor = True
        '
        'dtpCPODate
        '
        Me.dtpCPODate.Location = New System.Drawing.Point(148, 98)
        Me.dtpCPODate.Name = "dtpCPODate"
        Me.dtpCPODate.Size = New System.Drawing.Size(165, 20)
        Me.dtpCPODate.TabIndex = 135
        '
        'lblsearchBy
        '
        Me.lblsearchBy.AutoSize = True
        Me.lblsearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblsearchBy.Location = New System.Drawing.Point(1, 41)
        Me.lblsearchBy.Name = "lblsearchBy"
        Me.lblsearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchBy.TabIndex = 54
        Me.lblsearchBy.Text = "Search By"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(798, 134)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 25)
        Me.btnClose.TabIndex = 138
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(675, 134)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 137
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dgvCPOLoading
        '
        Me.dgvCPOLoading.AllowUserToAddRows = False
        Me.dgvCPOLoading.AllowUserToDeleteRows = False
        Me.dgvCPOLoading.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvCPOLoading.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCPOLoading.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCPOLoading.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCPOLoading.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCPOLoading.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCPOLoading.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCPOLoading.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCPOLoading.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclDispatchID, Me.dgclDispatchDate, Me.dgclBAPNo, Me.dgclShip, Me.dgclDOA, Me.dgclDOATime, Me.dgclDOL, Me.dgclDOLTime, Me.dgclDCL, Me.dgclDCLTime, Me.dgclDepartureDate, Me.DgclDepartureTime, Me.ViewReport})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCPOLoading.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCPOLoading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCPOLoading.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCPOLoading.EnableHeadersVisualStyles = False
        Me.dgvCPOLoading.GridColor = System.Drawing.Color.Gray
        Me.dgvCPOLoading.Location = New System.Drawing.Point(0, 176)
        Me.dgvCPOLoading.Name = "dgvCPOLoading"
        Me.dgvCPOLoading.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCPOLoading.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCPOLoading.RowHeadersVisible = False
        Me.dgvCPOLoading.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvCPOLoading.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCPOLoading.ShowCellErrors = False
        Me.dgvCPOLoading.Size = New System.Drawing.Size(1022, 343)
        Me.dgvCPOLoading.TabIndex = 127
        '
        'dgclDispatchID
        '
        Me.dgclDispatchID.DataPropertyName = "DispatchID"
        Me.dgclDispatchID.HeaderText = "DispatchID"
        Me.dgclDispatchID.Name = "dgclDispatchID"
        Me.dgclDispatchID.ReadOnly = True
        Me.dgclDispatchID.Visible = False
        Me.dgclDispatchID.Width = 94
        '
        'dgclDispatchDate
        '
        Me.dgclDispatchDate.DataPropertyName = "DispatchDate"
        Me.dgclDispatchDate.HeaderText = "Dispatch Date"
        Me.dgclDispatchDate.Name = "dgclDispatchDate"
        Me.dgclDispatchDate.ReadOnly = True
        Me.dgclDispatchDate.Width = 111
        '
        'dgclBAPNo
        '
        Me.dgclBAPNo.DataPropertyName = "BAPNo"
        Me.dgclBAPNo.HeaderText = "BAP No."
        Me.dgclBAPNo.Name = "dgclBAPNo"
        Me.dgclBAPNo.ReadOnly = True
        Me.dgclBAPNo.Width = 77
        '
        'dgclShip
        '
        Me.dgclShip.DataPropertyName = "ShipPontoon"
        Me.dgclShip.HeaderText = "Ship / Pontoon"
        Me.dgclShip.Name = "dgclShip"
        Me.dgclShip.ReadOnly = True
        Me.dgclShip.Width = 115
        '
        'dgclDOA
        '
        Me.dgclDOA.DataPropertyName = "DOA"
        Me.dgclDOA.HeaderText = "DOA "
        Me.dgclDOA.Name = "dgclDOA"
        Me.dgclDOA.ReadOnly = True
        Me.dgclDOA.Visible = False
        Me.dgclDOA.Width = 57
        '
        'dgclDOATime
        '
        Me.dgclDOATime.DataPropertyName = "DOATime"
        Me.dgclDOATime.HeaderText = "DOA Time"
        Me.dgclDOATime.Name = "dgclDOATime"
        Me.dgclDOATime.ReadOnly = True
        Me.dgclDOATime.Visible = False
        Me.dgclDOATime.Width = 89
        '
        'dgclDOL
        '
        Me.dgclDOL.DataPropertyName = "DOL"
        Me.dgclDOL.HeaderText = "DOL"
        Me.dgclDOL.Name = "dgclDOL"
        Me.dgclDOL.ReadOnly = True
        Me.dgclDOL.Visible = False
        Me.dgclDOL.Width = 55
        '
        'dgclDOLTime
        '
        Me.dgclDOLTime.DataPropertyName = "DOLTime"
        Me.dgclDOLTime.HeaderText = "DOL Time"
        Me.dgclDOLTime.Name = "dgclDOLTime"
        Me.dgclDOLTime.ReadOnly = True
        Me.dgclDOLTime.Visible = False
        Me.dgclDOLTime.Width = 87
        '
        'dgclDCL
        '
        Me.dgclDCL.DataPropertyName = "DCL"
        Me.dgclDCL.HeaderText = "DCL"
        Me.dgclDCL.Name = "dgclDCL"
        Me.dgclDCL.ReadOnly = True
        Me.dgclDCL.Visible = False
        Me.dgclDCL.Width = 55
        '
        'dgclDCLTime
        '
        Me.dgclDCLTime.DataPropertyName = "DCLTime"
        Me.dgclDCLTime.HeaderText = "DCL Time"
        Me.dgclDCLTime.Name = "dgclDCLTime"
        Me.dgclDCLTime.ReadOnly = True
        Me.dgclDCLTime.Visible = False
        Me.dgclDCLTime.Width = 87
        '
        'dgclDepartureDate
        '
        Me.dgclDepartureDate.DataPropertyName = "DepartureDate"
        Me.dgclDepartureDate.HeaderText = "Departure Date"
        Me.dgclDepartureDate.Name = "dgclDepartureDate"
        Me.dgclDepartureDate.ReadOnly = True
        Me.dgclDepartureDate.Visible = False
        Me.dgclDepartureDate.Width = 120
        '
        'DgclDepartureTime
        '
        Me.DgclDepartureTime.DataPropertyName = "DepartureTime"
        Me.DgclDepartureTime.HeaderText = "Departure Time"
        Me.DgclDepartureTime.Name = "DgclDepartureTime"
        Me.DgclDepartureTime.ReadOnly = True
        Me.DgclDepartureTime.Visible = False
        Me.DgclDepartureTime.Width = 121
        '
        'ViewReport
        '
        Me.ViewReport.HeaderText = "View Report"
        Me.ViewReport.Name = "ViewReport"
        Me.ViewReport.ReadOnly = True
        Me.ViewReport.Text = "View Report"
        Me.ViewReport.UseColumnTextForButtonValue = True
        Me.ViewReport.Width = 81
        '
        'lblView
        '
        Me.lblView.AutoSize = True
        Me.lblView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblView.ForeColor = System.Drawing.Color.Red
        Me.lblView.Location = New System.Drawing.Point(420, 296)
        Me.lblView.Name = "lblView"
        Me.lblView.Size = New System.Drawing.Size(130, 13)
        Me.lblView.TabIndex = 128
        Me.lblView.Text = "Record not found !!"
        Me.lblView.Visible = False
        '
        'AdviceofCPOLoadingRptFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1022, 519)
        Me.Controls.Add(Me.lblView)
        Me.Controls.Add(Me.dgvCPOLoading)
        Me.Controls.Add(Me.plCPOSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "AdviceofCPOLoadingRptFrm"
        Me.Text = "AdviceofCPOLoadingRptFrm"
        Me.plCPOSearch.ResumeLayout(False)
        Me.plCPOSearch.PerformLayout()
        CType(Me.dgvCPOLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents txtBAPNo As System.Windows.Forms.TextBox
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents lblBAPNo As System.Windows.Forms.Label
    Friend WithEvents plCPOSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents chkCPOdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpCPODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvCPOLoading As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgclDispatchID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDispatchDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBAPNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclShip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDOA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDOATime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDOL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDOLTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDCLTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDepartureDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgclDepartureTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewReport As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lblView As System.Windows.Forms.Label
End Class

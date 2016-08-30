<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReturnGoodsNoteApprovalFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReturnGoodsNoteApprovalFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PnlSearch = New Stepi.UI.ExtendedPanel()
        Me.chkViewRGNDate = New System.Windows.Forms.CheckBox()
        Me.dtpRGNDateSearch = New System.Windows.Forms.DateTimePicker()
        Me.txtRGNNoSearch = New System.Windows.Forms.TextBox()
        Me.lblSearchBy = New System.Windows.Forms.Label()
        Me.lblRGNNoSerach = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnViewReport = New System.Windows.Forms.Button()
        Me.PnlGrid = New System.Windows.Forms.Panel()
        Me.lblNoRecord = New System.Windows.Forms.Label()
        Me.dgViewRGN = New System.Windows.Forms.DataGridView()
        Me.dgclSIVNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRGNNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRGNDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRejectedStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclSTRGNID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclViewSTIssueID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclViewDetails = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PnlSearch.SuspendLayout()
        Me.PnlGrid.SuspendLayout()
        CType(Me.dgViewRGN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.PnlSearch.CaptionText = "Search Return To Store"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.chkViewRGNDate)
        Me.PnlSearch.Controls.Add(Me.dtpRGNDateSearch)
        Me.PnlSearch.Controls.Add(Me.txtRGNNoSearch)
        Me.PnlSearch.Controls.Add(Me.lblSearchBy)
        Me.PnlSearch.Controls.Add(Me.lblRGNNoSerach)
        Me.PnlSearch.Controls.Add(Me.btnSearch)
        Me.PnlSearch.Controls.Add(Me.btnViewReport)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(0, 0)
        Me.PnlSearch.Moveable = True
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(774, 111)
        Me.PnlSearch.TabIndex = 88
        '
        'chkViewRGNDate
        '
        Me.chkViewRGNDate.AutoSize = True
        Me.chkViewRGNDate.BackColor = System.Drawing.Color.Transparent
        Me.chkViewRGNDate.Location = New System.Drawing.Point(94, 63)
        Me.chkViewRGNDate.Name = "chkViewRGNDate"
        Me.chkViewRGNDate.Size = New System.Drawing.Size(76, 17)
        Me.chkViewRGNDate.TabIndex = 1
        Me.chkViewRGNDate.Text = "RTS Date"
        Me.chkViewRGNDate.UseVisualStyleBackColor = False
        '
        'dtpRGNDateSearch
        '
        Me.dtpRGNDateSearch.CalendarFont = New System.Drawing.Font("Verdana", 7.5!)
        Me.dtpRGNDateSearch.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtpRGNDateSearch.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.dtpRGNDateSearch.CustomFormat = "dd/MM/yyyy"
        Me.dtpRGNDateSearch.Enabled = False
        Me.dtpRGNDateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRGNDateSearch.Location = New System.Drawing.Point(94, 85)
        Me.dtpRGNDateSearch.Name = "dtpRGNDateSearch"
        Me.dtpRGNDateSearch.Size = New System.Drawing.Size(129, 20)
        Me.dtpRGNDateSearch.TabIndex = 2
        '
        'txtRGNNoSearch
        '
        Me.txtRGNNoSearch.Location = New System.Drawing.Point(229, 85)
        Me.txtRGNNoSearch.Name = "txtRGNNoSearch"
        Me.txtRGNNoSearch.Size = New System.Drawing.Size(129, 20)
        Me.txtRGNNoSearch.TabIndex = 3
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearchBy.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchBy.Location = New System.Drawing.Point(2, 45)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchBy.TabIndex = 69
        Me.lblSearchBy.Text = "Search By"
        '
        'lblRGNNoSerach
        '
        Me.lblRGNNoSerach.AutoSize = True
        Me.lblRGNNoSerach.BackColor = System.Drawing.Color.Transparent
        Me.lblRGNNoSerach.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblRGNNoSerach.ForeColor = System.Drawing.Color.Black
        Me.lblRGNNoSerach.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRGNNoSerach.Location = New System.Drawing.Point(229, 63)
        Me.lblRGNNoSerach.Name = "lblRGNNoSerach"
        Me.lblRGNNoSerach.Size = New System.Drawing.Size(51, 13)
        Me.lblRGNNoSerach.TabIndex = 74
        Me.lblRGNNoSerach.Text = "RTS No"
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearch.Location = New System.Drawing.Point(383, 76)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(116, 29)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnViewReport
        '
        Me.btnViewReport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.Image = CType(resources.GetObject("btnViewReport.Image"), System.Drawing.Image)
        Me.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewReport.Location = New System.Drawing.Point(508, 76)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(116, 29)
        Me.btnViewReport.TabIndex = 5
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        Me.btnViewReport.Visible = False
        '
        'PnlGrid
        '
        Me.PnlGrid.BackColor = System.Drawing.Color.Transparent
        Me.PnlGrid.Controls.Add(Me.lblNoRecord)
        Me.PnlGrid.Controls.Add(Me.dgViewRGN)
        Me.PnlGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlGrid.Location = New System.Drawing.Point(0, 111)
        Me.PnlGrid.Name = "PnlGrid"
        Me.PnlGrid.Size = New System.Drawing.Size(774, 380)
        Me.PnlGrid.TabIndex = 89
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(130, 137)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 112
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'dgViewRGN
        '
        Me.dgViewRGN.AllowUserToAddRows = False
        Me.dgViewRGN.AllowUserToDeleteRows = False
        Me.dgViewRGN.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgViewRGN.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgViewRGN.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgViewRGN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgViewRGN.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewRGN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgViewRGN.ColumnHeadersHeight = 30
        Me.dgViewRGN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclSIVNO, Me.dgclRGNNo, Me.dgclRGNDate, Me.dgclRemarks, Me.dgclStatus, Me.dgclRejectedStatus, Me.dgclSTRGNID, Me.dgclViewSTIssueID, Me.dgclViewDetails})
        Me.dgViewRGN.EnableHeadersVisualStyles = False
        Me.dgViewRGN.GridColor = System.Drawing.Color.Gray
        Me.dgViewRGN.Location = New System.Drawing.Point(5, 6)
        Me.dgViewRGN.MultiSelect = False
        Me.dgViewRGN.Name = "dgViewRGN"
        Me.dgViewRGN.ReadOnly = True
        Me.dgViewRGN.RowHeadersVisible = False
        Me.dgViewRGN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgViewRGN.Size = New System.Drawing.Size(757, 361)
        Me.dgViewRGN.TabIndex = 86
        Me.dgViewRGN.TabStop = False
        '
        'dgclSIVNO
        '
        Me.dgclSIVNO.DataPropertyName = "SIVNO"
        Me.dgclSIVNO.HeaderText = "SIV NO"
        Me.dgclSIVNO.Name = "dgclSIVNO"
        Me.dgclSIVNO.ReadOnly = True
        '
        'dgclRGNNo
        '
        Me.dgclRGNNo.DataPropertyName = "RGNNo"
        Me.dgclRGNNo.HeaderText = "RTS No"
        Me.dgclRGNNo.Name = "dgclRGNNo"
        Me.dgclRGNNo.ReadOnly = True
        '
        'dgclRGNDate
        '
        Me.dgclRGNDate.DataPropertyName = "RGNDate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgclRGNDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgclRGNDate.HeaderText = "RTS Date"
        Me.dgclRGNDate.Name = "dgclRGNDate"
        Me.dgclRGNDate.ReadOnly = True
        Me.dgclRGNDate.Width = 150
        '
        'dgclRemarks
        '
        Me.dgclRemarks.DataPropertyName = "Remarks"
        Me.dgclRemarks.HeaderText = "Remarks"
        Me.dgclRemarks.Name = "dgclRemarks"
        Me.dgclRemarks.ReadOnly = True
        Me.dgclRemarks.Width = 200
        '
        'dgclStatus
        '
        Me.dgclStatus.DataPropertyName = "Status"
        Me.dgclStatus.HeaderText = "Status"
        Me.dgclStatus.Name = "dgclStatus"
        Me.dgclStatus.ReadOnly = True
        '
        'dgclRejectedStatus
        '
        Me.dgclRejectedStatus.DataPropertyName = "RejectedStatus"
        Me.dgclRejectedStatus.HeaderText = "RejectedStatus"
        Me.dgclRejectedStatus.Name = "dgclRejectedStatus"
        Me.dgclRejectedStatus.ReadOnly = True
        Me.dgclRejectedStatus.Visible = False
        '
        'dgclSTRGNID
        '
        Me.dgclSTRGNID.DataPropertyName = "STRGNID"
        Me.dgclSTRGNID.HeaderText = "STRTSID"
        Me.dgclSTRGNID.Name = "dgclSTRGNID"
        Me.dgclSTRGNID.ReadOnly = True
        Me.dgclSTRGNID.Visible = False
        Me.dgclSTRGNID.Width = 150
        '
        'dgclViewSTIssueID
        '
        Me.dgclViewSTIssueID.DataPropertyName = "STIssueID"
        Me.dgclViewSTIssueID.HeaderText = "STIssueID"
        Me.dgclViewSTIssueID.Name = "dgclViewSTIssueID"
        Me.dgclViewSTIssueID.ReadOnly = True
        Me.dgclViewSTIssueID.Visible = False
        '
        'dgclViewDetails
        '
        Me.dgclViewDetails.DataPropertyName = "ViewDetails"
        Me.dgclViewDetails.HeaderText = "View Details"
        Me.dgclViewDetails.Name = "dgclViewDetails"
        Me.dgclViewDetails.ReadOnly = True
        Me.dgclViewDetails.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgclViewDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgclViewDetails.Width = 135
        '
        'ReturnGoodsNoteApprovalFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(774, 517)
        Me.Controls.Add(Me.PnlGrid)
        Me.Controls.Add(Me.PnlSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ReturnGoodsNoteApprovalFrm"
        Me.Text = "ReturnGoodsNoteApprovalFrm"
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.PnlGrid.ResumeLayout(False)
        Me.PnlGrid.PerformLayout()
        CType(Me.dgViewRGN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents dtpRGNDateSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRGNNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents lblRGNNoSerach As System.Windows.Forms.Label
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents PnlGrid As System.Windows.Forms.Panel
    Friend WithEvents dgViewRGN As System.Windows.Forms.DataGridView
    Friend WithEvents chkViewRGNDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents dgclSIVNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRGNNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRGNDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRejectedStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTRGNID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclViewSTIssueID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclViewDetails As System.Windows.Forms.DataGridViewButtonColumn
End Class

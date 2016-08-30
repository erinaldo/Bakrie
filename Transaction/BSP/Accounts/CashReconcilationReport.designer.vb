<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashReconcilationReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CashReconcilationReport))
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.gpCashHistory = New System.Windows.Forms.GroupBox
        Me.BtnHistoryDate = New System.Windows.Forms.Button
        Me.btnHistoryReport = New System.Windows.Forms.Button
        Me.ddlHistoryDate = New System.Windows.Forms.ComboBox
        Me.lblDate = New System.Windows.Forms.Label
        Me.ddlYear = New System.Windows.Forms.ComboBox
        Me.ddlMonth = New System.Windows.Forms.ComboBox
        Me.lblYear = New System.Windows.Forms.Label
        Me.lblmonth = New System.Windows.Forms.Label
        Me.GpCashReconcilation = New System.Windows.Forms.GroupBox
        Me.lblCashReconDate = New System.Windows.Forms.Label
        Me.dtpCashReconcilationDate = New System.Windows.Forms.DateTimePicker
        Me.chkConfirmation = New System.Windows.Forms.CheckBox
        Me.btnviewReport = New System.Windows.Forms.Button
        Me.PnlSearch.SuspendLayout()
        Me.gpCashHistory.SuspendLayout()
        Me.GpCashReconcilation.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlSearch
        '
        Me.PnlSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlSearch.BorderColor = System.Drawing.Color.Gray
        Me.PnlSearch.CaptionColorOne = System.Drawing.Color.White
        Me.PnlSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlSearch.CaptionSize = 40
        Me.PnlSearch.CaptionText = "Cash Reconciliation Report"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.gpCashHistory)
        Me.PnlSearch.Controls.Add(Me.GpCashReconcilation)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.ForeColor = System.Drawing.Color.Black
        Me.PnlSearch.Location = New System.Drawing.Point(0, 0)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(832, 526)
        Me.PnlSearch.TabIndex = 101
        '
        'gpCashHistory
        '
        Me.gpCashHistory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpCashHistory.Controls.Add(Me.BtnHistoryDate)
        Me.gpCashHistory.Controls.Add(Me.btnHistoryReport)
        Me.gpCashHistory.Controls.Add(Me.ddlHistoryDate)
        Me.gpCashHistory.Controls.Add(Me.lblDate)
        Me.gpCashHistory.Controls.Add(Me.ddlYear)
        Me.gpCashHistory.Controls.Add(Me.ddlMonth)
        Me.gpCashHistory.Controls.Add(Me.lblYear)
        Me.gpCashHistory.Controls.Add(Me.lblmonth)
        Me.gpCashHistory.ForeColor = System.Drawing.Color.Black
        Me.gpCashHistory.Location = New System.Drawing.Point(42, 188)
        Me.gpCashHistory.Name = "gpCashHistory"
        Me.gpCashHistory.Size = New System.Drawing.Size(732, 165)
        Me.gpCashHistory.TabIndex = 221
        Me.gpCashHistory.TabStop = False
        Me.gpCashHistory.Text = "Cash Reconciliation History "
        '
        'BtnHistoryDate
        '
        Me.BtnHistoryDate.BackgroundImage = CType(resources.GetObject("BtnHistoryDate.BackgroundImage"), System.Drawing.Image)
        Me.BtnHistoryDate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnHistoryDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHistoryDate.ForeColor = System.Drawing.Color.Black
        Me.BtnHistoryDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnHistoryDate.Location = New System.Drawing.Point(531, 27)
        Me.BtnHistoryDate.Name = "BtnHistoryDate"
        Me.BtnHistoryDate.Size = New System.Drawing.Size(102, 25)
        Me.BtnHistoryDate.TabIndex = 109
        Me.BtnHistoryDate.Text = "Get Date"
        Me.BtnHistoryDate.UseVisualStyleBackColor = True
        '
        'btnHistoryReport
        '
        Me.btnHistoryReport.BackgroundImage = CType(resources.GetObject("btnHistoryReport.BackgroundImage"), System.Drawing.Image)
        Me.btnHistoryReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnHistoryReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistoryReport.ForeColor = System.Drawing.Color.Black
        Me.btnHistoryReport.Image = CType(resources.GetObject("btnHistoryReport.Image"), System.Drawing.Image)
        Me.btnHistoryReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHistoryReport.Location = New System.Drawing.Point(403, 88)
        Me.btnHistoryReport.Name = "btnHistoryReport"
        Me.btnHistoryReport.Size = New System.Drawing.Size(122, 25)
        Me.btnHistoryReport.TabIndex = 111
        Me.btnHistoryReport.Text = "View Report"
        Me.btnHistoryReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHistoryReport.UseVisualStyleBackColor = True
        '
        'ddlHistoryDate
        '
        Me.ddlHistoryDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlHistoryDate.FormattingEnabled = True
        Me.ddlHistoryDate.Items.AddRange(New Object() {"Select All", "OPEN", "APPROVED"})
        Me.ddlHistoryDate.Location = New System.Drawing.Point(181, 90)
        Me.ddlHistoryDate.Name = "ddlHistoryDate"
        Me.ddlHistoryDate.Size = New System.Drawing.Size(192, 21)
        Me.ddlHistoryDate.TabIndex = 110
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDate.Location = New System.Drawing.Point(125, 94)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(38, 13)
        Me.lblDate.TabIndex = 220
        Me.lblDate.Text = "Date "
        '
        'ddlYear
        '
        Me.ddlYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlYear.FormattingEnabled = True
        Me.ddlYear.Location = New System.Drawing.Point(69, 29)
        Me.ddlYear.Name = "ddlYear"
        Me.ddlYear.Size = New System.Drawing.Size(192, 21)
        Me.ddlYear.TabIndex = 107
        '
        'ddlMonth
        '
        Me.ddlMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlMonth.FormattingEnabled = True
        Me.ddlMonth.Items.AddRange(New Object() {"Select All", "OPEN", "APPROVED"})
        Me.ddlMonth.Location = New System.Drawing.Point(333, 29)
        Me.ddlMonth.Name = "ddlMonth"
        Me.ddlMonth.Size = New System.Drawing.Size(192, 21)
        Me.ddlMonth.TabIndex = 108
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.BackColor = System.Drawing.Color.Transparent
        Me.lblYear.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblYear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblYear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblYear.Location = New System.Drawing.Point(18, 33)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(33, 13)
        Me.lblYear.TabIndex = 219
        Me.lblYear.Text = "Year"
        '
        'lblmonth
        '
        Me.lblmonth.AutoSize = True
        Me.lblmonth.BackColor = System.Drawing.Color.Transparent
        Me.lblmonth.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblmonth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblmonth.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblmonth.Location = New System.Drawing.Point(267, 33)
        Me.lblmonth.Name = "lblmonth"
        Me.lblmonth.Size = New System.Drawing.Size(41, 13)
        Me.lblmonth.TabIndex = 120
        Me.lblmonth.Text = "Month"
        '
        'GpCashReconcilation
        '
        Me.GpCashReconcilation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GpCashReconcilation.Controls.Add(Me.lblCashReconDate)
        Me.GpCashReconcilation.Controls.Add(Me.dtpCashReconcilationDate)
        Me.GpCashReconcilation.Controls.Add(Me.chkConfirmation)
        Me.GpCashReconcilation.Controls.Add(Me.btnviewReport)
        Me.GpCashReconcilation.Location = New System.Drawing.Point(42, 55)
        Me.GpCashReconcilation.Name = "GpCashReconcilation"
        Me.GpCashReconcilation.Size = New System.Drawing.Size(732, 108)
        Me.GpCashReconcilation.TabIndex = 220
        Me.GpCashReconcilation.TabStop = False
        Me.GpCashReconcilation.Text = "Cash Reconciliation"
        '
        'lblCashReconDate
        '
        Me.lblCashReconDate.AutoSize = True
        Me.lblCashReconDate.BackColor = System.Drawing.Color.Transparent
        Me.lblCashReconDate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblCashReconDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCashReconDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCashReconDate.Location = New System.Drawing.Point(6, 35)
        Me.lblCashReconDate.Name = "lblCashReconDate"
        Me.lblCashReconDate.Size = New System.Drawing.Size(146, 13)
        Me.lblCashReconDate.TabIndex = 216
        Me.lblCashReconDate.Text = "Cash Reconciliation Date"
        '
        'dtpCashReconcilationDate
        '
        Me.dtpCashReconcilationDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpCashReconcilationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCashReconcilationDate.Location = New System.Drawing.Point(173, 31)
        Me.dtpCashReconcilationDate.Name = "dtpCashReconcilationDate"
        Me.dtpCashReconcilationDate.Size = New System.Drawing.Size(192, 21)
        Me.dtpCashReconcilationDate.TabIndex = 104
        '
        'chkConfirmation
        '
        Me.chkConfirmation.AutoSize = True
        Me.chkConfirmation.Location = New System.Drawing.Point(401, 34)
        Me.chkConfirmation.Name = "chkConfirmation"
        Me.chkConfirmation.Size = New System.Drawing.Size(265, 17)
        Me.chkConfirmation.TabIndex = 105
        Me.chkConfirmation.Text = " check this to confirm Cash Reconciliation "
        Me.chkConfirmation.UseVisualStyleBackColor = True
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(243, 77)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(122, 25)
        Me.btnviewReport.TabIndex = 106
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'CashReconcilationReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(832, 527)
        Me.Controls.Add(Me.PnlSearch)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "CashReconcilationReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CashReconcilationReport"
        Me.PnlSearch.ResumeLayout(False)
        Me.gpCashHistory.ResumeLayout(False)
        Me.gpCashHistory.PerformLayout()
        Me.GpCashReconcilation.ResumeLayout(False)
        Me.GpCashReconcilation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents ddlMonth As System.Windows.Forms.ComboBox
    Friend WithEvents lblCashReconDate As System.Windows.Forms.Label
    Friend WithEvents ddlYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblmonth As System.Windows.Forms.Label
    Friend WithEvents chkConfirmation As System.Windows.Forms.CheckBox
    Friend WithEvents dtpCashReconcilationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents gpCashHistory As System.Windows.Forms.GroupBox
    Friend WithEvents GpCashReconcilation As System.Windows.Forms.GroupBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents BtnHistoryDate As System.Windows.Forms.Button
    Friend WithEvents btnHistoryReport As System.Windows.Forms.Button
    Friend WithEvents ddlHistoryDate As System.Windows.Forms.ComboBox
End Class

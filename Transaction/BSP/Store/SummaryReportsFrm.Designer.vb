<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SummaryReportsFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SummaryReportsFrm))
        Me.pnlSummaryrpts = New Stepi.UI.ExtendedPanel
        Me.cbMonth = New System.Windows.Forms.ComboBox
        Me.rbITININSummary = New System.Windows.Forms.RadioButton
        Me.rbRGNSummary = New System.Windows.Forms.RadioButton
        Me.rbAdjustmentSummary = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.rbIDNSummary = New System.Windows.Forms.RadioButton
        Me.rbITNOUTSummary = New System.Windows.Forms.RadioButton
        Me.lblMonth = New System.Windows.Forms.Label
        Me.cbYear = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblYear = New System.Windows.Forms.Label
        Me.lblsearchBy = New System.Windows.Forms.Label
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.pnlSummaryrpts.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSummaryrpts
        '
        Me.pnlSummaryrpts.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSummaryrpts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSummaryrpts.BorderColor = System.Drawing.Color.Gray
        Me.pnlSummaryrpts.CaptionColorOne = System.Drawing.Color.White
        Me.pnlSummaryrpts.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSummaryrpts.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSummaryrpts.CaptionSize = 40
        Me.pnlSummaryrpts.CaptionText = "Summary Reports"
        Me.pnlSummaryrpts.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSummaryrpts.Controls.Add(Me.cbMonth)
        Me.pnlSummaryrpts.Controls.Add(Me.rbITININSummary)
        Me.pnlSummaryrpts.Controls.Add(Me.rbRGNSummary)
        Me.pnlSummaryrpts.Controls.Add(Me.rbAdjustmentSummary)
        Me.pnlSummaryrpts.Controls.Add(Me.Label2)
        Me.pnlSummaryrpts.Controls.Add(Me.rbIDNSummary)
        Me.pnlSummaryrpts.Controls.Add(Me.rbITNOUTSummary)
        Me.pnlSummaryrpts.Controls.Add(Me.lblMonth)
        Me.pnlSummaryrpts.Controls.Add(Me.cbYear)
        Me.pnlSummaryrpts.Controls.Add(Me.Label1)
        Me.pnlSummaryrpts.Controls.Add(Me.lblYear)
        Me.pnlSummaryrpts.Controls.Add(Me.lblsearchBy)
        Me.pnlSummaryrpts.Controls.Add(Me.btnReport)
        Me.pnlSummaryrpts.Controls.Add(Me.btnClose)
        Me.pnlSummaryrpts.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSummaryrpts.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSummaryrpts.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSummaryrpts.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSummaryrpts.ForeColor = System.Drawing.Color.Black
        Me.pnlSummaryrpts.Location = New System.Drawing.Point(0, 0)
        Me.pnlSummaryrpts.Name = "pnlSummaryrpts"
        Me.pnlSummaryrpts.Size = New System.Drawing.Size(899, 229)
        Me.pnlSummaryrpts.TabIndex = 119
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(78, 87)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(140, 21)
        Me.cbMonth.TabIndex = 0
        '
        'rbITININSummary
        '
        Me.rbITININSummary.AutoSize = True
        Me.rbITININSummary.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbITININSummary.Location = New System.Drawing.Point(175, 153)
        Me.rbITININSummary.Name = "rbITININSummary"
        Me.rbITININSummary.Size = New System.Drawing.Size(127, 17)
        Me.rbITININSummary.TabIndex = 4
        Me.rbITININSummary.TabStop = True
        Me.rbITININSummary.Text = "ITIN IN Summary"
        Me.rbITININSummary.UseVisualStyleBackColor = True
        '
        'rbRGNSummary
        '
        Me.rbRGNSummary.AutoSize = True
        Me.rbRGNSummary.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRGNSummary.Location = New System.Drawing.Point(603, 153)
        Me.rbRGNSummary.Name = "rbRGNSummary"
        Me.rbRGNSummary.Size = New System.Drawing.Size(110, 17)
        Me.rbRGNSummary.TabIndex = 7
        Me.rbRGNSummary.TabStop = True
        Me.rbRGNSummary.Text = "RTS Summary"
        Me.rbRGNSummary.UseVisualStyleBackColor = True
        '
        'rbAdjustmentSummary
        '
        Me.rbAdjustmentSummary.AutoSize = True
        Me.rbAdjustmentSummary.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAdjustmentSummary.Location = New System.Drawing.Point(447, 153)
        Me.rbAdjustmentSummary.Name = "rbAdjustmentSummary"
        Me.rbAdjustmentSummary.Size = New System.Drawing.Size(150, 17)
        Me.rbAdjustmentSummary.TabIndex = 6
        Me.rbAdjustmentSummary.TabStop = True
        Me.rbAdjustmentSummary.Text = "Adjustment Summary"
        Me.rbAdjustmentSummary.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(307, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = ":"
        '
        'rbIDNSummary
        '
        Me.rbIDNSummary.AutoSize = True
        Me.rbIDNSummary.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIDNSummary.Location = New System.Drawing.Point(61, 151)
        Me.rbIDNSummary.Name = "rbIDNSummary"
        Me.rbIDNSummary.Size = New System.Drawing.Size(107, 17)
        Me.rbIDNSummary.TabIndex = 3
        Me.rbIDNSummary.TabStop = True
        Me.rbIDNSummary.Text = "DN Summary"
        Me.rbIDNSummary.UseVisualStyleBackColor = True
        '
        'rbITNOUTSummary
        '
        Me.rbITNOUTSummary.AutoSize = True
        Me.rbITNOUTSummary.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbITNOUTSummary.Location = New System.Drawing.Point(310, 153)
        Me.rbITNOUTSummary.Name = "rbITNOUTSummary"
        Me.rbITNOUTSummary.Size = New System.Drawing.Size(133, 17)
        Me.rbITNOUTSummary.TabIndex = 5
        Me.rbITNOUTSummary.TabStop = True
        Me.rbITNOUTSummary.Text = "TN OUT Summary"
        Me.rbITNOUTSummary.UseVisualStyleBackColor = True
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.ForeColor = System.Drawing.Color.Black
        Me.lblMonth.Location = New System.Drawing.Point(10, 90)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(41, 13)
        Me.lblMonth.TabIndex = 139
        Me.lblMonth.Text = "Month"
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(320, 89)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(140, 21)
        Me.cbYear.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = ":"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.Location = New System.Drawing.Point(269, 92)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(33, 13)
        Me.lblYear.TabIndex = 10
        Me.lblYear.Text = "Year"
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
        'btnReport
        '
        Me.btnReport.BackgroundImage = CType(resources.GetObject("btnReport.BackgroundImage"), System.Drawing.Image)
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.Color.Black
        Me.btnReport.Image = CType(resources.GetObject("btnReport.Image"), System.Drawing.Image)
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(596, 183)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(122, 25)
        Me.btnReport.TabIndex = 8
        Me.btnReport.Text = "View Reports"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(724, 183)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(101, 25)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'SummaryReportsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(899, 474)
        Me.Controls.Add(Me.pnlSummaryrpts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "SummaryReportsFrm"
        Me.Text = "Summary Reports "
        Me.pnlSummaryrpts.ResumeLayout(False)
        Me.pnlSummaryrpts.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSummaryrpts As Stepi.UI.ExtendedPanel
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents rbRGNSummary As System.Windows.Forms.RadioButton
    Friend WithEvents rbAdjustmentSummary As System.Windows.Forms.RadioButton
    Friend WithEvents rbITNOUTSummary As System.Windows.Forms.RadioButton
    Friend WithEvents rbITININSummary As System.Windows.Forms.RadioButton
    Friend WithEvents rbIDNSummary As System.Windows.Forms.RadioButton
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionKCPReportFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionKCPReportFrm))
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblsearchBy = New System.Windows.Forms.Label
        Me.lblYear = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.plReport = New Stepi.UI.ExtendedPanel
        Me.cbMonth = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblMonth = New System.Windows.Forms.Label
        Me.cbYear = New System.Windows.Forms.ComboBox
        Me.plReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnReport
        '
        Me.btnReport.BackgroundImage = CType(resources.GetObject("btnReport.BackgroundImage"), System.Drawing.Image)
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.Color.Black
        Me.btnReport.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(153, 144)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(138, 25)
        Me.btnReport.TabIndex = 143
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
        Me.btnClose.Location = New System.Drawing.Point(334, 144)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(126, 25)
        Me.btnClose.TabIndex = 144
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblsearchBy
        '
        Me.lblsearchBy.AutoSize = True
        Me.lblsearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblsearchBy.Location = New System.Drawing.Point(7, 41)
        Me.lblsearchBy.Name = "lblsearchBy"
        Me.lblsearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchBy.TabIndex = 54
        Me.lblsearchBy.Text = "Search By"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.Location = New System.Drawing.Point(271, 102)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(33, 13)
        Me.lblYear.TabIndex = 10
        Me.lblYear.Text = "Year"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = ":"
        '
        'plReport
        '
        Me.plReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plReport.BorderColor = System.Drawing.Color.Gray
        Me.plReport.CaptionColorOne = System.Drawing.Color.White
        Me.plReport.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plReport.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plReport.CaptionSize = 40
        Me.plReport.CaptionText = "PRODUCTION KCP REPORTS"
        Me.plReport.CaptionTextColor = System.Drawing.Color.Black
        Me.plReport.Controls.Add(Me.cbMonth)
        Me.plReport.Controls.Add(Me.Label2)
        Me.plReport.Controls.Add(Me.lblMonth)
        Me.plReport.Controls.Add(Me.cbYear)
        Me.plReport.Controls.Add(Me.Label1)
        Me.plReport.Controls.Add(Me.lblYear)
        Me.plReport.Controls.Add(Me.lblsearchBy)
        Me.plReport.Controls.Add(Me.btnClose)
        Me.plReport.Controls.Add(Me.btnReport)
        Me.plReport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plReport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plReport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.plReport.ForeColor = System.Drawing.Color.Black
        Me.plReport.Location = New System.Drawing.Point(0, 0)
        Me.plReport.Name = "plReport"
        Me.plReport.Size = New System.Drawing.Size(791, 176)
        Me.plReport.TabIndex = 118
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(78, 99)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(140, 21)
        Me.cbMonth.TabIndex = 141
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(308, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = ":"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.ForeColor = System.Drawing.Color.Black
        Me.lblMonth.Location = New System.Drawing.Point(10, 102)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(41, 13)
        Me.lblMonth.TabIndex = 139
        Me.lblMonth.Text = "Month"
        '
        'cbYear
        '
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(321, 99)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(140, 21)
        Me.cbYear.TabIndex = 142
        '
        'ProductionKCPReportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(791, 519)
        Me.Controls.Add(Me.plReport)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ProductionKCPReportFrm"
        Me.Text = "AdviceofCPOLoadingRptFrm"
        Me.plReport.ResumeLayout(False)
        Me.plReport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents plReport As Stepi.UI.ExtendedPanel
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
End Class

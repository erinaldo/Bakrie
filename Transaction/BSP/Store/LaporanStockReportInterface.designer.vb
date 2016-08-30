<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LaporanStockReportInterface
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LaporanStockReportInterface))
        Me.pnlLaporanstockRpt = New Stepi.UI.ExtendedPanel
        Me.Chkzeroqtystock = New System.Windows.Forms.CheckBox
        Me.cbMonth = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblMonth = New System.Windows.Forms.Label
        Me.cbYear = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblYear = New System.Windows.Forms.Label
        Me.lblsearchBy = New System.Windows.Forms.Label
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.pnlLaporanstockRpt.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLaporanstockRpt
        '
        Me.pnlLaporanstockRpt.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlLaporanstockRpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlLaporanstockRpt.BorderColor = System.Drawing.Color.Gray
        Me.pnlLaporanstockRpt.CaptionColorOne = System.Drawing.Color.White
        Me.pnlLaporanstockRpt.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlLaporanstockRpt.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlLaporanstockRpt.CaptionSize = 40
        Me.pnlLaporanstockRpt.CaptionText = "Laporan Stock Report"
        Me.pnlLaporanstockRpt.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlLaporanstockRpt.Controls.Add(Me.Chkzeroqtystock)
        Me.pnlLaporanstockRpt.Controls.Add(Me.cbMonth)
        Me.pnlLaporanstockRpt.Controls.Add(Me.Label2)
        Me.pnlLaporanstockRpt.Controls.Add(Me.lblMonth)
        Me.pnlLaporanstockRpt.Controls.Add(Me.cbYear)
        Me.pnlLaporanstockRpt.Controls.Add(Me.Label1)
        Me.pnlLaporanstockRpt.Controls.Add(Me.lblYear)
        Me.pnlLaporanstockRpt.Controls.Add(Me.lblsearchBy)
        Me.pnlLaporanstockRpt.Controls.Add(Me.btnReport)
        Me.pnlLaporanstockRpt.Controls.Add(Me.btnClose)
        Me.pnlLaporanstockRpt.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlLaporanstockRpt.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlLaporanstockRpt.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlLaporanstockRpt.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLaporanstockRpt.ForeColor = System.Drawing.Color.Black
        Me.pnlLaporanstockRpt.Location = New System.Drawing.Point(0, 0)
        Me.pnlLaporanstockRpt.Name = "pnlLaporanstockRpt"
        Me.pnlLaporanstockRpt.Size = New System.Drawing.Size(887, 198)
        Me.pnlLaporanstockRpt.TabIndex = 121
        '
        'Chkzeroqtystock
        '
        Me.Chkzeroqtystock.AutoSize = True
        Me.Chkzeroqtystock.Location = New System.Drawing.Point(496, 92)
        Me.Chkzeroqtystock.Name = "Chkzeroqtystock"
        Me.Chkzeroqtystock.Size = New System.Drawing.Size(134, 17)
        Me.Chkzeroqtystock.TabIndex = 143
        Me.Chkzeroqtystock.Text = "Include Zero qty Stock"
        Me.Chkzeroqtystock.UseVisualStyleBackColor = True
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(78, 87)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(140, 21)
        Me.cbMonth.TabIndex = 141
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
        Me.cbYear.TabIndex = 142
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
        Me.btnReport.Location = New System.Drawing.Point(596, 157)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(122, 25)
        Me.btnReport.TabIndex = 144
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
        Me.btnClose.Location = New System.Drawing.Point(724, 157)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(101, 25)
        Me.btnClose.TabIndex = 154
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'LaporanStockReportInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(887, 406)
        Me.Controls.Add(Me.pnlLaporanstockRpt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "LaporanStockReportInterface"
        Me.Text = "LaporanStockReportInterface"
        Me.pnlLaporanstockRpt.ResumeLayout(False)
        Me.pnlLaporanstockRpt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLaporanstockRpt As Stepi.UI.ExtendedPanel
    Friend WithEvents Chkzeroqtystock As System.Windows.Forms.CheckBox
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleRunningExpenditureReportFrm2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VehicleRunningExpenditureReportFrm2))
        Me.pnlVehicleRunningExpenditureReport = New Stepi.UI.ExtendedPanel()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblsearchBy = New System.Windows.Forms.Label()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lstDetailCostCode = New System.Windows.Forms.ListBox()
        Me.pnlVehicleRunningExpenditureReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlVehicleRunningExpenditureReport
        '
        Me.pnlVehicleRunningExpenditureReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlVehicleRunningExpenditureReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlVehicleRunningExpenditureReport.BorderColor = System.Drawing.Color.Gray
        Me.pnlVehicleRunningExpenditureReport.CaptionColorOne = System.Drawing.Color.White
        Me.pnlVehicleRunningExpenditureReport.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlVehicleRunningExpenditureReport.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlVehicleRunningExpenditureReport.CaptionSize = 40
        Me.pnlVehicleRunningExpenditureReport.CaptionText = "Vehicle Running Expenditure Report"
        Me.pnlVehicleRunningExpenditureReport.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlVehicleRunningExpenditureReport.Controls.Add(Me.lstDetailCostCode)
        Me.pnlVehicleRunningExpenditureReport.Controls.Add(Me.cbMonth)
        Me.pnlVehicleRunningExpenditureReport.Controls.Add(Me.Label2)
        Me.pnlVehicleRunningExpenditureReport.Controls.Add(Me.lblMonth)
        Me.pnlVehicleRunningExpenditureReport.Controls.Add(Me.cbYear)
        Me.pnlVehicleRunningExpenditureReport.Controls.Add(Me.Label1)
        Me.pnlVehicleRunningExpenditureReport.Controls.Add(Me.lblYear)
        Me.pnlVehicleRunningExpenditureReport.Controls.Add(Me.lblsearchBy)
        Me.pnlVehicleRunningExpenditureReport.Controls.Add(Me.btnReport)
        Me.pnlVehicleRunningExpenditureReport.Controls.Add(Me.btnClose)
        Me.pnlVehicleRunningExpenditureReport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlVehicleRunningExpenditureReport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlVehicleRunningExpenditureReport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlVehicleRunningExpenditureReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVehicleRunningExpenditureReport.ForeColor = System.Drawing.Color.Black
        Me.pnlVehicleRunningExpenditureReport.Location = New System.Drawing.Point(0, 0)
        Me.pnlVehicleRunningExpenditureReport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlVehicleRunningExpenditureReport.Name = "pnlVehicleRunningExpenditureReport"
        Me.pnlVehicleRunningExpenditureReport.Size = New System.Drawing.Size(1368, 459)
        Me.pnlVehicleRunningExpenditureReport.TabIndex = 121
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(117, 134)
        Me.cbMonth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(208, 28)
        Me.cbMonth.TabIndex = 141
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(460, 142)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 20)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = ":"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.ForeColor = System.Drawing.Color.Black
        Me.lblMonth.Location = New System.Drawing.Point(15, 138)
        Me.lblMonth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(62, 20)
        Me.lblMonth.TabIndex = 139
        Me.lblMonth.Text = "Month"
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(480, 137)
        Me.cbYear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(208, 28)
        Me.cbYear.TabIndex = 142
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(87, 138)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 20)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = ":"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.Location = New System.Drawing.Point(404, 142)
        Me.lblYear.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(45, 20)
        Me.lblYear.TabIndex = 10
        Me.lblYear.Text = "Year"
        '
        'lblsearchBy
        '
        Me.lblsearchBy.AutoSize = True
        Me.lblsearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblsearchBy.Location = New System.Drawing.Point(15, 80)
        Me.lblsearchBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsearchBy.Name = "lblsearchBy"
        Me.lblsearchBy.Size = New System.Drawing.Size(103, 20)
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
        Me.btnReport.Location = New System.Drawing.Point(743, 370)
        Me.btnReport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(183, 38)
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
        Me.btnClose.Location = New System.Drawing.Point(935, 370)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(152, 38)
        Me.btnClose.TabIndex = 144
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lstDetailCostCode
        '
        Me.lstDetailCostCode.FormattingEnabled = True
        Me.lstDetailCostCode.ItemHeight = 20
        Me.lstDetailCostCode.Location = New System.Drawing.Point(117, 174)
        Me.lstDetailCostCode.Name = "lstDetailCostCode"
        Me.lstDetailCostCode.Size = New System.Drawing.Size(571, 244)
        Me.lstDetailCostCode.TabIndex = 145
        '
        'VehicleRunningExpenditureReportFrm2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1368, 698)
        Me.Controls.Add(Me.pnlVehicleRunningExpenditureReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "VehicleRunningExpenditureReportFrm2"
        Me.Text = "VehicleRunningExpenditureReportFrm"
        Me.pnlVehicleRunningExpenditureReport.ResumeLayout(False)
        Me.pnlVehicleRunningExpenditureReport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlVehicleRunningExpenditureReport As Stepi.UI.ExtendedPanel
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lstDetailCostCode As System.Windows.Forms.ListBox
End Class

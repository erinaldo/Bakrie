<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthGradingInterfaceFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MonthGradingInterfaceFrm))
        Me.pnlmonthgrading = New Stepi.UI.ExtendedPanel
        Me.cbMonth = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblMonth = New System.Windows.Forms.Label
        Me.cbYear = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblYear = New System.Windows.Forms.Label
        Me.lblsearchBy = New System.Windows.Forms.Label
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.pnlmonthgrading.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlmonthgrading
        '
        Me.pnlmonthgrading.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlmonthgrading.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlmonthgrading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlmonthgrading.BorderColor = System.Drawing.Color.Gray
        Me.pnlmonthgrading.CaptionColorOne = System.Drawing.Color.White
        Me.pnlmonthgrading.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlmonthgrading.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlmonthgrading.CaptionSize = 40
        Me.pnlmonthgrading.CaptionText = "Monthly Grading Report"
        Me.pnlmonthgrading.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlmonthgrading.Controls.Add(Me.cbMonth)
        Me.pnlmonthgrading.Controls.Add(Me.Label1)
        Me.pnlmonthgrading.Controls.Add(Me.lblMonth)
        Me.pnlmonthgrading.Controls.Add(Me.cbYear)
        Me.pnlmonthgrading.Controls.Add(Me.Label5)
        Me.pnlmonthgrading.Controls.Add(Me.lblYear)
        Me.pnlmonthgrading.Controls.Add(Me.lblsearchBy)
        Me.pnlmonthgrading.Controls.Add(Me.btnReport)
        Me.pnlmonthgrading.Controls.Add(Me.btnClose)
        Me.pnlmonthgrading.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlmonthgrading.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlmonthgrading.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlmonthgrading.ForeColor = System.Drawing.Color.Black
        Me.pnlmonthgrading.Location = New System.Drawing.Point(0, 0)
        Me.pnlmonthgrading.Name = "pnlmonthgrading"
        Me.pnlmonthgrading.Size = New System.Drawing.Size(910, 166)
        Me.pnlmonthgrading.TabIndex = 122
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(91, 86)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(163, 21)
        Me.cbMonth.TabIndex = 141
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(358, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = ":"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.ForeColor = System.Drawing.Color.Black
        Me.lblMonth.Location = New System.Drawing.Point(12, 90)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(41, 13)
        Me.lblMonth.TabIndex = 139
        Me.lblMonth.Text = "Month"
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(373, 86)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(163, 21)
        Me.cbYear.TabIndex = 142
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(68, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = ":"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.Location = New System.Drawing.Point(314, 90)
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
        Me.lblsearchBy.Location = New System.Drawing.Point(12, 52)
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
        Me.btnReport.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(585, 84)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(142, 25)
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
        Me.btnClose.Location = New System.Drawing.Point(734, 84)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(118, 25)
        Me.btnClose.TabIndex = 144
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'MonthGradingInterfaceFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(911, 502)
        Me.Controls.Add(Me.pnlmonthgrading)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "MonthGradingInterfaceFrm"
        Me.Text = "MonthGradingInterfaceFrm"
        Me.pnlmonthgrading.ResumeLayout(False)
        Me.pnlmonthgrading.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlmonthgrading As Stepi.UI.ExtendedPanel
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyCostingRpt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DailyCostingRpt))
        Me.plReport = New Stepi.UI.ExtendedPanel()
        Me.rdKHL = New System.Windows.Forms.RadioButton()
        Me.rdKHT = New System.Windows.Forms.RadioButton()
        Me.lblsearchBy = New System.Windows.Forms.Label()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.plReport.SuspendLayout()
        Me.SuspendLayout()
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
        Me.plReport.CaptionText = "Daily Costing Report KHT/KHL "
        Me.plReport.CaptionTextColor = System.Drawing.Color.Black
        Me.plReport.Controls.Add(Me.rdKHL)
        Me.plReport.Controls.Add(Me.rdKHT)
        Me.plReport.Controls.Add(Me.lblsearchBy)
        Me.plReport.Controls.Add(Me.btnReport)
        Me.plReport.Controls.Add(Me.Label5)
        Me.plReport.Controls.Add(Me.dtEndDate)
        Me.plReport.Controls.Add(Me.dtStartDate)
        Me.plReport.Controls.Add(Me.Label3)
        Me.plReport.Controls.Add(Me.Label4)
        Me.plReport.Controls.Add(Me.btnClose)
        Me.plReport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plReport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plReport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.plReport.ForeColor = System.Drawing.Color.Black
        Me.plReport.Location = New System.Drawing.Point(0, 0)
        Me.plReport.Name = "plReport"
        Me.plReport.Size = New System.Drawing.Size(687, 193)
        Me.plReport.TabIndex = 121
        '
        'rdKHL
        '
        Me.rdKHL.AutoSize = True
        Me.rdKHL.Location = New System.Drawing.Point(88, 66)
        Me.rdKHL.Name = "rdKHL"
        Me.rdKHL.Size = New System.Drawing.Size(47, 17)
        Me.rdKHL.TabIndex = 222
        Me.rdKHL.Text = "KHL"
        Me.rdKHL.UseVisualStyleBackColor = True
        Me.rdKHL.Visible = False
        '
        'rdKHT
        '
        Me.rdKHT.AutoSize = True
        Me.rdKHT.Checked = True
        Me.rdKHT.Location = New System.Drawing.Point(10, 66)
        Me.rdKHT.Name = "rdKHT"
        Me.rdKHT.Size = New System.Drawing.Size(48, 17)
        Me.rdKHT.TabIndex = 221
        Me.rdKHT.TabStop = True
        Me.rdKHT.Text = "KHT"
        Me.rdKHT.UseVisualStyleBackColor = True
        Me.rdKHT.Visible = False
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
        Me.lblsearchBy.TabIndex = 220
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
        Me.btnReport.Location = New System.Drawing.Point(174, 143)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(118, 25)
        Me.btnReport.TabIndex = 112
        Me.btnReport.Text = "View Reports"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(274, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 13)
        Me.Label5.TabIndex = 219
        Me.Label5.Text = "to"
        '
        'dtEndDate
        '
        Me.dtEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtEndDate.Enabled = False
        Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEndDate.Location = New System.Drawing.Point(298, 99)
        Me.dtEndDate.Name = "dtEndDate"
        Me.dtEndDate.Size = New System.Drawing.Size(135, 21)
        Me.dtEndDate.TabIndex = 218
        '
        'dtStartDate
        '
        Me.dtStartDate.CustomFormat = "dd/MM/yyyy"
        Me.dtStartDate.Enabled = False
        Me.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtStartDate.Location = New System.Drawing.Point(133, 99)
        Me.dtStartDate.Name = "dtStartDate"
        Me.dtStartDate.Size = New System.Drawing.Size(135, 21)
        Me.dtStartDate.TabIndex = 217
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(115, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 13)
        Me.Label3.TabIndex = 216
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(7, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 215
        Me.Label4.Text = "Period"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(298, 143)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(102, 25)
        Me.btnClose.TabIndex = 118
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'DailyCostingRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(687, 415)
        Me.Controls.Add(Me.plReport)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DailyCostingRpt"
        Me.Text = "DailyCostingRpt"
        Me.plReport.ResumeLayout(False)
        Me.plReport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plReport As Stepi.UI.ExtendedPanel
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents rdKHL As System.Windows.Forms.RadioButton
    Friend WithEvents rdKHT As System.Windows.Forms.RadioButton
End Class

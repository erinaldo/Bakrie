<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PieceRateTransactionRptFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PieceRateTransactionRptFrm))
        Me.plReport = New Stepi.UI.ExtendedPanel()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblsearchBy = New System.Windows.Forms.Label()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.plReport.CaptionText = "Piece Rate Transaction Report"
        Me.plReport.CaptionTextColor = System.Drawing.Color.Black
        Me.plReport.Controls.Add(Me.dtpDateTo)
        Me.plReport.Controls.Add(Me.Label1)
        Me.plReport.Controls.Add(Me.Label3)
        Me.plReport.Controls.Add(Me.dtpDate)
        Me.plReport.Controls.Add(Me.Label2)
        Me.plReport.Controls.Add(Me.lblYear)
        Me.plReport.Controls.Add(Me.lblsearchBy)
        Me.plReport.Controls.Add(Me.btnReport)
        Me.plReport.Controls.Add(Me.btnClose)
        Me.plReport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plReport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plReport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.plReport.ForeColor = System.Drawing.Color.Black
        Me.plReport.Location = New System.Drawing.Point(0, 0)
        Me.plReport.Name = "plReport"
        Me.plReport.Size = New System.Drawing.Size(582, 154)
        Me.plReport.TabIndex = 121
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(71, 74)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpDate.TabIndex = 142
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = ":"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.Location = New System.Drawing.Point(17, 77)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(36, 13)
        Me.lblYear.TabIndex = 10
        Me.lblYear.Text = "From"
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
        'btnReport
        '
        Me.btnReport.BackgroundImage = CType(resources.GetObject("btnReport.BackgroundImage"), System.Drawing.Image)
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.Color.Black
        Me.btnReport.Image = CType(resources.GetObject("btnReport.Image"), System.Drawing.Image)
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(153, 117)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(118, 25)
        Me.btnReport.TabIndex = 112
        Me.btnReport.Text = "View Report"
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
        Me.btnClose.Location = New System.Drawing.Point(277, 117)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(102, 25)
        Me.btnClose.TabIndex = 118
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(341, 74)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateTo.TabIndex = 145
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(324, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(287, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "To"
        '
        'PieceRateTransactionRptFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(582, 158)
        Me.Controls.Add(Me.plReport)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PieceRateTransactionRptFrm"
        Me.Text = "PieceRateTransactionRptFrm"
        Me.plReport.ResumeLayout(False)
        Me.plReport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plReport As Stepi.UI.ExtendedPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class

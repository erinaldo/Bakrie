<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KeraniPanenForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KeraniPanenForm))
        Me.plReport = New Stepi.UI.ExtendedPanel()
        Me.dpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
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
        Me.plReport.CaptionText = "Kerani Panen Form"
        Me.plReport.CaptionTextColor = System.Drawing.Color.Black
        Me.plReport.Controls.Add(Me.dpDate)
        Me.plReport.Controls.Add(Me.Label1)
        Me.plReport.Controls.Add(Me.lblDate)
        Me.plReport.Controls.Add(Me.btnClose)
        Me.plReport.Controls.Add(Me.btnReport)
        Me.plReport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plReport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plReport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.plReport.ForeColor = System.Drawing.Color.Black
        Me.plReport.Location = New System.Drawing.Point(0, 0)
        Me.plReport.Name = "plReport"
        Me.plReport.Size = New System.Drawing.Size(881, 334)
        Me.plReport.TabIndex = 122
        '
        'dpDate
        '
        Me.dpDate.CustomFormat = "dd/MM/yyyy"
        Me.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpDate.Location = New System.Drawing.Point(93, 73)
        Me.dpDate.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.dpDate.Name = "dpDate"
        Me.dpDate.Size = New System.Drawing.Size(240, 21)
        Me.dpDate.TabIndex = 144
        Me.dpDate.Value = New Date(2013, 3, 5, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(76, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = ":"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(22, 79)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(53, 13)
        Me.lblDate.TabIndex = 10
        Me.lblDate.Text = "By Date"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(231, 112)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(102, 25)
        Me.btnClose.TabIndex = 155
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.BackgroundImage = CType(resources.GetObject("btnReport.BackgroundImage"), System.Drawing.Image)
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.Color.Black
        Me.btnReport.Image = CType(resources.GetObject("btnReport.Image"), System.Drawing.Image)
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(93, 112)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(118, 25)
        Me.btnReport.TabIndex = 154
        Me.btnReport.Text = "View Reports"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'KeraniPanenForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(881, 355)
        Me.Controls.Add(Me.plReport)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "KeraniPanenForm"
        Me.Text = "Kerani Panen Form"
        Me.plReport.ResumeLayout(False)
        Me.plReport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plReport As Stepi.UI.ExtendedPanel
    Friend WithEvents dpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReport As System.Windows.Forms.Button
End Class

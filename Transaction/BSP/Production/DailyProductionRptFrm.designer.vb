<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyProductionRptFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DailyProductionRptFrm))
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.btnClose = New System.Windows.Forms.Button
        Me.PnlSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlSearch
        '
        Me.PnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlSearch.BorderColor = System.Drawing.Color.Gray
        Me.PnlSearch.CaptionColorOne = System.Drawing.Color.White
        Me.PnlSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlSearch.CaptionSize = 40
        Me.PnlSearch.CaptionText = "Daily Production Report CPO"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.btnClose)
        Me.PnlSearch.Controls.Add(Me.btnViewReport)
        Me.PnlSearch.Controls.Add(Me.dtpDate)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.ForeColor = System.Drawing.Color.Black
        Me.PnlSearch.Location = New System.Drawing.Point(0, 0)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(847, 118)
        Me.PnlSearch.TabIndex = 117
        '
        'btnViewReport
        '
        Me.btnViewReport.BackgroundImage = CType(resources.GetObject("btnViewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.ForeColor = System.Drawing.Color.Black
        Me.btnViewReport.Image = CType(resources.GetObject("btnViewReport.Image"), System.Drawing.Image)
        Me.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewReport.Location = New System.Drawing.Point(192, 57)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(142, 25)
        Me.btnViewReport.TabIndex = 104
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(10, 61)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(163, 21)
        Me.dtpDate.TabIndex = 102
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(350, 57)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 25)
        Me.btnClose.TabIndex = 143
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'DailyProductionRptFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(847, 121)
        Me.Controls.Add(Me.PnlSearch)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "DailyProductionRptFrm"
        Me.Text = "Dispatch Analysis And Stock"
        Me.PnlSearch.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class

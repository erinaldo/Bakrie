<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WBCropReport
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WBCropReport))
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.lblToDate = New System.Windows.Forms.Label()
        Me.pnlDailyReport = New System.Windows.Forms.Panel()
        Me.plWeighingDailyReport = New Stepi.UI.ExtendedPanel()
        Me.lblsearchby = New System.Windows.Forms.Label()
        Me.btnviewReport = New System.Windows.Forms.Button()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlDailyReport.SuspendLayout()
        Me.plWeighingDailyReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpToDate
        '
        Me.dtpToDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Location = New System.Drawing.Point(375, 91)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(142, 20)
        Me.dtpToDate.TabIndex = 102
        '
        'lblToDate
        '
        Me.lblToDate.AutoSize = True
        Me.lblToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToDate.ForeColor = System.Drawing.Color.Black
        Me.lblToDate.Location = New System.Drawing.Point(312, 95)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(60, 13)
        Me.lblToDate.TabIndex = 118
        Me.lblToDate.Text = "To Date :"
        '
        'pnlDailyReport
        '
        Me.pnlDailyReport.AutoSize = True
        Me.pnlDailyReport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.pnlDailyReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlDailyReport.Controls.Add(Me.plWeighingDailyReport)
        Me.pnlDailyReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDailyReport.Location = New System.Drawing.Point(0, 0)
        Me.pnlDailyReport.Name = "pnlDailyReport"
        Me.pnlDailyReport.Size = New System.Drawing.Size(976, 261)
        Me.pnlDailyReport.TabIndex = 2
        '
        'plWeighingDailyReport
        '
        Me.plWeighingDailyReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plWeighingDailyReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plWeighingDailyReport.BorderColor = System.Drawing.Color.Gray
        Me.plWeighingDailyReport.CaptionColorOne = System.Drawing.Color.White
        Me.plWeighingDailyReport.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plWeighingDailyReport.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plWeighingDailyReport.CaptionSize = 40
        Me.plWeighingDailyReport.CaptionText = "Weighing Daily Report"
        Me.plWeighingDailyReport.CaptionTextColor = System.Drawing.Color.Black
        Me.plWeighingDailyReport.Controls.Add(Me.lblsearchby)
        Me.plWeighingDailyReport.Controls.Add(Me.dtpToDate)
        Me.plWeighingDailyReport.Controls.Add(Me.lblToDate)
        Me.plWeighingDailyReport.Controls.Add(Me.btnviewReport)
        Me.plWeighingDailyReport.Controls.Add(Me.lblFromDate)
        Me.plWeighingDailyReport.Controls.Add(Me.dtpFromDate)
        Me.plWeighingDailyReport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plWeighingDailyReport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plWeighingDailyReport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plWeighingDailyReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.plWeighingDailyReport.ForeColor = System.Drawing.Color.Black
        Me.plWeighingDailyReport.Location = New System.Drawing.Point(0, 0)
        Me.plWeighingDailyReport.Name = "plWeighingDailyReport"
        Me.plWeighingDailyReport.Size = New System.Drawing.Size(976, 177)
        Me.plWeighingDailyReport.TabIndex = 147
        '
        'lblsearchby
        '
        Me.lblsearchby.AutoSize = True
        Me.lblsearchby.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchby.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchby.ForeColor = System.Drawing.Color.Black
        Me.lblsearchby.Location = New System.Drawing.Point(3, 74)
        Me.lblsearchby.Name = "lblsearchby"
        Me.lblsearchby.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchby.TabIndex = 54
        Me.lblsearchby.Text = "Search By"
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(375, 130)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(142, 25)
        Me.btnviewReport.TabIndex = 107
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFromDate.ForeColor = System.Drawing.Color.Black
        Me.lblFromDate.Location = New System.Drawing.Point(79, 93)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(76, 13)
        Me.lblFromDate.TabIndex = 16
        Me.lblFromDate.Text = "From Date :"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromDate.Location = New System.Drawing.Point(156, 89)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(144, 20)
        Me.dtpFromDate.TabIndex = 101
        '
        'WBCropReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(976, 261)
        Me.Controls.Add(Me.pnlDailyReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "WBCropReport"
        Me.Text = "Weighbridge Crop Statement"
        Me.pnlDailyReport.ResumeLayout(False)
        Me.plWeighingDailyReport.ResumeLayout(False)
        Me.plWeighingDailyReport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblToDate As System.Windows.Forms.Label
    Friend WithEvents pnlDailyReport As System.Windows.Forms.Panel
    Friend WithEvents plWeighingDailyReport As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchby As System.Windows.Forms.Label
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class

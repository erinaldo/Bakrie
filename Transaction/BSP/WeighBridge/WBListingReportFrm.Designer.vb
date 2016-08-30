<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WBListingReportFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WBListingReportFrm))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlDailyReport = New System.Windows.Forms.Panel()
        Me.plWBListingReport = New Stepi.UI.ExtendedPanel()
        Me.lblsearchby = New System.Windows.Forms.Label()
        Me.btnviewReport = New System.Windows.Forms.Button()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.pnlDailyReport.SuspendLayout()
        Me.plWBListingReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDailyReport
        '
        Me.pnlDailyReport.AutoSize = True
        Me.pnlDailyReport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.pnlDailyReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlDailyReport.Controls.Add(Me.plWBListingReport)
        Me.pnlDailyReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDailyReport.Location = New System.Drawing.Point(0, 0)
        Me.pnlDailyReport.Name = "pnlDailyReport"
        Me.pnlDailyReport.Size = New System.Drawing.Size(986, 557)
        Me.pnlDailyReport.TabIndex = 1
        '
        'plWBListingReport
        '
        Me.plWBListingReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plWBListingReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plWBListingReport.BorderColor = System.Drawing.Color.Gray
        Me.plWBListingReport.CaptionColorOne = System.Drawing.Color.White
        Me.plWBListingReport.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plWBListingReport.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plWBListingReport.CaptionSize = 40
        Me.plWBListingReport.CaptionText = "Weighing In/Out Listing Report"
        Me.plWBListingReport.CaptionTextColor = System.Drawing.Color.Black
        Me.plWBListingReport.Controls.Add(Me.lblsearchby)
        Me.plWBListingReport.Controls.Add(Me.btnviewReport)
        Me.plWBListingReport.Controls.Add(Me.lblFromDate)
        Me.plWBListingReport.Controls.Add(Me.dtpDate)
        Me.plWBListingReport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plWBListingReport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plWBListingReport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plWBListingReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.plWBListingReport.ForeColor = System.Drawing.Color.Black
        Me.plWBListingReport.Location = New System.Drawing.Point(0, 0)
        Me.plWBListingReport.Name = "plWBListingReport"
        Me.plWBListingReport.Size = New System.Drawing.Size(986, 177)
        Me.plWBListingReport.TabIndex = 147
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
        Me.btnviewReport.Location = New System.Drawing.Point(804, 141)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(122, 25)
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
        Me.lblFromDate.Size = New System.Drawing.Size(43, 13)
        Me.lblFromDate.TabIndex = 16
        Me.lblFromDate.Text = "Date :"
        '
        'dtpDate
        '
        Me.dtpDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Location = New System.Drawing.Point(128, 87)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(158, 20)
        Me.dtpDate.TabIndex = 101
        '
        'WBListingReportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(986, 557)
        Me.Controls.Add(Me.pnlDailyReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "WBListingReportFrm"
        Me.Text = "DailyReport"
        Me.pnlDailyReport.ResumeLayout(False)
        Me.plWBListingReport.ResumeLayout(False)
        Me.plWBListingReport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlDailyReport As System.Windows.Forms.Panel
    Friend WithEvents plWBListingReport As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchby As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
End Class

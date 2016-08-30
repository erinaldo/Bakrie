<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecapitulationFFBReceivedFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecapitulationFFBReceivedFrm))
        Me.pnlRecapitulationFFBReceivedReport = New System.Windows.Forms.Panel
        Me.plWeighingDailyReport = New Stepi.UI.ExtendedPanel
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.lblsearchby = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.btnviewReport = New System.Windows.Forms.Button
        Me.pnlRecapitulationFFBReceivedReport.SuspendLayout()
        Me.plWeighingDailyReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlRecapitulationFFBReceivedReport
        '
        Me.pnlRecapitulationFFBReceivedReport.AutoSize = True
        Me.pnlRecapitulationFFBReceivedReport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.pnlRecapitulationFFBReceivedReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlRecapitulationFFBReceivedReport.Controls.Add(Me.plWeighingDailyReport)
        Me.pnlRecapitulationFFBReceivedReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRecapitulationFFBReceivedReport.Location = New System.Drawing.Point(0, 0)
        Me.pnlRecapitulationFFBReceivedReport.Name = "pnlRecapitulationFFBReceivedReport"
        Me.pnlRecapitulationFFBReceivedReport.Size = New System.Drawing.Size(986, 557)
        Me.pnlRecapitulationFFBReceivedReport.TabIndex = 2
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
        Me.plWeighingDailyReport.CaptionText = "Recapitulation FFB Received  Report"
        Me.plWeighingDailyReport.CaptionTextColor = System.Drawing.Color.Black
        Me.plWeighingDailyReport.Controls.Add(Me.dtpDate)
        Me.plWeighingDailyReport.Controls.Add(Me.lblsearchby)
        Me.plWeighingDailyReport.Controls.Add(Me.lblDate)
        Me.plWeighingDailyReport.Controls.Add(Me.btnviewReport)
        Me.plWeighingDailyReport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plWeighingDailyReport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plWeighingDailyReport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plWeighingDailyReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.plWeighingDailyReport.ForeColor = System.Drawing.Color.Black
        Me.plWeighingDailyReport.Location = New System.Drawing.Point(0, 0)
        Me.plWeighingDailyReport.Name = "plWeighingDailyReport"
        Me.plWeighingDailyReport.Size = New System.Drawing.Size(986, 177)
        Me.plWeighingDailyReport.TabIndex = 147
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(210, 76)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(128, 20)
        Me.dtpDate.TabIndex = 111
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
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(161, 78)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(43, 13)
        Me.lblDate.TabIndex = 16
        Me.lblDate.Text = "Date :"
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(791, 135)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(122, 25)
        Me.btnviewReport.TabIndex = 107
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'RecapitulationFFBReceivedFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 557)
        Me.Controls.Add(Me.pnlRecapitulationFFBReceivedReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "RecapitulationFFBReceivedFrm"
        Me.Text = "RecapitulationFFB_ReceivedFrm"
        Me.pnlRecapitulationFFBReceivedReport.ResumeLayout(False)
        Me.plWeighingDailyReport.ResumeLayout(False)
        Me.plWeighingDailyReport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlRecapitulationFFBReceivedReport As System.Windows.Forms.Panel
    Friend WithEvents plWeighingDailyReport As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchby As System.Windows.Forms.Label
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
End Class

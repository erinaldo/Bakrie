<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WBWeighingTicketReportFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WBWeighingTicketReportFrm))
        Me.plWBWeighingTicketReport = New Stepi.UI.ExtendedPanel
        Me.lblsearchby = New System.Windows.Forms.Label
        Me.cmbTicketNo = New System.Windows.Forms.ComboBox
        Me.lblWeighingTicket = New System.Windows.Forms.Label
        Me.btnviewReport = New System.Windows.Forms.Button
        Me.plWBWeighingTicketReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'plWBWeighingTicketReport
        '
        Me.plWBWeighingTicketReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plWBWeighingTicketReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plWBWeighingTicketReport.BorderColor = System.Drawing.Color.Gray
        Me.plWBWeighingTicketReport.CaptionColorOne = System.Drawing.Color.White
        Me.plWBWeighingTicketReport.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plWBWeighingTicketReport.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plWBWeighingTicketReport.CaptionSize = 40
        Me.plWBWeighingTicketReport.CaptionText = "WBWeighingTicketReport"
        Me.plWBWeighingTicketReport.CaptionTextColor = System.Drawing.Color.Black
        Me.plWBWeighingTicketReport.Controls.Add(Me.lblsearchby)
        Me.plWBWeighingTicketReport.Controls.Add(Me.cmbTicketNo)
        Me.plWBWeighingTicketReport.Controls.Add(Me.lblWeighingTicket)
        Me.plWBWeighingTicketReport.Controls.Add(Me.btnviewReport)
        Me.plWBWeighingTicketReport.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plWBWeighingTicketReport.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plWBWeighingTicketReport.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plWBWeighingTicketReport.Dock = System.Windows.Forms.DockStyle.Top
        Me.plWBWeighingTicketReport.ForeColor = System.Drawing.Color.Black
        Me.plWBWeighingTicketReport.Location = New System.Drawing.Point(0, 0)
        Me.plWBWeighingTicketReport.Name = "plWBWeighingTicketReport"
        Me.plWBWeighingTicketReport.Size = New System.Drawing.Size(978, 177)
        Me.plWBWeighingTicketReport.TabIndex = 148
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
        'cmbTicketNo
        '
        Me.cmbTicketNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTicketNo.FormattingEnabled = True
        Me.cmbTicketNo.Location = New System.Drawing.Point(263, 74)
        Me.cmbTicketNo.Name = "cmbTicketNo"
        Me.cmbTicketNo.Size = New System.Drawing.Size(150, 21)
        Me.cmbTicketNo.TabIndex = 108
        '
        'lblWeighingTicket
        '
        Me.lblWeighingTicket.AutoSize = True
        Me.lblWeighingTicket.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeighingTicket.ForeColor = System.Drawing.Color.Black
        Me.lblWeighingTicket.Location = New System.Drawing.Point(161, 78)
        Me.lblWeighingTicket.Name = "lblWeighingTicket"
        Me.lblWeighingTicket.Size = New System.Drawing.Size(96, 13)
        Me.lblWeighingTicket.TabIndex = 16
        Me.lblWeighingTicket.Text = "WB Ticket No. :"
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
        'WBWeighingTicketReportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(978, 523)
        Me.Controls.Add(Me.plWBWeighingTicketReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "WBWeighingTicketReportFrm"
        Me.Text = "WBWeighingTicketReportFrm"
        Me.plWBWeighingTicketReport.ResumeLayout(False)
        Me.plWBWeighingTicketReport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plWBWeighingTicketReport As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchby As System.Windows.Forms.Label
    Friend WithEvents lblWeighingTicket As System.Windows.Forms.Label
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents cmbTicketNo As System.Windows.Forms.ComboBox
End Class

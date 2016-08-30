<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyProductionReportKCPFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DailyProductionReportKCPFrm))
        Me.plKCPSearch = New Stepi.UI.ExtendedPanel
        Me.dtpDailyProdKCPDate = New System.Windows.Forms.DateTimePicker
        Me.lblsearchBy = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.plKCPSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'plKCPSearch
        '
        Me.plKCPSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plKCPSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plKCPSearch.BorderColor = System.Drawing.Color.Gray
        Me.plKCPSearch.CaptionColorOne = System.Drawing.Color.White
        Me.plKCPSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.plKCPSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plKCPSearch.CaptionSize = 40
        Me.plKCPSearch.CaptionText = "Daily Production Report KCP"
        Me.plKCPSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.plKCPSearch.Controls.Add(Me.dtpDailyProdKCPDate)
        Me.plKCPSearch.Controls.Add(Me.lblsearchBy)
        Me.plKCPSearch.Controls.Add(Me.btnSearch)
        Me.plKCPSearch.Controls.Add(Me.btnClose)
        Me.plKCPSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.plKCPSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.plKCPSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.plKCPSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.plKCPSearch.ForeColor = System.Drawing.Color.Black
        Me.plKCPSearch.Location = New System.Drawing.Point(0, 0)
        Me.plKCPSearch.Name = "plKCPSearch"
        Me.plKCPSearch.Size = New System.Drawing.Size(710, 154)
        Me.plKCPSearch.TabIndex = 119
        '
        'dtpDailyProdKCPDate
        '
        Me.dtpDailyProdKCPDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDailyProdKCPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDailyProdKCPDate.Location = New System.Drawing.Point(9, 78)
        Me.dtpDailyProdKCPDate.Name = "dtpDailyProdKCPDate"
        Me.dtpDailyProdKCPDate.Size = New System.Drawing.Size(195, 21)
        Me.dtpDailyProdKCPDate.TabIndex = 140
        '
        'lblsearchBy
        '
        Me.lblsearchBy.AutoSize = True
        Me.lblsearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblsearchBy.Location = New System.Drawing.Point(7, 49)
        Me.lblsearchBy.Name = "lblsearchBy"
        Me.lblsearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchBy.TabIndex = 54
        Me.lblsearchBy.Text = "Search By"
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(222, 76)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnSearch.TabIndex = 141
        Me.btnSearch.Text = "View Report"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(345, 76)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 25)
        Me.btnClose.TabIndex = 142
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'DailyProductionReportKCPFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(710, 464)
        Me.Controls.Add(Me.plKCPSearch)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "DailyProductionReportKCPFrm"
        Me.Text = "DailyProductionReportKCP"
        Me.plKCPSearch.ResumeLayout(False)
        Me.plKCPSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plKCPSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchBy As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dtpDailyProdKCPDate As System.Windows.Forms.DateTimePicker
End Class

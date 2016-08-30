<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreConsignmentstockmovementsReportFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StoreConsignmentstockmovementsReportFrm))
        Me.pnlConsrpt = New Stepi.UI.ExtendedPanel
        Me.cmbYearSearch = New System.Windows.Forms.ComboBox
        Me.lblYearSerach = New System.Windows.Forms.Label
        Me.cmbMonthSearch = New System.Windows.Forms.ComboBox
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.lblMonthSerach = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.pnlConsrpt.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlConsrpt
        '
        Me.pnlConsrpt.BackColor = System.Drawing.Color.Transparent
        Me.pnlConsrpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlConsrpt.BorderColor = System.Drawing.Color.Gray
        Me.pnlConsrpt.CaptionColorOne = System.Drawing.Color.Transparent
        Me.pnlConsrpt.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlConsrpt.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlConsrpt.CaptionSize = 30
        Me.pnlConsrpt.CaptionText = "Consignment Stock Movements Report"
        Me.pnlConsrpt.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlConsrpt.Controls.Add(Me.cmbYearSearch)
        Me.pnlConsrpt.Controls.Add(Me.lblYearSerach)
        Me.pnlConsrpt.Controls.Add(Me.cmbMonthSearch)
        Me.pnlConsrpt.Controls.Add(Me.btnViewReport)
        Me.pnlConsrpt.Controls.Add(Me.lblSearchBy)
        Me.pnlConsrpt.Controls.Add(Me.lblMonthSerach)
        Me.pnlConsrpt.Controls.Add(Me.Label30)
        Me.pnlConsrpt.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlConsrpt.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlConsrpt.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlConsrpt.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlConsrpt.ForeColor = System.Drawing.Color.Black
        Me.pnlConsrpt.Location = New System.Drawing.Point(0, 0)
        Me.pnlConsrpt.Name = "pnlConsrpt"
        Me.pnlConsrpt.Size = New System.Drawing.Size(589, 146)
        Me.pnlConsrpt.TabIndex = 2
        '
        'cmbYearSearch
        '
        Me.cmbYearSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYearSearch.FormattingEnabled = True
        Me.cmbYearSearch.Location = New System.Drawing.Point(203, 79)
        Me.cmbYearSearch.Name = "cmbYearSearch"
        Me.cmbYearSearch.Size = New System.Drawing.Size(170, 21)
        Me.cmbYearSearch.TabIndex = 2
        '
        'lblYearSerach
        '
        Me.lblYearSerach.AutoSize = True
        Me.lblYearSerach.BackColor = System.Drawing.Color.Transparent
        Me.lblYearSerach.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblYearSerach.ForeColor = System.Drawing.Color.Black
        Me.lblYearSerach.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblYearSerach.Location = New System.Drawing.Point(203, 60)
        Me.lblYearSerach.Name = "lblYearSerach"
        Me.lblYearSerach.Size = New System.Drawing.Size(33, 13)
        Me.lblYearSerach.TabIndex = 143
        Me.lblYearSerach.Text = "Year"
        '
        'cmbMonthSearch
        '
        Me.cmbMonthSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonthSearch.FormattingEnabled = True
        Me.cmbMonthSearch.Location = New System.Drawing.Point(17, 79)
        Me.cmbMonthSearch.Name = "cmbMonthSearch"
        Me.cmbMonthSearch.Size = New System.Drawing.Size(170, 21)
        Me.cmbMonthSearch.TabIndex = 1
        '
        'btnViewReport
        '
        Me.btnViewReport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnViewReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewReport.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnViewReport.Image = CType(resources.GetObject("btnViewReport.Image"), System.Drawing.Image)
        Me.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewReport.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnViewReport.Location = New System.Drawing.Point(392, 79)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(139, 29)
        Me.btnViewReport.TabIndex = 3
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearchBy.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchBy.Location = New System.Drawing.Point(3, 35)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchBy.TabIndex = 78
        Me.lblSearchBy.Text = "Search By"
        '
        'lblMonthSerach
        '
        Me.lblMonthSerach.AutoSize = True
        Me.lblMonthSerach.BackColor = System.Drawing.Color.Transparent
        Me.lblMonthSerach.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblMonthSerach.ForeColor = System.Drawing.Color.Black
        Me.lblMonthSerach.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMonthSerach.Location = New System.Drawing.Point(17, 60)
        Me.lblMonthSerach.Name = "lblMonthSerach"
        Me.lblMonthSerach.Size = New System.Drawing.Size(41, 13)
        Me.lblMonthSerach.TabIndex = 80
        Me.lblMonthSerach.Text = "Month"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(81, 36)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(12, 14)
        Me.Label30.TabIndex = 79
        Me.Label30.Text = ":"
        '
        'StoreConsignmentstockmovementsReportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(589, 145)
        Me.Controls.Add(Me.pnlConsrpt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "StoreConsignmentstockmovementsReportFrm"
        Me.Text = "StoreConsignmentstockmovementsReportFrm"
        Me.pnlConsrpt.ResumeLayout(False)
        Me.pnlConsrpt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlConsrpt As Stepi.UI.ExtendedPanel
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents lblMonthSerach As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbMonthSearch As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYearSearch As System.Windows.Forms.ComboBox
    Friend WithEvents lblYearSerach As System.Windows.Forms.Label
End Class

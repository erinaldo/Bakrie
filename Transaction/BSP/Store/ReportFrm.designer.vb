<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportFrm
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
        Me.crvReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crvReport
        '
        Me.crvReport.ActiveViewIndex = -1
        Me.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crvReport.Location = New System.Drawing.Point(0, 0)
        Me.crvReport.Name = "crvReport"
        Me.crvReport.SelectionFormula = ""
        Me.crvReport.ShowCloseButton = False
        Me.crvReport.ShowGroupTreeButton = False
        Me.crvReport.ShowParameterPanelButton = False
        Me.crvReport.ShowRefreshButton = False
        Me.crvReport.Size = New System.Drawing.Size(610, 360)
        Me.crvReport.TabIndex = 1
        Me.crvReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crvReport.ViewTimeSelectionFormula = ""
        '
        'ReportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(610, 360)
        Me.Controls.Add(Me.crvReport)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "ReportFrm"
        Me.Text = "ReportFrm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvReport As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

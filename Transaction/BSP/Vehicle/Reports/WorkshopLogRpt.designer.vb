<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkshopLogRpt
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
        Me.crvWorkshopLogRpt = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crvWorkshopLogRpt
        '
        Me.crvWorkshopLogRpt.ActiveViewIndex = -1
        Me.crvWorkshopLogRpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvWorkshopLogRpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvWorkshopLogRpt.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.crvWorkshopLogRpt.Location = New System.Drawing.Point(0, 0)
        Me.crvWorkshopLogRpt.Name = "crvWorkshopLogRpt"
        Me.crvWorkshopLogRpt.ShowCloseButton = False
        Me.crvWorkshopLogRpt.ShowGroupTreeButton = False
        Me.crvWorkshopLogRpt.ShowParameterPanelButton = False
        Me.crvWorkshopLogRpt.ShowRefreshButton = False
        Me.crvWorkshopLogRpt.Size = New System.Drawing.Size(292, 273)
        Me.crvWorkshopLogRpt.TabIndex = 0
        Me.crvWorkshopLogRpt.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'WorkshopLogRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.crvWorkshopLogRpt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WorkshopLogRpt"
        Me.Text = "WorkshopLogRpt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvWorkshopLogRpt As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

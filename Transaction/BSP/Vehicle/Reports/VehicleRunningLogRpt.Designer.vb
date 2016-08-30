<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleRunningLogRpt
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
        Me.crvVehicleRunningLogRpt = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crvVehicleRunningLogRpt
        '
        Me.crvVehicleRunningLogRpt.ActiveViewIndex = -1
        Me.crvVehicleRunningLogRpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvVehicleRunningLogRpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvVehicleRunningLogRpt.Location = New System.Drawing.Point(0, 0)
        Me.crvVehicleRunningLogRpt.Name = "crvVehicleRunningLogRpt"
        Me.crvVehicleRunningLogRpt.ShowCloseButton = False
        Me.crvVehicleRunningLogRpt.ShowGroupTreeButton = False
        Me.crvVehicleRunningLogRpt.ShowParameterPanelButton = False
        Me.crvVehicleRunningLogRpt.ShowRefreshButton = False
        Me.crvVehicleRunningLogRpt.Size = New System.Drawing.Size(292, 273)
        Me.crvVehicleRunningLogRpt.TabIndex = 2
        Me.crvVehicleRunningLogRpt.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'VehicleRunningLogRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.crvVehicleRunningLogRpt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VehicleRunningLogRpt"
        Me.Text = "VehicleRunningLogRpt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvVehicleRunningLogRpt As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

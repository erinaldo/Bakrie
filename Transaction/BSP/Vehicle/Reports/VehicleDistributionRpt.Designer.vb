<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleDistributionRpt
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
        Me.crvVehicleDistributionRpt = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crvVehicleDistributionRpt
        '
        Me.crvVehicleDistributionRpt.ActiveViewIndex = -1
        Me.crvVehicleDistributionRpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvVehicleDistributionRpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvVehicleDistributionRpt.Location = New System.Drawing.Point(0, 0)
        Me.crvVehicleDistributionRpt.Name = "crvVehicleDistributionRpt"
        Me.crvVehicleDistributionRpt.ShowCloseButton = False
        Me.crvVehicleDistributionRpt.ShowGroupTreeButton = False
        Me.crvVehicleDistributionRpt.ShowParameterPanelButton = False
        Me.crvVehicleDistributionRpt.ShowRefreshButton = False
        Me.crvVehicleDistributionRpt.Size = New System.Drawing.Size(292, 273)
        Me.crvVehicleDistributionRpt.TabIndex = 1
        Me.crvVehicleDistributionRpt.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'VehicleDistributionRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.crvVehicleDistributionRpt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VehicleDistributionRpt"
        Me.Text = "VehicleDistributionRpt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvVehicleDistributionRpt As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleViewReport
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
        Me.crvVehicle = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crvVehicle
        '
        Me.crvVehicle.ActiveViewIndex = -1
        Me.crvVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvVehicle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvVehicle.Location = New System.Drawing.Point(0, 0)
        Me.crvVehicle.Name = "crvVehicle"
        Me.crvVehicle.ShowCloseButton = False
        Me.crvVehicle.ShowGroupTreeButton = False
        Me.crvVehicle.ShowParameterPanelButton = False
        Me.crvVehicle.ShowRefreshButton = False
        Me.crvVehicle.Size = New System.Drawing.Size(341, 266)
        Me.crvVehicle.TabIndex = 0
        Me.crvVehicle.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'VehicleViewReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 266)
        Me.Controls.Add(Me.crvVehicle)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "VehicleViewReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvVehicle As CrystalDecisions.Windows.Forms.CrystalReportViewer

End Class

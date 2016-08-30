<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreIPRInTabReport
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
        Me.VehicleFarmTractorHEVehicleRunningLog = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.crvInternalTransferNoteINRpt = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.crvInternalTransferNoteOUTRpt = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.VehicleFarmTractorHEVehicleRunningLog.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'VehicleFarmTractorHEVehicleRunningLog
        '
        Me.VehicleFarmTractorHEVehicleRunningLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VehicleFarmTractorHEVehicleRunningLog.Controls.Add(Me.TabPage2)
        Me.VehicleFarmTractorHEVehicleRunningLog.Controls.Add(Me.TabPage1)
        Me.VehicleFarmTractorHEVehicleRunningLog.Location = New System.Drawing.Point(-2, 1)
        Me.VehicleFarmTractorHEVehicleRunningLog.Name = "VehicleFarmTractorHEVehicleRunningLog"
        Me.VehicleFarmTractorHEVehicleRunningLog.SelectedIndex = 0
        Me.VehicleFarmTractorHEVehicleRunningLog.Size = New System.Drawing.Size(764, 727)
        Me.VehicleFarmTractorHEVehicleRunningLog.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.crvInternalTransferNoteINRpt)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(756, 701)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TN IN"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'crvInternalTransferNoteINRpt
        '
        Me.crvInternalTransferNoteINRpt.ActiveViewIndex = -1
        Me.crvInternalTransferNoteINRpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvInternalTransferNoteINRpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvInternalTransferNoteINRpt.Location = New System.Drawing.Point(3, 3)
        Me.crvInternalTransferNoteINRpt.Name = "crvInternalTransferNoteINRpt"
        Me.crvInternalTransferNoteINRpt.ShowCloseButton = False
        Me.crvInternalTransferNoteINRpt.ShowGroupTreeButton = False
        Me.crvInternalTransferNoteINRpt.ShowParameterPanelButton = False
        Me.crvInternalTransferNoteINRpt.ShowRefreshButton = False
        Me.crvInternalTransferNoteINRpt.Size = New System.Drawing.Size(750, 695)
        Me.crvInternalTransferNoteINRpt.TabIndex = 1
        Me.crvInternalTransferNoteINRpt.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.crvInternalTransferNoteOUTRpt)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(756, 701)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "TN OUT"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'crvInternalTransferNoteOUTRpt
        '
        Me.crvInternalTransferNoteOUTRpt.ActiveViewIndex = -1
        Me.crvInternalTransferNoteOUTRpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvInternalTransferNoteOUTRpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvInternalTransferNoteOUTRpt.Location = New System.Drawing.Point(0, 0)
        Me.crvInternalTransferNoteOUTRpt.Name = "crvInternalTransferNoteOUTRpt"
        Me.crvInternalTransferNoteOUTRpt.ShowCloseButton = False
        Me.crvInternalTransferNoteOUTRpt.ShowGroupTreeButton = False
        Me.crvInternalTransferNoteOUTRpt.ShowParameterPanelButton = False
        Me.crvInternalTransferNoteOUTRpt.ShowRefreshButton = False
        Me.crvInternalTransferNoteOUTRpt.Size = New System.Drawing.Size(756, 701)
        Me.crvInternalTransferNoteOUTRpt.TabIndex = 2
        Me.crvInternalTransferNoteOUTRpt.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'StoreIPRInTabReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 688)
        Me.Controls.Add(Me.VehicleFarmTractorHEVehicleRunningLog)
        Me.Name = "StoreIPRInTabReport"
        Me.Text = "StoreITNReport"
        Me.VehicleFarmTractorHEVehicleRunningLog.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VehicleFarmTractorHEVehicleRunningLog As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents crvInternalTransferNoteINRpt As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents crvInternalTransferNoteOUTRpt As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

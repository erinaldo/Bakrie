<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRViewer
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
        Me.crystalViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crystalViewer
        '
        Me.crystalViewer.ActiveViewIndex = -1
        Me.crystalViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crystalViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crystalViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crystalViewer.Location = New System.Drawing.Point(0, 0)
        Me.crystalViewer.Name = "crystalViewer"
        Me.crystalViewer.ReuseParameterValuesOnRefresh = True
        Me.crystalViewer.ShowCloseButton = False
        'Me.crystalViewer.ShowCopyButton = False
        Me.crystalViewer.ShowGroupTreeButton = False
        Me.crystalViewer.ShowParameterPanelButton = False
        Me.crystalViewer.ShowRefreshButton = False
        Me.crystalViewer.Size = New System.Drawing.Size(784, 562)
        Me.crystalViewer.TabIndex = 0
        Me.crystalViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'CRViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.crystalViewer)
        Me.Name = "CRViewer"
        Me.Text = "Report Viewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crystalViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

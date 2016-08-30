<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpinningProgressFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpinningProgressFrm))
        Me.SpinningProgressBar = New BSP.SpinningProgress()
        Me.SuspendLayout()
        '
        'SpinningProgressBar
        '
        Me.SpinningProgressBar.BehindTransistionSegmentIsActive = False
        resources.ApplyResources(Me.SpinningProgressBar, "SpinningProgressBar")
        Me.SpinningProgressBar.Name = "SpinningProgressBar"
        Me.SpinningProgressBar.TransistionSegment = 1
        '
        'SpinningProgressFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ControlBox = False
        Me.Controls.Add(Me.SpinningProgressBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SpinningProgressFrm"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Transparent
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpinningProgressBar As BSP.SpinningProgress
End Class

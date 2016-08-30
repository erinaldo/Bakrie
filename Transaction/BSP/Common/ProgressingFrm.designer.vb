<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgressingFrm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProgressingFrm))
        Me.pbWait = New System.Windows.Forms.ProgressBar()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.SpinningProgress5 = New CircularProgress.SpinningProgress.SpinningProgress()
        Me.SuspendLayout()
        '
        'pbWait
        '
        resources.ApplyResources(Me.pbWait, "pbWait")
        Me.pbWait.Name = "pbWait"
        '
        'lblMessage
        '
        resources.ApplyResources(Me.lblMessage, "lblMessage")
        Me.lblMessage.Name = "lblMessage"
        '
        'lblTitle
        '
        resources.ApplyResources(Me.lblTitle, "lblTitle")
        Me.lblTitle.Name = "lblTitle"
        '
        'SpinningProgress5
        '
        Me.SpinningProgress5.AutoIncrementFrequency = 500.0R
        resources.ApplyResources(Me.SpinningProgress5, "SpinningProgress5")
        Me.SpinningProgress5.Name = "SpinningProgress5"
        Me.SpinningProgress5.TransistionSegment = 4
        '
        'ProgressingFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ControlBox = False
        Me.Controls.Add(Me.SpinningProgress5)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.pbWait)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "ProgressingFrm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbWait As System.Windows.Forms.ProgressBar
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents SpinningProgress5 As CircularProgress.SpinningProgress.SpinningProgress
End Class

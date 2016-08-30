<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetailPremiProcess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetailPremiProcess))
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'btnProcess
        '
        Me.btnProcess.BackColor = System.Drawing.Color.Transparent
        Me.btnProcess.BackgroundImage = CType(resources.GetObject("btnProcess.BackgroundImage"), System.Drawing.Image)
        Me.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProcess.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcess.Image = Global.BSP.My.Resources.Resources._001_58
        Me.btnProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcess.Location = New System.Drawing.Point(67, 130)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(299, 30)
        Me.btnProcess.TabIndex = 209
        Me.btnProcess.Text = "Update Premi Values"
        Me.btnProcess.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(379, 130)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 30)
        Me.btnClose.TabIndex = 210
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.Location = New System.Drawing.Point(63, 220)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(25, 24)
        Me.lblProgress.TabIndex = 211
        Me.lblProgress.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(67, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "From"
        '
        'dpFrom
        '
        Me.dpFrom.Location = New System.Drawing.Point(70, 53)
        Me.dpFrom.Name = "dpFrom"
        Me.dpFrom.Size = New System.Drawing.Size(200, 20)
        Me.dpFrom.TabIndex = 213
        '
        'dpTo
        '
        Me.dpTo.Location = New System.Drawing.Point(306, 53)
        Me.dpTo.Name = "dpTo"
        Me.dpTo.Size = New System.Drawing.Size(200, 20)
        Me.dpTo.TabIndex = 215
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(303, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 214
        Me.Label2.Text = "To"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(67, 258)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(439, 23)
        Me.ProgressBar1.TabIndex = 216
        '
        'DetailPremiProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(592, 366)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.dpTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dpFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.btnClose)
        Me.MaximizeBox = False
        Me.Name = "DetailPremiProcess"
        Me.Text = "Detail Premi Process"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class

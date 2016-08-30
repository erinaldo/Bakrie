<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RekapLaporanMandor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RekapLaporanMandor))
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnRekapLapMandorTPanen = New System.Windows.Forms.Button
        Me.btnRekapLapMandorTLain = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rekap Laporan Mandor"
        '
        'btnRekapLapMandorTPanen
        '
        Me.btnRekapLapMandorTPanen.BackColor = System.Drawing.Color.Transparent
        Me.btnRekapLapMandorTPanen.BackgroundImage = CType(resources.GetObject("btnRekapLapMandorTPanen.BackgroundImage"), System.Drawing.Image)
        Me.btnRekapLapMandorTPanen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRekapLapMandorTPanen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRekapLapMandorTPanen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRekapLapMandorTPanen.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRekapLapMandorTPanen.Image = CType(resources.GetObject("btnRekapLapMandorTPanen.Image"), System.Drawing.Image)
        Me.btnRekapLapMandorTPanen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRekapLapMandorTPanen.Location = New System.Drawing.Point(10, 19)
        Me.btnRekapLapMandorTPanen.Name = "btnRekapLapMandorTPanen"
        Me.btnRekapLapMandorTPanen.Size = New System.Drawing.Size(299, 30)
        Me.btnRekapLapMandorTPanen.TabIndex = 206
        Me.btnRekapLapMandorTPanen.Text = "Rekap Laporan Mandor Team Panen"
        Me.btnRekapLapMandorTPanen.UseVisualStyleBackColor = False
        '
        'btnRekapLapMandorTLain
        '
        Me.btnRekapLapMandorTLain.BackColor = System.Drawing.Color.Transparent
        Me.btnRekapLapMandorTLain.BackgroundImage = CType(resources.GetObject("btnRekapLapMandorTLain.BackgroundImage"), System.Drawing.Image)
        Me.btnRekapLapMandorTLain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRekapLapMandorTLain.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRekapLapMandorTLain.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRekapLapMandorTLain.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRekapLapMandorTLain.Image = CType(resources.GetObject("btnRekapLapMandorTLain.Image"), System.Drawing.Image)
        Me.btnRekapLapMandorTLain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRekapLapMandorTLain.Location = New System.Drawing.Point(315, 19)
        Me.btnRekapLapMandorTLain.Name = "btnRekapLapMandorTLain"
        Me.btnRekapLapMandorTLain.Size = New System.Drawing.Size(299, 30)
        Me.btnRekapLapMandorTLain.TabIndex = 207
        Me.btnRekapLapMandorTLain.Text = "Rekap Laporan Mandor Team Lain"
        Me.btnRekapLapMandorTLain.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(627, 19)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 30)
        Me.btnClose.TabIndex = 208
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnRekapLapMandorTLain)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnRekapLapMandorTPanen)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(765, 91)
        Me.GroupBox1.TabIndex = 209
        Me.GroupBox1.TabStop = False
        '
        'RekapLaporanMandor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(807, 180)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RekapLaporanMandor"
        Me.Text = "RekapLaporanMandor"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRekapLapMandorTPanen As System.Windows.Forms.Button
    Friend WithEvents btnRekapLapMandorTLain As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class

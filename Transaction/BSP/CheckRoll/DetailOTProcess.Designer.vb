<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetailOTProcess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetailOTProcess))
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.txtMax1 = New System.Windows.Forms.TextBox()
        Me.txtMax2 = New System.Windows.Forms.TextBox()
        Me.txtMax3 = New System.Windows.Forms.TextBox()
        Me.txtMax4 = New System.Windows.Forms.TextBox()
        Me.txtOT4 = New System.Windows.Forms.TextBox()
        Me.txtOT3 = New System.Windows.Forms.TextBox()
        Me.txtOT2 = New System.Windows.Forms.TextBox()
        Me.txtOT1 = New System.Windows.Forms.TextBox()
        Me.txtH4 = New System.Windows.Forms.TextBox()
        Me.txtH3 = New System.Windows.Forms.TextBox()
        Me.txtH2 = New System.Windows.Forms.TextBox()
        Me.txtH1 = New System.Windows.Forms.TextBox()
        Me.txtdOTResult = New System.Windows.Forms.TextBox()
        Me.txtOTResult = New System.Windows.Forms.TextBox()
        Me.txtBasicRate = New System.Windows.Forms.TextBox()
        Me.txtTotalOTValue = New System.Windows.Forms.TextBox()
        Me.txtRicePrice = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.btnProcess.Location = New System.Drawing.Point(100, 200)
        Me.btnProcess.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(448, 46)
        Me.btnProcess.TabIndex = 209
        Me.btnProcess.Text = "Process Over Time"
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
        Me.btnClose.Location = New System.Drawing.Point(568, 200)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(190, 46)
        Me.btnClose.TabIndex = 210
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.Location = New System.Drawing.Point(94, 338)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(39, 33)
        Me.lblProgress.TabIndex = 211
        Me.lblProgress.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(100, 57)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "From"
        '
        'dpFrom
        '
        Me.dpFrom.Location = New System.Drawing.Point(105, 82)
        Me.dpFrom.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dpFrom.Name = "dpFrom"
        Me.dpFrom.Size = New System.Drawing.Size(298, 26)
        Me.dpFrom.TabIndex = 213
        '
        'dpTo
        '
        Me.dpTo.Location = New System.Drawing.Point(459, 82)
        Me.dpTo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dpTo.Name = "dpTo"
        Me.dpTo.Size = New System.Drawing.Size(298, 26)
        Me.dpTo.TabIndex = 215
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(454, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 20)
        Me.Label2.TabIndex = 214
        Me.Label2.Text = "To"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(100, 397)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(658, 35)
        Me.ProgressBar1.TabIndex = 216
        '
        'txtMax1
        '
        Me.txtMax1.Location = New System.Drawing.Point(886, 52)
        Me.txtMax1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMax1.Name = "txtMax1"
        Me.txtMax1.Size = New System.Drawing.Size(72, 26)
        Me.txtMax1.TabIndex = 217
        Me.txtMax1.Visible = False
        '
        'txtMax2
        '
        Me.txtMax2.Location = New System.Drawing.Point(886, 100)
        Me.txtMax2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMax2.Name = "txtMax2"
        Me.txtMax2.Size = New System.Drawing.Size(72, 26)
        Me.txtMax2.TabIndex = 218
        Me.txtMax2.Visible = False
        '
        'txtMax3
        '
        Me.txtMax3.Location = New System.Drawing.Point(886, 140)
        Me.txtMax3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMax3.Name = "txtMax3"
        Me.txtMax3.Size = New System.Drawing.Size(72, 26)
        Me.txtMax3.TabIndex = 219
        Me.txtMax3.Visible = False
        '
        'txtMax4
        '
        Me.txtMax4.Location = New System.Drawing.Point(886, 180)
        Me.txtMax4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMax4.Name = "txtMax4"
        Me.txtMax4.Size = New System.Drawing.Size(72, 26)
        Me.txtMax4.TabIndex = 220
        Me.txtMax4.Visible = False
        '
        'txtOT4
        '
        Me.txtOT4.Location = New System.Drawing.Point(969, 180)
        Me.txtOT4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOT4.Name = "txtOT4"
        Me.txtOT4.Size = New System.Drawing.Size(72, 26)
        Me.txtOT4.TabIndex = 224
        Me.txtOT4.Visible = False
        '
        'txtOT3
        '
        Me.txtOT3.Location = New System.Drawing.Point(969, 140)
        Me.txtOT3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOT3.Name = "txtOT3"
        Me.txtOT3.Size = New System.Drawing.Size(72, 26)
        Me.txtOT3.TabIndex = 223
        Me.txtOT3.Visible = False
        '
        'txtOT2
        '
        Me.txtOT2.Location = New System.Drawing.Point(969, 100)
        Me.txtOT2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOT2.Name = "txtOT2"
        Me.txtOT2.Size = New System.Drawing.Size(72, 26)
        Me.txtOT2.TabIndex = 222
        Me.txtOT2.Visible = False
        '
        'txtOT1
        '
        Me.txtOT1.Location = New System.Drawing.Point(969, 52)
        Me.txtOT1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOT1.Name = "txtOT1"
        Me.txtOT1.Size = New System.Drawing.Size(72, 26)
        Me.txtOT1.TabIndex = 221
        Me.txtOT1.Visible = False
        '
        'txtH4
        '
        Me.txtH4.Location = New System.Drawing.Point(1046, 180)
        Me.txtH4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtH4.Name = "txtH4"
        Me.txtH4.Size = New System.Drawing.Size(72, 26)
        Me.txtH4.TabIndex = 228
        Me.txtH4.Visible = False
        '
        'txtH3
        '
        Me.txtH3.Location = New System.Drawing.Point(1046, 140)
        Me.txtH3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtH3.Name = "txtH3"
        Me.txtH3.Size = New System.Drawing.Size(72, 26)
        Me.txtH3.TabIndex = 227
        Me.txtH3.Visible = False
        '
        'txtH2
        '
        Me.txtH2.Location = New System.Drawing.Point(1046, 100)
        Me.txtH2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtH2.Name = "txtH2"
        Me.txtH2.Size = New System.Drawing.Size(72, 26)
        Me.txtH2.TabIndex = 226
        Me.txtH2.Visible = False
        '
        'txtH1
        '
        Me.txtH1.Location = New System.Drawing.Point(1046, 52)
        Me.txtH1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtH1.Name = "txtH1"
        Me.txtH1.Size = New System.Drawing.Size(72, 26)
        Me.txtH1.TabIndex = 225
        Me.txtH1.Visible = False
        '
        'txtdOTResult
        '
        Me.txtdOTResult.Location = New System.Drawing.Point(1128, 92)
        Me.txtdOTResult.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtdOTResult.Name = "txtdOTResult"
        Me.txtdOTResult.Size = New System.Drawing.Size(72, 26)
        Me.txtdOTResult.TabIndex = 230
        Me.txtdOTResult.Visible = False
        '
        'txtOTResult
        '
        Me.txtOTResult.Location = New System.Drawing.Point(1128, 52)
        Me.txtOTResult.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOTResult.Name = "txtOTResult"
        Me.txtOTResult.Size = New System.Drawing.Size(72, 26)
        Me.txtOTResult.TabIndex = 229
        Me.txtOTResult.Visible = False
        '
        'txtBasicRate
        '
        Me.txtBasicRate.Location = New System.Drawing.Point(1128, 142)
        Me.txtBasicRate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBasicRate.Name = "txtBasicRate"
        Me.txtBasicRate.Size = New System.Drawing.Size(72, 26)
        Me.txtBasicRate.TabIndex = 231
        Me.txtBasicRate.Visible = False
        '
        'txtTotalOTValue
        '
        Me.txtTotalOTValue.Location = New System.Drawing.Point(1128, 182)
        Me.txtTotalOTValue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotalOTValue.Name = "txtTotalOTValue"
        Me.txtTotalOTValue.Size = New System.Drawing.Size(72, 26)
        Me.txtTotalOTValue.TabIndex = 232
        Me.txtTotalOTValue.Visible = False
        '
        'txtRicePrice
        '
        Me.txtRicePrice.Location = New System.Drawing.Point(255, 140)
        Me.txtRicePrice.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRicePrice.Name = "txtRicePrice"
        Me.txtRicePrice.Size = New System.Drawing.Size(148, 26)
        Me.txtRicePrice.TabIndex = 233
        Me.txtRicePrice.Text = "8500"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(100, 140)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 20)
        Me.Label3.TabIndex = 234
        Me.Label3.Text = "Harga Beras OT"
        '
        'DetailOTProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1228, 546)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRicePrice)
        Me.Controls.Add(Me.txtTotalOTValue)
        Me.Controls.Add(Me.txtBasicRate)
        Me.Controls.Add(Me.txtdOTResult)
        Me.Controls.Add(Me.txtOTResult)
        Me.Controls.Add(Me.txtH4)
        Me.Controls.Add(Me.txtH3)
        Me.Controls.Add(Me.txtH2)
        Me.Controls.Add(Me.txtH1)
        Me.Controls.Add(Me.txtOT4)
        Me.Controls.Add(Me.txtOT3)
        Me.Controls.Add(Me.txtOT2)
        Me.Controls.Add(Me.txtOT1)
        Me.Controls.Add(Me.txtMax4)
        Me.Controls.Add(Me.txtMax3)
        Me.Controls.Add(Me.txtMax2)
        Me.Controls.Add(Me.txtMax1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.dpTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dpFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.btnClose)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "DetailOTProcess"
        Me.Text = "Process Over Time"
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
    Friend WithEvents txtMax1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMax2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMax3 As System.Windows.Forms.TextBox
    Friend WithEvents txtMax4 As System.Windows.Forms.TextBox
    Friend WithEvents txtOT4 As System.Windows.Forms.TextBox
    Friend WithEvents txtOT3 As System.Windows.Forms.TextBox
    Friend WithEvents txtOT2 As System.Windows.Forms.TextBox
    Friend WithEvents txtOT1 As System.Windows.Forms.TextBox
    Friend WithEvents txtH4 As System.Windows.Forms.TextBox
    Friend WithEvents txtH3 As System.Windows.Forms.TextBox
    Friend WithEvents txtH2 As System.Windows.Forms.TextBox
    Friend WithEvents txtH1 As System.Windows.Forms.TextBox
    Friend WithEvents txtdOTResult As System.Windows.Forms.TextBox
    Friend WithEvents txtOTResult As System.Windows.Forms.TextBox
    Friend WithEvents txtBasicRate As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalOTValue As System.Windows.Forms.TextBox
    Friend WithEvents txtRicePrice As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class

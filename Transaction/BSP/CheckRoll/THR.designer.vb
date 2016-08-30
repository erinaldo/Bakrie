<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class THR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(THR))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBNik = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblColon1 = New System.Windows.Forms.Label()
        Me.dtpProcDate = New System.Windows.Forms.DateTimePicker()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.txtTunjanganBeras = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.txtTunjanganBeras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "THR"
        '
        'lblBNik
        '
        Me.lblBNik.AutoSize = True
        Me.lblBNik.BackColor = System.Drawing.Color.Transparent
        Me.lblBNik.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBNik.ForeColor = System.Drawing.Color.Black
        Me.lblBNik.Location = New System.Drawing.Point(36, 78)
        Me.lblBNik.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBNik.Name = "lblBNik"
        Me.lblBNik.Size = New System.Drawing.Size(75, 20)
        Me.lblBNik.TabIndex = 159
        Me.lblBNik.Text = "Tanggal"
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(40, 267)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(158, 46)
        Me.btnSave.TabIndex = 160
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(228, 267)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(158, 46)
        Me.btnClose.TabIndex = 161
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.BackColor = System.Drawing.Color.Transparent
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(189, 72)
        Me.lblColon1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(16, 20)
        Me.lblColon1.TabIndex = 162
        Me.lblColon1.Text = ":"
        '
        'dtpProcDate
        '
        Me.dtpProcDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpProcDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpProcDate.Location = New System.Drawing.Point(224, 72)
        Me.dtpProcDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpProcDate.Name = "dtpProcDate"
        Me.dtpProcDate.Size = New System.Drawing.Size(157, 26)
        Me.dtpProcDate.TabIndex = 163
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.BackColor = System.Drawing.Color.Transparent
        Me.LblMsg.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsg.Location = New System.Drawing.Point(166, 181)
        Me.LblMsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(91, 25)
        Me.LblMsg.TabIndex = 0
        Me.LblMsg.Text = "LblMsg"
        Me.LblMsg.Visible = False
        '
        'txtTunjanganBeras
        '
        Me.txtTunjanganBeras.Increment = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txtTunjanganBeras.Location = New System.Drawing.Point(224, 110)
        Me.txtTunjanganBeras.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtTunjanganBeras.Name = "txtTunjanganBeras"
        Me.txtTunjanganBeras.Size = New System.Drawing.Size(157, 26)
        Me.txtTunjanganBeras.TabIndex = 179
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(189, 112)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 20)
        Me.Label8.TabIndex = 178
        Me.Label8.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(37, 112)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 20)
        Me.Label9.TabIndex = 177
        Me.Label9.Text = "Harga Beras"
        '
        'THR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(580, 409)
        Me.Controls.Add(Me.txtTunjanganBeras)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtpProcDate)
        Me.Controls.Add(Me.lblColon1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblBNik)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "THR"
        Me.Text = "THR"
        CType(Me.txtTunjanganBeras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBNik As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents dtpProcDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents txtTunjanganBeras As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class

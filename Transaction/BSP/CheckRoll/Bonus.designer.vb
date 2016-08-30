<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bonus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Bonus))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBNik = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblColon1 = New System.Windows.Forms.Label()
        Me.dtpProcDate = New System.Windows.Forms.DateTimePicker()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNoofMonths = New System.Windows.Forms.NumericUpDown()
        Me.txtDeductionSBSI = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDeductionSPSB = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTunjanganBeras = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtOtherMonthYear = New System.Windows.Forms.DateTimePicker()
        Me.optPreviousBonus = New System.Windows.Forms.CheckBox()
        CType(Me.txtNoofMonths, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDeductionSBSI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDeductionSPSB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTunjanganBeras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(81, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bonus"
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
        Me.lblBNik.Size = New System.Drawing.Size(134, 20)
        Me.lblBNik.TabIndex = 159
        Me.lblBNik.Text = "Tanggal Bonus"
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(47, 389)
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
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(250, 389)
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
        Me.lblColon1.Location = New System.Drawing.Point(189, 78)
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
        Me.LblMsg.Location = New System.Drawing.Point(188, 329)
        Me.LblMsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(91, 25)
        Me.LblMsg.TabIndex = 0
        Me.LblMsg.Text = "LblMsg"
        Me.LblMsg.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(189, 122)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 20)
        Me.Label2.TabIndex = 166
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(37, 122)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 20)
        Me.Label3.TabIndex = 165
        Me.Label3.Text = "No. Of Months"
        '
        'txtNoofMonths
        '
        Me.txtNoofMonths.DecimalPlaces = 1
        Me.txtNoofMonths.Location = New System.Drawing.Point(224, 121)
        Me.txtNoofMonths.Name = "txtNoofMonths"
        Me.txtNoofMonths.Size = New System.Drawing.Size(75, 26)
        Me.txtNoofMonths.TabIndex = 167
        Me.txtNoofMonths.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtDeductionSBSI
        '
        Me.txtDeductionSBSI.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtDeductionSBSI.Location = New System.Drawing.Point(224, 155)
        Me.txtDeductionSBSI.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtDeductionSBSI.Name = "txtDeductionSBSI"
        Me.txtDeductionSBSI.Size = New System.Drawing.Size(157, 26)
        Me.txtDeductionSBSI.TabIndex = 170
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(189, 156)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 20)
        Me.Label4.TabIndex = 169
        Me.Label4.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(37, 156)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 20)
        Me.Label5.TabIndex = 168
        Me.Label5.Text = "Deduction SPSI"
        '
        'txtDeductionSPSB
        '
        Me.txtDeductionSPSB.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtDeductionSPSB.Location = New System.Drawing.Point(224, 196)
        Me.txtDeductionSPSB.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtDeductionSPSB.Name = "txtDeductionSPSB"
        Me.txtDeductionSPSB.Size = New System.Drawing.Size(157, 26)
        Me.txtDeductionSPSB.TabIndex = 173
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(189, 202)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 172
        Me.Label6.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(37, 202)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(146, 20)
        Me.Label7.TabIndex = 171
        Me.Label7.Text = "Deduction SBSI"
        '
        'txtTunjanganBeras
        '
        Me.txtTunjanganBeras.Increment = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txtTunjanganBeras.Location = New System.Drawing.Point(224, 238)
        Me.txtTunjanganBeras.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtTunjanganBeras.Name = "txtTunjanganBeras"
        Me.txtTunjanganBeras.Size = New System.Drawing.Size(157, 26)
        Me.txtTunjanganBeras.TabIndex = 176
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(189, 244)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 20)
        Me.Label8.TabIndex = 175
        Me.Label8.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(37, 244)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 20)
        Me.Label9.TabIndex = 174
        Me.Label9.Text = "Harga Beras"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dtOtherMonthYear)
        Me.Panel1.Controls.Add(Me.optPreviousBonus)
        Me.Panel1.Location = New System.Drawing.Point(442, 104)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(222, 118)
        Me.Panel1.TabIndex = 177
        '
        'dtOtherMonthYear
        '
        Me.dtOtherMonthYear.CustomFormat = "MMMM/yyyy"
        Me.dtOtherMonthYear.Enabled = False
        Me.dtOtherMonthYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtOtherMonthYear.Location = New System.Drawing.Point(4, 59)
        Me.dtOtherMonthYear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtOtherMonthYear.Name = "dtOtherMonthYear"
        Me.dtOtherMonthYear.Size = New System.Drawing.Size(207, 26)
        Me.dtOtherMonthYear.TabIndex = 178
        '
        'optPreviousBonus
        '
        Me.optPreviousBonus.AutoSize = True
        Me.optPreviousBonus.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.optPreviousBonus.Location = New System.Drawing.Point(4, 15)
        Me.optPreviousBonus.Name = "optPreviousBonus"
        Me.optPreviousBonus.Size = New System.Drawing.Size(207, 24)
        Me.optPreviousBonus.TabIndex = 0
        Me.optPreviousBonus.Text = "Use Other Bonus Month"
        Me.optPreviousBonus.UseVisualStyleBackColor = True
        '
        'Bonus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(717, 464)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtTunjanganBeras)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDeductionSPSB)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDeductionSBSI)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNoofMonths)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpProcDate)
        Me.Controls.Add(Me.lblColon1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblBNik)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Bonus"
        Me.Text = "THR"
        CType(Me.txtNoofMonths, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDeductionSBSI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDeductionSPSB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTunjanganBeras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNoofMonths As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtDeductionSBSI As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDeductionSPSB As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTunjanganBeras As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtOtherMonthYear As System.Windows.Forms.DateTimePicker
    Friend WithEvents optPreviousBonus As System.Windows.Forms.CheckBox
End Class

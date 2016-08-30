<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalarySelectionReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalarySelectionReport))
        Me.CboCategory = New System.Windows.Forms.ComboBox
        Me.lblCategory = New System.Windows.Forms.Label
        Me.lblColon2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpProcessingDate = New System.Windows.Forms.DateTimePicker
        Me.chkProcessingDate = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CboCategory
        '
        Me.CboCategory.FormattingEnabled = True
        Me.CboCategory.Items.AddRange(New Object() {"ALL CATEGORY", "BHL", "KHT", "HIP"})
        Me.CboCategory.Location = New System.Drawing.Point(202, 29)
        Me.CboCategory.Name = "CboCategory"
        Me.CboCategory.Size = New System.Drawing.Size(135, 21)
        Me.CboCategory.TabIndex = 157
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(15, 31)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(60, 13)
        Me.lblCategory.TabIndex = 155
        Me.lblCategory.Text = "Category"
        '
        'lblColon2
        '
        Me.lblColon2.AutoSize = True
        Me.lblColon2.BackColor = System.Drawing.Color.Transparent
        Me.lblColon2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon2.Location = New System.Drawing.Point(185, 32)
        Me.lblColon2.Name = "lblColon2"
        Me.lblColon2.Size = New System.Drawing.Size(12, 13)
        Me.lblColon2.TabIndex = 156
        Me.lblColon2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Processing Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(185, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 13)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = ":"
        '
        'dtpProcessingDate
        '
        Me.dtpProcessingDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpProcessingDate.Enabled = False
        Me.dtpProcessingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpProcessingDate.Location = New System.Drawing.Point(202, 56)
        Me.dtpProcessingDate.Name = "dtpProcessingDate"
        Me.dtpProcessingDate.Size = New System.Drawing.Size(135, 20)
        Me.dtpProcessingDate.TabIndex = 160
        '
        'chkProcessingDate
        '
        Me.chkProcessingDate.AutoSize = True
        Me.chkProcessingDate.Location = New System.Drawing.Point(352, 62)
        Me.chkProcessingDate.Name = "chkProcessingDate"
        Me.chkProcessingDate.Size = New System.Drawing.Size(15, 14)
        Me.chkProcessingDate.TabIndex = 161
        Me.chkProcessingDate.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.dtpProcessingDate)
        Me.GroupBox1.Controls.Add(Me.chkProcessingDate)
        Me.GroupBox1.Controls.Add(Me.lblColon2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CboCategory)
        Me.GroupBox1.Controls.Add(Me.lblCategory)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(636, 119)
        Me.GroupBox1.TabIndex = 162
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(460, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(166, 30)
        Me.Button1.TabIndex = 201
        Me.Button1.Text = "Salary Report"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'SalarySelectionReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(667, 147)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SalarySelectionReport"
        Me.Text = "Selection Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblColon2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpProcessingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkProcessingDate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class

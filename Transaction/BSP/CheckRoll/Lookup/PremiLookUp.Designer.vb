<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PremiLookUp
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PremiLookUp))
        Me.dgpremi = New System.Windows.Forms.DataGridView
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblsearchCategory = New System.Windows.Forms.Label
        Me.lblAttID = New System.Windows.Forms.Label
        Me.txtAttendanceCode = New System.Windows.Forms.TextBox
        Me.txtBlockID = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.dgpremi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgpremi
        '
        Me.dgpremi.AllowUserToAddRows = False
        Me.dgpremi.AllowUserToDeleteRows = False
        Me.dgpremi.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgpremi.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgpremi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgpremi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgpremi.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgpremi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgpremi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgpremi.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgpremi.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgpremi.EnableHeadersVisualStyles = False
        Me.dgpremi.GridColor = System.Drawing.Color.Gray
        Me.dgpremi.Location = New System.Drawing.Point(10, 41)
        Me.dgpremi.MultiSelect = False
        Me.dgpremi.Name = "dgpremi"
        Me.dgpremi.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgpremi.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgpremi.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgpremi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgpremi.Size = New System.Drawing.Size(703, 117)
        Me.dgpremi.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(595, 164)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(118, 29)
        Me.btnClose.TabIndex = 119
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblsearchCategory
        '
        Me.lblsearchCategory.AutoSize = True
        Me.lblsearchCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchCategory.Location = New System.Drawing.Point(7, 16)
        Me.lblsearchCategory.Name = "lblsearchCategory"
        Me.lblsearchCategory.Size = New System.Drawing.Size(101, 13)
        Me.lblsearchCategory.TabIndex = 120
        Me.lblsearchCategory.Text = "Premi Preview"
        '
        'lblAttID
        '
        Me.lblAttID.AutoSize = True
        Me.lblAttID.BackColor = System.Drawing.Color.Transparent
        Me.lblAttID.Location = New System.Drawing.Point(538, 16)
        Me.lblAttID.Name = "lblAttID"
        Me.lblAttID.Size = New System.Drawing.Size(39, 13)
        Me.lblAttID.TabIndex = 121
        Me.lblAttID.Text = "Label1"
        Me.lblAttID.Visible = False
        '
        'txtAttendanceCode
        '
        Me.txtAttendanceCode.Location = New System.Drawing.Point(583, 13)
        Me.txtAttendanceCode.Name = "txtAttendanceCode"
        Me.txtAttendanceCode.Size = New System.Drawing.Size(114, 20)
        Me.txtAttendanceCode.TabIndex = 122
        Me.txtAttendanceCode.Visible = False
        '
        'txtBlockID
        '
        Me.txtBlockID.Location = New System.Drawing.Point(386, 13)
        Me.txtBlockID.Name = "txtBlockID"
        Me.txtBlockID.Size = New System.Drawing.Size(146, 20)
        Me.txtBlockID.TabIndex = 122
        Me.txtBlockID.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblsearchCategory)
        Me.GroupBox1.Controls.Add(Me.txtBlockID)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.lblAttID)
        Me.GroupBox1.Controls.Add(Me.dgpremi)
        Me.GroupBox1.Controls.Add(Me.txtAttendanceCode)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(721, 201)
        Me.GroupBox1.TabIndex = 123
        Me.GroupBox1.TabStop = False
        '
        'PremiLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(727, 209)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "PremiLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgpremi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgpremi As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents lblAttID As System.Windows.Forms.Label
    Friend WithEvents txtAttendanceCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBlockID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class

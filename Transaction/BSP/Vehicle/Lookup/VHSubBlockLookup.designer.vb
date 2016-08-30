<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VHSubBlockLookup
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.rbDIVCode = New System.Windows.Forms.RadioButton
        Me.rbYOPCode = New System.Windows.Forms.RadioButton
        Me.dgvSubBlockCode = New System.Windows.Forms.DataGridView
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.btnGo = New System.Windows.Forms.Button
        Me.txtSearchBy = New System.Windows.Forms.TextBox
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.rbSubBlock = New System.Windows.Forms.RadioButton
        Me.Div = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YOP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlockName = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvSubBlockCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbDIVCode
        '
        Me.rbDIVCode.AutoSize = True
        Me.rbDIVCode.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDIVCode.Location = New System.Drawing.Point(249, 33)
        Me.rbDIVCode.Name = "rbDIVCode"
        Me.rbDIVCode.Size = New System.Drawing.Size(47, 18)
        Me.rbDIVCode.TabIndex = 35
        Me.rbDIVCode.Text = "Afdeling"
        Me.rbDIVCode.UseVisualStyleBackColor = True
        '
        'rbYOPCode
        '
        Me.rbYOPCode.AutoSize = True
        Me.rbYOPCode.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbYOPCode.Location = New System.Drawing.Point(193, 33)
        Me.rbYOPCode.Name = "rbYOPCode"
        Me.rbYOPCode.Size = New System.Drawing.Size(50, 18)
        Me.rbYOPCode.TabIndex = 34
        Me.rbYOPCode.Text = "YOP"
        Me.rbYOPCode.UseVisualStyleBackColor = True
        '
        'dgvSubBlockCode
        '
        Me.dgvSubBlockCode.AllowUserToAddRows = False
        Me.dgvSubBlockCode.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSubBlockCode.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSubBlockCode.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSubBlockCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSubBlockCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSubBlockCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSubBlockCode.ColumnHeadersHeight = 35
        Me.dgvSubBlockCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Div, Me.YOP, Me.BlockName})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSubBlockCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSubBlockCode.EnableHeadersVisualStyles = False
        Me.dgvSubBlockCode.Location = New System.Drawing.Point(23, 121)
        Me.dgvSubBlockCode.MultiSelect = False
        Me.dgvSubBlockCode.Name = "dgvSubBlockCode"
        Me.dgvSubBlockCode.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSubBlockCode.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSubBlockCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSubBlockCode.Size = New System.Drawing.Size(376, 152)
        Me.dgvSubBlockCode.TabIndex = 28
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(431, 57)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 33
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnViewReport
        '
        Me.btnViewReport.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.Location = New System.Drawing.Point(351, 57)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(75, 23)
        Me.btnViewReport.TabIndex = 32
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.Location = New System.Drawing.Point(271, 57)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 31
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'txtSearchBy
        '
        Me.txtSearchBy.BackColor = System.Drawing.SystemColors.Window
        Me.txtSearchBy.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchBy.Location = New System.Drawing.Point(23, 57)
        Me.txtSearchBy.Name = "txtSearchBy"
        Me.txtSearchBy.Size = New System.Drawing.Size(240, 22)
        Me.txtSearchBy.TabIndex = 30
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchBy.Location = New System.Drawing.Point(23, 33)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(78, 14)
        Me.lblSearchBy.TabIndex = 29
        Me.lblSearchBy.Text = "Search By :"
        '
        'rbSubBlock
        '
        Me.rbSubBlock.AutoSize = True
        Me.rbSubBlock.Checked = True
        Me.rbSubBlock.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSubBlock.Location = New System.Drawing.Point(104, 33)
        Me.rbSubBlock.Name = "rbSubBlock"
        Me.rbSubBlock.Size = New System.Drawing.Size(85, 18)
        Me.rbSubBlock.TabIndex = 27
        Me.rbSubBlock.TabStop = True
        Me.rbSubBlock.Text = "Field No"
        Me.rbSubBlock.UseVisualStyleBackColor = True
        '
        'Div
        '
        Me.Div.DataPropertyName = "Div"
        Me.Div.HeaderText = "Afdeling Code"
        Me.Div.Name = "Div"
        Me.Div.ReadOnly = True
        '
        'YOP
        '
        Me.YOP.DataPropertyName = "YOP"
        Me.YOP.HeaderText = "Yop Code"
        Me.YOP.Name = "YOP"
        Me.YOP.ReadOnly = True
        '
        'BlockName
        '
        Me.BlockName.DataPropertyName = "BlockName"
        Me.BlockName.HeaderText = "FieldNo Name"
        Me.BlockName.Name = "BlockName"
        Me.BlockName.ReadOnly = True
        Me.BlockName.Width = 130
        '
        'VHSubBlockLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(529, 307)
        Me.Controls.Add(Me.rbDIVCode)
        Me.Controls.Add(Me.rbYOPCode)
        Me.Controls.Add(Me.dgvSubBlockCode)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnViewReport)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.txtSearchBy)
        Me.Controls.Add(Me.lblSearchBy)
        Me.Controls.Add(Me.rbSubBlock)
        Me.Name = "VHSubBlockLookup"
        Me.Text = "Sub-Block Lookup"
        CType(Me.dgvSubBlockCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbDIVCode As System.Windows.Forms.RadioButton
    Friend WithEvents rbYOPCode As System.Windows.Forms.RadioButton
    Friend WithEvents dgvSubBlockCode As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents txtSearchBy As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents rbSubBlock As System.Windows.Forms.RadioButton
    Friend WithEvents Div As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlockName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VHMasterLookup
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
        Me.dgvVehicleDetails = New System.Windows.Forms.DataGridView
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.btnGo = New System.Windows.Forms.Button
        Me.txtSearchBy = New System.Windows.Forms.TextBox
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.rbModel = New System.Windows.Forms.RadioButton
        Me.rbName = New System.Windows.Forms.RadioButton
        Me.rbVehicleCode = New System.Windows.Forms.RadioButton
        Me.VHWSCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHModel = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvVehicleDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvVehicleDetails
        '
        Me.dgvVehicleDetails.AllowUserToAddRows = False
        Me.dgvVehicleDetails.AllowUserToDeleteRows = False
        Me.dgvVehicleDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvVehicleDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVehicleDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVehicleDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvVehicleDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVehicleDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVehicleDetails.ColumnHeadersHeight = 35
        Me.dgvVehicleDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VHWSCode, Me.Category, Me.VHModel})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVehicleDetails.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVehicleDetails.EnableHeadersVisualStyles = False
        Me.dgvVehicleDetails.Location = New System.Drawing.Point(23, 124)
        Me.dgvVehicleDetails.MultiSelect = False
        Me.dgvVehicleDetails.Name = "dgvVehicleDetails"
        Me.dgvVehicleDetails.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVehicleDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvVehicleDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVehicleDetails.Size = New System.Drawing.Size(376, 200)
        Me.dgvVehicleDetails.TabIndex = 9
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(431, 60)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 16
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnViewReport
        '
        Me.btnViewReport.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.Location = New System.Drawing.Point(351, 60)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(75, 23)
        Me.btnViewReport.TabIndex = 15
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.Location = New System.Drawing.Point(271, 60)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 14
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'txtSearchBy
        '
        Me.txtSearchBy.BackColor = System.Drawing.SystemColors.Window
        Me.txtSearchBy.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchBy.Location = New System.Drawing.Point(23, 60)
        Me.txtSearchBy.Name = "txtSearchBy"
        Me.txtSearchBy.Size = New System.Drawing.Size(240, 22)
        Me.txtSearchBy.TabIndex = 13
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchBy.Location = New System.Drawing.Point(23, 36)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(78, 14)
        Me.lblSearchBy.TabIndex = 12
        Me.lblSearchBy.Text = "Search By :"
        '
        'rbModel
        '
        Me.rbModel.AutoSize = True
        Me.rbModel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbModel.Location = New System.Drawing.Point(280, 36)
        Me.rbModel.Name = "rbModel"
        Me.rbModel.Size = New System.Drawing.Size(62, 18)
        Me.rbModel.TabIndex = 11
        Me.rbModel.Text = "Model"
        Me.rbModel.UseVisualStyleBackColor = True
        '
        'rbName
        '
        Me.rbName.AutoSize = True
        Me.rbName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbName.Location = New System.Drawing.Point(216, 36)
        Me.rbName.Name = "rbName"
        Me.rbName.Size = New System.Drawing.Size(61, 18)
        Me.rbName.TabIndex = 10
        Me.rbName.Text = "Name"
        Me.rbName.UseVisualStyleBackColor = True
        '
        'rbVehicleCode
        '
        Me.rbVehicleCode.AutoSize = True
        Me.rbVehicleCode.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.rbVehicleCode.Checked = True
        Me.rbVehicleCode.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVehicleCode.Location = New System.Drawing.Point(104, 36)
        Me.rbVehicleCode.Name = "rbVehicleCode"
        Me.rbVehicleCode.Size = New System.Drawing.Size(106, 18)
        Me.rbVehicleCode.TabIndex = 8
        Me.rbVehicleCode.TabStop = True
        Me.rbVehicleCode.Text = "Vehicle Code"
        Me.rbVehicleCode.UseVisualStyleBackColor = True
        '
        'VHWSCode
        '
        Me.VHWSCode.DataPropertyName = "VHWSCode"
        Me.VHWSCode.HeaderText = "Vehicle Code"
        Me.VHWSCode.Name = "VHWSCode"
        Me.VHWSCode.ReadOnly = True
        '
        'Category
        '
        Me.Category.DataPropertyName = "Category"
        Me.Category.HeaderText = "Name"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        '
        'VHModel
        '
        Me.VHModel.DataPropertyName = "VHModel"
        Me.VHModel.HeaderText = "Model"
        Me.VHModel.Name = "VHModel"
        Me.VHModel.ReadOnly = True
        '
        'VehicleLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(529, 339)
        Me.Controls.Add(Me.dgvVehicleDetails)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnViewReport)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.txtSearchBy)
        Me.Controls.Add(Me.lblSearchBy)
        Me.Controls.Add(Me.rbModel)
        Me.Controls.Add(Me.rbName)
        Me.Controls.Add(Me.rbVehicleCode)
        Me.Name = "VehicleLookup"
        Me.Text = "Vehicle Lookup"
        CType(Me.dgvVehicleDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvVehicleDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents txtSearchBy As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents rbModel As System.Windows.Forms.RadioButton
    Friend WithEvents rbName As System.Windows.Forms.RadioButton
    Friend WithEvents rbVehicleCode As System.Windows.Forms.RadioButton
    Friend WithEvents VHWSCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHModel As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OperatorLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OperatorLookup))
        Me.dgvOperatorCode = New System.Windows.Forms.DataGridView
        Me.dgclEmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclEmpCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclEmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblsearchDiv = New System.Windows.Forms.Label
        Me.txtOperatorCodeSearch = New System.Windows.Forms.TextBox
        Me.panOperatorLookUp = New Stepi.UI.ExtendedPanel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOperatorSearch = New System.Windows.Forms.Button
        Me.lblOperatoNameSearch = New System.Windows.Forms.Label
        Me.txtOperatorNameSearch = New System.Windows.Forms.TextBox
        Me.lblOperatorCodeSearch = New System.Windows.Forms.Label
        CType(Me.dgvOperatorCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panOperatorLookUp.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvOperatorCode
        '
        Me.dgvOperatorCode.AllowUserToAddRows = False
        Me.dgvOperatorCode.AllowUserToDeleteRows = False
        Me.dgvOperatorCode.AllowUserToOrderColumns = True
        Me.dgvOperatorCode.AllowUserToResizeColumns = False
        Me.dgvOperatorCode.AllowUserToResizeRows = False
        Me.dgvOperatorCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvOperatorCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvOperatorCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOperatorCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOperatorCode.ColumnHeadersHeight = 30
        Me.dgvOperatorCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvOperatorCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclEmpID, Me.dgclEmpCode, Me.dgclEmpName})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOperatorCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOperatorCode.EnableHeadersVisualStyles = False
        Me.dgvOperatorCode.GridColor = System.Drawing.Color.Gray
        Me.dgvOperatorCode.Location = New System.Drawing.Point(0, 119)
        Me.dgvOperatorCode.MultiSelect = False
        Me.dgvOperatorCode.Name = "dgvOperatorCode"
        Me.dgvOperatorCode.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOperatorCode.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOperatorCode.RowHeadersVisible = False
        Me.dgvOperatorCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOperatorCode.Size = New System.Drawing.Size(421, 348)
        Me.dgvOperatorCode.TabIndex = 19
        '
        'dgclEmpID
        '
        Me.dgclEmpID.DataPropertyName = "EmpID"
        Me.dgclEmpID.HeaderText = "EmpID"
        Me.dgclEmpID.Name = "dgclEmpID"
        Me.dgclEmpID.ReadOnly = True
        Me.dgclEmpID.Visible = False
        Me.dgclEmpID.Width = 70
        '
        'dgclEmpCode
        '
        Me.dgclEmpCode.DataPropertyName = "EmpCode"
        Me.dgclEmpCode.HeaderText = "Operator Code"
        Me.dgclEmpCode.Name = "dgclEmpCode"
        Me.dgclEmpCode.ReadOnly = True
        Me.dgclEmpCode.Width = 116
        '
        'dgclEmpName
        '
        Me.dgclEmpName.DataPropertyName = "EmpName"
        Me.dgclEmpName.HeaderText = "Operator Name"
        Me.dgclEmpName.Name = "dgclEmpName"
        Me.dgclEmpName.ReadOnly = True
        Me.dgclEmpName.Width = 119
        '
        'lblsearchDiv
        '
        Me.lblsearchDiv.AutoSize = True
        Me.lblsearchDiv.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchDiv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchDiv.Location = New System.Drawing.Point(4, 52)
        Me.lblsearchDiv.Name = "lblsearchDiv"
        Me.lblsearchDiv.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchDiv.TabIndex = 54
        Me.lblsearchDiv.Text = "Search By"
        '
        'txtOperatorCodeSearch
        '
        Me.txtOperatorCodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtOperatorCodeSearch.Location = New System.Drawing.Point(3, 93)
        Me.txtOperatorCodeSearch.Name = "txtOperatorCodeSearch"
        Me.txtOperatorCodeSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtOperatorCodeSearch.TabIndex = 101
        '
        'panOperatorLookUp
        '
        Me.panOperatorLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panOperatorLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panOperatorLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panOperatorLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panOperatorLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panOperatorLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panOperatorLookUp.CaptionSize = 40
        Me.panOperatorLookUp.CaptionText = "Select Operator"
        Me.panOperatorLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panOperatorLookUp.Controls.Add(Me.btnClose)
        Me.panOperatorLookUp.Controls.Add(Me.Label1)
        Me.panOperatorLookUp.Controls.Add(Me.btnOperatorSearch)
        Me.panOperatorLookUp.Controls.Add(Me.lblOperatoNameSearch)
        Me.panOperatorLookUp.Controls.Add(Me.txtOperatorNameSearch)
        Me.panOperatorLookUp.Controls.Add(Me.lblOperatorCodeSearch)
        Me.panOperatorLookUp.Controls.Add(Me.lblsearchDiv)
        Me.panOperatorLookUp.Controls.Add(Me.txtOperatorCodeSearch)
        Me.panOperatorLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panOperatorLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panOperatorLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panOperatorLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panOperatorLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panOperatorLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panOperatorLookUp.Name = "panOperatorLookUp"
        Me.panOperatorLookUp.Size = New System.Drawing.Size(421, 119)
        Me.panOperatorLookUp.TabIndex = 18
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(385, 86)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 105
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(82, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = " :"
        '
        'btnOperatorSearch
        '
        Me.btnOperatorSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnOperatorSearch.BackgroundImage = CType(resources.GetObject("btnOperatorSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnOperatorSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnOperatorSearch.FlatAppearance.BorderSize = 0
        Me.btnOperatorSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnOperatorSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOperatorSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOperatorSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOperatorSearch.Location = New System.Drawing.Point(359, 86)
        Me.btnOperatorSearch.Name = "btnOperatorSearch"
        Me.btnOperatorSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnOperatorSearch.TabIndex = 104
        Me.btnOperatorSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOperatorSearch.UseVisualStyleBackColor = False
        '
        'lblOperatoNameSearch
        '
        Me.lblOperatoNameSearch.AutoSize = True
        Me.lblOperatoNameSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblOperatoNameSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperatoNameSearch.Location = New System.Drawing.Point(181, 77)
        Me.lblOperatoNameSearch.Name = "lblOperatoNameSearch"
        Me.lblOperatoNameSearch.Size = New System.Drawing.Size(114, 13)
        Me.lblOperatoNameSearch.TabIndex = 106
        Me.lblOperatoNameSearch.Text = "Operator Name :"
        '
        'txtOperatorNameSearch
        '
        Me.txtOperatorNameSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtOperatorNameSearch.Location = New System.Drawing.Point(181, 93)
        Me.txtOperatorNameSearch.Name = "txtOperatorNameSearch"
        Me.txtOperatorNameSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtOperatorNameSearch.TabIndex = 105
        '
        'lblOperatorCodeSearch
        '
        Me.lblOperatorCodeSearch.AutoSize = True
        Me.lblOperatorCodeSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblOperatorCodeSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperatorCodeSearch.Location = New System.Drawing.Point(3, 77)
        Me.lblOperatorCodeSearch.Name = "lblOperatorCodeSearch"
        Me.lblOperatorCodeSearch.Size = New System.Drawing.Size(109, 13)
        Me.lblOperatorCodeSearch.TabIndex = 104
        Me.lblOperatorCodeSearch.Text = "Operator Code :"
        '
        'OperatorLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 467)
        Me.Controls.Add(Me.dgvOperatorCode)
        Me.Controls.Add(Me.panOperatorLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "OperatorLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "VHOperatorLookup"
        CType(Me.dgvOperatorCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panOperatorLookUp.ResumeLayout(False)
        Me.panOperatorLookUp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvOperatorCode As System.Windows.Forms.DataGridView
    Friend WithEvents lblsearchDiv As System.Windows.Forms.Label
    Friend WithEvents txtOperatorCodeSearch As System.Windows.Forms.TextBox
    Friend WithEvents panOperatorLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents lblOperatorCodeSearch As System.Windows.Forms.Label
    Friend WithEvents lblOperatoNameSearch As System.Windows.Forms.Label
    Friend WithEvents txtOperatorNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnOperatorSearch As System.Windows.Forms.Button
    Friend WithEvents dgclEmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclEmpCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclEmpName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

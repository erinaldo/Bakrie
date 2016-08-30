<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PressNoLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PressNoLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panPressNoLookup = New Stepi.UI.ExtendedPanel
        Me.lblPressNoSearch = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblsearchDiv = New System.Windows.Forms.Label
        Me.btnPressNoSearch = New System.Windows.Forms.Button
        Me.txtPressNoSearch = New System.Windows.Forms.TextBox
        Me.dgPressNo = New System.Windows.Forms.DataGridView
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.dgMachineID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgMachineCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgMachineName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgCapacity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.panPressNoLookup.SuspendLayout()
        CType(Me.dgPressNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panPressNoLookup
        '
        Me.panPressNoLookup.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panPressNoLookup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panPressNoLookup.BorderColor = System.Drawing.Color.Gray
        Me.panPressNoLookup.CaptionColorOne = System.Drawing.Color.White
        Me.panPressNoLookup.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panPressNoLookup.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPressNoLookup.CaptionSize = 40
        Me.panPressNoLookup.CaptionText = "Select Press No"
        Me.panPressNoLookup.CaptionTextColor = System.Drawing.Color.Black
        Me.panPressNoLookup.Controls.Add(Me.lblPressNoSearch)
        Me.panPressNoLookup.Controls.Add(Me.btnClose)
        Me.panPressNoLookup.Controls.Add(Me.lblsearchDiv)
        Me.panPressNoLookup.Controls.Add(Me.btnPressNoSearch)
        Me.panPressNoLookup.Controls.Add(Me.txtPressNoSearch)
        Me.panPressNoLookup.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panPressNoLookup.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panPressNoLookup.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panPressNoLookup.Dock = System.Windows.Forms.DockStyle.Top
        Me.panPressNoLookup.ForeColor = System.Drawing.Color.DimGray
        Me.panPressNoLookup.Location = New System.Drawing.Point(0, 0)
        Me.panPressNoLookup.Name = "panPressNoLookup"
        Me.panPressNoLookup.Size = New System.Drawing.Size(421, 119)
        Me.panPressNoLookup.TabIndex = 19
        '
        'lblPressNoSearch
        '
        Me.lblPressNoSearch.AutoSize = True
        Me.lblPressNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblPressNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressNoSearch.Location = New System.Drawing.Point(3, 77)
        Me.lblPressNoSearch.Name = "lblPressNoSearch"
        Me.lblPressNoSearch.Size = New System.Drawing.Size(72, 13)
        Me.lblPressNoSearch.TabIndex = 104
        Me.lblPressNoSearch.Text = "Press No :"
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
        Me.btnClose.Location = New System.Drawing.Point(214, 87)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 2
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
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
        'btnPressNoSearch
        '
        Me.btnPressNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnPressNoSearch.BackgroundImage = CType(resources.GetObject("btnPressNoSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnPressNoSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnPressNoSearch.FlatAppearance.BorderSize = 0
        Me.btnPressNoSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnPressNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPressNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPressNoSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPressNoSearch.Location = New System.Drawing.Point(188, 87)
        Me.btnPressNoSearch.Name = "btnPressNoSearch"
        Me.btnPressNoSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnPressNoSearch.TabIndex = 1
        Me.btnPressNoSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPressNoSearch.UseVisualStyleBackColor = False
        '
        'txtPressNoSearch
        '
        Me.txtPressNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtPressNoSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPressNoSearch.Location = New System.Drawing.Point(3, 93)
        Me.txtPressNoSearch.Name = "txtPressNoSearch"
        Me.txtPressNoSearch.Size = New System.Drawing.Size(172, 21)
        Me.txtPressNoSearch.TabIndex = 0
        '
        'dgPressNo
        '
        Me.dgPressNo.AllowUserToAddRows = False
        Me.dgPressNo.AllowUserToDeleteRows = False
        Me.dgPressNo.AllowUserToOrderColumns = True
        Me.dgPressNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgPressNo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgPressNo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgPressNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgPressNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPressNo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgPressNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgMachineID, Me.dgMachineCode, Me.dgMachineName, Me.dgCapacity})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPressNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgPressNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPressNo.EnableHeadersVisualStyles = False
        Me.dgPressNo.GridColor = System.Drawing.Color.Gray
        Me.dgPressNo.Location = New System.Drawing.Point(0, 119)
        Me.dgPressNo.MultiSelect = False
        Me.dgPressNo.Name = "dgPressNo"
        Me.dgPressNo.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPressNo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgPressNo.RowHeadersVisible = False
        Me.dgPressNo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgPressNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPressNo.Size = New System.Drawing.Size(421, 348)
        Me.dgPressNo.TabIndex = 3
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(108, 234)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 114
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'dgMachineID
        '
        Me.dgMachineID.DataPropertyName = "MachineID"
        Me.dgMachineID.HeaderText = "WeighingID"
        Me.dgMachineID.Name = "dgMachineID"
        Me.dgMachineID.ReadOnly = True
        Me.dgMachineID.Visible = False
        Me.dgMachineID.Width = 97
        '
        'dgMachineCode
        '
        Me.dgMachineCode.DataPropertyName = "MachineCode"
        Me.dgMachineCode.HeaderText = "Press No"
        Me.dgMachineCode.Name = "dgMachineCode"
        Me.dgMachineCode.ReadOnly = True
        Me.dgMachineCode.Width = 81
        '
        'dgMachineName
        '
        Me.dgMachineName.DataPropertyName = "MachineName"
        Me.dgMachineName.HeaderText = "Machine Name"
        Me.dgMachineName.Name = "dgMachineName"
        Me.dgMachineName.ReadOnly = True
        Me.dgMachineName.Width = 114
        '
        'dgCapacity
        '
        Me.dgCapacity.DataPropertyName = "Capacity"
        Me.dgCapacity.HeaderText = "Capacity"
        Me.dgCapacity.Name = "dgCapacity"
        Me.dgCapacity.ReadOnly = True
        Me.dgCapacity.Width = 81
        '
        'PressNoLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(421, 467)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgPressNo)
        Me.Controls.Add(Me.panPressNoLookup)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "PressNoLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Press No  Lookup"
        Me.panPressNoLookup.ResumeLayout(False)
        Me.panPressNoLookup.PerformLayout()
        CType(Me.dgPressNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panPressNoLookup As Stepi.UI.ExtendedPanel
    Friend WithEvents lblPressNoSearch As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchDiv As System.Windows.Forms.Label
    Friend WithEvents btnPressNoSearch As System.Windows.Forms.Button
    Friend WithEvents txtPressNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgPressNo As System.Windows.Forms.DataGridView
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents dgMachineID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMachineCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMachineName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCapacity As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

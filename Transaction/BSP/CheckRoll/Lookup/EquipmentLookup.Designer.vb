<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentLookup
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EquipmentLookup))
        Me.dgEquipment = New System.Windows.Forms.DataGridView()
        Me.dgclEquipmentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclEquipmentCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclEquipmentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblsearchEquipment = New System.Windows.Forms.Label()
        Me.panEquipmentLookUp = New Stepi.UI.ExtendedPanel()
        Me.txtEquipDescSearch = New System.Windows.Forms.TextBox()
        Me.lblEquipName = New System.Windows.Forms.Label()
        Me.lblEquipmentCode = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnEquipSearch = New System.Windows.Forms.Button()
        Me.txtEquipSearch = New System.Windows.Forms.TextBox()
        Me.lblNoRecord = New System.Windows.Forms.Label()
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panEquipmentLookUp.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgEquipment
        '
        Me.dgEquipment.AllowUserToAddRows = False
        Me.dgEquipment.AllowUserToDeleteRows = False
        Me.dgEquipment.AllowUserToOrderColumns = True
        Me.dgEquipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgEquipment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgEquipment.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgEquipment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgEquipment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgEquipment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgEquipment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclEquipmentID, Me.dgclEquipmentCode, Me.dgclEquipmentName})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgEquipment.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgEquipment.EnableHeadersVisualStyles = False
        Me.dgEquipment.GridColor = System.Drawing.Color.Gray
        Me.dgEquipment.Location = New System.Drawing.Point(0, 119)
        Me.dgEquipment.MultiSelect = False
        Me.dgEquipment.Name = "dgEquipment"
        Me.dgEquipment.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgEquipment.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgEquipment.RowHeadersVisible = False
        Me.dgEquipment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgEquipment.Size = New System.Drawing.Size(430, 352)
        Me.dgEquipment.TabIndex = 15
        '
        'dgclEquipmentID
        '
        Me.dgclEquipmentID.DataPropertyName = "MachineID"
        Me.dgclEquipmentID.HeaderText = "Equipment ID"
        Me.dgclEquipmentID.Name = "dgclEquipmentID"
        Me.dgclEquipmentID.ReadOnly = True
        Me.dgclEquipmentID.Visible = False
        Me.dgclEquipmentID.Width = 89
        '
        'dgclEquipmentCode
        '
        Me.dgclEquipmentCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclEquipmentCode.DataPropertyName = "MachineCode"
        Me.dgclEquipmentCode.HeaderText = "Equipment Code"
        Me.dgclEquipmentCode.Name = "dgclEquipmentCode"
        Me.dgclEquipmentCode.ReadOnly = True
        Me.dgclEquipmentCode.Width = 150
        '
        'dgclEquipmentName
        '
        Me.dgclEquipmentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclEquipmentName.DataPropertyName = "MachineName"
        Me.dgclEquipmentName.HeaderText = "Equipment Name"
        Me.dgclEquipmentName.Name = "dgclEquipmentName"
        Me.dgclEquipmentName.ReadOnly = True
        Me.dgclEquipmentName.Width = 200
        '
        'lblsearchEquipment
        '
        Me.lblsearchEquipment.AutoSize = True
        Me.lblsearchEquipment.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchEquipment.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchEquipment.Location = New System.Drawing.Point(3, 43)
        Me.lblsearchEquipment.Name = "lblsearchEquipment"
        Me.lblsearchEquipment.Size = New System.Drawing.Size(76, 13)
        Me.lblsearchEquipment.TabIndex = 54
        Me.lblsearchEquipment.Text = "Search By "
        '
        'panEquipmentLookUp
        '
        Me.panEquipmentLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panEquipmentLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panEquipmentLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panEquipmentLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panEquipmentLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panEquipmentLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panEquipmentLookUp.CaptionSize = 40
        Me.panEquipmentLookUp.CaptionText = "Select Equipment"
        Me.panEquipmentLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panEquipmentLookUp.Controls.Add(Me.txtEquipDescSearch)
        Me.panEquipmentLookUp.Controls.Add(Me.lblEquipName)
        Me.panEquipmentLookUp.Controls.Add(Me.lblEquipmentCode)
        Me.panEquipmentLookUp.Controls.Add(Me.btnClose)
        Me.panEquipmentLookUp.Controls.Add(Me.lblsearchEquipment)
        Me.panEquipmentLookUp.Controls.Add(Me.btnEquipSearch)
        Me.panEquipmentLookUp.Controls.Add(Me.txtEquipSearch)
        Me.panEquipmentLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panEquipmentLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panEquipmentLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panEquipmentLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panEquipmentLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panEquipmentLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panEquipmentLookUp.Name = "panEquipmentLookUp"
        Me.panEquipmentLookUp.Size = New System.Drawing.Size(430, 119)
        Me.panEquipmentLookUp.TabIndex = 14
        '
        'txtEquipDescSearch
        '
        Me.txtEquipDescSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtEquipDescSearch.Location = New System.Drawing.Point(184, 89)
        Me.txtEquipDescSearch.Name = "txtEquipDescSearch"
        Me.txtEquipDescSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtEquipDescSearch.TabIndex = 106
        '
        'lblEquipName
        '
        Me.lblEquipName.AutoSize = True
        Me.lblEquipName.BackColor = System.Drawing.Color.Transparent
        Me.lblEquipName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquipName.Location = New System.Drawing.Point(181, 67)
        Me.lblEquipName.Name = "lblEquipName"
        Me.lblEquipName.Size = New System.Drawing.Size(117, 13)
        Me.lblEquipName.TabIndex = 105
        Me.lblEquipName.Text = "Equipment Name"
        '
        'lblEquipmentCode
        '
        Me.lblEquipmentCode.AutoSize = True
        Me.lblEquipmentCode.BackColor = System.Drawing.Color.Transparent
        Me.lblEquipmentCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquipmentCode.Location = New System.Drawing.Point(3, 67)
        Me.lblEquipmentCode.Name = "lblEquipmentCode"
        Me.lblEquipmentCode.Size = New System.Drawing.Size(112, 13)
        Me.lblEquipmentCode.TabIndex = 104
        Me.lblEquipmentCode.Text = "Equipment Code"
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
        Me.btnClose.Location = New System.Drawing.Point(395, 85)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnEquipSearch
        '
        Me.btnEquipSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnEquipSearch.BackgroundImage = CType(resources.GetObject("btnEquipSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnEquipSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnEquipSearch.FlatAppearance.BorderSize = 0
        Me.btnEquipSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnEquipSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEquipSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEquipSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEquipSearch.Location = New System.Drawing.Point(360, 85)
        Me.btnEquipSearch.Name = "btnEquipSearch"
        Me.btnEquipSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnEquipSearch.TabIndex = 102
        Me.btnEquipSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEquipSearch.UseVisualStyleBackColor = False
        '
        'txtEquipSearch
        '
        Me.txtEquipSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtEquipSearch.Location = New System.Drawing.Point(6, 89)
        Me.txtEquipSearch.Name = "txtEquipSearch"
        Me.txtEquipSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtEquipSearch.TabIndex = 101
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(86, 229)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 112
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'EquipmentLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(430, 471)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgEquipment)
        Me.Controls.Add(Me.panEquipmentLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EquipmentLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Equipment Lookup"
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panEquipmentLookUp.ResumeLayout(False)
        Me.panEquipmentLookUp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgEquipment As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchEquipment As System.Windows.Forms.Label
    Friend WithEvents panEquipmentLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents btnEquipSearch As System.Windows.Forms.Button
    Friend WithEvents txtEquipSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblEquipName As System.Windows.Forms.Label
    Friend WithEvents lblEquipmentCode As System.Windows.Forms.Label
    Friend WithEvents txtEquipDescSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgclEquipmentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclEquipmentCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclEquipmentName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
End Class

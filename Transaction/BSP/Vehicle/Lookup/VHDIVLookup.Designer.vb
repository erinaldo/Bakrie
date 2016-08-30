<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VHDIVLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DivLookup))
        Me.dgDIV = New System.Windows.Forms.DataGridView
        Me.dgclDivID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclDiv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclDivName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblsearchDiv = New System.Windows.Forms.Label
        Me.btnDIVSearch = New System.Windows.Forms.Button
        Me.txtDIVSearch = New System.Windows.Forms.TextBox
        Me.panDIVLookUp = New Stepi.UI.ExtendedPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblDivNameSearch = New System.Windows.Forms.Label
        Me.txtDivNameSearch = New System.Windows.Forms.TextBox
        Me.lbldivSearch = New System.Windows.Forms.Label
        CType(Me.dgDIV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panDIVLookUp.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgDIV
        '
        Me.dgDIV.AllowUserToAddRows = False
        Me.dgDIV.AllowUserToDeleteRows = False
        Me.dgDIV.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgDIV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDIV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgDIV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgDIV.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgDIV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgDIV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDIV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgDIV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclDivID, Me.dgclDiv, Me.dgclDivName})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDIV.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgDIV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDIV.EnableHeadersVisualStyles = False
        Me.dgDIV.GridColor = System.Drawing.Color.Gray
        Me.dgDIV.Location = New System.Drawing.Point(0, 119)
        Me.dgDIV.MultiSelect = False
        Me.dgDIV.Name = "dgDIV"
        Me.dgDIV.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDIV.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgDIV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgDIV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDIV.Size = New System.Drawing.Size(421, 348)
        Me.dgDIV.TabIndex = 19
        '
        'dgclDivID
        '
        Me.dgclDivID.DataPropertyName = "DivID"
        Me.dgclDivID.HeaderText = "Afdeling ID"
        Me.dgclDivID.Name = "dgclDivID"
        Me.dgclDivID.ReadOnly = True
        Me.dgclDivID.Width = 68
        '
        'dgclDiv
        '
        Me.dgclDiv.DataPropertyName = "Div"
        Me.dgclDiv.HeaderText = "Afdeling"
        Me.dgclDiv.Name = "dgclDiv"
        Me.dgclDiv.ReadOnly = True
        Me.dgclDiv.Width = 53
        '
        'dgclDivName
        '
        Me.dgclDivName.DataPropertyName = "DivName"
        Me.dgclDivName.HeaderText = "Afdeling Name"
        Me.dgclDivName.Name = "dgclDivName"
        Me.dgclDivName.ReadOnly = True
        Me.dgclDivName.Width = 87
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
        Me.btnClose.Location = New System.Drawing.Point(387, 87)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
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
        'btnDIVSearch
        '
        Me.btnDIVSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnDIVSearch.BackgroundImage = CType(resources.GetObject("btnDIVSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnDIVSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnDIVSearch.FlatAppearance.BorderSize = 0
        Me.btnDIVSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnDIVSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDIVSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDIVSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDIVSearch.Location = New System.Drawing.Point(361, 87)
        Me.btnDIVSearch.Name = "btnDIVSearch"
        Me.btnDIVSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnDIVSearch.TabIndex = 102
        Me.btnDIVSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDIVSearch.UseVisualStyleBackColor = False
        '
        'txtDIVSearch
        '
        Me.txtDIVSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDIVSearch.Location = New System.Drawing.Point(3, 93)
        Me.txtDIVSearch.Name = "txtDIVSearch"
        Me.txtDIVSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtDIVSearch.TabIndex = 101
        '
        'panDIVLookUp
        '
        Me.panDIVLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panDIVLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panDIVLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panDIVLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panDIVLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panDIVLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panDIVLookUp.CaptionSize = 40
        Me.panDIVLookUp.CaptionText = "Select DIV"
        Me.panDIVLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panDIVLookUp.Controls.Add(Me.Label1)
        Me.panDIVLookUp.Controls.Add(Me.lblDivNameSearch)
        Me.panDIVLookUp.Controls.Add(Me.txtDivNameSearch)
        Me.panDIVLookUp.Controls.Add(Me.lbldivSearch)
        Me.panDIVLookUp.Controls.Add(Me.btnClose)
        Me.panDIVLookUp.Controls.Add(Me.lblsearchDiv)
        Me.panDIVLookUp.Controls.Add(Me.btnDIVSearch)
        Me.panDIVLookUp.Controls.Add(Me.txtDIVSearch)
        Me.panDIVLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panDIVLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panDIVLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panDIVLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panDIVLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panDIVLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panDIVLookUp.Name = "panDIVLookUp"
        Me.panDIVLookUp.Size = New System.Drawing.Size(421, 119)
        Me.panDIVLookUp.TabIndex = 18
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
        'lblDivNameSearch
        '
        Me.lblDivNameSearch.AutoSize = True
        Me.lblDivNameSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblDivNameSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivNameSearch.Location = New System.Drawing.Point(181, 77)
        Me.lblDivNameSearch.Name = "lblDivNameSearch"
        Me.lblDivNameSearch.Size = New System.Drawing.Size(75, 13)
        Me.lblDivNameSearch.TabIndex = 106
        Me.lblDivNameSearch.Text = "Afdeling Name:"
        '
        'txtDivNameSearch
        '
        Me.txtDivNameSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDivNameSearch.Location = New System.Drawing.Point(181, 93)
        Me.txtDivNameSearch.Name = "txtDivNameSearch"
        Me.txtDivNameSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtDivNameSearch.TabIndex = 105
        '
        'lbldivSearch
        '
        Me.lbldivSearch.AutoSize = True
        Me.lbldivSearch.BackColor = System.Drawing.Color.Transparent
        Me.lbldivSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldivSearch.Location = New System.Drawing.Point(3, 77)
        Me.lbldivSearch.Name = "lbldivSearch"
        Me.lbldivSearch.Size = New System.Drawing.Size(38, 13)
        Me.lbldivSearch.TabIndex = 104
        Me.lbldivSearch.Text = "Afdeling :"
        '
        'DivLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(421, 467)
        Me.Controls.Add(Me.dgDIV)
        Me.Controls.Add(Me.panDIVLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "VHDivLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "VHDivLookup"
        CType(Me.dgDIV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panDIVLookUp.ResumeLayout(False)
        Me.panDIVLookUp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgDIV As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchDiv As System.Windows.Forms.Label
    Friend WithEvents btnDIVSearch As System.Windows.Forms.Button
    Friend WithEvents txtDIVSearch As System.Windows.Forms.TextBox
    Friend WithEvents panDIVLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents lbldivSearch As System.Windows.Forms.Label
    Friend WithEvents dgclDivID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDiv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDivName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblDivNameSearch As System.Windows.Forms.Label
    Friend WithEvents txtDivNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

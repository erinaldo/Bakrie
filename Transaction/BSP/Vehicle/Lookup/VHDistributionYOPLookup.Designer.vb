<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VHDistributionYOPLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VHDistributionYOPLookup))
        Me.dgYOP = New System.Windows.Forms.DataGridView
        Me.dgclYOPID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclYOP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblsearchYOP = New System.Windows.Forms.Label
        Me.btnYOPSearch = New System.Windows.Forms.Button
        Me.txtYOPSearch = New System.Windows.Forms.TextBox
        Me.panYOPLookUp = New Stepi.UI.ExtendedPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblYOPName = New System.Windows.Forms.Label
        Me.txtYOPNameSearch = New System.Windows.Forms.TextBox
        Me.lblYOP = New System.Windows.Forms.Label
        CType(Me.dgYOP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panYOPLookUp.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgYOP
        '
        Me.dgYOP.AllowUserToAddRows = False
        Me.dgYOP.AllowUserToDeleteRows = False
        Me.dgYOP.AllowUserToOrderColumns = True
        Me.dgYOP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgYOP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgYOP.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgYOP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgYOP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgYOP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgYOP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclYOPID, Me.dgclYOP, Me.dgclName})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgYOP.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgYOP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgYOP.EnableHeadersVisualStyles = False
        Me.dgYOP.GridColor = System.Drawing.Color.Gray
        Me.dgYOP.Location = New System.Drawing.Point(0, 119)
        Me.dgYOP.MultiSelect = False
        Me.dgYOP.Name = "dgYOP"
        Me.dgYOP.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgYOP.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgYOP.RowHeadersVisible = False
        Me.dgYOP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgYOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgYOP.Size = New System.Drawing.Size(435, 331)
        Me.dgYOP.TabIndex = 17
        '
        'dgclYOPID
        '
        Me.dgclYOPID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclYOPID.DataPropertyName = "YOPID"
        Me.dgclYOPID.HeaderText = "YOP Id"
        Me.dgclYOPID.Name = "dgclYOPID"
        Me.dgclYOPID.ReadOnly = True
        '
        'dgclYOP
        '
        Me.dgclYOP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclYOP.DataPropertyName = "YOP"
        Me.dgclYOP.HeaderText = "YOP"
        Me.dgclYOP.Name = "dgclYOP"
        Me.dgclYOP.ReadOnly = True
        '
        'dgclName
        '
        Me.dgclName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclName.DataPropertyName = "Name"
        Me.dgclName.HeaderText = "Name"
        Me.dgclName.Name = "dgclName"
        Me.dgclName.ReadOnly = True
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
        Me.btnClose.Location = New System.Drawing.Point(395, 83)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblsearchYOP
        '
        Me.lblsearchYOP.AutoSize = True
        Me.lblsearchYOP.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchYOP.Location = New System.Drawing.Point(3, 41)
        Me.lblsearchYOP.Name = "lblsearchYOP"
        Me.lblsearchYOP.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchYOP.TabIndex = 54
        Me.lblsearchYOP.Text = "Search By"
        '
        'btnYOPSearch
        '
        Me.btnYOPSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnYOPSearch.BackgroundImage = CType(resources.GetObject("btnYOPSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnYOPSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnYOPSearch.FlatAppearance.BorderSize = 0
        Me.btnYOPSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnYOPSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYOPSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYOPSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnYOPSearch.Location = New System.Drawing.Point(360, 83)
        Me.btnYOPSearch.Name = "btnYOPSearch"
        Me.btnYOPSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnYOPSearch.TabIndex = 102
        Me.btnYOPSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnYOPSearch.UseVisualStyleBackColor = False
        '
        'txtYOPSearch
        '
        Me.txtYOPSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtYOPSearch.Location = New System.Drawing.Point(3, 89)
        Me.txtYOPSearch.Name = "txtYOPSearch"
        Me.txtYOPSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtYOPSearch.TabIndex = 101
        '
        'panYOPLookUp
        '
        Me.panYOPLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panYOPLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panYOPLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panYOPLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panYOPLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panYOPLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panYOPLookUp.CaptionSize = 40
        Me.panYOPLookUp.CaptionText = "Select YOP"
        Me.panYOPLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panYOPLookUp.Controls.Add(Me.Label1)
        Me.panYOPLookUp.Controls.Add(Me.lblYOPName)
        Me.panYOPLookUp.Controls.Add(Me.txtYOPNameSearch)
        Me.panYOPLookUp.Controls.Add(Me.lblYOP)
        Me.panYOPLookUp.Controls.Add(Me.btnClose)
        Me.panYOPLookUp.Controls.Add(Me.lblsearchYOP)
        Me.panYOPLookUp.Controls.Add(Me.btnYOPSearch)
        Me.panYOPLookUp.Controls.Add(Me.txtYOPSearch)
        Me.panYOPLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panYOPLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panYOPLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panYOPLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panYOPLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panYOPLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panYOPLookUp.Name = "panYOPLookUp"
        Me.panYOPLookUp.Size = New System.Drawing.Size(435, 119)
        Me.panYOPLookUp.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(78, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = ":"
        '
        'lblYOPName
        '
        Me.lblYOPName.AutoSize = True
        Me.lblYOPName.BackColor = System.Drawing.Color.Transparent
        Me.lblYOPName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOPName.Location = New System.Drawing.Point(182, 74)
        Me.lblYOPName.Name = "lblYOPName"
        Me.lblYOPName.Size = New System.Drawing.Size(69, 13)
        Me.lblYOPName.TabIndex = 106
        Me.lblYOPName.Text = "YOPName"
        '
        'txtYOPNameSearch
        '
        Me.txtYOPNameSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtYOPNameSearch.Location = New System.Drawing.Point(182, 90)
        Me.txtYOPNameSearch.Name = "txtYOPNameSearch"
        Me.txtYOPNameSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtYOPNameSearch.TabIndex = 105
        '
        'lblYOP
        '
        Me.lblYOP.AutoSize = True
        Me.lblYOP.BackColor = System.Drawing.Color.Transparent
        Me.lblYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOP.Location = New System.Drawing.Point(3, 73)
        Me.lblYOP.Name = "lblYOP"
        Me.lblYOP.Size = New System.Drawing.Size(32, 13)
        Me.lblYOP.TabIndex = 104
        Me.lblYOP.Text = "YOP"
        '
        'YOPLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(435, 450)
        Me.Controls.Add(Me.dgYOP)
        Me.Controls.Add(Me.panYOPLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "YOPLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "YOP Lookup"
        CType(Me.dgYOP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panYOPLookUp.ResumeLayout(False)
        Me.panYOPLookUp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgYOP As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchYOP As System.Windows.Forms.Label
    Friend WithEvents btnYOPSearch As System.Windows.Forms.Button
    Friend WithEvents txtYOPSearch As System.Windows.Forms.TextBox
    Friend WithEvents panYOPLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents lblYOPName As System.Windows.Forms.Label
    Friend WithEvents txtYOPNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblYOP As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgclYOPID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclYOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

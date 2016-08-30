<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccouontBatchLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccouontBatchLookup))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panLedgerBatchLookUp = New Stepi.UI.ExtendedPanel
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblsearchLedgerType = New System.Windows.Forms.Label
        Me.btnLedgerTypeSearch = New System.Windows.Forms.Button
        Me.txtLedgerTypeSearch = New System.Windows.Forms.TextBox
        Me.dgLedgerType = New System.Windows.Forms.DataGridView
        Me.LedgerType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LedgerDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LedgerSetupId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.panLedgerBatchLookUp.SuspendLayout()
        CType(Me.dgLedgerType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panLedgerBatchLookUp
        '
        Me.panLedgerBatchLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panLedgerBatchLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panLedgerBatchLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panLedgerBatchLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panLedgerBatchLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panLedgerBatchLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panLedgerBatchLookUp.CaptionSize = 40
        Me.panLedgerBatchLookUp.CaptionText = "Select Ledger Type"
        Me.panLedgerBatchLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panLedgerBatchLookUp.Controls.Add(Me.btnClose)
        Me.panLedgerBatchLookUp.Controls.Add(Me.lblsearchLedgerType)
        Me.panLedgerBatchLookUp.Controls.Add(Me.btnLedgerTypeSearch)
        Me.panLedgerBatchLookUp.Controls.Add(Me.txtLedgerTypeSearch)
        Me.panLedgerBatchLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panLedgerBatchLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panLedgerBatchLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panLedgerBatchLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panLedgerBatchLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panLedgerBatchLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panLedgerBatchLookUp.Name = "panLedgerBatchLookUp"
        Me.panLedgerBatchLookUp.Size = New System.Drawing.Size(410, 119)
        Me.panLedgerBatchLookUp.TabIndex = 12
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(367, 83)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblsearchLedgerType
        '
        Me.lblsearchLedgerType.AutoSize = True
        Me.lblsearchLedgerType.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchLedgerType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchLedgerType.Location = New System.Drawing.Point(10, 58)
        Me.lblsearchLedgerType.Name = "lblsearchLedgerType"
        Me.lblsearchLedgerType.Size = New System.Drawing.Size(161, 13)
        Me.lblsearchLedgerType.TabIndex = 54
        Me.lblsearchLedgerType.Text = "Search By Ledger Type:"
        '
        'btnLedgerTypeSearch
        '
        Me.btnLedgerTypeSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnLedgerTypeSearch.BackgroundImage = CType(resources.GetObject("btnLedgerTypeSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnLedgerTypeSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnLedgerTypeSearch.FlatAppearance.BorderSize = 0
        Me.btnLedgerTypeSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnLedgerTypeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLedgerTypeSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLedgerTypeSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLedgerTypeSearch.Location = New System.Drawing.Point(332, 83)
        Me.btnLedgerTypeSearch.Name = "btnLedgerTypeSearch"
        Me.btnLedgerTypeSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnLedgerTypeSearch.TabIndex = 102
        Me.btnLedgerTypeSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLedgerTypeSearch.UseVisualStyleBackColor = False
        '
        'txtLedgerTypeSearch
        '
        Me.txtLedgerTypeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtLedgerTypeSearch.Location = New System.Drawing.Point(145, 89)
        Me.txtLedgerTypeSearch.Name = "txtLedgerTypeSearch"
        Me.txtLedgerTypeSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtLedgerTypeSearch.TabIndex = 101
        '
        'dgLedgerType
        '
        Me.dgLedgerType.AllowUserToAddRows = False
        Me.dgLedgerType.AllowUserToDeleteRows = False
        Me.dgLedgerType.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgLedgerType.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgLedgerType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgLedgerType.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgLedgerType.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgLedgerType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgLedgerType.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLedgerType.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgLedgerType.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LedgerType, Me.LedgerDescription, Me.LedgerSetupId})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLedgerType.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgLedgerType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgLedgerType.EnableHeadersVisualStyles = False
        Me.dgLedgerType.GridColor = System.Drawing.Color.Gray
        Me.dgLedgerType.Location = New System.Drawing.Point(0, 119)
        Me.dgLedgerType.MultiSelect = False
        Me.dgLedgerType.Name = "dgLedgerType"
        Me.dgLedgerType.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLedgerType.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgLedgerType.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgLedgerType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLedgerType.Size = New System.Drawing.Size(410, 296)
        Me.dgLedgerType.TabIndex = 13
        '
        'LedgerType
        '
        Me.LedgerType.DataPropertyName = "LedgerType"
        Me.LedgerType.HeaderText = "Ledger Type"
        Me.LedgerType.Name = "LedgerType"
        Me.LedgerType.ReadOnly = True
        Me.LedgerType.Width = 102
        '
        'LedgerDescription
        '
        Me.LedgerDescription.DataPropertyName = "LedgerTypeDescp"
        Me.LedgerDescription.HeaderText = "LedgerDescription"
        Me.LedgerDescription.Name = "LedgerDescription"
        Me.LedgerDescription.ReadOnly = True
        Me.LedgerDescription.Width = 134
        '
        'LedgerSetupId
        '
        Me.LedgerSetupId.DataPropertyName = "LedgerSetupId"
        Me.LedgerSetupId.HeaderText = "LedgerSetUpId"
        Me.LedgerSetupId.Name = "LedgerSetupId"
        Me.LedgerSetupId.ReadOnly = True
        Me.LedgerSetupId.Visible = False
        Me.LedgerSetupId.Width = 116
        '
        'LedgerBatchLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(410, 415)
        Me.Controls.Add(Me.dgLedgerType)
        Me.Controls.Add(Me.panLedgerBatchLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LedgerBatchLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VehicleCodeLookUp"
        Me.panLedgerBatchLookUp.ResumeLayout(False)
        Me.panLedgerBatchLookUp.PerformLayout()
        CType(Me.dgLedgerType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panLedgerBatchLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents btnLedgerTypeSearch As System.Windows.Forms.Button
    Friend WithEvents lblsearchLedgerType As System.Windows.Forms.Label
    Friend WithEvents txtLedgerTypeSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgLedgerType As System.Windows.Forms.DataGridView
    Friend WithEvents LedgerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LedgerDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LedgerSetupId As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

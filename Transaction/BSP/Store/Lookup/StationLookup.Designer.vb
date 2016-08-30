<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StationLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StationLookup))
        Me.dgStation = New System.Windows.Forms.DataGridView
        Me.dgclStationID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclStationCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclStationDescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblsearchStation = New System.Windows.Forms.Label
        Me.panStationLookUp = New Stepi.UI.ExtendedPanel
        Me.txtStationDescSearch = New System.Windows.Forms.TextBox
        Me.lblStationDesc = New System.Windows.Forms.Label
        Me.lblStationCode = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnStationSearch = New System.Windows.Forms.Button
        Me.txtStationSearch = New System.Windows.Forms.TextBox
        Me.lblNoRecord = New System.Windows.Forms.Label
        CType(Me.dgStation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panStationLookUp.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgStation
        '
        Me.dgStation.AllowUserToAddRows = False
        Me.dgStation.AllowUserToDeleteRows = False
        Me.dgStation.AllowUserToOrderColumns = True
        Me.dgStation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgStation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgStation.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgStation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgStation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgStation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclStationID, Me.dgclStationCode, Me.dgclStationDescp})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgStation.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgStation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgStation.EnableHeadersVisualStyles = False
        Me.dgStation.GridColor = System.Drawing.Color.Gray
        Me.dgStation.Location = New System.Drawing.Point(0, 119)
        Me.dgStation.MultiSelect = False
        Me.dgStation.Name = "dgStation"
        Me.dgStation.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStation.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgStation.RowHeadersVisible = False
        Me.dgStation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgStation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgStation.Size = New System.Drawing.Size(430, 352)
        Me.dgStation.TabIndex = 15
        '
        'dgclStationID
        '
        Me.dgclStationID.DataPropertyName = "StationID"
        Me.dgclStationID.HeaderText = "Station ID"
        Me.dgclStationID.Name = "dgclStationID"
        Me.dgclStationID.ReadOnly = True
        Me.dgclStationID.Visible = False
        Me.dgclStationID.Width = 89
        '
        'dgclStationCode
        '
        Me.dgclStationCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclStationCode.DataPropertyName = "StationCode"
        Me.dgclStationCode.HeaderText = "Station Code"
        Me.dgclStationCode.Name = "dgclStationCode"
        Me.dgclStationCode.ReadOnly = True
        Me.dgclStationCode.Width = 150
        '
        'dgclStationDescp
        '
        Me.dgclStationDescp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclStationDescp.DataPropertyName = "StationDescp"
        Me.dgclStationDescp.HeaderText = "Station Descp"
        Me.dgclStationDescp.Name = "dgclStationDescp"
        Me.dgclStationDescp.ReadOnly = True
        Me.dgclStationDescp.Width = 200
        '
        'lblsearchStation
        '
        Me.lblsearchStation.AutoSize = True
        Me.lblsearchStation.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchStation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchStation.Location = New System.Drawing.Point(3, 43)
        Me.lblsearchStation.Name = "lblsearchStation"
        Me.lblsearchStation.Size = New System.Drawing.Size(76, 13)
        Me.lblsearchStation.TabIndex = 54
        Me.lblsearchStation.Text = "Search By "
        '
        'panStationLookUp
        '
        Me.panStationLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panStationLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panStationLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panStationLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panStationLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panStationLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panStationLookUp.CaptionSize = 40
        Me.panStationLookUp.CaptionText = "Select Station"
        Me.panStationLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panStationLookUp.Controls.Add(Me.txtStationDescSearch)
        Me.panStationLookUp.Controls.Add(Me.lblStationDesc)
        Me.panStationLookUp.Controls.Add(Me.lblStationCode)
        Me.panStationLookUp.Controls.Add(Me.btnClose)
        Me.panStationLookUp.Controls.Add(Me.lblsearchStation)
        Me.panStationLookUp.Controls.Add(Me.btnStationSearch)
        Me.panStationLookUp.Controls.Add(Me.txtStationSearch)
        Me.panStationLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panStationLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panStationLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panStationLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panStationLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panStationLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panStationLookUp.Name = "panStationLookUp"
        Me.panStationLookUp.Size = New System.Drawing.Size(430, 119)
        Me.panStationLookUp.TabIndex = 14
        '
        'txtStationDescSearch
        '
        Me.txtStationDescSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtStationDescSearch.Location = New System.Drawing.Point(184, 89)
        Me.txtStationDescSearch.Name = "txtStationDescSearch"
        Me.txtStationDescSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtStationDescSearch.TabIndex = 106
        '
        'lblStationDesc
        '
        Me.lblStationDesc.AutoSize = True
        Me.lblStationDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblStationDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStationDesc.Location = New System.Drawing.Point(181, 67)
        Me.lblStationDesc.Name = "lblStationDesc"
        Me.lblStationDesc.Size = New System.Drawing.Size(131, 13)
        Me.lblStationDesc.TabIndex = 105
        Me.lblStationDesc.Text = "Station Description"
        '
        'lblStationCode
        '
        Me.lblStationCode.AutoSize = True
        Me.lblStationCode.BackColor = System.Drawing.Color.Transparent
        Me.lblStationCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStationCode.Location = New System.Drawing.Point(3, 67)
        Me.lblStationCode.Name = "lblStationCode"
        Me.lblStationCode.Size = New System.Drawing.Size(89, 13)
        Me.lblStationCode.TabIndex = 104
        Me.lblStationCode.Text = "Station Code"
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
        'btnStationSearch
        '
        Me.btnStationSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnStationSearch.BackgroundImage = CType(resources.GetObject("btnStationSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnStationSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnStationSearch.FlatAppearance.BorderSize = 0
        Me.btnStationSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnStationSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStationSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStationSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStationSearch.Location = New System.Drawing.Point(360, 85)
        Me.btnStationSearch.Name = "btnStationSearch"
        Me.btnStationSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnStationSearch.TabIndex = 102
        Me.btnStationSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStationSearch.UseVisualStyleBackColor = False
        '
        'txtStationSearch
        '
        Me.txtStationSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtStationSearch.Location = New System.Drawing.Point(6, 89)
        Me.txtStationSearch.Name = "txtStationSearch"
        Me.txtStationSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtStationSearch.TabIndex = 101
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
        'StationLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(430, 471)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgStation)
        Me.Controls.Add(Me.panStationLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "StationLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Station Lookup"
        CType(Me.dgStation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panStationLookUp.ResumeLayout(False)
        Me.panStationLookUp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgStation As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchStation As System.Windows.Forms.Label
    Friend WithEvents panStationLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents btnStationSearch As System.Windows.Forms.Button
    Friend WithEvents txtStationSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblStationDesc As System.Windows.Forms.Label
    Friend WithEvents lblStationCode As System.Windows.Forms.Label
    Friend WithEvents txtStationDescSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgclStationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStationCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStationDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WSTLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WSTLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panTLookup = New Stepi.UI.ExtendedPanel
        Me.lblTDesc = New System.Windows.Forms.Label
        Me.txtTDescSearch = New System.Windows.Forms.TextBox
        Me.lblTValue = New System.Windows.Forms.Label
        Me.lblsearchAnalysisCode = New System.Windows.Forms.Label
        Me.txtTValueSearch = New System.Windows.Forms.TextBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnTSearch = New System.Windows.Forms.Button
        Me.dgTlookup = New System.Windows.Forms.DataGridView
        Me.TAnalysisId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TAnalysisCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TAnalysisDescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TAnalysisAbbrev = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlGrid = New System.Windows.Forms.Panel
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.panTLookup.SuspendLayout()
        CType(Me.dgTlookup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'panTLookup
        '
        Me.panTLookup.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panTLookup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panTLookup.BorderColor = System.Drawing.Color.Gray
        Me.panTLookup.CaptionColorOne = System.Drawing.Color.White
        Me.panTLookup.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panTLookup.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panTLookup.CaptionSize = 40
        Me.panTLookup.CaptionText = "Select Analysis Code"
        Me.panTLookup.CaptionTextColor = System.Drawing.Color.Black
        Me.panTLookup.Controls.Add(Me.lblTDesc)
        Me.panTLookup.Controls.Add(Me.txtTDescSearch)
        Me.panTLookup.Controls.Add(Me.lblTValue)
        Me.panTLookup.Controls.Add(Me.lblsearchAnalysisCode)
        Me.panTLookup.Controls.Add(Me.txtTValueSearch)
        Me.panTLookup.Controls.Add(Me.btnClose)
        Me.panTLookup.Controls.Add(Me.btnTSearch)
        Me.panTLookup.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panTLookup.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panTLookup.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panTLookup.Dock = System.Windows.Forms.DockStyle.Top
        Me.panTLookup.ForeColor = System.Drawing.Color.DimGray
        Me.panTLookup.Location = New System.Drawing.Point(0, 0)
        Me.panTLookup.Name = "panTLookup"
        Me.panTLookup.Size = New System.Drawing.Size(484, 119)
        Me.panTLookup.TabIndex = 13
        Me.panTLookup.TabStop = True
        '
        'lblTDesc
        '
        Me.lblTDesc.AutoSize = True
        Me.lblTDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblTDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTDesc.Location = New System.Drawing.Point(184, 73)
        Me.lblTDesc.Name = "lblTDesc"
        Me.lblTDesc.Size = New System.Drawing.Size(97, 13)
        Me.lblTDesc.TabIndex = 106
        Me.lblTDesc.Text = "T Description:"
        '
        'txtTDescSearch
        '
        Me.txtTDescSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTDescSearch.Location = New System.Drawing.Point(187, 89)
        Me.txtTDescSearch.Name = "txtTDescSearch"
        Me.txtTDescSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtTDescSearch.TabIndex = 2
        '
        'lblTValue
        '
        Me.lblTValue.AutoSize = True
        Me.lblTValue.BackColor = System.Drawing.Color.Transparent
        Me.lblTValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTValue.Location = New System.Drawing.Point(3, 73)
        Me.lblTValue.Name = "lblTValue"
        Me.lblTValue.Size = New System.Drawing.Size(59, 13)
        Me.lblTValue.TabIndex = 104
        Me.lblTValue.Text = "T Value:"
        '
        'lblsearchAnalysisCode
        '
        Me.lblsearchAnalysisCode.AutoSize = True
        Me.lblsearchAnalysisCode.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchAnalysisCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchAnalysisCode.Location = New System.Drawing.Point(10, 44)
        Me.lblsearchAnalysisCode.Name = "lblsearchAnalysisCode"
        Me.lblsearchAnalysisCode.Size = New System.Drawing.Size(80, 13)
        Me.lblsearchAnalysisCode.TabIndex = 54
        Me.lblsearchAnalysisCode.Text = "Search By :"
        '
        'txtTValueSearch
        '
        Me.txtTValueSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTValueSearch.Location = New System.Drawing.Point(6, 89)
        Me.txtTValueSearch.Name = "txtTValueSearch"
        Me.txtTValueSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtTValueSearch.TabIndex = 1
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
        Me.btnClose.Location = New System.Drawing.Point(406, 82)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 4
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnTSearch
        '
        Me.btnTSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnTSearch.BackgroundImage = CType(resources.GetObject("btnTSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnTSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnTSearch.FlatAppearance.BorderSize = 0
        Me.btnTSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnTSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTSearch.Location = New System.Drawing.Point(371, 82)
        Me.btnTSearch.Name = "btnTSearch"
        Me.btnTSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnTSearch.TabIndex = 3
        Me.btnTSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTSearch.UseVisualStyleBackColor = False
        '
        'dgTlookup
        '
        Me.dgTlookup.AllowUserToAddRows = False
        Me.dgTlookup.AllowUserToDeleteRows = False
        Me.dgTlookup.AllowUserToOrderColumns = True
        Me.dgTlookup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgTlookup.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgTlookup.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgTlookup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgTlookup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTlookup.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTlookup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TAnalysisId, Me.TAnalysisCode, Me.TValue, Me.TAnalysisDescp, Me.TAnalysisAbbrev, Me.EstateId})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTlookup.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgTlookup.EnableHeadersVisualStyles = False
        Me.dgTlookup.GridColor = System.Drawing.Color.Gray
        Me.dgTlookup.Location = New System.Drawing.Point(3, 3)
        Me.dgTlookup.MultiSelect = False
        Me.dgTlookup.Name = "dgTlookup"
        Me.dgTlookup.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTlookup.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgTlookup.RowHeadersVisible = False
        Me.dgTlookup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgTlookup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTlookup.Size = New System.Drawing.Size(477, 336)
        Me.dgTlookup.TabIndex = 0
        '
        'TAnalysisId
        '
        Me.TAnalysisId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TAnalysisId.DataPropertyName = "TAnalysisId"
        Me.TAnalysisId.HeaderText = "TAnalysis Id"
        Me.TAnalysisId.Name = "TAnalysisId"
        Me.TAnalysisId.ReadOnly = True
        Me.TAnalysisId.Visible = False
        '
        'TAnalysisCode
        '
        Me.TAnalysisCode.DataPropertyName = "TAnalysisCode"
        Me.TAnalysisCode.HeaderText = "TAnalysis Code"
        Me.TAnalysisCode.Name = "TAnalysisCode"
        Me.TAnalysisCode.ReadOnly = True
        Me.TAnalysisCode.Visible = False
        Me.TAnalysisCode.Width = 119
        '
        'TValue
        '
        Me.TValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TValue.DataPropertyName = "TValue"
        Me.TValue.HeaderText = "TValue"
        Me.TValue.Name = "TValue"
        Me.TValue.ReadOnly = True
        Me.TValue.Width = 150
        '
        'TAnalysisDescp
        '
        Me.TAnalysisDescp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TAnalysisDescp.DataPropertyName = "TAnalysisDescp"
        Me.TAnalysisDescp.HeaderText = "TAnalysis Descp"
        Me.TAnalysisDescp.Name = "TAnalysisDescp"
        Me.TAnalysisDescp.ReadOnly = True
        Me.TAnalysisDescp.Width = 300
        '
        'TAnalysisAbbrev
        '
        Me.TAnalysisAbbrev.DataPropertyName = "TAnalysisAbbrev"
        Me.TAnalysisAbbrev.HeaderText = "TAnalysis Abbrev"
        Me.TAnalysisAbbrev.Name = "TAnalysisAbbrev"
        Me.TAnalysisAbbrev.ReadOnly = True
        Me.TAnalysisAbbrev.Visible = False
        Me.TAnalysisAbbrev.Width = 130
        '
        'EstateId
        '
        Me.EstateId.DataPropertyName = "EstateId"
        Me.EstateId.HeaderText = "Estate Id"
        Me.EstateId.Name = "EstateId"
        Me.EstateId.ReadOnly = True
        Me.EstateId.Visible = False
        Me.EstateId.Width = 82
        '
        'pnlGrid
        '
        Me.pnlGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlGrid.Controls.Add(Me.lblNoRecord)
        Me.pnlGrid.Controls.Add(Me.dgTlookup)
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGrid.Location = New System.Drawing.Point(0, 119)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(484, 339)
        Me.pnlGrid.TabIndex = 15
        Me.pnlGrid.TabStop = True
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(109, 155)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 112
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'Tlookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(484, 459)
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.panTLookup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Tlookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "T Lookup"
        Me.panTLookup.ResumeLayout(False)
        Me.panTLookup.PerformLayout()
        CType(Me.dgTlookup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGrid.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panTLookup As Stepi.UI.ExtendedPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchAnalysisCode As System.Windows.Forms.Label
    Friend WithEvents btnTSearch As System.Windows.Forms.Button
    Friend WithEvents txtTValueSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgTlookup As System.Windows.Forms.DataGridView
    Friend WithEvents lblTValue As System.Windows.Forms.Label
    Friend WithEvents lblTDesc As System.Windows.Forms.Label
    Friend WithEvents txtTDescSearch As System.Windows.Forms.TextBox
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents TAnalysisId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TAnalysisCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TAnalysisDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TAnalysisAbbrev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
End Class

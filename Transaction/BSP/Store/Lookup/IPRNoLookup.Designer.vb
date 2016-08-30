<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IPRNoLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IPRNoLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlIPRNoSearch = New Stepi.UI.ExtendedPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblIPRNo = New System.Windows.Forms.Label
        Me.btnIPRNoSearch = New System.Windows.Forms.Button
        Me.lblsearchCategory = New System.Windows.Forms.Label
        Me.txtIPRNo = New System.Windows.Forms.TextBox
        Me.dgvIPRNo = New System.Windows.Forms.DataGridView
        Me.dgclSTIPRID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSTIPRDetID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclIPRNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclIPRDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlIPRNoSearch.SuspendLayout()
        CType(Me.dgvIPRNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlIPRNoSearch
        '
        Me.pnlIPRNoSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlIPRNoSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlIPRNoSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlIPRNoSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlIPRNoSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlIPRNoSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlIPRNoSearch.CaptionSize = 40
        Me.pnlIPRNoSearch.CaptionText = "Search PR No."
        Me.pnlIPRNoSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlIPRNoSearch.Controls.Add(Me.Label3)
        Me.pnlIPRNoSearch.Controls.Add(Me.btnClose)
        Me.pnlIPRNoSearch.Controls.Add(Me.lblIPRNo)
        Me.pnlIPRNoSearch.Controls.Add(Me.btnIPRNoSearch)
        Me.pnlIPRNoSearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlIPRNoSearch.Controls.Add(Me.txtIPRNo)
        Me.pnlIPRNoSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlIPRNoSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlIPRNoSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlIPRNoSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlIPRNoSearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlIPRNoSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlIPRNoSearch.Name = "pnlIPRNoSearch"
        Me.pnlIPRNoSearch.Size = New System.Drawing.Size(410, 119)
        Me.pnlIPRNoSearch.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(108, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = ":"
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
        Me.btnClose.Location = New System.Drawing.Point(348, 79)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 3
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblIPRNo
        '
        Me.lblIPRNo.AutoSize = True
        Me.lblIPRNo.BackColor = System.Drawing.Color.Transparent
        Me.lblIPRNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIPRNo.Location = New System.Drawing.Point(48, 86)
        Me.lblIPRNo.Name = "lblIPRNo"
        Me.lblIPRNo.Size = New System.Drawing.Size(54, 13)
        Me.lblIPRNo.TabIndex = 105
        Me.lblIPRNo.Text = "PR No."
        '
        'btnIPRNoSearch
        '
        Me.btnIPRNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnIPRNoSearch.BackgroundImage = CType(resources.GetObject("btnIPRNoSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnIPRNoSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnIPRNoSearch.FlatAppearance.BorderSize = 0
        Me.btnIPRNoSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnIPRNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIPRNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIPRNoSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIPRNoSearch.Location = New System.Drawing.Point(313, 79)
        Me.btnIPRNoSearch.Name = "btnIPRNoSearch"
        Me.btnIPRNoSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnIPRNoSearch.TabIndex = 2
        Me.btnIPRNoSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIPRNoSearch.UseVisualStyleBackColor = False
        '
        'lblsearchCategory
        '
        Me.lblsearchCategory.AutoSize = True
        Me.lblsearchCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchCategory.Location = New System.Drawing.Point(1, 41)
        Me.lblsearchCategory.Name = "lblsearchCategory"
        Me.lblsearchCategory.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchCategory.TabIndex = 54
        Me.lblsearchCategory.Text = "Search By"
        '
        'txtIPRNo
        '
        Me.txtIPRNo.Location = New System.Drawing.Point(120, 83)
        Me.txtIPRNo.Name = "txtIPRNo"
        Me.txtIPRNo.Size = New System.Drawing.Size(172, 20)
        Me.txtIPRNo.TabIndex = 1
        '
        'dgvIPRNo
        '
        Me.dgvIPRNo.AllowUserToAddRows = False
        Me.dgvIPRNo.AllowUserToDeleteRows = False
        Me.dgvIPRNo.AllowUserToOrderColumns = True
        Me.dgvIPRNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvIPRNo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvIPRNo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIPRNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvIPRNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPRNo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIPRNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclSTIPRID, Me.dgclSTIPRDetID, Me.dgclIPRNo, Me.dgclIPRDate})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPRNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvIPRNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPRNo.EnableHeadersVisualStyles = False
        Me.dgvIPRNo.GridColor = System.Drawing.Color.Gray
        Me.dgvIPRNo.Location = New System.Drawing.Point(0, 119)
        Me.dgvIPRNo.MultiSelect = False
        Me.dgvIPRNo.Name = "dgvIPRNo"
        Me.dgvIPRNo.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPRNo.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvIPRNo.RowHeadersVisible = False
        Me.dgvIPRNo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvIPRNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIPRNo.Size = New System.Drawing.Size(410, 296)
        Me.dgvIPRNo.TabIndex = 4
        Me.dgvIPRNo.TabStop = False
        '
        'dgclSTIPRID
        '
        Me.dgclSTIPRID.DataPropertyName = "STIPRID"
        DataGridViewCellStyle2.Format = "dd/mm/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgclSTIPRID.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgclSTIPRID.HeaderText = "STPR ID"
        Me.dgclSTIPRID.Name = "dgclSTIPRID"
        Me.dgclSTIPRID.ReadOnly = True
        Me.dgclSTIPRID.Visible = False
        Me.dgclSTIPRID.Width = 84
        '
        'dgclSTIPRDetID
        '
        Me.dgclSTIPRDetID.DataPropertyName = "STIPRDetID"
        Me.dgclSTIPRDetID.HeaderText = "STPRDet ID"
        Me.dgclSTIPRDetID.Name = "dgclSTIPRDetID"
        Me.dgclSTIPRDetID.ReadOnly = True
        Me.dgclSTIPRDetID.Visible = False
        Me.dgclSTIPRDetID.Width = 104
        '
        'dgclIPRNo
        '
        Me.dgclIPRNo.DataPropertyName = "IPRNo"
        Me.dgclIPRNo.HeaderText = "PR No."
        Me.dgclIPRNo.Name = "dgclIPRNo"
        Me.dgclIPRNo.ReadOnly = True
        Me.dgclIPRNo.Width = 74
        '
        'dgclIPRDate
        '
        Me.dgclIPRDate.DataPropertyName = "IPRdate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgclIPRDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgclIPRDate.HeaderText = "PR Date"
        Me.dgclIPRDate.Name = "dgclIPRDate"
        Me.dgclIPRDate.ReadOnly = True
        Me.dgclIPRDate.Width = 82
        '
        'IPRNoLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(410, 415)
        Me.Controls.Add(Me.dgvIPRNo)
        Me.Controls.Add(Me.pnlIPRNoSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "IPRNoLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRNo Lookup"
        Me.pnlIPRNoSearch.ResumeLayout(False)
        Me.pnlIPRNoSearch.PerformLayout()
        CType(Me.dgvIPRNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlIPRNoSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblIPRNo As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnIPRNoSearch As System.Windows.Forms.Button
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents txtIPRNo As System.Windows.Forms.TextBox
    Friend WithEvents dgvIPRNo As System.Windows.Forms.DataGridView
    Friend WithEvents dgclSTIPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSTIPRDetID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIPRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclIPRDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

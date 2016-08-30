<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerNoLookUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LedgerNoLookUp))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panLedgerNoLookUp = New Stepi.UI.ExtendedPanel
        Me.lblsearchLedgerNo = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtLedgerNoSearch = New System.Windows.Forms.TextBox
        Me.btnLedgerNoSearch = New System.Windows.Forms.Button
        Me.dgLedgerNo = New System.Windows.Forms.DataGridView
        Me.dgclLedgerNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclDescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclBatchTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclAccBatchID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.panLedgerNoLookUp.SuspendLayout()
        CType(Me.dgLedgerNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panLedgerNoLookUp
        '
        Me.panLedgerNoLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panLedgerNoLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panLedgerNoLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panLedgerNoLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panLedgerNoLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panLedgerNoLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panLedgerNoLookUp.CaptionSize = 40
        Me.panLedgerNoLookUp.CaptionText = " Select Ledger No"
        Me.panLedgerNoLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panLedgerNoLookUp.Controls.Add(Me.lblsearchLedgerNo)
        Me.panLedgerNoLookUp.Controls.Add(Me.btnClose)
        Me.panLedgerNoLookUp.Controls.Add(Me.txtLedgerNoSearch)
        Me.panLedgerNoLookUp.Controls.Add(Me.btnLedgerNoSearch)
        Me.panLedgerNoLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panLedgerNoLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panLedgerNoLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panLedgerNoLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panLedgerNoLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panLedgerNoLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panLedgerNoLookUp.Name = "panLedgerNoLookUp"
        Me.panLedgerNoLookUp.Size = New System.Drawing.Size(410, 119)
        Me.panLedgerNoLookUp.TabIndex = 13
        '
        'lblsearchLedgerNo
        '
        Me.lblsearchLedgerNo.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchLedgerNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchLedgerNo.Location = New System.Drawing.Point(10, 58)
        Me.lblsearchLedgerNo.Name = "lblsearchLedgerNo"
        Me.lblsearchLedgerNo.Size = New System.Drawing.Size(146, 27)
        Me.lblsearchLedgerNo.TabIndex = 54
        Me.lblsearchLedgerNo.Text = "Search By Ledger No:"
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
        Me.btnClose.Location = New System.Drawing.Point(367, 55)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtLedgerNoSearch
        '
        Me.txtLedgerNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtLedgerNoSearch.Location = New System.Drawing.Point(162, 55)
        Me.txtLedgerNoSearch.Name = "txtLedgerNoSearch"
        Me.txtLedgerNoSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtLedgerNoSearch.TabIndex = 101
        '
        'btnLedgerNoSearch
        '
        Me.btnLedgerNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnLedgerNoSearch.BackgroundImage = CType(resources.GetObject("btnLedgerNoSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnLedgerNoSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnLedgerNoSearch.FlatAppearance.BorderSize = 0
        Me.btnLedgerNoSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnLedgerNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLedgerNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLedgerNoSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLedgerNoSearch.Location = New System.Drawing.Point(334, 55)
        Me.btnLedgerNoSearch.Name = "btnLedgerNoSearch"
        Me.btnLedgerNoSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnLedgerNoSearch.TabIndex = 102
        Me.btnLedgerNoSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLedgerNoSearch.UseVisualStyleBackColor = False
        '
        'dgLedgerNo
        '
        Me.dgLedgerNo.AllowUserToAddRows = False
        Me.dgLedgerNo.AllowUserToDeleteRows = False
        Me.dgLedgerNo.AllowUserToOrderColumns = True
        Me.dgLedgerNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgLedgerNo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgLedgerNo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgLedgerNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgLedgerNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLedgerNo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLedgerNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclLedgerNo, Me.dgclDescp, Me.dgclBatchTotal, Me.dgclAccBatchID})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLedgerNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgLedgerNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgLedgerNo.EnableHeadersVisualStyles = False
        Me.dgLedgerNo.GridColor = System.Drawing.Color.Gray
        Me.dgLedgerNo.Location = New System.Drawing.Point(0, 119)
        Me.dgLedgerNo.MultiSelect = False
        Me.dgLedgerNo.Name = "dgLedgerNo"
        Me.dgLedgerNo.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLedgerNo.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgLedgerNo.RowHeadersVisible = False
        Me.dgLedgerNo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgLedgerNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLedgerNo.Size = New System.Drawing.Size(410, 296)
        Me.dgLedgerNo.TabIndex = 14
        '
        'dgclLedgerNo
        '
        Me.dgclLedgerNo.DataPropertyName = "LedgerNo"
        Me.dgclLedgerNo.HeaderText = "Ledger No"
        Me.dgclLedgerNo.Name = "dgclLedgerNo"
        Me.dgclLedgerNo.ReadOnly = True
        Me.dgclLedgerNo.Width = 89
        '
        'dgclDescp
        '
        Me.dgclDescp.DataPropertyName = "LedgerDescp"
        Me.dgclDescp.HeaderText = "Description"
        Me.dgclDescp.Name = "dgclDescp"
        Me.dgclDescp.ReadOnly = True
        Me.dgclDescp.Width = 95
        '
        'dgclBatchTotal
        '
        Me.dgclBatchTotal.DataPropertyName = "AccBatchTotal"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgclBatchTotal.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgclBatchTotal.HeaderText = "Batch Total"
        Me.dgclBatchTotal.Name = "dgclBatchTotal"
        Me.dgclBatchTotal.ReadOnly = True
        Me.dgclBatchTotal.Width = 95
        '
        'dgclAccBatchID
        '
        Me.dgclAccBatchID.DataPropertyName = "AccBatchID"
        Me.dgclAccBatchID.HeaderText = "AccBatchID"
        Me.dgclAccBatchID.Name = "dgclAccBatchID"
        Me.dgclAccBatchID.ReadOnly = True
        Me.dgclAccBatchID.Visible = False
        Me.dgclAccBatchID.Width = 97
        '
        'LedgerNoLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(410, 415)
        Me.Controls.Add(Me.dgLedgerNo)
        Me.Controls.Add(Me.panLedgerNoLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "LedgerNoLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panLedgerNoLookUp.ResumeLayout(False)
        Me.panLedgerNoLookUp.PerformLayout()
        CType(Me.dgLedgerNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panLedgerNoLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchLedgerNo As System.Windows.Forms.Label
    Friend WithEvents btnLedgerNoSearch As System.Windows.Forms.Button
    Friend WithEvents txtLedgerNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgLedgerNo As System.Windows.Forms.DataGridView
    Friend WithEvents dgclLedgerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBatchTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclAccBatchID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IPRViewLookUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IPRViewLookUp))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtSupplierSearch = New System.Windows.Forms.TextBox
        Me.pnlsearchIPRView = New Stepi.UI.ExtendedPanel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblSearchby = New System.Windows.Forms.Label
        Me.lblSearchColumn = New System.Windows.Forms.Label
        Me.btnGO = New System.Windows.Forms.Button
        Me.dgvIPRDetails = New System.Windows.Forms.DataGridView
        Me.gvIPRdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gvIPRNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gvCategory = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gvDeliveredTo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gvClassification = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gvRequiredfor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gvMainstatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlsearchIPRView.SuspendLayout()
        CType(Me.dgvIPRDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSupplierSearch
        '
        Me.txtSupplierSearch.Location = New System.Drawing.Point(148, 87)
        Me.txtSupplierSearch.Name = "txtSupplierSearch"
        Me.txtSupplierSearch.Size = New System.Drawing.Size(179, 20)
        Me.txtSupplierSearch.TabIndex = 1
        '
        'pnlsearchIPRView
        '
        Me.pnlsearchIPRView.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlsearchIPRView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlsearchIPRView.BorderColor = System.Drawing.Color.Gray
        Me.pnlsearchIPRView.CaptionColorOne = System.Drawing.Color.White
        Me.pnlsearchIPRView.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlsearchIPRView.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlsearchIPRView.CaptionSize = 40
        Me.pnlsearchIPRView.CaptionText = "Search PR Details"
        Me.pnlsearchIPRView.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlsearchIPRView.Controls.Add(Me.btnClose)
        Me.pnlsearchIPRView.Controls.Add(Me.Label4)
        Me.pnlsearchIPRView.Controls.Add(Me.lblSearchby)
        Me.pnlsearchIPRView.Controls.Add(Me.txtSupplierSearch)
        Me.pnlsearchIPRView.Controls.Add(Me.lblSearchColumn)
        Me.pnlsearchIPRView.Controls.Add(Me.btnGO)
        Me.pnlsearchIPRView.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlsearchIPRView.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlsearchIPRView.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlsearchIPRView.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlsearchIPRView.ForeColor = System.Drawing.Color.DimGray
        Me.pnlsearchIPRView.Location = New System.Drawing.Point(0, 0)
        Me.pnlsearchIPRView.Name = "pnlsearchIPRView"
        Me.pnlsearchIPRView.Size = New System.Drawing.Size(410, 119)
        Me.pnlsearchIPRView.TabIndex = 13
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
        Me.btnClose.Location = New System.Drawing.Point(367, 80)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 3
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(206, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = ":"
        '
        'lblSearchby
        '
        Me.lblSearchby.AutoSize = True
        Me.lblSearchby.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchby.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchby.Location = New System.Drawing.Point(14, 58)
        Me.lblSearchby.Name = "lblSearchby"
        Me.lblSearchby.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchby.TabIndex = 54
        Me.lblSearchby.Text = "Search By"
        '
        'lblSearchColumn
        '
        Me.lblSearchColumn.AutoSize = True
        Me.lblSearchColumn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchColumn.Location = New System.Drawing.Point(92, 58)
        Me.lblSearchColumn.Name = "lblSearchColumn"
        Me.lblSearchColumn.Size = New System.Drawing.Size(55, 13)
        Me.lblSearchColumn.TabIndex = 15
        Me.lblSearchColumn.Text = "Column"
        '
        'btnGO
        '
        Me.btnGO.BackColor = System.Drawing.Color.Transparent
        Me.btnGO.BackgroundImage = CType(resources.GetObject("btnGO.BackgroundImage"), System.Drawing.Image)
        Me.btnGO.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnGO.FlatAppearance.BorderSize = 0
        Me.btnGO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnGO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGO.Location = New System.Drawing.Point(336, 81)
        Me.btnGO.Name = "btnGO"
        Me.btnGO.Size = New System.Drawing.Size(27, 30)
        Me.btnGO.TabIndex = 2
        Me.btnGO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGO.UseVisualStyleBackColor = False
        '
        'dgvIPRDetails
        '
        Me.dgvIPRDetails.AllowUserToAddRows = False
        Me.dgvIPRDetails.AllowUserToDeleteRows = False
        Me.dgvIPRDetails.AllowUserToOrderColumns = True
        Me.dgvIPRDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvIPRDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvIPRDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvIPRDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvIPRDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPRDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIPRDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvIPRdate, Me.gvIPRNo, Me.gvCategory, Me.gvDeliveredTo, Me.gvClassification, Me.gvRequiredfor, Me.gvMainstatus})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPRDetails.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIPRDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPRDetails.EnableHeadersVisualStyles = False
        Me.dgvIPRDetails.GridColor = System.Drawing.Color.Gray
        Me.dgvIPRDetails.Location = New System.Drawing.Point(0, 119)
        Me.dgvIPRDetails.Name = "dgvIPRDetails"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPRDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvIPRDetails.RowHeadersVisible = False
        Me.dgvIPRDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvIPRDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIPRDetails.Size = New System.Drawing.Size(410, 296)
        Me.dgvIPRDetails.TabIndex = 4
        '
        'gvIPRdate
        '
        Me.gvIPRdate.DataPropertyName = "ColumnName"
        Me.gvIPRdate.HeaderText = "PR Date"
        Me.gvIPRdate.Name = "gvIPRdate"
        Me.gvIPRdate.Width = 82
        '
        'gvIPRNo
        '
        Me.gvIPRNo.DataPropertyName = "IPRNo"
        Me.gvIPRNo.HeaderText = "PR No."
        Me.gvIPRNo.Name = "gvIPRNo"
        Me.gvIPRNo.Width = 74
        '
        'gvCategory
        '
        Me.gvCategory.DataPropertyName = "STCategoryID"
        Me.gvCategory.HeaderText = "Category"
        Me.gvCategory.Name = "gvCategory"
        Me.gvCategory.Width = 84
        '
        'gvDeliveredTo
        '
        Me.gvDeliveredTo.DataPropertyName = "DeliveredTo"
        Me.gvDeliveredTo.HeaderText = "Delivered To"
        Me.gvDeliveredTo.Name = "gvDeliveredTo"
        Me.gvDeliveredTo.Width = 104
        '
        'gvClassification
        '
        Me.gvClassification.DataPropertyName = "Classification"
        Me.gvClassification.HeaderText = "Classification"
        Me.gvClassification.Name = "gvClassification"
        Me.gvClassification.Width = 106
        '
        'gvRequiredfor
        '
        Me.gvRequiredfor.DataPropertyName = "RequiredFor"
        Me.gvRequiredfor.HeaderText = "Required For"
        Me.gvRequiredfor.Name = "gvRequiredfor"
        Me.gvRequiredfor.Width = 104
        '
        'gvMainstatus
        '
        Me.gvMainstatus.DataPropertyName = "MainStatus"
        Me.gvMainstatus.HeaderText = "Main Status"
        Me.gvMainstatus.Name = "gvMainstatus"
        Me.gvMainstatus.Width = 97
        '
        'IPRViewLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(410, 415)
        Me.Controls.Add(Me.dgvIPRDetails)
        Me.Controls.Add(Me.pnlsearchIPRView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "IPRViewLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlsearchIPRView.ResumeLayout(False)
        Me.pnlsearchIPRView.PerformLayout()
        CType(Me.dgvIPRDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSupplierSearch As System.Windows.Forms.TextBox
    Friend WithEvents pnlsearchIPRView As Stepi.UI.ExtendedPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSearchby As System.Windows.Forms.Label
    Friend WithEvents btnGO As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvIPRDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearchColumn As System.Windows.Forms.Label
    Friend WithEvents gvIPRdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvIPRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvDeliveredTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvClassification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvRequiredfor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvMainstatus As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StandardPriceListStockLookUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StandardPriceListStockLookUp))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panStockLookUp = New Stepi.UI.ExtendedPanel
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblBudgetYearSearch = New System.Windows.Forms.Label
        Me.txtBudgetYearSearch = New System.Windows.Forms.TextBox
        Me.lblsearchDiv = New System.Windows.Forms.Label
        Me.lblDescpSearch = New System.Windows.Forms.Label
        Me.btnSTockCodeLookUpSearch = New System.Windows.Forms.Button
        Me.txtDescpSearch = New System.Windows.Forms.TextBox
        Me.dgStockLookUp = New System.Windows.Forms.DataGridView
        Me.StandardPriceListID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.panStockLookUp.SuspendLayout()
        CType(Me.dgStockLookUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panStockLookUp
        '
        Me.panStockLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panStockLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panStockLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panStockLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panStockLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panStockLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panStockLookUp.CaptionSize = 40
        Me.panStockLookUp.CaptionText = "Select Description"
        Me.panStockLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panStockLookUp.Controls.Add(Me.btnClose)
        Me.panStockLookUp.Controls.Add(Me.lblBudgetYearSearch)
        Me.panStockLookUp.Controls.Add(Me.txtBudgetYearSearch)
        Me.panStockLookUp.Controls.Add(Me.lblsearchDiv)
        Me.panStockLookUp.Controls.Add(Me.lblDescpSearch)
        Me.panStockLookUp.Controls.Add(Me.btnSTockCodeLookUpSearch)
        Me.panStockLookUp.Controls.Add(Me.txtDescpSearch)
        Me.panStockLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panStockLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panStockLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panStockLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panStockLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panStockLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panStockLookUp.Name = "panStockLookUp"
        Me.panStockLookUp.Size = New System.Drawing.Size(537, 124)
        Me.panStockLookUp.TabIndex = 19
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
        'lblBudgetYearSearch
        '
        Me.lblBudgetYearSearch.AutoSize = True
        Me.lblBudgetYearSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblBudgetYearSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBudgetYearSearch.Location = New System.Drawing.Point(7, 77)
        Me.lblBudgetYearSearch.Name = "lblBudgetYearSearch"
        Me.lblBudgetYearSearch.Size = New System.Drawing.Size(94, 13)
        Me.lblBudgetYearSearch.TabIndex = 106
        Me.lblBudgetYearSearch.Text = "Budget Year :"
        '
        'txtBudgetYearSearch
        '
        Me.txtBudgetYearSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtBudgetYearSearch.Location = New System.Drawing.Point(7, 93)
        Me.txtBudgetYearSearch.Name = "txtBudgetYearSearch"
        Me.txtBudgetYearSearch.Size = New System.Drawing.Size(172, 21)
        Me.txtBudgetYearSearch.TabIndex = 105
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
        'lblDescpSearch
        '
        Me.lblDescpSearch.AutoSize = True
        Me.lblDescpSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblDescpSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescpSearch.Location = New System.Drawing.Point(185, 77)
        Me.lblDescpSearch.Name = "lblDescpSearch"
        Me.lblDescpSearch.Size = New System.Drawing.Size(54, 13)
        Me.lblDescpSearch.TabIndex = 104
        Me.lblDescpSearch.Text = "Descp :"
        '
        'btnSTockCodeLookUpSearch
        '
        Me.btnSTockCodeLookUpSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSTockCodeLookUpSearch.BackgroundImage = CType(resources.GetObject("btnSTockCodeLookUpSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSTockCodeLookUpSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnSTockCodeLookUpSearch.FlatAppearance.BorderSize = 0
        Me.btnSTockCodeLookUpSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnSTockCodeLookUpSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSTockCodeLookUpSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSTockCodeLookUpSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSTockCodeLookUpSearch.Location = New System.Drawing.Point(361, 87)
        Me.btnSTockCodeLookUpSearch.Name = "btnSTockCodeLookUpSearch"
        Me.btnSTockCodeLookUpSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnSTockCodeLookUpSearch.TabIndex = 102
        Me.btnSTockCodeLookUpSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSTockCodeLookUpSearch.UseVisualStyleBackColor = False
        '
        'txtDescpSearch
        '
        Me.txtDescpSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDescpSearch.Location = New System.Drawing.Point(185, 93)
        Me.txtDescpSearch.Name = "txtDescpSearch"
        Me.txtDescpSearch.Size = New System.Drawing.Size(172, 21)
        Me.txtDescpSearch.TabIndex = 101
        '
        'dgStockLookUp
        '
        Me.dgStockLookUp.AllowUserToAddRows = False
        Me.dgStockLookUp.AllowUserToDeleteRows = False
        Me.dgStockLookUp.AllowUserToOrderColumns = True
        Me.dgStockLookUp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgStockLookUp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgStockLookUp.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgStockLookUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgStockLookUp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStockLookUp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgStockLookUp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StandardPriceListID, Me.BudgetYear, Me.StockCode, Me.Descp, Me.Type, Me.TotalCost})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgStockLookUp.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgStockLookUp.EnableHeadersVisualStyles = False
        Me.dgStockLookUp.GridColor = System.Drawing.Color.Gray
        Me.dgStockLookUp.Location = New System.Drawing.Point(0, 126)
        Me.dgStockLookUp.MultiSelect = False
        Me.dgStockLookUp.Name = "dgStockLookUp"
        Me.dgStockLookUp.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStockLookUp.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgStockLookUp.RowHeadersVisible = False
        Me.dgStockLookUp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgStockLookUp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgStockLookUp.Size = New System.Drawing.Size(537, 307)
        Me.dgStockLookUp.TabIndex = 116
        '
        'StandardPriceListID
        '
        Me.StandardPriceListID.DataPropertyName = "StandardPriceListID"
        Me.StandardPriceListID.HeaderText = "StandardPriceListID"
        Me.StandardPriceListID.Name = "StandardPriceListID"
        Me.StandardPriceListID.ReadOnly = True
        Me.StandardPriceListID.Visible = False
        Me.StandardPriceListID.Width = 144
        '
        'BudgetYear
        '
        Me.BudgetYear.DataPropertyName = "BudgetYear"
        Me.BudgetYear.HeaderText = "Budget Year"
        Me.BudgetYear.Name = "BudgetYear"
        Me.BudgetYear.ReadOnly = True
        Me.BudgetYear.Width = 101
        '
        'StockCode
        '
        Me.StockCode.DataPropertyName = "StockCode"
        Me.StockCode.HeaderText = "Stock Code"
        Me.StockCode.Name = "StockCode"
        Me.StockCode.ReadOnly = True
        Me.StockCode.Width = 97
        '
        'Descp
        '
        Me.Descp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Descp.DataPropertyName = "Descp"
        Me.Descp.HeaderText = "Descp "
        Me.Descp.Name = "Descp"
        Me.Descp.ReadOnly = True
        '
        'Type
        '
        Me.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Type.DataPropertyName = "Type"
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Width = 200
        '
        'TotalCost
        '
        Me.TotalCost.DataPropertyName = "TotalCost"
        Me.TotalCost.HeaderText = "TotalCost"
        Me.TotalCost.Name = "TotalCost"
        Me.TotalCost.ReadOnly = True
        Me.TotalCost.Visible = False
        Me.TotalCost.Width = 85
        '
        'StandardPriceListStockLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(537, 435)
        Me.Controls.Add(Me.dgStockLookUp)
        Me.Controls.Add(Me.panStockLookUp)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "StandardPriceListStockLookUp"
        Me.Text = "StandardPriceListStockLookUp"
        Me.panStockLookUp.ResumeLayout(False)
        Me.panStockLookUp.PerformLayout()
        CType(Me.dgStockLookUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panStockLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents lblBudgetYearSearch As System.Windows.Forms.Label
    Friend WithEvents txtBudgetYearSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblDescpSearch As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchDiv As System.Windows.Forms.Label
    Friend WithEvents btnSTockCodeLookUpSearch As System.Windows.Forms.Button
    Friend WithEvents txtDescpSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgStockLookUp As System.Windows.Forms.DataGridView
    Friend WithEvents StandardPriceListID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCost As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WBSupplierLookUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WBSupplierLookUp))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtSearchSupplierCode = New System.Windows.Forms.TextBox
        Me.pnlSupplierSearch = New Stepi.UI.ExtendedPanel
        Me.lblColon4 = New System.Windows.Forms.Label
        Me.cmbCompany = New System.Windows.Forms.ComboBox
        Me.lblCompany = New System.Windows.Forms.Label
        Me.txtSearchSupplerName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSearchSupplierName = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblSearchSupplierCode = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.dgvSupplier = New System.Windows.Forms.DataGridView
        Me.dgclSupplierCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclCompany = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProductDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplierID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProductID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlSupplierSearch.SuspendLayout()
        CType(Me.dgvSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSearchSupplierCode
        '
        Me.txtSearchSupplierCode.Location = New System.Drawing.Point(141, 55)
        Me.txtSearchSupplierCode.Name = "txtSearchSupplierCode"
        Me.txtSearchSupplierCode.Size = New System.Drawing.Size(208, 21)
        Me.txtSearchSupplierCode.TabIndex = 1
        '
        'pnlSupplierSearch
        '
        Me.pnlSupplierSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSupplierSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSupplierSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlSupplierSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlSupplierSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSupplierSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSupplierSearch.CaptionSize = 40
        Me.pnlSupplierSearch.CaptionText = "Search by:"
        Me.pnlSupplierSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSupplierSearch.Controls.Add(Me.lblColon4)
        Me.pnlSupplierSearch.Controls.Add(Me.cmbCompany)
        Me.pnlSupplierSearch.Controls.Add(Me.lblCompany)
        Me.pnlSupplierSearch.Controls.Add(Me.txtSearchSupplerName)
        Me.pnlSupplierSearch.Controls.Add(Me.Label1)
        Me.pnlSupplierSearch.Controls.Add(Me.lblSearchSupplierName)
        Me.pnlSupplierSearch.Controls.Add(Me.Label4)
        Me.pnlSupplierSearch.Controls.Add(Me.lblSearchSupplierCode)
        Me.pnlSupplierSearch.Controls.Add(Me.txtSearchSupplierCode)
        Me.pnlSupplierSearch.Controls.Add(Me.btnClose)
        Me.pnlSupplierSearch.Controls.Add(Me.btnView)
        Me.pnlSupplierSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSupplierSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSupplierSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSupplierSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSupplierSearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlSupplierSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlSupplierSearch.Name = "pnlSupplierSearch"
        Me.pnlSupplierSearch.Size = New System.Drawing.Size(475, 142)
        Me.pnlSupplierSearch.TabIndex = 13
        '
        'lblColon4
        '
        Me.lblColon4.AutoSize = True
        Me.lblColon4.BackColor = System.Drawing.Color.Transparent
        Me.lblColon4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon4.ForeColor = System.Drawing.Color.Black
        Me.lblColon4.Location = New System.Drawing.Point(122, 114)
        Me.lblColon4.Name = "lblColon4"
        Me.lblColon4.Size = New System.Drawing.Size(12, 14)
        Me.lblColon4.TabIndex = 67
        Me.lblColon4.Text = ":"
        '
        'cmbCompany
        '
        Me.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Items.AddRange(New Object() {"Outside Company", "Own Company", "ALL"})
        Me.cmbCompany.Location = New System.Drawing.Point(141, 112)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(208, 21)
        Me.cmbCompany.TabIndex = 15
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.BackColor = System.Drawing.Color.Transparent
        Me.lblCompany.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(7, 115)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(67, 13)
        Me.lblCompany.TabIndex = 66
        Me.lblCompany.Text = "Company"
        '
        'txtSearchSupplerName
        '
        Me.txtSearchSupplerName.Location = New System.Drawing.Point(141, 83)
        Me.txtSearchSupplerName.Name = "txtSearchSupplerName"
        Me.txtSearchSupplerName.Size = New System.Drawing.Size(208, 21)
        Me.txtSearchSupplerName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(123, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 14)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = ":"
        '
        'lblSearchSupplierName
        '
        Me.lblSearchSupplierName.AutoSize = True
        Me.lblSearchSupplierName.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchSupplierName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchSupplierName.Location = New System.Drawing.Point(8, 86)
        Me.lblSearchSupplierName.Name = "lblSearchSupplierName"
        Me.lblSearchSupplierName.Size = New System.Drawing.Size(102, 13)
        Me.lblSearchSupplierName.TabIndex = 63
        Me.lblSearchSupplierName.Text = "Supplier Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(123, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = ":"
        '
        'lblSearchSupplierCode
        '
        Me.lblSearchSupplierCode.AutoSize = True
        Me.lblSearchSupplierCode.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchSupplierCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchSupplierCode.Location = New System.Drawing.Point(8, 58)
        Me.lblSearchSupplierCode.Name = "lblSearchSupplierCode"
        Me.lblSearchSupplierCode.Size = New System.Drawing.Size(97, 13)
        Me.lblSearchSupplierCode.TabIndex = 54
        Me.lblSearchSupplierCode.Text = "Supplier Code"
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
        Me.btnClose.Location = New System.Drawing.Point(423, 106)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 27)
        Me.btnClose.TabIndex = 4
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnView
        '
        Me.btnView.BackColor = System.Drawing.Color.Transparent
        Me.btnView.BackgroundImage = CType(resources.GetObject("btnView.BackgroundImage"), System.Drawing.Image)
        Me.btnView.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnView.FlatAppearance.BorderSize = 0
        Me.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnView.Location = New System.Drawing.Point(367, 106)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(28, 30)
        Me.btnView.TabIndex = 3
        Me.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnView.UseVisualStyleBackColor = False
        '
        'dgvSupplier
        '
        Me.dgvSupplier.AllowUserToAddRows = False
        Me.dgvSupplier.AllowUserToDeleteRows = False
        Me.dgvSupplier.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgvSupplier.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSupplier.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSupplier.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSupplier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSupplier.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSupplier.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSupplier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclSupplierCode, Me.dgclSupplierName, Me.dgclCompany, Me.dgclProductCode, Me.dgclProductDesc, Me.dgclSupplierID, Me.dgclProductID})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSupplier.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSupplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSupplier.EnableHeadersVisualStyles = False
        Me.dgvSupplier.GridColor = System.Drawing.Color.Gray
        Me.dgvSupplier.Location = New System.Drawing.Point(0, 142)
        Me.dgvSupplier.Name = "dgvSupplier"
        Me.dgvSupplier.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSupplier.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSupplier.RowHeadersVisible = False
        Me.dgvSupplier.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSupplier.Size = New System.Drawing.Size(475, 273)
        Me.dgvSupplier.TabIndex = 14
        '
        'dgclSupplierCode
        '
        Me.dgclSupplierCode.DataPropertyName = "SupplierCode"
        Me.dgclSupplierCode.HeaderText = "Supplier Code"
        Me.dgclSupplierCode.Name = "dgclSupplierCode"
        Me.dgclSupplierCode.ReadOnly = True
        Me.dgclSupplierCode.Width = 112
        '
        'dgclSupplierName
        '
        Me.dgclSupplierName.DataPropertyName = "SupplierName"
        Me.dgclSupplierName.HeaderText = "Supplier Name"
        Me.dgclSupplierName.Name = "dgclSupplierName"
        Me.dgclSupplierName.ReadOnly = True
        Me.dgclSupplierName.Width = 115
        '
        'dgclCompany
        '
        Me.dgclCompany.DataPropertyName = "Company"
        Me.dgclCompany.HeaderText = "Company"
        Me.dgclCompany.Name = "dgclCompany"
        Me.dgclCompany.ReadOnly = True
        Me.dgclCompany.Width = 86
        '
        'dgclProductCode
        '
        Me.dgclProductCode.DataPropertyName = "ProductCode"
        Me.dgclProductCode.HeaderText = "Product Code"
        Me.dgclProductCode.Name = "dgclProductCode"
        Me.dgclProductCode.ReadOnly = True
        Me.dgclProductCode.Visible = False
        Me.dgclProductCode.Width = 108
        '
        'dgclProductDesc
        '
        Me.dgclProductDesc.DataPropertyName = "ProductDescp"
        Me.dgclProductDesc.HeaderText = "Product Desc"
        Me.dgclProductDesc.Name = "dgclProductDesc"
        Me.dgclProductDesc.ReadOnly = True
        Me.dgclProductDesc.Visible = False
        Me.dgclProductDesc.Width = 106
        '
        'dgclSupplierID
        '
        Me.dgclSupplierID.DataPropertyName = "SupplierCustID"
        Me.dgclSupplierID.HeaderText = "SupplierID"
        Me.dgclSupplierID.Name = "dgclSupplierID"
        Me.dgclSupplierID.ReadOnly = True
        Me.dgclSupplierID.Visible = False
        Me.dgclSupplierID.Width = 92
        '
        'dgclProductID
        '
        Me.dgclProductID.DataPropertyName = "ProductID"
        Me.dgclProductID.HeaderText = "Product ID"
        Me.dgclProductID.Name = "dgclProductID"
        Me.dgclProductID.ReadOnly = True
        Me.dgclProductID.Visible = False
        Me.dgclProductID.Width = 92
        '
        'WBSupplierLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(475, 415)
        Me.Controls.Add(Me.dgvSupplier)
        Me.Controls.Add(Me.pnlSupplierSearch)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "WBSupplierLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WBSupplier LookUp"
        Me.pnlSupplierSearch.ResumeLayout(False)
        Me.pnlSupplierSearch.PerformLayout()
        CType(Me.dgvSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSearchSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents pnlSupplierSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSearchSupplierCode As System.Windows.Forms.Label
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvSupplier As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSearchSupplierName As System.Windows.Forms.Label
    Friend WithEvents txtSearchSupplerName As System.Windows.Forms.TextBox
    Friend WithEvents lblColon4 As System.Windows.Forms.Label
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents dgclSupplierCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclCompany As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProductDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProductID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbCompany As System.Windows.Forms.ComboBox
End Class

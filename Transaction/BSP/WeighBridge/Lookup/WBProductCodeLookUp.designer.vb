<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WBProductCodeLookUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WBProductCodeLookUp))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtSerachProductCode = New System.Windows.Forms.TextBox
        Me.pnlProductSearch = New Stepi.UI.ExtendedPanel
        Me.txtSearchProductDesc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSearchProductDesc = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblSearchProductCode = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.dgvProductCode = New System.Windows.Forms.DataGridView
        Me.dgclProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProductDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProductID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlProductSearch.SuspendLayout()
        CType(Me.dgvProductCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSerachProductCode
        '
        Me.txtSerachProductCode.Location = New System.Drawing.Point(171, 54)
        Me.txtSerachProductCode.Name = "txtSerachProductCode"
        Me.txtSerachProductCode.Size = New System.Drawing.Size(202, 21)
        Me.txtSerachProductCode.TabIndex = 1
        '
        'pnlProductSearch
        '
        Me.pnlProductSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlProductSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlProductSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlProductSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlProductSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlProductSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlProductSearch.CaptionSize = 40
        Me.pnlProductSearch.CaptionText = "Search by :"
        Me.pnlProductSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlProductSearch.Controls.Add(Me.txtSearchProductDesc)
        Me.pnlProductSearch.Controls.Add(Me.Label1)
        Me.pnlProductSearch.Controls.Add(Me.lblSearchProductDesc)
        Me.pnlProductSearch.Controls.Add(Me.Label4)
        Me.pnlProductSearch.Controls.Add(Me.lblSearchProductCode)
        Me.pnlProductSearch.Controls.Add(Me.btnClose)
        Me.pnlProductSearch.Controls.Add(Me.btnView)
        Me.pnlProductSearch.Controls.Add(Me.txtSerachProductCode)
        Me.pnlProductSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlProductSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlProductSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlProductSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlProductSearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlProductSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlProductSearch.Name = "pnlProductSearch"
        Me.pnlProductSearch.Size = New System.Drawing.Size(486, 119)
        Me.pnlProductSearch.TabIndex = 14
        '
        'txtSearchProductDesc
        '
        Me.txtSearchProductDesc.Location = New System.Drawing.Point(171, 88)
        Me.txtSearchProductDesc.Name = "txtSearchProductDesc"
        Me.txtSearchProductDesc.Size = New System.Drawing.Size(202, 21)
        Me.txtSearchProductDesc.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(153, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 14)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = ":"
        '
        'lblSearchProductDesc
        '
        Me.lblSearchProductDesc.AutoSize = True
        Me.lblSearchProductDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchProductDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchProductDesc.Location = New System.Drawing.Point(8, 90)
        Me.lblSearchProductDesc.Name = "lblSearchProductDesc"
        Me.lblSearchProductDesc.Size = New System.Drawing.Size(135, 13)
        Me.lblSearchProductDesc.TabIndex = 62
        Me.lblSearchProductDesc.Text = "Product Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(153, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = ":"
        '
        'lblSearchProductCode
        '
        Me.lblSearchProductCode.AutoSize = True
        Me.lblSearchProductCode.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchProductCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchProductCode.Location = New System.Drawing.Point(8, 58)
        Me.lblSearchProductCode.Name = "lblSearchProductCode"
        Me.lblSearchProductCode.Size = New System.Drawing.Size(93, 13)
        Me.lblSearchProductCode.TabIndex = 54
        Me.lblSearchProductCode.Text = "Product Code"
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
        Me.btnClose.Location = New System.Drawing.Point(432, 83)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 27)
        Me.btnClose.TabIndex = 4
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnView
        '
        Me.btnView.BackColor = System.Drawing.Color.Transparent
        Me.btnView.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnView.FlatAppearance.BorderSize = 0
        Me.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnView.Location = New System.Drawing.Point(385, 81)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(50, 30)
        Me.btnView.TabIndex = 3
        Me.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnView.UseVisualStyleBackColor = False
        '
        'dgvProductCode
        '
        Me.dgvProductCode.AllowUserToAddRows = False
        Me.dgvProductCode.AllowUserToDeleteRows = False
        Me.dgvProductCode.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgvProductCode.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvProductCode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvProductCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvProductCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvProductCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProductCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclProductCode, Me.dgclProductDesc, Me.dgclProductID})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProductCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductCode.EnableHeadersVisualStyles = False
        Me.dgvProductCode.GridColor = System.Drawing.Color.Gray
        Me.dgvProductCode.Location = New System.Drawing.Point(0, 119)
        Me.dgvProductCode.Name = "dgvProductCode"
        Me.dgvProductCode.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductCode.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProductCode.RowHeadersVisible = False
        Me.dgvProductCode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvProductCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductCode.Size = New System.Drawing.Size(486, 296)
        Me.dgvProductCode.TabIndex = 15
        '
        'dgclProductCode
        '
        Me.dgclProductCode.DataPropertyName = "ProductCode"
        Me.dgclProductCode.HeaderText = "Product Code"
        Me.dgclProductCode.Name = "dgclProductCode"
        Me.dgclProductCode.ReadOnly = True
        Me.dgclProductCode.Width = 108
        '
        'dgclProductDesc
        '
        Me.dgclProductDesc.DataPropertyName = "ProductDescp"
        Me.dgclProductDesc.HeaderText = "Product Desc"
        Me.dgclProductDesc.Name = "dgclProductDesc"
        Me.dgclProductDesc.ReadOnly = True
        Me.dgclProductDesc.Width = 106
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
        'WBProductCodeLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(486, 415)
        Me.Controls.Add(Me.dgvProductCode)
        Me.Controls.Add(Me.pnlProductSearch)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "WBProductCodeLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WBProductCodeLookUp"
        Me.pnlProductSearch.ResumeLayout(False)
        Me.pnlProductSearch.PerformLayout()
        CType(Me.dgvProductCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSerachProductCode As System.Windows.Forms.TextBox
    Friend WithEvents pnlProductSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSearchProductCode As System.Windows.Forms.Label
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvProductCode As System.Windows.Forms.DataGridView
    Friend WithEvents txtSearchProductDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSearchProductDesc As System.Windows.Forms.Label
    Friend WithEvents dgclProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProductDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProductID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

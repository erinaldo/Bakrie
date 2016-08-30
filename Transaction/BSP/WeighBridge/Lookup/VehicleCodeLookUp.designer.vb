<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleCodeLookUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VehicleCodeLookUp))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlVehicleSearch = New Stepi.UI.ExtendedPanel
        Me.txtSearchVehicleDesc = New System.Windows.Forms.TextBox
        Me.lblSearchVehicleDesc = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblSearchVehicleCode = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnVehicleSearch = New System.Windows.Forms.Button
        Me.txtSearchVehicleCode = New System.Windows.Forms.TextBox
        Me.dgvVehicleCode = New System.Windows.Forms.DataGridView
        Me.dgclVehicleCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclVehicleDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplierDetID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplierCustID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProductID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclProductDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlVehicleSearch.SuspendLayout()
        CType(Me.dgvVehicleCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlVehicleSearch
        '
        Me.pnlVehicleSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlVehicleSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlVehicleSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlVehicleSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlVehicleSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlVehicleSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlVehicleSearch.CaptionSize = 40
        Me.pnlVehicleSearch.CaptionText = "Search by :"
        Me.pnlVehicleSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlVehicleSearch.Controls.Add(Me.txtSearchVehicleDesc)
        Me.pnlVehicleSearch.Controls.Add(Me.lblSearchVehicleDesc)
        Me.pnlVehicleSearch.Controls.Add(Me.Label2)
        Me.pnlVehicleSearch.Controls.Add(Me.btnClose)
        Me.pnlVehicleSearch.Controls.Add(Me.lblSearchVehicleCode)
        Me.pnlVehicleSearch.Controls.Add(Me.Label4)
        Me.pnlVehicleSearch.Controls.Add(Me.btnVehicleSearch)
        Me.pnlVehicleSearch.Controls.Add(Me.txtSearchVehicleCode)
        Me.pnlVehicleSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlVehicleSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlVehicleSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlVehicleSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVehicleSearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlVehicleSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlVehicleSearch.Name = "pnlVehicleSearch"
        Me.pnlVehicleSearch.Size = New System.Drawing.Size(478, 119)
        Me.pnlVehicleSearch.TabIndex = 12
        '
        'txtSearchVehicleDesc
        '
        Me.txtSearchVehicleDesc.Location = New System.Drawing.Point(169, 85)
        Me.txtSearchVehicleDesc.Name = "txtSearchVehicleDesc"
        Me.txtSearchVehicleDesc.Size = New System.Drawing.Size(200, 21)
        Me.txtSearchVehicleDesc.TabIndex = 2
        '
        'lblSearchVehicleDesc
        '
        Me.lblSearchVehicleDesc.AutoSize = True
        Me.lblSearchVehicleDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchVehicleDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchVehicleDesc.Location = New System.Drawing.Point(12, 85)
        Me.lblSearchVehicleDesc.Name = "lblSearchVehicleDesc"
        Me.lblSearchVehicleDesc.Size = New System.Drawing.Size(132, 13)
        Me.lblSearchVehicleDesc.TabIndex = 64
        Me.lblSearchVehicleDesc.Text = "Vehicle Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(151, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = ":"
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
        Me.btnClose.Location = New System.Drawing.Point(426, 81)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 27)
        Me.btnClose.TabIndex = 4
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblSearchVehicleCode
        '
        Me.lblSearchVehicleCode.AutoSize = True
        Me.lblSearchVehicleCode.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchVehicleCode.Location = New System.Drawing.Point(12, 58)
        Me.lblSearchVehicleCode.Name = "lblSearchVehicleCode"
        Me.lblSearchVehicleCode.Size = New System.Drawing.Size(90, 13)
        Me.lblSearchVehicleCode.TabIndex = 54
        Me.lblSearchVehicleCode.Text = "Vehicle Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(152, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = ":"
        '
        'btnVehicleSearch
        '
        Me.btnVehicleSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnVehicleSearch.BackgroundImage = CType(resources.GetObject("btnVehicleSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnVehicleSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnVehicleSearch.FlatAppearance.BorderSize = 0
        Me.btnVehicleSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnVehicleSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVehicleSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehicleSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVehicleSearch.Location = New System.Drawing.Point(386, 80)
        Me.btnVehicleSearch.Name = "btnVehicleSearch"
        Me.btnVehicleSearch.Size = New System.Drawing.Size(27, 23)
        Me.btnVehicleSearch.TabIndex = 3
        Me.btnVehicleSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVehicleSearch.UseVisualStyleBackColor = False
        '
        'txtSearchVehicleCode
        '
        Me.txtSearchVehicleCode.Location = New System.Drawing.Point(170, 58)
        Me.txtSearchVehicleCode.Name = "txtSearchVehicleCode"
        Me.txtSearchVehicleCode.Size = New System.Drawing.Size(200, 21)
        Me.txtSearchVehicleCode.TabIndex = 1
        '
        'dgvVehicleCode
        '
        Me.dgvVehicleCode.AllowUserToAddRows = False
        Me.dgvVehicleCode.AllowUserToDeleteRows = False
        Me.dgvVehicleCode.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgvVehicleCode.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVehicleCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvVehicleCode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvVehicleCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvVehicleCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvVehicleCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVehicleCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVehicleCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclVehicleCode, Me.dgclVehicleDesc, Me.dgclSupplierDetID, Me.dgclSupplier, Me.dgclProductCode, Me.dgclSupplierCustID, Me.dgclProductID, Me.dgclProductDesc})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVehicleCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVehicleCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVehicleCode.EnableHeadersVisualStyles = False
        Me.dgvVehicleCode.GridColor = System.Drawing.Color.Gray
        Me.dgvVehicleCode.Location = New System.Drawing.Point(0, 119)
        Me.dgvVehicleCode.MultiSelect = False
        Me.dgvVehicleCode.Name = "dgvVehicleCode"
        Me.dgvVehicleCode.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVehicleCode.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvVehicleCode.RowHeadersVisible = False
        Me.dgvVehicleCode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvVehicleCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVehicleCode.Size = New System.Drawing.Size(478, 296)
        Me.dgvVehicleCode.TabIndex = 13
        '
        'dgclVehicleCode
        '
        Me.dgclVehicleCode.DataPropertyName = "VehicleCode"
        Me.dgclVehicleCode.HeaderText = "Vehicle Code"
        Me.dgclVehicleCode.Name = "dgclVehicleCode"
        Me.dgclVehicleCode.ReadOnly = True
        Me.dgclVehicleCode.Width = 106
        '
        'dgclVehicleDesc
        '
        Me.dgclVehicleDesc.DataPropertyName = "VehicleDescp"
        Me.dgclVehicleDesc.HeaderText = "Vehicle Description"
        Me.dgclVehicleDesc.Name = "dgclVehicleDesc"
        Me.dgclVehicleDesc.ReadOnly = True
        Me.dgclVehicleDesc.Width = 140
        '
        'dgclSupplierDetID
        '
        Me.dgclSupplierDetID.DataPropertyName = "WBVehicleID"
        Me.dgclSupplierDetID.HeaderText = "VehicleID"
        Me.dgclSupplierDetID.Name = "dgclSupplierDetID"
        Me.dgclSupplierDetID.ReadOnly = True
        Me.dgclSupplierDetID.Visible = False
        Me.dgclSupplierDetID.Width = 86
        '
        'dgclSupplier
        '
        Me.dgclSupplier.DataPropertyName = "SupplierCode"
        Me.dgclSupplier.HeaderText = "Supplier Code"
        Me.dgclSupplier.Name = "dgclSupplier"
        Me.dgclSupplier.ReadOnly = True
        Me.dgclSupplier.Visible = False
        Me.dgclSupplier.Width = 112
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
        'dgclSupplierCustID
        '
        Me.dgclSupplierCustID.DataPropertyName = "SupplierCustID"
        Me.dgclSupplierCustID.HeaderText = "Supplier Cust ID"
        Me.dgclSupplierCustID.Name = "dgclSupplierCustID"
        Me.dgclSupplierCustID.ReadOnly = True
        Me.dgclSupplierCustID.Visible = False
        Me.dgclSupplierCustID.Width = 126
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
        'dgclProductDesc
        '
        Me.dgclProductDesc.DataPropertyName = "ProductDescp"
        Me.dgclProductDesc.HeaderText = "Product Desc"
        Me.dgclProductDesc.Name = "dgclProductDesc"
        Me.dgclProductDesc.ReadOnly = True
        Me.dgclProductDesc.Visible = False
        Me.dgclProductDesc.Width = 106
        '
        'VehicleCodeLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(478, 415)
        Me.Controls.Add(Me.dgvVehicleCode)
        Me.Controls.Add(Me.pnlVehicleSearch)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "VehicleCodeLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VehicleCodeLookUp"
        Me.pnlVehicleSearch.ResumeLayout(False)
        Me.pnlVehicleSearch.PerformLayout()
        CType(Me.dgvVehicleCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlVehicleSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents btnVehicleSearch As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSearchVehicleCode As System.Windows.Forms.Label
    Friend WithEvents txtSearchVehicleCode As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvVehicleCode As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearchVehicleDesc As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSearchVehicleDesc As System.Windows.Forms.TextBox
    Friend WithEvents dgclVehicleCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclVehicleDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierDetID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierCustID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProductID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProductDesc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

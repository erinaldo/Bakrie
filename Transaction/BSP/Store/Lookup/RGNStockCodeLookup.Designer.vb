<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RGNStockCodeLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RGNStockCodeLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panRGNStockCodeLookUp = New Stepi.UI.ExtendedPanel
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPartNoSearch = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblStockDescSearch = New System.Windows.Forms.Label
        Me.txtStockDescSearch = New System.Windows.Forms.TextBox
        Me.lblStockCodeSearch = New System.Windows.Forms.Label
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.txtStockCodeSearch = New System.Windows.Forms.TextBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSIVSearch = New System.Windows.Forms.Button
        Me.dgStockCode = New System.Windows.Forms.DataGridView
        Me.StockCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VarianceCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SIVCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SIVCOACODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SIVCOADESCP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IssuedValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STIssueDetailsID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STIssueId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T0Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T1Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T2Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T3Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T4Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Div = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YOP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YOPId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Block = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlockId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHDetailCostCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHDetailCostCodeId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Station = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StationId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ODOReading = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IssuedQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.panRGNStockCodeLookUp.SuspendLayout()
        CType(Me.dgStockCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panRGNStockCodeLookUp
        '
        Me.panRGNStockCodeLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panRGNStockCodeLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panRGNStockCodeLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panRGNStockCodeLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panRGNStockCodeLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panRGNStockCodeLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panRGNStockCodeLookUp.CaptionSize = 40
        Me.panRGNStockCodeLookUp.CaptionText = "Select Stock Code"
        Me.panRGNStockCodeLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panRGNStockCodeLookUp.Controls.Add(Me.Label4)
        Me.panRGNStockCodeLookUp.Controls.Add(Me.txtPartNoSearch)
        Me.panRGNStockCodeLookUp.Controls.Add(Me.Label3)
        Me.panRGNStockCodeLookUp.Controls.Add(Me.Label2)
        Me.panRGNStockCodeLookUp.Controls.Add(Me.Label1)
        Me.panRGNStockCodeLookUp.Controls.Add(Me.lblStockDescSearch)
        Me.panRGNStockCodeLookUp.Controls.Add(Me.txtStockDescSearch)
        Me.panRGNStockCodeLookUp.Controls.Add(Me.lblStockCodeSearch)
        Me.panRGNStockCodeLookUp.Controls.Add(Me.lblSearchBy)
        Me.panRGNStockCodeLookUp.Controls.Add(Me.txtStockCodeSearch)
        Me.panRGNStockCodeLookUp.Controls.Add(Me.btnClose)
        Me.panRGNStockCodeLookUp.Controls.Add(Me.btnSIVSearch)
        Me.panRGNStockCodeLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panRGNStockCodeLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panRGNStockCodeLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panRGNStockCodeLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panRGNStockCodeLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panRGNStockCodeLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panRGNStockCodeLookUp.Name = "panRGNStockCodeLookUp"
        Me.panRGNStockCodeLookUp.Size = New System.Drawing.Size(1184, 119)
        Me.panRGNStockCodeLookUp.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(362, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Part No"
        '
        'txtPartNoSearch
        '
        Me.txtPartNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtPartNoSearch.Location = New System.Drawing.Point(362, 93)
        Me.txtPartNoSearch.Name = "txtPartNoSearch"
        Me.txtPartNoSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtPartNoSearch.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(80, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = " :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(297, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = " :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(82, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = " :"
        '
        'lblStockDescSearch
        '
        Me.lblStockDescSearch.AutoSize = True
        Me.lblStockDescSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblStockDescSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockDescSearch.Location = New System.Drawing.Point(181, 77)
        Me.lblStockDescSearch.Name = "lblStockDescSearch"
        Me.lblStockDescSearch.Size = New System.Drawing.Size(121, 13)
        Me.lblStockDescSearch.TabIndex = 106
        Me.lblStockDescSearch.Text = "Stock Description"
        '
        'txtStockDescSearch
        '
        Me.txtStockDescSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtStockDescSearch.Location = New System.Drawing.Point(181, 93)
        Me.txtStockDescSearch.Name = "txtStockDescSearch"
        Me.txtStockDescSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtStockDescSearch.TabIndex = 2
        '
        'lblStockCodeSearch
        '
        Me.lblStockCodeSearch.AutoSize = True
        Me.lblStockCodeSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblStockCodeSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockCodeSearch.Location = New System.Drawing.Point(3, 77)
        Me.lblStockCodeSearch.Name = "lblStockCodeSearch"
        Me.lblStockCodeSearch.Size = New System.Drawing.Size(79, 13)
        Me.lblStockCodeSearch.TabIndex = 104
        Me.lblStockCodeSearch.Text = "Stock Code"
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchBy.Location = New System.Drawing.Point(4, 52)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchBy.TabIndex = 54
        Me.lblSearchBy.Text = "Search By"
        '
        'txtStockCodeSearch
        '
        Me.txtStockCodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtStockCodeSearch.Location = New System.Drawing.Point(3, 93)
        Me.txtStockCodeSearch.Name = "txtStockCodeSearch"
        Me.txtStockCodeSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtStockCodeSearch.TabIndex = 1
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
        Me.btnClose.Location = New System.Drawing.Point(579, 89)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 5
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSIVSearch
        '
        Me.btnSIVSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSIVSearch.BackgroundImage = CType(resources.GetObject("btnSIVSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSIVSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnSIVSearch.FlatAppearance.BorderSize = 0
        Me.btnSIVSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnSIVSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSIVSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSIVSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSIVSearch.Location = New System.Drawing.Point(553, 89)
        Me.btnSIVSearch.Name = "btnSIVSearch"
        Me.btnSIVSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnSIVSearch.TabIndex = 4
        Me.btnSIVSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSIVSearch.UseVisualStyleBackColor = False
        '
        'dgStockCode
        '
        Me.dgStockCode.AllowUserToAddRows = False
        Me.dgStockCode.AllowUserToDeleteRows = False
        Me.dgStockCode.AllowUserToOrderColumns = True
        Me.dgStockCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgStockCode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgStockCode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgStockCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgStockCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStockCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgStockCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StockCode, Me.VarianceCOAID, Me.StockCOAID, Me.SIVCOAID, Me.SIVCOACODE, Me.SIVCOADESCP, Me.StockID, Me.StockDesc, Me.Unit, Me.PartNo, Me.IssuedValue, Me.STIssueDetailsID, Me.STIssueId, Me.T0, Me.T0Id, Me.T1, Me.T1Id, Me.T2, Me.T2Id, Me.T3, Me.T3Id, Me.T4, Me.T4Id, Me.Div, Me.DivId, Me.YOP, Me.YOPId, Me.Block, Me.BlockId, Me.VHNo, Me.VHId, Me.VHDetailCostCode, Me.VHDetailCostCodeId, Me.Station, Me.StationId, Me.ODOReading, Me.IssuedQty})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgStockCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgStockCode.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgStockCode.EnableHeadersVisualStyles = False
        Me.dgStockCode.GridColor = System.Drawing.Color.Gray
        Me.dgStockCode.Location = New System.Drawing.Point(0, 119)
        Me.dgStockCode.MultiSelect = False
        Me.dgStockCode.Name = "dgStockCode"
        Me.dgStockCode.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStockCode.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgStockCode.RowHeadersVisible = False
        Me.dgStockCode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.dgStockCode.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgStockCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgStockCode.Size = New System.Drawing.Size(1184, 321)
        Me.dgStockCode.TabIndex = 6
        Me.dgStockCode.TabStop = False
        '
        'StockCode
        '
        Me.StockCode.DataPropertyName = "StockCode"
        Me.StockCode.HeaderText = "Stock Code"
        Me.StockCode.Name = "StockCode"
        Me.StockCode.ReadOnly = True
        Me.StockCode.Width = 97
        '
        'VarianceCOAID
        '
        Me.VarianceCOAID.DataPropertyName = "VarianceCOAID"
        Me.VarianceCOAID.HeaderText = "VarianceCOAID"
        Me.VarianceCOAID.Name = "VarianceCOAID"
        Me.VarianceCOAID.ReadOnly = True
        Me.VarianceCOAID.Visible = False
        Me.VarianceCOAID.Width = 121
        '
        'StockCOAID
        '
        Me.StockCOAID.DataPropertyName = "StockCOAID"
        Me.StockCOAID.HeaderText = "StockCOAID"
        Me.StockCOAID.Name = "StockCOAID"
        Me.StockCOAID.ReadOnly = True
        Me.StockCOAID.Visible = False
        Me.StockCOAID.Width = 103
        '
        'SIVCOAID
        '
        Me.SIVCOAID.DataPropertyName = "SIVCOAID"
        Me.SIVCOAID.HeaderText = "SIVCOAID"
        Me.SIVCOAID.Name = "SIVCOAID"
        Me.SIVCOAID.ReadOnly = True
        Me.SIVCOAID.Visible = False
        Me.SIVCOAID.Width = 92
        '
        'SIVCOACODE
        '
        Me.SIVCOACODE.DataPropertyName = "SIVCOACODE"
        Me.SIVCOACODE.HeaderText = "Acc.Code"
        Me.SIVCOACODE.Name = "SIVCOACODE"
        Me.SIVCOACODE.ReadOnly = True
        Me.SIVCOACODE.Width = 85
        '
        'SIVCOADESCP
        '
        Me.SIVCOADESCP.DataPropertyName = "SIVCOADESCP"
        Me.SIVCOADESCP.HeaderText = "Acc.Descp"
        Me.SIVCOADESCP.Name = "SIVCOADESCP"
        Me.SIVCOADESCP.ReadOnly = True
        Me.SIVCOADESCP.Width = 90
        '
        'StockID
        '
        Me.StockID.DataPropertyName = "StockID"
        Me.StockID.HeaderText = "Stock ID"
        Me.StockID.Name = "StockID"
        Me.StockID.ReadOnly = True
        Me.StockID.Visible = False
        Me.StockID.Width = 81
        '
        'StockDesc
        '
        Me.StockDesc.DataPropertyName = "StockDesc"
        Me.StockDesc.HeaderText = "Stock Description"
        Me.StockDesc.Name = "StockDesc"
        Me.StockDesc.ReadOnly = True
        Me.StockDesc.Width = 131
        '
        'Unit
        '
        Me.Unit.DataPropertyName = "Unit"
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        Me.Unit.Width = 53
        '
        'PartNo
        '
        Me.PartNo.DataPropertyName = "PartNo"
        Me.PartNo.HeaderText = "Part No"
        Me.PartNo.Name = "PartNo"
        Me.PartNo.ReadOnly = True
        Me.PartNo.Width = 73
        '
        'IssuedValue
        '
        Me.IssuedValue.DataPropertyName = "IssueValue"
        Me.IssuedValue.HeaderText = "IssuedValue"
        Me.IssuedValue.Name = "IssuedValue"
        Me.IssuedValue.ReadOnly = True
        Me.IssuedValue.Visible = False
        Me.IssuedValue.Width = 101
        '
        'STIssueDetailsID
        '
        Me.STIssueDetailsID.DataPropertyName = "STIssueDetailsID"
        Me.STIssueDetailsID.HeaderText = "STIssueDetailsID"
        Me.STIssueDetailsID.Name = "STIssueDetailsID"
        Me.STIssueDetailsID.ReadOnly = True
        Me.STIssueDetailsID.Visible = False
        Me.STIssueDetailsID.Width = 130
        '
        'STIssueId
        '
        Me.STIssueId.DataPropertyName = "STIssueId"
        Me.STIssueId.HeaderText = "STIssueId"
        Me.STIssueId.Name = "STIssueId"
        Me.STIssueId.ReadOnly = True
        Me.STIssueId.Visible = False
        Me.STIssueId.Width = 89
        '
        'T0
        '
        Me.T0.DataPropertyName = "T0"
        Me.T0.HeaderText = "T0"
        Me.T0.Name = "T0"
        Me.T0.ReadOnly = True
        Me.T0.Visible = False
        Me.T0.Width = 45
        '
        'T0Id
        '
        Me.T0Id.DataPropertyName = "T0Id"
        Me.T0Id.HeaderText = "T0Id"
        Me.T0Id.Name = "T0Id"
        Me.T0Id.ReadOnly = True
        Me.T0Id.Visible = False
        Me.T0Id.Width = 57
        '
        'T1
        '
        Me.T1.DataPropertyName = "T1"
        Me.T1.HeaderText = "T1"
        Me.T1.Name = "T1"
        Me.T1.ReadOnly = True
        Me.T1.Visible = False
        Me.T1.Width = 45
        '
        'T1Id
        '
        Me.T1Id.DataPropertyName = "T1Id"
        Me.T1Id.HeaderText = "T1Id"
        Me.T1Id.Name = "T1Id"
        Me.T1Id.ReadOnly = True
        Me.T1Id.Visible = False
        Me.T1Id.Width = 57
        '
        'T2
        '
        Me.T2.DataPropertyName = "T2"
        Me.T2.HeaderText = "T2"
        Me.T2.Name = "T2"
        Me.T2.ReadOnly = True
        Me.T2.Visible = False
        Me.T2.Width = 45
        '
        'T2Id
        '
        Me.T2Id.DataPropertyName = "T2Id"
        Me.T2Id.HeaderText = "T2Id"
        Me.T2Id.Name = "T2Id"
        Me.T2Id.ReadOnly = True
        Me.T2Id.Visible = False
        Me.T2Id.Width = 57
        '
        'T3
        '
        Me.T3.DataPropertyName = "T3"
        Me.T3.HeaderText = "T3"
        Me.T3.Name = "T3"
        Me.T3.ReadOnly = True
        Me.T3.Visible = False
        Me.T3.Width = 45
        '
        'T3Id
        '
        Me.T3Id.DataPropertyName = "T3Id"
        Me.T3Id.HeaderText = "T3Id"
        Me.T3Id.Name = "T3Id"
        Me.T3Id.ReadOnly = True
        Me.T3Id.Visible = False
        Me.T3Id.Width = 57
        '
        'T4
        '
        Me.T4.DataPropertyName = "T4"
        Me.T4.HeaderText = "T4"
        Me.T4.Name = "T4"
        Me.T4.ReadOnly = True
        Me.T4.Visible = False
        Me.T4.Width = 45
        '
        'T4Id
        '
        Me.T4Id.DataPropertyName = "T4Id"
        Me.T4Id.HeaderText = "T4Id"
        Me.T4Id.Name = "T4Id"
        Me.T4Id.ReadOnly = True
        Me.T4Id.Visible = False
        Me.T4Id.Width = 57
        '
        'Div
        '
        Me.Div.DataPropertyName = "Div"
        Me.Div.HeaderText = "Afdeling"
        Me.Div.Name = "Div"
        Me.Div.ReadOnly = True
        Me.Div.Width = 50
        '
        'DivId
        '
        Me.DivId.DataPropertyName = "DivId"
        Me.DivId.HeaderText = "AfdelingId"
        Me.DivId.Name = "DivId"
        Me.DivId.ReadOnly = True
        Me.DivId.Visible = False
        Me.DivId.Width = 62
        '
        'YOP
        '
        Me.YOP.DataPropertyName = "YOP"
        Me.YOP.HeaderText = "YOP"
        Me.YOP.Name = "YOP"
        Me.YOP.ReadOnly = True
        Me.YOP.Width = 54
        '
        'YOPId
        '
        Me.YOPId.DataPropertyName = "YOPId"
        Me.YOPId.HeaderText = "YOPId"
        Me.YOPId.Name = "YOPId"
        Me.YOPId.ReadOnly = True
        Me.YOPId.Visible = False
        Me.YOPId.Width = 66
        '
        'Block
        '
        Me.Block.DataPropertyName = "Block"
        Me.Block.HeaderText = "FieldNo"
        Me.Block.Name = "Block"
        Me.Block.ReadOnly = True
        Me.Block.Width = 62
        '
        'BlockId
        '
        Me.BlockId.DataPropertyName = "BlockId"
        Me.BlockId.HeaderText = "FieldNoId"
        Me.BlockId.Name = "BlockId"
        Me.BlockId.ReadOnly = True
        Me.BlockId.Visible = False
        Me.BlockId.Width = 74
        '
        'VHNo
        '
        Me.VHNo.DataPropertyName = "VHNo"
        Me.VHNo.HeaderText = "VHNo/WS No"
        Me.VHNo.Name = "VHNo"
        Me.VHNo.ReadOnly = True
        Me.VHNo.Width = 105
        '
        'VHId
        '
        Me.VHId.DataPropertyName = "VHId"
        Me.VHId.HeaderText = "VHId"
        Me.VHId.Name = "VHId"
        Me.VHId.ReadOnly = True
        Me.VHId.Visible = False
        Me.VHId.Width = 59
        '
        'VHDetailCostCode
        '
        Me.VHDetailCostCode.DataPropertyName = "VHDetailCostCode"
        Me.VHDetailCostCode.HeaderText = "VH Detail Cost Code"
        Me.VHDetailCostCode.Name = "VHDetailCostCode"
        Me.VHDetailCostCode.ReadOnly = True
        Me.VHDetailCostCode.Width = 148
        '
        'VHDetailCostCodeId
        '
        Me.VHDetailCostCodeId.DataPropertyName = "VHDetailCostCodeId"
        Me.VHDetailCostCodeId.HeaderText = "VHDetailCostCodeId"
        Me.VHDetailCostCodeId.Name = "VHDetailCostCodeId"
        Me.VHDetailCostCodeId.ReadOnly = True
        Me.VHDetailCostCodeId.Visible = False
        Me.VHDetailCostCodeId.Width = 148
        '
        'Station
        '
        Me.Station.DataPropertyName = "Station"
        Me.Station.HeaderText = "Station"
        Me.Station.Name = "Station"
        Me.Station.ReadOnly = True
        Me.Station.Width = 71
        '
        'StationId
        '
        Me.StationId.DataPropertyName = "StationId"
        Me.StationId.HeaderText = "StationId"
        Me.StationId.Name = "StationId"
        Me.StationId.ReadOnly = True
        Me.StationId.Visible = False
        Me.StationId.Width = 83
        '
        'ODOReading
        '
        Me.ODOReading.DataPropertyName = "ODOReading"
        Me.ODOReading.HeaderText = "ODOReading"
        Me.ODOReading.Name = "ODOReading"
        Me.ODOReading.ReadOnly = True
        Me.ODOReading.Visible = False
        Me.ODOReading.Width = 104
        '
        'IssuedQty
        '
        Me.IssuedQty.DataPropertyName = "IssueQty"
        Me.IssuedQty.HeaderText = "IssuedQty"
        Me.IssuedQty.Name = "IssuedQty"
        Me.IssuedQty.ReadOnly = True
        Me.IssuedQty.Width = 89
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(150, 229)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(117, 13)
        Me.lblNoRecord.TabIndex = 110
        Me.lblNoRecord.Text = "No Record Found"
        Me.lblNoRecord.Visible = False
        '
        'RGNStockCodeLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1184, 443)
        Me.Controls.Add(Me.dgStockCode)
        Me.Controls.Add(Me.panRGNStockCodeLookUp)
        Me.Controls.Add(Me.lblNoRecord)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RGNStockCodeLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RTS Stock Code Lookup"
        Me.panRGNStockCodeLookUp.ResumeLayout(False)
        Me.panRGNStockCodeLookUp.PerformLayout()
        CType(Me.dgStockCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panRGNStockCodeLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStockDescSearch As System.Windows.Forms.Label
    Friend WithEvents txtStockDescSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblStockCodeSearch As System.Windows.Forms.Label
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtStockCodeSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSIVSearch As System.Windows.Forms.Button
    Friend WithEvents dgStockCode As System.Windows.Forms.DataGridView
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPartNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents StockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VarianceCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIVCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIVCOACODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIVCOADESCP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IssuedValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STIssueDetailsID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STIssueId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T0Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T1Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T2Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T3Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T4Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Div As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YOPId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Block As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlockId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDetailCostCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDetailCostCodeId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Station As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StationId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ODOReading As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IssuedQty As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

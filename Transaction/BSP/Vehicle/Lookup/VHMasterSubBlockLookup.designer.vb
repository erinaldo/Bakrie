<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VHMasterSubBlockLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VHMasterSubBlockLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.EstateId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSubBlockSearch = New System.Windows.Forms.Button()
        Me.ContractName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDivSearch = New System.Windows.Forms.TextBox()
        Me.panSubBlockLookUp = New Stepi.UI.ExtendedPanel()
        Me.lblYOPSearch = New System.Windows.Forms.Label()
        Me.txtYOPSearch = New System.Windows.Forms.TextBox()
        Me.lblBlockName = New System.Windows.Forms.Label()
        Me.txtBlockNameSearch = New System.Windows.Forms.TextBox()
        Me.lblDivSearch = New System.Windows.Forms.Label()
        Me.lblsearchSubBlock = New System.Windows.Forms.Label()
        Me.ContractNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgContractNo = New System.Windows.Forms.DataGridView()
        Me.ContractID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSubBlock = New System.Windows.Forms.DataGridView()
        Me.lblNoRecord = New System.Windows.Forms.Label()
        Me.dgclDiv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDivID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclDivName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclYOPID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclYOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclBlockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclBlockName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPlantedHect = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclBlockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcCropID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panSubBlockLookUp.SuspendLayout()
        CType(Me.dgContractNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSubBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btnClose.Location = New System.Drawing.Point(397, 83)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
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
        'btnSubBlockSearch
        '
        Me.btnSubBlockSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSubBlockSearch.BackgroundImage = CType(resources.GetObject("btnSubBlockSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSubBlockSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnSubBlockSearch.FlatAppearance.BorderSize = 0
        Me.btnSubBlockSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnSubBlockSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubBlockSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubBlockSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubBlockSearch.Location = New System.Drawing.Point(362, 83)
        Me.btnSubBlockSearch.Name = "btnSubBlockSearch"
        Me.btnSubBlockSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnSubBlockSearch.TabIndex = 102
        Me.btnSubBlockSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSubBlockSearch.UseVisualStyleBackColor = False
        '
        'ContractName
        '
        Me.ContractName.DataPropertyName = "ContractName"
        Me.ContractName.HeaderText = "Contract Name"
        Me.ContractName.Name = "ContractName"
        Me.ContractName.ReadOnly = True
        Me.ContractName.Width = 117
        '
        'txtDivSearch
        '
        Me.txtDivSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDivSearch.Location = New System.Drawing.Point(5, 89)
        Me.txtDivSearch.Name = "txtDivSearch"
        Me.txtDivSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtDivSearch.TabIndex = 101
        '
        'panSubBlockLookUp
        '
        Me.panSubBlockLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panSubBlockLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panSubBlockLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panSubBlockLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panSubBlockLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panSubBlockLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panSubBlockLookUp.CaptionSize = 40
        Me.panSubBlockLookUp.CaptionText = "Select FieldNo"
        Me.panSubBlockLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panSubBlockLookUp.Controls.Add(Me.lblYOPSearch)
        Me.panSubBlockLookUp.Controls.Add(Me.txtYOPSearch)
        Me.panSubBlockLookUp.Controls.Add(Me.lblBlockName)
        Me.panSubBlockLookUp.Controls.Add(Me.txtBlockNameSearch)
        Me.panSubBlockLookUp.Controls.Add(Me.lblDivSearch)
        Me.panSubBlockLookUp.Controls.Add(Me.btnClose)
        Me.panSubBlockLookUp.Controls.Add(Me.btnSubBlockSearch)
        Me.panSubBlockLookUp.Controls.Add(Me.lblsearchSubBlock)
        Me.panSubBlockLookUp.Controls.Add(Me.txtDivSearch)
        Me.panSubBlockLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panSubBlockLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panSubBlockLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panSubBlockLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panSubBlockLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panSubBlockLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panSubBlockLookUp.Name = "panSubBlockLookUp"
        Me.panSubBlockLookUp.Size = New System.Drawing.Size(466, 161)
        Me.panSubBlockLookUp.TabIndex = 14
        '
        'lblYOPSearch
        '
        Me.lblYOPSearch.AutoSize = True
        Me.lblYOPSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblYOPSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOPSearch.Location = New System.Drawing.Point(181, 70)
        Me.lblYOPSearch.Name = "lblYOPSearch"
        Me.lblYOPSearch.Size = New System.Drawing.Size(32, 13)
        Me.lblYOPSearch.TabIndex = 108
        Me.lblYOPSearch.Text = "YOP"
        '
        'txtYOPSearch
        '
        Me.txtYOPSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtYOPSearch.Location = New System.Drawing.Point(184, 90)
        Me.txtYOPSearch.Name = "txtYOPSearch"
        Me.txtYOPSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtYOPSearch.TabIndex = 107
        '
        'lblBlockName
        '
        Me.lblBlockName.AutoSize = True
        Me.lblBlockName.BackColor = System.Drawing.Color.Transparent
        Me.lblBlockName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlockName.Location = New System.Drawing.Point(5, 116)
        Me.lblBlockName.Name = "lblBlockName"
        Me.lblBlockName.Size = New System.Drawing.Size(97, 13)
        Me.lblBlockName.TabIndex = 106
        Me.lblBlockName.Text = "FieldNo Name"
        '
        'txtBlockNameSearch
        '
        Me.txtBlockNameSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtBlockNameSearch.Location = New System.Drawing.Point(5, 136)
        Me.txtBlockNameSearch.Name = "txtBlockNameSearch"
        Me.txtBlockNameSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtBlockNameSearch.TabIndex = 105
        '
        'lblDivSearch
        '
        Me.lblDivSearch.AutoSize = True
        Me.lblDivSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblDivSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivSearch.Location = New System.Drawing.Point(5, 69)
        Me.lblDivSearch.Name = "lblDivSearch"
        Me.lblDivSearch.Size = New System.Drawing.Size(61, 13)
        Me.lblDivSearch.TabIndex = 104
        Me.lblDivSearch.Text = "Afdeling"
        '
        'lblsearchSubBlock
        '
        Me.lblsearchSubBlock.AutoSize = True
        Me.lblsearchSubBlock.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchSubBlock.Location = New System.Drawing.Point(3, 44)
        Me.lblsearchSubBlock.Name = "lblsearchSubBlock"
        Me.lblsearchSubBlock.Size = New System.Drawing.Size(76, 13)
        Me.lblsearchSubBlock.TabIndex = 54
        Me.lblsearchSubBlock.Text = "Search By "
        '
        'ContractNo
        '
        Me.ContractNo.DataPropertyName = "ContractNo"
        Me.ContractNo.HeaderText = "Contract No"
        Me.ContractNo.Name = "ContractNo"
        Me.ContractNo.ReadOnly = True
        Me.ContractNo.Width = 99
        '
        'dgContractNo
        '
        Me.dgContractNo.AllowUserToAddRows = False
        Me.dgContractNo.AllowUserToDeleteRows = False
        Me.dgContractNo.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgContractNo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgContractNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgContractNo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgContractNo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgContractNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgContractNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContractNo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgContractNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ContractID, Me.ContractNo, Me.ContractName, Me.EstateId})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgContractNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgContractNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgContractNo.EnableHeadersVisualStyles = False
        Me.dgContractNo.GridColor = System.Drawing.Color.Gray
        Me.dgContractNo.Location = New System.Drawing.Point(0, 0)
        Me.dgContractNo.MultiSelect = False
        Me.dgContractNo.Name = "dgContractNo"
        Me.dgContractNo.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContractNo.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgContractNo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgContractNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgContractNo.Size = New System.Drawing.Size(466, 475)
        Me.dgContractNo.TabIndex = 15
        '
        'ContractID
        '
        Me.ContractID.DataPropertyName = "ContractID"
        Me.ContractID.HeaderText = "Contract ID"
        Me.ContractID.Name = "ContractID"
        Me.ContractID.ReadOnly = True
        Me.ContractID.Width = 98
        '
        'dgSubBlock
        '
        Me.dgSubBlock.AllowUserToAddRows = False
        Me.dgSubBlock.AllowUserToDeleteRows = False
        Me.dgSubBlock.AllowUserToOrderColumns = True
        Me.dgSubBlock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgSubBlock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgSubBlock.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgSubBlock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgSubBlock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSubBlock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgSubBlock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclDiv, Me.dgclDivID, Me.dgclDivName, Me.dgclYOPID, Me.dgclYOP, Me.dgclName, Me.dgclBlockID, Me.dgclBlockName, Me.dgclPlantedHect, Me.dgclBlockStatus, Me.dgcCropID})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSubBlock.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgSubBlock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSubBlock.EnableHeadersVisualStyles = False
        Me.dgSubBlock.GridColor = System.Drawing.Color.Gray
        Me.dgSubBlock.Location = New System.Drawing.Point(0, 161)
        Me.dgSubBlock.MultiSelect = False
        Me.dgSubBlock.Name = "dgSubBlock"
        Me.dgSubBlock.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSubBlock.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgSubBlock.RowHeadersVisible = False
        Me.dgSubBlock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgSubBlock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSubBlock.Size = New System.Drawing.Size(466, 314)
        Me.dgSubBlock.TabIndex = 16
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(104, 240)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 112
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'dgclDiv
        '
        Me.dgclDiv.DataPropertyName = "Div"
        Me.dgclDiv.HeaderText = "Afdeling"
        Me.dgclDiv.Name = "dgclDiv"
        Me.dgclDiv.ReadOnly = True
        Me.dgclDiv.Visible = False
        Me.dgclDiv.Width = 77
        '
        'dgclDivID
        '
        Me.dgclDivID.DataPropertyName = "DivID"
        Me.dgclDivID.HeaderText = "Afdeling ID"
        Me.dgclDivID.Name = "dgclDivID"
        Me.dgclDivID.ReadOnly = True
        Me.dgclDivID.Visible = False
        Me.dgclDivID.Width = 95
        '
        'dgclDivName
        '
        Me.dgclDivName.DataPropertyName = "DivName"
        Me.dgclDivName.HeaderText = "Afdeling"
        Me.dgclDivName.Name = "dgclDivName"
        Me.dgclDivName.ReadOnly = True
        Me.dgclDivName.Width = 77
        '
        'dgclYOPID
        '
        Me.dgclYOPID.DataPropertyName = "YOPID"
        Me.dgclYOPID.HeaderText = "YOPID"
        Me.dgclYOPID.Name = "dgclYOPID"
        Me.dgclYOPID.ReadOnly = True
        Me.dgclYOPID.Visible = False
        Me.dgclYOPID.Width = 68
        '
        'dgclYOP
        '
        Me.dgclYOP.DataPropertyName = "YOP"
        Me.dgclYOP.HeaderText = "YOP"
        Me.dgclYOP.Name = "dgclYOP"
        Me.dgclYOP.ReadOnly = True
        Me.dgclYOP.Width = 54
        '
        'dgclName
        '
        Me.dgclName.DataPropertyName = "Name"
        Me.dgclName.HeaderText = "Name"
        Me.dgclName.Name = "dgclName"
        Me.dgclName.ReadOnly = True
        Me.dgclName.Visible = False
        Me.dgclName.Width = 64
        '
        'dgclBlockID
        '
        Me.dgclBlockID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgclBlockID.DataPropertyName = "BlockID"
        Me.dgclBlockID.HeaderText = "FieldNo ID"
        Me.dgclBlockID.Name = "dgclBlockID"
        Me.dgclBlockID.ReadOnly = True
        Me.dgclBlockID.Visible = False
        '
        'dgclBlockName
        '
        Me.dgclBlockName.DataPropertyName = "BlockName"
        Me.dgclBlockName.HeaderText = "FieldNo Name"
        Me.dgclBlockName.Name = "dgclBlockName"
        Me.dgclBlockName.ReadOnly = True
        Me.dgclBlockName.Width = 109
        '
        'dgclPlantedHect
        '
        Me.dgclPlantedHect.DataPropertyName = "PlantedHect"
        Me.dgclPlantedHect.HeaderText = "Planted Hect"
        Me.dgclPlantedHect.Name = "dgclPlantedHect"
        Me.dgclPlantedHect.ReadOnly = True
        Me.dgclPlantedHect.Width = 102
        '
        'dgclBlockStatus
        '
        Me.dgclBlockStatus.DataPropertyName = "BlockStatus"
        Me.dgclBlockStatus.HeaderText = "FieldNo Status"
        Me.dgclBlockStatus.Name = "dgclBlockStatus"
        Me.dgclBlockStatus.ReadOnly = True
        Me.dgclBlockStatus.Width = 112
        '
        'dgcCropID
        '
        Me.dgcCropID.DataPropertyName = "CropID"
        Me.dgcCropID.HeaderText = "CropID"
        Me.dgcCropID.Name = "dgcCropID"
        Me.dgcCropID.ReadOnly = True
        Me.dgcCropID.Width = 73
        '
        'VHMasterSubBlockLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(466, 475)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgSubBlock)
        Me.Controls.Add(Me.panSubBlockLookUp)
        Me.Controls.Add(Me.dgContractNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "VHMasterSubBlockLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Field No Lookup"
        Me.panSubBlockLookUp.ResumeLayout(False)
        Me.panSubBlockLookUp.PerformLayout()
        CType(Me.dgContractNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSubBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents EstateId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSubBlockSearch As System.Windows.Forms.Button
    Friend WithEvents ContractName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDivSearch As System.Windows.Forms.TextBox
    Friend WithEvents panSubBlockLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchSubBlock As System.Windows.Forms.Label
    Friend WithEvents ContractNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgContractNo As System.Windows.Forms.DataGridView
    Friend WithEvents ContractID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgSubBlock As System.Windows.Forms.DataGridView
    Friend WithEvents lblBlockName As System.Windows.Forms.Label
    Friend WithEvents txtBlockNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblDivSearch As System.Windows.Forms.Label
    Friend WithEvents lblYOPSearch As System.Windows.Forms.Label
    Friend WithEvents txtYOPSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents dgclDiv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDivID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDivName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclYOPID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclYOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBlockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBlockName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPlantedHect As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBlockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgcCropID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContractNoLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContractNoLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panContractNoLookUp = New Stepi.UI.ExtendedPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblContNo = New System.Windows.Forms.Label
        Me.lblContName = New System.Windows.Forms.Label
        Me.txtContractNameSearch = New System.Windows.Forms.TextBox
        Me.lblsearchContractNo = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtContractNoSearch = New System.Windows.Forms.TextBox
        Me.btnContractNoSearch = New System.Windows.Forms.Button
        Me.dgContractNo = New System.Windows.Forms.DataGridView
        Me.ContractID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContractNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContractName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContractCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContractCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContractCOADescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContractOldCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlGrid = New System.Windows.Forms.Panel
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.panContractNoLookUp.SuspendLayout()
        CType(Me.dgContractNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'panContractNoLookUp
        '
        Me.panContractNoLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panContractNoLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panContractNoLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panContractNoLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panContractNoLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panContractNoLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panContractNoLookUp.CaptionSize = 40
        Me.panContractNoLookUp.CaptionText = "Select Contract Id"
        Me.panContractNoLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panContractNoLookUp.Controls.Add(Me.Label1)
        Me.panContractNoLookUp.Controls.Add(Me.lblContNo)
        Me.panContractNoLookUp.Controls.Add(Me.lblContName)
        Me.panContractNoLookUp.Controls.Add(Me.txtContractNameSearch)
        Me.panContractNoLookUp.Controls.Add(Me.lblsearchContractNo)
        Me.panContractNoLookUp.Controls.Add(Me.btnClose)
        Me.panContractNoLookUp.Controls.Add(Me.txtContractNoSearch)
        Me.panContractNoLookUp.Controls.Add(Me.btnContractNoSearch)
        Me.panContractNoLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panContractNoLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panContractNoLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panContractNoLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panContractNoLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panContractNoLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panContractNoLookUp.Name = "panContractNoLookUp"
        Me.panContractNoLookUp.Size = New System.Drawing.Size(488, 119)
        Me.panContractNoLookUp.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(151, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = " :"
        '
        'lblContNo
        '
        Me.lblContNo.AutoSize = True
        Me.lblContNo.BackColor = System.Drawing.Color.Transparent
        Me.lblContNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContNo.Location = New System.Drawing.Point(4, 72)
        Me.lblContNo.Name = "lblContNo"
        Me.lblContNo.Size = New System.Drawing.Size(87, 13)
        Me.lblContNo.TabIndex = 106
        Me.lblContNo.Text = "Contract No:"
        '
        'lblContName
        '
        Me.lblContName.AutoSize = True
        Me.lblContName.BackColor = System.Drawing.Color.Transparent
        Me.lblContName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContName.Location = New System.Drawing.Point(181, 72)
        Me.lblContName.Name = "lblContName"
        Me.lblContName.Size = New System.Drawing.Size(107, 13)
        Me.lblContName.TabIndex = 105
        Me.lblContName.Text = "Contract Name:"
        '
        'txtContractNameSearch
        '
        Me.txtContractNameSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtContractNameSearch.Location = New System.Drawing.Point(184, 93)
        Me.txtContractNameSearch.Name = "txtContractNameSearch"
        Me.txtContractNameSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtContractNameSearch.TabIndex = 2
        '
        'lblsearchContractNo
        '
        Me.lblsearchContractNo.AutoSize = True
        Me.lblsearchContractNo.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchContractNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchContractNo.Location = New System.Drawing.Point(1, 44)
        Me.lblsearchContractNo.Name = "lblsearchContractNo"
        Me.lblsearchContractNo.Size = New System.Drawing.Size(150, 13)
        Me.lblsearchContractNo.TabIndex = 54
        Me.lblsearchContractNo.Text = "Search By Contract ID"
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
        Me.btnClose.Location = New System.Drawing.Point(398, 86)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 4
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtContractNoSearch
        '
        Me.txtContractNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtContractNoSearch.Location = New System.Drawing.Point(7, 94)
        Me.txtContractNoSearch.Name = "txtContractNoSearch"
        Me.txtContractNoSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtContractNoSearch.TabIndex = 1
        '
        'btnContractNoSearch
        '
        Me.btnContractNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnContractNoSearch.BackgroundImage = CType(resources.GetObject("btnContractNoSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnContractNoSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnContractNoSearch.FlatAppearance.BorderSize = 0
        Me.btnContractNoSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnContractNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContractNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContractNoSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnContractNoSearch.Location = New System.Drawing.Point(363, 86)
        Me.btnContractNoSearch.Name = "btnContractNoSearch"
        Me.btnContractNoSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnContractNoSearch.TabIndex = 3
        Me.btnContractNoSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnContractNoSearch.UseVisualStyleBackColor = False
        '
        'dgContractNo
        '
        Me.dgContractNo.AllowUserToAddRows = False
        Me.dgContractNo.AllowUserToDeleteRows = False
        Me.dgContractNo.AllowUserToOrderColumns = True
        Me.dgContractNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgContractNo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgContractNo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgContractNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgContractNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContractNo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgContractNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ContractID, Me.ContractNo, Me.ContractName, Me.EstateId, Me.ContractCOAID, Me.ContractCOACode, Me.ContractCOADescp, Me.ContractOldCOACode})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgContractNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgContractNo.EnableHeadersVisualStyles = False
        Me.dgContractNo.GridColor = System.Drawing.Color.Gray
        Me.dgContractNo.Location = New System.Drawing.Point(0, 3)
        Me.dgContractNo.MultiSelect = False
        Me.dgContractNo.Name = "dgContractNo"
        Me.dgContractNo.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContractNo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgContractNo.RowHeadersVisible = False
        Me.dgContractNo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgContractNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgContractNo.Size = New System.Drawing.Size(485, 366)
        Me.dgContractNo.TabIndex = 5
        '
        'ContractID
        '
        Me.ContractID.DataPropertyName = "ContractID"
        Me.ContractID.HeaderText = "Contract ID"
        Me.ContractID.Name = "ContractID"
        Me.ContractID.ReadOnly = True
        Me.ContractID.Visible = False
        Me.ContractID.Width = 98
        '
        'ContractNo
        '
        Me.ContractNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ContractNo.DataPropertyName = "ContractNo"
        Me.ContractNo.HeaderText = "Contract No"
        Me.ContractNo.Name = "ContractNo"
        Me.ContractNo.ReadOnly = True
        Me.ContractNo.Width = 150
        '
        'ContractName
        '
        Me.ContractName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ContractName.DataPropertyName = "ContractName"
        Me.ContractName.HeaderText = "Contract Name"
        Me.ContractName.Name = "ContractName"
        Me.ContractName.ReadOnly = True
        Me.ContractName.Width = 300
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
        'ContractCOAID
        '
        Me.ContractCOAID.DataPropertyName = "COAID"
        Me.ContractCOAID.HeaderText = "ContractCOAID"
        Me.ContractCOAID.Name = "ContractCOAID"
        Me.ContractCOAID.ReadOnly = True
        Me.ContractCOAID.Visible = False
        Me.ContractCOAID.Width = 120
        '
        'ContractCOACode
        '
        Me.ContractCOACode.DataPropertyName = "COACode"
        Me.ContractCOACode.HeaderText = "ContractCOACode"
        Me.ContractCOACode.Name = "ContractCOACode"
        Me.ContractCOACode.ReadOnly = True
        Me.ContractCOACode.Visible = False
        Me.ContractCOACode.Width = 136
        '
        'ContractCOADescp
        '
        Me.ContractCOADescp.DataPropertyName = "COADescp"
        Me.ContractCOADescp.HeaderText = "ContractCOADescp"
        Me.ContractCOADescp.Name = "ContractCOADescp"
        Me.ContractCOADescp.ReadOnly = True
        Me.ContractCOADescp.Visible = False
        Me.ContractCOADescp.Width = 141
        '
        'ContractOldCOACode
        '
        Me.ContractOldCOACode.DataPropertyName = "OldCOACode"
        Me.ContractOldCOACode.HeaderText = "ContractOldCOACode"
        Me.ContractOldCOACode.Name = "ContractOldCOACode"
        Me.ContractOldCOACode.ReadOnly = True
        Me.ContractOldCOACode.Visible = False
        Me.ContractOldCOACode.Width = 155
        '
        'pnlGrid
        '
        Me.pnlGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlGrid.Controls.Add(Me.lblNoRecord)
        Me.pnlGrid.Controls.Add(Me.dgContractNo)
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGrid.Location = New System.Drawing.Point(0, 119)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(488, 372)
        Me.pnlGrid.TabIndex = 14
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(99, 105)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 114
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'ContractNoLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(488, 501)
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.panContractNoLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "ContractNoLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Contract No LookUp"
        Me.panContractNoLookUp.ResumeLayout(False)
        Me.panContractNoLookUp.PerformLayout()
        CType(Me.dgContractNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGrid.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panContractNoLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchContractNo As System.Windows.Forms.Label
    Friend WithEvents txtContractNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgContractNo As System.Windows.Forms.DataGridView
    Friend WithEvents btnContractNoSearch As System.Windows.Forms.Button
    Friend WithEvents lblContNo As System.Windows.Forms.Label
    Friend WithEvents lblContName As System.Windows.Forms.Label
    Friend WithEvents txtContractNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents ContractID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractCOADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractOldCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
End Class

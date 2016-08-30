<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubBlockLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SubBlockLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSubBlockSearch = New System.Windows.Forms.Button
        Me.txtDivSearch = New System.Windows.Forms.TextBox
        Me.panSubBlockLookUp = New Stepi.UI.ExtendedPanel
        Me.lblYOPSearch = New System.Windows.Forms.Label
        Me.txtYOPSearch = New System.Windows.Forms.TextBox
        Me.lblBlockName = New System.Windows.Forms.Label
        Me.txtBlockNameSearch = New System.Windows.Forms.TextBox
        Me.lblDivSearch = New System.Windows.Forms.Label
        Me.lblsearchSubBlock = New System.Windows.Forms.Label
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgSubBlock = New System.Windows.Forms.DataGridView
        Me.dgclBlockName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclDiv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclDivID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclDivName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclYOPID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclYOP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclBlockID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclPlantedHect = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclBlockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.panSubBlockLookUp.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.btnClose.TabIndex = 5
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
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
        Me.btnSubBlockSearch.TabIndex = 4
        Me.btnSubBlockSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSubBlockSearch.UseVisualStyleBackColor = False
        '
        'txtDivSearch
        '
        Me.txtDivSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDivSearch.Location = New System.Drawing.Point(5, 89)
        Me.txtDivSearch.Name = "txtDivSearch"
        Me.txtDivSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtDivSearch.TabIndex = 1
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
        Me.txtYOPSearch.TabIndex = 2
        '
        'lblBlockName
        '
        Me.lblBlockName.AutoSize = True
        Me.lblBlockName.BackColor = System.Drawing.Color.Transparent
        Me.lblBlockName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlockName.Location = New System.Drawing.Point(5, 116)
        Me.lblBlockName.Name = "lblBlockName"
        Me.lblBlockName.Size = New System.Drawing.Size(70, 13)
        Me.lblBlockName.TabIndex = 106
        Me.lblBlockName.Text = "Field No"
        '
        'txtBlockNameSearch
        '
        Me.txtBlockNameSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtBlockNameSearch.Location = New System.Drawing.Point(5, 136)
        Me.txtBlockNameSearch.Name = "txtBlockNameSearch"
        Me.txtBlockNameSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtBlockNameSearch.TabIndex = 3
        '
        'lblDivSearch
        '
        Me.lblDivSearch.AutoSize = True
        Me.lblDivSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblDivSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivSearch.Location = New System.Drawing.Point(5, 69)
        Me.lblDivSearch.Name = "lblDivSearch"
        Me.lblDivSearch.Size = New System.Drawing.Size(28, 13)
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
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(10, 102)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 112
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgSubBlock)
        Me.Panel1.Controls.Add(Me.lblNoRecord)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 161)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(466, 311)
        Me.Panel1.TabIndex = 113
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSubBlock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSubBlock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclBlockName, Me.dgclDiv, Me.dgclDivID, Me.dgclDivName, Me.dgclYOPID, Me.dgclYOP, Me.dgclName, Me.dgclBlockID, Me.dgclPlantedHect, Me.dgclBlockStatus})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSubBlock.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgSubBlock.EnableHeadersVisualStyles = False
        Me.dgSubBlock.GridColor = System.Drawing.Color.Gray
        Me.dgSubBlock.Location = New System.Drawing.Point(0, -2)
        Me.dgSubBlock.MultiSelect = False
        Me.dgSubBlock.Name = "dgSubBlock"
        Me.dgSubBlock.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSubBlock.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgSubBlock.RowHeadersVisible = False
        Me.dgSubBlock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgSubBlock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSubBlock.Size = New System.Drawing.Size(466, 314)
        Me.dgSubBlock.TabIndex = 113
        '
        'dgclBlockName
        '
        Me.dgclBlockName.DataPropertyName = "BlockName"
        Me.dgclBlockName.HeaderText = "FieldNo"
        Me.dgclBlockName.Name = "dgclBlockName"
        Me.dgclBlockName.ReadOnly = True
        Me.dgclBlockName.Width = 84
        '
        'dgclDiv
        '
        Me.dgclDiv.DataPropertyName = "Div"
        Me.dgclDiv.HeaderText = "Afdeling"
        Me.dgclDiv.Name = "dgclDiv"
        Me.dgclDiv.ReadOnly = True
        Me.dgclDiv.Visible = False
        Me.dgclDiv.Width = 50
        '
        'dgclDivID
        '
        Me.dgclDivID.DataPropertyName = "DivID"
        Me.dgclDivID.HeaderText = "Afdeling ID"
        Me.dgclDivID.Name = "dgclDivID"
        Me.dgclDivID.ReadOnly = True
        Me.dgclDivID.Visible = False
        Me.dgclDivID.Width = 64
        '
        'dgclDivName
        '
        Me.dgclDivName.DataPropertyName = "DivName"
        Me.dgclDivName.HeaderText = "Afdeling"
        Me.dgclDivName.Name = "dgclDivName"
        Me.dgclDivName.ReadOnly = True
        Me.dgclDivName.Width = 53
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
        'dgclPlantedHect
        '
        Me.dgclPlantedHect.DataPropertyName = "PlantedHect"
        Me.dgclPlantedHect.HeaderText = "Planted Hect"
        Me.dgclPlantedHect.Name = "dgclPlantedHect"
        Me.dgclPlantedHect.ReadOnly = True
        Me.dgclPlantedHect.Visible = False
        Me.dgclPlantedHect.Width = 102
        '
        'dgclBlockStatus
        '
        Me.dgclBlockStatus.DataPropertyName = "BlockStatus"
        Me.dgclBlockStatus.HeaderText = "FieldNo Status"
        Me.dgclBlockStatus.Name = "dgclBlockStatus"
        Me.dgclBlockStatus.ReadOnly = True
        Me.dgclBlockStatus.Width = 102
        '
        'SubBlockLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(466, 475)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panSubBlockLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "SubBlockLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Field No Lookup"
        Me.panSubBlockLookUp.ResumeLayout(False)
        Me.panSubBlockLookUp.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgSubBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSubBlockSearch As System.Windows.Forms.Button
    Friend WithEvents txtDivSearch As System.Windows.Forms.TextBox
    Friend WithEvents panSubBlockLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents lblsearchSubBlock As System.Windows.Forms.Label
    Friend WithEvents lblBlockName As System.Windows.Forms.Label
    Friend WithEvents txtBlockNameSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblDivSearch As System.Windows.Forms.Label
    Friend WithEvents lblYOPSearch As System.Windows.Forms.Label
    Friend WithEvents txtYOPSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgSubBlock As System.Windows.Forms.DataGridView
    Friend WithEvents dgclBlockName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDiv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDivID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclDivName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclYOPID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclYOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBlockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPlantedHect As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBlockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VHDistributionAccountlookup
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VHDistributionAccountlookup))
        Me.dgAccountcode = New System.Windows.Forms.DataGridView
        Me.AccountID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccountCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccountDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblsearchAcctNo = New System.Windows.Forms.Label
        Me.panAcctLookUp = New Stepi.UI.ExtendedPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAccountDescSearch = New System.Windows.Forms.TextBox
        Me.lblAcctDesc = New System.Windows.Forms.Label
        Me.lblAcctcode = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnAccountcodeSearch = New System.Windows.Forms.Button
        Me.txtAccountCodeSearch = New System.Windows.Forms.TextBox
        CType(Me.dgAccountcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panAcctLookUp.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgAccountcode
        '
        Me.dgAccountcode.AllowUserToAddRows = False
        Me.dgAccountcode.AllowUserToDeleteRows = False
        Me.dgAccountcode.AllowUserToOrderColumns = True
        Me.dgAccountcode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgAccountcode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgAccountcode.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgAccountcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgAccountcode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAccountcode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgAccountcode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AccountID, Me.AccountCode, Me.AccountDescription, Me.EstateID})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAccountcode.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgAccountcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAccountcode.EnableHeadersVisualStyles = False
        Me.dgAccountcode.GridColor = System.Drawing.Color.Gray
        Me.dgAccountcode.Location = New System.Drawing.Point(0, 119)
        Me.dgAccountcode.MultiSelect = False
        Me.dgAccountcode.Name = "dgAccountcode"
        Me.dgAccountcode.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAccountcode.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgAccountcode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgAccountcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAccountcode.Size = New System.Drawing.Size(435, 324)
        Me.dgAccountcode.TabIndex = 15
        '
        'AccountID
        '
        Me.AccountID.DataPropertyName = "COAID"
        Me.AccountID.HeaderText = "Account Id"
        Me.AccountID.Name = "AccountID"
        Me.AccountID.ReadOnly = True
        Me.AccountID.Width = 92
        '
        'AccountCode
        '
        Me.AccountCode.DataPropertyName = "COACode"
        Me.AccountCode.HeaderText = "Account Code"
        Me.AccountCode.Name = "AccountCode"
        Me.AccountCode.ReadOnly = True
        Me.AccountCode.Width = 110
        '
        'AccountDescription
        '
        Me.AccountDescription.DataPropertyName = "COADescp"
        Me.AccountDescription.HeaderText = "Account Description"
        Me.AccountDescription.Name = "AccountDescription"
        Me.AccountDescription.ReadOnly = True
        Me.AccountDescription.Width = 144
        '
        'EstateID
        '
        Me.EstateID.HeaderText = "EstateID"
        Me.EstateID.Name = "EstateID"
        Me.EstateID.ReadOnly = True
        Me.EstateID.Visible = False
        Me.EstateID.Width = 80
        '
        'lblsearchAcctNo
        '
        Me.lblsearchAcctNo.AutoSize = True
        Me.lblsearchAcctNo.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchAcctNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchAcctNo.Location = New System.Drawing.Point(7, 45)
        Me.lblsearchAcctNo.Name = "lblsearchAcctNo"
        Me.lblsearchAcctNo.Size = New System.Drawing.Size(76, 13)
        Me.lblsearchAcctNo.TabIndex = 54
        Me.lblsearchAcctNo.Text = "Search By "
        '
        'panAcctLookUp
        '
        Me.panAcctLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panAcctLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panAcctLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panAcctLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panAcctLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panAcctLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panAcctLookUp.CaptionSize = 40
        Me.panAcctLookUp.CaptionText = "Select Account Code"
        Me.panAcctLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panAcctLookUp.Controls.Add(Me.Label1)
        Me.panAcctLookUp.Controls.Add(Me.txtAccountDescSearch)
        Me.panAcctLookUp.Controls.Add(Me.lblAcctDesc)
        Me.panAcctLookUp.Controls.Add(Me.lblAcctcode)
        Me.panAcctLookUp.Controls.Add(Me.btnClose)
        Me.panAcctLookUp.Controls.Add(Me.lblsearchAcctNo)
        Me.panAcctLookUp.Controls.Add(Me.btnAccountcodeSearch)
        Me.panAcctLookUp.Controls.Add(Me.txtAccountCodeSearch)
        Me.panAcctLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panAcctLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panAcctLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panAcctLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panAcctLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panAcctLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panAcctLookUp.Name = "panAcctLookUp"
        Me.panAcctLookUp.Size = New System.Drawing.Size(435, 119)
        Me.panAcctLookUp.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(85, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = " :"
        '
        'txtAccountDescSearch
        '
        Me.txtAccountDescSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtAccountDescSearch.Location = New System.Drawing.Point(182, 90)
        Me.txtAccountDescSearch.Name = "txtAccountDescSearch"
        Me.txtAccountDescSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtAccountDescSearch.TabIndex = 106
        '
        'lblAcctDesc
        '
        Me.lblAcctDesc.AutoSize = True
        Me.lblAcctDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblAcctDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcctDesc.Location = New System.Drawing.Point(185, 71)
        Me.lblAcctDesc.Name = "lblAcctDesc"
        Me.lblAcctDesc.Size = New System.Drawing.Size(137, 13)
        Me.lblAcctDesc.TabIndex = 105
        Me.lblAcctDesc.Text = "Account Description"
        '
        'lblAcctcode
        '
        Me.lblAcctcode.AutoSize = True
        Me.lblAcctcode.BackColor = System.Drawing.Color.Transparent
        Me.lblAcctcode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcctcode.Location = New System.Drawing.Point(5, 71)
        Me.lblAcctcode.Name = "lblAcctcode"
        Me.lblAcctcode.Size = New System.Drawing.Size(95, 13)
        Me.lblAcctcode.TabIndex = 104
        Me.lblAcctcode.Text = "Account Code"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(396, 83)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnAccountcodeSearch
        '
        Me.btnAccountcodeSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnAccountcodeSearch.BackgroundImage = CType(resources.GetObject("btnAccountcodeSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnAccountcodeSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnAccountcodeSearch.FlatAppearance.BorderSize = 0
        Me.btnAccountcodeSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnAccountcodeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccountcodeSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccountcodeSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAccountcodeSearch.Location = New System.Drawing.Point(361, 83)
        Me.btnAccountcodeSearch.Name = "btnAccountcodeSearch"
        Me.btnAccountcodeSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnAccountcodeSearch.TabIndex = 102
        Me.btnAccountcodeSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAccountcodeSearch.UseVisualStyleBackColor = False
        '
        'txtAccountCodeSearch
        '
        Me.txtAccountCodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtAccountCodeSearch.Location = New System.Drawing.Point(3, 89)
        Me.txtAccountCodeSearch.Name = "txtAccountCodeSearch"
        Me.txtAccountCodeSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtAccountCodeSearch.TabIndex = 101
        '
        'Accountlookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 443)
        Me.Controls.Add(Me.dgAccountcode)
        Me.Controls.Add(Me.panAcctLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Accountlookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Accountlookup"
        CType(Me.dgAccountcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panAcctLookUp.ResumeLayout(False)
        Me.panAcctLookUp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgAccountcode As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchAcctNo As System.Windows.Forms.Label
    Friend WithEvents panAcctLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents btnAccountcodeSearch As System.Windows.Forms.Button
    Friend WithEvents txtAccountCodeSearch As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountDescSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblAcctDesc As System.Windows.Forms.Label
    Friend WithEvents lblAcctcode As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AccountID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

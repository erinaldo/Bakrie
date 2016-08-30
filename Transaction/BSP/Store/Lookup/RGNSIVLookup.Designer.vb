<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RGNSIVLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RGNSIVLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panRGNSIVLookUp = New Stepi.UI.ExtendedPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSIVNoSearch = New System.Windows.Forms.Label
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.txtSIVSearch = New System.Windows.Forms.TextBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSIVSearch = New System.Windows.Forms.Button
        Me.dgSIVNo = New System.Windows.Forms.DataGridView
        Me.SIVNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STIssueId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SIVDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContractID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.panRGNSIVLookUp.SuspendLayout()
        CType(Me.dgSIVNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panRGNSIVLookUp
        '
        Me.panRGNSIVLookUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panRGNSIVLookUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panRGNSIVLookUp.BorderColor = System.Drawing.Color.Gray
        Me.panRGNSIVLookUp.CaptionColorOne = System.Drawing.Color.White
        Me.panRGNSIVLookUp.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panRGNSIVLookUp.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panRGNSIVLookUp.CaptionSize = 40
        Me.panRGNSIVLookUp.CaptionText = "Select SIV"
        Me.panRGNSIVLookUp.CaptionTextColor = System.Drawing.Color.Black
        Me.panRGNSIVLookUp.Controls.Add(Me.Label3)
        Me.panRGNSIVLookUp.Controls.Add(Me.Label1)
        Me.panRGNSIVLookUp.Controls.Add(Me.lblSIVNoSearch)
        Me.panRGNSIVLookUp.Controls.Add(Me.lblSearchBy)
        Me.panRGNSIVLookUp.Controls.Add(Me.txtSIVSearch)
        Me.panRGNSIVLookUp.Controls.Add(Me.btnClose)
        Me.panRGNSIVLookUp.Controls.Add(Me.btnSIVSearch)
        Me.panRGNSIVLookUp.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panRGNSIVLookUp.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panRGNSIVLookUp.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panRGNSIVLookUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.panRGNSIVLookUp.ForeColor = System.Drawing.Color.DimGray
        Me.panRGNSIVLookUp.Location = New System.Drawing.Point(0, 0)
        Me.panRGNSIVLookUp.Name = "panRGNSIVLookUp"
        Me.panRGNSIVLookUp.Size = New System.Drawing.Size(339, 119)
        Me.panRGNSIVLookUp.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(49, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = " :"
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
        'lblSIVNoSearch
        '
        Me.lblSIVNoSearch.AutoSize = True
        Me.lblSIVNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSIVNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVNoSearch.Location = New System.Drawing.Point(3, 77)
        Me.lblSIVNoSearch.Name = "lblSIVNoSearch"
        Me.lblSIVNoSearch.Size = New System.Drawing.Size(50, 13)
        Me.lblSIVNoSearch.TabIndex = 104
        Me.lblSIVNoSearch.Text = "SIV No"
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
        'txtSIVSearch
        '
        Me.txtSIVSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSIVSearch.Location = New System.Drawing.Point(3, 93)
        Me.txtSIVSearch.Name = "txtSIVSearch"
        Me.txtSIVSearch.Size = New System.Drawing.Size(172, 20)
        Me.txtSIVSearch.TabIndex = 1
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
        Me.btnClose.Location = New System.Drawing.Point(223, 89)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 3
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
        Me.btnSIVSearch.Location = New System.Drawing.Point(190, 87)
        Me.btnSIVSearch.Name = "btnSIVSearch"
        Me.btnSIVSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnSIVSearch.TabIndex = 2
        Me.btnSIVSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSIVSearch.UseVisualStyleBackColor = False
        '
        'dgSIVNo
        '
        Me.dgSIVNo.AllowUserToAddRows = False
        Me.dgSIVNo.AllowUserToDeleteRows = False
        Me.dgSIVNo.AllowUserToOrderColumns = True
        Me.dgSIVNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgSIVNo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgSIVNo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgSIVNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgSIVNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSIVNo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSIVNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SIVNo, Me.STIssueId, Me.SIVDate, Me.ContractID, Me.Remarks, Me.Status})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSIVNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgSIVNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSIVNo.EnableHeadersVisualStyles = False
        Me.dgSIVNo.GridColor = System.Drawing.Color.Gray
        Me.dgSIVNo.Location = New System.Drawing.Point(0, 119)
        Me.dgSIVNo.MultiSelect = False
        Me.dgSIVNo.Name = "dgSIVNo"
        Me.dgSIVNo.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSIVNo.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgSIVNo.RowHeadersVisible = False
        Me.dgSIVNo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgSIVNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSIVNo.Size = New System.Drawing.Size(339, 341)
        Me.dgSIVNo.TabIndex = 4
        Me.dgSIVNo.TabStop = False
        '
        'SIVNo
        '
        Me.SIVNo.DataPropertyName = "SIVNo"
        Me.SIVNo.HeaderText = "SIVNo"
        Me.SIVNo.Name = "SIVNo"
        Me.SIVNo.ReadOnly = True
        Me.SIVNo.Width = 67
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
        'SIVDate
        '
        Me.SIVDate.DataPropertyName = "SIVDate"
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.SIVDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.SIVDate.HeaderText = "SIVDate"
        Me.SIVDate.Name = "SIVDate"
        Me.SIVDate.ReadOnly = True
        Me.SIVDate.Width = 79
        '
        'ContractID
        '
        Me.ContractID.DataPropertyName = "ContractID"
        Me.ContractID.HeaderText = "ContractID"
        Me.ContractID.Name = "ContractID"
        Me.ContractID.ReadOnly = True
        Me.ContractID.Visible = False
        Me.ContractID.Width = 94
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        Me.Remarks.Visible = False
        Me.Remarks.Width = 82
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 67
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(92, 216)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 110
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'RGNSIVLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(339, 460)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgSIVNo)
        Me.Controls.Add(Me.panRGNSIVLookUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "RGNSIVLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RTS SIV Lookup"
        Me.panRGNSIVLookUp.ResumeLayout(False)
        Me.panRGNSIVLookUp.PerformLayout()
        CType(Me.dgSIVNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panRGNSIVLookUp As Stepi.UI.ExtendedPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSIVNoSearch As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents btnSIVSearch As System.Windows.Forms.Button
    Friend WithEvents txtSIVSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgSIVNo As System.Windows.Forms.DataGridView
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents SIVNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STIssueId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIVDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

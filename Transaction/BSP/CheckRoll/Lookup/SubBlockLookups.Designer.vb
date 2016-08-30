<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubBlockLookups
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SubBlockLookups))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.pnlCategorySearch = New Stepi.UI.ExtendedPanel
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSubBlockName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCategoryDesc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblsearchCategory = New System.Windows.Forms.Label
        Me.txtCategoryCode = New System.Windows.Forms.TextBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnVehicleSearch = New System.Windows.Forms.Button
        Me.dgvSubBlock = New System.Windows.Forms.DataGridView
        Me.bmColumnDivName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bmColumnDivID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bmColumnYOP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bmColumnYOPID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bmColumnBlockName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bmColumnBlockID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bmColumnBlockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bmColumnEstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bmColumnEstateName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlCategorySearch.SuspendLayout()
        CType(Me.dgvSubBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(132, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "YOP"
        '
        'pnlCategorySearch
        '
        Me.pnlCategorySearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlCategorySearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCategorySearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlCategorySearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlCategorySearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlCategorySearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCategorySearch.CaptionSize = 40
        Me.pnlCategorySearch.CaptionText = "Search Field No"
        Me.pnlCategorySearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlCategorySearch.Controls.Add(Me.Label5)
        Me.pnlCategorySearch.Controls.Add(Me.txtSubBlockName)
        Me.pnlCategorySearch.Controls.Add(Me.Label6)
        Me.pnlCategorySearch.Controls.Add(Me.Label3)
        Me.pnlCategorySearch.Controls.Add(Me.Label2)
        Me.pnlCategorySearch.Controls.Add(Me.Label1)
        Me.pnlCategorySearch.Controls.Add(Me.txtCategoryDesc)
        Me.pnlCategorySearch.Controls.Add(Me.Label4)
        Me.pnlCategorySearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlCategorySearch.Controls.Add(Me.txtCategoryCode)
        Me.pnlCategorySearch.Controls.Add(Me.btnClose)
        Me.pnlCategorySearch.Controls.Add(Me.btnVehicleSearch)
        Me.pnlCategorySearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlCategorySearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlCategorySearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlCategorySearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCategorySearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlCategorySearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategorySearch.Name = "pnlCategorySearch"
        Me.pnlCategorySearch.Size = New System.Drawing.Size(514, 154)
        Me.pnlCategorySearch.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "Field No"
        '
        'txtSubBlockName
        '
        Me.txtSubBlockName.Location = New System.Drawing.Point(144, 116)
        Me.txtSubBlockName.Name = "txtSubBlockName"
        Me.txtSubBlockName.Size = New System.Drawing.Size(172, 20)
        Me.txtSubBlockName.TabIndex = 109
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(131, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Afdeling"
        '
        'txtCategoryDesc
        '
        Me.txtCategoryDesc.Enabled = False
        Me.txtCategoryDesc.Location = New System.Drawing.Point(144, 90)
        Me.txtCategoryDesc.Name = "txtCategoryDesc"
        Me.txtCategoryDesc.Size = New System.Drawing.Size(172, 20)
        Me.txtCategoryDesc.TabIndex = 104
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(131, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = ":"
        '
        'lblsearchCategory
        '
        Me.lblsearchCategory.AutoSize = True
        Me.lblsearchCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchCategory.Location = New System.Drawing.Point(1, 41)
        Me.lblsearchCategory.Name = "lblsearchCategory"
        Me.lblsearchCategory.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchCategory.TabIndex = 54
        Me.lblsearchCategory.Text = "Search By"
        '
        'txtCategoryCode
        '
        Me.txtCategoryCode.Enabled = False
        Me.txtCategoryCode.Location = New System.Drawing.Point(144, 63)
        Me.txtCategoryCode.Name = "txtCategoryCode"
        Me.txtCategoryCode.Size = New System.Drawing.Size(172, 20)
        Me.txtCategoryCode.TabIndex = 101
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
        Me.btnClose.Location = New System.Drawing.Point(468, 113)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 103
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
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
        Me.btnVehicleSearch.Location = New System.Drawing.Point(435, 116)
        Me.btnVehicleSearch.Name = "btnVehicleSearch"
        Me.btnVehicleSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnVehicleSearch.TabIndex = 102
        Me.btnVehicleSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVehicleSearch.UseVisualStyleBackColor = False
        '
        'dgvSubBlock
        '
        Me.dgvSubBlock.AllowUserToAddRows = False
        Me.dgvSubBlock.AllowUserToDeleteRows = False
        Me.dgvSubBlock.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvSubBlock.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSubBlock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSubBlock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSubBlock.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSubBlock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSubBlock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSubBlock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSubBlock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bmColumnDivName, Me.bmColumnDivID, Me.bmColumnYOP, Me.bmColumnYOPID, Me.bmColumnBlockName, Me.bmColumnBlockID, Me.bmColumnBlockStatus, Me.bmColumnEstateID, Me.bmColumnEstateName})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSubBlock.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSubBlock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSubBlock.EnableHeadersVisualStyles = False
        Me.dgvSubBlock.GridColor = System.Drawing.Color.Gray
        Me.dgvSubBlock.Location = New System.Drawing.Point(0, 154)
        Me.dgvSubBlock.MultiSelect = False
        Me.dgvSubBlock.Name = "dgvSubBlock"
        Me.dgvSubBlock.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSubBlock.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSubBlock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvSubBlock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSubBlock.Size = New System.Drawing.Size(514, 343)
        Me.dgvSubBlock.TabIndex = 0
        '
        'bmColumnDivName
        '
        Me.bmColumnDivName.DataPropertyName = "DIVName"
        Me.bmColumnDivName.HeaderText = "Afdeling"
        Me.bmColumnDivName.Name = "bmColumnDivName"
        Me.bmColumnDivName.ReadOnly = True
        Me.bmColumnDivName.Width = 53
        '
        'bmColumnDivID
        '
        Me.bmColumnDivID.DataPropertyName = "DivID"
        Me.bmColumnDivID.HeaderText = "Afdeling ID"
        Me.bmColumnDivID.Name = "bmColumnDivID"
        Me.bmColumnDivID.ReadOnly = True
        Me.bmColumnDivID.Visible = False
        Me.bmColumnDivID.Width = 64
        '
        'bmColumnYOP
        '
        Me.bmColumnYOP.DataPropertyName = "YOP"
        Me.bmColumnYOP.HeaderText = "YOP"
        Me.bmColumnYOP.Name = "bmColumnYOP"
        Me.bmColumnYOP.ReadOnly = True
        Me.bmColumnYOP.Width = 54
        '
        'bmColumnYOPID
        '
        Me.bmColumnYOPID.DataPropertyName = "YOPID"
        Me.bmColumnYOPID.HeaderText = "YOPID"
        Me.bmColumnYOPID.Name = "bmColumnYOPID"
        Me.bmColumnYOPID.ReadOnly = True
        Me.bmColumnYOPID.Visible = False
        Me.bmColumnYOPID.Width = 68
        '
        'bmColumnBlockName
        '
        Me.bmColumnBlockName.DataPropertyName = "BlockName"
        Me.bmColumnBlockName.HeaderText = "FieldNo Name"
        Me.bmColumnBlockName.Name = "bmColumnBlockName"
        Me.bmColumnBlockName.ReadOnly = True
        Me.bmColumnBlockName.Width = 99
        '
        'bmColumnBlockID
        '
        Me.bmColumnBlockID.DataPropertyName = "BlockID"
        Me.bmColumnBlockID.HeaderText = "FieldNoID"
        Me.bmColumnBlockID.Name = "bmColumnBlockID"
        Me.bmColumnBlockID.ReadOnly = True
        Me.bmColumnBlockID.Visible = False
        Me.bmColumnBlockID.Width = 76
        '
        'bmColumnBlockStatus
        '
        Me.bmColumnBlockStatus.DataPropertyName = "BlockStatus"
        Me.bmColumnBlockStatus.HeaderText = "FieldNo Status"
        Me.bmColumnBlockStatus.Name = "bmColumnBlockStatus"
        Me.bmColumnBlockStatus.ReadOnly = True
        Me.bmColumnBlockStatus.Width = 102
        '
        'bmColumnEstateID
        '
        Me.bmColumnEstateID.DataPropertyName = "EstateID"
        Me.bmColumnEstateID.HeaderText = "EstateID"
        Me.bmColumnEstateID.Name = "bmColumnEstateID"
        Me.bmColumnEstateID.ReadOnly = True
        Me.bmColumnEstateID.Visible = False
        Me.bmColumnEstateID.Width = 80
        '
        'bmColumnEstateName
        '
        Me.bmColumnEstateName.DataPropertyName = "EstateName"
        Me.bmColumnEstateName.HeaderText = "EstateName"
        Me.bmColumnEstateName.Name = "bmColumnEstateName"
        Me.bmColumnEstateName.ReadOnly = True
        Me.bmColumnEstateName.Visible = False
        Me.bmColumnEstateName.Width = 99
        '
        'SubBlockLookups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 497)
        Me.Controls.Add(Me.dgvSubBlock)
        Me.Controls.Add(Me.pnlCategorySearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SubBlockLookups"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TopMost = True
        Me.pnlCategorySearch.ResumeLayout(False)
        Me.pnlCategorySearch.PerformLayout()
        CType(Me.dgvSubBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlCategorySearch As Stepi.UI.ExtendedPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCategoryDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnVehicleSearch As System.Windows.Forms.Button
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents txtCategoryCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSubBlockName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvSubBlock As System.Windows.Forms.DataGridView
    Friend WithEvents bmColumnDivName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bmColumnDivID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bmColumnYOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bmColumnYOPID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bmColumnBlockName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bmColumnBlockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bmColumnBlockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bmColumnEstateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bmColumnEstateName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

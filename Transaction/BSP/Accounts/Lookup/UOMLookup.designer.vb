<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UOMLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UOMLookup))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panUOMLookup = New Stepi.UI.ExtendedPanel
        Me.lblWBTicketSearch = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblsearchDiv = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtUOMSearch = New System.Windows.Forms.TextBox
        Me.dgUOM = New System.Windows.Forms.DataGridView
        Me.dgUOMID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgUnit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgDescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.panUOMLookup.SuspendLayout()
        CType(Me.dgUOM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panUOMLookup
        '
        Me.panUOMLookup.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panUOMLookup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panUOMLookup.BorderColor = System.Drawing.Color.Gray
        Me.panUOMLookup.CaptionColorOne = System.Drawing.Color.White
        Me.panUOMLookup.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panUOMLookup.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panUOMLookup.CaptionSize = 40
        Me.panUOMLookup.CaptionText = "Select UOM"
        Me.panUOMLookup.CaptionTextColor = System.Drawing.Color.Black
        Me.panUOMLookup.Controls.Add(Me.lblWBTicketSearch)
        Me.panUOMLookup.Controls.Add(Me.btnClose)
        Me.panUOMLookup.Controls.Add(Me.lblsearchDiv)
        Me.panUOMLookup.Controls.Add(Me.btnSearch)
        Me.panUOMLookup.Controls.Add(Me.txtUOMSearch)
        Me.panUOMLookup.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panUOMLookup.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panUOMLookup.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panUOMLookup.Dock = System.Windows.Forms.DockStyle.Top
        Me.panUOMLookup.ForeColor = System.Drawing.Color.DimGray
        Me.panUOMLookup.Location = New System.Drawing.Point(0, 0)
        Me.panUOMLookup.Name = "panUOMLookup"
        Me.panUOMLookup.Size = New System.Drawing.Size(421, 119)
        Me.panUOMLookup.TabIndex = 19
        '
        'lblWBTicketSearch
        '
        Me.lblWBTicketSearch.AutoSize = True
        Me.lblWBTicketSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblWBTicketSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWBTicketSearch.Location = New System.Drawing.Point(3, 77)
        Me.lblWBTicketSearch.Name = "lblWBTicketSearch"
        Me.lblWBTicketSearch.Size = New System.Drawing.Size(43, 13)
        Me.lblWBTicketSearch.TabIndex = 104
        Me.lblWBTicketSearch.Text = "UOM :"
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
        Me.btnClose.Location = New System.Drawing.Point(214, 87)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 2
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblsearchDiv
        '
        Me.lblsearchDiv.AutoSize = True
        Me.lblsearchDiv.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchDiv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchDiv.Location = New System.Drawing.Point(4, 52)
        Me.lblsearchDiv.Name = "lblsearchDiv"
        Me.lblsearchDiv.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchDiv.TabIndex = 54
        Me.lblsearchDiv.Text = "Search By"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(188, 87)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtUOMSearch
        '
        Me.txtUOMSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtUOMSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUOMSearch.Location = New System.Drawing.Point(3, 93)
        Me.txtUOMSearch.Name = "txtUOMSearch"
        Me.txtUOMSearch.Size = New System.Drawing.Size(172, 21)
        Me.txtUOMSearch.TabIndex = 0
        '
        'dgUOM
        '
        Me.dgUOM.AllowUserToAddRows = False
        Me.dgUOM.AllowUserToDeleteRows = False
        Me.dgUOM.AllowUserToOrderColumns = True
        Me.dgUOM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgUOM.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgUOM.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgUOM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgUOM.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUOM.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgUOM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgUOMID, Me.dgUnit, Me.dgDescp})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgUOM.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgUOM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgUOM.EnableHeadersVisualStyles = False
        Me.dgUOM.GridColor = System.Drawing.Color.Gray
        Me.dgUOM.Location = New System.Drawing.Point(0, 119)
        Me.dgUOM.MultiSelect = False
        Me.dgUOM.Name = "dgUOM"
        Me.dgUOM.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUOM.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgUOM.RowHeadersVisible = False
        Me.dgUOM.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgUOM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgUOM.Size = New System.Drawing.Size(421, 348)
        Me.dgUOM.TabIndex = 3
        '
        'dgUOMID
        '
        Me.dgUOMID.DataPropertyName = "UOMID"
        Me.dgUOMID.HeaderText = "UOMID"
        Me.dgUOMID.Name = "dgUOMID"
        Me.dgUOMID.ReadOnly = True
        Me.dgUOMID.Visible = False
        Me.dgUOMID.Width = 71
        '
        'dgUnit
        '
        Me.dgUnit.DataPropertyName = "UOM"
        Me.dgUnit.HeaderText = "UOM"
        Me.dgUnit.Name = "dgUnit"
        Me.dgUnit.ReadOnly = True
        Me.dgUnit.Width = 57
        '
        'dgDescp
        '
        Me.dgDescp.DataPropertyName = "Description"
        Me.dgDescp.HeaderText = "Description"
        Me.dgDescp.Name = "dgDescp"
        Me.dgDescp.ReadOnly = True
        Me.dgDescp.Width = 95
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(108, 234)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 114
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'UOMLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(421, 467)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgUOM)
        Me.Controls.Add(Me.panUOMLookup)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "UOMLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WBTicket  Lookup"
        Me.panUOMLookup.ResumeLayout(False)
        Me.panUOMLookup.PerformLayout()
        CType(Me.dgUOM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panUOMLookup As Stepi.UI.ExtendedPanel
    Friend WithEvents lblWBTicketSearch As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchDiv As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtUOMSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgUOM As System.Windows.Forms.DataGridView
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents dgUOMID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgDescp As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

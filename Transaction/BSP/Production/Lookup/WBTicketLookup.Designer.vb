<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WBTicketLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WBTicketLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panWBTicketLookup = New Stepi.UI.ExtendedPanel
        Me.lblWBTicketSearch = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblsearchDiv = New System.Windows.Forms.Label
        Me.btnWBTicketNoSearch = New System.Windows.Forms.Button
        Me.txtWBTicketNoSearch = New System.Windows.Forms.TextBox
        Me.dgWBTicketNo = New System.Windows.Forms.DataGridView
        Me.dgWeighingID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgWBTicket = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.panWBTicketLookup.SuspendLayout()
        CType(Me.dgWBTicketNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panWBTicketLookup
        '
        Me.panWBTicketLookup.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panWBTicketLookup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panWBTicketLookup.BorderColor = System.Drawing.Color.Gray
        Me.panWBTicketLookup.CaptionColorOne = System.Drawing.Color.White
        Me.panWBTicketLookup.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.panWBTicketLookup.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panWBTicketLookup.CaptionSize = 40
        Me.panWBTicketLookup.CaptionText = "Select WB Ticket No"
        Me.panWBTicketLookup.CaptionTextColor = System.Drawing.Color.Black
        Me.panWBTicketLookup.Controls.Add(Me.lblWBTicketSearch)
        Me.panWBTicketLookup.Controls.Add(Me.btnClose)
        Me.panWBTicketLookup.Controls.Add(Me.lblsearchDiv)
        Me.panWBTicketLookup.Controls.Add(Me.btnWBTicketNoSearch)
        Me.panWBTicketLookup.Controls.Add(Me.txtWBTicketNoSearch)
        Me.panWBTicketLookup.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.panWBTicketLookup.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.panWBTicketLookup.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.panWBTicketLookup.Dock = System.Windows.Forms.DockStyle.Top
        Me.panWBTicketLookup.ForeColor = System.Drawing.Color.DimGray
        Me.panWBTicketLookup.Location = New System.Drawing.Point(0, 0)
        Me.panWBTicketLookup.Name = "panWBTicketLookup"
        Me.panWBTicketLookup.Size = New System.Drawing.Size(421, 119)
        Me.panWBTicketLookup.TabIndex = 19
        '
        'lblWBTicketSearch
        '
        Me.lblWBTicketSearch.AutoSize = True
        Me.lblWBTicketSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblWBTicketSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWBTicketSearch.Location = New System.Drawing.Point(3, 77)
        Me.lblWBTicketSearch.Name = "lblWBTicketSearch"
        Me.lblWBTicketSearch.Size = New System.Drawing.Size(100, 13)
        Me.lblWBTicketSearch.TabIndex = 104
        Me.lblWBTicketSearch.Text = "WB Ticket No :"
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
        'btnWBTicketNoSearch
        '
        Me.btnWBTicketNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnWBTicketNoSearch.BackgroundImage = CType(resources.GetObject("btnWBTicketNoSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnWBTicketNoSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnWBTicketNoSearch.FlatAppearance.BorderSize = 0
        Me.btnWBTicketNoSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnWBTicketNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWBTicketNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWBTicketNoSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnWBTicketNoSearch.Location = New System.Drawing.Point(188, 87)
        Me.btnWBTicketNoSearch.Name = "btnWBTicketNoSearch"
        Me.btnWBTicketNoSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnWBTicketNoSearch.TabIndex = 1
        Me.btnWBTicketNoSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnWBTicketNoSearch.UseVisualStyleBackColor = False
        '
        'txtWBTicketNoSearch
        '
        Me.txtWBTicketNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtWBTicketNoSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWBTicketNoSearch.Location = New System.Drawing.Point(3, 93)
        Me.txtWBTicketNoSearch.Name = "txtWBTicketNoSearch"
        Me.txtWBTicketNoSearch.Size = New System.Drawing.Size(172, 21)
        Me.txtWBTicketNoSearch.TabIndex = 0
        '
        'dgWBTicketNo
        '
        Me.dgWBTicketNo.AllowUserToAddRows = False
        Me.dgWBTicketNo.AllowUserToDeleteRows = False
        Me.dgWBTicketNo.AllowUserToOrderColumns = True
        Me.dgWBTicketNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgWBTicketNo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgWBTicketNo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgWBTicketNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgWBTicketNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgWBTicketNo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgWBTicketNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgWeighingID, Me.dgWBTicket})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgWBTicketNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgWBTicketNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgWBTicketNo.EnableHeadersVisualStyles = False
        Me.dgWBTicketNo.GridColor = System.Drawing.Color.Gray
        Me.dgWBTicketNo.Location = New System.Drawing.Point(0, 119)
        Me.dgWBTicketNo.MultiSelect = False
        Me.dgWBTicketNo.Name = "dgWBTicketNo"
        Me.dgWBTicketNo.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgWBTicketNo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgWBTicketNo.RowHeadersVisible = False
        Me.dgWBTicketNo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgWBTicketNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgWBTicketNo.Size = New System.Drawing.Size(421, 348)
        Me.dgWBTicketNo.TabIndex = 3
        '
        'dgWeighingID
        '
        Me.dgWeighingID.DataPropertyName = "WeighingID"
        Me.dgWeighingID.HeaderText = "WeighingID"
        Me.dgWeighingID.Name = "dgWeighingID"
        Me.dgWeighingID.ReadOnly = True
        Me.dgWeighingID.Visible = False
        Me.dgWeighingID.Width = 97
        '
        'dgWBTicket
        '
        Me.dgWBTicket.DataPropertyName = "WBTicketNo"
        Me.dgWBTicket.HeaderText = "WB Ticket No"
        Me.dgWBTicket.Name = "dgWBTicket"
        Me.dgWBTicket.ReadOnly = True
        Me.dgWBTicket.Width = 107
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
        'WBTicketLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(421, 467)
        Me.Controls.Add(Me.lblNoRecord)
        Me.Controls.Add(Me.dgWBTicketNo)
        Me.Controls.Add(Me.panWBTicketLookup)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "WBTicketLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WBTicket  Lookup"
        Me.panWBTicketLookup.ResumeLayout(False)
        Me.panWBTicketLookup.PerformLayout()
        CType(Me.dgWBTicketNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panWBTicketLookup As Stepi.UI.ExtendedPanel
    Friend WithEvents lblWBTicketSearch As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblsearchDiv As System.Windows.Forms.Label
    Friend WithEvents btnWBTicketNoSearch As System.Windows.Forms.Button
    Friend WithEvents txtWBTicketNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgWBTicketNo As System.Windows.Forms.DataGridView
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents dgWeighingID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgWBTicket As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SenderReceiverLocLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SenderReceiverLocLookup))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlSenderLocSearch = New Stepi.UI.ExtendedPanel
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblSenderlocation = New System.Windows.Forms.Label
        Me.lblSearchby = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnSenderLocSearch = New System.Windows.Forms.Button
        Me.txtSenderLocsearch = New System.Windows.Forms.TextBox
        Me.dgvSenderLocation = New System.Windows.Forms.DataGridView
        Me.dgclLocation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplierLocationID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSupplierCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclT0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclT1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclT2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclT3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclT4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlSenderLocSearch.SuspendLayout()
        CType(Me.dgvSenderLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSenderLocSearch
        '
        Me.pnlSenderLocSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSenderLocSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSenderLocSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlSenderLocSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlSenderLocSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSenderLocSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSenderLocSearch.CaptionSize = 40
        Me.pnlSenderLocSearch.CaptionText = "Search  Location"
        Me.pnlSenderLocSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSenderLocSearch.Controls.Add(Me.btnClose)
        Me.pnlSenderLocSearch.Controls.Add(Me.lblSenderlocation)
        Me.pnlSenderLocSearch.Controls.Add(Me.lblSearchby)
        Me.pnlSenderLocSearch.Controls.Add(Me.Label4)
        Me.pnlSenderLocSearch.Controls.Add(Me.btnSenderLocSearch)
        Me.pnlSenderLocSearch.Controls.Add(Me.txtSenderLocsearch)
        Me.pnlSenderLocSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSenderLocSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSenderLocSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSenderLocSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSenderLocSearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlSenderLocSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlSenderLocSearch.Name = "pnlSenderLocSearch"
        Me.pnlSenderLocSearch.Size = New System.Drawing.Size(402, 119)
        Me.pnlSenderLocSearch.TabIndex = 14
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
        Me.btnClose.Location = New System.Drawing.Point(367, 83)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 27)
        Me.btnClose.TabIndex = 3
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblSenderlocation
        '
        Me.lblSenderlocation.AutoSize = True
        Me.lblSenderlocation.BackColor = System.Drawing.Color.Transparent
        Me.lblSenderlocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSenderlocation.Location = New System.Drawing.Point(21, 65)
        Me.lblSenderlocation.Name = "lblSenderlocation"
        Me.lblSenderlocation.Size = New System.Drawing.Size(62, 13)
        Me.lblSenderlocation.TabIndex = 64
        Me.lblSenderlocation.Text = "Location"
        '
        'lblSearchby
        '
        Me.lblSearchby.AutoSize = True
        Me.lblSearchby.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchby.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchby.Location = New System.Drawing.Point(4, 42)
        Me.lblSearchby.Name = "lblSearchby"
        Me.lblSearchby.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchby.TabIndex = 54
        Me.lblSearchby.Text = "Search By"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(142, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = ":"
        '
        'btnSenderLocSearch
        '
        Me.btnSenderLocSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSenderLocSearch.BackgroundImage = CType(resources.GetObject("btnSenderLocSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSenderLocSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnSenderLocSearch.FlatAppearance.BorderSize = 0
        Me.btnSenderLocSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnSenderLocSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSenderLocSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSenderLocSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSenderLocSearch.Location = New System.Drawing.Point(332, 83)
        Me.btnSenderLocSearch.Name = "btnSenderLocSearch"
        Me.btnSenderLocSearch.Size = New System.Drawing.Size(27, 30)
        Me.btnSenderLocSearch.TabIndex = 2
        Me.btnSenderLocSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSenderLocSearch.UseVisualStyleBackColor = False
        '
        'txtSenderLocsearch
        '
        Me.txtSenderLocsearch.Location = New System.Drawing.Point(154, 63)
        Me.txtSenderLocsearch.Name = "txtSenderLocsearch"
        Me.txtSenderLocsearch.Size = New System.Drawing.Size(172, 20)
        Me.txtSenderLocsearch.TabIndex = 1
        '
        'dgvSenderLocation
        '
        Me.dgvSenderLocation.AllowUserToAddRows = False
        Me.dgvSenderLocation.AllowUserToDeleteRows = False
        Me.dgvSenderLocation.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSenderLocation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSenderLocation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSenderLocation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSenderLocation.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSenderLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSenderLocation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSenderLocation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSenderLocation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclLocation, Me.dgclSupplierLocationID, Me.dgclSupplierCOAID, Me.dgclT0, Me.dgclT1, Me.dgclT2, Me.dgclT3, Me.dgclT4})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSenderLocation.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSenderLocation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSenderLocation.EnableHeadersVisualStyles = False
        Me.dgvSenderLocation.GridColor = System.Drawing.Color.Gray
        Me.dgvSenderLocation.Location = New System.Drawing.Point(0, 119)
        Me.dgvSenderLocation.MultiSelect = False
        Me.dgvSenderLocation.Name = "dgvSenderLocation"
        Me.dgvSenderLocation.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSenderLocation.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSenderLocation.RowHeadersVisible = False
        Me.dgvSenderLocation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvSenderLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSenderLocation.Size = New System.Drawing.Size(402, 262)
        Me.dgvSenderLocation.TabIndex = 4
        Me.dgvSenderLocation.TabStop = False
        '
        'dgclLocation
        '
        Me.dgclLocation.DataPropertyName = "DistributionDescp"
        Me.dgclLocation.HeaderText = "Location"
        Me.dgclLocation.Name = "dgclLocation"
        Me.dgclLocation.ReadOnly = True
        Me.dgclLocation.Width = 78
        '
        'dgclSupplierLocationID
        '
        Me.dgclSupplierLocationID.DataPropertyName = "DistributionSetupID"
        Me.dgclSupplierLocationID.HeaderText = "LocationID"
        Me.dgclSupplierLocationID.Name = "dgclSupplierLocationID"
        Me.dgclSupplierLocationID.ReadOnly = True
        Me.dgclSupplierLocationID.Visible = False
        Me.dgclSupplierLocationID.Width = 92
        '
        'dgclSupplierCOAID
        '
        Me.dgclSupplierCOAID.DataPropertyName = "SupplierCOAID"
        Me.dgclSupplierCOAID.HeaderText = "SupplierCOAID"
        Me.dgclSupplierCOAID.Name = "dgclSupplierCOAID"
        Me.dgclSupplierCOAID.ReadOnly = True
        Me.dgclSupplierCOAID.Visible = False
        Me.dgclSupplierCOAID.Width = 118
        '
        'dgclT0
        '
        Me.dgclT0.DataPropertyName = "T0"
        Me.dgclT0.HeaderText = "T0"
        Me.dgclT0.Name = "dgclT0"
        Me.dgclT0.ReadOnly = True
        Me.dgclT0.Visible = False
        Me.dgclT0.Width = 45
        '
        'dgclT1
        '
        Me.dgclT1.DataPropertyName = "T1"
        Me.dgclT1.HeaderText = "T1"
        Me.dgclT1.Name = "dgclT1"
        Me.dgclT1.ReadOnly = True
        Me.dgclT1.Visible = False
        Me.dgclT1.Width = 45
        '
        'dgclT2
        '
        Me.dgclT2.DataPropertyName = "T2"
        Me.dgclT2.HeaderText = "T2"
        Me.dgclT2.Name = "dgclT2"
        Me.dgclT2.ReadOnly = True
        Me.dgclT2.Visible = False
        Me.dgclT2.Width = 45
        '
        'dgclT3
        '
        Me.dgclT3.DataPropertyName = "T3"
        Me.dgclT3.HeaderText = "T3"
        Me.dgclT3.Name = "dgclT3"
        Me.dgclT3.ReadOnly = True
        Me.dgclT3.Visible = False
        Me.dgclT3.Width = 45
        '
        'dgclT4
        '
        Me.dgclT4.DataPropertyName = "T4"
        Me.dgclT4.HeaderText = "T4"
        Me.dgclT4.Name = "dgclT4"
        Me.dgclT4.ReadOnly = True
        Me.dgclT4.Visible = False
        Me.dgclT4.Width = 45
        '
        'SenderReceiverLocLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(402, 381)
        Me.Controls.Add(Me.dgvSenderLocation)
        Me.Controls.Add(Me.pnlSenderLocSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "SenderReceiverLocLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sender Receiver Lookup"
        Me.pnlSenderLocSearch.ResumeLayout(False)
        Me.pnlSenderLocSearch.PerformLayout()
        CType(Me.dgvSenderLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSenderLocSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblSenderlocation As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSearchby As System.Windows.Forms.Label
    Friend WithEvents btnSenderLocSearch As System.Windows.Forms.Button
    Friend WithEvents txtSenderLocsearch As System.Windows.Forms.TextBox
    Friend WithEvents dgvSenderLocation As System.Windows.Forms.DataGridView
    Friend WithEvents dgclLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierLocationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSupplierCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclT4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

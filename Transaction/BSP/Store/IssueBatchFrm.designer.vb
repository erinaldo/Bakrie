<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IssueBatchFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IssueBatchFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblSIVNO = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.plIB1 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgIssueBatchDetails = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnResetIB = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSIVNO = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.dgclDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclSIVNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgclBatchID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.plIB1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgIssueBatchDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Red
        Me.lblDate.Location = New System.Drawing.Point(27, 15)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(34, 13)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Date"
        '
        'lblSIVNO
        '
        Me.lblSIVNO.AutoSize = True
        Me.lblSIVNO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVNO.ForeColor = System.Drawing.Color.Red
        Me.lblSIVNO.Location = New System.Drawing.Point(27, 43)
        Me.lblSIVNO.Name = "lblSIVNO"
        Me.lblSIVNO.Size = New System.Drawing.Size(47, 13)
        Me.lblSIVNO.TabIndex = 1
        Me.lblSIVNO.Text = "SIV No"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Red
        Me.lblTotal.Location = New System.Drawing.Point(27, 73)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(35, 13)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.Text = "Total"
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(126, 14)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 25)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(344, 14)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 25)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(170, 11)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(135, 20)
        Me.dtpDate.TabIndex = 1
        '
        'plIB1
        '
        Me.plIB1.BackColor = System.Drawing.Color.Transparent
        Me.plIB1.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.plIB1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plIB1.Controls.Add(Me.Panel1)
        Me.plIB1.Controls.Add(Me.GroupBox2)
        Me.plIB1.Controls.Add(Me.GroupBox1)
        Me.plIB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plIB1.Location = New System.Drawing.Point(0, 0)
        Me.plIB1.Name = "plIB1"
        Me.plIB1.Size = New System.Drawing.Size(486, 462)
        Me.plIB1.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgIssueBatchDetails)
        Me.Panel1.Location = New System.Drawing.Point(26, 169)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(448, 274)
        Me.Panel1.TabIndex = 14
        '
        'dgIssueBatchDetails
        '
        Me.dgIssueBatchDetails.AllowUserToAddRows = False
        Me.dgIssueBatchDetails.AllowUserToDeleteRows = False
        Me.dgIssueBatchDetails.AllowUserToOrderColumns = True
        Me.dgIssueBatchDetails.AllowUserToResizeColumns = False
        Me.dgIssueBatchDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgIssueBatchDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgIssueBatchDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgIssueBatchDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgIssueBatchDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgIssueBatchDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgIssueBatchDetails.ColumnHeadersHeight = 30
        Me.dgIssueBatchDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclDate, Me.dgclSIVNo, Me.dgclTotal, Me.dgclBatchID})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgIssueBatchDetails.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgIssueBatchDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgIssueBatchDetails.EnableHeadersVisualStyles = False
        Me.dgIssueBatchDetails.GridColor = System.Drawing.Color.Gray
        Me.dgIssueBatchDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgIssueBatchDetails.MultiSelect = False
        Me.dgIssueBatchDetails.Name = "dgIssueBatchDetails"
        Me.dgIssueBatchDetails.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgIssueBatchDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgIssueBatchDetails.RowHeadersVisible = False
        Me.dgIssueBatchDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgIssueBatchDetails.Size = New System.Drawing.Size(448, 268)
        Me.dgIssueBatchDetails.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnResetIB)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Controls.Add(Me.btnClose)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(448, 45)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'btnResetIB
        '
        Me.btnResetIB.BackgroundImage = CType(resources.GetObject("btnResetIB.BackgroundImage"), System.Drawing.Image)
        Me.btnResetIB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetIB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetIB.Image = CType(resources.GetObject("btnResetIB.Image"), System.Drawing.Image)
        Me.btnResetIB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetIB.Location = New System.Drawing.Point(235, 14)
        Me.btnResetIB.Name = "btnResetIB"
        Me.btnResetIB.Size = New System.Drawing.Size(98, 25)
        Me.btnResetIB.TabIndex = 5
        Me.btnResetIB.Text = "Reset"
        Me.btnResetIB.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblTotal)
        Me.GroupBox1.Controls.Add(Me.lblSIVNO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblDate)
        Me.GroupBox1.Controls.Add(Me.dtpDate)
        Me.GroupBox1.Controls.Add(Me.txtSIVNO)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(448, 100)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(91, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(91, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(91, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = ":"
        '
        'txtSIVNO
        '
        Me.txtSIVNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIVNO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIVNO.Location = New System.Drawing.Point(170, 41)
        Me.txtSIVNO.Name = "txtSIVNO"
        Me.txtSIVNO.Size = New System.Drawing.Size(135, 21)
        Me.txtSIVNO.TabIndex = 2
        '
        'txtTotal
        '
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(170, 72)
        Me.txtTotal.MaxLength = 22
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(135, 21)
        Me.txtTotal.TabIndex = 3
        '
        'dgclDate
        '
        Me.dgclDate.DataPropertyName = "BatchDate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgclDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgclDate.HeaderText = "Date"
        Me.dgclDate.Name = "dgclDate"
        Me.dgclDate.ReadOnly = True
        Me.dgclDate.Width = 125
        '
        'dgclSIVNo
        '
        Me.dgclSIVNo.DataPropertyName = "SIVNo"
        Me.dgclSIVNo.HeaderText = "SIV No"
        Me.dgclSIVNo.Name = "dgclSIVNo"
        Me.dgclSIVNo.ReadOnly = True
        Me.dgclSIVNo.Width = 125
        '
        'dgclTotal
        '
        Me.dgclTotal.DataPropertyName = "BatchValue"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.dgclTotal.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgclTotal.HeaderText = "Total"
        Me.dgclTotal.Name = "dgclTotal"
        Me.dgclTotal.ReadOnly = True
        Me.dgclTotal.Width = 125
        '
        'dgclBatchID
        '
        Me.dgclBatchID.DataPropertyName = "StIssueBatchID"
        Me.dgclBatchID.HeaderText = "StIssueBatchID"
        Me.dgclBatchID.Name = "dgclBatchID"
        Me.dgclBatchID.ReadOnly = True
        Me.dgclBatchID.Visible = False
        Me.dgclBatchID.Width = 125
        '
        'IssueBatchFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(486, 462)
        Me.Controls.Add(Me.plIB1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "IssueBatchFrm"
        Me.Text = "IssueBatchFrm"
        Me.plIB1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgIssueBatchDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblSIVNO As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents plIB1 As System.Windows.Forms.Panel
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtSIVNO As System.Windows.Forms.TextBox
    Friend WithEvents btnResetIB As System.Windows.Forms.Button
    Friend WithEvents dgIssueBatchDetails As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgclDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclSIVNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclBatchID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

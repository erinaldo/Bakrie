<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommonLookUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CommonLookUp))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlVehicleSearch = New Stepi.UI.ExtendedPanel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblSearchField = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearchValue = New System.Windows.Forms.TextBox()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.pnlVehicleSearch.SuspendLayout()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlVehicleSearch
        '
        Me.pnlVehicleSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlVehicleSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlVehicleSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlVehicleSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlVehicleSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlVehicleSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlVehicleSearch.CaptionSize = 40
        Me.pnlVehicleSearch.CaptionText = "Search by :"
        Me.pnlVehicleSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlVehicleSearch.Controls.Add(Me.btnClose)
        Me.pnlVehicleSearch.Controls.Add(Me.lblSearchField)
        Me.pnlVehicleSearch.Controls.Add(Me.btnSearch)
        Me.pnlVehicleSearch.Controls.Add(Me.txtSearchValue)
        Me.pnlVehicleSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlVehicleSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlVehicleSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlVehicleSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVehicleSearch.ForeColor = System.Drawing.Color.DimGray
        Me.pnlVehicleSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlVehicleSearch.Name = "pnlVehicleSearch"
        Me.pnlVehicleSearch.Size = New System.Drawing.Size(478, 112)
        Me.pnlVehicleSearch.TabIndex = 12
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
        Me.btnClose.Location = New System.Drawing.Point(426, 81)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 27)
        Me.btnClose.TabIndex = 4
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblSearchField
        '
        Me.lblSearchField.AutoSize = True
        Me.lblSearchField.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchField.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchField.Location = New System.Drawing.Point(12, 61)
        Me.lblSearchField.Name = "lblSearchField"
        Me.lblSearchField.Size = New System.Drawing.Size(52, 13)
        Me.lblSearchField.TabIndex = 54
        Me.lblSearchField.Text = "Search"
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
        Me.btnSearch.Location = New System.Drawing.Point(388, 83)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(27, 23)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearchValue
        '
        Me.txtSearchValue.Location = New System.Drawing.Point(15, 85)
        Me.txtSearchValue.Name = "txtSearchValue"
        Me.txtSearchValue.Size = New System.Drawing.Size(367, 21)
        Me.txtSearchValue.TabIndex = 1
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToDeleteRows = False
        Me.dgvResult.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgvResult.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvResult.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResult.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResult.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResult.EnableHeadersVisualStyles = False
        Me.dgvResult.GridColor = System.Drawing.Color.Gray
        Me.dgvResult.Location = New System.Drawing.Point(0, 112)
        Me.dgvResult.MultiSelect = False
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResult.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvResult.RowHeadersVisible = False
        Me.dgvResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResult.Size = New System.Drawing.Size(478, 303)
        Me.dgvResult.TabIndex = 13
        '
        'CommonLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(478, 415)
        Me.Controls.Add(Me.dgvResult)
        Me.Controls.Add(Me.pnlVehicleSearch)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "CommonLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Common Look up"
        Me.pnlVehicleSearch.ResumeLayout(False)
        Me.pnlVehicleSearch.PerformLayout()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlVehicleSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearchField As System.Windows.Forms.Label
    Friend WithEvents txtSearchValue As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvResult As System.Windows.Forms.DataGridView
End Class

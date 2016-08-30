Namespace CheckRoll.Import
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ImportAllowance
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportAllowance))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.tcAllowanceDeduction = New System.Windows.Forms.TabControl()
            Me.tabAllowanceDeduction = New System.Windows.Forms.TabPage()
            Me.LblSource = New System.Windows.Forms.Label()
            Me.BtnBrowse = New System.Windows.Forms.Button()
            Me.BtnSave = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.gbEnquipmentData = New System.Windows.Forms.GroupBox()
            Me.dgvAllowance = New System.Windows.Forms.DataGridView()
            Me.LblProcess = New System.Windows.Forms.Label()
            Me.ProgressBar = New System.Windows.Forms.ProgressBar()
            Me.tcAllowanceDeduction.SuspendLayout()
            Me.tabAllowanceDeduction.SuspendLayout()
            Me.gbEnquipmentData.SuspendLayout()
            CType(Me.dgvAllowance, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tcAllowanceDeduction
            '
            Me.tcAllowanceDeduction.Controls.Add(Me.tabAllowanceDeduction)
            Me.tcAllowanceDeduction.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tcAllowanceDeduction.Location = New System.Drawing.Point(0, 0)
            Me.tcAllowanceDeduction.Name = "tcAllowanceDeduction"
            Me.tcAllowanceDeduction.SelectedIndex = 0
            Me.tcAllowanceDeduction.Size = New System.Drawing.Size(900, 444)
            Me.tcAllowanceDeduction.TabIndex = 203
            '
            'tabAllowanceDeduction
            '
            Me.tabAllowanceDeduction.AutoScroll = True
            Me.tabAllowanceDeduction.BackColor = System.Drawing.Color.Transparent
            Me.tabAllowanceDeduction.BackgroundImage = CType(resources.GetObject("tabAllowanceDeduction.BackgroundImage"), System.Drawing.Image)
            Me.tabAllowanceDeduction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tabAllowanceDeduction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tabAllowanceDeduction.Controls.Add(Me.ProgressBar)
            Me.tabAllowanceDeduction.Controls.Add(Me.LblProcess)
            Me.tabAllowanceDeduction.Controls.Add(Me.LblSource)
            Me.tabAllowanceDeduction.Controls.Add(Me.BtnBrowse)
            Me.tabAllowanceDeduction.Controls.Add(Me.BtnSave)
            Me.tabAllowanceDeduction.Controls.Add(Me.btnClose)
            Me.tabAllowanceDeduction.Controls.Add(Me.gbEnquipmentData)
            Me.tabAllowanceDeduction.Location = New System.Drawing.Point(4, 22)
            Me.tabAllowanceDeduction.Name = "tabAllowanceDeduction"
            Me.tabAllowanceDeduction.Padding = New System.Windows.Forms.Padding(3)
            Me.tabAllowanceDeduction.Size = New System.Drawing.Size(892, 418)
            Me.tabAllowanceDeduction.TabIndex = 0
            Me.tabAllowanceDeduction.Text = "Allowance & Deduction"
            Me.tabAllowanceDeduction.UseVisualStyleBackColor = True
            '
            'LblSource
            '
            Me.LblSource.AutoSize = True
            Me.LblSource.Location = New System.Drawing.Point(139, 18)
            Me.LblSource.Name = "LblSource"
            Me.LblSource.Size = New System.Drawing.Size(59, 13)
            Me.LblSource.TabIndex = 151
            Me.LblSource.Text = "Source : ..."
            '
            'BtnBrowse
            '
            Me.BtnBrowse.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
            Me.BtnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.BtnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.BtnBrowse.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BtnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.BtnBrowse.Location = New System.Drawing.Point(10, 9)
            Me.BtnBrowse.Name = "BtnBrowse"
            Me.BtnBrowse.Size = New System.Drawing.Size(110, 30)
            Me.BtnBrowse.TabIndex = 150
            Me.BtnBrowse.Text = "&Browse"
            Me.BtnBrowse.UseVisualStyleBackColor = True
            '
            'BtnSave
            '
            Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
            Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.BtnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BtnSave.Image = Global.BSP.My.Resources.Resources.user_add
            Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.BtnSave.Location = New System.Drawing.Point(9, 380)
            Me.BtnSave.Name = "BtnSave"
            Me.BtnSave.Size = New System.Drawing.Size(110, 30)
            Me.BtnSave.TabIndex = 9
            Me.BtnSave.Text = "&Save"
            Me.BtnSave.UseVisualStyleBackColor = True
            '
            'btnClose
            '
            Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
            Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnClose.Location = New System.Drawing.Point(125, 380)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(110, 30)
            Me.btnClose.TabIndex = 13
            Me.btnClose.Text = "&Close"
            Me.btnClose.UseVisualStyleBackColor = True
            '
            'gbEnquipmentData
            '
            Me.gbEnquipmentData.Controls.Add(Me.dgvAllowance)
            Me.gbEnquipmentData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbEnquipmentData.Location = New System.Drawing.Point(7, 52)
            Me.gbEnquipmentData.Name = "gbEnquipmentData"
            Me.gbEnquipmentData.Size = New System.Drawing.Size(796, 321)
            Me.gbEnquipmentData.TabIndex = 14
            Me.gbEnquipmentData.TabStop = False
            Me.gbEnquipmentData.Text = "Allowance"
            '
            'dgvAllowance
            '
            Me.dgvAllowance.AllowUserToAddRows = False
            Me.dgvAllowance.AllowUserToDeleteRows = False
            Me.dgvAllowance.AllowUserToOrderColumns = True
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
            Me.dgvAllowance.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvAllowance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvAllowance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
            Me.dgvAllowance.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.dgvAllowance.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvAllowance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAllowance.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvAllowance.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvAllowance.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvAllowance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.dgvAllowance.EnableHeadersVisualStyles = False
            Me.dgvAllowance.GridColor = System.Drawing.Color.Gray
            Me.dgvAllowance.Location = New System.Drawing.Point(3, 17)
            Me.dgvAllowance.Name = "dgvAllowance"
            Me.dgvAllowance.ReadOnly = True
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
            DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAllowance.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
            Me.dgvAllowance.RowHeadersVisible = False
            Me.dgvAllowance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
            Me.dgvAllowance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvAllowance.ShowCellErrors = False
            Me.dgvAllowance.Size = New System.Drawing.Size(790, 301)
            Me.dgvAllowance.TabIndex = 10
            '
            'LblProcess
            '
            Me.LblProcess.AutoSize = True
            Me.LblProcess.Location = New System.Drawing.Point(285, 389)
            Me.LblProcess.Name = "LblProcess"
            Me.LblProcess.Size = New System.Drawing.Size(60, 13)
            Me.LblProcess.TabIndex = 152
            Me.LblProcess.Text = "Process : .."
            '
            'ProgressBar
            '
            Me.ProgressBar.Location = New System.Drawing.Point(597, 384)
            Me.ProgressBar.Name = "ProgressBar"
            Me.ProgressBar.Size = New System.Drawing.Size(203, 14)
            Me.ProgressBar.Step = 1
            Me.ProgressBar.TabIndex = 153
            '
            'ImportAllowance
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.AutoSize = True
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.ClientSize = New System.Drawing.Size(900, 444)
            Me.Controls.Add(Me.tcAllowanceDeduction)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.KeyPreview = True
            Me.Name = "ImportAllowance"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Allowance & Deduction"
            Me.tcAllowanceDeduction.ResumeLayout(False)
            Me.tabAllowanceDeduction.ResumeLayout(False)
            Me.tabAllowanceDeduction.PerformLayout()
            Me.gbEnquipmentData.ResumeLayout(False)
            CType(Me.dgvAllowance, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents tcAllowanceDeduction As System.Windows.Forms.TabControl
        Friend WithEvents tabAllowanceDeduction As System.Windows.Forms.TabPage
        Friend WithEvents BtnSave As System.Windows.Forms.Button
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents gbEnquipmentData As System.Windows.Forms.GroupBox
        Friend WithEvents dgvAllowance As System.Windows.Forms.DataGridView
        Friend WithEvents BtnBrowse As System.Windows.Forms.Button
        Friend WithEvents LblSource As System.Windows.Forms.Label
        Friend WithEvents LblProcess As System.Windows.Forms.Label
        Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    End Class
End Namespace
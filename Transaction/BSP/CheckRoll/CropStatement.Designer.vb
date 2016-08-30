<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CropStatement
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CropStatement))
        Me.tbpgView = New System.Windows.Forms.TabPage()
        Me.plIPRView = New System.Windows.Forms.Panel()
        Me.lblRecordNotFound = New System.Windows.Forms.Label()
        Me.dgvviewCropstatement = New System.Windows.Forms.DataGridView()
        Me.dgvCropStatementID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvBlock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDIV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvYOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvYieldType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvMillWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvBunches = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvBlockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDIVID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvYOPID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvCropYieldID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsCropStatement = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlCropstatementSearch = New Stepi.UI.ExtendedPanel()
        Me.cmbSearchYieldType = New System.Windows.Forms.ComboBox()
        Me.lblSearchYieldType = New System.Windows.Forms.Label()
        Me.lblSearchblock = New System.Windows.Forms.Label()
        Me.txtsearchblock = New System.Windows.Forms.TextBox()
        Me.btnsearchblocklookup = New System.Windows.Forms.Button()
        Me.lblviewSearchBy = New System.Windows.Forms.Label()
        Me.btnviewCropstatementReport = New System.Windows.Forms.Button()
        Me.btnviewCropstatementSearch = New System.Windows.Forms.Button()
        Me.tbpgCropStatement = New System.Windows.Forms.TabPage()
        Me.GbCropstatement = New System.Windows.Forms.GroupBox()
        Me.dtAD = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDIVdsp = New System.Windows.Forms.Label()
        Me.cmbYieldType = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblYieldType = New System.Windows.Forms.Label()
        Me.lblBlock = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtblock = New System.Windows.Forms.TextBox()
        Me.btnblocklookup = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblYOPdsp = New System.Windows.Forms.Label()
        Me.lblYOP = New System.Windows.Forms.Label()
        Me.lblISRT2Name = New System.Windows.Forms.Label()
        Me.lblISRT1Name = New System.Windows.Forms.Label()
        Me.lblISRT0Name = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBunches = New System.Windows.Forms.TextBox()
        Me.lblBunches = New System.Windows.Forms.Label()
        Me.txtMillWeight = New System.Windows.Forms.TextBox()
        Me.lblMillWeight = New System.Windows.Forms.Label()
        Me.lblDiv = New System.Windows.Forms.Label()
        Me.lblColon3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tcCropStatement = New System.Windows.Forms.TabControl()
        Me.tbpgView.SuspendLayout()
        Me.plIPRView.SuspendLayout()
        CType(Me.dgvviewCropstatement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsCropStatement.SuspendLayout()
        Me.pnlCropstatementSearch.SuspendLayout()
        Me.tbpgCropStatement.SuspendLayout()
        Me.GbCropstatement.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tcCropStatement.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbpgView
        '
        Me.tbpgView.AutoScroll = True
        Me.tbpgView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgView.Controls.Add(Me.plIPRView)
        Me.tbpgView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpgView.Location = New System.Drawing.Point(4, 29)
        Me.tbpgView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbpgView.Name = "tbpgView"
        Me.tbpgView.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbpgView.Size = New System.Drawing.Size(1171, 735)
        Me.tbpgView.TabIndex = 1
        Me.tbpgView.Text = "View"
        Me.tbpgView.UseVisualStyleBackColor = True
        '
        'plIPRView
        '
        Me.plIPRView.Controls.Add(Me.lblRecordNotFound)
        Me.plIPRView.Controls.Add(Me.dgvviewCropstatement)
        Me.plIPRView.Controls.Add(Me.pnlCropstatementSearch)
        Me.plIPRView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plIPRView.Location = New System.Drawing.Point(4, 5)
        Me.plIPRView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.plIPRView.Name = "plIPRView"
        Me.plIPRView.Size = New System.Drawing.Size(1163, 725)
        Me.plIPRView.TabIndex = 45
        '
        'lblRecordNotFound
        '
        Me.lblRecordNotFound.AutoSize = True
        Me.lblRecordNotFound.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lblRecordNotFound.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordNotFound.ForeColor = System.Drawing.Color.Red
        Me.lblRecordNotFound.Location = New System.Drawing.Point(470, 335)
        Me.lblRecordNotFound.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRecordNotFound.Name = "lblRecordNotFound"
        Me.lblRecordNotFound.Size = New System.Drawing.Size(194, 20)
        Me.lblRecordNotFound.TabIndex = 119
        Me.lblRecordNotFound.Text = "Record not found !!"
        Me.lblRecordNotFound.Visible = False
        '
        'dgvviewCropstatement
        '
        Me.dgvviewCropstatement.AllowUserToAddRows = False
        Me.dgvviewCropstatement.AllowUserToDeleteRows = False
        Me.dgvviewCropstatement.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvviewCropstatement.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvviewCropstatement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvviewCropstatement.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvviewCropstatement.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.dgvviewCropstatement.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvviewCropstatement.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvviewCropstatement.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvviewCropstatement.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvCropStatementID, Me.dgvDDate, Me.dgvBlock, Me.dgvDIV, Me.dgvYOP, Me.dgvYieldType, Me.dgvMillWeight, Me.dgvBunches, Me.dgvBlockID, Me.dgvDIVID, Me.dgvYOPID, Me.dgvCropYieldID})
        Me.dgvviewCropstatement.ContextMenuStrip = Me.cmsCropStatement
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvviewCropstatement.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvviewCropstatement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvviewCropstatement.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvviewCropstatement.EnableHeadersVisualStyles = False
        Me.dgvviewCropstatement.GridColor = System.Drawing.Color.Gray
        Me.dgvviewCropstatement.Location = New System.Drawing.Point(0, 208)
        Me.dgvviewCropstatement.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvviewCropstatement.Name = "dgvviewCropstatement"
        Me.dgvviewCropstatement.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvviewCropstatement.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvviewCropstatement.RowHeadersVisible = False
        Me.dgvviewCropstatement.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvviewCropstatement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvviewCropstatement.ShowCellErrors = False
        Me.dgvviewCropstatement.Size = New System.Drawing.Size(1163, 517)
        Me.dgvviewCropstatement.TabIndex = 5
        Me.dgvviewCropstatement.TabStop = False
        '
        'dgvCropStatementID
        '
        Me.dgvCropStatementID.DataPropertyName = "CropStatementID"
        Me.dgvCropStatementID.HeaderText = "CropStatementID"
        Me.dgvCropStatementID.Name = "dgvCropStatementID"
        Me.dgvCropStatementID.ReadOnly = True
        Me.dgvCropStatementID.Visible = False
        Me.dgvCropStatementID.Width = 132
        '
        'dgvDDate
        '
        Me.dgvDDate.DataPropertyName = "DDate"
        Me.dgvDDate.HeaderText = "Date"
        Me.dgvDDate.Name = "dgvDDate"
        Me.dgvDDate.ReadOnly = True
        Me.dgvDDate.Width = 73
        '
        'dgvBlock
        '
        Me.dgvBlock.DataPropertyName = "BlockName"
        Me.dgvBlock.HeaderText = "FieldNo"
        Me.dgvBlock.Name = "dgvBlock"
        Me.dgvBlock.ReadOnly = True
        Me.dgvBlock.Width = 97
        '
        'dgvDIV
        '
        Me.dgvDIV.DataPropertyName = "DivName"
        Me.dgvDIV.HeaderText = "Afdeling"
        Me.dgvDIV.Name = "dgvDIV"
        Me.dgvDIV.ReadOnly = True
        Me.dgvDIV.Width = 104
        '
        'dgvYOP
        '
        Me.dgvYOP.DataPropertyName = "YOP"
        Me.dgvYOP.HeaderText = "YOP"
        Me.dgvYOP.Name = "dgvYOP"
        Me.dgvYOP.ReadOnly = True
        Me.dgvYOP.Width = 66
        '
        'dgvYieldType
        '
        Me.dgvYieldType.DataPropertyName = "CropYieldCode"
        Me.dgvYieldType.HeaderText = "Yield Type"
        Me.dgvYieldType.Name = "dgvYieldType"
        Me.dgvYieldType.ReadOnly = True
        Me.dgvYieldType.Width = 119
        '
        'dgvMillWeight
        '
        Me.dgvMillWeight.DataPropertyName = "MilWeight"
        Me.dgvMillWeight.HeaderText = "Mill Weight"
        Me.dgvMillWeight.Name = "dgvMillWeight"
        Me.dgvMillWeight.ReadOnly = True
        Me.dgvMillWeight.Width = 128
        '
        'dgvBunches
        '
        Me.dgvBunches.DataPropertyName = "Bunches"
        Me.dgvBunches.HeaderText = "Bunches"
        Me.dgvBunches.Name = "dgvBunches"
        Me.dgvBunches.ReadOnly = True
        Me.dgvBunches.Width = 106
        '
        'dgvBlockID
        '
        Me.dgvBlockID.DataPropertyName = "BlockID"
        Me.dgvBlockID.HeaderText = "FieldNoID"
        Me.dgvBlockID.Name = "dgvBlockID"
        Me.dgvBlockID.ReadOnly = True
        Me.dgvBlockID.Visible = False
        Me.dgvBlockID.Width = 86
        '
        'dgvDIVID
        '
        Me.dgvDIVID.DataPropertyName = "DivID"
        Me.dgvDIVID.HeaderText = "Afdeling ID"
        Me.dgvDIVID.Name = "dgvDIVID"
        Me.dgvDIVID.ReadOnly = True
        Me.dgvDIVID.Visible = False
        Me.dgvDIVID.Width = 95
        '
        'dgvYOPID
        '
        Me.dgvYOPID.DataPropertyName = "YOPID"
        Me.dgvYOPID.HeaderText = "YOPID"
        Me.dgvYOPID.Name = "dgvYOPID"
        Me.dgvYOPID.ReadOnly = True
        Me.dgvYOPID.Visible = False
        Me.dgvYOPID.Width = 68
        '
        'dgvCropYieldID
        '
        Me.dgvCropYieldID.DataPropertyName = "CropYieldID"
        Me.dgvCropYieldID.HeaderText = "CropYieldID"
        Me.dgvCropYieldID.Name = "dgvCropYieldID"
        Me.dgvCropYieldID.ReadOnly = True
        Me.dgvCropYieldID.Visible = False
        '
        'cmsCropStatement
        '
        Me.cmsCropStatement.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsCropStatement.Name = "cmsIPR"
        Me.cmsCropStatement.Size = New System.Drawing.Size(190, 94)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(189, 30)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(189, 30)
        Me.EditToolStripMenuItem.Text = "Edit / Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(189, 30)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'pnlCropstatementSearch
        '
        Me.pnlCropstatementSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlCropstatementSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCropstatementSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlCropstatementSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlCropstatementSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlCropstatementSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCropstatementSearch.CaptionSize = 40
        Me.pnlCropstatementSearch.CaptionText = "Search Crop Statement"
        Me.pnlCropstatementSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlCropstatementSearch.Controls.Add(Me.cmbSearchYieldType)
        Me.pnlCropstatementSearch.Controls.Add(Me.lblSearchYieldType)
        Me.pnlCropstatementSearch.Controls.Add(Me.lblSearchblock)
        Me.pnlCropstatementSearch.Controls.Add(Me.txtsearchblock)
        Me.pnlCropstatementSearch.Controls.Add(Me.btnsearchblocklookup)
        Me.pnlCropstatementSearch.Controls.Add(Me.lblviewSearchBy)
        Me.pnlCropstatementSearch.Controls.Add(Me.btnviewCropstatementReport)
        Me.pnlCropstatementSearch.Controls.Add(Me.btnviewCropstatementSearch)
        Me.pnlCropstatementSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlCropstatementSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlCropstatementSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlCropstatementSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCropstatementSearch.ForeColor = System.Drawing.Color.Black
        Me.pnlCropstatementSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlCropstatementSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlCropstatementSearch.Name = "pnlCropstatementSearch"
        Me.pnlCropstatementSearch.Size = New System.Drawing.Size(1163, 208)
        Me.pnlCropstatementSearch.TabIndex = 116
        '
        'cmbSearchYieldType
        '
        Me.cmbSearchYieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchYieldType.FormattingEnabled = True
        Me.cmbSearchYieldType.Items.AddRange(New Object() {"--Select--", "FFB", "Loose Fruits"})
        Me.cmbSearchYieldType.Location = New System.Drawing.Point(429, 134)
        Me.cmbSearchYieldType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbSearchYieldType.Name = "cmbSearchYieldType"
        Me.cmbSearchYieldType.Size = New System.Drawing.Size(210, 28)
        Me.cmbSearchYieldType.TabIndex = 242
        '
        'lblSearchYieldType
        '
        Me.lblSearchYieldType.AutoSize = True
        Me.lblSearchYieldType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchYieldType.ForeColor = System.Drawing.Color.Black
        Me.lblSearchYieldType.Location = New System.Drawing.Point(474, 92)
        Me.lblSearchYieldType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSearchYieldType.Name = "lblSearchYieldType"
        Me.lblSearchYieldType.Size = New System.Drawing.Size(95, 20)
        Me.lblSearchYieldType.TabIndex = 243
        Me.lblSearchYieldType.Text = "Yield Type"
        '
        'lblSearchblock
        '
        Me.lblSearchblock.AutoSize = True
        Me.lblSearchblock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchblock.ForeColor = System.Drawing.Color.Black
        Me.lblSearchblock.Location = New System.Drawing.Point(198, 92)
        Me.lblSearchblock.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSearchblock.Name = "lblSearchblock"
        Me.lblSearchblock.Size = New System.Drawing.Size(73, 20)
        Me.lblSearchblock.TabIndex = 238
        Me.lblSearchblock.Text = "FieldNo"
        '
        'txtsearchblock
        '
        Me.txtsearchblock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearchblock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearchblock.Location = New System.Drawing.Point(126, 128)
        Me.txtsearchblock.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtsearchblock.MaxLength = 50
        Me.txtsearchblock.Name = "txtsearchblock"
        Me.txtsearchblock.Size = New System.Drawing.Size(210, 28)
        Me.txtsearchblock.TabIndex = 236
        '
        'btnsearchblocklookup
        '
        Me.btnsearchblocklookup.Image = CType(resources.GetObject("btnsearchblocklookup.Image"), System.Drawing.Image)
        Me.btnsearchblocklookup.Location = New System.Drawing.Point(344, 128)
        Me.btnsearchblocklookup.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnsearchblocklookup.Name = "btnsearchblocklookup"
        Me.btnsearchblocklookup.Size = New System.Drawing.Size(46, 40)
        Me.btnsearchblocklookup.TabIndex = 237
        Me.btnsearchblocklookup.TabStop = False
        Me.btnsearchblocklookup.UseVisualStyleBackColor = True
        '
        'lblviewSearchBy
        '
        Me.lblviewSearchBy.AutoSize = True
        Me.lblviewSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblviewSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewSearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblviewSearchBy.Location = New System.Drawing.Point(2, 63)
        Me.lblviewSearchBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblviewSearchBy.Name = "lblviewSearchBy"
        Me.lblviewSearchBy.Size = New System.Drawing.Size(103, 20)
        Me.lblviewSearchBy.TabIndex = 54
        Me.lblviewSearchBy.Text = "Search By"
        '
        'btnviewCropstatementReport
        '
        Me.btnviewCropstatementReport.BackgroundImage = CType(resources.GetObject("btnviewCropstatementReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewCropstatementReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewCropstatementReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewCropstatementReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewCropstatementReport.Image = CType(resources.GetObject("btnviewCropstatementReport.Image"), System.Drawing.Image)
        Me.btnviewCropstatementReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewCropstatementReport.Location = New System.Drawing.Point(942, 131)
        Me.btnviewCropstatementReport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnviewCropstatementReport.Name = "btnviewCropstatementReport"
        Me.btnviewCropstatementReport.Size = New System.Drawing.Size(189, 38)
        Me.btnviewCropstatementReport.TabIndex = 4
        Me.btnviewCropstatementReport.Text = "View Report"
        Me.btnviewCropstatementReport.UseVisualStyleBackColor = True
        '
        'btnviewCropstatementSearch
        '
        Me.btnviewCropstatementSearch.BackgroundImage = CType(resources.GetObject("btnviewCropstatementSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnviewCropstatementSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewCropstatementSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewCropstatementSearch.ForeColor = System.Drawing.Color.Black
        Me.btnviewCropstatementSearch.Image = CType(resources.GetObject("btnviewCropstatementSearch.Image"), System.Drawing.Image)
        Me.btnviewCropstatementSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewCropstatementSearch.Location = New System.Drawing.Point(744, 131)
        Me.btnviewCropstatementSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnviewCropstatementSearch.Name = "btnviewCropstatementSearch"
        Me.btnviewCropstatementSearch.Size = New System.Drawing.Size(189, 38)
        Me.btnviewCropstatementSearch.TabIndex = 3
        Me.btnviewCropstatementSearch.Text = "Search"
        Me.btnviewCropstatementSearch.UseVisualStyleBackColor = True
        '
        'tbpgCropStatement
        '
        Me.tbpgCropStatement.AutoScroll = True
        Me.tbpgCropStatement.BackColor = System.Drawing.Color.Transparent
        Me.tbpgCropStatement.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgCropStatement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgCropStatement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbpgCropStatement.Controls.Add(Me.GbCropstatement)
        Me.tbpgCropStatement.Controls.Add(Me.GroupBox4)
        Me.tbpgCropStatement.Location = New System.Drawing.Point(4, 29)
        Me.tbpgCropStatement.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbpgCropStatement.Name = "tbpgCropStatement"
        Me.tbpgCropStatement.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbpgCropStatement.Size = New System.Drawing.Size(1171, 735)
        Me.tbpgCropStatement.TabIndex = 0
        Me.tbpgCropStatement.Text = "Crop Statement"
        Me.tbpgCropStatement.UseVisualStyleBackColor = True
        '
        'GbCropstatement
        '
        Me.GbCropstatement.Controls.Add(Me.dtAD)
        Me.GbCropstatement.Controls.Add(Me.Label1)
        Me.GbCropstatement.Controls.Add(Me.Label2)
        Me.GbCropstatement.Controls.Add(Me.lblDIVdsp)
        Me.GbCropstatement.Controls.Add(Me.cmbYieldType)
        Me.GbCropstatement.Controls.Add(Me.Label12)
        Me.GbCropstatement.Controls.Add(Me.lblYieldType)
        Me.GbCropstatement.Controls.Add(Me.lblBlock)
        Me.GbCropstatement.Controls.Add(Me.Label15)
        Me.GbCropstatement.Controls.Add(Me.txtblock)
        Me.GbCropstatement.Controls.Add(Me.btnblocklookup)
        Me.GbCropstatement.Controls.Add(Me.Label13)
        Me.GbCropstatement.Controls.Add(Me.lblYOPdsp)
        Me.GbCropstatement.Controls.Add(Me.lblYOP)
        Me.GbCropstatement.Controls.Add(Me.lblISRT2Name)
        Me.GbCropstatement.Controls.Add(Me.lblISRT1Name)
        Me.GbCropstatement.Controls.Add(Me.lblISRT0Name)
        Me.GbCropstatement.Controls.Add(Me.Label21)
        Me.GbCropstatement.Controls.Add(Me.Label9)
        Me.GbCropstatement.Controls.Add(Me.txtBunches)
        Me.GbCropstatement.Controls.Add(Me.lblBunches)
        Me.GbCropstatement.Controls.Add(Me.txtMillWeight)
        Me.GbCropstatement.Controls.Add(Me.lblMillWeight)
        Me.GbCropstatement.Controls.Add(Me.lblDiv)
        Me.GbCropstatement.Controls.Add(Me.lblColon3)
        Me.GbCropstatement.Location = New System.Drawing.Point(3, 9)
        Me.GbCropstatement.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GbCropstatement.Name = "GbCropstatement"
        Me.GbCropstatement.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GbCropstatement.Size = New System.Drawing.Size(970, 385)
        Me.GbCropstatement.TabIndex = 2
        Me.GbCropstatement.TabStop = False
        Me.GbCropstatement.Text = "Crop Statement"
        '
        'dtAD
        '
        Me.dtAD.CustomFormat = "dd/MM/yyyy"
        Me.dtAD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtAD.Location = New System.Drawing.Point(246, 63)
        Me.dtAD.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtAD.Name = "dtAD"
        Me.dtAD.Size = New System.Drawing.Size(210, 26)
        Me.dtAD.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(40, 62)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 20)
        Me.Label1.TabIndex = 244
        Me.Label1.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(207, 65)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 20)
        Me.Label2.TabIndex = 245
        Me.Label2.Text = ":"
        '
        'lblDIVdsp
        '
        Me.lblDIVdsp.ForeColor = System.Drawing.Color.Blue
        Me.lblDIVdsp.Location = New System.Drawing.Point(242, 158)
        Me.lblDIVdsp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDIVdsp.Name = "lblDIVdsp"
        Me.lblDIVdsp.Size = New System.Drawing.Size(202, 18)
        Me.lblDIVdsp.TabIndex = 242
        '
        'cmbYieldType
        '
        Me.cmbYieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYieldType.FormattingEnabled = True
        Me.cmbYieldType.ItemHeight = 20
        Me.cmbYieldType.Items.AddRange(New Object() {"FFB", "Loose Fruits"})
        Me.cmbYieldType.Location = New System.Drawing.Point(244, 245)
        Me.cmbYieldType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbYieldType.Name = "cmbYieldType"
        Me.cmbYieldType.Size = New System.Drawing.Size(210, 28)
        Me.cmbYieldType.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(207, 245)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 20)
        Me.Label12.TabIndex = 241
        Me.Label12.Text = ":"
        '
        'lblYieldType
        '
        Me.lblYieldType.AutoSize = True
        Me.lblYieldType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYieldType.ForeColor = System.Drawing.Color.Red
        Me.lblYieldType.Location = New System.Drawing.Point(40, 245)
        Me.lblYieldType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYieldType.Name = "lblYieldType"
        Me.lblYieldType.Size = New System.Drawing.Size(95, 20)
        Me.lblYieldType.TabIndex = 240
        Me.lblYieldType.Text = "Yield Type"
        '
        'lblBlock
        '
        Me.lblBlock.AutoSize = True
        Me.lblBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock.ForeColor = System.Drawing.Color.Red
        Me.lblBlock.Location = New System.Drawing.Point(40, 109)
        Me.lblBlock.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBlock.Name = "lblBlock"
        Me.lblBlock.Size = New System.Drawing.Size(73, 20)
        Me.lblBlock.TabIndex = 234
        Me.lblBlock.Text = "FieldNo"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(208, 109)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 20)
        Me.Label15.TabIndex = 235
        Me.Label15.Text = ":"
        '
        'txtblock
        '
        Me.txtblock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtblock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtblock.Location = New System.Drawing.Point(246, 106)
        Me.txtblock.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtblock.MaxLength = 50
        Me.txtblock.Name = "txtblock"
        Me.txtblock.Size = New System.Drawing.Size(210, 28)
        Me.txtblock.TabIndex = 3
        '
        'btnblocklookup
        '
        Me.btnblocklookup.Image = CType(resources.GetObject("btnblocklookup.Image"), System.Drawing.Image)
        Me.btnblocklookup.Location = New System.Drawing.Point(464, 106)
        Me.btnblocklookup.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnblocklookup.Name = "btnblocklookup"
        Me.btnblocklookup.Size = New System.Drawing.Size(46, 40)
        Me.btnblocklookup.TabIndex = 10
        Me.btnblocklookup.TabStop = False
        Me.btnblocklookup.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(207, 200)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 20)
        Me.Label13.TabIndex = 231
        Me.Label13.Text = ":"
        '
        'lblYOPdsp
        '
        Me.lblYOPdsp.ForeColor = System.Drawing.Color.Blue
        Me.lblYOPdsp.Location = New System.Drawing.Point(242, 197)
        Me.lblYOPdsp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYOPdsp.Name = "lblYOPdsp"
        Me.lblYOPdsp.Size = New System.Drawing.Size(202, 20)
        Me.lblYOPdsp.TabIndex = 230
        '
        'lblYOP
        '
        Me.lblYOP.AutoSize = True
        Me.lblYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOP.ForeColor = System.Drawing.Color.Black
        Me.lblYOP.Location = New System.Drawing.Point(39, 197)
        Me.lblYOP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYOP.Name = "lblYOP"
        Me.lblYOP.Size = New System.Drawing.Size(42, 20)
        Me.lblYOP.TabIndex = 229
        Me.lblYOP.Text = "YOP"
        '
        'lblISRT2Name
        '
        Me.lblISRT2Name.AutoSize = True
        Me.lblISRT2Name.ForeColor = System.Drawing.Color.Blue
        Me.lblISRT2Name.Location = New System.Drawing.Point(1192, 180)
        Me.lblISRT2Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblISRT2Name.Name = "lblISRT2Name"
        Me.lblISRT2Name.Size = New System.Drawing.Size(0, 20)
        Me.lblISRT2Name.TabIndex = 218
        '
        'lblISRT1Name
        '
        Me.lblISRT1Name.AutoSize = True
        Me.lblISRT1Name.ForeColor = System.Drawing.Color.Blue
        Me.lblISRT1Name.Location = New System.Drawing.Point(1196, 140)
        Me.lblISRT1Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblISRT1Name.Name = "lblISRT1Name"
        Me.lblISRT1Name.Size = New System.Drawing.Size(0, 20)
        Me.lblISRT1Name.TabIndex = 217
        '
        'lblISRT0Name
        '
        Me.lblISRT0Name.AutoSize = True
        Me.lblISRT0Name.ForeColor = System.Drawing.Color.Blue
        Me.lblISRT0Name.Location = New System.Drawing.Point(1196, 100)
        Me.lblISRT0Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblISRT0Name.Name = "lblISRT0Name"
        Me.lblISRT0Name.Size = New System.Drawing.Size(0, 20)
        Me.lblISRT0Name.TabIndex = 216
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(208, 289)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(16, 20)
        Me.Label21.TabIndex = 211
        Me.Label21.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(210, 331)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 20)
        Me.Label9.TabIndex = 209
        Me.Label9.Text = ":"
        '
        'txtBunches
        '
        Me.txtBunches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBunches.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBunches.Location = New System.Drawing.Point(244, 328)
        Me.txtBunches.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBunches.Name = "txtBunches"
        Me.txtBunches.Size = New System.Drawing.Size(210, 28)
        Me.txtBunches.TabIndex = 6
        '
        'lblBunches
        '
        Me.lblBunches.AutoSize = True
        Me.lblBunches.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBunches.ForeColor = System.Drawing.Color.Black
        Me.lblBunches.Location = New System.Drawing.Point(40, 329)
        Me.lblBunches.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBunches.Name = "lblBunches"
        Me.lblBunches.Size = New System.Drawing.Size(82, 20)
        Me.lblBunches.TabIndex = 203
        Me.lblBunches.Text = "Bunches"
        '
        'txtMillWeight
        '
        Me.txtMillWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMillWeight.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMillWeight.Location = New System.Drawing.Point(244, 286)
        Me.txtMillWeight.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMillWeight.Name = "txtMillWeight"
        Me.txtMillWeight.Size = New System.Drawing.Size(210, 28)
        Me.txtMillWeight.TabIndex = 5
        '
        'lblMillWeight
        '
        Me.lblMillWeight.AutoSize = True
        Me.lblMillWeight.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMillWeight.ForeColor = System.Drawing.Color.Red
        Me.lblMillWeight.Location = New System.Drawing.Point(40, 289)
        Me.lblMillWeight.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMillWeight.Name = "lblMillWeight"
        Me.lblMillWeight.Size = New System.Drawing.Size(158, 20)
        Me.lblMillWeight.TabIndex = 201
        Me.lblMillWeight.Text = "Mill Weight (Kgs)"
        '
        'lblDiv
        '
        Me.lblDiv.AutoSize = True
        Me.lblDiv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiv.ForeColor = System.Drawing.Color.Black
        Me.lblDiv.Location = New System.Drawing.Point(40, 158)
        Me.lblDiv.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDiv.Name = "lblDiv"
        Me.lblDiv.Size = New System.Drawing.Size(80, 20)
        Me.lblDiv.TabIndex = 179
        Me.lblDiv.Text = "Afdeling"
        '
        'lblColon3
        '
        Me.lblColon3.AutoSize = True
        Me.lblColon3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon3.Location = New System.Drawing.Point(208, 158)
        Me.lblColon3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblColon3.Name = "lblColon3"
        Me.lblColon3.Size = New System.Drawing.Size(16, 20)
        Me.lblColon3.TabIndex = 180
        Me.lblColon3.Text = ":"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnReset)
        Me.GroupBox4.Controls.Add(Me.btnClose)
        Me.GroupBox4.Controls.Add(Me.btnSave)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 403)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Size = New System.Drawing.Size(966, 75)
        Me.GroupBox4.TabIndex = 30
        Me.GroupBox4.TabStop = False
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(636, 23)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(142, 43)
        Me.btnReset.TabIndex = 8
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(788, 23)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(142, 43)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(470, 23)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(158, 43)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tcCropStatement
        '
        Me.tcCropStatement.Controls.Add(Me.tbpgCropStatement)
        Me.tcCropStatement.Controls.Add(Me.tbpgView)
        Me.tcCropStatement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcCropStatement.Location = New System.Drawing.Point(0, 0)
        Me.tcCropStatement.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tcCropStatement.Name = "tcCropStatement"
        Me.tcCropStatement.SelectedIndex = 0
        Me.tcCropStatement.Size = New System.Drawing.Size(1179, 768)
        Me.tcCropStatement.TabIndex = 1
        Me.tcCropStatement.TabStop = False
        '
        'CropStatement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1179, 768)
        Me.Controls.Add(Me.tcCropStatement)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "CropStatement"
        Me.Text = "CropStatement"
        Me.tbpgView.ResumeLayout(False)
        Me.plIPRView.ResumeLayout(False)
        Me.plIPRView.PerformLayout()
        CType(Me.dgvviewCropstatement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsCropStatement.ResumeLayout(False)
        Me.pnlCropstatementSearch.ResumeLayout(False)
        Me.pnlCropstatementSearch.PerformLayout()
        Me.tbpgCropStatement.ResumeLayout(False)
        Me.GbCropstatement.ResumeLayout(False)
        Me.GbCropstatement.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.tcCropStatement.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbpgView As System.Windows.Forms.TabPage
    Friend WithEvents plIPRView As System.Windows.Forms.Panel
    Friend WithEvents lblRecordNotFound As System.Windows.Forms.Label
    Friend WithEvents dgvviewCropstatement As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCropstatementSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents cmbSearchYieldType As System.Windows.Forms.ComboBox
    Friend WithEvents lblSearchYieldType As System.Windows.Forms.Label
    Friend WithEvents lblSearchblock As System.Windows.Forms.Label
    Friend WithEvents txtsearchblock As System.Windows.Forms.TextBox
    Friend WithEvents btnsearchblocklookup As System.Windows.Forms.Button
    Friend WithEvents lblviewSearchBy As System.Windows.Forms.Label
    Friend WithEvents btnviewCropstatementReport As System.Windows.Forms.Button
    Friend WithEvents btnviewCropstatementSearch As System.Windows.Forms.Button
    Friend WithEvents tbpgCropStatement As System.Windows.Forms.TabPage
    Friend WithEvents GbCropstatement As System.Windows.Forms.GroupBox
    Friend WithEvents lblDIVdsp As System.Windows.Forms.Label
    Friend WithEvents cmbYieldType As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblYieldType As System.Windows.Forms.Label
    Friend WithEvents lblBlock As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtblock As System.Windows.Forms.TextBox
    Friend WithEvents btnblocklookup As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblYOPdsp As System.Windows.Forms.Label
    Friend WithEvents lblYOP As System.Windows.Forms.Label
    Friend WithEvents lblISRT2Name As System.Windows.Forms.Label
    Friend WithEvents lblISRT1Name As System.Windows.Forms.Label
    Friend WithEvents lblISRT0Name As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBunches As System.Windows.Forms.TextBox
    Friend WithEvents lblBunches As System.Windows.Forms.Label
    Friend WithEvents txtMillWeight As System.Windows.Forms.TextBox
    Friend WithEvents lblMillWeight As System.Windows.Forms.Label
    Friend WithEvents lblDiv As System.Windows.Forms.Label
    Friend WithEvents lblColon3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tcCropStatement As System.Windows.Forms.TabControl
    Friend WithEvents cmsCropStatement As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtAD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvCropStatementID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvBlock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDIV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvYOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvYieldType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvMillWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvBunches As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvBlockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDIVID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvYOPID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvCropYieldID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

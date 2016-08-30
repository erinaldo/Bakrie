<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountBatchFrm
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountBatchFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tcAccountBatchView = New System.Windows.Forms.TabControl
        Me.tbAccountBatch = New System.Windows.Forms.TabPage
        Me.gbLedgerBatch = New System.Windows.Forms.GroupBox
        Me.btnLookUp = New System.Windows.Forms.Button
        Me.lblColon4 = New System.Windows.Forms.Label
        Me.lblColon2 = New System.Windows.Forms.Label
        Me.lblColon3 = New System.Windows.Forms.Label
        Me.lblColon1 = New System.Windows.Forms.Label
        Me.chkRecurringJournals = New System.Windows.Forms.CheckBox
        Me.txtBatchTotal = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtLedgerNumber = New System.Windows.Forms.TextBox
        Me.txtLedgerType = New System.Windows.Forms.TextBox
        Me.lblBatchTotal = New System.Windows.Forms.Label
        Me.lblDescription = New System.Windows.Forms.Label
        Me.lblLedgerNo = New System.Windows.Forms.Label
        Me.lblLedgerType = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.tbAccountBatchView = New System.Windows.Forms.TabPage
        Me.plIPRView = New System.Windows.Forms.Panel
        Me.lblNoRecordFound = New System.Windows.Forms.Label
        Me.dgBatchDetails = New System.Windows.Forms.DataGridView
        Me.cmsAccountBatchDetail = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlSearch = New Stepi.UI.ExtendedPanel
        Me.txtviewLedgerType = New System.Windows.Forms.TextBox
        Me.lblviewLedgerType = New System.Windows.Forms.Label
        Me.lblviewAccBatchSearchBy = New System.Windows.Forms.Label
        Me.lblviewLedgerno = New System.Windows.Forms.Label
        Me.btnviewAccountBatchReport = New System.Windows.Forms.Button
        Me.txtviewLedgerNo = New System.Windows.Forms.TextBox
        Me.btnviewAccountBatchSearch = New System.Windows.Forms.Button
        Me.LedgerType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Expr1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LedgerNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LedgerSetupID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approved = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActiveMonthYearId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccBatchID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RecuringJournal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tcAccountBatchView.SuspendLayout()
        Me.tbAccountBatch.SuspendLayout()
        Me.gbLedgerBatch.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tbAccountBatchView.SuspendLayout()
        Me.plIPRView.SuspendLayout()
        CType(Me.dgBatchDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAccountBatchDetail.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcAccountBatchView
        '
        Me.tcAccountBatchView.Controls.Add(Me.tbAccountBatch)
        Me.tcAccountBatchView.Controls.Add(Me.tbAccountBatchView)
        Me.tcAccountBatchView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcAccountBatchView.Location = New System.Drawing.Point(0, 0)
        Me.tcAccountBatchView.Name = "tcAccountBatchView"
        Me.tcAccountBatchView.SelectedIndex = 0
        Me.tcAccountBatchView.Size = New System.Drawing.Size(1019, 621)
        Me.tcAccountBatchView.TabIndex = 202
        Me.tcAccountBatchView.TabStop = False
        '
        'tbAccountBatch
        '
        Me.tbAccountBatch.AutoScroll = True
        Me.tbAccountBatch.BackColor = System.Drawing.Color.Transparent
        Me.tbAccountBatch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbAccountBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbAccountBatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbAccountBatch.Controls.Add(Me.gbLedgerBatch)
        Me.tbAccountBatch.Controls.Add(Me.GroupBox4)
        Me.tbAccountBatch.Location = New System.Drawing.Point(4, 22)
        Me.tbAccountBatch.Name = "tbAccountBatch"
        Me.tbAccountBatch.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAccountBatch.Size = New System.Drawing.Size(1011, 595)
        Me.tbAccountBatch.TabIndex = 0
        Me.tbAccountBatch.Text = "Account Batch"
        Me.tbAccountBatch.UseVisualStyleBackColor = True
        '
        'gbLedgerBatch
        '
        Me.gbLedgerBatch.Controls.Add(Me.btnLookUp)
        Me.gbLedgerBatch.Controls.Add(Me.lblColon4)
        Me.gbLedgerBatch.Controls.Add(Me.lblColon2)
        Me.gbLedgerBatch.Controls.Add(Me.lblColon3)
        Me.gbLedgerBatch.Controls.Add(Me.lblColon1)
        Me.gbLedgerBatch.Controls.Add(Me.chkRecurringJournals)
        Me.gbLedgerBatch.Controls.Add(Me.txtBatchTotal)
        Me.gbLedgerBatch.Controls.Add(Me.txtDescription)
        Me.gbLedgerBatch.Controls.Add(Me.txtLedgerNumber)
        Me.gbLedgerBatch.Controls.Add(Me.txtLedgerType)
        Me.gbLedgerBatch.Controls.Add(Me.lblBatchTotal)
        Me.gbLedgerBatch.Controls.Add(Me.lblDescription)
        Me.gbLedgerBatch.Controls.Add(Me.lblLedgerNo)
        Me.gbLedgerBatch.Controls.Add(Me.lblLedgerType)
        Me.gbLedgerBatch.Location = New System.Drawing.Point(7, 6)
        Me.gbLedgerBatch.Name = "gbLedgerBatch"
        Me.gbLedgerBatch.Size = New System.Drawing.Size(632, 169)
        Me.gbLedgerBatch.TabIndex = 134
        Me.gbLedgerBatch.TabStop = False
        '
        'btnLookUp
        '
        Me.btnLookUp.Image = CType(resources.GetObject("btnLookUp.Image"), System.Drawing.Image)
        Me.btnLookUp.Location = New System.Drawing.Point(308, 24)
        Me.btnLookUp.Name = "btnLookUp"
        Me.btnLookUp.Size = New System.Drawing.Size(31, 26)
        Me.btnLookUp.TabIndex = 135
        Me.btnLookUp.UseVisualStyleBackColor = True
        '
        'lblColon4
        '
        Me.lblColon4.AutoSize = True
        Me.lblColon4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon4.Location = New System.Drawing.Point(109, 135)
        Me.lblColon4.Name = "lblColon4"
        Me.lblColon4.Size = New System.Drawing.Size(11, 13)
        Me.lblColon4.TabIndex = 137
        Me.lblColon4.Text = ":"
        '
        'lblColon2
        '
        Me.lblColon2.AutoSize = True
        Me.lblColon2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon2.Location = New System.Drawing.Point(109, 60)
        Me.lblColon2.Name = "lblColon2"
        Me.lblColon2.Size = New System.Drawing.Size(11, 13)
        Me.lblColon2.TabIndex = 136
        Me.lblColon2.Text = ":"
        '
        'lblColon3
        '
        Me.lblColon3.AutoSize = True
        Me.lblColon3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon3.Location = New System.Drawing.Point(109, 93)
        Me.lblColon3.Name = "lblColon3"
        Me.lblColon3.Size = New System.Drawing.Size(11, 13)
        Me.lblColon3.TabIndex = 135
        Me.lblColon3.Text = ":"
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(110, 26)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(11, 13)
        Me.lblColon1.TabIndex = 132
        Me.lblColon1.Text = ":"
        '
        'chkRecurringJournals
        '
        Me.chkRecurringJournals.AutoSize = True
        Me.chkRecurringJournals.Location = New System.Drawing.Point(413, 26)
        Me.chkRecurringJournals.Name = "chkRecurringJournals"
        Me.chkRecurringJournals.Size = New System.Drawing.Size(109, 17)
        Me.chkRecurringJournals.TabIndex = 8
        Me.chkRecurringJournals.Text = "Recurring Journal"
        Me.chkRecurringJournals.UseVisualStyleBackColor = True
        '
        'txtBatchTotal
        '
        Me.txtBatchTotal.Location = New System.Drawing.Point(134, 132)
        Me.txtBatchTotal.Multiline = True
        Me.txtBatchTotal.Name = "txtBatchTotal"
        Me.txtBatchTotal.Size = New System.Drawing.Size(168, 20)
        Me.txtBatchTotal.TabIndex = 3
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(134, 76)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(168, 50)
        Me.txtDescription.TabIndex = 2
        '
        'txtLedgerNumber
        '
        Me.txtLedgerNumber.Location = New System.Drawing.Point(134, 50)
        Me.txtLedgerNumber.Name = "txtLedgerNumber"
        Me.txtLedgerNumber.Size = New System.Drawing.Size(168, 20)
        Me.txtLedgerNumber.TabIndex = 1
        '
        'txtLedgerType
        '
        Me.txtLedgerType.Enabled = False
        Me.txtLedgerType.Location = New System.Drawing.Point(134, 24)
        Me.txtLedgerType.Name = "txtLedgerType"
        Me.txtLedgerType.Size = New System.Drawing.Size(168, 20)
        Me.txtLedgerType.TabIndex = 0
        '
        'lblBatchTotal
        '
        Me.lblBatchTotal.AutoSize = True
        Me.lblBatchTotal.ForeColor = System.Drawing.Color.Red
        Me.lblBatchTotal.Location = New System.Drawing.Point(15, 135)
        Me.lblBatchTotal.Name = "lblBatchTotal"
        Me.lblBatchTotal.Size = New System.Drawing.Size(62, 13)
        Me.lblBatchTotal.TabIndex = 3
        Me.lblBatchTotal.Text = "Batch Total"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.ForeColor = System.Drawing.Color.Red
        Me.lblDescription.Location = New System.Drawing.Point(15, 93)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 2
        Me.lblDescription.Text = "Description"
        '
        'lblLedgerNo
        '
        Me.lblLedgerNo.AutoSize = True
        Me.lblLedgerNo.ForeColor = System.Drawing.Color.Red
        Me.lblLedgerNo.Location = New System.Drawing.Point(15, 60)
        Me.lblLedgerNo.Name = "lblLedgerNo"
        Me.lblLedgerNo.Size = New System.Drawing.Size(80, 13)
        Me.lblLedgerNo.TabIndex = 1
        Me.lblLedgerNo.Text = "Ledger Number"
        '
        'lblLedgerType
        '
        Me.lblLedgerType.AutoSize = True
        Me.lblLedgerType.ForeColor = System.Drawing.Color.Red
        Me.lblLedgerType.Location = New System.Drawing.Point(15, 27)
        Me.lblLedgerType.Name = "lblLedgerType"
        Me.lblLedgerType.Size = New System.Drawing.Size(67, 13)
        Me.lblLedgerType.TabIndex = 0
        Me.lblLedgerType.Text = "Ledger Type"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnReset)
        Me.GroupBox4.Controls.Add(Me.btnClose)
        Me.GroupBox4.Controls.Add(Me.btnSave)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 181)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(632, 49)
        Me.GroupBox4.TabIndex = 133
        Me.GroupBox4.TabStop = False
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(419, 15)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 28)
        Me.btnReset.TabIndex = 118
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
        Me.btnClose.Location = New System.Drawing.Point(520, 15)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 28)
        Me.btnClose.TabIndex = 119
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
        Me.btnSave.Location = New System.Drawing.Point(318, 15)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 28)
        Me.btnSave.TabIndex = 117
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tbAccountBatchView
        '
        Me.tbAccountBatchView.AutoScroll = True
        Me.tbAccountBatchView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbAccountBatchView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbAccountBatchView.Controls.Add(Me.plIPRView)
        Me.tbAccountBatchView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAccountBatchView.Location = New System.Drawing.Point(4, 22)
        Me.tbAccountBatchView.Name = "tbAccountBatchView"
        Me.tbAccountBatchView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAccountBatchView.Size = New System.Drawing.Size(1011, 595)
        Me.tbAccountBatchView.TabIndex = 1
        Me.tbAccountBatchView.Text = "View"
        Me.tbAccountBatchView.UseVisualStyleBackColor = True
        '
        'plIPRView
        '
        Me.plIPRView.Controls.Add(Me.lblNoRecordFound)
        Me.plIPRView.Controls.Add(Me.dgBatchDetails)
        Me.plIPRView.Controls.Add(Me.pnlSearch)
        Me.plIPRView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plIPRView.Location = New System.Drawing.Point(3, 3)
        Me.plIPRView.Name = "plIPRView"
        Me.plIPRView.Size = New System.Drawing.Size(1005, 589)
        Me.plIPRView.TabIndex = 45
        '
        'lblNoRecordFound
        '
        Me.lblNoRecordFound.AutoSize = True
        Me.lblNoRecordFound.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblNoRecordFound.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecordFound.Location = New System.Drawing.Point(184, 210)
        Me.lblNoRecordFound.Name = "lblNoRecordFound"
        Me.lblNoRecordFound.Size = New System.Drawing.Size(104, 13)
        Me.lblNoRecordFound.TabIndex = 121
        Me.lblNoRecordFound.Text = "No Record Found"
        '
        'dgBatchDetails
        '
        Me.dgBatchDetails.AllowUserToAddRows = False
        Me.dgBatchDetails.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgBatchDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgBatchDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgBatchDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgBatchDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgBatchDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgBatchDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBatchDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgBatchDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LedgerType, Me.Expr1, Me.EstateID, Me.LedgerNo, Me.Description, Me.BatchTotal, Me.LedgerSetupID, Me.Approved, Me.ActiveMonthYearId, Me.AccBatchID, Me.RecuringJournal})
        Me.dgBatchDetails.ContextMenuStrip = Me.cmsAccountBatchDetail
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgBatchDetails.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgBatchDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgBatchDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgBatchDetails.EnableHeadersVisualStyles = False
        Me.dgBatchDetails.GridColor = System.Drawing.Color.Gray
        Me.dgBatchDetails.Location = New System.Drawing.Point(0, 135)
        Me.dgBatchDetails.Name = "dgBatchDetails"
        Me.dgBatchDetails.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBatchDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgBatchDetails.RowHeadersVisible = False
        Me.dgBatchDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgBatchDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBatchDetails.ShowCellErrors = False
        Me.dgBatchDetails.Size = New System.Drawing.Size(1005, 454)
        Me.dgBatchDetails.TabIndex = 120
        '
        'cmsAccountBatchDetail
        '
        Me.cmsAccountBatchDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsAccountBatchDetail.Name = "cmsIPR"
        Me.cmsAccountBatchDetail.Size = New System.Drawing.Size(149, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.EditToolStripMenuItem.Text = "Edit / Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearch.CaptionSize = 40
        Me.pnlSearch.CaptionText = "Search Account Batch "
        Me.pnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSearch.Controls.Add(Me.txtviewLedgerType)
        Me.pnlSearch.Controls.Add(Me.lblviewLedgerType)
        Me.pnlSearch.Controls.Add(Me.lblviewAccBatchSearchBy)
        Me.pnlSearch.Controls.Add(Me.lblviewLedgerno)
        Me.pnlSearch.Controls.Add(Me.btnviewAccountBatchReport)
        Me.pnlSearch.Controls.Add(Me.txtviewLedgerNo)
        Me.pnlSearch.Controls.Add(Me.btnviewAccountBatchSearch)
        Me.pnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearch.ForeColor = System.Drawing.Color.Black
        Me.pnlSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(1005, 135)
        Me.pnlSearch.TabIndex = 116
        '
        'txtviewLedgerType
        '
        Me.txtviewLedgerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewLedgerType.Location = New System.Drawing.Point(52, 87)
        Me.txtviewLedgerType.MaxLength = 50
        Me.txtviewLedgerType.Name = "txtviewLedgerType"
        Me.txtviewLedgerType.Size = New System.Drawing.Size(165, 21)
        Me.txtviewLedgerType.TabIndex = 118
        '
        'lblviewLedgerType
        '
        Me.lblviewLedgerType.AutoSize = True
        Me.lblviewLedgerType.ForeColor = System.Drawing.Color.Black
        Me.lblviewLedgerType.Location = New System.Drawing.Point(66, 64)
        Me.lblviewLedgerType.Name = "lblviewLedgerType"
        Me.lblviewLedgerType.Size = New System.Drawing.Size(78, 13)
        Me.lblviewLedgerType.TabIndex = 117
        Me.lblviewLedgerType.Text = "Ledger Type"
        '
        'lblviewAccBatchSearchBy
        '
        Me.lblviewAccBatchSearchBy.AutoSize = True
        Me.lblviewAccBatchSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblviewAccBatchSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblviewAccBatchSearchBy.ForeColor = System.Drawing.Color.Black
        Me.lblviewAccBatchSearchBy.Location = New System.Drawing.Point(1, 42)
        Me.lblviewAccBatchSearchBy.Name = "lblviewAccBatchSearchBy"
        Me.lblviewAccBatchSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblviewAccBatchSearchBy.TabIndex = 54
        Me.lblviewAccBatchSearchBy.Text = "Search By"
        '
        'lblviewLedgerno
        '
        Me.lblviewLedgerno.AutoSize = True
        Me.lblviewLedgerno.ForeColor = System.Drawing.Color.Black
        Me.lblviewLedgerno.Location = New System.Drawing.Point(300, 64)
        Me.lblviewLedgerno.Name = "lblviewLedgerno"
        Me.lblviewLedgerno.Size = New System.Drawing.Size(69, 13)
        Me.lblviewLedgerno.TabIndex = 17
        Me.lblviewLedgerno.Text = "Ledger No."
        '
        'btnviewAccountBatchReport
        '
        Me.btnviewAccountBatchReport.BackgroundImage = CType(resources.GetObject("btnviewAccountBatchReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewAccountBatchReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewAccountBatchReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewAccountBatchReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewAccountBatchReport.Image = CType(resources.GetObject("btnviewAccountBatchReport.Image"), System.Drawing.Image)
        Me.btnviewAccountBatchReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewAccountBatchReport.Location = New System.Drawing.Point(573, 83)
        Me.btnviewAccountBatchReport.Name = "btnviewAccountBatchReport"
        Me.btnviewAccountBatchReport.Size = New System.Drawing.Size(126, 25)
        Me.btnviewAccountBatchReport.TabIndex = 116
        Me.btnviewAccountBatchReport.Text = "View Report"
        Me.btnviewAccountBatchReport.UseVisualStyleBackColor = True
        '
        'txtviewLedgerNo
        '
        Me.txtviewLedgerNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtviewLedgerNo.Location = New System.Drawing.Point(250, 87)
        Me.txtviewLedgerNo.MaxLength = 50
        Me.txtviewLedgerNo.Name = "txtviewLedgerNo"
        Me.txtviewLedgerNo.Size = New System.Drawing.Size(165, 21)
        Me.txtviewLedgerNo.TabIndex = 32
        '
        'btnviewAccountBatchSearch
        '
        Me.btnviewAccountBatchSearch.BackgroundImage = CType(resources.GetObject("btnviewAccountBatchSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnviewAccountBatchSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewAccountBatchSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewAccountBatchSearch.ForeColor = System.Drawing.Color.Black
        Me.btnviewAccountBatchSearch.Image = CType(resources.GetObject("btnviewAccountBatchSearch.Image"), System.Drawing.Image)
        Me.btnviewAccountBatchSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewAccountBatchSearch.Location = New System.Drawing.Point(450, 83)
        Me.btnviewAccountBatchSearch.Name = "btnviewAccountBatchSearch"
        Me.btnviewAccountBatchSearch.Size = New System.Drawing.Size(117, 25)
        Me.btnviewAccountBatchSearch.TabIndex = 112
        Me.btnviewAccountBatchSearch.Text = "Search"
        Me.btnviewAccountBatchSearch.UseVisualStyleBackColor = True
        '
        'LedgerType
        '
        Me.LedgerType.DataPropertyName = "LedgerType"
        Me.LedgerType.HeaderText = "Ledger Type"
        Me.LedgerType.Name = "LedgerType"
        Me.LedgerType.ReadOnly = True
        Me.LedgerType.Width = 102
        '
        'Expr1
        '
        Me.Expr1.DataPropertyName = "Expr1"
        Me.Expr1.HeaderText = "Expr1"
        Me.Expr1.Name = "Expr1"
        Me.Expr1.ReadOnly = True
        Me.Expr1.Visible = False
        Me.Expr1.Width = 64
        '
        'EstateID
        '
        Me.EstateID.DataPropertyName = "EstateID"
        Me.EstateID.HeaderText = "EstateID"
        Me.EstateID.Name = "EstateID"
        Me.EstateID.ReadOnly = True
        Me.EstateID.Visible = False
        Me.EstateID.Width = 80
        '
        'LedgerNo
        '
        Me.LedgerNo.DataPropertyName = "LedgerNo"
        Me.LedgerNo.HeaderText = "Ledger Number"
        Me.LedgerNo.Name = "LedgerNo"
        Me.LedgerNo.ReadOnly = True
        Me.LedgerNo.Width = 119
        '
        'Description
        '
        Me.Description.DataPropertyName = "LedgerDescp"
        Me.Description.HeaderText = "Ledger Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 138
        '
        'BatchTotal
        '
        Me.BatchTotal.DataPropertyName = "AccBatchTotal"
        Me.BatchTotal.HeaderText = "Batch Total"
        Me.BatchTotal.Name = "BatchTotal"
        Me.BatchTotal.ReadOnly = True
        Me.BatchTotal.Width = 95
        '
        'LedgerSetupID
        '
        Me.LedgerSetupID.DataPropertyName = "LedgerSetUpID"
        Me.LedgerSetupID.HeaderText = "LedgerSetupId"
        Me.LedgerSetupID.Name = "LedgerSetupID"
        Me.LedgerSetupID.ReadOnly = True
        Me.LedgerSetupID.Visible = False
        Me.LedgerSetupID.Width = 115
        '
        'Approved
        '
        Me.Approved.DataPropertyName = "Approved"
        Me.Approved.HeaderText = "Approved"
        Me.Approved.Name = "Approved"
        Me.Approved.ReadOnly = True
        Me.Approved.Visible = False
        Me.Approved.Width = 86
        '
        'ActiveMonthYearId
        '
        Me.ActiveMonthYearId.DataPropertyName = "ActiveMonthYearId"
        Me.ActiveMonthYearId.HeaderText = "ActiveMonthYearId"
        Me.ActiveMonthYearId.Name = "ActiveMonthYearId"
        Me.ActiveMonthYearId.ReadOnly = True
        Me.ActiveMonthYearId.Visible = False
        Me.ActiveMonthYearId.Width = 138
        '
        'AccBatchID
        '
        Me.AccBatchID.DataPropertyName = "AccBatchID"
        Me.AccBatchID.HeaderText = "AccBatchID"
        Me.AccBatchID.Name = "AccBatchID"
        Me.AccBatchID.ReadOnly = True
        Me.AccBatchID.Visible = False
        Me.AccBatchID.Width = 97
        '
        'RecuringJournal
        '
        Me.RecuringJournal.DataPropertyName = "RecuringJournal"
        Me.RecuringJournal.HeaderText = "RecuringJournal"
        Me.RecuringJournal.Name = "RecuringJournal"
        Me.RecuringJournal.ReadOnly = True
        Me.RecuringJournal.Visible = False
        Me.RecuringJournal.Width = 122
        '
        'AccountBatchFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1019, 621)
        Me.Controls.Add(Me.tcAccountBatchView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AccountBatchFrm"
        Me.tcAccountBatchView.ResumeLayout(False)
        Me.tbAccountBatch.ResumeLayout(False)
        Me.gbLedgerBatch.ResumeLayout(False)
        Me.gbLedgerBatch.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.tbAccountBatchView.ResumeLayout(False)
        Me.plIPRView.ResumeLayout(False)
        Me.plIPRView.PerformLayout()
        CType(Me.dgBatchDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAccountBatchDetail.ResumeLayout(False)
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcAccountBatchView As System.Windows.Forms.TabControl
    Friend WithEvents tbAccountBatch As System.Windows.Forms.TabPage
    Friend WithEvents gbLedgerBatch As System.Windows.Forms.GroupBox
    Friend WithEvents lblColon4 As System.Windows.Forms.Label
    Friend WithEvents lblColon2 As System.Windows.Forms.Label
    Friend WithEvents lblColon3 As System.Windows.Forms.Label
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents chkRecurringJournals As System.Windows.Forms.CheckBox
    Friend WithEvents txtBatchTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtLedgerNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtLedgerType As System.Windows.Forms.TextBox
    Friend WithEvents lblBatchTotal As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblLedgerNo As System.Windows.Forms.Label
    Friend WithEvents lblLedgerType As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tbAccountBatchView As System.Windows.Forms.TabPage
    Friend WithEvents plIPRView As System.Windows.Forms.Panel
    Friend WithEvents pnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblviewAccBatchSearchBy As System.Windows.Forms.Label
    Friend WithEvents lblviewLedgerno As System.Windows.Forms.Label
    Friend WithEvents btnviewAccountBatchReport As System.Windows.Forms.Button
    Friend WithEvents txtviewLedgerNo As System.Windows.Forms.TextBox
    Friend WithEvents btnviewAccountBatchSearch As System.Windows.Forms.Button
    Friend WithEvents dgBatchDetails As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAccountBatchDetail As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtviewLedgerType As System.Windows.Forms.TextBox
    Friend WithEvents lblviewLedgerType As System.Windows.Forms.Label
    Friend WithEvents btnLookUp As System.Windows.Forms.Button
    Friend WithEvents lblNoRecordFound As System.Windows.Forms.Label
    Friend WithEvents LedgerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Expr1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LedgerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LedgerSetupID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approved As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActiveMonthYearId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccBatchID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecuringJournal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
